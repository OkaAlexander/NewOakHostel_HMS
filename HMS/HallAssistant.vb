Public Class HallAssistant

    Dim student As New StudentFunctions
    Dim logObj() As Object 'Gets all student objects in a room

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel1.DisplayRectangle, Color.White, ButtonBorderStyle.Solid)

    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        logObj = student.ViewRoomMembers(TextBox1, TextBox10, TextBox6, TextBox7, TextBox2, TextBox11, TextBox5, TextBox8, TextBox3, TextBox12, TextBox4, TextBox9, PictureBox1, PictureBox4, PictureBox2, PictureBox3, Button2, Button3, Button4, Button5, txtSearch.Text, Label17, GetOption(ComboBox1))
        If IsNothing(logObj) Then
            Exit Sub
        End If
        Dim keyStatus As String = student.Room.GetKeyStatus(txtSearch.Text.Trim)
        If IsNothing(keyStatus) Then
            Exit Sub
        End If
        If keyStatus = "IN" Then
            PictureBox5.Image = My.Resources.key__1_
        Else
            PictureBox5.Image = My.Resources._008_close_1
            Dim log As New keyLoggerFunctions

            If logObj(0).indexNumber = log.LastCheckOut(txtSearch.Text.Trim) Then
                PictureBox7.Visible = True
            ElseIf logObj(1).indexNumber = log.LastCheckOut(txtSearch.Text.Trim) Then
                PictureBox8.Visible = True
            ElseIf logObj(2).indexNumber = log.LastCheckOut(txtSearch.Text.Trim) Then
                PictureBox9.Visible = True
            ElseIf logObj(3).indexNumber = log.LastCheckOut(txtSearch.Text.Trim) Then
                PictureBox10.Visible = True
            End If
        End If
        Label18.Text = "ROOM " + txtSearch.Text.Trim
        Label19.Text = keyStatus
        Label19.Visible = True
        PictureBox5.Visible = True

    End Sub



    Private Sub Action(sender As Object, e As EventArgs) Handles Button2.Click, Button3.Click, Button4.Click, Button5.Click
        Dim log As New keyLoggerFunctions
        Dim i As Integer
        If sender.Equals(Button2) Then
            i = 0
        ElseIf sender.Equals(Button3) Then
            i = 1
        ElseIf sender.Equals(Button4) Then
            i = 2
        ElseIf sender.Equals(Button5) Then
            i = 3
        End If
        log.CreateLog(logObj(i), log.ActionString(student.Room.GetKeyStatus(txtSearch.Text.Trim)))
        Dim result As Integer = MessageBox.Show("'" + log.TruncateString(log.NameOfStudent) + "' of 'ROOM " + log.RoomN0 + "' has " + log.Action + " key",
                                               "Key Logger", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            log.Add()
            If log.Action = "CheckIn" Then
                student.Room.ChangeKeyStatus("IN")
            Else
                student.Room.ChangeKeyStatus("OUT")
            End If
            refreshPage()
            ShowMessage(Timer1, Label17, Color.Lime, log.Action + " Successfully")

        End If
    End Sub

    Private Sub refreshPage()
        student.ViewRoomMembers(TextBox1, TextBox10, TextBox6, TextBox7, TextBox2, TextBox11, TextBox5, TextBox8, TextBox3, TextBox12, TextBox4, TextBox9, PictureBox1, PictureBox4, PictureBox2, PictureBox3, Button2, Button3, Button4, Button5, "", Label17, GetOption(ComboBox1))
        Label18.Text = ""
        Label17.Visible = False
        Label19.Visible = False
        PictureBox5.Visible = False
        PictureBox7.Visible = False
        PictureBox8.Visible = False
        PictureBox9.Visible = False
        PictureBox10.Visible = False
        txtSearch.Clear()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        refreshPage()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CloseMessage(Timer1, Label17)
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtSearch.Focus()
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        refreshPage()
        txtSearch.Focus()
        If ComboBox1.SelectedIndex = 0 Then
            txtSearch.Mask = ">L09"
            Label7.Text = "Phone Number"
            Label10.Text = "Phone Number"
            Label13.Text = "Phone Number"
            Label4.Text = "Phone Number"
            TextBox3.Size = New Size(150, 30)
            TextBox4.Size = New Size(150, 30)
            TextBox12.Size = New Size(150, 30)
            TextBox9.Size = New Size(150, 30)
        ElseIf ComboBox1.SelectedIndex = 1 Then
            txtSearch.Mask = "(999) 000-0000"
            Label7.Text = "Room Number"
            Label10.Text = "Room Number"
            Label13.Text = "Room Number"
            Label4.Text = "Room Number"
            TextBox3.Size = New Size(70, 30)
            TextBox4.Size = New Size(70, 30)
            TextBox12.Size = New Size(70, 30)
            TextBox9.Size = New Size(70, 30)
        End If
    End Sub

    Private Sub Btn_MouseHover(sender As Object, e As EventArgs) Handles BtnRefresh.MouseHover, BtnKeyLog.MouseHover, BtnSearch.MouseHover
        If sender.Equals(BtnSearch) Then
            BtnSearch.Size = New Size(30, 30)
            BtnSearch.Location = New Point(1218, 50)
        ElseIf sender.Equals(BtnRefresh) Then
            BtnRefresh.Size = New Size(30, 30)
            BtnRefresh.Location = New Point(1254, 50)
        ElseIf sender.Equals(BtnKeyLog) Then
            BtnKeyLog.Size = New Size(36, 36)
            BtnKeyLog.Location = New Point(1303, 13)
        End If
    End Sub

    Private Sub Btn_MouseLeave(sender As Object, e As EventArgs) Handles BtnRefresh.MouseLeave, BtnKeyLog.MouseLeave, BtnSearch.MouseLeave
        If sender.Equals(BtnSearch) Then
            BtnSearch.Size = New Size(26, 26)
            BtnSearch.Location = New Point(1220, 52)
        ElseIf sender.Equals(BtnRefresh) Then
            BtnRefresh.Size = New Size(26, 26)
            BtnRefresh.Location = New Point(1256, 52)
        ElseIf sender.Equals(BtnKeyLog) Then
            BtnKeyLog.Size = New Size(32, 32)
            BtnKeyLog.Location = New Point(1305, 15)
        End If
    End Sub

    Private Sub PictureBox6_MouseHover(sender As Object, e As EventArgs) Handles PictureBox6.MouseHover
        PictureBox6.Size = New Size(44, 40)
        PictureBox6.Location = New Point(70, 30)
    End Sub

    Private Sub PictureBox6_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.Size = New Size(40, 40)
        PictureBox6.Location = New Point(74, 32)
    End Sub

    Private Sub BtnKeyLog_Click(sender As Object, e As EventArgs) Handles BtnKeyLog.Click
        Dim keylogform As New keyLog
        keylogform.ShowDialog()
    End Sub
End Class