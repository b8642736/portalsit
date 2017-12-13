﻿Public Partial Class SiteGroupEdit
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New CompanyLINQDB.IMDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ldsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        If String.IsNullOrEmpty(Me.TextBox1.Text.Trim) Then
            e.Result = From A In DBDataContext.SiteGroup Where A.GroupName Like "*" & Me.TextBox1.Text.Trim & "*" Select A
        End If

    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        TextBox1.Text = Nothing
    End Sub

    Private Sub ListView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.PreRender
        Dim InsertIDControl As TextBox = ListView1.InsertItem.FindControl("IDTextBox")
        If String.IsNullOrEmpty(InsertIDControl.Text) Then
            InsertIDControl.Text = Guid.NewGuid.ToString
        End If
    End Sub
End Class