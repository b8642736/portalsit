Public Class LabRecordA2_Report
    Inherits System.Web.UI.UserControl

    Private C_System_Type As String = "品保_檢驗報告輸入"
    Private C_Split_Symbol As String = "|"
    Private C_UnInitValue As String = "UnInitValue"

#Region "ViewState"
    Const C_DataTable_AssayDat As String = "DataTable_AssayDat"
    Private Property WP_DataTable_AssayDat As DataTable
        Get
            If ViewState(C_DataTable_AssayDat) Is Nothing Then
                ViewState(C_DataTable_AssayDat) = LabRecordA2_Setting_Module.FD_GetDataKet5_AssayDat
            End If
            Return ViewState(C_DataTable_AssayDat)
        End Get

        Set(value As DataTable)
            ViewState(C_DataTable_AssayDat) = value
        End Set
    End Property

    <Global.System.Serializable()>
    Class ClassAssayItem
        Private _itemID As String
        Public Property itemID As String
            Set(value As String)
                _itemID = value
            End Set
            Get
                Return _itemID
            End Get
        End Property

        Private _itemValue As String
        Public Property itemValue As String
            Set(value As String)
                _itemValue = value
            End Set
            Get
                Return _itemValue
            End Get
        End Property

        Sub New(ByVal fromItemID As String)
            itemID = fromItemID
        End Sub
    End Class


    Const C_AssayItem As String = "AssayItem"
    Private Property WP_AssayItem As List(Of ClassAssayItem)
        Get
            If ViewState(C_AssayItem) Is Nothing Then
                ViewState(C_AssayItem) = New List(Of ClassAssayItem)
            End If
            Return ViewState(C_AssayItem)
        End Get

        Set(value As List(Of ClassAssayItem))
            ViewState(C_AssayItem) = value
        End Set
    End Property



#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LabRecordA2_Setting_Module.P_IE_Compatible(Page)

        If Not IsPostBack Then
            P_INIT()
        End If

        P_HtmlTable_AddControl_tableEdit1()
        P_HtmlTable_AddControl_tableEdit3()
    End Sub

    Private Sub P_INIT()
        P_INIT_edit()

        tbStartDate.Text = Format(DateAdd(DateInterval.Day, -14, Now), "yyyy/MM/dd")
        tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        tbSAMPLE_ID.Text = ""

        Me.hfSample_Unit.Value = ""
        Me.hfSQL_Master.Value = ""
        Me.hfSample_Kind_ID.Value = ""
        Me.hfSample_Kind_Name.Value = ""

        Me.hfDetailPK.Value = ""
        Me.hfDetailDoModeIsEdit.Value = ""
        Me.hfSQL_Detail.Value = ""



        MultiView1.SetActiveView(View1)
    End Sub

    Private Sub P_INIT_edit()
        Me.CustomValidator1.ErrorMessage = ""

        Me.editSAMPLE_DATETextBox.Text = ""
        Me.editSAMPLE_IDTextBox.Text = ""
        Me.editSAVE_INFORMATTextBox.Text = ""

        Dim tableEdit As HtmlTable = getTableEdit3()
        Dim objTextbox1 As TextBox
        Dim W_NameTextbox As String
        For Each eachAssayItem As ClassAssayItem In WP_AssayItem
            W_NameTextbox = FS_Get_EditControlName(eachAssayItem.itemID, EnumContolType.Textbox)
            objTextbox1 = tableEdit.FindControl(W_NameTextbox)

            objTextbox1.Text = ""
        Next eachAssayItem
    End Sub

#Region "P_HtmlTable_AddControl：動態產生HtmlTable相關Control"

    Private Sub P_HtmlTable_AddControl_tableEdit1()
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
        Dim W_Note_Type As String = "_輸入單位"
        Dim W_Note_Type2 As String = "_檢驗單位"

        Dim tableEdit As HtmlTable = Me.FindControl("tableEdit1")
        Dim tableColumnCount As Integer = 3
        Dim tableRow As HtmlTableRow
        Dim tableCell1 As HtmlTableCell, tableCell2 As HtmlTableCell, tableCell3 As HtmlTableCell

        Dim objButton1 As Button, objButton2 As Button, objButton3 As Button
        Dim W_KeyInUnitDataTable As DataTable = W_ClsSystemNote.getLev3(C_System_Type, W_Note_Type)
        Dim W_Sample_Kind As String

        Dim W_Index_Item_Now As Integer = -1
        Dim W_Index_Item_Max As Integer = W_KeyInUnitDataTable.Rows.Count - 1

        Do Until (W_Index_Item_Now >= W_Index_Item_Max)

            W_Index_Item_Now += 1
            tableCell1 = New HtmlTableCell
            If (W_Index_Item_Now <= W_Index_Item_Max) Then
                W_Sample_Kind = W_ClsSystemNote.getLev4Content(C_System_Type, W_Note_Type2, W_KeyInUnitDataTable.Rows(W_Index_Item_Now).Item(W_ClsSystemNote.NOTE_ID))
                objButton1 = P_HtmlTable_AddControl_tableEdit1_Get_NewButton(W_KeyInUnitDataTable.Rows(W_Index_Item_Now).Item(W_ClsSystemNote.NOTE_ID), W_KeyInUnitDataTable.Rows(W_Index_Item_Now).Item(W_ClsSystemNote.CONTENT), W_Sample_Kind)

                tableCell1.Controls.Add(objButton1)
            End If

            W_Index_Item_Now += 1
            tableCell2 = New HtmlTableCell
            If (W_Index_Item_Now <= W_Index_Item_Max) Then
                W_Sample_Kind = W_ClsSystemNote.getLev4Content(C_System_Type, W_Note_Type2, W_KeyInUnitDataTable.Rows(W_Index_Item_Now).Item(W_ClsSystemNote.NOTE_ID))
                objButton2 = P_HtmlTable_AddControl_tableEdit1_Get_NewButton(W_KeyInUnitDataTable.Rows(W_Index_Item_Now).Item(W_ClsSystemNote.NOTE_ID), W_KeyInUnitDataTable.Rows(W_Index_Item_Now).Item(W_ClsSystemNote.CONTENT), W_Sample_Kind)

                tableCell2.Controls.Add(objButton2)
            End If

            W_Index_Item_Now += 1
            tableCell3 = New HtmlTableCell
            If (W_Index_Item_Now <= W_Index_Item_Max) Then
                W_Sample_Kind = W_ClsSystemNote.getLev4Content(C_System_Type, W_Note_Type2, W_KeyInUnitDataTable.Rows(W_Index_Item_Now).Item(W_ClsSystemNote.NOTE_ID))
                objButton3 = P_HtmlTable_AddControl_tableEdit1_Get_NewButton(W_KeyInUnitDataTable.Rows(W_Index_Item_Now).Item(W_ClsSystemNote.NOTE_ID), W_KeyInUnitDataTable.Rows(W_Index_Item_Now).Item(W_ClsSystemNote.CONTENT), W_Sample_Kind)

                tableCell3.Controls.Add(objButton3)
            End If

            '------------------------------------------------------------
            tableRow = New HtmlTableRow
            tableRow.Cells.Add(tableCell1)
            tableRow.Cells.Add(tableCell2)
            tableRow.Cells.Add(tableCell3)

            tableEdit.Rows.Add(tableRow)
        Loop
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------


    End Sub

    Protected Function P_HtmlTable_AddControl_tableEdit1_Get_NewButton(ByVal fromID As String, ByVal fromText As String, ByVal fromSample_Kind As String) As Button
        Dim retObjButton As New Button
        retObjButton.ID = "btnKeyInUnit_" & fromID & "_" & fromSample_Kind
        retObjButton.Text = fromText

        retObjButton.Attributes.Add("class", "btnKeyInUnit")

        retObjButton.Attributes.Add("runat", "server")
        AddHandler retObjButton.Click, AddressOf btnKeyInUnit_GoKeyIn_Click

        Return retObjButton
    End Function


    Private Sub P_HtmlTable_AddControl_tableEdit3()
        Dim W_Sample_Unit As String = Me.hfSample_Unit.Value
        If W_Sample_Unit = "" Then Exit Sub

        Dim W_Note_Type As String = String.Concat("檢驗項目_", W_Sample_Unit)

        Dim tableEdit As HtmlTable = getTableEdit3()
        Dim tableColumnCount As Integer = 3
        Dim tableRow As HtmlTableRow
        Dim tableCell1 As HtmlTableCell, tableCell2 As HtmlTableCell, tableCell3 As HtmlTableCell

        Dim objLabel1 As Label
        Dim objTextbox1 As TextBox

        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
        Dim W_KeyInAssayDataTable As DataTable = W_ClsSystemNote.getLev3(C_System_Type, W_Note_Type)

        Dim W_ASSAY_ID As String = ""

        Dim W_Index_Item_Now As Integer
        Dim W_Index_Item_Max As Integer = W_KeyInAssayDataTable.Rows.Count - 1

        WP_AssayItem.Clear()
        W_Index_Item_Now = -1
        Do Until (W_Index_Item_Now >= W_Index_Item_Max)

            W_Index_Item_Now += 1

            W_ASSAY_ID = W_KeyInAssayDataTable.Rows(W_Index_Item_Now).Item(W_ClsSystemNote.NOTE_ID)
            WP_AssayItem.Add(New ClassAssayItem(W_ASSAY_ID))

            tableCell1 = New HtmlTableCell
            tableCell1.Attributes.Add("class", "styleTableEdit3_TD2")

            objLabel1 = New Label
            objLabel1.ID = FS_Get_EditControlName(W_ASSAY_ID, EnumContolType.Label)
            objLabel1.Text = showAssayInfo(W_ASSAY_ID)

            objLabel1.Attributes.Add("class", "ListView1CSS_Input")
            objLabel1.Attributes.Add("runat", "server")

            tableCell2 = New HtmlTableCell
            tableCell2.Controls.Add(objLabel1)

            objTextbox1 = New TextBox
            objTextbox1.ID = FS_Get_EditControlName(W_ASSAY_ID, EnumContolType.Textbox)
            objTextbox1.Attributes.Add("class", "ListView1CSS_Input")
            objTextbox1.Attributes.Add("runat", "server")

            tableCell3 = New HtmlTableCell
            tableCell3.Controls.Add(objTextbox1)
            '------------------------------------------------------------
            tableRow = New HtmlTableRow
            tableRow.Cells.Add(tableCell1)
            tableRow.Cells.Add(tableCell2)
            tableRow.Cells.Add(tableCell3)

            tableEdit.Rows.Add(tableRow)
        Loop
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------

        Dim DoModeIs As LabRecordA2_Setting_Module.EditMode_Enum = EditMode_Enum.初始化
        'Check is Rebuild

        '01:有輸入檢體編號
        If (editSAMPLE_IDTextBox.Text) <> "" Then
            DoModeIs = EditMode_Enum.Rebuild
        End If

        '02:有輸入檢驗項目值
        For Each eachAssayItem As ClassAssayItem In WP_AssayItem
            If getRequestControl(FS_Get_EditControlName(eachAssayItem.itemID, EnumContolType.Textbox)) <> "" Then
                DoModeIs = EditMode_Enum.Rebuild
            End If
        Next eachAssayItem

        '03:檢查物件訊息
        If CustomValidator1.ErrorMessage <> "" Then
            DoModeIs = EditMode_Enum.Rebuild
        End If

        '04:檢驗日期格式錯誤
        If editSAMPLE_DATETextBox.Text <> "" Then
            If IsDate(editSAMPLE_DATETextBox.Text) = False Then
                DoModeIs = EditMode_Enum.Rebuild
            End If
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        P_Detail_Display(DoModeIs)
    End Sub

    Enum EnumContolType
        Label = 1
        Textbox = 2
    End Enum
    Private Function FS_Get_EditControlName(ByVal fromASSAY_ID As String _
                                                                      , ByVal fromContolType As EnumContolType) As String
        Dim W_Sample_Unit As String = Me.hfSample_Unit.Value
        Dim W_ControlType As String = [Enum].GetName(GetType(EnumContolType), fromContolType)

        Return String.Concat("editASSAY_ID_", W_Sample_Unit, "_", fromASSAY_ID, W_ControlType)
    End Function

#End Region



#Region "Button：btn按鈕相關"
    Protected Sub btnInserNewRecord1_Click(sender As Object, e As EventArgs) _
                Handles btnInserNewRecord1.Click

        P_Detail_Display(EditMode_Enum.新增)

    End Sub

    Protected Sub btnBackTo1A_Click(sender As Object, e As EventArgs) Handles btnBackTo1A.Click
        'TabContainer1.ActiveTabIndex = 0
        P_Detail_Display(EditMode_Enum.初始化)
    End Sub

    Protected Sub btnKeyInUnit_GoKeyIn_Click(sender As Object, e As EventArgs)


        Dim objButton As Button = CType(sender, Button)
        Dim W_Split_ID() As String = objButton.ID.Split("_")

        Me.hfSample_Unit.Value = W_Split_ID(1)
        lbSample_Unit_Name.Text = String.Concat("【", objButton.Text, "】")

        Me.hfSample_Kind_ID.Value = W_Split_ID(2)

        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
        Dim W_Note_Type As String = "_檢驗單位"
        Dim W_Content As String = W_ClsSystemNote.getLev4Content(C_System_Type, W_Note_Type, Me.hfSample_Kind_ID.Value)

        Me.hfSample_Kind_Name.Value = W_Content
        Me.lbhfSample_Kind_Name_Query.Text = Me.hfSample_Kind_Name.Value
        Me.lbhfSample_Kind_Name_Edit.Text = Me.lbhfSample_Kind_Name_Query.Text


        P_HtmlTable_AddControl_tableEdit3()

        btnSearch_Click(Nothing, Nothing)
        MultiView1.SetActiveView(View2)
    End Sub

    Protected Sub btnKeyInUnit_GoBack_Click(sender As Object, e As EventArgs) Handles btnKeyInUnit_GoBack.Click
        P_INIT()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        GridView1.SelectedIndex = -1
        GridView1.PageIndex = 0

        WP_DataTable_AssayDat = Nothing
        GridView1_DataBind_My()
    End Sub



    Protected Sub btnEdit_Cancel_Click(sender As Object, e As EventArgs) Handles btnEdit_Cancel.Click
        If Me.hfDetailPK.Value.Length > 0 Then
            P_Detail_Display(EditMode_Enum.編輯)
        Else
            P_Detail_Display(EditMode_Enum.新增)
        End If
    End Sub

    Protected Sub btnEdit_Save_Click(sender As Object, e As EventArgs) Handles btnEdit_Save.Click
        TabContainer1.ActiveTabIndex = 1

        '資料驗證
        '-------------------------------------------------------------------------------------
        If FB_CustomValidator1() = False Then
            Exit Sub
        End If
        '-------------------------------------------------------------------------------------
        If FB_DB_CRUD() = False Then

            Exit Sub
        End If

        '-------------------------------------------------------------------------------------
        P_INIT_edit()


        btnSearch_Click(Nothing, Nothing)
    End Sub


    Private Function FB_CustomValidator1() As Boolean


        CustomValidator1.ErrorMessage = ""
        Dim W_MSG As New List(Of String)
        Dim W_Char_Start As String = "【"
        Dim W_Char_End As String = "】"

        If IsDate(editSAMPLE_DATETextBox.Text) = False Then
            W_MSG.Add(String.Concat(W_Char_Start, "檢驗日期", W_Char_End, " 格式錯誤"))
        End If

        If editSAMPLE_IDTextBox.Text.Trim = "" Then
            W_MSG.Add(String.Concat(W_Char_Start, lbhfSample_Kind_Name_Edit.Text, W_Char_End, " 未輸入"))
        End If


       Dim tableEdit As HtmlTable = getTableEdit3()

        Dim W_NameTextbox As String
        Dim objTextbox1 As TextBox
        Dim W_HaveAssayItem As Boolean = False
        For Each eachAssayItem As ClassAssayItem In WP_AssayItem
            W_NameTextbox = FS_Get_EditControlName(eachAssayItem.itemID, EnumContolType.Textbox)
            objTextbox1 = tableEdit.FindControl(W_NameTextbox)

            If objTextbox1.Text = "" Then
                If W_HaveAssayItem = False Then
                    W_HaveAssayItem = True

                    W_MSG.Add("")
                    W_MSG.Add(String.Concat("檢驗項目"))
                    W_MSG.Add(Space(50).Replace(Space(1), "-"))
                End If

                W_MSG.Add(String.Concat(W_Char_Start, showAssayInfo(eachAssayItem.itemID), W_Char_End, " 未輸入"))
            End If
        Next eachAssayItem


        '新增時需檢查KEY是否重複，格式都對才檢查DB
        '---------------------------------------------------
        If Not Me.hfDetailDoModeIsEdit.Value.Equals("Y") AndAlso _
            W_MSG.Count = 0 Then

            Dim W_SQL As New StringBuilder
            W_SQL.Append("Select 1 " & vbNewLine)
            W_SQL.Append("FROM [LabRecordA2_Report] " & vbNewLine)
            W_SQL.Append("Where 1 = 1 " & vbNewLine)
            W_SQL.Append("AND SAMPLE_UNIT= '" & Me.hfSample_Unit.Value & "' " & vbNewLine)
            W_SQL.Append("AND SAMPLE_DATE= " & FS_Convert_Date_EEEMMDD(Me.editSAMPLE_DATETextBox.Text) & " " & vbNewLine)
            W_SQL.Append("AND SAMPLE_ID = '" & Me.editSAMPLE_IDTextBox.Text & "' " & vbNewLine)

            Dim W_Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
            If W_Adapter.SelectQuery(W_SQL.ToString).Rows.Count > 0 Then
                W_MSG.Add(String.Concat(W_Char_Start, "資料重複", W_Char_End, " 檢驗日期：" & Me.editSAMPLE_DATETextBox.Text, Space(2), Me.lbhfSample_Kind_Name_Edit.Text, "：" & Me.editSAMPLE_IDTextBox.Text))
            End If

        End If
        '---------------------------------------------------

        CustomValidator1.ErrorMessage = String.Join("<BR/>", W_MSG.ToArray)
        CustomValidator1.IsValid = (CustomValidator1.ErrorMessage.Length = 0)
        Return CustomValidator1.IsValid
    End Function

    Private Function FB_DB_CRUD() As Boolean
   
        Dim W_SQL_Del As New StringBuilder
        Dim W_SQL_Add As New StringBuilder
        Dim W_SAVE_OPER As String = LabRecordA2_Setting_Module.FS_SAVE_OPER
        Dim W_SAVE_DATE As String = LabRecordA2_Setting_Module.FS_DATE_FORMAT(LabRecordA2_Setting_Module.FS_SAVE_DATE, 1)

        Try
            CustomValidator1.ErrorMessage = ""

            Dim W_NameTextbox As String
            Dim objTextbox1 As TextBox
            Dim W_Additem As String
            Dim tableEdit As HtmlTable = getTableEdit3()
            Dim W_SAMPLE_DATE As String = FS_Convert_Date_EEEMMDD(Me.editSAMPLE_DATETextBox.Text)

            'Type1： 準備資料

            W_SQL_Del.Append("DELETE " & vbNewLine)
            W_SQL_Del.Append("FROM [LabRecordA2_Report] " & vbNewLine)
            W_SQL_Del.Append("Where 1 = 1 " & vbNewLine)
            W_SQL_Del.Append("AND SAMPLE_UNIT= '" & Me.hfSample_Unit.Value & "' " & vbNewLine)
            W_SQL_Del.Append("AND SAMPLE_DATE= " & W_SAMPLE_DATE & " " & vbNewLine)
            W_SQL_Del.Append("AND SAMPLE_ID = '" & Me.editSAMPLE_IDTextBox.Text & "' " & vbNewLine)


            W_SQL_Add.Append("INSERT INTO [LabRecordA2_Report] ([SAMPLE_UNIT] ,[SAMPLE_DATE] ,[SAMPLE_KIND] ,[SAMPLE_ID] ,[ASSAY_ID] ,[RESULT_VALUE] ,[SAVE_OPER] ,[SAVE_DATE])  " & vbNewLine)
            W_SQL_Add.Append(" VALUES  " & vbNewLine)

            W_Additem = ""
            For Each eachAssayItem As ClassAssayItem In WP_AssayItem
                W_NameTextbox = FS_Get_EditControlName(eachAssayItem.itemID, EnumContolType.Textbox)
                objTextbox1 = tableEdit.FindControl(W_NameTextbox)

                If W_Additem <> "" Then W_Additem &= vbNewLine & ","
                W_Additem &= "( "
                W_Additem & = " '" & Me.hfSample_Unit.Value & "' "
                W_Additem &= ", " & W_SAMPLE_DATE
                W_Additem &= ", '" & Me.hfSample_Kind_ID.Value & "'"
                W_Additem &= ", '" & Me.editSAMPLE_IDTextBox.Text & "'"
                W_Additem &= ", '" & eachAssayItem.itemID & "'"
                W_Additem &= ", '" & objTextbox1.Text & "'"
                W_Additem &= ", '" & W_SAVE_OPER & "'"
                W_Additem &= ", '" & W_SAVE_DATE & "'"
                W_Additem &= ") "
            Next eachAssayItem

            W_SQL_Add.Append(W_Additem & " " & vbNewLine)


            Dim W_HaveDelete As Boolean = (Me.hfDetailDoModeIsEdit.Value.Equals("Y"))
            Dim W_Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
            Dim W_SqlConnection As SqlClient.SqlConnection = W_Adapter.SqlConnection
            W_SqlConnection.Open()

            Dim W_SqlTransaction As SqlClient.SqlTransaction = W_SqlConnection.BeginTransaction

            Dim W_CMD_Del As New SqlClient.SqlCommand(W_SQL_Del.ToString, W_SqlConnection)
            W_CMD_Del.Transaction = W_SqlTransaction

            Dim W_CMD_Add As New SqlClient.SqlCommand(W_SQL_Add.ToString, W_SqlConnection)
            W_CMD_Add.Transaction = W_SqlTransaction

            Try

                'Type2-1：編輯時要先刪除舊資料
                If W_HaveDelete = True Then
                    W_CMD_Del.ExecuteNonQuery()
                End If

                'Type2-2：新增資料
                W_CMD_Add.ExecuteNonQuery()

                'Type2-3:Commit
                W_SqlTransaction.Commit()

            Catch ex2 As Exception
                W_SqlTransaction.Rollback()
                CustomValidator1.ErrorMessage &= vbNewLine & "FB_DB_CRUD-2：" & ex2.Message

            Finally
                W_SqlConnection.Close()
            End Try
   


        Catch ex1 As Exception
            CustomValidator1.ErrorMessage &= vbNewLine & "FB_DB_CRUD-1：" & ex1.Message

        Finally

        End Try

        CustomValidator1.IsValid = (CustomValidator1.ErrorMessage.Length = 0)
        Return CustomValidator1.IsValid
    End Function


#End Region


#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"


    Enum Enum_QueryMode
        Master = 1
        Detail = 2
    End Enum

    Private Sub MakeQryStringToControl_Master()
        MakeQryStringToControl(Enum_QueryMode.Master)
    End Sub

    Private Sub MakeQryStringToControl_Detail_Edit()
        MakeQryStringToControl(Enum_QueryMode.Detail)
    End Sub


    Private Sub MakeQryStringToControl(ByVal fromQueryMode As Enum_QueryMode)

        Dim queryTime As String = Now.ToString("HHmmss")

        Dim sql As New StringBuilder
        sql.Append("SELECT  A.* " & vbNewLine)
        sql.Append("FROM QCdb01.dbo.LabRecordA2_Report  A" & vbNewLine)
        sql.Append("		LEFT JOIN  [QCdb01].[dbo].[LabRecordA2_Assay_DAT] B ON A.ASSAY_ID = B.ASSAY_ID " & vbNewLine)
        sql.Append(" WHERE 1=1  " & vbNewLine)

        Select Case fromQueryMode
            Case Enum_QueryMode.Master
                Dim StartDateValue As String = New AS400DateConverter(CType(Me.tbStartDate.Text, Date)).TwIntegerTypeData
                Dim EndDateValue As String = New AS400DateConverter(CType(Me.tbEndDate.Text, Date)).TwIntegerTypeData

                sql.Append("       AND SAMPLE_UNIT ='" & Me.hfSample_Unit.Value & "'  " & vbNewLine)
                sql.Append("       AND SAMPLE_DATE   BETWEEN " & StartDateValue & " AND " & EndDateValue & "  " & vbNewLine)

                sql.Append("       AND SAMPLE_KIND ='" & Me.hfSample_Kind_ID.Value & "'  " & vbNewLine)
                If Not String.IsNullOrEmpty(tbSAMPLE_ID.Text) Then
                    tbSAMPLE_ID.Text = tbSAMPLE_ID.Text.Replace("'", Nothing)
                    sql.Append(IIf(tbSAMPLE_ID.Text.Trim.Length > 0, " AND SAMPLE_ID  IN ('" & tbSAMPLE_ID.Text.Replace(",", "','") & "')", Nothing) & "    " & vbNewLine)
                End If
                sql.Append(" ORDER BY SAMPLE_UNIT, SAMPLE_DATE , SAMPLE_ID,  B.DISPLAY_SEQ" & vbNewLine)

                Me.hfSQL_Master.Value = queryTime & "|" & sql.ToString

            Case Enum_QueryMode.Detail
                Dim W_Split_DetailPK() As String = Split(Me.hfDetailPK.Value, C_Split_Symbol)

                Dim W_SAMPLE_UNIT As String = W_Split_DetailPK(0)
                Dim W_SAMPLE_DATE As String = W_Split_DetailPK(1)
                Dim W_SAMPLE_ID As String = W_Split_DetailPK(2)

                sql.Append("       AND SAMPLE_UNIT ='" & W_SAMPLE_UNIT & "'  " & vbNewLine)
                sql.Append("       AND SAMPLE_DATE   = " & W_SAMPLE_DATE & "  " & vbNewLine)
                sql.Append("       AND SAMPLE_KIND ='" & Me.hfSample_Kind_ID.Value & "'  " & vbNewLine)
                sql.Append("       AND SAMPLE_ID ='" & W_SAMPLE_ID & "'  " & vbNewLine)
                sql.Append(" ORDER BY B.DISPLAY_SEQ, ASSAY_ID " & vbNewLine)

                Me.hfSQL_Detail.Value = queryTime & "|" & sql.ToString

        End Select



    End Sub
#End Region

#Region "CRUD"

    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL As String) As DataTable
        If String.IsNullOrEmpty(fromSQL) OrElse fromSQL = "" _
            OrElse fromSQL.Split("|").Count < 2 Then
            Return New DataTable
        End If

        Dim adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        Dim ds As DataTable = adapter.SelectQuery(fromSQL.Split("|")(1))

        Return ds
    End Function
#End Region

#Region "Master：GridView1相關"

    Public Sub GridView1_DataBind_My()
        MakeQryStringToControl_Master()
        Dim W_DataTable As DataTable = Search(Me.hfSQL_Master.Value)

        GridView1.DataSource = W_DataTable
        GridView1.DataBind()


        GridView1_MergeRows(GridView1, "Label") ';// GridView 要整合的列數 需要改變的Lable控制項

        TabContainer1.ActiveTabIndex = 0
    End Sub

    Enum GridView1_Enum
        編輯 = 0
        檢驗日期 = 1
        檢驗單位 = 2
        檢驗項目 = 3
        檢驗結果 = 4
        存檔資訊 = 5
    End Enum

    Public Sub GridView1_MergeRows(ByRef fromGridView As GridView _
                                                                  , ByVal fromControlNameo As String)


        Dim col_0 As Integer = GridView1_Enum.檢驗日期  '0
        Dim col_1 As Integer = GridView1_Enum.檢驗單位 '1
        Dim col_099 As Integer = 99
        Dim controlName_0 As String = String.Concat(fromControlNameo, "0") '; // 獲取當前列需要改變的Lable控制項ID
        Dim controlName_1 As String = String.Concat(fromControlNameo, "1")
        Dim controlName_099 As String = String.Concat(fromControlNameo, "0", col_099)
        Dim W_Index_099 As Integer = 0


        Dim row As GridViewRow
        Dim previousRow As GridViewRow

        Dim rowIndex As Integer
        Dim row_lbl_0 As Label
        Dim previousrow_lbl_0
        Dim row_lbl_1 As Label
        Dim previousrow_lbl_1 As Label
        Dim row_lbl_099 As Label

        W_Index_099 += 1
        rowIndex = (fromGridView.Rows.Count - 1)
        If rowIndex < 0 Then Exit Sub

        row = fromGridView.Rows(rowIndex)
        row_lbl_099 = CType(row.Cells(col_0).FindControl(controlName_099), Label)
        row_lbl_099.Text = W_Index_099
        GridView1_BackColor(row, row_lbl_099)


        For rowIndex = fromGridView.Rows.Count - 2 To 0 Step -1 ' //GridView中獲取行數 並遍歷每一行

            row = fromGridView.Rows(rowIndex) '; // 獲取當前行
            previousRow = fromGridView.Rows(rowIndex + 1) ' // 獲取當前行 的上一行

            row_lbl_0 = CType(row.Cells(col_0).FindControl(controlName_0), Label) '; // 獲取當前列當前行 的 Lable 控制項ID 的文本
            previousrow_lbl_0 = CType(previousRow.Cells(col_0).FindControl(controlName_0), Label) '; // 獲取當前列當前行 的上一行 的 Lable控制項ID 的文本
            row_lbl_1 = CType(row.Cells(col_1).FindControl(controlName_1), Label)
            previousrow_lbl_1 = CType(previousRow.Cells(col_1).FindControl(controlName_1), Label)
            row_lbl_099 = CType(row.Cells(col_0).FindControl(controlName_099), Label)


            If (Not row_lbl_0 Is Nothing AndAlso Not previousrow_lbl_0 Is Nothing) AndAlso (Not row_lbl_1 Is Nothing AndAlso Not previousrow_lbl_1 Is Nothing) Then ' // 如果當前行 和 上一行 要改動的 Lable 的ID 的文本不為空

                If (row_lbl_0.Text = previousrow_lbl_0.Text) AndAlso (row_lbl_1.Text = previousrow_lbl_1.Text) Then '// 如果當前行 和 上一行 要改動的 Lable 的ID 的文本不為空 且相同

                    '// 當前行的目前的儲存格（儲存格跨越的行數。 預設值為 0 ） 與下一行的目前的儲存格的跨越行數相等且小於一 則 返回2 否則讓上一行行的目前的儲存格的跨越行數+1
                    row.Cells(col_0).RowSpan = IIf(previousRow.Cells(col_0).RowSpan < 1, 2, previousRow.Cells(col_0).RowSpan + 1)
                    row.Cells(GridView1_Enum.編輯).RowSpan = row.Cells(col_0).RowSpan
                    row.Cells(GridView1_Enum.檢驗單位).RowSpan = row.Cells(col_0).RowSpan
                    row.Cells(GridView1_Enum.存檔資訊).RowSpan = row.Cells(col_0).RowSpan

                    '//並讓上一行的目前的儲存格不顯示
                    previousRow.Cells(col_0).Visible = False
                    previousRow.Cells(GridView1_Enum.編輯).Visible = (previousRow.Cells(col_0).Visible)
                    previousRow.Cells(GridView1_Enum.檢驗單位).Visible = (previousRow.Cells(col_0).Visible)
                    previousRow.Cells(GridView1_Enum.存檔資訊).Visible = (previousRow.Cells(col_0).Visible)

                Else
                    W_Index_099 += 1
                End If

            End If

            row_lbl_099.Text = W_Index_099
            GridView1_BackColor(row, row_lbl_099)


        Next rowIndex


    End Sub

    Public Sub GridView1_BackColor(ByRef fromRow As GridViewRow _
                                                              , ByVal fromLabel099 As Label)

        If (Integer.Parse(fromLabel099.Text) Mod 2 = 0) Then Exit Sub

        For Each cell As TableCell In fromRow.Cells
            cell.BackColor = Drawing.Color.PaleGoldenrod
        Next cell
    End Sub

    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        P_Detail_Display(EditMode_Enum.編輯)
    End Sub

    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex

        GridView1_DataBind_My()

        TabContainer1.ActiveTabIndex = 0
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If (e.Row.RowType = DataControlRowType.Header) Then
            e.Row.Cells(GridView1_Enum.檢驗單位).Text = Me.hfSample_Kind_Name.Value
        End If

    End Sub

    Public Function GridView1_PageSize() As Integer
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
        Dim W_Note_Type As String = "_GridView1"
        Dim W_Note_ID As String = "PageSize"
        Dim W_DataTable As DataTable = W_ClsSystemNote.getLev3(C_System_Type, W_Note_Type)

        Dim W_Content As String = (From A In W_DataTable Where A.Field(Of String)(W_ClsSystemNote.NOTE_ID).Equals(W_Note_ID) Select A.Field(Of String)(W_ClsSystemNote.CONTENT)).FirstOrDefault

        If IsNumeric(W_Content) = False Then W_Content = "2"

        Return Integer.Parse(W_Content)
    End Function

#End Region


#Region "Dynamic HtmlTabl"

    Private Function getRequestIndex(ByVal fromControlID As String) As Integer

        Dim W_Index As Integer
        For Each eachItem As String In Request.Form.AllKeys

            For Each eachSplit As String In eachItem.Split("$")
                If eachSplit.Equals(fromControlID) Then
                    Return W_Index
                End If
            Next

            W_Index += 1
        Next

        Return -1
    End Function


    Private Function getRequestControl(ByVal fromControlID As String) As String
        Dim W_Index As Integer = getRequestIndex(fromControlID)
        Dim retRequest As String = ""

        If W_Index > -1 Then
            retRequest = Request.Form(W_Index)
        End If

        Return retRequest
    End Function


#End Region
#Region "Detail相關"
    Private Function getTableEdit3() As HtmlTable
        Dim W_Me_Now As Object = Me.FindControl("MultiView1").FindControl("View2").FindControl("TabContainer1").FindControl("TabPanel2")
        Dim tableEdit As HtmlTable = W_Me_Now.FindControl("tableEdit3")

        Return tableEdit
    End Function

    Private Sub P_Detail_Display(ByVal fromDoModeIs As LabRecordA2_Setting_Module.EditMode_Enum)

        Dim W_SAMPLE_UNIT As String = ""
        Dim W_SAMPLE_DATE As String = Format(Now, "yyyy/MM/dd")
        Dim W_SAMPLE_ID As String = ""

        Dim W_SAVE_INFORMAT As String = ""

        Dim W_hfDetailPK As String = ""
        Dim W_hfDetailDoModeIsEdit As String = "N"
        Dim W_CustomValidator1 As String = ""
        Dim W_Input_Lock_Check As Boolean = False

        Dim W_Assay_Value As String = ""

        Dim tableEdit As HtmlTable = getTableEdit3()
        Dim W_NameTextbox As String
        Dim objTextbox1 As TextBox



        'Step1：準備資料
        '------------------------------------------------------------------------------------------------

        Select Case fromDoModeIs
            Case EditMode_Enum.編輯
                W_Input_Lock_Check = True
                W_hfDetailDoModeIsEdit = "Y"

                Dim W_SelectedRowIndex As Integer = GridView1.SelectedRow.RowIndex

                W_SAMPLE_UNIT = GridView1.DataKeys(W_SelectedRowIndex).Values(0)
                W_SAMPLE_DATE = GridView1.DataKeys(W_SelectedRowIndex).Values(1)
                W_SAMPLE_ID = GridView1.DataKeys(W_SelectedRowIndex).Values(2)

                W_hfDetailPK = String.Concat(W_SAMPLE_UNIT, C_Split_Symbol, _
                                                                         W_SAMPLE_DATE, C_Split_Symbol, _
                                                                         W_SAMPLE_ID)


                Me.hfDetailPK.Value = W_hfDetailPK
                '---------------------------------------------------------------------------------------------------
                MakeQryStringToControl_Detail_Edit()
                Dim W_DataTable As DataTable = Search(Me.hfSQL_Detail.Value)


                '準備檢驗項目報告資料
                '---------------------------------------------------------------------------------------------------
                For Each eachAssayItem As ClassAssayItem In WP_AssayItem
                    W_Assay_Value = (From A In W_DataTable.AsEnumerable _
                                                           Where A.Field(Of String)("ASSAY_ID").Equals(eachAssayItem.itemID) _
                                                        Select A.Field(Of String)("RESULT_VALUE")).FirstOrDefault

                    eachAssayItem.itemValue = W_Assay_Value
                Next eachAssayItem

                Dim W_SAVE_OPER As String = (From A In W_DataTable.AsEnumerable Select A.Field(Of String)("SAVE_OPER")).FirstOrDefault
                Dim W_SAVE_DATE As String = (From A In W_DataTable.AsEnumerable Select A.Field(Of DateTime)("SAVE_DATE")).FirstOrDefault
                W_SAVE_INFORMAT = Replace(showSaveInfo(W_SAVE_OPER, W_SAVE_DATE), "<BR>", vbNewLine)
                '---------------------------------------------------------------------------------------------------
                W_SAMPLE_DATE = FS_Convert_Date_YYYYMMDD(W_SAMPLE_DATE)



            Case EditMode_Enum.Rebuild
                W_hfDetailDoModeIsEdit = Me.hfDetailDoModeIsEdit.Value
                W_CustomValidator1 = Me.CustomValidator1.ErrorMessage
                W_hfDetailPK = Me.hfDetailPK.Value()
                W_Input_Lock_Check = (W_hfDetailDoModeIsEdit.Equals("Y"))

                W_SAMPLE_DATE = editSAMPLE_DATETextBox.Text
                W_SAMPLE_ID = editSAMPLE_IDTextBox.Text
                W_SAVE_INFORMAT = editSAVE_INFORMATTextBox.Text

                '準備檢驗項目報告資料
                '---------------------------------------------------------------------------------------------------
                For Each eachAssayItem As ClassAssayItem In WP_AssayItem
                    W_Assay_Value = getRequestControl(FS_Get_EditControlName(eachAssayItem.itemID, EnumContolType.Textbox))

                    eachAssayItem.itemValue = W_Assay_Value
                Next eachAssayItem

                '---------------------------------------------------------------------------------------------------


            Case Else

                If fromDoModeIs <> EditMode_Enum.初始化 Then
                    W_hfDetailPK = ""
                End If

                '準備檢驗項目報告資料
                '---------------------------------------------------------------------------------------------------
                For Each eachAssayItem As ClassAssayItem In WP_AssayItem
                    W_Assay_Value = ""

                    eachAssayItem.itemValue = W_Assay_Value
                Next eachAssayItem
                '---------------------------------------------------------------------------------------------------
        End Select


        'Step2：共同一樣

        '---------------------------------------------------------------------------------------------------
        Me.hfDetailDoModeIsEdit.Value = W_hfDetailDoModeIsEdit
        Me.hfDetailPK.Value = W_hfDetailPK

        Me.CustomValidator1.ErrorMessage = W_CustomValidator1


        P_Detail_Textbox_Attributes(editSAMPLE_DATETextBox, W_SAMPLE_DATE, W_Input_Lock_Check)
        editSAMPLE_DATETextBox.Enabled = Not W_Input_Lock_Check

        P_Detail_Textbox_Attributes(editSAMPLE_IDTextBox, W_SAMPLE_ID, W_Input_Lock_Check)
        P_Detail_Textbox_Attributes(editSAVE_INFORMATTextBox, W_SAVE_INFORMAT, True)

        For Each eachAssayItem As ClassAssayItem In WP_AssayItem
            W_NameTextbox = FS_Get_EditControlName(eachAssayItem.itemID, EnumContolType.Textbox)
            objTextbox1 = tableEdit.FindControl(W_NameTextbox)

            P_Detail_Textbox_Attributes(objTextbox1, eachAssayItem.itemValue, False)
        Next eachAssayItem
        '---------------------------------------------------------------------------------------------------


        'Step3：切換TabContainer1.ActiveTabIndex
        '------------------------------------------------------------------------------------------------
        Select Case fromDoModeIs
            Case EditMode_Enum.初始化
                TabContainer1.ActiveTabIndex = 0

            Case Else
                TabContainer1.ActiveTabIndex = 1
        End Select

    End Sub

    Private Sub P_Detail_Textbox_Attributes(ByRef fromTextboxObj As TextBox _
                                                                  , ByVal fromTextValue As String _
                                                                  , ByVal fromIsLock As Boolean)

        fromTextboxObj.Text = fromTextValue

        fromTextboxObj.Attributes.Clear()
        If fromIsLock = True Then
            fromTextboxObj.Attributes.Add("class", "ListView1CSS_Lock")
            fromTextboxObj.Attributes.Add("ReadOnly", "true")
        Else
            fromTextboxObj.Attributes.Add("class", "ListView1CSS_Input")
        End If
    End Sub

#End Region


#Region "FS_Convert_Date_YYYYMMDD：日期格式轉換"
    Public Function FS_Convert_Date_EEEMMDD(ByVal fromDate_YYYYMMDD As String) As String

        Dim W_Date_YYYYMMDD As Integer = Integer.Parse(fromDate_YYYYMMDD.Replace("/", ""))
        Dim retString As String = (W_Date_YYYYMMDD - 19110000).ToString

        Return retString
    End Function

    Public Function FS_Convert_Date_YYYYMMDD(ByVal fromDate_EEEMMDD As String) As String
        Dim retString As String = fromDate_EEEMMDD

        Select Case fromDate_EEEMMDD.Length
            Case 6, 7
                Dim W_Year As String, W_Month As String, W_Day As String
                W_Year = fromDate_EEEMMDD.Substring(0, fromDate_EEEMMDD.Length - 4)
                W_Month = fromDate_EEEMMDD.Substring(W_Year.Length, 2)
                W_Day = fromDate_EEEMMDD.Substring(fromDate_EEEMMDD.Length - 2, 2)

                retString = String.Concat((Integer.Parse(W_Year) + 1911), "/", W_Month, "/", W_Day)

            Case Else

        End Select


        Return retString
    End Function

#End Region




    Public Function showAssayInfo(ByVal fromAssayID As String) As String
        Return LabRecordA2_Setting_Module.FS_Get_DataKey5_檢驗代號名稱(fromAssayID, WP_DataTable_AssayDat)
    End Function

    Public Function showSaveInfo(ByVal fromSAVE_OPER As String, ByVal fromSAVE_DATE As String) As String
        Dim retString As String

        retString = fromSAVE_OPER
        retString &= "<BR>"
        retString &= FS_DATE_FORMAT(fromSAVE_DATE, 3)

        Return retString
    End Function

    Public Function FS_DATE_FORMAT(ByVal fromDate As Date, ByVal fromType As Integer) As String
        Return LabRecordA2_Setting_Module.FS_DATE_FORMAT(fromDate, fromType)
    End Function



End Class