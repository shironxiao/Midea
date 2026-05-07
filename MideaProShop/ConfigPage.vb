Imports MySql.Data.MySqlClient

Public Class ConfigPage

    Private Sub ConfigPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MideaProShopModule.LoadConfig()
        txtServer.Text = MideaProShopModule.Server
        txtUserId.Text = MideaProShopModule.UserId
        txtPassword.Text = MideaProShopModule.Password
        txtDatabase.Text = MideaProShopModule.Database
        txtPort.Text = MideaProShopModule.Port
        CenterCard()
        ShowLoginPanel() ' Start with login form first
    End Sub

    Private Sub ConfigPage_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        CenterCard()
    End Sub

    Private Sub CenterCard()
        If pnlCard IsNot Nothing Then
            pnlCard.Left = (Me.ClientSize.Width - pnlCard.Width) \ 2
            pnlCard.Top = (Me.ClientSize.Height - pnlCard.Height) \ 2
        End If
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        Dim testConnectionString As String = $"server={txtServer.Text};userid={txtUserId.Text};password={txtPassword.Text};database={txtDatabase.Text};port={txtPort.Text};"
        Try
            Using testConn As New MySqlConnection(testConnectionString)
                testConn.Open()
                MessageBox.Show("Connection successful!", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("Connection failed: " & ex.Message, "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim testConnectionString As String = $"server={txtServer.Text};userid={txtUserId.Text};password={txtPassword.Text};database={txtDatabase.Text};port={txtPort.Text};"
        
        Try
            ' Test connection before saving
            Using testConn As New MySqlConnection(testConnectionString)
                testConn.Open()
                ' If successful, save and show login
                MideaProShopModule.SaveConfig(txtServer.Text, txtUserId.Text, txtPassword.Text, txtDatabase.Text, txtPort.Text)
                MessageBox.Show("Configuration verified and saved successfully.", "Save Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ShowLoginPanel()
            End Using
        Catch ex As Exception
            MessageBox.Show("Cannot save configuration. Connection failed: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Stay on the config page to allow fixes
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ShowLoginPanel()
        ' Hide all config controls
        lblServer.Visible = False
        txtServer.Visible = False
        lblUserId.Visible = False
        txtUserId.Visible = False
        lblPassword.Visible = False
        txtPassword.Visible = False
        lblDatabase.Visible = False
        txtDatabase.Visible = False
        btnSave.Visible = False
        btnTest.Visible = False
        btnCancel.Visible = False
        lblPort.Visible = False
        txtPort.Visible = False

        ' Show login controls
        lblLoginHeader.Visible = True
        lblLoginUser.Visible = True
        txtLoginUser.Visible = True
        lblLoginPass.Visible = True
        txtLoginPass.Visible = True
        btnLoginSubmit.Visible = True
        btnLoginBack.Visible = True

        Me.Text = "Midea Pro Shop - Login"
        btnLoginBack.Text = "Server Settings" ' Rename back button to settings toggle
        txtLoginUser.Clear()
        txtLoginPass.Clear()
        txtLoginUser.Focus()
    End Sub

    Private Sub btnLoginSubmit_Click(sender As Object, e As EventArgs) Handles btnLoginSubmit.Click
        Dim username As String = txtLoginUser.Text.Trim()
        Dim password As String = txtLoginPass.Text

        If (username = "admin" AndAlso password = "admin123") OrElse
           (username = "user" AndAlso password = "user123") Then
            
            ' Store the user role and password for permission handling and verification
            MideaProShopModule.CurrentUserRole = username
            MideaProShopModule.CurrentUserPassword = password
            
            ' Open the main dashboard
            Dim mainForm As New MDIMainForm()
            mainForm.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLoginPass.Clear()
            txtLoginUser.Focus()
        End If
    End Sub

    Private Sub ShowConfigPanel()
        ' Show all config controls
        lblServer.Visible = True
        txtServer.Visible = True
        lblUserId.Visible = True
        txtUserId.Visible = True
        lblPassword.Visible = True
        txtPassword.Visible = True
        lblDatabase.Visible = True
        txtDatabase.Visible = True
        btnSave.Visible = True
        btnTest.Visible = True
        btnCancel.Visible = True
        lblPort.Visible = True
        txtPort.Visible = True

        ' Hide login controls
        lblLoginHeader.Visible = False
        lblLoginUser.Visible = False
        txtLoginUser.Visible = False
        lblLoginPass.Visible = False
        txtLoginPass.Visible = False
        btnLoginSubmit.Visible = False
        btnLoginBack.Visible = False

        Me.Text = "Server Configuration"
    End Sub

    Private Sub btnLoginBack_Click(sender As Object, e As EventArgs) Handles btnLoginBack.Click
        ShowConfigPanel()
    End Sub

End Class