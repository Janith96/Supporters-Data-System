﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class suggestions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(suggestions))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.yeartxt = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gndivisiontxt = New System.Windows.Forms.TextBox()
        Me.divisiontxt = New System.Windows.Forms.TextBox()
        Me.suggestiontxt = New System.Windows.Forms.TextBox()
        Me.coordinatortxt = New System.Windows.Forms.TextBox()
        Me.mobiletext = New System.Windows.Forms.TextBox()
        Me.categorycombo = New System.Windows.Forms.ComboBox()
        Me.completecombo = New System.Windows.Forms.ComboBox()
        Me.Exitbtn = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.resetbtn = New System.Windows.Forms.Button()
        Me.Savebtn = New System.Windows.Forms.Button()
        Me.Updatebtn = New System.Windows.Forms.Button()
        Me.Deletebtn = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Year"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Division"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "GN Division"
        Me.ToolTip1.SetToolTip(Me.Label3, "Grama Niladhari Division")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(414, 157)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Suggestion"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(414, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Coordinator"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(414, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Mobile No."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(37, 157)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 15)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Complete"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(37, 201)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Category"
        '
        'yeartxt
        '
        Me.yeartxt.Location = New System.Drawing.Point(137, 28)
        Me.yeartxt.Name = "yeartxt"
        Me.yeartxt.Size = New System.Drawing.Size(211, 23)
        Me.yeartxt.TabIndex = 1
        '
        'gndivisiontxt
        '
        Me.gndivisiontxt.Location = New System.Drawing.Point(137, 113)
        Me.gndivisiontxt.Name = "gndivisiontxt"
        Me.gndivisiontxt.Size = New System.Drawing.Size(211, 23)
        Me.gndivisiontxt.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.gndivisiontxt, "Grama Niladhari Division")
        '
        'divisiontxt
        '
        Me.divisiontxt.Location = New System.Drawing.Point(137, 72)
        Me.divisiontxt.Name = "divisiontxt"
        Me.divisiontxt.Size = New System.Drawing.Size(211, 23)
        Me.divisiontxt.TabIndex = 2
        '
        'suggestiontxt
        '
        Me.suggestiontxt.Location = New System.Drawing.Point(519, 113)
        Me.suggestiontxt.Multiline = True
        Me.suggestiontxt.Name = "suggestiontxt"
        Me.suggestiontxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.suggestiontxt.Size = New System.Drawing.Size(211, 120)
        Me.suggestiontxt.TabIndex = 8
        '
        'coordinatortxt
        '
        Me.coordinatortxt.Location = New System.Drawing.Point(519, 28)
        Me.coordinatortxt.Name = "coordinatortxt"
        Me.coordinatortxt.Size = New System.Drawing.Size(211, 23)
        Me.coordinatortxt.TabIndex = 6
        '
        'mobiletext
        '
        Me.mobiletext.Location = New System.Drawing.Point(519, 69)
        Me.mobiletext.Name = "mobiletext"
        Me.mobiletext.Size = New System.Drawing.Size(211, 23)
        Me.mobiletext.TabIndex = 7
        '
        'categorycombo
        '
        Me.categorycombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.categorycombo.FormattingEnabled = True
        Me.categorycombo.Items.AddRange(New Object() {"Bridges/Foot Bridges", "Concrete", "Irrigation", "Other", "Welfare"})
        Me.categorycombo.Location = New System.Drawing.Point(137, 198)
        Me.categorycombo.Name = "categorycombo"
        Me.categorycombo.Size = New System.Drawing.Size(211, 23)
        Me.categorycombo.TabIndex = 5
        '
        'completecombo
        '
        Me.completecombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.completecombo.FormattingEnabled = True
        Me.completecombo.Items.AddRange(New Object() {"No", "Yes"})
        Me.completecombo.Location = New System.Drawing.Point(137, 155)
        Me.completecombo.Name = "completecombo"
        Me.completecombo.Size = New System.Drawing.Size(211, 23)
        Me.completecombo.TabIndex = 4
        '
        'Exitbtn
        '
        Me.Exitbtn.Location = New System.Drawing.Point(655, 257)
        Me.Exitbtn.Name = "Exitbtn"
        Me.Exitbtn.Size = New System.Drawing.Size(75, 23)
        Me.Exitbtn.TabIndex = 17
        Me.Exitbtn.Text = "Exit"
        Me.Exitbtn.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Location = New System.Drawing.Point(28, 299)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 25
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(744, 169)
        Me.DataGridView1.TabIndex = 18
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Edit, Me.Delete, Me.SelectAll})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(123, 70)
        '
        'Edit
        '
        Me.Edit.Image = CType(resources.GetObject("Edit.Image"), System.Drawing.Image)
        Me.Edit.Name = "Edit"
        Me.Edit.Size = New System.Drawing.Size(122, 22)
        Me.Edit.Text = "Edit"
        '
        'Delete
        '
        Me.Delete.Image = CType(resources.GetObject("Delete.Image"), System.Drawing.Image)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(122, 22)
        Me.Delete.Text = "Delete"
        '
        'SelectAll
        '
        Me.SelectAll.Image = CType(resources.GetObject("SelectAll.Image"), System.Drawing.Image)
        Me.SelectAll.Name = "SelectAll"
        Me.SelectAll.Size = New System.Drawing.Size(122, 22)
        Me.SelectAll.Text = "Select All"
        '
        'resetbtn
        '
        Me.resetbtn.Location = New System.Drawing.Point(549, 257)
        Me.resetbtn.Name = "resetbtn"
        Me.resetbtn.Size = New System.Drawing.Size(75, 23)
        Me.resetbtn.TabIndex = 19
        Me.resetbtn.Text = "Clear"
        Me.resetbtn.UseVisualStyleBackColor = True
        '
        'Savebtn
        '
        Me.Savebtn.Location = New System.Drawing.Point(414, 257)
        Me.Savebtn.Name = "Savebtn"
        Me.Savebtn.Size = New System.Drawing.Size(95, 23)
        Me.Savebtn.TabIndex = 9
        Me.Savebtn.Text = "Save"
        Me.Savebtn.UseVisualStyleBackColor = True
        '
        'Updatebtn
        '
        Me.Updatebtn.Enabled = False
        Me.Updatebtn.Location = New System.Drawing.Point(304, 257)
        Me.Updatebtn.Name = "Updatebtn"
        Me.Updatebtn.Size = New System.Drawing.Size(75, 23)
        Me.Updatebtn.TabIndex = 10
        Me.Updatebtn.Text = "Update"
        Me.Updatebtn.UseVisualStyleBackColor = True
        '
        'Deletebtn
        '
        Me.Deletebtn.Location = New System.Drawing.Point(183, 256)
        Me.Deletebtn.Name = "Deletebtn"
        Me.Deletebtn.Size = New System.Drawing.Size(75, 23)
        Me.Deletebtn.TabIndex = 20
        Me.Deletebtn.Text = "Delete"
        Me.Deletebtn.UseVisualStyleBackColor = True
        '
        'suggestions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.Deletebtn)
        Me.Controls.Add(Me.Updatebtn)
        Me.Controls.Add(Me.Savebtn)
        Me.Controls.Add(Me.resetbtn)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Exitbtn)
        Me.Controls.Add(Me.completecombo)
        Me.Controls.Add(Me.categorycombo)
        Me.Controls.Add(Me.mobiletext)
        Me.Controls.Add(Me.coordinatortxt)
        Me.Controls.Add(Me.suggestiontxt)
        Me.Controls.Add(Me.gndivisiontxt)
        Me.Controls.Add(Me.divisiontxt)
        Me.Controls.Add(Me.yeartxt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "suggestions"
        Me.Text = "Add/Edit Suggestion"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents yeartxt As TextBox
    Friend WithEvents divisiontxt As TextBox
    Friend WithEvents gndivisiontxt As TextBox
    Friend WithEvents suggestiontxt As TextBox
    Friend WithEvents coordinatortxt As TextBox
    Friend WithEvents mobiletext As TextBox
    Friend WithEvents categorycombo As ComboBox
    Friend WithEvents completecombo As ComboBox
    Friend WithEvents Exitbtn As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents resetbtn As Button
    Friend WithEvents Savebtn As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Edit As ToolStripMenuItem
    Friend WithEvents Delete As ToolStripMenuItem
    Friend WithEvents SelectAll As ToolStripMenuItem
    Friend WithEvents Updatebtn As Button
    Friend WithEvents Deletebtn As Button
End Class
