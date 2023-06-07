Imports MySql.Data.MySqlClient
Public Class frmMotorList
    Dim _plate, _brand, _model, _color, _rental As String
    Private Sub frmMotorList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadMotor()
    End Sub

    Sub LoadMotor()
        DataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("Select * from tblMotor", cn)
        dr = cm.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr.Item("plate"), dr.Item("brand"), dr.Item("model"), dr.Item("color"), dr.Item("rental"), dr.Item("status"))
            i += 1
        End While
        dr.Close()
        cn.Close()
        lblCount.Text = i
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        With frmMotor
            .btnSave.Enabled = True
            .btnUpdate.Enabled = False
            .txtPlate.Enabled = True
            .ShowDialog()
        End With
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        _plate = DataGridView1.Item(0, i).Value
        _brand = DataGridView1.Item(1, i).Value
        _model = DataGridView1.Item(2, i).Value
        _color = DataGridView1.Item(3, i).Value
        _rental = DataGridView1.Item(4, i).Value
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        With frmMotor
            .btnSave.Enabled = False
            .txtPlate.Enabled = False
            .btnUpdate.Enabled = True
            .txtColor.Text = _color
            .txtModel.Text = _model
            .txtPlate.Text = _plate
            .txtRental.Text = _rental
            .cboBrand.Text = _brand
            .ShowDialog()
        End With
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If MsgBox("Do you want to delete thsi record?", vbYesNo + vbQuestion) = vbYes Then
                cn.Open()
                cm = New MySqlCommand("delete from tblmotor where plate like '" & _plate & "'", cn)
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Record deleted.", vbInformation)
                LoadMotor()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
End Class