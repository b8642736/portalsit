''' <summary>
''' 利用ViewState儲存放置已新增鋼捲的DataTable (tempTable)
''' </summary>
''' <remarks></remarks>
Public Class NonRadioactive_Edit
    Inherits System.Web.UI.UserControl

    Dim WP_System_Type As String = "品保_無輻射證明"
    Dim dot_NOTE_Type As String = "_分隔符號"
    Dim FPinfo_NOTE_Type As String = "第一頁_內容"
    Dim FPtitle_NOTE_Type As String = "第一頁_標題"
    Dim FPpeople_NOTE_Type As String = "第一頁_偵檢人員"
    Dim SPinfo_NOTE_Type As String = "第二頁_內容"
    Dim WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
    Dim WP_LangCode As String
    Dim WP_SplitStr As String
    Dim subLabFormate As String = "000"
    Private Q_qcddl As String = "ddlQCman"
    Private Const Q_Table1_Row As Integer = 11

    Public Event Event_reFresh父物件(ByVal from主畫面_ActiveTabIndex As NonRadioactive_Main.主畫面_Enum, _
                           ByVal fromLabno As String, ByVal subno As Int32)

    Enum MultiView1_Index
        目前清單 = 0
        新增資料 = 1
    End Enum

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            P_Init()
        End If
    End Sub
    Public Sub P_reFresh子物件(ByVal unlock As Boolean)
        P_Init()
        UnLockAllItem(unlock)
    End Sub
    Public Sub P_reFresh子物件(ByVal labno As String, ByVal subno As Int32)
        P_Init()
        Dim queryCol As String = "SELECT * FROM [dbo].[LabRecordA1_D] " & vbNewLine
        queryCol &= "WHERE LAB_REPORTNO = '" & labno & "'" & vbNewLine
        queryCol &= "AND LAB_REPORTNO2 = '" & subno & "'" & vbNewLine
        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(queryCol)
        ViewState("tempViewTable") = dtResult
        GridView5.DataSource = dtResult
        GridView5.DataBind()
        UnLockAllItem(False)
        lbBuyer.Text = "單號：" & labno
        lb_Err.Text = ""
        tb_splitnum.Text = ""
    End Sub

    Private Sub UnLockAllItem(ByVal state As Boolean)
        ddSearchType.Enabled = state
        tbLabNo.Enabled = state
        btnCancel.Enabled = state
        btnSearch.Enabled = state
        btnSave.Enabled = state
        ddLanguage.Enabled = state
        cb_splitlab.Checked = False
        cb_splitlab.Enabled = state
    End Sub

    Private Sub P_Init()
        ViewState.Clear()
        GridView3.DataSource = Nothing
        GridView3.DataBind()
        GridView4.DataSource = Nothing
        GridView4.DataBind()
        GridView5.DataSource = Nothing
        GridView5.DataBind()
        GridView3.Attributes("bordercolor") = System.Drawing.ColorTranslator.ToHtml(Drawing.Color.Black)
        GridView3.Attributes("bordestyle") = "Solid"
        tbLabNo.Text = ""
        lbBuyer.Text = ""
        MultiView1.ActiveViewIndex = MultiView1_Index.目前清單
        With ddSearchType.Items
            .Clear()
            .Add(New ListItem("提貨單號碼", "M提貨單號碼"))
            .Add(New ListItem("報價單號碼", "M報價單號碼"))
            .Add(New ListItem("鋼捲號碼", "M鋼捲號碼"))
        End With
        Dim tableEdit As HtmlTable = Me.FindControl("Table1")

        ddLanguage.SelectedIndex = 0
        Dim queryTableLangCode As DataTable = WP_ClsSystemNote.getLev3(WP_System_Type, "_語系")
        WP_ClsSystemNote.setDropDownList(ddLanguage, queryTableLangCode)
    End Sub
#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    Private Sub MakeQryStringToControl()
        Dim querySql As New StringBuilder
        querySql.Append("EXEC QCdb01.dbo.[PD_AS400_鋼捲基本資訊] @from查詢模式 = '" & ddSearchType.Text & "',@from查詢號碼清單='" & tbLabNo.Text.Trim & "'")

        Me.hfSQL.Value = querySql.ToString
    End Sub
#End Region

#Region "鋼捲資訊Select"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL As String) As DataTable
        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")

        If String.IsNullOrEmpty(fromSQL) Or fromSQL = "" Then
            Return New DataTable

        End If
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(fromSQL)
        Return dtResult
    End Function
#End Region

#Region "偵檢人員&偵檢日期Select"
    Public Function FD_PersonTable(ByVal fromFno As String) As DataTable
        Dim result As String = ""
        Dim querySql As String = "EXEC [PD_AS400_檢驗資料_化學成份] @from爐號清單 =  '" & fromFno & "'"
        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(querySql)
        Return dtResult
    End Function
#End Region

#Region "新增表單Insert"
    Public Function InsertMaster(ByVal fromObj As SQLServer.QCdb01.LabRecordA1_M) As Integer
        Try
            Return fromObj.CDBInsert
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "系統資訊")
        End Try
    End Function
#End Region

#Region "表單編號Update"
    Public Function UpdateNo(ByVal fromObj As SQLServer.QCdb01.SystemNote) As Integer
        Try
            Return fromObj.CDBUpdate
        Catch ex As Exception
            If ex.Message.Contains("字串或二進位資料會被截斷") Then
                MsgBox("資料庫欄位長度不足，請聯絡資訊處。", MsgBoxStyle.OkOnly, "系統資訊")
            End If
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "系統資訊")
        End Try
    End Function
#End Region

#Region "新增鋼捲明細Insert"
    Public Function InsertDetail(ByVal fromObj As SQLServer.QCdb01.LabRecordA1_D) As Integer
        Try
            Return fromObj.CDBInsert
        Catch ex As Exception
            If ex.Message.Contains("字串或二進位資料會被截斷") Then
                MsgBox("資料庫欄位長度不足，請聯絡資訊處。", MsgBoxStyle.OkOnly, "系統資訊")
            End If
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "系統資訊")
        End Try
    End Function
#End Region

#Region "LabRecordA1_D:Insert"
    Public Sub InsertAllDetail(ByVal fromLabno As String, ByVal split As String)
        Dim sublabno As Int32 = 1
        Dim count As Int32 = 0
        Dim splitno As Int32 = 0
        If IsNumeric(split) Then
            splitno = CInt(split)
        End If
        Try
            For Each dr As DataRow In CType(ViewState("tempTable"), DataTable).Rows
                Dim obj As New SQLServer.QCDB01.LabRecordA1_D
                With obj
                    .LAB_REPORTNO = fromLabno
                    .鋼種 = dr.Item("鋼種名稱").ToString.Trim
                    .鋼捲號碼 = dr.Item("鋼捲號碼").ToString.Trim
                    .寬度 = dr.Item("寬度").ToString.Trim
                    .重量 = dr.Item("淨重").ToString.Trim
                    .厚度 = dr.Item("厚度").ToString.Trim
                    .表面 = dr.Item("表面").ToString.Trim
                    .LAB_REPORTNO2 = 0
                End With
                If IsNumeric(split) Then
                    If count = splitno Then
                        sublabno += 1
                        count = 0
                    End If
                    obj.LAB_REPORTNO2 = sublabno
                    count += 1
                    InsertDetail(obj)
                Else
                    InsertDetail(obj)
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "系統資訊")
        End Try
    End Sub

#End Region

#Region "新增鋼捲  按鈕:btnView2Confrim_Click"
    Protected Sub btnView2Confrim_Click(sender As Object, e As EventArgs) Handles btnView2Confrim.Click
        lbMessage.Text = ""
        Dim chkSelect As CheckBox
        Dim tempTable As DataTable '全域
        Dim tempTableForCheck As DataTable '站存選擇鋼捲，確認無誤後全部寫入
        Dim selected As Boolean = False '用來判斷鋼捲是否已被新增
        Dim alliswell As Boolean = True '用來判斷資料是否無誤
        Dim errorCoils As String = ""
        'Craete tempTable from GridView4 to ViewState  第一欄checkbox忽略
        If ViewState("tempTable") Is Nothing Then
            tempTable = New DataTable
            tempTableForCheck = New DataTable
            For Each gvColum In GridView4.Columns
                If gvColum.HeaderText = "加入" Then
                    Continue For
                End If
                Dim dc1 = New DataColumn
                Dim dc2 = New DataColumn
                dc1.ColumnName = gvColum.HeaderText
                dc2.ColumnName = gvColum.HeaderText
                tempTable.Columns.Add(dc1)
            Next

            ViewState.Add("tempTable", tempTable)
        End If
        tempTable = CType(ViewState("tempTable"), DataTable)
        tempTableForCheck = tempTable.Clone
        '將GridView4所有勾選的Row寫入tempTableForCheck
        For Each gvRow As GridViewRow In GridView4.Rows
            selected = False
            chkSelect = gvRow.FindControl("CheckBox2")
            If (chkSelect.Checked) Then
                Dim dr = tempTableForCheck.NewRow()
                For i = 0 To gvRow.Cells.Count - 2   'gvRow.Cells(0)為加入checkbox 不複製該欄位
                    dr.Item(i) = gvRow.Cells(i + 1).Text
                Next
                '檢查勾選的鋼捲是否已存在tempTable
                For Each dtRow As DataRow In tempTable.Rows
                    If dr.Item(3).ToString = dtRow.Item(3).ToString Then 'item(3) 為鋼捲號碼
                        errorCoils &= dr.Item(3).ToString.Trim & ","
                        'lbMessage.Text = "鋼捲：" & dr.Item(3).ToString.Trim & "已在清單中"
                        selected = True
                        alliswell = False
                    End If
                    If Not dr.Item(2).ToString = dtRow.Item(2).ToString And dtRow.Item(2).ToString.Trim.Length > 0 Then 'item(3) 為鋼捲號碼
                        lbMessage.Text = "客戶代號不相符"
                        selected = True
                        alliswell = False
                    End If
                Next
                If selected Then
                    Continue For
                End If
                Dim dr2 As DataRow = dr
                tempTableForCheck.Rows.Add(dr2)
                lbBuyer.Text = "買受人：" & Fs_buyername(dr.Item(2).ToString.Trim)
            End If
        Next
        If errorCoils.Length > 0 Then
            errorCoils = errorCoils.Remove(errorCoils.Length - 1)
            lbMessage.Text = "鋼捲：" & errorCoils & "已在清單中"
        End If
        '若無重複勾選的鋼捲 將tempTableForCheck寫入tempTable
        If alliswell Then
            For Each dr As DataRow In tempTableForCheck.Rows
                tempTable.ImportRow(dr)
            Next
            ViewState("tempTable") = tempTable
            GridView3.DataSource = tempTable
            GridView3.DataBind()
            P_View2_GoView1()
        End If

    End Sub
#End Region

#Region "查詢客戶資料"
    Protected Function Fs_buyername(ByVal fromOrderID As String) As String
        Dim result As String = ""
        Dim querySql As String = "EXEC [dbo].[PD_AS400_客戶基本資料檔] @from客戶編號清單 = '" & fromOrderID & "'"
        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
        If String.IsNullOrEmpty(querySql) Then
            Return ""
        End If
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(querySql)
        result = dtResult.Rows(0).Item("CUA02")
        Return result
    End Function
#End Region

#Region "取得偵檢人員與偵檢日期"
    Private Sub getQcinfo(ByVal fromTable As DataTable)
        Dim personList As String = ""
        Dim dateStart As String = ""
        Dim dateEnd As String = ""
        For Each dr As DataRow In fromTable.Rows
            If Not personList.Contains(dr.Item("OPERATOR")) Then
                personList &= dr.Item("OPERATOR") & "|"
            End If
            If dateStart.Length = 0 Or dateEnd.Length = 0 Then
                dateStart = dr.Item("DATE")
                dateEnd = dr.Item("DATE")
            End If
            If CInt(dr.Item("DATE")) < CInt(dateStart) Then
                dateStart = dr.Item("DATE")
            End If
            If CInt(dr.Item("DATE")) > CInt(dateEnd) Then
                dateEnd = dr.Item("DATE")
            End If
        Next
        personList = Left(personList, personList.Length - 1)
        dateStart = calculateString(dateStart, 19110000)
        dateEnd = calculateString(dateEnd, 19110000)

        ViewState("qcperson") = personList
        ViewState("dateStart") = dateStart.Insert(4, "/").Insert(7, "/")
        ViewState("dateEnd") = dateEnd.Insert(4, "/").Insert(7, "/")
    End Sub
#End Region


    Protected Sub btnView2Cencel_Click(sender As Object, e As EventArgs) Handles btnView2Cencel.Click
        P_View2_GoView1()
    End Sub


    Private Sub P_View2_GoView1()
        MultiView1.ActiveViewIndex = MultiView1_Index.目前清單
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        lbMessage.Text = ""
        lbSearchType.Text = ""
        lbSearchType.Text = ddSearchType.Text.Substring(1) & "：" & tbLabNo.Text
        MakeQryStringToControl()
        MultiView1.ActiveViewIndex = MultiView1_Index.新增資料
        btnClearAll_Click(Nothing, Nothing)


    End Sub

    ''' <summary>
    ''' 從ViewState中取出DataTable刪除後 塞回ViewState並重新繫結
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView3_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView3.RowDeleting
        Dim dt As DataTable = CType(ViewState("tempTable"), DataTable)
        'index為該頁RowIndex+頁數*該頁筆數
        dt.Rows(e.RowIndex + GridView3.PageIndex * GridView3.PageSize).Delete()
        GridView3.DataSource = dt
        ViewState("tempTable") = dt
        If dt.Rows.Count = 0 Then
            lbBuyer.Text = ""
        End If
        GridView3.DataBind()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not checkAdded() Then
            Exit Sub
        End If
        If cb_splitlab.Checked Then
            If Not IsNumeric(tb_splitnum.Text) Then
                lb_Err.Text = "請輸入數字!"
                Exit Sub
            ElseIf CInt(tb_splitnum.Text) <= 0 Then
                lb_Err.Text = "每份證明，鋼捲數不可小於1"
                Exit Sub
            End If
        End If
        Dim tempTable As DataTable = CType(ViewState("tempTable"), DataTable)
        Dim buyerId As String = tempTable.Rows(0).Item("客戶代號").ToString.Trim
        Dim lan As String = ddLanguage.Text.Substring(0, ddLanguage.Text.IndexOf("："))
        '------------取得爐號-----------
        Dim Fno As String = ""
        For Each dr As DataRow In tempTable.Rows
            If Not Fno.Contains(dr.Item("爐號編號2")) Then
                Fno &= dr.Item("爐號編號2") & ","
            End If
        Next
        Fno = Left(Fno, Fno.Length - 1)
        '------------取得偵檢人員與日期-----------
        getQcinfo(FD_PersonTable(Fno))
        Dim qcperson() As String = Split(ViewState("qcperson").ToString, "|")
        Dim dateStart As Date = Date.Parse(ViewState("dateStart").ToString)
        Dim dateEnd As Date = Date.Parse(ViewState("dateEnd").ToString)

        Dim no As Int32 = CInt(WP_ClsSystemNote.getLev4Content(WP_System_Type, "_表單編號", "下一個號碼"))
        If no > 9999 Then
            alert("表單編號已用罄，請聯絡資訊處")
            P_Init()
            RaiseEvent Event_reFresh父物件(NonRadioactive_Main.主畫面_Enum.查詢, Nothing, Nothing)
        End If

        Dim lengthNo As Int32 = CInt(WP_ClsSystemNote.getLev4Content(WP_System_Type, "_表單編號", "號碼長度補足至幾碼"))
        Dim formateNo As String = Space(lengthNo).Replace(" ", "0")

        Dim labno As String = (WP_ClsSystemNote.getLev4Content(WP_System_Type, "_表單編號", "年度")) & no.ToString(formateNo)
        Dim title1 As String = (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPtitle_NOTE_Type, "01_" & lan))
        Dim title2 As String = (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPtitle_NOTE_Type, "02A_" & lan)) & _
                               (WP_ClsSystemNote.getLev4Content(WP_System_Type, dot_NOTE_Type, lan)) & _
                               (WP_ClsSystemNote.getLev4Content(WP_System_Type, "_表單編號", "年度")) & _
                               (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPtitle_NOTE_Type, "02B_" & lan)) & _
                                no.ToString(formateNo) & _
                               (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPtitle_NOTE_Type, "02C_" & lan))
        Dim memo1 As String = (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "01_" & lan))
        Dim memo2 As String = (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "02_" & lan))
        Dim buyer As String = (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "03_" & lan)) & _
                              (WP_ClsSystemNote.getLev4Content(WP_System_Type, dot_NOTE_Type, lan)) & _
                              Fs_buyername(buyerId)
        Dim maker As String = (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "04A_" & lan)) & _
                              (WP_ClsSystemNote.getLev4Content(WP_System_Type, dot_NOTE_Type, lan)) & _
                              (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "04B_" & lan))
        Dim aecNo As String = (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "05A_" & lan)) & _
                              (WP_ClsSystemNote.getLev4Content(WP_System_Type, dot_NOTE_Type, lan)) & _
                              (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "05B_" & lan))
        Dim qcman As String = (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "06A_" & lan)) & _
                              (WP_ClsSystemNote.getLev4Content(WP_System_Type, dot_NOTE_Type, lan))
        Dim manCount As Integer = 1

        '組合偵檢人員字串
        Array.Sort(qcperson)
        qcman &= (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "06B_" & lan)) & " , "
        For Each uid As String In qcperson

            Dim man = (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPpeople_NOTE_Type, uid & "_" & lan))
            If man = uid & "_" & lan Then
                Continue For
            End If
            qcman &= man & " , "
            '每兩人換行
            If manCount Mod 2 = 1 Then
                qcman &= vbNewLine
            End If
            manCount += 1
        Next
        '刪除結尾標點符號與換行符號
        qcman = Left(qcman, qcman.Length - 3)
        If manCount Mod 2 = 0 Then
            qcman = Left(qcman, qcman.Length - 2)
        End If

        Dim qaman As String = (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "07A_" & lan)) & _
                              (WP_ClsSystemNote.getLev4Content(WP_System_Type, dot_NOTE_Type, lan)) & _
                              (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "07B_" & lan))

        Dim insdateStart As String = dateStart
        Dim insdateEnd As String = dateEnd

        Dim chair As String = (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "09A_" & lan)) & _
                              (WP_ClsSystemNote.getLev4Content(WP_System_Type, dot_NOTE_Type, lan)) & _
                              (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "09B_" & lan))

        Dim address As String = (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "10A_" & lan)) & _
                                (WP_ClsSystemNote.getLev4Content(WP_System_Type, dot_NOTE_Type, lan)) & _
                                (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "10B_" & lan))

        Dim issdate As String = DateTime.Now

        Dim insertObj As New SQLServer.QCDB01.LabRecordA1_M


        With insertObj
            .LAB_REPORTNO = labno
            .標題1 = title1
            .標題2 = title2
            .說明1 = memo1
            .說明2 = memo2
            .客戶名稱 = buyer
            .公司名稱 = maker
            .原能會字號 = aecNo
            .檢驗人員字號 = qcman
            .品檢主管 = qaman
            .品檢日期_起 = Date.Parse(insdateStart)
            .品檢日期_迄 = Date.Parse(insdateEnd)
            .公司負責人 = chair
            .公司地址 = address
            .資料日期 = DateTime.Parse(issdate)
            .LAB_REPORTNO2 = 0
        End With


        Dim newNoObj As New SQLServer.QCDB01.SystemNote
        With newNoObj
            .SYSTEM_TYPE = WP_System_Type
            .NOTE_TYPE = "_表單編號"
            .NOTE_ID = "下一個號碼"
            .CONTENT = (no + 1).ToString
        End With

        If cb_splitlab.Checked Then
            For i = 1 To Math.Ceiling(tempTable.Rows.Count / CInt(tb_splitnum.Text))
                Dim newtitle2 As String = (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPtitle_NOTE_Type, "02A_" & lan)) & _
                                          (WP_ClsSystemNote.getLev4Content(WP_System_Type, dot_NOTE_Type, lan)) & _
                                          (WP_ClsSystemNote.getLev4Content(WP_System_Type, "_表單編號", "年度")) & _
                                          (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPtitle_NOTE_Type, "02B_" & lan)) & _
                                          no.ToString(formateNo) & _
                                          "-" & i.ToString(subLabFormate) & _
                                          (WP_ClsSystemNote.getLev4Content(WP_System_Type, FPtitle_NOTE_Type, "02C_" & lan))
                insertObj.標題2 = newtitle2
                insertObj.LAB_REPORTNO2 = i
                InsertMaster(insertObj)
            Next
            InsertAllDetail(labno, CInt(tb_splitnum.Text))
        Else
            InsertAllDetail(labno, "N")
            InsertMaster(insertObj)
        End If

        UpdateNo(newNoObj)
        'alert("新增成功")
        P_Init()
        RaiseEvent Event_reFresh父物件(NonRadioactive_Main.主畫面_Enum.查詢, labno, Nothing)

    End Sub
#Region "資料驗證"
    Private Function checkAdded() As Boolean
        If ViewState("tempTable") Is Nothing Then
            alert("已加入鋼捲中尚無資料!")
            Return False
        End If
        If CType(ViewState("tempTable"), DataTable).Rows.Count = 0 Then
            alert("已加入鋼捲中尚無資料!")
            Return False
        End If
        Return True
    End Function
#End Region

#Region "訊息對話窗"
    Private Sub alert(ByVal msg As String)
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "警告", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>")
    End Sub
#End Region

    Private Function calculateString(ByVal fromStr As String, ByVal value As Int32) As String
        Return (CInt(fromStr.Trim) + value).ToString
    End Function
#Region "新增鋼捲：全選、清除功能"
    Protected Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        Dim chkSelect As CheckBox
        For Each gvr As GridViewRow In GridView4.Rows
            chkSelect = gvr.FindControl("CheckBox2")
            chkSelect.Checked = True
        Next
    End Sub

    Protected Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        Dim chkSelect As CheckBox
        For Each gvr As GridViewRow In GridView4.Rows
            chkSelect = gvr.FindControl("CheckBox2")
            chkSelect.Checked = False
        Next
    End Sub
#End Region

    Enum TableEdit2_Mode
        Rebuild = 1
        AddNewRow = 2
        ReFreshData = 3
    End Enum

    '抑制顯示 (若不透過RowCreated將Visible設為False 將無法取得Cells的值)
    Protected Sub GridView3_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles GridView3.RowCreated
        If e.Row.RowType = DataControlRowType.Header Or e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(14).Visible = False
        End If
    End Sub
    Protected Sub GridView4_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles GridView4.RowCreated
        If e.Row.RowType = DataControlRowType.Header Or e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(14).Visible = False
        End If
    End Sub


    Protected Sub GridView3_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView3.PageIndexChanging
        GridView3.PageIndex = e.NewPageIndex
        GridView3.DataSource = CType(ViewState("tempTable"), DataTable)
        GridView3.DataBind()
    End Sub

    Protected Sub GridView5_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView5.PageIndexChanging
        GridView5.PageIndex = e.NewPageIndex
        GridView5.DataSource = CType(ViewState("tempViewTable"), DataTable)
        GridView5.DataBind()
    End Sub

    

    Protected Sub GridView4_PreRender(sender As Object, e As EventArgs) Handles GridView4.PreRender
        If GridView4.Rows.Count = 0 And Not lbSearchType.Text.Contains("傳回的資料筆數") Then
            lbSearchType.Text &= "  傳回的資料筆數:0"
        End If
    End Sub

    
    Protected Sub cb_splitlab_CheckedChanged(sender As Object, e As EventArgs) Handles cb_splitlab.CheckedChanged
        tb_splitnum.Enabled = cb_splitlab.Checked
        If Not tb_splitnum.Enabled Then
            tb_splitnum.Text = ""
        End If
    End Sub
End Class