Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            'ucAuthorizeButton 會把Click事件劫走,故只用ucAuthorizeButton的權限控管,顯示用原生Button

            CopyButtonAttr(ucBtnServer1, displayBtnServer1)

            CopyButtonAttr(ucBtnServer2_1, displayBtnServer2_1)
            CopyButtonAttr(ucbtnServer2_2, displayBtnServer2_2)
            CopyButtonAttr(ucbtnServer2_3, displayBtnServer2_3)
        End If
    End Sub

    Protected Sub CopyButtonAttr(ByRef fromBtn1 As UCAjaxServerControl1.ucAuthorizeButton, ByRef fromBtn2 As Button)
        fromBtn2.Enabled = fromBtn1.Enabled
        fromBtn2.Visible = fromBtn1.Visible

        fromBtn1.Visible = False
    End Sub

    Protected Sub btnServer1_Click(sender As Object, e As EventArgs) Handles displayBtnServer1.Click
        Dim URL As String = ""

        '106~108 三台電腦同樣內容
        URL = "http://10.1.5.106:8000/asip-api"
        'URL = "http://10.1.5.107:8000/asip-api"
        'URL = "http://10.1.5.108:8000/asip-api"

        If CheckBrowser(Me, BrowserEnum.Chrome, False) Then
            OpenURL(Me, URL)
        Else
            OpenURL2(Me, URL)
        End If
    End Sub


    Protected Sub btnServer2_Click(sender As Object, e As EventArgs) Handles displayBtnServer2_1.Click, displayBtnServer2_2.Click, displayBtnServer2_3.Click
        Dim URL As String = "http://10.1.4.12/EIP"

        Select Case CType(sender, Button).ID
            Case "displayBtnServer2_1"
                URL = "http://10.1.5.129/"
            Case "displayBtnServer2_2"
                URL = "http://10.1.5.130/"
            Case "displayBtnServer2_3"
                URL = "http://10.1.5.131/"
        End Select

        If CheckBrowser(Me, BrowserEnum.IE) = True Then OpenURL(Me, URL)
    End Sub



End Class