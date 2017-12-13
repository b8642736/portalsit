Public Class StartForm

#Region "鋼水溫度重量記錄查詢控制項 屬性/事件:TemperatureWeightSearchControl/TemperatureWeightSearchEvent"
    WithEvents TemperatureWeightSearchEvent As TemperatureWeightSearch
    Private _TemperatureWeightSearchControl As New TemperatureWeightSearch
    ''' <summary>
    ''' 鋼水溫度重量記錄查詢控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TemperatureWeightSearchControl As TemperatureWeightSearch
        Get
            Return _TemperatureWeightSearchControl
        End Get
    End Property
#End Region
#Region "扁鋼胚連續鑄造記錄查詢控制項 屬性/事件:SLABProcessSearchControl/SLABProcessSearchEvent"
    WithEvents SLABProcessSearchEvent As SLABProcessSearch
    Private _SLABProcessSearchControl As New SLABProcessSearch
    ''' <summary>
    ''' 鋼水溫度重量記錄查詢控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SLABProcessSearchControl As SLABProcessSearch
        Get
            Return _SLABProcessSearchControl
        End Get
    End Property
#End Region
#Region "鋼水溫度重量記錄控制項 屬性/事件:TemperatureWeightEditEditControl/TemperatureWeightEditEditControlEvent"
    Public WithEvents TemperatureWeightEditEditControlEvent As TemperatureWeightEdit
    Private _TemperatureWeightEditEditControl As New TemperatureWeightEdit
    ''' <summary>
    ''' 鋼水溫度重量記錄控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TemperatureWeightEditEditControl As TemperatureWeightEdit
        Get
            Return _TemperatureWeightEditEditControl
        End Get
    End Property
#End Region
#Region "扁鋼胚連續鑄造記錄表控制項 屬性/事件:SLABProcessEditControl/SLABProcessEditControlEvent"
    Public WithEvents SLABProcessEditControlEvent As SLABProcessEdit
    Private _SLABProcessEditControl As New SLABProcessEdit
    ''' <summary>
    ''' 扁鋼胚連續鑄造記錄表控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SLABProcessEditControl As SLABProcessEdit
        Get
            Return _SLABProcessEditControl
        End Get
    End Property
#End Region

#Region "元件登出核對是否可行 方法:IsControlCheckOutOK"
    ''' <summary>
    ''' 元件登出核對是否可行
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsControlCheckOutOK() As Boolean
        If Panel1.Controls.Count = 0 Then
            Return True
        End If
        If Panel1.Controls(0) Is TemperatureWeightEditEditControl Then
            Return TemperatureWeightEditEditControl.IsCheckOutOK
        End If
        If Panel1.Controls(0) Is SLABProcessEditControl Then
            Return SLABProcessEditControl.IsCheckOutOK
        End If
        Return True
    End Function
#End Region

    Private Sub btnEditSMSC1PF_Click(sender As System.Object, e As System.EventArgs) Handles btnEditSMSC1PF.Click, btnEditSMSC2PF.Click, btnSearchSMSC1PF.Click, btnSearchSMSC2PF.Click
        If IsControlCheckOutOK() = False Then
            Exit Sub
        End If
        btnEditSMSC1PF.BackColor = Control.DefaultBackColor
        btnEditSMSC2PF.BackColor = Control.DefaultBackColor
        btnSearchSMSC1PF.BackColor = Control.DefaultBackColor
        btnSearchSMSC2PF.BackColor = Control.DefaultBackColor
        CType(sender, Button).BackColor = Color.LightBlue
        Dim UseControl As Control = Nothing
        TemperatureWeightSearchEvent = Nothing
        SLABProcessSearchEvent = Nothing
        TemperatureWeightEditEditControlEvent = Nothing
        SLABProcessEditControlEvent = Nothing
        Select Case True
            Case sender Is btnEditSMSC1PF
                UseControl = TemperatureWeightEditEditControl
                TemperatureWeightEditEditControlEvent = UseControl
            Case sender Is btnEditSMSC2PF
                UseControl = SLABProcessEditControl
                SLABProcessEditControlEvent = UseControl
            Case sender Is btnSearchSMSC1PF
                UseControl = TemperatureWeightSearchControl
                TemperatureWeightSearchEvent = TemperatureWeightSearchControl
            Case sender Is btnSearchSMSC2PF
                UseControl = SLABProcessSearchControl
                SLABProcessSearchEvent = SLABProcessSearchControl
        End Select
        Panel1.Controls.Clear()
        If Not IsNothing(UseControl) Then
            Panel1.Controls.Add(UseControl)
            If Not UseControl Is SLABProcessEditControl Then
                UseControl.Dock = DockStyle.Fill
            Else
                UseControl.Location = New Point(0, 0)
            End If
        End If

    End Sub

    Private Sub StartForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If IsControlCheckOutOK() = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TemperatureWeightSearchEvent_SearchResult(Result As System.Collections.Generic.List(Of CompanyORMDB.SMS100LB.SMSC1PF)) Handles TemperatureWeightSearchEvent.SearchResult
        Call btnEditSMSC1PF_Click(btnEditSMSC1PF, Nothing)
        TemperatureWeightEditEditControl.SetSearchResultDatas(Result)
    End Sub

    Private Sub SLABProcessSearchEvent_SearchResult(Result As System.Collections.Generic.List(Of CompanyORMDB.SMS100LB.SMSC2PF)) Handles SLABProcessSearchEvent.SearchResult
        Call btnEditSMSC1PF_Click(btnEditSMSC2PF, Nothing)
        SLABProcessEditControl.SetSearchResultDatas(Result)

    End Sub

    Private Sub TemperatureWeightEditEditControlEvent_NewOrEditSMSC2PFEvent(EditData As CompanyORMDB.SMS100LB.SMSC2PF) Handles TemperatureWeightEditEditControlEvent.NewOrEditSMSC2PFEvent
        Call btnEditSMSC1PF_Click(btnEditSMSC2PF, Nothing)
        Dim SetData As New List(Of CompanyORMDB.SMS100LB.SMSC2PF)
        SetData.Add(EditData)
        SLABProcessEditControl.SetSearchResultDatas(SetData)
    End Sub

    Private Sub SLABProcessEditControlEvent_NewOrEditSMSC1PFEvent(EditData As CompanyORMDB.SMS100LB.SMSC1PF) Handles SLABProcessEditControlEvent.NewOrEditSMSC1PFEvent
        Call btnEditSMSC1PF_Click(btnEditSMSC1PF, Nothing)
        Dim SetData As New List(Of CompanyORMDB.SMS100LB.SMSC1PF)
        SetData.Add(EditData)
        TemperatureWeightEditEditControl.SetSearchResultDatas(SetData)
    End Sub
End Class