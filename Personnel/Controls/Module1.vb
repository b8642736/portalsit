Module Module1

#Region "取得AS400請假明細 函式:SearchAS400_PLT000LB_PQDT03PF"

    Public Function getPLT000LB_CodeName(ByVal fromCode As String) As String
        Select Case fromCode.Trim  '代碼多碼
            Case "MA"
                Return "年休假"
        End Select

        Select Case fromCode.Trim.Substring(0, 1)   '代號一碼
            Case "M"
                Return "補　休"
            Case "N"
                Return "公傷假"
            Case "O"
                Return "公　出"
            Case "P"
                Return "公　假"
            Case "Q"
                Return "喪　假"
            Case "R"
                Return "特別休假"
            Case "S"
                Return "住院病假"
            Case "T"
                Return "非住院病假"
            Case "U"
                Return "事　假"
            Case "V"
                Return "娩　假"
            Case "W"
                Return "婚　假"
            Case "Y"
                Return "公　差"
        End Select

        Return fromCode

    End Function
#End Region


    Public Function Fs_GetStrBefor(ByVal L_Txt As String, ByVal l_Term As String) As String
        '取得某字元以前的字串
        '如 Fs_GetStrBefor("01:尿液",":")-->"01"
        Dim W_txt As String
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
        '如 Fs_GetStrBefor("01:尿液",":")-->"01"
        Dim W_txt As String
        Dim II As Integer
        II = InStr(1, L_Txt, l_Term)
        If II <= 0 Then
            Fs_GetStrAfter = L_Txt
        Else
            Fs_GetStrAfter = Mid(L_Txt, II + 1)
            Exit Function
        End If
    End Function

End Module
