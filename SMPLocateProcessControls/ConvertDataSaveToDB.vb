Public Class ConvertDataSaveToDB

#Region "最後接數資料內容 屬性:LastReceiveData"

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
            Dim OLDData As String = _LastReceiveData
            _LastReceiveData = value
            Try
                If Not String.IsNullOrEmpty(_LastReceiveData) AndAlso OLDData <> _LastReceiveData Then
                    Select Case True
                        Case Me.LastReceiveDataDeviceType = DeviceTypeEnum.JY1
                            Dim DataConverter As New JY1Converter(_LastReceiveData)
                            Me.bsJY.Add(DataConverter.ORMObject)
                            Me.TabControl1.SelectedTab = Me.tpJYEditPage
                        Case Me.LastReceiveDataDeviceType = DeviceTypeEnum.JY3
                            Dim DataConverter As New JY3Converter(_LastReceiveData)
                            For Each EachItem As CompanyORMDB.SQLServer.QCDB01.JYData In DataConverter.ORMObjects
                                Me.bsJY.Add(EachItem)
                            Next
                            Me.TabControl1.SelectedTab = Me.tpJYEditPage
                        Case Me.LastReceiveDataDeviceType = DeviceTypeEnum.JY4
                            Dim DataConverter As New JY4Converter(_LastReceiveData)
                            For Each EachItem As CompanyORMDB.SQLServer.QCDB01.JYData In DataConverter.ORMObjects
                                Me.bsJY.Add(EachItem)
                            Next
                            Me.TabControl1.SelectedTab = Me.tpJYEditPage
                        Case Me.LastReceiveDataDeviceType = DeviceTypeEnum.JY5
                            Dim DataConverter As New JY5Converter(_LastReceiveData)
                            For Each EachItem As CompanyORMDB.SQLServer.QCDB01.JYData In DataConverter.ORMObjects
                                Me.bsJY.Add(EachItem)
                            Next
                            Me.TabControl1.SelectedTab = Me.tpJYEditPage
                        Case Me.LastReceiveDataDeviceType = DeviceTypeEnum.Xray
                            Dim DataConverter As New XRayConverter(_LastReceiveData)
                            For Each EachItem As CompanyORMDB.SQLServer.QCDB01.JYData In DataConverter.ORMObjects
                                Me.bsJY.Add(EachItem)
                            Next
                            Me.TabControl1.SelectedTab = Me.tpJYEditPage
                        Case Me.LastReceiveDataDeviceType = DeviceTypeEnum.OXYGEN
                            Dim DataConverter As New OXYGENConverter(_LastReceiveData)
                            Me.bsOXYGEN.Add(DataConverter.ORMObject)
                            Me.TabControl1.SelectedTab = Me.tpOxygenNitrogenPage
                        Case Me.LastReceiveDataDeviceType = DeviceTypeEnum.CarbonSulfur
                            Dim DataConverter As New CarbonSulfurConverter(_LastReceiveData)
                            Me.bsCarbonSulfur.Add(DataConverter.ORMObject)
                            Me.TabControl1.SelectedTab = Me.tpCarbonSulfurPage
                    End Select
                End If
            Catch ex As Exception
                MsgBox("儀器接收資料轉換發生錯誤!", ex.ToString)
            End Try
        End Set
    End Property

#End Region
#Region "最後接收資料裝置型別 屬性:LastReceiveDataDeviceType"
    Private _LastReceiveDataDeviceType As DeviceTypeEnum = DeviceTypeEnum.UnKnow
    ''' <summary>
    ''' 最後接收資料裝置型別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LastReceiveDataDeviceType() As DeviceTypeEnum
        Get
            Return _LastReceiveDataDeviceType
        End Get
        Private Set(ByVal value As DeviceTypeEnum)
            _LastReceiveDataDeviceType = value
        End Set
    End Property
#End Region
#Region "設定資料內容及接收裝置型別 函式:SetReceiveDataAndDeviceType"
    ''' <summary>
    ''' 設定資料內容及接收裝置型別
    ''' </summary>
    ''' <param name="SetData"></param>
    ''' <param name="SetDeviceType"></param>
    ''' <remarks></remarks>
    Public Sub SetReceiveDataAndDeviceType(ByVal SetData As String, ByVal SetDeviceType As DeviceTypeEnum)
        Me.LastReceiveDataDeviceType = SetDeviceType
        Me.LastReceiveData = SetData
    End Sub
#End Region
#Region "RS232接收控制項 屬性:RS232ReceiveControl"

    Private _RS232ReceiveControl As EquipmentDataReceive
    ''' <summary>
    ''' RS232接收控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RS232ReceiveControl() As EquipmentDataReceive
        Get
            Return _RS232ReceiveControl
        End Get
        Set(ByVal value As EquipmentDataReceive)
            Dim OldControl As EquipmentDataReceive = _RS232ReceiveControl
            _RS232ReceiveControl = value
            tpDeviceReceive.Controls.Clear()
            If Not IsNothing(OldControl) Then
                RemoveHandler OldControl.ReceiveData, AddressOf RS232ControlReceiveData
            End If
            If Not IsNothing(_RS232ReceiveControl) Then
                AddHandler _RS232ReceiveControl.ReceiveData, AddressOf RS232ControlReceiveData
                tpDeviceReceive.Controls.Add(_RS232ReceiveControl)
                _RS232ReceiveControl.Dock = DockStyle.Fill
                _RS232ReceiveControl.ReConnectAllRS232Equipment()
            End If
        End Set
    End Property

#End Region

    Public Sub RS232ControlReceiveData(ByVal ReceiveData As String, ByVal DataDeviceType As DeviceTypeEnum)
        SetReceiveDataAndDeviceType(ReceiveData, DataDeviceType)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If MsgBox("是否確定要清除所有資料", MsgBoxStyle.YesNo, ) = MsgBoxResult.Yes Then
            Me.bsJY.Clear()
        End If
    End Sub

    Private Sub ConvertDataSaveToDB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RS232ReceiveControl = New EquipmentDataReceive
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click

    End Sub

End Class
