Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Module MideaProShopModule

    Public conn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public dr As MySqlDataReader
    Public da As MySqlDataAdapter
    Public dt As New DataTable

    Public connectionString As String = "server=localhost;userid=root;password=;database=mideaproshop;"

    ' Function to Open Connection
    Public Sub OpenConnection()
        Try
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

End Module