<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBoss
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
        Me.progHP = New System.Windows.Forms.ProgressBar()
        Me.imgCookie = New System.Windows.Forms.PictureBox()
        Me.CoinDrainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblBossDMG = New System.Windows.Forms.Label()
        CType(Me.imgCookie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'progHP
        '
        Me.progHP.BackColor = System.Drawing.SystemColors.Control
        Me.progHP.Location = New System.Drawing.Point(12, 293)
        Me.progHP.MarqueeAnimationSpeed = 50
        Me.progHP.Name = "progHP"
        Me.progHP.Size = New System.Drawing.Size(314, 23)
        Me.progHP.Step = 1
        Me.progHP.TabIndex = 8
        Me.progHP.Value = 100
        '
        'imgCookie
        '
        Me.imgCookie.BackColor = System.Drawing.Color.DarkRed
        Me.imgCookie.Cursor = System.Windows.Forms.Cursors.Hand
        Me.imgCookie.Enabled = False
        Me.imgCookie.Image = Global.Project_2.My.Resources.Resources.cookie_0
        Me.imgCookie.ImageLocation = ""
        Me.imgCookie.InitialImage = Nothing
        Me.imgCookie.Location = New System.Drawing.Point(-104, -46)
        Me.imgCookie.Name = "imgCookie"
        Me.imgCookie.Size = New System.Drawing.Size(533, 427)
        Me.imgCookie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgCookie.TabIndex = 7
        Me.imgCookie.TabStop = False
        '
        'CoinDrainTimer
        '
        Me.CoinDrainTimer.Interval = 1000
        '
        'lblBossDMG
        '
        Me.lblBossDMG.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblBossDMG.AutoSize = True
        Me.lblBossDMG.BackColor = System.Drawing.Color.Transparent
        Me.lblBossDMG.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBossDMG.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblBossDMG.Location = New System.Drawing.Point(107, 9)
        Me.lblBossDMG.Name = "lblBossDMG"
        Me.lblBossDMG.Size = New System.Drawing.Size(124, 24)
        Me.lblBossDMG.TabIndex = 9
        Me.lblBossDMG.Text = "0 Boss DMG"
        Me.lblBossDMG.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmBoss
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkRed
        Me.ClientSize = New System.Drawing.Size(340, 324)
        Me.Controls.Add(Me.lblBossDMG)
        Me.Controls.Add(Me.progHP)
        Me.Controls.Add(Me.imgCookie)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmBoss"
        Me.Text = "Boss Fight!"
        CType(Me.imgCookie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents progHP As ProgressBar
    Friend WithEvents imgCookie As PictureBox
    Friend WithEvents CoinDrainTimer As Timer
    Friend WithEvents lblBossDMG As Label
End Class
