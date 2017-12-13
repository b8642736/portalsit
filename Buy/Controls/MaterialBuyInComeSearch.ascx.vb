Public Class MaterialBuyInComeSearch
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As BuyDataSet.MaterialBuyInComeSearchDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New BuyDataSet.MaterialBuyInComeSearchDataTable
        End If
        Dim ReturnValue As New BuyDataSet.MaterialBuyInComeSearchDataTable
        Dim SearchResult As DataTable = (New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)).SelectQuery

        For Each EachItem As DataRow In SearchResult.Rows
            Dim AddRow As BuyDataSet.MaterialBuyInComeSearchRow = ReturnValue.NewRow
            With AddRow
                .合約案號 = EachItem.Item("MSU701")
                .項次 = EachItem.Item("MSU702")
                .物料編號 = EachItem.Item("MSU704")
                .品名 = EachItem.Item("MSU705")
                If Not IsDBNull(EachItem.Item("MTSV04")) Then
                    .供應商 = EachItem.Item("MTSV04")
                End If
                .合約日期 = EachItem.Item("MSU710")
                .履約期限 = EachItem.Item("MSU711")
                .單位 = EachItem.Item("MSU706")
                .數量 = EachItem.Item("MSU714")
                .幣別 = EachItem.Item("MSU713")
                .單價 = EachItem.Item("MSU715")
                .總價 = EachItem.Item("MSU716")
                .已驗收數量 = EachItem.Item("MSU718")

                '.合約案號 = EachItem.Item("MST014")
                '.驗收日期 = EachItem.Item("MST017")
                '.入帳日期 = EachItem.Item("MST018")
                '.付款期限 = EachItem.Item("MST019")
                '.項次 = EachItem.Item("MST015")
                '.料號 = EachItem.Item("MST002")
                '.品名 = EachItem.Item("MSM002")
                '.特性 = EachItem.Item("MST027")

                '.單位 = EachItem.Item("MST004")
                '.數量 = EachItem.Item("MST003")
                '.單價 = EachItem.Item("MST006")
                '.總價 = EachItem.Item("MST007")
                'Select Case True
                '    Case {"1219", "1226", "1227", "1228"}.Contains(CType(EachItem.Item("MST032"), String).Trim)
                '        .罰款或折讓金額 = EachItem.Item("MST008")
                '    Case {"2144", "214A"}.Contains(CType(EachItem.Item("MST032"), String).Trim)
                '        .罰款或折讓金額 = EachItem.Item("MST056")
                '    Case Else
                '        .罰款或折讓金額 = EachItem.Item("MST056")
                'End Select
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
        Dim ReturnValue As String = "Select A.*,C.MTSV04 FROM @#MTS600LB.MTS700PF A LEFT JOIN @#MTS100LB.MTSM01PF B ON A.MSU704=B.MSM001 LEFT JOIN @#MTS600LB.MTSV01PF C ON A.MSU708=C.MTSV01 WHERE  B.MSM027='1' "

        ReturnValue &= " AND A.MSU710>=" & (New CompanyORMDB.AS400DateConverter(CType(Me.tbStartDate.Text, Date))).TwSevenCharsTypeData
        ReturnValue &= " AND A.MSU710<=" & (New CompanyORMDB.AS400DateConverter(CType(Me.tbEndDate.Text, Date))).TwSevenCharsTypeData

        If Not String.IsNullOrEmpty(tbMaterialID.Text) AndAlso tbMaterialID.Text.Trim.Length > 0 Then
            ReturnValue &= " AND A.MSU704 IN ('" & Me.tbMaterialID.Text.Replace(",", "','") & "')"
        End If
        If Not String.IsNullOrEmpty(tbSupplyName.Text) AndAlso tbSupplyName.Text.Trim.Length > 0 Then
            ReturnValue &= " AND C.MTSV04 IN ('" & Me.tbSupplyName.Text.Replace(",", "','") & "')"
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
        Dim SearchResult As BuyDataSet.MaterialBuyInComeSearchDataTable = Search(Me.hfQry.Value)
        ExcelConvert = New PublicClassLibrary.DataConvertExcel(SearchResult, "原料採購進貨資料查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

End Class