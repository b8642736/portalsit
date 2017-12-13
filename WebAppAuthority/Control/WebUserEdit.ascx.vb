Public Partial Class WebUserEdit
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


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.FormView1.DataBind()
    End Sub

    Private Sub LDSWebLoginAccount_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSWebLoginAccount.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = True
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.WebLoginAccount) = (From A In DBDataContext.WebLoginAccount Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox1.Text), Result, From A In Result Where A.WindowLoginName.Contains(TextBox1.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox2.Text), Result, From A In Result Where A.DisplayName.Contains(TextBox2.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox3.Text), Result, From A In Result Where A.Memo1.Contains(TextBox3.Text.Trim) Select A)
        e.Result = Result

    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
    End Sub

    Protected Sub CustomValidator1_ServerValidate1(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim GetLoginString As String = CType(Me.FormView1.FindControl("WindowLoginNameTextBox"), TextBox).Text
        If IsNothing(GetLoginString) OrElse GetLoginString.Trim = "" Then
            CType(Me.FormView1.FindControl("CustomValidator1"), CustomValidator).ErrorMessage = "登入帳號不可空白!"
            args.IsValid = False
            Exit Sub
        End If
        If (From A In DBDataContext.WebLoginAccount Where A.WindowLoginName = GetLoginString Select A).Any Then
            CType(Me.FormView1.FindControl("CustomValidator1"), CustomValidator).ErrorMessage = "此帳號已有人使用無法再新增!"
            args.IsValid = False
            Exit Sub
        End If
        args.IsValid = True

    End Sub

    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.FormView1.ChangeMode(FormViewMode.Insert)
    End Sub
End Class