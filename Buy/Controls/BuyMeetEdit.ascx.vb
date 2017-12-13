Public Class BuyMeetEdit
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As List(Of CompanyORMDB.MTS600LB.MTSBC1PF)
        If String.IsNullOrEmpty(SQLString) Then
            Return New List(Of CompanyORMDB.MTS600LB.MTSBC1PF)
        End If
        Return CompanyORMDB.MTS600LB.MTSBC1PF.CDBSelect(Of CompanyORMDB.MTS600LB.MTSBC1PF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function
#End Region
#Region "新增 方法:CDBInsert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Function CDBInsert(ByVal SourceObject As CompanyORMDB.MTS600LB.MTSBC1PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBInsert()
    End Function
#End Region
#Region "刪除 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function CDBDelete(ByVal SourceObject As CompanyORMDB.MTS600LB.MTSBC1PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBDelete()
    End Function
#End Region
#Region "修改 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As CompanyORMDB.MTS600LB.MTSBC1PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBUpdate()
    End Function
#End Region

#Region "使用者登入帳號 屬性:WindowsLoginEmployeeNumber"
    ''' <summary>
    ''' 使用者登入帳號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WindowsLoginEmployeeNumber As String
        Get
            Return WebAppAuthority.ValidAuthorityModule.CurrentWindowsLoginEmployeeNumber
        End Get
    End Property
#End Region

#Region "產生查詢至控制項 方法:MakerQryToControl"
    ''' <summary>
    ''' 產生查詢至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakerQryToControl()
        Dim ReturnValue As String = "Select * FROM @#MTS600LB.MTSBC1PF WHERE 1=1 "

        If CheckBox1.Checked Then
            ReturnValue &= " AND MTSB02='" & tbMeetDate.Text.Trim.Replace("'", Nothing) & "'"
        End If
        If Not String.IsNullOrEmpty(tbEmployeeID.Text) AndAlso tbEmployeeID.Text.Trim.Length > 0 Then
            ReturnValue &= " AND MTSB08='" & tbEmployeeID.Text.Trim.Replace("'", Nothing) & "'"
        End If

        If RadioButtonList1.SelectedValue <> "ALL" Then
            ReturnValue &= " AND MTSB05 =" & RadioButtonList1.SelectedValue
        End If

        Me.hfQrystring.Value = ReturnValue & " ORDER BY MTSB02,MTSB03,MTSB06"
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbMeetDate.Text = (Val(Format(Now, "yyyy")) - 1911) & Format(Now, "MMdd")
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakerQryToControl()
        ListView1.DataBind()
    End Sub

    Private Sub ListView1_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles ListView1.ItemDataBound
        Dim EditUserCotrol As HiddenField = e.Item.FindControl("hfMTSB08")
        If IsNothing(EditUserCotrol) OrElse String.IsNullOrEmpty(EditUserCotrol.Value) OrElse EditUserCotrol.Value.Trim.Length = 0 Then
            Exit Sub
        End If

        Dim DeleteButton As Button = e.Item.FindControl("DeleteButton")
        If Not IsNothing(DeleteButton) Then
            DeleteButton.Enabled = (EditUserCotrol.Value.Trim = WindowsLoginEmployeeNumber.Trim)
        End If

        Dim EditButton As Button = e.Item.FindControl("EditButton")
        If Not IsNothing(EditButton) Then
            EditButton.Enabled = (EditUserCotrol.Value.Trim = WindowsLoginEmployeeNumber.Trim)
        End If

    End Sub

    Private Sub ListView1_PreRender(sender As Object, e As System.EventArgs) Handles ListView1.PreRender

        Dim MeetDateControl As TextBox = ListView1.InsertItem.FindControl("MTSB01TextBox")
        If Not IsNothing(MeetDateControl) AndAlso String.IsNullOrEmpty(MeetDateControl.Text) OrElse MeetDateControl.Text.Trim.Length = 0 Then
            MeetDateControl.Text = Format(Now, "yyyyMMddHHmmss")
        End If

        MeetDateControl = ListView1.InsertItem.FindControl("MTSB02TextBox")
        If Not IsNothing(MeetDateControl) AndAlso String.IsNullOrEmpty(MeetDateControl.Text) OrElse MeetDateControl.Text.Trim.Length = 0 Then
            If Now > Now.Date.AddHours(9) Then
                MeetDateControl.Text = (Val(Format(Now.AddDays(2), "yyyy")) - 1911) & Format(Now.AddDays(2), "MMdd")
            Else
                MeetDateControl.Text = (Val(Format(Now, "yyyy")) - 1911) & Format(Now, "MMdd")
            End If
        End If

        MeetDateControl = ListView1.InsertItem.FindControl("MTSB03TextBox")
        If Not IsNothing(MeetDateControl) AndAlso String.IsNullOrEmpty(MeetDateControl.Text) OrElse MeetDateControl.Text.Trim.Length = 0 Then
            MeetDateControl.Text = "1400"
        End If

        MeetDateControl = ListView1.InsertItem.FindControl("MTSB04TextBox")
        If Not IsNothing(MeetDateControl) AndAlso String.IsNullOrEmpty(MeetDateControl.Text) OrElse MeetDateControl.Text.Trim.Length = 0 Then
            MeetDateControl.Text = "1500"
        End If

        Dim EditUserCotrol As HiddenField = ListView1.InsertItem.FindControl("hfMTSB08")
        If Not IsNothing(EditUserCotrol) Then
            EditUserCotrol.Value = WindowsLoginEmployeeNumber
        End If
        If Not IsNothing(ListView1.EditItem) AndAlso Not IsNothing(ListView1.EditItem.FindControl("hfMTSB08")) Then
            EditUserCotrol = ListView1.EditItem.FindControl("hfMTSB08")
            EditUserCotrol.Value = WindowsLoginEmployeeNumber
        End If

    End Sub


    Public Sub InsertCustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim SenderControl As CustomValidator = source
        Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        SenderControl.ErrorMessage = ""
        Dim DateInputControl As TextBox
        If Not IsNothing(Me.ListView1.EditItem) Then
            '驗證更新部份
            DateInputControl = Me.ListView1.EditItem.FindControl("MTSB02TextBox")
            Dim ControlDate As Date
            Dim IsConvertError As Boolean = False
            Try
                ControlDate = New CompanyORMDB.AS400DateConverter(Integer.Parse(DateInputControl.Text)).DateValue
            Catch ex As Exception
                IsConvertError = True
            End Try
            Select Case True
                Case IsConvertError
                    SenderControl.ErrorMessage = "日期欄位日期輸入有誤請重新檢查是否為民國年數字ex:1000701!"
                Case String.IsNullOrEmpty(DateInputControl.Text)
                    SenderControl.ErrorMessage = "日期欄位不可為空白!"
                Case DateInputControl.Text.Trim.Length < 7
                    SenderControl.ErrorMessage = "日期格式必須為民國年數字七位(含)以上!"
                Case ControlDate < Now.Date
                    SenderControl.ErrorMessage = "日期欄位不可為過期日期!"
                Case Now > Now.Date.AddHours(9) AndAlso ControlDate < Now.Date.AddDays(2)
                    SenderControl.ErrorMessage = "今天已過上午9點,日期欄位必須為後天日期!"
            End Select

            Dim MTSB01Control As TextBox = Me.ListView1.EditItem.FindControl("MTSB01TextBox")
            Dim MTSB03Control As TextBox = Me.ListView1.EditItem.FindControl("MTSB03TextBox")
            Dim MTSB04Control As TextBox = Me.ListView1.EditItem.FindControl("MTSB04TextBox")
            Dim MTSB06Control As DropDownList = Me.ListView1.EditItem.FindControl("DropDownList2")
            Dim SQLQry As String = "Select COUNT(*) from @#MTS600LB.MTSBC1PF WHERE MTSB02='" & DateInputControl.Text.Trim & "' AND MTSB01<>'" & MTSB01Control.Text.Trim & "' "
            SQLQry &= " AND ( ('" & MTSB03Control.Text.Trim & "' > MTSB03 AND '" & MTSB03Control.Text.Trim & "'< MTSB04) OR ('" & MTSB04Control.Text.Trim & "' > MTSB03 AND '" & MTSB04Control.Text.Trim & "'< MTSB04)"
            SQLQry &= " OR ('" & MTSB03Control.Text.Trim & "' < MTSB03 AND '" & MTSB04Control.Text.Trim & "' > MTSB04 ) OR  ('" & MTSB03Control.Text.Trim & "' >= MTSB03 AND '" & MTSB04Control.Text.Trim & "' <= MTSB04 )  )"
            SQLQry &= " AND MTSB06=" & MTSB06Control.SelectedValue
            If Val(AS400Adapter.SelectQuery(SQLQry).Rows(0).Item(0)) > 0 Then
                SenderControl.ErrorMessage = "此時段已有人預約了!"
            End If

        Else
            '驗證新增部份
            DateInputControl = Me.ListView1.InsertItem.FindControl("MTSB02TextBox")
            Dim ControlDate As Date
            Dim IsConvertError As Boolean = False
            Try
                ControlDate = New CompanyORMDB.AS400DateConverter(Integer.Parse(DateInputControl.Text)).DateValue
            Catch ex As Exception
                IsConvertError = True
            End Try
            Select Case True
                Case IsConvertError
                    SenderControl.ErrorMessage = "日期欄位日期輸入有誤請重新檢查是否為民國年數字ex:1000701!"
                Case String.IsNullOrEmpty(DateInputControl.Text)
                    SenderControl.ErrorMessage = "日期欄位不可為空白!"
                Case DateInputControl.Text.Trim.Length < 7
                    SenderControl.ErrorMessage = "日期格式必須為民國年數字七位(含)以上!"
                Case ControlDate < Now.Date
                    SenderControl.ErrorMessage = "日期欄位不可為過期日期!"
                Case Now > Now.Date.AddHours(9) AndAlso ControlDate < Now.Date.AddDays(2)
                    SenderControl.ErrorMessage = "今天已過上午9點,日期欄位必須為後天日期!"
            End Select

            Dim MTSB01Control As TextBox = Me.ListView1.InsertItem.FindControl("MTSB01TextBox")
            Dim MTSB03Control As TextBox = Me.ListView1.InsertItem.FindControl("MTSB03TextBox")
            Dim MTSB04Control As TextBox = Me.ListView1.InsertItem.FindControl("MTSB04TextBox")
            Dim MTSB06Control As DropDownList = Me.ListView1.InsertItem.FindControl("DropDownList2")
            Dim SQLQry As String = "Select COUNT(*) from @#MTS600LB.MTSBC1PF WHERE MTSB02='" & DateInputControl.Text.Trim & "' AND MTSB01<>'" & MTSB01Control.Text.Trim & "' "
            SQLQry &= " AND ( ('" & MTSB03Control.Text.Trim & "' > MTSB03 AND '" & MTSB03Control.Text.Trim & "'< MTSB04) OR ('" & MTSB04Control.Text.Trim & "' > MTSB03 AND '" & MTSB04Control.Text.Trim & "'< MTSB04)"
            SQLQry &= " OR ('" & MTSB03Control.Text.Trim & "' < MTSB03 AND '" & MTSB04Control.Text.Trim & "' > MTSB04 ) OR  ('" & MTSB03Control.Text.Trim & "' >= MTSB03 AND '" & MTSB04Control.Text.Trim & "' <= MTSB04 )  )"
            SQLQry &= " AND MTSB06=" & MTSB06Control.SelectedValue
            If Val(AS400Adapter.SelectQuery(SQLQry).Rows(0).Item(0)) > 0 Then
                SenderControl.ErrorMessage = "此時段已有人預約了!"
            End If

        End If



        args.IsValid = String.IsNullOrEmpty(SenderControl.ErrorMessage)
    End Sub


End Class