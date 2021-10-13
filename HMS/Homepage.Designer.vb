<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Homepage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Homepage))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.RecordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StaffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetAmountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisableRoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComplainsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComplainsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeyLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnFullBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDiffBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnFullRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.FullToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDiffRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPortal = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UserMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RecordsToolStripMenuItem, Me.SettingToolStripMenuItem, Me.ComplainsToolStripMenuItem, Me.KeyLogToolStripMenuItem, Me.HelpToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MenuStrip1.Size = New System.Drawing.Size(1284, 40)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'RecordsToolStripMenuItem
        '
        Me.RecordsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StudentToolStripMenuItem, Me.StaffToolStripMenuItem, Me.UsersToolStripMenuItem})
        Me.RecordsToolStripMenuItem.Enabled = False
        Me.RecordsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecordsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RecordsToolStripMenuItem.Name = "RecordsToolStripMenuItem"
        Me.RecordsToolStripMenuItem.Size = New System.Drawing.Size(78, 36)
        Me.RecordsToolStripMenuItem.Text = "Records"
        Me.RecordsToolStripMenuItem.ToolTipText = "click to view records"
        '
        'StudentToolStripMenuItem
        '
        Me.StudentToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.StudentToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.StudentToolStripMenuItem.Name = "StudentToolStripMenuItem"
        Me.StudentToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.StudentToolStripMenuItem.Text = "Student "
        '
        'StaffToolStripMenuItem
        '
        Me.StaffToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.StaffToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.StaffToolStripMenuItem.Name = "StaffToolStripMenuItem"
        Me.StaffToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.StaffToolStripMenuItem.Text = "Staff"
        '
        'UsersToolStripMenuItem
        '
        Me.UsersToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.UsersToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.UsersToolStripMenuItem.Name = "UsersToolStripMenuItem"
        Me.UsersToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.UsersToolStripMenuItem.Text = "Users"
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetAmountToolStripMenuItem, Me.DisableRoomToolStripMenuItem})
        Me.SettingToolStripMenuItem.Enabled = False
        Me.SettingToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SettingToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(71, 36)
        Me.SettingToolStripMenuItem.Text = "Setting"
        '
        'SetAmountToolStripMenuItem
        '
        Me.SetAmountToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SetAmountToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.SetAmountToolStripMenuItem.Name = "SetAmountToolStripMenuItem"
        Me.SetAmountToolStripMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.SetAmountToolStripMenuItem.Text = "Set Amount"
        '
        'DisableRoomToolStripMenuItem
        '
        Me.DisableRoomToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DisableRoomToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.DisableRoomToolStripMenuItem.Name = "DisableRoomToolStripMenuItem"
        Me.DisableRoomToolStripMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.DisableRoomToolStripMenuItem.Text = "Disable Room"
        '
        'ComplainsToolStripMenuItem
        '
        Me.ComplainsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComplainsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComplainsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComplainsToolStripMenuItem.Name = "ComplainsToolStripMenuItem"
        Me.ComplainsToolStripMenuItem.Size = New System.Drawing.Size(96, 36)
        Me.ComplainsToolStripMenuItem.Text = "Complains"
        Me.ComplainsToolStripMenuItem.ToolTipText = "click to lodge a complains"
        '
        'ComplainsToolStripMenuItem1
        '
        Me.ComplainsToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ComplainsToolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.ComplainsToolStripMenuItem1.Name = "ComplainsToolStripMenuItem1"
        Me.ComplainsToolStripMenuItem1.Size = New System.Drawing.Size(281, 26)
        Me.ComplainsToolStripMenuItem1.Text = " Complains and Maintenance"
        '
        'KeyLogToolStripMenuItem
        '
        Me.KeyLogToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyLogToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.KeyLogToolStripMenuItem.Name = "KeyLogToolStripMenuItem"
        Me.KeyLogToolStripMenuItem.Size = New System.Drawing.Size(77, 36)
        Me.KeyLogToolStripMenuItem.Text = "Key Log"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(54, 36)
        Me.HelpToolStripMenuItem.Text = "Help"
        Me.HelpToolStripMenuItem.Visible = False
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackupToolStripMenuItem, Me.btnFullRestore})
        Me.ToolsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(57, 36)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFullBackup, Me.btnDiffBackup})
        Me.BackupToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(133, 26)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'btnFullBackup
        '
        Me.btnFullBackup.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnFullBackup.ForeColor = System.Drawing.Color.White
        Me.btnFullBackup.Name = "btnFullBackup"
        Me.btnFullBackup.Size = New System.Drawing.Size(157, 26)
        Me.btnFullBackup.Text = "Full"
        '
        'btnDiffBackup
        '
        Me.btnDiffBackup.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnDiffBackup.ForeColor = System.Drawing.Color.White
        Me.btnDiffBackup.Name = "btnDiffBackup"
        Me.btnDiffBackup.Size = New System.Drawing.Size(157, 26)
        Me.btnDiffBackup.Text = "Differential"
        Me.btnDiffBackup.Visible = False
        '
        'btnFullRestore
        '
        Me.btnFullRestore.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnFullRestore.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FullToolStripMenuItem1, Me.btnDiffRestore})
        Me.btnFullRestore.ForeColor = System.Drawing.Color.White
        Me.btnFullRestore.Name = "btnFullRestore"
        Me.btnFullRestore.Size = New System.Drawing.Size(133, 26)
        Me.btnFullRestore.Text = "Restore"
        Me.btnFullRestore.Visible = False
        '
        'FullToolStripMenuItem1
        '
        Me.FullToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FullToolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.FullToolStripMenuItem1.Name = "FullToolStripMenuItem1"
        Me.FullToolStripMenuItem1.Size = New System.Drawing.Size(157, 26)
        Me.FullToolStripMenuItem1.Text = "Full"
        '
        'btnDiffRestore
        '
        Me.btnDiffRestore.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnDiffRestore.ForeColor = System.Drawing.Color.White
        Me.btnDiffRestore.Name = "btnDiffRestore"
        Me.btnDiffRestore.Size = New System.Drawing.Size(157, 26)
        Me.btnDiffRestore.Text = "Differential"
        '
        'btnPortal
        '
        Me.btnPortal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnPortal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPortal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPortal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPortal.ForeColor = System.Drawing.Color.White
        Me.btnPortal.Location = New System.Drawing.Point(27, 157)
        Me.btnPortal.Name = "btnPortal"
        Me.btnPortal.Size = New System.Drawing.Size(172, 55)
        Me.btnPortal.TabIndex = 0
        Me.btnPortal.Text = "HALL ASSISTANT"
        Me.btnPortal.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Enabled = False
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(27, 508)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(172, 55)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "REGISTER STAFF"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Enabled = False
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(27, 391)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(172, 55)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "REGISTER USERS"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Enabled = False
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(27, 274)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(172, 55)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "REGISTER STUDENT"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(27, 625)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(172, 55)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "CLOSE"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(543, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(274, 32)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "SECOND HOME HOSTEL"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SaveFileDialog1
        '
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.HMS.My.Resources.Resources.interior_2685521_19201
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(228, 155)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1044, 527)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(900, 470)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 52)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Developed by:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "OASTAGdevs" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "www.oastagdevs.com" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0553215783"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UserMenu
        '
        Me.UserMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.UserMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogOutToolStripMenuItem})
        Me.UserMenu.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserMenu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.UserMenu.Image = CType(resources.GetObject("UserMenu.Image"), System.Drawing.Image)
        Me.UserMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.UserMenu.Name = "UserMenu"
        Me.UserMenu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UserMenu.Size = New System.Drawing.Size(77, 36)
        Me.UserMenu.Text = "Mora"
        Me.UserMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LogOutToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.LogOutToolStripMenuItem.Text = "LogOut"
        '
        'Homepage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CancelButton = Me.Button4
        Me.ClientSize = New System.Drawing.Size(1284, 717)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnPortal)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Homepage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home page"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents RecordsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StudentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StaffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComplainsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComplainsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnPortal As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents UsersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents UserMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetAmountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisableRoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeyLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFullRestore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFullBackup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDiffBackup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FullToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDiffRestore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
