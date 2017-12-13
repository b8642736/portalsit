﻿Imports CompanyORMDB.SQLServer.QCDB01

Public Class LabRecordA2_Setting_Assay_RES_V2
    Inherits System.Web.UI.UserControl
    'Private WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote


#Region "GetDataKey"
    Protected Sub editKey3DropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim W_Obj_ListViewItem As ListViewItem = Me.ListView1.InsertItem
        If W_Obj_ListViewItem Is Nothing Then Exit Sub

        Dim W_ObjDropDownList As DropDownList = CType(sender, DropDownList)
        Dim W_editKey4DropDownList As DropDownList

        '----------------------------------------------------
        P_DropboxList_Vaule_Set(W_Obj_ListViewItem)
        '----------------------------------------------------

        If W_ObjDropDownList.ID = "EditKey3DropDownList" Then
            W_editKey4DropDownList = CType((W_Obj_ListViewItem.FindControl("EditKey4DropDownList")), DropDownList)
            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey4_材質(W_editKey4DropDownList, W_ObjDropDownList.SelectedValue)
        End If

    End Sub

    Protected Sub queryKeyDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)
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

    End Sub

    Protected Sub P_DropboxList_Vaule_Set(ByRef fromListViewItem As ListViewItem)
        P_DropboxList_Vaule_DoLoop(fromListViewItem, Enum_VauleDoMode.i_1_Set_ALL)
    End Sub
    Protected Sub P_DropboxList_Vaule_Set_NOT_Normal_range_Result_format(ByRef fromListViewItem As ListViewItem)
        P_DropboxList_Vaule_DoLoop(fromListViewItem, Enum_VauleDoMode.i_1_Set_NOT_Normal_range_Result_format)
    End Sub
    Protected Sub P_DropboxList_Vaule_Set_NOT_Key(ByRef fromListViewItem As ListViewItem)
        P_DropboxList_Vaule_DoLoop(fromListViewItem, Enum_VauleDoMode.i_1_Set_NOT_Key)
    End Sub
    Protected Sub P_DropboxList_Vaule_Set_ONLY_Eff_flag(ByRef fromListViewItem As ListViewItem)
        P_DropboxList_Vaule_DoLoop(fromListViewItem, Enum_VauleDoMode.i_1_Set_ONLY_Eff_flag)
    End Sub

    Protected Sub P_DropboxList_Vaule_Get(ByRef fromListViewItem As ListViewItem)
        P_DropboxList_Vaule_DoLoop(fromListViewItem, Enum_VauleDoMode.i_2_Get_ALL)
    End Sub

    Class CS_ListView_Array_Info
        Public W_NameOfDropboxList As String
        Public W_NameOfTextbox As String
        Public W_NeedSpecialChar As Boolean

        Sub New(ByVal fromNameOfDropboxList As String, ByVal fromNameOfTextbox As String, ByVal fromNeedSpecialChar As Boolean)
            Me.W_NameOfDropboxList = fromNameOfDropboxList
            Me.W_NameOfTextbox = fromNameOfTextbox
            Me.W_NeedSpecialChar = fromNeedSpecialChar
        End Sub
    End Class


    Private Function PA_CS_ListView_Array_Info_ItemGet(ByVal fromObjKind As Integer _
                                                                                                      , ByVal fromObjName As String) As CS_ListView_Array_Info
        Dim retObj As CS_ListView_Array_Info = Nothing

        For Each eachItem As CS_ListView_Array_Info In WP_CS_ListView_Array_Info_List
            Select Case fromObjKind
                Case 1  'NameOfDropboxList
                    If eachItem.W_NameOfDropboxList.Equals(fromObjName) = True Then
                        retObj = eachItem
                        Return retObj
                    End If

                Case 2  'NameOfTextbox
                    If eachItem.W_NameOfTextbox.Equals(fromObjName) = True Then
                        retObj = eachItem
                        Return retObj
                    End If

            End Select
        Next

        Return retObj
    End Function

    Private _WP_CS_ListView_Array_Info_List As List(Of CS_ListView_Array_Info) = Nothing
    Private ReadOnly Property WP_CS_ListView_Array_Info_List As List(Of CS_ListView_Array_Info)
        Get
            If _WP_CS_ListView_Array_Info_List Is Nothing Then
                Dim W_CS_ListView_Array_Info As New List(Of CS_ListView_Array_Info)
                W_CS_ListView_Array_Info.Add(New CS_ListView_Array_Info("EditKey1DropDownList", "參照規範TextBox", False))
                W_CS_ListView_Array_Info.Add(New CS_ListView_Array_Info("EditKey2DropDownList", "表面類別TextBox", False))
                W_CS_ListView_Array_Info.Add(New CS_ListView_Array_Info("EditKey3DropDownList", "鋼種TextBox", False))
                W_CS_ListView_Array_Info.Add(New CS_ListView_Array_Info("EditKey4DropDownList", "材質TextBox", False))
                W_CS_ListView_Array_Info.Add(New CS_ListView_Array_Info("EditKey5DropDownList", "ASSAY_IDTextBox", True))
                W_CS_ListView_Array_Info.Add(New CS_ListView_Array_Info("EditEFF_FLAGDropDownList", "EFF_FLAGTextBox", True))

                _WP_CS_ListView_Array_Info_List = W_CS_ListView_Array_Info
            End If

            Return _WP_CS_ListView_Array_Info_List
        End Get
    End Property

    Enum Enum_VauleDoMode
        Kind_i_1_Set = 1
        i_1_Set_ALL = 110
        i_1_Set_NOT_Normal_range_Result_format = 120
        i_1_Set_NOT_Key = 125
        i_1_Set_ONLY_Eff_flag = 130

        Kind_i_2_Get = 2
        i_2_Get_ALL = 210
    End Enum

    Protected Sub P_DropboxList_Vaule_DoLoop(ByRef fromListViewItem As ListViewItem _
                                                                          , ByVal fromDoMode As Enum_VauleDoMode)

        For Each eachDoItem As CS_ListView_Array_Info In WP_CS_ListView_Array_Info_List

            Select Case fromDoMode
                Case Enum_VauleDoMode.i_1_Set_NOT_Normal_range_Result_format
                    If (eachDoItem.W_NameOfDropboxList.Substring(0, "EditNORMAL_RANGE_L".Length).Equals("EditNORMAL_RANGE_L") _
                            Or eachDoItem.W_NameOfDropboxList.Substring(0, "EditNORMAL_RANGE_H".Length).Equals("EditNORMAL_RANGE_H") _
                            Or eachDoItem.W_NameOfDropboxList.Substring(0, "EditRESULT_FORMAT".Length).Equals("EditRESULT_FORMAT")) Then
                        Continue For
                    End If

                Case Enum_VauleDoMode.i_1_Set_NOT_Key
                    If (eachDoItem.W_NameOfDropboxList.Substring(0, "EditKey".Length).Equals("EditKey")) Then
                        Continue For
                    End If

                Case Enum_VauleDoMode.i_1_Set_ONLY_Eff_flag
                    If Not (eachDoItem.W_NameOfDropboxList.Substring(0, "EditEFF_FLAG".Length).Equals("EditEFF_FLAG")) Then
                        Continue For
                    End If

            End Select

            P_DropboxList_Vaule_DoOneItem(fromListViewItem, fromDoMode, eachDoItem)
        Next
    End Sub

    Protected Sub P_DropboxList_Vaule_DoOneItem(ByRef fromListViewItem As ListViewItem _
                                                                              , ByVal fromDoMode As Enum_VauleDoMode _
                                                                              , ByVal fromDoItem As CS_ListView_Array_Info)
        Dim W_ObjDropDownList As DropDownList
        Dim W_ObjTextBox As TextBox = Nothing
        Dim W_TextValue As String
        Dim C_Enum_FixNum As Integer = 100

        W_ObjDropDownList = CType((fromListViewItem.FindControl(fromDoItem.W_NameOfDropboxList)), DropDownList)
        W_ObjTextBox = CType((fromListViewItem.FindControl(fromDoItem.W_NameOfTextbox)), TextBox)

        If (fromDoMode \ C_Enum_FixNum) = Enum_VauleDoMode.Kind_i_1_Set Then             'Set
            W_TextValue = FS_DropboxList_Vaule_TextValue(fromDoItem, W_ObjDropDownList.SelectedValue)
            W_ObjTextBox.Text = W_TextValue

        ElseIf (fromDoMode \ C_Enum_FixNum) = Enum_VauleDoMode.Kind_i_2_Get Then      'Get
            If W_ObjTextBox.Text.Length > 0 Then
                W_TextValue = FS_DropboxList_Vaule_TextValue(fromDoItem, W_ObjTextBox.Text)
                PublicClassLibrary.ModTools.SelectedIndexByValue(W_ObjDropDownList, W_TextValue)
            End If

        End If

        'Next
    End Sub

    Protected Function FS_DropboxList_Vaule_TextValue(ByRef fromItemInfo As CS_ListView_Array_Info, ByVal fromTextValue As String) As String
        Dim W_TextValue As String

        If fromItemInfo.W_NeedSpecialChar = True Then
            Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
            W_TextValue = W_ClsSystemNote.Fs_GetStrBefor(fromTextValue, W_ClsSystemNote.Display_Symbol)
        Else
            W_TextValue = fromTextValue
        End If

        Return W_TextValue
    End Function

#End Region


#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    Private Sub MakeQryStringToControl()
        Dim queryTime As String = Now.ToString("HHmmss")
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        Dim querySql As New StringBuilder
        querySql.Append("Select * " & vbNewLine)
        querySql.Append("FROM [LabRecordA2_Assay_RES] " & vbNewLine)
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
            Dim W_ASSAYID As String = W_ClsSystemNote.Fs_GetStrBefor(queryKey5DropDownList.SelectedValue, W_ClsSystemNote.Display_Symbol)
            querySql.Append("AND [ASSAY_ID] = '" & W_ASSAYID & "' " & vbNewLine)
        End If

        Dim W_EFF_FLAG As String = W_ClsSystemNote.Fs_GetStrBefor(queryEFF_FLAGDropDown.SelectedValue, W_ClsSystemNote.Display_Symbol)
        If W_EFF_FLAG <> "ALL" Then
            querySql.Append("AND EFF_FLAG ='" & W_EFF_FLAG & "' " & vbNewLine)
        End If

        querySql.Append("ORDER BY [參照規範], [表面類別], [鋼種], [材質], [ASSAY_ID] " & vbNewLine)

        Me.hfSQL.Value = queryTime & "|" & querySql.ToString
    End Sub
#End Region


#Region "CRUD"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL As String) As List(Of LabRecordA2_Assay_RES)
        If String.IsNullOrEmpty(fromSQL) OrElse fromSQL = "" _
            OrElse fromSQL.Split("|").Count < 2 Then
            Return New List(Of LabRecordA2_Assay_RES)
        End If

        Dim dtResult As List(Of LabRecordA2_Assay_RES) = _
                    LabRecordA2_Assay_RES.CDBSelect(Of LabRecordA2_Assay_RES)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, fromSQL.Split("|")(1))

        Return dtResult
    End Function

    <DataObjectMethod(DataObjectMethodType.Insert)>
    Public Function Insert(ByVal fromObj As LabRecordA2_Assay_RES) As Integer
        Return fromObj.CDBInsert
    End Function

    <DataObjectMethod(DataObjectMethodType.Update)>
    Public Function Update(ByVal fromObj As LabRecordA2_Assay_RES) As Integer
        Return fromObj.CDBUpdate
    End Function

    <DataObjectMethod(DataObjectMethodType.Delete)>
    Public Function Delete(ByVal fromObj As LabRecordA2_Assay_RES) As Integer
        Return fromObj.CDBDelete
    End Function

#End Region

    Protected Sub btnSerach_Click(sender As Object, e As EventArgs) Handles btnSerach.Click
        ListView1.EditIndex = -1
        ListView1.InsertItemPosition = InsertItemPosition.LastItem

        MakeQryStringToControl()
        ListView1.DataBind()
    End Sub

#Region "ListView1"

    Public Sub CustomValidator_1_Insert_ServerValidate(source As Object, args As System.Web.UI.WebControls.ServerValidateEventArgs) 'Handles CustomValidator1.ServerValidate
        Dim validatorObjl As CustomValidator = Nothing
        Dim listViewItemObj As System.Web.UI.WebControls.ListViewItem = Nothing
        Dim textboxObj As TextBox = Nothing
        Dim W_DoModeIs As LabRecordA2_Setting_Module.EditMode_Enum
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        If LabRecordA2_Setting_Module.Main_Targe_IsMe(W_Now主畫面_Enum) = False Then Exit Sub

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
            textboxObj = CType(listViewItemObj.FindControl("editRESULT_FORMATTextBox"), TextBox)

            'validatorObjl.ErrorMessage = String.Empty

            If IsNumeric(textboxObj.Text) = False Then
                If W_MSG <> "" Then W_MSG &= "、"
                W_MSG &= "『小數點位數』格式錯誤"
            End If

            If W_DoModeIs = EditMode_Enum.新增 Then
                '-- 新增 ---------------------------------------------------------------------------
                Dim dropDownListObj As DropDownList = Nothing
                Dim flag1_Plus As Boolean, flag2_Minus As Boolean
                Dim W_SQL As New StringBuilder
                W_SQL.Append("Select * From [LabRecordA2_ASSAY_RES] WHERE 1=1 " & vbNewLine)

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

                dropDownListObj = listViewItemObj.FindControl(String.Concat("EditKey", 5, C_Fix_DropDownList))
                Dim W_ASSAYID As String = W_ClsSystemNote.Fs_GetStrBefor(dropDownListObj.SelectedValue, W_ClsSystemNote.Display_Symbol)
                W_SQL.Append("AND [ASSAY_ID] = '" & W_ASSAYID & "' " & vbNewLine)

                Dim queryList As List(Of CompanyORMDB.SQLServer.QCDB01.LabRecordA2_Assay_RES) = _
                    CompanyORMDB.SQLServer.QCDB01.LabRecordA2_Assay_RES.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.LabRecordA2_Assay_RES)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, W_SQL.ToString)

                If queryList.Count > 0 Then
                    If W_MSG <> "" Then W_MSG &= "、"
                    W_MSG &= "『KEY重複』"
                End If


                If (flag1_Plus = True AndAlso flag2_Minus = True) Then
                    If W_MSG <> "" Then W_MSG &= "、"
                    W_MSG &= "『保留字+-』不可同時出現"
                End If
                '-- 新增 ---------------------------------------------------------------------------
            End If

            If W_MSG <> "" Then
                validatorObjl.ErrorMessage = "Check：" & W_MSG
            Else
                validatorObjl.ErrorMessage = ""
            End If
            args.IsValid = (validatorObjl.ErrorMessage.Trim.Length = 0)

            If args.IsValid = False Then
                '----------------------------------------------------
                If W_DoModeIs = EditMode_Enum.新增 Then
                    P_DropboxList_Vaule_Set(listViewItemObj)

                ElseIf W_DoModeIs = EditMode_Enum.編輯 Then
                    P_DropboxList_Vaule_Set_NOT_Key(listViewItemObj)
                End If
                '----------------------------------------------------
            End If

        End If

    End Sub


    Private Sub ListView1_ItemInserting(sender As Object, e As ListViewInsertEventArgs) Handles ListView1.ItemInserting
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        Dim W_Obj_listView As ListViewItem = CType(sender, ListView).InsertItem
        e.Values("參照規範") = CType(W_Obj_listView.FindControl("EditKey1DropDownList"), DropDownList).SelectedValue
        e.Values("表面類別") = CType(W_Obj_listView.FindControl("EditKey2DropDownList"), DropDownList).SelectedValue
        e.Values("鋼種") = CType(W_Obj_listView.FindControl("EditKey3DropDownList"), DropDownList).SelectedValue
        e.Values("材質") = CType(W_Obj_listView.FindControl("EditKey4DropDownList"), DropDownList).SelectedValue

        e.Values("ASSAY_ID") = W_ClsSystemNote.Fs_GetStrBefor(CType(W_Obj_listView.FindControl("EditKey5DropDownList"), DropDownList).SelectedValue, LabRecordA2_Setting_Module.C_ClsSystemNote_Display_Symbol)

        e.Values("NORMAL_RANGE_L") = CType(W_Obj_listView.FindControl("EditNORMAL_RANGE_LTextBox"), TextBox).Text
        e.Values("NORMAL_RANGE_H") = CType(W_Obj_listView.FindControl("EditNORMAL_RANGE_HTextBox"), TextBox).Text
        e.Values("RESULT_FORMAT") = CType(W_Obj_listView.FindControl("EditRESULT_FORMATTextBox"), TextBox).Text

        e.Values("EFF_FLAG") = W_ClsSystemNote.Fs_GetStrBefor(CType(W_Obj_listView.FindControl("EditEFF_FLAGDropDownList"), DropDownList).SelectedValue, LabRecordA2_Setting_Module.C_ClsSystemNote_Display_Symbol)

        e.Values("SAVE_OPER") = LabRecordA2_Setting_Module.FS_SAVE_OPER()
        e.Values("SAVE_DATE") = LabRecordA2_Setting_Module.FS_SAVE_DATE

    End Sub

    Private Sub ListView1_ItemInserted(sender As Object, e As ListViewInsertedEventArgs) Handles ListView1.ItemInserted
        ListView1.DataBind()
    End Sub

    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Dim W_Obj_listView As ListViewItem = CType(sender, ListView).EditItem
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        e.NewValues("EFF_FLAG") = W_ClsSystemNote.Fs_GetStrBefor(CType(W_Obj_listView.FindControl("EditEFF_FLAGDropDownList"), DropDownList).SelectedValue, W_ClsSystemNote.Display_Symbol)

        e.NewValues("SAVE_OPER") = LabRecordA2_Setting_Module.FS_SAVE_OPER()
        e.NewValues("SAVE_DATE") = LabRecordA2_Setting_Module.FS_SAVE_DATE
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

    Private Sub ListView1_ItemCommand(sender As Object, e As ListViewCommandEventArgs) Handles ListView1.ItemCommand
        Dim listViewItemObj As System.Web.UI.WebControls.ListViewItem = Nothing
        Dim validatorObjl As CustomValidator = Nothing
        Dim W_DoModeIs As LabRecordA2_Setting_Module.EditMode_Enum = Nothing

        If Not ListView1.EditItem Is Nothing Then
            listViewItemObj = ListView1.EditItem
            W_DoModeIs = EditMode_Enum.編輯

        ElseIf Not ListView1.InsertItem Is Nothing Then
            listViewItemObj = ListView1.InsertItem
            W_DoModeIs = EditMode_Enum.新增
        End If


        Select Case e.CommandName
            Case "Edit"
                ListView1.InsertItemPosition = InsertItemPosition.None

            Case "ReadDefault"

            Case Else
                validatorObjl = CType(listViewItemObj.FindControl("CV_EditItem"), CustomValidator)

                If (W_DoModeIs = EditMode_Enum.編輯) AndAlso _
                     (validatorObjl.ErrorMessage <> "") AndAlso _
                     (Not e.CommandName.Equals("Cancel")) Then
                    '編輯時有錯，且不是按取消按鈕。

                Else
                    ListView1.InsertItemPosition = InsertItemPosition.LastItem
                End If
        End Select
    End Sub

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        Dim listViewItemObj As System.Web.UI.WebControls.ListViewItem = Nothing
        Dim dropDownListObj1 As DropDownList, dropDownListObj2 As DropDownList
        Dim textBoxObj1 As TextBox
        Dim W_TextValue As String
        Dim W_DoModeIs As LabRecordA2_Setting_Module.EditMode_Enum

        Dim W_eachItem As CS_ListView_Array_Info
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        If Not ListView1.EditItem Is Nothing Then
            listViewItemObj = ListView1.EditItem
            W_DoModeIs = EditMode_Enum.編輯

            'EditEFF_FLAG
            '1:設定DropboxList選項
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditEFF_FLAGDropDownList"), DropDownList)
            P_DropDownList_SetItem(Enum_DropDownList.檢驗項目基本檔_停用否, dropDownListObj1)
            '2:設定選項
            W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)
            W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
            PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)

        ElseIf Not ListView1.InsertItem Is Nothing Then
            listViewItemObj = ListView1.InsertItem
            W_DoModeIs = EditMode_Enum.新增

            '--------------------------------------------------------
            '1:設定DropboxList選項
            '2:設定選項
            '       2a:順位1: ListView.Insert.Textbox
            '       2b:順位2:查詢畫面
            '                       Me.queryKey[*]CheckBox.Checked = True
            '                       queryKey[*]DropDownList.SelectedValue
            '--------------------------------------------------------
            'EditEFF_FLAG
            '1:設定DropboxList選項
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditEFF_FLAGDropDownList"), DropDownList)
            P_DropDownList_SetItem(Enum_DropDownList.檢驗項目基本檔_停用否, dropDownListObj1)
            '2:設定選項
            W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)

            If textBoxObj1.Text <> "" Then
                '       2a:順位1: ListView.Insert.Textbox
                W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
                PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)

            ElseIf W_ClsSystemNote.Fs_GetStrBefor(queryEFF_FLAGDropDown.SelectedValue, W_ClsSystemNote.Display_Symbol) <> "ALL" Then
                '       2b:順位2:查詢畫面
                dropDownListObj1.SelectedValue = queryEFF_FLAGDropDown.SelectedValue
            End If

            'Key1
            '1:設定DropboxList選項
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey1DropDownList"), DropDownList)
            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey1_參照規範(dropDownListObj1)
            '2:設定選項
            W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)

            If textBoxObj1.Text <> "" Then
                '       2a:順位1: ListView.Insert.Textbox
                W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
                PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)

            ElseIf queryKey1CheckBox.Checked = True Then
                '       2b:順位2:查詢畫面
                dropDownListObj1.SelectedValue = queryKey1DropDownList.SelectedValue
            End If

            'Key2
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey2DropDownList"), DropDownList)
            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey2_表面類別(dropDownListObj1)

            W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)

            If textBoxObj1.Text <> "" Then
                W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
                PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)

            ElseIf queryKey2CheckBox.Checked = True Then
                dropDownListObj1.SelectedValue = queryKey2DropDownList.SelectedValue
            End If

            'Key3
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey3DropDownList"), DropDownList)
            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey3_鋼種(dropDownListObj1)

            W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)

            If textBoxObj1.Text <> "" Then
                W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
                PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)

            ElseIf queryKey3CheckBox.Checked = True Then
                dropDownListObj1.SelectedValue = queryKey3DropDownList.SelectedValue
            End If

            'Key4
            dropDownListObj2 = dropDownListObj1
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey4DropDownList"), DropDownList)
            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey4_材質(dropDownListObj1, dropDownListObj2.SelectedValue)

            W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)

            If textBoxObj1.Text <> "" Then
                W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
                PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)

            ElseIf queryKey4CheckBox.Checked = True Then
                dropDownListObj1.SelectedValue = queryKey4DropDownList.SelectedValue
            End If

            'Key5
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey5DropDownList"), DropDownList)
            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey5_檢驗代號(dropDownListObj1)

            W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)

            If textBoxObj1.Text <> "" Then
                W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
                PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)

            ElseIf queryKey5CheckBox.Checked = True Then
                dropDownListObj1.SelectedValue = queryKey5DropDownList.SelectedValue
            End If

        End If

    End Sub

    Public Sub ListView1_BtnReadDefault_Click(sender As Object, e As EventArgs)
        Dim W_Obj_ListViewItem As ListViewItem = Nothing
        Dim W_DoModeIs As LabRecordA2_Setting_Module.EditMode_Enum
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        If Not ListView1.EditItem Is Nothing Then
            W_Obj_ListViewItem = ListView1.EditItem
            W_DoModeIs = EditMode_Enum.編輯

        ElseIf Not ListView1.InsertItem Is Nothing Then
            W_Obj_ListViewItem = ListView1.InsertItem
            W_DoModeIs = EditMode_Enum.新增
        End If

        Dim W_editKey5Text As String = ""
        Dim W_NORMAL_RANGE_L As TextBox, W_NORMAL_RANGE_H As TextBox, W_RESULT_FORMAT As TextBox

        If W_DoModeIs = EditMode_Enum.新增 Then
            W_editKey5Text = CType((W_Obj_ListViewItem.FindControl("EditKey5DropDownList")), DropDownList).SelectedValue

        ElseIf W_DoModeIs = EditMode_Enum.編輯 Then
            W_editKey5Text = CType((W_Obj_ListViewItem.FindControl("EditASSAY_IDLabel")), Label).Text
        End If

        W_NORMAL_RANGE_L = CType((W_Obj_ListViewItem.FindControl("EditNORMAL_RANGE_LTextBox")), TextBox)
        W_NORMAL_RANGE_H = CType((W_Obj_ListViewItem.FindControl("EditNORMAL_RANGE_HTextBox")), TextBox)

        W_RESULT_FORMAT = CType((W_Obj_ListViewItem.FindControl("EditRESULT_FORMATTextBox")), TextBox)


        Dim W_AssayID As String = W_ClsSystemNote.Fs_GetStrBefor(W_editKey5Text, W_ClsSystemNote.Display_Symbol)
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey5_檢驗資訊(W_AssayID, W_NORMAL_RANGE_L, W_NORMAL_RANGE_H, W_RESULT_FORMAT)

        If W_DoModeIs = EditMode_Enum.新增 Then
            P_DropboxList_Vaule_Set_NOT_Normal_range_Result_format(W_Obj_ListViewItem)

        Else

            'Dim W_eachItem As CS_ListView_Array_Info
            'Dim dropDownListObj1 As DropDownList, textBoxObj1 As TextBox
            'Dim W_TextValue As String

            'dropDownListObj1 = CType(W_Obj_ListViewItem.FindControl("EditEFF_FLAGDropDownList"), DropDownList)
            'W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            'textBoxObj1 = CType((W_Obj_ListViewItem.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)
            'W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, dropDownListObj1.SelectedValue)
            'textBoxObj1.Text = W_TextValue

            P_DropboxList_Vaule_Set_ONLY_Eff_flag(W_Obj_ListViewItem)
        End If

    End Sub
#End Region




#Region "P_INIT"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            P_INIT()
        End If
    End Sub

    Private W_Now主畫面_Enum As 主畫面_Enum = 主畫面_Enum.檢驗項目_對照檔
    Private Sub P_INIT()
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey1_參照規範(queryKey1DropDownList)
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey2_表面類別(queryKey2DropDownList)
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey3_鋼種(queryKey3DropDownList)
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey4_材質(queryKey4DropDownList, queryKey3DropDownList.SelectedValue)
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey5_檢驗代號(queryKey5DropDownList)

        P_DropDownList_SetItem(Enum_DropDownList.檢驗項目基本檔_停用否, queryEFF_FLAGDropDown)
        queryEFF_FLAGDropDown.Items.Add("ALL：全部")

        LabRecordA2_Setting_Module.Main_Targe_Who = W_Now主畫面_Enum
    End Sub

    Public Function showAssayInfo(ByVal fromAssayID As String) As String
        Return LabRecordA2_Setting_Module.FS_Get_DataKey5_檢驗代號名稱(fromAssayID)
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
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
        Dim W_NoteType As String = [Enum].GetName(GetType(Enum_DropDownList), fromNote_Type)
        Dim queryDataTable1 As DataTable
        queryDataTable1 = W_ClsSystemNote.getLev3(C_SYSTEM_TYPE, W_NoteType)
        W_ClsSystemNote.setDropDownList(fromObj, queryDataTable1, W_ClsSystemNote.Display_Lable)
    End Sub


#End Region


    Public Function FS_DATE_FORMAT(ByVal fromDate As Date, ByVal fromType As Integer) As String
        Return LabRecordA2_Setting_Module.FS_DATE_FORMAT(fromDate, fromType)
    End Function

    Public Function FS_NORMAL_RANGE(ByVal fromNORMAL_RANGE_L As String, ByVal fromNORMAL_RANGE_H As String) As String
        Return LabRecordA2_Setting_Module.FS_NORMAL_RANGE(fromNORMAL_RANGE_L, fromNORMAL_RANGE_H)
    End Function
End Class