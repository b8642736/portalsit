Public Class ZmlReplaceHistory
    Inherits System.Web.UI.UserControl

    Const C_ShiftSing As Integer = 4

#Region "畫面上相關控制項程式碼"
    Private Sub P_Init()
        Me.txtDateStart.Text = Format(Now.AddMonths(-3), "yyyy/MM/") & "01"
        Me.txtDateEnd.Text = Format(CType(Format(Now.AddMonths(1), "yyyy/MM/") & "01", Date).AddDays(-1), "yyyy/MM/dd")

        radioDataKind.Items.Clear()
        For II As Integer = 0 To ddlistDataKind.Items.Count - 1
            radioDataKind.Items.Add(ddlistDataKind.Items(II).Text)
        Next

        checkBoxListInsKind.SelectedAll()
        checkBoxListShiftKind.SelectedAll()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Me.hfDataKind.Value = "原因-" & ddlistDataKind.SelectedValue.ToString
            P_Init()
        End If
    End Sub

    Protected Sub btnClearSearchCondiction_Click(sender As Object, e As EventArgs) Handles btnClearSearchCondiction.Click
        P_Init()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakeQryStringToControl()
    End Sub

    Protected Sub radioDataKind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles radioDataKind.SelectedIndexChanged
        ddlistDataKind.SelectedIndexByValue(radioDataKind.Text)
        MakeQryStringToControl(False)
    End Sub

    Protected Sub checkBoxList_DataBound_SelectAll(sender As Object, e As EventArgs)
        Dim checkBoxList As UCAjaxServerControl1.CheckBoxListEx = CType(sender, CheckBoxList)
        checkBoxList.SelectedAll()
    End Sub
#End Region

#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    Private Sub MakeQryStringToControl()
        MakeQryStringToControl(True)
    End Sub

    Private Sub MakeQryStringToControl(ByVal fromQuerReal As Boolean)
        Dim querySql As New StringBuilder
        Dim queryStr As String

        querySql.Append("SELECT * FROM ZML更換紀錄表 ")
        If fromQuerReal = False Then
            querySql.Append("WHERE 1=2 ")
        Else
            querySql.Append("WHERE 1=1 ")
            querySql.Append("AND 紀錄表類別='" & ddlistDataKind.Text & "' ")

            queryStr = checkBoxListInsKind.TextSelectToSQL
            querySql.Append(IIf(queryStr = "", "", "AND 機別 IN(" & queryStr & ")"))

            querySql.Append(IIf(txtDateStart.Text <> "", "AND 日期 >= '" & txtDateStart.Text & "' ", ""))
            querySql.Append(IIf(txtDateEnd.Text <> "", "AND 日期 <= '" & txtDateEnd.Text & "' ", ""))

            queryStr = checkBoxListShiftKind.TextSelectToSQL
            querySql.Append(IIf(queryStr = "", "", "AND 班別 IN(" & queryStr & ")"))

            querySql.Append("ORDER BY 日期,機別,班別 ")
        End If


        Me.hfDataKind.Value = "原因-" & ddlistDataKind.SelectedValue.ToString
        Me.hfSQL.Value = querySql.ToString
    End Sub
#End Region

#Region "ZML更換紀錄表Object:CRUD"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL As String) As List(Of SQLServer.QCDB01.ZML更換紀錄表)
        If String.IsNullOrEmpty(fromSQL) Or fromSQL = "" Then
            Return New List(Of SQLServer.QCDB01.ZML更換紀錄表)
        End If
        Return SQLServer.QCDB01.ZML更換紀錄表.CDBSelect(Of SQLServer.QCDB01.ZML更換紀錄表)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, fromSQL)
    End Function

    <DataObjectMethod(DataObjectMethodType.Insert)>
    Public Function Insert(ByVal fromObj As SQLServer.QCDB01.ZML更換紀錄表) As Integer
        Return fromObj.CDBInsert
    End Function

    <DataObjectMethod(DataObjectMethodType.Update)>
    Public Function Update(ByVal fromObj As SQLServer.QCDB01.ZML更換紀錄表) As Integer
        Return fromObj.CDBUpdate
    End Function

    <DataObjectMethod(DataObjectMethodType.Delete)>
    Public Function Delete(ByVal fromObj As SQLServer.QCDB01.ZML更換紀錄表) As Integer
        Return fromObj.CDBDelete
    End Function
#End Region

#Region "ListView相關物件程式"
    Public showItem尺寸上輥 As Boolean = True
    Public showItem尺寸下輥 As Boolean = True
    Public showItem尺寸驅動輥 As Boolean = True
    Public showItem背輥代號 As Boolean = True
    Public showItem規格 As Boolean = True

    Protected Sub refreshListViewState(ByVal listView As ListView)
        labDataKind1.Text = "ZML" & ddlistDataKind.Text & "更換紀錄表"
        radioDataKind.SelectedByText(ddlistDataKind.SelectedItem.Text)

        If ddlistDataKind.Text = "第一中間輥" Then
            showItem尺寸上輥 = True
            showItem尺寸下輥 = True
            showItem尺寸驅動輥 = False
            showItem背輥代號 = False
            showItem規格 = True

            If Not listView.FindControl("Th尺寸上輥") Is Nothing Then listView.FindControl("Th尺寸上輥").Visible = True
            If Not listView.FindControl("Th尺寸下輥") Is Nothing Then listView.FindControl("Th尺寸下輥").Visible = True
            If Not listView.FindControl("Th尺寸驅動輥") Is Nothing Then listView.FindControl("Th尺寸驅動輥").Visible = False
            If Not listView.FindControl("Th背輥代號") Is Nothing Then listView.FindControl("Th背輥代號").Visible = False
            If Not listView.FindControl("Th規格") Is Nothing Then listView.FindControl("Th規格").Visible = True

        ElseIf ddlistDataKind.Text = "第二中間輥" Then
            showItem尺寸上輥 = True
            showItem尺寸下輥 = True
            showItem尺寸驅動輥 = True
            showItem背輥代號 = False
            showItem規格 = False

            If Not listView.FindControl("Th尺寸上輥") Is Nothing Then listView.FindControl("Th尺寸上輥").Visible = True
            If Not listView.FindControl("Th尺寸下輥") Is Nothing Then listView.FindControl("Th尺寸下輥").Visible = True
            If Not listView.FindControl("Th尺寸驅動輥") Is Nothing Then listView.FindControl("Th尺寸驅動輥").Visible = True
            If Not listView.FindControl("Th背輥代號") Is Nothing Then listView.FindControl("Th背輥代號").Visible = False
            If Not listView.FindControl("Th規格") Is Nothing Then listView.FindControl("Th規格").Visible = False

        Else
            showItem尺寸上輥 = False
            showItem尺寸下輥 = False
            showItem尺寸驅動輥 = False
            showItem背輥代號 = True
            showItem規格 = False

            If Not listView.FindControl("Th尺寸上輥") Is Nothing Then listView.FindControl("Th尺寸上輥").Visible = False
            If Not listView.FindControl("Th尺寸下輥") Is Nothing Then listView.FindControl("Th尺寸下輥").Visible = False
            If Not listView.FindControl("Th尺寸驅動輥") Is Nothing Then listView.FindControl("Th尺寸驅動輥").Visible = False
            If Not listView.FindControl("Th背輥代號") Is Nothing Then listView.FindControl("Th背輥代號").Visible = True
            If Not listView.FindControl("Th規格") Is Nothing Then listView.FindControl("Th規格").Visible = False
        End If

    End Sub


    Protected Sub ListViewAll_ItemInserting(sender As Object, e As ListViewInsertEventArgs)
        Dim listView As ListView = ListView1

        e.Values("紀錄表類別") = ddlistDataKind.Text
        e.Values("班別說明") = CType(listView.InsertItem.FindControl("ddlistShiftSingCRUD"), DropDownList).SelectedValue
        e.Values("機別") = Left(e.Values("班別說明"), 2)
        e.Values("班別") = CType(listView.InsertItem.FindControl("ddlistShiftKindCRUD"), DropDownList).SelectedValue
        e.Values("定期更換") = IIf(CType(listView.InsertItem.FindControl("定期更換CheckBoxCRUD"), CheckBox).Checked, "V", "")
        e.Values("損換更換") = IIf(CType(listView.InsertItem.FindControl("損換更換CheckBoxCRUD"), CheckBox).Checked, "V", "")

        e.Values("GID") = Convert.ToInt32(CType(DateTime.Now.ToLocalTime() - New DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime(), TimeSpan).TotalSeconds).ToString
        '--------------------------------------------------------------------------------------------------------
        '一個欄位同時使用片語/自行輸入
        '背輥代號
        ChangeSystemNoteCRUDObject(CType(listView.InsertItem.FindControl("ddlist背輥代號"), DropDownList), e, "背輥代號")

        '規格 
        ChangeSystemNoteCRUDObject(CType(listView.InsertItem.FindControl("ddlist規格"), DropDownList), e, "規格")

        '原因 
        ChangeSystemNoteCRUDObject(CType(listView.InsertItem.FindControl("ddlist原因"), DropDownList), e, "原因")
    End Sub

    Protected Sub ListViewAll_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs)
        Dim listView As ListView = ListView1
        e.NewValues("班別") = CType(listView.EditItem.FindControl("ddlistShiftKindCRUD"), DropDownList).SelectedValue
        e.NewValues("班別說明") = CType(listView.EditItem.FindControl("ddlistShiftSingCRUD"), DropDownList).SelectedValue
        e.NewValues("機別") = Left(e.NewValues("班別說明"), 2)
        e.NewValues("定期更換") = IIf(CType(listView.EditItem.FindControl("定期更換CheckBoxCRUD"), CheckBox).Checked, "V", "")
        e.NewValues("損換更換") = IIf(CType(listView.EditItem.FindControl("損換更換CheckBoxCRUD"), CheckBox).Checked, "V", "")

        '--------------------------------------------------------------------------------------------------------
        '一個欄位同時使用片語/自行輸入
        '背輥代號
        ChangeSystemNoteCRUDObject(CType(listView.EditItem.FindControl("ddlist背輥代號"), DropDownList), e, "背輥代號")

        '規格 
        ChangeSystemNoteCRUDObject(CType(listView.EditItem.FindControl("ddlist規格"), DropDownList), e, "規格")

        '原因 
        ChangeSystemNoteCRUDObject(CType(listView.InsertItem.FindControl("ddlist原因"), DropDownList), e, "原因")
    End Sub

    Private Sub DropDownListExAddShiftSing(ByRef fromDropDownListEx As UCAjaxServerControl1.DropDownListEx)
        fromDropDownListEx.Items.Clear()
        For II As Integer = 0 To checkBoxListInsKind.Items.Count - 1
            For JJ As Integer = 1 To C_ShiftSing
                fromDropDownListEx.Items.Add(New ListItem(checkBoxListInsKind.Items(II).Text & CStr(JJ).Trim, checkBoxListInsKind.Items(II).Text & CStr(JJ).Trim))
            Next JJ
        Next II
    End Sub

    Protected Sub ListViewAll_PreRender(sender As Object, e As EventArgs)
        Dim listViewObj As ListView = CType(sender, ListView)

        refreshListViewState(listViewObj)

        If Not IsNothing(listViewObj.InsertItem) Then
            ''日期
            Dim txtDateCURDObjObj As TextBox = listViewObj.InsertItem.FindControl("txtDateCRUD")
            If txtDateCURDObjObj.Text = "" Then txtDateCURDObjObj.Text = Format(Now, "yyyy/MM/dd")

            '帶班簽名
            DropDownListExAddShiftSing(CType(listViewObj.InsertItem.FindControl("ddlistShiftSingCRUD"), UCAjaxServerControl1.DropDownListEx))
        End If

        If Not IsNothing(listViewObj.EditItem) Then
            Dim dropDownList1 As UCAjaxServerControl1.DropDownListEx
            Dim GetFindValue As String

            '班別
            dropDownList1 = listViewObj.EditItem.FindControl("ddlistShiftKindCRUD")
            GetFindValue = CType(listViewObj.EditItem.FindControl("hfShiftKindCRUD"), HiddenField).Value
            dropDownList1.SelectedIndexByValue(GetFindValue)

            '帶班簽名
            dropDownList1 = listViewObj.EditItem.FindControl("ddlistShiftSingCRUD")
            DropDownListExAddShiftSing(dropDownList1)
            GetFindValue = CType(listViewObj.EditItem.FindControl("hfShiftSingCRUD"), HiddenField).Value
            dropDownList1.SelectedIndexByValue(GetFindValue)

            '背輥代號
            ChangeSystemNoteFormObject(
                        CType(listViewObj.EditItem.FindControl("ddlist背輥代號"), DropDownList),
                        CType(listViewObj.EditItem.FindControl("背輥代號TextBox"), TextBox),
                        CType(listViewObj.EditItem.FindControl("hf背輥代號CRUD"), HiddenField))

            '規格 
            ChangeSystemNoteFormObject(
                        CType(listViewObj.EditItem.FindControl("ddlist規格"), DropDownList),
                        CType(listViewObj.EditItem.FindControl("規格TextBox"), TextBox),
                        CType(listViewObj.EditItem.FindControl("hf規格CRUD"), HiddenField))

            '原因 
            ChangeSystemNoteFormObject(
                        CType(listViewObj.EditItem.FindControl("ddlist原因"), DropDownList),
                        CType(listViewObj.EditItem.FindControl("原因TextBox"), TextBox),
                        CType(listViewObj.EditItem.FindControl("hf原因CRUD"), HiddenField))

            Dim checkbox1 As CheckBox
            '定期更換
            checkbox1 = listViewObj.EditItem.FindControl("定期更換CheckBoxCRUD")
            GetFindValue = CType(listViewObj.EditItem.FindControl("hf定期更換CRUD"), HiddenField).Value
            If (Not checkbox1 Is Nothing) Then
                checkbox1.Checked = (GetFindValue = "V")
            End If

            '定期更換
            checkbox1 = listViewObj.EditItem.FindControl("損換更換CheckBoxCRUD")
            GetFindValue = CType(listViewObj.EditItem.FindControl("hf損換更換CRUD"), HiddenField).Value
            If (Not checkbox1 Is Nothing) Then
                checkbox1.Checked = (GetFindValue = "V")
            End If

        End If

    End Sub


#End Region

#Region "片語相關程式:SystemNote"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function SearchSystemNote(ByVal fromNoteType As String) As List(Of SQLServer.QCDB01.SystemNote)
        Dim retSQL As New StringBuilder

        retSQL.Append("SELECT * FROM SystemNote ")
        retSQL.Append("WHERE system_type='ZML更換紀錄表' ")
        retSQL.Append("AND NOTE_TYPE='" & fromNoteType & "' ")
        retSQL.Append("ORDER BY DISPLAY_SEQ,NOTE_ID ")

        Return SQLServer.QCDB01.SystemNote.CDBSelect(Of SQLServer.QCDB01.SystemNote)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, retSQL.ToString)
    End Function

    Protected Sub SystemNoteDropDownListObj_DataBinding(sender As Object, e As EventArgs)
        Dim dropDownList As DropDownList = CType(sender, DropDownList)

        dropDownList.Items.Clear()
        dropDownList.Items.Add(New ListItem("- 片語 -", "- 片語 -"))
    End Sub

    ''' <summary>
    ''' 資料異動預設是自行輸入輸入資料，從TextBox取得
    ''' 如果選擇片語輸入，則從DropDownList取得
    ''' </summary>
    ''' <param name="fromDropDownList"></param>
    ''' <param name="fromE"></param>
    ''' <param name="fromKey"></param>
    ''' <remarks></remarks>
    Protected Sub ChangeSystemNoteCRUDObject(ByRef fromDropDownList As DropDownList, ByRef fromE As Object, ByRef fromKey As String)
        If Not fromDropDownList Is Nothing AndAlso fromDropDownList.SelectedIndex > 0 Then

            If TypeOf fromE Is ListViewInsertEventArgs Then
                fromE.Values(fromKey) = fromDropDownList.SelectedValue
            ElseIf TypeOf fromE Is ListViewUpdateEventArgs Then
                fromE.NewValues(fromKey) = fromDropDownList.SelectedValue
            End If

        End If
    End Sub

    ''' <summary>
    ''' 如果資料存在片語中則顯示在DropDownList
    ''' 否則就顯示在TextBox
    ''' </summary>
    ''' <param name="fromDropDownList"></param>
    ''' <param name="fromTextbox"></param>
    ''' <param name="fromHiddenField"></param>
    ''' <remarks></remarks>
    Protected Sub ChangeSystemNoteFormObject(ByRef fromDropDownList As UCAjaxServerControl1.DropDownListEx, ByRef fromTextbox As TextBox, ByVal fromHiddenField As HiddenField)
        If (Not fromTextbox Is Nothing) And (Not fromDropDownList Is Nothing) And (Not fromHiddenField Is Nothing) Then
            Dim GetFindValue As String = fromHiddenField.Value
            fromDropDownList.SelectedIndexByValue(GetFindValue)
            If fromDropDownList.SelectedIndex > 0 Then
                fromTextbox.Text = ""
            Else
                fromTextbox.Text = GetFindValue
            End If

        End If
    End Sub

#End Region


    Public Sub CustomValidator1_ServerValidate(source As Object, args As System.Web.UI.WebControls.ServerValidateEventArgs) 'Handles CustomValidator1.ServerValidate
        Dim validatorObjl As CustomValidator = Nothing
        Dim listViewItemObj As System.Web.UI.WebControls.ListViewItem = Nothing
        Dim textboxObj As TextBox = Nothing

        '特別地方: 修改時 InsertItem與 EditItem 都會存在
        '                   新增時 InsertItem
        If Not ListView1.InsertItem Is Nothing Then
            listViewItemObj = ListView1.InsertItem
        End If
        If Not ListView1.EditItem Is Nothing Then
            listViewItemObj = ListView1.EditItem
        End If

        If Not listViewItemObj Is Nothing Then
            validatorObjl = listViewItemObj.FindControl("CustomValidator1")
            textboxObj = listViewItemObj.FindControl("txtDateCRUD")

            validatorObjl.ErrorMessage = String.Empty
            If Date.TryParse(textboxObj.Text, New Date()) = False Then
                validatorObjl.ErrorMessage = "輸入的日期格式錯誤"
            End If
            args.IsValid = (validatorObjl.ErrorMessage.Trim.Length = 0)
        End If

    End Sub



End Class