Imports System.Globalization

Public Class TestList
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            MakeQryStringToControl()
        End If

    End Sub
#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    Private Sub MakeQryStringToControl()

        Dim querySql As New StringBuilder
        querySql.Append("SELECT * FROM LabRecordA1_M WHERE 1=1 ")

        Me.hfSQL.Value = querySql.ToString
    End Sub
#End Region

#Region "SystemNote:CRUD"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL As String) As List(Of SQLServer.QCdb01.LabRecordA1_M)
        If String.IsNullOrEmpty(fromSQL) Or fromSQL = "" Then
            Return New List(Of SQLServer.QCdb01.LabRecordA1_M)
        End If
        Return SQLServer.QCdb01.LabRecordA1_M.CDBSelect(Of SQLServer.QCdb01.LabRecordA1_M)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, fromSQL)
    End Function

    <DataObjectMethod(DataObjectMethodType.Insert)>
    Public Function Insert(ByVal fromObj As SQLServer.QCdb01.LabRecordA1_M) As Integer
        Try
            Return fromObj.CDBInsert
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "系統資訊")
        End Try
    End Function

    <DataObjectMethod(DataObjectMethodType.Update)>
    Public Function Update(ByVal fromObj As SQLServer.QCdb01.LabRecordA1_M) As Integer
        Return fromObj.CDBUpdate
    End Function

    <DataObjectMethod(DataObjectMethodType.Delete)>
    Public Function Delete(ByVal fromObj As SQLServer.QCdb01.LabRecordA1_M) As Integer
        Return fromObj.CDBDelete
    End Function
#End Region

    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Dim tbDateS As TextBox = ListView1.EditItem.FindControl("品檢日期_起TextBox")
        e.NewValues("品檢日期_起") = Date.Parse(tbDateS.Text)
        e.NewValues("品檢日期_迄") = Date.Parse(e.NewValues("品檢日期_迄"))
        e.NewValues("資料日期") = Date.Parse(e.NewValues("資料日期"))
        Dim ddlisTitle2 As DropDownList = ListView1.EditItem.FindControl("ddlisTitle2")
        e.NewValues("標題2") = ddlisTitle2.SelectedValue
    End Sub

    Private Sub ListView1_ItemInserting(sender As Object, e As ListViewInsertEventArgs) Handles ListView1.ItemInserting
        e.Values("品檢日期_起") = Date.Parse(e.Values("品檢日期_起"))
        e.Values("品檢日期_迄") = Date.Parse(e.Values("品檢日期_迄"))
        e.Values("資料日期") = Date.Parse(e.Values("資料日期"))
    End Sub

    Public Sub CustomValidator1_ServerValidate(source As Object, args As System.Web.UI.WebControls.ServerValidateEventArgs) 'Handles CustomValidator1.ServerValidate
        Dim validatorObjl As CustomValidator = Nothing
        Dim listViewItemObj As System.Web.UI.WebControls.ListViewItem = Nothing
        Dim textboxObj1 As TextBox = Nothing
        Dim textboxObj2 As TextBox = Nothing
        Dim textboxObj3 As TextBox = Nothing

        '特別地方: 修改時 InsertItem與 EditItem 都會存在
        '                   新增時 InsertItem
        If Not ListView1.InsertItem Is Nothing Then
            listViewItemObj = ListView1.InsertItem
        End If
        If Not ListView1.EditItem Is Nothing Then
            listViewItemObj = ListView1.EditItem
        End If
        ''品檢日期_起TextBox 品檢日期_迄TextBox 資料日期TextBox



        If Not listViewItemObj Is Nothing Then
            validatorObjl = listViewItemObj.FindControl("CustomValidator1")
            textboxObj1 = listViewItemObj.FindControl("品檢日期_起TextBox")
            textboxObj2 = listViewItemObj.FindControl("品檢日期_迄TextBox")
            textboxObj3 = listViewItemObj.FindControl("資料日期TextBox")

            validatorObjl.ErrorMessage = String.Empty
            If Date.TryParse(textboxObj1.Text, New Date()) = False Then
                validatorObjl.ErrorMessage = "輸入的日期格式錯誤"
                validatorObjl.ForeColor = Drawing.Color.Red
                textboxObj1.ForeColor = Drawing.Color.Red
            ElseIf Date.TryParse(textboxObj2.Text, New Date()) = False Then
                validatorObjl.ErrorMessage = "輸入的日期格式錯誤"
                validatorObjl.ForeColor = Drawing.Color.Red
                textboxObj2.ForeColor = Drawing.Color.Red
            ElseIf Date.TryParse(textboxObj3.Text, New Date()) = False Then
                validatorObjl.ErrorMessage = "輸入的日期格式錯誤"
                validatorObjl.ForeColor = Drawing.Color.Red
                textboxObj3.ForeColor = Drawing.Color.Red

            End If
            args.IsValid = (validatorObjl.ErrorMessage.Trim.Length = 0)
        End If

    End Sub

    Protected Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        If Not IsNothing(ListView1.EditItem) Then
            Dim tbTitle2 As TextBox = ListView1.EditItem.FindControl("標題2TextBox")
            Dim ddlisTitle2 As DropDownList = ListView1.EditItem.FindControl("ddlisTitle2")
            Dim tbDateS As TextBox = ListView1.EditItem.FindControl("品檢日期_起TextBox")
            Try
                tbDateS.Text = Date.Parse(tbDateS.Text)
            Catch ex As Exception

            End Try

            For Each eachItem As ListItem In ddlisTitle2.Items
                If tbTitle2.Text = eachItem.Text Then
                    ddlisTitle2.SelectedValue = tbTitle2.Text
                    Exit For
                End If
            Next

        End If
    End Sub
End Class