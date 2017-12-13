Public Class MonitorClientPCStatusDisplayItem
    Inherits CompanyLINQDB.SMPClientPCMonitor

    Shared DataContext As New ClassDBDataContext

#Region "查詢 屬性:Search"
    Private Shared Mut As New Threading.Mutex

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Search() As List(Of MonitorClientPCStatusDisplayItem)
        Mut.WaitOne()
        Dim MonitorPCClient As IQueryable(Of CompanyLINQDB.SMPClientPCMonitor) = From A In DataContext.SMPClientPCMonitor Select A
        Dim MonitorPCClientInfo As List(Of CompanyLINQDB.WebClientPCAccount) = (From A In DataContext.WebClientPCAccount, B In MonitorPCClient Where A.ClientIP = B.ClientPCIP Select A).ToList
        Dim ReturnValue As New List(Of MonitorClientPCStatusDisplayItem)
        For Each EachItem As CompanyLINQDB.SMPClientPCMonitor In MonitorPCClient.ToList
            Dim AddItem As New MonitorClientPCStatusDisplayItem
            Dim EachItemTemp As CompanyLINQDB.SMPClientPCMonitor = EachItem
            Dim AddItemInfo As CompanyLINQDB.WebClientPCAccount = (From A In MonitorPCClientInfo Where A.ClientIP = EachItemTemp.ClientPCIP Select A).FirstOrDefault
            With AddItem
                .ClientPCIP = EachItem.ClientPCIP
                .PingTimeOutSeconds = EachItem.PingTimeOutSeconds
                If Not IsNothing(AddItemInfo) Then
                    .ClentPCName = AddItemInfo.PCName
                    .Memo1 = AddItemInfo.Memo1
                Else
                    .ClentPCName = "電腦IP:" & EachItem.ClientPCIP
                End If
            End With
            ReturnValue.Add(AddItem)
            Threading.ThreadPool.QueueUserWorkItem(AddressOf PingCompletedCallback, AddItem)
        Next
        For Each EachItem In ReturnValue
            EachItem.AsyncPingSignal.WaitOne()
        Next
        Mut.ReleaseMutex()
        Return (From A In ReturnValue Select A Order By A.IsNetworkNormal).ToList
    End Function

    Private Shared Sub PingCompletedCallback(ByVal sender As Object)
        Dim pingSender As New Net.NetworkInformation.Ping
        Dim SenderObj As MonitorClientPCStatusDisplayItem = sender
        Try
            SenderObj.IsNetworkNormal = pingSender.Send(SenderObj.ClientPCIP.Trim, SenderObj.PingTimeOutSeconds * 1000).Status = Net.NetworkInformation.IPStatus.Success
        Catch ex As Exception
            SenderObj.IsNetworkNormal = False
            SenderObj.PingErrorMessagee = ex.ToString
        End Try

        SenderObj.AsyncPingSignal.Set()
    End Sub

#End Region

#Region "是否連線正常 屬性:IsNetworkNormal"
    Private _IsNetworkNormal As Boolean = False
    ''' <summary>
    ''' 是否連線正常
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsNetworkNormal() As Boolean
        Get
            Return _IsNetworkNormal
        End Get
        Private Set(ByVal value As Boolean)
            _IsNetworkNormal = value
        End Set
    End Property
#End Region

#Region "是否連線正常顯示說明 屬性:IsNetworkNormalDisplayText"
    ''' <summary>
    ''' 是否連線正常顯示說明
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsNetworkNormalDisplayText() As String
        Get
            If Me.IsNetworkNormal Then
                Return "連線正常Ok!"
            End If
            Return "注意:連線異常!"
        End Get
    End Property

#End Region

#Region "PING錯誤訊息 屬性:PingErrorMessagee"

    Private _PingErrorMessagee As String
    ''' <summary>
    ''' PING錯誤訊息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PingErrorMessagee() As String
        Get
            Return _PingErrorMessagee
        End Get
        Set(ByVal value As String)
            _PingErrorMessagee = value
        End Set
    End Property

#End Region

#Region "非同步Ping訊號 屬性:AsyncPingSignal"
    ''' <summary>
    ''' 非同步Ping訊號
    ''' </summary>
    ''' <remarks></remarks>
    Private _AsyncPingSignal As New Threading.AutoResetEvent(False)
    Private Property AsyncPingSignal() As Threading.AutoResetEvent
        Get
            Return _AsyncPingSignal
        End Get
        Set(ByVal value As Threading.AutoResetEvent)
            _AsyncPingSignal = value
        End Set
    End Property

#End Region

#Region "電腦名稱 屬性:ClentPCName"

    Private _ClentPCName As String
    ''' <summary>
    ''' 電腦名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ClentPCName() As String
        Get
            Return _ClentPCName
        End Get
        Private Set(ByVal value As String)
            _ClentPCName = value
        End Set
    End Property

#End Region

#Region "備註1 屬性:Memo1"

    Private _Memo1 As String
    ''' <summary>
    ''' 備註1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Memo1() As String
        Get
            Return _Memo1
        End Get
        Private Set(ByVal value As String)
            _Memo1 = value
        End Set
    End Property

#End Region



End Class
