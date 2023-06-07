Imports MySql.Data.MySqlClient
Public Class frmBrand
    Dim _brand As String
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If IS_EMPTY(txtBrand) = True Then Return
            cn.Open()
            cm = New MySqlCommand("insert into tblbrand values('" & txtBrand.Text & "')", cn)
            cm.ExecuteNonQuery()
            cn.Close()
            MsgBox("Record saved.", vbInformation)
            LoadBrand()
            txtBrand.Clear()
            txtBrand.Focus()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub frmBrand_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadBrand()
    End Sub
    Sub LoadBrand()
        DataGridView1.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblbrand", cn)
        dr = cm.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr.Item("brand"))
        End While
        dr.Close()
        cn.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As System.EventArgs) Handles DataGridView1.Click
        txtBrand.Text = _brand
        btnSave.Enabled = False
        btnDelete.Enabled = True
        btnUpdate.Enabled = True
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        _brand = DataGridView1.Item(0, i).Value
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        txtBrand.Clear()
        txtBrand.Focus()
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        Try
            If IS_EMPTY(txtBrand) = True Then Return
            cn.Open()
            cm = New MySqlCommand("update tblbrand set brand = '" & txtBrand.Text & "' where brand like '" & _brand & "'", cn)
            cm.ExecuteNonQuery()
            cn.Close()
            MsgBox("Record updated.", vbInformation)
            LoadBrand()
            txtBrand.Clear()
            txtBrand.Focus()
            btnSave.Enabled = True
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If MsgBox("Do you want to delete " & _brand & "?", vbYesNo + vbQuestion) = vbYes Then
                cn.Open()
                cm = New MySqlCommand("delete from tblbrand where brand like '" & _brand & "'", cn)
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Record deleted.", vbInformation)
                LoadBrand()
                txtBrand.Clear()
                txtBrand.Focus()
                btnSave.Enabled = True
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
            End If
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Dispose()
    End Sub
End Class