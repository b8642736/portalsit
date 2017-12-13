Public Partial Class Depreciation
    Inherits System.Web.UI.UserControl

#Region "重整顯示部門篩選名稱 函式:RefreshShowDepartemntNames"
    ''' <summary>
    ''' 重整顯示部門篩選名稱
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshShowDepartemntNames()
        CheckBoxList1.Items.Clear()
        For Each EachItem As String In AST106PF.GetAST106PF_DEPTSA("ASTF" & RadioButtonList1.SelectedValue)
            Me.CheckBoxList1.Items.Add(EachItem)
        Next
    End Sub
    Private Function GetAST106PF_DEPTSA(ByVal MemberName As String) As List(Of String)
        Dim SQLQry As String = Nothing
        Select Case True
            Case MemberName.ToUpper = "DEPTSA"
                SQLQry = "Select DISTINCT DEPTSA FROM @#AST500LB.AST106PF." & MemberName & " Where NUMBER IN (Select Number From @#AST500LB.AST101PF." & MemberName & " Where DEPT='SA') AND SEQ=1 Order by DEPTSA"
            Case Else
                SQLQry = "Select DISTINCT DEPTSA FROM @#AST500LB.AST106PF." & MemberName & " Where NUMBER IN (Select Number From @#AST500LB.AST101PF." & MemberName & " ) AND SEQ=1 Order by DEPTSA"
        End Select
        Return (From A In (New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)).SelectQuery(SQLQry) Select CType(A.Item("DEPTSA"), String)).ToList

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RefreshShowDepartemntNames()
        End If
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        CheckBoxList1.Visible = (RadioButtonList1.SelectedValue = "SA" OrElse RadioButtonList1.SelectedValue = "AA" OrElse RadioButtonList1.SelectedValue = "AB" OrElse RadioButtonList1.SelectedValue = "QA" OrElse RadioButtonList1.SelectedValue = "NA")
        btnSelectAll.Visible = CheckBoxList1.Visible
        btnClearAll.Visible = CheckBoxList1.Visible
        If CheckBoxList1.Visible Then
            RefreshShowDepartemntNames()
        End If
        Me.UpdatePanel2.Update()
    End Sub

    Protected Sub btnSelectAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectAll.Click
        For Each EachItem As ListItem In CheckBoxList1.Items
            EachItem.Selected = True
        Next
    End Sub

    Protected Sub btnClearAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearAll.Click
        For Each EachItem As ListItem In CheckBoxList1.Items
            EachItem.Selected = False
        Next
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Dim SetDepartments As String = Nothing
        If Me.RadioButtonList1.SelectedValue = "SA" OrElse Me.RadioButtonList1.SelectedValue = "AA" OrElse Me.RadioButtonList1.SelectedValue = "AB" OrElse Me.RadioButtonList1.SelectedValue = "QA" OrElse Me.RadioButtonList1.SelectedValue = "NA" Then
            For Each EachItem As ListItem In Me.CheckBoxList1.Items
                If EachItem.Selected Then
                    SetDepartments &= IIf(IsNothing(SetDepartments), EachItem.Text, "|" & EachItem.Text)
                End If
            Next
        End If
        Dim SetACD2s As String = Nothing
        For Each EachItem As ListItem In Me.CheckBoxList2.Items
            Select Case True
                Case EachItem.Selected AndAlso EachItem.Value = "0"
                    SetACD2s &= IIf(IsNothing(SetACD2s), " ", "| ")
                Case EachItem.Selected AndAlso EachItem.Value = "1"
                    SetACD2s &= IIf(IsNothing(SetACD2s), "A", "|A")
                Case EachItem.Selected AndAlso EachItem.Value = "2"
                    SetACD2s &= IIf(IsNothing(SetACD2s), "B", "|B")
            End Select
        Next
        Me.ODSSearchReslut.SelectParameters.Item("SearchACD2String").DefaultValue = SetACD2s
        Me.ODSSearchReslut.SelectParameters.Item("SearchDepartmentString").DefaultValue = SetDepartments
        IsUserAlreadyPutSearch = True
        Me.GridView1.DataBind()
        IsUserAlreadyPutSearch = False
    End Sub

    Protected Sub btnExcelFileDownload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExcelFileDownload.Click
        Dim SetDepartments As String = Nothing
        If Me.RadioButtonList1.SelectedValue = "SA" OrElse Me.RadioButtonList1.SelectedValue = "AA" OrElse Me.RadioButtonList1.SelectedValue = "AB" OrElse Me.RadioButtonList1.SelectedValue = "QA" OrElse Me.RadioButtonList1.SelectedValue = "NA" Then
            For Each EachItem As ListItem In Me.CheckBoxList1.Items
                If EachItem.Selected Then
                    SetDepartments &= IIf(IsNothing(SetDepartments), EachItem.Text, "|" & EachItem.Text)
                End If
            Next
        End If
        Dim SetACD2s As String = Nothing
        For Each EachItem As ListItem In Me.CheckBoxList2.Items
            Select Case True
                Case EachItem.Selected AndAlso EachItem.Value = "0"
                    SetACD2s &= IIf(IsNothing(SetACD2s), " ", "| ")
                Case EachItem.Selected AndAlso EachItem.Value = "1"
                    SetACD2s &= IIf(IsNothing(SetACD2s), "A", "|A")
                Case EachItem.Selected AndAlso EachItem.Value = "2"
                    SetACD2s &= IIf(IsNothing(SetACD2s), "B", "|B")
            End Select
        Next
        Me.ODSSearchReslut.SelectParameters.Item("SearchDepartmentString").DefaultValue = SetDepartments
        Me.ODSSearchReslut.SelectParameters.Item("SearchDepartmentString").DefaultValue = SetDepartments

        Dim SetDisplayColumns As New List(Of ConvertColumnName)
        SetDisplayColumns.Add(New ConvertColumnName("DisplayName", "項次"))
        SetDisplayColumns.Add(New ConvertColumnName("DEPTSA", "單位代碼"))
        SetDisplayColumns.Add(New ConvertColumnName("Number", "資產編號"))
        SetDisplayColumns.Add(New ConvertColumnName("Name", "資產名稱"))
        SetDisplayColumns.Add(New ConvertColumnName("Quant", "數量"))
        SetDisplayColumns.Add(New ConvertColumnName("Amount", "帳面金額"))
        SetDisplayColumns.Add(New ConvertColumnName("StartDate", "入帳年月"))
        SetDisplayColumns.Add(New ConvertColumnName("Uslaff", "使用年限"))
        SetDisplayColumns.Add(New ConvertColumnName("Depr", "本月累計折舊"))
        SetDisplayColumns.Add(New ConvertColumnName("ThisMonthDepr", "本月折舊"))
        SetDisplayColumns.Add(New ConvertColumnName("ACD2_ChineseName", "狀態"))
        Dim ExcelConvert As New DataConvertExcel(DepreciationDisplayItem.SearchToDataTabe(Me.RadioButtonList1.SelectedValue, SetDepartments, SetACD2s), SetDisplayColumns, "固定資產折舊" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)

        '未解決權限問題
        'Dim ExcelConvert As New DataConvertExcel(DepreciationDisplayItem.SearchToDataTabe(Me.RadioButtonList1.SelectedValue, SetDepartments), SetDisplayColumns, "固定資產折舊" & Format(Now, "mmss") & ".xls")
        'ExcelConvert.ConvertToExcelSheet(Me.RadioButtonList1.SelectedValue & "固定資產折舊")
        'ExcelConvert.DownloadEXCELFile(Me.Page)

        'Dim NewDataSet As New DataSet
        'NewDataSet.Tables.Add(DepreciationDisplayItem.SearchToDataTabe(Me.RadioButtonList1.SelectedValue, SetDepartments))
        'PublicClassLibrary.DataConvertExcel.DownloadEXCELFile(NewDataSet, Me.Response)
    End Sub

    Private Sub ODSSearchReslut_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ODSSearchReslut.Selecting
        If IsUserAlreadyPutSearch = False Then
            e.Cancel = True
        End If
    End Sub
End Class