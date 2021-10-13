Public Class RoomFunctions
    Private TA As New HMSDBDataSetTableAdapters.RoomTTableAdapter
    Private UpdateIdStr As String

    '
    'Attributes
    '
    Private room As String
    Private numOfPeople As Integer
    Private roomStatus As String
    Private roomGender As String
    Private numPerRoom As Integer
    Private keyStatus As String

    '
    'Get key Status
    '
    Public Function GetKeyStatus(roomN0 As String) As String
        If IsExist(roomN0.Trim) Then
            Me.Fetch(roomN0.Trim)
            Return Me.keyStatus
        Else
            Return Nothing
        End If
    End Function

    '
    'Disables the room
    '
    Public Sub Disable(room As String)
        If IsExist(room.Trim) Then
            Fetch(room.Trim)
            If Me.numPerRoom <> Me.numOfPeople And Me.roomStatus = "AVAILABLE" Then
                Me.roomStatus = "UNAVAILABLE"
                Add()
            End If
        End If
    End Sub

    '
    'List of disabled rooms
    '
    Public Sub DisabledList(list As ListBox)
        If TA.GetDataByDisabled.Count = 0 Then
            Exit Sub
        End If
        Dim rooms(TA.GetDataByDisabled.Count - 1) As String
        For i = 0 To TA.GetDataByDisabled.Count - 1
            Dim roomNum As String = TA.GetDataByDisabled.Rows(i).Item("RoomN0").ToString
            list.Items.Add(roomNum)
        Next
    End Sub

    '
    'Checks if Room is disabled
    '
    Public Function Disabled() As Boolean
        If Me.numPerRoom <> Me.numOfPeople And Me.roomStatus = "UNAVAILABLE" Then
            Return True
        Else
            Return False
        End If
    End Function

    '
    'Enables the room
    '
    Public Sub Enable(room As String)
        If IsExist(room.Trim) Then
            Fetch(room.Trim)
            If Disabled() Then
                Me.roomStatus = "AVAILABLE"
                Add()
            End If
        End If
    End Sub

    '
    'Changes the Key Status
    '
    Public Sub ChangeKeyStatus(status As String)
        Me.keyStatus = status
        Me.Add()
    End Sub

    '
    'Sets Attributes
    '
    Private Sub SetAttribute(room As String, numOfPeople As Integer, roomStatus As String, roomgender As String, numPerRoom As Integer, keyStatus As String)
        Me.room = room.Trim
        Me.numOfPeople = numOfPeople
        Me.roomStatus = roomStatus.Trim
        Me.roomGender = roomgender.Trim
        Me.numPerRoom = numPerRoom
        Me.keyStatus = keyStatus.Trim
    End Sub

    '
    'Returns Number per room
    '
    Public Function GetNumberPerRoom() As Integer
        Return Me.numPerRoom
    End Function

    '
    'checks the kind of gender a room accepts
    '
    Public Function GenderAccept(gender As String) As Boolean
        Try
            If Me.roomGender = "NONE" Then
                Me.roomGender = gender
                Return True
            ElseIf Me.roomGender = gender Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    '
    'checks Number per room is accepted
    '
    Public Function NumberPerRoom(numPerRoom As Integer) As Boolean
        Try
            If numPerRoom = Me.numPerRoom Then
                Return True
            ElseIf Me.numOfPeople = 0 And numPerRoom <> Me.numOfPeople Then
                Me.numPerRoom = numPerRoom
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    '
    ' checks if key exists
    '
    Public Function IsExist(key As String) As Boolean
        If TA.GetDataByID(key).Count > 0 Then
            Fetch(key)
            Return True
        Else
            Return False
        End If
    End Function

    '
    'fetches the room
    '
    Public Function Fetch(room As String) As Boolean
        Try
            Dim TB = TA.GetDataByID(room)

            Dim roomNum As String = TB.Rows(0).Item("RoomN0")
            Dim numOfPeople As Integer = TB.Rows(0).Item("NumOfPeople")
            Dim status As String = TB.Rows(0).Item("RoomStatus")
            Dim roomGender As String = TB.Rows(0).Item("RoomGender")
            Dim numPerRoom As Integer = TB.Rows(0).Item("NumPerRoom")
            Dim keyStatus As String = TB.Rows(0).Item("KeyStatus")
            SetAttribute(roomNum.Trim, numOfPeople, status.Trim, roomGender.Trim, numPerRoom, keyStatus)

                'set room for update
                UpdateIdStr = roomNum

                Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '
    'Generates The Amount To Be Paid
    '
    Public Function AmountToPay(numPerRoom As Integer) As Double
        Return (My.Settings.Amount * 4) / numPerRoom
    End Function

    '
    'Generates Balance to be paid
    '
    Public Function Balance(numPerRoom As Integer, amount As Double) As Double
        Return AmountToPay(numPerRoom) - amount
    End Function

    '
    'Adds or updates a room record
    '
    Public Sub Add()
        Try
            TA.UpdateByID(Me.room, Me.numOfPeople, Me.roomStatus, Me.roomGender, Me.numPerRoom, Me.keyStatus, UpdateIdStr)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '
    'checks if room is full
    '
    Public Function IsFull() As Boolean
        If "AVAILABLE" = Me.roomStatus.Trim Then
            Return False
        Else
            Return True
        End If
    End Function

    '
    'get number of student in room
    '
    Public Function NumInRoom() As String
        Return Me.numOfPeople
    End Function
    '
    'Assigns room
    '
    Public Sub Assign()
        Me.numOfPeople += 1
        If Me.numOfPeople = Me.numPerRoom Then
            Me.roomStatus = "UNAVAILABLE"
        End If
        Add()
    End Sub

    '
    'Unassign Room
    '
    Public Sub Unassign()
        Me.numOfPeople -= 1
        Me.roomStatus = "AVAILABLE"
        If Me.numOfPeople = 0 Then
            Me.roomGender = "NONE"
            Me.numPerRoom = 4
        End If
        Add()
    End Sub

    '
    'THIS IS A SPECIAL ALGORITHM DESIGNED BY @MORA 
    '
    'Suggest Room Based on Gender and Level
    '
    Public Function Suggest(Optional gender As String = Nothing, Optional level As Integer = 0, Optional numPerRoom As Integer = 4) As String
        Dim roomNo As String
        Dim i As Integer = 0
        If gender <> Nothing Then
            If gender = "FEMALE" Then
                If TA.SuggestFemale1(numPerRoom).Count > 0 Then
                    roomNo = TA.SuggestFemale1(numPerRoom).Rows(i).Item("RoomN0")
                ElseIf TA.SuggestFemale2.Count > 0 Then
                    roomNo = TA.SuggestFemale2.Rows(i).Item("RoomN0")
                Else
                    Return Nothing
                End If
            ElseIf gender = "MALE" And (level = 0 Or level = 100) Then
                If TA.SuggestAllMale1(numPerRoom).Count > 0 Then
                    roomNo = TA.SuggestAllMale1(numPerRoom).Rows(i).Item("RoomN0")
                ElseIf TA.SuggestAllMale2.Count > 0 Then
                    roomNo = TA.SuggestAllMale2.Rows(i).Item("RoomN0")
                Else
                    Return Nothing
                End If
            ElseIf gender = "MALE" And level <> 100 And TA.SuggestSomeMale1(numPerRoom).Count > 0 Then
                If TA.SuggestSomeMale1(numPerRoom).Count > 0 Then
                    roomNo = TA.SuggestSomeMale1(numPerRoom).Rows(i).Item("RoomN0")
                ElseIf TA.SuggestSomeMale2.Count > 0 Then
                    roomNo = TA.SuggestSomeMale2.Rows(i).Item("RoomN0")
                Else
                    Return Nothing
                End If
            ElseIf gender = "MALE" And level <> 100 And TA.SuggestSomeMale1(numPerRoom).Count = 0 Then
                If TA.SuggestAllMale1(numPerRoom).Count > 0 Then
                    roomNo = TA.SuggestAllMale1(numPerRoom).Rows(i).Item("RoomN0")
                ElseIf TA.SuggestAllMale2.Count > 0 Then
                    roomNo = TA.SuggestAllMale2.Rows(i).Item("RoomN0")
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
            Return roomNo.Trim
        Else
            Return Nothing
        End If
    End Function

End Class
