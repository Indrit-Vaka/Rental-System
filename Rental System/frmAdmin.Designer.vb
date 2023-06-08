<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFullname = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtBdate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboID = New System.Windows.Forms.ComboBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(661, 3)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Emri i plote :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFullname
        '
        Me.txtFullname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFullname.Location = New System.Drawing.Point(155, 53)
        Me.txtFullname.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFullname.Name = "txtFullname"
        Me.txtFullname.Size = New System.Drawing.Size(477, 23)
        Me.txtFullname.TabIndex = 2
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(155, 84)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAddress.Size = New System.Drawing.Size(477, 23)
        Me.txtAddress.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 32)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Adresa :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 28)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Datelindja :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtContact
        '
        Me.txtContact.Location = New System.Drawing.Point(155, 146)
        Me.txtContact.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(477, 23)
        Me.txtContact.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 29)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Nr kontaktit :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtBdate
        '
        Me.dtBdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtBdate.Location = New System.Drawing.Point(155, 115)
        Me.dtBdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtBdate.Name = "dtBdate"
        Me.dtBdate.Size = New System.Drawing.Size(477, 23)
        Me.dtBdate.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 28)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Tipi ID :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboID
        '
        Me.cboID.FormattingEnabled = True
        Me.cboID.Items.AddRange(New Object() {"Company", "Driver License", "SSS", "TIN", "School", "Others"})
        Me.cboID.Location = New System.Drawing.Point(155, 177)
        Me.cboID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboID.Name = "cboID"
        Me.cboID.Size = New System.Drawing.Size(477, 23)
        Me.cboID.TabIndex = 11
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(155, 208)
        Me.txtID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(477, 23)
        Me.txtID.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(15, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 31)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Nr identifikimit :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Gray
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(341, 248)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(92, 33)
        Me.Button3.TabIndex = 17
        Me.Button3.Text = "Fshi"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(248, 248)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(92, 33)
        Me.btnUpdate.TabIndex = 16
        Me.btnUpdate.Text = "Rifresko"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(104, 51)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(0, 15)
        Me.lblID.TabIndex = 18
        Me.lblID.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(584, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 17)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "[ Mbyll ]"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(12, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(111, 17)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Modifiko te dhenat e Adminit"
        '
        'frmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 304)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtBdate)
        Me.Controls.Add(Me.txtContact)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFullname)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAdmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFullname As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtBdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboID As System.Windows.Forms.ComboBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label14 As Label
End Class
