Public Class ManagerPage

    Public Event UserLogoutEvent(ByVal Sender As ManagerPage)

#Region "過磅控制項 屬性/事件:POUNDControl/POUNDControlEvent"
    Public WithEvents POUNDControlEvent As POUND1
    Private _POUNDControl As POUND1 = Nothing
    ''' <summary>
    ''' 過磅控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property POUNDControl As POUND1
        Get
            If IsNothing(_POUNDControl) Then
                _POUNDControl = New POUND1
            End If
            POUNDControlEvent = _POUNDControl
            Return _POUNDControl
        End Get
    End Property
#End Region
#Region "查詢列印控制項 屬性/事件:SearchPrintControl"
    Private _SearchPrintControl As New SearchPrint
    ''查詢列印控制項
    ReadOnly Property SearchPrintControl As SearchPrint
        Get
            Return _SearchPrintControl
        End Get
    End Property
#End Region
#Region "設定成功登入之使用者 函式:SetSuccessLoginID"
    ''' <summary>
    ''' 設定成功登入之使用者
    ''' </summary>
    ''' <param name="UserID"></param>
    ''' <remarks></remarks>
    Public Sub SetSuccessLoginID(ByVal UserID As String)
        Me.POUNDControl.LoginID = UserID
        Me.POUNDControl.StartForm_Load(Nothing, Nothing)
    End Sub
#End Region

    Private Sub ManagerPage_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        POUNDControl.SaveNodesValueToDB()
        POUNDControl.Dispose()
    End Sub

    Private Sub ManagerPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TabPage1.Controls.Add(POUNDControl)
        POUNDControl.Dock = DockStyle.Fill
        Me.TabPage2.Controls.Add(SearchPrintControl)
        SearchPrintControl.Dock = DockStyle.Fill
    End Sub

    Private Sub POUNDControlEvent_PoundUserLogoutEvent(Sender As POUND1) Handles POUNDControlEvent.PoundUserLogoutEvent
        RaiseEvent UserLogoutEvent(Me)
    End Sub

    Private Sub TabControl1_Deselecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl1.Deselecting
        If e.TabPage.Text = "過磅處理" Then
            POUNDControl.EndEditAndSaveNodesValueToDB()
            POUNDControl.SaveNodesValueToDB()
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab.Text = "查詢印表" Then
            SearchPrintControl.RefreshEditPullDownBatchMenu()
        End If
    End Sub
End Class
