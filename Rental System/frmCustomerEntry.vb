Imports MySql.Data.MySqlClient
Public Class frmCustomerEntry

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If MsgBox("Save this record?", vbYesNo + vbQuestion) = vbYes Then
                Dim sdate As String = dtBdate.Value.ToString("yyyy-MM-dd")
                cn.Open()
                cm = New MySqlCommand("insert into tblcustomer (fullname, address, bdate, contact, idtype, idno) values('" & txtFullname.Text & "','" & txtAddress.Text & "','" & sdate & "','" & txtContact.Text & "','" & cboID.Text & "','" & txtID.Text & "')", cn)
                cm.ExecuteNonQuery()
                cn.Close()
                Clear()
                frmCustomer.LoadCustomer()
                MsgBox("Record has been successfully saved.", vbInformation)
            End If
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        Try
            If MsgBox("Update this record?", vbYesNo + vbQuestion) = vbYes Then
                Dim sdate As String = dtBdate.Value.ToString("yyyy-MM-dd")
                cn.Open()
                cm = New MySqlCommand("update tblcustomer  set fullname = '" & txtFullname.Text & "', address = '" & txtAddress.Text & "', bdate = '" & sdate & "', contact = '" & txtContact.Text & "', idtype = '" & cboID.Text & "', idno = '" & txtID.Text & "' where id like '" & lblID.Text & "'", cn)
                cm.ExecuteNonQuery()
                cn.Close()
                Clear()
                frmCustomer.LoadCustomer()
                MsgBox("Record has been successfully updated.", vbInformation)
                Me.Close()
            End If
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Clear()
        txtFullname.Focus()
    End Sub
    Sub Clear()
        txtAddress.Clear()
        txtContact.Clear()
        txtFullname.Clear()
        txtID.Clear()
        lblID.Text = ""
        cboID.Text = ""
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Dispose()
    End Sub
End Class