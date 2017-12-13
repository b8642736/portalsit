Public Class WebServiceUtils

    Private _WebServerUrl As String
    Private _WebServerMethod As String
    Private _WebServerParamData As String

    Private _EncodeFlag_URL As Boolean
    Private _EncodeFlag_XML As Boolean
    Private _WebServerVerKind As Enum_VerKind
    Public Enum Enum_VerKind
        A_MS_AspNet = 1
        B_CCMail_PHP = 2
    End Enum
    Public Shared _WebServerUrl_A As String = "http://10.1.4.12/MvcWebService/WebService.asmx"
    Public Shared _WebServerUrl_B As String = "http://172.16.1.3/EIP/peonyapi2.php"

    Public Shared _WebServerMethod_A As String = "XMLString"
    Public Shared _WebServerMethod_B As String = ""

    
#Region "SampleXML"
    Public Shared _ParamData_SampleA As String = _
                                "<?xml version=""1.0"" encoding=""UTF-8""?> " & vbNewLine & _
                                "<PARAM_OBJECT>  " & vbNewLine & _
                                "  <PARAMS>  " & vbNewLine & _
                                "    <PARAM>  " & vbNewLine & _
                                "      <CLASS_NAME>TESTKUKU.AST103PFC</CLASS_NAME>  " & vbNewLine & _
                                "      <METHOD_NAME>findAS301</METHOD_NAME>  " & vbNewLine & _
                                "      <AS301>60101-003</AS301>  " & vbNewLine & _
                                "    </PARAM>  " & vbNewLine & _
                                "  </PARAMS>  " & vbNewLine & _
                                "</PARAM_OBJECT>  "

    Public Shared _ParamData_SampleB As String = _
                                "<?xml version=""1.0"" encoding=""UTF-8""?> " & vbNewLine & _
                                "<email-cmcc> " & vbNewLine & _
                                "<apikey>41518664-180f-11e6-8739-005056010199</apikey> " & vbNewLine & _
                                "<orgInfos> " & vbNewLine & _
                                "<orgItem> " & vbNewLine & _
                                "<orgId>000001</orgId> " & vbNewLine & _
                                "<o>000001</o> " & vbNewLine & _
                                "<mode>sub</mode> " & vbNewLine & _
                                "</orgItem> " & vbNewLine & _
                                "<flag>query</flag> " & vbNewLine & _
                                "</orgInfos> " & vbNewLine

#End Region

    'Sub New(ByVal fromWebServerVerKind As Enum_VerKind, _
    '                  ByVal fromWebServerMethod As String, _
    '                  ByVal fromParamData As String)
    '    '_WebServerUrl = "http://localhost/MvcWebService/WebService.asmx"

    '    '_WebServerMethod = fromWebServerMethod
    '    '_WebServerParamData = fromParamData

    '    'Me.New(fromWebServerVerKind, _
    '    '                    "http://localhost/MvcWebService/WebService.asmx", _
    '    '                     fromWebServerMethod, _
    '    '                     fromParamData)
    'End Sub

    Sub New(ByVal fromWebServerVerKind As Enum_VerKind, _
                      ByVal fromWebServerUrl As String, _
                      ByVal fromWebServerMethod As String, _
                      ByVal fromParamData As String)

        _WebServerVerKind = fromWebServerVerKind
        Select Case _WebServerVerKind
            Case Enum_VerKind.A_MS_AspNet
                _EncodeFlag_URL = True
                _EncodeFlag_XML = True

            Case Else
                _EncodeFlag_URL = False
                _EncodeFlag_XML = False
        End Select

        _WebServerUrl = fromWebServerUrl

        _WebServerMethod = fromWebServerMethod
        _WebServerParamData = fromParamData
    End Sub


    Private Function XMLStringIsEncode(ByVal fromXML As String)
        If fromXML.Substring(0, 9) = "%3c%3fxml" Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Function Get_RequestContent_XML() As String
        Dim requestXML As String = ""

        Select Case _WebServerVerKind
            Case Enum_VerKind.A_MS_AspNet
                requestXML = "<?xml version=""1.0"" encoding=""utf-8""?>"
                requestXML &= "<soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">"
                requestXML &= "<soap12:Body>"

                '方法名稱  
                requestXML &= "<" & _WebServerMethod & " xmlns=""http://tempuri.org/"">"

                '參數名稱跟傳入的值
                '>>參數名稱:   fromXML
                requestXML &= IIf(_WebServerParamData.Length = 0, "", _
                                                "<fromXML>" & _
                                                            IIf(XMLStringIsEncode(_WebServerParamData), _WebServerParamData, PublicUtils.URLEncode(_WebServerParamData)) & _
                                                "</fromXML>")


                requestXML &= "</" & _WebServerMethod & ">"

                requestXML &= "</soap12:Body>"
                requestXML &= "</soap12:Envelope>"


            Case Enum_VerKind.B_CCMail_PHP
                requestXML = _WebServerParamData

        End Select

        Return requestXML
    End Function

    Public Function GetQueryString() As String
        'SOAP 1.2
        Dim retString As String = ""

        Dim W_RequestContent_XML As String = Get_RequestContent_XML()
        Dim W_RequestContent_ByteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(W_RequestContent_XML)

        Dim request As Net.WebRequest = Net.WebRequest.Create(_WebServerUrl)

        Select Case _WebServerVerKind
            Case Enum_VerKind.A_MS_AspNet
                request.ContentType = "application/soap+xml; charset=utf-8"
            Case Enum_VerKind.B_CCMail_PHP
                request.ContentType = "application/xml; charset=utf-8"
        End Select


        request.Method = "POST"
        request.Timeout = 20000
        request.ContentLength = W_RequestContent_ByteArray.Length

        Dim dataStream As System.IO.Stream = Nothing
        Try
            '寫入資料流：Type 1
            dataStream = request.GetRequestStream()
            ' Write the data to the request stream.
            dataStream.Write(W_RequestContent_ByteArray, 0, W_RequestContent_ByteArray.Length)
            ' Close the Stream object.
            dataStream.Close()

            ''寫入資料流 ：Type 2
            'Dim sw As New IO.StreamWriter(request.GetRequestStream, System.Text.Encoding.Default)
            'sw.Write(requestXML)
            'sw.Close()
            'request = CType(request.GetResponse, Net.HttpWebResponse)



            '取回資料流 
            Dim response As System.Net.WebResponse = request.GetResponse()
            dataStream = response.GetResponseStream()

            ' Open the stream using a StreamReader for easy access.
            Dim reader As New System.IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()


            Select Case _WebServerVerKind
                Case Enum_VerKind.A_MS_AspNet
                    retString = responseFromServer.Substring(InStr(responseFromServer, "%3c%3fxml") - 2)
                    retString = retString.Substring(1, InStr(retString, "</") - 2)

                    If XMLStringIsEncode(retString) = True Then
                        retString = PublicUtils.URLDecode(retString)
                    End If

                Case Enum_VerKind.B_CCMail_PHP
                    retString = responseFromServer
            End Select
            


            ' Clean up the streams.
            reader.Close()
            dataStream.Close()
            response.Close()

        Catch ex As Exception
            retString = ex.ToString
        Finally

        End Try

        Return retString
    End Function



End Class
