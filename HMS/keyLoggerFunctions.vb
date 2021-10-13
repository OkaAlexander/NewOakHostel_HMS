Public Class keyLoggerFunctions
    Inherits GeneralFunctions
    Dim TA As New HMSDBDataSetTableAdapters.keyLoggerTTableAdapter

    Public DateOfLog As Date
    Public RoomN0 As String
    Public IndexN0 As String
    Public NameOfStudent As String
    Public Action As String
    Public Username As String
    '
    'Set Attributes
    '
    Private Sub SetAttribute(DateOfLog As Date, RoomN0 As String, IndexN0 As String, NameOfStudent As String, Action As String, Username As String)
        Me.DateOfLog = DateOfLog
        Me.RoomN0 = RoomN0
        Me.NameOfStudent = NameOfStudent
        Me.Action = Action
        Me.IndexN0 = IndexN0
        Me.Username = Username
    End Sub

    '
    'Gets last student who took the key
    '
    Public Function LastCheckOut(room As String) As String
        Fetch(room)
        Return Me.IndexN0
    End Function

    Public Function Fetch(key As String) As Boolean
        Try

            Dim TB = TA.GetDataByRoom(key)

            Dim DateOfLog As Date = TB.Rows(0).Item("DateOfLog")
            Dim RoomN0 As String = TB.Rows(0).Item("RoomN0")
            Dim IndexN0 As String = TB.Rows(0).Item("IndexN0")
            Dim NameOfStudent As String = TB.Rows(0).Item("NameOfStudent")
            Dim Action As String = TB.Rows(0).Item("Action")
            Dim Username As String = TB.Rows(0).Item("Username")

            SetAttribute(DateOfLog, RoomN0, IndexN0, NameOfStudent, Action, Username)

            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '
    'Adds new log
    '
    Public Sub Add()
        Try
            TA.Insert(Me.DateOfLog, Me.RoomN0, Me.IndexN0, Me.NameOfStudent, Me.Action, Me.Username)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '
    'Creates new log
    '
    Public Sub CreateLog(student As Object, action As String)
        Me.SetAttribute(Now, student.roomNumber, student.indexNumber, student.name, action, My.Settings.Username)
    End Sub

    '
    'Displays the key log in Listview
    '
    Public Function ViewLog(listview As ListView) As Boolean
        listview.Items.Clear()
        Dim TB = TA.GetData
        If TB.Rows.Count = 0 Then
            Return False
        Else
            For i = 0 To TA.GetData.Rows.Count - 1
                Dim newItem As New ListViewItem
                newItem.Text = TB.Rows(i).Item(0).ToString
                newItem.SubItems.Add(TB.Rows(i).Item(1).ToString)
                newItem.SubItems.Add(TB.Rows(i).Item(2).ToString)
                newItem.SubItems.Add(TB.Rows(i).Item(3).ToString)
                newItem.SubItems.Add(TB.Rows(i).Item(4).ToString)
                newItem.SubItems.Add(TB.Rows(i).Item(5).ToString)
                listview.Items.Add(newItem)
            Next i
            Return True
        End If
    End Function

    '
    'Get action String
    '
    Public Function ActionString(status As String) As String
        If status = "IN" Then
            Return "CheckOut"
        Else
            Return "CheckIn"
        End If
    End Function
End Class
