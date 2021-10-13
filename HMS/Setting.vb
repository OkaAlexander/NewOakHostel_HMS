Public Class Setting
    Dim room As New RoomFunctions
    Private Sub Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtRoom.Focus()
        room.DisabledList(ListBox1)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        room.Enable(ListBox1.SelectedItem)
        ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not room.IsExist(txtRoom.Text.Trim) Then
            ErrorProvider1.SetError(txtRoom, "Room does not exist")
            Exit Sub
        ElseIf ListBox1.Items.Contains(txtRoom.Text.Trim) Then
            ErrorProvider1.SetError(txtRoom, "Room already listed")
            Exit Sub
        ElseIf room.Fetch(txtRoom.Text.Trim) And room.IsFull() Then
            ErrorProvider1.SetError(txtRoom, "Room is already full")
            Exit Sub
        End If
        ErrorProvider1.Clear()
        ListBox1.ClearSelected()
        Button1.Enabled = False
        room.Disable(txtRoom.Text.Trim)
        ListBox1.Items.Clear()
        room.DisabledList(ListBox1)
        ListBox1.SelectedItem = txtRoom.Text.Trim
        txtRoom.Clear()
        txtRoom.Focus()
    End Sub

    Private Sub txtRoom_TextChanged(sender As Object, e As EventArgs) Handles txtRoom.TextChanged
        If Not txtRoom.Text = "" Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
        ErrorProvider1.Clear()
    End Sub
End Class