Imports System.Data.Sql
Public Class SplashScreen
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        RectangleShape2.Width += 2
        If RectangleShape2.Width = 400 Then
            Timer1.Stop()
        End If
    End Sub

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Creates the connectionString for the first time
        ' If My.Settings.HMSDBConnectionString = "NONE" Then
        BackgroundWorker1.RunWorkerAsync()
        'End If

    End Sub

    'Gets the First Server Instance of the user computer
    Private Function GetServer() As String

        Dim Server As String = String.Empty
        Dim instance As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance

        Try
            Dim table As System.Data.DataTable = instance.GetDataSources()
            Dim row As System.Data.DataRow = table.Rows(0)
            Server = row("ServerName")
            If row("InstanceName").ToString.Length > 0 Then
                Server = Server & "\" & row("InstanceName")
            End If
            Return Server.Trim
        Catch e As Exception
            MessageBox.Show(e.Message, "System Error")
            Return Nothing
        End Try
    End Function

    'Generates the connection String
    Private Sub NewConString(serverName As String)
        My.Settings.HMSDBConnectionString = "Data Source=" + serverName + ";Initial Catalog = GETFund;Integrated Security=True"
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        NewConString(GetServer)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If RectangleShape2.Width < 400 Then Timer1.Stop() : RectangleShape2.Width = 400
        login.Show()
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class