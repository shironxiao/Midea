<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigPage
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.lblUserId = New System.Windows.Forms.Label()
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblDatabase = New System.Windows.Forms.Label()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.lblLoginUser = New System.Windows.Forms.Label()
        Me.txtLoginUser = New System.Windows.Forms.TextBox()
        Me.lblLoginPass = New System.Windows.Forms.Label()
        Me.txtLoginPass = New System.Windows.Forms.TextBox()
        Me.btnLoginSubmit = New System.Windows.Forms.Button()
        Me.lblLoginHeader = New System.Windows.Forms.Label()
        Me.btnLoginBack = New System.Windows.Forms.Button()
        Me.pnlCard = New System.Windows.Forms.Panel()
        Me.pnlCard.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(36, 42)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(41, 13)
        Me.lblServer.TabIndex = 0
        Me.lblServer.Text = "Server:"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(111, 39)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(189, 20)
        Me.txtServer.TabIndex = 1
        '
        'lblUserId
        '
        Me.lblUserId.AutoSize = True
        Me.lblUserId.Location = New System.Drawing.Point(36, 81)
        Me.lblUserId.Name = "lblUserId"
        Me.lblUserId.Size = New System.Drawing.Size(46, 13)
        Me.lblUserId.TabIndex = 2
        Me.lblUserId.Text = "User ID:"
        '
        'txtUserId
        '
        Me.txtUserId.Location = New System.Drawing.Point(111, 78)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(189, 20)
        Me.txtUserId.TabIndex = 3
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(36, 120)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(56, 13)
        Me.lblPassword.TabIndex = 4
        Me.lblPassword.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(111, 117)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(189, 20)
        Me.txtPassword.TabIndex = 5
        '
        'lblDatabase
        '
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.Location = New System.Drawing.Point(36, 159)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(56, 13)
        Me.lblDatabase.TabIndex = 6
        Me.lblDatabase.Text = "Database:"
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(111, 156)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(189, 20)
        Me.txtDatabase.TabIndex = 7
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(225, 240)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(144, 240)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(39, 240)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(99, 23)
        Me.btnTest.TabIndex = 10
        Me.btnTest.Text = "Test Connection"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(36, 198)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(29, 13)
        Me.lblPort.TabIndex = 18
        Me.lblPort.Text = "Port:"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(111, 195)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(189, 20)
        Me.txtPort.TabIndex = 19
        Me.txtPort.Text = "3306"
        '
        'lblLoginUser
        '
        Me.lblLoginUser.AutoSize = True
        Me.lblLoginUser.Location = New System.Drawing.Point(36, 80)
        Me.lblLoginUser.Name = "lblLoginUser"
        Me.lblLoginUser.Size = New System.Drawing.Size(58, 13)
        Me.lblLoginUser.TabIndex = 11
        Me.lblLoginUser.Text = "Username:"
        Me.lblLoginUser.Visible = False
        '
        'txtLoginUser
        '
        Me.txtLoginUser.Location = New System.Drawing.Point(111, 77)
        Me.txtLoginUser.Name = "txtLoginUser"
        Me.txtLoginUser.Size = New System.Drawing.Size(189, 20)
        Me.txtLoginUser.TabIndex = 12
        Me.txtLoginUser.Visible = False
        '
        'lblLoginPass
        '
        Me.lblLoginPass.AutoSize = True
        Me.lblLoginPass.Location = New System.Drawing.Point(36, 120)
        Me.lblLoginPass.Name = "lblLoginPass"
        Me.lblLoginPass.Size = New System.Drawing.Size(56, 13)
        Me.lblLoginPass.TabIndex = 13
        Me.lblLoginPass.Text = "Password:"
        Me.lblLoginPass.Visible = False
        '
        'txtLoginPass
        '
        Me.txtLoginPass.Location = New System.Drawing.Point(111, 117)
        Me.txtLoginPass.Name = "txtLoginPass"
        Me.txtLoginPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtLoginPass.Size = New System.Drawing.Size(189, 20)
        Me.txtLoginPass.TabIndex = 14
        Me.txtLoginPass.Visible = False
        '
        'btnLoginSubmit
        '
        Me.btnLoginSubmit.Location = New System.Drawing.Point(225, 160)
        Me.btnLoginSubmit.Name = "btnLoginSubmit"
        Me.btnLoginSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnLoginSubmit.TabIndex = 15
        Me.btnLoginSubmit.Text = "Login"
        Me.btnLoginSubmit.UseVisualStyleBackColor = True
        Me.btnLoginSubmit.Visible = False
        '
        'btnLoginBack
        '
        Me.btnLoginBack.Location = New System.Drawing.Point(144, 160)
        Me.btnLoginBack.Name = "btnLoginBack"
        Me.btnLoginBack.Size = New System.Drawing.Size(75, 23)
        Me.btnLoginBack.TabIndex = 17
        Me.btnLoginBack.Text = "Back"
        Me.btnLoginBack.UseVisualStyleBackColor = True
        Me.btnLoginBack.Visible = False
        '
        'lblLoginHeader
        '
        Me.lblLoginHeader.AutoSize = True
        Me.lblLoginHeader.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblLoginHeader.Location = New System.Drawing.Point(36, 10)
        Me.lblLoginHeader.Name = "lblLoginHeader"
        Me.lblLoginHeader.Size = New System.Drawing.Size(70, 30)
        Me.lblLoginHeader.TabIndex = 16
        Me.lblLoginHeader.Text = "Login"
        Me.lblLoginHeader.Visible = False
        '
        'pnlCard
        '
        Me.pnlCard.BackColor = System.Drawing.Color.White
        Me.pnlCard.Controls.Add(Me.lblLoginHeader)
        Me.pnlCard.Controls.Add(Me.lblServer)
        Me.pnlCard.Controls.Add(Me.txtServer)
        Me.pnlCard.Controls.Add(Me.lblUserId)
        Me.pnlCard.Controls.Add(Me.txtUserId)
        Me.pnlCard.Controls.Add(Me.lblPassword)
        Me.pnlCard.Controls.Add(Me.txtPassword)
        Me.pnlCard.Controls.Add(Me.lblDatabase)
        Me.pnlCard.Controls.Add(Me.txtDatabase)
        Me.pnlCard.Controls.Add(Me.btnSave)
        Me.pnlCard.Controls.Add(Me.btnCancel)
        Me.pnlCard.Controls.Add(Me.btnTest)
        Me.pnlCard.Controls.Add(Me.lblLoginUser)
        Me.pnlCard.Controls.Add(Me.txtLoginUser)
        Me.pnlCard.Controls.Add(Me.lblLoginPass)
        Me.pnlCard.Controls.Add(Me.txtLoginPass)
        Me.pnlCard.Controls.Add(Me.btnLoginSubmit)
        Me.pnlCard.Controls.Add(Me.btnLoginBack)
        Me.pnlCard.Controls.Add(Me.lblPort)
        Me.pnlCard.Controls.Add(Me.txtPort)
        Me.pnlCard.Location = New System.Drawing.Point(0, 0)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.Size = New System.Drawing.Size(341, 290)
        Me.pnlCard.TabIndex = 16
        '
        'ConfigPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add(Me.pnlCard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.Name = "ConfigPage"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Server Configuration"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ControlBox = True
        Me.MinimizeBox = True
        Me.MaximizeBox = True
        Me.pnlCard.ResumeLayout(False)
        Me.pnlCard.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents lblUserId As System.Windows.Forms.Label
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblDatabase As System.Windows.Forms.Label
    Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents lblLoginUser As System.Windows.Forms.Label
    Friend WithEvents txtLoginUser As System.Windows.Forms.TextBox
    Friend WithEvents lblLoginPass As System.Windows.Forms.Label
    Friend WithEvents txtLoginPass As System.Windows.Forms.TextBox
    Friend WithEvents btnLoginSubmit As System.Windows.Forms.Button
    Friend WithEvents lblLoginHeader As System.Windows.Forms.Label
    Friend WithEvents btnLoginBack As System.Windows.Forms.Button
    Friend WithEvents pnlCard As System.Windows.Forms.Panel
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
End Class