Imports System.Windows.Forms

Public Class ShowOrderDialog

#Region "上層表單 私有屬性:UPLevelForm"

    Private _UPLevelForm As Form
    ''' <summary>
    ''' 上層表單
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property UPLevelForm() As Form
        Get
            Return _UPLevelForm
        End Get
        Set(ByVal value As Form)
            _UPLevelForm = value
        End Set
    End Property


#End Region

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
        End Set
    End Property

#End Region
#Region "顯示在製品鋼捲入有主資料 屬性:DisplaySL2CICPFs"
    ''' <summary>
    ''' 顯示在製品鋼捲入有主資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DisplaySL2CICPFs As List(Of CompanyORMDB.SLS300LB.SL2CICPF)
        Get
            If IsNothing(CurrentRunningTreeNode) Then
                Return New List(Of CompanyORMDB.SLS300LB.SL2CICPF)
            End If
            Dim LastPPSSHAPFs As List(Of CompanyORMDB.IPPS100LB.IPPSSHAPF) = CurrentRunningTreeNode.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF
            If LastPPSSHAPFs.Count = 0 Then
                Return New List(Of CompanyORMDB.SLS300LB.SL2CICPF)
            End If
            Dim GetSL2CICPF As CompanyORMDB.SLS300LB.SL2CICPF = LastPPSSHAPFs(0).AboutSL2CICPF
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
            If IsNothing(CurrentRunningTreeNode) Then
                Return New List(Of CompanyORMDB.SLS300LB.SL2CIDPF)
            End If
            Dim LastPPSSHAPFs As List(Of CompanyORMDB.IPPS100LB.IPPSSHAPF) = CurrentRunningTreeNode.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF
            If LastPPSSHAPFs.Count = 0 Then
                Return New List(Of CompanyORMDB.SLS300LB.SL2CIDPF)
            End If
            Dim GetSL2CICPF As CompanyORMDB.SLS300LB.SL2CIDPF = LastPPSSHAPFs(0).AboutSL2CIDPF
            If IsNothing(GetSL2CICPF) Then
                Return New List(Of CompanyORMDB.SLS300LB.SL2CIDPF)
            End If
            Dim ReturnValue As New List(Of CompanyORMDB.SLS300LB.SL2CIDPF)
            ReturnValue.Add(GetSL2CICPF)
            Return ReturnValue
        End Get
    End Property
#End Region

    Shadows Sub Show(ByVal ParentForm As Form, ByVal SetCurrentRunningTreeNode As CoilScanedTreeNode)
        ParentForm.Enabled = False
        MyBase.Show()
        Dim SetControl As New SchedualInformation(SetCurrentRunningTreeNode)
        Panel1.Controls.Clear()
        Panel1.Controls.Add(SetControl)
        SetControl.Dock = DockStyle.Fill
        'Me.Controls.Add(SetControl)
        'Me.CurrentRunningTreeNode = SetCurrentRunningTreeNode
        'bsPPSCICPF.DataSource = DisplaySL2CICPFs
        'bsPPSCIDPF.DataSource = DisplaySL2CIDPFs
        Me.UPLevelForm = ParentForm
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        UPLevelForm.Enabled = True
        UPLevelForm.Show()
        Me.Close()
    End Sub



End Class
