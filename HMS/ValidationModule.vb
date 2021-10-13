Imports System.Text.RegularExpressions
Module ValidationModule
    Public student As New StudentFunctions
    Public staff As New StaffFunctions
    Public user As New UserFunctions

    '
    'Options
    '
    Public Enum keyType 'Search type options
        Id
        Room
        Phone
    End Enum

    Public Function GetOption(cmb As ComboBox) As keyType 'Gets a Search Type option 
        If cmb.SelectedItem = "Id" Then
            Return keyType.Id
        ElseIf cmb.SelectedItem = "Room" Then
            Return keyType.Room
        ElseIf cmb.SelectedItem = "Phone" Then
            Return keyType.Phone
        Else
            Return keyType.Id
        End If
    End Function

    '
    'VALIDATION FUNCTIONS
    '

    Public Function ValidatePassword(errorProvider As ErrorProvider, txtbox As TextBox, message As String, searchBox As MaskedTextBox) As Boolean
        Dim pattern As String = "^.*(?=.{5,16}).*$"
        Dim password As New Regex(pattern) 'Attach Pattern To name Textbox

        'Not A Match
        If searchBox.Focused Then
            errorProvider.SetError(txtbox, "")
            Return False
        ElseIf txtbox.Text = "" Then
            errorProvider.SetError(txtbox, "Please the field must not be empty")
            Return False
        ElseIf Not password.IsMatch(txtbox.Text.Trim) Then
            errorProvider.SetError(txtbox, message)
            Return False
        Else
            errorProvider.SetError(txtbox, "")
            Return True
        End If
    End Function

    Public Function ValidateConfirmPassword(errorProvider As ErrorProvider, txtbox As TextBox, txtbox1 As TextBox, message As String, searchBox As MaskedTextBox) As Boolean
        If searchBox.Focused Then
            errorProvider.SetError(txtbox, "")
            Return False
        ElseIf txtbox.Text = "" Then
            errorProvider.SetError(txtbox, "Please the field must not be empty")
            Return False
        ElseIf txtbox.Text.Trim <> txtbox1.Text.Trim Then
            errorProvider.SetError(txtbox, message)
            Return False
        Else
            errorProvider.SetError(txtbox, "")
            Return True
        End If
    End Function


    Public Function ValidateUsername(errorProvider As ErrorProvider, txtbox As TextBox, message As String, searchBox As MaskedTextBox) As Boolean

        Dim pattern As String = "^[a-zA-Z0-9_]{5,20}$"

        Dim name As New Regex(pattern) 'Attach Pattern To name Textbox

        'Not A Match
        If searchBox.Focused Then
            errorProvider.SetError(txtbox, "")
            Return False
        ElseIf txtbox.Text = "" Then
            errorProvider.SetError(txtbox, "Please the field must not be empty")
            Return False
        ElseIf Not name.IsMatch(txtbox.Text.Trim) Then
            errorProvider.SetError(txtbox, message)
            Return False
        ElseIf UserRegistration.btnUpdate.Enabled = True And user.updateKey = UserRegistration.txtUsername.Text.Trim Then
            errorProvider.SetError(txtbox, "")
            Return True
        ElseIf user.IsExist(keyType.Id, txtbox.Text.Trim) Then
            errorProvider.SetError(txtbox, "This Username already exist")
            Return False
        Else
            errorProvider.SetError(txtbox, "")
            Return True
        End If
    End Function


    Public Function ValidateName(errorProvider As ErrorProvider, txtbox As TextBox, message As String, searchBox As MaskedTextBox) As Boolean
        'Create A Pattern For name
        Dim pattern As String = "^[a-zA-Z\s]+$"

        Dim name As New Regex(pattern) 'Attach Pattern To name Textbox

        'Not A Match
        If searchBox.Focused Then
            errorProvider.SetError(txtbox, "")
            Return False
        ElseIf txtbox.Text = "" Then
            errorProvider.SetError(txtbox, "Please the field must not be empty")
            Return False
        ElseIf Not name.IsMatch(txtbox.Text.Trim) Then
            errorProvider.SetError(txtbox, message)
            Return False
        Else
            errorProvider.SetError(txtbox, "")
            Return True
        End If
    End Function


    Public Function ValidateComboBox(errorProvider As ErrorProvider, cmbBox As ComboBox, message As String, searchBox As MaskedTextBox) As Boolean
        If searchBox.Focused Then
            errorProvider.SetError(cmbBox, "")
            Return False
        ElseIf cmbBox.SelectedIndex = -1 Then
            errorProvider.SetError(cmbBox, message)
            Return False
        Else
            errorProvider.SetError(cmbBox, "")
            Return True
        End If
    End Function






    Public Function ValidateAmount(errorProvider As ErrorProvider, txtbox As TextBox, amountToPay As Double, searchBox As MaskedTextBox) As Boolean
        If searchBox.Focused Then
            errorProvider.SetError(txtbox, "")
            Return False
        ElseIf IsNothing(txtbox.Text) = True Then
            errorProvider.SetError(txtbox, "")
            Return True
        ElseIf IsNumeric(txtbox.Text) = False Then
            errorProvider.SetError(txtbox, "Please enter valid amount paid")
            Return False
        ElseIf Int(txtbox.Text) < 0 Then
            errorProvider.SetError(txtbox, "Amount should not be less then 0")
            Return False
        ElseIf CDbl(txtbox.Text) > amountToPay Then
            errorProvider.SetError(txtbox, "Amount should not be more then amount to be paid")
            Return False
        Else
            errorProvider.SetError(txtbox, "")
            Return True
        End If
    End Function


    Public Function ValidateNumber(errorProvider As ErrorProvider, txtbox As TextBox, message As String, searchBox As MaskedTextBox) As Boolean
        If searchBox.Focused Then
            errorProvider.SetError(txtbox, "")
            Return False
        ElseIf IsNothing(txtbox.Text) = True Then
            errorProvider.SetError(txtbox, "")
            Return True
        ElseIf txtbox.Text.Length > 20 Then
            errorProvider.SetError(txtbox, message)
            Return False
        Else
            errorProvider.SetError(txtbox, "")
            Return True
        End If
    End Function

    Public Function ValidateID(errorProvider As ErrorProvider, txtbox As MaskedTextBox, message As String, searchBox As MaskedTextBox) As Boolean
        If searchBox.Focused Then
            errorProvider.SetError(txtbox, "")
            Return False
        ElseIf txtbox.Text = "" Then
            errorProvider.SetError(txtbox, "Field should not be empty")
            Return False
        ElseIf txtbox.Text.Length > 10 Or txtbox.Text.Length < 8 Then
            errorProvider.SetError(txtbox, message)
            Return False
        ElseIf StudentRegistration.btnUpdate.Enabled = True And student.updateKey = StudentRegistration.txtindexno.Text.Trim Then
            errorProvider.SetError(txtbox, "")
            Return True
        ElseIf student.IsExist(keyType.Id, txtbox.Text.Trim) Then
            errorProvider.SetError(txtbox, "This ID already exist")
            Return False
        Else
            errorProvider.SetError(txtbox, "")
            Return True
        End If
    End Function

    Public Function ValidateIDStaff(errorProvider As ErrorProvider, txtbox As MaskedTextBox, message As String, searchBox As MaskedTextBox) As Boolean
        If searchBox.Focused Then
            errorProvider.SetError(txtbox, "")
            Return False
        ElseIf txtbox.Text = "" Then
            errorProvider.SetError(txtbox, "Field should not be empty")
            Return False
        ElseIf txtbox.Text.Length > 10 Or txtbox.Text.Length < 8 Then
            errorProvider.SetError(txtbox, message)
            Return False
        ElseIf StaffRegistration.btnUpdate.Enabled = True And staff.updateKey = StaffRegistration.txtStaffID.Text.Trim Then
            errorProvider.SetError(txtbox, "")
            Return True
        ElseIf staff.IsExist(keyType.Id, txtbox.Text.Trim) Then
            errorProvider.SetError(txtbox, "This ID already exist")
            Return False
        Else
            errorProvider.SetError(txtbox, "")
            Return True
        End If
    End Function

    Public Function ValidatePhoneN0(errorProvider As ErrorProvider, txtbox As MaskedTextBox, message As String, searchBox As MaskedTextBox) As Boolean
        If searchBox.Focused Then
            errorProvider.SetError(txtbox, "")
            Return False
        ElseIf txtbox.Text = "" Then
            errorProvider.SetError(txtbox, "Field should not be empty")
            Return False
        ElseIf txtbox.Text.Length < 14 Then
            errorProvider.SetError(txtbox, message)
            Return False
        Else
            errorProvider.SetError(txtbox, "")
            Return True
        End If
    End Function

    Public Function ValidateDOB(errorProvider As ErrorProvider, txtbox As MaskedTextBox, message As String, searchBox As MaskedTextBox) As Boolean
        If searchBox.Focused Then
            errorProvider.SetError(txtbox, "")
            Return False
        ElseIf txtbox.Text = "" Then
            errorProvider.SetError(txtbox, "Field should not be empty")
            Return False
        ElseIf txtbox.Text.Length < 10 Then
            errorProvider.SetError(txtbox, message)
            Return False
        Else
            errorProvider.SetError(txtbox, "")
            Return True
        End If
    End Function

    Public Function ValidateDate(errorProvider As ErrorProvider, datePicker As DateTimePicker, message As String, searchBox As MaskedTextBox) As Boolean
        If searchBox.Focused Then
            errorProvider.SetError(datePicker, "")
            Return False
        ElseIf datePicker.Value.CompareTo(Now) = 1 Then
            errorProvider.SetError(datePicker, message)
            Return False
        Else
            errorProvider.SetError(datePicker, "")
            Return True
        End If
    End Function

    Public Function ValidateRoomN01(errorProvider As ErrorProvider, txtbox As MaskedTextBox, searchBox As MaskedTextBox) As Boolean
        Dim Room As New RoomFunctions
        If searchBox.Focused Then
            errorProvider.SetError(txtbox, "")
            Return False
        ElseIf txtbox.Text = "" Then
            errorProvider.SetError(txtbox, "Field should not be empty")
            Return False
        ElseIf txtbox.Text.Length > 3 Then
            errorProvider.SetError(txtbox, "Invalid Room Number")
            Return False
        ElseIf Not Room.IsExist(txtbox.Text) Then
            errorProvider.SetError(txtbox, "Room does not exist")
            Return False
        Else
            errorProvider.SetError(txtbox, "")
            Return True
        End If
    End Function

    Public Function ValidateProblem(errorProvider As ErrorProvider, txtbox As TextBox, searchBox As MaskedTextBox) As Boolean
        If searchBox.Focused Then
            errorProvider.SetError(txtbox, "")
            Return False
        ElseIf txtbox.Text = "" Then
            errorProvider.SetError(txtbox, "Field should not be empty")
            Return False
        ElseIf IsNumeric(txtbox.Text.Trim) Then
            errorProvider.SetError(txtbox, "Invalid Problem")
            Return False
        Else
            errorProvider.SetError(txtbox, "")
            Return True
        End If
    End Function

    Public Function ValidateRoomN0(errorProvider As ErrorProvider, txtbox As MaskedTextBox, gender As String, numPerRoom As Integer, searchBox As MaskedTextBox) As Boolean
        If searchBox.Focused Then
            errorProvider.SetError(txtbox, "")
            Return False
        ElseIf txtbox.Text = "" Then
            errorProvider.SetError(txtbox, "Field should not be empty")
            Return False
        ElseIf student.original_room = txtbox.Text.Trim Then
            errorProvider.SetError(txtbox, "")
            Return True
        ElseIf txtbox.Text.Length > 3 Or IsNumeric(txtbox.Text) Then
            errorProvider.SetError(txtbox, "Invalid Room Number")
            Return False
        ElseIf StudentRegistration.btnUpdate.Enabled = True And student.original_room = StudentRegistration.txtRoom.Text.Trim Then
            errorProvider.SetError(txtbox, "")
            Return True
        ElseIf Not student.Room.IsExist(txtbox.Text) Then
            errorProvider.SetError(txtbox, "Room does not exist")
            Return False
        ElseIf student.Room.Disabled Then
            errorProvider.SetError(txtbox, "Room Disabed")
            Return False
        ElseIf student.Room.IsFull() Then
            errorProvider.SetError(txtbox, "Room is full")
            Return False
        ElseIf Not student.Room.GenderAccept(gender) Then
            errorProvider.SetError(txtbox, "Room can not accept this gender")
            Return False
        ElseIf Not student.Room.NumberPerRoom(numPerRoom) Then
            errorProvider.SetError(txtbox, "Invalid Number Per Room")
            Return False
        Else
            errorProvider.SetError(txtbox, "")
            Return True
        End If
    End Function

    '
    'show message
    '
    Public Sub ShowMessage(time As Timer, lbl As Label, fontcolor As Color, message As String)
        time.Start()
        lbl.Text = message
        lbl.Visible = True
        lbl.ForeColor = fontcolor
    End Sub

    '
    'closes message
    '
    Public Sub CloseMessage(time As Timer, lbl As Label)
        time.Stop()
        lbl.Visible = False
    End Sub

End Module
