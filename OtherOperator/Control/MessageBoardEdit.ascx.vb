Public Partial Class MessageBoardEdit
    Inherits System.Web.UI.UserControl

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

    Dim DBDataContext As New CompanyLINQDB.OtherOperatorDataContext
    'Dim cc As New CompanyLINQDB.OtherOperatorDataContext
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Private Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting

    End Sub

    Private Sub FormView1_ModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.ModeChanged

    End Sub

    Private Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            CType(Me.FormView1.FindControl("StartDateTimeTextBox"), TextBox).Text = Format(Now, "yyyy/MM/dd").ToString
            CType(Me.FormView1.FindControl("EndDateTimeTextBox"), TextBox).Text = Format(Now.AddDays(7), "yyyy/MM/dd").ToString
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            CType(Me.FormView1.FindControl("StartDateTimeTextBox"), TextBox).Text = Format(CType(CType(Me.FormView1.FindControl("StartDateTimeTextBox"), TextBox).Text, DateTime), "yyyy/MM/dd").ToString
            CType(Me.FormView1.FindControl("EndDateTimeTextBox"), TextBox).Text = Format(CType(CType(Me.FormView1.FindControl("EndDateTimeTextBox"), TextBox).Text, DateTime), "yyyy/MM/dd").ToString
        End If
        If Me.FormView1.CurrentMode = FormViewMode.ReadOnly AndAlso Not IsNothing(Me.FormView1.FindControl("StartDateTimeLabel")) Then
            CType(Me.FormView1.FindControl("StartDateTimeLabel"), Label).Text = Format(CType(CType(Me.FormView1.FindControl("StartDateTimeLabel"), Label).Text, DateTime), "yyyy/MM/dd").ToString
            CType(Me.FormView1.FindControl("EndDateTimeLabel"), Label).Text = Format(CType(CType(Me.FormView1.FindControl("EndDateTimeLabel"), Label).Text, DateTime), "yyyy/MM/dd").ToString
        End If
    End Sub

    Private Sub LDSMessageBoard_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceInsertEventArgs) Handles LDSMessageBoard.Inserting
        Dim InsertObject As CompanyLINQDB.MessageBoard = e.NewObject
        With InsertObject
            .DataSaveDateTeime = Now
            .DataSaveUser = WebAppAuthority.ValidAuthorityModule.CurrentWindowsLoginEmployeeNumber
        End With
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.FormView1.ChangeMode(FormViewMode.Insert)
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        FormView1.DataBind()
    End Sub

    Private Sub LDSMessageBoard_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSMessageBoard.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = True
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.MessageBoard) = (From A In DBDataContext.MessageBoard Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox1.Text), Result, From A In Result Where A.StartDateTime >= CType(TextBox1.Text, DateTime) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox2.Text), Result, From A In Result Where A.EndDateTime <= CType(TextBox2.Text, DateTime).AddDays(1).AddSeconds(-1) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox3.Text), Result, From A In Result Where A.MessageContent.Contains(TextBox3.Text.Trim) Select A)
        e.Result = Result
    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
    End Sub

    Private Sub LDSMessageBoard_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceUpdateEventArgs) Handles LDSMessageBoard.Updating
        Dim InsertObject As CompanyLINQDB.MessageBoard = e.NewObject
        With InsertObject
            .DataSaveDateTeime = Now
            .DataSaveUser = WebAppAuthority.ValidAuthorityModule.CurrentWindowsLoginEmployeeNumber
        End With
    End Sub
End Class