Imports System.IO

Public Class FileMoniter

    Public Event MessageChanged(ByVal ChangeFileFullPath As String, ByVal ChangeText As String)
    Private monitor_state As Boolean
    Private MonitorFileName As String

#Region "監看資料夾目錄 屬性:MoniterFolderPath"
    Private _MoniterFolderPath As String
    ''' <summary>
    ''' 監看資料夾目錄
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MoniterFolderPath() As String
        Get
            Return _MoniterFolderPath
        End Get
        Set(ByVal value As String)
            _MoniterFolderPath = value
        End Set
    End Property

#End Region

#Region "特定檔案內容 屬性:AllFileText"
    ''' <summary>
    ''' 特定檔案內容
    ''' </summary>
    ''' <remarks></remarks>
    Private _AllFileText As String
    Public Property AllFileText() As String
        Get
            Try
                'Get the name of all the txt files
                'Dim getfile = Directory.EnumerateFiles(MoniterFolderPath, "*.txt")
                'Dim fileReader As String

                '_AllFileText = ""
                ''Get all the data in each txt file , and merge
                'For Each cur_file As String In getfile
                '    Dim fileName = getfile.To.Substring(MoniterFolderPath.Length + 1)
                '    fileReader = My.Computer.FileSystem.ReadAllText(MoniterFolderPath + "\" + fileName)
                '    _AllFileText += fileReader
                'Next
                Dim fileReader As String
                Dim fileName = MoniterFolderPath + "\" + MonitorFileName + ".txt"

                _AllFileText = ""
                fileReader = My.Computer.FileSystem.ReadAllText(fileName)
                _AllFileText = fileReader
            Catch ex As Exception
            End Try
            Return _AllFileText
        End Get
        Private Set(ByVal value As String)
            _AllFileText = value
        End Set
    End Property

#End Region
#Region "新增之檔案內容 屬性:ChangedFileText"
    ''' <summary>
    ''' 新增之檔案內容
    ''' </summary>
    ''' <remarks></remarks>
    Private _ChangFileText As String
    Public Property ChangFileText() As String
        Get
            Dim new_data As String = ""
            Dim changed_data As String = ""

            If origin_data <> AllFileText() And origin_data.Length < AllFileText().Length Then

                Do While new_data.Length < origin_data.Length
                    new_data = AllFileText()
                Loop

                changed_data = new_data.Replace(origin_data, "")
                'Set the new data to be the origine data
                origin_data = new_data
                new_data = changed_data.Trim()
            End If
            _ChangFileText = new_data

            Return _ChangFileText
        End Get
        Private Set(ByVal value As String)
            _ChangFileText = value
        End Set
    End Property

#End Region

#Region "建立: FileSystemWatcher"
    Private _FileSystemWatcher1 As FileSystemWatcher
    Public Property FileSystemWatcher1() As FileSystemWatcher
        Get
            Return _FileSystemWatcher1
        End Get
        Set(ByVal value As FileSystemWatcher)
            _FileSystemWatcher1 = value
        End Set
    End Property
#End Region

    Public Sub StartWatch()
        If Not monitor_state Then
            Me._FileSystemWatcher1.EnableRaisingEvents = True
            origin_data = AllFileText()
            monitor_state = True
        End If
    End Sub

    Public Sub StopWatch()
        If monitor_state Then
            Me._FileSystemWatcher1.EnableRaisingEvents = False
            origin_data = ""
            monitor_state = False
        End If
    End Sub

    Sub New(ByVal SetMoniterFolderPath As String, ByVal SetMonitorFileName As String)
        Me.MoniterFolderPath = SetMoniterFolderPath
        Me.MonitorFileName = SetMonitorFileName

        If IsNothing(Me.FileSystemWatcher1) Then
            FileSystemWatcher1 = New FileSystemWatcher
            FileSystemWatcher1.Path = Me.MoniterFolderPath
            FileSystemWatcher1.NotifyFilter = NotifyFilters.Size
            FileSystemWatcher1.Filter = "*.txt"
            AddHandler FileSystemWatcher1.Changed, AddressOf FileChanged
        End If
    End Sub

    Private origin_data As String
    Private Sub FileChanged(sender As Object, e As FileSystemEventArgs)

        'Throw New NotImplementedException("Error")        

        Dim str_changed As String = ""

        str_changed = ChangFileText()

        RaiseEvent MessageChanged(e.FullPath, str_changed)
    End Sub
End Class
