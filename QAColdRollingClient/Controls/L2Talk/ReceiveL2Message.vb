Public Class ReceiveL2Message

    Public Event FileChangedEvent(sender As Object, e As IO.FileSystemEventArgs, L2Messages As L2Message1)

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

#Region "手動取得檔案並觸發物件 函式:ManualGetFileInfo"
    ''' <summary>
    ''' 手動取得檔案並觸發物件
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ManualGetFileInfo() As L2Message1
        If IsFileExist = False Then
            Return Nothing
        End If
        Dim LocalTempFileFullPath As String = Application.StartupPath & "\L2DataTemp.txt"

        'FileCopy(myFileSystemWatcher.Path & myFileSystemWatcher.Filter, LocalTempFileFullPath)


        FileCopy(Me.FileFullPath, LocalTempFileFullPath)


        ' Dim GetL2Message As New L2Message1("APL1,RUNNING,1,K1234,K1234B,0,0.52,1035")
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
            Return Nothing
        End If


        Dim GetL2Message As L2Message1 = New L2Message1(ReadDatas(0))


        ''original
        Try
            GetL2Message = New L2Message1(ReadDatas(0))
        Catch ex As Exception
            ErrorMessage &= IIf(String.IsNullOrEmpty(ErrorMessage), Nothing, vbNewLine) & ex.ToString
            RaiseEvent ErrorMessageEvent(ErrorMessage)
        End Try

        Return GetL2Message
    End Function
#End Region

#Region "錯誤訊息 屬性/事件:ErrorMessage/ErrorMessageEvent"
    Public Event ErrorMessageEvent(ErrorMessage As String)

    Private _ErrorMessage As String
    ''' <summary>
    ''' 錯誤訊息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ErrorMessage() As String
        Get
            Return _ErrorMessage
        End Get
        Set(ByVal value As String)
            _ErrorMessage = value
        End Set
    End Property

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
        Static PreEventFirstRowData As L2Message1 = Nothing
        Dim ErrorMessage As String = Nothing

        Threading.Thread.Sleep(0.5) '等待一下一防止檔案資料之不完整接收
        Dim LocalTempFileFullPath As String = Application.StartupPath & "\L2DataTemp.txt"
        For EachCount As Integer = 1 To 6   '
            Try
                FileCopy(e.FullPath, LocalTempFileFullPath)
                Exit For
            Catch ex As Exception
                Threading.Thread.Sleep(0.8) '等待一下
                If EachCount = 6 Then
                    Throw New Exception("傳送監看檔案變更事件FileCopy發生錯誤(6次):" & ex.ToString)
                End If
            End Try
        Next

        Dim GetL2Message As L2Message1 = Nothing

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
            GetL2Message = New L2Message1(ReadDatas(0))
        Catch ex As Exception
            ErrorMessage &= IIf(String.IsNullOrEmpty(ErrorMessage), Nothing, vbNewLine) & ex.ToString
            RaiseEvent ErrorMessageEvent(ErrorMessage)
            Exit Sub
        End Try
        If Not IsNothing(PreEventFirstRowData) AndAlso PreEventFirstRowData.Message = GetL2Message.Message Then
            Exit Sub
        End If
        PreEventFirstRowData = GetL2Message
        RaiseEvent FileChangedEvent(sender, e, GetL2Message)
    End Sub
#End Region



End Class
