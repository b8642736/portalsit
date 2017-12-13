Public Class clsSQLString
    Enum Insert_Kind_num
        isString = 0
        isNumber = 1
        isOther = 2
        isLongDate = 3
        isShortDate = 4
    End Enum
    Enum Modify_Kind_num
        Insert = 0
        Update = 1
    End Enum
    Enum IsPK_num
        No = 0
        Yes = 1
    End Enum
    Enum DataBaseKind_Enum
        Oracle = 0
        MSSQL = 1
        MySQL = 2
        Prosgress = 3
        MDB = 4
        DBF = 5
    End Enum
    Structure Data
        Dim FieldName As String
        Dim Value As Object
        Dim Type As Insert_Kind_num
        Dim Pk As IsPK_num
    End Structure
    Dim m_Index As Integer
    Dim m_TableName As String
    Dim m_Field(255) As Data
    Dim m_Kind As Modify_Kind_num
    Dim m_DataBaseKind As DataBaseKind_Enum = DataBaseKind_Enum.MSSQL

    Public Sub SetTable(ByVal TableName As String, ByVal kind As Modify_Kind_num)
        m_TableName = TableName
        m_Index = 0
        m_Kind = kind
    End Sub
    Public Sub Add(ByVal FieldName As String, ByVal Value As String, Optional ByVal kind As Insert_Kind_num = Insert_Kind_num.isString, Optional ByVal isPK As IsPK_num = IsPK_num.No)
        m_Index = m_Index + 1
        m_Field(m_Index).FieldName = FieldName
        m_Field(m_Index).Value = Value
        m_Field(m_Index).Type = kind
        m_Field(m_Index).Pk = isPK

    End Sub
    Public Sub Clear()
        m_Index = 0
    End Sub
    Public ReadOnly Property SQLString() As String
        Get
            Dim i As Integer
            Dim HaveWhere As Boolean = False

            SQLString = ""
            If m_Index > 0 Then
                If m_Kind = Modify_Kind_num.Insert Then
                    SQLString = "INSERT INTO " & m_TableName & " ("
                    For i = 1 To m_Index - 1
                        SQLString = SQLString & m_Field(i).FieldName & ","
                    Next i
                    SQLString = SQLString & m_Field(m_Index).FieldName & ") VALUES ("
                    For i = 1 To m_Index
                        If m_Field(i).Value = "" Then
                            SQLString = SQLString & "null,"
                        Else
                            Select Case m_Field(i).Type
                                Case Insert_Kind_num.isString
                                    SQLString = SQLString & "'" & Replace(m_Field(i).Value, "'", "''") & "',"
                                Case Insert_Kind_num.isNumber
                                    SQLString = SQLString & ToVal(m_Field(i).Value) & ","
                                Case Insert_Kind_num.isLongDate
                                    Select Case m_DataBaseKind
                                        Case DataBaseKind_Enum.Oracle
                                            SQLString = SQLString & "TO_DATE('" & m_Field(i).Value & "','YYYY/MM/DD HH24:MI:SS'),"
                                        Case Else
                                            SQLString = SQLString & "'" & m_Field(i).Value & "',"
                                    End Select
                                Case Insert_Kind_num.isShortDate
                                    Select Case m_DataBaseKind
                                        Case DataBaseKind_Enum.Oracle
                                            SQLString = SQLString & "TO_DATE('" & m_Field(i).Value & "','YYYY/MM/DD'),"
                                        Case Else
                                            SQLString = SQLString & "'" & m_Field(i).Value & "',"
                                    End Select
                                Case Insert_Kind_num.isOther
                                    SQLString = SQLString & m_Field(i).Value & ","
                            End Select
                        End If
                    Next i
                    SQLString = Left(SQLString, Len(SQLString) - 1) & ")"
                Else
                    SQLString = "UPDATE " & m_TableName & " SET "
                    For i = 1 To m_Index
                        If m_Field(i).Pk = IsPK_num.No Then
                            SQLString = SQLString & m_Field(i).FieldName
                            If m_Field(i).Value = "" Then
                                SQLString = SQLString & "=null,"
                            Else
                                Select Case m_Field(i).Type
                                    Case Insert_Kind_num.isString
                                        SQLString = SQLString & "='" & Replace(m_Field(i).Value, "'", "''") & "',"
                                    Case Insert_Kind_num.isNumber
                                        SQLString = SQLString & "=" & ToVal(m_Field(i).Value) & ","
                                    Case Insert_Kind_num.isLongDate
                                        Select Case m_DataBaseKind
                                            Case DataBaseKind_Enum.Oracle
                                                SQLString = SQLString & "=TO_DATE('" & m_Field(i).Value & "','YYYY/MM/DD HH24:MI:SS'),"
                                            Case Else
                                                SQLString = SQLString & "='" & m_Field(i).Value & "',"
                                        End Select
                                    Case Insert_Kind_num.isShortDate
                                        Select Case m_DataBaseKind
                                            Case DataBaseKind_Enum.Oracle
                                                SQLString = SQLString & "=TO_DATE('" & m_Field(i).Value & "','YYYY/MM/DD'),"
                                            Case Else
                                                SQLString = SQLString & "='" & m_Field(i).Value & "',"
                                        End Select
                                    Case Insert_Kind_num.isOther
                                        SQLString = SQLString & "=" & m_Field(i).Value & ","
                                End Select
                            End If
                        End If
                    Next i
                    SQLString = Left(SQLString, Len(SQLString) - 1)

                    SQLString = SQLString & " where "

                    For i = 1 To m_Index
                        If m_Field(i).Pk = IsPK_num.Yes Then
                            HaveWhere = True
                            SQLString = SQLString & m_Field(i).FieldName
                            If m_Field(i).Value = "" Then
                                SQLString = SQLString & " is null and "
                            Else
                                Select Case m_Field(i).Type
                                    Case Insert_Kind_num.isString
                                        SQLString = SQLString & "='" & Replace(m_Field(i).Value, "'", "''") & "' and "
                                    Case Insert_Kind_num.isNumber
                                        SQLString = SQLString & "=" & ToVal(m_Field(i).Value) & " and "
                                    Case Insert_Kind_num.isLongDate
                                        Select Case m_DataBaseKind
                                            Case DataBaseKind_Enum.Oracle
                                                SQLString = SQLString & "=TO_DATE('" & m_Field(i).Value & "','YYYY/MM/DD HH24:MI:SS'),and "
                                            Case Else
                                                SQLString = SQLString & "='" & m_Field(i).Value & "' and "
                                        End Select
                                    Case Insert_Kind_num.isShortDate
                                        Select Case m_DataBaseKind
                                            Case DataBaseKind_Enum.Oracle
                                                SQLString = SQLString & "=TO_DATE('" & m_Field(i).Value & "','YYYY/MM/DD') and "
                                            Case Else
                                                SQLString = SQLString & "='" & m_Field(i).Value & "' and "
                                        End Select
                                    Case Insert_Kind_num.isOther
                                        SQLString = SQLString & "=" & m_Field(i).Value & " and "
                                End Select
                            End If
                        End If
                    Next i
                    If HaveWhere = False Then
                        SQLString = Left(SQLString, Len(SQLString) - 7)
                    Else
                        SQLString = Left(SQLString, Len(SQLString) - 5)
                    End If
                End If
            End If
        End Get
    End Property

    Public Property TableName() As String
        Get
            TableName = m_TableName
        End Get
        Set(ByVal value As String)
            m_TableName = value
        End Set
    End Property
    Public Property DataBaseKind() As DataBaseKind_Enum
        Get
            DataBaseKind = m_TableName
        End Get
        Set(ByVal value As DataBaseKind_Enum)
            m_DataBaseKind = value
        End Set
    End Property
    Public Property Value(ByVal Index As Object) As String
        Get
            Dim II As Integer
            If IsNumeric(Index) = False Then
                II = GetIndexByName(Index)
            Else
                II = Index
            End If
            If II < 1 Or II > m_Index Then
                Value = ""
                MsgBox("沒有此欄位")
            Else
                Value = m_Field(II).Value
            End If
        End Get
        Set(ByVal value As String)
            Dim II As Integer
            If IsNumeric(Index) = False Then
                II = GetIndexByName(Index)
            Else
                II = Index
            End If
            If II < 1 Or II > m_Index Then
                MsgBox("沒有此欄位")
            Else
                m_Field(II).Value = value
            End If
        End Set
    End Property
    Private Function ToVal(ByVal W_str As Object) As Double
        ToVal = 0
        On Error Resume Next
        ToVal = CDbl(W_str)
    End Function

    'Public Function CheckLens(ByRef Conn As OleDb.OleDbConnection) As String
    '    '此功能專為Oracle設計
    '    Dim II As Integer
    '    Dim W_str As String
    '    Dim W_TB As DataTable
    '    CheckLens = ""
    '    If m_TableName = "" Then Exit Function
    '    '        On Error GoTo Err_Rtn
    '    CheckLens = ""
    '    W_str = "select * from " & m_TableName & " where Rownum <1"
    '    W_TB = F_GetDaReader(W_str).GetSchemaTable
    '    For II = 1 To m_Index
    '        If W_TB.Columns(m_Field(II).FieldName).MaxLength > 0 Then
    '            If W_TB.Columns(m_Field(II).FieldName).MaxLength < Len(m_Field(II).Value) Then
    '                CheckLens = m_Field(II).FieldName
    '                Exit For
    '            End If
    '        End If
    '    Next II
    'End Function
    Public Sub NoKey2Insert(ByRef Conn As OleDb.OleDbConnection)
        If m_Kind = Modify_Kind_num.Update Then
            If F_ExeCommand(SQLString, Conn) = 0 Then
                m_Kind = Modify_Kind_num.Insert
                F_ExeCommand(SQLString, Conn)
            End If
        End If
    End Sub

    Public Sub HaveKey2Update(ByRef Conn As OleDb.OleDbConnection)
        Dim W_str As String
        Dim i As Integer
        If m_Kind = Modify_Kind_num.Insert Then

            W_str = "select count(*) as Num from " & m_TableName & " where "

            For i = 1 To m_Index
                If m_Field(i).Pk = IsPK_num.Yes Then
                    W_str = W_str & m_Field(i).FieldName
                    If m_Field(i).Value = "" Then
                        W_str = W_str & " is null and"
                    Else
                        Select Case m_Field(i).Type
                            Case Insert_Kind_num.isString
                                W_str = W_str & "='" & Replace(m_Field(i).Value, "'", "''") & "' and "
                            Case Insert_Kind_num.isNumber
                                W_str = W_str & "=" & ToVal(m_Field(i).Value) & " and "
                            Case Insert_Kind_num.isLongDate
                                Select Case m_DataBaseKind
                                    Case DataBaseKind_Enum.Oracle
                                        W_str = W_str & "=TO_DATE('" & m_Field(i).Value & "','YYYY/MM/DD HH24:MI:SS') and "
                                    Case DataBaseKind_Enum.DBF, DataBaseKind_Enum.MDB, DataBaseKind_Enum.MSSQL
                                        W_str = W_str & "='" & m_Field(i).Value & "' and "
                                End Select
                            Case Insert_Kind_num.isShortDate
                                Select Case m_DataBaseKind
                                    Case DataBaseKind_Enum.Oracle
                                        W_str = W_str & "=TO_DATE('" & m_Field(i).Value & "','YYYY/MM/DD') and "
                                    Case DataBaseKind_Enum.DBF, DataBaseKind_Enum.MDB, DataBaseKind_Enum.MSSQL
                                        W_str = W_str & "='" & m_Field(i).Value & "' and "
                                End Select
                            Case Insert_Kind_num.isOther
                                W_str = W_str & m_Field(i).Value & " and "
                        End Select
                    End If
                End If
            Next i
            W_str = Left(W_str, Len(W_str) - 5)
            If F_GetRs0Value(W_str, Conn)(0) = 0 Then
                F_ExeCommand(SQLString, Conn)
            Else
                m_Kind = Modify_Kind_num.Update
                F_ExeCommand(SQLString, Conn)
            End If
        End If
    End Sub
    Private Function GetIndexByName(ByVal Key As String) As Integer
        Dim II As Integer
        GetIndexByName = 0
        For II = 1 To m_Index
            If m_Field(II).FieldName = Key Then
                GetIndexByName = II
                Exit Function
            End If
        Next II
    End Function


    Private Function F_ExeCommand(ByVal strSQL As String, ByRef W_DataBase As OleDb.OleDbConnection) As Integer
        Dim W_Rs As New OleDb.OleDbCommand
        W_Rs.Connection = W_DataBase
        W_Rs.CommandText = strSQL
        Try
            F_ExeCommand = W_Rs.ExecuteNonQuery
        Catch
            MsgBox(Err.Description)
            'F_GetDaReader = New OleDb.OleDbDataReader
            F_ExeCommand = 0
        End Try
    End Function
    Private Function F_GetRs0Value(ByVal strSQL As String, ByRef W_DataBase As OleDb.OleDbConnection) As Object
        Dim W_Rs As New OleDb.OleDbCommand
        W_Rs.Connection = W_DataBase
        W_Rs.CommandText = strSQL
        Try
            F_GetRs0Value = W_Rs.ExecuteScalar
        Catch
            MsgBox(Err.Description)
            F_GetRs0Value = ""
        End Try
    End Function
    'Private Sub P_GetDataTable(ByVal str As String, ByRef DataTable1 As DataTable, ByRef W_DataBase As OleDb.OleDbConnection)
    '    Dim W_Rs As OleDb.OleDbCommand
    '    W_Rs = WG_DataBase.CreateCommand()
    '    W_Rs.CommandText = str
    '    DataTable1.Load(W_Rs.ExecuteReader())
    'End Sub
    'Private Function F_GetDataTable(ByVal strSQL As String) As DataTable
    '    F_GetDataTable = New DataTable
    '    Dim W_Rs As New OleDb.OleDbCommand
    '    W_Rs.Connection = WG_DataBase
    '    W_Rs.CommandText = strSQL
    '    Try
    '        F_GetDataTable.Load(W_Rs.ExecuteReader())
    '    Catch
    '        MsgBox(Err.Description)
    '    End Try
    'End Function
    'Private Sub P_GetDaReader(ByVal strSQL As String, ByRef DataReader As OleDb.OleDbDataReader, ByRef W_DataBase As OleDb.OleDbConnection)
    '    Dim W_Rs As OleDb.OleDbCommand
    '    W_Rs = WG_DataBase.CreateCommand()
    '    W_Rs.CommandText = strSQL
    '    DataReader = W_Rs.ExecuteReader()
    'End Sub

    'Private Function F_GetDaReader(ByVal strSQL As String) As OleDb.OleDbDataReader

    '    Dim W_Rs As New OleDb.OleDbCommand
    '    W_Rs.Connection = WG_DataBase
    '    W_Rs.CommandText = strSQL
    '    Try
    '        F_GetDaReader = W_Rs.ExecuteReader()
    '    Catch
    '        MsgBox(Err.Description)
    '        F_GetDaReader = Nothing
    '    End Try

    'End Function
End Class
