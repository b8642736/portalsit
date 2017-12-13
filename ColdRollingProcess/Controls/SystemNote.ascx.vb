Public Class SystemNote
    Inherits System.Web.UI.UserControl

    Private _clsSystemNote As New PublicClassLibrary.ClsSystemNote

    'Private WP_SYSTEM_TYPE_default As String = ""
#Region "ViewState：WP_SYSTEM_TYPE_default"
    Const C_SYSTEM_TYPE_default As String = "VS_SYSTEM_TYPE_default"
    Private Property WP_SYSTEM_TYPE_default As String
        Get
            If ViewState(C_SYSTEM_TYPE_default) Is Nothing Then
                ViewState(C_SYSTEM_TYPE_default) = ""
            End If
            Return ViewState(C_SYSTEM_TYPE_default)
        End Get
        Set(value As String)
            ViewState(C_SYSTEM_TYPE_default) = value
        End Set

    End Property
#End Region

#Region "ViewState：WP_SYSTEM_TYPE_select"
    Const C_SYSTEM_TYPE_select As String = "VS_SYSTEM_TYPE_select"
    Private Property WP_SYSTEM_TYPE_select As String
        Get
            If ViewState(C_SYSTEM_TYPE_select) Is Nothing Then
                ViewState(C_SYSTEM_TYPE_select) = ""
            End If
            Return ViewState(C_SYSTEM_TYPE_select)
        End Get
        Set(value As String)
            ViewState(C_SYSTEM_TYPE_select) = value
        End Set

    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            ddlistSYSTEM_TYPE.Items.Clear()

            Dim queryDataTable As DataTable = _clsSystemNote.getLev1
            _clsSystemNote.setDropDownList(ddlistSYSTEM_TYPE, queryDataTable)


            Dim sessionkey1 As String = "defaultSYSTEM_TYPE"
            If Not Session(sessionkey1) Is Nothing Then
                WP_SYSTEM_TYPE_default = HttpUtility.UrlDecode(Session(sessionkey1).ToString())
                ddlistSYSTEM_TYPE.SelectedIndexByValue(WP_SYSTEM_TYPE_default)
                ddlistSYSTEM_TYPE.Enabled = False

                Session.Remove(sessionkey1)
            End If

            ddlistSYSTEM_TYPE_SelectedIndexChanged(Nothing, Nothing)
            ddlistNOTE_TYPE_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Protected Sub ddlistSYSTEM_TYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlistSYSTEM_TYPE.SelectedIndexChanged
        ddlistNOTE_TYPE.Items.Clear()

        Dim queryDataTable As DataTable = _clsSystemNote.getLev2(ddlistSYSTEM_TYPE.Text)
        _clsSystemNote.setDropDownList(ddlistNOTE_TYPE, queryDataTable)


        ddlistNOTE_TYPE_SelectedIndexChanged(Nothing, Nothing)
    End Sub


#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    Private Sub MakeQryStringToControl()
        Dim queryDel_Flag As String = _clsSystemNote.Fs_GetStrBefor(ddlistDel_Flag.Text, "：")

        Dim querySql As New StringBuilder
        querySql.Append("SELECT * FROM SystemNote WHERE 1=1 ")
        querySql.Append("AND SYSTEM_TYPE='" & ddlistSYSTEM_TYPE.Text & "' ")
        querySql.Append("AND NOTE_TYPE='" & ddlistNOTE_TYPE.Text & "' ")

        If queryDel_Flag <> "ALL" Then
            querySql.Append("AND del_flag='" & queryDel_Flag & "' ")
        End If

        querySql.Append("ORDER BY DISPLAY_SEQ,NOTE_ID  ")

        Me.hfSQL.Value = querySql.ToString
    End Sub
#End Region

#Region "SystemNote:CRUD"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL As String) As List(Of SQLServer.QCDB01.SystemNote)
        If String.IsNullOrEmpty(fromSQL) Or fromSQL = "" Then
            Return New List(Of SQLServer.QCDB01.SystemNote)
        End If
        Return SQLServer.QCDB01.ZML更換紀錄表.CDBSelect(Of SQLServer.QCDB01.SystemNote)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, fromSQL)
    End Function

    <DataObjectMethod(DataObjectMethodType.Insert)>
    Public Function Insert(ByVal fromObj As SQLServer.QCDB01.SystemNote) As Integer
        Try
            Return fromObj.CDBInsert
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "系統資訊")
        End Try
    End Function

    <DataObjectMethod(DataObjectMethodType.Update)>
    Public Function Update(ByVal fromObj As SQLServer.QCDB01.SystemNote) As Integer
        Return fromObj.CDBUpdate
    End Function

    <DataObjectMethod(DataObjectMethodType.Delete)>
    Public Function Delete(ByVal fromObj As SQLServer.QCDB01.SystemNote) As Integer
        Return fromObj.CDBDelete
    End Function
#End Region

    Protected Sub ddlistNOTE_TYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlistNOTE_TYPE.SelectedIndexChanged
        MakeQryStringToControl()
    End Sub

    Protected Sub ddlistDel_Flag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlistDel_Flag.SelectedIndexChanged
        MakeQryStringToControl()
    End Sub

    Public Function showDeleteButton() As Boolean
        Return (WP_SYSTEM_TYPE_default = "")
    End Function

    Private Sub ListView1_ItemInserting(sender As Object, e As ListViewInsertEventArgs) Handles ListView1.ItemInserting

        If IsNumeric(e.Values("DISPLAY_SEQ")) = False Then e.Values("DISPLAY_SEQ") = 0

        Dim dEL_FLAGDropDownListEx As DropDownList = ListView1.InsertItem.FindControl("DEL_FLAGDropDownListEx")
        e.Values("DEL_FLAG") = dEL_FLAGDropDownListEx.SelectedValue

    End Sub

    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating

        If IsNumeric(e.NewValues("DISPLAY_SEQ")) = False Then e.NewValues("DISPLAY_SEQ") = 0

        Dim dEL_FLAGDropDownListEx As DropDownList = ListView1.EditItem.FindControl("DEL_FLAGDropDownListEx")
        e.NewValues("DEL_FLAG") = dEL_FLAGDropDownListEx.SelectedValue
    End Sub


    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        If Not IsNothing(ListView1.InsertItem) Then
            Dim txtDISPLAY_SEQTextBox As TextBox = ListView1.InsertItem.FindControl("DISPLAY_SEQTextBox")
            If txtDISPLAY_SEQTextBox.Text = "" Then txtDISPLAY_SEQTextBox.Text = "0"


            Dim txtSYSTEM_TYPETextBox As TextBox = ListView1.InsertItem.FindControl("SYSTEM_TYPETextBox")
            txtSYSTEM_TYPETextBox.Text = ddlistSYSTEM_TYPE.SelectedValue

            Dim txtNOTE_TYPETextBox As TextBox = ListView1.InsertItem.FindControl("NOTE_TYPETextBox")
            txtNOTE_TYPETextBox.Text = ddlistNOTE_TYPE.SelectedValue
        End If


        If Not IsNothing(ListView1.EditItem) Then
            Dim txtDEL_FLAGTextBox As TextBox = ListView1.EditItem.FindControl("DEL_FLAGTextBox")
            Dim dEL_FLAGDropDownListEx As DropDownList = ListView1.EditItem.FindControl("DEL_FLAGDropDownListEx")

            For Each eachItem As ListItem In dEL_FLAGDropDownListEx.Items
                If txtDEL_FLAGTextBox.Text = eachItem.Text Then
                    dEL_FLAGDropDownListEx.SelectedValue = txtDEL_FLAGTextBox.Text
                    Exit For
                End If
            Next

        End If


    End Sub

End Class