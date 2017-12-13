Imports CompanyORMDB.SQLServer.QCDB01

Public Class LabRecordA2_Setting_Remark_RES_ASSAY
    Inherits System.Web.UI.UserControl


#Region "GetDataKey"


    Protected Sub editKey_reFresh(ByVal fromVauleNeedSave As Boolean)
        Dim listViewItemObj As ListViewItem = Me.ListView1.InsertItem
        If listViewItemObj Is Nothing Then Exit Sub


        Dim W_TextValue As String
        Dim textBoxObj1 As TextBox
        Dim W_eachItem As CS_ListView_Array_Info
        Dim editDownListObj1 As DropDownList, editDownListObj2 As DropDownList
        Dim editDownListObj3 As DropDownList, editDownListObj4 As DropDownList
        Dim editDownListObj5 As DropDownList, editDownListObj_Now As DropDownList
        Dim Checked1 As Boolean, Checked2 As Boolean, Checked3 As Boolean
        Dim Checked4 As Boolean, Checked5 As Boolean
        Dim queryKeyCheckBox_Now As CheckBox
        Dim queryKeyDropDownList_Now As DropDownList

        editDownListObj1 = CType(listViewItemObj.FindControl("EditKey1DropDownList"), DropDownList)
        editDownListObj2 = CType(listViewItemObj.FindControl("EditKey2DropDownList"), DropDownList)
        editDownListObj3 = CType(listViewItemObj.FindControl("EditKey3DropDownList"), DropDownList)
        editDownListObj4 = CType(listViewItemObj.FindControl("EditKey4DropDownList"), DropDownList)
        editDownListObj5 = CType(listViewItemObj.FindControl("EditKey5DropDownList"), DropDownList)

        Dim display條件檢查_Enum As LabRecordA2_Setting_Module.條件檢查_Enum

        For II As Integer = Convert.ToInt32(LabRecordA2_Setting_Module.條件檢查_Enum.DataKey1_參照規範) _
                                                To Convert.ToInt32(LabRecordA2_Setting_Module.條件檢查_Enum.DataKey4_材質)

            display條件檢查_Enum = DirectCast([Enum].Parse(GetType(LabRecordA2_Setting_Module.條件檢查_Enum), II), LabRecordA2_Setting_Module.條件檢查_Enum)
            Checked5 = True

            Checked1 = IIf(II > 1, True, False)
            Checked2 = IIf(II > 2, True, False)
            Checked3 = IIf(II > 3, True, False)
            Checked4 = IIf(II > 4, True, False)

            'A:query查詢條件
            queryKeyCheckBox_Now = CType(Me.FindControl(String.Concat("queryKey", II, "CheckBox")), CheckBox)
            queryKeyDropDownList_Now = CType(Me.FindControl(String.Concat("queryKey", II, "DropDownList")), DropDownList)


            '1:設定DropboxList選項
            editDownListObj_Now = CType(listViewItemObj.FindControl(String.Concat("EditKey", II, "DropDownList")), DropDownList)
            'LabRecordA2_Setting_Module.P_SetDropDownList_DataKey1_參照規範(editDownListObj_Now)

            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey_條件檢查_DO( _
                                                         editDownListObj_Now _
                                                        , display條件檢查_Enum _
                                                        , Checked1, editDownListObj1.SelectedValue _
                                                        , Checked2, editDownListObj2.SelectedValue _
                                                        , Checked3, editDownListObj3.SelectedValue _
                                                        , Checked4, editDownListObj4.SelectedValue _
                                                        , Checked5, editDownListObj5.SelectedValue)


            '2:設定選項
            W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, editDownListObj_Now.ID)
            textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)

            If textBoxObj1.Text <> "" Then
                '       2a:順位1: ListView.Insert.Textbox
                W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
                PublicClassLibrary.ModTools.SelectedIndexByValue(editDownListObj_Now, W_TextValue)

            ElseIf queryKeyCheckBox_Now.Checked = True Then
                '       2b:順位2:查詢畫面
                'editDownListObj_Now.SelectedValue = queryKey1DropDownList.SelectedValue

                PublicClassLibrary.ModTools.SelectedIndexByValue(editDownListObj_Now, queryKeyDropDownList_Now.SelectedValue)
            End If

        Next
        '    Dim W_ObjDropDownList As DropDownList = CType(sender, DropDownList)
        '    Dim W_editKey4DropDownList As DropDownList

        '----------------------------------------------------
        If fromVauleNeedSave = True Then
            P_DropboxList_Vaule_Set(listViewItemObj)
        End If
        '----------------------------------------------------

        '    If W_ObjDropDownList.ID = "EditKey3DropDownList" Then
        '        W_editKey4DropDownList = CType((W_Obj_ListViewItem.FindControl("EditKey4DropDownList")), DropDownList)
        '        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey4_材質(W_editKey4DropDownList, W_ObjDropDownList.SelectedValue)
        '    End If

    End Sub

    Protected Sub editKeyDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)
        'Step1
        Dim W_eachItem As CS_ListView_Array_Info
        Dim dropDownListObj1 As DropDownList = sender
        Dim textBoxObj1 As TextBox
        Dim listViewItemObj As ListViewItem = ListView1.InsertItem
        Dim W_TextValue As String

        W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
        textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)
        W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, dropDownListObj1.Text)
        textBoxObj1.Text = W_TextValue

        'Step2
        editKey_reFresh(True)
    End Sub

    Protected Sub queryKey_reFresh()
        Dim dropDownListObj As DropDownList
        Dim display條件檢查_Enum As LabRecordA2_Setting_Module.條件檢查_Enum

        For II As Integer = Convert.ToInt32(LabRecordA2_Setting_Module.條件檢查_Enum.DataKey1_參照規範) _
                                                To Convert.ToInt32(LabRecordA2_Setting_Module.條件檢查_Enum.DataKey4_材質)

            dropDownListObj = CType(Me.FindControl(String.Concat("queryKey", II, "DropDownList")), DropDownList)
            display條件檢查_Enum = DirectCast([Enum].Parse(GetType(LabRecordA2_Setting_Module.條件檢查_Enum), II), LabRecordA2_Setting_Module.條件檢查_Enum)

            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey_條件檢查_DO( _
                                                                                 dropDownListObj _
                                                                                , display條件檢查_Enum _
                                                                                , queryKey1CheckBox.Checked, queryKey1DropDownList.SelectedValue _
                                                                                , queryKey2CheckBox.Checked, queryKey2DropDownList.SelectedValue _
                                                                                , queryKey3CheckBox.Checked, queryKey3DropDownList.SelectedValue _
                                                                                , queryKey4CheckBox.Checked, queryKey4DropDownList.SelectedValue _
                                                                                , queryKey5CheckBox.Checked, queryKey5DropDownList.SelectedValue)
        Next II
    End Sub

    Protected Sub queryKeyCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles queryKey5CheckBox.CheckedChanged, queryKey1CheckBox.CheckedChanged
        queryKey_reFresh()
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
            Case "4"
                W_ObjCheckBox = queryKey4CheckBox

            Case "5"
                queryKey1CheckBox.Checked = False
                queryKey2CheckBox.Checked = False
                queryKey3CheckBox.Checked = False
                queryKey4CheckBox.Checked = False
        End Select

        W_ObjCheckBox.Checked = True

        queryKey_reFresh()
    End Sub


    Protected Sub P_DropboxList_Vaule_Set(ByRef fromListViewItem As ListViewItem)
        P_DropboxList_Vaule_Do(fromListViewItem, 1)
    End Sub
    Protected Sub P_DropboxList_Vaule_Get(ByRef fromListViewItem As ListViewItem)
        P_DropboxList_Vaule_Do(fromListViewItem, 2)
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


    Private Function PA_CS_ListView_Array_Info_ItemGet(ByVal fromObjKind As Integer, ByVal fromObjName As String) As CS_ListView_Array_Info
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
                W_CS_ListView_Array_Info.Add(New CS_ListView_Array_Info("EditKey5DropDownList", "REMARK_IDTextBox", True))
                W_CS_ListView_Array_Info.Add(New CS_ListView_Array_Info("EditKey6DropDownList", "ASSAY_IDTextBox", True))
                W_CS_ListView_Array_Info.Add(New CS_ListView_Array_Info("EditJUDGET_TYPEDropDownList", "JUDGET_TYPETextBox", True))
                W_CS_ListView_Array_Info.Add(New CS_ListView_Array_Info("EditEFF_FLAGDropDownList", "EFF_FLAGTextBox", True))

                _WP_CS_ListView_Array_Info_List = W_CS_ListView_Array_Info
            End If

            Return _WP_CS_ListView_Array_Info_List
        End Get
    End Property


    Protected Sub P_DropboxList_Vaule_Do(ByRef fromListViewItem As ListViewItem, ByVal fromDoMode As Integer)
        Dim W_ObjDropDownList As DropDownList
        Dim W_ObjTextBox As TextBox = Nothing
        Dim W_TextValue As String

        For Each eachItem As CS_ListView_Array_Info In WP_CS_ListView_Array_Info_List
            W_ObjDropDownList = CType((fromListViewItem.FindControl(eachItem.W_NameOfDropboxList)), DropDownList)
            W_ObjTextBox = CType((fromListViewItem.FindControl(eachItem.W_NameOfTextbox)), TextBox)

            If fromDoMode = 1 Then             'Set
                W_TextValue = FS_DropboxList_Vaule_TextValue(eachItem, W_ObjDropDownList.SelectedValue)
                W_ObjTextBox.Text = W_TextValue

            ElseIf fromDoMode = 2 Then      'Get
                If W_ObjTextBox.Text.Length > 0 Then
                    W_TextValue = FS_DropboxList_Vaule_TextValue(eachItem, W_ObjTextBox.Text)
                    PublicClassLibrary.ModTools.SelectedIndexByValue(W_ObjDropDownList, W_TextValue)
                End If

            End If

        Next
    End Sub

    Protected Function FS_DropboxList_Vaule_TextValue(ByRef fromItemInfo As CS_ListView_Array_Info, ByVal fromTextValue As String) As String
        Dim W_TextValue As String
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        If fromItemInfo.W_NeedSpecialChar = True Then
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
        querySql.Append("FROM [LabRecordA2_Remark_RESAssay] " & vbNewLine)
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
            Dim W_REMARKID As String = W_ClsSystemNote.Fs_GetStrBefor(queryKey5DropDownList.SelectedValue, W_ClsSystemNote.Display_Symbol)
            querySql.Append("AND [REMARK_ID] = '" & W_REMARKID & "' " & vbNewLine)
        End If

        Dim W_EFF_FLAG As String = W_ClsSystemNote.Fs_GetStrBefor(queryEFF_FLAGDropDown.SelectedValue, W_ClsSystemNote.Display_Symbol)
        If W_EFF_FLAG <> "ALL" Then
            querySql.Append("AND EFF_FLAG ='" & W_EFF_FLAG & "' " & vbNewLine)
        End If

        querySql.Append("ORDER BY [參照規範], [表面類別], [鋼種], [材質], [REMARK_ID], [ASSAY_ID] " & vbNewLine)

        Me.hfSQL.Value = queryTime & "|" & querySql.ToString
    End Sub
#End Region


#Region "CRUD"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL As String) As List(Of LabRecordA2_Remark_RESAssay)
        If String.IsNullOrEmpty(fromSQL) OrElse fromSQL = "" _
            OrElse fromSQL.Split("|").Count < 2 Then
            Return New List(Of LabRecordA2_Remark_RESAssay)
        End If

        Dim dtResult As List(Of LabRecordA2_Remark_RESAssay) = _
                    LabRecordA2_Remark_RES.CDBSelect(Of LabRecordA2_Remark_RESAssay)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, fromSQL.Split("|")(1))

        Return dtResult
    End Function

    <DataObjectMethod(DataObjectMethodType.Insert)>
    Public Function Insert(ByVal fromObj As LabRecordA2_Remark_RESAssay) As Integer
        Return fromObj.CDBInsert
    End Function

    <DataObjectMethod(DataObjectMethodType.Update)>
    Public Function Update(ByVal fromObj As LabRecordA2_Remark_RESAssay) As Integer
        Return fromObj.CDBUpdate
    End Function

    <DataObjectMethod(DataObjectMethodType.Delete)>
    Public Function Delete(ByVal fromObj As LabRecordA2_Remark_RESAssay) As Integer
        Return fromObj.CDBDelete
    End Function

#End Region

    Protected Sub btnSerach_Click(sender As Object, e As EventArgs) Handles btnSerach.Click
        ListView1.EditIndex = -1
        'ListView1.InsertItemPosition = InsertItemPosition.LastItem

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
            textboxObj = CType(listViewItemObj.FindControl("EditJUDGET_DOCTextBox"), TextBox)

            validatorObjl.ErrorMessage = String.Empty

            If textboxObj.Text.Length = 0 Then
                If W_MSG <> "" Then W_MSG &= "、"
                W_MSG &= "『條件說明』未輸入"
            End If

            If W_DoModeIs = EditMode_Enum.新增 Then
                '-- 新增 ---------------------------------------------------------------------------
                Dim dropDownListObj As DropDownList = Nothing
                Dim flag1_Plus As Boolean, flag2_Minus As Boolean
                Dim W_SQL As New StringBuilder
                W_SQL.Append("Select * From [LabRecordA2_Remark_RESAssay] WHERE 1=1 " & vbNewLine)

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
                Dim W_REMARKID As String = W_ClsSystemNote.Fs_GetStrBefor(dropDownListObj.SelectedValue, W_ClsSystemNote.Display_Symbol)
                W_SQL.Append("AND [REMARK_ID] = '" & W_REMARKID & "' " & vbNewLine)

                dropDownListObj = listViewItemObj.FindControl(String.Concat("EditKey", 6, C_Fix_DropDownList))
                Dim W_ASSAY_ID As String = W_ClsSystemNote.Fs_GetStrBefor(dropDownListObj.SelectedValue, W_ClsSystemNote.Display_Symbol)
                W_SQL.Append("AND [ASSAY_ID] = '" & W_ASSAY_ID & "' " & vbNewLine)


                Dim queryList As List(Of CompanyORMDB.SQLServer.QCDB01.LabRecordA2_Remark_RES) = _
                    CompanyORMDB.SQLServer.QCDB01.LabRecordA2_Remark_RES.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.LabRecordA2_Remark_RES)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, W_SQL.ToString)

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
                P_DropboxList_Vaule_Set(listViewItemObj)
                '----------------------------------------------------
            End If

        End If

    End Sub


    Private Sub ListView1_ItemInserting(sender As Object, e As ListViewInsertEventArgs) Handles ListView1.ItemInserting
        Dim W_Obj_listView As ListViewItem = CType(sender, ListView).InsertItem
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        e.Values("參照規範") = CType(W_Obj_listView.FindControl("EditKey1DropDownList"), DropDownList).SelectedValue
        e.Values("表面類別") = CType(W_Obj_listView.FindControl("EditKey2DropDownList"), DropDownList).SelectedValue
        e.Values("鋼種") = CType(W_Obj_listView.FindControl("EditKey3DropDownList"), DropDownList).SelectedValue
        e.Values("材質") = CType(W_Obj_listView.FindControl("EditKey4DropDownList"), DropDownList).SelectedValue

        e.Values("REMARK_ID") = W_ClsSystemNote.Fs_GetStrBefor(CType(W_Obj_listView.FindControl("EditKey5DropDownList"), DropDownList).SelectedValue, W_ClsSystemNote.Display_Symbol)
        e.Values("ASSAY_ID") = W_ClsSystemNote.Fs_GetStrBefor(CType(W_Obj_listView.FindControl("EditKey6DropDownList"), DropDownList).SelectedValue, LabRecordA2_Setting_Module.C_ClsSystemNote_Display_Symbol)

        e.Values("JUDGET_TYPE") = W_ClsSystemNote.Fs_GetStrBefor(CType(W_Obj_listView.FindControl("EditJUDGET_TYPEDropDownList"), DropDownList).SelectedValue, W_ClsSystemNote.Display_Symbol)

        e.Values("EFF_FLAG") = W_ClsSystemNote.Fs_GetStrBefor(CType(W_Obj_listView.FindControl("EditEFF_FLAGDropDownList"), DropDownList).SelectedValue, W_ClsSystemNote.Display_Symbol)




        e.Values("SAVE_OPER") = LabRecordA2_Setting_Module.FS_SAVE_OPER()
        e.Values("SAVE_DATE") = LabRecordA2_Setting_Module.FS_SAVE_DATE


    End Sub

    Private Sub ListView1_ItemInserted(sender As Object, e As ListViewInsertedEventArgs) Handles ListView1.ItemInserted
        ListView1.DataBind()
    End Sub

    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Dim W_Obj_listView As ListViewItem = CType(sender, ListView).EditItem
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        e.NewValues("JUDGET_TYPE") = W_ClsSystemNote.Fs_GetStrBefor(CType(W_Obj_listView.FindControl("EditJUDGET_TYPEDropDownList"), DropDownList).SelectedValue, LabRecordA2_Setting_Module.C_ClsSystemNote_Display_Symbol)

        e.NewValues("EFF_FLAG") = W_ClsSystemNote.Fs_GetStrBefor(CType(W_Obj_listView.FindControl("EditEFF_FLAGDropDownList"), DropDownList).SelectedValue, LabRecordA2_Setting_Module.C_ClsSystemNote_Display_Symbol)



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
        Select Case e.CommandName
            Case "Edit"
                ListView1.InsertItemPosition = InsertItemPosition.None

            Case Else
                ListView1.InsertItemPosition = InsertItemPosition.LastItem
        End Select
    End Sub

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        Dim listViewItemObj As System.Web.UI.WebControls.ListViewItem = Nothing
        Dim dropDownListObj1 As DropDownList
        Dim textBoxObj1 As TextBox
        Dim W_TextValue As String
        Dim W_DoModeIs As LabRecordA2_Setting_Module.EditMode_Enum

        Dim W_eachItem As CS_ListView_Array_Info
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        If Not ListView1.EditItem Is Nothing Then
            listViewItemObj = ListView1.EditItem
            W_DoModeIs = EditMode_Enum.編輯


            'EditJUDGET_TYPE
            '1:設定DropboxList選項
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditJUDGET_TYPEDropDownList"), DropDownList)
            P_DropDownList_SetItem(Enum_DropDownList.片語基本檔_條件判斷, dropDownListObj1)
            '2:設定選項
            W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)
            W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
            PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)


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

            'EditJUDGET_TYPE
            '1:設定DropboxList選項
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditJUDGET_TYPEDropDownList"), DropDownList)
            P_DropDownList_SetItem(Enum_DropDownList.片語基本檔_條件判斷, dropDownListObj1)
            '2:設定選項
            W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)

            If textBoxObj1.Text <> "" Then
                '       2a:順位1: ListView.Insert.Textbox
                W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
                PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)

                'ElseIf W_ClsSystemNote.Fs_GetStrBefor(queryJUDGET_TYPEDropDown.SelectedValue, W_ClsSystemNote.Display_Symbol) <> "ALL" Then
                '    '       2b:順位2:查詢畫面
                '    dropDownListObj1.SelectedValue = queryJUDGET_TYPEDropDown.SelectedValue
            End If


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




            'Key6
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey6DropDownList"), DropDownList)
            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey5_檢驗代號(dropDownListObj1)

            W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)

            If textBoxObj1.Text <> "" Then
                W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
                PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)

            End If


            'Key5
            dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey5DropDownList"), DropDownList)
            LabRecordA2_Setting_Module.P_SetDropDownList_DataKey5_片語代號_條件檢查(dropDownListObj1)

            W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)

            If textBoxObj1.Text <> "" Then
                W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
                PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)

            ElseIf queryKey5CheckBox.Checked = True Then
                dropDownListObj1.SelectedValue = queryKey5DropDownList.SelectedValue
            End If



            'Key1~Key4
            editKey_reFresh(False)


            ''Key1
            ''1:設定DropboxList選項
            'dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey1DropDownList"), DropDownList)
            'LabRecordA2_Setting_Module.P_SetDropDownList_DataKey1_參照規範(dropDownListObj1)
            ''2:設定選項
            'W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            'textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)

            'If textBoxObj1.Text <> "" Then
            '    '       2a:順位1: ListView.Insert.Textbox
            '    W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
            '    PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)

            'ElseIf queryKey1CheckBox.Checked = True Then
            '    '       2b:順位2:查詢畫面
            '    dropDownListObj1.SelectedValue = queryKey1DropDownList.SelectedValue
            'End If

            ''Key2
            'dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey2DropDownList"), DropDownList)
            'LabRecordA2_Setting_Module.P_SetDropDownList_DataKey2_表面類別(dropDownListObj1)

            'W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            'textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)

            'If textBoxObj1.Text <> "" Then
            '    W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
            '    PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)

            'ElseIf queryKey2CheckBox.Checked = True Then
            '    dropDownListObj1.SelectedValue = queryKey2DropDownList.SelectedValue
            'End If

            ''Key3
            'dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey3DropDownList"), DropDownList)
            'LabRecordA2_Setting_Module.P_SetDropDownList_DataKey3_鋼種(dropDownListObj1)

            'W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            'textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)

            'If textBoxObj1.Text <> "" Then
            '    W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
            '    PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)

            'ElseIf queryKey3CheckBox.Checked = True Then
            '    dropDownListObj1.SelectedValue = queryKey3DropDownList.SelectedValue
            'End If

            ''Key4
            'dropDownListObj2 = dropDownListObj1
            'dropDownListObj1 = CType(listViewItemObj.FindControl("EditKey4DropDownList"), DropDownList)
            'LabRecordA2_Setting_Module.P_SetDropDownList_DataKey4_材質(dropDownListObj1, dropDownListObj2.SelectedValue)

            'W_eachItem = PA_CS_ListView_Array_Info_ItemGet(1, dropDownListObj1.ID)
            'textBoxObj1 = CType((listViewItemObj.FindControl(W_eachItem.W_NameOfTextbox)), TextBox)

            'If textBoxObj1.Text <> "" Then
            '    W_TextValue = FS_DropboxList_Vaule_TextValue(W_eachItem, textBoxObj1.Text)
            '    PublicClassLibrary.ModTools.SelectedIndexByValue(dropDownListObj1, W_TextValue)

            'ElseIf queryKey4CheckBox.Checked = True Then
            '    dropDownListObj1.SelectedValue = queryKey4DropDownList.SelectedValue
            'End If







        End If

    End Sub
#End Region


#Region "P_INIT"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            P_INIT()
        End If
    End Sub

    Private W_Now主畫面_Enum As 主畫面_Enum = 主畫面_Enum.片語_條件檢查
    Private Sub P_INIT()
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey5_片語代號_條件檢查(queryKey5DropDownList)
        queryKey5CheckBox.Checked = True

        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey_條件檢查_DO( _
                                                                             queryKey1DropDownList _
                                                                            , 條件檢查_Enum.DataKey1_參照規範 _
                                                                            , False, queryKey1DropDownList.SelectedValue _
                                                                            , False, queryKey2DropDownList.SelectedValue _
                                                                            , False, queryKey3DropDownList.SelectedValue _
                                                                            , False, queryKey4DropDownList.SelectedValue _
                                                                            , True, queryKey5DropDownList.SelectedValue)


        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey_條件檢查_DO( _
                                                                     queryKey2DropDownList _
                                                                    , 條件檢查_Enum.DataKey2_表面類別 _
                                                                    , True, queryKey1DropDownList.SelectedValue _
                                                                    , False, queryKey2DropDownList.SelectedValue _
                                                                    , False, queryKey3DropDownList.SelectedValue _
                                                                    , False, queryKey4DropDownList.SelectedValue _
                                                                    , True, queryKey5DropDownList.SelectedValue)

        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey_條件檢查_DO( _
                                                                     queryKey3DropDownList _
                                                                    , 條件檢查_Enum.DataKey3_鋼種 _
                                                                    , True, queryKey1DropDownList.SelectedValue _
                                                                    , True, queryKey2DropDownList.SelectedValue _
                                                                    , False, queryKey3DropDownList.SelectedValue _
                                                                    , False, queryKey4DropDownList.SelectedValue _
                                                                    , True, queryKey5DropDownList.SelectedValue)

        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey_條件檢查_DO( _
                                                                     queryKey4DropDownList _
                                                                    , 條件檢查_Enum.DataKey4_材質 _
                                                                    , True, queryKey1DropDownList.SelectedValue _
                                                                    , True, queryKey2DropDownList.SelectedValue _
                                                                    , True, queryKey3DropDownList.SelectedValue _
                                                                    , False, queryKey4DropDownList.SelectedValue _
                                                                    , True, queryKey5DropDownList.SelectedValue)


        P_DropDownList_SetItem(Enum_DropDownList.檢驗項目基本檔_停用否, queryEFF_FLAGDropDown)
        queryEFF_FLAGDropDown.Items.Add("ALL：全部")

        LabRecordA2_Setting_Module.Main_Targe_Who = W_Now主畫面_Enum
    End Sub

    Public Function showRemarkInfo(ByVal fromRemarkID As String) As String
        Return LabRecordA2_Setting_Module.FS_Get_DataKey5_片語代號名稱(fromRemarkID)
    End Function

    Public Function showAssayInfo(ByVal fromAssayID As String) As String
        Dim retAssayName As String
        retAssayName = LabRecordA2_Setting_Module.FS_Get_DataKey5_檢驗代號名稱(fromAssayID)
        If retAssayName = "" Then retAssayName = fromAssayID

        Return retAssayName
    End Function
#End Region

#Region "SystemNote"
    Public Enum Enum_DropDownList
        檢驗項目基本檔_停用否 = 1
        檢驗項目基本檔_代號群組 = 2
        檢驗項目基本檔_資料來源類型 = 3
        檢驗項目基本檔_是否顯示 = 4
        片語基本檔_條件判斷 = 5
    End Enum

    Public Sub P_DropDownList_SetItem(ByVal fromNote_Type As Enum_DropDownList, _
                                        ByRef fromObj As DropDownList)
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
        Dim W_NoteType As String = [Enum].GetName(GetType(Enum_DropDownList), fromNote_Type)
        Dim queryDataTable1 As DataTable
        queryDataTable1 = W_ClsSystemNote.getLev3(C_SYSTEM_TYPE, W_NoteType)
        W_ClsSystemNote.setDropDownList(fromObj, queryDataTable1, W_ClsSystemNote.Display_Lable)
    End Sub

    Public Function showJUDGET_TYPE(ByVal fromNote_ID As String) As String
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
        Dim W_NoteType As String = [Enum].GetName(GetType(Enum_DropDownList), Enum_DropDownList.片語基本檔_條件判斷)

        Dim W_Context As String = W_ClsSystemNote.getLev4Content(C_SYSTEM_TYPE, W_NoteType, fromNote_ID)

        Dim retMsg As String = String.Concat(fromNote_ID, W_ClsSystemNote.Display_Symbol, W_Context)
        Return retMsg
    End Function

#End Region



    Public Function FS_DATE_FORMAT(ByVal fromDate As Date, ByVal fromType As Integer) As String
        Return LabRecordA2_Setting_Module.FS_DATE_FORMAT(fromDate, fromType)
    End Function


End Class