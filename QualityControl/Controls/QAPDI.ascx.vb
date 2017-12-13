Public Class QAPDI
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As List(Of CompanyORMDB.SQLServer.PPS100LB.PDI)
        Dim ReturnValue As New List(Of CompanyORMDB.SQLServer.PPS100LB.PDI)
        If String.IsNullOrEmpty(SQLString) OrElse SQLString.Trim.Length = 0 Then
            Return ReturnValue
        End If
        ReturnValue = CompanyORMDB.SQLServer.PPS100LB.PDI.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.PDI)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLString)
        Return ReturnValue
    End Function
#End Region
#Region "新增 方法:CDBInsert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Function CDBInsert(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.PDI) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        Dim ReturnValue As Integer = SourceObject.CDBInsert()
        If ReturnValue > 0 Then
            ReSortSeparateNameAndSave(SourceObject.CoilFullNumber, SourceObject.RunLineName, SourceObject.CreateMsgTime)
        End If
        Return ReturnValue
    End Function

#End Region
#Region "刪除 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function CDBDelete(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.PDI) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        Dim ReturnValue As Integer = SourceObject.CDBDelete()
        If ReturnValue > 0 Then
            ReSortSeparateNameAndSave(SourceObject.CoilFullNumber, SourceObject.RunLineName, SourceObject.CreateMsgTime)
        End If
        Return ReturnValue
    End Function
#End Region
#Region "修改 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.PDI) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        Dim ReturnValue As Integer = SourceObject.CDBUpdate()
        If ReturnValue > 0 Then
            ReSortSeparateNameAndSave(SourceObject.CoilFullNumber, SourceObject.RunLineName, SourceObject.CreateMsgTime)
        End If
        Return ReturnValue
    End Function
#End Region
#Region "重整並儲存分捲號碼 函式:ReSortSeparateNameAndSave"
    ''' <summary>
    ''' 重整並儲存分捲號碼
    ''' </summary>
    ''' <param name="CoilFullNumber"></param>
    ''' <param name="SetLineName"></param>
    ''' <param name="DataDate"></param>
    ''' <remarks></remarks>
    Private Shared Sub ReSortSeparateNameAndSave(ByVal CoilFullNumber As String, ByVal SetLineName As String, ByVal DataDate As Date)
        Dim Qry As String = "Select * from PDI WHERE MsgType=1 and CoilFullNumber='" & CoilFullNumber & "' and RunLineName='" & SetLineName & "' and CreateMsgTime>='" & Format(DataDate.AddYears(-3), "yyyy/MM/dd") & "' and CreateMsgTime<='" & Format(DataDate.AddYears(1), "yyyy/MM/dd") & "' Order by QASeparateName ASC, CreateMsgTime DESC "
        Dim SearchResult As List(Of CompanyORMDB.SQLServer.PPS100LB.PDI) = CompanyORMDB.SQLServer.PPS100LB.PDI.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.PDI)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, Qry)
        If SearchResult.Count = 1 Then
            SearchResult(0).QASeparateName = ""
            SearchResult(0).CDBSave()
            Exit Sub
        End If
        Dim Setchar As Char = "A"
        For Each EachItem As CompanyORMDB.SQLServer.PPS100LB.PDI In SearchResult
            EachItem.QASeparateName = Setchar
            EachItem.CDBSave()
            Setchar = ChrW(AscW(Setchar) + 1)
        Next
    End Sub
#End Region
#Region "取得鋼捲號碼之預計下捲分捲號碼 方法:GetNextBreakCoilChar"
    ''' <summary>
    ''' 取得鋼捲號碼之預計下捲分捲號碼
    ''' </summary>
    ''' <param name="FindCoilNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNextBreakCoilChar(ByVal FindCoilNumber As String, ByVal LineName As String) As String
        If String.IsNullOrEmpty(FindCoilNumber) Then
            Return "A"
        End If
        Dim SearchDate As DateTime = Now.AddYears(-3)
        Dim Qry As String = "Select * from PDI WHERE MsgType=1 and CoilFullNumber='" & FindCoilNumber & "' and RunLineName='" & LineName & "' and CreateMsgTime>='" & Format(SearchDate, "yyyy/MM/dd") & "' Order by QASeparateName Desc"
        Dim SearchResult As List(Of CompanyORMDB.SQLServer.PPS100LB.PDI) = CompanyORMDB.SQLServer.PPS100LB.PDI.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.PDI)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, Qry)
        If SearchResult.Count = 0 Then
            Return "A"
        End If
        For Each EachItem As CompanyORMDB.SQLServer.PPS100LB.PDI In SearchResult
            If Not String.IsNullOrEmpty(EachItem.QASeparateName) Then
                Dim Getchar As Char = EachItem.QASeparateName
                If Trim(Getchar) = "" Then
                    Getchar = "A"
                End If
                Getchar = ChrW(AscW(Getchar) + 1)
                Return Getchar
            End If
        Next
        Return "A"
    End Function
#End Region

#Region "最後新增之鋼捲資料 屬性:LastInsertCoilDatas"
    ''' <summary>
    ''' 最後新增之鋼捲資料s
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LastInsertCoilDatas() As String
        Get
            Return Me.ViewState("_LastInsertCoilDatas")
        End Get
        Set(ByVal value As String)
            Me.ViewState("_LastInsertCoilDatas") = value
        End Set
    End Property

#End Region

#Region "控制項SQL條件產生器 方法:SQLMakerToControl"
    ''' <summary>
    ''' 控制項SQL條件產生器
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SQLMakerToControl()
        Dim ReturnValue As String = "Select * from PDI WHERE CreateMsgDept='QA' AND MsgType=1 and CreateMsgTime>='" & Me.tbStartDate.Text.Trim & "' and CreateMsgTime<'" & CType(Me.tbEndDate.Text.Trim, Date).AddDays(1) & "' "
        If Not String.IsNullOrEmpty(tbCoilNumbers.Text) AndAlso tbCoilNumbers.Text.Trim.Length > 0 Then
            ReturnValue &= " and CoilFullNumber in ('" & tbCoilNumbers.Text.ToUpper.Replace(",", "','") & "')"
        End If

        Dim StartTime As DateTime = New DateTime(Me.tbStartDate.Text.Split("/")(0), Me.tbStartDate.Text.Split("/")(1), Me.tbStartDate.Text.Split("/")(2))
        StartTime = StartTime.AddHours(Me.tbStartTime.Text.Substring(0, 2)).AddMinutes(Me.tbStartTime.Text.Substring(2, 2))
        Dim EndTime As DateTime = New DateTime(Me.tbEndDate.Text.Split("/")(0), Me.tbEndDate.Text.Split("/")(1), Me.tbEndDate.Text.Split("/")(2))
        EndTime = EndTime.AddHours(Me.tbEndTime.Text.Substring(0, 2)).AddMinutes(Me.tbStartTime.Text.Substring(2, 2))
        ReturnValue &= " and CreateMsgTime>='" & Format(StartTime, "yyyy/MM/dd HH:mm:ss") & "' "
        ReturnValue &= " and CreateMsgTime<='" & Format(EndTime, "yyyy/MM/dd HH:mm:ss") & "' "

        Me.hfQry.Value = ReturnValue & " order by CoilFullNumber,CreateMsgTime"
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now.AddMonths(-6), "yyyy/MM/01")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        SQLMakerToControl()
        ListView1.DataBind()
    End Sub

    Private Sub ListView1_ItemCommand(sender As Object, e As ListViewCommandEventArgs) Handles ListView1.ItemCommand
        If e.CommandName = "CopyInsert" Then
            CType(ListView1.InsertItem.FindControl("CoilFullNumberTextBox"), TextBox).Text = CType(e.Item.FindControl("CoilFullNumberLabel"), Label).Text.ToUpper
            CType(ListView1.InsertItem.FindControl("CoilThickTextBox"), TextBox).Text = CType(e.Item.FindControl("CoilThickLabel"), Label).Text
            CType(ListView1.InsertItem.FindControl("QASeparateNameTextBox"), TextBox).Text = GetNextBreakCoilChar(CType(e.Item.FindControl("CoilFullNumberLabel"), Label).Text.ToUpper, CType(e.Item.FindControl("RunLineNameLabel"), Label).Text.ToUpper)
            CType(ListView1.InsertItem.FindControl("CoilWidthTextBox"), TextBox).Text = CType(e.Item.FindControl("CoilWidthLabel"), Label).Text
            CType(ListView1.InsertItem.FindControl("CoilLengthTextBox"), TextBox).Text = CType(e.Item.FindControl("CoilLengthLabel"), Label).Text
        End If
    End Sub

    Private Sub ListView1_ItemInserted(sender As Object, e As ListViewInsertedEventArgs) Handles ListView1.ItemInserted
        If e.Values.Count > 0 Then
            Dim InsertDatas As New StringBuilder
            If Not String.IsNullOrEmpty(e.Values("CoilFullNumber")) Then
                InsertDatas.Append(CType(e.Values("CoilFullNumber"), String).Replace(",", Nothing) & ",")
            Else
                InsertDatas.Append(",")
            End If
            If Not String.IsNullOrEmpty(e.Values("CoilThick")) Then
                InsertDatas.Append(CType(e.Values("CoilThick"), String).Replace(",", Nothing) & ",")
            Else
                InsertDatas.Append(",")
            End If
            If Not String.IsNullOrEmpty(e.Values("CoilWidth")) Then
                InsertDatas.Append(CType(e.Values("CoilWidth"), String).Replace(",", Nothing) & ",")
            Else
                InsertDatas.Append(",")
            End If
            InsertDatas.Append(CType(e.Values("RunLineName"), String).Replace(",", Nothing))

            LastInsertCoilDatas = InsertDatas.ToString
            Me.hfQry.Value = "Select * from PDI WHERE CreateMsgDept='QA' AND MsgType=1 and CreateMsgTime>='" & Me.tbStartDate.Text.Trim & "' and CreateMsgTime<'" & CType(Me.tbEndDate.Text.Trim, Date).AddDays(1) & "' "
            Me.hfQry.Value &= " and CoilFullNumber = '" & LastInsertCoilDatas.Split(",")(0).ToUpper & "' and RunLineName='" & CType(e.Values("RunLineName"), String) & "'" & " order by CoilFullNumber,QASeparateName,CreateMsgTime"
            Me.ListView1.DataBind()
        End If
    End Sub

    Private Sub ListView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewInsertEventArgs) Handles ListView1.ItemInserting
        e.Values("CoilFullNumber") = e.Values("CoilFullNumber").ToString.Trim.ToUpper
        If Not IsNothing(e.Values("QASeparateName")) Then
            e.Values("QASeparateName") = e.Values("QASeparateName").ToString.Trim.ToUpper
        End If
        e.Values("CreateMsgDept") = "QA"
        e.Values("CreateMsgTime") = Format(Now, "yyyy/MM/dd HH:mm:ss")
        e.Values("MsgType") = 1
        e.Values("MsgTypeName") = "成品線作業規定"
        'e.Values("RunLineName") = CType(ListView1.InsertItem.FindControl("ddlQARunLineName"), DropDownList).SelectedValue
    End Sub


    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        e.NewValues("CoilFullNumber") = e.NewValues("CoilFullNumber").ToString.Trim.ToUpper
        If Not IsNothing(e.NewValues("QASeparateName")) Then
            e.NewValues("QASeparateName") = e.NewValues("QASeparateName").ToString.Trim.ToUpper
        End If
        'e.NewValues("RunLineName") = CType(ListView1.EditItem.FindControl("ddlQARunLineName"), DropDownList).SelectedValue
    End Sub

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        If Not String.IsNullOrEmpty(Me.LastInsertCoilDatas) AndAlso Me.LastInsertCoilDatas.Trim.Length > 0 AndAlso CType(LastInsertCoilDatas.Split(",")(3), String) <> "SPL1" Then
            CType(ListView1.InsertItem.FindControl("CoilFullNumberTextBox"), TextBox).Text = LastInsertCoilDatas.Split(",")(0)
            CType(ListView1.InsertItem.FindControl("CoilThickTextBox"), TextBox).Text = LastInsertCoilDatas.Split(",")(1)
            CType(ListView1.InsertItem.FindControl("QASeparateNameTextBox"), TextBox).Text = GetNextBreakCoilChar(LastInsertCoilDatas.Split(",")(0), LastInsertCoilDatas.Split(",")(3))
            CType(ListView1.InsertItem.FindControl("CoilWidthTextBox"), TextBox).Text = CType(LastInsertCoilDatas.Split(",")(2), String)
            CType(ListView1.InsertItem.FindControl("ddlQARunLineName"), DropDownList).SelectedValue = CType(LastInsertCoilDatas.Split(",")(3), String)
        End If
    End Sub

    Public Sub InsertCustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim SenderControl As CustomValidator = source
        SenderControl.ErrorMessage = ""
        Dim GetCoilNumber As String = CType(Me.ListView1.InsertItem.FindControl("CoilFullNumberTextBox"), TextBox).Text
        Select Case True
            Case String.IsNullOrEmpty(GetCoilNumber)
                SenderControl.ErrorMessage = "鋼捲編號不可為空白!"
            Case GetCoilNumber.Trim.Length < 5 OrElse GetCoilNumber.Trim.Length > 10
                SenderControl.ErrorMessage = "鋼捲編號輸入錯誤(5~10位)!"
        End Select
        args.IsValid = String.IsNullOrEmpty(SenderControl.ErrorMessage)
    End Sub


    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Me.hfQry.Value = "Select * from PDI WHERE 1=0"
        'Me.ListView1.DataBind()
        tbStartTime.Text = "0000"
        tbEndTime.Text = "2400"
        tbCoilNumbers.Text = Nothing
    End Sub
End Class