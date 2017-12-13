Imports System
Imports System.Management
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Diagnostics


Public Class Form5
    Dim objCls As ManagementObject  'ManagementObject 類別 , 表示 WMI 執行個體。
    Dim strCls As String = "Win32_NetworkAdapterConfiguration"  'WMI 名稱空間 ( Namespace )
    Dim strNS As String = "\\MyMachine\root\cimv2" 'WMI 類別 (Class)
    Dim strIndex As String = "7" '用來記錄網路介面卡 Index


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'GetNetInfo()
        'GetAdtInfo()
        'SetAuto()
        SetNetCfg(1, {"192.168.1.3"}, {"255.255.255.0"}, {"192.168.1.1"}, {"168.95.192.1"}, {"168.95.192.1"})


        'Dim strWMIcls As String
        'Dim objNetAdt As Object
        'Dim strIPaddress(2) As String, strSubMask() As String, strGateway() As String
        'Dim strDNS1() As String, strDNS2() As String
        'strWMIcls = "Win32_NetworkAdapterConfiguration" ' WMI 類別
        'strIPaddress = {"192.168.10.99", "192.168.10.99"} ' IP 位址
        'strSubMask = {"255.255.255.0"} ' 子網路遮罩
        'strGateway = {"192.168.10.254"} ' 預設閘道
        'strDNS1 = {"168.95.1.1"} ' 慣用 DNS 伺服器
        'strDNS2 = {"168.95.192.1"} ' 其他 DNS 伺服器
        'objNetAdt = GetObject("winmgmts:").InstancesOf(strWMIcls)(strWMIcls & ".Index=1")
        '' Index=1 , 1 是可變的 , 可為 1 ~ N
        'With objNetAdt
        '    ' 變更 IP Address

        '    If .EnableStatic({strIPaddress}, {strSubMask}) = 0 Then MsgBox("IP 變更成功 !")
        '    ' 變更 Gateway
        '    'If .SetGateways({strGateway}, {1}) = 0 Then MsgBox("Gateway 變更成功 !")
        '    ' 變更 DNS Server
        '    'If .SetDNSServerSearchOrder({strDNS1, strDNS2}) = 0 Then MsgBox("DNS 變更成功 !")
        'End With
    End Sub



    Private Sub SetNetCfg(intIndex As Integer, strIP() As String, strSubmask() As String, strGateway() As String, strDNS1() As String, strDNS2() As String)

        Dim strComputer = "."
        Dim objWMIService = GetObject( _
            "winmgmts:\\" & strComputer & "\root\cimv2")
        Dim colNetAdapters = objWMIService.ExecQuery _
            ("Select * from Win32_NetworkAdapterConfiguration " _
                & "where IPEnabled=TRUE")
        Dim strIPAddress = {"192.168.1.141"}
        Dim strSubnetMask = {"255.255.255.0"}
        'Dim strGateway = {"192.168.1.100"}
        Dim strGatewayMetric = {"1"}

        For Each objNetAdapter In colNetAdapters
            Try
                Dim errEnable = objNetAdapter.EnableStatic(strIP, strSubmask)
                Dim errGateways = objNetAdapter.SetGateways(strGateway, strDNS1)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next
    End Sub
    Private Sub GetNetInfo()
        Dim strQry = "Select * from Win32_NetworkAdapterConfiguration where IPEnabled=True"
        Dim objSc As ManagementObjectSearcher = New ManagementObjectSearcher(strQry)
        Dim Msg1 As String = Nothing

        For Each objQry As ManagementObject In objSc.Get()
            Msg1 &= objQry("MACAddress").ToString
            Msg1 &= objQry("ServiceName").ToString
            Msg1 &= objQry("Index").ToString
        Next
        MsgBox(Msg1)
    End Sub



    Private Sub GetAdtInfo()
        Dim strQry = "Select * from Win32_NetworkAdapterConfiguration where IPEnabled=True"
        Dim objSc As ManagementObjectSearcher = New ManagementObjectSearcher(strQry)
        Dim Msg1 As String = Nothing
        For Each objQry In objSc.Get()
            Msg1 &= objQry("Caption")
        Next
        MsgBox(Msg1)

        '        // 指定查詢網路介面卡組態 ( IPEnabled 為 True 的 )
        'string strQry = "Select * from Win32_NetworkAdapterConfiguration where IPEnabled=True";

        '// ManagementObjectSearcher 類別 , 根據指定的查詢擷取管理物件的集合。
        'ManagementObjectSearcher objSc = new ManagementObjectSearcher(strQry);

        '// 使用 Foreach 陳述式 存取集合類別中物件 (元素)
        '// Get 方法 , 叫用指定的 WMI 查詢 , 並傳回產生的集合。
        'foreach (ManagementObject objQry in objSc.Get())
        '{
        '    // 取網路介面卡資訊
        '    ComboBox.Items.Add(objQry["Caption"]); // 將 Caption 新增至 ComboBox

        '}
        'ComboBox.SelectedIndex = 0;//預設選擇第一個

    End Sub

    Private Sub SetAuto()

        ' 建立 ManagementObject 物件 ( Scope , Path , options )

        'Dim s As New ManagementScope("\\MyMachine\root\cimv2")
        'Dim p As New ManagementPath("Win32_NetworkAdapterConfiguration")


        Dim objCls = New ManagementObject(strNS, strCls + ".INDEX=" + strIndex, Nothing)

        'Dim strWMIcls = "Win32_NetworkAdapterConfiguration" ' WMI 類別
        'Dim objCls = GetObject("winmgmts:").InstancesOf(strWMIcls)(strWMIcls & ".Index=1")
        ' InvokeMethod 方法 : 在物件上叫用方法。
        'objCls.InvokeMethod("EnableDHCP", {True}) ' 設定自動取得 IP
        'objCls.InvokeMethod("ReleaseDHCPLease", Nothing) ' 釋放 IP
        'objCls.InvokeMethod("RenewDHCPLease", Nothing) ' 重新取得 IP
        'objCls.InvokeMethod("SetDNSServerSearchOrder", Nothing) '設定自動取得DNS
        MessageBox.Show("自動取得IP設定完成！", "設定完成", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        MsgBox(CompanyORMDB.DeviceInformation.ModifyPCIP("區域連線", "192.168.1.253", "255.255.255.0", "192.168.1.254"))
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        MsgBox(CompanyORMDB.DeviceInformation.ModifyPCIP("區域連線", "10.1.3.22", "255.255.0.0", "10.1.1.253"))

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Threading.Thread.Sleep(6000)
        Process.Start("IExplore.exe", "http://10.1.4.12/ColdRollingClient/ColdRollingClient.application")
        Me.Close()
    End Sub
End Class