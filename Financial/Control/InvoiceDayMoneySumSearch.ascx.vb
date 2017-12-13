Public Class InvoiceDayMoneySumSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As FinancialDataSet.InvoiceDayMoneySumDataTable

        Dim ReturnValue As New FinancialDataSet.InvoiceDayMoneySumDataTable
        Dim QryAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        Dim SearchResult As DataTable = QryAdapter.SelectQuery(SQLString)

        Dim AddItem As Financial.FinancialDataSet.InvoiceDayMoneySumRow
        For Each EachDate As String In (From A In SearchResult Select CType(A.Item("UFI01"), String)).Distinct
            Dim EachDateTemp = EachDate
            For Each EachKind As String In (From A In SearchResult Where CType(A.Item("UFI01"), String) = EachDateTemp Select CType(A.Item("RCV11"), String)).Distinct
                Dim EachKindTemp = EachKind
                Dim OneDayOneKindDatas As List(Of DataRow) = (From A In SearchResult Where CType(A.Item("UFI01"), String) = EachDateTemp And CType(A.Item("RCV11"), String) = EachKindTemp Select A).ToList
                AddItem = ReturnValue.NewRow
                With AddItem
                    .日期 = EachDateTemp
                    Select Case True
                        Case EachKindTemp = "C"
                            .類別 = "現金"
                        Case EachKindTemp = "E"
                            .類別 = "電匯"
                        Case EachKindTemp = "L"
                            .類別 = "LC"
                        Case EachKindTemp = "M"
                            .類別 = "買方LC"
                    End Select
                    .台幣金額 = Format((From A In OneDayOneKindDatas Where CType(A.Item("RCV93"), String) = " " Select CType(A.Item("UFI15"), Double)).Sum, "#,##0")
                    .美金轉台幣金類 = Format((From A In OneDayOneKindDatas Where CType(A.Item("RCV93"), String) = "A" Select CType(A.Item("UFI15"), Double)).Sum, "#,##0")
                    .金額合計 = Format(CType(.台幣金額, Double) + CType(.美金轉台幣金類, Double), "#,##0")
                End With
                ReturnValue.Rows.Add(AddItem)
            Next
        Next

        AddItem = ReturnValue.NewRow
        With AddItem

            .類別 = "合計"
            .台幣金額 = Format((From A In SearchResult Where CType(A.Item("RCV93"), String) = " " Select CType(A.Item("UFI15"), Double)).Sum, "#,##0")
            .美金轉台幣金類 = Format((From A In SearchResult Where CType(A.Item("RCV93"), String) = "A" Select CType(A.Item("UFI15"), Double)).Sum, "#,##0")
            .金額合計 = Format(CType(.台幣金額, Double) + CType(.美金轉台幣金類, Double), "#,##0")
        End With
        ReturnValue.Rows.Add(AddItem)

        Return ReturnValue

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


#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim StartDate As String = (New CompanyORMDB.AS400DateConverter(CType(tbStartDate.Text, Date))).TwSevenCharsTypeData
        Dim EndDate As String = (New CompanyORMDB.AS400DateConverter(CType(tbEndDate.Text, Date))).TwSevenCharsTypeData
        Dim SQLString As String = "Select A.UFI01, A.UFI15 , B.RCV11 ,B.RCV93 From  @#SLS300LB.SL2UFIPF A LEFT OUTER JOIN @#SLS300LB.SL2RCVPF B ON A.UFI14=B.RCV02  Where A.UFI01>'" & StartDate & "' AND A.UFI01<='" & EndDate & "' Order by UFI01 "
        Me.hfSQLString.Value = SQLString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now, "yyyy/MM/dd")
            tbEndDate.Text = tbStartDate.Text
        End If
    End Sub


    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

    Protected Sub tbSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Click
        IsUserAlreadyPutSearch = True
        MakQryStringToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub tbSearch0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch0.Click
        IsUserAlreadyPutSearch = True
        MakQryStringToControl()
        Dim ExcelConvert As New DataConvertExcel(Search(Me.hfSQLString.Value), "每日發票收款查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub
End Class