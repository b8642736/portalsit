Public Class MainForm


#Region "偵測未上傳轉換之Excel檔並上傳後刪除 方法:UploadExcelFileConvertSuccessToDelete"
    ''' <summary>
    ''' 偵測未上傳轉換之Excel檔並上傳後刪除
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UploadExcelFileConvertSuccessToDelete() As Boolean
        NotifyIcon1.Text = "資料正在傳送中請稍後.....!"
        RichTextBox1.Text = Nothing
        StatusMessage.Text = NotifyIcon1.Text
        ConvertTimer.Enabled = False
        Try

            For Each EachFile As String In IO.Directory.GetFiles(My.Settings.Item("WatchFilderString"))

                Dim UploadFileFullPath As String = EachFile
                If EachFile.Length < 4 OrElse EachFile.Substring(EachFile.Length - 4, 4).ToUpper <> ".XLS" Then
                    Try
                        System.IO.File.Delete(UploadFileFullPath)
                    Catch ex As Exception
                        RichTextBox1.Text = ex.ToString & vbNewLine & RichTextBox1.Text
                    End Try
                    Continue For
                End If
                Me.ListBox1.Items.Clear()

                Dim AddNewConvertItem As New WaitConvertFileInfo(EachFile)
                Me.ListBox1.Items.Add(AddNewConvertItem)
                AddNewConvertItem.UploadAndConvert()
                RichTextBox1.Text = vbNewLine & AddNewConvertItem.ConvertResultMessage & "(時間:" & Now.ToString & ")" & RichTextBox1.Text
                If AddNewConvertItem.IsFileExistInDisk = False Then
                    Me.ListBox1.Items.Remove(AddNewConvertItem)
                End If
            Next
        Catch ex As Exception
            RichTextBox1.Text = ex.ToString & vbNewLine & RichTextBox1.Text
        Finally
            ConvertTimer.Enabled = (IO.Directory.GetFiles(My.Settings.Item("WatchFilderString")).Length > 0)
        End Try
        NotifyIcon1.Text = "EAF作業監控上傳轉檔程式"
        StatusMessage.Text = IIf(ConvertTimer.Enabled, "仍有資料轉換未完成,系統自動於" & ConvertTimer.Interval / 60000 & "分鐘後自動重送!", "所資料轉換完成!")
    End Function
#End Region



    Private Sub btnChangeWatchFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeWatchFolder.Click

        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.Item("WatchFilderString") = Me.FolderBrowserDialog1.SelectedPath
            lblWatchFolder.Text = My.Settings.Item("WatchFilderString")
            Me.FileSystemWatcher1.Path = My.Settings.Item("WatchFilderString")
        End If
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.IsNullOrEmpty(My.Settings.Item("WatchFilderString")) Then
            My.Settings.Item("WatchFilderString") = "C:\WatchFileTemp\Watching"
        End If
        lblWatchFolder.Text = My.Settings.Item("WatchFilderString")
        If System.IO.Directory.Exists(My.Settings.Item("WatchFilderString")) = False Then
            System.IO.Directory.CreateDirectory(My.Settings.Item("WatchFilderString"))
        End If
        Me.FileSystemWatcher1.Path = My.Settings.Item("WatchFilderString")
        UploadExcelFileConvertSuccessToDelete()
    End Sub

    Private Sub FileSystemWatcher1_Changed(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed
        Static PreChangeFile As String = Nothing
        If Not IsNothing(PreChangeFile) AndAlso PreChangeFile = e.FullPath Then
            Exit Sub
        End If
        PreChangeFile = e.FullPath
        UploadExcelFileConvertSuccessToDelete()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Visible = True
        Me.NotifyIcon1.Visible = False
    End Sub

    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click
        Me.Visible = False
        NotifyIcon1.Visible = True
    End Sub

    Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        btnHide_Click(Nothing, Nothing)
    End Sub


    Private Sub btnReStartConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReStartConvert.Click
        TabControl1.SelectedTab = Me.TabPage1
        UploadExcelFileConvertSuccessToDelete()
    End Sub

    Private Sub btnDeleteFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteFile.Click
        If Not IsNothing(Me.ListBox1.SelectedItem) Then
            CType(Me.ListBox1.SelectedItem, WaitConvertFileInfo).DeleteFile()
            If CType(Me.ListBox1.SelectedItem, WaitConvertFileInfo).IsFileExistInDisk = False Then
                Me.ListBox1.Items.Remove(Me.ListBox1.SelectedItem)
            End If
        End If
        btnDeleteFile.Enabled = False
    End Sub


    Private Sub ListBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseUp
        btnDeleteFile.Enabled = Not IsNothing(ListBox1.SelectedItem)
    End Sub

    Private Sub ConvertTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConvertTimer.Tick
        UploadExcelFileConvertSuccessToDelete()
    End Sub

End Class
