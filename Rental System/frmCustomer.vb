Imports MySql.Data.MySqlClient
Public Class frmCustomer
    Dim _id, _fullname, _address, _bdate, _contact, _idtype, _idno As String
    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        With frmCustomerEntry
            .btnSave.Enabled = True
            .btnUpdate.Enabled = False
            .ShowDialog()
        End With
    End Sub

    Private Sub frmCustomer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadCustomer()
    End Sub

    Sub LoadCustomer()
        DataGridView1.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("Select * from tblcustomer where fullname like '" & txtSearch.Text & "%'", cn)
        dr = cm.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr.Item("id"), dr.Item("fullname"), dr.Item("address"), Format(dr.Item("bdate"), "MMM-dd-yyyy"), dr.Item("contact"), dr.Item("idtype"), dr.Item("idno"))
        End While
        dr.Close()
        cn.Close()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        _id = DataGridView1.Item(0, i).Value
        _fullname = DataGridView1.Item(1, i).Value
        _address = DataGridView1.Item(2, i).Value
        _bdate = DataGridView1.Item(3, i).Value
        _contact = DataGridView1.Item(4, i).Value
        _idtype = DataGridView1.Item(5, i).Value
        _idno = DataGridView1.Item(6, i).Value
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        With frmCustomerEntry
            .lblID.Text = _id
            .txtFullname.Text = _fullname
            .txtAddress.Text = _address
            .dtBdate.Value = _bdate
            .txtContact.Text = _contact
            .cboID.Text = _idtype
            .txtID.Text = _idno
            .btnSave.Enabled = False
            .btnUpdate.Enabled = True
            .ShowDialog()
        End With
    End Sub

    Private Sub txtSearch_Click(sender As System.Object, e As System.EventArgs) Handles txtSearch.Click

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As System.EventArgs) Handles txtSearch.TextChanged
        LoadCustomer()
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        txtSearch.Clear()
        LoadCustomer()
    End Sub
End Class