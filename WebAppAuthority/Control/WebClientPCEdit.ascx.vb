Public Partial Class WebClientPCEdit
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New ClassDBDataContext

#Region "使用者是否已按下查詢 屬性:IsUserAlreadyPutSearch"

    ''' <summary>
    ''' 使用者是否已按下查詢
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsUserAlreadyPutSearch() As Boolean
        Get
            If IsNothing(Me.ViewState("_IsUserAlreadyPutSearch")) Then
                Return False
            End If
            Return Me.ViewState("_IsUserAlreadyPutSearch")
        End Get
        Set(ByVal value As Boolean)
            Me.ViewState("_IsUserAlreadyPutSearch") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
    End Sub

    Private Sub LDSWebClientPCAccount_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSWebClientPCAccount.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = True
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.WebClientPCAccount) = (From A In DBDataContext.WebClientPCAccount Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox1.Text), Result, From A In Result Where A.ClientIP.Contains(TextBox1.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox2.Text), Result, From A In Result Where A.PCName.Contains(TextBox2.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox3.Text), Result, From A In Result Where A.Memo1.Contains(TextBox3.Text.Trim) Select A)
        e.Result = Result

    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.FormView1.ChangeMode(FormViewMode.Insert)
    End Sub

    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim GetPCIPString As String = CType(Me.FormView1.FindControl("ClientIPTextBox"), TextBox).Text
        If IsNothing(GetPCIPString) OrElse GetPCIPString.Trim = "" Then
            CType(Me.FormView1.FindControl("CustomValidator1"), CustomValidator).ErrorMessage = "電腦IP不可空白!"
            args.IsValid = False
            Exit Sub
        End If
        If (From A In DBDataContext.WebClientPCAccount Where A.ClientIP = GetPCIPString Select A).Any Then
            CType(Me.FormView1.FindControl("CustomValidator1"), CustomValidator).ErrorMessage = "此電腦IP已有存在無法再新增!"
            args.IsValid = False
            Exit Sub
        End If

        Dim ClientIP As System.Net.IPAddress = Nothing
        If Not IsNothing(GetPCIPString) AndAlso System.Net.IPAddress.TryParse(GetPCIPString, ClientIP) = False Then
            CType(Me.FormView1.FindControl("CustomValidator1"), CustomValidator).ErrorMessage = "您輸入的IP非合法正確的IP請重新輸入!"
            args.IsValid = False
            Exit Sub
        Else
            CType(Me.FormView1.FindControl("ClientIPTextBox"), TextBox).Text = ClientIP.ToString
        End If
        args.IsValid = True
    End Sub

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.FormView1.DataBind()
    End Sub
End Class