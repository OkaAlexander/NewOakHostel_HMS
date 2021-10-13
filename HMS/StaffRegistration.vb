Public Class StaffRegistration

    Dim Img As String

    Public validStaffID As Boolean
    Public validFName As Boolean
    Public validLName As Boolean
    Public validGender As Boolean
    Public validPhone As Boolean
    Public validEmail As Boolean = True
    Public validRank As Boolean
    Public validDOB As Boolean
    

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel1.DisplayRectangle, Color.White, ButtonBorderStyle.Solid)
    End Sub
   
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If staff.Delete() Then
            staff.Refresh()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If staff.uploadImg(Upload, PictureBox1) Then
            btnRemove.Enabled = True
        Else
            btnRemove.Enabled = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validStaffID And validFName And validLName And validEmail And validPhone And validDOB And validRank And validGender Then
            staff.SetAttribute(txtStaffID.Text, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPhone.Text, cmbRank.Text, cmbGender.Text, txtDOB.Text, PictureBox1.Image)
            If staff.Add() Then
                btnRemove.Enabled = False
                staff.refresh()
                ShowMessage(Timer1, Label19, Color.Lime, "Registration Successful")
            Else
                ShowMessage(Timer1, Label19, Color.Red, "Registration Unsuccessful")
            End If
        Else
            ShowMessage(Timer1, Label19, Color.Red, "Registration Unsuccessful")
            validStaffID = ValidateIDStaff(ErrorProvider1, txtStaffID, "Invalid ID", txtSearch)
            validFName = ValidateName(ErrorProvider1, txtFirstName, "Invalid First Name", txtSearch)
            validLName = ValidateName(ErrorProvider1, txtLastName, "Invalid Last Name", txtSearch)

            validPhone = ValidatePhoneN0(ErrorProvider1, txtPhone, "Invalid Phone Number", txtSearch)
            validRank = ValidateComboBox(ErrorProvider1, cmbRank, "Select Rank", txtSearch)
            validGender = ValidateComboBox(ErrorProvider1, cmbGender, "Select Gender", txtSearch)
            validDOB = ValidateDOB(ErrorProvider1, txtDOB, "Invalid DOB", txtSearch)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If validStaffID And validFName And validLName And validEmail And validPhone And validDOB And validRank And validGender Then
            staff.SetAttribute(txtStaffID.Text, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPhone.Text, cmbRank.Text, cmbGender.Text, txtDOB.Text, PictureBox1.Image)
            If staff.Add(GeneralFunctions.mode.Update) Then
                btnRemove.Enabled = False
                staff.refresh()
                ShowMessage(Timer1, Label19, Color.Lime, "Update Successful")
            Else
                ShowMessage(Timer1, Label19, Color.Red, "Update Unsuccessful")
            End If
        Else
            ShowMessage(Timer1, Label19, Color.Red, "Update Unsuccessful")

        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        staff.refresh()
        If staff.Fetch(GetOption(ComboBox2), txtSearch.Text) Then
            staff.FillByIDN0(txtStaffID, txtFirstName, txtLastName, txtEmail, txtPhone, cmbRank, cmbGender, txtDOB, PictureBox1)
            validStaffID = True
            validLName = True
            validFName = True
            validGender = True
            validPhone = True
            validEmail = True
            validRank = True
            validDOB = True
            Me.btnUpdate.Enabled = True
            Me.btnDelete.Enabled = True
            Me.btnSave.Enabled = False
            Me.btnRemove.Enabled = True
        Else
            ShowMessage(Timer1, Label19, Color.Blue, "No Record found")
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
        Me.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        txtSearch.Clear()
        txtSearch.Focus()
        If ComboBox2.SelectedIndex = 0 Then
            txtSearch.Mask = ">AA00000099"
        ElseIf ComboBox2.SelectedIndex = 1 Then
            txtSearch.Mask = "(999) 000-0000"
        End If
    End Sub

    Private Sub Btn_MouseHover(sender As Object, e As EventArgs) Handles BtnRefresh.MouseHover, BtnSearch.MouseHover
        If sender.Equals(BtnSearch) Then
            BtnSearch.Size = New Size(30, 30)
            BtnSearch.Location = New Point(1218, 50)
        ElseIf sender.Equals(BtnRefresh) Then
            BtnRefresh.Size = New Size(30, 30)
            BtnRefresh.Location = New Point(1254, 50)
        End If
    End Sub

    Private Sub Btn_MouseLeave(sender As Object, e As EventArgs) Handles BtnRefresh.MouseLeave, BtnSearch.MouseLeave
        If sender.Equals(BtnSearch) Then
            BtnSearch.Size = New Size(26, 26)
            BtnSearch.Location = New Point(1220, 52)
        ElseIf sender.Equals(BtnRefresh) Then
            BtnRefresh.Size = New Size(26, 26)
            BtnRefresh.Location = New Point(1256, 52)
        End If
    End Sub


    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox2.SelectedIndex = 0
        Panel1.Focus()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        staff.Refresh()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        txtSearch.Clear()
    End Sub

    Private Sub txtStaffID_Leave(sender As Object, e As EventArgs) Handles txtStaffID.Leave
        validStaffID = ValidateIDStaff(ErrorProvider1, txtStaffID, "Invalid ID", txtSearch)
    End Sub

    Private Sub txtFirstName_Leave(sender As Object, e As EventArgs) Handles txtFirstName.Leave
        validFName = ValidateName(ErrorProvider1, txtFirstName, "Invalid First Name", txtSearch)
    End Sub

    Private Sub txtLastName_Leave(sender As Object, e As EventArgs) Handles txtLastName.Leave
        validLName = ValidateName(ErrorProvider1, txtLastName, "Invalid Last Name", txtSearch)
    End Sub

    Private Sub txtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave

    End Sub

    Private Sub txtPhone_Leave(sender As Object, e As EventArgs) Handles txtPhone.Leave
        validPhone = ValidatePhoneN0(ErrorProvider1, txtPhone, "Invalid Phone Number", txtSearch)
    End Sub

    Private Sub cmbRank_Leave(sender As Object, e As EventArgs) Handles cmbRank.Leave
        validRank = ValidateComboBox(ErrorProvider1, cmbRank, "Select Rank", txtSearch)
    End Sub

    Private Sub cmbGender_Leave(sender As Object, e As EventArgs) Handles cmbGender.Leave
        validGender = ValidateComboBox(ErrorProvider1, cmbGender, "Select Gender", txtSearch)
    End Sub

    Private Sub txtDOB_Leave(sender As Object, e As EventArgs) Handles txtDOB.Leave
        validDOB = ValidateDOB(ErrorProvider1, txtDOB, "Invalid DOB", txtSearch)
    End Sub

    Private Sub PictureBox6_MouseHover(sender As Object, e As EventArgs) Handles PictureBox6.MouseHover
        PictureBox6.Size = New Size(44, 40)
        PictureBox6.Location = New Point(70, 30)
    End Sub

    Private Sub PictureBox6_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.Size = New Size(40, 40)
        PictureBox6.Location = New Point(74, 32)
    End Sub
End Class