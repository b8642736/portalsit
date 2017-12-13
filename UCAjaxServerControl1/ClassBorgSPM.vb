
Public Class ClassBorgSPM

    Private Shared _DesRgbKey As String = "20031231"
    Private Shared Function _DesRgbIv() As String
        '中文系統
        _DesRgbIv = "知足常樂"

        If System.Text.Encoding.Default.GetBytes(_DesRgbIv).Length <> 8 Then
            '英文系統
            _DesRgbIv = "13213002"
        End If
    End Function


    Public Shared Function Encrypt(StrInput As String) As String

        If StrInput = "" Then StrInput = "empty"

        Dim retStr As String = ""
        Try
            Dim bytes() As Byte = System.Text.Encoding.Default.GetBytes(StrInput)
            Dim stream2 As System.IO.MemoryStream = New System.IO.MemoryStream()
            Dim provider As System.Security.Cryptography.DESCryptoServiceProvider = New System.Security.Cryptography.DESCryptoServiceProvider
            Dim stream As System.Security.Cryptography.CryptoStream = New System.Security.Cryptography.CryptoStream(stream2, provider.CreateEncryptor(System.Text.Encoding.Default.GetBytes(_DesRgbKey), System.Text.Encoding.Default.GetBytes(_DesRgbIv)), System.Security.Cryptography.CryptoStreamMode.Write)
            stream.Write(bytes, 0, bytes.Length)
            stream.FlushFinalBlock()

            retStr = Convert.ToBase64String(stream2.ToArray())
        Catch ex As Exception
        End Try

        Return retStr
    End Function

    Public Shared Function Decrypt(StrInput As String) As String
        Dim retStr As String = StrInput

        Dim buffer() As Byte = Convert.FromBase64String(StrInput)
        Dim stream2 As System.IO.MemoryStream = New System.IO.MemoryStream()
        Dim provider As System.Security.Cryptography.DESCryptoServiceProvider = New System.Security.Cryptography.DESCryptoServiceProvider()

        Try
            Dim stream As System.Security.Cryptography.CryptoStream = New System.Security.Cryptography.CryptoStream(stream2, provider.CreateDecryptor(System.Text.Encoding.Default.GetBytes(_DesRgbKey), System.Text.Encoding.Default.GetBytes(_DesRgbIv)), System.Security.Cryptography.CryptoStreamMode.Write)
            stream.Write(buffer, 0, buffer.Length)
            stream.FlushFinalBlock()

            retStr = System.Text.Encoding.Default.GetString(stream2.ToArray())
            If retStr = "empty" Then
                Return ""
            End If
            Return retStr
        Catch exception1 As Exception
            Return retStr
        End Try
    End Function




End Class

