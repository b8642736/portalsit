Imports QualityControl.LabRecordA2_Edit_Module

Public Class LabRecordA2_Search
    Inherits System.Web.UI.UserControl
    Public Event Event_reFresh父物件(ByVal from主畫面_ActiveTabIndex As LabRecordA2_Main.主畫面_Enum, _
                           ByVal fromLabno As String)
    Public Event Event_reFresh父物件2(ByVal from主畫面_ActiveTabIndex As LabRecordA2_Main.主畫面_Enum, _
                           ByVal fromLabno As String, ByVal from_ds_main As QualityControlDataSet.LabRecordA2DetailsDataTable, _
                           ByVal from_ds_meesage As QualityControlDataSet.LabRecordA2DetailsMessageDataTable)
    Dim WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
    Dim have_miss_data As Boolean = False
    Public Enum 單據狀態
        未開立 = 0
        已開立 = 1
        ALL = 2
    End Enum

    Protected SerchMode As String = "M提貨單號碼"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            P_Init()
            'MakeQryStringToControl()
        End If
    End Sub
    Private Sub P_Init()
        Dim W_Date_E As Date = Now
        Dim W_Date_S As Date = DateAdd(DateInterval.DayOfYear, -7, W_Date_E)
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey1_參照規範(ddl_specif_mother, False)
        ddl_specif_mother.Items.Insert(0, "自訂參照規範")
        ddl_labkind.Items.Add(New ListItem("未開立", 單據狀態.未開立))
        ddl_labkind.Items.Add(New ListItem("已開立", 單據狀態.已開立))
        ddl_labkind.Items.Add(New ListItem("ALL", 單據狀態.ALL))
        ddl_labkind.SelectedIndex = 0
        tbDateS.Text = W_Date_S.ToString("yyyy/MM/dd")
        tbDateE.Text = W_Date_E.ToString("yyyy/MM/dd")
        tbBuyer.Text = ""
        tbCoilno.Text = ""
        ListView2.EditIndex = -1
        lb_labno.Text = ""
        gv_detail.DataSource = Nothing
        gv_detail.DataBind()
    End Sub

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryStringToControl()
        If ddl_UI_Type.SelectedValue = 0 Then
            Dim WhereString As String = Nothing
            Dim ReturnValue As String = Nothing
            Dim buyer As String = ""
            If tbBuyer.Text.Trim.Length > 2 Then
                If tbBuyer.Text.IndexOf(":") > 0 Then
                    buyer = tbBuyer.Text.Split(":")(0).Trim
                Else
                    buyer = tbBuyer.Text.Trim
                End If
            End If
            'ReturnValue = "SELECT BOL02 FROM @#SLS300LB.SL2BOLPF WHERE BOL93='*'" & vbNewLine
            'ReturnValue &= "AND BOL01 > 1050810 " & vbNewLine'
            ReturnValue = "SELECT BOL01,BOL02,BOL03 FROM @#SLS300LB.SL2BOLPF WHERE 1=1" & vbNewLine
            ReturnValue &= "AND BOL01 >= '" & FS_ConvertToTaiwanDate(tbDateS.Text) & "'" & vbNewLine
            ReturnValue &= "AND BOL01 <= '" & FS_ConvertToTaiwanDate(tbDateE.Text) & "'" & vbNewLine
            If Not tb_deliveryNo.Text.Trim = "" Then
                ReturnValue &= "AND BOL02 = " & tb_deliveryNo.Text.Trim & "" & vbNewLine
            End If
            Select Case ddl_labkind.SelectedValue
                Case 單據狀態.未開立
                    ReturnValue &= "AND NOT BOL93='*'" & vbNewLine
                Case 單據狀態.已開立
                    ReturnValue &= "AND BOL93='*'" & vbNewLine
                Case 單據狀態.ALL

            End Select
            If Not buyer = "" Then
                ReturnValue &= "AND SUBSTR(BOL03,1,3) = '" & buyer & "'" & vbNewLine
            End If
            If Not tbCoilno.Text.Trim = "" Then
                ReturnValue &= "AND BOL16 IN(" & FS_SQL_IN(tbCoilno.Text, ",") & ")" & vbNewLine
            End If
            ReturnValue &= "AND NOT BOL06 IN (SELECT CH201 FROM @#SLS300LB.SL2CH2PF WHERE CH202='Y') " & vbNewLine
            ReturnValue &= "GROUP BY BOL01,BOL02,BOL03" & vbNewLine
            ReturnValue &= "Fetch First 100 Row Only"
            'hfSQL0.Value = ""
            hfSQL.Value = ReturnValue & "♒" & Now.ToString
        Else
            Dim ReturnValue As String = Nothing
            ReturnValue &= "SELECT * FROM [QCdb01].[dbo].[LabRecordA2_M]" & vbNewLine
            ReturnValue &= "WHERE 1=1" & vbNewLine
            ReturnValue &= "AND NOT LABREPORT_NO = '000000000'" & vbNewLine
            ReturnValue &= "AND NOT EFF_FLAG = 'Y'" & vbNewLine
            If Not tb_deliveryNo.Text.Trim = "" Then
                ReturnValue &= "AND LABREPORT_NO IN(" & FS_SQL_IN(tb_deliveryNo.Text, ",") & ")" & vbNewLine
            End If
            If Not tbBuyer.Text.Trim = "" Then
                ReturnValue &= "AND CUSTOMER LIKE '%" & tbBuyer.Text & "%'" & vbNewLine
            End If
            If Not tb_deliveryNo.Text.Trim = "" Then
                ReturnValue &= "AND DELIVERY_NO IN(" & FS_SQL_IN(tb_deliveryNo.Text, ",") & ")" & vbNewLine
            End If
           
                Dim DateE As String = Date.Parse(tbDateE.Text).AddDays(1).ToString("yyyy/MM/dd")
                ReturnValue &= "AND SAVE_DATATIME BETWEEN '" & tbDateS.Text & "' and '" & DateE & "'" & vbNewLine



            ReturnValue &= "ORDER BY LABREPORT_NO" & vbNewLine

            'hfSQL.Value = ""
            hfSQL0.Value = ReturnValue & "♒" & Now.ToString
            hf_all_lab.Value = ""
        End If
    End Sub
#End Region

#Region "List:查詢提貨單"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL As String) As List(Of SLS300LB.SL2BOLPF)
        'fromSQL = fromSQL.Split("♒")(0)
        If String.IsNullOrEmpty(fromSQL) Or fromSQL = "" Then
            Return New List(Of SLS300LB.SL2BOLPF)
        End If
        fromSQL = fromSQL.Split("♒")(0)
        Return SLS300LB.SL2BOLPF.CDBSelect(Of SLS300LB.SL2BOLPF)(fromSQL, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function
#End Region
#Region "SystemNote:CRUD"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search_SQL(ByVal fromSQL As String) As List(Of SQLServer.QCDB01.LabRecordA2_M)

        If String.IsNullOrEmpty(fromSQL) Or fromSQL = "" Then
            Return New List(Of SQLServer.QCDB01.LabRecordA2_M)
        End If
        fromSQL = fromSQL.Split("♒")(0)
        Return SQLServer.QCDB01.LabRecordA2_M.CDBSelect(Of SQLServer.QCDB01.LabRecordA2_M)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, fromSQL)
    End Function


    <DataObjectMethod(DataObjectMethodType.Update)>
    Public Function Update(ByVal fromObj As SQLServer.QCDB01.LabRecordA2_M) As Integer
        Return fromObj.CDBUpdate
    End Function

#End Region



    Private Function UpdateNo(ByVal fromObj As SQLServer.QCDB01.SystemNote) As Integer
        Try
            Return fromObj.CDBUpdate
        Catch ex As Exception

        End Try
    End Function

    Protected Sub btnMakelab_Click(sender As Object, e As EventArgs) Handles btnMakelab.Click
        If ddl_UI_Type.SelectedValue = 0 Then
            Makelab(False, "", False)
        Else
            Dim labnos_array As String() = FS_selectedlab(False)
            Dim labnos As String = ""
            For Each labno As String In labnos_array
                labnos &= labno & ";"
            Next
            If labnos.Any Then
                labnos.Remove(labnos.Length - 1)
            End If
            RaiseEvent Event_reFresh父物件(LabRecordA2_Main.主畫面_Enum.列印, labnos)
        End If

    End Sub
    Protected Sub btnMakeAll_Click(sender As Object, e As EventArgs) Handles btnMakeAll.Click
        If ddl_UI_Type.SelectedValue = 0 Then
            Makelab(False, "", True)
        Else
            Dim labnos_array As String() = FS_selectedlab(True)
            Dim labnos As String = ""
            For Each labno As String In labnos_array
                labnos &= labno & ";"
            Next
            If labnos.Any Then
                labnos.Remove(labnos.Length - 1)
            End If
            RaiseEvent Event_reFresh父物件(LabRecordA2_Main.主畫面_Enum.列印, labnos)
        End If
    End Sub
    Protected Sub preview(sender As Object, e As EventArgs)
        Makelab(True, CType(sender, Button).ToolTip.Trim, False)
    End Sub
    
    Private Sub Preview_Init()
        Dim sql_M As New StringBuilder
        Dim sql_D As New StringBuilder
        sql_M.Append("DELETE " & vbNewLine)
        sql_M.Append("FROM [QCdb01].[dbo].[LabRecordA2_M] " & vbNewLine)
        sql_M.Append("WHERE LABREPORT_NO = '000000000' " & vbNewLine)
        DT_QuerySQL(sql_M.ToString)
        sql_D.Append("DELETE " & vbNewLine)
        sql_D.Append("FROM [QCdb01].[dbo].[LabRecordA2_D] " & vbNewLine)
        sql_D.Append("WHERE LABREPORT_NO = '000000000' " & vbNewLine)
        DT_QuerySQL(sql_D.ToString)
    End Sub
    Private Sub Roll_Back(ByVal fromLabno As String)
        Dim sql_M As New StringBuilder
        Dim sql_D As New StringBuilder
        sql_M.Append("DELETE " & vbNewLine)
        sql_M.Append("FROM [QCdb01].[dbo].[LabRecordA2_M] " & vbNewLine)
        sql_M.Append("WHERE LABREPORT_NO = '" & fromLabno & "' " & vbNewLine)
        DT_QuerySQL(sql_M.ToString)
        sql_D.Append("DELETE " & vbNewLine)
        sql_D.Append("FROM [QCdb01].[dbo].[LabRecordA2_D] " & vbNewLine)
        sql_D.Append("WHERE LABREPORT_NO = '" & fromLabno & "' " & vbNewLine)
        DT_QuerySQL(sql_D.ToString)
    End Sub
    
    Protected Sub Makelab(ByVal isPreview As Boolean, ByVal previewLab As String, ByVal print_All As Boolean)

        '=======1.取得選取提貨單======

        Dim selected_deliveryNo_set As String() = FS_selectedlab(print_All)
        Dim spec_deliveryNo_set As String() = {}
        Dim spec_set As String() = {}
        If isPreview And previewLab <> "" Then
            selected_deliveryNo_set = {previewLab}
        End If
        If selected_deliveryNo_set.Length = 0 Then
            Exit Sub
        End If
        Get_custom_specification(spec_deliveryNo_set, spec_set)

        '=======2.取得選取提貨單所有資料======
        Dim queryString As String = FS_getQueryStringForLab(selected_deliveryNo_set)
        Dim selected_lab_set As DataTable = DT_QuerySQL(queryString)
        selected_lab_set.Columns.Add("SIZE")

        For Each custom_spec As String In spec_set
            Dim delivery As String = custom_spec.Split(":")(0)
            Dim spec As String = custom_spec.Split(":")(1)
            Dim coils_set = From dr As DataRow In selected_lab_set
                            Where dr.Item("delivery_Num").ToString.Trim = delivery

            For Each dr As DataRow In coils_set
                dr.Item(參照規範) = spec
                dr.Item("SPECIFCATION" & _RealName) = spec
            Next

        Next
        Dim nowlab As DataTable = selected_lab_set.Clone
        Dim labnoListForPrint As String = ""
        Dim ds_details_main As New QualityControlDataSet.LabRecordA2DetailsDataTable
        Dim ds_details_message As New QualityControlDataSet.LabRecordA2DetailsMessageDataTable

        '=======3.對每張提貨單做處理======
        For Each deliveryNo As String In selected_deliveryNo_set
            Dim errMsg As String = ""
            nowlab.Clear()

            '=======3-1 取得本單所有鋼捲
            Dim coils_set = From dr As DataRow In selected_lab_set.AsEnumerable
                            Where dr.Item("delivery_Num").ToString.Trim = deliveryNo _
                            And dr.Item("delivery_Num2").ToString.Trim = deliveryNo

            For Each coils As DataRow In coils_set
                coils.Item("SIZE") = coils.Item("THICKNESS").ToString.Trim & "mm * " & coils.Item("WIDTH").ToString.Trim & "mm * " & coils.Item("LENGHT").ToString.Trim & "m"
                nowlab.ImportRow(coils)
            Next



            '=======3-2 取得本單設定(本程式假設不同鋼種會拆單  沒拆單去找Key單的人算帳)
           

            Dim sCustomer As String = FS_Customer(nowlab.Rows(0).Item("CUST_NUM"))
            Dim sContractNO As String = nowlab.Rows(0).Item("ORDER_NUM")
            Dim sLCNo As String = ""
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
            Dim baseinfoID As String() = baseItem
            assaydat = clone_format(assayres, assaydat)
            '=======3-3 產生表號
            Dim no As Int32 = CInt(WP_ClsSystemNote.getLev4Content(WP_System_Type, "_表單編號", "下一個號碼"))
            Dim lengthNo As Int32 = CInt(WP_ClsSystemNote.getLev4Content(WP_System_Type, "_表單編號", "號碼長度補足至幾碼"))
            Dim formateNo As String = Space(lengthNo).Replace(" ", "0")
            Dim labno As String = ""

            '=======3-4 處理本單所有鋼捲
            Dim index_coils As Int32 = 1
            Dim list_coils_set As New List(Of SQLServer.QCDB01.LabRecordA2_D)

            For Each coils As DataRow In nowlab.Rows
                Dim coil_num As String = coils.Item(鋼捲號碼).ToString.Trim
                Dim heatno As String = coils.Item(爐號).ToString.Trim
                Dim Finish As String = coils.Item(表面).ToString.Trim
                Dim Steel As String = coils.Item(鋼種).ToString.Trim
                Dim Category As String = coils.Item(料別).ToString.Trim
                Dim Specifcation As String = coils.Item(參照規範).ToString.Trim

                have_miss_data = False
                Dim miss_elements As String = ""
                '=======3-3-1 依據設定取得化性
                Dim AA = From assayitem As DataRow In assaydat
                         Where assayitem.Item("ASSAY_ID").ToString.StartsWith("AA")
                Dim queryString_item = ""
                For Each item As DataRow In AA
                    queryString_item = item.Item("RESULT_TABLE_COLUMN") & "," & vbNewLine
                    Dim formatstring As String = "0." & Space(item.Item("RESULT_FORMAT")).Replace(" ", "0")
                    Dim dt_qc As DataTable = DT_QueryChemical(heatno.Trim, queryString_item)
                    Dim result As String = ""
                    Dim values As Double = 0
                    If dt_qc.Rows.Count = 0 Then
                        result = "  "
                        have_miss_data = True
                        miss_elements &= item.Item("ASSAY_NAME").ToString & ","
                    Else
                        values = dt_qc.Rows(0).Item(0).ToString
                        result = values.ToString(formatstring)
                    End If
                    item.Item("values") = result
                Next

                '=======3-3-2 依據設定取得物性
                Dim AB = From assayitem As DataRow In assaydat
                         Where assayitem.Item("ASSAY_ID").ToString.StartsWith("AB")
                queryString_item = ""
                For Each item As DataRow In AB
                    queryString_item = item.Item("RESULT_TABLE_COLUMN") & vbNewLine
                    Dim formatstring As String = "0." & Space(item.Item("RESULT_FORMAT")).Replace(" ", "0")
                    Dim dt_mc As DataTable = DT_Mechanical(heatno.Trim, queryString_item)
                    Dim result As String = ""
                    Dim values As Double = 0
                    If dt_mc.Rows.Count = 0 Then
                        result = "  "
                        have_miss_data = True
                        miss_elements &= item.Item("ASSAY_NAME").ToString & ","
                    Else
                        values = dt_mc.Rows(0).Item(0).ToString
                        result = values.ToString(formatstring)
                    End If
                    item.Item("values") = result


                Next
                '=======3-3-3 依據設定取得其他資訊
                Dim AC = From assayitem As DataRow In assaydat
                         Where assayitem.Item("ASSAY_ID").ToString.Substring(0, 2) = "AC"
                queryString_item = ""
                For Each item As DataRow In AC
                    queryString_item = item.Item("RESULT_TABLE_COLUMN") & vbNewLine
                    Dim formatstring As String = "0." & Space(item.Item("RESULT_FORMAT")).Replace(" ", "0")
                    Dim dt_o As DataTable = DT_Other(item.Item("RESULT_KIND"), coil_num & "," & heatno, item.Item("ASSAY_ID"))
                    Dim result As String = ""
                    Dim values As Double = 0
                    If dt_o.Rows.Count = 0 Then
                        result = "  "
                        have_miss_data = True
                        miss_elements &= item.Item("ASSAY_NAME").ToString & ","
                    Else
                        values = dt_o.Rows(0).Item(0).ToString
                        If IsNumeric(values) Then
                            result = values.ToString(formatstring)
                        Else
                            result = values.ToString()
                        End If

                    End If
                    item.Item("values") = result
                Next
                If have_miss_data Then
                    miss_elements = miss_elements.Remove(miss_elements.Length - 1)
                    errMsg = "鋼捲:" & coil_num & "  " & miss_elements & ":" & "查無資料"
                    addErrorMessage(ds_details_message, deliveryNo, errMsg)
                End If

                '=======3-3-4 依據設定加入Remark
                Dim remarklist As String = ""
                For Each remarkID As String In remark_id_set
                    remarklist &= remarkID & ","
                Next
                If remarklist.Length > 0 Then
                    remarklist.Remove(remarklist.Length - 1, 1)
                End If
                '=======3-3-4 依據設定檢查欄位資訊
                Dim Check_Rule_Set = From checkitem As DataRow In remarkres.Rows
                                     Where checkitem.Item(Remark_ID).ToString.StartsWith("RC")

                For Each Check_Rule As DataRow In Check_Rule_Set
                    Dim judget_steel As String = Check_Rule.Item("鋼種").ToString.Trim
                    Dim judget_finish As String = Check_Rule.Item("表面類別").ToString.Trim
                    Dim judget_category As String = Check_Rule.Item("材質").ToString.Trim
                    Dim judget_specification As String = Check_Rule.Item("參照規範").ToString.Trim
                    Dim remarkID As String = Check_Rule.Item(Remark_ID).ToString.Trim
                    Dim Check_table As DataTable = DT_check(judget_steel, judget_finish, judget_category, judget_specification, remarkID)
                    Dim Check_Assay_Dat As DataTable = assaydat.Copy


                    If Check_table.Rows.Count > 0 Then
                        For Each check_item As DataRow In Check_table.Rows
                            Dim judget_item As String = check_item.Item(Assay_ID).ToString.Trim
                            Dim judget_item_set = From item As DataRow In assaydat.Rows
                                                  Where item.Item(Assay_ID).ToString.Trim = judget_item

                            Dim judget_item_name As String
                            Dim judget_item_value As String
                            Dim Operators As String
                            Dim target As String
                            Dim result As String
                            If Not judget_item_set.Any Then
                                Continue For
                            End If
                            judget_item_name = judget_item_set.FirstOrDefault.Item("ASSAY_NAME")
                            judget_item_value = judget_item_set.FirstOrDefault.Item("values")
                            Operators = check_item.Item(JUDGET_TYPE)
                            target = check_item.Item(JUDGET_DOC)
                            result = good_judget(judget_item_value, Operators, target)
                            Select Case result
                                Case 判定結果.正常
                                    Debug.WriteLine(remarkID & ":" & judget_item_name & ":正常")
                                Case 判定結果.不符
                                    errMsg = "鋼捲:" & coil_num & "  " & remarkID & ":" & judget_item_name & ":不符" & vbNewLine
                                    errMsg &= "     " & judget_item_name & ":" & judget_item_value & " " & FS_Operator(Operators) & " " & target & "不符"
                                    addErrorMessage(ds_details_message, deliveryNo, errMsg)
                                    Debug.WriteLine(errMsg)
                                Case 判定結果.格式錯誤
                                    errMsg = "鋼捲:" & coil_num & "  " & remarkID & ": 格式錯誤(請檢察是否改用文字類別判定)" & vbNewLine
                                    errMsg &= "     " & judget_item_name & ":" & judget_item_value & " " & "非數字"
                                    addErrorMessage(ds_details_message, deliveryNo, errMsg)
                                    Debug.WriteLine(errMsg)
                                Case 判定結果.未知的運算元
                                    errMsg = "鋼捲:" & coil_num & "  " & remarkID & ":" & Operators & ":未知的運算元"
                                    addErrorMessage(ds_details_message, deliveryNo, errMsg)
                                    Debug.WriteLine(errMsg)
                            End Select
                        Next
                    Else
                        errMsg = "鋼捲:" & coil_num & "  " & remarkID & ":找不到相對應的判定規則"
                        addErrorMessage(ds_details_message, deliveryNo, errMsg)
                        Debug.WriteLine(errMsg)
                    End If
                Next

                '=======
                If index_coils = 1 Then
                    If isPreview Then
                        Preview_Init()
                        labno = "000000000"
                    Else
                        labno = (Now.Year - 1911).ToString & (Now.Month).ToString("00") & no.ToString(formateNo)
                    End If

                    Dim readyLab As New SQLServer.QCDB01.LabRecordA2_M
                    With readyLab
                        .LABREPORT_NO = labno
                        .CUSTOMER = sCustomer
                        .CONTRACT_NO = sContractNO
                        .DELIVERY_NO = deliveryNo
                        .LC_NO = ""
                        .REMARK_LIST = remarklist
                        .APPEND_LIST = yawuList
                        .SAVE_DATATIME = DateAndTime.Now
                    End With
                    Try
                        If errMsg = "" Then
                            readyLab.CDBInsert()
                            'labnoListForPrint &= labno & ";"
                        End If
                    Catch ex As Exception
                        errMsg = "SQL資料庫:" & ex.ToString
                        addErrorMessage(ds_details_message, deliveryNo, errMsg)
                    End Try

                End If
                For Each item As String In baseinfoID
                    Dim insertObj As New SQLServer.QCDB01.LabRecordA2_D
                    With insertObj
                        .LABREPORT_NO = labno
                        .ASSAY_ID = item
                        .ITEM_NO = index_coils
                        .RESULT_VALUE = coils.Item(FS_dcNams_ColisBaseItem(item)).ToString.Trim
                    End With
                    Try
                        If errMsg = "" Then
                            insertObj.CDBInsert()
                            'labnoListForPrint &= labno & ";"
                        End If
                    Catch ex As Exception
                        errMsg = "SQL資料庫:" & ex.ToString
                        addErrorMessage(ds_details_message, deliveryNo, errMsg)
                    End Try
                Next
                For Each item As DataRow In assaydat.Rows
                    Dim insertObj As New SQLServer.QCDB01.LabRecordA2_D
                    With insertObj
                        .LABREPORT_NO = labno
                        .ASSAY_ID = item.Item("ASSAY_ID")
                        .ITEM_NO = index_coils
                        .RESULT_VALUE = IIf(IsDBNull(item.Item("values")), "", item.Item("values"))
                    End With

                    Try
                        If errMsg = "" Then
                            insertObj.CDBInsert()
                            'labnoListForPrint &= labno & ";"
                        End If
                    Catch ex As Exception
                        errMsg = "SQL資料庫:" & ex.ToString
                        addErrorMessage(ds_details_message, deliveryNo, errMsg)
                    End Try
                Next
                index_coils += 1
                If index_coils > 4 Then
                    index_coils = 1
                    no += 1
                End If
            Next
            If errMsg = "" Then
                '新增成功單號
                labnoListForPrint &= labno & ";"
                addResult(ds_details_main, deliveryNo, "SUCESS")
            Else
                '新增失敗單號
                Roll_Back(labno)
                addResult(ds_details_main, deliveryNo, "FAILD")
            End If


            If Not isPreview And errMsg = "" Then
                Dim newNoObj As New SQLServer.QCDB01.SystemNote
                With newNoObj
                    .SYSTEM_TYPE = WP_System_Type
                    .NOTE_TYPE = "_表單編號"
                    .NOTE_ID = "下一個號碼"
                    .CONTENT = (no + 1).ToString
                End With

                newNoObj.CDBUpdate()
            End If

            If cb_debugmode.Checked Then
                GridView1.DataSource = assayres
                GridView1.DataBind()
                GridView2.DataSource = assaydat
                GridView2.DataBind()
                GridView3.DataSource = nowlab
                GridView3.DataBind()
            Else
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                GridView2.DataSource = Nothing
                GridView2.DataBind()
                GridView3.DataSource = Nothing
                GridView3.DataBind()
            End If

        Next
        If isPreview Then
            RaiseEvent Event_reFresh父物件2(LabRecordA2_Main.主畫面_Enum.列印, "000000000", ds_details_main, ds_details_message)
        Else
            If labnoListForPrint.IndexOf(";") > 0 Then
                labnoListForPrint = labnoListForPrint.Remove(labnoListForPrint.Length - 1)
            End If
            RaiseEvent Event_reFresh父物件2(LabRecordA2_Main.主畫面_Enum.列印, labnoListForPrint, ds_details_main, ds_details_message)
        End If


        '=======1.取得選取提貨單======
        '=======1.取得選取提貨單======
        '=======1.取得選取提貨單======
    End Sub
    Private Sub Get_custom_specification(ByRef devily_set As String(), ByRef specification_set As String())
        Dim listview As ListView
        Dim ddl_specification As DropDownList
        Dim S_devily_Set As String = ""
        Dim S_specification As String = ""
        If ddl_UI_Type.SelectedValue = 0 Then
            listview = ListView2
        Else
            Exit Sub
        End If
        For Each lvItem As ListViewItem In listview.Items
            ddl_specification = lvItem.FindControl("ddl_Specification")
            If ddl_specification.SelectedIndex <> 0 Then
                S_devily_Set &= ddl_specification.ToolTip.ToString.Trim & "|"
                S_specification &= ddl_specification.ToolTip.ToString.Trim & ":" & ddl_specification.Text.Trim & "|"
            End If
        Next
        If S_devily_Set.Trim = "" Or S_specification = "" Then
            devily_set = {}
            specification_set = {}
            Exit Sub
        End If
        S_devily_Set = S_devily_Set.Remove(S_devily_Set.Length - 1)
        S_specification = S_specification.Remove(S_specification.Length - 1)
        devily_set = S_devily_Set.Split("|")
        specification_set = S_specification.Split("|")
    End Sub
    Private Function FS_selectedlab(ByVal print_all As Boolean) As String()
        Dim selected_lab As String = ""
        Dim Result As String()
        Dim listview As ListView
        If ddl_UI_Type.SelectedValue = 0 Then
            listview = ListView2
        Else
            listview = ListView1
        End If


        If print_all Then
            If ddl_UI_Type.SelectedValue = 0 Then
                Dim all_list As List(Of SLS300LB.SL2BOLPF) = Search(hfSQL.Value)
                For Each item As SLS300LB.SL2BOLPF In all_list
                    selected_lab &= item.BOL02.Trim & "|"
                Next
                If selected_lab.Trim = "" Then
                    Return {}
                End If
            Else
                Dim all_list As List(Of SQLServer.QCDB01.LabRecordA2_M) = Search_SQL(hfSQL0.Value)
                For Each item As SQLServer.QCDB01.LabRecordA2_M In all_list
                    selected_lab &= item.LABREPORT_NO.Trim & "|"
                Next
                If selected_lab.Trim = "" Then
                    Return {}
                End If
            End If

            selected_lab = selected_lab.Remove(selected_lab.Length - 1)
            Result = selected_lab.Split("|")
        Else
            Dim chkSelect As CheckBox
            Dim lab As Label
            For Each lvItem As ListViewItem In listview.Items
                chkSelect = lvItem.FindControl("cb_Select")
                If chkSelect.Checked = True Then
                    lab = lvItem.FindControl("BOL02Label")
                    If ddl_UI_Type.SelectedValue = 0 Then
                        selected_lab &= lab.Text.Trim & "|"
                    Else
                        selected_lab &= lab.ToolTip.Trim & "|"
                    End If

                End If
            Next
            If selected_lab.Trim = "" Then
                Return {}
            End If
            selected_lab = selected_lab.Remove(selected_lab.Length - 1)
            Result = selected_lab.Split("|")
        End If

        Return Result
    End Function

    
    Private Function FS_getQueryStringForLab(labset As String()) As String
        Dim queryString As String = ""
        Dim labsetString As String = ""
        For Each lab As String In labset
            labsetString &= lab & ","
        Next
        labsetString = labsetString.Remove(labsetString.Length - 1)
        queryString &= ("EXEC QCdb01.dbo.[PD_AS400_鋼捲基本資訊] @from查詢模式 = 'M提貨單號碼',@from查詢號碼清單='" & labsetString & "'")
        Return queryString
        'Dim queryString As String = ""
        'Dim nowindex as Int32 = 0
        'queryString = "SELECT * FROM @#SLS300LB.SL2BOLPF WHERE 1=1" & vbNewLine
        'queryString &= "AND BOL01 > 1050410 " & vbNewLine
        'If labset.Length = 1 Then
        '    queryString &= "AND BOL02 = '" & labset(0) & "'" & vbNewLine
        'Else
        '    For Each lab As String In labset
        '        If nowindex = 0 Then
        '            queryString &= "AND (BOL02 = '" & lab & "'" & vbNewLine
        '        ElseIf nowindex = labset.Length - 1 Then
        '            queryString &= "OR BOL02 = '" & lab & "')" & vbNewLine
        '        Else
        '            queryString &= "OR BOL02 = '" & lab & "'" & vbNewLine
        '        End If
        '    Next
        'End If
        'Return queryString
    End Function


    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        lbMessage.Text = ""
        Try
            'If cb_Bydate.Checked Then
            '    Date.Parse(tbDateS.Text)
            '    Date.Parse(tbDateE.Text)
            'End If
            Date.Parse(tbDateS.Text)
            Date.Parse(tbDateE.Text)
        Catch ex As Exception
            lbMessage.Text = "Error：請輸入正確時間格式"
            Exit Sub
        End Try
        '1050909 by renhsin
        'ListView2.EditIndex = -1
        btn_hideSetting_Click(Nothing,Nothing)
        'btn_hidedetail_Click(Nothing, Nothing)
        MakeQryStringToControl()
    End Sub

    Protected Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        Dim chkSelect As CheckBox
        If ddl_UI_Type.SelectedValue = 0 Then
            For Each lvRow As ListViewItem In ListView2.Items()
                chkSelect = lvRow.FindControl("cb_Select")
                chkSelect.Checked = True
            Next
        Else
            For Each lvRow As ListViewItem In ListView1.Items()
                chkSelect = lvRow.FindControl("cb_Select")
                chkSelect.Checked = True
            Next
        End If
    End Sub
    Protected Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        Dim chkSelect As CheckBox
        Dim ddl_sepcif As DropDownList
        If ddl_UI_Type.SelectedValue = 0 Then
            For Each lvRow As ListViewItem In ListView2.Items()
                chkSelect = lvRow.FindControl("cb_Select")
                ddl_sepcif = lvRow.FindControl("ddl_Specification")
                chkSelect.Checked = False
                ddl_sepcif.SelectedIndex = 0
            Next
        Else
            For Each lvRow As ListViewItem In ListView1.Items()
                chkSelect = lvRow.FindControl("cb_Select")
                chkSelect.Checked = False
            Next
        End If
        
    End Sub

    Public Sub P_reFresh子物件()
        MakeQryStringToControl()
        ListView2.DataBind()
    End Sub
    Protected Sub btnPrint_Click(sender As Object, e As EventArgs)
        Dim labno As String = CType(sender, Button).ToolTip.Trim
        RaiseEvent Event_reFresh父物件(NonRadioactive_Main.主畫面_Enum.列印, labno)
    End Sub
    Protected Sub btnView_Click(sender As Object, e As EventArgs)
        Dim labno As String = CType(sender, Button).ToolTip.Trim
        RaiseEvent Event_reFresh父物件(NonRadioactive_Main.主畫面_Enum.編修, labno)
    End Sub

    Private Function FS_dcNams_ColisBaseItem(ByVal fromBaseItem As String) As String
        Select Case fromBaseItem
            Case "AZ01"
                Return "COIL_NUM"
            Case "AZ02"
                Return "HEAT_NO"
            Case "AZ03"
                Return "PRODUCT"
            Case "AZ04"
                Return "STEEL_GRAGE" & _RealName
            Case "AZ05"
                Return "FINISH" & _RealName
            Case "AZ06"
                Return "CATEGORY" & _RealName
            Case "AZ07"
                Return "SIZE"
            Case "AZ08"
                Return "NETWEIGHT"
            Case "AZ09"
                Return "SPECIFCATION" & _RealName
        End Select
        Return ""
    End Function
    Private Function FS_detail_Chinese_Name(ByVal fromBaseItem As String) As String
        Select Case fromBaseItem
            Case "BOL01"
                Return "日期"
            Case "BOL03"
                Return "報價單號"
            Case "COILSNO"
                Return "鋼捲編號"
            Case "BOL05"
                Return "鋼種"
            Case "BOL06"
                Return "表面"
            Case "SIZE"
                Return "產品尺寸"
            Case "BOL14"
                Return "淨重"
            Case "STEEL_GRAGE_DISPLAY"
                Return "鋼種"
            Case "FINISH_DISPLAY"
                Return "表面"
            Case Else
                Return fromBaseItem
        End Select
        Return ""
    End Function

    Protected Sub btn_ShowDetail_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim Detail_Column As String() = {"COIL_NUM", "STEEL_GRAGE_DISPLAY", "FINISH_DISPLAY", "SIZE", "NETWEIGHT"}
        Dim DT_Detail As DataTable = DT_QuerySQL("EXEC QCdb01.dbo.[PD_AS400_鋼捲基本資訊] @from查詢模式 = 'M提貨單號碼',@from查詢號碼清單='" & btn.ToolTip.Trim & "'")
        Dim result As New DataTable
        DT_Detail.Columns.Add("SIZE")
        For Each coils As DataRow In DT_Detail.Rows
            coils.Item("SIZE") = coils.Item("THICKNESS").ToString.Trim & "mm * " & coils.Item("WIDTH").ToString.Trim & "mm * " & coils.Item("LENGHT").ToString.Trim & "m"
        Next
        For Each ColName As String In Detail_Column
            result.Columns.Add(ColName)
        Next
        For Each dr As DataRow In DT_Detail.Rows
            result.ImportRow(dr)
        Next
        result = FD_convert_columnName(result)
        For Each col As DataColumn In result.Columns
            col.ColumnName = FS_detail_Chinese_Name(col.ColumnName)
        Next
        lb_labno.Text = "提貨單號 : " & btn.ToolTip
        gv_detail.DataSource = result
        gv_detail.DataBind()
        btn_hidedetail.Visible = True
    End Sub

    Protected Sub ListView2_PagePropertiesChanged(sender As Object, e As EventArgs) Handles ListView2.PagePropertiesChanged
        If Not ListView2.EditIndex = -1 Then
            ListView2.EditIndex = -1
        End If
        lb_labno.Text = ""
        gv_detail.DataSource = Nothing
        gv_detail.DataBind()
        btn_hideSetting_Click(Nothing, Nothing)
    End Sub
    '1050909 by renhsin
    Private Sub ListView2_ItemDataBound(sender As Object, e As ListViewItemEventArgs) Handles ListView2.ItemDataBound
        Dim listViewOjb As ListView = CType(sender, ListView)
        Dim ddl As DropDownList = e.Item.FindControl("ddl_Specification")
        For Each item As ListItem In ddl_specif_mother.Items
            ddl.Items.Add(item)
        Next
        If listViewOjb.EditIndex > -1 Then
            Dim dataitemObj As ListViewDataItem = CType(e.Item, ListViewDataItem)
            If dataitemObj.DisplayIndex <> listViewOjb.EditIndex Then
                e.Item.Visible = False
            End If
        End If
    End Sub
    '1050909 by renhsin    
    Protected Sub btn_hidedetail_Click(sender As Object, e As EventArgs) Handles btn_hidedetail.Click
        If Not ListView2.EditIndex = -1 Then
            ListView2.EditIndex = -1
        End If
        btn_hidedetail.Visible = False
        lb_labno.Text = ""
        gv_detail.DataSource = Nothing
        gv_detail.DataBind()
    End Sub
    Private Sub ListView1_ItemDataBound(sender As Object, e As ListViewItemEventArgs) Handles ListView1.ItemDataBound
        Dim listViewOjb As ListView = CType(sender, ListView)

        If listViewOjb.EditIndex > -1 Then
            Dim dataitemObj As ListViewDataItem = CType(e.Item, ListViewDataItem)
            If dataitemObj.DisplayIndex <> listViewOjb.EditIndex Then
                e.Item.Visible = False
            End If
        End If
    End Sub


    Protected Sub btn_showSetting_Click(sender As Object, e As EventArgs)
        Panel_detail.Visible = True
        tabc_showdetail.ActiveTabIndex = 0
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

        lb_4Key1.Text = "鋼種：" & sSteel & "　材質：" & sCategory & "　表面類別：" & sFinish & "　參照規範：" & sSpecifcation
        lb_4Key2.Text = "鋼種：" & sSteel & "　材質：" & sCategory & "　表面類別：" & sFinish & "　參照規範：" & sSpecifcation

        UI_set_debug_RES_gridview(gv_assay_res_result, 對照檔.Assay, sSpecifcation, sFinish, sSteel, sCategory, yawuList)
        UI_set_debug_RES_gridview(gv_remark_res_result, 對照檔.Remark, sSpecifcation, sFinish, sSteel, sCategory, yawuList)
        UI_set_debug_DAT_gridview(gv_assay_dat_result, 對照檔.Assay, sSpecifcation, sFinish, sSteel, sCategory, yawuList)
        UI_set_debug_DAT_gridview(gv_remark_dat_result, 對照檔.Remark, sSpecifcation, sFinish, sSteel, sCategory, yawuList)

        '' 以下為產生檢驗項目小數位數 套用前與套用後表格code
        gv_coils.DataSource = FD_ConvertToDebugMode(nowlab, False)
        gv_coils.DataBind()
        'btn_hideSetting.Visible = True
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
                Try
                    Dim values As Double = DT_QueryChemical(heatno.Trim, queryString_item).Rows(0).Item(0).ToString
                    item.Item("source_values") = values.ToString
                    coils_source_chemical.Item(item.Item(Assay_ID)) = item.Item("source_values")
                    Dim result As String = values.ToString(formatstring)
                    item.Item("format_values") = result
                    coils_format_chemical.Item(item.Item(Assay_ID)) = item.Item("format_values")
                Catch ex As Exception
                    item.Item("source_values") = "  "
                    coils_source_chemical.Item(item.Item(Assay_ID)) = item.Item("source_values")
                    Dim result As String = "  "
                    item.Item("format_values") = result
                    coils_format_chemical.Item(item.Item(Assay_ID)) = item.Item("format_values")
                End Try
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
        If Not ListView1.EditIndex = -1 Then
            ListView1.EditIndex = -1
        End If
        If Not ListView2.EditIndex = -1 Then
            ListView2.EditIndex = -1
        End If

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

    'Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
    '    'MakeQryStringToControl()
    'End Sub

    Protected Sub gv_coils_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv_coils.RowCommand
        If e.CommandName = "show_Chemical" Then
            Dim coils_index As Int32 = e.CommandArgument
            Dim fno As String = gv_coils.Rows(coils_index).Cells(6).Text.Trim
        End If
    End Sub



    Protected Sub ddl_UI_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_UI_Type.SelectedIndexChanged
        'MakeQryStringToControl()
        'btn_hidedetail_Click(Nothing, Nothing)

        tb_deliveryNo.Text = ""
        tbBuyer.Text = ""
        tbCoilno.Text = ""
       

        If ddl_UI_Type.SelectedValue = 0 Then
            If Not ListView2.EditIndex = -1 Then
                ListView2.EditIndex = -1
            End If

            ListView2.Visible = True
            ListView1.Visible = False
            tbBuyer_AutoCompleteExtender.Enabled = True
            lb_cus.Text = "客戶代碼："
            lb_buyerRemark.Text = "(輸入客戶代碼)"
            tbCoilno.Enabled = True
            ddl_labkind.Enabled = True
            'btn_hideSetting_Click(Nothing, Nothing)
        Else
            If Not ListView1.EditIndex = -1 Then
                ListView1.EditIndex = -1
            End If

            ListView2.Visible = False
            ListView1.Visible = True
            tbBuyer_AutoCompleteExtender.Enabled = False
            lb_cus.Text = "客戶名稱："
            lb_buyerRemark.Text = "(輸入客戶名稱)"
            tbCoilno.Enabled = False
            ddl_labkind.Enabled = False
            'btn_hideSetting_Click(Nothing, Nothing)
        End If
        
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

    End Sub

    
    Protected Sub ListView1_PagePropertiesChanged(sender As Object, e As EventArgs) Handles ListView1.PagePropertiesChanged
        If Not ListView1.EditIndex = -1 Then
            ListView1.EditIndex = -1
        End If
        btn_hideSetting_Click(Nothing, Nothing)
    End Sub

    
End Class
