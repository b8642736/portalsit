Public Partial Class CSEquipmentCheckSearch
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New CompanyLINQDB.SMPDataContext

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
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now.AddDays(-1), "yyyy/MM/dd")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        IsUserAlreadyPutSearch = False
        tbSampleID = Nothing
        tbStartDate.Text = Format(Now.AddDays(-1), "yyyy/MM/dd")
        tbEndDate.Text = Format(Now, "yyyy/MM/dd")
    End Sub

    Protected Sub ldsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = True
            Exit Sub
        End If
        Dim Result As IQueryable(Of CompanyLINQDB.標準樣本接收資料CS) = From A In DBDataContext.標準樣本接收資料CS Where A.日期時間 >= CType(Me.tbStartDate.Text, Date) And A.日期時間 < CType(Me.tbEndDate.Text, Date).AddDays(1) And (A.ShowSampleID = "" Or A.ShowSampleID Is Nothing) Select A
        If Not String.IsNullOrEmpty(tbSampleID.Text) Then
            Result = From A In Result Where A.SampleID = tbSampleID.Text.Trim Select A
        End If
        e.Result = Result
    End Sub

End Class