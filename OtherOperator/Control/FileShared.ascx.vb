Public Partial Class FileShared
    Inherits System.Web.UI.UserControl

#Region "上傳檔案目錄路徑  屬性:UploadFileDirectPath"
    ''' <summary>
    ''' 上傳檔案目錄路徑
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property UploadFileDirectPath() As String
        Get
            Return "\\HP-NAS01\sql_data$\WebUploadFiles\"
        End Get
    End Property
#End Region
#Region "是否可編修資料 屬性:IsCanEditData"
    ''' <summary>
    ''' 是否可編修資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsCanEditData() As Boolean
        Get
            If IsNothing(Me.ViewState("_IsCanEditData")) Then
                Me.ViewState("_IsCanEditData") = WebAppAuthority.IsCanValidAuthoritySystem("Other01", "Other0106", Me.Request.UserHostAddress)
            End If
            Return Me.ViewState("_IsCanEditData")
        End Get
    End Property
#End Region
#Region "清除暫存資料夾及過期檔案 函式:ClearOverDayTempFolderAndFiles"
    ''' <summary>
    ''' 清除暫存資料夾及過期檔案
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearOverDayTempFolderAndFiles()
        Dim DeleteDate As DateTime = Now.AddDays(-1)
        For Each EachFolder As String In IO.Directory.GetDirectories(Server.MapPath(".") & "\DownLoadFileTemp\")
            Dim DirectoryInfo As New IO.DirectoryInfo(EachFolder)
            If DirectoryInfo.CreationTime <= DeleteDate Then
                DirectoryInfo.Delete(True)
            End If
        Next

    End Sub
#End Region
#Region "比較來源檔與目地檔案是否相同 方法:CompareFile"
    ''' <summary>
    ''' 比較來源檔與目地檔案是否相同
    ''' </summary>
    ''' <param name="SourceFileFullPath"></param>
    ''' <param name="TargetFileFullPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CompareFile(ByVal SourceFileFullPath As String, ByVal TargetFileFullPath As String) As Boolean
        Dim SourceFileInfo As New IO.FileInfo(SourceFileFullPath)
        If SourceFileInfo.Exists = False Then
            Throw New Exception("比較來源檔與目地檔案是否相同時來源檔不存在!")
        End If
        Dim TargetFileFileInfo As New IO.FileInfo(TargetFileFullPath)
        If TargetFileFileInfo.Exists = False Then
            Return False
        End If
        Select Case True
            Case SourceFileInfo.LastWriteTime <> TargetFileFileInfo.LastWriteTime
                Return False
            Case SourceFileInfo.Length <> TargetFileFileInfo.Length
                Return False
        End Select
        Return True
    End Function
#End Region

    Dim DBDataContext As New CompanyLINQDB.OtherOperatorDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ClearOverDayTempFolderAndFiles()
    End Sub

    Private Sub ListView1_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles ListView1.ItemCreated
        If e.Item.ItemType = ListViewItemType.InsertItem Then
            e.Item.Visible = IsCanEditData
        End If
    End Sub

    Private Sub ListView1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles ListView1.ItemDataBound

        If e.Item.ItemType = ListViewItemType.DataItem AndAlso Not IsNothing(e.Item.FindControl("HLDownLoad")) Then
            Dim FileSubFolderName As String = CType(e.Item.FindControl("HFID"), HiddenField).Value.Trim
            Dim FileSubName As String = CType(e.Item.FindControl("FileNameLabel"), Label).Text.Trim
            If Not IO.Directory.Exists(Server.MapPath(".") & "\DownLoadFileTemp\" & FileSubFolderName) Then
                IO.Directory.CreateDirectory(Server.MapPath(".") & "\DownLoadFileTemp\" & FileSubFolderName)
            End If
            Dim CopyToTmepFileFullPath As String = Server.MapPath(".") & "\DownLoadFileTemp\" & FileSubFolderName & "\" & FileSubName
            Dim CopyFileName As String = CType(CType(e.Item.FindControl("HLDownLoad"), HyperLink).ToolTip, String).Trim
            CType(e.Item.FindControl("HLDownLoad"), HyperLink).NavigateUrl = "~/DownLoadFileTemp/" & FileSubFolderName & "/" & FileSubName
            Dim CopyFromFileFullPath As String = CType(e.Item.FindControl("SaveFileFullPathLabel"), Label).Text
            If CompareFile(CopyFromFileFullPath, CopyToTmepFileFullPath) = False Then
                IO.File.Copy(CopyFromFileFullPath, CopyToTmepFileFullPath, True)
            End If

            CType(e.Item.FindControl("HLDownLoad"), HyperLink).Enabled = IO.File.Exists(CopyToTmepFileFullPath)
            CType(e.Item.FindControl("DeleteButton"), Button).Visible = IsCanEditData
            CType(e.Item.FindControl("EditButton"), Button).Visible = IsCanEditData
            CType(e.Item.FindControl("SaveFileFullPathLabel"), Label).Visible = IsCanEditData
            CType(e.Item.FindControl("SaveFileFullPathLabel1"), Label).Visible = Not IsCanEditData
        End If
    End Sub

    Private Sub ListView1_ItemDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewDeleteEventArgs) Handles ListView1.ItemDeleting
        Dim FindRecord As CompanyLINQDB.FileSharedRecord = (From A In DBDataContext.FileSharedRecord Where A.ID = CType(e.Keys(0), String) Select A).FirstOrDefault
        If Not IsNothing(FindRecord) AndAlso IO.File.Exists(FindRecord.SaveFileFullPath) Then
            IO.File.Delete(FindRecord.SaveFileFullPath)
        End If

    End Sub

    Private Sub ListView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewInsertEventArgs) Handles ListView1.ItemInserting
        Dim UpLoadFileControl As FileUpload = ListView1.InsertItem.FindControl("FileUpload1")
        If UpLoadFileControl.HasFile = False Then
            e.Cancel = True
            Exit Sub
        End If

        e.Values.Item("ID") = Guid.NewGuid.ToString
        e.Values.Item("FileName") = UpLoadFileControl.FileName
        e.Values.Item("SaveFileFullPath") = UploadFileDirectPath & e.Values.Item("ID")
        e.Values.Item("UploadTime") = Now
        e.Values.Item("UploadUser") = WebAppAuthority.CurrentWindowsLoginEmployeeNumber
        e.Values.Item("UploadPCIP") = Request.UserHostAddress
        UpLoadFileControl.SaveAs(e.Values.Item("SaveFileFullPath"))
    End Sub

    Private Sub ListView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Dim UpLoadFileControl As FileUpload = ListView1.EditItem.FindControl("FileUpload1")
        If UpLoadFileControl.HasFile Then
            e.NewValues.Item("FileName") = UpLoadFileControl.FileName
            e.NewValues.Item("SaveFileFullPath") = UploadFileDirectPath & e.Keys(0)
            e.NewValues.Item("UploadTime") = Now
            e.NewValues.Item("UploadUser") = WebAppAuthority.CurrentWindowsLoginEmployeeNumber
            e.NewValues.Item("UploadPCIP") = Request.UserHostAddress
            UpLoadFileControl.SaveAs(e.NewValues.Item("SaveFileFullPath"))
        End If

    End Sub
End Class