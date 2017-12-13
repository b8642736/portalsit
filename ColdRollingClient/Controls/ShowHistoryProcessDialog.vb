Imports System.Windows.Forms

Public Class ShowHistoryProcessDialog
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
                Me.bsCurrentRunProcessData.DataSource = _CurrentRunningTreeNode.MyPPSSHAPFFlowAdapter.FinalALLPPSSHAPFs
            End If
        End Set
    End Property

#End Region

    Shadows Sub Show(ByVal ParentForm As Form, ByVal SetCurrentRunningTreeNode As CoilScanedTreeNode)
        ParentForm.Enabled = False
        MyBase.Show()
        Me.UPLevelForm = ParentForm
        Me.CurrentRunningTreeNode = SetCurrentRunningTreeNode
    End Sub

    Private Sub OK_Button_Click_1(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        UPLevelForm.Enabled = True
        UPLevelForm.Show()
        Me.Close()
    End Sub
End Class
