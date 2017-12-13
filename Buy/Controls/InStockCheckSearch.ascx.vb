Public Class InStockCheckSearch
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As BuyDataSet.InStockCheckSearchDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New BuyDataSet.InStockCheckSearchDataTable
        End If
        Dim ReturnValue As New BuyDataSet.InStockCheckSearchDataTable
        Dim SearchResult As DataTable = (New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)).SelectQuery

        For Each EachItem As DataRow In SearchResult.rows
            Dim AddRow As BuyDataSet.InStockCheckSearchRow = ReturnValue.NewRow
            With AddRow
                .合約案號 = EachItem.Item("MST014")
                .驗收日期 = EachItem.Item("MST017")
                .入帳日期 = EachItem.Item("MST018")
                .付款期限 = EachItem.Item("MST019")
                .項次 = EachItem.Item("MST015")
                .料號 = EachItem.Item("MST002")
                .品名 = EachItem.Item("MSM002")
                .特性 = EachItem.Item("MST027")

                Select Case True
                    Case .特性 = " "
                        .特性 = "物料"
                    Case .特性 = "1"
                        .特性 = "原枓"
                    Case .特性 = "2"
                        .特性 = "配件"
                    Case .特性 = "3"
                        .特性 = "然料"
                End Select
                .單位 = EachItem.Item("MST004")
                .數量 = EachItem.Item("MST003")
                .單價 = EachItem.Item("MST006")
                .總價 = EachItem.Item("MST007")
                Select Case True
                    Case {"1219", "1226", "1227", "1228"}.Contains(CType(EachItem.Item("MST032"), String).Trim)
                        .罰款或折讓金額 = EachItem.Item("MST008")
                    Case {"2144", "214A"}.Contains(CType(EachItem.Item("MST032"), String).Trim)
                        .罰款或折讓金額 = EachItem.Item("MST056")
                    Case Else
                        .罰款或折讓金額 = EachItem.Item("MST056")
                End Select
            End With
            ReturnValue.Rows.Add(AddRow)
        Next

        Return ReturnValue
    End Function
#End Region

#Region "產生查詢至控制項 方法:MakerQryToControl"
    ''' <summary>
    ''' 產生查詢至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakerQryToControl()
        Dim ReturnValue As String = "Select A.*,B.MSM002 FROM @#MTS100LB.MTST01PF A LEFT JOIN @#MTS100LB.MTSM01PF B ON A.MST002=B.MSM001 WHERE  A.MST001='C '"

        ReturnValue &= " AND A.MST017>='" & (New CompanyORMDB.AS400DateConverter(CType(Me.tbStartDate.Text, Date))).TwSevenCharsTypeData & "'"
        ReturnValue &= " AND A.MST017<='" & (New CompanyORMDB.AS400DateConverter(CType(Me.tbEndDate.Text, Date))).TwSevenCharsTypeData & "'"

        If Not String.IsNullOrEmpty(tbMaterialID.Text) AndAlso tbMaterialID.Text.Trim.Length > 0 Then
            ReturnValue &= " AND A.MST002 IN ('" & Me.tbMaterialID.Text.Replace(",", "','") & "')"
        End If

        If CheckBoxList1.SelectedValue.Split(",").Count < CheckBoxList1.Items.Count Then
            ReturnValue &= " AND  A.MST027 IN ('" & Me.CheckBoxList1.SelectedValue.Replace(",", "','") & "')"
        End If

        Me.hfQry.Value = ReturnValue
    End Sub
#End Region



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(New Date(Now.Year, Now.Month, 1), "yyyy/MM/dd")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakerQryToControl()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchToExcel.Click
        MakerQryToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing
        Dim SearchResult As BuyDataSet.InStockCheckSearchDataTable = Search(Me.hfQry.Value)
        ExcelConvert = New PublicClassLibrary.DataConvertExcel(SearchResult, "廠商進貨驗收資料查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

    Protected Sub CheckBoxList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxList1.SelectedIndexChanged
        If String.IsNullOrEmpty(CheckBoxList1.SelectedValue) Then
            For Each EachItem As ListItem In CheckBoxList1.Items
                CType(EachItem, ListItem).Selected = True
            Next
        End If
    End Sub
End Class