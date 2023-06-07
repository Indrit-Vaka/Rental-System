Imports MySql.Data.MySqlClient
Public Class frmIncome

    Private Sub frmIncome_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
        LoadIncome()
    End Sub

    Sub LoadIncome()
        Dim sdate1 As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim sdate2 As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")
        Dim income As Double
        DataGridView1.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblpayment where cash > 0 and sdate between '" & sdate1 & "' and '" & sdate2 & "'", cn)
        dr = cm.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr.Item("transno"), dr.Item("name"), Format(dr.Item("cash"), "#,##0.00"), Format(dr.Item("sdate"), "MMM-dd-yyyy"))
            income += CDbl(dr.Item("cash"))
        End While
        dr.Close()
        cn.Close()
        lblIncome.Text = Format(income, "#,##0.00")
    End Sub

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        LoadIncome()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Dispose()
    End Sub
End Class