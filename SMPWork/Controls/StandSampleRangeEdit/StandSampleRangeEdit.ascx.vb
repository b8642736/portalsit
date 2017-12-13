Public Class StandSampleRangeEdit
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New CompanyLINQDB.SMPDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub ldsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        If tbSampleNumber.Text.Trim.Length > 0 Then
            e.Result = From A In DBDataContext.標準樣本接收資料上下限 Where A.SampleNumber Like "*" & tbSampleNumber.Text.Trim & "*" Select A
        End If
    End Sub

    Private Sub ListView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewInsertEventArgs) Handles ListView1.ItemInserting
        e.Values("SampleNumber") = CType(ListView1.InsertItem.FindControl("DropDownList2"), DropDownList).SelectedValue.Trim
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        ListView1.DataBind()
    End Sub

    Protected Sub LDSSMPStandSample_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSSMPStandSample.Selecting
        e.Result = From A In DBDataContext.SMPStandardSample Where Not (From B In DBDataContext.標準樣本接收資料上下限 Select B.SampleNumber.Trim).Contains(A.SampleNumber.Trim) Select A
    End Sub
End Class