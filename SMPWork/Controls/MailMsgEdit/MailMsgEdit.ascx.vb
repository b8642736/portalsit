Public Class MailMsgEdit
    Inherits System.Web.UI.UserControl

#Region "是否已按下搜尋按鈕 屬性:IsPaushSearchButton"
    ''' <summary>
    ''' 是否已按下搜尋按鈕
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsPaushSearchButton() As Boolean
        Get
            If IsNothing(ViewState("_IsPaushSearchButton")) Then
                ViewState("_IsPaushSearchButton") = False
            End If
            Return ViewState("_IsPaushSearchButton")
        End Get
        Set(ByVal value As Boolean)
            ViewState("_IsPaushSearchButton") = value
        End Set
    End Property


#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub ldsSearchResult_Inserting(sender As Object, e As System.Web.UI.WebControls.LinqDataSourceInsertEventArgs) Handles ldsSearchResult.Inserting
        CType(e.NewObject, CompanyLINQDB.MailMsgEdit).ID = Guid.NewGuid.ToString
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        IsPaushSearchButton = True
        ListView1.DataBind()
    End Sub

    Private Sub ldsSearchResult_Selecting(sender As Object, e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        Dim DBDataContext As New CompanyLINQDB.Qcdb01DataContext
        If IsPaushSearchButton Then
            Dim ReturnValue As IQueryable(Of CompanyLINQDB.MailMsgEdit) = From A In DBDataContext.MailMsgEdit Select A
            If Not String.IsNullOrEmpty(tbReceiveName.Text) Then
                ReturnValue = From A In ReturnValue Where A.ReceivePersonName Like "*" & tbReceiveName.Text & "*" Select A
            End If
            If Not String.IsNullOrEmpty(tbReceiveEmail.Text) Then
                ReturnValue = From A In ReturnValue Where A.MailAddress Like "*" & tbReceiveEmail.Text & "*" Select A
            End If
            If RadioButtonList1.SelectedValue <> "ALL" Then
                ReturnValue = From A In ReturnValue Where A.MailType = RadioButtonList1.SelectedValue Select A
            End If
            e.Result = ReturnValue
        Else
            e.Result = Nothing
        End If
    End Sub
End Class