Imports MySql.Data.MySqlClient
Public Class frmTransactionLog
    
    Private Sub frmTransactionLog_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
        LoadTransactionLog()
    End Sub
    Sub LoadTransactionLog()
        Dim sdate1 As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim sdate2 As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")
        Dim income As Double
        DataGridView1.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from qrental where dborrowed between '" & sdate1 & "' and '" & sdate2 & "'", cn)
        dr = cm.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr.Item("transno"), dr.Item("fullname"), dr.Item("plateno"), Format(dr.Item("rentalpay"), "#,##0.00"), dr.Item("status"), Format(dr.Item("dborrowed"), "MMM-dd-yyyy"))
        End While
        dr.Close()
        cn.Close()
    End Sub

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        LoadTransactionLog()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Dispose()
    End Sub
End Class