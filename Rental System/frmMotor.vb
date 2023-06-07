Imports MySql.Data.MySqlClient
Public Class frmMotor

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try

            If MsgBox("Save this record?", vbYesNo + vbQuestion) = vbYes Then
                cn.Open()
                cm = New MySqlCommand("insert into tblmotor (plate, brand, model, color, rental) values('" & txtPlate.Text & "','" & cboBrand.Text & "','" & txtModel.Text & "','" & txtColor.Text & "','" & txtRental.Text & "')", cn)
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Record has been successfully saved.", vbInformation)
                Clear()
                frmMotorList.LoadMotor()
            End If
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Sub Clear()
        txtColor.Clear()
        txtModel.Clear()
        txtPlate.Clear()
        txtRental.Clear()
        cboBrand.Text = ""
        btnSave.Enabled = True
        btnUpdate.Enabled = True
    End Sub

    Private Sub frmMotor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadBrand()
    End Sub

    Sub LoadBrand()
        cboBrand.Items.Clear()
        cn.Open()
        cm = New MySqlCommand("Select * from tblbrand", cn)
        dr = cm.ExecuteReader
        While dr.Read
            cboBrand.Items.Add(dr.Item("brand"))
        End While
        dr.Close()
        cn.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        Try
            If MsgBox("Update this record?", vbYesNo + vbQuestion) = vbYes Then
                cn.Open()
                cm = New MySqlCommand("update tblmotor set brand = '" & cboBrand.Text & "', model ='" & txtModel.Text & "', color ='" & txtColor.Text & "', rental = '" & txtRental.Text & "' where plate like '" & txtPlate.Text & "'", cn)
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Record has been successfully updated.", vbInformation)
                Clear()
            End If
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Dispose()
    End Sub
End Class