<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpgrades
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Cursor Upgrades", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Passive Upgrades", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "Bigger Cursor", "0", "$20", "+1 DMG"}, 0, System.Drawing.Color.Empty, System.Drawing.Color.Transparent, Nothing)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "Sharper Teeth", "0", "$180", "+10 DMG"}, 1)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "Liposuction", "0", "$300", "+25 DMG"}, 2)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "Unhinged Jaw", "0", "$2500", "+100 DMG"}, 3)
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "Auto Clickers", "0", "$100", "+1 DPS"}, 4)
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "Cookie Bakers", "0", "$500", "+5 DPS"}, 5)
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "Cookie Factory", "0", "$3500", "+50 DPS"}, 6)
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "Cookie Nuke", "0", "$8000", "+100 DPS"}, 7)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpgrades))
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Total Upgrades", "0"}, -1)
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Total Clicks", "0"}, -1)
        Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Total Cash", "$0"}, -1)
        Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Total Dead Cookies", "0"}, -1)
        Dim ListViewItem13 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"DMG", "1"}, -1)
        Dim ListViewItem14 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"DPS", "0"}, -1)
        Dim ListViewItem15 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Total Time Played", "00:00:00"}, -1)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblDMG = New System.Windows.Forms.Label()
        Me.lblDPS = New System.Windows.Forms.Label()
        Me.lblCoins = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.tabUpgrades = New System.Windows.Forms.TabPage()
        Me.btnSacrifice = New System.Windows.Forms.Button()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.btnRefund = New System.Windows.Forms.Button()
        Me.btnBuy = New System.Windows.Forms.Button()
        Me.listUpgrades = New System.Windows.Forms.ListView()
        Me.ColumnHeader0 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageListUpgrades = New System.Windows.Forms.ImageList(Me.components)
        Me.tabCheat = New System.Windows.Forms.TabPage()
        Me.btnTakeDMG = New System.Windows.Forms.Button()
        Me.btnTakeDPS = New System.Windows.Forms.Button()
        Me.btnTakeCoins = New System.Windows.Forms.Button()
        Me.numAddDMG = New System.Windows.Forms.NumericUpDown()
        Me.btnAddDMG = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLvlUp = New System.Windows.Forms.Button()
        Me.btnLvlDown = New System.Windows.Forms.Button()
        Me.btnHealCookie = New System.Windows.Forms.Button()
        Me.btnInstakill = New System.Windows.Forms.Button()
        Me.numAddDPS = New System.Windows.Forms.NumericUpDown()
        Me.btnAddDPS = New System.Windows.Forms.Button()
        Me.numAddCoins = New System.Windows.Forms.NumericUpDown()
        Me.btnAddCoins = New System.Windows.Forms.Button()
        Me.listStats = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pbCoin = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.tabUpgrades.SuspendLayout()
        Me.tabCheat.SuspendLayout()
        CType(Me.numAddDMG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numAddDPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAddCoins, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCoin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblDMG)
        Me.Panel1.Controls.Add(Me.lblDPS)
        Me.Panel1.Controls.Add(Me.pbCoin)
        Me.Panel1.Controls.Add(Me.lblCoins)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(302, 45)
        Me.Panel1.TabIndex = 7
        '
        'lblDMG
        '
        Me.lblDMG.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDMG.AutoSize = True
        Me.lblDMG.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDMG.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDMG.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblDMG.Location = New System.Drawing.Point(10, 11)
        Me.lblDMG.Name = "lblDMG"
        Me.lblDMG.Size = New System.Drawing.Size(60, 20)
        Me.lblDMG.TabIndex = 6
        Me.lblDMG.Text = "1 DMG"
        '
        'lblDPS
        '
        Me.lblDPS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDPS.AutoSize = True
        Me.lblDPS.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDPS.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblDPS.Location = New System.Drawing.Point(96, 11)
        Me.lblDPS.Name = "lblDPS"
        Me.lblDPS.Size = New System.Drawing.Size(55, 20)
        Me.lblDPS.TabIndex = 5
        Me.lblDPS.Text = "0 DPS"
        '
        'lblCoins
        '
        Me.lblCoins.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCoins.AutoSize = True
        Me.lblCoins.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblCoins.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoins.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblCoins.Location = New System.Drawing.Point(223, 11)
        Me.lblCoins.Name = "lblCoins"
        Me.lblCoins.Size = New System.Drawing.Size(27, 20)
        Me.lblCoins.TabIndex = 4
        Me.lblCoins.Text = "$0"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.tabUpgrades)
        Me.TabControl.Controls.Add(Me.tabCheat)
        Me.TabControl.Location = New System.Drawing.Point(0, 44)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(302, 325)
        Me.TabControl.TabIndex = 6
        '
        'tabUpgrades
        '
        Me.tabUpgrades.BackColor = System.Drawing.Color.Transparent
        Me.tabUpgrades.Controls.Add(Me.btnSacrifice)
        Me.tabUpgrades.Controls.Add(Me.lblDescription)
        Me.tabUpgrades.Controls.Add(Me.btnRefund)
        Me.tabUpgrades.Controls.Add(Me.btnBuy)
        Me.tabUpgrades.Controls.Add(Me.listUpgrades)
        Me.tabUpgrades.Location = New System.Drawing.Point(4, 22)
        Me.tabUpgrades.Name = "tabUpgrades"
        Me.tabUpgrades.Padding = New System.Windows.Forms.Padding(3)
        Me.tabUpgrades.Size = New System.Drawing.Size(294, 299)
        Me.tabUpgrades.TabIndex = 0
        Me.tabUpgrades.Text = "Upgrades"
        '
        'btnSacrifice
        '
        Me.btnSacrifice.Enabled = False
        Me.btnSacrifice.Location = New System.Drawing.Point(161, 272)
        Me.btnSacrifice.Name = "btnSacrifice"
        Me.btnSacrifice.Size = New System.Drawing.Size(130, 23)
        Me.btnSacrifice.TabIndex = 6
        Me.btnSacrifice.Text = "Sacrifice"
        Me.btnSacrifice.UseVisualStyleBackColor = True
        Me.btnSacrifice.Visible = False
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(7, 240)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(279, 29)
        Me.lblDescription.TabIndex = 5
        Me.lblDescription.Text = "Select an upgrade for more information."
        '
        'btnRefund
        '
        Me.btnRefund.Enabled = False
        Me.btnRefund.Location = New System.Drawing.Point(161, 272)
        Me.btnRefund.Name = "btnRefund"
        Me.btnRefund.Size = New System.Drawing.Size(130, 23)
        Me.btnRefund.TabIndex = 4
        Me.btnRefund.Text = "Refund"
        Me.btnRefund.UseVisualStyleBackColor = True
        '
        'btnBuy
        '
        Me.btnBuy.Enabled = False
        Me.btnBuy.Location = New System.Drawing.Point(31, 272)
        Me.btnBuy.Name = "btnBuy"
        Me.btnBuy.Size = New System.Drawing.Size(124, 23)
        Me.btnBuy.TabIndex = 3
        Me.btnBuy.Text = "Buy"
        Me.btnBuy.UseVisualStyleBackColor = True
        '
        'listUpgrades
        '
        Me.listUpgrades.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader0, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.listUpgrades.FullRowSelect = True
        ListViewGroup1.Header = "Cursor Upgrades"
        ListViewGroup1.Name = "ListViewGroup1"
        ListViewGroup2.Header = "Passive Upgrades"
        ListViewGroup2.Name = "ListViewGroup2"
        Me.listUpgrades.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2})
        Me.listUpgrades.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.listUpgrades.HideSelection = False
        ListViewItem1.Group = ListViewGroup1
        ListViewItem1.StateImageIndex = 0
        ListViewItem1.Tag = ""
        ListViewItem1.ToolTipText = "Increases the size of the cursor, making each click more effective."
        ListViewItem2.Checked = True
        ListViewItem2.Group = ListViewGroup1
        ListViewItem2.StateImageIndex = 1
        ListViewItem2.ToolTipText = "Bite through cookies like they're nothing."
        ListViewItem3.Checked = True
        ListViewItem3.Group = ListViewGroup1
        ListViewItem3.StateImageIndex = 2
        ListViewItem3.ToolTipText = "Eat cookies faster without the guilt."
        ListViewItem4.Checked = True
        ListViewItem4.Group = ListViewGroup1
        ListViewItem4.StateImageIndex = 3
        ListViewItem4.ToolTipText = "Fit more of the cookie in your mouth at once."
        ListViewItem5.Checked = True
        ListViewItem5.Group = ListViewGroup2
        ListViewItem5.StateImageIndex = 4
        ListViewItem5.ToolTipText = "Get more cursors that click for you."
        ListViewItem6.Checked = True
        ListViewItem6.Group = ListViewGroup2
        ListViewItem6.StateImageIndex = 5
        ListViewItem6.ToolTipText = "Hire bakers to make and then burn cookies."
        ListViewItem7.Checked = True
        ListViewItem7.Group = ListViewGroup2
        ListViewItem7.StateImageIndex = 6
        ListViewItem7.ToolTipText = "Get robots to bake and then burn the cookies, too."
        ListViewItem8.Checked = True
        ListViewItem8.Group = ListViewGroup2
        ListViewItem8.StateImageIndex = 7
        ListViewItem8.ToolTipText = "It's like Hiroshima, but with cookies. Radiation poisoning passively kills cookie" &
    "s."
        Me.listUpgrades.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8})
        Me.listUpgrades.LargeImageList = Me.ImageListUpgrades
        Me.listUpgrades.Location = New System.Drawing.Point(0, 0)
        Me.listUpgrades.MultiSelect = False
        Me.listUpgrades.Name = "listUpgrades"
        Me.listUpgrades.Scrollable = False
        Me.listUpgrades.ShowItemToolTips = True
        Me.listUpgrades.Size = New System.Drawing.Size(294, 237)
        Me.listUpgrades.SmallImageList = Me.ImageListUpgrades
        Me.listUpgrades.TabIndex = 2
        Me.listUpgrades.UseCompatibleStateImageBehavior = False
        Me.listUpgrades.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.Text = ""
        Me.ColumnHeader0.Width = 24
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Upgrade"
        Me.ColumnHeader1.Width = 87
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Owned"
        Me.ColumnHeader2.Width = 46
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Cost"
        Me.ColumnHeader3.Width = 52
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Effect"
        Me.ColumnHeader4.Width = 98
        '
        'ImageListUpgrades
        '
        Me.ImageListUpgrades.ImageStream = CType(resources.GetObject("ImageListUpgrades.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListUpgrades.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListUpgrades.Images.SetKeyName(0, "cursor.png")
        Me.ImageListUpgrades.Images.SetKeyName(1, "tooth.png")
        Me.ImageListUpgrades.Images.SetKeyName(2, "fat.png")
        Me.ImageListUpgrades.Images.SetKeyName(3, "openjaw.png")
        Me.ImageListUpgrades.Images.SetKeyName(4, "autocursor.png")
        Me.ImageListUpgrades.Images.SetKeyName(5, "cook.png")
        Me.ImageListUpgrades.Images.SetKeyName(6, "factory.png")
        Me.ImageListUpgrades.Images.SetKeyName(7, "nuke.png")
        '
        'tabCheat
        '
        Me.tabCheat.Controls.Add(Me.btnTakeDMG)
        Me.tabCheat.Controls.Add(Me.btnTakeDPS)
        Me.tabCheat.Controls.Add(Me.btnTakeCoins)
        Me.tabCheat.Controls.Add(Me.numAddDMG)
        Me.tabCheat.Controls.Add(Me.btnAddDMG)
        Me.tabCheat.Controls.Add(Me.GroupBox2)
        Me.tabCheat.Controls.Add(Me.GroupBox1)
        Me.tabCheat.Controls.Add(Me.numAddDPS)
        Me.tabCheat.Controls.Add(Me.btnAddDPS)
        Me.tabCheat.Controls.Add(Me.numAddCoins)
        Me.tabCheat.Controls.Add(Me.btnAddCoins)
        Me.tabCheat.Location = New System.Drawing.Point(4, 22)
        Me.tabCheat.Name = "tabCheat"
        Me.tabCheat.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCheat.Size = New System.Drawing.Size(294, 299)
        Me.tabCheat.TabIndex = 2
        Me.tabCheat.Text = "Cheats"
        Me.tabCheat.UseVisualStyleBackColor = True
        '
        'btnTakeDMG
        '
        Me.btnTakeDMG.Location = New System.Drawing.Point(168, 61)
        Me.btnTakeDMG.Name = "btnTakeDMG"
        Me.btnTakeDMG.Size = New System.Drawing.Size(75, 23)
        Me.btnTakeDMG.TabIndex = 11
        Me.btnTakeDMG.Text = "Take DMG"
        Me.btnTakeDMG.UseVisualStyleBackColor = True
        '
        'btnTakeDPS
        '
        Me.btnTakeDPS.Location = New System.Drawing.Point(168, 32)
        Me.btnTakeDPS.Name = "btnTakeDPS"
        Me.btnTakeDPS.Size = New System.Drawing.Size(75, 23)
        Me.btnTakeDPS.TabIndex = 10
        Me.btnTakeDPS.Text = "Take DPS"
        Me.btnTakeDPS.UseVisualStyleBackColor = True
        '
        'btnTakeCoins
        '
        Me.btnTakeCoins.Location = New System.Drawing.Point(168, 3)
        Me.btnTakeCoins.Name = "btnTakeCoins"
        Me.btnTakeCoins.Size = New System.Drawing.Size(75, 23)
        Me.btnTakeCoins.TabIndex = 9
        Me.btnTakeCoins.Text = "Take Coins"
        Me.btnTakeCoins.UseVisualStyleBackColor = True
        '
        'numAddDMG
        '
        Me.numAddDMG.Location = New System.Drawing.Point(6, 62)
        Me.numAddDMG.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.numAddDMG.Name = "numAddDMG"
        Me.numAddDMG.Size = New System.Drawing.Size(75, 20)
        Me.numAddDMG.TabIndex = 8
        '
        'btnAddDMG
        '
        Me.btnAddDMG.Location = New System.Drawing.Point(87, 61)
        Me.btnAddDMG.Name = "btnAddDMG"
        Me.btnAddDMG.Size = New System.Drawing.Size(75, 23)
        Me.btnAddDMG.TabIndex = 7
        Me.btnAddDMG.Text = "Add DMG"
        Me.btnAddDMG.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.listStats)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 90)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 126)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Stats"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnLvlUp)
        Me.GroupBox1.Controls.Add(Me.btnLvlDown)
        Me.GroupBox1.Controls.Add(Me.btnHealCookie)
        Me.GroupBox1.Controls.Add(Me.btnInstakill)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 222)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 73)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Instant Actions"
        '
        'btnLvlUp
        '
        Me.btnLvlUp.Location = New System.Drawing.Point(133, 44)
        Me.btnLvlUp.Name = "btnLvlUp"
        Me.btnLvlUp.Size = New System.Drawing.Size(120, 23)
        Me.btnLvlUp.TabIndex = 3
        Me.btnLvlUp.Text = "Level Up"
        Me.btnLvlUp.UseVisualStyleBackColor = True
        '
        'btnLvlDown
        '
        Me.btnLvlDown.Location = New System.Drawing.Point(7, 44)
        Me.btnLvlDown.Name = "btnLvlDown"
        Me.btnLvlDown.Size = New System.Drawing.Size(120, 23)
        Me.btnLvlDown.TabIndex = 2
        Me.btnLvlDown.Text = "Level Down"
        Me.btnLvlDown.UseVisualStyleBackColor = True
        '
        'btnHealCookie
        '
        Me.btnHealCookie.Location = New System.Drawing.Point(133, 20)
        Me.btnHealCookie.Name = "btnHealCookie"
        Me.btnHealCookie.Size = New System.Drawing.Size(120, 23)
        Me.btnHealCookie.TabIndex = 1
        Me.btnHealCookie.Text = "Restore Health"
        Me.btnHealCookie.UseVisualStyleBackColor = True
        '
        'btnInstakill
        '
        Me.btnInstakill.Location = New System.Drawing.Point(7, 20)
        Me.btnInstakill.Name = "btnInstakill"
        Me.btnInstakill.Size = New System.Drawing.Size(120, 23)
        Me.btnInstakill.TabIndex = 0
        Me.btnInstakill.Text = "Instant Kill"
        Me.btnInstakill.UseVisualStyleBackColor = True
        '
        'numAddDPS
        '
        Me.numAddDPS.Location = New System.Drawing.Point(6, 33)
        Me.numAddDPS.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.numAddDPS.Name = "numAddDPS"
        Me.numAddDPS.Size = New System.Drawing.Size(75, 20)
        Me.numAddDPS.TabIndex = 3
        '
        'btnAddDPS
        '
        Me.btnAddDPS.Location = New System.Drawing.Point(87, 32)
        Me.btnAddDPS.Name = "btnAddDPS"
        Me.btnAddDPS.Size = New System.Drawing.Size(75, 23)
        Me.btnAddDPS.TabIndex = 2
        Me.btnAddDPS.Text = "Add DPS"
        Me.btnAddDPS.UseVisualStyleBackColor = True
        '
        'numAddCoins
        '
        Me.numAddCoins.Location = New System.Drawing.Point(6, 5)
        Me.numAddCoins.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.numAddCoins.Name = "numAddCoins"
        Me.numAddCoins.Size = New System.Drawing.Size(75, 20)
        Me.numAddCoins.TabIndex = 1
        '
        'btnAddCoins
        '
        Me.btnAddCoins.Location = New System.Drawing.Point(87, 3)
        Me.btnAddCoins.Name = "btnAddCoins"
        Me.btnAddCoins.Size = New System.Drawing.Size(75, 23)
        Me.btnAddCoins.TabIndex = 0
        Me.btnAddCoins.Text = "Add Coins"
        Me.btnAddCoins.UseVisualStyleBackColor = True
        '
        'listStats
        '
        Me.listStats.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6})
        Me.listStats.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.listStats.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem9, ListViewItem10, ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15})
        Me.listStats.Location = New System.Drawing.Point(7, 19)
        Me.listStats.MultiSelect = False
        Me.listStats.Name = "listStats"
        Me.listStats.Size = New System.Drawing.Size(275, 101)
        Me.listStats.TabIndex = 0
        Me.listStats.UseCompatibleStateImageBehavior = False
        Me.listStats.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Statistic"
        Me.ColumnHeader5.Width = 150
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Value"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader6.Width = 105
        '
        'pbCoin
        '
        Me.pbCoin.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pbCoin.Image = Global.Project_2.My.Resources.Resources.Coin
        Me.pbCoin.Location = New System.Drawing.Point(190, 5)
        Me.pbCoin.Name = "pbCoin"
        Me.pbCoin.Size = New System.Drawing.Size(33, 33)
        Me.pbCoin.TabIndex = 3
        Me.pbCoin.TabStop = False
        '
        'frmUpgrades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 368)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmUpgrades"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Upgrades"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.tabUpgrades.ResumeLayout(False)
        Me.tabCheat.ResumeLayout(False)
        CType(Me.numAddDMG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.numAddDPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAddCoins, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCoin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblDMG As Label
    Friend WithEvents lblDPS As Label
    Friend WithEvents pbCoin As PictureBox
    Friend WithEvents lblCoins As Label
    Friend WithEvents TabControl As TabControl
    Friend WithEvents tabUpgrades As TabPage
    Friend WithEvents lblDescription As Label
    Friend WithEvents btnRefund As Button
    Friend WithEvents btnBuy As Button
    Friend WithEvents listUpgrades As ListView
    Friend WithEvents ColumnHeader0 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents tabCheat As TabPage
    Friend WithEvents btnTakeDMG As Button
    Friend WithEvents btnTakeDPS As Button
    Friend WithEvents btnTakeCoins As Button
    Friend WithEvents numAddDMG As NumericUpDown
    Friend WithEvents btnAddDMG As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnLvlUp As Button
    Friend WithEvents btnLvlDown As Button
    Friend WithEvents btnHealCookie As Button
    Friend WithEvents btnInstakill As Button
    Friend WithEvents numAddDPS As NumericUpDown
    Friend WithEvents btnAddDPS As Button
    Friend WithEvents numAddCoins As NumericUpDown
    Friend WithEvents btnAddCoins As Button
    Friend WithEvents btnSacrifice As Button
    Friend WithEvents ImageListUpgrades As ImageList
    Friend WithEvents listStats As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
End Class
