Imports System.Threading

Public Class RollingAPLTemperatureMonitor
    Implements IMonitorObject

    Public Event Messag(ByVal IsErrorMessage As Boolean, ByVal Message As String)
    Public Event DataChanged(ByVal Sender As RollingAPLTemperatureMonitor, ByVal ChangedDatas As List(Of L2RealTimeTagDisplay), ByVal TimeOutDatas As List(Of L2RealTimeTagDisplay))


#Region "父控制項 屬性:ParentControl"
    ''' <summary>
    ''' 父控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ParentControl As Control
#End Region
#Region "產線名稱 屬性:LineName"
    ''' <summary>
    ''' 產線名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LineName As String = Nothing
#End Region

#Region "顯示更新計時器(每三秒更新一次) 屬性:DisplayTimer"
    ''' <summary>
    ''' 顯示更新計時器(每三秒更新一次)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property DisplayTimer As System.Timers.Timer = New System.Timers.Timer(3000)
#End Region
#Region "Tag爐溫資料記錄寫入計時器 屬性:TagWriteTimers"
    ''' <summary>
    ''' Tag爐溫資料記錄寫入計時器
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property TagWriteTimers As List(Of System.Timers.Timer) = New List(Of System.Timers.Timer)
#End Region
#Region "所有顯示欄位定義 屬性:ALLL2RecordDefine"
    Private _ALLL2RecordDefine As List(Of CompanyORMDB.SQLServer.PPS100LB.L2RecordDefine)
    ''' <summary>
    ''' 所有顯示欄位定義
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ALLL2RecordDefine() As List(Of CompanyORMDB.SQLServer.PPS100LB.L2RecordDefine)
        Get
            If IsNothing(_ALLL2RecordDefine) Then
                Dim QryString As String = "Select a.* from PPS100LB.dbo.L2RecordDefine a where a.linename='" & Me.LineName & "' and a.isenable=1 and a.DataSourceServer='APLMySQLServer1'  order by a.LineName,a.TagName"
                _ALLL2RecordDefine = L2RealTimeTagDisplay.CDBSelect(Of L2RecordDefine)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
            End If
            Return _ALLL2RecordDefine
        End Get
        Set(ByVal value As List(Of CompanyORMDB.SQLServer.PPS100LB.L2RecordDefine))
            _ALLL2RecordDefine = value
        End Set
    End Property

#End Region

#Region "開始定時取得資料 函式:StartUseOPCServerGetData "
    Public Shared mut As New Mutex()
    Private Sub StartUseServerGetData()
        ALLL2RecordDefine = Nothing
        AddHandler DisplayTimer.Elapsed, AddressOf OnTimedEvent
        DisplayTimer.Start()
    End Sub

    Private Sub OnTimedEvent(source As Object, e As Timers.ElapsedEventArgs)
        If (Me.LineName <> "APL1" And Me.LineName <> "APL2") OrElse IsPauseGetData Then
            Exit Sub
        End If
        Static PreGetDBLastTimeFielValue As String = Nothing
        Dim Conn As Data.Odbc.OdbcConnection = Nothing
        Dim QryString As String = Nothing
        If Me.LineName = "APL1" Then
            Conn = New Data.Odbc.OdbcConnection(My.Settings.APL1MySQL)
            QryString = "Select * from apl1.table1 order by Time desc limit 1 "
        Else
            Conn = New Data.Odbc.OdbcConnection(My.Settings.APL1MySQL)
            QryString = "Select * from apl2.table1 order by Time desc limit 1 "
        End If
        Dim QryCmd As New System.Data.Odbc.OdbcCommand(QryString, Conn)
        Dim QryAdapter As New System.Data.Odbc.OdbcDataAdapter(QryCmd)
        Dim MyDataset As New DataSet
        Dim ChangedDatas As New List(Of L2RealTimeTagDisplay)
        Dim TimeOutDatas As New List(Of L2RealTimeTagDisplay)
        Dim NowTime As DateTime = Now

        Try
            mut.WaitOne()
            QryAdapter.Fill(MyDataset)
            For Each EachItem As DataColumn In MyDataset.Tables(0).Columns
                If {"TIME"}.Contains(EachItem.ColumnName.ToUpper) Then
                    Continue For
                End If
                Dim FindDisplayData As L2RealTimeTagDisplay = (From A In AllL2RealTimeTagDisplay Where A.TagName.Trim = EachItem.ColumnName Select A).FirstOrDefault
                If IsNothing(FindDisplayData) Then
                    Dim AddItem As New L2RealTimeTagDisplay
                    With AddItem
                        .LineName = Me.LineName
                        .TagName = EachItem.ColumnName
                        .ValueChangeTime = NowTime
                        .IsGoodStatus = False
                        .NextSaveTime = NowTime.AddDays(-1).AddSeconds(-3000)
                    End With
                    If AddItem.CDBSave > 0 Then
                        AllL2RealTimeTagDisplay.Add(AddItem)
                    End If
                End If
            Next

            Dim ColumnName As String = Nothing
            If MyDataset.Tables(0).Rows.Count = 0 Then
                Exit Sub
            End If
            For Each EachItem In AllL2RealTimeTagDisplay
                If Not IsNothing(MyDataset.Tables(0).Columns.Item(EachItem.TagName.Trim.ToUpper)) Then
                    With EachItem
                        Select Case True
                            Case {"DATA1", "DATA2", "DATA3", "DATA4", "DATA5", "DATA6", "DATA7", "DATA8", "DATA9", "DATA10"}.Contains(.TagName.Trim.ToUpper)
                                If .TagIntValue <> MyDataset.Tables(0).Rows(0).Item(.TagName.Trim) Then
                                    .TagIntValue = MyDataset.Tables(0).Rows(0).Item(.TagName.Trim)
                                    .TagStringValue = .TagIntValue
                                    .ValueChangeTime = NowTime
                                    .IsGoodStatus = True
                                End If
                            Case .TagName.Substring(0, 4).ToUpper = "TIME"
                                .TagStringValue = Format(MyDataset.Tables(0).Rows(0).Item(.TagName), "yyyy/MM/dd HH:mm:ss")
                                .ValueChangeTime = NowTime
                                .IsGoodStatus = True
                            Case Else
                                .ValueChangeTime = NowTime
                                .IsGoodStatus = False
                        End Select

                        Dim GetL2RecordDefine As L2RecordDefine = (From A In ALLL2RecordDefine Where A.LineName.Trim = LineName And A.TagName.Trim.ToUpper = CType(EachItem.TagName, String).Trim.ToUpper Select A).FirstOrDefault
                        If Not IsNothing(GetL2RecordDefine) Then
                            .Description = GetL2RecordDefine.Description
                            If GetL2RecordDefine.SaveDataTagIntervalSec < 0 Then
                                '不做存檔記錄
                                .NextSaveTime = NowTime.AddDays(-1).AddSeconds(-3000)
                            Else
                                .NextSaveTime = NowTime.AddSeconds(GetL2RecordDefine.SaveDataTagIntervalSec)
                                TimeOutDatas.Add(EachItem)
                            End If
                        Else
                            '不做存檔記錄
                            .NextSaveTime = NowTime.AddDays(-1).AddSeconds(-3000)
                        End If
                    End With
                    If EachItem.ValueChangeTime = NowTime Then
                        ChangedDatas.Add(EachItem)
                    End If

                End If
            Next

            'RaiseEvent DataChanged(Me, ChangedDatas, TimeOutDatas)
            AsyncDataChanged(Me, ChangedDatas, TimeOutDatas)
        Catch ex As Exception
            'RaiseEvent Messag(True, ex.Message)
            AsyncMessag(True, ex.Message)
        Finally
            If Conn.State <> ConnectionState.Closed Then
                Conn.Close()
            End If
            mut.ReleaseMutex()
        End Try
    End Sub

    Delegate Sub DataChangedDelegate(ByVal Sender As RollingAPLTemperatureMonitor, ByVal ChangedDatas As List(Of L2RealTimeTagDisplay), ByVal TimeOutDatas As List(Of L2RealTimeTagDisplay))
    Sub AsyncDataChanged(ByVal Sender As RollingAPLTemperatureMonitor, ByVal ChangedDatas As List(Of L2RealTimeTagDisplay), ByVal TimeOutDatas As List(Of L2RealTimeTagDisplay))
        Dim DelegrateObj As DataChangedDelegate = New DataChangedDelegate(AddressOf AsyncDataChangedRaiseEvent)
        Me.ParentControl.Invoke(DelegrateObj, Me, ChangedDatas, TimeOutDatas)
    End Sub
    Sub AsyncDataChangedRaiseEvent(ByVal Sender As RollingAPLTemperatureMonitor, ByVal ChangedDatas As List(Of L2RealTimeTagDisplay), ByVal TimeOutDatas As List(Of L2RealTimeTagDisplay))
        RaiseEvent DataChanged(Sender, ChangedDatas, TimeOutDatas)
    End Sub


    Delegate Sub MessagDelegate(ByVal IsErrorMessage As Boolean, ByVal Message As String)
    Sub AsyncMessag(ByVal IsErrorMessage As Boolean, ByVal Message As String)
        Dim DelegrateObj As MessagDelegate = New MessagDelegate(AddressOf AsyncMessagEvent)
        Me.ParentControl.Invoke(DelegrateObj, IsErrorMessage, Message)
    End Sub
    Sub AsyncMessagEvent(ByVal IsErrorMessage As Boolean, ByVal Message As String)
        RaiseEvent Messag(IsErrorMessage, Message)
    End Sub
#End Region
#Region "所有即時看版L2Tag資料 屬性:AllL2RealTimeTagDisplay"
    Private _AllL2RealTimeTagDisplay As List(Of L2RealTimeTagDisplay)
    ''' <summary>
    ''' 所有即看版示L2Tag資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AllL2RealTimeTagDisplay() As List(Of L2RealTimeTagDisplay) Implements IMonitorObject.AllL2RealTimeTagDisplay
        Get
            If IsNothing(_AllL2RealTimeTagDisplay) Then
                Dim ShowFields As New System.Text.StringBuilder
                For Each EachField As L2RecordDefine In ALLL2RecordDefine
                    ShowFields.Append(IIf(String.IsNullOrEmpty(ShowFields.ToString), "", ",") & "'" & EachField.TagName.Trim & "'")
                Next
                Dim QryString As String = "Select a.* from IM.dbo.L2RealTimeTagDisplay a where linename='" & Me.LineName & "' and tagname in (" & ShowFields.ToString & ") order by a.LineName,a.TagName"
                _AllL2RealTimeTagDisplay = L2RealTimeTagDisplay.CDBSelect(Of L2RealTimeTagDisplay)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                'RaiseEvent DataChanged(Me, Nothing, Nothing)
                AsyncDataChanged(Me, Nothing, Nothing)

            End If
            Return _AllL2RealTimeTagDisplay
        End Get
        Private Set(ByVal value As List(Of L2RealTimeTagDisplay))
            _AllL2RealTimeTagDisplay = value
            'RaiseEvent DataChanged(Me, Nothing, Nothing)
            AsyncDataChanged(Me, Nothing, Nothing)
        End Set
    End Property

#End Region

#Region "開始訂閱監看變數 屬性:StartMonitorAllL2Tags"
    ''' <summary>
    ''' 訂閱監看變數
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartMonitorAllL2Tags() Implements IMonitorObject.StartMonitorAllL2Tags
        ReloadAllL2MonitorTagsFromDB(True)
    End Sub
#End Region
#Region "停止訂閱監看變數 屬性:StopMonitorAllL2Tags"
    ''' <summary>
    ''' 停止訂閱監看變數
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StopMonitorAllL2Tags() Implements IMonitorObject.StopMonitorAllL2Tags
        DisplayTimer.Stop()
    End Sub
#End Region
#Region "監看L2變數集合 屬性:AllL2MonitorTags"
    Private _AllL2MonitorTags As New List(Of L2RecordDefine)
    ''' <summary>
    ''' 監看L2變數集合
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AllL2MonitorTags() As List(Of L2RecordDefine)
        Get
            Return _AllL2MonitorTags
        End Get
        Set(ByVal value As List(Of L2RecordDefine))
            _AllL2MonitorTags = value
        End Set
    End Property
#End Region
#Region "重新由資料庫取得監看L2變數集合 函式:ReloadAllL2MonitorTagsFromDB"
    ''' <summary>
    ''' 變數集合
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReloadAllL2MonitorTagsFromDB(Optional ByVal WillReloadL2RecordDefine As Boolean = False)
        If Me.IsPauseGetData Then
            Exit Sub
        End If
        Dim Qry As String = "Select * from L2RecordDefine Where LineName='" & Me.LineName & "' and IsEnable=1 and DataSourceServer='APLMySQLServer1' Order by LineName,TagName"
        Dim ReturnValue = L2RecordDefine.CDBSelect(Of L2RecordDefine)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, Qry)
        Dim IsDifferentOldData As Boolean = False
        IsDifferentOldData = WillReloadL2RecordDefine
        If Not IsNothing(AllL2MonitorTags) AndAlso ReturnValue.Count = AllL2MonitorTags.Count Then
            For Each EachTag As L2RecordDefine In ReturnValue
                Dim FindOldTag As L2RecordDefine = (From A In AllL2MonitorTags Where A.LineName = EachTag.LineName And A.TagName = EachTag.TagName Select A).FirstOrDefault
                Select Case True
                    Case IsNothing(FindOldTag)
                        IsDifferentOldData = True : Exit For
                    Case FindOldTag.LineName <> EachTag.LineName OrElse
                        FindOldTag.TagName <> EachTag.TagName OrElse
                        FindOldTag.SaveDataTagIntervalSec <> EachTag.SaveDataTagIntervalSec OrElse
                        FindOldTag.IsEnable <> EachTag.IsEnable OrElse
                        FindOldTag.GetValueType <> EachTag.GetValueType OrElse
                        FindOldTag.DataSourceServer <> EachTag.DataSourceServer
                        IsDifferentOldData = True : Exit For
                End Select
            Next
        Else
            IsDifferentOldData = True
        End If

        If ReturnValue.Count = 0 Then
            Me.StopMonitorAllL2Tags()
            AllL2MonitorTags.Clear()
            Exit Sub
        End If

        Try
            mut.WaitOne()
            If IsDifferentOldData Then
                Me.StopMonitorAllL2Tags()
                AllL2MonitorTags = ReturnValue
                StartUseServerGetData()
                Exit Sub
            End If
            AllL2MonitorTags = ReturnValue
        Catch ex As Exception
            Throw ex
        Finally
            mut.ReleaseMutex()
        End Try

    End Sub
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

    Sub New(ByVal SetParentControl As Control, ByVal SetLineName As String)
        Me.ParentControl = SetParentControl
        LineName = SetLineName
    End Sub

End Class
