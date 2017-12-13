Public Class EquipmentDataReceive

    Public Event ReceiveData(ByVal ReceiveData As String, ByVal DataDeviceType As DeviceTypeEnum)

#Region "最後接收資料SerialPort 屬性:LastReceiveDataSerialPort"
    Private _LastReceiveDataSerialPort As IO.Ports.SerialPort
    ''' <summary>
    ''' 最後接收資料SerialPort
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LastReceiveDataSerialPort() As IO.Ports.SerialPort
        Get
            Return _LastReceiveDataSerialPort
        End Get
        Private Set(ByVal value As IO.Ports.SerialPort)
            _LastReceiveDataSerialPort = value

            If Not IsNothing(_LastReceiveDataSerialPort) Then
                Try
                    Me.LastReceiveData = _LastReceiveDataSerialPort.ReadExisting

                Catch ex As Exception
                    rbtErrorMessage.Text = ex.ToString & rbtErrorMessage.Text
                    TabControl1.SelectedTab = TabPage3
                End Try
            End If
        End Set
    End Property

#End Region
#Region "最後接收資料裝置型別 屬性:LastReceiveDataDeviceType"
    ''' <summary>
    ''' 最後接收資料裝置型別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property LastReceiveDataDeviceType() As DeviceTypeEnum
        Get
            Select Case True
                Case IsNothing(LastReceiveDataSerialPort)
                    Return DeviceTypeEnum.UnKnow
                Case Me.LastReceiveDataSerialPort Is spJY1
                    Return DeviceTypeEnum.JY1
                Case Me.LastReceiveDataSerialPort Is spJY3
                    Return DeviceTypeEnum.JY3
                Case Me.LastReceiveDataSerialPort Is spJY4
                    Return DeviceTypeEnum.JY4
                Case Me.LastReceiveDataSerialPort Is spJY5
                    Return DeviceTypeEnum.JY5
                Case Me.LastReceiveDataSerialPort Is spOxygenNitrogen
                    Return DeviceTypeEnum.OXYGEN
                Case Me.LastReceiveDataSerialPort Is spXray
                    Return DeviceTypeEnum.Xray
                Case Me.LastReceiveDataSerialPort Is spCarbonSulfur
                    Return DeviceTypeEnum.CarbonSulfur
                Case Me.LastReceiveDataSerialPort Is spD
                    Return DeviceTypeEnum.DDevice
                Case Else
                    Return DeviceTypeEnum.UnKnow
            End Select
        End Get
    End Property
#End Region
#Region "最後接收資料內容 屬性:LastReceiveData"

    Private _LastReceiveData As String
    ''' <summary>
    ''' 最後接數資料內容
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LastReceiveData() As String
        Get
            Return _LastReceiveData
        End Get
        Private Set(ByVal value As String)
            _LastReceiveData = value
            Me.RTBData.Text = _LastReceiveData.Clone
            Me.RTBData.Refresh()
            RaiseEvent ReceiveData(_LastReceiveData, LastReceiveDataDeviceType)
        End Set
    End Property

#End Region
#Region "資料接收設定函式 函式:SetJY1Data,SetJY3Data,..."

    Private Sub SetJY1Data()
        Me.LastReceiveDataSerialPort = spJY1
    End Sub
    Private Sub SetJY3Data()
        Me.LastReceiveDataSerialPort = spJY3
    End Sub
    Private Sub SetJY4Data()
        Me.LastReceiveDataSerialPort = spJY4
    End Sub
    Private Sub SetJY5Data()
        Me.LastReceiveDataSerialPort = spJY5
    End Sub
    Private Sub SetOxygenNitrogenData()
        Me.LastReceiveDataSerialPort = spOxygenNitrogen
    End Sub
    Private Sub SetXrayData()
        Me.LastReceiveDataSerialPort = spXray
    End Sub
    Private Sub SetCarbonSulfurData()
        Me.LastReceiveDataSerialPort = spCarbonSulfur
    End Sub
    Private Sub SetDData()
        Me.LastReceiveDataSerialPort = spD
    End Sub

#End Region
#Region "重新連結所有Rs232設備 函式:ReConnectAllRS232Equipment"
    ''' <summary>
    ''' 重新連結所有Rs232設備
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReConnectAllRS232Equipment()
        For Each EachItem As IO.Ports.SerialPort In Me.RS232Components
            Dim SourceComponent As System.IO.Ports.SerialPort = EachItem
            If SourceComponent.IsOpen Then
                SourceComponent.Close()
            End If
            Dim ERRMsg As String = Nothing
            Try
                SourceComponent.Open()
            Catch ex As Exception
                ERRMsg = ex.ToString
            End Try
            Dim ConnectLabelControl As Label = Nothing
            Select Case True
                Case EachItem Is spJY1
                    ConnectLabelControl = jy1ConnMsg
                Case EachItem Is spJY3
                    ConnectLabelControl = jy3ConnMsg
                Case EachItem Is spJY4
                    ConnectLabelControl = jy4ConnMsg
                Case EachItem Is spJY5
                    ConnectLabelControl = jy5ConnMsg
                Case EachItem Is spOxygenNitrogen
                    ConnectLabelControl = ONConnMsg
                Case EachItem Is spXray
                    ConnectLabelControl = XrayConnMsg
                Case EachItem Is spCarbonSulfur
                    ConnectLabelControl = CSConnMsg
                Case EachItem Is spD
                    ConnectLabelControl = DEquipConnMsg
            End Select
            ConnectLabelControl.Text = IIf(IsNothing(ERRMsg), Format(Now, "yyyy/MM/dd hh:mm:ss ") & "連線成功!", "連線失敗!")
            ConnectLabelControl.ForeColor = IIf(IsNothing(ERRMsg), Color.Black, Color.Red)
            Select Case True
                Case Not String.IsNullOrEmpty(ERRMsg) AndAlso String.IsNullOrEmpty(rbtErrorMessage.Text)
                    rbtErrorMessage.Text = ERRMsg
                Case Not String.IsNullOrEmpty(ERRMsg) AndAlso Not String.IsNullOrEmpty(rbtErrorMessage.Text)
                    rbtErrorMessage.Text = ERRMsg & vbNewLine & rbtErrorMessage.Text
            End Select
        Next

    End Sub
#End Region
#Region "RS232元件集合 屬性:RS232Components"

    Private _RS232Components As List(Of IO.Ports.SerialPort)
    ''' <summary>
    ''' RS232元件集合
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RS232Components() As List(Of IO.Ports.SerialPort)
        Get
            If IsNothing(_RS232Components) Then
                _RS232Components = New List(Of IO.Ports.SerialPort)
                For Each EachItem As System.ComponentModel.IComponent In Me.components.Components
                    If TypeOf EachItem Is System.IO.Ports.SerialPort Then
                        _RS232Components.Add(EachItem)
                    End If
                Next
            End If
            Return _RS232Components
        End Get
    End Property

#End Region

    Private Shared Mut As New Threading.Mutex
    Private Sub spJY1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles spJY1.DataReceived, spJY3.DataReceived, spJY4.DataReceived, spJY5.DataReceived, spOxygenNitrogen.DataReceived, spXray.DataReceived, spCarbonSulfur.DataReceived, spD.DataReceived
        Threading.Thread.Sleep(3000)
        Mut.WaitOne()
        Select Case True
            Case sender Is spJY1
                Me.Invoke(New MethodInvoker(AddressOf Me.SetJY1Data), Nothing)
            Case sender Is spJY3
                Me.Invoke(New MethodInvoker(AddressOf Me.SetJY3Data), Nothing)
            Case sender Is spJY4
                Me.Invoke(New MethodInvoker(AddressOf Me.SetJY4Data), Nothing)
            Case sender Is spJY5
                Me.Invoke(New MethodInvoker(AddressOf Me.SetJY5Data), Nothing)
            Case sender Is spOxygenNitrogen
                Me.Invoke(New MethodInvoker(AddressOf Me.SetOxygenNitrogenData), Nothing)
            Case sender Is spXray
                Me.Invoke(New MethodInvoker(AddressOf Me.SetXrayData), Nothing)
            Case sender Is spCarbonSulfur
                Me.Invoke(New MethodInvoker(AddressOf Me.SetCarbonSulfurData), Nothing)
            Case sender Is spD
                Me.Invoke(New MethodInvoker(AddressOf Me.SetDData), Nothing)
        End Select
        Mut.ReleaseMutex()

    End Sub

    Private Sub spJY1_ErrorReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialErrorReceivedEventArgs) Handles spJY1.ErrorReceived, spJY3.ErrorReceived, spJY4.ErrorReceived, spJY5.ErrorReceived, spOxygenNitrogen.ErrorReceived, spXray.ErrorReceived, spCarbonSulfur.ErrorReceived, spD.ErrorReceived
        If String.IsNullOrEmpty(rbtErrorMessage.Text) Then
            rbtErrorMessage.Text = e.ToString
        Else
            rbtErrorMessage.Text &= e.ToString
        End If
    End Sub

    Private Sub btnClearErrorMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearErrorMessage.Click
        rbtErrorMessage.Text = Nothing
    End Sub

    Private Sub btnResetAllComPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAllComPort.Click
        ReConnectAllRS232Equipment()
    End Sub

    Private Sub btnShowDetail1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowDetailJY1.Click, btnShowDetailJY3.Click, btnShowDetailJY4.Click, btnShowDetailJY5.Click, btnShowDetailCS.Click, btnShowDetailD.Click, btnShowDetailOAndN.Click, btnShowDetailXRay.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.Cancel OrElse Me.OpenFileDialog1.CheckFileExists = False Then
            Exit Sub
        End If
        Dim ReadData As String = (New IO.StreamReader(Me.OpenFileDialog1.FileName)).ReadToEnd
        Me.RTBData.Text = ReadData
        Select Case True
            Case sender Is btnShowDetailJY1
                LastReceiveDataSerialPort = Me.spJY1
                Me.LastReceiveData = ReadData
            Case sender Is btnShowDetailJY3
                LastReceiveDataSerialPort = Me.spJY3
                Me.LastReceiveData = ReadData
            Case sender Is btnShowDetailJY4
                LastReceiveDataSerialPort = Me.spJY4
                Me.LastReceiveData = ReadData
            Case sender Is btnShowDetailJY5
                LastReceiveDataSerialPort = Me.spJY5
                Me.LastReceiveData = ReadData
            Case sender Is btnShowDetailCS
                LastReceiveDataSerialPort = Me.spCarbonSulfur
                Me.LastReceiveData = ReadData
            Case sender Is btnShowDetailD
                LastReceiveDataSerialPort = Me.spD
                Me.LastReceiveData = ReadData
            Case sender Is btnShowDetailOAndN
                LastReceiveDataSerialPort = Me.spOxygenNitrogen
                Me.LastReceiveData = ReadData
            Case sender Is btnShowDetailXRay
                LastReceiveDataSerialPort = Me.spXray
                Me.LastReceiveData = ReadData
        End Select
    End Sub

End Class
