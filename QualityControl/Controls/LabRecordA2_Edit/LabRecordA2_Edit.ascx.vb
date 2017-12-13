
Public Class LabRecordA2_Edit
    Inherits System.Web.UI.UserControl
    Public Event Event_reFresh父物件(ByVal from主畫面_ActiveTabIndex As NonRadioactive_Main.主畫面_Enum, _
                           ByVal fromLabno As String)
    Protected SerchMode As String = "M提貨單號碼"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            P_Init()
            MakeQryStringToControl()

        End If
    End Sub

    Private Sub P_Init()
        Dim W_Date_E As Date = Now
        Dim W_Date_S As Date = DateAdd(DateInterval.Month, -1, W_Date_E)
        tbDateS.Text = W_Date_S.ToString("yyyy/MM/dd")
        tbDateE.Text = W_Date_E.ToString("yyyy/MM/dd")

    End Sub
#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryStringToControl()
        Dim ReturnValue As String = Nothing
        ReturnValue &= "SELECT * FROM [QCdb01].[dbo].[LabRecordA2_M]" & vbNewLine
        ReturnValue &= "WHERE 1=1" & vbNewLine
        ReturnValue &= "AND NOT LABREPORT_NO = '000000000'" & vbNewLine
        If Not tbLabno.Text.Trim = "" Then
            ReturnValue &= "AND LABREPORT_NO IN(" & FS_SQL_IN(tbLabno.Text, ",") & ")" & vbNewLine
        End If
        If Not tbBuyer.Text.Trim = "" Then
            ReturnValue &= "AND CUSTOMER LIKE '%" & tbBuyer.Text & "%'" & vbNewLine
        End If
        If Not tb_deliveryNo.Text.Trim = "" Then
            ReturnValue &= "AND DELIVERY_NO IN(" & FS_SQL_IN(tb_deliveryNo.Text, ",") & ")" & vbNewLine
        End If
        If Not tb_orderNo.Text.Trim = "" Then
            ReturnValue &= "AND CONTRACT_NO IN(" & FS_SQL_IN(tb_orderNo.Text, ",") & ")" & vbNewLine
        End If

        If ckBydate.Checked Then
            Dim DateE As String = Date.Parse(tbDateE.Text).AddDays(1).ToString("yyyy/MM/dd")
            ReturnValue &= "AND SAVE_DATATIME BETWEEN '" & tbDateS.Text & "' and '" & DateE & "'" & vbNewLine
        End If


        ReturnValue &= "ORDER BY LABREPORT_NO desc" & vbNewLine


        hfSQL.Value = ReturnValue
    End Sub
#End Region

#Region "SystemNote:CRUD"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL As String) As List(Of SQLServer.QCDB01.LabRecordA2_M)
        If String.IsNullOrEmpty(fromSQL) Or fromSQL = "" Then
            Return New List(Of SQLServer.QCDB01.LabRecordA2_M)
        End If
        Return SQLServer.QCDB01.LabRecordA2_M.CDBSelect(Of SQLServer.QCDB01.LabRecordA2_M)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, fromSQL)
    End Function


    <DataObjectMethod(DataObjectMethodType.Update)>
    Public Function Update(ByVal fromObj As SQLServer.QCDB01.LabRecordA2_M) As Integer
        Return fromObj.CDBUpdate
    End Function

#End Region


    Protected Sub btn_showSetting_Click(sender As Object, e As EventArgs)
        Panel_detail.Visible = True
        Dim btn As Button = CType(sender, Button)
        Dim queryString As String = "EXEC QCdb01.dbo.[PD_AS400_鋼捲基本資訊] @from查詢模式 = 'M提貨單號碼',@from查詢號碼清單='" & btn.ToolTip & "'"
        Dim nowlab As DataTable = DT_QuerySQL(queryString)
        Dim sSpecifcation As String = nowlab.Rows(0).Item(參照規範)
        Dim sFinish As String = nowlab.Rows(0).Item(表面)
        Dim sSteel As String = nowlab.Rows(0).Item(鋼種)
        Dim sCategory As String = nowlab.Rows(0).Item(料別)
        ' 0912 業務附註
        Dim yawuList As String = nowlab.Rows(0).Item(業務附註)
        Dim assayres As DataTable = DT_getResTable(對照檔.Assay, sSpecifcation, sFinish, sSteel, sCategory, yawuList)
        Dim remarkres As DataTable = DT_getResTable(對照檔.Remark, sSpecifcation, sFinish, sSteel, sCategory, yawuList)
        Dim assay_id_set As String() = FS_filedtostring(assayres, Assay_ID).Split("|")
        Dim remark_id_set As String() = FS_filedtostring(remarkres, Remark_ID).Split("|")
        Dim assaydat As DataTable = DT_configdat(對照檔.Assay, assay_id_set)
        assaydat.Columns.Add("values")
        Dim remarkdat As DataTable = DT_configdat(對照檔.Remark, remark_id_set)

        UI_set_debug_RES_gridview(gv_assay_res_result, 對照檔.Assay, sSpecifcation, sFinish, sSteel, sCategory, yawuList)
        UI_set_debug_RES_gridview(gv_remark_res_result, 對照檔.Remark, sSpecifcation, sFinish, sSteel, sCategory, yawuList)
        UI_set_debug_DAT_gridview(gv_assay_dat_result, 對照檔.Assay, sSpecifcation, sFinish, sSteel, sCategory, yawuList)
        UI_set_debug_DAT_gridview(gv_remark_dat_result, 對照檔.Remark, sSpecifcation, sFinish, sSteel, sCategory, yawuList)

        '' 以下為產生檢驗項目小數位數 套用前與套用後表格code
        gv_coils.DataSource = FD_ConvertToDebugMode(nowlab, False)
        gv_coils.DataBind()
        btn_hideSetting.Visible = True
        assaydat = DT_configdat(對照檔.Assay, assay_id_set)
        assaydat.Columns.Add("source_values")
        assaydat.Columns.Add("format_values")
        assaydat = clone_format(assayres, assaydat)
        Dim DT_values As New DataTable
        DT_values.Columns.Add("鋼捲號碼")
        For Each dr As DataRow In assaydat.Rows
            If dr.Item(Assay_ID).ToString.StartsWith("AA") Then
                DT_values.Columns.Add(dr.Item(Assay_ID))
            End If
        Next
        gv_chemical.DataSource = DT_values
        nowlab = DT_QuerySQL(queryString)
        For Each dr As DataRow In nowlab.Rows
            Dim heatno As String = dr.Item("CAST_NO").ToString.Trim
            Dim AA = From assayitem As DataRow In assaydat
                     Where assayitem.Item("ASSAY_ID").ToString.Substring(0, 2) = "AA"
            Dim queryString_item = ""
            Dim coils_source_chemical As DataRow = DT_values.NewRow
            Dim coils_format_chemical As DataRow = DT_values.NewRow
            coils_source_chemical.Item("鋼捲號碼") = dr.Item("COIL_NUM") & "(原始值)"
            coils_format_chemical.Item("鋼捲號碼") = dr.Item("COIL_NUM") & "(格式化)"
            For Each item As DataRow In AA
                queryString_item = item.Item("RESULT_TABLE_COLUMN") & "," & vbNewLine
                Dim formatstring As String = "0." & Space(item.Item("RESULT_FORMAT")).Replace(" ", "0")
                Dim values As Double = DT_QueryChemical(heatno.Trim, queryString_item).Rows(0).Item(0).ToString
                item.Item("source_values") = values.ToString
                coils_source_chemical.Item(item.Item(Assay_ID)) = item.Item("source_values")
                Dim result As String = values.ToString(formatstring)
                item.Item("format_values") = result
                coils_format_chemical.Item(item.Item(Assay_ID)) = item.Item("format_values")
            Next
            DT_values.Rows.Add(coils_source_chemical)
            DT_values.Rows.Add(coils_format_chemical)
        Next
        For Each col As DataColumn In DT_values.Columns
            Dim AA = From assayitem As DataRow In assaydat
                     Where assayitem.Item("ASSAY_ID") = col.ColumnName

            If AA.Count > 0 Then
                col.ColumnName = (AA.First.Item("ASSAY_NAME") & "(" & AA.First.Item("RESULT_FORMAT") & ")")
            End If
        Next

        gv_chemical.DataSource = DT_values
        gv_chemical.DataBind()


    End Sub

    Protected Sub btn_invalid_Click(sender As Object, e As EventArgs)
        Dim sqlstring As String = ""
        Dim labno As String = CType(sender, Button).ToolTip.Trim
        sqlstring &= "UPDATE [QCdb01].[dbo].[LabRecordA2_M] set EFF_FLAG = 'Y'" & vbNewLine
        sqlstring &= "WHERE LABREPORT_NO = '" & labno & "'" & vbNewLine
        DT_QuerySQL(sqlstring)
        hfSQL.Value = ""
        MakeQryStringToControl()
        ListView1.DataBind()
    End Sub

    Protected Sub btn_print_Click(sender As Object, e As EventArgs)
        Dim labno As String = CType(sender, Button).ToolTip.Trim
        RaiseEvent Event_reFresh父物件(LabRecordA2_Main.主畫面_Enum.列印, labno)
    End Sub

    Protected Sub btn_hideSetting_Click(sender As Object, e As EventArgs) Handles btn_hideSetting.Click
        ListView1.EditIndex = -1

        gv_assay_res_result.DataSource = Nothing
        gv_assay_res_result.DataBind()
        gv_assay_dat_result.DataSource = Nothing
        gv_assay_dat_result.DataBind()

        gv_remark_res_result.DataSource = Nothing
        gv_remark_res_result.DataBind()
        gv_remark_dat_result.DataSource = Nothing
        gv_remark_dat_result.DataBind()
        gv_coils.DataSource = Nothing
        gv_coils.DataBind()
        Panel_detail.Visible = False
        btn_hideSetting.Visible = False
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakeQryStringToControl()
    End Sub

    Protected Sub gv_coils_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv_coils.RowCommand
        If e.CommandName = "show_Chemical" Then
            Dim coils_index As Int32 = e.CommandArgument
            Dim fno As String = gv_coils.Rows(coils_index).Cells(6).Text.Trim
        End If
    End Sub

   
End Class