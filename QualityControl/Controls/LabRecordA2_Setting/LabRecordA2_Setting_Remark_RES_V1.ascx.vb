Imports CompanyORMDB.SQLServer.QCDB01

Public Class LabRecordA2_Setting_Remark_RES_V1
    Inherits System.Web.UI.UserControl

    Private Shared WP_AS400SQLQueryAdapter As New AS400SQLQueryAdapter
    Private WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

    Dim WP_SQLAdapter_Server04M_QCdb01 As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")

    'Private C_SYSTEM_TYPE As String = "品保_檢驗證明書"
    'Private C_Fix_DropDownList As String = "DropDownList"
    'Private C_Fix_CheckBox As String = "CheckBox"

#Region "GetDataKey"
    Private WP_editKey1 As String = ""
    Private WP_editKey2 As String = ""
    Private WP_editKey3 As String = ""
    Private WP_editKey4 As String = ""
    Private WP_editKey5 As String = ""

    Private WP_editEFF_FLAG As String = ""

    Private WP_editCustomValidator As String

    Private Sub P_Init_WP_Edit()
        WP_editKey1 = ""
        WP_editKey2 = ""
        WP_editKey3 = ""
        WP_editKey4 = ""
        WP_editKey5 = ""

        WP_editEFF_FLAG = ""

        WP_editCustomValidator = ""
    End Sub

    Protected Sub editKey3DropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)
        P_KeeyValue_Item()

        Dim W_Obj_ListViewItem As ListViewItem = Me.ListView1.InsertItem
        If W_Obj_ListViewItem Is Nothing Then Exit Sub

        Dim W_ObjDropDownList As DropDownList = CType(sender, DropDownList)
        Dim W_editKey4DropDownList As DropDownList
        If W_ObjDropDownList.ID = "EditKey3DropDownList" Then
            W_editKey4DropDownList = CType((W_Obj_ListViewItem.FindControl("EditKey4DropDownList")), DropDownList)
            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey4_材質(W_editKey4DropDownList, W_ObjDropDownList.SelectedValue)
        End If

        WP_editCustomValidator = ""
        ListView1_CheckNeed_Not = True
    End Sub

    Protected Sub P_KeeyValue_Item()
        Dim W_Obj_ListViewItem As ListViewItem = Nothing
        Dim W_DoModeIs As LabRecordA2_Setting_Module.EditMode_Enum

        If Not ListView1.EditItem Is Nothing Then
            W_Obj_ListViewItem = ListView1.EditItem
            W_DoModeIs = EditMode_Enum.編輯

        ElseIf Not ListView1.InsertItem Is Nothing Then
            W_Obj_ListViewItem = ListView1.InsertItem
            W_DoModeIs = EditMode_Enum.新增
        End If

        If W_Obj_ListViewItem Is Nothing Then Exit Sub

        If W_DoModeIs = EditMode_Enum.新增 Then
            WP_editKey1 = CType((W_Obj_ListViewItem.FindControl("EditKey1DropDownList")), DropDownList).SelectedValue
            WP_editKey2 = CType((W_Obj_ListViewItem.FindControl("EditKey2DropDownList")), DropDownList).SelectedValue
            WP_editKey3 = CType((W_Obj_ListViewItem.FindControl("EditKey3DropDownList")), DropDownList).SelectedValue
            WP_editKey4 = CType((W_Obj_ListViewItem.FindControl("EditKey4DropDownList")), DropDownList).SelectedValue
            WP_editKey5 = CType((W_Obj_ListViewItem.FindControl("EditKey5DropDownList")), DropDownList).SelectedValue

        ElseIf W_DoModeIs = EditMode_Enum.編輯 Then
            WP_editKey1 = ""
            WP_editKey2 = ""
            WP_editKey3 = ""
            WP_editKey4 = ""
            WP_editKey5 = ""
        End If


        WP_editEFF_FLAG = CType((W_Obj_ListViewItem.FindControl("EditEFF_FLAGDropDownList")), DropDownList).SelectedValue

        WP_editCustomValidator = CType((W_Obj_ListViewItem.FindControl("CV_EditItem")), CustomValidator).ErrorMessage
    End Sub

    Protected Sub queryKeyDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles queryKey1DropDownList.SelectedIndexChanged, queryKey5DropDownList.SelectedIndexChanged
        Dim W_ObjDropDownList As DropDownList = CType(sender, DropDownList)
        Dim W_ObjID As String = W_ObjDropDownList.ID.Replace(C_Fix_DropDownList, "")
        Dim W_ObjCheckBox As CheckBox = CType(FindControl(String.Concat(W_ObjID, C_Fix_CheckBox)), CheckBox)

        Select Case Microsoft.VisualBasic.Right(W_ObjID, 1)
            Case "1"
                W_ObjCheckBox = queryKey1CheckBox
            Case "2"
                W_ObjCheckBox = queryKey2CheckBox
            Case "3"
                W_ObjCheckBox = queryKey3CheckBox
                LabRecordA2_Setting_Module.P_SetDropDownList_DataKey4_材質(queryKey4DropDownList, queryKey3DropDownList.SelectedValue)
            Case "4"
                W_ObjCheckBox = queryKey4CheckBox
        End Select

        W_ObjCheckBox.Checked = True
        ListView1_CheckNeed_Not = True
    End Sub
#End Region



#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    Private Sub MakeQryStringToControl()
        Dim queryTime As String = Now.ToString("HHmmss")

        Dim querySql As New StringBuilder
        querySql.Append("Select * " & vbNewLine)
        querySql.Append("FROM [LabRecordA2_Remark_RES] " & vbNewLine)
        querySql.Append("WHERE 1=1 " & vbNewLine)

        If queryKey1CheckBox.Checked = True Then
            querySql.Append("AND [參照規範] = '" & queryKey1DropDownList.SelectedValue & "' " & vbNewLine)
        End If
        If queryKey2CheckBox.Checked = True Then
            querySql.Append("AND [表面類別] = '" & queryKey2DropDownList.SelectedValue & "' " & vbNewLine)
        End If
        If queryKey3CheckBox.Checked = True Then
            querySql.Append("AND [鋼種] = '" & queryKey3DropDownList.SelectedValue & "' " & vbNewLine)
        End If
        If queryKey4CheckBox.Checked = True Then
            querySql.Append("AND [材質] = '" & queryKey4DropDownList.SelectedValue & "' " & vbNewLine)
        End If

        If queryKey5CheckBox.Checked = True Then
            Dim W_REMARKID As String = WP_ClsSystemNote.Fs_GetStrBefor(queryKey5DropDownList.SelectedValue, WP_ClsSystemNote.Display_Symbol)
            querySql.Append("AND [REMARK_ID] = '" & W_REMARKID & "' " & vbNewLine)
        End If

        Dim W_EFF_FLAG As String = WP_ClsSystemNote.Fs_GetStrBefor(queryEFF_FLAGDropDown.SelectedValue, WP_ClsSystemNote.Display_Symbol)
        If W_EFF_FLAG <> "ALL" Then
            querySql.Append("AND EFF_FLAG ='" & W_EFF_FLAG & "' " & vbNewLine)
        End If

        querySql.Append("ORDER BY [參照規範], [表面類別], [鋼種], [材質], [REMARK_ID] " & vbNewLine)

        Me.hfSQL.Value = queryTime & "|" & querySql.ToString
    End Sub
#End Region

#Region "CRUD"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL As String) As List(Of LabRecordA2_Remark_RES)
        If String.IsNullOrEmpty(fromSQL) OrElse fromSQL = "" _
            OrElse fromSQL.Split("|").Count < 2 Then
            Return New List(Of LabRecordA2_Remark_RES)
        End If

        Dim dtResult As List(Of LabRecordA2_Remark_RES) = _
                    LabRecordA2_Remark_RES.CDBSelect(Of LabRecordA2_Remark_RES)(fromSQL.Split("|")(1), WP_SQLAdapter_Server04M_QCdb01)

        Return dtResult
    End Function

    <DataObjectMethod(DataObjectMethodType.Insert)>
    Public Function Insert(ByVal fromObj As LabRecordA2_Remark_RES) As Integer
        Return fromObj.CDBInsert
    End Function

    <DataObjectMethod(DataObjectMethodType.Update)>
    Public Function Update(ByVal fromObj As LabRecordA2_Remark_RES) As Integer
        Return fromObj.CDBUpdate
    End Function

    <DataObjectMethod(DataObjectMethodType.Delete)>
    Public Function Delete(ByVal fromObj As LabRecordA2_Remark_RES) As Integer
        Return fromObj.CDBDelete
    End Function

#End Region

    Protected Sub btnSerach_Click(sender As Object, e As EventArgs) Handles btnSerach.Click
        ListView1.EditIndex = -1
        ListView1_CheckNeed_Not = True

        P_Init_WP_Edit()

        MakeQryStringToControl()
        ListView1.DataBind()
    End Sub

#Region "ListView1"
    Private C_hfCheckNeed_Not As String = "hfCheckNeed_Not"
    Private Property ListView1_CheckNeed_Not As Boolean
        Get
            Dim retFalg As Boolean

            retFalg = IIf(CType(Me.FindControl(C_hfCheckNeed_Not), HiddenField).Value = "", True, False)
            Return retFalg
        End Get

        Set(value As Boolean)
            Dim setFlag As String
            setFlag = IIf(value = True, "V", "")
            CType(Me.FindControl(C_hfCheckNeed_Not), HiddenField).Value = setFlag
        End Set
    End Property

    Public Sub CustomValidator_1_Insert_ServerValidate(source As Object, args As System.Web.UI.WebControls.ServerValidateEventArgs) 'Handles CustomValidator1.ServerValidate
        Dim validatorObjl As CustomValidator = Nothing
        Dim listViewItemObj As System.Web.UI.WebControls.ListViewItem = Nothing
        Dim textboxObj As TextBox = Nothing
        Dim W_DoModeIs As LabRecordA2_Setting_Module.EditMode_Enum

        If ListView1_CheckNeed_Not = True Then
            ListView1_CheckNeed_Not = False
            Exit Sub
        End If

        If Not ListView1.EditItem Is Nothing Then
            listViewItemObj = ListView1.EditItem
            W_DoModeIs = EditMode_Enum.編輯

        ElseIf Not ListView1.InsertItem Is Nothing Then
            listViewItemObj = ListView1.InsertItem
            W_DoModeIs = EditMode_Enum.新增
        End If

        If Not listViewItemObj Is Nothing Then
            Dim W_MSG As String = ""

            validatorObjl = CType(listViewItemObj.FindControl("CV_EditItem"), CustomValidator)
            'textboxObj = CType(listViewItemObj.FindControl("editRESULT_FORMATTextBox"), TextBox)

            'validatorObjl.ErrorMessage = String.Empty

            'If IsNumeric(textboxObj.Text) = False Then
            '    If W_MSG <> "" Then W_MSG &= "、"
            '    W_MSG &= "『小數點位數』格式錯誤"
            'End If

            If W_DoModeIs = EditMode_Enum.新增 Then
                '-- 新增 ---------------------------------------------------------------------------
                Dim dropDownListObj As DropDownList = Nothing
                Dim flag1_Plus As Boolean, flag2_Minus As Boolean
                Dim W_SQL As New StringBuilder
                W_SQL.Append("Select * From [LabRecordA2_REMARK_RES] WHERE 1=1 " & vbNewLine)

                For II = 1 To 4
                    dropDownListObj = listViewItemObj.FindControl(String.Concat("EditKey", II, C_Fix_DropDownList))

                    If dropDownListObj.SelectedValue = "+" Then
                        flag1_Plus = True
                    ElseIf dropDownListObj.SelectedValue = "-" Then
                        flag2_Minus = True
                    End If

                    Select Case II
                        Case 1
                            W_SQL.Append("AND  [參照規範] = '" & dropDownListObj.SelectedValue & "' " & vbNewLine)
                        Case 2
                            W_SQL.Append("AND  [表面類別] = '" & dropDownListObj.SelectedValue & "' " & vbNewLine)
                        Case 3
                            W_SQL.Append("AND  [鋼種] = '" & dropDownListObj.SelectedValue & "' " & vbNewLine)
                        Case 4
                            W_SQL.Append("AND  [材質] = '" & dropDownListObj.SelectedValue & "' " & vbNewLine)
                    End Select

                Next II

                If (flag1_Plus = True AndAlso flag2_Minus = True) Then
                    If W_MSG <> "" Then W_MSG &= "、"
                    W_MSG &= "『保留字+-』不可同時出現"
                End If

                dropDownListObj = listViewItemObj.FindControl(String.Concat("EditKey", 5, C_Fix_DropDownList))
                Dim W_REMARKID As String = WP_ClsSystemNote.Fs_GetStrBefor(dropDownListObj.SelectedValue, WP_ClsSystemNote.Display_Symbol)
                W_SQL.Append("AND [REMARK_ID] = '" & W_REMARKID & "' " & vbNewLine)

                Dim queryList As List(Of CompanyORMDB.SQLServer.QCDB01.LabRecordA2_Remark_RES) = _
                    CompanyORMDB.SQLServer.QCDB01.LabRecordA2_Remark_RES.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.LabRecordA2_Remark_RES)(W_SQL.ToString, WP_SQLAdapter_Server04M_QCdb01)

                If queryList.Count > 0 Then
                    If W_MSG <> "" Then W_MSG &= "、"
                    W_MSG &= "『KEY重複』"
                End If

                '-- 新增 ---------------------------------------------------------------------------
            End If

            If W_MSG <> "" Then
                validatorObjl.ErrorMessage = "Check：" & W_MSG
            Else
                validatorObjl.ErrorMessage = ""
            End If
            args.IsValid = (validatorObjl.ErrorMessage.Trim.Length = 0)

            If (args.IsValid = False) Then
                P_KeeyValue_Item()
            End If

        End If

    End Sub

    Private Sub ListView1_ItemCommand(sender As Object, e As ListViewCommandEventArgs) Handles ListView1.ItemCommand
        Select Case e.CommandName
            Case "ReadDefault"
                WP_editCustomValidator = ""

            Case "Edit"
                ListView1.InsertItemPosition = InsertItemPosition.None
                P_Init_WP_Edit()

            Case "Update"
                If WP_editCustomValidator = "" Then
                    ListView1.InsertItemPosition = InsertItemPosition.LastItem
                    P_Init_WP_Edit()
                End If

            Case "Cancel"       'Type 1：編輯未完成離開   Type2：新增未完成離開
                ListView1.InsertItemPosition = InsertItemPosition.LastItem
                P_Init_WP_Edit()

            Case Else
                ListView1.InsertItemPosition = InsertItemPosition.LastItem
        End Select

    End Sub

    Private Sub ListView1_ItemInserted(sender As Object, e As ListViewInsertedEventArgs) Handles ListView1.ItemInserted
        ListView1.DataBind()
    End Sub

    Private Sub ListView1_ItemInserting(sender As Object, e As ListViewInsertEventArgs) Handles ListView1.ItemInserting
        Dim W_Obj_listView As ListViewItem = CType(sender, ListView).InsertItem
        e.Values("參照規範") = CType(W_Obj_listView.FindControl("EditKey1DropDownList"), DropDownList).SelectedValue
        e.Values("表面類別") = CType(W_Obj_listView.FindControl("EditKey2DropDownList"), DropDownList).SelectedValue
        e.Values("鋼種") = CType(W_Obj_listView.FindControl("EditKey3DropDownList"), DropDownList).SelectedValue
        e.Values("材質") = CType(W_Obj_listView.FindControl("EditKey4DropDownList"), DropDownList).SelectedValue

        e.Values("REMARK_ID") = WP_ClsSystemNote.Fs_GetStrBefor(CType(W_Obj_listView.FindControl("EditKey5DropDownList"), DropDownList).SelectedValue, WP_ClsSystemNote.Display_Symbol)

        e.Values("EFF_FLAG") = WP_ClsSystemNote.Fs_GetStrBefor(CType(W_Obj_listView.FindControl("EditEFF_FLAGDropDownList"), DropDownList).SelectedValue, WP_ClsSystemNote.Display_Symbol)
    End Sub

    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Dim W_Obj_listView As ListViewItem = CType(sender, ListView).EditItem
        e.NewValues("EFF_FLAG") = WP_ClsSystemNote.Fs_GetStrBefor(CType(W_Obj_listView.FindControl("EditEFF_FLAGDropDownList"), DropDownList).SelectedValue, WP_ClsSystemNote.Display_Symbol)
    End Sub

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        Dim listViewItemObj As System.Web.UI.WebControls.ListViewItem = Nothing
        Dim dropDownListObj1 As DropDownList, dropDownListObj2 As DropDownList
        Dim hiddenFieldObj As HiddenField
        Dim W_DoModeIs As LabRecordA2_Setting_Module.EditMode_Enum

        If Not ListView1.EditItem Is Nothing Then
            listViewItemObj = ListView1.EditItem
            W_DoModeIs = EditMode_Enum.編輯

            dropDownListObj1 = CType(listViewItemObj.FindControl("EditEFF_FLAGDropDownList"), DropDownList)
            P_DropDownList_SetItem(Enum_DropDownList.檢驗項目基本檔_停用否, dropDownListObj1)

            hiddenFieldObj = CType(listViewItemObj.FindControl("EFF_FLAGHiddenField"), HiddenField)
            PublicClassLibrary.ModTools.SelectedIndexByText(dropDownListObj1, hiddenFieldObj.Value)

        ElseIf Not ListView1.InsertItem Is Nothing Then
            listViewItemObj = ListView1.InsertItem
            W_DoModeIs = EditMode_Enum.新增

            dropDownListObj1 = CType(listViewItemObj.FindControl("EditEFF_FLAGDropDownList"), DropDownList)
            P_DropDownList_SetItem(Enum_DropDownList.檢驗項目基本檔_停用否, dropDownListObj1)
            If WP_editEFF_FLAG <> "" Then
                dropDownListObj1.SelectedValue = WP_editEFF_FLAG

            ElseIf WP_ClsSystemNote.Fs_GetStrBefor(queryEFF_FLAGDropDown.SelectedValue, WP_ClsSystemNote.Display_Symbol) <> "ALL" Then
                dropDownListObj1.SelectedValue = queryEFF_FLAGDropDown.SelectedValue
            End If

            'Key1
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey1DropDownList"), DropDownList)
            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey1_參照規範(dropDownListObj1)
            If WP_editKey1 <> "" Then
                dropDownListObj1.SelectedValue = WP_editKey1

            ElseIf queryKey1CheckBox.Checked = True Then
                dropDownListObj1.SelectedValue = queryKey1DropDownList.SelectedValue
            End If

            'Key2
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey2DropDownList"), DropDownList)
            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey2_表面類別(dropDownListObj1)
            If WP_editKey2 <> "" Then
                dropDownListObj1.SelectedValue = WP_editKey2

            ElseIf queryKey2CheckBox.Checked = True Then
                dropDownListObj1.SelectedValue = queryKey2DropDownList.SelectedValue
            End If

            'Key3
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey3DropDownList"), DropDownList)
            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey3_鋼種(dropDownListObj1)
            If WP_editKey3 <> "" Then
                ModTools.SelectedIndexByValue(dropDownListObj1, WP_editKey3)

            ElseIf queryKey3CheckBox.Checked = True Then
                dropDownListObj1.SelectedValue = queryKey3DropDownList.SelectedValue
            End If

            'Key4
            dropDownListObj2 = dropDownListObj1
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey4DropDownList"), DropDownList)
            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey4_材質(dropDownListObj1, dropDownListObj2.SelectedValue)
            If WP_editKey4 <> "" Then
                ModTools.SelectedIndexByValue(dropDownListObj1, WP_editKey4)

            ElseIf queryKey4CheckBox.Checked = True Then
                dropDownListObj1.SelectedValue = queryKey4DropDownList.SelectedValue
            End If

            'Key5
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey5DropDownList"), DropDownList)
            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey5_片語代號(dropDownListObj1)
            If WP_editKey5 <> "" Then
                dropDownListObj1.SelectedValue = WP_editKey5
            End If

        End If

        '-- Same ------------------------------------------------------------



        Dim customValidatorObj As CustomValidator
        customValidatorObj = CType(listViewItemObj.FindControl("CV_EditItem"), CustomValidator)
        customValidatorObj.ErrorMessage = WP_editCustomValidator
        customValidatorObj.IsValid = (customValidatorObj.ErrorMessage.Length = 0)

        Call P_Init_WP_Edit()
        '-- Same ------------------------------------------------------------
    End Sub


#End Region


#Region "P_INIT"
    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            P_INIT()
        End If
    End Sub

    Private Sub P_INIT()
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey1_參照規範(queryKey1DropDownList)
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey2_表面類別(queryKey2DropDownList)
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey3_鋼種(queryKey3DropDownList)
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey4_材質(queryKey4DropDownList, queryKey3DropDownList.SelectedValue)
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey5_片語代號(queryKey5DropDownList)

        P_DropDownList_SetItem(Enum_DropDownList.檢驗項目基本檔_停用否, queryEFF_FLAGDropDown)
        queryEFF_FLAGDropDown.Items.Add("ALL：全部")

    End Sub

    Protected Function showRemarkInfo(ByVal fromRemarkID As String) As String
        Return LabRecordA2_Setting_Module.FS_Get_DataKey5_片語代號名稱(fromRemarkID)
    End Function
#End Region

#Region "SystemNote"
    Public Enum Enum_DropDownList
        檢驗項目基本檔_停用否 = 1
        檢驗項目基本檔_代號群組 = 2
        檢驗項目基本檔_資料來源類型 = 3
        檢驗項目基本檔_是否顯示 = 4
    End Enum

    Public Sub P_DropDownList_SetItem(ByVal fromNote_Type As Enum_DropDownList, _
                                        ByRef fromObj As DropDownList)

        Dim W_NoteType As String = [Enum].GetName(GetType(Enum_DropDownList), fromNote_Type)
        Dim queryDataTable1 As DataTable
        queryDataTable1 = WP_ClsSystemNote.getLev3(C_SYSTEM_TYPE, W_NoteType)
        WP_ClsSystemNote.setDropDownList(fromObj, queryDataTable1, WP_ClsSystemNote.Display_Lable)
    End Sub


#End Region





End Class