Imports Microsoft.Reporting.WebForms

Public Class FoodMonthReport_Detail
    Inherits System.Web.UI.UserControl

    Private WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
    Private WP_ClsReportViwer As New ClsReportViwer
    Private WP_AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    Private WP_AS400DateConverter As New CompanyORMDB.AS400DateConverter()

#Region "ViewState：PeopleKind"
    Const C_PeopleKind As String = "PeopleKind"
    Private ReadOnly Property WP_DataTableOfPeopleKind As DataTable
        Get
            If ViewState(C_PeopleKind) Is Nothing Then
                ViewState(C_PeopleKind) = WP_ClsSystemNote.getLev3("伙食", "身分別")
            End If
            Return ViewState(C_PeopleKind)
        End Get
    End Property
#End Region

#Region "ViewState：fodsuppf"
    Const C_fodsuppf As String = "fodsuppf"
    Private Property WP_DataTable_fodsuppf As DataTable
        Get
            If ViewState(C_fodsuppf) Is Nothing Then
                ViewState(C_fodsuppf) = (WP_AS400Adapter.SelectQuery("SELECT * FROM @#FOD100LB.FODSUPPF"))
            End If
            Return ViewState(C_fodsuppf)
        End Get
        Set(value As DataTable)
            ViewState(C_fodsuppf) = value
        End Set

    End Property
#End Region

#Region ""
    Private ReadOnly Property C_價格_A_葷食 As Integer
        Get
            Return (From A In WP_DataTable_fodsuppf Where A.Item("fdsup1").ToString.Equals("A") Select Integer.Parse(A.Item("fdsup3"))).FirstOrDefault
        End Get
    End Property

    Private ReadOnly Property C_價格_B_素食 As Integer
        Get
            Return (From A In WP_DataTable_fodsuppf Where A.Item("fdsup1").ToString.Equals("B") Select Integer.Parse(A.Item("fdsup3"))).FirstOrDefault
        End Get
    End Property

#End Region


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

            Dim peopleList As List(Of String) = (From A In WP_DataTableOfPeopleKind Group A By content = A.Item(WP_ClsSystemNote.CONTENT) Into GroupMy = Group Select New String(content)).ToList
            With ddPeopleKind.Items
                .Clear()

                For Each eachItem As String In peopleList
                    .Add(eachItem)
                Next
            End With
            ddPeopleKind.SelectedIndex = 0

            ReportViewer1.ShowExportControls = False

        End If

    End Sub



    Protected Sub btnExec_Click(sender As Object, e As EventArgs) Handles btnExec.Click
        If IsDate(txtQueryDate.Text & "/01") = False Then
            MsgBox(Me, "輸入的日期錯誤：" & txtQueryDate.Text)
            Exit Sub
        End If


        SetQryStringToControl()

        Dim queryTable As Personnel.Report_伙食報支總表DataTable = Search(Me.hfQryString.Value)
        If queryTable.Rows.Count = 0 Then
            Me.CustomValidator1.Text = "輸入的條件查無資料，請從新查詢。"
            Me.CustomValidator1.IsValid = False
            Exit Sub
        End If

        Dim W_QueryInfo As String
        W_QueryInfo = CDate(Me.txtQueryDate.Text).ToString("yyyy_MM")
        W_QueryInfo &= "_" & New PublicClassLibrary.ClsSystemNote().Fs_GetStrAfter(ddPeopleKind.SelectedValue, "：")

        Dim dataTableOfFoodType As DataTable = WP_AS400Adapter.SelectQuery("SELECT v1.* , fdsup1 || '：' || fdsup2 AS " & WP_ClsSystemNote.Display_Lable & "  FROM @#fod100lb.FODSUPPF v1  WHERE fdsup2<>'' ")
        prepareReport(W_QueryInfo, queryTable, dataTableOfFoodType)
    End Sub

    Public Sub prepareReport(ByVal fromQueryInfo As String, _
                                                      ByVal fromQueryTable As Personnel.Report_伙食報支總表DataTable, _
                                                      ByVal fromDataTableOfFoodType As DataTable)

        '報表共用
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim W_ReportExport As ClsReportViwer.ReportExport_Enum = ddReportKind.SelectedValue
        Dim W_ReportDate As Date = Now
        Dim W_ReportName As String = "伙食報支總表"
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
        W_ParamReportTitle &= Space(1) & Integer.Parse(Date.Parse(txtQueryDate.Text).ToString("yyyy")) - 1911 & "年"
        W_ParamReportTitle &= Date.Parse(txtQueryDate.Text).ToString("MM") & "月"
        W_ParamReportTitle &= Space(1) & W_ParamFoodKind
        W_ParamReportTitle &= Space(1) & W_ReportName
        W_ParamReportTitle &= Space(1) & "( 部門別 )"

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
        ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WebForms.ReportParameter("ParamFoodKind", W_ParamFoodKind))
        ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WebForms.ReportParameter("ParamPriceA", C_價格_A_葷食))
        ReportViewer1.LocalReport.SetParameters(New Microsoft.Reporting.WebForms.ReportParameter("ParamPriceB", C_價格_B_素食))


        '執行
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        WP_ClsReportViwer.execReport(W_ReportExport, ReportViewer1, Response, W_FileName)
    End Sub

    Public Function ParamFoodKind() As String
        Return WP_ClsSystemNote.Fs_GetStrAfter(ddPeopleKind.SelectedValue, "：")
    End Function





#Region "查詢 方法:Search"
    Public Function Search(ByVal fromQryString As String) As Personnel.Report_伙食報支總表DataTable
        Dim II As Integer, II_Start As Integer, II_End As Integer

        Dim addRow As Personnel.Report_伙食報支總表Row
        Dim returnTable As New Personnel.Report_伙食報支總表DataTable

        Dim as400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim queryTableALL As DataTable = as400Adapter.SelectQuery(fromQryString)
        Dim queryEEEMM As List(Of Int32) = (From A In queryTableALL Group A By fdtym = A.Item("FDTYM") Into GroupMy = Group Select Int32.Parse(fdtym)).ToList
        Dim searchEEEMM As Integer
        Dim queryTableUnit_People As DataTable
        Dim queryRowPeople As DataRow


        Dim peopleList As List(Of String) = (From A In WP_DataTableOfPeopleKind Group A By content = A.Item(WP_ClsSystemNote.CONTENT) Into GroupMy = Group Select New String(content)).ToList

        Dim W_Index_People As Integer
        Dim W_編號_Now As String = "", W_編號_Last As String = ""
        Dim W_姓名 As String
        Dim W_置便當 As String
        Dim W_部門_Now As String = "", W_部門_Last As String = ""

        Dim W_數量_午餐_葷食 As Integer
        Dim W_數量_午餐_素食 As Integer
        Dim W_數量_晚餐_葷食 As Integer
        Dim W_數量_晚餐_素食 As Integer

        Dim query_單位代號_職工編號 As List(Of Class_單位代號_職工編號) = (From A In queryTableALL
                Group A By FD005 = A.Field(Of String)("FD005"), FD001 = A.Field(Of String)("FD001") Into MonthGroup = Group
                Order By FD005, FD001
                Select New Class_單位代號_職工編號(FD005, FD001)).ToList
        Dim W_PayMoney As Long

        'Step1：依單位 & 使用者
        W_Index_People = 0
        For Each eachGroup As Class_單位代號_職工編號 In query_單位代號_職工編號
            If W_部門_Last = "" Then W_部門_Last = W_部門_Now


            W_Index_People += 1

            W_編號_Now = ""
            W_姓名 = ""
            W_置便當 = ""
            W_部門_Now = ""
            W_數量_午餐_葷食 = 0
            W_數量_午餐_素食 = 0
            W_數量_晚餐_葷食 = 0
            W_數量_晚餐_素食 = 0


            queryTableUnit_People = (From A In queryTableALL Where A.Item("fd005").ToString.Equals(eachGroup.單位代號) And A.Item("fd001").ToString.Equals(eachGroup.職工編號) Select A).CopyToDataTable
            'Step2：依使用者
            For Each eachPeople As DataRow In queryTableUnit_People.Rows



                'Step3：依月份
                If Int32.Parse(eachPeople.Item("fdtym")) = queryEEEMM(0) Then
                    '上個月 26~31
                    searchEEEMM = queryEEEMM(0)
                    II_Start = 26 : II_End = 31
                Else
                    '本    月 01~25
                    searchEEEMM = queryEEEMM(1)
                    II_Start = 1 : II_End = 25
                End If


                'II_Start = 26 : II_End = 31
                'For Each eachEEEMM As Integer In queryEEEMM

                '    If II_Start = 26 Then
                '        II_Start = 1 : II_End = 25
                '    End If
                queryRowPeople = ((From B In queryTableUnit_People Where Int32.Parse(B.Item("fdtym")) = searchEEEMM AndAlso B.Item("fd001").ToString.Equals(eachPeople.Item("fd001").ToString) Select B).FirstOrDefault)
                If queryRowPeople Is Nothing Then Continue For

                W_編號_Now = queryRowPeople.Item("fd001")
                W_姓名 = queryRowPeople.Item("fd002")
                W_置便當 = queryRowPeople.Item("fd004")
                W_部門_Now = queryRowPeople.Item("fd005")

                If W_部門_Last <> W_部門_Now Then
                    W_部門_Last = W_部門_Now
                    W_Index_People = 1
                End If


                For II = II_Start To II_End     'Step4：依日期
                    '3-1：午餐
                    Select Case queryRowPeople.Item("fd" & String.Format("{0:00}", II) & "B").ToString
                        Case "A"
                            W_數量_午餐_葷食 += 1
                        Case "B"
                            W_數量_午餐_素食 += 1
                    End Select

                    '3-2：晚餐
                    Select Case queryRowPeople.Item("fd" & String.Format("{0:00}", II) & "C").ToString
                        Case "A"
                            W_數量_晚餐_葷食 += 1
                        Case "B"
                            W_數量_晚餐_素食 += 1
                    End Select


                Next         'Step4：依日期


                'Next    'Step3：依月份



            Next      'Step2-：依使用者

            'Step2-B：AddRow
            '--------------------------------------------------------------------------------------------------------------------------
            addRow = returnTable.NewReport_伙食報支總表Row
            '--------------------------------------------------------------------------------------------------------------------------



            addRow.序號 = W_Index_People
            addRow.編號 = W_編號_Now
            addRow.姓名 = W_姓名
            addRow.置便當 = W_置便當
            addRow.部門 = W_部門_Now
            addRow.午葷 = W_數量_午餐_葷食
            addRow.午素 = W_數量_午餐_素食
            addRow.晚葷 = W_數量_晚餐_葷食
            addRow.晚素 = W_數量_晚餐_素食
            W_PayMoney = ((W_數量_午餐_葷食 + W_數量_晚餐_葷食) * C_價格_A_葷食) + _
                                         ((W_數量_午餐_素食 + W_數量_晚餐_素食) * C_價格_B_素食)
            addRow.應付 = W_PayMoney 

            '--------------------------------------------------------------------------------------------------------------------------
            If W_PayMoney > 0 Then
                returnTable.Rows.Add(addRow)
            End If

        Next          'Step1：依單位 & 使用者

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

        Dim queryPeople_Array As List(Of String) = (From A In WP_DataTableOfPeopleKind Where A.Item(WP_ClsSystemNote.CONTENT).ToString.Equals(ddPeopleKind.SelectedValue) Select New String(A.Item(WP_ClsSystemNote.NOTE_ID))).ToList
        Dim queryPeople_List As String = String.Join("','", queryPeople_Array.ToArray)


        W_SQL.Append("SELECT * " & vbCrLf)
        W_SQL.Append("FROM @#fod100lb.fodm01pf " & vbCrLf)
        W_SQL.Append("WHERE 1=1 " & vbCrLf)
        W_SQL.Append("  AND ( FDTYM=" & queryEEEMM_Last & " OR FDTYM=" & queryEEEMM_Now & " ) " & vbCrLf)
        W_SQL.Append("  AND  substr(fd001,1,2) in ( '" & queryPeople_List & "' ) " & vbCrLf)
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

        Public Sub New(ByVal from單位代號 As String, ByVal from職工編號 As String)
            Me.單位代號 = from單位代號
            Me.職工編號 = from職工編號
        End Sub


    End Class
End Class