<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.DirectoryLabel = New System.Windows.Forms.Label()
        Me.DirectoryTextBox = New System.Windows.Forms.TextBox()
        Me.SelectDirectoryButton = New System.Windows.Forms.Button()
        Me.RenameButton = New System.Windows.Forms.Button()
        Me.FilesListView = New System.Windows.Forms.ListView()
        Me.WithLabel = New System.Windows.Forms.Label()
        Me.WithTextBox = New System.Windows.Forms.TextBox()
        Me.ReplaceTextBox = New System.Windows.Forms.TextBox()
        Me.ReplaceLabel = New System.Windows.Forms.Label()
        Me.SelectAllButton = New System.Windows.Forms.Button()
        Me.SelectNoneButton = New System.Windows.Forms.Button()
        Me.LowerCaseExtensionCheckBox = New System.Windows.Forms.CheckBox()
        Me.SubDirectoriesCheckBox = New System.Windows.Forms.CheckBox()
        Me.OptionsFrame = New System.Windows.Forms.GroupBox()
        Me.DirectoriesOnlyCheckBox = New System.Windows.Forms.CheckBox()
        Me.FilesDivider = New System.Windows.Forms.Label()
        Me.DirectoryDivider = New System.Windows.Forms.Label()
        Me.TextChangeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.OptionsFrame.SuspendLayout()
        Me.SuspendLayout()
        '
        'DirectoryLabel
        '
        Me.DirectoryLabel.AutoSize = True
        Me.DirectoryLabel.Location = New System.Drawing.Point(9, 9)
        Me.DirectoryLabel.Name = "DirectoryLabel"
        Me.DirectoryLabel.Size = New System.Drawing.Size(52, 13)
        Me.DirectoryLabel.TabIndex = 0
        Me.DirectoryLabel.Text = "Directory:"
        Me.DirectoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DirectoryTextBox
        '
        Me.DirectoryTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DirectoryTextBox.Location = New System.Drawing.Point(12, 25)
        Me.DirectoryTextBox.Name = "DirectoryTextBox"
        Me.DirectoryTextBox.Size = New System.Drawing.Size(426, 20)
        Me.DirectoryTextBox.TabIndex = 1
        '
        'SelectDirectoryButton
        '
        Me.SelectDirectoryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SelectDirectoryButton.Location = New System.Drawing.Point(444, 23)
        Me.SelectDirectoryButton.Name = "SelectDirectoryButton"
        Me.SelectDirectoryButton.Size = New System.Drawing.Size(24, 23)
        Me.SelectDirectoryButton.TabIndex = 2
        Me.SelectDirectoryButton.Text = "..."
        Me.SelectDirectoryButton.UseVisualStyleBackColor = True
        '
        'RenameButton
        '
        Me.RenameButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RenameButton.Enabled = False
        Me.RenameButton.Location = New System.Drawing.Point(393, 486)
        Me.RenameButton.Name = "RenameButton"
        Me.RenameButton.Size = New System.Drawing.Size(75, 23)
        Me.RenameButton.TabIndex = 13
        Me.RenameButton.Text = "Rename"
        Me.RenameButton.UseVisualStyleBackColor = True
        '
        'FilesListView
        '
        Me.FilesListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilesListView.CheckBoxes = True
        Me.FilesListView.FullRowSelect = True
        Me.FilesListView.Location = New System.Drawing.Point(12, 180)
        Me.FilesListView.Name = "FilesListView"
        Me.FilesListView.Size = New System.Drawing.Size(456, 300)
        Me.FilesListView.TabIndex = 10
        Me.FilesListView.UseCompatibleStateImageBehavior = False
        Me.FilesListView.View = System.Windows.Forms.View.Details
        '
        'WithLabel
        '
        Me.WithLabel.AutoSize = True
        Me.WithLabel.Location = New System.Drawing.Point(12, 105)
        Me.WithLabel.Name = "WithLabel"
        Me.WithLabel.Size = New System.Drawing.Size(32, 13)
        Me.WithLabel.TabIndex = 6
        Me.WithLabel.Text = "With:"
        Me.WithLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WithTextBox
        '
        Me.WithTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WithTextBox.Location = New System.Drawing.Point(12, 121)
        Me.WithTextBox.Name = "WithTextBox"
        Me.WithTextBox.Size = New System.Drawing.Size(294, 20)
        Me.WithTextBox.TabIndex = 7
        '
        'ReplaceTextBox
        '
        Me.ReplaceTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReplaceTextBox.Location = New System.Drawing.Point(12, 82)
        Me.ReplaceTextBox.Name = "ReplaceTextBox"
        Me.ReplaceTextBox.Size = New System.Drawing.Size(294, 20)
        Me.ReplaceTextBox.TabIndex = 5
        '
        'ReplaceLabel
        '
        Me.ReplaceLabel.AutoSize = True
        Me.ReplaceLabel.Location = New System.Drawing.Point(9, 66)
        Me.ReplaceLabel.Name = "ReplaceLabel"
        Me.ReplaceLabel.Size = New System.Drawing.Size(50, 13)
        Me.ReplaceLabel.TabIndex = 4
        Me.ReplaceLabel.Text = "Replace:"
        Me.ReplaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SelectAllButton
        '
        Me.SelectAllButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SelectAllButton.Location = New System.Drawing.Point(12, 486)
        Me.SelectAllButton.Name = "SelectAllButton"
        Me.SelectAllButton.Size = New System.Drawing.Size(75, 23)
        Me.SelectAllButton.TabIndex = 11
        Me.SelectAllButton.Text = "Select All"
        Me.SelectAllButton.UseVisualStyleBackColor = True
        '
        'SelectNoneButton
        '
        Me.SelectNoneButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SelectNoneButton.Location = New System.Drawing.Point(93, 486)
        Me.SelectNoneButton.Name = "SelectNoneButton"
        Me.SelectNoneButton.Size = New System.Drawing.Size(75, 23)
        Me.SelectNoneButton.TabIndex = 12
        Me.SelectNoneButton.Text = "Select None"
        Me.SelectNoneButton.UseVisualStyleBackColor = True
        '
        'LowerCaseExtensionCheckBox
        '
        Me.LowerCaseExtensionCheckBox.AccessibleDescription = ""
        Me.LowerCaseExtensionCheckBox.AutoSize = True
        Me.LowerCaseExtensionCheckBox.Checked = True
        Me.LowerCaseExtensionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LowerCaseExtensionCheckBox.Location = New System.Drawing.Point(6, 65)
        Me.LowerCaseExtensionCheckBox.Name = "LowerCaseExtensionCheckBox"
        Me.LowerCaseExtensionCheckBox.Size = New System.Drawing.Size(142, 17)
        Me.LowerCaseExtensionCheckBox.TabIndex = 2
        Me.LowerCaseExtensionCheckBox.Text = "Lowercase file extension"
        Me.LowerCaseExtensionCheckBox.UseVisualStyleBackColor = True
        '
        'SubDirectoriesCheckBox
        '
        Me.SubDirectoriesCheckBox.AccessibleDescription = ""
        Me.SubDirectoriesCheckBox.AutoSize = True
        Me.SubDirectoriesCheckBox.Location = New System.Drawing.Point(6, 42)
        Me.SubDirectoriesCheckBox.Name = "SubDirectoriesCheckBox"
        Me.SubDirectoriesCheckBox.Size = New System.Drawing.Size(132, 17)
        Me.SubDirectoriesCheckBox.TabIndex = 1
        Me.SubDirectoriesCheckBox.Text = "Include sub-directories"
        Me.SubDirectoriesCheckBox.UseVisualStyleBackColor = True
        '
        'OptionsFrame
        '
        Me.OptionsFrame.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OptionsFrame.Controls.Add(Me.DirectoriesOnlyCheckBox)
        Me.OptionsFrame.Controls.Add(Me.LowerCaseExtensionCheckBox)
        Me.OptionsFrame.Controls.Add(Me.SubDirectoriesCheckBox)
        Me.OptionsFrame.Location = New System.Drawing.Point(312, 70)
        Me.OptionsFrame.Name = "OptionsFrame"
        Me.OptionsFrame.Size = New System.Drawing.Size(156, 88)
        Me.OptionsFrame.TabIndex = 8
        Me.OptionsFrame.TabStop = False
        Me.OptionsFrame.Text = "Options"
        '
        'DirectoriesOnlyCheckBox
        '
        Me.DirectoriesOnlyCheckBox.AccessibleDescription = ""
        Me.DirectoriesOnlyCheckBox.AutoSize = True
        Me.DirectoriesOnlyCheckBox.Location = New System.Drawing.Point(6, 19)
        Me.DirectoriesOnlyCheckBox.Name = "DirectoriesOnlyCheckBox"
        Me.DirectoriesOnlyCheckBox.Size = New System.Drawing.Size(98, 17)
        Me.DirectoriesOnlyCheckBox.TabIndex = 0
        Me.DirectoriesOnlyCheckBox.Text = "Directories only"
        Me.DirectoriesOnlyCheckBox.UseVisualStyleBackColor = True
        '
        'FilesDivider
        '
        Me.FilesDivider.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilesDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.FilesDivider.Location = New System.Drawing.Point(12, 168)
        Me.FilesDivider.Margin = New System.Windows.Forms.Padding(0)
        Me.FilesDivider.Name = "FilesDivider"
        Me.FilesDivider.Size = New System.Drawing.Size(456, 2)
        Me.FilesDivider.TabIndex = 9
        '
        'DirectoryDivider
        '
        Me.DirectoryDivider.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DirectoryDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DirectoryDivider.Location = New System.Drawing.Point(12, 57)
        Me.DirectoryDivider.Margin = New System.Windows.Forms.Padding(0)
        Me.DirectoryDivider.Name = "DirectoryDivider"
        Me.DirectoryDivider.Size = New System.Drawing.Size(456, 2)
        Me.DirectoryDivider.TabIndex = 3
        '
        'TextChangeTimer
        '
        Me.TextChangeTimer.Interval = 1000
        '
        'MainForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(480, 521)
        Me.Controls.Add(Me.DirectoryDivider)
        Me.Controls.Add(Me.FilesDivider)
        Me.Controls.Add(Me.OptionsFrame)
        Me.Controls.Add(Me.SelectNoneButton)
        Me.Controls.Add(Me.SelectAllButton)
        Me.Controls.Add(Me.WithLabel)
        Me.Controls.Add(Me.WithTextBox)
        Me.Controls.Add(Me.ReplaceTextBox)
        Me.Controls.Add(Me.ReplaceLabel)
        Me.Controls.Add(Me.FilesListView)
        Me.Controls.Add(Me.RenameButton)
        Me.Controls.Add(Me.SelectDirectoryButton)
        Me.Controls.Add(Me.DirectoryTextBox)
        Me.Controls.Add(Me.DirectoryLabel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bulk File Rename"
        Me.OptionsFrame.ResumeLayout(False)
        Me.OptionsFrame.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents RenameButton As System.Windows.Forms.Button
    Private WithEvents FilesListView As System.Windows.Forms.ListView
    Private WithEvents DirectoryLabel As System.Windows.Forms.Label
    Private WithEvents DirectoryTextBox As System.Windows.Forms.TextBox
    Private WithEvents SelectDirectoryButton As System.Windows.Forms.Button
    Private WithEvents WithLabel As System.Windows.Forms.Label
    Private WithEvents WithTextBox As System.Windows.Forms.TextBox
    Private WithEvents ReplaceTextBox As System.Windows.Forms.TextBox
    Private WithEvents ReplaceLabel As System.Windows.Forms.Label
    Private WithEvents LowerCaseExtensionCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents SubDirectoriesCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents TextChangeTimer As System.Windows.Forms.Timer
    Private WithEvents SelectAllButton As System.Windows.Forms.Button
    Private WithEvents SelectNoneButton As System.Windows.Forms.Button
    Private WithEvents OptionsFrame As System.Windows.Forms.GroupBox
    Private WithEvents FilesDivider As System.Windows.Forms.Label
    Private WithEvents DirectoryDivider As System.Windows.Forms.Label
    Private WithEvents DirectoriesOnlyCheckBox As System.Windows.Forms.CheckBox

End Class
