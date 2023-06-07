Imports MySql.Data.MySqlClient

Public Class frmMain

    Private adminForm As frmAdmin

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Connection()
        LoadAdmin()
    End Sub

    Sub LoadAdmin()
        cn.Open()
        cm = New MySqlCommand("SELECT fullname FROM tbladmin LIMIT 1", cn)
        Dim fullName As String = Convert.ToString(cm.ExecuteScalar())
        cn.Close()
        Label1.Text = fullName
    End Sub




    Private Sub btnRental_Click(sender As Object, e As EventArgs) Handles btnRental.Click
        With frmRental
            .LoadAutoNo()
            .AutoSuggestModule1()
            .AutoSuggestModule()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        With frmReturn
            .ShowDialog()
        End With
    End Sub

    Private Sub btnClient_Click(sender As Object, e As EventArgs) Handles btnClient.Click
        With frmCustomer
            .TopLevel = False
            Panel5.Controls.Add(frmCustomer)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnMotor_Click(sender As Object, e As EventArgs) Handles btnMotor.Click
        With frmMotorList
            .TopLevel = False
            Panel5.Controls.Add(frmMotorList)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnIncome_Click(sender As Object, e As EventArgs) Handles btnIncome.Click
        With frmIncome
            .TopLevel = False
            Panel5.Controls.Add(frmIncome)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        With frmTransactionLog
            .TopLevel = False
            Panel5.Controls.Add(frmTransactionLog)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnBrand_Click(sender As Object, e As EventArgs) Handles btnBrand.Click
        With frmBrand
            .TopLevel = False
            Panel5.Controls.Add(frmBrand)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click
        ' Check if frmAdmin is already open
        If adminForm IsNot Nothing AndAlso Not adminForm.IsDisposed Then
            adminForm.BringToFront()
        Else
            ' Create a new instance of frmAdmin
            adminForm = New frmAdmin()

            ' Handle the FullNameUpdated event
            AddHandler adminForm.FullNameUpdated, AddressOf AdminForm_FullNameUpdated

            ' Set the parent control and show the form
            adminForm.TopLevel = False
            Panel5.Controls.Add(adminForm)
            adminForm.BringToFront()
            adminForm.Show()
        End If
    End Sub

    Private Sub AdminForm_FullNameUpdated(sender As Object, fullName As String)
        ' Update Label1.Text with the updated FullName value
        Label1.Text = fullName
    End Sub
End Class
