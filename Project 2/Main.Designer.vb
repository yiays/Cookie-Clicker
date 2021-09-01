<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.DPSTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuAutoSaveToggle = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GitHubToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.progHP = New System.Windows.Forms.ProgressBar()
        Me.lblLVL = New System.Windows.Forms.Label()
        Me.progXP = New System.Windows.Forms.ProgressBar()
        Me.btnHSUpgrades = New System.Windows.Forms.Button()
        Me.imgCookie = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.imgCookie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DPSTimer
        '
        Me.DPSTimer.Enabled = True
        Me.DPSTimer.Interval = 1000
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "sav"
        Me.SaveFileDialog1.FileName = "cookie.sav"
        Me.SaveFileDialog1.Filter = "Clicker Save File|*.sav"
        Me.SaveFileDialog1.RestoreDirectory = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "sav"
        Me.OpenFileDialog1.FileName = "cookie.sav"
        Me.OpenFileDialog1.Filter = "Clicker Save File|*.sav"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(340, 25)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.menuAutoSaveToggle, Me.LoadToolStripMenuItem, Me.ResetToolStripMenuItem, Me.ToolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(39, 21)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'menuAutoSaveToggle
        '
        Me.menuAutoSaveToggle.AutoToolTip = True
        Me.menuAutoSaveToggle.CheckOnClick = True
        Me.menuAutoSaveToggle.Name = "menuAutoSaveToggle"
        Me.menuAutoSaveToggle.Size = New System.Drawing.Size(180, 22)
        Me.menuAutoSaveToggle.Text = "Enable Autosave"
        Me.menuAutoSaveToggle.ToolTipText = "Automatically backs up your save data every time you level up"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LoadToolStripMenuItem.Text = "Load"
        '
        'ResetToolStripMenuItem
        '
        Me.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem"
        Me.ResetToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ResetToolStripMenuItem.Text = "Reset"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(177, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1, Me.GitHubToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(47, 21)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.HelpToolStripMenuItem1.Text = "How to Play"
        '
        'GitHubToolStripMenuItem
        '
        Me.GitHubToolStripMenuItem.Name = "GitHubToolStripMenuItem"
        Me.GitHubToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GitHubToolStripMenuItem.Text = "GitHub"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Century", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(4, 27)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(158, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Clicker Game"
        '
        'progHP
        '
        Me.progHP.BackColor = System.Drawing.SystemColors.Control
        Me.progHP.Location = New System.Drawing.Point(80, 351)
        Me.progHP.MarqueeAnimationSpeed = 50
        Me.progHP.Maximum = 500
        Me.progHP.Name = "progHP"
        Me.progHP.Size = New System.Drawing.Size(184, 10)
        Me.progHP.Step = 1
        Me.progHP.TabIndex = 6
        Me.progHP.Value = 500
        '
        'lblLVL
        '
        Me.lblLVL.AutoSize = True
        Me.lblLVL.Location = New System.Drawing.Point(286, 25)
        Me.lblLVL.Name = "lblLVL"
        Me.lblLVL.Size = New System.Drawing.Size(42, 13)
        Me.lblLVL.TabIndex = 7
        Me.lblLVL.Text = "Level 1"
        Me.lblLVL.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'progXP
        '
        Me.progXP.BackColor = System.Drawing.SystemColors.Control
        Me.progXP.Location = New System.Drawing.Point(283, 41)
        Me.progXP.MarqueeAnimationSpeed = 0
        Me.progXP.Name = "progXP"
        Me.progXP.Size = New System.Drawing.Size(55, 10)
        Me.progXP.Step = 1
        Me.progXP.TabIndex = 8
        '
        'btnHSUpgrades
        '
        Me.btnHSUpgrades.Location = New System.Drawing.Point(309, 345)
        Me.btnHSUpgrades.Name = "btnHSUpgrades"
        Me.btnHSUpgrades.Size = New System.Drawing.Size(31, 23)
        Me.btnHSUpgrades.TabIndex = 10
        Me.btnHSUpgrades.Text = "<<"
        Me.btnHSUpgrades.UseVisualStyleBackColor = True
        '
        'imgCookie
        '
        Me.imgCookie.Cursor = System.Windows.Forms.Cursors.Hand
        Me.imgCookie.Image = Global.Project_2.My.Resources.Resources.cookie_0
        Me.imgCookie.ImageLocation = ""
        Me.imgCookie.InitialImage = Nothing
        Me.imgCookie.Location = New System.Drawing.Point(0, 57)
        Me.imgCookie.Name = "imgCookie"
        Me.imgCookie.Size = New System.Drawing.Size(340, 311)
        Me.imgCookie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgCookie.TabIndex = 2
        Me.imgCookie.TabStop = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 370)
        Me.Controls.Add(Me.btnHSUpgrades)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.progXP)
        Me.Controls.Add(Me.lblLVL)
        Me.Controls.Add(Me.progHP)
        Me.Controls.Add(Me.imgCookie)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "Clicker"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.imgCookie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents imgCookie As PictureBox
    Friend WithEvents progHP As ProgressBar
    Friend WithEvents lblLVL As Label
    Friend WithEvents progXP As ProgressBar
    Friend WithEvents DPSTimer As Timer
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnHSUpgrades As Button
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents menuAutoSaveToggle As ToolStripMenuItem
    Friend WithEvents GitHubToolStripMenuItem As ToolStripMenuItem
End Class
