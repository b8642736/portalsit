Imports System.Threading

Public Class MainForm


#Region "是否程式進入測試模式 變數:IsInTestMode"
    ''' <summary>
    ''' 是否程式進入測試模式
    ''' </summary>
    ''' <remarks></remarks>
    Private _IsInTestMode As Boolean
    Public Property IsInTestMode() As Boolean
        Get
            Return _IsInTestMode
        End Get
        Set(ByVal value As Boolean)
            _IsInTestMode = value
            If Not IsNothing(RollingOPCServer1MonitorObject) Then
            End If
        End Set
    End Property


#End Region

#Region "軋鋼伺服器監控物件 屬性:RollingOPCServer1MonitorObject"
    Public WithEvents RollingOPCServer1MonitorObjectEvent As RollIngOPCServer1Monitor
    Private _RollingOPCServer1MonitorObject As RollIngOPCServer1Monitor
    ''' <summary>
    ''' 軋鋼伺服器監控物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RollingOPCServer1MonitorObject() As RollIngOPCServer1Monitor
        Get
            If IsNothing(_RollingOPCServer1MonitorObject) Then
                _RollingOPCServer1MonitorObject = New RollIngOPCServer1Monitor(Me)
                RollingOPCServer1MonitorObjectEvent = _RollingOPCServer1MonitorObject
            End If
            Return _RollingOPCServer1MonitorObject
        End Get
        Set(ByVal value As RollIngOPCServer1Monitor)
            _RollingOPCServer1MonitorObject = value
            RollingOPCServer1MonitorObjectEvent = _RollingOPCServer1MonitorObject
        End Set
    End Property

#End Region
#Region "軋鋼爐溫監控物件 屬性:RollingAPLTemperatureMonitorObjects"
    Public WithEvents RollingAPL1TemperatureMonitorObjectsEvent As RollingAPLTemperatureMonitor
    Public WithEvents RollingAPL2TemperatureMonitorObjectsEvent As RollingAPLTemperatureMonitor
    Private _RollingAPLTemperatureMonitorObjects As List(Of RollingAPLTemperatureMonitor)
    ''' <summary>
    ''' 軋鋼爐溫監控物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RollingAPLTemperatureMonitorObjects() As List(Of RollingAPLTemperatureMonitor)
        Get
            If IsNothing(_RollingAPLTemperatureMonitorObjects) Then
                _RollingAPLTemperatureMonitorObjects = New List(Of RollingAPLTemperatureMonitor)
                Dim AddItem As New RollingAPLTemperatureMonitor(Me, "APL1")
                _RollingAPLTemperatureMonitorObjects.Add(AddItem)
                RollingAPL1TemperatureMonitorObjectsEvent = AddItem
                'AddItem = New RollingAPLTemperatureMonitor(Me, "APL2")
                '_RollingAPLTemperatureMonitorObjects.Add(AddItem)
                'RollingAPL2TemperatureMonitorObjectsEvent = AddItem
            End If
            Return _RollingAPLTemperatureMonitorObjects
        End Get
        Set(ByVal value As List(Of RollingAPLTemperatureMonitor))
            _RollingAPLTemperatureMonitorObjects = value
        End Set
    End Property


#End Region


#Region "即時顯示資來源 屬性:L2RealTimeTagDisplayDataSource"
    Private _L2RealTimeTagDisplayDataSource As New List(Of L2RealTimeTagDisplay)
    ''' <summary>
    ''' 即時顯示資來源
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property L2RealTimeTagDisplayDataSource() As List(Of L2RealTimeTagDisplay)
        Get
            Return _L2RealTimeTagDisplayDataSource
        End Get
        Set(ByVal value As List(Of L2RealTimeTagDisplay))
            _L2RealTimeTagDisplayDataSource = value
        End Set
    End Property


#End Region
#Region "合併即顯示資料至現有資料來源 函式:MergeL2RealTimeTagDisplayDataSource"
    ''' <summary>
    ''' 合併即顯示資料至現有資料來源
    ''' </summary>
    ''' <param name="FromMergeData"></param>
    ''' <param name="ToMergeData"></param>
    ''' <remarks></remarks>
    Private Sub MergeL2RealTimeTagDisplayDataSource(ByVal FromMergeData As List(Of L2RealTimeTagDisplay), ByRef ToMergeData As List(Of L2RealTimeTagDisplay), ByRef IsDataCountHaveChanged As Boolean)
        For Each EachItem As L2RealTimeTagDisplay In FromMergeData
            With EachItem
                Dim FindObject As L2RealTimeTagDisplay = (From A In ToMergeData Where A.LineName.Trim.ToUpper = .LineName.Trim And A.TagName.Trim.ToUpper = .TagName.Trim.ToUpper Select A).FirstOrDefault
                If IsNothing(FindObject) Then
                    ToMergeData.Add(EachItem)
                    IsDataCountHaveChanged = True
                Else
                    FindObject.ValueChangeTime = .ValueChangeTime
                    FindObject.KeyNameForCoil = .KeyNameForCoil
                    FindObject.TagIntValue = .TagIntValue
                    FindObject.TagStringValue = .TagStringValue
                    FindObject.IsGoodStatus = .IsGoodStatus
                    FindObject.NextSaveTime = .NextSaveTime
                    FindObject.Description = .Description
                End If
            End With
        Next
    End Sub
#End Region

#Region "Tag接收後續處理物件 屬性:AllTagChangeProcesses"
    Private _AllTagChangeProcesses As List(Of ITagChangeForProcess)
    ''' <summary>
    ''' Tag接收後續處理物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AllTagChangeProcesses() As List(Of ITagChangeForProcess)
        Get
            If IsNothing(_AllTagChangeProcesses) Then
                _AllTagChangeProcesses = New List(Of ITagChangeForProcess)
                _AllTagChangeProcesses.Add(New TagChangeForSaveProcess)
                _AllTagChangeProcesses.Add(New TagChangeForAPLProcess("APL1"))
                _AllTagChangeProcesses.Add(New TagChangeForAPLProcess("APL2"))
            End If
            Return _AllTagChangeProcesses
        End Get
        Private Set(ByVal value As List(Of ITagChangeForProcess))
            _AllTagChangeProcesses = value
        End Set
    End Property

#End Region

#Region "重整按鈕Enable 函式:RefreshEnableButton"
    ''' <summary>
    ''' 重整按鈕Enable
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshEnableButton(Optional ByVal PushButton As Button = Nothing)
        btnStart.Enabled = False
        btnStop.Enabled = False
        If tHAServerLookChange.Enabled OrElse (Not IsNothing(PushButton) AndAlso PushButton Is btnStart) Then
            btnStop.Enabled = True
        End If
        btnStart.Enabled = Not btnStop.Enabled

    End Sub
#End Region

#Region "是否啟動L2訊號截取 屬性:IsStartMoniter"
    Private _IsStartGetL2Value As Boolean = False
    ''' <summary>
    ''' 是否啟動L2訊號截取
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsStartGetL2Value As Boolean
        Get
            Return _IsStartGetL2Value
        End Get
        Private Set(value As Boolean)
            _IsStartGetL2Value = value
        End Set
    End Property
#End Region
#Region "啟動L2訊號截取 函式:StartGetL2Value"
    ''' <summary>
    ''' 啟動L2訊號截取
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StartGetL2Value()
        If IsStartGetL2Value = True Then
            Exit Sub
        End If

        '依據之前狀態重新預設訊號處理程序之狀態
        ReadLastStateAndSetThisStationState()

        Me.L2RealTimeTagDisplayDataSource.Clear()
        RollingOPCServer1MonitorObject.StartMonitorAllL2Tags()
        For Each EachItem As IMonitorObject In RollingAPLTemperatureMonitorObjects
            EachItem.StartMonitorAllL2Tags()
        Next
        RefreshEnableButton(btnStart)
        _IsStartGetL2Value = True
    End Sub
#End Region
#Region "結束L2訊號截取 函式:StopGetL2Value"
    ''' <summary>
    ''' 結束L2訊號截取
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StopGetL2Value()
        If IsStartGetL2Value = False Then
            Exit Sub
        End If
        RollingOPCServer1MonitorObject.StopMonitorAllL2Tags()
        For Each EachItem As IMonitorObject In RollingAPLTemperatureMonitorObjects
            EachItem.StopMonitorAllL2Tags()
        Next
        Dim myTheMachineServerData As CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus = TheMachineServerData
        myTheMachineServerData.LastRunningTime = myTheMachineServerData.LastRunningTime.AddSeconds(-10)
        myTheMachineServerData.IsRunningServer = False
        myTheMachineServerData.CDBSave()
        RefreshEnableButton(btnStop)
        _IsStartGetL2Value = False
        'L2RealTimeTagDisplayDataSource.Clear()
        DataGridView1.Refresh()
    End Sub
#End Region
#Region "暫停L2訊號截取 函式:PauseGetL2Value"
    ''' <summary>
    ''' 暫停L2訊號截取
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PauseGetL2Value()
        RollingOPCServer1MonitorObject.IsPauseGetData = True
        For Each EachItem As IMonitorObject In RollingAPLTemperatureMonitorObjects
            EachItem.IsPauseGetData = True
        Next
    End Sub
#End Region
#Region "繼續L2訊號截取 函式:ContinueGetL2Value"
    ''' <summary>
    ''' 繼續L2訊號截取
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ContinueGetL2Value()
        RollingOPCServer1MonitorObject.IsPauseGetData = False
        For Each EachItem As IMonitorObject In RollingAPLTemperatureMonitorObjects
            EachItem.IsPauseGetData = False
        Next
    End Sub
#End Region
#Region "讀取之前狀態重新預設訊號處理程序之狀態 函式:ReadLastStateAndSetThisStationState"
    ''' <summary>
    ''' 讀取之前狀態重新預設訊號處理程序之狀態
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReadLastStateAndSetThisStationState(Optional ByVal SetTheMachineServerData As L2RealTimeServerStatus = Nothing)
        Dim myTheMachineServerData = SetTheMachineServerData
        If IsNothing(SetTheMachineServerData) Then
            SetTheMachineServerData = Me.TheMachineServerData
        End If

        '設定APL1狀態
        Dim myTagChangeProcess As ITagChangeForProcess = (From A In AllTagChangeProcesses Where Not IsNothing(A.LineName) AndAlso A.LineName.Trim = "APL1" Select A).FirstOrDefault
        If Not IsNothing(myTheMachineServerData) AndAlso Not IsNothing(myTagChangeProcess) AndAlso Not String.IsNullOrEmpty(myTheMachineServerData.APL1ProcessStatus) AndAlso myTheMachineServerData.APL1ProcessStatus.Trim.Length > 0 Then
            For Each EachItem As String In myTheMachineServerData.APL1ProcessStatus.Trim.Split(";")
                Dim KeyValue() = EachItem.Split("@")
                If KeyValue.Count >= 2 Then
                    myTagChangeProcess.WriteObjectRunningProcessStatus.Item(KeyValue(0)) = KeyValue(1)
                End If
            Next
        End If

    End Sub
#End Region

    '-----------高可用性伺服器切換相關程式碼(檢測所有伺服器運作狀態,以達到高可用性目地)--------------
#Region "所有高可用性伺服器資料 ALLHAServerDataS"
    Private _ALLHAServerDataSLastAccessTime As DateTime = Now.AddSeconds(-3)
    Private _ALLHAServerDatas As List(Of CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus)
    ''' <summary>
    ''' 所有高可用性伺服器資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ALLHAServerDatas(Optional IsFlashData As Boolean = False) As List(Of CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus)
        Get
            If IsFlashData = True OrElse Now.Subtract(_ALLHAServerDataSLastAccessTime).TotalSeconds > 3 OrElse IsNothing(_ALLHAServerDatas) Then
                Dim QryString As String = "Select * from L2RealTimeServerStatus Where IsEnable=1 Order by NextStartUPOrder"
                _ALLHAServerDatas = CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus.CDBSelect(Of CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
            End If
            Dim NowTime As DateTime
            Try
                NowTime = CompanyORMDB.DeviceInformation.GetSQLServerTime(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m).Value
            Catch ex As Exception
                NowTime = Now
            End Try
            _ALLHAServerDataSLastAccessTime = NowTime
            Return _ALLHAServerDatas
        End Get
        Private Set(value As List(Of CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus))
            _ALLHAServerDatas = value
            Dim NowTime As DateTime
            Try
                NowTime = CompanyORMDB.DeviceInformation.GetSQLServerTime(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m).Value
            Catch ex As Exception
                NowTime = Now
            End Try
            _ALLHAServerDataSLastAccessTime = NowTime
        End Set
    End Property
#End Region
#Region "正在使用之伺服器資料 屬性:CurrentUseServerData"
    ''' <summary>
    ''' 正在使用之伺服器資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CurrentUseServerData As CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus
        Get
            Dim NowTime As DateTime
            Try
                NowTime = CompanyORMDB.DeviceInformation.GetSQLServerTime(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m).Value
            Catch ex As Exception
                NowTime = Now
            End Try
            For Each EachItem As CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus In ALLHAServerDatas(True)
                If EachItem.IsRunningServer AndAlso NowTime.Subtract(EachItem.LastRunningTime).TotalSeconds <= 20 Then
                    Return EachItem
                End If
            Next
            Return Nothing
        End Get
    End Property
#End Region
#Region "本機伺服器資料 屬性:TheMachineServerData"
    Private _TheMachineServerData As CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus
    ''' <summary>
    ''' 本機伺服器資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TheMachineServerData As CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus
        Get
            Dim ThePCIP As String = CompanyORMDB.DeviceInformation.GetLocalIPs(0).Trim
            _TheMachineServerData = (From A In ALLHAServerDatas(True) Where A.ServerIP = ThePCIP Select A).FirstOrDefault
            If IsNothing(_TheMachineServerData) Then
                Dim myALLHAServerDatas As List(Of CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus) = ALLHAServerDatas
                _TheMachineServerData = (From A In myALLHAServerDatas Where A.ServerIP.Trim = ThePCIP Select A).FirstOrDefault
                If IsNothing(_TheMachineServerData) Then
                    _TheMachineServerData = New CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus
                    With _TheMachineServerData
                        .ServerIP = ThePCIP
                        .NextStartUPOrder = myALLHAServerDatas.Count + 1
                        .IsRunningServer = (myALLHAServerDatas.Count = 0)
                        .IsEnable = True
                        Try
                            .LastRunningTime = CompanyORMDB.DeviceInformation.GetSQLServerTime(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m).Value
                        Catch ex As Exception
                            .LastRunningTime = Now
                        End Try
                        If .CDBSave() = 0 Then
                            _TheMachineServerData = Nothing
                        End If
                    End With
                End If
            End If
            Return _TheMachineServerData
        End Get
    End Property

#End Region
#Region "重整高可用性訊息狀態 函式:RefreshHAServerStateMessage"
    ''' <summary>
    ''' 重整高可用性訊息狀態
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshHAServerStateMessage()
        Dim ShowMessage As String = Nothing
        ShowMessage = IIf(tHAServerLookChange.Enabled, "高可用性功能啟動", "高可用性功能關閉")
        Dim ThePCIP As String = CompanyORMDB.DeviceInformation.GetLocalIPs(0).Trim
        Dim myTheMachineServerData As CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus = (From A In ALLHAServerDatas Where A.ServerIP.Trim = ThePCIP Select A).FirstOrDefault
        Dim myCurrentUseServerData As CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus = (From A In ALLHAServerDatas Where A.IsRunningServer Select A).FirstOrDefault
        If Not IsNothing(myTheMachineServerData) AndAlso Not IsNothing(myCurrentUseServerData) Then
            ShowMessage &= "," & IIf(myTheMachineServerData.ServerIP.Trim = myCurrentUseServerData.ServerIP.Trim, "本機正在執行資料接收運作", "本機正待命中") & "(優先權:" & myTheMachineServerData.NextStartUPOrder & ") !"
        End If
        tsslHAServerState.Text = ShowMessage

    End Sub
#End Region


    Private Sub tHAServerLookChange_Tick(sender As Object, e As EventArgs) Handles tHAServerLookChange.Tick
        '檢測所有伺服器運作狀態,以達到高可用性目地
        Try
            Dim NowTime As DateTime
            Try
                NowTime = CompanyORMDB.DeviceInformation.GetSQLServerTime(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m).Value
            Catch ex As Exception
                NowTime = Now
            End Try
            Dim myALLHAServerDatas As List(Of CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus) = ALLHAServerDatas(True)
            Dim myTheMachineServerData As CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus
            myTheMachineServerData = Me.TheMachineServerData
            Dim MyCurrentUseServerData As CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus = CurrentUseServerData
            If IsNothing(MyCurrentUseServerData) Then
                For Each EachItem As CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus In (From A In myALLHAServerDatas Where A.NextStartUPOrder <= myTheMachineServerData.NextStartUPOrder Select A).ToList
                    If EachItem.ServerIP.Trim <> myTheMachineServerData.ServerIP.Trim AndAlso NowTime.Subtract(EachItem.LastRunningTime).TotalSeconds <= 5 Then
                        Exit Sub     '有其它較為優先之伺服器存在,等待其它伺服器接手
                    End If
                    '無其它較為優先之伺服器存在,由本機伺服器接手
                    If EachItem.ServerIP.Trim = myTheMachineServerData.ServerIP.Trim Then
                        '由本機取得主要執行權並更新料庫通知其它主機
                        With EachItem
                            .CDBDelete()
                            .NextStartUPOrder = 1
                            .IsRunningServer = True
                            .LastRunningTime = NowTime
                            If .CDBSave() > 0 Then
                                If IsStartGetL2Value = False Then
                                    StartGetL2Value()   '實際起動L2接收
                                End If
                                Me.ContinueGetL2Value() '將原本暫止接收態改為繼續接收狀態
                                '變更其它服器為非運作狀態,並重新排序
                                Dim OrderCout As Integer = EachItem.NextStartUPOrder + 1
                                For Each EachOtherItem As CompanyORMDB.SQLServer.IM.L2RealTimeServerStatus In (From A In myALLHAServerDatas Where A.ServerIP.Trim <> EachItem.ServerIP.Trim Select A).ToList
                                    EachOtherItem.CDBDelete()
                                    EachOtherItem.NextStartUPOrder = OrderCout
                                    EachOtherItem.IsRunningServer = False
                                    EachOtherItem.CDBSave()
                                    OrderCout += 1
                                Next
                                Exit Sub
                            End If
                        End With
                    End If
                Next
            End If

            '不斷自我更新存在時間表示自已仍存在並在線上執行或等待,順便由資料庫更新本機狀態
            Dim ThePCIP As String = CompanyORMDB.DeviceInformation.GetLocalIPs(0).Trim
            If Not IsNothing(myTheMachineServerData) Then
                ReadLastStateAndSetThisStationState(myTheMachineServerData)   '順便由資料庫更新本機狀態
                With myTheMachineServerData
                    .LastRunningTime = NowTime
                    .CDBSave()
                End With
            End If

            '判斷是否本機為線上行中之伺服器,如果為真則將本機處理狀態同步寫入其它主機設定檔,以方便接手時直接取得
            Dim APL1ProcessStatusString As String = ""
            If Not IsNothing(MyCurrentUseServerData) AndAlso Not IsNothing(myTheMachineServerData) AndAlso MyCurrentUseServerData.ServerIP.Trim = myTheMachineServerData.ServerIP.Trim Then
                '已確認本機為線上正在執行運作之主要伺服器
                For Each EachItem As ITagChangeForProcess In AllTagChangeProcesses
                    If Not String.IsNullOrEmpty(EachItem.LineName) AndAlso TypeOf EachItem Is TagChangeForAPLProcess Then
                        Select Case True
                            Case EachItem.LineName.ToUpper.Trim = "APL1"
                                For Each EachItem1 In EachItem.ReadObjectRunningProcessStatus
                                    APL1ProcessStatusString &= IIf(String.IsNullOrEmpty(APL1ProcessStatusString), "", ";") & EachItem1.Key.Trim & "@" & EachItem1.Value.Trim
                                Next
                        End Select
                    End If
                Next
                Dim QryString = "Update L2RealTimeServerStatus Set APL1ProcessStatus='" & APL1ProcessStatusString & "'"
                MyCurrentUseServerData.SQLQueryAdapterByThisObject.ExecuteNonQuery(QryString)
            Else
                '已確認本機不是線上正在執行運作之主要伺服器
                If IsStartGetL2Value = True Then
                    Me.PauseGetL2Value()    '將本機L2接收態改為暫止接收
                End If
            End If

            RefreshHAServerStateMessage()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        tHAServerLookChange.Enabled = True
        RefreshEnableButton()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        tHAServerLookChange.Enabled = False
        PauseGetL2Value()
        RefreshHAServerStateMessage()
        RefreshEnableButton()
    End Sub

    Delegate Sub RunTagChangeProcessDelegate(ByVal RunProcessObject As ITagChangeForProcess, ByVal MonitorObject As IMonitorObject, ChangedDatas As List(Of L2RealTimeTagDisplay), ByVal TimeOutDatas As List(Of L2RealTimeTagDisplay))
    Private Sub RollingOPCServer1MonitorObjectEvent_DataChanged(ByVal Sender As IMonitorObject, ChangedDatas As List(Of L2RealTimeTagDisplay), ByVal TimeOutDatas As List(Of L2RealTimeTagDisplay)) Handles RollingOPCServer1MonitorObjectEvent.DataChanged, RollingAPL1TemperatureMonitorObjectsEvent.DataChanged, RollingAPL2TemperatureMonitorObjectsEvent.DataChanged
        If IsInTestMode Then
            Exit Sub
        End If
        For Each EachRunProcessObject As ITagChangeForProcess In AllTagChangeProcesses.ToArray
            Dim cb As New RunTagChangeProcessDelegate(AddressOf RunTagChangeProcess)
            Me.BeginInvoke(cb, EachRunProcessObject, Sender, ChangedDatas, TimeOutDatas)
        Next
        Dim IsDataCountHaveChanged As Boolean = False
        MergeL2RealTimeTagDisplayDataSource(Sender.AllL2RealTimeTagDisplay, L2RealTimeTagDisplayDataSource, IsDataCountHaveChanged)
        Me.bsL2RealTimeTagDisplay.DataSource = Me.L2RealTimeTagDisplayDataSource
        If IsDataCountHaveChanged Then
            Me.bsL2RealTimeTagDisplay.ResetBindings(False)
        End If
        DataGridView1.Refresh()

    End Sub


    'Private Sub RunTagChangeProcess(ByVal RunProcessObject As ITagChangeForProcess, ByVal MonitorObject As RollIngOPCServer1Monitor, ChangedDatas As List(Of L2RealTimeTagDisplay), ByVal TimeOutDatas As List(Of L2RealTimeTagDisplay))
    '    RunProcessObject.ProcessChange(MonitorObject.AllL2RealTimeTagDisplay, ChangedDatas, TimeOutDatas)
    'End Sub

    Private Sub RunTagChangeProcess(ByVal RunProcessObject As ITagChangeForProcess, ByVal MonitorObject As IMonitorObject, ChangedDatas As List(Of L2RealTimeTagDisplay), ByVal TimeOutDatas As List(Of L2RealTimeTagDisplay))
        RunProcessObject.ProcessChange(MonitorObject.AllL2RealTimeTagDisplay, ChangedDatas, TimeOutDatas)
        'Dim ProcessStatusString As String = ""
        'For Each EachItem In RunProcessObject.ReadObjectRunningProcessStatus
        '    ProcessStatusString &= IIf(String.IsNullOrEmpty(ProcessStatusString), "", ";") & EachItem.Key.Trim & ":" & EachItem.Value.Trim
        'Next
        'If Not String.IsNullOrEmpty(RunProcessObject.LineName) AndAlso TypeOf RunProcessObject Is TagChangeForAPLProcess Then
        '    Select Case True
        '        Case RunProcessObject.LineName.ToUpper.Trim = "APL1"
        '            TheMachineServerData.APL1ProcessStatus = ProcessStatusString
        '    End Select
        'End
    End Sub


    Private Sub RollingOPCServer1MonitorObjectEvent_Messag(IsErrorMessage As Boolean, Message As String) Handles RollingOPCServer1MonitorObjectEvent.Messag, RollingAPL1TemperatureMonitorObjectsEvent.Messag, RollingAPL1TemperatureMonitorObjectsEvent.Messag
        If IsErrorMessage Then
            tsslMessage.Text = Message
        Else
            tsslSaveTagMsg.Text = Message
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick, NotifyIcon1.MouseClick
        Me.Show()
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
        Else
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub MainForm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        StopGetL2Value()    '停止L2
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ''測試環境開啟強制轉變資料庫連線字串
        'CompanyORMDB.SQLServerSQLQueryAdapter.GlobalReplaceSqlConnectionString = "Data Source=10.1.3.52\SQLSERVER2014;Initial Catalog=QCdb01;Persist Security Info=True;User ID=TangengTest;Password='1j4@vu.4'"
        tHAServerLookChange.Enabled = True  '開始自動偵測並啟動訊號監控
        RefreshHAServerStateMessage()
    End Sub

End Class