Class StudentFunctions
    Inherits GeneralFunctions
    Private TA As New HMSDBDataSetTableAdapters.StudentTTableAdapter
    Public Room As New RoomFunctions
    Public original_room As String
    '
    'Attributes of a student
    '
    Public name As String
    Public indexNumber As String
    Public programme As String
    Public gender As String
    Public level As String
    Public phone As String
    Public email As String
    Public roomNumber As String
    Public receiptNumber As String
    Public amountPaid As Double
    Public balance As Double
    Public arrivalDate As Date
    Public image As Byte()
    Public academicYear As String
   
    '
    'Sets Student's Attributes
    '
    Public Sub SetAttribute(name As String, indexNumber As String, programme As String, gender As String, level As String, phone As String, email As String, roomNumber As String, receiptNumber As String, amountPaid As Double, balance As Double, arrivalDate As Date, image As Image, academicYear As String)
        Me.name = name.Trim
        Me.indexNumber = indexNumber.Trim
        Me.programme = programme.Trim
        Me.gender = gender.Trim
        Me.level = level.Trim
        Me.phone = phone.Trim
        Me.email = email.Trim
        Me.roomNumber = roomNumber.Trim
        Me.receiptNumber = receiptNumber.Trim
        Me.amountPaid = amountPaid
        Me.balance = balance
        Me.arrivalDate = arrivalDate
        Me.image = ConvertToByteArray(image)
        Me.academicYear = academicYear
    End Sub

    '
    'Adds or updates a new student record
    '
    Public Function Add(Optional mode As mode = GeneralFunctions.mode.Save) As Boolean
        Try
            If mode = mode.Save Then
                If TA.Insert(Me.name, Me.indexNumber, Me.programme, Me.gender, Me.level, Me.phone, Me.email, Me.roomNumber, Me.receiptNumber, Me.amountPaid, Me.balance, Me.arrivalDate, Me.image, Me.academicYear) Then
                    Room.Assign()
                    My.Settings.LastRoomAssigned = Me.roomNumber
                    Return True
                Else
                    Return False
                End If
            ElseIf mode = mode.Update Then
                Dim result As Integer
                result = MessageBox.Show("You Are Updating Record with key '" + student.updateKey + "'", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If result = DialogResult.Yes Then
                    If TA.UpdateByID(Me.name, Me.indexNumber, Me.programme, Me.gender, Me.level, Me.phone, Me.email, Me.roomNumber, Me.receiptNumber, Me.amountPaid, Me.balance, Me.arrivalDate, Me.image, updateKey) Then
                        If Not original_room = Me.roomNumber Then
                            Room.Assign()
                            Dim init_room As New RoomFunctions
                            init_room.Fetch(original_room)
                            init_room.Unassign()
                        End If
                        updateKey = Nothing
                        original_room = Nothing
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Private Function ActionStatus(roomN0 As String) As String
        If Room.GetKeyStatus(roomN0.Trim) = "IN" Then
            Return "CheckOut"
        Else
            Return "CheckIn"
        End If
    End Function

    '
    'for displaying students in a room
    '
    Public Function ViewRoomMembers(txtname0 As TextBox, txtname1 As TextBox, txtname2 As TextBox, txtname3 As TextBox, _
                                    txtprogramme0 As TextBox, txtprogramme1 As TextBox, txtprogramme2 As TextBox, txtprogramme3 As TextBox, _
                                    txtPhone0 As TextBox, txtPhone1 As TextBox, txtPhone2 As TextBox, txtPhone3 As TextBox, _
                                    pBox0 As PictureBox, pBox1 As PictureBox, pBox2 As PictureBox, pBox3 As PictureBox, _
                                    btn0 As Button, btn1 As Button, btn2 As Button, btn3 As Button, key As String, message As Label, searchType As keyType) As Object()
        Try

            Dim txtName(3) As TextBox
            Dim txtProg(3) As TextBox
            Dim txtPhone(3) As TextBox
            Dim pBoxImage(3) As PictureBox
            Dim action(3) As Button

            Dim obj(3) As Object
            message.Visible = False

            'holds the name textBoxes
            txtName(0) = txtname0
            txtName(1) = txtname1
            txtName(2) = txtname2
            txtName(3) = txtname3
            'holds the programme textBoxes
            txtProg(0) = txtprogramme0
            txtProg(1) = txtprogramme1
            txtProg(2) = txtprogramme2
            txtProg(3) = txtprogramme3
            'holds the phone textBoxes
            txtPhone(0) = txtPhone0
            txtPhone(1) = txtPhone1
            txtPhone(2) = txtPhone2
            txtPhone(3) = txtPhone3
            'holds the image pictureBoxes
            pBoxImage(0) = pBox0
            pBoxImage(1) = pBox1
            pBoxImage(2) = pBox2
            pBoxImage(3) = pBox3

            'holds the action buttons
            action(0) = btn0
            action(1) = btn1
            action(2) = btn2
            action(3) = btn3

            For i = 0 To 3
                txtName(i).Clear()
                txtProg(i).Clear()
                txtPhone(i).Clear()
                action(i).Visible = False
                pBoxImage(i).Image = HMS.My.Resources.Resources.Default_Image
            Next

            If searchType = keyType.Phone Then
                If Not IsExist(keyType.Phone, key) Then
                    message.Visible = True
                    message.Text = "No Student Found"
                    Return Nothing
                Else
                    Me.Fetch(keyType.Phone, key)
                    txtName(0).Text = TruncateString(Me.name)
                    txtProg(0).Text = TruncateString(Me.programme)
                    txtPhone(0).Text = Me.roomNumber
                    pBoxImage(0).Image = ConvertToImage(Me.image)
                    Return Nothing
                End If
                Exit Function
            End If

            If Not Room.IsExist(key.Trim) Then
                message.Visible = True
                message.Text = "Room Doesn't Exist"
                Return Nothing
                Exit Function
            End If

            If Not IsEmptyRoom(key.Trim) Then
                Dim TB = TA.GetDataByRoomN0(key.Trim)
                Dim btnText As String = ActionStatus(key.Trim)

                'loops through the students found and displays them
                For i = 0 To TB.Count - 1

                    obj(i) = New StudentFunctions 'Represents each student in the room

                    obj(i).Fetch(keyType.Id, TB.Rows(i).Item("Index_number"))
                    txtName(i).Text = TruncateString(obj(i).name)
                    txtProg(i).Text = TruncateString(obj(i).programme)
                    txtPhone(i).Text = obj(i).phone
                    pBoxImage(i).Image = ConvertToImage(obj(i).image)
                    action(i).Text = btnText
                    action(i).Visible = True
                Next
                Return obj
            Else
                message.Text = "No Student Found"
                message.ForeColor = Color.Blue
                message.Visible = True
                Return Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    '
    'checks if room is empty
    '
    Private Function IsEmptyRoom(room As String) As Boolean
        Try
            If TA.GetDataByRoomN0(room).Count > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    '
    'fill fields with student's record details using Index number
    '
    Public Sub FillByIndexNo(txtStdName As TextBox, txtIndexNO As MaskedTextBox, CmbProgramme As ComboBox, cmbGender As ComboBox, cmbLevel As ComboBox, txtPhoneNO As MaskedTextBox, txtEmail As TextBox, cmbNumPerRoom As ComboBox, txtRoomNO As MaskedTextBox, txtReceiptNO As TextBox, txtAmountPaid As TextBox, txtBalance As TextBox, DateTimePicker1 As DateTimePicker, Pbox As PictureBox)
        'inserts data into fields
        Room.Fetch(Me.roomNumber)

        txtStdName.Text = Me.name
        txtIndexNO.Text = Me.indexNumber
        CmbProgramme.Text = Me.programme
        cmbGender.Text = Me.gender
        cmbLevel.Text = Me.level
        txtPhoneNO.Text = Me.phone
        txtEmail.Text = Me.email
        cmbNumPerRoom.Text = Room.GetNumberPerRoom.ToString
        txtRoomNO.Text = Me.roomNumber
        txtReceiptNO.Text = Me.receiptNumber
        txtAmountPaid.Text = Me.amountPaid
        txtBalance.Text = Me.balance
        DateTimePicker1.Value = Me.arrivalDate
        Pbox.Image = ConvertToImage(Me.image)


    End Sub

    '
    'fetches a student and sets the attributes
    '
    Public Function Fetch(type As keyType, key As String) As Boolean
        Try

            If Not IsExist(type, key) Then
                Return False
                Exit Function
            End If

            Dim TB As HMS.HMSDBDataSet.StudentTDataTable = Nothing


            If type = keyType.Id Then
                TB = TA.GetDataByID(key)
            ElseIf type = keyType.Phone Then
                TB = TA.GetDataByPhone(key)
            End If

            'assigns record data
            Dim name As String = TB.Rows(0).Item("Stud_name")
            Dim indexNo As String = TB.Rows(0).Item("Index_number")
            Dim prog As String = TB.Rows(0).Item("Programme")
            Dim gender As String = TB.Rows(0).Item("gender")
            Dim level As String = TB.Rows(0).Item("Stud_Level")
            Dim phone As String = TB.Rows(0).Item("PhoneNumber")
            Dim email As String = TB.Rows(0).Item("Email")
            Dim roomNo As String = TB.Rows(0).Item("RoomNumber")
            Dim reeiptNo As String = TB.Rows(0).Item("ReceiptNumber")
            Dim amountPaid As Double = TB.Rows(0).Item("AmountPaid")
            Dim balance As Double = TB.Rows(0).Item("Balance")
            Dim arrivalDate As Date = TB.Rows(0).Item("ArrivalDate")
            Dim img As Image = ConvertToImage(TB.Rows(0).Item("Picture"))
            Dim acd As String = TB.Rows(0).Item("AcademicYear")
            'sets attributes
            SetAttribute(name.Trim, indexNo.Trim, prog.Trim, gender.Trim, level.Trim, phone.Trim, email.Trim, roomNo.Trim, reeiptNo.Trim, amountPaid, balance, arrivalDate, img, acd)

            'set Key number for update
            updateKey = indexNo

            'sets initial room
            original_room = roomNo.Trim
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '
    ' checks if key exists
    '
    Public Function IsExist(Type As keyType, key As String) As Boolean
        If Type = keyType.Id Then
            If TA.GetDataByID(key).Count > 0 Then
                Return True
            Else
                Return False
            End If
        ElseIf Type = keyType.Phone Then
            If TA.GetDataByPhone(key).Count > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    '
    'checks and deletes a Student
    '
    Public Function Delete() As Boolean
        Dim result As Integer
        Try
            result = MessageBox.Show("You Are Deleting Record with key '" + updateKey + "'", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                TA.DeleteByID(updateKey)
                Room.Unassign()
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    '
    'Resets all fields
    '
    Public Function Refresh() As Boolean
        StudentRegistration.cmbprogramme.SelectedIndex = -1
        StudentRegistration.cmbgender.SelectedIndex = -1
        StudentRegistration.cmblevel.SelectedIndex = -1
        StudentRegistration.txtRoom.Clear()
        StudentRegistration.txtname.Clear()
        StudentRegistration.txtindexno.Clear()
        StudentRegistration.txtphoneno.Clear()
        StudentRegistration.txtEmail.Clear()
        StudentRegistration.txtreceipt.Clear()
        StudentRegistration.txtamountpaid.Text = 0
        StudentRegistration.txtbalance.Text = My.Settings.Amount
        StudentRegistration.DateTimePicker1.Value = Today
        StudentRegistration.PictureBox1.Image = HMS.My.Resources.Resources.Default_Image
        StudentRegistration.btnUpdate.Enabled = False
        StudentRegistration.btnDelete.Enabled = False
        StudentRegistration.btnSave.Enabled = True
        StudentRegistration.btnRemove.Enabled = False
        StudentRegistration.ComboBox1.SelectedIndex = 0
        StudentRegistration.ErrorProvider1.Clear()
        StudentRegistration.Panel1.Focus()
        StudentRegistration.validId = False
        StudentRegistration.validName = False
        StudentRegistration.validProg = False
        StudentRegistration.validGender = False
        StudentRegistration.validLevel = False
        StudentRegistration.validPhone = False
        StudentRegistration.validEmail = True
        StudentRegistration.validNumPerRoom = True
        StudentRegistration.validRoomN0 = False
        StudentRegistration.validReceiptN0 = False
        StudentRegistration.validAmountPaid = False
        StudentRegistration.validDate = True
        Return True
    End Function

    '
    'Displays all Student Records in a ListView
    '
    Public Function AllStudent(sortOrder As String, cmb1 As ComboBox, cmb2 As ComboBox, txt As MaskedTextBox) As List(Of StudentFunctions)
        Try
            Dim TB As DataTable = TA.GetData()
            Dim studentList As New List(Of StudentFunctions)
            If sortOrder = "Gender" Then
                If cmb1.SelectedIndex = 0 Then
                    TB = TA.GetData()
                Else
                    TB = TA.SortByGender(cmb1.Text)
                End If
            ElseIf sortOrder = "ID" Then
                If txt.Text.Trim = "" Then
                    TB = TA.GetData()
                Else
                    TB = TA.SortByID(txt.Text.Trim)
                End If
            ElseIf sortOrder = "Level" Then
                If cmb1.SelectedIndex = 0 And cmb2.SelectedIndex = 0 Then
                    TB = TA.GetData()
                ElseIf cmb1.SelectedIndex > 0 And cmb2.SelectedIndex = 0 Then
                    TB = TA.SortByLevel(cmb1.Text)
                ElseIf cmb1.SelectedIndex = 0 And cmb2.SelectedIndex > 0 Then
                    TB = TA.SortByGender(cmb2.Text)
                Else
                    TB = TA.SortByGenderAndLevel(cmb2.Text, cmb1.Text)
                End If
            ElseIf sortOrder = "Name" Then
                If txt.Text.Trim = "" Then
                    TB = TA.GetData()
                Else
                    TB = TA.SortByName(txt.Text.Trim)
                End If
            ElseIf sortOrder = "Room" Then
                If txt.Text.Trim = "" Then
                    TB = TA.GetData()
                Else
                    TB = TA.SortByRoom(txt.Text.Trim)
                End If
            End If

            For Each record In TB.Rows
                Dim name As String = TB.Rows(0).Item("Stud_name")
                Dim indexNo As String = TB.Rows(0).Item("Index_number")
                Dim prog As String = TB.Rows(0).Item("Programme")
                Dim gender As String = TB.Rows(0).Item("gender")
                Dim level As String = TB.Rows(0).Item("Stud_Level")
                Dim phone As String = TB.Rows(0).Item("PhoneNumber")
                Dim email As String = TB.Rows(0).Item("Email")
                Dim roomNo As String = TB.Rows(0).Item("RoomNumber")
                Dim reeiptNo As String = TB.Rows(0).Item("ReceiptNumber")
                Dim amountPaid As Double = TB.Rows(0).Item("AmountPaid")
                Dim balance As Double = TB.Rows(0).Item("Balance")
                Dim arrivalDate As Date = TB.Rows(0).Item("ArrivalDate")
                Dim img As Image = ConvertToImage(TB.Rows(0).Item("Picture"))
                Dim acd As String = TB.Rows(0).Item("AcademicYear")
                'sets attributes

                Dim newStudent As New StudentFunctions
                newStudent.SetAttribute(name.Trim, indexNo.Trim, prog.Trim, gender.Trim, level.Trim, phone.Trim, email.Trim, roomNo.Trim, reeiptNo.Trim, amountPaid, balance, arrivalDate, img, acd)
                studentList.Add(newStudent)
            Next
            Return studentList

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing

        End Try
    End Function
End Class
