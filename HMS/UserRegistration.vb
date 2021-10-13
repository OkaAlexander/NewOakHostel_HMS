Public Class UserRegistration

    Public validRank As Boolean
    Public validName As Boolean
    Public validUsername As Boolean
    Public validEmail As Boolean = True
    Public validPassword As Boolean
    Public validConfrimPassword As Boolean
    Public validPhone As Boolean

    
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel1.DisplayRectangle, Color.White, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel2.DisplayRectangle, Color.White, ButtonBorderStyle.Solid)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validRank And validUsername And validName And validPassword And validPhone And validEmail And validConfrimPassword Then
            user.SetAttribute(txtName.Text, txtUsername.Text, txtPassword.Text, cmbRank.Text, txtPhone.Text, txtEmail.Text, PictureBox1.Image)
            If user.Add() Then
                ShowMessage(Timer1, Label19, Color.Lime, "Registration Successful")
                btnRemove.Enabled = False
                user.Refresh()
            Else
                ShowMessage(Timer1, Label19, Color.Red, "Registration Unsuccessful")
            End If
        Else
            ShowMessage(Timer1, Label19, Color.Red, "Registration Unsuccessful")
            validRank = ValidateComboBox(ErrorProvider1, cmbRank, "Select Rank", txtSearch)
            validPhone = ValidatePhoneN0(ErrorProvider1, txtPhone, "Invalid Phone Number", txtSearch)

            validName = ValidateName(ErrorProvider1, txtName, "Invalid Name", txtSearch)
            validUsername = validateUsername(ErrorProvider1, txtUsername, "-User name must be between 5 to 20 characters" & vbCrLf & "-User name can have lowercase and uppercase characters" & vbCrLf & "-User name can be alpha-numeric" & vbCrLf & "-No special character allowed", txtSearch)
            validPassword = ValidatePassword(ErrorProvider1, txtPassword, "-Must be between 5 to 16 characters", txtSearch)
            validConfrimPassword = ValidateConfirmPassword(ErrorProvider1, txtConfirmPassword, txtPassword, "Passwords do not match", txtSearch)
        End If

    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If user.uploadImg(upload, PictureBox1) Then
            btnRemove.Enabled = True
        Else
            btnRemove.Enabled = False
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If validRank And validUsername And validName And validPassword And validPhone And validEmail And validConfrimPassword Then
            user.SetAttribute(txtName.Text, txtUsername.Text, txtPassword.Text, cmbRank.Text, txtPhone.Text, txtEmail.Text, PictureBox1.Image)
            If user.Add(GeneralFunctions.mode.Update) Then
                user.Refresh()
                btnRemove.Enabled = False
                ShowMessage(Timer1, Label19, Color.Lime, "Update Successful")
            Else
                ShowMessage(Timer1, Label19, Color.Red, "Update Unsuccessful")
            End If
        Else
            ShowMessage(Timer1, Label19, Color.Red, "Update Unsuccessful")
        End If
    End Sub

    'fetches a user and fill the fields
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        If txtSearch.Text.Trim = "ADMIN" Then
            ShowMessage(Timer1, Label19, Color.Blue, "User can not be altered")
            Exit Sub
        End If
        If user.Fetch(GetOption(ComboBox2), txtSearch.Text) Then
            user.FillByUsername(cmbRank, txtName, txtUsername, txtPhone, txtEmail, txtPassword, PictureBox1)
            validRank = True
            validUsername = True
            validName = True
            validPassword = True
            validEmail = True
            validPhone = True
            validConfrimPassword = False
            Me.btnUpdate.Enabled = True
            Me.btnDelete.Enabled = True
            Me.btnSave.Enabled = False
            Me.btnRemove.Enabled = True
        Else
            ShowMessage(Timer1, Label19, Color.Blue, "No Record found")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If user.Delete() Then
            user.Refresh()
        Else
            ShowMessage(Timer1, Label19, Color.Red, "Delete Unsuccessful")
        End If
    End Sub


    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        PictureBox1.Image = HMS.My.Resources.Resources.Default_Image
        btnRemove.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CloseMessage(Timer1, Label19)
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Homepage.Show()
        Me.Close()
    End Sub

    Private Sub cmbRank_Leave(sender As Object, e As EventArgs) Handles cmbRank.Leave
        validRank = ValidateComboBox(ErrorProvider1, cmbRank, "Select Rank", txtSearch)
    End Sub

    Private Sub txtPhone_Leave(sender As Object, e As EventArgs) Handles txtPhone.Leave
        validPhone = ValidatePhoneN0(ErrorProvider1, txtPhone, "Invalid Phone Number", txtSearch)
    End Sub

    Private Sub txtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave

    End Sub

    Private Sub txtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave
        validName = ValidateName(ErrorProvider1, txtName, "Invalid Name", txtSearch)
    End Sub

   
    Private Sub txtUsername_Leave(sender As Object, e As EventArgs) Handles txtUsername.Leave
        validUsername = validateUsername(ErrorProvider1, txtUsername, "-User name must be between 5 to 20 characters" & vbCrLf & "-User name can have lowercase and uppercase characters" & vbCrLf & "-User name can be alpha-numeric" & vbCrLf & "-No special character allowed", txtSearch)
    End Sub

    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        validPassword = ValidatePassword(ErrorProvider1, txtPassword, "-Must be between 5 to 16 characters", txtSearch)
    End Sub

    Private Sub txtConfirmPassword_Leave(sender As Object, e As EventArgs) Handles txtConfirmPassword.Leave
        validConfrimPassword = ValidateConfirmPassword(ErrorProvider1, txtConfirmPassword, txtPassword, "Passwords do not match", txtSearch)
    End Sub

    Private Sub PictureBox6_MouseHover(sender As Object, e As EventArgs) Handles PictureBox6.MouseHover
        PictureBox6.Size = New Size(44, 40)
        PictureBox6.Location = New Point(70, 30)
    End Sub

    Private Sub PictureBox6_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.Size = New Size(40, 40)
        PictureBox6.Location = New Point(74, 32)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        txtSearch.Clear()
        txtSearch.Focus()
        If ComboBox2.SelectedIndex = 0 Then
            txtSearch.Mask = ">AAAAAaaaaa"
        ElseIf ComboBox2.SelectedIndex = 1 Then
            txtSearch.Mask = "(999) 000-0000"
        End If
    End Sub

    Private Sub Btn_MouseHover(sender As Object, e As EventArgs) Handles BtnSearch.MouseHover, BtnRefresh.MouseHover
        If sender.Equals(BtnSearch) Then
            BtnSearch.Size = New Size(30, 30)
            BtnSearch.Location = New Point(1218, 50)
        ElseIf sender.Equals(BtnRefresh) Then
            BtnRefresh.Size = New Size(30, 30)
            BtnRefresh.Location = New Point(1254, 50)
        End If
    End Sub

    Private Sub Btn_MouseLeave(sender As Object, e As EventArgs) Handles BtnSearch.MouseLeave, BtnRefresh.MouseLeave
        If sender.Equals(BtnSearch) Then
            BtnSearch.Size = New Size(26, 26)
            BtnSearch.Location = New Point(1220, 52)
        ElseIf sender.Equals(BtnRefresh) Then
            BtnRefresh.Size = New Size(26, 26)
            BtnRefresh.Location = New Point(1256, 52)
        End If
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Focus()
        ComboBox2.SelectedIndex = 0
        Panel1.Focus()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        user.Refresh()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        txtSearch.Clear()
    End Sub

    
End Class