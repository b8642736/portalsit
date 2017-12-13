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

        Lev1Table = (100 + Lev1)
        Lev2Table = (100 + Lev2)
        Lev3Table = (100 + Lev3)
        Lev4Table = (100 + Lev4Content)
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
        End Select
    End Function

    Private Function getQuerySQL(ByVal fromEnum_SystemNote As Enum_SystemNote, ByVal fromParam() As String) As String
        Dim retSQL As New System.Text.StringBuilder

        Select Case fromEnum_SystemNote
            Case Enum_SystemNote.Lev1, Enum_SystemNote.Lev1Table
                If fromEnum_SystemNote = Enum_SystemNote.Lev1 Then
                    retSQL.Append("SELECT system_type " & vbNewLine)
                Else
                    retSQL.Append("SELECT * " & vbNewLine)
                End If

                retSQL.Append("FROM systemnote " & vbNewLine)
                If fromEnum_SystemNote = Enum_SystemNote.Lev1 Then
                    retSQL.Append("GROUP BY system_type " & vbNewLine)
                End If

            Case Enum_SystemNote.Lev2, Enum_SystemNote.Lev2Table
                If fromEnum_SystemNote = Enum_SystemNote.Lev2 Then
                    retSQL.Append("SELECT note_type " & vbNewLine)
                Else
                    retSQL.Append("SELECT * " & vbNewLine)
                End If

                retSQL.Append("FROM systemnote " & vbNewLine)
                retSQL.Append("WHERE system_type='" & fromParam(Enum_Param.System_Type) & "' " & vbNewLine)
                retSQL.Append("    AND del_flag='" & fromParam(Enum_Param.Del_Flag) & "' " & vbNewLine)

                If fromEnum_SystemNote = Enum_SystemNote.Lev2 Then
                    retSQL.Append("GROUP BY note_type " & vbNewLine)
                End If

            Case Enum_SystemNote.Lev3, Enum_SystemNote.Lev3Table
                retSQL.Append("SELECT * " & vbNewLine)
                retSQL.Append("FROM systemnote " & vbNewLine)
                retSQL.Append("WHERE system_type='" & fromParam(Enum_Param.System_Type) & "' " & vbNewLine)
                retSQL.Append("    AND note_type='" & fromParam(Enum_Param.Note_Type) & "' " & vbNewLine)
                retSQL.Append("    AND del_flag='" & fromParam(Enum_Param.Del_Flag) & "' " & vbNewLine)
                retSQL.Append("ORDER BY display_Seq, LEN(note_id) , note_id  " & vbNewLine)

            Case Enum_SystemNote.Lev4Content, Enum_SystemNote.Lev4Table
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
    Public Display_Lable As String = "Display_Lable"
    Public Display_Symbol As String = "："
    Public NOTE_TYPE As String = "NOTE_TYPE"
    Public NOTE_ID As String = "NOTE_ID"
    Public CONTENT As String = "CONTENT"

    Public Function getLev1() As DataTable
        Return _getLev1(Enum_SystemNote.Lev1)
    End Function

    Public Function getLev1Table() As DataTable
        Return _getLev1(Enum_SystemNote.Lev1Table)
    End Function

    Private Function _getLev1(ByVal fromEnum_SystemNote As Enum_SystemNote) As DataTable
        Dim queryDataTable As DataTable = _SQLAdapter.SelectQuery(getQuerySQL(fromEnum_SystemNote, Nothing))
        queryDataTable.Columns.Add(Display_Lable, Type.GetType("System.String"), "system_type")

        Return queryDataTable
    End Function



    Public Function getLev2(ByVal fromSystem_Type As String) As DataTable
        Return getLev2(fromSystem_Type, "N")
    End Function

    Public Function getLev2(ByVal fromSystem_Type As String, ByVal fromDel_Flag As String) As DataTable
        Return _getLev2(Enum_SystemNote.Lev2, fromSystem_Type, fromDel_Flag)
    End Function

    Public Function getLev2Table(ByVal fromSystem_Type As String) As DataTable
        Return getLev2Table(fromSystem_Type, "N")
    End Function

    Public Function getLev2Table(ByVal fromSystem_Type As String, ByVal fromDel_Flag As String) As DataTable
        Return _getLev2(Enum_SystemNote.Lev2Table, fromSystem_Type, fromDel_Flag)
    End Function

    Private Function _getLev2(ByVal fromEnum_SystemNote As Enum_SystemNote, ByVal fromSystem_Type As String, ByVal fromDel_Flag As String) As DataTable
        Dim queryDataTable As DataTable = _SQLAdapter.SelectQuery(getQuerySQL(fromEnum_SystemNote, {fromSystem_Type, "", fromDel_Flag}))

        queryDataTable.Columns.Add(Display_Lable, Type.GetType("System.String"), "note_type")
        Return queryDataTable
    End Function



    Public Function getLev3(ByVal fromSystem_Type As String, ByVal fromNote_Type As String) As DataTable
        Return getLev3(fromSystem_Type, fromNote_Type, "N")
    End Function

    Public Function getLev3(ByVal fromSystem_Type As String, ByVal fromNote_Type As String, ByVal fromDel_Flag As String) As DataTable
        Return _getLev3(Enum_SystemNote.Lev3, fromSystem_Type, fromNote_Type, fromDel_Flag)
    End Function

    Public Function getLev3Table(ByVal fromSystem_Type As String, ByVal fromNote_Type As String) As DataTable
        Return getLev3Table(fromSystem_Type, fromNote_Type, "N")
    End Function

    Public Function getLev3Table(ByVal fromSystem_Type As String, ByVal fromNote_Type As String, ByVal fromDel_Flag As String) As DataTable
        Return _getLev3(Enum_SystemNote.Lev3Table, fromSystem_Type, fromNote_Type, fromDel_Flag)
    End Function

    Private Function _getLev3(ByVal fromEnum_SystemNote As Enum_SystemNote, ByVal fromSystem_Type As String, ByVal fromNote_Type As String, ByVal fromDel_Flag As String) As DataTable
        Dim queryDataTable As DataTable = _SQLAdapter.SelectQuery(getQuerySQL(fromEnum_SystemNote, {fromSystem_Type, fromNote_Type, fromDel_Flag}))

        queryDataTable.Columns.Add(Display_Lable, Type.GetType("System.String"), "note_id+'" & Display_Symbol & "'+ content")
        Return queryDataTable
    End Function

    'Public Function getLev3Table(ByVal fromSystem_Type As String, ByVal fromNote_Type As String, ByVal fromDel_Flag As String) As DataTable
    '    Return _getLev3(Enum_SystemNote.Lev3Table, fromSystem_Type, fromNote_Type, fromDel_Flag)
    'End Function

    'Private Function _getLev3(ByVal fromEnum_SystemNote As Enum_SystemNote, ByVal fromSystem_Type As String, ByVal fromNote_Type As String, ByVal fromDel_Flag As String) As DataTable
    '    Dim queryDataTable As DataTable = _SQLAdapter.SelectQuery(getQuerySQL(fromEnum_SystemNote, {fromSystem_Type, fromNote_Type, fromDel_Flag}))

    '    queryDataTable.Columns.Add(Display_Lable, Type.GetType("System.String"), "note_id+'" & Display_Symbol & "'+ content")
    '    Return queryDataTable
    'End Function



    Public Function getLev4Table(ByVal fromSystem_Type As String, ByVal fromNote_Type As String, ByVal fromNote_Id As String) As DataTable
        Return getLev4Table(fromSystem_Type, fromNote_Type, fromNote_Id, "")  '因為有PK保護唯一，所以代號轉名稱時拉全部資料
    End Function

    Public Function getLev4Table(ByVal fromSystem_Type As String, ByVal fromNote_Type As String, ByVal fromNote_Id As String, ByVal fromDel_Flag As String) As DataTable
        Return getLev99Table(Enum_SystemNote.Lev4Table, fromSystem_Type, fromNote_Type, fromNote_Id, fromDel_Flag)
    End Function


    Public Function getLev99Table(ByVal fromEnum_SystemNote As Enum_SystemNote, ByVal fromSystem_Type As String, ByVal fromNote_Type As String, ByVal fromNote_Id As String, ByVal fromDel_Flag As String) As DataTable

        Dim queryDataTable As DataTable
        If Not SourceDataTable Is Nothing Then
            queryDataTable = (From A In SourceDataTable.AsEnumerable
                                                Where 1 = 1 _
                                                     And A.Field(Of String)(getName_Enum_Param(Enum_Param.System_Type)).Equals(fromSystem_Type) _
                                                     And A.Field(Of String)(getName_Enum_Param(Enum_Param.Note_Type)).Equals(fromNote_Type) _
                                                     And A.Field(Of String)(getName_Enum_Param(Enum_Param.Note_ID)).Equals(fromNote_Id) _
                                                Select A).CopyToDataTable

            If Not fromDel_Flag.Equals("") Then
                queryDataTable = (From B In queryDataTable
                                                Where 1 = 1 _
                                                     And B.Field(Of String)(getName_Enum_Param(Enum_Param.Del_Flag)).Equals(fromDel_Flag) _
                                                Select B).CopyToDataTable
            End If


        Else
            queryDataTable = _SQLAdapter.SelectQuery(getQuerySQL(Enum_SystemNote.Lev4Table, {fromSystem_Type, fromNote_Type, fromDel_Flag, fromNote_Id}))
        End If

        Return queryDataTable
    End Function

    Public Function getLev4Content(ByVal fromSystem_Type As String, ByVal fromNote_Type As String, ByVal fromNote_Id As String) As String
        Return getLev4Content(fromSystem_Type, fromNote_Type, fromNote_Id, "")  '因為有PK保護唯一，所以代號轉名稱時拉全部資料
    End Function

    Public Function getLev4Content(ByVal fromSystem_Type As String, ByVal fromNote_Type As String, ByVal fromNote_Id As String, ByVal fromDel_Flag As String) As String
        'Dim queryDataTable As DataTable = _SQLAdapter.SelectQuery(getQuerySQL(Enum_SystemNote.Lev4Content, {fromSystem_Type, fromNote_Type, fromDel_Flag, fromNote_Id}))
        Dim queryDataTable As DataTable = getLev4Table(fromSystem_Type, fromNote_Type, fromNote_Id)

        Dim retContent As String = fromNote_Id
        If queryDataTable.Rows.Count > 0 Then
            retContent = queryDataTable.Rows(0).Item(CONTENT)
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