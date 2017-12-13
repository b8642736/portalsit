Public Class ReceiveL2PDOMessage


    Public Shadows Event FileChangedEvent(sender As Object, e As IO.FileSystemEventArgs, L2PDOMessages As L2PDOMessage)

    Sub New(ByVal SetGetFileFullPath As String)
        FileFullPath = SetGetFileFullPath
    End Sub


#Region "開始監控 函式:StartWatch"
    ''' <summary>
    ''' 開始監控
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StartWatch() As Boolean
        If IsFileExist = False Then
            Return False
        End If
        myFileSystemWatcher.NotifyFilter = IO.NotifyFilters.LastWrite
        myFileSystemWatcher.Path = FilePath
        myFileSystemWatcher.Filter = FileName
        Me.myFileSystemWatcher.EnableRaisingEvents = True
        Return True
    End Function
#End Region

#Region "終止監控 函式:StopWatch"
    ''' <summary>
    ''' 終止監控
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StopWatch()
        Me.myFileSystemWatcher.EnableRaisingEvents = False
    End Sub
#End Region

#Region "重新載入L2檔案資料並傳送訊息 函式:RelodL2FileAndSendPDOMessage"
    ''' <summary>
    ''' 重新載入L2檔案資料並傳送訊息
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RelodL2FileAndSendPDOMessage()
        If IsFileExist = False Then
            Exit Sub
        End If
        Dim arg As New IO.FileSystemEventArgs(IO.WatcherChangeTypes.Changed, FilePath, FileName)
        SendWatchFileChangedEventSub(Nothing, arg, False)
    End Sub
#End Region

#Region "錯誤訊息 屬性/事件:ErrorMessage/ErrorMessageEvent"
    Public Shadows Event ErrorMessageEvent(ErrorMessage As String)
#End Region


#Region "檔案完整路徑 屬性:FileFullPath"
    Private _FileFullPath As String
    ''' <summary>
    ''' 檔案完整路徑
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileFullPath() As String
        Get
            Return _FileFullPath
        End Get
        Set(ByVal value As String)
            If IsFileExist = True Then
                RemoveHandler myFileSystemWatcher.Changed, AddressOf SendWatchFileChangedEvent
            End If
            _FileFullPath = value
            If IsFileExist = False Then
                Try
                    My.Computer.FileSystem.WriteAllText(_FileFullPath, "", False)
                Catch ex As Exception
                End Try
            End If
            If IsFileExist = True Then
                AddHandler myFileSystemWatcher.Changed, AddressOf SendWatchFileChangedEvent
            Else
                _FileFullPath = Nothing
            End If
        End Set
    End Property
#End Region
#Region "檔案是否存在 屬性:IsFileExist"
    ''' <summary>
    ''' 檔案是否存在
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsFileExist As Boolean
        Get
            If String.IsNullOrEmpty(FileFullPath) Then
                Return False
            End If
            Return IO.File.Exists(FileFullPath)
        End Get
    End Property
#End Region
#Region "監看檔案路徑 屬性:FilePath"
    ''' <summary>
    ''' 監看檔案路徑
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property FilePath As String
        Get
            If String.IsNullOrEmpty(FileFullPath) OrElse FileFullPath.Trim.Length = 0 Then
                Return ""
            End If
            Dim LastCharIndex As Integer = FileFullPath.LastIndexOf("/")
            If LastCharIndex < 0 Then
                Return ""
            End If
            Return FileFullPath.Substring(0, LastCharIndex + 1)
        End Get
    End Property
#End Region
#Region "監看檔案名稱 屬性:FileName"
    ''' <summary>
    ''' 監看檔案名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property FileName As String
        Get
            Dim ReplaceSting As String = FilePath
            If String.IsNullOrEmpty(FileFullPath) OrElse String.IsNullOrEmpty(ReplaceSting) OrElse FileFullPath.Trim.Length = 0 Then
                Return ""
            End If
            Return FileFullPath.Replace(ReplaceSting, Nothing)
        End Get
    End Property
#End Region

#Region "檔案監控物件 屬性:myFileSystemWatcher"
    Private _myFileSystemWatcher As IO.FileSystemWatcher = New IO.FileSystemWatcher
    ''' <summary>
    ''' 檔案監控物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property myFileSystemWatcher() As IO.FileSystemWatcher
        Get
            Return _myFileSystemWatcher
        End Get
    End Property

#End Region

#Region "傳送監看檔案變更事件 函式:SendWatchFileChangedEvent"
    ''' <summary>
    ''' 傳送監看檔案變更事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub SendWatchFileChangedEvent(sender As Object, e As IO.FileSystemEventArgs)
        SendWatchFileChangedEventSub(sender, e, True)
    End Sub

    Private Sub SendWatchFileChangedEventSub(ByVal sender As Object, ByVal e As IO.FileSystemEventArgs, ByVal WillCheckLastAccessTime As Boolean)
        Static PreEventFirstRowData As L2PDOMessage = Nothing
        Dim ErrorMessage As String = Nothing

        Threading.Thread.Sleep(0.5) '等待一下一防止檔案資料之不完整接收
        Dim LocalTempFileFullPath As String = Application.StartupPath & "\L2PDODataTemp.txt"
        FileCopy(e.FullPath, LocalTempFileFullPath)

        Dim GetL2PDOMessage As L2PDOMessage = Nothing

        Dim ReadDatas As New List(Of String)
        Using sr As New IO.StreamReader(LocalTempFileFullPath)
            Dim line As String
            Do
                line = sr.ReadLine()
                If Not (line Is Nothing) Then
                    ReadDatas.Add(line)
                End If
            Loop Until line Is Nothing
        End Using

        If ReadDatas.Count = 0 Then
            Exit Sub
        End If
        Try
            GetL2PDOMessage = New L2PDOMessage(ReadDatas(0))
        Catch ex As Exception
            ErrorMessage &= IIf(String.IsNullOrEmpty(ErrorMessage), Nothing, vbNewLine) & ex.ToString
            RaiseEvent ErrorMessageEvent(ErrorMessage)
            Exit Sub
        End Try
        If WillCheckLastAccessTime AndAlso Not IsNothing(PreEventFirstRowData) AndAlso PreEventFirstRowData.HappenTime = GetL2PDOMessage.HappenTime Then
            Exit Sub
        End If
        PreEventFirstRowData = GetL2PDOMessage
        RaiseEvent FileChangedEvent(sender, e, GetL2PDOMessage)
    End Sub

#End Region

End Class
