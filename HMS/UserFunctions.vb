Public Class UserFunctions
    Inherits GeneralFunctions

    Dim TA As New HMSDBDataSetTableAdapters.AddUserTTableAdapter

    '
    'User Attributes
    '
    Private rank As String
    Private name As String
    Private username As String
    Private phone As String
    Private email As String
    Private password As String
    Private image As Byte()

    '
    'set properties
    '
    Public Sub SetAttribute(Name As String, Username As String, Password As String, Rank As String, Phone As String, Email As String, Image As Image)
        Me.rank = Rank.Trim
        Me.name = Name.Trim
        Me.username = Username.Trim
        Me.phone = Phone.Trim
        Me.email = Email.Trim
        Me.password = Password.Trim
        Me.image = ConvertToByteArray(Image)
    End Sub

    '
    ' Checks if user with ID exists
    '
    Public Function IsExistUser() As Boolean
        If TA.GetData.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '
    ' checks if username exists
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
    'checks and deletes a user
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

    'Adds or updates a user's record
    Public Function Add(Optional mode As mode = GeneralFunctions.mode.Save) As Boolean
        Try

            If mode = mode.Save Then
                If TA.Insert(Me.rank, Me.name, Me.username, Me.phone, Me.email, Me.password, Me.image) Then
                    Return True
                Else
                    Return False
                End If
            ElseIf mode = mode.Update Then
                If TA.UpdateByID(Me.rank, Me.name, Me.username, Me.phone, Me.email, Me.password, Me.image, updateKey) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            Refresh()
            Return True
        End Try
    End Function

    'fill fields with user's record details using Username

    Public Sub FillByUsername(rank As ComboBox, name As TextBox, username As TextBox, phone As MaskedTextBox, email As TextBox, password As TextBox, picture As PictureBox)
        Try
            'inserts data into fields
            rank.Text = Me.rank
            name.Text = Me.name
            username.Text = Me.username
            phone.Text = Me.phone
            email.Text = Me.email
            password.Text = Me.password
            picture.Image = ConvertToImage(Me.image)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '
    'Resets all fields
    '
    Public Sub Refresh()
        UserRegistration.cmbRank.SelectedIndex = -1
        UserRegistration.txtName.Clear()
        UserRegistration.txtUsername.Clear()
        UserRegistration.txtPhone.Clear()
        UserRegistration.txtEmail.Text = "default@example.com"
        UserRegistration.txtPassword.Clear()
        UserRegistration.txtConfirmPassword.Clear()
        UserRegistration.PictureBox1.Image = HMS.My.Resources.Resources.Default_Image
        UserRegistration.ErrorProvider1.Clear()
        UserRegistration.Panel1.Focus()
        UserRegistration.btnDelete.Enabled = False
        UserRegistration.btnUpdate.Enabled = False
        UserRegistration.btnSave.Enabled = True
        UserRegistration.btnRemove.Enabled = False
        UserRegistration.validRank = False
        UserRegistration.validUsername = False
        UserRegistration.validName = False
        UserRegistration.validPassword = False
        UserRegistration.validEmail = True
        UserRegistration.validPhone = False
        UserRegistration.validConfrimPassword = False
    End Sub

    '
    'Options
    '
    Public Enum keyType 'Search type options
        Id
        Phone
    End Enum

    '
    'fetch a user by username and sets its attributes
    '
    Public Function Fetch(type As keyType, key As String) As Boolean
        Try
            If Not IsExist(type, key) Then
                Return False
                Exit Function
            End If

            Dim TB As HMS.HMSDBDataSet.AddUserTDataTable = Nothing

            If type = keyType.Id Then
                TB = TA.GetDataByID(key)
            ElseIf type = keyType.Phone Then
                TB = TA.GetDataByPhone(key)
            End If

            Dim rank As String = TB.Rows(0).Item("Rank")
            Dim name As String = TB.Rows(0).Item("Name")
            Dim username As String = TB.Rows(0).Item("UserName")
            Dim phone As String = TB.Rows(0).Item("PhoneNumber")
            Dim email As String = TB.Rows(0).Item("Email")
            Dim password As String = TB.Rows(0).Item("Password")
            Dim picture As Image = ConvertToImage(TB.Rows(0).Item("UPICTURE"))

            SetAttribute(name, username, password, rank, phone, email, picture)

            'set username for update
            updateKey = username

            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '
    'Authenticates the user
    '
    Public Function login(username As String, pass As String) As Boolean
        Try
            'checks if username exist and password is correct 
            If IsExist(keyType.Id, username) And Fetch(keyType.Id, username) And Me.password = pass Then
                My.Settings.Username = Me.username
                If Me.rank = "ADMIN" Then
                    Homepage.Button1.Enabled = True
                    Homepage.Button2.Enabled = True
                    Homepage.Button3.Enabled = True
                    Homepage.RecordsToolStripMenuItem.Enabled = True
                    Homepage.SettingToolStripMenuItem.Enabled = True
                Else
                    Homepage.Button1.Enabled = False
                    Homepage.Button2.Enabled = False
                    Homepage.Button3.Enabled = False
                    Homepage.RecordsToolStripMenuItem.Enabled = False
                    Homepage.SettingToolStripMenuItem.Enabled = False
                End If
                If Me.name.IndexOf(" ") > 0 And Me.name.Substring(0, Me.name.IndexOf(" ") + 1).Length > 13 Then
                    Homepage.UserMenu.Text = Me.name.Substring(0, 10) + "..."
                    Homepage.UserMenu.Image = ConvertToImage(Me.image)
                ElseIf Me.name.IndexOf(" ") > 0 Then
                    Homepage.UserMenu.Text = Me.name.Substring(0, Me.name.IndexOf(" ") + 1)
                    Homepage.UserMenu.Image = ConvertToImage(Me.image)
                ElseIf Me.name.Length > 13 Then
                    Homepage.UserMenu.Text = Me.name.Substring(0, 10) + "..."
                    Homepage.UserMenu.Image = ConvertToImage(Me.image)
                Else
                    Homepage.UserMenu.Text = Me.name
                    Homepage.UserMenu.Image = ConvertToImage(Me.image)
                End If
                Return True
            Else
                MessageBox.Show("Incorrect Username Or Password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Error")
            Return False
        End Try
    End Function

    '
    'Displays all User Records in a ListView
    '
    Public Function AllUsers(list As ListView) As Boolean
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
                    list.Items.Add(newItem)
                Next i
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return True
        End Try
    End Function
End Class
