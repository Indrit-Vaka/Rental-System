Imports MySql.Data.MySqlClient

Public Class frmAdmin

    Public Event FullNameUpdated As EventHandler(Of String)
    Private Sub frmAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sdate As String = dtBdate.Value.ToString("yyyy-MM-dd")
        cn.Open()
        Dim query As String = "SELECT * FROM tbladmin LIMIT 1"
        Using command As New MySqlCommand(query, cn)
            Using reader As MySqlDataReader = command.ExecuteReader()
                If reader.Read() Then
                    txtFullname.Text = reader.GetString("fullname")
                    txtAddress.Text = reader.GetString("address")
                    dtBdate.Value = reader.GetDateTime("bdate")
                    txtContact.Text = reader.GetString("contact")
                    cboID.SelectedItem = reader.GetString("idtype")
                    txtID.Text = reader.GetString("idno")
                End If
            End Using
        End Using

        cn.Close()

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Dispose()
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

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        cn.Open()

        Dim query As String = "UPDATE tbladmin SET fullname = @fullname, address = @address, bdate = @bdate, contact = @contact, idtype = @idtype, idno = @idno WHERE id = @id"

        Using command As New MySqlCommand(query, cn)
            command.Parameters.AddWithValue("@fullname", txtFullname.Text)
            command.Parameters.AddWithValue("@address", txtAddress.Text)
            command.Parameters.AddWithValue("@bdate", dtBdate.Value.ToString("yyyy-MM-dd"))
            command.Parameters.AddWithValue("@contact", txtContact.Text)
            command.Parameters.AddWithValue("@idtype", cboID.SelectedItem.ToString())
            command.Parameters.AddWithValue("@idno", txtID.Text)
            command.Parameters.AddWithValue("@id", 1)
            command.ExecuteNonQuery()
        End Using


        Dim fullName As String = txtFullname.Text
        RaiseEvent FullNameUpdated(Me, fullName)

        MessageBox.Show("Row updated successfully.")

        cn.Close()
        Me.Dispose()
    End Sub
End Class