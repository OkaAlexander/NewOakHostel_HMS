Class StaffFunctions
    Inherits GeneralFunctions
    Dim TA As New HMSDBDataSetTableAdapters.STAFFTTableAdapter

    '
    'User Attributes
    '
    Private id As String
    Private firstName As String
    Private lastName As String
    Private email As String
    Private phone As String
    Private rank As String
    Private gender As String
    Private dob As String
    Private image As Byte()

    '
    'set properties
    '
    Public Sub SetAttribute(id As String, firstName As String, lastName As String, email As String, phone As String, rank As String, gender As String, dob As String, image As Image)
        Me.id = id.Trim
        Me.firstName = firstName.Trim
        Me.lastName = lastName.Trim
        Me.email = email.Trim
        Me.phone = phone.Trim
        Me.rank = rank.Trim
        Me.gender = gender.Trim
        Me.dob = dob.Trim
        Me.image = ConvertToByteArray(image)
    End Sub

    
    '
    'Adds or updates a new staff record
    '
    Public Function Add(Optional mode As mode = GeneralFunctions.mode.Save) As Boolean
        Try

            If mode = mode.Save Then
                If TA.Insert(Me.id, Me.firstName, Me.lastName, Me.email, Me.phone, Me.rank, Me.gender, Me.dob, Me.image) Then
                    Return True
                Else
                    Return False
                End If
            ElseIf mode = StudentFunctions.mode.Update Then
                If TA.UpdateByID(Me.id, Me.firstName, Me.lastName, Me.email, Me.phone, Me.rank, Me.gender, Me.dob, Me.image, updateKey) Then
                    Return True
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

    '
    'fill fields with staff's record details using IDNo
    '
    Public Sub FillByIDN0(StaffID As MaskedTextBox, Firstname As TextBox, Lastname As TextBox, Email As TextBox, Phone As MaskedTextBox, Rank As ComboBox, Gender As ComboBox, DOB As MaskedTextBox, Picture As PictureBox)
        'inserts data into fields
        StaffID.Text = Me.id
        Firstname.Text = Me.firstName
        Lastname.Text = Me.lastName
        Email.Text = Me.email
        Phone.Text = Me.phone
        Rank.Text = Me.rank
        Gender.Text = Me.gender
        DOB.Text = Me.dob
        Picture.Image = ConvertToImage(Me.image)
    End Sub

    '
    'fetch a user by id and sets its attributes
    '
    Public Function Fetch(type As keyType, key As String) As Boolean
        Try

            If Not IsExist(type, key) Then
                Return False
                Exit Function
            End If

            Dim TB As HMS.HMSDBDataSet.STAFFTDataTable = Nothing


            If type = keyType.Id Then
                TB = TA.GetDataByID(key)
            ElseIf type = keyType.Phone Then
                TB = TA.GetDataByPhone(key)
            End If
            'inserts data into fields
            Dim id As String = TB.Rows(0).Item("IDN0")
            Dim firstName As String = TB.Rows(0).Item("FirstName")
            Dim lastName As String = TB.Rows(0).Item("LastName")
            Dim email As String = TB.Rows(0).Item("EmailAddress")
            Dim phone As String = TB.Rows(0).Item("PhoneNumber")
            Dim rank As String = TB.Rows(0).Item("Rank")
            Dim gender As String = TB.Rows(0).Item("Gender")
            Dim dob As String = TB.Rows(0).Item("DOB")
            Dim picture As Image = ConvertToImage(TB.Rows(0).Item("SPICTURE"))

            SetAttribute(id, firstName, lastName, email, phone, rank, gender, dob, picture)

            'set username for update
            updateKey = id

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
    'checks and deletes a Staff
    '
    Public Function Delete() As Boolean
        Try
            MessageBox.Show("You Are Deleting Record with key '" + updateKey + "'", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If TA.DeleteByID(updateKey) Then
                MessageBox.Show("Delete Successful", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    Public Sub Refresh()
        StaffRegistration.txtStaffID.Clear()
        StaffRegistration.txtFirstName.Clear()
        StaffRegistration.txtLastName.Clear()
        StaffRegistration.txtPhone.Clear()
        StaffRegistration.txtEmail.Text = "default@example.com"
        StaffRegistration.txtDOB.Clear()
        StaffRegistration.PictureBox1.Image = HMS.My.Resources.Resources.Default_Image
        StaffRegistration.cmbGender.SelectedIndex = -1
        StaffRegistration.cmbRank.SelectedIndex = -1
        StaffRegistration.Panel1.Focus()
        StaffRegistration.ErrorProvider1.Clear()
        StaffRegistration.validStaffID = False
        StaffRegistration.validLName = False
        StaffRegistration.validFName = False
        StaffRegistration.validGender = False
        StaffRegistration.validPhone = False
        StaffRegistration.validEmail = True
        StaffRegistration.validRank = False
        StaffRegistration.validDOB = False
        StaffRegistration.btnDelete.Enabled = False
        StaffRegistration.btnUpdate.Enabled = False
        StaffRegistration.btnSave.Enabled = True
        StaffRegistration.btnRemove.Enabled = False
    End Sub

    '
    'Adds all Staff Records to a ListView
    '
    Public Function AllStaffs(list As ListView) As Boolean
        Try
            list.Items.Clear()
            If TA.GetData.Rows.Count = 0 Then
                Return False
            Else
                For i = 0 To TA.GetData.Rows.Count - 1
                    Dim newItem As New ListViewItem
                    newItem.Text = TA.GetData.Rows(i).Item(0).ToString
                    newItem.SubItems.Add(TA.GetData.Rows(i).Item(1).ToString)
                    newItem.SubItems.Add(TA.GetData.Rows(i).Item(2).ToString)
                    newItem.SubItems.Add(TA.GetData.Rows(i).Item(3).ToString)
                    newItem.SubItems.Add(TA.GetData.Rows(i).Item(4).ToString)
                    newItem.SubItems.Add(TA.GetData.Rows(i).Item(5).ToString)
                    newItem.SubItems.Add(TA.GetData.Rows(i).Item(6).ToString)
                    newItem.SubItems.Add(TA.GetData.Rows(i).Item(7).ToString)
                    list.Items.Add(newItem)
                Next i
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function
End Class
