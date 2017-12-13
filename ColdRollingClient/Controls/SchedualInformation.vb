Public Class SchedualInformation

#Region "自訂顯示排程按鈕類別 類別:DisplayPPSSHAPFButtonClass"
    ''' <summary>
    ''' 自訂顯示排程按鈕類別
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DisplayPPSSHAPFButtonClass
        Inherits Button

        Sub New(ByVal SetDisplayPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF)
            Me.DisplayPPSSHAPF = SetDisplayPPSSHAPF
        End Sub

#Region "顯示排程 屬性:DisplayPPSSHAPF"

        Private _DisplayPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF
        ''' <summary>
        ''' 顯示排程
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DisplayPPSSHAPF() As CompanyORMDB.IPPS100LB.IPPSSHAPF
            Get
                Return _DisplayPPSSHAPF
            End Get
            Private Set(ByVal value As CompanyORMDB.IPPS100LB.IPPSSHAPF)
                _DisplayPPSSHAPF = value
            End Set
        End Property

#End Region
    End Class
#End Region
    'Public Event DisplayPPSSHAPFButtonClickEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)

#Region "目前正在執行鋼捲節點項目 屬性:CurrentRunningTreeNode"

    Private _CurrentRunningTreeNode As CoilScanedTreeNode
    ''' <summary>
    ''' 目前正在執行鋼捲節點項目
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentRunningTreeNode() As CoilScanedTreeNode
        Get
            Return _CurrentRunningTreeNode
        End Get
        Private Set(ByVal value As CoilScanedTreeNode)
            _CurrentRunningTreeNode = value
            If IsNothing(_CurrentRunningTreeNode) Then
                Me.Text = "未知!"
            Else
                Me.Text = _CurrentRunningTreeNode.CoilFullNumber
            End If
            ReSetRunDisplayButtons()
            If FlowLayoutPanel1.Controls.Count > 0 Then
                CurrentRunDisplayPPSSHAPFButton = FlowLayoutPanel1.Controls(0)
            End If
        End Set
    End Property

    Private Sub ReSetRunDisplayButtons()
        For Each EachItem As DisplayPPSSHAPFButtonClass In FlowLayoutPanel1.Controls
            RemoveHandler EachItem.Click, AddressOf DisplayPPSSHAPFButtonClick
        Next
        FlowLayoutPanel1.Controls.Clear()
        If IsNothing(CurrentRunningTreeNode) Then
            Exit Sub
        End If
        Dim CoilFullNumberForLastPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = CurrentRunningTreeNode.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF
        Dim AddButton As New DisplayPPSSHAPFButtonClass(CoilFullNumberForLastPPSSHAPF)
        AddButton.Text = CoilFullNumberForLastPPSSHAPF.SHA01 & CoilFullNumberForLastPPSSHAPF.SHA02.Trim
        AddHandler AddButton.Click, AddressOf DisplayPPSSHAPFButtonClick
        FlowLayoutPanel1.Controls.Add(AddButton)
    End Sub
#End Region
#Region "目前正在顯示之排程按鈕 屬性:CurrentRunDisplayPPSSHAPFButton"

    Private _CurrentRunDisplayPPSSHAPFButton As DisplayPPSSHAPFButtonClass
    ''' <summary>
    ''' 目前正在顯示之排程按鈕
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentRunDisplayPPSSHAPFButton() As DisplayPPSSHAPFButtonClass
        Get
            Return _CurrentRunDisplayPPSSHAPFButton
        End Get
        Set(ByVal value As DisplayPPSSHAPFButtonClass)
            _CurrentRunDisplayPPSSHAPFButton = value
            For Each Eachitem As DisplayPPSSHAPFButtonClass In FlowLayoutPanel1.Controls
                Eachitem.BackColor = Me.BackColor
            Next
            If Not IsNothing(_CurrentRunDisplayPPSSHAPFButton) Then
                _CurrentRunDisplayPPSSHAPFButton.BackColor = Color.LightGreen
            End If
            RefreshDisplay()
        End Set
    End Property

#End Region
#Region "顯示訂單資料 屬性:DisplaySL2CICPFs"
    ''' <summary>
    ''' 顯示訂單資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DisplaySL2CICPFs As List(Of CompanyORMDB.SLS300LB.SL2CICPF)
        Get
            If IsNothing(CurrentRunDisplayPPSSHAPFButton) OrElse IsNothing(CurrentRunningTreeNode) Then
                Return New List(Of CompanyORMDB.SLS300LB.SL2CICPF)
            End If
            Dim LastPPSSHAPFs As CompanyORMDB.IPPS100LB.IPPSSHAPF = CurrentRunningTreeNode.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF
            If IsNothing(LastPPSSHAPFs) Then
                Return New List(Of CompanyORMDB.SLS300LB.SL2CICPF)
            End If
            Dim GetSL2CICPF As CompanyORMDB.SLS300LB.SL2CICPF = LastPPSSHAPFs.AboutSL2CICPF
            If IsNothing(GetSL2CICPF) Then
                Return New List(Of CompanyORMDB.SLS300LB.SL2CICPF)
            End If
            Dim ReturnValue As New List(Of CompanyORMDB.SLS300LB.SL2CICPF)
            ReturnValue.Add(GetSL2CICPF)
            Return ReturnValue
        End Get
    End Property
#End Region
#Region "顯示列管訂單資料 屬性:DisplaySL2CIDPFs"
    ''' <summary>
    ''' 顯示列管訂單資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DisplaySL2CIDPFs As List(Of CompanyORMDB.SLS300LB.SL2CIDPF)
        Get
            If IsNothing(CurrentRunDisplayPPSSHAPFButton) OrElse IsNothing(CurrentRunningTreeNode) Then
                Return New List(Of CompanyORMDB.SLS300LB.SL2CIDPF)
            End If
            Dim LastPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = CurrentRunningTreeNode.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF
            If IsNothing(LastPPSSHAPF) Then
                Return New List(Of CompanyORMDB.SLS300LB.SL2CIDPF)
            End If
            Dim GetSL2CICPF As CompanyORMDB.SLS300LB.SL2CIDPF = LastPPSSHAPF.AboutSL2CIDPF
            If IsNothing(GetSL2CICPF) Then
                Return New List(Of CompanyORMDB.SLS300LB.SL2CIDPF)
            End If
            Dim ReturnValue As New List(Of CompanyORMDB.SLS300LB.SL2CIDPF)
            ReturnValue.Add(GetSL2CICPF)
            Return ReturnValue
        End Get
    End Property
#End Region
#Region "重整顯示 函式:RefreshDisplay"
    ''' <summary>
    ''' 重整顯示
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshDisplay()
        bsPPSCICPF.DataSource = DisplaySL2CICPFs
        bsPPSCIDPF.DataSource = DisplaySL2CIDPFs
        TabControl1.SelectedIndex = 0
    End Sub
#End Region

    Sub New(ByVal SetCurrentRunningTreeNode As CoilScanedTreeNode)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.CurrentRunningTreeNode = SetCurrentRunningTreeNode
    End Sub

    Private Sub DisplayPPSSHAPFButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CurrentRunDisplayPPSSHAPFButton = sender
    End Sub

End Class
