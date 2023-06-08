Imports MySql.Data.MySqlClient
Public Class frmRental
    Dim _id, _plate As String
    Private Sub frmRental_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadCart()
    End Sub

    Sub LoadAutoNo()
        Dim rand = New Random
        lblTrans.Text = rand.Next(11111111, 99999999)
    End Sub

    Sub AutoSuggestModule()
        cn.Open()
        cm = New MySqlCommand("SELECT * from tblcustomer", cn)
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(cm)
        da.Fill(ds, "customer")
        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        For i = 0 To ds.Tables(0).Rows.Count - 1
            col.Add(ds.Tables(0).Rows(i)("fullname").ToString())
        Next
        cn.Close()
        txtCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtCustomer.AutoCompleteCustomSource = col
        txtCustomer.AutoCompleteMode = AutoCompleteMode.Suggest
    End Sub

    Sub AutoSuggestModule1()
        cn.Open()
        cm = New MySqlCommand("SELECT * from tblmotor where status like 'Available'", cn)
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(cm)
        da.Fill(ds, "motor")
        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        For i = 0 To ds.Tables(0).Rows.Count - 1
            col.Add(ds.Tables(0).Rows(i)("plate").ToString())
        Next
        cn.Close()
        txtPlateNo.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtPlateNo.AutoCompleteCustomSource = col
        txtPlateNo.AutoCompleteMode = AutoCompleteMode.Suggest
    End Sub

    Private Sub txtCustomer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCustomer.TextChanged
        Try
            cn.Open()
            cm = New MySqlCommand("Select * from tblcustomer where fullname like '" & txtCustomer.Text & "'", cn)
            dr = cm.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                txtID.Text = dr.Item("id").ToString
                txtName.Text = dr.Item("fullname").ToString
                txtContact.Text = dr.Item("contact").ToString
            Else
                txtID.Clear()
                txtName.Clear()
                txtContact.Clear()
            End If
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub txtPlateNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPlateNo.TextChanged
        Try
            cn.Open()
            cm = New MySqlCommand("Select * from tblmotor where plate like '" & txtPlateNo.Text & "' and status like 'Available'", cn)
            dr = cm.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                txtPlate.Text = dr.Item("plate").ToString
                txtDetails.Text = dr.Item("brand").ToString & " " & dr.Item("model").ToString & " " & dr.Item("color").ToString
                txtRate.Text = Format(CDbl(dr.Item("rental").ToString), "#,##0.00")
            End If
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub txtRate_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRate.TextChanged
        GetTotal()
    End Sub


    Sub GetTotal()
        Try
            Dim day As Integer
            day = DateDiff("d", Now.Date.ToString("MM-dd-yyyy"), DateTimePicker1.Value.ToString("MM-dd-yyyy"))
            day += 1
            lblDay.Text = day
            txtTotal.Text = Format(day * CDbl(txtRate.Text), "#,##0.00")
        Catch ex As Exception
            txtTotal.Text = "0.00"
        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        GetTotal()
    End Sub

    Private Sub btnRent_Click(sender As System.Object, e As System.EventArgs) Handles btnRent.Click
        Try
            If IS_EMPTY(txtID) = True Then Return
            If IS_EMPTY(txtPlateNo) = True Then Return
            Dim sdate1 As String = Now.Date.ToString("yyyy-MM-dd")
            Dim sdate2 As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
            Dim total As Double = txtTotal.Text
            If MsgBox("Shto per te marre me qira kete automjet??", vbYesNo + vbQuestion) = vbYes Then
                cn.Open()
                cm = New MySqlCommand("insert into tblrent (transno, cid, plateno, dborrowed, dreturned, rental, noofdays, rentalpay, remarks) values ('" & lblTrans.Text & "','" & txtID.Text & "','" & txtPlate.Text & "','" & sdate1 & "','" & sdate2 & "','" & txtRate.Text & "','" & lblDay.Text & "','" & total & "','" & txtRemarks.Text & "')", cn)
                cm.ExecuteNonQuery()

                MsgBox("Regjistrimi është shtuar me sukses.", vbInformation)
                cn.Close()
                LoadCart()

                cn.Open()
                cm = New MySqlCommand("update tblmotor set status ='Borrowed' where plate like '" & txtPlate.Text & "'", cn)
                cm.ExecuteNonQuery()
                cn.Close()

                txtPlateNo.Clear()
                txtDetails.Clear()
                txtRate.Text = "0.00"
                DateTimePicker1.Value = Now.Date

                AutoSuggestModule1()
            End If
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Sub LoadCart()
        Dim i As Integer
        Dim tot As Double
        DataGridView1.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("Select * from tblrent where transno like '" & lblTrans.Text & "'", cn)
        dr = cm.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr.Item("id").ToString, dr.Item("plateno").ToString, Format(CDbl(dr.Item("rentalpay").ToString), "#,##0.00"), Format(CDate(dr.Item("dborrowed").ToString), "MMM-dd-yyyy"), Format(CDate(dr.Item("dreturned").ToString), "MMM-dd-yyyy"))
            tot += CDbl(dr.Item("rentalpay"))
            i += 1
        End While
        dr.Close()
        cn.Close()
        lblTotal.Text = Format(tot, "#,##0.00")
        lblCount.Text = i
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        With frmPay
            .lblTransNo.Text = lblTrans.Text
            .lblName.Text = txtCustomer.Text
            .lblCount.Text = lblCount.Text
            .lblTotal.Text = lblTotal.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column3" Then
            If MsgBox("Dëshironi ta hiqni këtë artikull nga lista?", vbYesNo + vbQuestion) = vbYes Then
                cn.Open()
                cm = New MySqlCommand("delete from tblrent where id like '" & _id & "'", cn)
                cm.ExecuteNonQuery()
                cn.Close()


                cn.Open()
                cm = New MySqlCommand("update tblmotor set status = 'Available' where plate like '" & _plate & "'", cn)
                cm.ExecuteNonQuery()
                cn.Close()

                MsgBox("Regjistri u hoq me sukses nga lista.", vbInformation)
                LoadCart()

                AutoSuggestModule1()

            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        _id = DataGridView1.Item(0, i).Value
        _plate = DataGridView1.Item(1, i).Value
    End Sub
End Class