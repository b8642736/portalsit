Module ModPublic

    Public Enum BrowserEnum
        IE = 1
        Chrome = 2
    End Enum


    Public Sub MsgBox(ByRef fromControl As Object, ByVal Message As String)
        Dim Control As System.Web.UI.Control = fromControl
        Dim Type As System.Type = Control.GetType

        MsgBox(Control, Type, Message)
    End Sub

    Public Sub MsgBox(ByRef fromControl As System.Web.UI.Control, _
                                           ByVal fromType As System.Type, ByVal Message As String)
        Dim sScript As String
        Dim sMessage As String

        sMessage = Strings.Replace(Message, "'", "\'") '處理單引號
        sMessage = Strings.Replace(sMessage, vbNewLine, "\n") '處理換行
        sScript = String.Format("alert('{0}');", sMessage)
        ScriptManager.RegisterStartupScript(fromControl, fromType, "alert", sScript, True)
    End Sub


    Public Function CheckBrowser(ByRef fromControl As Object, _
                                                  ByVal fromBrowser As BrowserEnum) As Boolean
        Return CheckBrowser(fromControl, fromBrowser, True)
    End Function

    Public Function CheckBrowser(ByRef fromControl As Object, _
                                                      ByVal fromBrowser As BrowserEnum, _
                                                      ByVal fromAlterMsg As Boolean) As Boolean
        Dim Request As System.Web.HttpRequest = fromControl.Request
        Dim BrowSerNameNow As String = Request.Browser.Browser.ToString
        Dim fromBrowserName As String
        Select Case fromBrowser
            Case BrowserEnum.Chrome
                fromBrowserName = "Chrome"
            Case BrowserEnum.IE
                fromBrowserName = "IE"
            Case Else
                fromBrowserName = fromBrowser.ToString
        End Select


        If BrowSerNameNow.Equals(fromBrowserName) = False Then
            Dim Control As System.Web.UI.Control = fromControl
            Dim Type As System.Type = Control.GetType

            If fromAlterMsg = True Then
                MsgBox(Control, Type, "此監視系統瀏覽器需使用" & fromBrowserName & vbNewLine & vbNewLine & "目前登入瀏覽器為" & BrowSerNameNow)
            End If

            CheckBrowser = False
        Else
            CheckBrowser = True
        End If
    End Function


    ''' <summary>
    ''' 使用IE用對話框方式開啟網頁
    ''' </summary>
    ''' <param name="fromControl"></param>
    ''' <param name="fromURL"></param>
    ''' <remarks></remarks>
    Public Sub OpenURL(ByRef fromControl As Object, ByVal fromURL As String)
        Dim JavaSrciptString As String
        Dim Control As System.Web.UI.Control = fromControl
        Dim Type As System.Type = Control.GetType


        'JavaSrciptString = "<script language='JavaScript'>window.open('" & fromURL & "','','menubar=no,location=no,height='+screen.availHeight+',width='+screen.availWidth+'');</script>"
        'Response.Write(JavaSrciptString)


        'JavaSrciptString = "<script language='JavaScript'>window.showModalDialog('" & fromURL & "','','status: off;center: yes;dialogHeight: '+screen.availHeight+'px;dialogWidth: '+screen.availWidth+'px;');"
        'JavaSrciptString = JavaSrciptString + "</script>"
        'Me.Page.RegisterStartupScript("JavaSrciptString", JavaSrciptString)


        'JavaSrciptString = "window.showModalDialog('" & fromURL & "','','status: off;center: yes;dialogHeight: '+screen.availHeight+'px;dialogWidth: '+screen.availWidth+'px;');"
        JavaSrciptString = "window.showModalDialog('" & fromURL & "','','status: off;center: no;dialogLeft=0;dialogTop=0;dialogHeight: '+window.screen.availHeight+'px;dialogWidth: '+screen.availWidth+'px;');"
        ScriptManager.RegisterStartupScript(Control, Type, "OpenURL", JavaSrciptString, True)
    End Sub

    ''' <summary>
    ''' 使用Chrome開啟網頁
    ''' </summary>
    ''' <param name="fromControl"></param>
    ''' <param name="fromURL"></param>
    ''' <remarks></remarks>
    Public Sub OpenURL2(ByRef fromControl As Object, ByVal fromURL As String)
        Dim JavaSrciptString As String

        Dim Control As System.Web.UI.Control = fromControl
        Dim Type As System.Type = Control.GetType

        JavaSrciptString = " var WshShell = new ActiveXObject('Wscript.Shell');  "
        JavaSrciptString += "WshShell.Run('Chrome " & fromURL & "');"
        ScriptManager.RegisterStartupScript(Control, Type, "OpenURL", JavaSrciptString, True)
    End Sub
End Module
