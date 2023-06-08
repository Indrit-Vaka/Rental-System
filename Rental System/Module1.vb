Imports MySql.Data.MySqlClient
Module Module1
    Public cn As New MySqlConnection
    Public cm As New MySqlCommand
    Public dr As MySqlDataReader

    Sub Connection()
        With cn
            .ConnectionString = "server=localhost;user id=root;password=password;database=rentaldb;"
            .Open()
            .Close()
        End With
    End Sub

    Public Function IS_EMPTY(ByRef sText As Object) As Boolean
        On Error Resume Next
        If sText.Text = "" Then
            IS_EMPTY = True
            MsgBox("Kujdes: Nje fushe e kerkuar mungon.", vbExclamation)
            sText.BackColor = Color.LemonChiffon
            sText.SetFocus()
        Else
            IS_EMPTY = False
            sText.BackColor = Color.White
        End If
        Return IS_EMPTY
    End Function

End Module
