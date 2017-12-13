Public Partial Class MessageEdit
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

    Dim DBDataContext As New CompanyLINQDB.IMDataContext


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub ListView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.PreRender
        'Dim InsertItemIDControl As TextBox = ListView1.InsertItem.FindControl("ID")
        'If Not IsNothing(InsertItemIDControl) AndAlso String.IsNullOrEmpty(InsertItemIDControl.Text) Then
        '    InsertItemIDControl.Text = Guid.NewGuid.ToString
        'End If
        'If Not IsNothing(ListView1.EditItem) Then
        '    Dim EditItemIDControl As TextBox = ListView1.EditItem.FindControl("ID")
        '    If Not IsNothing(EditItemIDControl) AndAlso String.IsNullOrEmpty(EditItemIDControl.Text) Then
        '        EditItemIDControl.Text = Guid.NewGuid.ToString
        '    End If
        'End If

        'FinalRecieveTimeSpanTextBox
        'NotSendReplyTimeSpan
        CType(ListView1.InsertItem.FindControl("FinalRecieveTimeSpanTextBox"), TextBox).Text = "30"
        CType(ListView1.InsertItem.FindControl("NotSendReplyTimeSpanTextBox"), TextBox).Text = "30"
    End Sub

    Private Sub ldsSearchResult_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceInsertEventArgs) Handles ldsSearchResult.Inserting
        CType(e.NewObject, CompanyLINQDB.Message).ID = Guid.NewGuid.ToString
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.ListView1.DataBind()
    End Sub

    Private Sub ldsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Result = New List(Of Message) ' From A In DBDataContext.Message Where A.ID = "#$%" Select A
            Exit Sub
        End If

        Dim ReturnValue As IQueryable(Of Message) = From A In DBDataContext.Message Select A
        If Not String.IsNullOrEmpty(tbMessageID.Text) Then
            ReturnValue = From A In ReturnValue Where A.ID Like tbMessageID.Text & "*" Select A
        End If
        If Not String.IsNullOrEmpty(tbMessageString.Text) Then
            ReturnValue = From A In ReturnValue Where A.MsgText Like tbMessageString.Text & "*" Select A
        End If
        e.Result = ReturnValue
    End Sub

End Class