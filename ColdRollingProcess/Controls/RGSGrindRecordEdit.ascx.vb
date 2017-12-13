Public Class RGSGrindRecordEdit
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As List(Of RGSGrindRecord)
        Dim ReturnValue As New List(Of RGSGrindRecord)
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If
        Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        For Each EachItem As DataRow In Adapter.SelectQuery(QryString).Rows
            Dim AddItem As New RGSGrindRecord
            AddItem.CDBSetDataRowValueToObject(EachItem)
            ReturnValue.Add(AddItem)
        Next
        Return ReturnValue
    End Function

    Public Function SearchToDataTable(ByVal QryString As String) As ColdRollingProcessDataSet.RGSGrindRecordEditDataTable
        Dim ReturnValue As New ColdRollingProcessDataSet.RGSGrindRecordEditDataTable
        For Each EachItem As RGSGrindRecord In Search(QryString)
            Dim AddItem As ColdRollingProcessDataSet.RGSGrindRecordEditRow = ReturnValue.NewRow
            With AddItem
                .RGS研磨機 = EachItem.RGSID
                .研磨輥號 = EachItem.RollerID
                .尺寸 = EachItem.Size
                .冠形 = EachItem.CrownShape
                .研磨量 = EachItem.GrindWeight
                .處理狀況 = EachItem.ProcessStateDescript
                .備註1 = EachItem.Memo1
                .ZML使用機號 = EachItem.AboutRunProcessData_ZMLName
                .使用鋼捲 = EachItem.AboutRunProcessData_CoilFullNumber
                .輸入員工號 = EachItem.ProcessEmployeeID
                .資料輸入時間 = EachItem.DataSaveTime
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Return ReturnValue
    End Function

#End Region

#Region "新增 方法:Insert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Function Insert(ByVal SourceObject As RGSGrindRecord) As Integer
        If Not String.IsNullOrEmpty(SourceObject.RollerID) Then
            SourceObject.RollerID = SourceObject.RollerID.ToUpper
        End If
        Return SourceObject.CDBInsert
    End Function
#End Region
#Region "更新 方法:Update"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Function Update(ByVal SourceObject As RGSGrindRecord) As Integer
        If Not String.IsNullOrEmpty(SourceObject.RollerID) Then
            SourceObject.RollerID = SourceObject.RollerID.ToUpper
        End If
        Return SourceObject.CDBUpdate
    End Function
#End Region
#Region "刪除 方法:Delete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Function Delete(ByVal SourceObject As RGSGrindRecord) As Integer
        Return SourceObject.CDBDelete
    End Function
#End Region

#Region "最後新增之RGS研磨機ID 屬性:LastInsertRGSID"
    ''' <summary>
    ''' 最後新增之RGS研磨機ID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LastInsertRGSID() As String
        Get
            Return Me.ViewState("_LastInsertRGSID")
        End Get
        Set(ByVal value As String)
            Me.ViewState("_LastInsertRGSID") = value
        End Set
    End Property
#End Region
#Region "最後新增之員工ID 屬性:LastInsertEmployeeID"
    ''' <summary>
    ''' 最後新增之員工ID 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LastInsertEmployeeID() As String
        Get
            Return Me.ViewState("_LastInsertEmployeeID")
        End Get
        Set(ByVal value As String)
            Me.ViewState("_LastInsertEmployeeID") = value
        End Set
    End Property
#End Region

#Region "產生查詢字串至控制項  函式:MakeQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryStringToControl()
        Dim ReturnValue As New StringBuilder

        ReturnValue.Append("Select A.*, B.* From RGSGrindRecord A LEFT JOIN (SELECT * FROM  RunProcessData UNION SELECT * FROM  RunProcessDataHistory) B ON A.FK2_RunProcessData_ID=B.ID  Where 1=1 ")
        If CheckBox1.Checked Then
            ReturnValue.Append(" AND A.DataSaveTime >= '" & Me.tbSatartDate.Text & "' AND A.DataSaveTime <= '" & Format(CType(tbEndDate.Text, Date).AddDays(1), "yyyy/MM/dd") & "' ")
        End If


        If Not String.IsNullOrEmpty(tbRollerID.Text) AndAlso tbRollerID.Text.Trim.Length > 0 Then
            tbRollerID.Text = tbRollerID.Text.ToUpper
            ReturnValue.Append(" and A.RollerID in ('" & tbRollerID.Text.Replace(",", "','") & "')")
        End If

        Dim SelectValues As String = Nothing
        For Each EachItem As CheckBox In PlaceHolder1.Controls
            If EachItem.Checked Then
                SelectValues &= IIf(String.IsNullOrEmpty(SelectValues), "", ",") & EachItem.Text
            End If
        Next
        If SelectValues.Split(",").Count < PlaceHolder1.Controls.Count Then
            ReturnValue.Append(" and A.RGSID in  ('" & SelectValues.Replace(",", "','") & "')")
        End If

        SelectValues = Nothing
        For Each EachItem As CheckBox In PlaceHolder2.Controls
            If EachItem.Checked Then
                SelectValues &= IIf(String.IsNullOrEmpty(SelectValues), "", ",") & EachItem.Text
            End If
        Next
        If SelectValues.Split(",").Count < PlaceHolder2.Controls.Count Then
            ReturnValue.Append(" and B.FK_RunStationName in ('" & SelectValues.Replace(",", "','") & "')")
        End If

        If Not String.IsNullOrEmpty(tbCoilNumbers.Text) AndAlso tbCoilNumbers.Text.Trim.Length > 0 Then
            ReturnValue.Append(" and B.FK_OutSHA01 + B.FK_OutSHA02 in ('" & tbCoilNumbers.Text.Replace(",", "','") & "')")
        End If

        If tbSatartSize.Text <> 0 OrElse tbEndSize.Text <> 999 Then
            ReturnValue.Append(" and A.size >= " & tbSatartSize.Text & " and A.size <= " & tbEndSize.Text)
        End If

        If tbSatartGrideWeight.Text <> 0 OrElse tbENDGrideWeight.Text <> 999 Then
            ReturnValue.Append(" and A.GrindWeight >= " & tbSatartGrideWeight.Text & " and A.GrindWeight <= " & tbENDGrideWeight.Text)
        End If

        If Not String.IsNullOrEmpty(tbCrownShape.Text) AndAlso tbCrownShape.Text.Trim.Length > 0 Then
            For Each EachItem As String In tbCrownShape.Text.Split(",")
                ReturnValue.Append(" and A.CrownShape like '%" & EachItem & "%'")
            Next
        End If

        If Not String.IsNullOrEmpty(tbMemo1.Text) AndAlso tbMemo1.Text.Trim.Length > 0 Then
            ReturnValue.Append(" and A.Memo1 like '%" & tbCrownShape.Text & "%'")
        End If

        If Not String.IsNullOrEmpty(tbEmployees.Text) AndAlso tbEmployees.Text.Trim.Length > 0 Then
            ReturnValue.Append(" and A.ProcessEmployeeID in ('" & tbEmployees.Text.Replace(",", "','") & "')")
        End If
        ReturnValue.Append(" order by RollerID ")
        Me.hfQryString.Value = ReturnValue.ToString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbSatartDate.Text = Format(Now.AddMonths(-6), "yyyy/MM/dd")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakeQryStringToControl()
        ListView1.DataBind()
    End Sub

    Private Sub ListView1_ItemInserted(sender As Object, e As ListViewInsertedEventArgs) Handles ListView1.ItemInserted
        LastInsertRGSID = e.Values("RGSID")
        LastInsertEmployeeID = e.Values("ProcessEmployeeID")
    End Sub

    Private Sub ListView1_ItemInserting(sender As Object, e As ListViewInsertEventArgs) Handles ListView1.ItemInserting
        e.Values("RGSID") = CType(ListView1.InsertItem.FindControl("ddlRGS"), DropDownList).SelectedValue
        e.Values("DataSaveTime") = Now
        '驗證欄輸入值
        Dim RollerID As String = e.Values("RollerID")
        Dim CrownShape As String = e.Values("CrownShape")
        Dim Size As Single = e.Values("Size")
        Dim MSGLabel As Label = ListView1.InsertItem.FindControl("lbMessage")
        MSGLabel.Text = ""
        If String.IsNullOrEmpty(MSGLabel.Text) AndAlso (String.IsNullOrEmpty(RollerID) OrElse RollerID.Trim.Length = 0) Then
            MSGLabel.Text = "研磨輥號不可為空白!"
        End If
        If String.IsNullOrEmpty(MSGLabel.Text) AndAlso (String.IsNullOrEmpty(CrownShape) OrElse CrownShape.Trim.Length = 0) Then
            MSGLabel.Text = "冠形不可為空白!"
        End If
        If String.IsNullOrEmpty(MSGLabel.Text) AndAlso Size = 0 Then
            MSGLabel.Text = "尺寸不可為零!"
        End If
        If Not String.IsNullOrEmpty(MSGLabel.Text) Then
            e.Cancel = True : Exit Sub
        End If
        MSGLabel.Text = "資料輸入驗證無誤,新增一筆!"
    End Sub

    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        e.NewValues("DataSaveTime") = CType(e.NewValues("DataSaveTime"), DateTime)
        Dim CrownShape As String = e.NewValues("CrownShape")
        Dim Size As Single = e.NewValues("Size")
        Dim MSGLabel As Label = ListView1.EditItem.FindControl("lbMessage")
        MSGLabel.Text = ""
        If String.IsNullOrEmpty(MSGLabel.Text) AndAlso (String.IsNullOrEmpty(CrownShape) OrElse CrownShape.Trim.Length = 0) Then
            MSGLabel.Text = "冠形不可為空白!"
        End If
        If String.IsNullOrEmpty(MSGLabel.Text) AndAlso Size = 0 Then
            MSGLabel.Text = "尺寸不可為零!"
        End If
        If Not String.IsNullOrEmpty(MSGLabel.Text) Then
            e.Cancel = True : Exit Sub
        End If
        MSGLabel.Text = "資料輸入驗證無誤,新增一筆!"
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        Call MakeQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(SearchToDataTable(Me.hfQryString.Value), "RGS自主檢查表" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)

    End Sub

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        CType(ListView1.InsertItem.FindControl("ddlRGS"), DropDownList).SelectedValue = LastInsertRGSID
        CType(ListView1.InsertItem.FindControl("ProcessEmployeeIDTextBox"), TextBox).Text = LastInsertEmployeeID
    End Sub

End Class