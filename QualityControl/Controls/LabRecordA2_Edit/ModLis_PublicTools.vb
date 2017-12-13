Public Class ModLis_PublicTools

    Private Function DT_QuerySQL(ByVal fromSQL As String) As DataTable
        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
        If String.IsNullOrEmpty(fromSQL) Or fromSQL = "" Then
            Return New DataTable
        End If
        Dim dtResult As DataTable = sqlAdapter.SelectQuery(fromSQL)
        Return dtResult
    End Function


    Private Function Fs_Move_AssayVal(ByVal L_爐號 As String _
                                                                      , ByVal L_站別 As String _
                                                                      , ByVal L_序號 As String _
                                                                      , ByVal L_日期 As String _
                                                                      , ByVal L_AssayID As String) As String
        Dim W_Rec_LabrecordD As New DataTable
        Dim W_SQL As String

        W_SQL = "SELECT [" & L_AssayID & "] from 分析資料 "
        W_SQL = W_SQL & "WHERE 1=1 "
        W_SQL = W_SQL & "  AND 爐號 = '" & L_爐號 & "' "
        W_SQL = W_SQL & "  AND 站別 = '" & L_站別 & "' "
        W_SQL = W_SQL & "  AND 序號 = " & L_序號 & " "
        W_SQL = W_SQL & "  AND 日期 = " & L_日期 & " "

        W_Rec_LabrecordD = DT_QuerySQL(W_SQL)
        If Not W_Rec_LabrecordD.Rows.Count = 0 Then
            Return W_Rec_LabrecordD.Rows(0).Item(0)
        End If
        W_Rec_LabrecordD = Nothing
        Return ""
    End Function


    Private Function Fs_Comput_Function(ByVal L_爐號 As String _
                                                                          , ByVal L_站別 As String _
                                                                          , ByVal L_序號 As String _
                                                                          , ByVal L_日期 As String _
                                                                          , ByVal L_Function As String) As String
        Dim II As Integer
        Dim W_Posit_S As Integer, W_Posit_E As Integer
        Dim W_AssayName As String
        Dim W_Function As String
        Dim W_TMP As String

        II = 1
        W_Function = ""
        Do Until II > Len(L_Function)
            W_Posit_S = InStr(II, L_Function, "[")
            If W_Posit_S = 0 Then
                If InStr(1, W_Function, "(") Then W_Function = W_Function & ")"
                W_Function = W_Function & Mid(L_Function, II)
                ' Fs_Comput_Function=L_Function
                Exit Do
            Else
                If W_Posit_S > 1 Then
                    W_Function = W_Function & Mid(L_Function, II, W_Posit_S - II)
                End If
                W_Posit_E = InStr(II + 1, L_Function, "]")
                If W_Posit_E = 0 Then
                    Exit Do
                Else
                    W_AssayName = Mid(L_Function, W_Posit_S + 1, W_Posit_E - W_Posit_S - 1)
                    W_TMP = Fs_Move_AssayVal(L_爐號, L_站別, L_序號, L_日期, W_AssayName)
                    If IsNumeric(W_TMP) = False Then
                        Return ""

                    End If
                    W_Function = W_Function & W_TMP
                    II = W_Posit_E + 1
                End If
            End If
        Loop
        If W_Function <> "" Then
            Return Fn_Recursive_Comp(W_Function)
        End If
        Return ""
    End Function

    '--- 依公式計算結果 --------------
    Public Function Fn_Recursive_Comp(ByVal L_STR As String) As Double
        Dim W_Posit1 As Integer
        Dim W_Left As String, W_Right As String
        Dim W_Posit_A As Integer, W_Posit_B As Integer
        Dim W_Str As String, W_Result_str As String


        '---- 處理( )-------------------------------
        W_Posit_A = InStr(1, L_STR, "(", vbTextCompare)
        Do Until W_Posit_A = 0

            W_Posit_B = InStr(W_Posit_A, L_STR, ")", vbTextCompare)
            If W_Posit_B > 0 Then
                W_Str = Mid(L_STR, W_Posit_A + 1, W_Posit_B - W_Posit_A - 1)
                W_Result_str = Fn_Recursive_Comp(W_Str)
            Else
                MsgBox("公式錯誤!!.....")
            End If
            L_STR = Left(L_STR, W_Posit_A - 1) & W_Result_str & Mid(L_STR, W_Posit_B + 1)

            W_Posit_A = InStr(1, L_STR, "(", vbTextCompare)
        Loop
        '---------------------------------------

        W_Posit1 = InStr(1, L_STR, "+", vbTextCompare)
        If W_Posit1 > 0 Then
            W_Left = Left(L_STR, W_Posit1 - 1)
            W_Right = Mid(L_STR, W_Posit1 + 1)
            Return Fn_Recursive_Comp(W_Left) + Fn_Recursive_Comp(W_Right)
        Else
            W_Posit1 = InStr(2, L_STR, "-", vbTextCompare)
            If W_Posit1 > 0 Then
                W_Left = Left(L_STR, W_Posit1 - 1)
                W_Right = Mid(L_STR, W_Posit1)
                Return Fn_Recursive_Comp(W_Left) + Fn_Recursive_Comp(W_Right)
            Else
                W_Posit1 = InStr(1, L_STR, "*", vbTextCompare)
                If W_Posit1 > 0 Then
                    W_Left = Left(L_STR, W_Posit1 - 1)
                    W_Right = Mid(L_STR, W_Posit1 + 1)
                    Return Fn_Recursive_Comp(W_Left) * Fn_Recursive_Comp(W_Right)
                Else
                    W_Posit1 = InStr(1, L_STR, "/", vbTextCompare)
                    If W_Posit1 > 0 Then
                        W_Left = Left(L_STR, W_Posit1 - 1)
                        W_Right = Mid(L_STR, W_Posit1 + 1)
                        Return Fn_Recursive_Comp(W_Left) / Fn_Recursive_Comp(W_Right)
                    Else
                        Return Val(L_STR)
                    End If
                End If
            End If
        End If
    End Function


    Public Sub GO_LIS()
        Dim W_爐號 As String : W_爐號 = "A6224"
        Dim W_站別 As String : W_站別 = "L1"
        Dim W_序號 As String : W_序號 = "1"
        Dim W_日期 As String : W_日期 = "1051021"
        Dim W_Function As String : W_Function = "( [N1]*10+ [C]) * 5"

        Dim W_ResultValue As String
        W_ResultValue = Fs_Comput_Function(W_爐號, W_站別, W_序號, W_日期, W_Function)
        Debug.Write(W_ResultValue)
    End Sub


End Class
