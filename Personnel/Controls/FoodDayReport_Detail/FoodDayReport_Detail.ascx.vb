Imports Microsoft.Reporting.WebForms

Public Class FoodDayReport_Detail
    Inherits System.Web.UI.UserControl

    Private WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
    Private WP_ClsReportViwer As New ClsReportViwer
    Private WP_AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)


#Region "ViewState：UnitChange_Report"
    Const C_UnitChange_Report As String = "UnitChange_Report"
    Private ReadOnly Property WP_DataTableOfUnitChange_Report As DataTable
        Get
            If ViewState(C_UnitChange_Report) Is Nothing Then
                ViewState(C_UnitChange_Report) = WP_ClsSystemNote.getLev3("伙食", "單位轉換_報表")
            End If
            Return ViewState(C_UnitChange_Report)
        End Get
    End Property
#End Region

#Region "ViewState：Unit"
    Const C_DataTableUnit As String = "DataTableUnit"
    Private Property WP_DataTable_Unit As DataTable
        Get
            If ViewState(C_DataTableUnit) Is Nothing Then
                ViewState(C_DataTableUnit) = FD_Data_Department_Super()
            End If
            Return ViewState(C_DataTableUnit)
        End Get
        Set(value As DataTable)
            ViewState(C_DataTableUnit) = value
        End Set

    End Property

    Public Function showDeptName(ByVal fromID As String) As String
        Dim showName As String = (From A In WP_DataTable_Unit Where A.Item("pqdp1").ToString.Trim.Equals(fromID.Trim) Select A.Item("pqdp2").ToString.Trim).FirstOrDefault
        Dim retMsg As String = IIf(showName.Trim.Equals(""), fromID, showName)

        Return retMsg
    End Function
#End Region

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

        Dim queryTable As Personnel.Report_伙食明細表DataTable = Search(Me.hfQryString.Value)
        If queryTable.Rows.Count = 0 Then
            Me.CustomValidator1.Text = "輸入的條件查無資料，請從新查詢。"
            Me.CustomValidator1.IsValid = False
            Exit Sub
        End If

        Dim W_QueryInfo As String
        W_QueryInfo = CDate(Me.txtQueryDate.Text).ToString("yyyy_MM_dd")
        W_QueryInfo &= "_" & New PublicClassLibrary.ClsSystemNote().Fs_GetStrAfter(ddFoodKind.SelectedValue, "：")

        Dim dataTableOfFoodType As DataTable = WP_AS400Adapter.SelectQuery("SELECT v1.* , fdsup1 || '：' || fdsup2 AS " & WP_ClsSystemNote.Display_Lable & "  FROM @#fod100lb.FODSUPPF v1  WHERE fdsup2<>'' ")
        prepareReport(W_QueryInfo, queryTable, dataTableOfFoodType)
    End Sub

    Public Sub prepareReport(ByVal fromQueryInfo As String, _
                                                      ByVal fromQueryTable As Personnel.Report_伙食明細表DataTable, _
                                                      ByVal fromDataTableOfFoodType As DataTable)

        '報表共用
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim W_ReportExport As ClsReportViwer.ReportExport_Enum = ddReportKind.SelectedValue
        Dim W_ReportDate As Date = Now
        Dim W_ReportName As String = "伙食明細表"
        Dim W_FileName As String = W_ReportName & "_" & fromQueryInfo _
                                                               & "_" & W_ReportDate.ToString("yyyyMMdd_HHmmss")

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
        W_ParamDataTime &= Space(2) & W_ReportDate.ToString("HH:mm:ss")


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
    Public Function Search(ByVal fromQryString As String) As Personnel.Report_伙食明細表DataTable
        Dim II As Integer
        Dim addRow As Personnel.Report_伙食明細表Row
        Dim returnTable As New Personnel.Report_伙食明細表DataTable

        Dim as400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim queryTableALL As DataTable = as400Adapter.SelectQuery(fromQryString)
        Dim queryTablePlace As DataTable

        Dim queryFodplcpf As List(Of FOD100LB.FODPLCPF) = FOD100LB.FODPLCPF.CDBSelect(Of FOD100LB.FODPLCPF)("SELECT * FROM @#FOD100LB.FODPLCPF", as400Adapter)

        Dim searchUnitChange As String

        Dim queryPlace As List(Of String) = (From A In queryTableALL
                Group A By FD004 = A.Field(Of String)("FD004") Into MonthGroup = Group
                Order By FD004
                Select FD004).ToList

        Dim W_PlaceCode As String, W_PlaceName As String
        Dim W_UnitCode0 As String, W_UnitCode1 As String, W_UnitName As String
        For Each eachPlaceCode In queryPlace
            II = 0
            W_PlaceCode = eachPlaceCode.Trim
            W_PlaceName = (From A In queryFodplcpf Where A.FDPLC1.Equals(W_PlaceCode) Select A.FDPLC2).FirstOrDefault
            queryTablePlace = (From A In queryTableALL Where A.Item("fd004").ToString.Trim.Equals(W_PlaceCode) Select A).CopyToDataTable

            For Each eachItem As DataRow In queryTablePlace.Rows
                W_UnitCode1 = eachItem.Item("fd005").ToString.Trim
                W_UnitName = showDeptName(W_UnitCode1)

                '--------------------------------------------------------------------------------------------------------------------------
                W_UnitCode0 = W_UnitCode1
                searchUnitChange = (From A In WP_DataTableOfUnitChange_Report Where A.Item(WP_ClsSystemNote.NOTE_ID).ToString.Trim.Equals(W_PlaceCode) Select A.Item(WP_ClsSystemNote.CONTENT)).FirstOrDefault
                If IsNumeric(searchUnitChange) = True Then
                    If W_UnitCode1.Length > Integer.Parse(searchUnitChange) Then
                        W_UnitCode0 = W_UnitCode1.Substring(0, Integer.Parse(searchUnitChange))
                    End If
                End If

                '--------------------------------------------------------------------------------------------------------------------------
                addRow = returnTable.NewReport_伙食明細表Row
                '--------------------------------------------------------------------------------------------------------------------------
                II += 1
                addRow.處置 = W_PlaceCode & Space(2) & W_PlaceName
                addRow.序號 = II.ToString("0000")
                addRow.編號 = eachItem.Item("fd001")
                addRow.姓名 = eachItem.Item("fd002")
                addRow.部門0 = W_UnitCode0
                addRow.部門1 = W_UnitCode1
                addRow.部門2 = W_UnitName
                If eachItem.Item("Fd_DayFoodKind").ToString.Trim.Equals("A") Then
                    addRow.葷食 = "A"
                Else
                    addRow.素食 = "B"
                End If

                '--------------------------------------------------------------------------------------------------------------------------
                returnTable.Rows.Add(addRow)

            Next

        Next

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

        W_SQL.Append("SELECT fd004, fd" & queryDD & queryFoodKind & " as Fd_DayFoodKind , fd001, fd002, fd005 " & vbCrLf)
        W_SQL.Append("FROM @#fod100lb.fodm01pf " & vbCrLf)
        W_SQL.Append("WHERE 1=1 " & vbCrLf)
        W_SQL.Append("  AND FDTYM=" & queryEEE & queryMM & vbCrLf)
        W_SQL.Append("  AND fd" & queryDD & queryFoodKind & " <> '' " & vbCrLf)
        W_SQL.Append("ORDER BY fd004, fd005,  fd001" & vbCrLf)

        Me.hfQryString.Value = W_SQL.ToString

    End Sub
#End Region



    Protected Sub txtQueryDate_TextChanged(sender As Object, e As EventArgs) Handles txtQueryDate.TextChanged

    End Sub

End Class