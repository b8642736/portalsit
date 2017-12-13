''' <summary>
''' 硬體資訊
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class DeviceInformation



#Region "建構 初始值設定"
    Sub New()
        Me.NetworkPhysicalAddresss = GetNetworkPhysicalAddresss()    '取得本機網卡硬體編號
        Me.CpuIDs = GetCpuIDs() '取得本機CPU編號
        Me._ComputerTime = Now
    End Sub
#End Region


#Region "網卡硬體編號 屬性:NetworkPhysicalAddresss"

    Private _NetworkPhysicalAddresss As List(Of String)
    ''' <summary>
    ''' 網卡硬體編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NetworkPhysicalAddresss() As List(Of String)
        Get
            Return _NetworkPhysicalAddresss
        End Get
        Set(ByVal value As List(Of String))
            _NetworkPhysicalAddresss = value
        End Set
    End Property


#End Region
#Region "CPU編號 屬性:CpuIDs"

    Private _CpuIDs As List(Of String)
    ''' <summary>
    ''' CPU編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CpuIDs() As List(Of String)
        Get
            Return _CpuIDs
        End Get
        Set(ByVal value As List(Of String))
            _CpuIDs = value
        End Set
    End Property

#End Region
#Region "硬碟編號 屬性:HardDiskIDs"

    Private _HardDiskIDs As List(Of String)
    ''' <summary>
    ''' 硬碟編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HardDiskIDs() As List(Of String)
        Get
            Return _HardDiskIDs
        End Get
        Set(ByVal value As List(Of String))
            _HardDiskIDs = value
        End Set
    End Property

#End Region
#Region "系統時間 屬性:ComputerTime"

    Private _ComputerTime As DateTime
    Public Property ComputerTime() As DateTime
        Get
            If IsNothing(Me.CpuIDs) OrElse Me.CpuIDs.Item(0) = DeviceInformation.GetCpuIDs.Item(0) Then
                _ComputerTime = Now
            End If
            Return _ComputerTime
        End Get
        Set(ByVal value As DateTime)
            _ComputerTime = value
        End Set
    End Property

#End Region


#Region "取得本機網卡硬體編號 方法:GetNetworkPhysicalAddresss"
    ''' <summary>
    ''' 取得本機網卡硬體編號
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetNetworkPhysicalAddresss() As List(Of String)
        Static ReturnValue As List(Of String)


        If IsNothing(ReturnValue) OrElse ReturnValue.Count = 0 Then
            ReturnValue = New List(Of String)
            Dim mc As ManagementClass = New Management.ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim moc As Management.ManagementObjectCollection = mc.GetInstances()

            For Each mo As ManagementObject In moc
                If mo.Item("IPEnabled") = True Then
                    ReturnValue.Add(mo.Item("MacAddress").ToString())
                End If
            Next
        End If



        Return ReturnValue
    End Function

#End Region
#Region "取得本機CPU編號 方法:GetCpuIDs"
    ''' <summary>
    ''' 取得本機CPU編號
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetCpuIDs() As List(Of String)

        Static ReturnValue As List(Of String)

        'ReturnValue = New List(Of String)
        'ReturnValue.Add("aaaaaa")
        'Return ReturnValue

        If IsNothing(ReturnValue) OrElse ReturnValue.Count = 0 Then
            ReturnValue = New List(Of String)
            Dim mc As ManagementClass = New Management.ManagementClass("Win32_Processor")
            Dim moc As Management.ManagementObjectCollection = mc.GetInstances()

            For Each mo As ManagementObject In moc
                ReturnValue.Add(mo.Item("ProcessorId").ToString())
            Next
        End If

        Return ReturnValue
    End Function

#End Region
#Region "取得本機IP 方法:GetLocalIPs"
    ''' <summary>
    ''' 取得本機IP
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetLocalIPs() As List(Of String)
        Static ReturnValue As List(Of String) = Nothing
        If IsNothing(ReturnValue) Then
            ReturnValue = New List(Of String)
            Dim mso As ManagementObjectSearcher = New ManagementObjectSearcher("select * from Win32_NetworkAdapterConfiguration where IPEnabled='TRUE'")
            Dim ip As String = String.Empty
            For Each mo As ManagementObject In mso.Get()
                If Not IsDBNull(mo("IPAddress")) Then
                    For Each str As String In mo("IPAddress")
                        Select Case True
                            Case str = "0.0.0.0"
                            Case str.Split(".").Length <> 4
                            Case Else
                                ReturnValue.Add(IIf(str.Substring(0, 1) = ":", "127.0.0.1", str))
                        End Select
                    Next
                End If
            Next
        End If

        Return ReturnValue
    End Function
#End Region
#Region "變更本機網卡IP 方法:ChangeLocalIPs"
    ''' <summary>
    ''' 變更本機網卡IP
    ''' </summary>
    ''' <param name="SetNetworkPhysicalAddresssa"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ChangeLocalIPs(ByVal SetNetworkPhysicalAddresssa As String) As Boolean

    End Function
#End Region

#Region "變更電腦IP 函式:ModifyPCIP"
    ''' <summary>
    ''' 變更電腦IP
    ''' </summary>
    ''' <param name="NetworkAdapterName"></param>
    ''' <param name="IPaddress"></param>
    ''' <param name="SubMask"></param>
    ''' <param name="Gateway"></param>
    ''' <remarks>當執行發生異常則回傳錯誤訊息!</remarks>
    Shared Function ModifyPCIP(ByVal NetworkAdapterName As String, ByVal IPaddress As String, ByVal SubMask As String, ByVal Gateway As String) As String
        Dim DosCMD As String = "netsh interface ip set address " & NetworkAdapterName & " static " & IPaddress & " " & SubMask & " " & Gateway & " 1"
        Return RunDOSCmdHidden(DosCMD)
    End Function
#End Region

#Region "執行DOS命令 函式:RunDOSCmdHidden"
    ''' <summary>
    ''' 執行DOS命令
    ''' </summary>
    ''' <param name="RunCommand"></param>
    ''' <remarks>當執行發生異常則回傳錯誤訊息!</remarks>
    Shared Function RunDOSCmdHidden(ByVal RunCommand As String) As String
        Dim NewProcess As Process = New Process
        Dim NewProcessInfo As ProcessStartInfo = New ProcessStartInfo("cmd.exe")
        With NewProcessInfo
            .CreateNoWindow = True
            .UseShellExecute = False
            .Arguments = "/C " + RunCommand
            .RedirectStandardInput = False
            .RedirectStandardOutput = True
            .WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
        End With
        NewProcess.StartInfo = NewProcessInfo
        Try
            If NewProcess.Start Then
                NewProcess.WaitForExit(5000)
                Return NewProcess.StandardOutput.ReadToEnd.Trim
            End If
            Return "偵測處理程序無法啟動!"
        Catch ex As Exception
            Return ex.ToString
        Finally
            NewProcess.Close()
        End Try
    End Function
#End Region


#Region "取得AS400系統時間 方法:GetAS400ServerTime"
    ''' <summary>
    ''' 取得AS400系統時間
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAS400ServerTime() As Nullable(Of DateTime)
        Dim QryString As String = "SELECT current timestamp FROM @#sysibm.sysdummy1"
        Try
            Dim Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
            Dim GetValue As String = Adapter.SelectQuery.Rows(0).Item(0)
            Return DateTime.Parse(GetValue).AddYears(11)    'AS400日期落後11年
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region
#Region "取得SQLServer系統時間 方法:GetSQLServerTime"
    ''' <summary>
    ''' 取得SQLServer系統時間
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetSQLServerTime(ByVal SetSQLServerName As SQLServerSQLQueryAdapter.ConnectServerNameEnum) As Nullable(Of DateTime)
        Dim QryString As String = "select  getdate()"
        Try
            Dim Adapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SetSQLServerName, "tempdb")
            Dim GetValue As String = Adapter.SelectQuery(QryString).Rows(0).Item(0)
            Return DateTime.Parse(GetValue)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region

End Class
