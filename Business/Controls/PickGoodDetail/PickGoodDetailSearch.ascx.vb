Public Class PickGoodDetailSearch
    Inherits System.Web.UI.UserControl


#Region "登入使用者工號 屬性:CurrentLoginUserID"
    ''' <summary>
    ''' 登入使用者工號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CurrentLoginUserID As String
        Get
            Return WebAppAuthority.CurrentWindowsLoginEmployeeNumber
        End Get
    End Property
#End Region
#Region "特殊授權使用者 屬性:SupperAuthorityUsersID"
    ''' <summary>
    ''' 特殊授權使用者
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SupperAuthorityUsersID As String
        Get
            Return "30276,31124,10592" 'ex:李丹彣/郭文龍
        End Get
    End Property

#End Region
    '客戶提貨明細對帳單程式碼
#Region "資料查詢 方法:SearchData"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function SearchData(ByVal QryString As String) As SLS300LB.PickGoodDetailDataTable
        Dim ReturnValue As New SLS300LB.PickGoodDetailDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If
        For Each EachItem In CompanyORMDB.SLS300LB.MAIL03PF.CDBSelect(Of CompanyORMDB.SLS300LB.MAIL03PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            Dim AddRow As SLS300LB.PickGoodDetailRow = ReturnValue.NewRow
            With AddRow
                .客戶 = EachItem.ML300
                .銀行 = EachItem.ML301
                .LC號碼 = EachItem.ML302
                .收款金額 = EachItem.ML303
                .收款單 = EachItem.ML304
                .統一發票 = EachItem.ML305
                .提貨單號 = EachItem.ML306
                .鋼捲編號 = EachItem.ML307
                .鋼種 = EachItem.ML308
                .表面 = EachItem.ML309
                .厚度 = EachItem.ML310
                .寬度 = EachItem.ML311
                .等級 = EachItem.ML312
                .重量 = EachItem.ML313
                .報價單號 = EachItem.ML314
                .貨款 = EachItem.ML315
                .利息 = EachItem.ML316
                .稅額 = EachItem.ML317
                .提貨日 = EachItem.ML318
                .打單日 = EachItem.ML319
                .一級 = EachItem.ML320
                .二級 = EachItem.ML321
                .三級 = EachItem.ML322
                .頭尾 = EachItem.ML323
                .邊料 = EachItem.ML324
                .廢料 = EachItem.ML325
                .一級品金額 = EachItem.BOL21
                .二級品金額 = EachItem.BOL22
                .三級品金額 = EachItem.BOL23
                .頭尾料金額 = EachItem.BOL24
                .邊緣料金額 = EachItem.BOL25
                .廢料金金額 = EachItem.BOL26
            End With
            ReturnValue.Rows.Add(AddRow)
        Next
        Return ReturnValue
    End Function

#End Region
#Region "產生查詢至控製項 函式:MakeQryDataToControl"
    ''' <summary>
    ''' 產生查詢至控製項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryDataToControl()

        If String.IsNullOrEmpty(CurrentLoginUserID) Then
            Response.Write("身份辨示失敗,無法查詢")
            Response.End()
            Exit Sub
        End If
        Dim LogString As New StringBuilder
        Dim LogCanQueryUsers As New StringBuilder
        Dim QryCanUseCustomer As New StringBuilder
        Dim SQLString As New StringBuilder
        Dim AuthorizationTime As DateTime = Now
        SQLString.Append("Select CUA01 from WebLoginAccountToPickGoodDetail Where IsCancellation=0 and WindowLoginName='" & CurrentLoginUserID & "'")
        SQLString.Append(" and '" & Format(AuthorizationTime, "yyyy/MM/dd HH:mm:ss") & "' >= CONVERT(DATE,AuthorizationStartTime) and '" & Format(AuthorizationTime, "yyyy/MM/dd HH:mm:ss") & "' < DATEADD(day,1,CONVERT(DATE,AuthorizationDueTime))")
        If Not String.IsNullOrEmpty(tbCustomers.Text) AndAlso tbCustomers.Text.Trim.Length > 0 Then
            SQLString.Append(" and CUA01 in ('" & tbCustomers.Text.Trim.Replace(",", "','") & "')")
        End If
        Dim QryAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        For Each EachItem As DataRow In QryAdapter.SelectQuery(SQLString.ToString).Rows
            QryCanUseCustomer.Append(IIf(QryCanUseCustomer.Length = 0, "", ",") & EachItem.Item(0))
            LogCanQueryUsers.Append(IIf(String.IsNullOrEmpty(LogCanQueryUsers.ToString), "", ",") & tbCustomerID.Text.Trim)
        Next
        LogCanQueryUsers.Append(IIf(String.IsNullOrEmpty(LogCanQueryUsers.ToString), "", "CanQueryCustomers=" & LogString.ToString))

        SQLString = New StringBuilder
        SQLString.Append("Select * from @#SLS300LB.MAIL03PF.EMAIL Where ML300 in ('" & QryCanUseCustomer.ToString.Replace(",", "','") & "')")
        If cbPickGoodDate.Checked Then
            SQLString.Append(" AND ML318>='" & tbPickGoodStartDate.Text.Trim & "' AND ML318<='" & tbPickGoodEndDate.Text.Trim & "'")
            QryCanUseCustomer.Append(" AND ML318>='" & tbPickGoodStartDate.Text.Trim & "' AND ML318<='" & tbPickGoodEndDate.Text.Trim & "'")
            LogString.Append(IIf(String.IsNullOrEmpty(LogString.ToString), "", "/") & "PickGoodStartDate=" & tbPickGoodStartDate.Text.Trim)
        End If

        If cbTypeOrderDate.Checked Then
            SQLString.Append(" AND ML319>='" & tbTypeOrderStartDate.Text & "' AND ML319<='" & tbTypeOrderEndDate.Text & "'")
            QryCanUseCustomer.Append(" AND ML319>='" & tbTypeOrderStartDate.Text & "' AND ML319<='" & tbTypeOrderEndDate.Text & "'")
            LogString.Append(IIf(String.IsNullOrEmpty(LogString.ToString), "", "/") & "TypeOrderStartDate=" & tbTypeOrderStartDate.Text.Trim)
        End If


        Dim SaveLog As New CompanyORMDB.SQLServer.QCDB01.PickGoodDetailQryLog
        With SaveLog
            .QueryTime = Now
            .LoginUserName = CurrentLoginUserID
            .CanQueryUsers = LogCanQueryUsers.ToString ' QryCanUseCustomer.ToString
            .QueryUsers = tbCustomerID.Text.Trim
            .QueryLog = LogString.ToString
        End With
        If SaveLog.CDBSave() > 0 Then
            hfQueryData.Value = SQLString.ToString
        Else
            hfQueryData.Value = ""
        End If
    End Sub
#End Region

    '授權程式碼編
#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function WebLoginAccountToPickGoodDetailSearch(ByVal QryString As String) As List(Of CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail)
        If String.IsNullOrEmpty(QryString) Then
            Return New List(Of CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail)
        End If
        Return CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01", QryString)
    End Function

#End Region
#Region "授權資料新增 方法:CDBInsert"
    ''' <summary>
    ''' 授權資料新增
    ''' </summary>
    ''' <param name="SourceObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Function CDBInsert(ByVal SourceObject As CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail) As Integer
        SourceObject.AuthorizationTime = Now
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        SourceObject.CUA01 = SourceObject.CUA01.ToUpper
        Return SourceObject.CDBInsert
    End Function
#End Region
#Region "授權資料修改 方法:CDBUpdate"
    ''' <summary>
    ''' 授權資料修改
    ''' </summary>
    ''' <param name="SourceObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        Dim UpdateQuery As String = "Update WebLoginAccountToPickGoodDetail set IsCancellation=1 where WindowLoginName='" & SourceObject.WindowLoginName.Trim & "' and CUA01='" & SourceObject.CUA01 & "' and AuthorizationTime='" & Format(SourceObject.AuthorizationTime, "yyyy/MM/dd HH:mm:ss") & "' "
        SourceObject.SQLQueryAdapterByThisObject.ExecuteNonQuery(UpdateQuery)
        SourceObject.AuthorizationTime = Now
        SourceObject.IsCancellation = False
        Return SourceObject.CDBSave
    End Function
#End Region
#Region "授權資料刪除 方法:CDBDelete"
    ''' <summary>
    ''' 授權資料刪除
    ''' </summary>
    ''' <param name="SourceObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function CDBDelete(ByVal SourceObject As CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        Dim UpdateQuery As String = "Update WebLoginAccountToPickGoodDetail set IsCancellation=1 where WindowLoginName='" & SourceObject.WindowLoginName.Trim & "' and CUA01='" & SourceObject.CUA01 & "' and AuthorizationTime='" & Format(SourceObject.AuthorizationTime, "yyyy/MM/dd HH:mm:ss") & "' "
        Return SourceObject.SQLQueryAdapterByThisObject.ExecuteNonQuery(UpdateQuery)
    End Function
#End Region
#Region "產生查詢至控製項 函式:MakeQryToControl"
    ''' <summary>
    ''' 產生查詢至控製項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryToControl()
        Dim SQLString As New StringBuilder

        SQLString.Append("Select * from WebLoginAccountToPickGoodDetail Where IsCancellation=0 ")
        If Not String.IsNullOrEmpty(tbCustomerID.Text) AndAlso tbCustomerID.Text.Trim.Length > 0 Then
            SQLString.Append(" and CUA01 in ('" & tbCustomerID.Text.Trim.Replace(",", "','") & "')")
        End If
        If Not String.IsNullOrEmpty(tbEmployeeID.Text) AndAlso tbEmployeeID.Text.Trim.Length > 0 Then
            SQLString.Append(" and WindowLoginName in ('" & tbEmployeeID.Text.Trim.Replace(",", "','") & "')")
        End If
        Dim AuthorizationTime As DateTime
        If CheckBox1.Checked AndAlso DateTime.TryParse(tbCanUseAuthorizationTime.Text, AuthorizationTime) Then
            AuthorizationTime = AuthorizationTime.Date
            SQLString.Append(" and '" & AuthorizationTime & "' >= CONVERT(DATE,AuthorizationStartTime) and '" & AuthorizationTime & "' < DATEADD(day,1,CONVERT(DATE,AuthorizationDueTime))")
        End If

        hfQryString.Value = SQLString.ToString
    End Sub
#End Region
#Region "新增資料暫存 屬性:InsertDataTemp"
    ''' <summary>
    ''' 新增資料暫存
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property InsertDataTemp As Dictionary(Of String, String)
        Get
            Dim ReturnValue As New Dictionary(Of String, String)
            If Not IsNothing(Me.ViewState("InsertDataTemp")) Then
                For Each EachItem As String In CType(Me.ViewState("InsertDataTemp"), String).Split(",")
                    ReturnValue.Add(EachItem.Split(":")(0), EachItem.Split(":")(1))
                Next
            End If
            Return ReturnValue
        End Get
        Set(value As Dictionary(Of String, String))
            Dim SetValue As New StringBuilder()
            For Each EachItem As KeyValuePair(Of String, String) In value
                SetValue.Append(EachItem.Key.Trim & ":" & EachItem.Value.Trim)
            Next
            Me.ViewState("InsertDataTemp") = SetValue.ToString
        End Set
    End Property
#End Region

#Region "複製授權 函式:CopyAuthority"
    ''' <summary>
    ''' 複製授權
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CopyAuthority()
        If String.IsNullOrEmpty(CurrentLoginUserID) Then
            lbMessage.Text = "身份辨示失敗,無法授權!"
            Exit Sub
        End If
        Dim CopyAuthorityStartDate As Date
        Dim CopyAuthorityEndDate As Date
        If String.IsNullOrEmpty(tbCopyLoginEmployeeID.Text) OrElse tbCopyLoginEmployeeID.Text.Trim.Length = 0 OrElse _
            String.IsNullOrEmpty(tbCopyToEmployeeID.Text) OrElse tbCopyToEmployeeID.Text.Trim.Length = 0 OrElse _
            String.IsNullOrEmpty(tbCopyStartDate.Text) OrElse tbCopyStartDate.Text.Trim.Length = 0 OrElse Date.TryParse(tbCopyStartDate.Text, CopyAuthorityStartDate) = False OrElse _
            String.IsNullOrEmpty(tbCopyEndDate.Text) OrElse tbCopyEndDate.Text.Trim.Length = 0 OrElse Date.TryParse(tbCopyEndDate.Text, CopyAuthorityEndDate) = False Then
            lbMessage.Text = "授權資料不正確/不完整或日期不正確,無法授權!"
            Exit Sub
        End If

        'Dim IsSuperUser As String = False ' = IIf(SupperAuthorityUsersID.Contains(CurrentLoginUserID) , "TRUE", "FALSE")
        'If Not String.IsNullOrEmpty(tbCopyLoginEmployeeID.Text) AndAlso tbCopyLoginEmployeeID.Text.Trim.Length > 0 Then
        '    IsSuperUser = "TRUE"
        'End If
        Dim SQLString As New StringBuilder
        SQLString.Append("Select * from WebLoginAccountToPickGoodDetail Where IsCancellation=0 and WindowLoginName='" & tbCopyLoginEmployeeID.Text.Trim & "'")
        SQLString.Append(" and '" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "' >= CONVERT(DATE,AuthorizationStartTime) and '" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "' < DATEADD(day,1,CONVERT(DATE,AuthorizationDueTime))")
        If Not String.IsNullOrEmpty(tbCopyCustomerID.Text) And tbCopyCustomerID.Text.Trim.Length > 0 Then
            SQLString.Append(" and CUA01  in ('" & tbCopyCustomerID.Text.Trim.Replace(",", "','") & "')")
        End If
        Dim SearchResut As List(Of CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail) = CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLString.ToString)
        Dim AuthorityCount As Integer = 0
        For Each EachItem In SearchResut
            Dim NewAuthorityItem As New CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail
            With NewAuthorityItem
                .SQLQueryAdapterByThisObject = EachItem.SQLQueryAdapterByThisObject
                .WindowLoginName = tbCopyToEmployeeID.Text.Trim
                .CUA01 = EachItem.CUA01
                .AuthorizationStartTime = CopyAuthorityStartDate
                .AuthorizationDueTime = CopyAuthorityEndDate
                .AuthorizationTime = Now
                AuthorityCount += .CDBSave()
            End With
        Next

        lbMessage.Text = "已完成 " & AuthorityCount & " 筆資料授權!"
    End Sub
#End Region

#Region "取消授權 函式:CancelAuthority"
    ''' <summary>
    ''' 取消授權
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CancelAuthority()
        If String.IsNullOrEmpty(CurrentLoginUserID) Then
            lbMessage.Text = "身份辨示失敗,無法解除授權!"
            Exit Sub
        End If
        Dim CancelAuthorityStartDate As Date
        Dim CancelAuthorityEndDate As Date
        If String.IsNullOrEmpty(tbCancelEmployeeID.Text) OrElse tbCancelEmployeeID.Text.Trim.Length = 0 OrElse _
            String.IsNullOrEmpty(tbCancelStartDate.Text) OrElse tbCancelStartDate.Text.Trim.Length = 0 OrElse Date.TryParse(tbCancelStartDate.Text, CancelAuthorityStartDate) = False OrElse _
            String.IsNullOrEmpty(tbCancelEndDate.Text) OrElse tbCancelEndDate.Text.Trim.Length = 0 OrElse Date.TryParse(tbCancelEndDate.Text, CancelAuthorityEndDate) = False Then
            lbMessage.Text = "授權資料不正確/不完整或日期不正確,無法取消授權!"
            Exit Sub
        End If

        Dim SQLString As New StringBuilder
        SQLString.Append("Select * from WebLoginAccountToPickGoodDetail Where IsCancellation=0 and WindowLoginName='" & tbCancelEmployeeID.Text.Trim & "'")
        SQLString.Append(" and '" & Format(CancelAuthorityStartDate, "yyyy/MM/dd") & "' = AuthorizationStartTime and '" & Format(CancelAuthorityEndDate, "yyyy/MM/dd") & "' = AuthorizationDueTime")
        If Not String.IsNullOrEmpty(tbCancelCustomerID.Text) And tbCancelCustomerID.Text.Trim.Length > 0 Then
            SQLString.Append(" and CUA01  in ('" & tbCancelCustomerID.Text.Trim.Replace(",", "','") & "')")
        End If
        Dim SearchResut As List(Of CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail) = CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.WebLoginAccountToPickGoodDetail)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLString.ToString)
        Dim CancelAuthorityCount As Integer = 0
        For Each EachItem In SearchResut
            With EachItem
                .IsCancellation = True
                CancelAuthorityCount += .CDBSave()
            End With
        Next
        lbMessage.Text = "已取消 " & CancelAuthorityCount & " 筆資料授權!"

    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbCanUseAuthorizationTime.Text = Format(Now, "yyyy/MM/dd")
            tbPickGoodStartDate.Text = New CompanyORMDB.AS400DateConverter(Now.AddMonths(-3)).TwSevenCharsTypeData
            tbPickGoodEndDate.Text = New CompanyORMDB.AS400DateConverter(Now).TwSevenCharsTypeData
            tbTypeOrderStartDate.Text = New CompanyORMDB.AS400DateConverter(Now.AddMonths(-3)).TwSevenCharsTypeData
            tbTypeOrderEndDate.Text = New CompanyORMDB.AS400DateConverter(Now).TwSevenCharsTypeData
            tbCopyLoginEmployeeID.Text = Me.CurrentLoginUserID
            tbCopyLoginEmployeeID.Enabled = SupperAuthorityUsersID.Contains(CurrentLoginUserID)
            'btnCancelAuthority.Enabled = SupperAuthorityUsersID.Contains(CurrentLoginUserID)

            '超級使用者授權判斷
            btnCancelAuthority.Enabled = SupperAuthorityUsersID.Contains(Me.CurrentLoginUserID)
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        hfQryString.Value = Nothing
        hfQueryData.Value = Nothing
        MakeQryToControl()
        ListView1.DataBind()
    End Sub

    Private Sub ListView1_ItemInserting(sender As Object, e As ListViewInsertEventArgs) Handles ListView1.ItemInserting
        If Not TabContainer1.ActiveTab Is TabPanel2 Then
            Exit Sub
        End If
        Dim KeepValue As New Dictionary(Of String, String)
        KeepValue.Add("WindowLoginName", e.Values("WindowLoginName"))
        KeepValue.Add("CUA01", e.Values("CUA01"))
        KeepValue.Add("AuthorizationStartTime", e.Values("AuthorizationStartTime"))
        KeepValue.Add("AuthorizationDueTime", e.Values("AuthorizationDueTime"))
        InsertDataTemp = KeepValue
    End Sub

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        If Not TabContainer1.ActiveTab Is TabPanel2 Then
            Exit Sub
        End If
        If InsertDataTemp.Count >= 4 Then
            CType(ListView1.InsertItem.FindControl("WindowLoginNameTextBox"), TextBox).Text = InsertDataTemp.Item("WindowLoginName")
            CType(ListView1.InsertItem.FindControl("CUA01TextBox"), TextBox).Text = InsertDataTemp.Item("CUA01")
            CType(ListView1.InsertItem.FindControl("AuthorizationStartTimeTextBox"), TextBox).Text = InsertDataTemp.Item("AuthorizationStartTime")
            CType(ListView1.InsertItem.FindControl("AuthorizationDueTimeTextBox"), TextBox).Text = InsertDataTemp.Item("AuthorizationDueTime")
        Else
            CType(ListView1.InsertItem.FindControl("AuthorizationStartTimeTextBox"), TextBox).Text = Format(Now.AddDays(1), "yyyy/MM/dd")
            CType(ListView1.InsertItem.FindControl("AuthorizationDueTimeTextBox"), TextBox).Text = Format(Now.AddDays(1), "yyyy/MM/dd")
        End If

        '超級使用者授權判斷
        If Not SupperAuthorityUsersID.Contains(Me.CurrentLoginUserID) Then
            ListView1.InsertItem.Visible = False
            For Each EachItem In ListView1.Items
                If Not IsNothing(EachItem.FindControl("DeleteButton")) Then
                    CType(EachItem.FindControl("DeleteButton"), Button).Enabled = False
                End If
                If Not IsNothing(EachItem.FindControl("EditButton")) Then
                    CType(EachItem.FindControl("EditButton"), Button).Enabled = False
                End If
            Next
        Else
            ListView1.InsertItem.Visible = True
            For Each EachItem In ListView1.Items
                If Not IsNothing(EachItem.FindControl("DeleteButton")) Then
                    CType(EachItem.FindControl("DeleteButton"), Button).Enabled = True
                End If
                If Not IsNothing(EachItem.FindControl("EditButton")) Then
                    CType(EachItem.FindControl("EditButton"), Button).Enabled = True
                End If
            Next

        End If
    End Sub

    Protected Sub btnSearchData_Click(sender As Object, e As EventArgs) Handles btnSearchData.Click
        hfQryString.Value = Nothing
        hfQueryData.Value = Nothing
        MakeQryDataToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchDataToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchDataToExcel.Click
        hfQryString.Value = Nothing
        hfQueryData.Value = Nothing
        MakeQryDataToControl()
        Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(SearchData(hfQueryData.Value), "客戶提貨明細對帳資料" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

    Protected Sub btnAuthority_Click(sender As Object, e As EventArgs) Handles btnAuthority.Click
        CopyAuthority()
    End Sub

    Protected Sub btnCancelAuthority_Click(sender As Object, e As EventArgs) Handles btnCancelAuthority.Click
        CancelAuthority()
    End Sub

    Protected Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class