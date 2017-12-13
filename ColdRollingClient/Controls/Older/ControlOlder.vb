Public Class ControlOlder

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
            Dim OldValue As CoilScanedTreeNode = _CurrentRunningTreeNode
            _CurrentRunningTreeNode = value
            If Not IsNothing(_CurrentRunningTreeNode) AndAlso _CurrentRunningTreeNode.IsSpecialOrder = True Then
                If Not OldValue Is _CurrentRunningTreeNode Then
                    Me.bsPPSCIDPF.DataSource = DisplaySL2CIDPF
                End If
            Else
                Me.bsPPSCIDPF.Clear()
            End If
        End Set
    End Property
#End Region

#Region "顯示列管訂單資料 屬性:DisplaySL2CIDPF"
    Private _DisplaySL2CIDPF As New List(Of CompanyORMDB.SLS300LB.SL2CIDPF)
    ''' <summary>
    ''' 顯示列管訂單資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DisplaySL2CIDPF() As List(Of CompanyORMDB.SLS300LB.SL2CIDPF)
        Get
            _DisplaySL2CIDPF.Clear()
            If _DisplaySL2CIDPF.Count = 0 AndAlso Not IsNothing(CurrentRunningTreeNode) AndAlso Not IsNothing(CurrentRunningTreeNode.MyPPSSHAPFFlowAdapter) Then
                _DisplaySL2CIDPF = New List(Of CompanyORMDB.SLS300LB.SL2CIDPF)
                Dim AboutPPSSHAPF = (From A In CurrentRunningTreeNode.MyPPSSHAPFFlowAdapter.AboutAS400PPSSHAPFs Select A).LastOrDefault
                If Not IsNothing(AboutPPSSHAPF) Then
                    _DisplaySL2CIDPF.Add(AboutPPSSHAPF.AboutSL2CIDPF)
                End If
            End If
            Return _DisplaySL2CIDPF
        End Get
        Private Set(ByVal value As List(Of CompanyORMDB.SLS300LB.SL2CIDPF))
            _DisplaySL2CIDPF = value
        End Set
    End Property
#End Region

#Region "重整顯示 函式:RefreshDisplay"
    ''' <summary>
    ''' 重整顯示
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshDisplay()
        Me.bsPPSCIDPF.ResetBindings(False)
    End Sub
#End Region



    Sub New(ByVal SetCurrentRunningTreeNode As CoilScanedTreeNode)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.CurrentRunningTreeNode = SetCurrentRunningTreeNode
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
