Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Public Class Homepage

    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem.Click
        StudentRecords.Show()
    End Sub

    Private Sub StaffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffToolStripMenuItem.Click
        StaffRecords.Show()
    End Sub

    Private Sub ComplainsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ComplainsToolStripMenuItem1.Click
        ComplainsMaintenance.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel1.DisplayRectangle, Color.White, ButtonBorderStyle.Dashed)
    End Sub

    Private Sub btnPortal_Click(sender As Object, e As EventArgs) Handles btnPortal.Click
        HallAssistant.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        StudentRegistration.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UserRegistration.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        StaffRegistration.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim result As Integer
        result = MessageBox.Show("Sure You Want To Exit", "Exiting...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersToolStripMenuItem.Click
        UserRecords.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        login.Show()
        Me.Close()
    End Sub

    Private Sub SetAmountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetAmountToolStripMenuItem.Click
        If Not SetAmount() Then
            SetAmount()
        End If
    End Sub
    Private Function SetAmount() As Boolean
        Dim result As String = InputBox("Please Enter Current Hostel Fee", "Amount Setting", CStr(My.Settings.Amount))
        If Not result = "" Then
            My.Settings.Amount = CDbl(result)
            Return True
        Else
            MessageBox.Show("Please Enter Amount", "Amount Setting")
            Return False
        End If
    End Function

    Private Sub Button_Hover(sender As Button, e As EventArgs) Handles btnPortal.MouseHover, Button1.MouseHover, Button2.MouseHover, Button3.MouseHover, Button4.MouseHover
        sender.BackColor = Color.White
        sender.ForeColor = Color.FromArgb(0, 64, 64)
    End Sub
    Private Sub Button_Leave(sender As Button, e As EventArgs) Handles btnPortal.MouseLeave, Button1.MouseLeave, Button2.MouseLeave, Button3.MouseLeave, Button4.MouseLeave
        sender.BackColor = Color.FromArgb(0, 64, 64)
        sender.ForeColor = Color.White
    End Sub


    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        Dim userManual As New Word.Application
        userManual.Visible = True
        userManual.Documents.Open("C:\Users\mora\Desktop\HMS_2\HMS\HMS\Resources\User Manual.docx", , , True)
    End Sub

    Private Sub KeyLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeyLogToolStripMenuItem.Click
        keyLog.Show()
    End Sub


    Private Sub Homepage_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        My.Settings.Username = Nothing
    End Sub

    Private Sub FullToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnFullBackup.Click
        SaveFileDialog1.FileName = "GETFund.bak"
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Try
            Dim con As New SqlConnection(My.Settings.HMSDBConnectionString)
            con.Open()
            Dim query As New SqlCommand
            query.CommandType = CommandType.Text
            query.Connection = con
            query.CommandText = "BACKUP DATABASE HMSDB TO Disk= '" & SaveFileDialog1.FileName & "'"

            If query.ExecuteNonQuery Then
                MessageBox.Show("Full Backup of 'HMSDB' complete", "Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DisableRoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableRoomToolStripMenuItem.Click
        Setting.Show()
    End Sub

    Private Sub Homepage_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Setting.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
