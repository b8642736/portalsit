Public Class PublicUtils


    Public Shared Function URLEncode(ByVal fromText As String) As String
        Dim II As Integer
        Dim nowChar As Char
        Dim nowAsc As Integer
        Dim encText As String

        encText = ""
        For II = 1 To Len(fromText)
            nowChar = Mid(fromText, II, 1)
            nowAsc = Asc(nowChar)

            Select Case nowAsc
                Case 48 To 57, 65 To 90, 97 To 122, 45 To 46, 95
                    '48 To 57是0~9；65 To 90是A~Z；97 To 122是a~z；45是-；46是.；95是 _
                    encText = encText & Chr(nowAsc)

                Case 32
                    '32是Space
                    encText = encText & "+"

                Case Else
                    If nowAsc >= 0 And nowAsc < 16 Then
                        encText = encText & "%0" & Hex(nowAsc).ToLower
                    Else
                        For Each eachItem As Byte In System.Text.Encoding.UTF8.GetBytes(nowChar)
                            encText = encText & "%" & Hex(eachItem).ToLower
                        Next
                    End If

            End Select
        Next

        Return encText
    End Function

    'Public Shared Function URLDecode(ByVal fromCode As String) As String
    '    Dim strIndex As Integer = 0
    '    Dim strByte(0) As Byte
    '    Dim retString As String = ""

    '    fromCode = fromCode.Replace("+", Chr(32))
    '    For II As Long = 0 To fromCode.Length - 1
    '        ReDim Preserve strByte(strIndex)
    '        strIndex += 1

    '        If fromCode.Substring(II, 1) = "%" Then
    '            strByte(UBound(strByte)) = CByte("&H" & fromCode.Substring(II + 1, 2))
    '            II += 2
    '        Else
    '            strByte(UBound(strByte)) = Asc(fromCode.Substring(II, 1))
    '        End If
    '    Next

    '    retString = System.Text.Encoding.UTF8.GetString(strByte)
    '    Return retString
    'End Function

    Public Shared Function URLDecode(ByVal fromCode As String) As String
        Dim strIndex As Integer = 0
        Dim strByte(fromCode.Length - 1) As Byte
        Dim strByteIndex As Integer = -1
        Dim retString As String = ""

        fromCode = fromCode.Replace("+", Chr(32))
        For II As Long = 0 To fromCode.Length - 1
            strIndex += 1
            strByteIndex += 1

            If fromCode.Substring(II, 1) = "%" Then
                strByte(strByteIndex) = CByte("&H" & fromCode.Substring(II + 1, 2))
                II += 2
            Else
                strByte(strByteIndex) = Asc(fromCode.Substring(II, 1))
            End If
        Next

        ReDim Preserve strByte(strByteIndex)

        retString = System.Text.Encoding.UTF8.GetString(strByte)
        Return retString
    End Function

    Public Shared Function StringFormatNumberOf3Symbol(ByVal fromString As String) As String
        If String.IsNullOrEmpty(fromString) Then Return ""

        Dim ReturnString As String
        Dim Num1 As String
        Dim Num2 As String
        Dim NumPoint As Integer

        NumPoint = fromString.IndexOf(".")
        If NumPoint = -1 Then
            Num1 = fromString
            Num2 = ""
        Else
            Num1 = IIf(NumPoint = 0, "0", fromString.Substring(0, NumPoint))
            Num2 = fromString.Substring(NumPoint + 1)
        End If

        ReturnString = IIf(NumPoint = 0, "", String.Format("{0:N0}", Integer.Parse(Num1)))
        ReturnString &= IIf(Num2 = "", "", "." & Num2)
        Return ReturnString
    End Function
End Class
