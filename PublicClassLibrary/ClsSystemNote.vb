Public Class ClsSystemNote

    Private _SQLAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter( _
                                       CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, _
                                       CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, _
                                        "QCDB01")

#Region "片語共用片段"

    Public Enum Enum_SystemNote
        Lev1 = 1
        Lev2 = 2
        Lev3 = 3
        Lev4Content = 4
    End Enum

    Public Enum Enum_Param
        System_Type = 0
        Note_Type = 1
        Del_Flag = 2
        Note_ID = 3
    End Enum

    Public Function getName_Enum_Param(ByVal fromParam As Enum_Param) As String
        Select Case fromParam
            Case Enum_Param.System_Type
                Return "System_Type"
            Case Enum_Param.Note_Type
                Return "Note_Type"
            Case Enum_Param.Del_Flag
                Return "Del_Flag"
            Case Enum_Param.Note_ID
                Return "Note_ID"
            Case Else
                Return "UnKnow：" & fromParam
        End Select
    End Function

    Private Function getQuerySQL(ByVal fromEnum_SystemNote As Enum_SystemNote, ByVal fromParam() As String) As String
        Dim retSQL As New System.Text.StringBuilder

        Select Case fromEnum_SystemNote
            Case Enum_SystemNote.Lev1
                retSQL.Append("SELECT system_type " & vbNewLine)
                retSQL.Append("FROM systemnote " & vbNewLine)
                retSQL.Append("GROUP BY system_type " & vbNewLine)

            Case Enum_SystemNote.Lev2
                retSQL.Append("SELECT note_type " & vbNewLine)
                retSQL.Append("FROM systemnote " & vbNewLine)
                retSQL.Append("WHERE system_type='" & fromParam(Enum_Param.System_Type) & "' " & vbNewLine)
                retSQL.Append("    AND del_flag='" & fromParam(Enum_Param.Del_Flag) & "' " & vbNewLine)
                retSQL.Append("GROUP BY note_type " & vbNewLine)

            Case Enum_SystemNote.Lev3
                retSQL.Append("SELECT * " & vbNewLine)
                retSQL.Append("FROM systemnote " & vbNewLine)
                retSQL.Append("WHERE system_type='" & fromParam(Enum_Param.System_Type) & "' " & vbNewLine)
                retSQL.Append("    AND note_type='" & fromParam(Enum_Param.Note_Type) & "' " & vbNewLine)
                retSQL.Append("    AND del_flag='" & fromParam(Enum_Param.Del_Flag) & "' " & vbNewLine)
                retSQL.Append("ORDER BY display_Seq,note_id " & vbNewLine)

            Case Enum_SystemNote.Lev4Content
                retSQL.Append("SELECT * " & vbNewLine)
                retSQL.Append("FROM systemnote " & vbNewLine)
                retSQL.Append("WHERE system_type='" & fromParam(Enum_Param.System_Type) & "' " & vbNewLine)
                retSQL.Append("    AND note_type='" & fromParam(Enum_Param.Note_Type) & "' " & vbNewLine)

                If fromParam(Enum_Param.Del_Flag) <> "" Then
                    retSQL.Append("    AND del_flag='" & fromParam(Enum_Param.Del_Flag) & "' " & vbNewLine)
                End If
                retSQL.Append("    AND note_id='" & fromParam(Enum_Param.Note_ID) & "' " & vbNewLine)
        End Select

        Return retSQL.ToString
    End Function
#End Region

#Region "SourceDataTable：節省Query次數"
    Private _SourceDataTable As DataTable
    Public Property SourceDataTable As DataTable
        Get
            Return _SourceDataTable
        End Get
        Set(value As DataTable)
            _SourceDataTable = value
        End Set
    End Property
#End Region

#Region "取得片語表"

    Public Function getLev1() As DataTable
        Dim queryDataTable As DataTable = _SQLAdapter.SelectQuery(getQuerySQL(Enum_SystemNote.Lev1, Nothing))
        queryDataTable.Columns.Add(Display_Lable, Type.GetType("System.String"), "system_type")

        Return queryDataTable
    End Function

    Public Function getLev2(ByVal fromSystem_Type As String) As DataTable
        Return getLev2(fromSystem_Type, "N")
    End Function

    Public Function getLev2(ByVal fromSystem_Type As String, ByVal fromDel_Flag As String) As DataTable
        Dim queryDataTable As DataTable = _SQLAdapter.SelectQuery(getQuerySQL(Enum_SystemNote.Lev2, {fromSystem_Type, "", fromDel_Flag}))

        queryDataTable.Columns.Add(Display_Lable, Type.GetType("System.String"), "note_type")
        Return queryDataTable
    End Function

    Public Function getLev3(ByVal fromSystem_Type As String, ByVal fromNote_Type As String) As DataTable
        Return getLev3(fromSystem_Type, fromNote_Type, "N")
    End Function

    Public Display_Lable As String = "Display_Lable"
    Public Display_Symbol As String = "："
    Public NOTE_TYPE As String = "NOTE_TYPE"
    Public NOTE_ID As String = "NOTE_ID"
    Public CONTENT As String = "CONTENT"


    Public Function getLev3(ByVal fromSystem_Type As String, ByVal fromNote_Type As String, ByVal fromDel_Flag As String) As DataTable
        Dim queryDataTable As DataTable = _SQLAdapter.SelectQuery(getQuerySQL(Enum_SystemNote.Lev3, {fromSystem_Type, fromNote_Type, fromDel_Flag}))

        queryDataTable.Columns.Add(Display_Lable, Type.GetType("System.String"), "note_id+'" & Display_Symbol & "'+ content")
        Return queryDataTable
    End Function

    Public Function getLev4Content(ByVal fromSystem_Type As String, ByVal fromNote_Type As String, ByVal fromNote_Id As String) As String
        Return getLev4Content(fromSystem_Type, fromNote_Type, fromNote_Id, "")  '因為有PK保護唯一，所以代號轉名稱時拉全部資料
    End Function

    Public Function getLev4Content(ByVal fromSystem_Type As String, ByVal fromNote_Type As String, ByVal fromNote_Id As String, ByVal fromDel_Flag As String) As String
        Dim queryDataTable As DataTable = _SQLAdapter.SelectQuery(getQuerySQL(Enum_SystemNote.Lev4Content, {fromSystem_Type, fromNote_Type, fromDel_Flag, fromNote_Id}))

        Dim retContent As String = fromNote_Id
        If queryDataTable.Rows.Count > 0 Then
            retContent = queryDataTable.Rows(0).Item("content")
        End If
        Return retContent
    End Function

#End Region


    Public Sub setDropDownList(ByRef fromDropDownList As Web.UI.WebControls.DropDownList, _
                                                          ByVal fromDataTable As DataTable)
        setDropDownList(fromDropDownList, fromDataTable, Display_Lable)
    End Sub

    Public Sub setDropDownList(ByRef fromDropDownList As Web.UI.WebControls.DropDownList, _
                                                          ByVal fromDataTable As DataTable, _
                                                          ByVal fromShowTextField As String)

        fromDropDownList.DataSource = fromDataTable
        fromDropDownList.DataTextField = fromShowTextField
        fromDropDownList.DataBind()
    End Sub


#Region "取得字串在某符號的前後文字"
    Public Function Fs_GetStrBefor(ByVal L_Txt As String, ByVal l_Term As String) As String
        '取得某字元以前的字串
        '如 Fs_GetStrBefor("01:尿液",":")-->"01"

        Dim II As Integer
        II = InStr(1, L_Txt, l_Term)
        If II <= 0 Then
            Fs_GetStrBefor = L_Txt
        Else
            Fs_GetStrBefor = Left(L_Txt, II - 1)
            Exit Function
        End If
    End Function
    Public Function Fs_GetStrAfter(ByVal L_Txt As String, ByVal l_Term As String) As String
        '取得某字元以前的字串
        '如 Fs_GetStrAfter("01:尿液",":")-->"尿液"
        Dim II As Integer
        II = InStr(1, L_Txt, l_Term)
        If II <= 0 Then
            Fs_GetStrAfter = L_Txt
        Else
            Fs_GetStrAfter = Mid(L_Txt, II + 1)
            Exit Function
        End If
    End Function
#End Region


End Class