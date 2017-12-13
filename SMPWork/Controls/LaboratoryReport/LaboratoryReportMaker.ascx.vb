Public Class LaboratoryReportMaker
    Inherits System.Web.UI.UserControl

#Region "顯示查詢 方法:DisplaySearch"
    ''' <summary>
    ''' 顯示查詢
    ''' </summary>
    ''' <param name="SqlQry"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function DisplaySearch(ByVal SqlQry As String) As List(Of CompanyORMDB.SQLServer.QCDB01.分析資料)
        If String.IsNullOrEmpty(SqlQry) Then
            Return New List(Of CompanyORMDB.SQLServer.QCDB01.分析資料)
        End If
        Return CompanyORMDB.SQLServer.QCDB01.分析資料.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.分析資料)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SqlQry)
    End Function
#End Region
#Region "印表查詢 方法:Search"
    ''' <summary>
    ''' 印表查詢
    ''' </summary>
    ''' <param name="SqlQry"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SqlQry As String, ByVal fromPrintDate As String) As ReportUseDataSet.LaboratoryDataTableDataTable 'List(Of ReportUseDataSet.LaboratoryDataTableRow)
        Dim ReturnValue As New ReportUseDataSet.LaboratoryDataTableDataTable
        If String.IsNullOrEmpty(SqlQry) Then
            Return ReturnValue
        End If
        Dim GetPrintData As CompanyORMDB.SQLServer.QCDB01.分析資料 = (From A In CompanyORMDB.SQLServer.QCDB01.分析資料.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.分析資料)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SqlQry) Select A).FirstOrDefault
        If IsNothing(GetPrintData) Then
            Return ReturnValue
        End If
        Dim AddItem As ReportUseDataSet.LaboratoryDataTableRow
        AddItem = ReturnValue.NewRow
        With AddItem
            .委託號碼 = GetPrintData.爐號.Trim & "-" & GetPrintData.站別.Trim & "-" & GetPrintData.序號.ToString.Trim
            .C = Format(GetPrintData.C, "0.0000")
            .Si = Format(GetPrintData.Si, "0.0000")
            .Mn = Format(GetPrintData.Mn, "0.0000")
            .P = Format(GetPrintData.P, "0.0000")
            .S = Format(GetPrintData.S, "0.0000")
            .Cr = Format(GetPrintData.Cr, "0.0000")
            .Ni = Format(GetPrintData.Ni, "0.0000")
            .Cu = Format(GetPrintData.Cu, "0.0000")
            .Mo = Format(GetPrintData.Mo, "0.0000")
            .Co = Format(GetPrintData.Co, "0.0000")
            .Al = Format(GetPrintData.AL, "0.0000")
            .Sn = Format(GetPrintData.Sn, "0.0000")
            .Pb = Format(GetPrintData.Pb, "0.0000")
            .Ti = Format(GetPrintData.Ti, "0.0000")
            .Nb = Format(GetPrintData.Nb, "0.0000")
            .V = Format(GetPrintData.V, "0.0000")
            .Fe = Format(GetPrintData.Fe, "0.0000")


            ._As = Format(GetPrintData.As, "0.0000")
            .Bi = Format(GetPrintData.Bi, "0.0000")
            .Sb = Format(GetPrintData.Sb, "0.0000")
            .Zn = Format(GetPrintData.Zn, "0.0000")
            .Zr = Format(GetPrintData.Zr, "0.0000")
            .GP = Format(GetPrintData.GP, "0.0000")
            .Ta = Format(GetPrintData.Ta, "0.0000")

            ' .ElementTitles = "Mo,Co,Al,Sn,Pb,T1,Nb,V,Fe"
            .ElementTitles = "Mo,Co,Al,Sn,Pb,T1,Nb,V,Fe,As,Bi,Sb,Zn,Zr,GP,Ta"

        End With
        ReturnValue.Rows.Add(AddItem)
        If ReturnValue.Count > 0 Then

            Dim InsertItem As New CompanyORMDB.SQLServer.QCDB01.LaboratoryReportRecord
            With InsertItem
                .爐號 = GetPrintData.爐號
                .站別 = GetPrintData.站別
                .序號 = GetPrintData.序號
                .日期 = GetPrintData.日期
                .列印日期 = Date.Parse(String.Concat(fromPrintDate, Space(1), String.Format("{0:HH:mm:ss}", Now)))
                If CompanyORMDB.DeviceInformation.GetLocalIPs.Count > 0 Then
                    .列印者 = CompanyORMDB.DeviceInformation.GetLocalIPs(0)
                End If
            End With
            InsertItem.CDBSave()
        End If
        Return ReturnValue
    End Function
#End Region

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Me.hfQry.Value = Nothing
        Dim SQLString As String = "Select * From 分析資料 Where 1=1 "
        If Me.CheckBox1.Checked Then
            Dim StartDateTime As Date = CType(tbStartDate.Text, Date)
            Dim StartDate As Integer = (Format(StartDateTime, "yyyy") - 1911) * 10000 + Format(StartDateTime, "MMdd")
            Dim EndDateTime As Date = CType(tbEndDate.Text, Date).AddDays(1)
            Dim EndDate As Integer = (Format(EndDateTime, "yyyy") - 1911) * 10000 + Format(EndDateTime, "MMdd")
            SQLString &= " AND 日期>=" & StartDate & " AND 日期<=" & EndDate
        End If
        If Not String.IsNullOrEmpty(tbStoveNumber.Text) AndAlso tbStoveNumber.Text.Trim.Length > 0 Then
            SQLString &= " AND 爐號 LIKE '%" & tbStoveNumber.Text.Trim & "%'"
        End If
        Select Case RadioButtonList1.SelectedValue
            Case "YES"
                SQLString &= " AND (LTrim(RTrim((爐號)))+ LTrim(RTrim((站別))) + LTrim(RTrim(STR(序號))) + LTrim(RTrim(STR(日期)))) IN (Select (LTrim(RTrim((爐號)))+ LTrim(RTrim((站別))) + LTrim(RTrim(STR(序號))) + LTrim(RTrim(STR(日期)))) From LaboratoryReportRecord) "
            Case "NO"
                SQLString &= " AND NOT (LTrim(RTrim((爐號)))+ LTrim(RTrim((站別))) + LTrim(RTrim(STR(序號))) + LTrim(RTrim(STR(日期)))) IN (Select (LTrim(RTrim((爐號)))+ LTrim(RTrim((站別))) + LTrim(RTrim(STR(序號))) + LTrim(RTrim(STR(日期)))) From LaboratoryReportRecord) "
        End Select
        If RadioButtonList2.SelectedValue <> "ALL" Then
            SQLString &= " AND 驗收料='" & RadioButtonList2.SelectedValue & "'"
        End If

        Me.hfQry.Value = SQLString & " ORDER BY 日期,時間"
    End Sub
#End Region
#Region "產生查詢字串至控制項 函式:MakPrintQryStringToControl"
    Private Sub MakPrintQryStringToControl()
        Me.hfPrintQry.Value = Nothing
        If GridView1.SelectedIndex < 0 Then
            Me.hfPrintQry.Value = Nothing
            Exit Sub
        End If
        Dim SQLString As String = "Select TOP 1 * From 分析資料 Where (LTrim(RTrim((爐號)))+ LTrim(RTrim((站別))) + LTrim(RTrim(STR(序號))) + LTrim(RTrim(STR(日期)))) ='" & GridView1.SelectedDataKey(0).ToString.Trim & GridView1.SelectedDataKey(1).ToString.Trim & GridView1.SelectedDataKey(2).ToString.Trim & GridView1.SelectedDataKey(3).ToString.Trim & "'"
        Me.hfPrintQry.Value = SQLString
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.tbStartDate.Text = Format(Now, "yyyy/MM/dd")
            Me.tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.TabContainer1.ActiveTab = Me.TabPanel1
        Me.hfPrintQry = Nothing
        Call MakQryStringToControl()
        Me.GridView1.DataBind()
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        MakPrintQryStringToControl()
        Dim Parameters(1) As Microsoft.Reporting.WebForms.ReportParameter
        Dim RightString As String = "甲　存　　根".PadRight(140) & "丁　委託單位 原料驗收課　一"
        RightString &= ",乙　委託單位　煉鋼廠　一".PadRight(125) & "戊　委託單位 原料驗收課　二"
        RightString &= ",丙　委託單位　煉鋼廠　二"
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("Value1", RightString)


        Dim W_GriveGridrow As GridViewRow = GridView1.Rows(GridView1.SelectedIndex)
        Dim W_Date_檢驗日期 As String = New CompanyORMDB.AS400DateConverter().StringToDate(W_GriveGridrow.Cells(5).Text).ToString("yyyy/MM/dd")
        Dim W_Date_列印日期 As String = CType(W_GriveGridrow.FindControl("tbPrintdate"), TextBox).Text
        Me.hfPrintDate.Value = W_Date_列印日期

        Dim W_Param_DateInfo As String = String.Concat("檢驗日期:", W_Date_檢驗日期 _
                                                                                                        , Space(5) _
                                                                                                      , "列印日期:", W_Date_列印日期)
        Parameters(1) = New Microsoft.Reporting.WebForms.ReportParameter("Param_DateInfo", W_Param_DateInfo)


        ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.LocalReport.Refresh()
        Me.TabContainer1.ActiveTab = Me.TabPanel2
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        MakQryStringToControl()
        Dim SearchResult As New SMPWork.ReportUseDataSet.LaboratoryReportMakerDataTable
        For Each EachItem In DisplaySearch(Me.hfQry.Value)
            Dim AddItem As SMPWork.ReportUseDataSet.LaboratoryReportMakerRow = SearchResult.NewRow
            With AddItem
                .爐號 = EachItem.爐號
                .站別 = EachItem.站別
                .序號 = EachItem.序號
                .日期 = EachItem.日期
                .時間 = EachItem.時間
                .C = EachItem.C
                .Si = EachItem.Si
                .Mn = EachItem.Mn
                .P = EachItem.P
                .S = EachItem.S
                .Cr = EachItem.Cr
                .Ni = EachItem.Ni
                .Cu = EachItem.Cu
                .Mo = EachItem.Mo
                .Co = EachItem.Co
                .AL = EachItem.AL
                .Sn = EachItem.Sn
                .Pb = EachItem.Pb
                .Ti = EachItem.Ti
                .Nb = EachItem.Nb
                .V = EachItem.V
                .Fe = EachItem.Fe

                ._As = EachItem.As
                .Bi = EachItem.Bi
                .Sb = EachItem.Sb
                .Zn = EachItem.Zn
                .Zr = EachItem.Zr
                .GP = EachItem.GP
                .Ta = EachItem.Ta

            End With
            SearchResult.Rows.Add(AddItem)
        Next
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(SearchResult, "化驗報告單資料查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If
    End Sub

    Public Function FS_DATE_Now() As String
        Return Format(Now, "yyyy/MM/dd")
    End Function
End Class