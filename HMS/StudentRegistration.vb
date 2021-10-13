Imports Smsgh.Api.Sdk.Smsgh
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Public Class StudentRegistration
    'Api Service Global variables
    Dim allstudents(9000, 2) As String
    Dim currId As Integer = 0
    'end of the api global variables
    Public validName As Boolean
    Public validProg As Boolean
    Public validGender As Boolean
    Public validLevel As Boolean
    Public validPhone As Boolean
    Public validEmail As Boolean = True
    Public validNumPerRoom As Boolean = True
    Public validRoomN0 As Boolean
    Public validReceiptN0 As Boolean
    Public validAmountPaid As Boolean
    Public validId As Boolean
    Public validDate As Boolean = True
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel1.DisplayRectangle, Color.White, ButtonBorderStyle.Solid)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel2.DisplayRectangle, Color.White, ButtonBorderStyle.Solid)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' MessageBox.Show(validId.ToString + "," + validName.ToString + "," + validProg.ToString + "," + validGender.ToString + "," + validLevel.ToString + "," + validPhone.ToString + "," + validEmail.ToString + "," + _
        '        validNumPerRoom.ToString + "," + validRoomN0.ToString + "," + validReceiptN0.ToString + "," + validAmountPaid.ToString + "," + validDate.ToString)
        If validId And validName And validProg And validGender And validLevel And validPhone And validEmail And
                validNumPerRoom And validRoomN0 And validReceiptN0 And validAmountPaid And validDate Then

            student.SetAttribute(txtname.Text, txtindexno.Text, cmbprogramme.Text, cmbgender.Text, cmblevel.Text, txtphoneno.Text, txtEmail.Text, txtRoom.Text, txtreceipt.Text, FormatCurrency(CDbl(txtamountpaid.Text), 2), FormatCurrency(CDbl(txtbalance.Text), 2), DateTimePicker1.Value, PictureBox1.Image, My.Settings.AcademicYear)

            If student.Add() Then
                My.Settings.NumOfPeople = student.Room.NumInRoom()
                Label18.Text = "Last Room Assigned: " + My.Settings.LastRoomAssigned
                Label17.Text = My.Settings.NumOfPeople
                btnRemove.Enabled = False
                student.Refresh()
                ShowMessage(Timer1, Label19, Color.Lime, "Registration Successful")
                If Not sendMessage(student.phone, student.name, student.roomNumber) Then MessageBox.Show("SMS not sent")
            Else
                ShowMessage(Timer1, Label19, Color.Red, "Registration Unsuccessful")
            End If
        Else
            ShowMessage(Timer1, Label19, Color.Red, "Registration Unsuccessful")
            validId = ValidateID(ErrorProvider1, txtindexno, "Invalid Index/Ref Number", txtSearch)
            validName = ValidateName(ErrorProvider1, txtname, "Invalid Name", txtSearch)
            validProg = ValidateComboBox(ErrorProvider1, cmbprogramme, "Select Programme", txtSearch)
            validGender = ValidateComboBox(ErrorProvider1, cmbgender, "Select Gender", txtSearch)
            validLevel = ValidateComboBox(ErrorProvider1, cmblevel, "Select Level", txtSearch)
            validPhone = ValidatePhoneN0(ErrorProvider1, txtphoneno, "Invalid Phone Number", txtSearch)
            'validEmail = ValidateEmail(ErrorProvider1, txtEmail, txtSearch)
            validNumPerRoom = ValidateComboBox(ErrorProvider1, ComboBox1, "Select Number Per Room", txtSearch)
            validRoomN0 = ValidateRoomN0(ErrorProvider1, txtRoom, cmbgender.Text, ComboBox1.Text, txtSearch)
            validReceiptN0 = ValidateNumber(ErrorProvider1, txtreceipt, "Invalid Receipt Number", txtSearch)
            validAmountPaid = ValidateAmount(ErrorProvider1, txtamountpaid, student.Room.AmountToPay(ComboBox1.SelectedItem), txtSearch)
            validDate = ValidateDate(ErrorProvider1, DateTimePicker1, "Select Valid Date", txtSearch)
        End If
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If student.uploadImg(Upload, PictureBox1) Then
            btnRemove.Enabled = True
        Else
            btnRemove.Enabled = False
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'MessageBox.Show(validId.ToString + "," + validName.ToString + "," + validProg.ToString + "," + validGender.ToString + "," + validLevel.ToString + "," + validPhone.ToString + "," + validEmail.ToString + "," + _
        '        validNumPerRoom.ToString + "," + validRoomN0.ToString + "," + validReceiptN0.ToString + "," + validAmountPaid.ToString + "," + validDate.ToString)
        If validId And validName And validProg And validGender And validLevel And validPhone And validEmail And
            validNumPerRoom And validRoomN0 And validReceiptN0 And validAmountPaid And validDate Then

            student.SetAttribute(txtname.Text, txtindexno.Text, cmbprogramme.Text, cmbgender.Text, cmblevel.Text, txtphoneno.Text, txtEmail.Text, txtRoom.Text, txtreceipt.Text, FormatCurrency(CDbl(txtamountpaid.Text), 2), FormatCurrency(CDbl(txtbalance.Text), 2), DateTimePicker1.Value, PictureBox1.Image, My.Settings.AcademicYear)

            If student.Add(GeneralFunctions.mode.Update) Then
                btnRemove.Enabled = False
                student.Refresh()
                ShowMessage(Timer1, Label19, Color.Lime, "Update Successful")
            Else
                ShowMessage(Timer1, Label19, Color.Red, "Update Unsuccessful")
            End If
        Else
            ShowMessage(Timer1, Label19, Color.Red, "Update Unsuccessful")
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        student.Refresh()
        If student.Fetch(GetOption(ComboBox2), txtSearch.Text) Then
            student.FillByIndexNo(txtname, txtindexno, cmbprogramme, cmbgender, cmblevel, txtphoneno, txtEmail, ComboBox1, txtRoom, txtreceipt, txtamountpaid, txtbalance, DateTimePicker1, PictureBox1)
            validId = True
            validName = True
            validProg = True
            validGender = True
            validLevel = True
            validPhone = True
            validEmail = True
            validNumPerRoom = True
            validRoomN0 = True
            validReceiptN0 = True
            validAmountPaid = True
            validDate = True
            Me.btnUpdate.Enabled = True
            Me.btnDelete.Enabled = True
            Me.btnSave.Enabled = False
            Me.btnRemove.Enabled = True
        Else
            ShowMessage(Timer1, Label19, Color.Blue, "No Record found")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If student.Delete() Then
            student.Refresh()
            ShowMessage(Timer1, Label19, Color.Lime, "Delete Successful")
        Else
            ShowMessage(Timer1, Label19, Color.Red, "Delete Unsuccessful")
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        student.Refresh()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        PictureBox1.Image = HMS.My.Resources.Resources.Default_Image
        btnRemove.Enabled = False
    End Sub


    Private Sub txtroom_TextChanged(sender As Object, e As EventArgs) Handles txtRoom.TextChanged
        validRoomN0 = ValidateRoomN0(ErrorProvider1, txtRoom, cmbgender.Text, ComboBox1.Text, txtSearch)
        PictureBox4.Visible = False
        If student.Room.IsExist(txtRoom.Text.Trim) Then
            Label14.Text = student.Room.NumInRoom()
            Label14.Visible = True
            PictureBox2.Visible = True
            If student.Room.Disabled Then
                PictureBox4.Visible = True
            End If
        Else
            Label14.Visible = False
            PictureBox2.Visible = False
        End If
    End Sub

    Private Sub cmbgender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbgender.SelectedIndexChanged, cmblevel.SelectedIndexChanged
        If My.Settings.AutoSuggestion = True Then
            txtRoom.Text = student.Room.Suggest(cmbgender.SelectedItem, Val(cmblevel.SelectedItem), Int(ComboBox1.Text))
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CloseMessage(Timer1, Label19)
    End Sub

    Private Sub txtamountpaid_TextChanged(sender As Object, e As EventArgs) Handles txtamountpaid.TextChanged
        validAmountPaid = ValidateAmount(ErrorProvider1, txtamountpaid, student.Room.AmountToPay(ComboBox1.SelectedItem), txtSearch)
        If validAmountPaid Then
            Balance()
        Else
            txtbalance.Clear()
        End If
    End Sub

    Private Sub Balance()
        If txtamountpaid.Text = "0" Then
            txtbalance.Text = student.Room.AmountToPay(ComboBox1.SelectedItem)
        Else
            txtbalance.Text = student.Room.Balance(Int(ComboBox1.Text), CDbl(txtamountpaid.Text.Trim))
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Balance()
        If My.Settings.AutoSuggestion = True Then
            txtRoom.Text = student.Room.Suggest(cmbgender.SelectedItem, Val(cmblevel.SelectedItem), Int(ComboBox1.Text))
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Focus()
        txtSearch.Focus()
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        CheckBox1.Checked = My.Settings.AutoSuggestion
        Label18.Text = "Last Room Assigned: " + My.Settings.LastRoomAssigned
        Label17.Text = My.Settings.NumOfPeople
        Label22.Text = My.Settings.AcademicYear
    End Sub
    Private Sub txtname_Leave(sender As Object, e As EventArgs) Handles txtname.Leave
        validName = ValidateName(ErrorProvider1, txtname, "Invalid Name", txtSearch)
    End Sub

    Private Sub cmbprogramme_Leave(sender As Object, e As EventArgs) Handles cmbprogramme.Leave
        validProg = ValidateComboBox(ErrorProvider1, cmbprogramme, "Select Programme", txtSearch)
    End Sub

    Private Sub cmbgender_Leave(sender As Object, e As EventArgs) Handles cmbgender.Leave
        validGender = ValidateComboBox(ErrorProvider1, cmbgender, "Select Gender", txtSearch)
    End Sub

    Private Sub cmblevel_Leave(sender As Object, e As EventArgs) Handles cmblevel.Leave
        validLevel = ValidateComboBox(ErrorProvider1, cmblevel, "Select Level", txtSearch)
    End Sub

    Private Sub txtphoneno_Leave(sender As Object, e As EventArgs) Handles txtphoneno.Leave
        validPhone = ValidatePhoneN0(ErrorProvider1, txtphoneno, "Invalid Phone Number", txtSearch)
    End Sub

    Private Sub txtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        'validEmail = ValidateEmail(ErrorProvider1, txtEmail, txtSearch)
    End Sub

    Private Sub ComboBox1_Leave(sender As Object, e As EventArgs) Handles ComboBox1.Leave
        validNumPerRoom = ValidateComboBox(ErrorProvider1, ComboBox1, "Select Number Per Room", txtSearch)
    End Sub

    Private Sub txtroom_Leave(sender As Object, e As EventArgs) Handles txtRoom.Leave
        validRoomN0 = ValidateRoomN0(ErrorProvider1, txtRoom, cmbgender.Text, ComboBox1.Text, txtSearch)
    End Sub

    Private Sub txtreceipt_Leave(sender As Object, e As EventArgs) Handles txtreceipt.Leave
        validReceiptN0 = ValidateNumber(ErrorProvider1, txtreceipt, "Invalid Receipt Number", txtSearch)
    End Sub

    Private Sub txtamountpaid_Leave(sender As Object, e As EventArgs) Handles txtamountpaid.Leave
        If txtamountpaid.Text = "" Then
            txtamountpaid.Text = 0
        End If
        validAmountPaid = ValidateAmount(ErrorProvider1, txtamountpaid, student.Room.AmountToPay(ComboBox1.SelectedItem), txtSearch)
    End Sub

    Private Sub DateTimePicker1_Leave(sender As Object, e As EventArgs) Handles DateTimePicker1.Leave, DateTimePicker1.ValueChanged
        validDate = ValidateDate(ErrorProvider1, DateTimePicker1, "Select Valid Date", txtSearch)
    End Sub

    Private Sub txtindexno_Leave(sender As Object, e As EventArgs) Handles txtindexno.Leave
        validId = ValidateID(ErrorProvider1, txtindexno, "Invalid Index/Ref Number", txtSearch)
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

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        txtSearch.Clear()
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

    Private Sub PictureBox6_MouseHover(sender As Object, e As EventArgs) Handles PictureBox6.MouseHover
        PictureBox6.Size = New Size(44, 40)
        PictureBox6.Location = New Point(70, 30)
    End Sub

    Private Sub PictureBox6_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.Size = New Size(40, 40)
        PictureBox6.Location = New Point(74, 32)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        My.Settings.AutoSuggestion = CheckBox1.Checked
        If My.Settings.AutoSuggestion = True Then
            txtRoom.Text = student.Room.Suggest(cmbgender.SelectedItem, Val(cmblevel.SelectedItem), Int(ComboBox1.Text))
        Else
            txtRoom.Clear()
            ErrorProvider1.Clear()
        End If
    End Sub


    Private Sub Label22_DoubleClick(sender As Object, e As EventArgs) Handles Label22.DoubleClick
        Label22.Visible = False
        MaskedTextBox1.Text = My.Settings.AcademicYear
        MaskedTextBox1.Visible = True
        MaskedTextBox1.Focus()
        Button1.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.AcademicYear = MaskedTextBox1.Text.Trim
        Label22.Text = My.Settings.AcademicYear
        MaskedTextBox1.Visible = False
        Button1.Visible = False
        Label22.Visible = True

    End Sub


    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        student.Room.Enable(txtRoom.Text)
        PictureBox4.Visible = False
        ErrorProvider1.Clear()
    End Sub

    Private Sub PictureBox4_MouseHover(sender As Object, e As EventArgs) Handles PictureBox4.MouseHover
        PictureBox4.Location = New Point(460, 385)
        PictureBox4.Size = New Size(22, 26)
    End Sub

    Private Sub PictureBox4_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox4.MouseLeave
        PictureBox4.Location = New Point(461, 386)
        PictureBox4.Size = New Size(20, 24)
    End Sub

    Private Function sendMessage(phoneNumber As String, student_name As String, roomN0 As String) As Boolean
        Dim MESSAGE As String
        Dim firstName As String
        If student_name.IndexOf(" ") = -1 Then
            firstName = student_name.Substring(0)
        Else
            firstName = student_name.Substring(0, student_name.IndexOf(" "))
        End If

        MESSAGE = "Hi, " + firstName +
                   " , Your Application for GETFund Hostel has been approved. You have been assigned to Room " + roomN0 +
                   ". Thank you"


        Const clientId As String = "cbowznks"
        Const clientSecret As String = "ykbedfnn"
        Try
            Dim host = New ApiHost(New BasicAuth(clientId, clientSecret))
            Dim messageApi = New MessagingApi(host)
            Dim msg As MessageResponse = messageApi.SendQuickMessage("UENR", phoneNumber, MESSAGE, True)
            Return True
        Catch e As Exception
            If (e.GetType = GetType(HttpRequestException)) Then
                Dim ex = CType(e, HttpRequestException)
                If ((Not (ex) Is Nothing) _
                            AndAlso (Not (ex.HttpResponse) Is Nothing)) Then
                End If

            End If

            Return False
        End Try
    End Function

    Private Sub sendAPIRequestByRefNumber(ReferenceNumber)
        Try
            Dim staticAPIurl As String = "https://umishost.uenr.edu.gh/api/Applicant/GetAdmittedApplicant/"
            Dim RequestUrl As String = (staticAPIurl + ReferenceNumber).ToString()
            Dim URI As New Uri(RequestUrl)
            ' Dim request As HttpWebRequest = New HttpWebRequest()
            Dim request As HttpWebRequest = HttpWebRequest.Create(URI)
            request.Method = "GET"
            Dim response As HttpWebResponse = request.GetResponse()
            Dim Read = New StreamReader(response.GetResponseStream())
            Dim raw As String = Read.ReadToEnd()

            Dim collection As Object = New JavaScriptSerializer().Deserialize(Of List(Of Object))(raw)
            MsgBox("we got the data")
            For Each line As Object In collection
                'textBox1.Text += line("indexNumber").ToString() + vbTab + line("surname").ToString() + vbNewLine
                'MsgBox(line("indexNumber"))
                allstudents(currId, 0) = line("indexNumber").ToString()
                allstudents(currId, 1) = line("surname").ToString()
                'allstudents(currId, 2) = line("firstName").ToString()
                'allstudents(currId, 3) = line("email").ToString()
                'allstudents(currId, 4) = line("phone").ToString()
                'allstudents(currId, 5) = line("website").ToString()
                'allstudents(currId, 6) = line("id").ToString()
                'allstudents(currId, 7) = line("id").ToString()
                currId += 1
            Next
            txtname.Text = allstudents(0, 0)
            txtindexno.Text = allstudents(0, 1)
            ''txtUsername.Text = allstudents(0, 2)
            ''txtname.Text = allstudents(0, 3)
            ''txtID.Text = allstudents(0, 4)
            ''txtID.Text = allstudents(0, 5)
        Catch ex As Exception
            MessageBox.Show("Invalid Reference Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub APIRequestbtn_Click(sender As Object, e As EventArgs) Handles APIRequestbtn.Click
        If (StudentReferenceNumbertxt.Text.Length = 0) Then
            StudentReferenceNumbertxt.Focus()
        Else
            Dim StdRef As String = StudentReferenceNumbertxt.Text.ToString()
            sendAPIRequestByRefNumber(StdRef)
        End If
    End Sub
End Class