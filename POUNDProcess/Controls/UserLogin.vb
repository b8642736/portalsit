Public Class UserLogin

    Public Event SuccessLogin(ByVal LoginUser As CompanyORMDB.PPS100LB.PPSCIJPF)

#Region "所有使用者資料 屬性:AllUserDatas"
    Private _AllUserDatas As List(Of CompanyORMDB.PPS100LB.PPSCIJPF) = Nothing
    ''' <summary>
    ''' 所有使用者資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AllUserDatas As List(Of CompanyORMDB.PPS100LB.PPSCIJPF)
        Get
            If IsNothing(_AllUserDatas) Then
                _AllUserDatas = CompanyORMDB.PPS100LB.PPSCIJPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSCIJPF)("Select * from @#PPS100LB.PPSCIJPF", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            End If
            Return _AllUserDatas
        End Get
    End Property
#End Region
#Region "比對帳號碼密 函式:CompareUserLoginAndPwd"
    ''' <summary>
    ''' 比對帳號碼密
    ''' </summary>
    ''' <param name="LoginName"></param>
    ''' <param name="Pwd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CompareUserLoginAndPwd(ByVal LoginName As String, ByVal Pwd As String) As Boolean
        LoginName = LoginName.Replace("'", Nothing).Trim.ToUpper
        Pwd = Pwd.Replace("'", Nothing).Trim.ToUpper
        Me.SuccesUser = Nothing
        Dim FindUser As CompanyORMDB.PPS100LB.PPSCIJPF = (From A In AllUserDatas Where A.CIJ01.Trim.ToUpper = LoginName And A.CIJ02.Trim.ToUpper = Pwd Select A).FirstOrDefault
        If Not IsNothing(FindUser) Then
            Me.SuccesUser = FindUser
            Return True
        End If
        Return False
    End Function
#End Region
#Region "成功登入之使用者 屬性:SuccesUser"
    Private _SuccesUser As CompanyORMDB.PPS100LB.PPSCIJPF = Nothing
    ''' <summary>
    ''' 成功登入之使用者
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property SuccesUser() As CompanyORMDB.PPS100LB.PPSCIJPF
        Get
            Return _SuccesUser
        End Get
        Set(ByVal value As CompanyORMDB.PPS100LB.PPSCIJPF)
            _SuccesUser = value
        End Set
    End Property

#End Region
#Region "重新初始化登入控制項 函式:ReInitThisControl"
    ''' <summary>
    ''' 重新初始化登入控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReInitThisControl()
        tbLoginID.Text = Nothing
        tbLoginpwd.Text = Nothing
        tbNewpwd.Text = Nothing
        tbNewpwd.Enabled = False
        btnSavepwd.Enabled = False
        btnCancelSavepwd.Enabled = False
    End Sub
#End Region
#Region "系統登出 函式:UserLogout"
    ''' <summary>
    ''' 系統登出
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UserLogout()
        Me.SuccesUser = Nothing
        ReInitThisControl()
    End Sub
#End Region

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        lbMessage.Text = Nothing
        If CompareUserLoginAndPwd(tbLoginID.Text, tbLoginpwd.Text) Then
            RaiseEvent SuccessLogin(Me.SuccesUser)
            Exit Sub
        End If
        lbMessage.Text = "登入失敗!"
    End Sub

    Private Sub btnChangepwd_Click(sender As Object, e As EventArgs) Handles btnChangepwd.Click
        If CompareUserLoginAndPwd(tbLoginID.Text, tbLoginpwd.Text) Then
            btnSavepwd.Enabled = True
            btnCancelSavepwd.Enabled = True
            tbNewpwd.Enabled = True
        End If
    End Sub

    Private Sub btnSavepwd_Click(sender As Object, e As EventArgs) Handles btnSavepwd.Click
        Dim SetNewPwd As String = tbNewpwd.Text.Trim.ToUpper
        If IsNothing(SuccesUser) Then
            lbMessage.Text = "找不到成功登入使用者,無法變更使用者密碼!"
        End If
        If SuccesUser.CIJ02.Trim.ToUpper = SetNewPwd Then
            lbMessage.Text = "新密碼與舊密碼相同無法變更!"
        End If
        Try
            SuccesUser.CIJ02 = SetNewPwd
            If SuccesUser.CDBSave = 0 Then
                lbMessage.Text = "系統存檔失敗變更失敗!"
            End If
        Catch ex As Exception
            lbMessage.Text = "系統存檔失敗變更失敗!" & ex.ToString
        Finally
            Call ReInitThisControl()
        End Try
    End Sub

    Private Sub btnCancelSavepwd_Click(sender As Object, e As EventArgs) Handles btnCancelSavepwd.Click
        Call ReInitThisControl()
    End Sub

    Private Sub tbNewpwd_KeyDown(sender As Object, e As KeyEventArgs) Handles tbNewpwd.KeyDown
        If e.KeyData = Keys.Enter Then
            Call btnSavepwd_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tbLoginpwd_KeyDown(sender As Object, e As KeyEventArgs) Handles tbLoginpwd.KeyDown
        If e.KeyData = Keys.Enter Then
            Call btnLogin_Click(Nothing, Nothing)
        End If
    End Sub

End Class
