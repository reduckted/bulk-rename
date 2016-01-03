Imports System.IO
Imports System.Text.RegularExpressions


Public Class MainForm

    Private Const DigitPattern As String = "\d+"
    Private Const NumberPattern As String = "\{number(:" & DigitPattern & ")?\}"


    Private cgPopulatingFileList As Boolean


    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        SetupListView()

        If My.Application.CommandLineArgs.Count > 0 Then
            DirectoryTextBox.Text = My.Application.CommandLineArgs(0)
            ActiveControl = ReplaceTextBox
        End If

        PrepareSettings()
    End Sub


    Private Sub PrepareSettings()
        Dim p As Point


        p = My.Settings.FormLocation

        If p <> New Point(-1, -1) Then
            Location = p
        End If

        AddHandler My.Settings.SettingsSaving, AddressOf OnSettingsSaving
    End Sub


    Private Sub OnSettingsSaving(
            aSender As Object,
            aEventArgs As EventArgs
        )

        My.Settings.FormLocation = Location
    End Sub


    Private Sub SetupListView()
        FilesListView.Columns.Add("Current file name")
        FilesListView.Columns.Add("New file name")

        FilesListView.Columns(0).Width = (FilesListView.ClientSize.Width - 20) \ 2
        FilesListView.Columns(1).Width = FilesListView.Columns(0).Width
    End Sub


    Private Sub DirectoryTextBox_TextChanged(
            sender As Object,
            e As EventArgs
        ) Handles DirectoryTextBox.TextChanged

        RepopulateFileNames()
    End Sub


    Private Sub SelectDirectoryButton_Click(
            sender As Object,
            e As EventArgs
        ) Handles SelectDirectoryButton.Click

        Using dlg As New FolderBrowserDialog
            dlg.SelectedPath = DirectoryTextBox.Text
            dlg.ShowNewFolderButton = False

            If dlg.ShowDialog(Me) = DialogResult.OK Then
                DirectoryTextBox.Text = dlg.SelectedPath
            End If
        End Using
    End Sub


    Private Sub OnReplacementTextChanged(
            sender As Object,
            e As EventArgs
        ) Handles ReplaceTextBox.TextChanged,
                  WithTextBox.TextChanged

        If FilesListView.Items.Count > 300 Then
            TextChangeTimer.Stop()
            TextChangeTimer.Start()
        Else
            UpdateFileNames()
        End If
    End Sub


    Private Sub TextChangeTimer_Tick(
            sender As Object,
            e As EventArgs
        ) Handles TextChangeTimer.Tick

        TextChangeTimer.Stop()
        UpdateFileNames()
    End Sub


    Private Sub SubDirectoriesCheckBox_CheckedChanged(
            sender As Object,
            e As EventArgs
        ) Handles SubDirectoriesCheckBox.CheckedChanged

        RepopulateFileNames()
    End Sub


    Private Sub DirectoriesOnlyCheckBox_CheckedChanged(
            sender As Object,
            e As EventArgs
        ) Handles DirectoriesOnlyCheckBox.CheckedChanged

        LowerCaseExtensionCheckBox.Enabled = Not DirectoriesOnlyCheckBox.Checked
        SubDirectoriesCheckBox.Enabled = Not DirectoriesOnlyCheckBox.Checked

        RepopulateFileNames()
    End Sub


    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        If e.Control AndAlso (e.KeyCode = Keys.Return) Then
            RenameButton_Click(Nothing, EventArgs.Empty)
            e.SuppressKeyPress = True

        ElseIf e.KeyCode = Keys.F5 Then
            RepopulateFileNames()
            e.SuppressKeyPress = True
        End If

        MyBase.OnKeyDown(e)
    End Sub


    Private Sub OnTextBoxKeyDown(
            sender As Object,
            e As KeyEventArgs
        ) Handles DirectoryTextBox.KeyDown,
                  ReplaceTextBox.KeyDown,
                  WithTextBox.KeyDown

        If e.Control AndAlso (e.KeyCode = Keys.A) Then
            Dim txt As TextBox = TryCast(sender, TextBox)


            If txt IsNot Nothing Then
                txt.SelectAll()
                e.SuppressKeyPress = True
            End If
        End If
    End Sub


    Private Sub WithTextBox_KeyDown(
            sender As Object,
            e As KeyEventArgs
        ) Handles WithTextBox.KeyDown

        If e.Control AndAlso e.Shift Then
            Dim num As Integer = KeyToNumber(e.KeyCode)


            If num <> 0 Then
                WithTextBox.SelectedText = "{number:" & num & "}"
                e.SuppressKeyPress = True
            End If
        End If
    End Sub


    Private Function KeyToNumber(key As Keys) As Integer
        If (key >= Keys.D1) AndAlso (key <= Keys.D9) Then
            Return (key - Keys.D1) + 1
        Else
            Return 0
        End If
    End Function


    Private Sub RepopulateFileNames()
        Cursor = Cursors.WaitCursor

        Try
            RenameButton.Enabled = False

            If (DirectoryTextBox.TextLength > 0) AndAlso Directory.Exists(DirectoryTextBox.Text) Then
                RepopulateFileNames(DirectoryTextBox.Text)
                RenameButton.Enabled = True
            End If

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub RepopulateFileNames(directory As String)
        FilesListView.BeginUpdate()
        cgPopulatingFileList = True

        Try
            Dim items As New List(Of ListViewItem)


            If Not directory.EndsWith(Path.DirectorySeparatorChar) Then
                directory &= Path.DirectorySeparatorChar
            End If

            FilesListView.Items.Clear()

            CreateListItems(directory, directory, items)

            FilesListView.Items.AddRange(items.ToArray)

            UpdateFileNames()

        Catch ex As Exception
            MessageBox.Show(
                "An error occurred when finding the files:" & Environment.NewLine & Environment.NewLine & ex.Message,
                "Failure",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        Finally
            cgPopulatingFileList = False
            FilesListView.EndUpdate()
        End Try
    End Sub


    Private Sub CreateListItems(
            root As String,
            directory As String,
            items As List(Of ListViewItem)
        )

        If Not DirectoriesOnlyCheckBox.Checked Then
            Dim files() As String


            files = IO.Directory.GetFiles(directory)

            For Each f In files
                Dim li As New ListViewItem
                Dim ext As String


                ext = Path.GetExtension(f)

                li.Text = f.Substring(root.Length, f.Length - (root.Length + ext.Length))
                li.Tag = f
                li.Checked = True

                items.Add(li)
            Next f
        End If

        If SubDirectoriesCheckBox.Checked OrElse DirectoriesOnlyCheckBox.Checked Then
            Dim directories() As String


            directories = IO.Directory.GetDirectories(directory)

            For Each d In directories
                If DirectoriesOnlyCheckBox.Checked Then
                    Dim li As New ListViewItem


                    li.Text = d.Substring(root.Length)
                    li.Tag = d
                    li.Checked = True

                    items.Add(li)

                Else
                    CreateListItems(root, d, items)
                End If
            Next d
        End If
    End Sub


    Private Sub UpdateFileNames()
        FilesListView.BeginUpdate()

        Try
            Dim fileNumber As Integer = 1


            For Each item In FilesListView.Items.Cast(Of ListViewItem)
                UpdateFileName(item, item.Checked, fileNumber)
            Next item

        Finally
            FilesListView.EndUpdate()
        End Try
    End Sub


    Private Sub UpdateFileName(
            item As ListViewItem,
            canChangeName As Boolean,
            ByRef fileNumber As Integer
        )

        If item.SubItems.Count < 2 Then
            item.SubItems.Add("")
        End If

        If canChangeName Then
            item.SubItems(1).Text = GetNewFileName(item.Text, fileNumber)

            ' Increment the file number because
            ' we were allowed to change the name.
            fileNumber += 1

        Else
            item.SubItems(1).Text = item.Text
        End If

        If String.Equals(item.Text, item.SubItems(1).Text) Then
            SetListItemColor(item, Color.Gray)
        Else
            SetListItemColor(item, Color.Empty)
        End If
    End Sub


    Private Sub SetListItemColor(
            item As ListViewItem,
            color As Color
        )

        item.ForeColor = color
        item.UseItemStyleForSubItems = True
    End Sub


    Private Function GetNewFileName(
            oldFileName As String,
            fileNumber As Integer
        ) As String

        Dim rc As String
        Dim replaceText As String


        rc = oldFileName
        replaceText = ReplaceTextBox.Text

        If replaceText.Length > 0 Then
            Dim withText As String


            withText = GetWithText(fileNumber)

            Try
                rc = Regex.Replace(oldFileName, replaceText, withText)
            Catch ex As Exception
                rc = oldFileName
            End Try
        End If

        Return rc
    End Function


    Private Function GetWithText(fileNumber As Integer) As String
        Dim rc As String
        Dim numberMatch As Match


        rc = WithTextBox.Text

        numberMatch = Regex.Match(rc, NumberPattern)

        If numberMatch.Success Then
            Dim digitsMatch As Match
            Dim replacementString As String


            digitsMatch = Regex.Match(numberMatch.Value, DigitPattern)

            If digitsMatch.Success Then
                replacementString = fileNumber.ToString(New String("0"c, Integer.Parse(digitsMatch.Value)))
            Else
                replacementString = fileNumber.ToString
            End If

            rc = Regex.Replace(rc, NumberPattern, replacementString)
        End If

        Return rc
    End Function


    Private Sub RenameButton_Click(
            sender As Object,
            e As EventArgs
        ) Handles RenameButton.Click

        If TextChangeTimer.Enabled Then
            TextChangeTimer.Stop()
            TextChangeTimer_Tick(Nothing, EventArgs.Empty)
        End If

        If MessageBox.Show("Are you sure you want to rename these files?", "Confirm Rename", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            RenameFiles()

            If WithTextBox.Focused Then
                ReplaceTextBox.Focus()
            End If
        End If
    End Sub


    Private Sub RenameFiles()
        Try
            For Each item In FilesListView.Items.Cast(Of ListViewItem)
                If item.Checked Then
                    Dim oldFileName As String
                    Dim newFileName As String
                    Dim ext As String


                    oldFileName = CStr(item.Tag)
                    ext = Path.GetExtension(oldFileName)

                    If LowerCaseExtensionCheckBox.Checked Then
                        ext = ext.ToLower
                    End If

                    newFileName = Path.Combine(DirectoryTextBox.Text, item.SubItems(1).Text) & ext

                    If Not String.Equals(oldFileName, newFileName) Then
                        Dim dir As String


                        dir = Path.GetDirectoryName(newFileName)

                        If Not Directory.Exists(dir) Then
                            Directory.CreateDirectory(dir)
                        End If

                        If DirectoriesOnlyCheckBox.Checked Then
                            Directory.Move(oldFileName, newFileName)
                        Else
                            File.Move(oldFileName, newFileName)
                        End If
                    End If
                End If
            Next item

        Catch ex As Exception
            MessageBox.Show(
                "An error occurred when renaming the files:" & Environment.NewLine & Environment.NewLine & ex.Message,
                "Rename Failure",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try

        RepopulateFileNames()
    End Sub


    Private Sub SelectAllButton_Click(
            sender As Object,
            e As EventArgs
        ) Handles SelectAllButton.Click

        For Each item In FilesListView.Items.Cast(Of ListViewItem)
            item.Checked = True
        Next item
    End Sub


    Private Sub SelectNoneButton_Click(
            sender As Object,
            e As EventArgs
        ) Handles SelectNoneButton.Click

        For Each item In FilesListView.Items.Cast(Of ListViewItem)
            item.Checked = False
        Next item
    End Sub


    Private Sub FilesListView_ItemChecked(
            sender As Object,
            e As ItemCheckedEventArgs
        ) Handles FilesListView.ItemChecked

        If Not cgPopulatingFileList Then
            If Regex.IsMatch(WithTextBox.Text, NumberPattern) Then
                ' Update all file names, because the file numbers have changed.
                UpdateFileNames()
            Else
                ' Only update the one item because the file numbers are not used.
                UpdateFileName(e.Item, e.Item.Checked, 0)
            End If
        End If
    End Sub


    Protected Overrides Sub OnDragEnter(drgevent As DragEventArgs)
        MyBase.OnDragEnter(drgevent)

        If drgevent.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files() As String


            files = TryCast(drgevent.Data.GetData(DataFormats.FileDrop), String())

            If (files IsNot Nothing) AndAlso (files.Length = 1) Then
                If Directory.Exists(files(0)) Then
                    drgevent.Effect = DragDropEffects.Move
                End If
            End If
        End If
    End Sub


    Protected Overrides Sub OnDragDrop(drgevent As DragEventArgs)
        MyBase.OnDragDrop(drgevent)

        If drgevent.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files() As String


            files = TryCast(drgevent.Data.GetData(DataFormats.FileDrop), String())

            If (files IsNot Nothing) AndAlso (files.Length = 1) Then
                If Directory.Exists(files(0)) Then
                    DirectoryTextBox.Text = files(0)
                End If
            End If
        End If
    End Sub

End Class
