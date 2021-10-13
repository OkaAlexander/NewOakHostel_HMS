Public Class ComplainFunctions
    Inherits GeneralFunctions
    Private TA As New HMSDBDataSetTableAdapters.StudentComplanTTableAdapter
    Public UpdateID As Integer

    Private Id As Integer
    Private Complaint
    Private RoomNo As String
    Private ProblemType As String
    Private Problem As String
    Private DateOfComplain As Date
    Private Remark As String

    '
    'set properties
    '
    Public Sub SetAttribute(id As Integer, complaint As String, room As String, problemType As String, problem As String, DOC As Date, remark As String)
        Me.Id = id
        Me.Complaint = complaint.Trim
        Me.RoomNo = room.Trim
        Me.ProblemType = problemType.Trim
        Me.Problem = problem.Trim
        Me.DateOfComplain = DOC
        Me.Remark = remark.Trim
    End Sub

    '
    'Generate Id
    '
    Public Function IDGenerator() As Integer
        Try
            Dim tb = TA.GetID
            If tb.Count = 0 Then
                Return 1
            Else
                Return tb.Rows(0).Item("Id") + 1
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    '
    'Adds or updates 
    '
    Public Function Add(Optional mode As mode = GeneralFunctions.mode.Save)
        Try

            If mode = mode.Save Then
                If TA.Insert(Me.Id, Me.Complaint, Me.RoomNo, Me.ProblemType, Me.Problem, Me.DateOfComplain, Me.Remark) Then
                    Return True
                Else
                    Return False
                End If
            ElseIf mode = mode.Update Then
                If TA.UpdateByID(Me.Id, Me.Complaint, Me.RoomNo, Me.ProblemType, Me.Problem, Me.DateOfComplain, Me.Remark, Me.Id) Then
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

    'fill fields with complain record details using Id

    Public Sub FillByID(complaint As TextBox, room As MaskedTextBox, problemType As ComboBox, Problem As TextBox, dateOfComplain As DateTimePicker, remark As ComboBox)
        Try
            'inserts data into fields
            complaint.Text = Me.Complaint
            room.Text = Me.RoomNo
            problemType.Text = Me.ProblemType
            Problem.Text = Me.Problem
            dateOfComplain.Value = Me.DateOfComplain
            remark.Text = Me.Remark
        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '
    'Resets all fields
    '
    Public Sub Refresh()
        ComplainsMaintenance.TextBox1.Clear()
        ComplainsMaintenance.txtRoom1.Clear()
        ComplainsMaintenance.ComboBox4.SelectedIndex = -1
        ComplainsMaintenance.TextBox3.Clear()
        ComplainsMaintenance.DateTimePicker1.Value = Today
        ComplainsMaintenance.ComboBox1.SelectedIndex = -1
        ComplainsMaintenance.ErrorProvider1.Clear()
        ComplainsMaintenance.Panel2.Focus()
        ComplainsMaintenance.Button8.Enabled = True
        ComplainsMaintenance.Button7.Enabled = False
        ComplainsMaintenance.Button6.Enabled = False
        ComplainsMaintenance.validName = False
        ComplainsMaintenance.validProblem = False
        ComplainsMaintenance.validProblemType = False
        ComplainsMaintenance.validRemark = False
        ComplainsMaintenance.validRoomN0 = False
    End Sub

    '
    'fetch a complain by Id and sets its attributes
    '
    Public Function Fetch(Optional Id As Integer = 0) As Boolean
        Try
            Dim TB = TA.GetDataByID(Id)

            If Not IsExist(Id) Then
                Return False
            Else
                Dim idn0 As Integer = TB.Rows(0).Item("Id")
                Dim complaint As String = TB.Rows(0).Item("Complaint")
                Dim room As String = TB.Rows(0).Item("RoomNumber")
                Dim problemType As String = TB.Rows(0).Item("ProblemType")
                Dim problem As String = TB.Rows(0).Item("Problem")
                Dim dateOfComplain As Date = TB.Rows(0).Item("DateOfComplain")
                Dim remark As String = TB.Rows(0).Item("Remark")

                SetAttribute(idn0, complaint, room, problemType, problem, dateOfComplain, remark)
                UpdateID = idn0
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


    '
    ' checks if Key exists
    '
    Protected Function IsExist(key As Integer) As Boolean
        If TA.GetDataByID(key).Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    '
    'checks and deletes a Complain
    '
    Public Function Delete() As Boolean
        Try
            MessageBox.Show("You Are Deleting Record with key '" + Me.Id.ToString + "'", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If TA.DeleteByID(Me.Id) Then
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
    'Displays all Complains Records in a ListView
    '
    Public Function AllComplain(list As ListView) As Boolean
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
