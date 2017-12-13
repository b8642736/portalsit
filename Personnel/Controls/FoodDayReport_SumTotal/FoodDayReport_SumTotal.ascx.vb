Imports Microsoft.Reporting.WebForms

Public Class FoodDayReport_SumTotal
    Inherits System.Web.UI.UserControl

    Private WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
    Private WP_ClsReportViwer As New ClsReportViwer
    Private WP_AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            txtQueryDate.Text = Now.ToString("yyyy/MM/dd")

            With ddReportKind.Items
                .Clear()
                For II As Integer = ClsReportViwer.ReportExport_Enum.畫面 _
                                              To ClsReportViwer.ReportExport_Enum.PDF
                    .Add(New ListItem(WP_ClsReportViwer.ReportExport_Name(II), II))
                Next
            End With
            ddReportKind.SelectedIndex = 0

            With ddFoodKind.Items
                .Clear()
                .Add("A：早餐")
                .Add("B：午餐")
                .Add("C：晚餐")
            End With
            ddFoodKind.SelectedIndex = 1

            ReportViewer1.ShowExportControls = False

        End If

    End Sub






    Protected Sub btnExec_Click(sender As Object, e As EventArgs) Handles btnExec.Click
        If IsDate(txtQueryDate.Text) = False Then
            MsgBox(Me, "輸入的日期錯誤：" & txtQueryDate.Text)
            Exit Sub
        End If


        SetQryStringToControl()

        Dim queryTable As Personnel.Report_伙食小計表DataTable = Search(Me.hfQryString.Value)
        If queryTable.Rows.Count = 0 Then
            Me.CustomValidator1.Text = "輸入的條件查無資料，請從新查詢。"
            Me.CustomValidator1.IsValid = False
            Exit Sub
        End If

        Dim W_QueryInfo As String
        W_QueryInfo = CDate(Me.txtQueryDate.Text).ToString("yyyy_MM_dd")
        W_QueryInfo &= "_" & New PublicClassLibrary.ClsSystemNote().Fs_GetStrAfter(ddFoodKind.SelectedValue, "：")

        Dim dataTableOfFoodType As DataTable = WP_AS400Adapter.SelectQuery("SELECT v1.* , fdsup1 || '：' || fdsup2 AS " & WP_ClsSystemNote.Display_Lable & "  FROM @#fod100lb.FODSUPPF v1  WHERE fdsup2<>''")
        prepareReport(W_QueryInfo, queryTable, dataTableOfFoodType)
    End Sub




    Public Sub prepareReport(ByVal fromQueryInfo As String, _
                                              ByVal fromQueryTable As Personnel.Report_伙食小計表DataTable, _
                                              ByVal fromDataTableOfFoodType As DataTable)

        '報表共用
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim W_ReportExport As ClsReportViwer.ReportExport_Enum = ddReportKind.SelectedValue
        Dim W_ReportDate As Date = Now
        Dim W_ReportName As String = "伙食小計表"
        Dim W_FileName As String = W_ReportName & "_" & fromQueryInfo & "_" & W_ReportDate.ToString("yyyyMMdd_HHmmss")


        'DataSet
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim rds As New ReportDataSource()
        rds.Name = "DataSet1"
        rds.Value = fromQueryTable
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)



        '變數
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim W_ParamFoodKind As String = ParamFoodKind()
        Dim W_ParamReportTitle As String

        W_ParamReportTitle = "唐榮公司"
        W_ParamReportTitle &= Space(2) & Integer.Parse(Date.Parse(txtQueryDate.Text).ToString("yyyy")) - 1911
        W_ParamReportTitle &= " / " & Date.Parse(txtQueryDate.Text).ToString("MM / dd")
        W_ParamReportTitle &= Space(2) & W_ParamFoodKind
        W_ParamReportTitle &= Space(2) & W_ReportName

        Dim W_ParamDataTime As String
        W_ParamDataTime = Integer.Parse(W_ReportDate.ToString("yyyy")) - 1911
        W_ParamDataTime &= "/" & W_ReportDate.ToString("MM/dd")
        W_ParamDataTime &= vbNewLine & W_ReportDate.ToString("HH:mm:ss")


        ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WebForms.ReportParameter("ParamReportTitle", W_ParamReportTitle))
        ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WebForms.ReportParameter("ParamDataTime", W_ParamDataTime))
        ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WebForms.ReportParameter("ParamFoodKind", W_ParamFoodKind))

        Dim W_ShowName1 As String, W_ShowName2 As String, W_ShowName3 As String
        For II As Integer = 65 To 70
            W_ShowName1 = Chr(II)
            W_ShowName2 = (From A In fromDataTableOfFoodType Where A.Item("fdsup1").ToString.Trim.Equals(W_ShowName1) Select A.Item("fdsup2").ToString.Trim).FirstOrDefault
            W_ShowName3 = W_ShowName1 & Space(1) & W_ShowName2
            ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WebForms.ReportParameter("ParamName" & W_ShowName1, W_ShowName3))
        Next

                '執行
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        WP_ClsReportViwer.execReport(W_ReportExport, ReportViewer1, Response, W_FileName)

    End Sub

    Public Function ParamFoodKind() As String
        Return WP_ClsSystemNote.Fs_GetStrAfter(ddFoodKind.SelectedValue, "：")
    End Function

#Region "查詢 方法:Search"
    Public Function Search(ByVal fromQryString As String) As Personnel.Report_伙食小計表DataTable
        Dim II As Integer
        Dim addRow As Personnel.Report_伙食小計表Row
        Dim returnTable As New Personnel.Report_伙食小計表DataTable

        Dim as400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim queryTableALL As DataTable = as400Adapter.SelectQuery(fromQryString)

        Dim queryFodplcpf As List(Of FOD100LB.FODPLCPF) = FOD100LB.FODPLCPF.CDBSelect(Of FOD100LB.FODPLCPF)("SELECT * FROM @#FOD100LB.FODPLCPF", as400Adapter)

        Dim queryPlace As List(Of String) = (From A In queryTableALL
                Group A By FD004 = A.Field(Of String)("FD004") Into MonthGroup = Group
                Order By FD004
                Select FD004).ToList

        For Each eachPlaceCode In queryPlace
            addRow = returnTable.NewReport_伙食小計表Row
            '--------------------------------------------------------------------------------------------------------------------------
            II += 1
            addRow.序號 = II
            addRow.置放位子中文 = (From A In queryFodplcpf Where A.FDPLC1.Equals(eachPlaceCode) Select A.FDPLC2).FirstOrDefault
            addRow.置放位子代號 = "( " & eachPlaceCode & " )"
            addRow.時段 = WP_ClsSystemNote.Fs_GetStrAfter(ddFoodKind.SelectedValue, "：").Substring(0, 1)
            addRow.餐別A = (From A In queryTableALL Where A.Item("fd004").ToString.Equals(eachPlaceCode) AndAlso A.Item("Fd_DayFoodKind").ToString.Equals("A") Select A.Item("Cnt")).FirstOrDefault
            addRow.餐別B = (From A In queryTableALL Where A.Item("fd004").ToString.Equals(eachPlaceCode) AndAlso A.Item("Fd_DayFoodKind").ToString.Equals("B") Select A.Item("Cnt")).FirstOrDefault
            addRow.餐別C = (From A In queryTableALL Where A.Item("fd004").ToString.Equals(eachPlaceCode) AndAlso A.Item("Fd_DayFoodKind").ToString.Equals("C") Select A.Item("Cnt")).FirstOrDefault
            addRow.餐別D = (From A In queryTableALL Where A.Item("fd004").ToString.Equals(eachPlaceCode) AndAlso A.Item("Fd_DayFoodKind").ToString.Equals("D") Select A.Item("Cnt")).FirstOrDefault
            addRow.餐別E = (From A In queryTableALL Where A.Item("fd004").ToString.Equals(eachPlaceCode) AndAlso A.Item("Fd_DayFoodKind").ToString.Equals("E") Select A.Item("Cnt")).FirstOrDefault
            addRow.餐別F = (From A In queryTableALL Where A.Item("fd004").ToString.Equals(eachPlaceCode) AndAlso A.Item("Fd_DayFoodKind").ToString.Equals("F") Select A.Item("Cnt")).FirstOrDefault

            '--------------------------------------------------------------------------------------------------------------------------
            returnTable.Rows.Add(addRow)

        Next

        '合計
        addRow = returnTable.NewReport_伙食小計表Row
        '--------------------------------------------------------------------------------------------------------------------------
        addRow.時段 = "公司合計" & vbNewLine & ParamFoodKind()
        addRow.餐別A = (From A In returnTable Select Long.Parse(A.Item("餐別A"))).Sum
        addRow.餐別B = (From A In returnTable Select Long.Parse(A.Item("餐別B"))).Sum
        addRow.餐別C = (From A In returnTable Select Long.Parse(A.Item("餐別C"))).Sum
        addRow.餐別D = (From A In returnTable Select Long.Parse(A.Item("餐別D"))).Sum
        addRow.餐別E = (From A In returnTable Select Long.Parse(A.Item("餐別E"))).Sum
        addRow.餐別F = (From A In returnTable Select Long.Parse(A.Item("餐別F"))).Sum

        '--------------------------------------------------------------------------------------------------------------------------
        returnTable.Rows.Add(addRow)


        Return returnTable
    End Function
#End Region
#Region "設定查詢條件至控制項 屬性:SetQryStringToControl"
    ''' <summary>
    ''' 設定查詢條件至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryStringToControl()
        Dim W_SQL As New StringBuilder

        If IsDate(Me.txtQueryDate.Text) = False Then
            Me.CustomValidator1.IsValid = False
            Me.CustomValidator1.ErrorMessage = "輸入的日期錯誤，請檢查。"
            Exit Sub
        End If

        Dim queryEEE As String = Integer.Parse(CDate(Me.txtQueryDate.Text).ToString("yyyy")) - 1911
        Dim queryMM As String = CDate(Me.txtQueryDate.Text).ToString("MM")
        Dim queryDD As String = CDate(Me.txtQueryDate.Text).ToString("dd")
        Dim queryFoodKind As String = New PublicClassLibrary.ClsSystemNote().Fs_GetStrBefor(ddFoodKind.SelectedValue, "：")

        W_SQL.Append("SELECT fd004, fd" & queryDD & queryFoodKind & " as Fd_DayFoodKind ,count(1)  as Cnt " & vbCrLf)
        W_SQL.Append("FROM @#fod100lb.fodm01pf " & vbCrLf)
        W_SQL.Append("WHERE 1=1 " & vbCrLf)
        W_SQL.Append("  AND FDTYM=" & queryEEE & queryMM & vbCrLf)
        W_SQL.Append("  AND fd" & queryDD & queryFoodKind & " <> '' " & vbCrLf)
        W_SQL.Append("GROUP BY fd004, fd" & queryDD & queryFoodKind & vbCrLf)
        W_SQL.Append("ORDER BY fd004, fd" & queryDD & queryFoodKind & vbCrLf)

        Me.hfQryString.Value = W_SQL.ToString

    End Sub
#End Region



    Protected Sub txtQueryDate_TextChanged(sender As Object, e As EventArgs) Handles txtQueryDate.TextChanged

    End Sub


End Class