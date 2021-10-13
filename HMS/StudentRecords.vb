Public Class StudentRecords
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel1.DisplayRectangle, Color.White, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.VirtualListSize = 1000

        cmbSort.SelectedItem = "Room"
        displayRecords()

    End Sub

    '
    'Displays student records in listview and displays the count
    '
    Private Sub displayRecords()
        ListView1.Items.Clear()

        If student.AllStudent(cmbSort.Text, ComboBox1, ComboBox2, txtRoom).Count = 0 Then
            ListView1.GridLines = False
            Label19.Visible = True
        Else
            For Each record In student.AllStudent(cmbSort.Text, ComboBox1, ComboBox2, txtRoom)
                Dim newItem As New ListViewItem
                newItem.Text = record.name
                newItem.SubItems.Add(record.indexNumber.ToString)
                newItem.SubItems.Add(record.programme.ToString)
                newItem.SubItems.Add(record.gender.ToString)
                newItem.SubItems.Add(record.level.ToString)
                newItem.SubItems.Add(record.phone.ToString)
                newItem.SubItems.Add(record.email.ToString)
                newItem.SubItems.Add(record.roomNumber.ToString)
                newItem.SubItems.Add(record.receiptNumber.ToString)
                newItem.SubItems.Add(record.amountPaid.ToString)
                newItem.SubItems.Add(record.balance.ToString)
                newItem.SubItems.Add(record.arrivalDate.ToString)
                newItem.SubItems.Add(record.academicYear.ToString)
                ListView1.Items.Add(newItem)
            Next
            ListView1.GridLines = True
            Label19.Visible = False
        End If

        Label2.Text = "Count: " + CStr(NumberOfRecords())
    End Sub

    '
    'Gets Number of records
    '
    Public Function NumberOfRecords() As Integer
        Return ListView1.Items.Count
    End Function


    Private Sub cmbSort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSort.SelectedIndexChanged
        Dim gender(2) As String
        gender(0) = "All"
        gender(1) = "Female"
        gender(2) = "Male"
        Dim level(9) As String
        level(0) = "All"
        level(1) = "100"
        level(2) = "200"
        level(3) = "300"
        level(4) = "400"
        level(5) = "500"
        level(6) = "600"
        level(7) = "Masters"
        level(8) = "PHD"
        level(9) = "Others"
        If cmbSort.SelectedItem = "Gender" Then
            txtRoom.Visible = False
            ComboBox2.Visible = False
            ComboBox1.Items.Clear()
            ComboBox1.Items.AddRange(gender)
            ComboBox1.SelectedIndex = 0
            ComboBox1.Visible = True
        ElseIf cmbSort.SelectedItem = "ID" Then
            ComboBox1.Visible = False
            ComboBox2.Visible = False
            txtRoom.Clear()
            txtRoom.Mask = ">AA00000099"
            txtRoom.Size = New Size(88, 29)
            txtRoom.Visible = True
            txtRoom.Focus()
        ElseIf cmbSort.SelectedItem = "Level" Then
            txtRoom.Visible = False
            ComboBox1.Items.Clear()
            ComboBox1.Items.AddRange(level)
            ComboBox1.SelectedIndex = 0
            ComboBox2.SelectedIndex = 0
            ComboBox1.Visible = True
            ComboBox2.Visible = True
        ElseIf cmbSort.SelectedItem = "Name" Then
            ComboBox1.Visible = False
            ComboBox2.Visible = False
            txtRoom.Clear()
            txtRoom.Mask = ""
            txtRoom.Size = New Size(215, 29)
            txtRoom.Visible = True
            txtRoom.Focus()
        ElseIf cmbSort.SelectedItem = "Room" Then
            ComboBox2.Visible = False
            ComboBox1.Visible = False
            txtRoom.Clear()
            txtRoom.Mask = ">L09"
            txtRoom.Size = New Size(88, 29)
            txtRoom.Visible = True
            txtRoom.Focus()
        End If
        displayRecords()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.Close()
    End Sub

    Private Sub PictureBox6_MouseHover(sender As Object, e As EventArgs) Handles PictureBox6.MouseHover
        PictureBox6.Size = New Size(44, 40)
        PictureBox6.Location = New Point(70, 30)
    End Sub

    Private Sub PictureBox6_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.Size = New Size(40, 40)
        PictureBox6.Location = New Point(74, 32)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged, ComboBox1.SelectedIndexChanged
        displayRecords()
    End Sub


    Private Sub txtRoom_KeyUp(sender As Object, e As KeyEventArgs) Handles txtRoom.KeyUp
        displayRecords()

    End Sub

    Private Sub ListView1_RetrieveVirtualItem(sender As Object, e As RetrieveVirtualItemEventArgs) Handles ListView1.RetrieveVirtualItem

    End Sub
End Class