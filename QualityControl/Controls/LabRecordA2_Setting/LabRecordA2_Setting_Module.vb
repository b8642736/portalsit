Imports System.Web

Module LabRecordA2_Setting_Module

#Region "共用變數"
    Public C_SYSTEM_TYPE As String = "品保_檢驗證明書"

    Public C_Fix_DropDown As String = "DropDown"
    Public C_Fix_DropDownList As String = "DropDownList"

    Public C_Fix_HiddenField As String = "HiddenField"
    Public C_Fix_TextBox As String = "TextBox"

    Public C_Fix_CheckBox As String = "CheckBox"
#End Region

    Public C_SystemChar As String = "_"
    Public C_RGBTextColorLock As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#2B2B2B")
    Public C_RGBTextColorUnLock As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#000000")
    Public C_RGBColorLock As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#CCCCCC")
    Public C_RGBColorUNLock As System.Drawing.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF")


#Region "PublicClassLibrary.ClsSystemNote"
    '1050910 by renhsin,因為多個頁面會共同使用,Session會不明原因被切斷,因此每此都見一個新的。
    'Private WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
    Private _ClsSystemNote_Display_Symbol As String
    Public ReadOnly Property C_ClsSystemNote_Display_Symbol As String
        Get
            If _ClsSystemNote_Display_Symbol = "" Then
                _ClsSystemNote_Display_Symbol = New PublicClassLibrary.ClsSystemNote().Display_Symbol
            End If
            Return _ClsSystemNote_Display_Symbol
        End Get
    End Property
    Private _ClsSystemNote_C_NOTE_ID As String
    Public ReadOnly Property C_ClsSystemNote_NOTE_ID As String
        Get
            If _ClsSystemNote_C_NOTE_ID = "" Then
                _ClsSystemNote_C_NOTE_ID = New PublicClassLibrary.ClsSystemNote().NOTE_ID
            End If
            Return _ClsSystemNote_C_NOTE_ID
        End Get
    End Property
#End Region

    Public Enum EditMode_Enum
        初始化 = 0
        新增 = 1
        編輯 = 2
        查詢 = 3

        Rebuild = 4
    End Enum

#Region "Get_DataKey：1~4共用"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Const C_VW_GetDataKey0_Default As String = "VW_GetDataKey0_Default"
    Private _ViewState_C_VW_GetDataKey0_Default As DataTable = Nothing
    Private ReadOnly Property FD_GetDataKey0_Default() As DataTable
        Get
            If _ViewState_C_VW_GetDataKey0_Default Is Nothing Then
                Dim W_NoteType As String = "檢驗項目基本檔_批次資料代號"
                Dim queryDataTable1 As DataTable
                Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

                queryDataTable1 = W_ClsSystemNote.getLev3(C_SYSTEM_TYPE, W_NoteType)

                _ViewState_C_VW_GetDataKey0_Default = queryDataTable1

            End If

            Return _ViewState_C_VW_GetDataKey0_Default
        End Get
    End Property

    '1050905 by renhsin
    '先不啟用Cache,因為初期基本檔資料會有大量錯誤,修正後必須斷掉session後才會更新對照檔
    '故過一段時間後再啟動
    '
    'Const C_VW_GetDataKey1 As String = "VW_GetDataKey1"
    'Private _ViewState_C_VW_GetDataKey1 As DataTable = Nothing
    Private ReadOnly Property FD_GetDataKey1() As DataTable
        Get
            'If _ViewState_C_VW_GetDataKey1 Is Nothing Then
            Dim W_SQL As New StringBuilder

            W_SQL.Append("SELECT RTRIM(cio02) key1 " & vbNewLine)
            W_SQL.Append("FROM @#SLS300LB.SL2CIOPF " & vbNewLine)
            W_SQL.Append("WHERE 1=1 " & vbNewLine)
            W_SQL.Append("GROUP BY cio02 " & vbNewLine)
            W_SQL.Append("ORDER BY cio02 " & vbNewLine)

            Dim queryDataTable1 As DataTable = New AS400SQLQueryAdapter().SelectQuery(W_SQL.ToString)

            '_ViewState_C_VW_GetDataKey1 = queryDataTable1
            'End If

            'Return _ViewState_C_VW_GetDataKey1
            Return queryDataTable1
        End Get

    End Property

    'Const C_VW_GetDataKey2 As String = "VW_GetDataKey2"
    'Private _ViewState_C_VW_GetDataKey2 As DataTable = Nothing
    Private ReadOnly Property FD_GetDataKey2() As DataTable
        Get
            'If _ViewState_C_VW_GetDataKey2 Is Nothing Then
            Dim W_SQL As New StringBuilder

            W_SQL.Append("SELECT RTRIM(ch205) key2 " & vbNewLine)
            W_SQL.Append("FROM @#SLS300LB.SL2CH2PF " & vbNewLine)
            W_SQL.Append("WHERE 1=1 " & vbNewLine)
            W_SQL.Append("GROUP BY ch205 " & vbNewLine)
            W_SQL.Append("ORDER BY ch205 " & vbNewLine)

            Dim queryDataTable1 As DataTable = New AS400SQLQueryAdapter().SelectQuery(W_SQL.ToString)
            '_ViewState_C_VW_GetDataKey2 = queryDataTable1
            'End If

            'Return _ViewState_C_VW_GetDataKey2
            Return queryDataTable1
        End Get

    End Property

    'Const C_VW_GetDataKey3_Key4 As String = "VW_GetDataKey3_Key4"
    'Private _ViewState_C_VW_GetDataKey3_Key4 As DataTable = Nothing
    Private ReadOnly Property FD_GetDataKey3_Key4() As DataTable
        Get
            'If _ViewState_C_VW_GetDataKey3_Key4 Is Nothing Then
            Dim W_SQL As New StringBuilder

            W_SQL.Append("SELECT  RTRIM(ch101) key3 ,RTRIM(ch101a) key4     " & vbNewLine)
            W_SQL.Append("FROM @#SLS300LB.SL2CH1PF " & vbNewLine)
            W_SQL.Append("WHERE 1=1 " & vbNewLine)
            W_SQL.Append("AND NOT (ch101 = ''   AND  ch101a='') " & vbNewLine)
            W_SQL.Append("GROUP BY ch101,ch101a " & vbNewLine)
            W_SQL.Append("ORDER BY ch101,ch101a " & vbNewLine)

            Dim queryDataTable1 As DataTable = New AS400SQLQueryAdapter().SelectQuery(W_SQL.ToString)
            '_ViewState_C_VW_GetDataKey3_Key4 = queryDataTable1
            'End If

            'Return _ViewState_C_VW_GetDataKey3_Key4
            Return queryDataTable1
        End Get

    End Property

    Public Sub P_SetDropDownList_DataKey1_參照規範(ByVal fromDropDownList As DropDownList)
        P_SetDropDownList_DataKey1_參照規範(fromDropDownList, True)
    End Sub
    Public Sub P_SetDropDownList_DataKey1_參照規範(ByVal fromDropDownList As DropDownList, ByVal fromNeedList_Key0 As Boolean)
        Dim queryList1 As List(Of String) = (From A In FD_GetDataKey1.AsEnumerable _
                                                                          Group A By G_Key1 = A.Field(Of String)("KEY1") _
                                                                                    Into MA = Group _
                                                                          Order By G_Key1
                                                                          Select G_Key1).ToList

        P_SetDropDownList_DataKey(fromDropDownList, queryList1, fromNeedList_Key0)
    End Sub

    Public Sub P_SetDropDownList_DataKey2_表面類別(ByRef fromDropDownList As DropDownList)
        P_SetDropDownList_DataKey2_表面類別(fromDropDownList, True)
    End Sub
    Public Sub P_SetDropDownList_DataKey2_表面類別(ByRef fromDropDownList As DropDownList, ByVal fromNeedList_Key0 As Boolean)
        Dim queryList1 As List(Of String) = (From A In FD_GetDataKey2.AsEnumerable _
                                                                          Group A By G_Key2 = A.Field(Of String)("Key2") _
                                                                                    Into MA = Group _
                                                                          Order By G_Key2
                                                                          Select G_Key2).ToList

        P_SetDropDownList_DataKey(fromDropDownList, queryList1, fromNeedList_Key0)
    End Sub

    Public Sub P_SetDropDownList_DataKey3_鋼種(ByRef fromDropDownList As DropDownList)
        P_SetDropDownList_DataKey3_鋼種(fromDropDownList, True)
    End Sub
    Public Sub P_SetDropDownList_DataKey3_鋼種(ByRef fromDropDownList As DropDownList, ByVal fromNeedList_Key0 As Boolean)
        Dim queryList1 As List(Of String) = (From A In FD_GetDataKey3_Key4.AsEnumerable _
                                                                          Group A By G_Key3 = A.Field(Of String)("Key3") _
                                                                                    Into MA = Group _
                                                                          Order By G_Key3
                                                                          Select G_Key3).ToList

        P_SetDropDownList_DataKey(fromDropDownList, queryList1, fromNeedList_Key0)
    End Sub

    Public Sub P_SetDropDownList_DataKey4_材質(ByRef fromDropDownList As DropDownList, ByVal from鋼種 As String)
        P_SetDropDownList_DataKey4_材質(fromDropDownList, from鋼種, True)
    End Sub

    Public Sub P_SetDropDownList_DataKey4_材質(ByRef fromDropDownList As DropDownList, ByVal from鋼種 As String, ByVal fromNeedList_Key0 As Boolean)
        Dim queryList1 As List(Of String) = (From A In FD_GetDataKey3_Key4.AsEnumerable _
                                                                           Where A.Field(Of String)("Key3").Equals(from鋼種) _
                                                                          Order By A.Field(Of String)("Key4") _
                                                                          Select A.Field(Of String)("Key4")).ToList

        P_SetDropDownList_DataKey(fromDropDownList, queryList1, fromNeedList_Key0)
    End Sub

    'Private Sub P_SetDropDownList_DataKey(ByRef fromDropDownList As DropDownList, fromList As List(Of String))
    '    P_SetDropDownList_DataKey(fromDropDownList, fromList, True)
    'End Sub
    Private Sub P_SetDropDownList_DataKey(ByRef fromDropDownList As DropDownList, fromList As List(Of String), ByVal fromNeedList_Key0 As Boolean)
        Dim W_List_Key0 As List(Of String) = (From A In FD_GetDataKey0_Default.AsEnumerable _
                                                            Select A.Field(Of String)(C_ClsSystemNote_NOTE_ID)).ToList

        Dim W_List_All As New List(Of String)

        If fromNeedList_Key0 = True Then
            If W_List_Key0.Count > 0 Then W_List_All = W_List_Key0
        End If

        If fromList.Count > 0 Then W_List_All = W_List_All.Concat(fromList).ToList

        fromDropDownList.Items.Clear()
        fromDropDownList.DataSource = W_List_All
        fromDropDownList.DataBind()
    End Sub


#End Region

#Region "Get_DataKey5：檢驗"

    'Const C_VW_GetDataKet5_AssayDat As String = "VW_GetDataKet5_AssayDat"
    'Private _ViewState_C_VW_GetDataKet5_AssayDat As DataTable = Nothing
    Public ReadOnly Property FD_GetDataKet5_AssayDat() As DataTable
        Get
            'If _ViewState_C_VW_GetDataKet5_AssayDat Is Nothing Then
            Dim W_SQL As New StringBuilder

            W_SQL.Append("SELECT  ASSAY_ID, ASSAY_NAME, NORMAL_RANGE_L , NORMAL_RANGE_H , RESULT_FORMAT    " & vbNewLine)
            W_SQL.Append("FROM  LabRecordA2_Assay_DAT  " & vbNewLine)
            W_SQL.Append("WHERE 1=1 " & vbNewLine)
            W_SQL.Append("     AND EFF_FLAG='N'" & vbNewLine)
            W_SQL.Append("ORDER BY substring(ASSAY_ID, 1,2),  DISPLAY_SEQ , LEN(ASSAY_NAME) ,ASSAY_NAME " & vbNewLine)

            Dim queryDataTable1 As DataTable = New CompanyORMDB.SQLServerSQLQueryAdapter( _
                        SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, _
                        SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01").SelectQuery(W_SQL.ToString)
            '    _ViewState_C_VW_GetDataKet5_AssayDat = queryDataTable1
            'End If

            'Return _ViewState_C_VW_GetDataKet5_AssayDat
            Return queryDataTable1
        End Get

    End Property

    Public Function FS_Get_DataKey5_檢驗代號名稱(ByVal fromAssayID As String) As String
        Return FS_Get_DataKey5_檢驗代號名稱(fromAssayID, FD_GetDataKet5_AssayDat)
    End Function
    Public Function FS_Get_DataKey5_檢驗代號名稱(ByVal fromAssayID As String, ByVal fromAssayDat_DataTable As DataTable) As String
        Dim retString As String = (From A In fromAssayDat_DataTable.AsEnumerable _
                                                                        Where A.Field(Of String)("ASSAY_ID").Equals(fromAssayID) _
                                                                          Select String.Concat(A.Field(Of String)("ASSAY_ID"), _
                                                                                      C_ClsSystemNote_Display_Symbol, _
                                                                                      A.Field(Of String)("ASSAY_NAME"))).FirstOrDefault

        Return retString
    End Function
    Public Sub P_SetDropDownList_DataKey5_檢驗代號(ByRef fromDropDownList As DropDownList)
        Dim queryList1 As List(Of String) = (From A In FD_GetDataKet5_AssayDat.AsEnumerable _
                                                                          Select String.Concat(A.Field(Of String)("ASSAY_ID"), _
                                                                                      C_ClsSystemNote_Display_Symbol, _
                                                                                      A.Field(Of String)("ASSAY_NAME"))).ToList

        P_SetDropDownList_DataKey(fromDropDownList, queryList1, False)
    End Sub

    Public Sub P_SetDropDownList_DataKey5_檢驗資訊(ByVal fromAssayID As String, _
                                                                                                     ByRef fromNORMAL_RANGE_L As TextBox, _
                                                                                                     ByRef fromNORMAL_RANGE_H As TextBox, _
                                                                                                     ByRef fromRESULT_FORMAT As TextBox)
        Dim queryDataTable1 As DataTable = (From A In FD_GetDataKet5_AssayDat.AsEnumerable _
                                                                           Where A.Field(Of String)("ASSAY_ID").Equals(fromAssayID)
                                                                           Select A).CopyToDataTable

        fromNORMAL_RANGE_L.Text = ""
        fromNORMAL_RANGE_H.Text = ""
        fromRESULT_FORMAT.Text = ""
        If queryDataTable1.Rows.Count > 0 Then
            fromNORMAL_RANGE_L.Text = queryDataTable1.Rows(0).Field(Of String)("NORMAL_RANGE_L")
            fromNORMAL_RANGE_H.Text = queryDataTable1.Rows(0).Field(Of String)("NORMAL_RANGE_H")

            fromRESULT_FORMAT.Text = queryDataTable1.Rows(0).Field(Of Integer)("RESULT_FORMAT")
        End If
    End Sub

#End Region

#Region "SQL_Limit"
    Private Function FI_SQL_Limit_Length() As Integer
        Dim W_NoteType As String = "片語基本檔_內容文字"
        Dim W_NoteID As String
        Dim W_Note_Context As String

        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        Dim W_SQL_Limit_Length As Integer

        W_NoteID = "內容長度限制"
        W_Note_Context = W_ClsSystemNote.getLev4Content(C_SYSTEM_TYPE, W_NoteType, W_NoteID)
        W_SQL_Limit_Length = 20
        If IsNumeric(W_Note_Context) AndAlso Integer.Parse(W_Note_Context) > 0 Then
            W_SQL_Limit_Length = Integer.Parse(W_Note_Context)
        End If

        Return W_SQL_Limit_Length
    End Function

    Private Function FS_SQL_Limit_MSG() As String
        Dim W_NoteType As String = "片語基本檔_內容文字"
        Dim W_NoteID As String
        Dim W_Note_Context As String

        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        Dim W_SQL_Limit_MSG As String

        W_NoteID = "內容截斷取代字串"
        W_Note_Context = W_ClsSystemNote.getLev4Content(C_SYSTEM_TYPE, W_NoteType, W_NoteID)
        W_SQL_Limit_MSG = "...(略)"
        If W_Note_Context <> "" Then
            W_SQL_Limit_MSG = W_Note_Context
        End If
        Return W_SQL_Limit_MSG
    End Function
#End Region

#Region "Get_DataKey5：片語備註"

    'Const C_VW_GetDataKet5_RemarkDat As String = "VW_GetDataKet5_RemarkDat"
    'Private _ViewState_C_VW_GetDataKet5_RemarkDat As DataTable = Nothing
    Public ReadOnly Property FD_GetDataKet5_RemarkDat() As DataTable
        Get
            'If _ViewState_C_VW_GetDataKet5_RemarkDat Is Nothing Then
            Dim W_SQL_Limit_Length As Integer = FI_SQL_Limit_Length()
            Dim W_SQL_Limit_MSG As String = FS_SQL_Limit_MSG()

            Dim W_SQL As New StringBuilder

            W_SQL.Append("SELECT  Remark_ID,     " & vbNewLine)
            W_SQL.Append("CASE    " & vbNewLine)
            W_SQL.Append(String.Concat("          WHEN DATALENGTH(CONTEXT) >", W_SQL_Limit_Length, " THEN  CONCAT (LEFT(CONTEXT , ", W_SQL_Limit_Length, ") , '", W_SQL_Limit_MSG, "')   ") & vbNewLine)
            W_SQL.Append("          ELSE CONTEXT  " & vbNewLine)
            W_SQL.Append("END CONTEXT   " & vbNewLine)
            W_SQL.Append("FROM  LabRecordA2_Remark_DAT  " & vbNewLine)
            W_SQL.Append("WHERE 1=1 " & vbNewLine)

            W_SQL.Append("     AND EFF_FLAG='N'" & vbNewLine)
            'W_SQL.Append("ORDER BY substring(Remark_ID, 1,2),  DISPLAY_SEQ , LEN(CONTEXT) ,CONTEXT " & vbNewLine)
            W_SQL.Append("ORDER BY Remark_ID " & vbNewLine)

            Dim queryDataTable1 As DataTable = New CompanyORMDB.SQLServerSQLQueryAdapter( _
                        SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, _
                        SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01").SelectQuery(W_SQL.ToString)
            '    _ViewState_C_VW_GetDataKet5_RemarkDat = queryDataTable1
            'End If

            'Return _ViewState_C_VW_GetDataKet5_RemarkDat
            Return queryDataTable1
        End Get

    End Property


    Public Function FS_Get_DataKey5_片語代號名稱(ByVal fromRemarkID As String) As String
        Dim retString As String = (From A In FD_GetDataKet5_RemarkDat.AsEnumerable _
                                                                        Where A.Field(Of String)("Remark_ID").Equals(fromRemarkID) _
                                                                          Select String.Concat(A.Field(Of String)("Remark_ID"), _
                                                                                      C_ClsSystemNote_Display_Symbol, _
                                                                                      A.Field(Of String)("CONTEXT"))).FirstOrDefault

        Return retString
    End Function

    Public Sub P_SetDropDownList_DataKey5_片語代號(ByRef fromDropDownList As DropDownList)
        Dim queryList1 As List(Of String) = (From A In FD_GetDataKet5_RemarkDat.AsEnumerable _
                                                                          Select String.Concat(A.Field(Of String)("Remark_ID"), _
                                                                                      C_ClsSystemNote_Display_Symbol, _
                                                                                      A.Field(Of String)("CONTEXT"))).ToList


        P_SetDropDownList_DataKey(fromDropDownList, queryList1, False)
    End Sub

#End Region


#Region "Get_DataKey_CHECK_ASSAY_ITEM：條件檢查"

    'Const C_VW_Get_DataKey_CHECK_ASSAY_ITEM As String = "VW_Get_DataKey_CHECK_ASSAY_ITEM"
    'Private _ViewState_C_VW_Get_DataKey_CHECK_ASSAY_ITEM = Nothing
    Private ReadOnly Property FD_Get_DataKey_CHECK_ASSAY_ITEM() As DataTable
        Get
            'If _ViewState_C_VW_Get_DataKey_CHECK_ASSAY_ITEM Is Nothing Then
            Dim W_SQL_Limit_Length As Integer = FI_SQL_Limit_Length()
            Dim W_SQL_Limit_MSG As String = FS_SQL_Limit_MSG()

            Dim W_SQL As New StringBuilder

            W_SQL.Append("SELECT  A.* ,     " & vbNewLine)
            W_SQL.Append("CASE    " & vbNewLine)
            W_SQL.Append(String.Concat("          WHEN DATALENGTH(B.CONTEXT) >", W_SQL_Limit_Length, " THEN  CONCAT (LEFT(B.CONTEXT , ", W_SQL_Limit_Length, ") , '", W_SQL_Limit_MSG, "')   ") & vbNewLine)
            W_SQL.Append("          ELSE CONTEXT  " & vbNewLine)
            W_SQL.Append("END CONTEXT   " & vbNewLine)
            W_SQL.Append("FROM  [QCdb01].[dbo].[LabRecordA2_Remark_RES]  A  " & vbNewLine)
            W_SQL.Append("     LEFT JOIN [QCdb01].[dbo].[LabRecordA2_Remark_DAT]  B on  A.REMARK_ID = B.REMARK_ID    " & vbNewLine)
            W_SQL.Append("WHERE 1=1 " & vbNewLine)
            W_SQL.Append("     AND B.CHECK_ASSAY_ITEM ='Y' AND B.EFF_FLAG='N' " & vbNewLine)
            W_SQL.Append("     AND A.EFF_FLAG='N' " & vbNewLine)
            W_SQL.Append("ORDER BY Remark_ID " & vbNewLine)

            Dim queryDataTable1 As DataTable = New CompanyORMDB.SQLServerSQLQueryAdapter( _
                        SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, _
                        SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01").SelectQuery(W_SQL.ToString)
            '    _ViewState_C_VW_Get_DataKey_CHECK_ASSAY_ITEM = queryDataTable1
            'End If

            'Return _ViewState_C_VW_Get_DataKey_CHECK_ASSAY_ITEM
            Return queryDataTable1
        End Get

    End Property

    Public Sub P_SetDropDownList_DataKey5_片語代號_條件檢查(ByRef fromDropDownList As DropDownList)

        Dim queryList1 As List(Of String) = (From A In FD_Get_DataKey_CHECK_ASSAY_ITEM.AsEnumerable _
                                                                  Group A By g1_Remark_ID = A.Field(Of String)("Remark_ID") _
                                                                               , g2_CONTEXT = A.Field(Of String)("CONTEXT") Into M_A = Group _
                                                                  Order By g1_Remark_ID, g2_CONTEXT _
                                                                  Select String.Concat(g1_Remark_ID, _
                                                                              C_ClsSystemNote_Display_Symbol, _
                                                                              g2_CONTEXT)).ToList

        P_SetDropDownList_DataKey(fromDropDownList, queryList1, False)
    End Sub


    Enum 條件檢查_Enum
        DataKey1_參照規範 = 1
        DataKey2_表面類別 = 2
        DataKey3_鋼種 = 3
        DataKey4_材質 = 4
        DataKey5_片語代號 = 5
    End Enum
    Public Function PS_GetName_Enum_條件檢查(ByVal from條件檢查_Enum As 條件檢查_Enum) As String
        Dim W_ColumnName As String = ""
        Select Case from條件檢查_Enum
            Case 條件檢查_Enum.DataKey1_參照規範
                W_ColumnName = "參照規範"
            Case 條件檢查_Enum.DataKey2_表面類別
                W_ColumnName = "表面類別"
            Case 條件檢查_Enum.DataKey3_鋼種
                W_ColumnName = "鋼種"
            Case 條件檢查_Enum.DataKey4_材質
                W_ColumnName = "材質"
            Case 條件檢查_Enum.DataKey5_片語代號
                W_ColumnName = "片語代號"
        End Select

        Return W_ColumnName
    End Function
    Public Sub P_SetDropDownList_DataKey_條件檢查_DO(ByRef fromDropDownList As DropDownList _
                                                    , ByVal fromDisplay_Column As 條件檢查_Enum _
                                                    , ByVal fromKey1_Checked As Boolean _
                                                    , ByVal fromKey1_SelectedValue As String _
                                                    , ByVal fromKey2_Checked As Boolean _
                                                    , ByVal fromKey2_SelectedValue As String _
                                                    , ByVal fromKey3_Checked As Boolean _
                                                    , ByVal fromKey3_SelectedValue As String _
                                                    , ByVal fromKey4_Checked As Boolean _
                                                    , ByVal fromKey4_SelectedValue As String _
                                                    , ByVal fromKey5_Checked As Boolean _
                                                    , ByVal fromKey5_SelectedValue As String)


        Dim W_ClsSystemNote As New ClsSystemNote
        Dim W_REMARKID As String = W_ClsSystemNote.Fs_GetStrBefor(fromKey5_SelectedValue, W_ClsSystemNote.Display_Symbol)

        Dim W_DisplayColumn As String = PS_GetName_Enum_條件檢查(fromDisplay_Column)
        Dim queryList1 As List(Of String) = (From A In FD_Get_DataKey_CHECK_ASSAY_ITEM.AsEnumerable _
                                                                  Where 1 = 1 _
                                                                       AndAlso A.Field(Of String)("REMARK_ID").Equals(W_REMARKID) _
 _
                                                                       AndAlso A.Field(Of String)("參照規範").Equals( _
                                                                                        IIf(fromKey1_Checked = False _
                                                                                               , A.Field(Of String)("參照規範") _
                                                                                               , fromKey1_SelectedValue _
                                                                                        ) _
                                                                             ) _
 _
                                                                        AndAlso A.Field(Of String)("表面類別").Equals( _
                                                                                        IIf(fromKey2_Checked = False _
                                                                                               , A.Field(Of String)("表面類別") _
                                                                                               , fromKey2_SelectedValue _
                                                                                        ) _
                                                                             ) _
 _
                                                                        AndAlso A.Field(Of String)("鋼種").Equals( _
                                                                                        IIf(fromKey3_Checked = False _
                                                                                               , A.Field(Of String)("鋼種") _
                                                                                               , fromKey3_SelectedValue _
                                                                                        ) _
                                                                             ) _
 _
                                                                        AndAlso A.Field(Of String)("材質").Equals( _
                                                                                        IIf(fromKey4_Checked = False _
                                                                                               , A.Field(Of String)("材質") _
                                                                                               , fromKey4_SelectedValue _
                                                                                        ) _
                                                                             ) _
 _
                                                                  Group A By g1_DisplayColumn = A.Field(Of String)(W_DisplayColumn) _
                                                                  Into M_A = Group _
                                                                  Order By g1_DisplayColumn _
                                                                  Select g1_DisplayColumn).ToList

        P_SetDropDownList_DataKey(fromDropDownList, queryList1, False)
    End Sub


#End Region


    '#Region "SystemNote"
    '    Public Enum Enum_DropDownList
    '        檢驗項目基本檔_停用否 = 1
    '        檢驗項目基本檔_代號群組 = 2
    '        檢驗項目基本檔_資料來源類型 = 3
    '        檢驗項目基本檔_是否顯示 = 4
    '    End Enum

    '    Public Sub P_DropDownList_SetItem(ByVal fromNote_Type As LabRecordA2_Setting_Module.Enum_DropDownList, _
    '                                        ByRef fromObj As DropDownList)

    '        Dim W_NoteType As String = [Enum].GetName(GetType(Enum_DropDownList), fromNote_Type)
    '        Dim queryDataTable1 As DataTable
    '        queryDataTable1 = WP_ClsSystemNote.getLev3(C_SYSTEM_TYPE, W_NoteType)
    '        WP_ClsSystemNote.setDropDownList(fromObj, queryDataTable1, WP_ClsSystemNote.Display_Lable)
    '    End Sub
    '#End Region



#Region "P_reFresh母物件"
    Public Enum 主畫面_Enum
        檢驗項目_基本檔 = 0
        檢驗項目_對照檔 = 1
        片語_基本檔 = 2
        片語_對照檔 = 3
        片語_條件檢查 = 4
        設定值預覽 = 5
    End Enum

    Private _Main_Targe_Who As 主畫面_Enum
    Public Property Main_Targe_Who As 主畫面_Enum
        Get
            Return _Main_Targe_Who
        End Get
        Set(value As 主畫面_Enum)
            _Main_Targe_Who = value
        End Set
    End Property

    Public Function Main_Targe_IsMe(ByVal fromChekNow As 主畫面_Enum) As Boolean
        Dim retFalg As Boolean = (fromChekNow = Main_Targe_Who)

        Return retFalg
    End Function

#End Region


#Region "SAVE資訊"
    Public Function FS_SAVE_OPER() As String
        Dim W_UserName As String = System.Web.HttpContext.Current.User.Identity.Name
        Dim LoginWindowAccount As String = ""

        If String.IsNullOrEmpty(W_UserName) Then
            LoginWindowAccount = Nothing
        End If
        Dim DomainUserString() As String = W_UserName.Split("\")
        If DomainUserString.Length < 2 And DomainUserString(0).ToUpper <> "DOMAIN" And DomainUserString(0).ToUpper <> "TESSCO" Then
            LoginWindowAccount = Nothing
        Else
            LoginWindowAccount = DomainUserString(1)
        End If
        Return LoginWindowAccount
    End Function

    Public Function FS_SAVE_DATE() As Date
        Return Now
    End Function


    Public Function FS_DATE_FORMAT(ByVal fromDate As Date, ByVal fromType As Integer) As String
        Dim retString As String = ""
        Select Case fromType
            Case 1
                retString = String.Format("{0:yyyy/MM/dd HH:mm:ss}", fromDate)
            Case 2
                retString = String.Format("{0:yyyy/MM/dd}{1}{0:HH:mm:ss}", fromDate, "<BR/>")
            Case 3
                retString = String.Format("{0:yyyy/MM/dd HH:mm}", fromDate)
            Case 4
                retString = String.Format("{0:yyyy/MM/dd}{1}{0:HH:mm}", fromDate, "<BR/>")
        End Select

        Return retString

    End Function
#End Region

#Region "顯示NORMAL_RANGE"
    Public Function FS_NORMAL_RANGE(ByVal fromNORMAL_RANGE_L As String, ByVal fromNORMAL_RANGE_H As String) As String
        Dim retString As String = ""
        Select Case True
            Case fromNORMAL_RANGE_L = "-999"
                retString = String.Concat("≦", fromNORMAL_RANGE_H)
            Case fromNORMAL_RANGE_H = "999"
                retString = String.Concat("≧", fromNORMAL_RANGE_L)
            Case Else
                retString = String.Concat(fromNORMAL_RANGE_L, "~", fromNORMAL_RANGE_H)
        End Select
        Return retString
    End Function
#End Region

#Region "P_IE_Compatiblel：以最新版IE文件模式解析"
    Public Sub P_IE_Compatible(ByRef fromPage As Page)
        Dim htmlMeta As HtmlMeta = New HtmlMeta()
        htmlMeta.HttpEquiv = "X-UA-Compatible"
        htmlMeta.Content = "IE=EDGE"
        fromPage.Header.Controls.AddAt(0, htmlMeta)
    End Sub
#End Region
End Module
