Public Class LabRecordA2_Setting_Assay_DAT
    Inherits System.Web.UI.UserControl

    'Private WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

    'Private C_SYSTEM_TYPE As String = "品保_檢驗證明書"

    'Private C_Fix_DropDown As String = "DropDown"
    'Private C_Fix_HiddenField As String = "HiddenField"
    'Private C_Fix_TextBox As String = "TextBox"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            P_INIT()
        End If
    End Sub

#Region "SystemNote"
    Public Enum Enum_DropDownList
        檢驗項目基本檔_停用否 = 1
        檢驗項目基本檔_代號群組 = 2
        檢驗項目基本檔_資料來源類型 = 3
        檢驗項目基本檔_是否顯示 = 4
    End Enum

    Public Sub P_DropDownList_SetItem(ByVal fromNote_Type As Enum_DropDownList, _
                                        ByRef fromObj As DropDownList)

        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
        Dim W_NoteType As String = [Enum].GetName(GetType(Enum_DropDownList), fromNote_Type)
        Dim queryDataTable1 As DataTable
        queryDataTable1 = W_ClsSystemNote.getLev3(C_SYSTEM_TYPE, W_NoteType)
        W_ClsSystemNote.setDropDownList(fromObj, queryDataTable1, W_ClsSystemNote.Display_Lable)
    End Sub
#End Region

    Public Function FS_DropDownList_GetItem(ByVal fromNote_Type As Enum_DropDownList, _
                                       ByVal fromNoteID As String) As String
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
        Dim W_NoteType As String = [Enum].GetName(GetType(Enum_DropDownList), fromNote_Type)
        Dim W_Content As String = W_ClsSystemNote.getLev4Content(C_SYSTEM_TYPE, W_NoteType, fromNoteID)

        Dim W_ReturnMSG As String = String.Format("{0}{1}{2}", fromNoteID, W_ClsSystemNote.Display_Symbol, W_Content)

        Return W_ReturnMSG
    End Function

    Private W_Now主畫面_Enum As 主畫面_Enum = 主畫面_Enum.檢驗項目_基本檔
    Private Sub P_INIT()
        P_DropDownList_SetItem(Enum_DropDownList.檢驗項目基本檔_代號群組, queryASSAY_IDDropDownList)
        P_DropDownList_SetItem(Enum_DropDownList.檢驗項目基本檔_停用否, queryEFF_FLAGDropDown)
        queryEFF_FLAGDropDown.Items.Add("ALL：全部")

        MakeQryStringToControl_Master()
        MakeQryStringToControl_Detail_Insert()
        TabContainer1.ActiveTabIndex = 0

        LabRecordA2_Setting_Module.Main_Targe_Who = W_Now主畫面_Enum
    End Sub

    Protected Sub btnSerach_Master_Click(sender As Object, e As EventArgs) Handles btnSerach_Master.Click
        ListView1.EditIndex = -1
        GridView1.SelectedIndex = -1

        MakeQryStringToControl_Detail_Insert()
        MakeQryStringToControl_Master()


    End Sub

    Private Sub GridView1_PageIndexChanged(sender As Object, e As EventArgs) Handles GridView1.PageIndexChanged
        TabContainer1.ActiveTabIndex = 0
    End Sub

    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        'Me.hfAssy_ID.Value = GridView1.SelectedValue

        'MakeQryStringToControl_Detail_Edit()
        'TabContainer1.ActiveTabIndex = 1
        P_Detail_Display(GridView1.SelectedValue)
    End Sub

    Private Sub P_Detail_Display(ByVal fromAssay_ID As String)
        Me.hfAssy_ID.Value = fromAssay_ID

        MakeQryStringToControl_Detail_Edit()
        TabContainer1.ActiveTabIndex = 1
    End Sub

#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    Enum Enum_QueryMode
        Master = 1
        Detail_Edit = 2
        Detail_Insert = 3
    End Enum
    Private Sub MakeQryStringToControl_Master()
        MakeQryStringToControl(Enum_QueryMode.Master)
    End Sub
    Private Sub MakeQryStringToControl_Detail_Edit()
        MakeQryStringToControl(Enum_QueryMode.Detail_Edit)

        ListView1.EditIndex = -1
    End Sub
    Private Sub MakeQryStringToControl_Detail_Insert()
        MakeQryStringToControl(Enum_QueryMode.Detail_Insert)

        ListView1.EditIndex = -1
    End Sub
    Private Sub MakeQryStringToControl(ByVal fromQueryMode As Enum_QueryMode)
        Dim queryTime As String = Now.ToString("HHmmss")

        Dim querySql As New StringBuilder
        querySql.Append("SELECT * " & vbNewLine)
        querySql.Append("FROM LabRecordA2_Assay_DAT " & vbNewLine)
        querySql.Append("WHERE 1=1 " & vbNewLine)

        Select Case fromQueryMode
            Case Enum_QueryMode.Master

                Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
                Dim W_ASSAY_ID_KIND As String = W_ClsSystemNote.Fs_GetStrBefor(queryASSAY_IDDropDownList.SelectedValue, LabRecordA2_Setting_Module.C_ClsSystemNote_Display_Symbol)

                If queryASSAY_IDTextBox.Text = "" Then
                    querySql.Append("AND ASSAY_ID LIKE '" & W_ASSAY_ID_KIND & "%' " & vbNewLine)
                Else
                    querySql.Append("AND ASSAY_ID ='" & String.Concat(W_ASSAY_ID_KIND, queryASSAY_IDTextBox.Text) & "' " & vbNewLine)
                End If

                If queryASSAY_NAMETextBox.Text <> "" Then
                    querySql.Append("AND ASSAY_NAME LIKE '%" & queryASSAY_NAMETextBox.Text & "%' " & vbNewLine)
                End If
                If queryDISPLAY_SEQTextBox.Text <> "" Then
                    querySql.Append("AND DISPLAY_SEQ =" & queryDISPLAY_SEQTextBox.Text & " " & vbNewLine)
                End If

                Dim W_EFF_FLAG As String = W_ClsSystemNote.Fs_GetStrBefor(queryEFF_FLAGDropDown.SelectedValue, W_ClsSystemNote.Display_Symbol)
                If W_EFF_FLAG <> "ALL" Then
                    querySql.Append("AND EFF_FLAG ='" & W_EFF_FLAG & "' " & vbNewLine)
                End If

                querySql.Append("ORDER BY DISPLAY_SEQ , LEN(ASSAY_NAME) ,ASSAY_NAME " & vbNewLine)
                Me.hfSQL_Master.Value = queryTime & "|" & querySql.ToString

            Case Enum_QueryMode.Detail_Edit
                querySql.Append("AND ASSAY_ID ='" & Me.hfAssy_ID.Value & "' " & vbNewLine)
                Me.hfSQL_Detail.Value = queryTime & "|" & querySql.ToString
                ListView1.InsertItemPosition = InsertItemPosition.None

            Case Enum_QueryMode.Detail_Insert
                querySql.Append("AND 2=3 " & vbNewLine)
                Me.hfSQL_Detail.Value = queryTime & "|" & querySql.ToString
                ListView1.InsertItemPosition = InsertItemPosition.LastItem
        End Select


    End Sub
#End Region

#Region "CRUD"

    Protected Function Search(ByVal fromSQL As String) As List(Of SQLServer.QCDB01.LabRecordA2_Assay_DAT)
        If String.IsNullOrEmpty(fromSQL) OrElse fromSQL = "" _
            OrElse fromSQL.Split("|").Count < 2 Then
            Return New List(Of SQLServer.QCDB01.LabRecordA2_Assay_DAT)
        End If

        Return SQLServer.QCDB01.LabRecordA2_Assay_DAT.CDBSelect _
                            (Of SQLServer.QCDB01.LabRecordA2_Assay_DAT) _
                            (SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, _
                             SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, _
                             "QCDB01", fromSQL.Split("|")(1))
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search_Master(ByVal fromSQL As String) As List(Of SQLServer.QCDB01.LabRecordA2_Assay_DAT)
        Return Search(fromSQL)
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search_Detail(ByVal fromSQL As String) As List(Of SQLServer.QCDB01.LabRecordA2_Assay_DAT)
        Return Search(fromSQL)
    End Function

    <DataObjectMethod(DataObjectMethodType.Insert)>
    Public Function Insert(ByVal fromObj As SQLServer.QCDB01.LabRecordA2_Assay_DAT) As Integer
        Return fromObj.CDBInsert()
    End Function

    <DataObjectMethod(DataObjectMethodType.Update)>
    Public Function Update(ByVal fromObj As SQLServer.QCDB01.LabRecordA2_Assay_DAT) As Integer
        Return fromObj.CDBUpdate()
    End Function
#End Region

#Region "btnInserNewRecord1"
    Protected Sub btnInserNewRecord1_Click(sender As Object, e As EventArgs) _
                Handles btnInserNewRecord1.Click

        MakeQryStringToControl_Detail_Insert()
        TabContainer1.ActiveTabIndex = 1
    End Sub

    Protected Sub btnBackTo1A_Click(sender As Object, e As EventArgs) Handles btnBackTo1A.Click
        TabContainer1.ActiveTabIndex = 0
    End Sub
#End Region


#Region "ListView1"

    Private Sub P_ReFresh_GridView()
        MakeQryStringToControl_Master()
    End Sub
    Private Sub ListView1_ItemInserted(sender As Object, e As ListViewInsertedEventArgs) Handles ListView1.ItemInserted
        P_ReFresh_GridView()

        GridView1.SelectedIndex = -1
        P_Detail_Display(Me.hfAssy_ID.Value)
    End Sub

    Private Sub ListView1_ItemUpdated(sender As Object, e As ListViewUpdatedEventArgs) Handles ListView1.ItemUpdated
        P_ReFresh_GridView()
    End Sub

    Private Sub ListView1_ItemInserting(sender As Object, e As ListViewInsertEventArgs) Handles ListView1.ItemInserting
        Dim W_Value As String = ""
        Dim W_Obj_ListViewItem As ListViewItem
        Dim W_Obj_DropDownList As DropDownList = Nothing
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        Dim W_KeyArray As String()

        W_Obj_ListViewItem = (CType(sender, ListView).InsertItem)
        W_KeyArray = New String() {"ASSAY_ID", "DISPLAY_FLAG", "RESULT_KIND", "EFF_FLAG"}

        For Each eachItemKey As String In W_KeyArray
            W_Obj_DropDownList = CType(W_Obj_ListViewItem.FindControl(String.Concat(eachItemKey, C_Fix_DropDown)), DropDownList)
            W_Value = W_ClsSystemNote.Fs_GetStrBefor(W_Obj_DropDownList.SelectedValue, LabRecordA2_Setting_Module.C_ClsSystemNote_Display_Symbol)

            e.Values(eachItemKey) = W_Value
        Next


        'ASSAY_ID
        '---------------------------------------------------------------
        W_Value = Fs_GetNewAssay_ID_Number(e.Values("ASSAY_ID"))
        e.Values("ASSAY_ID") = W_Value
        hfAssy_ID.Value = W_Value
        '---------------------------------------------------------------


        e.Values("SAVE_OPER") = LabRecordA2_Setting_Module.FS_SAVE_OPER()
        e.Values("SAVE_DATE") = LabRecordA2_Setting_Module.FS_SAVE_DATE
    End Sub

    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Dim W_Value As String = ""
        Dim W_Obj_ListViewItem As ListViewItem
        Dim W_Obj_DropDownList As DropDownList = Nothing

        Dim W_KeyArray As String()
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        W_Obj_ListViewItem = (CType(sender, ListView).EditItem)
        W_KeyArray = New String() {"DISPLAY_FLAG", "RESULT_KIND", "EFF_FLAG"}

        For Each eachItemKey As String In W_KeyArray
            W_Obj_DropDownList = CType(W_Obj_ListViewItem.FindControl(String.Concat(eachItemKey, C_Fix_DropDown)), DropDownList)
            W_Value = W_ClsSystemNote.Fs_GetStrBefor(W_Obj_DropDownList.SelectedValue, LabRecordA2_Setting_Module.C_ClsSystemNote_Display_Symbol)

            e.NewValues(eachItemKey) = W_Value
        Next


        e.NewValues("SAVE_OPER") = LabRecordA2_Setting_Module.FS_SAVE_OPER()
        e.NewValues("SAVE_DATE") = LabRecordA2_Setting_Module.FS_SAVE_DATE
    End Sub


    Private Function Fs_GetNewAssay_ID_Number(ByVal fromAssay_ID_Kind As String) As String
        Dim W_SQLQueryAdapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        Dim W_SQL As New StringBuilder
        Dim W_Assay_ID_NumLeng As Integer = 2
        Dim W_Assay_ID_NumNow As String
        Dim W_Assay_ID_NumNew As String = Space(W_Assay_ID_NumLeng).Replace(Space(1), "0")

        W_SQL.Append("DECLARE @W_Assay_ID_KIND NVARCHAR(10) " & vbNewLine)
        W_SQL.Append("DECLARE @_W_Assay_ID_Num   NVARCHAR(10) " & vbNewLine)
        W_SQL.Append("SET @W_Assay_ID_KIND = '" & fromAssay_ID_Kind & "' " & vbNewLine)
        W_SQL.Append("SET @_W_Assay_ID_Num = '" & W_Assay_ID_NumNew & "' " & vbNewLine)
        W_SQL.Append(" " & vbNewLine)
        W_SQL.Append(" " & vbNewLine)
        W_SQL.Append("SELECT  ISNULL(  " & vbNewLine)
        W_SQL.Append("					 MAX(ASSAY_ID)  " & vbNewLine)
        W_SQL.Append("					,CONCAT(@W_Assay_ID_KIND, @_W_Assay_ID_Num ) " & vbNewLine)
        W_SQL.Append("				) ASSAY_ID_max " & vbNewLine)
        W_SQL.Append(" " & vbNewLine)
        W_SQL.Append("FROM [LabRecordA2_Assay_DAT] " & vbNewLine)
        W_SQL.Append("WHERE ASSAY_ID LIKE  CONCAT(@W_Assay_ID_KIND ,  '%' ) " & vbNewLine)

        W_Assay_ID_NumNow = W_SQLQueryAdapter.SelectQuery(W_SQL.ToString).Rows(0).Item(0)

        W_Assay_ID_NumNew = W_Assay_ID_NumNow.Substring(fromAssay_ID_Kind.Length)
        W_Assay_ID_NumNew = Hex(Convert.ToInt32(W_Assay_ID_NumNew, 16) + 1).PadLeft(W_Assay_ID_NumLeng, "0")

        Return String.Format("{0}{1}", fromAssay_ID_Kind, W_Assay_ID_NumNew)
    End Function

    Class ListVeiw2_Textbox
        Public ControlID As String
        Public DefaultValue As String
        Public Title As String

        Sub New(ByVal fromControlID As String, ByVal fromDefaultValue As String, ByVal fromTitle As String)
            Me.ControlID = fromControlID
            Me.DefaultValue = fromDefaultValue
            Me.Title = fromTitle
        End Sub
    End Class
    Class ListView1_DropDownList
        Public ControlID As String
        Public Note_Type As Enum_DropDownList

        Sub New(ByVal fromControlID As String, ByVal fromNoteType As Enum_DropDownList)
            Me.ControlID = fromControlID
            Me.Note_Type = fromNoteType
        End Sub
    End Class

    Private Function FL_ListOfNumberColumn() As List(Of ListVeiw2_Textbox)
        Dim W_DDList2 As New List(Of ListVeiw2_Textbox)
        W_DDList2.Add(New ListVeiw2_Textbox("DISPLAY_SEQ", "0", "群組序號"))
        W_DDList2.Add(New ListVeiw2_Textbox("RESULT_FORMAT", "3", "小數位數"))
        Return W_DDList2
    End Function
    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        Dim W_DoModeIs As LabRecordA2_Setting_Module.EditMode_Enum
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        Dim W_Obj_ListView As ListView = CType(sender, ListView)
        Dim W_Obj_ListViewItem As ListViewItem = Nothing
        Dim W_Obj_DropDownList As DropDownList = Nothing
        Dim W_Obj_HiddenField As HiddenField = Nothing
        Dim W_Obj_TextBox As TextBox = Nothing
        Dim validatorObjl As CustomValidator = Nothing

        Dim W_SelectValue As String = ""
        Dim W_AssayIDNumber As String

        If Not W_Obj_ListView.EditItem Is Nothing Then
            W_Obj_ListViewItem = W_Obj_ListView.EditItem
            W_DoModeIs = EditMode_Enum.編輯

        ElseIf Not W_Obj_ListView.InsertItem Is Nothing Then
            W_Obj_ListViewItem = W_Obj_ListView.InsertItem
            W_DoModeIs = EditMode_Enum.新增
        End If

        If W_Obj_ListViewItem Is Nothing Then Exit Sub

        'Step0：驗證要是沒有過就直接跳走，不更新畫面資料
        '---------------------------------------------------------------------------------------
        validatorObjl = W_Obj_ListViewItem.FindControl("CustomValidator1")
        If (validatorObjl.ErrorMessage.Trim.Length > 0) Then Exit Sub


        'Step1：畫面上DropDownList選單內容
        '---------------------------------------------------------------------------------------
        Dim W_DDList1 As New List(Of ListView1_DropDownList)
        W_DDList1.Add(New ListView1_DropDownList("ASSAY_ID", Enum_DropDownList.檢驗項目基本檔_代號群組))
        W_DDList1.Add(New ListView1_DropDownList("DISPLAY_FLAG", Enum_DropDownList.檢驗項目基本檔_是否顯示))
        W_DDList1.Add(New ListView1_DropDownList("RESULT_KIND", Enum_DropDownList.檢驗項目基本檔_資料來源類型))
        W_DDList1.Add(New ListView1_DropDownList("EFF_FLAG", Enum_DropDownList.檢驗項目基本檔_停用否))

        For Each eachItem1 As ListView1_DropDownList In W_DDList1
            W_Obj_DropDownList = CType(W_Obj_ListViewItem.FindControl(String.Concat(eachItem1.ControlID, C_Fix_DropDown)), DropDownList)
            P_DropDownList_SetItem(eachItem1.Note_Type, W_Obj_DropDownList)

            'Step1A：EditItem模式
            '---------------------------------------------------------------------------------------
            If W_DoModeIs = EditMode_Enum.編輯 Then
                W_Obj_HiddenField = CType(W_Obj_ListViewItem.FindControl(String.Concat(eachItem1.ControlID, C_Fix_HiddenField)), HiddenField)
                W_SelectValue = W_Obj_HiddenField.Value
                ModTools.SelectedIndexByValue(W_Obj_DropDownList, W_SelectValue)

                If eachItem1.Note_Type = Enum_DropDownList.檢驗項目基本檔_代號群組 Then
                    W_AssayIDNumber = W_SelectValue.Substring(2)
                    W_SelectValue = W_SelectValue.Substring(0, 2)

                    W_Obj_TextBox = CType(W_Obj_ListViewItem.FindControl(String.Concat(eachItem1.ControlID, C_Fix_TextBox)), TextBox)
                    W_Obj_TextBox.Text = W_AssayIDNumber
                End If

                '---------------------------------------------------------------------------------------

            Else
                'Step1B：InsertItem模式
                '---------------------------------------------------------------------------------------
                If eachItem1.Note_Type = Enum_DropDownList.檢驗項目基本檔_代號群組 Then
                    W_SelectValue = W_ClsSystemNote.Fs_GetStrBefor(queryASSAY_IDDropDownList.SelectedValue, LabRecordA2_Setting_Module.C_ClsSystemNote_Display_Symbol)
                    ModTools.SelectedIndexByValue(W_Obj_DropDownList, W_SelectValue)
                End If

                '---------------------------------------------------------------------------------------
            End If

        Next


        'Step2：畫面上Textbox內容預設值
        '---------------------------------------------------------------------------------------
        If W_DoModeIs = EditMode_Enum.新增 Then

            For Each eachItem2 As ListVeiw2_Textbox In FL_ListOfNumberColumn()
                W_Obj_TextBox = CType(W_Obj_ListViewItem.FindControl(String.Concat(eachItem2.ControlID, C_Fix_TextBox)), TextBox)
                W_Obj_TextBox.Text = eachItem2.DefaultValue
            Next
        End If


        'Step3：鎖定不可以編輯物件 
        '---------------------------------------------------------------------------------------
        'ASSAY_ID
        W_Obj_TextBox = CType(W_Obj_ListViewItem.FindControl(String.Concat("ASSAY_ID", C_Fix_TextBox)), TextBox)
        W_Obj_DropDownList = CType(W_Obj_ListViewItem.FindControl(String.Concat("ASSAY_ID", C_Fix_DropDown)), DropDownList)

        P_LockAndRefreshController(W_DoModeIs, W_Obj_TextBox)
        P_LockAndRefreshController(W_DoModeIs, W_Obj_DropDownList)
        '---------------------------------------------------------------------------------------
    End Sub

#End Region


#Region "鎖定畫面上物件：P_LockAndRefreshController"

    Private Sub P_LockAndRefreshController(ByVal fromEditMode As EditMode_Enum)

        For Each eachItem As System.Web.UI.Control In Me.ListView1.Controls
            P_LockAndRefreshController(fromEditMode, eachItem)
        Next
    End Sub

    Private Sub P_LockAndRefreshController(ByVal fromEditMode As EditMode_Enum, ByVal fromControl As Control)
        Dim objDropDownList As DropDownList
        Dim objTextBox As TextBox

        Select Case True

            Case TypeOf fromControl Is DropDownList
                objDropDownList = CType(fromControl, DropDownList)

                Select Case fromEditMode
                    Case EditMode_Enum.新增
                        objDropDownList.Enabled = True
                    Case Else
                        objDropDownList.Enabled = False
                End Select

            Case TypeOf fromControl Is TextBox
                objTextBox = CType(fromControl, TextBox)

                objTextBox.Enabled = False

                objTextBox.BackColor = IIf(objTextBox.Enabled = True, C_RGBColorUNLock, C_RGBColorLock)
                objTextBox.ForeColor = IIf(objTextBox.Enabled = True, C_RGBTextColorUnLock, C_RGBTextColorLock)

                objTextBox.ReadOnly = Not (objTextBox.Enabled)
                objTextBox.Text = IIf(objTextBox.Enabled = True, "", objTextBox.Text)

                objTextBox.Enabled = True

            Case Else


        End Select


    End Sub

#End Region


#Region "CustomValidator1：資料驗證"
    Public Sub CustomValidator1_ServerValidate(source As Object, args As System.Web.UI.WebControls.ServerValidateEventArgs) 'Handles CustomValidator1.ServerValidate
        Dim validatorObjl As CustomValidator = Nothing
        Dim listViewItemObj As System.Web.UI.WebControls.ListViewItem = Nothing
        Dim textboxObj As TextBox = Nothing
        Dim W_ERR_MSG As String = ""
        Dim W_DoModeIs As LabRecordA2_Setting_Module.EditMode_Enum

        If LabRecordA2_Setting_Module.Main_Targe_IsMe(W_Now主畫面_Enum) = False Then Exit Sub


        '特別地方: 修改時 InsertItem與 EditItem 都會存在
        '                   新增時 InsertItem
        If Not ListView1.InsertItem Is Nothing Then
            listViewItemObj = ListView1.InsertItem
            W_DoModeIs = EditMode_Enum.新增
        End If
        If Not ListView1.EditItem Is Nothing Then
            listViewItemObj = ListView1.EditItem
            W_DoModeIs = EditMode_Enum.編輯
        End If

        If Not listViewItemObj Is Nothing Then
            validatorObjl = listViewItemObj.FindControl("CustomValidator1")
            validatorObjl.ErrorMessage = String.Empty

            For Each eachItem2 As ListVeiw2_Textbox In FL_ListOfNumberColumn()
                textboxObj = listViewItemObj.FindControl(eachItem2.ControlID & C_Fix_TextBox)

                If Integer.TryParse(textboxObj.Text, New Integer) = False Then
                    If W_ERR_MSG <> "" Then W_ERR_MSG &= "、"

                    W_ERR_MSG &= "『" & eachItem2.Title & "』"
                End If
            Next

            If W_ERR_MSG <> "" Then
                validatorObjl.ErrorMessage = "輸入的 " & W_ERR_MSG & " 格式錯誤"
            End If

            args.IsValid = (validatorObjl.ErrorMessage.Trim.Length = 0)
        End If
    End Sub
#End Region

    Public Function FS_DATE_FORMAT(ByVal fromDate As Date, ByVal fromType As Integer) As String
        Return LabRecordA2_Setting_Module.FS_DATE_FORMAT(fromDate, fromType)
    End Function

    Public Function FS_NORMAL_RANGE(ByVal fromNORMAL_RANGE_L As String, ByVal fromNORMAL_RANGE_H As String) As String
        Return LabRecordA2_Setting_Module.FS_NORMAL_RANGE(fromNORMAL_RANGE_L, fromNORMAL_RANGE_H)
    End Function

End Class