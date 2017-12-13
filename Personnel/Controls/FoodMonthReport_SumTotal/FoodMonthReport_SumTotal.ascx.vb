Imports Microsoft.Reporting.WebForms

Public Class FoodMonthReport_SumTotal
    Inherits System.Web.UI.UserControl

    Private WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
    Private WP_ClsReportViwer As New ClsReportViwer
    Private WP_AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    Private WP_AS400DateConverter As New CompanyORMDB.AS400DateConverter()


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            txtQueryDate.Text = Now.ToString("yyyy/MM")

            With ddReportKind.Items
                .Clear()
                For II As Integer = ClsReportViwer.ReportExport_Enum.畫面 _
                                             To ClsReportViwer.ReportExport_Enum.PDF
                    .Add(New ListItem(WP_ClsReportViwer.ReportExport_Name(II), II))
                Next
            End With
            ddReportKind.SelectedIndex = 0


            ReportViewer1.ShowExportControls = False

        End If

    End Sub



    Protected Sub btnExec_Click(sender As Object, e As EventArgs) Handles btnExec.Click
        If IsDate(txtQueryDate.Text & "/01") = False Then
            MsgBox(Me, "輸入的日期錯誤：" & txtQueryDate.Text)
            Exit Sub
        End If


        SetQryStringToControl()

        Dim queryTable As Personnel.Report_伙食每日每餐總表DataTable = Search(Me.hfQryString.Value, Me.hfEEEMM_Last.Value, Me.hfEEEMM_Now.Value)
        If queryTable.Rows.Count = 0 Then
            Me.CustomValidator1.Text = "輸入的條件查無資料，請從新查詢。"
            Me.CustomValidator1.IsValid = False
            Exit Sub
        End If

        Dim W_QueryInfo As String
        W_QueryInfo = CDate(Me.txtQueryDate.Text).ToString("yyyy_MM")


        Dim dataTableOfFoodType As DataTable = WP_AS400Adapter.SelectQuery("SELECT v1.* , fdsup1 || '：' || fdsup2 AS " & WP_ClsSystemNote.Display_Lable & "  FROM @#fod100lb.FODSUPPF v1  WHERE fdsup2<>'' ")
        prepareReport(W_QueryInfo, queryTable, dataTableOfFoodType)
    End Sub

    Public Sub prepareReport(ByVal fromQueryInfo As String, _
                                                      ByVal fromQueryTable As Personnel.Report_伙食每日每餐總表DataTable, _
                                                      ByVal fromDataTableOfFoodType As DataTable)

        '報表共用
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim W_ReportExport As ClsReportViwer.ReportExport_Enum = ddReportKind.SelectedValue
        Dim W_ReportDate As Date = Now
        Dim W_ReportName As String = "伙食供應統計表"
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

        Dim W_ParamReportTitle As String
        W_ParamReportTitle = "唐榮公司"
        W_ParamReportTitle &= Space(1) & Integer.Parse(Date.Parse(txtQueryDate.Text).ToString("yyyy")) - 1911 & "年"
        W_ParamReportTitle &= Date.Parse(txtQueryDate.Text).ToString("MM") & "月"

        W_ParamReportTitle &= Space(1) & W_ReportName

        Dim W_ParamReportSubTitle As String
        W_ParamReportSubTitle = "（起訖日期："
        W_ParamReportSubTitle &= Me.hfEEEMM_Last.Value & "26"
        W_ParamReportSubTitle &= "~"
        W_ParamReportSubTitle &= Me.hfEEEMM_Now.Value & "25"
        W_ParamReportSubTitle &= "）"


        Dim W_ParamDataTime As String
        W_ParamDataTime = Integer.Parse(W_ReportDate.ToString("yyyy")) - 1911
        W_ParamDataTime &= "/" & W_ReportDate.ToString("MM/dd")
        W_ParamDataTime &= vbNewLine & W_ReportDate.ToString("HH:mm:ss")


        ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WebForms.ReportParameter("ParamReportTitle", W_ParamReportTitle))
        ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WebForms.ReportParameter("ParamReportSubTitle", W_ParamReportSubTitle))
        ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WebForms.ReportParameter("ParamDataTime", W_ParamDataTime))



        '執行
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        WP_ClsReportViwer.execReport(W_ReportExport, ReportViewer1, Response, W_FileName)
    End Sub





    Class Class伙食每日每餐統計
        Public 日期 As String
        Public 數量_午餐 As Integer
        Public 數量_晚餐 As Integer
    End Class

#Region "查詢 方法:Search"
    Public Function Search(ByVal fromQryString As String, ByVal fromEEEMM_Last As String, ByVal fromEEEMM_Now As String) As Personnel.Report_伙食每日每餐總表DataTable

        'Step1：統計資料
        '------------------------------------------------------------------------------------------------------------------------
        Dim as400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim queryTableALL As DataTable = as400Adapter.SelectQuery(fromQryString)
        Dim queryEEEMM As String, queryCount As Integer
        Dim queryTableDay As DataTable
        Dim queryTableFoodKind As DataTable
        Dim returnList As New List(Of Class伙食每日每餐統計)
        Dim AddItem As Class伙食每日每餐統計
        Dim chackDay As String
        Dim II As Integer, II_Day As Integer

        For II = 26 To 56
            '26~31,1~25
            'II：計次用     II_Day：真實日期

            II_Day = II
            If II_Day > 31 Then II_Day -= 31

            If II_Day <= 25 Then
                queryEEEMM = fromEEEMM_Now
            Else
                queryEEEMM = fromEEEMM_Last
                chackDay = Integer.Parse(queryEEEMM.Substring(0, queryEEEMM.Length - 2) + 1911) & "/" & queryEEEMM.Substring(queryEEEMM.Length - 2) & "/" & II_Day
                If IsDate(chackDay) = False Then Continue For
            End If

            queryTableDay = (From A In queryTableALL _
                                                Where A.Item("fdtym").ToString.Trim.Equals(queryEEEMM) _
                                                 Select A).CopyToDataTable

            AddItem = New Class伙食每日每餐統計
            AddItem.日期 = String.Format("{0:00}", II_Day)
            For Each eachTimeType As String In {"B", "C"}
                queryTableFoodKind = (From B In queryTableDay _
                                                         Where Not B.Item("fd" & String.Format("{0:00}", II_Day) & eachTimeType).ToString.Trim.Equals("") _
                                                         Select B).CopyToDataTable

                queryCount = queryTableFoodKind.Rows.Count

                If eachTimeType = "B" Then
                    AddItem.數量_午餐 = queryCount
                ElseIf eachTimeType = "C" Then
                    AddItem.數量_晚餐 = queryCount
                End If
            Next eachTimeType

            '待處理日期
            returnList.Add(AddItem)
        Next II


        'Step2：整理顯示資料 - 小計
        '------------------------------------------------------------------------------------------------------------------------
        Dim addRow As Personnel.Report_伙食每日每餐總表Row
        Dim returnTable As New Personnel.Report_伙食每日每餐總表DataTable

        Const C_Day_Fix_Column As Integer = 6
        Dim W_Day_Colomn As Integer = 0

        For Each eachItem As Class伙食每日每餐統計 In returnList
            If W_Day_Colomn = 0 Then
                addRow = returnTable.NewReport_伙食每日每餐總表Row
                addRow.標題 = "日期" & vbCrLf & "午" & vbCrLf & "晚"
            End If

            '------------------------------------------------------------------------------------------
            W_Day_Colomn += 1
            addRow.Item("資料" & W_Day_Colomn) = eachItem.日期 & vbCrLf _
                                                                                          & eachItem.數量_午餐 & vbCrLf _
                                                                                          & eachItem.數量_晚餐
            '------------------------------------------------------------------------------------------
            If W_Day_Colomn = C_Day_Fix_Column Then
                returnTable.Rows.Add(addRow)
                W_Day_Colomn = 0
            End If

        Next
        If W_Day_Colomn > 0 Then returnTable.Rows.Add(addRow)


        'Step3：整理顯示資料 - 合計
        '------------------------------------------------------------------------------------------------------------------------
        AddItem = New Class伙食每日每餐統計
        AddItem.數量_午餐 = (From C In returnList Where C.數量_午餐 > 0 Select C.數量_午餐).Sum
        AddItem.數量_晚餐 = (From C In returnList Where C.數量_晚餐 > 0 Select C.數量_晚餐).Sum


        addRow = returnTable.NewReport_伙食每日每餐總表Row
        addRow.標題 = "合計"
        addRow.Item("資料1") = "中餐" & vbCrLf & "晚餐"
        addRow.Item("資料2") = AddItem.數量_午餐 & vbCrLf & AddItem.數量_晚餐

        returnTable.Rows.Add(addRow)



        '------------------------------------------------------------------------------------------------------------------------
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
        Dim W_QueryDate As String = Me.txtQueryDate.Text & "/01"

        If IsDate(W_QueryDate) = False Then
            Me.CustomValidator1.IsValid = False
            Me.CustomValidator1.ErrorMessage = "輸入的日期錯誤，請檢查。"
            Exit Sub
        End If

        Dim queryEEEMM_Now As Integer
        WP_AS400DateConverter.DateValue = Date.Parse(W_QueryDate)
        queryEEEMM_Now = WP_AS400DateConverter.TwIntegerTypeData
        queryEEEMM_Now = -Fix(-queryEEEMM_Now / 100)

        Dim queryEEEMM_Last As Integer
        WP_AS400DateConverter.DateValue = DateAdd(DateInterval.Month, -1, Date.Parse(W_QueryDate))
        queryEEEMM_Last = WP_AS400DateConverter.TwIntegerTypeData
        queryEEEMM_Last = -Fix(-queryEEEMM_Last / 100)



        W_SQL.Append("SELECT * " & vbCrLf)
        W_SQL.Append("FROM @#fod100lb.fodm01pf " & vbCrLf)
        W_SQL.Append("WHERE 1=1 " & vbCrLf)
        W_SQL.Append("  AND ( FDTYM=" & queryEEEMM_Last & " OR FDTYM=" & queryEEEMM_Now & " ) " & vbCrLf)
        W_SQL.Append("ORDER BY FDTYM, fd005,  fd001" & vbCrLf)

        Me.hfQryString.Value = W_SQL.ToString
        Me.hfEEEMM_Last.Value = queryEEEMM_Last
        Me.hfEEEMM_Now.Value = queryEEEMM_Now
    End Sub
#End Region



    Class Class_單位代號_職工編號

#Region "單位代號"
        Private _單位代號 As String
        Public Property 單位代號 As String
            Get
                Return _單位代號
            End Get
            Set(value As String)
                _單位代號 = value
            End Set
        End Property
#End Region

#Region "職工編號"
        Private _職工編號 As String
        Public Property 職工編號 As String
            Get
                Return _職工編號
            End Get
            Set(value As String)
                _職工編號 = value
            End Set
        End Property
#End Region

        Public Sub New()

        End Sub
        Public Sub New(ByVal from單位代號 As String, ByVal from職工編號 As String)
            Me.單位代號 = from單位代號
            Me.職工編號 = from職工編號
        End Sub


    End Class

End Class