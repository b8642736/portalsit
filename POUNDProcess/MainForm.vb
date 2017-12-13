Public Class MainForm

#Region "登入控制項 屬性/事件:LoginControl/LoginControlEvent"
    Public WithEvents LoginControlEvent As UserLogin
    Private _LoginControl As New UserLogin
    ''' <summary>
    ''' 登入控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property LoginControl As UserLogin
        Get
            LoginControlEvent = _LoginControl
            Return _LoginControl
        End Get
    End Property
#End Region

#Region "作業控制項 屬性/事件:WorkControl/WorkControlEvent"
    Public WithEvents WorkControlEvent As ManagerPage
    Private _WorkControl As New ManagerPage
    ''' <summary>
    ''' 作業控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WorkControl As ManagerPage
        Get
            WorkControlEvent = _WorkControl
            Return _WorkControl
        End Get
    End Property
#End Region

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Controls.Clear()
        Me.Controls.Add(LoginControl)
        LoginControl.Dock = DockStyle.Fill
    End Sub

    Private Sub LoginControlEvent_SuccessLogin(LoginUser As CompanyORMDB.PPS100LB.PPSCIJPF) Handles LoginControlEvent.SuccessLogin
        Me.Controls.Clear()
        WorkControl.SetSuccessLoginID(LoginUser.CIJ01)
        Me.Controls.Add(WorkControl)
        WorkControl.Dock = DockStyle.Fill
    End Sub

    Private Sub WorkControlEvent_UserLogoutEvent(Sender As ManagerPage) Handles WorkControlEvent.UserLogoutEvent
        Me.LoginControl.UserLogout()
        Call MainForm_Load(Nothing, Nothing)
    End Sub
End Class