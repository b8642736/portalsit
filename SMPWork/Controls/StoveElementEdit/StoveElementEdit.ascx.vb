Public Class StoveElementEdit
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New CompanyLINQDB.SMPDataContext

#Region "更新資料至AS400 方法:ReplaceDataToAS400"
    ''' <summary>
    ''' 更新資料至AS400
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ReplaceDataToAS400(ByVal NewData As CompanyLINQDB.分析資料, ByVal SetReplaceDataType As ReplaceDataType) As Boolean
        Dim myAboutPPSSHAPF As CompanyORMDB.PPS100LB.PPSQCAPF = NewData.AboutPPSQCAPF

        Dim myNewDataRow As DataRow = NewData.CreateTheObjectDataRow
        If SetReplaceDataType = ReplaceDataType.InsertOrUpdate Then
            If IsNothing(myNewDataRow) Then
                Return False
            End If
            If IsNothing(myAboutPPSSHAPF) Then
                myAboutPPSSHAPF = New CompanyORMDB.PPS100LB.PPSQCAPF
            End If
            myAboutPPSSHAPF.CDBLibraryName = "TESTKUKU"
            myAboutPPSSHAPF.SetSQLServerDataRowValueToObject(myNewDataRow)
            myAboutPPSSHAPF.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            Return myAboutPPSSHAPF.CDBSave > 0
        End If
        If SetReplaceDataType = ReplaceDataType.Delete AndAlso Not IsNothing(myAboutPPSSHAPF) Then
            myAboutPPSSHAPF.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            myAboutPPSSHAPF.CDBLibraryName = "TESTKUKU"
            Return myAboutPPSSHAPF.CDBDelete > 0
        End If
        Return False
    End Function

    Private Enum ReplaceDataType
        InsertOrUpdate = 1
        Delete = 2
    End Enum

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("使用前請先將資料庫變更為測試環境!")
        Response.End()
        If Not IsPostBack Then
            Me.tbStartDate.Text = Format(Now, "yyyy/MM/dd")
            Me.tbEndDate.Text = Me.tbStartDate.Text
        End If
    End Sub

    Private Sub ldsSearchResult_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceDeleteEventArgs) Handles ldsSearchResult.Deleting
        If ReplaceDataToAS400(e.OriginalObject, ReplaceDataType.Delete) = False Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub ldsSearchResult_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceInsertEventArgs) Handles ldsSearchResult.Inserting
        Dim NewItem As CompanyLINQDB.分析資料 = e.NewObject
        If Not IsNothing(NewItem) Then
            NewItem.日期 = CType(Me.ListView1.InsertItem.FindControl("日期TextBox"), TextBox).Text.Replace("民國", Nothing).Replace("年", Nothing).Replace("月", Nothing).Replace("日", Nothing)
            NewItem.時間 = CType(Me.ListView1.InsertItem.FindControl("時間Textbox"), TextBox).Text.Replace("時", ":").Replace("分", ":").Replace("秒", Nothing)
        End If
        If ReplaceDataToAS400(NewItem, ReplaceDataType.InsertOrUpdate) = False Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub ldsSearchResult_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceUpdateEventArgs) Handles ldsSearchResult.Updating
        Dim NewItem As CompanyLINQDB.分析資料 = e.NewObject
        If Not IsNothing(NewItem) Then
            NewItem.時間 = CType(Me.ListView1.EditItem.FindControl("時間Textbox"), TextBox).Text.Replace("時", ":").Replace("分", ":").Replace("秒", Nothing)
        End If
        If ReplaceDataToAS400(NewItem, ReplaceDataType.InsertOrUpdate) = False Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub


    Protected Sub ldsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles ldsSearchResult.Selecting
        Dim StartDateValue As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbStartDate.Text, Date)).TwIntegerTypeData
        Dim EndDateValue As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbEndDate.Text, Date)).TwIntegerTypeData
        Dim SearchResult As IQueryable(Of CompanyLINQDB.分析資料) = From A In DBDataContext.分析資料 Where A.日期 >= StartDateValue And A.日期 <= EndDateValue Select A
        If Not String.IsNullOrEmpty(tbStoveNumber.Text) Then
            SearchResult = From A In SearchResult Where A.爐號.Trim = tbStoveNumber.Text.Trim Select A
        End If
        If DDLStationName.SelectedValue <> "ALL" Then
            SearchResult = From A In SearchResult Where A.站別 Like DDLStationName.SelectedValue & "*" Select A
        End If
        e.Result = SearchResult
    End Sub

    Protected Sub tbSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Click
        ListView1.DataBind()
    End Sub

    Private Sub ListView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.PreRender
        For Each EachItem In ListView1.Items
            If Not IsNothing(EachItem.FindControl("DeleteButton")) Then
                CType(EachItem.FindControl("DeleteButton"), Button).Visible = hfIsCanEdit.Value
            End If
        Next

        Dim InsertDateControl As TextBox = Me.ListView1.InsertItem.FindControl("日期TextBox")
        Dim InsertTimeControl As TextBox = Me.ListView1.InsertItem.FindControl("時間TextBox")
        Dim InsertRadiationControl As TextBox = Me.ListView1.InsertItem.FindControl("輻射TextBox")
        Dim InsertBackgroundControl As TextBox = Me.ListView1.InsertItem.FindControl("備註1TextBox")
        If String.IsNullOrEmpty(InsertDateControl.Text) OrElse InsertDateControl.Text.Trim.Length = 0 Then
            InsertDateControl.Text = Format((Format(Now, "yyyy") - 1911) * 10000 + Format(Now, "MMdd"), "國民000年00月00日")
        End If
        If String.IsNullOrEmpty(InsertTimeControl.Text) OrElse InsertTimeControl.Text.Trim.Length = 0 Then
            InsertTimeControl.Text = Format(Now, "HH時mm分ss秒")
        End If
        If String.IsNullOrEmpty(InsertRadiationControl.Text) OrElse InsertRadiationControl.Text.Trim.Length = 0 Then
            InsertRadiationControl.Text = "0.08"
        End If
        If String.IsNullOrEmpty(InsertBackgroundControl.Text) OrElse InsertBackgroundControl.Text.Trim.Length = 0 Then
            InsertBackgroundControl.Text = "0.08"
        End If

    End Sub

 
End Class