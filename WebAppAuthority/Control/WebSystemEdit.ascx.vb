Public Partial Class WebSystemEdit
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



    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FormView1.ChangeMode(FormViewMode.Edit)
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FormView1.DeleteItem()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.FormView1.DataBind()
    End Sub

    Protected Sub btnInsertSystem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FormView1.ChangeMode(FormViewMode.Insert)
    End Sub

    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FormView1.ChangeMode(FormViewMode.Insert)
    End Sub

    Protected Sub btnClearSearchField_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearSearchField.Click
        Me.TextBox1.Text = Nothing
        Me.TextBox2.Text = Nothing
        Me.TextBox3.Text = Nothing
    End Sub

    Protected Sub LDSWebAPPAuthorityDataSource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSWebAPPAuthorityDataSource.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = True
            Exit Sub
        End If
        Dim Result As IQueryable(Of CompanyLINQDB.WebSystem) = From A In DBDataContext.WebSystem Select A
        Result = IIf(String.IsNullOrEmpty(TextBox1.Text), Result, From A In Result Where A.SystemCode.Contains(TextBox1.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox2.Text), Result, From A In Result Where A.SystemName.Contains(TextBox2.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox3.Text), Result, From A In Result Where A.Description.Contains(TextBox3.Text.Trim) Select A)
        e.Result = Result
    End Sub

    Private Sub FormView1_ItemDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewDeleteEventArgs) Handles FormView1.ItemDeleting
        If (From A In DBDataContext.WebUserAuthority Where A.FK_SystemCode = CType(Me.FormView1.SelectedValue, String) Select A).Any Then
            Response.Write("已有使用者對此功能授權無法刪除!")
            e.Cancel = True
        End If

    End Sub
End Class