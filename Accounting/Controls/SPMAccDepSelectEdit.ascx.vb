Public Class SPMAccDepSelectEdit
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SqlString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SqlString As String) As List(Of CompanyORMDB.SPMSQLServer.SPM.TEAccDepSelect)
        Dim ReturnValue As New List(Of CompanyORMDB.SPMSQLServer.SPM.TEAccDepSelect)
        If String.IsNullOrEmpty(SqlString) Then
            Return ReturnValue
        End If
        ReturnValue = CompanyORMDB.SPMSQLServer.SPM.TEAccDepSelect.CDBSelect(Of CompanyORMDB.SPMSQLServer.SPM.TEAccDepSelect)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SqlString)

        Return ReturnValue
    End Function
#End Region
#Region "新增 方法:CDBInsert"
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <param name="SourceObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Function CDBInsert(ByVal SourceObject As TEAccDepSelect) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.ServerSPM, "SPM")

        '同步資料至測試區
        Dim SPMTestObject As TEAccDepSelect = SourceObject.CDBClone
        SPMTestObject.SQLQueryAdapterByThisObject = New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.ServerSPM, "SPMTest")
        SPMTestObject.CDBInsert()

        Return SourceObject.CDBInsert()
    End Function
#End Region
#Region "刪除 方法:CDBDelete"
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="SourceObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function CDBDelete(ByVal SourceObject As CompanyORMDB.SPMSQLServer.SPM.TEAccDepSelect) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.ServerSPM, "SPM")
        '同步資料至測試區
        Dim SPMTestObject As TEAccDepSelect = SourceObject.CDBClone
        SPMTestObject.SQLQueryAdapterByThisObject = New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.ServerSPM, "SPMTest")
        SPMTestObject.CDBDelete()

        Return SourceObject.CDBDelete()
    End Function
#End Region
#Region "修改 方法:CDBUpdate"
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <param name="SourceObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As CompanyORMDB.SPMSQLServer.SPM.TEAccDepSelect) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.ServerSPM, "SPM")

        '同步資料至測試區
        Dim SPMTestObject As TEAccDepSelect = SourceObject.CDBClone
        SPMTestObject.SQLQueryAdapterByThisObject = New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.ServerSPM, "SPMTest")
        SPMTestObject.CDBSave()

        Return SourceObject.CDBSave
    End Function
#End Region

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim ReturnValue As String = "Select * from TEAccDepSelect Where AC0001 = " & DropDownList1.SelectedValue

        If Not String.IsNullOrEmpty(tbAC0002Search.Text) AndAlso tbAC0002Search.Text.Trim.Length > 0 Then
            ReturnValue &= " AND AC0002 = '" & tbAC0002Search.Text.Trim.Trim & "'"
        End If

        If Not String.IsNullOrEmpty(tbAC0003Search.Text) AndAlso tbAC0003Search.Text.Trim.Length > 0 Then
            ReturnValue &= " AND AC0003 = '" & tbAC0003Search.Text.Trim.Trim & "'"
        End If

        If Not String.IsNullOrEmpty(tbAC0004Search.Text) AndAlso tbAC0004Search.Text.Trim.Length > 0 Then
            ReturnValue &= " AND AC0004 = '" & tbAC0004Search.Text.Trim.Trim & "'"
        End If

        Me.hfQryString.Value = ReturnValue & " ORDER BY AC0001,AC0002,AC0003,AC0004 "
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.MakQryStringToControl()
        ListView1.DataBind()
    End Sub

    Protected Sub CustomValidator1_ServerValidate(source As Object, args As System.Web.UI.WebControls.ServerValidateEventArgs)
        args.IsValid = False
        Dim QryString As String = "Select count(*) from TEAccDepSelect Where AC0001 = " & DropDownList1.SelectedValue
        Dim SourceControl As CustomValidator = source
        Dim ValidControl As TextBox = ListView1.InsertItem.FindControl("AC0002TextBox")
        SourceControl.ErrorMessage = String.Empty
        For Each EachItem In CompanyORMDB.GPL2.DEPCODPF.AllDEPCODPFs
            If EachItem.DEPCOD.Trim = ValidControl.Text.Trim Then
                QryString &= " and AC0002='" & ValidControl.Text.Trim & "'"
                args.IsValid = True : Exit For
            End If
        Next
        If args.IsValid = False Then
            SourceControl.ErrorMessage = "部門代碼輸入錯誤找不到部門資料!"
            Exit Sub
        End If

        args.IsValid = False
        ValidControl = ListView1.InsertItem.FindControl("AC0003TextBox")
        For Each EachItem As CompanyORMDB.ACLIB.ACA010PF In CompanyORMDB.ACLIB.ACA010PF.AllACA010PFs
            If EachItem.ACCTNO = ValidControl.Text.Trim Then
                QryString &= " and AC0003='" & ValidControl.Text.Trim & "'"
                args.IsValid = True : Exit For
            End If
        Next
        If args.IsValid = False Then
            SourceControl.ErrorMessage = "會計科目輸入錯誤找不到資料!"
            Exit Sub
        End If

        args.IsValid = False
        ValidControl = ListView1.InsertItem.FindControl("AC0004TextBox")
        For Each EachItem As CompanyORMDB.ACLIB.ACA020PF In CompanyORMDB.ACLIB.ACA020PF.AllACA020PFs
            If EachItem.DETLNO.Trim = ValidControl.Text.Trim Then
                QryString &= " and AC0004='" & ValidControl.Text.Trim & "'"
                args.IsValid = True : Exit For
            End If
        Next
        If args.IsValid = False Then
            SourceControl.ErrorMessage = "明細科目輸入錯誤找不到資料!"
            Exit Sub
        End If

        If ValidControl.Text.Trim.Length <> 3 Then
            args.IsValid = False
            SourceControl.ErrorMessage = "明細科目必須為長度3的科目數字代碼!"
            Exit Sub
        End If

        Dim SQLAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.ServerSPM, "SPM")
        If Val(SQLAdapter.SelectQuery(QryString).Rows(0).Item(0)) > 0 Then
            args.IsValid = False
            SourceControl.ErrorMessage = "此筆資料已存在資料庫無法重覆新增!"
        End If

    End Sub

End Class