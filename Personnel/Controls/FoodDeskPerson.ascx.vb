Public Class FoodDeskPerson
    Inherits System.Web.UI.UserControl

    Private WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote

    Private WP_AS400Adapter As New AS400SQLQueryAdapter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call P_Init()
        End If

    End Sub

#Region "ViewState：Employee"
    Const C_DataTableEmployee As String = "DataTableEmployee"
    Private Property WP_DataTable_Employee As DataTable
        Get
            If ViewState(C_DataTableEmployee) Is Nothing Then
                ViewState(C_DataTableEmployee) = FD_Data_Employee_Now()
            End If
            Return ViewState(C_DataTableEmployee)
        End Get
        Set(value As DataTable)
            ViewState(C_DataTableEmployee) = value
        End Set

    End Property


    Public Function showEmployeeName(ByVal fromID As String) As String
        Dim showName As String = (From A In WP_DataTable_Employee Where A.Item("qd100a").ToString.Trim.Equals(fromID.Trim) Select A.Item("qd100c").ToString.Trim).FirstOrDefault
        Dim retMsg As String = IIf(String.IsNullOrEmpty(showName), fromID, fromID & "：" & showName)

        Return retMsg

    End Function
#End Region

#Region "ViewState：Unit"
    Const C_DataTableUnit As String = "DataTableUnit"
    Private Property WP_DataTable_Unit As DataTable
        Get
            If ViewState(C_DataTableUnit) Is Nothing Then
                ViewState(C_DataTableUnit) = FD_Data_Department_Super()
            End If
            Return ViewState(C_DataTableUnit)
        End Get
        Set(value As DataTable)
            ViewState(C_DataTableUnit) = value
        End Set

    End Property

    Public Function showDeptName(ByVal fromID As String) As String
        Dim showName As String = (From A In WP_DataTable_Unit Where A.Item("pqdp1").ToString.Trim.Equals(fromID.Trim) Select A.Item("pqdp2").ToString.Trim).FirstOrDefault
        Dim retMsg As String = IIf(showName.Trim.Equals(""), fromID, fromID & "：" & showName)

        Return retMsg
    End Function
#End Region



#Region "P_Init"
    Private Sub P_Init()
        With ddUnit_Search.Items
            .Clear()

            Dim objViewStat As DataTable = WP_DataTable_Unit

            For Each eachItem As DataRow In objViewStat.Rows
                .Add(eachItem.Item("PQDP1").Trim & "：" & eachItem.Item("PQDP2").Trim)
            Next
        End With

        With ddDataType_Search.Items
            .Clear()
            .Add("ALL：全部")
            .Add("N：正在使用")
            .Add("Y：已刪除")
        End With
        ddDataType_Search.SelectedIndex = 1

    End Sub
#End Region

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakeQryStringToControl()
    End Sub

    Protected Sub ddUnit_Search_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddUnit_Search.SelectedIndexChanged
        MakeQryStringToControl()
    End Sub

    Protected Sub ddDataType_Search_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddDataType_Search.SelectedIndexChanged
        MakeQryStringToControl()
    End Sub

#Region "ListView1"
    Protected Sub btnSearchEmployee_Click(sender As Object, e As EventArgs)
        Dim listView As ListViewItem = ListView1.InsertItem

        If Not listView Is Nothing Then
            Dim textboxObj As TextBox = listView.FindControl("FD302TextBox")
            Dim labelObj As Label = listView.FindControl("FD302Label")
            Dim showName As String = showEmployeeName(textboxObj.Text)

            If InStr(showName, "：") = 0 Then
                labelObj.Text = ""
            Else
                labelObj.Text = showName
                textboxObj.Text = ""
            End If


        End If
    End Sub





    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        Dim II As Integer
        Dim ddDataTypeObj As DropDownList
        Dim labelOBj As Label
        Dim hiddenFieldObj As HiddenField
        Dim listViewItem As ListViewItem

        listViewItem = ListView1.InsertItem

        If Not listViewItem Is Nothing Then
            ddDataTypeObj = listViewItem.FindControl("ddDataType_Add")
            With ddDataTypeObj.Items
                .Clear()
                For Each eachItem As ListItem In ddDataType_Search.Items
                    If WP_ClsSystemNote.Fs_GetStrBefor(eachItem.Text, "：") = "ALL" Then Continue For
                    .Add(eachItem.Text)
                Next
            End With

            labelOBj = listViewItem.FindControl("FD301Label")
            labelOBj.Text = ddUnit_Search.SelectedValue
        End If


        listViewItem = ListView1.EditItem
        If Not listViewItem Is Nothing Then
            ddDataTypeObj = listViewItem.FindControl("ddDataType_Edit")
            With ddDataTypeObj.Items
                .Clear()
                For Each eachItem As ListItem In ddDataType_Search.Items
                    If WP_ClsSystemNote.Fs_GetStrBefor(eachItem.Text, "：") = "ALL" Then Continue For
                    .Add(eachItem.Text)
                Next
            End With

            hiddenFieldObj = listViewItem.FindControl("FD303HiddenField")
            For II = 0 To ddDataTypeObj.Items.Count - 1
                If WP_ClsSystemNote.Fs_GetStrBefor(ddDataTypeObj.Items(II).Text, "：") = hiddenFieldObj.Value.Trim Then
                    ddDataTypeObj.SelectedIndex = II
                    Exit For
                End If
            Next

        End If
    End Sub




    Private Sub ListView1_ItemInserting(sender As Object, e As ListViewInsertEventArgs) Handles ListView1.ItemInserting
        Dim FD301Label As Label = ListView1.InsertItem.FindControl("FD301Label")
        Dim FD302Label As Label = ListView1.InsertItem.FindControl("FD302Label")
        Dim ddDataType_Add As DropDownList = ListView1.InsertItem.FindControl("ddDataType_Add")

        e.Values("FD301") = WP_ClsSystemNote.Fs_GetStrBefor(FD301Label.Text, "：")
        e.Values("FD302") = WP_ClsSystemNote.Fs_GetStrBefor(FD302Label.Text, "：")
        e.Values("FD303") = WP_ClsSystemNote.Fs_GetStrBefor(ddDataType_Add.SelectedValue, "：")

        e.Values("FD304") = Format(Now, "yyyy/MM/dd HH:mm:ss")
    End Sub

    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Dim ddDataType_Edit As DropDownList = ListView1.EditItem.FindControl("ddDataType_Edit")
        e.NewValues("FD303") = WP_ClsSystemNote.Fs_GetStrBefor(ddDataType_Edit.SelectedValue, "：")

        e.NewValues("FD304") = Format(Now, "yyyy/MM/dd HH:mm:ss")
    End Sub


#End Region

#Region "驗證使用者輸入資料：CustomValidator"

    Protected Sub cv1_ServerValidate(source As Object, args As ServerValidateEventArgs) 'Handles cvQueryFood.ServerValidate
        Dim listViewItemObj As System.Web.UI.WebControls.ListViewItem = Nothing

        'Only Insert 
        If Not ListView1.EditItem Is Nothing Then Exit Sub
        If ListView1.InsertItem Is Nothing Then Exit Sub

        Dim SenderControl As CustomValidator = source
        SenderControl.ErrorMessage = ""

        Dim FD301Label As Label = ListView1.InsertItem.FindControl("FD301Label")
        Dim FD302Label As Label = ListView1.InsertItem.FindControl("FD302Label")


        SenderControl.ErrorMessage = ""
        If FD302Label.Text.Trim = "" Then
            SenderControl.ErrorMessage = "請先輸入職工編號後點選『查詢』，再點選『插入』"
        Else
            Dim W_SQL As New StringBuilder
            W_SQL.Append("SELECT 1 " & vbCrLf)
            W_SQL.Append("FROM @#FOD100LB.FODM03PF " & vbCrLf)
            W_SQL.Append("WHERE fd301='" & WP_ClsSystemNote.Fs_GetStrBefor(FD301Label.Text, "：") & "' " & vbCrLf)
            W_SQL.Append("    AND fd302='" & WP_ClsSystemNote.Fs_GetStrBefor(FD302Label.Text, "：") & "' " & vbCrLf)

            Dim queryDataTable As DataTable = WP_AS400Adapter.SelectQuery(W_SQL.ToString)
            If queryDataTable.Rows.Count > 0 Then
                If SenderControl.ErrorMessage <> "" Then
                    SenderControl.ErrorMessage &= Space(5)
                End If
                SenderControl.ErrorMessage &= "帳號重複，請確認。"
            End If
        End If



        args.IsValid = String.IsNullOrEmpty(SenderControl.ErrorMessage)

    End Sub
#End Region

#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    Private Sub MakeQryStringToControl()

        Dim querySql As New StringBuilder
        Dim queryUnit As String = WP_ClsSystemNote.Fs_GetStrBefor(ddUnit_Search.SelectedValue, "：")
        Dim queryIsDelete As String = WP_ClsSystemNote.Fs_GetStrBefor(ddDataType_Search.SelectedValue, "：")

        querySql.Append("SELECT * " & vbNewLine)
        querySql.Append("FROM @#fod100lb.fodm03pf" & vbNewLine)
        querySql.Append("  WHERE 1=1 " & vbNewLine)
        querySql.Append("  AND FD301= '" & queryUnit & "'" & vbNewLine)

        If Not WP_ClsSystemNote.Fs_GetStrBefor(ddDataType_Search.Text, "：") = "ALL" Then
            querySql.Append("  AND FD303= '" & queryIsDelete & "'" & vbNewLine)
        End If

        Me.hfSQL.Value = querySql.ToString

    End Sub
#End Region

#Region "CRUD：Fodm03PF"

    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal fromSQL As String) As List(Of FOD100LB.FODM03PF)
        If String.IsNullOrEmpty(fromSQL) Or fromSQL = "" Then
            Return New List(Of FOD100LB.FODM03PF)
        End If
        Return FOD100LB.FODM03PF.CDBSelect(Of FOD100LB.FODM03PF)(fromSQL, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function

    <DataObjectMethod(DataObjectMethodType.Insert)>
    Public Function Insert(ByVal fromObj As FOD100LB.FODM03PF) As Integer
        fromObj.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return fromObj.CDBInsert
    End Function

    <DataObjectMethod(DataObjectMethodType.Update)>
    Public Function Update(ByVal fromObj As FOD100LB.FODM03PF) As Integer
        fromObj.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return fromObj.CDBUpdate
    End Function

    '<DataObjectMethod(DataObjectMethodType.Delete)>
    'Public Function Delete(ByVal fromObj As FOD100LB.FODM03PF) As Integer
    '    Return fromObj.CDBDelete
    'End Function
#End Region





End Class