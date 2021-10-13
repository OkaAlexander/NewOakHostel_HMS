Public Class ComplainsMaintenance

    Dim maintenance As New MaintenanceFunctions
    Dim complain As New ComplainFunctions

    Public validName As Boolean
    Public validProblem As Boolean
    Public validProblemType As Boolean
    Public validRemark As Boolean
    Public validRoomN0 As Boolean

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel2.DisplayRectangle, Color.White, ButtonBorderStyle.Solid)
    End Sub



    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel1.DisplayRectangle, Color.White, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel4.DisplayRectangle, Color.White, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel5.DisplayRectangle, Color.White, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel6.DisplayRectangle, Color.White, ButtonBorderStyle.Solid)
    End Sub
    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel3.DisplayRectangle, Color.White, ButtonBorderStyle.Solid)
    End Sub

    '
    'for Maintenance Tab
    '
    'Save Button
    '
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If validRoomN0 And validProblemType And validProblem And validRemark Then
            maintenance.SetAttribute(maintenance.IDGenerator, txtRoom2.Text, ComboBox3.Text, TextBox6.Text, CDbl(txtCOM.Text), DateTimePicker2.Value, ComboBox2.Text)
            If maintenance.Add() Then
                maintenance.Refresh()
                ShowMessage(Timer2, Label19, Color.Lime, "Save Successful")
            Else
                ShowMessage(Timer2, Label19, Color.Lime, "Save Unsuccessful")
            End If
        Else
            validProblemType = ValidateComboBox(ErrorProvider1, ComboBox4, "Select Problem Type", txtSearch1)
            validProblem = ValidateProblem(ErrorProvider1, TextBox3, txtSearch1)
            validRemark = ValidateComboBox(ErrorProvider1, ComboBox1, "Select Remark", txtSearch1)
            validRoomN0 = ValidateRoomN01(ErrorProvider1, txtRoom1, txtSearch1)
            ShowMessage(Timer2, Label19, Color.Lime, "Save Unsuccessful")
        End If
    End Sub

    '
    'Update Button
    '
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If validRoomN0 And validProblemType And validProblem And validRemark Then
            maintenance.SetAttribute(maintenance.updateKey, txtRoom2.Text, ComboBox3.Text, TextBox6.Text, CDbl(txtCOM.Text), DateTimePicker2.Value, ComboBox2.Text)
            If maintenance.Add(GeneralFunctions.mode.Update) Then
                maintenance.Refresh()
                ShowMessage(Timer2, Label19, Color.Lime, "Update Successful")
            Else
                ShowMessage(Timer2, Label19, Color.Red, "Update Unsuccessful")
            End If
        Else
            ShowMessage(Timer2, Label19, Color.Red, "Update Unsuccessful")
        End If
    End Sub

    '
    'Close Message
    '
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        CloseMessage(Timer2, Label19)
    End Sub

    '
    'Delete Button
    '
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If maintenance.Delete() Then
            maintenance.refresh()
            ShowMessage(Timer2, Label19, Color.Lime, "Delete Successful")
        End If
    End Sub


    '
    'Search Button
    '
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btnSearch2.Click
        maintenance.Refresh()
        If maintenance.Fetch(txtSearch1.Text) Then
            maintenance.FillByID(txtRoom2, ComboBox3, TextBox6, txtCOM, DateTimePicker1, ComboBox2)
            validRoomN0 = True
            validProblemType = True
            validProblem = True
            validRemark = True
            Me.Button2.Enabled = True
            Me.Button4.Enabled = True
            Me.Button3.Enabled = False
        Else
            ShowMessage(Timer1, Label19, Color.Blue, "No Record Found")
        End If
    End Sub

    '
    'Cancel Button
    '
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        maintenance.refresh()
    End Sub

    '
    'For Complain Tab
    '
    'Search Button
    '
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        complain.Refresh()
        If complain.Fetch(txtSearch.Text) Then
            complain.FillByID(TextBox1, txtRoom1, ComboBox4, TextBox3, DateTimePicker1, ComboBox1)
            validName = True
            validRoomN0 = True
            validProblemType = True
            validProblem = True
            validRemark = True
            Me.Button7.Enabled = True
            Me.Button6.Enabled = True
            Me.Button8.Enabled = False
        Else
            ShowMessage(Timer1, Label18, Color.Blue, "No Record Found")
        End If
    End Sub

    '
    'Save Button
    '
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If validName And validRoomN0 And validProblemType And validProblem And validRemark Then
            complain.SetAttribute(complain.IDGenerator, TextBox1.Text, txtRoom1.Text, ComboBox4.Text, TextBox3.Text, DateTimePicker1.Value, ComboBox1.Text)
            If complain.Add() Then
                complain.Refresh()
                ShowMessage(Timer1, Label18, Color.Lime, "Save Successful")
            Else
                ShowMessage(Timer1, Label18, Color.Red, "Save Unsuccessful")
            End If
        Else
            validName = ValidateName(ErrorProvider1, TextBox1, "Invalid Name", txtSearch)
            validProblemType = ValidateComboBox(ErrorProvider1, ComboBox4, "Select Problem Type", txtSearch)
            validProblem = ValidateProblem(ErrorProvider1, TextBox3, txtSearch)
            validRemark = ValidateComboBox(ErrorProvider1, ComboBox1, "Select Remark", txtSearch)
            validRoomN0 = ValidateRoomN01(ErrorProvider1, txtRoom1, txtSearch)
            ShowMessage(Timer1, Label18, Color.Red, "Save Unsuccessful")
        End If
    End Sub

    '
    'Update Button
    '
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If validName And validRoomN0 And validProblemType And validProblem And validRemark Then
            complain.SetAttribute(complain.updateKey, TextBox1.Text, txtRoom1.Text, ComboBox4.Text, TextBox3.Text, DateTimePicker1.Value, ComboBox1.Text)
            If complain.Add(GeneralFunctions.mode.Update) Then
                complain.Refresh()
                ShowMessage(Timer1, Label18, Color.Lime, "Update Successful")
            Else
                ShowMessage(Timer1, Label18, Color.Red, "Update Unsuccessful")
            End If
        Else
            ShowMessage(Timer1, Label18, Color.Red, "Update Unsuccessful")
        End If
    End Sub

    '
    'Delete Button
    '
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If complain.Delete() Then
            complain.Refresh()
            ShowMessage(Timer1, Label18, Color.Lime, "Delete Successful")
        End If
    End Sub

    '
    'Close Message
    '
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CloseMessage(Timer1, Label18)
    End Sub

    '
    'Cancel Button
    '
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        complain.Refresh()
    End Sub

    '
    'Loads All Maintenance and Complains
    '
    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        If TabControl1.SelectedTab.Equals(TabPage1) Then
            Panel2.Focus()
        ElseIf TabControl1.SelectedTab.Equals(TabPage2) Then
            Panel1.Focus()
        ElseIf TabControl1.SelectedTab.Equals(TabPage3) Then
            ListView1.Items.Clear()
            If Not complain.AllComplain(ListView1) Then
                ListView1.GridLines = False
                Label20.Visible = True
            End If
        ElseIf TabControl1.SelectedTab.Equals(TabPage4) Then
            ListView2.Items.Clear()
            If Not maintenance.AllMaintenance(ListView2) Then
                ListView2.GridLines = False
                Label21.Visible = True
            End If
        End If
    End Sub

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Focus()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        validName = ValidateName(ErrorProvider1, TextBox1, "Invalid Name", txtSearch)
    End Sub

    Private Sub ComboBox4_Leave(sender As Object, e As EventArgs) Handles ComboBox4.Leave
        validProblemType = ValidateComboBox(ErrorProvider1, ComboBox4, "Select Problem Type", txtSearch)
    End Sub

    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles TextBox3.Leave
        validProblem = ValidateProblem(ErrorProvider1, TextBox3, txtSearch)
    End Sub

    Private Sub ComboBox1_Leave(sender As Object, e As EventArgs) Handles ComboBox1.Leave
        validRemark = ValidateComboBox(ErrorProvider1, ComboBox1, "Select Remark", txtSearch)
    End Sub

    Private Sub txtRoom1_Leave(sender As Object, e As EventArgs) Handles txtRoom1.Leave
        validRoomN0 = ValidateRoomN01(ErrorProvider1, txtRoom1, txtSearch)
    End Sub

    Private Sub btnRefresh1_Click(sender As Object, e As EventArgs) Handles btnRefresh1.Click
        txtSearch.Clear()
    End Sub

    Private Sub txtRoom2_Leave(sender As Object, e As EventArgs) Handles txtRoom2.Leave
        validRoomN0 = ValidateRoomN01(ErrorProvider1, txtRoom1, txtSearch1)
    End Sub

    Private Sub ComboBox3_Leave(sender As Object, e As EventArgs) Handles ComboBox3.Leave
        validProblemType = ValidateComboBox(ErrorProvider1, ComboBox4, "Select Problem Type", txtSearch1)
    End Sub

    Private Sub TextBox6_Leave(sender As Object, e As EventArgs) Handles TextBox6.Leave
        validProblem = ValidateProblem(ErrorProvider1, TextBox3, txtSearch1)
    End Sub

    Private Sub ComboBox2_Leave(sender As Object, e As EventArgs) Handles ComboBox2.Leave
        validRemark = ValidateComboBox(ErrorProvider1, ComboBox1, "Select Remark", txtSearch1)
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        txtSearch1.Clear()
    End Sub

    Private Sub PictureBox6_MouseHover(sender As Object, e As EventArgs) Handles PictureBox6.MouseHover
        PictureBox6.Size = New Size(44, 40)
        PictureBox6.Location = New Point(70, 30)
    End Sub

    Private Sub PictureBox6_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.Size = New Size(40, 40)
        PictureBox6.Location = New Point(74, 32)
    End Sub

    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        PictureBox1.Size = New Size(44, 40)
        PictureBox1.Location = New Point(70, 30)
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.Size = New Size(40, 40)
        PictureBox1.Location = New Point(74, 32)
    End Sub

    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox2.MouseHover
        PictureBox2.Size = New Size(44, 40)
        PictureBox2.Location = New Point(70, 30)
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.Size = New Size(40, 40)
        PictureBox2.Location = New Point(74, 32)
    End Sub

    Private Sub PictureBox3_MouseHover(sender As Object, e As EventArgs) Handles PictureBox3.MouseHover
        PictureBox3.Size = New Size(44, 40)
        PictureBox3.Location = New Point(70, 30)
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.Size = New Size(40, 40)
        PictureBox3.Location = New Point(74, 32)
    End Sub

End Class