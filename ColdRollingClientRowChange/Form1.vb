Public Class Form1

#Region "本機產線角色IP切換 函式:TheMachineRoleChange"
    ''' <summary>
    ''' 本機產線角色IP切換
    ''' </summary>
    ''' <param name="SetIP"></param>
    ''' <param name="SetMask"></param>
    ''' <param name="SetGateway"></param>
    ''' <remarks></remarks>
    Private Sub TheMachineRoleChange(ByVal SetIP As String, ByVal SetMask As String, ByVal SetGateway As String)
        Try
            Dim GetErrMessage As String = CompanyORMDB.DeviceInformation.ModifyPCIP("區域連線", SetIP, SetMask, SetGateway)
            If Not String.IsNullOrEmpty(GetErrMessage) Then
                MsgBox("電腦IP切換發生錯無法啟動 錯誤:" & GetErrMessage)
                CompanyORMDB.DeviceInformation.ModifyPCIP("區域連線", "192.168.1.253", "255.255.255.0", "192.168.1.254")
                Exit Sub
            End If
            Threading.Thread.Sleep(6000)
            Process.Start("IExplore.exe", "http://10.1.4.12/ColdRollingClient/ColdRollingClient.application")
            Me.Close()
        Catch ex As Exception
            MsgBox("電腦IP切換發生錯無法啟動 錯誤:" & ex.ToString)
            CompanyORMDB.DeviceInformation.ModifyPCIP("區域連線", "192.168.1.253", "255.255.255.0", "192.168.1.254")
        End Try
    End Sub
#End Region


    Private Sub tbCPL1_Click(sender As System.Object, e As System.EventArgs) Handles tbCPL1.Click, tbCPL2.Click, tbAPL1In.Click, tbAPL1Out.Click, tbAPL2In.Click, tbAPL2Out.Click, tbZML1.Click, tbZML2.Click, tbZML3.Click, tbGPL1.Click, tbGPL2.Click, tbBALIn.Click, tbBALOut.Click, tbSPLIn.Click, tbSPLOut.Click, tbSBL.Click, tbTLLOut.Click, tbUserDefine.Click, tbBALMiddle.Click, tbTLLIn.Click
        Dim SetIP As String = Nothing
        Dim SetMask As String = Nothing
        Dim SetGateway As String = Nothing

        Select Case True
            Case sender Is tbCPL1
                TheMachineRoleChange("10.12.10.10", "255.255.0.0", "10.12.1.253")
            Case sender Is tbCPL2
                TheMachineRoleChange("10.12.18.10", "255.255.0.0", "10.12.1.253")
            Case sender Is tbAPL1In
                TheMachineRoleChange("10.12.9.9", "255.255.0.0", "10.12.1.253")
            Case sender Is tbAPL1Out
                TheMachineRoleChange("10.12.7.10", "255.255.0.0", "10.12.1.253")
            Case sender Is tbAPL2In
                TheMachineRoleChange("10.12.4.9", "255.255.0.0", "10.12.1.253")
            Case sender Is tbAPL2Out
                TheMachineRoleChange("10.12.2.10", "255.255.0.0", "10.12.1.253")
            Case sender Is tbZML1
                TheMachineRoleChange("10.12.14.10", "255.255.0.0", "10.12.1.253")
            Case sender Is tbZML2
                TheMachineRoleChange("10.12.15.10", "255.255.0.0", "10.12.1.253")
            Case sender Is tbZML3
                TheMachineRoleChange("10.12.17.10", "255.255.0.0", "10.12.1.253")
            Case sender Is tbGPL1
                TheMachineRoleChange("10.12.13.19", "255.255.0.0", "10.12.1.253")
            Case sender Is tbGPL2
                TheMachineRoleChange("10.12.12.10", "255.255.0.0", "10.12.1.253")
            Case sender Is tbBALIn
                TheMachineRoleChange("10.12.21.9", "255.255.0.0", "10.12.1.253")
            Case sender Is tbBALMiddle
                TheMachineRoleChange("10.12.21.4", "255.255.0.0", "10.12.1.253")
            Case sender Is tbBALOut
                TheMachineRoleChange("10.12.21.3", "255.255.0.0", "10.12.1.253")
            Case sender Is tbSPLIn
                TheMachineRoleChange("10.12.6.9", "255.255.0.0", "10.12.1.253")
            Case sender Is tbSPLOut
                TheMachineRoleChange("10.12.6.10", "255.255.0.0", "10.12.1.253")
            Case sender Is tbSBL
                TheMachineRoleChange("10.12.20.10", "255.255.0.0", "10.12.1.253")
            Case sender Is tbTLLIn
                TheMachineRoleChange("10.12.5.4", "255.255.0.0", "10.12.1.253")
            Case sender Is tbTLLOut
                TheMachineRoleChange("10.12.5.10", "255.255.0.0", "10.12.1.253")
            Case sender Is tbUserDefine
                TheMachineRoleChange(TextBox1.Text.Trim, TextBox2.Text.Trim, TextBox3.Text.Trim)
        End Select
    End Sub


    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Try
        '    CompanyORMDB.DeviceInformation.ModifyPCIP("區域連線", "192.168.1.253", "255.255.255.0", "192.168.1.254")
        'Catch ex As Exception

        'End Try
    End Sub
End Class
