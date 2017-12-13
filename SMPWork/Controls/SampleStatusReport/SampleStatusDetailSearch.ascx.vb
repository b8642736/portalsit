Public Partial Class SampleStatusDetailSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SearchStation"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SearchStation As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal BugFieltItems As String, ByVal StoveNumbers As String) As List(Of CompanyLINQDB.取樣品質)
        Dim DBDataContext As New CompanyLINQDB.SMPDataContext
        Dim SetStartDate As Integer = (Format(StartDate, "yyyy") - 1911) * 10000 + Format(StartDate, "MMdd")
        Dim SetEndDate As Integer = (Format(EndDate, "yyyy") - 1911) * 10000 + Format(EndDate, "MMdd")
        Dim Query As IQueryable(Of CompanyLINQDB.取樣品質) = From A In DBDataContext.取樣品質 Where A.IsDeleted = False And A.日期 >= SetStartDate And A.日期 <= SetEndDate Select A Order By A.日期 Descending, A.時間 Descending
        If SearchStation <> "ALL" Then
            Query = From A In Query Where A.站別 = SearchStation Select A
        End If
        If BugFieltItems <> "" Then
            Query = From A In Query Where BugFieltItems.Split(",").Contains(A.取樣品質代碼) Select A
        End If
        If Not String.IsNullOrEmpty(StoveNumbers) AndAlso StoveNumbers.Trim.Length > 0 Then
            Query = From A In Query Where StoveNumbers.Split(",").Contains(A.爐號) Select A
        End If
        Return Query.ToList
    End Function
#End Region

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
#Region "設定參數值至查詢用空制項 函式:SetValueToSearchControl"
    ''' <summary>
    ''' 設定參數值至查詢用空制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetValueToSearchControl()
        hfSelectItems.Value = ""
        For Each EachItem As ListItem In Me.CheckBoxList1.Items
            hfSelectItems.Value &= IIf(EachItem.Selected, IIf(hfSelectItems.Value = "", EachItem.Value, "," & EachItem.Value), Nothing)
        Next

    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Now.Date.AddDays(-1)
            tbEndDate.Text = Now.Date
        End If

    End Sub

    Private Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not Me.IsUserAlreadyPutSearch
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        SetValueToSearchControl()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnSearchClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchClear.Click
        RadioButtonList2.SelectedIndex = 0
        For Each EachItem As ListItem In CheckBoxList1.Items
            EachItem.Selected = False
        Next
    End Sub

    Protected Sub btAllSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btAllSelect.Click, btAllNotSelect.Click
        Dim IsSelect As Boolean = sender Is btAllSelect
        For Each EachItem As ListItem In CheckBoxList1.Items
            EachItem.Selected = IsSelect
        Next
    End Sub
End Class