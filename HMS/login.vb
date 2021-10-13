
Public Class login
    Dim user As New UserFunctions
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel1.DisplayRectangle, Color.White, ButtonBorderStyle.Solid)
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        txtPassword.UseSystemPasswordChar = False
        PictureBox1.Image = My.Resources._006_eye
        PictureBox1.BackColor = Color.Black
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        txtPassword.UseSystemPasswordChar = True
        PictureBox1.Image = My.Resources.eye_1
        PictureBox1.BackColor = Color.White
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text <> "" Then
            PictureBox1.Visible = True
        Else
            PictureBox1.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not IsNothing(txtUsername) And Not IsNothing(txtPassword) Then
            If user.login(txtUsername.Text.Trim, txtPassword.Text.Trim) Then
                Homepage.Show()
                Background_Image.Close()
                Me.Close()
            End If
        Else
            MessageBox.Show("Please Fill All Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As Integer
        result = MessageBox.Show("Sure You Want To Exit", "Exiting...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Background_Image.Close()
            Me.Close()

        End If
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Background_Image.Show()
        If Not user.IsExistUser() Then
            user.SetAttribute("ADMINISTRATOR", "ADMIN", "12345678", "ADMIN", "0573235605", "eugenemora5@gmail.com", My.Resources.Default_Image)
            user.Add(GeneralFunctions.mode.Save)
        End If
    End Sub
    
End Class