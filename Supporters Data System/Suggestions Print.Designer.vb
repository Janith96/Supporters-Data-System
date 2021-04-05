<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Suggestions_Print
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
        Me.GroupBoxyear = New System.Windows.Forms.GroupBox()
        Me.allyearsradio = New System.Windows.Forms.RadioButton()
        Me.tolabel = New System.Windows.Forms.Label()
        Me.todtpick = New System.Windows.Forms.DateTimePicker()
        Me.fromlabel = New System.Windows.Forms.Label()
        Me.fromdtpcik = New System.Windows.Forms.DateTimePicker()
        Me.oneyeartxt = New System.Windows.Forms.TextBox()
        Me.fewyearsradio = New System.Windows.Forms.RadioButton()
        Me.oneyearradio = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.otherchkbox = New System.Windows.Forms.CheckBox()
        Me.welfarechkbox = New System.Windows.Forms.CheckBox()
        Me.irrigationchkbox = New System.Windows.Forms.CheckBox()
        Me.roadschkbox = New System.Windows.Forms.CheckBox()
        Me.bridgeschkbox = New System.Windows.Forms.CheckBox()
        Me.fewtypesradio = New System.Windows.Forms.RadioButton()
        Me.alltypesradio = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.completechkbox = New System.Windows.Forms.CheckBox()
        Me.pendingchkbox = New System.Windows.Forms.CheckBox()
        Me.declinedchkbox = New System.Windows.Forms.CheckBox()
        Me.approvedchkbox = New System.Windows.Forms.CheckBox()
        Me.fewsttatusradio = New System.Windows.Forms.RadioButton()
        Me.allstatusradio = New System.Windows.Forms.RadioButton()
        Me.selareabtn = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.searchbtn = New System.Windows.Forms.Button()
        Me.Resetbtn = New System.Windows.Forms.Button()
        Me.Printbtn = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.allareasradio = New System.Windows.Forms.RadioButton()
        Me.gndivisionwiseradio = New System.Windows.Forms.RadioButton()
        Me.divisionviseradio = New System.Windows.Forms.RadioButton()
        Me.seatwiseradio = New System.Windows.Forms.RadioButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripTotalRecords = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBoxyear.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxyear
        '
        Me.GroupBoxyear.Controls.Add(Me.allyearsradio)
        Me.GroupBoxyear.Controls.Add(Me.tolabel)
        Me.GroupBoxyear.Controls.Add(Me.todtpick)
        Me.GroupBoxyear.Controls.Add(Me.fromlabel)
        Me.GroupBoxyear.Controls.Add(Me.fromdtpcik)
        Me.GroupBoxyear.Controls.Add(Me.oneyeartxt)
        Me.GroupBoxyear.Controls.Add(Me.fewyearsradio)
        Me.GroupBoxyear.Controls.Add(Me.oneyearradio)
        Me.GroupBoxyear.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxyear.Name = "GroupBoxyear"
        Me.GroupBoxyear.Size = New System.Drawing.Size(322, 155)
        Me.GroupBoxyear.TabIndex = 0
        Me.GroupBoxyear.TabStop = False
        Me.GroupBoxyear.Text = "වර්ෂය"
        '
        'allyearsradio
        '
        Me.allyearsradio.AutoSize = True
        Me.allyearsradio.Location = New System.Drawing.Point(6, 22)
        Me.allyearsradio.Name = "allyearsradio"
        Me.allyearsradio.Size = New System.Drawing.Size(95, 19)
        Me.allyearsradio.TabIndex = 7
        Me.allyearsradio.TabStop = True
        Me.allyearsradio.Text = "සියලුම වසර"
        Me.allyearsradio.UseVisualStyleBackColor = True
        '
        'tolabel
        '
        Me.tolabel.AutoSize = True
        Me.tolabel.Enabled = False
        Me.tolabel.Location = New System.Drawing.Point(267, 80)
        Me.tolabel.Name = "tolabel"
        Me.tolabel.Size = New System.Drawing.Size(40, 15)
        Me.tolabel.TabIndex = 6
        Me.tolabel.Text = "දක්වා"
        '
        'todtpick
        '
        Me.todtpick.CustomFormat = "yyyy"
        Me.todtpick.Enabled = False
        Me.todtpick.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.todtpick.Location = New System.Drawing.Point(211, 76)
        Me.todtpick.Name = "todtpick"
        Me.todtpick.ShowUpDown = True
        Me.todtpick.Size = New System.Drawing.Size(51, 23)
        Me.todtpick.TabIndex = 5
        '
        'fromlabel
        '
        Me.fromlabel.AutoSize = True
        Me.fromlabel.Enabled = False
        Me.fromlabel.Location = New System.Drawing.Point(182, 80)
        Me.fromlabel.Name = "fromlabel"
        Me.fromlabel.Size = New System.Drawing.Size(26, 15)
        Me.fromlabel.TabIndex = 4
        Me.fromlabel.Text = "සිට"
        '
        'fromdtpcik
        '
        Me.fromdtpcik.CustomFormat = "yyyy"
        Me.fromdtpcik.Enabled = False
        Me.fromdtpcik.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fromdtpcik.Location = New System.Drawing.Point(125, 76)
        Me.fromdtpcik.Name = "fromdtpcik"
        Me.fromdtpcik.ShowUpDown = True
        Me.fromdtpcik.Size = New System.Drawing.Size(51, 23)
        Me.fromdtpcik.TabIndex = 3
        '
        'oneyeartxt
        '
        Me.oneyeartxt.Enabled = False
        Me.oneyeartxt.Location = New System.Drawing.Point(125, 47)
        Me.oneyeartxt.Name = "oneyeartxt"
        Me.oneyeartxt.Size = New System.Drawing.Size(182, 23)
        Me.oneyeartxt.TabIndex = 2
        '
        'fewyearsradio
        '
        Me.fewyearsradio.AutoSize = True
        Me.fewyearsradio.Location = New System.Drawing.Point(6, 76)
        Me.fewyearsradio.Name = "fewyearsradio"
        Me.fewyearsradio.Size = New System.Drawing.Size(100, 19)
        Me.fewyearsradio.TabIndex = 1
        Me.fewyearsradio.TabStop = True
        Me.fewyearsradio.Text = "වසර කීපයක්"
        Me.fewyearsradio.UseVisualStyleBackColor = True
        '
        'oneyearradio
        '
        Me.oneyearradio.AutoSize = True
        Me.oneyearradio.Location = New System.Drawing.Point(6, 48)
        Me.oneyearradio.Name = "oneyearradio"
        Me.oneyearradio.Size = New System.Drawing.Size(90, 19)
        Me.oneyearradio.TabIndex = 0
        Me.oneyearradio.TabStop = True
        Me.oneyearradio.Text = "එක් වසරක්"
        Me.oneyearradio.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.otherchkbox)
        Me.GroupBox2.Controls.Add(Me.welfarechkbox)
        Me.GroupBox2.Controls.Add(Me.irrigationchkbox)
        Me.GroupBox2.Controls.Add(Me.roadschkbox)
        Me.GroupBox2.Controls.Add(Me.bridgeschkbox)
        Me.GroupBox2.Controls.Add(Me.fewtypesradio)
        Me.GroupBox2.Controls.Add(Me.alltypesradio)
        Me.GroupBox2.Location = New System.Drawing.Point(625, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(299, 155)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "වර්ගය"
        '
        'otherchkbox
        '
        Me.otherchkbox.AutoSize = True
        Me.otherchkbox.Enabled = False
        Me.otherchkbox.Location = New System.Drawing.Point(199, 97)
        Me.otherchkbox.Name = "otherchkbox"
        Me.otherchkbox.Size = New System.Drawing.Size(67, 19)
        Me.otherchkbox.TabIndex = 6
        Me.otherchkbox.Text = "වෙනත්"
        Me.otherchkbox.UseVisualStyleBackColor = True
        '
        'welfarechkbox
        '
        Me.welfarechkbox.AutoSize = True
        Me.welfarechkbox.Enabled = False
        Me.welfarechkbox.Location = New System.Drawing.Point(199, 72)
        Me.welfarechkbox.Name = "welfarechkbox"
        Me.welfarechkbox.Size = New System.Drawing.Size(85, 19)
        Me.welfarechkbox.TabIndex = 5
        Me.welfarechkbox.Text = "සුභසාධන"
        Me.welfarechkbox.UseVisualStyleBackColor = True
        '
        'irrigationchkbox
        '
        Me.irrigationchkbox.AutoSize = True
        Me.irrigationchkbox.Enabled = False
        Me.irrigationchkbox.Location = New System.Drawing.Point(25, 122)
        Me.irrigationchkbox.Name = "irrigationchkbox"
        Me.irrigationchkbox.Size = New System.Drawing.Size(97, 19)
        Me.irrigationchkbox.TabIndex = 4
        Me.irrigationchkbox.Text = "ජල ව්‍යාපෘති"
        Me.irrigationchkbox.UseVisualStyleBackColor = True
        '
        'roadschkbox
        '
        Me.roadschkbox.AutoSize = True
        Me.roadschkbox.Enabled = False
        Me.roadschkbox.Location = New System.Drawing.Point(25, 97)
        Me.roadschkbox.Name = "roadschkbox"
        Me.roadschkbox.Size = New System.Drawing.Size(120, 19)
        Me.roadschkbox.TabIndex = 3
        Me.roadschkbox.Text = "මාර්ග සංවර්ධන"
        Me.roadschkbox.UseVisualStyleBackColor = True
        '
        'bridgeschkbox
        '
        Me.bridgeschkbox.AutoSize = True
        Me.bridgeschkbox.Enabled = False
        Me.bridgeschkbox.Location = New System.Drawing.Point(25, 72)
        Me.bridgeschkbox.Name = "bridgeschkbox"
        Me.bridgeschkbox.Size = New System.Drawing.Size(112, 19)
        Me.bridgeschkbox.TabIndex = 2
        Me.bridgeschkbox.Text = "පාලම්/බෝක්කු"
        Me.bridgeschkbox.UseVisualStyleBackColor = True
        '
        'fewtypesradio
        '
        Me.fewtypesradio.AutoSize = True
        Me.fewtypesradio.Location = New System.Drawing.Point(6, 48)
        Me.fewtypesradio.Name = "fewtypesradio"
        Me.fewtypesradio.Size = New System.Drawing.Size(166, 19)
        Me.fewtypesradio.TabIndex = 1
        Me.fewtypesradio.TabStop = True
        Me.fewtypesradio.Text = "වර්ග එකක් හෝ කීපයක්"
        Me.fewtypesradio.UseVisualStyleBackColor = True
        '
        'alltypesradio
        '
        Me.alltypesradio.AutoSize = True
        Me.alltypesradio.Location = New System.Drawing.Point(6, 22)
        Me.alltypesradio.Name = "alltypesradio"
        Me.alltypesradio.Size = New System.Drawing.Size(96, 19)
        Me.alltypesradio.TabIndex = 0
        Me.alltypesradio.TabStop = True
        Me.alltypesradio.Text = "සියලුම වර්ග"
        Me.alltypesradio.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.completechkbox)
        Me.GroupBox3.Controls.Add(Me.pendingchkbox)
        Me.GroupBox3.Controls.Add(Me.declinedchkbox)
        Me.GroupBox3.Controls.Add(Me.approvedchkbox)
        Me.GroupBox3.Controls.Add(Me.fewsttatusradio)
        Me.GroupBox3.Controls.Add(Me.allstatusradio)
        Me.GroupBox3.Location = New System.Drawing.Point(356, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(249, 155)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "තත්වය"
        '
        'completechkbox
        '
        Me.completechkbox.AutoSize = True
        Me.completechkbox.Enabled = False
        Me.completechkbox.Location = New System.Drawing.Point(130, 101)
        Me.completechkbox.Name = "completechkbox"
        Me.completechkbox.Size = New System.Drawing.Size(78, 19)
        Me.completechkbox.TabIndex = 5
        Me.completechkbox.Text = "Complete"
        Me.completechkbox.UseVisualStyleBackColor = True
        '
        'pendingchkbox
        '
        Me.pendingchkbox.AutoSize = True
        Me.pendingchkbox.Enabled = False
        Me.pendingchkbox.Location = New System.Drawing.Point(130, 76)
        Me.pendingchkbox.Name = "pendingchkbox"
        Me.pendingchkbox.Size = New System.Drawing.Size(70, 19)
        Me.pendingchkbox.TabIndex = 4
        Me.pendingchkbox.Text = "Pending"
        Me.pendingchkbox.UseVisualStyleBackColor = True
        '
        'declinedchkbox
        '
        Me.declinedchkbox.AutoSize = True
        Me.declinedchkbox.Enabled = False
        Me.declinedchkbox.Location = New System.Drawing.Point(24, 101)
        Me.declinedchkbox.Name = "declinedchkbox"
        Me.declinedchkbox.Size = New System.Drawing.Size(72, 19)
        Me.declinedchkbox.TabIndex = 3
        Me.declinedchkbox.Text = "Declined"
        Me.declinedchkbox.UseVisualStyleBackColor = True
        '
        'approvedchkbox
        '
        Me.approvedchkbox.AutoSize = True
        Me.approvedchkbox.Enabled = False
        Me.approvedchkbox.Location = New System.Drawing.Point(24, 76)
        Me.approvedchkbox.Name = "approvedchkbox"
        Me.approvedchkbox.Size = New System.Drawing.Size(78, 19)
        Me.approvedchkbox.TabIndex = 2
        Me.approvedchkbox.Text = "Approved"
        Me.approvedchkbox.UseVisualStyleBackColor = True
        '
        'fewsttatusradio
        '
        Me.fewsttatusradio.AutoSize = True
        Me.fewsttatusradio.Location = New System.Drawing.Point(6, 51)
        Me.fewsttatusradio.Name = "fewsttatusradio"
        Me.fewsttatusradio.Size = New System.Drawing.Size(170, 19)
        Me.fewsttatusradio.TabIndex = 1
        Me.fewsttatusradio.TabStop = True
        Me.fewsttatusradio.Text = "තත්ව එකක් හෝ කීපයක්"
        Me.fewsttatusradio.UseVisualStyleBackColor = True
        '
        'allstatusradio
        '
        Me.allstatusradio.AutoSize = True
        Me.allstatusradio.Location = New System.Drawing.Point(6, 25)
        Me.allstatusradio.Name = "allstatusradio"
        Me.allstatusradio.Size = New System.Drawing.Size(100, 19)
        Me.allstatusradio.TabIndex = 0
        Me.allstatusradio.TabStop = True
        Me.allstatusradio.Text = "සියලුම තත්ව"
        Me.allstatusradio.UseVisualStyleBackColor = True
        '
        'selareabtn
        '
        Me.selareabtn.Enabled = False
        Me.selareabtn.Location = New System.Drawing.Point(401, 70)
        Me.selareabtn.Name = "selareabtn"
        Me.selareabtn.Size = New System.Drawing.Size(132, 34)
        Me.selareabtn.TabIndex = 2
        Me.selareabtn.Text = "තෝරන්න"
        Me.selareabtn.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 546)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 25
        Me.DataGridView1.Size = New System.Drawing.Size(916, 96)
        Me.DataGridView1.TabIndex = 6
        '
        'searchbtn
        '
        Me.searchbtn.Location = New System.Drawing.Point(396, 328)
        Me.searchbtn.Name = "searchbtn"
        Me.searchbtn.Size = New System.Drawing.Size(149, 46)
        Me.searchbtn.TabIndex = 7
        Me.searchbtn.Text = "Search"
        Me.searchbtn.UseVisualStyleBackColor = True
        '
        'Resetbtn
        '
        Me.Resetbtn.Location = New System.Drawing.Point(94, 328)
        Me.Resetbtn.Name = "Resetbtn"
        Me.Resetbtn.Size = New System.Drawing.Size(149, 46)
        Me.Resetbtn.TabIndex = 8
        Me.Resetbtn.Text = "Reset"
        Me.Resetbtn.UseVisualStyleBackColor = True
        '
        'Printbtn
        '
        Me.Printbtn.Location = New System.Drawing.Point(707, 328)
        Me.Printbtn.Name = "Printbtn"
        Me.Printbtn.Size = New System.Drawing.Size(149, 46)
        Me.Printbtn.TabIndex = 9
        Me.Printbtn.Text = "Print"
        Me.Printbtn.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.selareabtn)
        Me.GroupBox5.Controls.Add(Me.allareasradio)
        Me.GroupBox5.Controls.Add(Me.gndivisionwiseradio)
        Me.GroupBox5.Controls.Add(Me.divisionviseradio)
        Me.GroupBox5.Controls.Add(Me.seatwiseradio)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 182)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(912, 124)
        Me.GroupBox5.TabIndex = 10
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "ප්‍රදේශය"
        '
        'allareasradio
        '
        Me.allareasradio.AutoSize = True
        Me.allareasradio.Location = New System.Drawing.Point(33, 24)
        Me.allareasradio.Name = "allareasradio"
        Me.allareasradio.Size = New System.Drawing.Size(103, 19)
        Me.allareasradio.TabIndex = 3
        Me.allareasradio.TabStop = True
        Me.allareasradio.Text = "සියලුම ප්‍රදේශ"
        Me.allareasradio.UseVisualStyleBackColor = True
        '
        'gndivisionwiseradio
        '
        Me.gndivisionwiseradio.AutoSize = True
        Me.gndivisionwiseradio.Location = New System.Drawing.Point(776, 24)
        Me.gndivisionwiseradio.Name = "gndivisionwiseradio"
        Me.gndivisionwiseradio.Size = New System.Drawing.Size(86, 19)
        Me.gndivisionwiseradio.TabIndex = 8
        Me.gndivisionwiseradio.TabStop = True
        Me.gndivisionwiseradio.Text = "වසම් අනුව"
        Me.gndivisionwiseradio.UseVisualStyleBackColor = True
        '
        'divisionviseradio
        '
        Me.divisionviseradio.AutoSize = True
        Me.divisionviseradio.Location = New System.Drawing.Point(504, 24)
        Me.divisionviseradio.Name = "divisionviseradio"
        Me.divisionviseradio.Size = New System.Drawing.Size(117, 19)
        Me.divisionviseradio.TabIndex = 7
        Me.divisionviseradio.TabStop = True
        Me.divisionviseradio.Text = "කොට්ඨාශ අනුව"
        Me.divisionviseradio.UseVisualStyleBackColor = True
        '
        'seatwiseradio
        '
        Me.seatwiseradio.AutoSize = True
        Me.seatwiseradio.Location = New System.Drawing.Point(267, 24)
        Me.seatwiseradio.Name = "seatwiseradio"
        Me.seatwiseradio.Size = New System.Drawing.Size(92, 19)
        Me.seatwiseradio.TabIndex = 6
        Me.seatwiseradio.TabStop = True
        Me.seatwiseradio.Text = "ආසන අනුව"
        Me.seatwiseradio.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTotalRecords})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 645)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(940, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripTotalRecords
        '
        Me.ToolStripTotalRecords.Name = "ToolStripTotalRecords"
        Me.ToolStripTotalRecords.Size = New System.Drawing.Size(0, 17)
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(45, 422)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(762, 87)
        Me.TextBox1.TabIndex = 12
        '
        'Suggestions_Print
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 667)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Printbtn)
        Me.Controls.Add(Me.Resetbtn)
        Me.Controls.Add(Me.searchbtn)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBoxyear)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Suggestions_Print"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "Print Suggestions"
        Me.GroupBoxyear.ResumeLayout(False)
        Me.GroupBoxyear.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBoxyear As GroupBox
    Friend WithEvents allyearsradio As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents todtpick As DateTimePicker
    Friend WithEvents fromlabel As Label
    Friend WithEvents fromdtpcik As DateTimePicker
    Friend WithEvents oneyeartxt As TextBox
    Friend WithEvents fewyearsradio As RadioButton
    Friend WithEvents oneyearradio As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents bridgeschkbox As CheckBox
    Friend WithEvents fewtypesradio As RadioButton
    Friend WithEvents alltypesradio As RadioButton
    Friend WithEvents roadschkbox As CheckBox
    Friend WithEvents otherchkbox As CheckBox
    Friend WithEvents welfarechkbox As CheckBox
    Friend WithEvents irrigationchkbox As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents fewsttatusradio As RadioButton
    Friend WithEvents allstatusradio As RadioButton
    Friend WithEvents completechkbox As CheckBox
    Friend WithEvents pendingchkbox As CheckBox
    Friend WithEvents declinedchkbox As CheckBox
    Friend WithEvents approvedchkbox As CheckBox
    Friend WithEvents selareabtn As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents searchbtn As Button
    Friend WithEvents Resetbtn As Button
    Friend WithEvents Printbtn As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents allareasradio As RadioButton
    Friend WithEvents gndivisionwiseradio As RadioButton
    Friend WithEvents divisionviseradio As RadioButton
    Friend WithEvents seatwiseradio As RadioButton
    Friend WithEvents tolabel As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripTotalRecords As ToolStripStatusLabel
    Friend WithEvents TextBox1 As TextBox
End Class
