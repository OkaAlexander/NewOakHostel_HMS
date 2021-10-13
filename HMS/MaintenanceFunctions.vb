Public Class MaintenanceFunctions
    Inherits GeneralFunctions
    Private TA As New HMSDBDataSetTableAdapters.MaintenanceTTableAdapter

    Private Id As Integer
    Private RoomNo As String
    Private ProblemType As String
    Private Problem As String
    Private CostOfMaintenance As Double
    Private DateOfMaintenance As Date
    Private Remark As String

    Public UpdateID As Integer

    '
    'set properties
    '
    Public Sub SetAttribute(id As Integer, room As String, problemType As String, problem As String, COM As Double, DOM As Date, remark As String)
        Me.Id = id
        Me.RoomNo = room.Trim
        Me.ProblemType = problemType.Trim
        Me.Problem = problem.Trim
        Me.CostOfMaintenance = COM
        Me.DateOfMaintenance = DOM
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
            Return 0
        End Try
    End Function

    'Adds or updates 
    Public Function Add(Optional mode As mode = GeneralFunctions.mode.Save)
        Try

            If mode = mode.Save Then
                If TA.Insert(Me.Id, Me.RoomNo, Me.ProblemType, Me.Problem, Me.CostOfMaintenance, Me.DateOfMaintenance, Me.Remark) Then
                    Return True
                Else
                    Return False
                End If
            ElseIf mode = mode.Update Then
                If TA.UpdateByID(Me.Id, Me.RoomNo, Me.ProblemType, Me.Problem, Me.CostOfMaintenance, Me.DateOfMaintenance, Me.Remark, Me.Id) Then
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

    'fill fields with user's record details using Username

    Public Sub FillByID(room As MaskedTextBox, problemType As ComboBox, Problem As TextBox, costOfMaintenance As MaskedTextBox, dateOfMaintenance As DateTimePicker, remark As ComboBox)
        Try
            'inserts data into fields
            room.Text = Me.RoomNo
            problemType.Text = Me.ProblemType
            Problem.Text = Me.Problem
            costOfMaintenance.Text = Me.CostOfMaintenance
            dateOfMaintenance.Value = Me.DateOfMaintenance
            remark.Text = Me.Remark
        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '
    'Resets all fields
    '
    Public Sub Refresh()
        ComplainsMaintenance.txtRoom2.Clear()
        ComplainsMaintenance.txtCOM.Clear()
        ComplainsMaintenance.ComboBox3.SelectedIndex = -1
        ComplainsMaintenance.TextBox6.Clear()
        ComplainsMaintenance.DateTimePicker2.Value = Today
        ComplainsMaintenance.ComboBox2.SelectedIndex = -1
        ComplainsMaintenance.ErrorProvider1.Clear()
        ComplainsMaintenance.Panel1.Focus()
        ComplainsMaintenance.Button3.Enabled = True
        ComplainsMaintenance.Button2.Enabled = False
        ComplainsMaintenance.Button4.Enabled = False
        ComplainsMaintenance.validName = False
        ComplainsMaintenance.validProblem = False
        ComplainsMaintenance.validProblemType = False
        ComplainsMaintenance.validRemark = False
        ComplainsMaintenance.validRoomN0 = False


    End Sub

    '
    'fetch a maintenance by key and sets its attributes
    '
    Public Function Fetch(Optional maintenanceId As Integer = 0) As Boolean
        Try
            Dim TB = TA.GetDataByID(maintenanceId)

            If Not IsExist(maintenanceId) Then
                Return False
            Else
                Dim id As Integer = TB.Rows(0).Item("Id")
                Dim room As String = TB.Rows(0).Item("RoomN0")
                Dim problemType As String = TB.Rows(0).Item("ProblemType")
                Dim problem As String = TB.Rows(0).Item("Problem")
                Dim costOfMaintenance As Double = TB.Rows(0).Item("CostOfMaintenance")
                Dim dateOfMaintenance As Date = TB.Rows(0).Item("DateOfMaintenance")
                Dim remark As String = TB.Rows(0).Item("Remark")

                SetAttribute(id, room, problemType, problem, costOfMaintenance, dateOfMaintenance, remark)
                UpdateID = id
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


    '
    ' checks if key Exists
    '
    Protected Function IsExist(key As Integer) As Boolean
        If TA.GetDataByID(key).Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    '
    'checks and deletes a maintenance
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
    'Displays all maintenance Records in a ListView
    '
    Public Function AllMaintenance(list As ListView) As Boolean
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
