Public Class CCClearAndArgEdit
    Inherits System.Web.UI.UserControl

#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As List(Of CompanyORMDB.SMS100LB.SMSREGPF)
        Dim ReturnValue As New List(Of CompanyORMDB.SMS100LB.SMSREGPF)
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If

        Dim DBAdapter = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        ReturnValue = CompanyORMDB.SMS100LB.SMSREGPF.CDBSelect(Of CompanyORMDB.SMS100LB.SMSREGPF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return ReturnValue
    End Function
#End Region

#Region "新增 方法:CDBInsert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Function CDBInsert(ByVal SourceObject As CompanyORMDB.SMS100LB.SMSREGPF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim ReturnValue As Integer = SourceObject.CDBInsert()
        Return ReturnValue
    End Function
#End Region
#Region "刪除 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function CDBDelete(ByVal SourceObject As CompanyORMDB.SMS100LB.SMSREGPF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBDelete()
    End Function
#End Region
#Region "修改 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As CompanyORMDB.SMS100LB.SMSREGPF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBUpdate
    End Function
#End Region

#Region "產生查詢指令至控制項 函式:MakeQryToControl"
    ''' <summary>
    ''' 產生查詢指令至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryToControl()
        Dim QueryString As String = "SELECT A.* FROM @#SMS100LB.SMSREGPF A  WHERE 1=1 "

        If CheckBox1.Checked Then
            Dim StartDateValue As Integer = New CompanyORMDB.AS400DateConverter(tbStartDate.Text).TwIntegerTypeData
            Dim EndDateValue As Integer = New CompanyORMDB.AS400DateConverter(tbEndDate.Text).TwIntegerTypeData
            QueryString &= " AND A.T1 >= " & StartDateValue & " AND A.T1 <= " & EndDateValue
        End If
        If Not String.IsNullOrEmpty(tbStoveNumber.Text) AndAlso tbStoveNumber.Text.Trim.Length > 0 Then
            Dim AddQryString As String = Nothing
            For Each EachItem As String In tbStoveNumber.Text.Split(",")
                AddQryString &= IIf(String.IsNullOrEmpty(AddQryString), Nothing, " OR ")
                If EachItem.Contains("~") Then
                    AddQryString &= " (A.T2 >='" & EachItem.ToUpper.Split("~")(0) & "' AND A.T2<='" & EachItem.ToUpper.Split("~")(1) & "')"
                Else
                    AddQryString &= " A.T2 = '" & EachItem.ToUpper & "'"
                End If
            Next
            QueryString &= " AND (" & AddQryString & " ) "
        End If

        QueryString &= " Order by A.T1,A.T25,A.T2"

        Me.hfQry.Value = QueryString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now, "yyyy/MM/01")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        'ListView1.EnableModelValidation = False
        MakeQryToControl()
        Dim ReturnValue As New StockStatic.DisplayDataSet.CCClearAndArgEditDataTable
        For Each EachItem As CompanyORMDB.SMS100LB.SMSREGPF In Search(Me.hfQry.Value)
            Dim AddItem As StockStatic.DisplayDataSet.CCClearAndArgEditRow = ReturnValue.NewRow
            With AddItem
                .澆鑄日期 = EachItem.T1
                .起鑄時分 = EachItem.T25
                .連鑄 = EachItem.T26
                .爐號 = EachItem.T2
                .鋼種 = EachItem.T41
                .寬度 = EachItem.T42
                .AOD出鋼量 = EachItem.T31
                .澆鑄粉 = EachItem.T3_Descript
                .澆鑄粉用量 = EachItem.T32
                .模溢位波動 = EachItem.T33_Descript
                .分鋼槽塗覆 = EachItem.T4_Descript
                .模液位控制 = EachItem.T5_Descript
                .澆鑄管 = EachItem.T6_Descript
                .澆鑄速度 = EachItem.T7_Descript
                .氣罩 = EachItem.T8_Descript
                .冷卻水量 = EachItem.T9_Descript
                .攪拌時間 = EachItem.T10
                .靜置時間 = EachItem.T11
                .交接爐TUNDISH重量 = EachItem.T12
                .攪拌狀況 = EachItem.T13_Descript
                .渣流動性 = EachItem.T14_Descript
                .攪拌強度 = EachItem.T15_Descript
                .分鋼槽溫度1 = EachItem.T16
                .分鋼槽溫度2 = EachItem.T17
                .分鋼槽溫度3 = EachItem.T18
                .吹氧次數 = EachItem.T19
                .分鋼槽內容積 = EachItem.T20_Descript
                .班別 = EachItem.T21
                .輪班時間 = EachItem.T22_Descript
                .澆鑄管品名 = EachItem.T23
                .氣罩品名 = EachItem.T24
                .投料 = EachItem.T27_Descript
                .AOD出鋼渣量 = EachItem.T34
                .分鋼槽連鑄完剩餘重量 = EachItem.T35
                .氣罩內壁夾鐵 = EachItem.T36
                .台車編號 = EachItem.T37
                .氣罩頸部最大直徑 = EachItem.T40
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(ReturnValue, "鋼液清淨及製程參數查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

    Private Sub ListView1_ItemEditing(sender As Object, e As System.Web.UI.WebControls.ListViewEditEventArgs) Handles ListView1.ItemEditing
        ListView1.EnableModelValidation = False
    End Sub

    'Private Sub ListView1_ItemInserted(sender As Object, e As System.Web.UI.WebControls.ListViewInsertedEventArgs) Handles ListView1.ItemInserted
    '    ListView1.EnableModelValidation = False
    'End Sub

    Private Sub ListView1_PreRender(sender As Object, e As System.EventArgs) Handles ListView1.PreRender
        Dim ControlObject As TextBox = ListView1.InsertItem.FindControl("T1TextBox")
        If String.IsNullOrEmpty(ControlObject.Text) Then
            'ControlObject.Text = (Val(Format(Now, "yyyy")) - 1911) * 10000 + Val(Format(Now, "MMdd"))
            ControlObject.Text = Format(Now, "yyyy/MM/dd")
        End If

        ControlObject = ListView1.InsertItem.FindControl("TextBox11")
        If String.IsNullOrEmpty(ControlObject.Text) Then
            ControlObject.Text = Format(Now, "ddHHmm")
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakeQryToControl()
        ListView1.DataBind()
    End Sub

    Public Sub CustomValidator1_ServerValidate(source As Object, args As System.Web.UI.WebControls.ServerValidateEventArgs) 'Handles CustomValidator1.ServerValidate
        Dim ValidatorControl As CustomValidator = ListView1.InsertItem.FindControl("CustomValidator1")

        Dim StoveNumber As String = CType(ListView1.InsertItem.FindControl("T2TextBox"), TextBox).Text.Trim.ToUpper
        ValidatorControl.ErrorMessage = String.Empty
        If StoveNumber.Length <> 5 Then
            ValidatorControl.ErrorMessage = "爐號輸入有誤(爐號長度為5位)"
        End If
        Dim DateValue As Integer
        Dim GetInputDate As Date = CType(ListView1.InsertItem.FindControl("T1TextBox"), TextBox).Text
        'Try
        '    DateValue = Val(CType(ListView1.InsertItem.FindControl("T1TextBox"), TextBox).Text)
        '    GetInputDate = New CompanyORMDB.AS400DateConverter(DateValue).DateValue
        'Catch ex As Exception
        '    ValidatorControl.ErrorMessage = "日期輸入有誤無法做日期轉換驗證!"
        'End Try


        Dim ValidStartDate As Integer = New CompanyORMDB.AS400DateConverter(GetInputDate.AddYears(-1)).TwIntegerTypeData
        Dim QryString As String = "Select * From @#SMS100LB.SMSREGPF WHERE T1>=" & ValidStartDate & " AND T1<=" & DateValue & " AND T2='" & StoveNumber & "'"
        Dim SearchReslut As DataTable = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString).SelectQuery
        If SearchReslut.Rows.Count > 0 Then
            ValidatorControl.ErrorMessage = "輸入有誤1年內不可有相同爐號出現!(爐號:" & StoveNumber & " 日期:" & SearchReslut.Rows(0).Item("T1") & ")"
        End If
        args.IsValid = (ValidatorControl.ErrorMessage.Trim.Length = 0)
    End Sub



    Protected Sub DropDownList27_DataBound(sender As Object, e As EventArgs)
        Dim dropDownList As DropDownList = CType(sender, DropDownList)
        If dropDownList.Text.Trim = "" Then Exit Sub

        For II As Integer = dropDownList.Items.Count - 1 To 0 Step -1
            If dropDownList.Items(II).Value.Trim = "" Then dropDownList.Items.Remove(dropDownList.Items(II))
        Next
    End Sub

    Protected Sub DropDownListT24_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim listViewItemObj As ListViewItem = Nothing
        Dim textboxObj As TextBox = Nothing
        Dim dropBoxListObj As DropDownList = Nothing

        If Not ListView1.EditItem Is Nothing Then
            listViewItemObj = ListView1.EditItem
        Else
            listViewItemObj = ListView1.InsertItem
        End If

        dropBoxListObj = listViewItemObj.FindControl("DropDownList24")
        textboxObj = listViewItemObj.FindControl("TextBoxT29")
        textboxObj.Visible = (dropBoxListObj.SelectedItem.Text = "未知")
        If textboxObj.Visible = False Then textboxObj.Text = ""
    End Sub

    Protected Function TextBoxT29Visible(ByVal fromT24 As String) As Boolean
        Return fromT24.Trim = ""
    End Function

End Class