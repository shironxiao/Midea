Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Module MideaProShopModule

    Public conn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public dr As MySqlDataReader
    Public da As MySqlDataAdapter
    Public dt As New DataTable

    Public connectionString As String = "server=localhost;userid=root;password=;database=mideaproshop;"
    Public Server As String = "localhost"
    Public UserId As String = "root"
    Public Password As String = ""
    Public Database As String = "mideaproshop"
    Public Port As String = "3306"
    Public CurrentUserRole As String = ""
    Public CurrentUserPassword As String = ""
    Private configLoaded As Boolean = False

    Public Sub LoadConfig()
        Dim configPath As String = System.IO.Path.Combine(Application.StartupPath, "db_config.txt")
        If System.IO.File.Exists(configPath) Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(configPath)
                If lines.Length >= 4 Then
                    Server = lines(0)
                    UserId = lines(1)
                    Password = lines(2)
                    Database = lines(3)
                    If lines.Length >= 5 Then
                        Port = lines(4)
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
        connectionString = $"server={Server};userid={UserId};password={Password};database={Database};port={Port};"
        configLoaded = True
    End Sub

    Public Sub SaveConfig(newServer As String, newUserId As String, newPassword As String, newDatabase As String, newPort As String)
        Server = newServer
        UserId = newUserId
        Password = newPassword
        Database = newDatabase
        Port = newPort
        connectionString = $"server={Server};userid={UserId};password={Password};database={Database};port={Port};"
        
        Dim configPath As String = System.IO.Path.Combine(Application.StartupPath, "db_config.txt")
        Try
            System.IO.File.WriteAllLines(configPath, {Server, UserId, Password, Database, Port})
        Catch ex As Exception
            MessageBox.Show("Error saving config: " & ex.Message)
        End Try
    End Sub

    ' Function to Open Connection
    Public Sub OpenConnection()
        Try
            If Not configLoaded Then LoadConfig()
            If conn.State = ConnectionState.Closed Then
                conn.ConnectionString = connectionString
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Connection Failed: " & ex.Message)
        End Try
    End Sub

    ' Function to Close Connection
    Public Sub CloseConnection()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error Closing Connection: " & ex.Message)
        End Try
    End Sub

    Public Function HashPassword(password As String) As String
        Using sha256Hash As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()
            For i As Integer = 0 To bytes.Length - 1
                builder.Append(bytes(i).ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

End Module