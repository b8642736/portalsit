Imports System.Threading

Public Class RollIngOPCServer1Monitor
    Implements IMonitorObject


    Public Event Messag(ByVal IsErrorMessage As Boolean, ByVal Message As String)
    Public Event DataChanged(ByVal Sender As RollIngOPCServer1Monitor, ByVal ChangedDatas As List(Of L2RealTimeTagDisplay), ByVal TimeOutDatas As List(Of L2RealTimeTagDisplay))

#Region "父控制項 屬性:ParentControl"
    ''' <summary>
    ''' 父控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ParentControl As Control
#End Region
#Region "L2訊號配接器 屬性/事件:L2OPCUAAdapter/L2OPCUAAdapterEvent"
    WithEvents L2OPCUAAdapterEvent As OPCUAAdapter
    Private _L2OPCUAAdapter As OPCUAAdapter
    ''' <summary>
    ''' L2訊號配接器
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property L2OPCUAAdapter() As OPCUAAdapter
        Get
            If IsNothing(L2OPCUAAdapterEvent) Then
                Dim tsslMessage As String = Nothing
                Try
                    _L2OPCUAAdapter = New OPCUAAdapter(ParentControl, "opc.tcp://10.12.6.30:49320")
                    If _L2OPCUAAdapter.ConnectOPCServer() = False Then
                        tsslMessage = "L2 設備訊號無法連線成功,無法取得訊號資料!"
                    Else
                        tsslMessage = "L2 設備訊號連線成功!"
                    End If
                Catch ex As Exception
                    tsslMessage = "L2 設備訊號連線失敗,無法取得訊號資料!"
                Finally
                    If Not IsNothing(tsslMessage) Then
                        RaiseEvent Messag(True, tsslMessage)
                    End If
                End Try
            End If
            L2OPCUAAdapterEvent = _L2OPCUAAdapter
            Return _L2OPCUAAdapter
        End Get
        Set(ByVal value As OPCUAAdapter)
            _L2OPCUAAdapter = value
        End Set
    End Property
#End Region
#Region "開始連線L2之OPCServer並取得資料 函式:StartUseOPCServerGetData "
    Private Sub StartUseOPCServerGetData()
        L2OPCUAAdapter.ClearSubscriptionItems()
        For Each EachTag As L2RecordDefine In AllL2MonitorDefine
            L2OPCUAAdapter.AddSubscriptionItem(EachTag.TagName.Trim, Type.GetType(EachTag.GetValueType.Trim))
        Next
        L2OPCUAAdapter.OPCItemSubscribt()
    End Sub

    Private Sub L2OPCUAAdapterEvent_DAServerStateChanged(clientHandle As Integer, state As Kepware.ClientAce.OpcDaClient.ServerState) Handles L2OPCUAAdapterEvent.DAServerStateChanged
        Select Case True
            Case state = Kepware.ClientAce.OpcDaClient.ServerState.CONNECTED
                RaiseEvent Messag(False, "L2訊號連線正常!")
            Case state = Kepware.ClientAce.OpcDaClient.ServerState.DISCONNECTED
                RaiseEvent Messag(True, "L2訊號中斷連線,無法取得鋼捲位置!")
            Case Else
                RaiseEvent Messag(True, "L2訊號連線異常,無法取得鋼捲位置!")
        End Select
    End Sub

    Public Shared mut As New Mutex()
    Private Sub L2OPCUAAdapterEvent_SubscriptionReaded(allQualitiesGood As Boolean, noErrors As Boolean, AllValues As Dictionary(Of Integer, OPCUAAdapter.OPCItemSubscribeDefine)) Handles L2OPCUAAdapterEvent.SubscriptionReaded
        If IsPauseGetData Then
            Exit Sub
        End If

        Try
            mut.WaitOne()
            Dim ChangedDatas As New List(Of L2RealTimeTagDisplay)
            Dim TimeOutDatas As New List(Of L2RealTimeTagDisplay)

            If allQualitiesGood = False Then
                RaiseEvent Messag(True, "資料載取有錯誤發生!")
            End If
            For Each EachItem As OPCUAAdapter.OPCItemSubscribeDefine In AllValues.Values
                Dim TagName As String = EachItem.ReadTagItemName.Trim
                Dim LineName As String = CType((EachItem.ReadTagItemName.Split("."))(0), String).Replace("ns=2;s=", Nothing).Trim
                Dim GetL2RealTimeTagDisplay As L2RealTimeTagDisplay = (From A In AllL2RealTimeTagDisplay Where A.LineName.Trim = LineName And A.TagName.Trim = TagName Select A).FirstOrDefault
                Dim AddItem As L2RealTimeTagDisplay = Nothing
                Dim IsHaveNewRecord As Boolean = False
                Dim DataChangeTime As DateTime = Now
                'OPCServerTrigerTime = DataChangeTime
                Dim GetL2RecordDefine As L2RecordDefine = (From A In AllL2MonitorDefine Where A.LineName.Trim = LineName And A.TagName.Trim = CType(EachItem.ReadTagItemName, String) Select A).FirstOrDefault
                If IsNothing(GetL2RealTimeTagDisplay) Then
                    AddItem = New L2RealTimeTagDisplay
                    With AddItem
                        .LineName = LineName
                        .TagName = TagName
                        .KeyNameForCoil = ""
                        .TagStringValue = ""
                        .IsGoodStatus = False
                        If Not IsNothing(GetL2RecordDefine) Then
                            .NextSaveTime = DataChangeTime.AddSeconds(GetL2RecordDefine.SaveDataTagIntervalSec)
                        Else
                            '不做存檔記錄,所以將下次存檔時前設為過期時間
                            .NextSaveTime = DataChangeTime.AddDays(-1).AddSeconds(-3000)
                        End If
                        .ValueChangeTime = DataChangeTime

                    End With
                    IsHaveNewRecord = True
                    AllL2RealTimeTagDisplay.Add(AddItem)
                    GetL2RealTimeTagDisplay = AddItem
                End If
                Dim QualityStatusCanged As Boolean = False

                With GetL2RealTimeTagDisplay
                    If .IsGoodStatus <> EachItem.OPCReturnValue.Quality.IsGood Then
                        .IsGoodStatus = EachItem.OPCReturnValue.Quality.IsGood
                        QualityStatusCanged = True
                    End If

                    If .NextSaveTime <= DataChangeTime Then
                        If Not IsNothing(GetL2RecordDefine) Then
                            .Description = GetL2RecordDefine.Description
                            If GetL2RecordDefine.SaveDataTagIntervalSec < 0 Then
                                '不做存檔記錄
                                .NextSaveTime = DataChangeTime.AddDays(-1).AddSeconds(-3000)
                            Else
                                .NextSaveTime = DataChangeTime.AddSeconds(GetL2RecordDefine.SaveDataTagIntervalSec)
                                TimeOutDatas.Add(GetL2RealTimeTagDisplay)
                            End If
                        Else
                            '不做存檔記錄
                            .NextSaveTime = DataChangeTime.AddDays(-1).AddSeconds(-3000)
                        End If
                    End If

                    If EachItem.DataType Is Type.GetType("Integer") Then
                        If .TagIntValue <> CType(EachItem.OPCReturnValue.Value, Single) Then
                            .TagIntValue = EachItem.OPCReturnValue.Value
                            .TagStringValue = .TagIntValue.ToString
                            .ValueChangeTime = DataChangeTime
                        End If
                    Else
                        If .TagStringValue.Trim <> CType(EachItem.OPCReturnValue.Value, String).Trim Then
                            .TagStringValue = EachItem.OPCReturnValue.Value.ToString
                            .TagIntValue = Val(.TagStringValue)
                            .ValueChangeTime = DataChangeTime
                        End If
                    End If
                    Try
                        If IsHaveNewRecord OrElse .ValueChangeTime = DataChangeTime OrElse QualityStatusCanged Then
                            ChangedDatas.Add(GetL2RealTimeTagDisplay)
                        End If
                        .CDBSave()
                    Catch ex As Exception
                        RaiseEvent Messag(True, ex.Message)
                    End Try
                End With

            Next
            RaiseEvent DataChanged(Me, ChangedDatas, TimeOutDatas)

        Catch ex As Exception
            RaiseEvent Messag(True, ex.Message)
        Finally
            mut.ReleaseMutex()
        End Try
    End Sub
#End Region
#Region "所有看版顯示L2Tag資料 屬性:AllL2RealTimeTagDisplay"
    Private _AllL2RealTimeTagDisplay As List(Of L2RealTimeTagDisplay)
    ''' <summary>
    ''' 所有看版顯示L2Tag資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AllL2RealTimeTagDisplay() As List(Of L2RealTimeTagDisplay) Implements IMonitorObject.AllL2RealTimeTagDisplay
        Get
            If IsNothing(_AllL2RealTimeTagDisplay) Then
                Dim QryString As String = "Select a.* from IM.dbo.L2RealTimeTagDisplay a LEFT JOIN PPS100LB.dbo.L2RecordDefine b on a.linename=b.linename and a.tagname=b.tagname where b.isenable=1 and b.DataSourceServer='RollingServer1'  order by a.LineName,a.TagName"
                _AllL2RealTimeTagDisplay = L2RealTimeTagDisplay.CDBSelect(Of L2RealTimeTagDisplay)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                'Me.bsL2RealTimeTagDisplay.DataSource = _AllL2RealTimeTagDisplay
                RaiseEvent DataChanged(Me, Nothing, Nothing)
            End If
            Return _AllL2RealTimeTagDisplay
        End Get
        Private Set(ByVal value As List(Of L2RealTimeTagDisplay))
            _AllL2RealTimeTagDisplay = value
            'Me.bsL2RealTimeTagDisplay.DataSource = _AllL2RealTimeTagDisplay
            RaiseEvent DataChanged(Me, Nothing, Nothing)
        End Set
    End Property

#End Region


#Region "開始訂閱監看變數 屬性:StartMonitorAllL2Tags"
    ''' <summary>
    ''' 訂閱監看變數
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartMonitorAllL2Tags() Implements IMonitorObject.StartMonitorAllL2Tags
        ReloadAllL2MonitordDefineFromDB()
        CheckMoniterTagsFromDBTimer.Enabled = True
    End Sub
#End Region
#Region "停止訂閱監看變數 屬性:StopMonitorAllL2Tags"
    ''' <summary>
    ''' 停止訂閱監看變數
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StopMonitorAllL2Tags() Implements IMonitorObject.StopMonitorAllL2Tags
        CheckMoniterTagsFromDBTimer.Enabled = False
        If L2OPCUAAdapter.IsEnableSubscribe Then
            L2OPCUAAdapter.Unsubscribe()
            'AllL2MonitorDefine = Nothing
            'AllL2RealTimeTagDisplay = Nothing
        End If
    End Sub
#End Region
#Region "監看L2變數定義 屬性:AllL2MonitorDefine"
    Private _AllL2MonitorDefine As New List(Of L2RecordDefine)
    ''' <summary>
    ''' 監看L2變數定義
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AllL2MonitorDefine() As List(Of L2RecordDefine)
        Get
            Return _AllL2MonitorDefine
        End Get
        Set(ByVal value As List(Of L2RecordDefine))
            _AllL2MonitorDefine = value
        End Set
    End Property
#End Region
#Region "重新由資料庫取得監看定義集合 函式:ReloadAllL2MonitordDefineFromDB"
    ''' <summary>
    ''' 重新由資料庫取得監看定義集合
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReloadAllL2MonitordDefineFromDB()
        If Me.IsPauseGetData Then
            Exit Sub
        End If
        Try
            mut.WaitOne()
            Dim Qry As String = "Select * from L2RecordDefine Where IsEnable=1 and DataSourceServer='RollingServer1' Order by LineName,TagName"
            Dim ReturnValue = L2RecordDefine.CDBSelect(Of L2RecordDefine)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, Qry)
            Dim AddOrModifyTagNames As New Dictionary(Of String, L2RecordDefine)
            Dim WillDeleteTagNames As New Dictionary(Of String, L2RecordDefine)



            'If Not IsNothing(AllL2MonitorDefine) AndAlso ReturnValue.Count = AllL2MonitorDefine.Count Then
            '    For Each EachTag As L2RecordDefine In ReturnValue
            '        Dim FindOldTag As L2RecordDefine = (From A In AllL2MonitorDefine Where A.LineName = EachTag.LineName And A.TagName.Trim.ToUpper = EachTag.TagName.Trim.ToUpper Select A).FirstOrDefault
            '        Select Case True
            '            Case IsNothing(FindOldTag)
            '                WillDeleteTagNames.Add(EachTag.TagName, EachTag)
            '            Case FindOldTag.LineName <> EachTag.LineName OrElse
            '                FindOldTag.TagName <> EachTag.TagName OrElse
            '                FindOldTag.SaveDataTagIntervalSec <> EachTag.SaveDataTagIntervalSec OrElse
            '                FindOldTag.IsEnable <> EachTag.IsEnable OrElse
            '                FindOldTag.GetValueType <> EachTag.GetValueType OrElse
            '                FindOldTag.DataSourceServer <> EachTag.DataSourceServer
            '                AddOrModifyTagNames.Add(EachTag.TagName, EachTag)
            '        End Select
            '    Next
            'Else
            '    For Each EachTag As L2RecordDefine In ReturnValue
            '        AddOrModifyTagNames.Add(EachTag.TagName, EachTag)
            '    Next
            'End If


            For Each EachTag As L2RecordDefine In AllL2MonitorDefine
                Dim FindNewTag As L2RecordDefine = (From A In ReturnValue Where A.LineName = EachTag.LineName And A.TagName.Trim.ToUpper = EachTag.TagName.Trim.ToUpper Select A).FirstOrDefault
                If IsNothing(FindNewTag) Then
                    WillDeleteTagNames.Add(EachTag.TagName, EachTag)
                Else
                    If FindNewTag.LineName <> EachTag.LineName OrElse _
                        FindNewTag.TagName <> EachTag.TagName OrElse _
                        FindNewTag.SaveDataTagIntervalSec <> EachTag.SaveDataTagIntervalSec OrElse _
                        FindNewTag.IsEnable <> EachTag.IsEnable OrElse
                        FindNewTag.GetValueType <> EachTag.GetValueType OrElse
                        FindNewTag.DataSourceServer <> EachTag.DataSourceServer Then
                        AddOrModifyTagNames.Add(FindNewTag.TagName, FindNewTag)
                    End If
                End If
            Next
            For Each EachTag As L2RecordDefine In ReturnValue
                Dim FindOldTag As L2RecordDefine = (From A In AllL2MonitorDefine Where A.LineName = EachTag.LineName And A.TagName.Trim.ToUpper = EachTag.TagName.Trim.ToUpper Select A).FirstOrDefault
                If IsNothing(FindOldTag) Then
                    AddOrModifyTagNames.Add(EachTag.TagName, EachTag)
                End If
            Next



            For Each EachItem As L2RecordDefine In AddOrModifyTagNames.Values
                Dim FindOldL2RecordDefine As L2RecordDefine = (From A In AllL2MonitorDefine Where A.TagName.Trim.ToUpper = EachItem.TagName.Trim.ToUpper Select A).FirstOrDefault
                If Not IsNothing(FindOldL2RecordDefine) Then
                    AllL2MonitorDefine.Remove(FindOldL2RecordDefine)
                End If
                L2OPCUAAdapter.AddSubscriptionItem(EachItem.TagName, System.Type.GetType(EachItem.GetValueType))
                AllL2MonitorDefine.Add(EachItem)
            Next
            For Each EachItem As L2RecordDefine In WillDeleteTagNames.Values
                'Dim FindOldL2RecordDefine As L2RecordDefine = (From A In AllL2MonitorDefine Where A.TagName.Trim.ToUpper = EachItem.TagName.Trim.ToUpper Select A).FirstOrDefault
                'If Not IsNothing(FindOldL2RecordDefine) Then
                'End If
                L2OPCUAAdapter.RemoveSubscriptionItem(EachItem.TagName)
                AllL2MonitorDefine.Remove(EachItem)
            Next

            If L2OPCUAAdapter.IsEnableSubscribe = False Then
                L2OPCUAAdapter.OPCItemSubscribt()
            End If

        Catch ex As Exception
            Throw ex
        Finally
            mut.ReleaseMutex()
        End Try

        'If ReturnValue.Count = 0 Then1
        '    If L2OPCUAAdapter.IsEnableSubscribe Then
        '        Me.StopMonitorAllL2Tags()
        '    End If
        '    AllL2MonitorDefine.Clear()
        '    Exit Sub
        'End If


        'Try
        '    mut.WaitOne()
        '    If IsDifferentOldData Then
        '        Me.StopMonitorAllL2Tags()
        '        AllL2MonitorDefine = ReturnValue
        '        StartUseOPCServerGetData()
        '        Exit Sub
        '    End If
        '    AllL2MonitorDefine = ReturnValue
        'Catch ex As Exception
        '    Throw ex
        'Finally
        '    mut.ReleaseMutex()
        'End Try

    End Sub
#End Region

#Region "監看變數查看變化計時器 屬性/事件:CheckMoniterTagsFromDBTimer/CheckMoniterTagsFromDBTimerObjEvent"
    WithEvents CheckMoniterTagsFromDBTimerObjEvent As System.Windows.Forms.Timer
    Private _CheckMoniterTagsFromDBTimer As System.Windows.Forms.Timer
    ''' <summary>
    ''' 監看變數查看變化計時器
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CheckMoniterTagsFromDBTimer As System.Windows.Forms.Timer
        Get
            If IsNothing(_CheckMoniterTagsFromDBTimer) Then
                _CheckMoniterTagsFromDBTimer = New System.Windows.Forms.Timer
                With _CheckMoniterTagsFromDBTimer
                    .Interval = 3000
                End With
                CheckMoniterTagsFromDBTimerObjEvent = _CheckMoniterTagsFromDBTimer
            End If

            Return _CheckMoniterTagsFromDBTimer
        End Get
    End Property

#End Region

#Region "是否暫停資截取 屬性:IsPauseGetData"
    ''' <summary>
    ''' 是否暫停資截取
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsPauseGetData As Boolean = False Implements IMonitorObject.IsPauseGetData
#End Region

    Private Sub CheckMoniterTagsFromDBTimerObjEvent_Tick(sender As Object, e As EventArgs) Handles CheckMoniterTagsFromDBTimerObjEvent.Tick
        CheckMoniterTagsFromDBTimer.Enabled = False
        ReloadAllL2MonitordDefineFromDB()
        CheckMoniterTagsFromDBTimer.Enabled = True
    End Sub

    Sub New(ByVal SetParentControl As Control)
        Me.ParentControl = SetParentControl
    End Sub

End Class
