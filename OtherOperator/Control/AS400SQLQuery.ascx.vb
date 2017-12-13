Public Partial Class AS400SQLQuery
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New CompanyLINQDB.OtherOperatorDataContext


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

#Region "是否可刪除查詢記錄 屬性:IsCanDelteSearchRecords"
    ''' <summary>
    ''' 是否可刪除查詢記錄
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsCanDelteSearchRecords() As Boolean
        Get

            Return Me.ViewState("_IsCanDelteSearchRecords")
        End Get
        Set(ByVal value As Boolean)
            Me.ViewState("_IsCanDelteSearchRecords") = value
        End Set
    End Property
#End Region

#Region "最後查詢記錄LINQ指令 屬性:LastQueryRecordLINQCommand"
    ''' <summary>
    ''' 最後查詢記錄LINQ指令
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property LastQueryRecordLINQCommand() As IQueryable(Of CompanyLINQDB.AS400QueryRecord)
        Get
            Return Me.Session("_LastQueryRecordLINQCommand")
        End Get
        Set(ByVal value As IQueryable(Of CompanyLINQDB.AS400QueryRecord))
            Session("_LastQueryRecordLINQCommand") = value
            btnDeleteHistory.Visible = Not IsNothing(value) And IsCanDelteSearchRecords
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TextBox2.Text = Format(Now.AddDays(-1), "yyyy/MM/dd")
            TextBox3.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnRunSQL_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRunSQL.Click
        Dim QueryObject As New PublicClassLibrary.AS400SQLQueryRecord
        QueryObject.SourceQueryString = Me.TextBox1.Text.Trim
        HFSQLString.Value = Me.TextBox1.Text
        Try


            Me.MultiView1.SetActiveView(Me.DynamicQueryView)
            Me.MultiView1.Visible = True
            Select Case QueryObject.QueryType
                Case CompanyORMDB.AS400SQLQueryAdapter.QueryTypeEnum.SelectType
                    Me.MultiView1.SetActiveView(Me.SearchQueryView)
                    Me.GridView1.DataSource = QueryObject.SelectQueryAndRecord(Me.Page)
                    Me.GridView1.DataBind()
                    Me.MultiView1.Visible = True
                    btnConverToExcel.Visible = True
                    labSearchResult0.Text = "有 " & GridView1.Rows.Count & "筆資成功被處理!"
                Case CompanyORMDB.AS400SQLQueryAdapter.QueryTypeEnum.UnKnowType
                    Me.MultiView1.Visible = False
                Case Else
                    Select Case QueryObject.QueryType
                        Case CompanyORMDB.AS400SQLQueryAdapter.QueryTypeEnum.InsertType
                            Me.RadioButtonList1.SelectedIndex = 0
                            labSearchResult.Text = "有 " & QueryObject.ExecuteNonQueryAndRecord(Me.Page, QueryObject.SourceQueryString) & "筆資成功被新增!"
                        Case CompanyORMDB.AS400SQLQueryAdapter.QueryTypeEnum.UpdateType
                            Me.RadioButtonList1.SelectedIndex = 1
                            labSearchResult.Text = "有 " & QueryObject.ExecuteNonQueryAndRecord(Me.Page, QueryObject.SourceQueryString) & "筆資成功被更新!"
                        Case CompanyORMDB.AS400SQLQueryAdapter.QueryTypeEnum.DeleteType
                            Me.RadioButtonList1.SelectedIndex = 2
                            labSearchResult.Text = "有 " & QueryObject.ExecuteNonQueryAndRecord(Me.Page, QueryObject.SourceQueryString) & "筆資成功被刪除!"
                    End Select
            End Select
        Catch ex As Exception
            btnConverToExcel.Visible = False
            labSearchResult0.Text = "查詢語法有誤!" & ex.ToString
            labSearchResult.Text = labSearchResult0.Text
        End Try

    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        TextBox1.Text = Nothing
        Me.MultiView1.Visible = False
    End Sub

    Protected Sub MultiView1_ActiveViewChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MultiView1.ActiveViewChanged

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.GridView2.DataBind()
    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        Me.TextBox2.Text = Nothing
        Me.TextBox3.Text = Nothing
        Me.TextBox4.Text = Nothing
        Me.TextBox5.Text = Nothing
        For Each EachItem As ListItem In CheckBoxList1.Items
            EachItem.Selected = True
        Next
        TextBox2.Text = Format(Now.AddDays(-1), "yyyy/MM/dd")
        TextBox3.Text = Format(Now, "yyyy/MM/dd")
    End Sub

    Protected Sub LDSSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSSearchResult.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = True
            Exit Sub
        End If

        Dim Result As IQueryable(Of CompanyLINQDB.AS400QueryRecord) = (From A In DBDataContext.AS400QueryRecord Where A.IsDeleted = False Select A)
        Dim DataSearchTypes As List(Of Integer) = (From A As ListItem In CheckBoxList1.Items Where A.Selected = True Select CType(A.Value, Integer)).ToList
        DataSearchTypes.Add(-99)
        Result = IIf(DataSearchTypes.Count = 0, Result, From A In Result Where DataSearchTypes.Contains(A.QueryType) Select A)
        Result = From A In Result Where A.RunTime > CType(TextBox2.Text, DateTime) Select A
        Result = From A In Result Where A.RunTime < CType(TextBox3.Text, DateTime).AddDays(1).AddSeconds(-1) Select A
        Result = IIf(String.IsNullOrEmpty(TextBox4.Text), Result, From A In Result Where A.RunPCIP.Contains(TextBox4.Text.Trim) Select A)
        Result = IIf(String.IsNullOrEmpty(TextBox5.Text), Result, From A In Result Where A.RunUser.Contains(TextBox5.Text.Trim) Select A)
        e.Result = From A In Result Select A Order By A.RunTime Descending
        LastQueryRecordLINQCommand = e.Result
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView2.SelectedIndexChanged
        If Not IsNothing(Me.GridView2.SelectedRow) Then
            Me.TextBox1.Text = CType(Me.GridView2.SelectedDataKey.Value, String)
            Me.MultiView1.Visible = False
            Me.TabContainer1.ActiveTab = Me.TabPanel1
        End If
    End Sub

    Protected Sub btnConverToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConverToExcel.Click
        Dim QueryObject As New PublicClassLibrary.AS400SQLQueryRecord
        Dim ConvertObjct As New PublicClassLibrary.DataConvertExcel(QueryObject.SelectQuery(HFSQLString.Value), "TempTable.xls")
        ConvertObjct.DownloadEXCELFile(Me.Page.Response)
    End Sub

    Protected Sub btnDeleteHistory_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteHistory.Click
        If IsNothing(LastQueryRecordLINQCommand) Then
            Exit Sub
        End If
        For Each EachItem In LastQueryRecordLINQCommand
            Me.DBDataContext.AS400QueryRecord.Attach(EachItem)
            EachItem.IsDeleted = True
        Next
        Me.DBDataContext.SubmitChanges()
        Me.GridView2.DataBind()
        LastQueryRecordLINQCommand = Nothing
    End Sub

End Class