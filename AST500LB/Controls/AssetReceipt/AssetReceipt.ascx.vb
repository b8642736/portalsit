Public Class AssetReceipt
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    'Public Shared Function Search() As List(Of AST500LBDataSet.AssetReceiptRow)

    'End Function
    Public Shared Function Search(ByVal QryString As String) As AST500LBDataSet.AssetReceiptDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return New AST500LBDataSet.AssetReceiptDataTable
        End If
        Dim ReturnValue As New AST500LBDataSet.AssetReceiptDataTable
        Dim DBAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchResult As DataTable = DBAdapter.SelectQuery(QryString)
        Dim AddRow As AST500LBDataSet.AssetReceiptRow = Nothing
        For Each EachItem As DataRow In SearchResult.Rows
            AddRow = ReturnValue.NewRow
            With AddRow
                .財產統一編號 = EachItem.Item("NUMBER")
                .類別 = AST101PF.GetCategoryName(.財產統一編號)
                .卡號 = EachItem.Item("CODE")
                .入帳年月 = CType(EachItem.Item("DATE"), String).PadLeft(5)
                .入帳年月 = .入帳年月.Substring(0, 3) & "/" & .入帳年月.Substring(3, 2)
                .使用單位 = EachItem.Item("DEPTSA")
                .使用年限 = EachItem.Item("USLAFF")
                '.計量單位 = EachItem.Item("UNIT")
                .管理單位 = "H62"
                .數量 = EachItem.Item("QUANT") & " " & EachItem.Item("UNIT")
                .中文名稱 = EachItem.Item("NAME")
                .規格 = CType(EachItem.Item("SPEC1"), String).Trim
                .案號 = CType(EachItem.Item("SPEC2"), String).Trim
                .供應商 = ""
                If IsDBNull(EachItem.Item("MTSV02")) Then
                    .供應商 &= "無供應商資料!"
                Else
                    .供應商 &= CType(EachItem.Item("MTSV02"), String).Trim
                    .供應商 &= CType(EachItem.Item("MTSV01"), String).Trim
                    .供應商 &= CType(EachItem.Item("MTSV05"), String).Trim
                    .供應商 &= CType(EachItem.Item("MTSV10"), String).Trim
                    .供應商 &= CType(EachItem.Item("MTSV11"), String).Trim
                    .供應商 &= vbNewLine & "電話:" & CType(EachItem.Item("MTSV07"), String).Trim
                End If
                .供應商 = .供應商.Replace("０", "0")
                .供應商 = .供應商.Replace("１", "1")
                .供應商 = .供應商.Replace("２", "2")
                .供應商 = .供應商.Replace("３", "3")
                .供應商 = .供應商.Replace("４", "4")
                .供應商 = .供應商.Replace("５", "5")
                .供應商 = .供應商.Replace("６", "6")
                .供應商 = .供應商.Replace("７", "7")
                .供應商 = .供應商.Replace("８", "8")
                .供應商 = .供應商.Replace("９", "9")
                .單價 = Format(Val(EachItem.Item("PRICE")), "#,#.00")
                .總金額 = Format(Val(EachItem.Item("TAMOUN")), "#,#.00")
                .填單編號 = EachItem.Item("PNO")
                .ToDeps = "第一聯 : 會計處@第二聯 : 行政處"
            End With
            ReturnValue.Rows.Add(AddRow)
        Next
        Dim AboutDepData As CompanyORMDB.PLT000LB.PQDDPDPF = Nothing
        If Not IsNothing(AddRow) Then
            AboutDepData = CompanyORMDB.PLT000LB.PQDDPDPF.FindPQDDPDPF(AddRow.使用單位)
        End If

        '製作複本
        Dim CopyTable1 As AST500LBDataSet.AssetReceiptDataTable = ReturnValue.Copy
        Dim CopyTable2 As AST500LBDataSet.AssetReceiptDataTable = ReturnValue.Copy
        CopyTable1.Rows(0).Item("ToDeps") = "第三聯 : 企劃處@第四聯 : "
        CopyTable2.Rows(0).Item("ToDeps") = "第五聯 : 資訊處@第六聯 : "
        If Not IsNothing(AboutDepData) Then
            CopyTable1.Rows(0).Item("ToDeps") &= AboutDepData.PQDD2
        Else
            CopyTable1.Rows(0).Item("ToDeps") &= "使用單位"
        End If
        ReturnValue.Merge(CopyTable1)
        ReturnValue.Merge(CopyTable2)

        ''製作複本
        'Dim CopyTable1 As AST500LBDataSet.AssetReceiptDataTable = ReturnValue.Copy
        'CopyTable1.Rows(0).Item("ToDeps") = "第三聯 : 企劃處@第四聯 : "
        'If Not IsNothing(AboutDepData) Then
        '    CopyTable1.Rows(0).Item("ToDeps") &= AboutDepData.PQDD2
        'Else
        '    CopyTable1.Rows(0).Item("ToDeps") &= "使用單位"
        'End If
        'ReturnValue.Merge(CopyTable1)

        Return ReturnValue
    End Function

    Public Shared Function DataPreViewSearch() As List(Of CompanyORMDB.AST500LB.AST001PF)
        Dim QryString As String = "Select * From @#AST500LB.AST001PF.ASTFSA"
        Return CompanyORMDB.AST500LB.AST001PF.CDBSelect(Of CompanyORMDB.AST500LB.AST001PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function
#End Region

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        If String.IsNullOrEmpty(hfPrintKeys.Value) Then
            Exit Sub
        End If
        Dim SQLString As String = "Select A.* , B.* , C.* From  @#AST500LB.AST001PF.ASTFSA A LEFT JOIN  @#AST500LB.AST106PF.ASTFSA B ON A.NUMBER=B.NUMBER LEFT JOIN  @#MTS600LB.MTSV01PF C  ON B.MTSV01=C.MTSV01 Where A.Number='" & hfPrintKeys.Value.Split(",")(0) & "' AND A.DEPT='" & hfPrintKeys.Value.Split(",")(1) & "'"
        Me.hfQry.Value = SQLString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub tbSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Click
        MakQryStringToControl()
        Me.GridView1.DataBind()
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.hfPrintKeys.Value = GridView1.SelectedDataKey(0) & "," & GridView1.SelectedDataKey(1)
        Me.TabContainer1.ActiveTab = TabPanel2
        MakQryStringToControl()
        ''Dim Parameters(0) As Microsoft.Reporting.WebForms.ReportParameter
        ''Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("SignDeps", GetSignDeps)
        ''ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.LocalReport.Refresh()
    End Sub

End Class