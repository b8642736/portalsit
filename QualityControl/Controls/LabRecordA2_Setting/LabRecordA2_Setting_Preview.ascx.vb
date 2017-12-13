Public Class LabRecordA2_Setting_Preview
    Inherits System.Web.UI.UserControl


    Protected Sub queryKeyDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim W_ObjDropDownList As DropDownList = CType(sender, DropDownList)
        Dim W_ObjID As String = W_ObjDropDownList.ID.Replace(C_Fix_DropDownList, "")
        Dim W_ObjCheckBox As CheckBox = CType(FindControl(String.Concat(W_ObjID, C_Fix_CheckBox)), CheckBox)

        Select Case Microsoft.VisualBasic.Right(W_ObjID, 1)
            Case "1"
                W_ObjCheckBox = queryKey1CheckBox
            Case "2"
                W_ObjCheckBox = queryKey2CheckBox
            Case "3"
                W_ObjCheckBox = queryKey3CheckBox
                LabRecordA2_Setting_Module.P_SetDropDownList_DataKey4_材質(queryKey4DropDownList, queryKey3DropDownList.SelectedValue)
            Case "4"
                W_ObjCheckBox = queryKey4CheckBox
        End Select

        W_ObjCheckBox.Checked = True

        HyperLink1.Text = ""
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            P_INIT()
        End If
    End Sub

#Region "SystemNote"
    Public Enum Enum_DropDownList
        檢驗項目基本檔_停用否 = 1
        片語基本檔_代號群組 = 2
        檢驗項目基本檔_資料來源類型 = 3
        片語基本檔_條件檢查 = 4
        檢驗項目基本檔_是否顯示 = 5
    End Enum

    Public Sub P_DropDownList_SetItem(ByVal fromNote_Type As Enum_DropDownList, _
                                        ByRef fromObj As DropDownList)

        Dim W_NoteType As String = [Enum].GetName(GetType(Enum_DropDownList), fromNote_Type)
        Dim queryDataTable1 As DataTable
        Dim W_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

        queryDataTable1 = W_ClsSystemNote.getLev3(C_SYSTEM_TYPE, W_NoteType)
        W_ClsSystemNote.setDropDownList(fromObj, queryDataTable1, W_ClsSystemNote.Display_Lable)
    End Sub
#End Region

    Private W_Now主畫面_Enum As 主畫面_Enum = 主畫面_Enum.設定值預覽
    Private Sub P_INIT()
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey1_參照規範(queryKey1DropDownList, False)
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey2_表面類別(queryKey2DropDownList, False)
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey3_鋼種(queryKey3DropDownList, False)
        LabRecordA2_Setting_Module.P_SetDropDownList_DataKey4_材質(queryKey4DropDownList, queryKey3DropDownList.SelectedValue, False)
    End Sub

    Protected Sub btnSerach_Click(sender As Object, e As EventArgs) Handles btnSerach.Click
        Dim W_URL As String = FS_GetURL()

        HyperLink1.Target = "_blank"
        HyperLink1.Text = "點我開啟預覽畫面"
        HyperLink1.NavigateUrl = W_URL

        'OpenURL(Me, W_URL)
        
    End Sub

    Private Function FS_GetURL() As String
        Dim W_URL As String = "", W_FileName As String = "LabRecordA2PreviewForm.aspx"

        Dim W_ParamValue As String = "", W_ParamEncode As String = ""

        Dim W_ObjDropDownList As DropDownList
        Dim W_ObjCheckBox As CheckBox
        For II As Integer = 1 To 4
            W_ObjCheckBox = CType((Me.FindControl(String.Concat("queryKey", II, "CheckBox"))), CheckBox)
            W_ObjDropDownList = CType((Me.FindControl(String.Concat("queryKey", II, "DropDownList"))), DropDownList)

            If W_ObjCheckBox.Checked = True Then
                If W_ParamValue <> "" Then W_ParamValue &= "&"
                W_ParamValue &= String.Concat("KEY", II, "=", HttpUtility.UrlEncode(W_ObjDropDownList.SelectedValue))
            End If
        Next II

        If W_ParamValue.Length > 0 Then
            W_ParamEncode = String.Concat("?", W_ParamValue)
        End If


        Try
            W_URL &= "http://"
            W_URL &= Page.Request.Url.Host
            W_URL &= ":" & Page.Request.Url.Port

            Dim ApplicationPath As String = Page.Request.ApplicationPath
            W_URL &= ApplicationPath
            If W_URL.Substring((W_URL.Length - 1), 1) <> "/" Then
                W_URL &= "/"
            End If

        Catch ex As Exception
            W_URL = "http://www.google.com.tw"
        End Try

        W_URL = String.Concat(W_URL, W_FileName, W_ParamEncode)
        Return W_URL
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

        'JavaSrciptString = "window.showModalDialog('" & fromURL & "','','status: off;center: yes;dialogHeight: '+screen.availHeight+'px;dialogWidth: '+screen.availWidth+'px;');"
        JavaSrciptString = "window.showModalDialog('" & fromURL & "','','status: off;center: no;dialogLeft=0;dialogTop=0;dialogHeight: '+window.screen.availHeight+'px;dialogWidth: '+screen.availWidth+'px;');"
        ScriptManager.RegisterStartupScript(Control, Type, "OpenURL", JavaSrciptString, True)
    End Sub

End Class