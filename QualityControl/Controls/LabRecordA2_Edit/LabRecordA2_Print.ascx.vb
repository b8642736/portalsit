Imports Microsoft.Reporting.WebForms
Imports System.Web.HttpServerUtility
Public Class LabRecordA2_Print
    Inherits System.Web.UI.UserControl
    Dim masterTable As DataTable
    Dim DT_baseInfoTable As DataTable
    Dim DT_AA_Table As DataTable
    Dim DT_AB_Table As DataTable
    Dim DT_AC_Table As DataTable
    Dim DT_Remark_Table As DataTable
    Dim DT_AssayRES As DataTable
    Dim DT_RemarkRES As DataTable
    Dim DT_sub_datasource As DataTable
    Dim ds_Details As QualityControlDataSet.LabRecordA2DetailsDataTable
    Dim ds_Message As QualityControlDataSet.LabRecordA2DetailsMessageDataTable
    Dim WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
    Dim is_preview_setting As Boolean = False
    Dim WP_LangCode As String
    Dim WP_SplitStr As String
    Dim sSpecifcation As String = ""
    Dim sFinish As String = ""
    Dim sSteel As String = ""
    Dim sCategory As String = ""
    Dim yawuList As String = ""
    Dim ValueBaseInfo() As String = {"", "", "", "", "", "", "", "", ""} '9
    Dim ValueElement() As String = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", ""} '15 
    Dim ValueMechanical() As String = {"", "", "", "", "", "", "", "", ""} '9
    Dim ValueOrther() As String = {"", "", "", "", "", ""} '6
    Dim TitleB() As String = (From dr In DT_QuerySQL("SELECT * FROM [QCdb01].[dbo].[LabRecordA2_Assay_DAT] WHERE SUBSTRING(ASSAY_ID,1,2) = 'AZ'")
                              Select dr.Field(Of String)("ASSAY_NAME")).ToArray
    Dim TitleE() As String = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", ""} '15
    Dim TitleM() As String = {"", "", "", "", "", "", "", "", ""} '9
    Dim TitleO() As String = {"", "", "", "", "", ""} '6
    Dim RangeE() As String = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", ""} '15
    Dim RangeM() As String = {"", "", "", "", "", "", "", "", ""} '9

    Private Enum 查詢目標
        項目 = 0
        資料 = 1
    End Enum
    Private Enum 報表_index
        工作清單 = 0
        材質證明 = 1
    End Enum


    Public Event Event_reFresh父物件(ByVal from主畫面_ActiveTabIndex As LabRecordA2_Main.主畫面_Enum, _
                          ByVal fromLabno As String)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LabRecordA2_Setting_Module.P_IE_Compatible(Page)
        If Not IsPostBack Then
            P_Init()
        End If
    End Sub
    Public Sub P_reFresh子物件(ByRef labnoList As String)
        P_Init()
        If labnoList = "LOCK" Then
            tbLabNo.Enabled = False
            btnPrint.Enabled = False

        Else
            'Tab_Report.Tabs(0).Enabled = False
            ddl_report.SelectedIndex = 報表_index.材質證明
            ddl_report.Enabled = False
            tbLabNo.Enabled = True
            btnPrint.Enabled = True
            tbLabNo.Text = labnoList
            btnPrint_Click(btnPrint, Nothing)
        End If
    End Sub
    Public Sub P_reFresh子物件(ByRef labnoList As String, ByVal fromDetails As QualityControlDataSet.LabRecordA2DetailsDataTable, ByVal fromDetailsMsg As QualityControlDataSet.LabRecordA2DetailsMessageDataTable)
        P_Init()
        If labnoList = "LOCK" Then
            tbLabNo.Enabled = False
            btnPrint.Enabled = False

        Else
            'Tab_Report.Tabs(0).Enabled = True
            ddl_report.Enabled = True
            ddl_report.SelectedIndex = 報表_index.工作清單
            tbLabNo.Enabled = True
            btnPrint.Enabled = True
            tbLabNo.Text = labnoList
            ds_Details = fromDetails
            ds_Message = fromDetailsMsg
            ViewState("ds_Details") = ds_Details
            ViewState("ds_Message") = ds_Message
            btnPrint_Click(btnPrint, Nothing)
        End If
    End Sub

    Private Sub P_Init()
        tbLabNo.Text = ""
        CustomValidator1.ErrorMessage = ""
        ReportViewer1.LocalReport.DataSources.Clear()
        ViewState.Clear()
        'KEY1:參照規範:sSpecifcation
        'KEY2:表面:sFinish
        'KEY3:鋼種:sSteel
        'KEY4:材質:sCategory
        If Request.RawUrl.Contains("Preview") Then
            is_preview_setting = True
        End If

        If Not Request.QueryString.Item("KEY3") = Nothing Then
            sSteel = Server.UrlDecode(Request.QueryString.Item("KEY3")).Trim
            is_preview_setting = True
        End If
        If Not Request.QueryString.Item("KEY4") = Nothing Then
            sCategory = Server.UrlDecode(Request.QueryString.Item("KEY4")).Trim
            is_preview_setting = True
        End If
        If Not Request.QueryString.Item("KEY2") = Nothing Then
            sFinish = Server.UrlDecode(Request.QueryString.Item("KEY2")).Trim
            is_preview_setting = True
        End If
        If Not Request.QueryString.Item("KEY1") = Nothing Then
            sSpecifcation = Server.UrlDecode(Request.QueryString.Item("KEY1")).Trim
            is_preview_setting = True
        End If

        If is_preview_setting Then
            ddl_report.SelectedIndex = 報表_index.材質證明
            ddl_report.Visible = False

            ReportViewer1.Visible = True
            tbLabNo.Visible = False
            tb_setting_par.Attributes.Add("style", "overflow :hidden")
            tb_setting_par.Text = "鋼種 : " & sSteel & vbNewLine
            tb_setting_par.Text &= "材質 : " & sCategory & vbNewLine
            tb_setting_par.Text &= "表面 : " & sFinish & vbNewLine
            tb_setting_par.Text &= "參照規範 : " & sSpecifcation & vbNewLine
            tb_setting_par.Visible = True
            btn_hideSetting.Visible = True

            btnPrint.Visible = False
            btnPrint_Click(Nothing, Nothing)
        End If




    End Sub
    Private Function FS_QuertString_labMaster(ByVal fromlabset As String) As String
        Dim labset As String = FS_SQL_IN(fromlabset, ";")
        Dim queryString As New StringBuilder
        queryString.Append("SELECT *" & vbNewLine)
        queryString.Append("FROM [QCdb01].[dbo].[LabRecordA2_M]" & vbNewLine)
        queryString.Append("WHERE 1=1" & vbNewLine)
        queryString.Append("AND LABREPORT_NO IN (" & labset & ")" & vbNewLine)
        Return queryString.ToString
    End Function
    Private Function FS_QuertString_RemarkDAT(fromRemarkList As String) As String
        If fromRemarkList.Trim = "" Then
            Return ""
        End If
        If fromRemarkList.IndexOf(",") > 0 Then
            fromRemarkList = fromRemarkList.Insert(0, "'")
            fromRemarkList = fromRemarkList.Insert(fromRemarkList.Length, "'")
            fromRemarkList = fromRemarkList.Replace(",", "','")
        Else
            fromRemarkList = fromRemarkList.Insert(0, "'")
            fromRemarkList = fromRemarkList.Insert(fromRemarkList.Length, "'")
        End If
        Dim queryString As New StringBuilder
        queryString.Append("SELECT CONTEXT " & vbNewLine)
        queryString.Append("FROM [QCdb01].[dbo].[LabRecordA2_Remark_DAT]" & vbNewLine)
        queryString.Append("WHERE REMARK_ID IN( " & fromRemarkList & ")" & vbNewLine)
        queryString.Append("ORDER BY DISPLAY_SEQ,REMARK_ID" & vbNewLine)
        Return queryString.ToString
    End Function

    Private Function FS_QuertString_labElement(ByVal fromlab As String, ByVal type As 查詢目標) As String
        Dim queryString As New StringBuilder
        queryString.Append("SELECT D.*,DAT.[ASSAY_ID] " & vbNewLine)
        queryString.Append(",DAT.[ASSAY_NAME] " & vbNewLine)
        queryString.Append(",DAT.[DISPLAY_SEQ] " & vbNewLine)
        queryString.Append(",DAT.[DISPLAY_FLAG] " & vbNewLine)
        queryString.Append(",DAT.[NORMAL_RANGE_L] + '~' + DAT.[NORMAL_RANGE_H] as NORMAL_RANGE" & vbNewLine)
        queryString.Append(",DAT.[RESULT_FORMAT] " & vbNewLine)
        queryString.Append(",DAT.[RESULT_KIND] " & vbNewLine)
        queryString.Append(",DAT.[RESULT_TABLE_COLUMN] " & vbNewLine)
        queryString.Append(",DAT.[EFF_FLAG] " & vbNewLine)
        queryString.Append(",DAT.[SAVE_OPER] " & vbNewLine)
        queryString.Append(",DAT.[SAVE_DATE] " & vbNewLine)
        queryString.Append("FROM [QCdb01].[dbo].[LabRecordA2_D] D   " & vbNewLine)
        queryString.Append("LEFT JOIN LabRecordA2_Assay_DAT DAT " & vbNewLine)
        queryString.Append("ON D.[ASSAY_ID]=DAT.ASSAY_ID " & vbNewLine)
        queryString.Append("WHERE LEFT(D.ASSAY_ID,2) = 'AA' " & vbNewLine)
        queryString.Append("AND DAT.DISPLAY_FLAG = 'Y' " & vbNewLine)
        queryString.Append("AND LABREPORT_NO ='" & fromlab & "'" & vbNewLine)
        If type = 查詢目標.項目 Then
            queryString.Append("AND ITEM_NO ='1'" & vbNewLine)
        End If
        queryString.Append("Order by LABREPORT_NO,ITEM_NO,DISPLAY_SEQ " & vbNewLine)
        Return queryString.ToString
    End Function
    Private Function FS_QuertString_labMechanical(ByVal fromlab As String, ByVal type As 查詢目標) As String
        Dim queryString As New StringBuilder
        queryString.Append("SELECT D.*,DAT.[ASSAY_ID] " & vbNewLine)
        queryString.Append(",DAT.[ASSAY_NAME] " & vbNewLine)
        queryString.Append(",DAT.[DISPLAY_SEQ] " & vbNewLine)
        queryString.Append(",DAT.[DISPLAY_FLAG] " & vbNewLine)
        queryString.Append(",DAT.[NORMAL_RANGE_L] + '~' + DAT.[NORMAL_RANGE_H] as NORMAL_RANGE" & vbNewLine)
        queryString.Append(",DAT.[RESULT_FORMAT] " & vbNewLine)
        queryString.Append(",DAT.[RESULT_KIND] " & vbNewLine)
        queryString.Append(",DAT.[RESULT_TABLE_COLUMN] " & vbNewLine)
        queryString.Append(",DAT.[EFF_FLAG] " & vbNewLine)
        queryString.Append(",DAT.[SAVE_OPER] " & vbNewLine)
        queryString.Append(",DAT.[SAVE_DATE] " & vbNewLine)
        queryString.Append("FROM [QCdb01].[dbo].[LabRecordA2_D] D   " & vbNewLine)
        queryString.Append("LEFT JOIN LabRecordA2_Assay_DAT DAT " & vbNewLine)
        queryString.Append("ON D.[ASSAY_ID]=DAT.ASSAY_ID " & vbNewLine)
        queryString.Append("WHERE LEFT(D.ASSAY_ID,2) = 'AB' " & vbNewLine)
        queryString.Append("AND DAT.DISPLAY_FLAG = 'Y' " & vbNewLine)
        queryString.Append("AND LABREPORT_NO ='" & fromlab & "'" & vbNewLine)
        If type = 查詢目標.項目 Then
            queryString.Append("AND ITEM_NO ='1'" & vbNewLine)
        End If
        queryString.Append("Order by LABREPORT_NO,ITEM_NO,DISPLAY_SEQ " & vbNewLine)
        Return queryString.ToString
    End Function
    Private Function FS_QuertString_labOrther(ByVal fromlab As String, ByVal type As 查詢目標) As String
        Dim queryString As New StringBuilder
        queryString.Append("SELECT D.*,DAT.[ASSAY_ID] " & vbNewLine)
        queryString.Append(",DAT.[ASSAY_NAME] " & vbNewLine)
        queryString.Append(",DAT.[DISPLAY_SEQ] " & vbNewLine)
        queryString.Append(",DAT.[DISPLAY_FLAG] " & vbNewLine)
        queryString.Append(",DAT.[NORMAL_RANGE_L] + '~' + DAT.[NORMAL_RANGE_H] as NORMAL_RANGE" & vbNewLine)
        queryString.Append(",DAT.[RESULT_FORMAT] " & vbNewLine)
        queryString.Append(",DAT.[RESULT_KIND] " & vbNewLine)
        queryString.Append(",DAT.[RESULT_TABLE_COLUMN] " & vbNewLine)
        queryString.Append(",DAT.[EFF_FLAG] " & vbNewLine)
        queryString.Append(",DAT.[SAVE_OPER] " & vbNewLine)
        queryString.Append(",DAT.[SAVE_DATE] " & vbNewLine)
        queryString.Append("FROM [QCdb01].[dbo].[LabRecordA2_D] D   " & vbNewLine)
        queryString.Append("LEFT JOIN LabRecordA2_Assay_DAT DAT " & vbNewLine)
        queryString.Append("ON D.[ASSAY_ID]=DAT.ASSAY_ID " & vbNewLine)
        queryString.Append("WHERE LEFT(D.ASSAY_ID,2) = 'AC' " & vbNewLine)
        queryString.Append("AND DAT.DISPLAY_FLAG = 'Y' " & vbNewLine)
        queryString.Append("AND LABREPORT_NO ='" & fromlab & "'" & vbNewLine)
        If type = 查詢目標.項目 Then
            queryString.Append("AND ITEM_NO ='1'" & vbNewLine)
        End If
        queryString.Append("Order by LABREPORT_NO,ITEM_NO,DISPLAY_SEQ " & vbNewLine)
        Return queryString.ToString
    End Function

    Private Function FS_QuertString_labBaseInfo(ByVal fromlab As String) As String
        Dim queryString As New StringBuilder
        queryString.Append("SELECT *" & vbNewLine)
        queryString.Append("FROM [QCdb01].[dbo].[LabRecordA2_D] " & vbNewLine)
        queryString.Append("WHERE LEFT(ASSAY_ID,2) = 'AZ' " & vbNewLine)
        queryString.Append("AND LABREPORT_NO ='" & fromlab & "'" & vbNewLine)
        queryString.Append("Order by LABREPORT_NO,ITEM_NO" & vbNewLine)
        Return queryString.ToString
    End Function

    Private Sub get_Element_structure(ByVal fromlabno)
        DT_AA_Table = New DataTable
        Dim DT_Source As DataTable = DT_QuerySQL(FS_QuertString_labElement(fromlabno, 查詢目標.項目))
        clone_format(DT_AssayRES, DT_Source)
        TitleE = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        RangeE = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        Dim Count As Int32 = 0
        For Each dr As DataRow In DT_Source.Rows
            DT_AA_Table.Columns.Add(dr.Item("ASSAY_ID"))
            TitleE(Count) = dr.Item("ASSAY_NAME")
            Try
                RangeE(Count) = FS_NORMAL_RANGE(dr.Item("NORMAL_RANGE").ToString.Split("~")(0), dr.Item("NORMAL_RANGE").ToString.Split("~")(1))
            Catch ex As Exception
                RangeE(Count) = dr.Item("NORMAL_RANGE")
            End Try

            Count += 1
        Next
    End Sub
    Private Sub get_Element_structure(ByVal fromlabno As String, ByVal FromDT As DataTable)
        DT_AA_Table = New DataTable
        Dim DT_Source As DataTable = FromDT
        clone_format(DT_AssayRES, DT_Source)
        TitleE = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        RangeE = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        Dim Count As Int32 = 0
        For Each dr As DataRow In DT_Source.Rows
            If dr.Item("ASSAY_ID").ToString.StartsWith("AA") Then
                DT_AA_Table.Columns.Add(dr.Item("ASSAY_ID"))
                TitleE(Count) = dr.Item("ASSAY_NAME")
                Try
                    RangeE(Count) = FS_NORMAL_RANGE(dr.Item("NORMAL_RANGE").ToString.Split("~")(0), dr.Item("NORMAL_RANGE").ToString.Split("~")(1))
                Catch ex As Exception
                    RangeE(Count) = dr.Item("NORMAL_RANGE")
                End Try
                Count += 1
            End If
        Next
    End Sub
    Private Sub get_Mechanical_structure(ByVal fromlabno)
        DT_AB_Table = New DataTable
        Dim DT_Source As DataTable = DT_QuerySQL(FS_QuertString_labMechanical(fromlabno, 查詢目標.項目))
        clone_format(DT_AssayRES, DT_Source)
        TitleM = {"", "", "", "", "", "", "", "", ""} '9
        RangeM = {"", "", "", "", "", "", "", "", ""} '9
        Dim Count As Int32 = 0
        For Each dr As DataRow In DT_Source.Rows
            DT_AB_Table.Columns.Add(dr.Item("ASSAY_ID"))
            TitleM(Count) = dr.Item("ASSAY_NAME")
            Try
                RangeE(Count) = FS_NORMAL_RANGE(dr.Item("NORMAL_RANGE").ToString.Split("~")(0), dr.Item("NORMAL_RANGE").ToString.Split("~")(1))
            Catch ex As Exception
                RangeE(Count) = dr.Item("NORMAL_RANGE")
            End Try
            Count += 1
        Next
    End Sub
    Private Sub get_Mechanical_structure(ByVal fromlabno As String, ByVal FromDT As DataTable)
        DT_AB_Table = New DataTable
        Dim DT_Source As DataTable = FromDT
        clone_format(DT_AssayRES, DT_Source)
        TitleM = {"", "", "", "", "", "", "", "", ""} '9
        RangeM = {"", "", "", "", "", "", "", "", ""} '9
        Dim Count As Int32 = 0
        For Each dr As DataRow In DT_Source.Rows
            If dr.Item("ASSAY_ID").ToString.StartsWith("AB") Then
                DT_AB_Table.Columns.Add(dr.Item("ASSAY_ID"))
                TitleM(Count) = dr.Item("ASSAY_NAME")
                Try
                    RangeE(Count) = FS_NORMAL_RANGE(dr.Item("NORMAL_RANGE").ToString.Split("~")(0), dr.Item("NORMAL_RANGE").ToString.Split("~")(1))
                Catch ex As Exception
                    RangeE(Count) = dr.Item("NORMAL_RANGE")
                End Try
                Count += 1
            End If
        Next
    End Sub
    Private Sub get_Other_structure(ByVal fromlabno)
        DT_AC_Table = New DataTable
        Dim DT_Source As DataTable = DT_QuerySQL(FS_QuertString_labOrther(fromlabno, 查詢目標.項目))
        TitleO = {"", "", "", "", "", "", "", "", "", "", "", ""}
        Dim Count As Int32 = 0
        For Each dr As DataRow In DT_Source.Rows
            DT_AC_Table.Columns.Add(dr.Item("ASSAY_ID"))
            TitleO(Count) = dr.Item("ASSAY_NAME")
            Count += 1
        Next
    End Sub
    Private Sub get_Other_structure(ByVal fromlabno As String, ByVal FromDT As DataTable)
        DT_AC_Table = New DataTable
        Dim DT_Source As DataTable = FromDT
        TitleO = {"", "", "", "", "", "", "", "", "", "", "", ""}
        Dim Count As Int32 = 0
        For Each dr As DataRow In DT_Source.Rows
            If dr.Item("ASSAY_ID").ToString.StartsWith("AC") Then
                DT_AC_Table.Columns.Add(dr.Item("ASSAY_ID"))
                TitleO(Count) = dr.Item("ASSAY_NAME")
                Count += 1
            End If
        Next
    End Sub
    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ReportViewer1.Visible = True

        Try
            masterTable = DT_QuerySQL(FS_QuertString_labMaster(tbLabNo.Text))

            'CustomValidator1.ErrorMessage = ""
            'If tbLabNo.Text.Trim = "" Then
            '    CustomValidator1.ErrorMessage = "請輸入單據號碼"
            '    Exit Try
            'End If
            ''------------------------------------------------------------------------------------------------------------------------
            'Dim SQLAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter( _
            '                       CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, _
            '                       CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, _
            '                        "QCDB01")
            'Dim W_SQL As String
            'W_SQL = "SELECT * FROM LabRecordA1_M WHERE LAB_REPORTNO = '" & tbLabNo.Text.Trim & "'"
            'Dim queryTableM As DataTable = SQLAdapter.SelectQuery(W_SQL)
            'W_SQL = "SELECT * FROM LabRecordA1_D WHERE LAB_REPORTNO = '" & tbLabNo.Text.Trim & "'"
            'Dim queryTableD As DataTable = SQLAdapter.SelectQuery(W_SQL)

            'Debug.Print(Now)

            '------------------------------------------------------------------------------------------------------------------------

            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler
            With ReportViewer1.LocalReport
                If ddl_report.Text = "工作報表" Then
                    .ReportPath = "bin\Controls\LabRecordA2_Edit\report\Report-Details.rdlc"
                    .DataSources.Clear()
                    ds_Details = CType(ViewState("ds_Details"), QualityControlDataSet.LabRecordA2DetailsDataTable)
                    ds_Message = CType(ViewState("ds_Message"), QualityControlDataSet.LabRecordA2DetailsMessageDataTable)
                    Dim success_list As String = ""
                    If Not IsNothing(ds_Details) Then
                        .DataSources.Add(P_AddTable("Main", ds_Details))
                        Dim sucess_set = From dr As QualityControlDataSet.LabRecordA2DetailsRow In ds_Details
                                         Where dr.RESULT = "SUCESS"

                        Dim sucess_count = sucess_set.Count
                        For Each lab As QualityControlDataSet.LabRecordA2DetailsRow In sucess_set
                            success_list &= lab.LABNO & "  "
                        Next
                        Dim faild_count = ds_Details.Rows.Count - sucess_count
                        .SetParameters(P_AddParam("par_sucess", sucess_count))
                        .SetParameters(P_AddParam("par_sucess_list", IIf(success_list = "", "無", success_list)))
                        .SetParameters(P_AddParam("par_faild", faild_count))
                    End If
                    If Not IsNothing(ds_Message) Then
                        .DataSources.Add(P_AddTable("Message", ds_Message))
                    End If
                    .Refresh()
                Else
                    .ReportPath = "bin\Controls\LabRecordA2_Edit\report\Report-Main.rdlc"
                    .DataSources.Clear()
                    .EnableExternalImages = True

                    Dim labno As String = tbLabNo.Text.Trim

                    If is_preview_setting Then
                        .DataSources.Add(P_AddTable("MasterDataSet", P_AddTable_Master(Nothing, True)))
                        DT_sub_datasource = P_AddTable_DetailTitle(Nothing, True)
                        .DataSources.Add(P_AddTable("Colis", DT_sub_datasource))

                    Else
                        .DataSources.Add(P_AddTable("MasterDataSet", P_AddTable_Master(Nothing)))
                        DT_sub_datasource = P_AddTable_DetailTitle(Nothing)
                        .DataSources.Add(P_AddTable("Colis", DT_sub_datasource))
                    End If
                    Dim Parmeters() = .GetParameters().ToArray()
                    .Refresh()
                End If

            End With

            'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler
            'With ReportViewer1.LocalReport
            '    If DropDownList1.Text = "工作報表" Then

            '    Else

            '    End If
            '    .DataSources.Clear()
            '    .EnableExternalImages = True

            '    Dim labno As String = tbLabNo.Text.Trim

            '    '-- Main---------------------------------------------------------------------------------------------------------------------------------------------
            '    If is_preview_setting Then
            '        .DataSources.Add(P_AddTable("MasterDataSet", P_AddTable_Master(Nothing, True)))
            '        DT_sub_datasource = P_AddTable_DetailTitle(Nothing, True)
            '        .DataSources.Add(P_AddTable("Colis", DT_sub_datasource))

            '    Else
            '        .DataSources.Add(P_AddTable("MasterDataSet", P_AddTable_Master(Nothing)))
            '        DT_sub_datasource = P_AddTable_DetailTitle(Nothing)
            '        .DataSources.Add(P_AddTable("Colis", DT_sub_datasource))
            '    End If



            '    Dim Parmeters() = .GetParameters().ToArray()

            '    'For Each par As Microsoft.Reporting.WebForms.ReportParameterInfo In Parmeters
            '    '    .SetParameters(P_AddParam(par.Name.ToString, "C"))
            '    'Next
            '    '.SetParameters(P_AddParam("RC", "0.301~" & vbNewLine & "0.509"))
            '    '.SetParameters(P_AddParam("RSi", "0.301 ~ 0.509"))
            '    .Refresh()
            'End With
            'If ReportViewer2.LocalReport.DataSources.Count = 0 Then
            '    With ReportViewer2.LocalReport
            '        .DataSources.Clear()
            '        If Not IsNothing(ds_Details) Then
            '            .DataSources.Add(P_AddTable("Main", ds_Details))
            '            Dim sucess_set = From dr As QualityControlDataSet.LabRecordA2DetailsRow In ds_Details
            '                             Where dr.RESULT = "SUCESS"

            '            Dim sucess_count = sucess_set.Count
            '            Dim faild_count = ds_Details.Rows.Count - sucess_count
            '            .SetParameters(P_AddParam("par_sucess", sucess_count))
            '            .SetParameters(P_AddParam("par_faild", faild_count))
            '        End If
            '        If Not IsNothing(ds_Message) Then
            '            .DataSources.Add(P_AddTable("Message", ds_Message))
            '        End If
            '        .Refresh()
            '    End With
            'End If
        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message
        End Try
        CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")
    End Sub

    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, _
     ByVal e As SubreportProcessingEventArgs)
        
            e.DataSources.Add(P_AddTable("Colis", DT_sub_datasource))
        
    End Sub
    Private Function P_AddTable_Master(ByVal lan As String) As QualityControlDataSet.LabRecordA2LABDataTable

        Dim paramTable As New QualityControlDataSet.LabRecordA2LABDataTable
        CustomValidator1.ErrorMessage = ""
        Try
            Dim paramRow As QualityControlDataSet.LabRecordA2LABRow
            For Each dr As DataRow In masterTable.Rows
                DT_Remark_Table = DT_QuerySQL(FS_QuertString_RemarkDAT(dr.Item("REMARK_LIST")))
                '測試Remark
                'DT_Remark_Table = DT_QuerySQL(FS_QuertString_RemarkDAT("RA0B,RA0C,RA0D,RA0E,RA0F,RA10,RA11,RA12,RA13"))
                yawuList = dr.Item("APPEND_LIST")
                Dim DT_lab_baseInfo As DataTable = DT_QuerySQL(FS_QuertString_labBaseInfo(dr.Item("LABREPORT_NO")))
                set_lab_config_rule(DT_lab_baseInfo)
                DT_AssayRES = DT_getResTable(對照檔.Assay, sSpecifcation, sFinish, sSteel, sCategory, yawuList)

                get_Element_structure(dr.Item("LABREPORT_NO"))
                get_Mechanical_structure(dr.Item("LABREPORT_NO"))
                get_Other_structure(dr.Item("LABREPORT_NO"))


                paramRow = paramTable.NewRow
                With paramRow
                    .LABNO = dr.Item("LABREPORT_NO")
                    .Buyer = dr.Item("CUSTOMER")
                    .ContractNO = dr.Item("CONTRACT_NO")
                    .LCNO = dr.Item("LC_NO")
                    '.Remark = "        附註 Remarks" & vbNewLine & FS_Make_Remark(DT_Remark_Table)
                    .Remark = "附註Remarks" & vbNewLine & FS_Make_Remark(DT_Remark_Table)
                    .T_BaseItem1 = TitleB(0)
                    .T_BaseItem2 = TitleB(1)
                    .T_BaseItem3 = TitleB(2)
                    .T_BaseItem4 = TitleB(3)
                    .T_BaseItem5 = TitleB(4)
                    .T_BaseItem6 = TitleB(5)
                    .T_BaseItem7 = TitleB(6)
                    .T_BaseItem8 = TitleB(7)
                    .T_BaseItem9 = TitleB(8)
                    .T_Element1 = TitleE(0)
                    .T_Element2 = TitleE(1)
                    .T_Element3 = TitleE(2)
                    .T_Element4 = TitleE(3)
                    .T_Element5 = TitleE(4)
                    .T_Element6 = TitleE(5)
                    .T_Element7 = TitleE(6)
                    .T_Element8 = TitleE(7)
                    .T_Element9 = TitleE(8)
                    .T_Element10 = TitleE(9)
                    .T_Element11 = TitleE(10)
                    .T_Element12 = TitleE(11)
                    .T_Element13 = TitleE(12)
                    .T_Element14 = TitleE(13)
                    .T_Element15 = TitleE(14)
                    .T_MechanicalP1 = TitleM(0)
                    .T_MechanicalP2 = TitleM(1)
                    .T_MechanicalP3 = TitleM(2)
                    '.T_MechanicalP1 = "T.S N/mm²"
                    '.T_MechanicalP2 = "Rp(1.0%) N/mm²"
                    '.T_MechanicalP3 = "HRC"
                    .T_MechanicalP4 = TitleM(3)
                    .T_MechanicalP5 = TitleM(4)
                    .T_MechanicalP6 = TitleM(5)
                    .T_MechanicalP7 = TitleM(6)
                    .T_MechanicalP8 = TitleM(7)
                    .T_MechanicalP9 = TitleM(8)
                    .T_OtherInformation1 = TitleO(0)
                    .T_OtherInformation2 = TitleO(1)
                    .T_OtherInformation3 = TitleO(2)
                    .T_OtherInformation4 = TitleO(3)
                    .T_OtherInformation5 = TitleO(4)
                    .T_OtherInformation6 = TitleO(5)
                    .R_Element1 = FS_FormatRange(RangeE(0))
                    .R_Element2 = FS_FormatRange(RangeE(1))
                    .R_Element3 = FS_FormatRange(RangeE(2))
                    .R_Element4 = FS_FormatRange(RangeE(3))
                    .R_Element5 = FS_FormatRange(RangeE(4))
                    .R_Element6 = FS_FormatRange(RangeE(5))
                    .R_Element7 = FS_FormatRange(RangeE(6))
                    .R_Element8 = FS_FormatRange(RangeE(7))
                    .R_Element9 = FS_FormatRange(RangeE(8))
                    .R_Element10 = FS_FormatRange(RangeE(9))
                    .R_Element11 = FS_FormatRange(RangeE(10))
                    .R_Element12 = FS_FormatRange(RangeE(11))
                    .R_Element13 = FS_FormatRange(RangeE(12))
                    .R_Element14 = FS_FormatRange(RangeE(13))
                    .R_Element15 = FS_FormatRange(RangeE(14))
                    .R_MechanicalP1 = FS_FormatRange(RangeM(0))
                    .R_MechanicalP2 = FS_FormatRange(RangeM(1))
                    .R_MechanicalP3 = FS_FormatRange(RangeM(2))
                    .R_MechanicalP4 = FS_FormatRange(RangeM(3))
                    .R_MechanicalP5 = FS_FormatRange(RangeM(4))
                    .R_MechanicalP6 = FS_FormatRange(RangeM(5))
                    .R_MechanicalP7 = FS_FormatRange(RangeM(6))
                    .R_MechanicalP8 = FS_FormatRange(RangeM(7))
                    .R_MechanicalP9 = FS_FormatRange(RangeM(8))

                End With
                paramTable.Rows.Add(paramRow)
            Next

        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message
        Finally
            CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")
        End Try
        Return paramTable
    End Function
    Private Function P_AddTable_DetailTitle(ByVal queryTable As DataTable) As QualityControlDataSet.LabRecordA2TableDataTable
        Dim paramTable As New QualityControlDataSet.LabRecordA2TableDataTable

        CustomValidator1.ErrorMessage = ""
        For Each lab As DataRow In masterTable.Rows
            '==========Step 1-1.取得基本項目
            Dim DT_lab_baseInfo As DataTable = DT_QuerySQL(FS_QuertString_labBaseInfo(lab.Item("LABREPORT_NO")))

            '==========Step 1-2.取得詳細項目
            Dim DT_lab_detail_AA As DataTable = DT_QuerySQL(FS_QuertString_labElement(lab.Item("LABREPORT_NO"), 查詢目標.資料))
            Dim DT_lab_detail_AB As DataTable = DT_QuerySQL(FS_QuertString_labMechanical(lab.Item("LABREPORT_NO"), 查詢目標.資料))
            Dim DT_lab_detail_AC As DataTable = DT_QuerySQL(FS_QuertString_labOrther(lab.Item("LABREPORT_NO"), 查詢目標.資料))
            '==========Step 1-3.取得表單結構(依照設定檔排序)           
            get_Element_structure(lab.Item("LABREPORT_NO"))
            get_Mechanical_structure(lab.Item("LABREPORT_NO"))
            get_Other_structure(lab.Item("LABREPORT_NO"))
            '==========Step 2-1. 填入四次Detail資料列(對應報表上的四列鋼捲資料列)
            For i As Int32 = 1 To 4
                Try
                    '==========Step 2-2-1. 將第i顆鋼捲基本項目置入暫存陣列(對應欄位)
                    set_BaseInfoArray(DT_lab_baseInfo, i.ToString)
                    '==========Step 2-2-2. 取得第i顆鋼捲所有化性物性
                    Dim coils_set_AA = From coils As DataRow In DT_lab_detail_AA
                                       Where coils.Item("ITEM_NO") = i.ToString _
                                       And coils.Item("ASSAY_ID").ToString.Substring(0, 2) = "AA"

                    Dim coils_set_AB = From coils As DataRow In DT_lab_detail_AB
                                       Where coils.Item("ITEM_NO") = i.ToString _
                                       And coils.Item("ASSAY_ID").ToString.Substring(0, 2) = "AB"

                    Dim coils_set_AC = From coils As DataRow In DT_lab_detail_AC
                                       Where coils.Item("ITEM_NO") = i.ToString _
                                       And coils.Item("ASSAY_ID").ToString.Substring(0, 2) = "AC"
                    '==========Step 2-2-3. 依據表單結構填入Value
                    Dim row_AA As DataRow = DT_AA_Table.NewRow
                    For Each element As DataRow In coils_set_AA
                        row_AA.Item(element.Item("ASSAY_ID")) = element.Item("RESULT_VALUE")
                    Next
                    DT_AA_Table.Rows.Add(row_AA)

                    Dim row_AB As DataRow = DT_AB_Table.NewRow
                    For Each element As DataRow In coils_set_AB
                        row_AB.Item(element.Item("ASSAY_ID")) = element.Item("RESULT_VALUE")
                    Next
                    DT_AB_Table.Rows.Add(row_AB)

                    Dim row_AC As DataRow = DT_AC_Table.NewRow
                    For Each element As DataRow In coils_set_AC
                        row_AC.Item(element.Item("ASSAY_ID")) = element.Item("RESULT_VALUE")
                    Next
                    DT_AC_Table.Rows.Add(row_AC)
                    '==========Step 2-2-4. 將第i顆鋼捲AA(化性)置入暫存陣列(對應欄位)
                    set_ValueElementArray(DT_AA_Table, i.ToString)
                    set_ValueMechanicalArray(DT_AB_Table, i.ToString)
                    set_ValueOrtherArray(DT_AC_Table, i.ToString)


                    Dim paramRow As QualityControlDataSet.LabRecordA2TableRow

                    paramRow = paramTable.NewRow
                    With paramRow
                        .LABNO = lab.Item("LABREPORT_NO")
                        .Item = i
                        .ProductID = ValueBaseInfo(0)
                        .HeadNo = ValueBaseInfo(1)
                        .ProductForm = ValueBaseInfo(2)
                        .SteelGrade = ValueBaseInfo(3)
                        .Finish = ValueBaseInfo(4)
                        .Category = ValueBaseInfo(5)
                        .Size = ValueBaseInfo(6)
                        .Weight = ValueBaseInfo(7) & IIf(ValueBaseInfo(7).Trim = "", "", " kg")
                        .Specification = ValueBaseInfo(8)
                        .Element1 = ValueElement(0)
                        .Element2 = ValueElement(1)
                        .Element3 = ValueElement(2)
                        .Element4 = ValueElement(3)
                        .Element5 = ValueElement(4)
                        .Element6 = ValueElement(5)
                        .Element7 = ValueElement(6)
                        .Element8 = ValueElement(7)
                        .Element9 = ValueElement(8)
                        .Element10 = ValueElement(9)
                        .Element11 = ValueElement(10)
                        .Element12 = ValueElement(11)
                        .Element13 = ValueElement(12)
                        .Element14 = ValueElement(13)
                        .Element15 = ValueElement(14)
                        .MechanicalP1 = ValueMechanical(0)
                        .MechanicalP2 = ValueMechanical(1)
                        .MechanicalP3 = ValueMechanical(2)
                        .MechanicalP4 = ValueMechanical(3)
                        .MechanicalP5 = ValueMechanical(4)
                        .MechanicalP6 = ValueMechanical(5)
                        .MechanicalP7 = ValueMechanical(6)
                        .MechanicalP8 = ValueMechanical(7)
                        .MechanicalP9 = ValueMechanical(8)
                        .OtherInformation1 = ValueOrther(0)
                        .OtherInformation2 = ValueOrther(1)
                        .OtherInformation3 = ValueOrther(2)
                        .OtherInformation4 = ValueOrther(3)
                        .OtherInformation5 = ValueOrther(4)
                        .OtherInformation6 = ValueOrther(5)
                    End With
                    paramTable.Rows.Add(paramRow)

                Catch ex As Exception
                    CustomValidator1.ErrorMessage = ex.Message
                Finally
                    CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")
                End Try
            Next
        Next
        Return paramTable
    End Function

    Private Function P_AddTable_Master(ByVal lan As String, ByVal preview_setting As Boolean) As QualityControlDataSet.LabRecordA2LABDataTable
        Dim paramTable As New QualityControlDataSet.LabRecordA2LABDataTable
        CustomValidator1.ErrorMessage = ""
        Try
            Dim paramRow As QualityControlDataSet.LabRecordA2LABRow
            DT_RemarkRES = DT_getResTable(對照檔.Remark, sSpecifcation, sFinish, sSteel, sCategory, yawuList)
            Dim remarklist As String = ""
            For Each dr As DataRow In DT_RemarkRES.Rows
                remarklist &= dr.Item(Remark_ID) & ","
            Next
            If remarklist.Length > 0 Then
                remarklist = remarklist.Remove(remarklist.Length - 1, 1)
            End If

            DT_Remark_Table = DT_QuerySQL(FS_QuertString_RemarkDAT(remarklist))

            DT_AssayRES = DT_getResTable(對照檔.Assay, sSpecifcation, sFinish, sSteel, sCategory, yawuList)
            Dim assay_id_set As String() = FS_filedtostring(DT_AssayRES, Assay_ID).Split("|")
            Dim assaydat As DataTable = DT_configdat(對照檔.Assay, assay_id_set)


            get_Element_structure("", assaydat)
            get_Mechanical_structure("", assaydat)
            get_Other_structure("", assaydat)


            paramRow = paramTable.NewRow
            With paramRow
                .LABNO = "000000001"
                .Buyer = ""
                .ContractNO = ""
                .LCNO = ""
                .Remark = "附註 Remarks" & vbNewLine & FS_Make_Remark(DT_Remark_Table)
                .T_BaseItem1 = TitleB(0)
                .T_BaseItem2 = TitleB(1)
                .T_BaseItem3 = TitleB(2)
                .T_BaseItem4 = TitleB(3)
                .T_BaseItem5 = TitleB(4)
                .T_BaseItem6 = TitleB(5)
                .T_BaseItem7 = TitleB(6)
                .T_BaseItem8 = TitleB(7)
                .T_BaseItem9 = TitleB(8)
                .T_Element1 = TitleE(0)
                .T_Element2 = TitleE(1)
                .T_Element3 = TitleE(2)
                .T_Element4 = TitleE(3)
                .T_Element5 = TitleE(4)
                .T_Element6 = TitleE(5)
                .T_Element7 = TitleE(6)
                .T_Element8 = TitleE(7)
                .T_Element9 = TitleE(8)
                .T_Element10 = TitleE(9)
                .T_Element11 = TitleE(10)
                .T_Element12 = TitleE(11)
                .T_Element13 = TitleE(12)
                .T_Element14 = TitleE(13)
                .T_Element15 = TitleE(14)
                .T_MechanicalP1 = TitleM(0)
                .T_MechanicalP2 = TitleM(1)
                .T_MechanicalP3 = TitleM(2)
                .T_MechanicalP4 = TitleM(3)
                .T_MechanicalP5 = TitleM(4)
                .T_MechanicalP6 = TitleM(5)
                .T_MechanicalP7 = TitleM(6)
                .T_MechanicalP8 = TitleM(7)
                .T_MechanicalP9 = TitleM(8)
                .T_OtherInformation1 = TitleO(0)
                .T_OtherInformation2 = TitleO(1)
                .T_OtherInformation3 = TitleO(2)
                .T_OtherInformation4 = TitleO(3)
                .T_OtherInformation5 = TitleO(4)
                .T_OtherInformation6 = TitleO(5)
                .R_Element1 = FS_FormatRange(RangeE(0))
                .R_Element2 = FS_FormatRange(RangeE(1))
                .R_Element3 = FS_FormatRange(RangeE(2))
                .R_Element4 = FS_FormatRange(RangeE(3))
                .R_Element5 = FS_FormatRange(RangeE(4))
                .R_Element6 = FS_FormatRange(RangeE(5))
                .R_Element7 = FS_FormatRange(RangeE(6))
                .R_Element8 = FS_FormatRange(RangeE(7))
                .R_Element9 = FS_FormatRange(RangeE(8))
                .R_Element10 = FS_FormatRange(RangeE(9))
                .R_Element11 = FS_FormatRange(RangeE(10))
                .R_Element12 = FS_FormatRange(RangeE(11))
                .R_Element13 = FS_FormatRange(RangeE(12))
                .R_Element14 = FS_FormatRange(RangeE(13))
                .R_Element15 = FS_FormatRange(RangeE(14))
                .R_MechanicalP1 = FS_FormatRange(RangeM(0))
                .R_MechanicalP2 = FS_FormatRange(RangeM(1))
                .R_MechanicalP3 = FS_FormatRange(RangeM(2))
                .R_MechanicalP4 = FS_FormatRange(RangeM(3))
                .R_MechanicalP5 = FS_FormatRange(RangeM(4))
                .R_MechanicalP6 = FS_FormatRange(RangeM(5))
                .R_MechanicalP7 = FS_FormatRange(RangeM(6))
                .R_MechanicalP8 = FS_FormatRange(RangeM(7))
                .R_MechanicalP9 = FS_FormatRange(RangeM(8))

            End With
            paramTable.Rows.Add(paramRow)


        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message
        Finally
            CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")
        End Try
        Return paramTable
    End Function
    Private Function P_AddTable_DetailTitle(ByVal queryTable As DataTable, ByVal preview_setting As Boolean) As QualityControlDataSet.LabRecordA2TableDataTable
        Dim paramTable As New QualityControlDataSet.LabRecordA2TableDataTable
        CustomValidator1.ErrorMessage = ""
        For i As Int32 = 1 To 4
            Dim paramRow As QualityControlDataSet.LabRecordA2TableRow
            paramRow = paramTable.NewRow
            With paramRow
                .LABNO = "000000001"
                .Item = i.ToString
                
            End With
            paramTable.Rows.Add(paramRow)
        Next

        Return paramTable
    End Function
    Private Sub set_lab_config_rule(ByVal fromBaseInfoTable As DataTable)
        sSpecifcation = ""
        sFinish = ""
        sSteel = ""
        sCategory = ""
        Dim item = From dr As DataRow In fromBaseInfoTable.Rows
                   Where dr.Item("ITEM_NO") = 1

        For Each dr As DataRow In item
            Select Case dr.Item("ASSAY_ID").ToString
                Case "AZ09"
                    sSpecifcation = dr.Item("RESULT_VALUE")
                Case "AZ05"
                    sFinish = dr.Item("RESULT_VALUE")
                Case "AZ04"
                    sSteel = dr.Item("RESULT_VALUE")
                Case "AZ06"
                    sCategory = dr.Item("RESULT_VALUE")
            End Select
        Next
    End Sub
    Private Sub set_BaseInfoArray(ByVal coils_set As DataTable, ByVal Item As String)
        ValueBaseInfo = {"", "", "", "", "", "", "", "", ""}
        ValueBaseInfo(0) = FS_getBaseInfoFromLinq(coils_set, "AZ01", Item).ToString.Trim
        ValueBaseInfo(1) = FS_getBaseInfoFromLinq(coils_set, "AZ02", Item).ToString.Trim
        ValueBaseInfo(2) = FS_getBaseInfoFromLinq(coils_set, "AZ03", Item).ToString.Trim
        ValueBaseInfo(3) = FS_getBaseInfoFromLinq(coils_set, "AZ04", Item).ToString.Trim
        ValueBaseInfo(4) = FS_getBaseInfoFromLinq(coils_set, "AZ05", Item).ToString.Trim
        ValueBaseInfo(5) = FS_getBaseInfoFromLinq(coils_set, "AZ06", Item).ToString.Trim
        ValueBaseInfo(6) = FS_getBaseInfoFromLinq(coils_set, "AZ07", Item).ToString.Trim
        ValueBaseInfo(7) = FS_getBaseInfoFromLinq(coils_set, "AZ08", Item).ToString.Trim
        ValueBaseInfo(8) = FS_getBaseInfoFromLinq(coils_set, "AZ09", Item).ToString.Trim
    End Sub
    Private Sub set_ValueElementArray(ByVal fromTable As DataTable, ByVal Item As String)
        Dim index As Int32 = 0
        For Each cells As String In ValueElement
            If CInt(Item) > fromTable.Rows.Count Or index + 1 > fromTable.Columns.Count Then
                ValueElement(index) = ""
                Continue For
            End If
            Try
                ValueElement(index) = fromTable.Rows(CInt(Item) - 1).Item(index)
            Catch ex As Exception
                ValueElement(index) = ""
            End Try
            index += 1
        Next
    End Sub
    Private Sub set_ValueMechanicalArray(ByVal fromTable As DataTable, ByVal Item As String)
        Dim index As Int32 = 0
        For Each cells As String In ValueMechanical
            If CInt(Item) > fromTable.Rows.Count Or index + 1 > fromTable.Columns.Count Then
                ValueMechanical(index) = ""
                Continue For
            End If
            Try
                ValueMechanical(index) = fromTable.Rows(CInt(Item) - 1).Item(index)
            Catch ex As Exception
                ValueMechanical(index) = ""
            End Try
            index += 1
        Next
    End Sub
    Private Sub set_ValueOrtherArray(ByVal fromTable As DataTable, ByVal Item As String)
        Dim index As Int32 = 0
        For Each cells As String In ValueOrther
            If CInt(Item) > fromTable.Rows.Count Or index + 1 > fromTable.Columns.Count Then
                ValueOrther(index) = ""
                Continue For
            End If
            Try
                ValueOrther(index) = fromTable.Rows(CInt(Item) - 1).Item(index)
            Catch ex As Exception
                ValueOrther(index) = ""
            End Try
            index += 1
        Next
    End Sub

    Private Function FS_getBaseInfoFromLinq(ByVal coils_set As DataTable, ByVal AssayID As String, ByVal Item As String)

        Dim coil = From coils As DataRow In coils_set
                   Where coils.Item("ITEM_NO") = Item And coils.Item("ASSAY_ID") = AssayID

        If coil.Count = 0 Then
            Return ""
        End If

        Try
            Return coil.First.Item("RESULT_VALUE")
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Function FS_Make_Remark(ByVal from_remarklist As DataTable) As String
        Dim result As String = ""
        Dim index As Int32 = 0
        For Each dr As DataRow In from_remarklist.Rows
            result &= " " & Chr(97 + index).ToString & "." & " " & dr.Item("CONTEXT") & vbNewLine
            index += 1
        Next

        Return result
    End Function
    Private Function FS_FormatRange(ByVal from_normalrange As String) As String
        If from_normalrange.IndexOf("~") < 0 Then
            Return from_normalrange
        End If
        Return from_normalrange.Insert(from_normalrange.IndexOf("~") + 1, vbNewLine)
    End Function

    Private Function P_AddParam(ByVal fromTag As String, ByVal fromObj As Object) As Microsoft.Reporting.WebForms.ReportParameter
        Dim reportParam As New Microsoft.Reporting.WebForms.ReportParameter(fromTag, fromObj.ToString)
        Return reportParam
    End Function

    Private Function P_AddTable(ByVal fromTag As String, ByVal fromObj As Object) As Microsoft.Reporting.WebForms.ReportDataSource
        Dim rds As New Microsoft.Reporting.WebForms.ReportDataSource()
        rds.Name = fromTag
        rds.Value = fromObj

        Return rds
    End Function

    Protected Sub btn_hideSetting_Click(sender As Object, e As EventArgs) Handles btn_hideSetting.Click
        If Not Request.QueryString.Item("KEY3") = Nothing Then
            sSteel = Server.UrlDecode(Request.QueryString.Item("KEY3")).Trim
            is_preview_setting = True
        End If
        If Not Request.QueryString.Item("KEY4") = Nothing Then
            sCategory = Server.UrlDecode(Request.QueryString.Item("KEY4")).Trim
            is_preview_setting = True
        End If
        If Not Request.QueryString.Item("KEY2") = Nothing Then
            sFinish = Server.UrlDecode(Request.QueryString.Item("KEY2")).Trim
            is_preview_setting = True
        End If
        If Not Request.QueryString.Item("KEY1") = Nothing Then
            sSpecifcation = Server.UrlDecode(Request.QueryString.Item("KEY1")).Trim
            is_preview_setting = True
        End If
        If btn_hideSetting.Text = "顯示設定" Then
            btn_hideSetting.Text = "隱藏設定"
            UI_set_debug_RES_gridview(gv_assay_res_result, 對照檔.Assay, sSpecifcation, sFinish, sSteel, sCategory, yawuList)
            UI_set_debug_RES_gridview(gv_remark_res_result, 對照檔.Remark, sSpecifcation, sFinish, sSteel, sCategory, yawuList)
            UI_set_debug_DAT_gridview(gv_assay_dat_result, 對照檔.Assay, sSpecifcation, sFinish, sSteel, sCategory, yawuList)
            UI_set_debug_DAT_gridview(gv_remark_dat_result, 對照檔.Remark, sSpecifcation, sFinish, sSteel, sCategory, yawuList)
            Panel_detail.Visible = True
        Else
            btn_hideSetting.Text = "顯示設定"
            gv_assay_res_result.DataSource = Nothing
            gv_assay_res_result.DataBind()
            gv_assay_dat_result.DataSource = Nothing
            gv_assay_dat_result.DataBind()
            gv_remark_res_result.DataSource = Nothing
            gv_remark_res_result.DataBind()
            gv_remark_dat_result.DataSource = Nothing
            gv_remark_dat_result.DataBind()
            Panel_detail.Visible = False

        End If
    End Sub

End Class