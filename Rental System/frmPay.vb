Imports MySql.Data.MySqlClient
Public Class frmPay

    Private Sub txtCash_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCash.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtCash_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCash.TextChanged
        GetChange()
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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If CDbl(txtCash.Text) < CDbl(lblTotal.Text) Then
            MsgBox("Insuffecient cash.", vbExclamation)
            Return
        Else
            If MsgBox("Accept Payment?", vbYesNo + vbQuestion) = vbYes Then
                Dim sdate As String = Now.Date.ToString("yyyy-MM-dd")
                cn.Open()
                cm = New MySqlCommand("insert into tblpayment(transno, name, cash, sdate) values('" & lblTransNo.Text & "','" & lblName.Text & "','" & CDbl(txtCash.Text) & "','" & sdate & "')", cn)
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Payment successfully saved.", vbInformation)

                txtCash.Text = "0"
                lblTotal.Text = "0"
                Me.Dispose()
                frmRental.LoadAutoNo()
                frmRental.txtCustomer.Clear()
                frmRental.txtPlateNo.Clear()
                frmRental.LoadCart()
            End If
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Dispose()
    End Sub
End Class