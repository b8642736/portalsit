Public Partial Class WebSystemFunctionEdit
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


    Private Sub DropDownList1_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        DropDownList2.DataBind()
        Me.UpdatePanel2.Update()
    End Sub

    Protected Sub LDSWebSystemFunction_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSWebSystemFunction.Selecting
        Dim Result As IQueryable(Of CompanyLINQDB.WebSystemFunction) = From A In DBDataContext.WebSystemFunction Select A
        Result = IIf(Me.DropDownList1.SelectedValue = "@ALL", Result, From A In Result Where A.SystemCode = Me.DropDownList1.SelectedValue Select A)
        e.Result = Result
    End Sub

    Private Sub DropDownList1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.DataBound
        Me.DropDownList1.Items.Insert(0, New ListItem("全部", "@ALL"))
        Me.DropDownList1.SelectedIndex = 0
        Me.UpdatePanel2.Update()
    End Sub

    Private Sub DropDownList2_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.DataBound
        Me.DropDownList2.Items.Insert(0, New ListItem("全部", "@ALL"))
        Me.DropDownList2.SelectedIndex = 0
    End Sub

    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If Not IsNothing(Me.FormView1.FindControl("DropDownList3")) AndAlso Not IsNothing(Me.FormView1.FindControl("FunctionCodeTextBox")) Then
            args.IsValid = ((From A In DBDataContext.WebSystemFunction Where A.SystemCode = CType(Me.FormView1.FindControl("DropDownList3"), DropDownList).SelectedValue And A.FunctionCode = CType(Me.FormView1.FindControl("FunctionCodeTextBox"), TextBox).Text Select A).Count = 0)
        End If
    End Sub

    Protected Sub btnClearSearchField_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearSearchField.Click
        DropDownList1.SelectedIndex = 0
        DropDownList2.SelectedIndex = 0
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
    End Sub

    Protected Sub btnInsertRecord_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FormView1.ChangeMode(FormViewMode.Insert)
    End Sub

    Protected Sub LDSSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSSearchResult.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = True
            Exit Sub
        End If
        Dim Result As IQueryable(Of CompanyLINQDB.WebSystemFunction) = (From A In DBDataContext.WebSystemFunction Select A)
        Result = IIf(DropDownList1.SelectedValue = "@ALL", Result, From A In Result Where A.SystemCode = DropDownList1.SelectedValue Select A)
        Result = IIf(DropDownList2.SelectedValue = "@ALL", Result, From A In Result Where A.FunctionCode = DropDownList2.SelectedValue Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox1.Text), Result, From A In Result Where A.FunctionName.Contains(TextBox1.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox2.Text), Result, From A In Result Where A.Description.Contains(TextBox2.Text.Trim) Select A)
        e.Result = Result
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        FormView1.DataBind()
    End Sub

    Private Sub FormView1_ItemDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewDeleteEventArgs) Handles FormView1.ItemDeleting
        If (From A In DBDataContext.WebUserAuthority Where A.FK_SystemFunctionCode = CType(Me.FormView1.SelectedValue, String) Select A).Any Then
            Response.Write("已有使用者對此功能授權無法刪除!")
            e.Cancel = True
        End If
    End Sub

    'Protected Sub CustomValidator2_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
    '    If (From A In DBDataContext.WebUserAuthority Where A.FK_SystemFunctionCode = CType(Me.FormView1.SelectedValue, String) Select A).Any Then
    '        CType(Me.FormView1.FindControl("CustomValidator2"), CustomValidator).ErrorMessage = "已有使用者對此功能授權無法刪除!"
    '        args.IsValid = False
    '        Exit Sub
    '    End If
    '    args.IsValid = True
    'End Sub
End Class