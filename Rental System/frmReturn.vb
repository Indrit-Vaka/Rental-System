Imports MySql.Data.MySqlClient
Public Class frmReturn

    Dim _id, _cid, _transaction, _fullname, _plateno, _ddue, _rent As String
    Sub LoadRental()
        DataGridView1.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("Select * from qrental where status like 'Borrowed' and fullname like '" & txtsearch.text & "%'", cn)
        dr = cm.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr.Item("id"), dr.Item("transno"), dr.Item("cid"), dr.Item("fullname"), dr.Item("plateno"), Format(dr.Item("dborrowed"), "MMM-dd-yyyy"), Format(dr.Item("dreturned"), "MMM-dd-yyyy"), Format(dr.Item("rental"), "#,##0.00"))
        End While
        dr.Close()
        cn.Close()
    End Sub

    Private Sub Panel2_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        LoadRental()
    End Sub

    Private Sub txtSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearch.TextChanged
        LoadRental()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As System.EventArgs) Handles DataGridView1.Click
        Try
            lblCustomer.Text = _fullname
            lblDateDue.Text = _ddue
            lblDateReturn.Text = Now.Date.ToString("MMM-dd-yyyy")
            lblDue.Text = DateDiff("d", lblDateDue.Text, lblDateReturn.Text)
            lblPlate.Text = _plateno
            lblTransNo.Text = _transaction
            lblRent.Text = _rent
            lblTotal.Text = CDbl(lblRent.Text) * CDbl(lblDue.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        _id = DataGridView1.Item(0, i).Value
        _transaction = DataGridView1.Item(1, i).Value
        _cid = DataGridView1.Item(2, i).Value
        _fullname = DataGridView1.Item(3, i).Value
        _plateno = DataGridView1.Item(4, i).Value
        _ddue = DataGridView1.Item(6, i).Value
        _rent = DataGridView1.Item(7, i).Value
    End Sub

    Private Sub txtCash_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCash.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtCash_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCash.TextChanged
        GetChange()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Dispose()
    End Sub

    Sub GetChange()
        Try
            If CDbl(txtCash.Text) >= CDbl(lblTotal.Text) Then
                lblChange.Text = Format(CDbl(txtCash.Text) - CDbl(lblTotal.Text), "#,##0.00")
            End If
        Catch ex As Exception
            lblChange.Text = "0.00"
        End Try

    End Sub

    Private Sub lblRent_Click(sender As System.Object, e As System.EventArgs) Handles lblRent.Click

    End Sub

    Private Sub lblRent_TextChanged(sender As Object, e As System.EventArgs) Handles lblRent.TextChanged
       
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If IS_EMPTY(txtCash) = True Then Return
            If CDbl(lblDue.Text) > 0 And CDbl(txtCash.Text) < CDbl(lblTotal.Text) Then
                MsgBox("Insuffecient cash.", vbExclamation)
                Return
            Else
                Dim sdate As String = Now.Date.ToString("yyyy-MM-dd")
                cn.Open()
                cm = New MySqlCommand("insert into tblpayment(transno, name, cash, sdate) values('" & lblTransNo.Text & "','" & lblCustomer.Text & "','" & CDbl(txtCash.Text) & "','" & sdate & "')", cn)
                cm.ExecuteNonQuery()
                cn.Close()

                cn.Open()
                cm = New MySqlCommand("update tblrent set status = 'Returned' where id like '" & _id & "'", cn)
                cm.ExecuteNonQuery()
                cn.Close()

                cn.Open()
                cm = New MySqlCommand("update tblmotor set status = 'Available' where plate like '" & lblPlate.Text & "'", cn)
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Payment successfully saved.", vbInformation)


                lblCustomer.Text = ""
                lblPlate.Text = ""
                lblTransNo.Text = ""
                lblDateReturn.Text = Now.Date.ToString("MMM-dd-yyyy")
                lblDue.Text = "0"
                lblRent.Text = "0.00"
                lblTotal.Text = "0.00"

            End If

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub lblDue_Click(sender As System.Object, e As System.EventArgs) Handles lblDue.Click

    End Sub

    Private Sub lblDue_TextChanged(sender As Object, e As System.EventArgs) Handles lblDue.TextChanged
        If CDbl(lblDue.Text) > 0 Then
            txtCash.Enabled = True
            txtCash.Text = "0"
        Else
            txtCash.Text = "0"
            txtCash.Enabled = False
        End If
    End Sub
End Class