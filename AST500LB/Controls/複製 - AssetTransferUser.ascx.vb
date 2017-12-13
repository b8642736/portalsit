Public Partial Class AssetTransferUser
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal TransStartDate As String, ByVal TransEndDate As String, ByVal AssetNumber As String) As List(Of AST401PF)
        Dim WhereString As String = " Where "
        Dim StartDate As Date = CType(TransStartDate, Date)
        Dim EndDate As Date = CType(TransEndDate, Date)
        WhereString &= " TRNDATE>=" & (Format(StartDate, "yyyy") - 1911) * 10000 + Format(StartDate, "MMdd")
        WhereString &= " AND TRNDATE<=" & (Format(EndDate, "yyyy") - 1911) * 10000 + Format(EndDate, "MMdd")
        If Not IsNothing(AssetNumber) AndAlso Not String.IsNullOrEmpty(AssetNumber) Then
            WhereString &= " AND (TNUMBER like '" & AssetNumber & "%'"
            WhereString &= " OR FNUMBER like '" & AssetNumber & "%')"
        End If
        Dim SQLString As String = "Select * from " & (New AST401PF).CDBFullAS400DBPath & WhereString & " Order by FNUMBER"
        Return ClassDBAS400.CDBSelect(Of AST401PF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function
#End Region
#Region "新增 方法:CDBInsert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
Public Shared Function CDBInsert(ByVal SourceObject As AST401PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        SourceObject.TRNTIME = Format(Now, "hhmmss")
        Return SourceObject.CDBInsert()
    End Function
#End Region
#Region "刪除 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
Public Shared Function CDBDelete(ByVal SourceObject As AST401PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBDelete()
    End Function
#End Region

#Region "使用者是否已按下查詢 屬性:IsUserAlreadyPutSearch"

    ''' <summary>
    ''' 使用者是否已按下查詢
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsUserAlreadyPutSearch() As Boolean
        Get
            If IsNothing(Me.ViewState("_IsUserAlreadyPutSearch")) Then
                Return False
            End If
            Return Me.ViewState("_IsUserAlreadyPutSearch")
        End Get
        Set(ByVal value As Boolean)
            Me.ViewState("_IsUserAlreadyPutSearch") = value
        End Set
    End Property
#End Region
#Region "使用者選擇之物件 屬性:UserSelectAST101PF"
    Private _UserSelectAST101PF As AST101PF
    ''' <summary>
    ''' 使用者選擇之物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property UserSelectAST101PF() As AST101PF
        Get
            Return Me.Session("{23CABD5D-89DA-400a-A16F-263D1E808F6A}")
        End Get
        Set(ByVal value As AST101PF)
            Me.Session("{23CABD5D-89DA-400a-A16F-263D1E808F6A}") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            btStartDate.Text = Format(New Date(Now.Year - 1, 1, 1), "yyyy/MM/dd")
            btEndDate.Text = Format(New Date(Now.Year, 12, 31), "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        Me.ListView1.DataBind()
    End Sub

    Protected Sub btnSearchCondictionClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchCondictionClear.Click
        btStartDate.Text = Format(New Date(Now.Year - 1, 1, 1), "yyyy/MM/dd")
        btEndDate.Text = Format(New Date(Now.Year, 12, 31), "yyyy/MM/dd")
        Me.TextBox3.Text = Nothing
        Me.IsUserAlreadyPutSearch = False
    End Sub

    Private Sub ListView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.PreRender
        Dim InsertControl As TextBox = ListView1.InsertItem.FindControl("TRNDATETextBox")
        If String.IsNullOrEmpty(InsertControl.Text) Then
            InsertControl.Text = Format(Now, "yyyy/MM/dd")
        End If
        If Not IsNothing(Me.UserSelectAST101PF) Then
            CType(ListView1.InsertItem.FindControl("FNUMBERTextBox"), TextBox).Text = Me.UserSelectAST101PF.NUMBER
            CType(ListView1.InsertItem.FindControl("TRNCOUNTTextBox"), TextBox).Text = Me.UserSelectAST101PF.QUANT
            Me.UserSelectAST101PF = Nothing
        End If
    End Sub

    Protected Sub btnAssetSearch_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.MultiView1.SetActiveView(View2)
    End Sub

    Private Sub AssetSearch1_UserSelectAST101PFEvent(ByVal Sender As AssetSearch, ByVal SelectObject As CompanyORMDB.AST500LB.AST101PF) Handles AssetSearch1.UserSelectAST101PFEvent
        Me.MultiView1.SetActiveView(View1)
        Me.UserSelectAST101PF = SelectObject
    End Sub

    Sub InsertDataValidator1_ServerValidation(ByVal source As Object, ByVal args As ServerValidateEventArgs)
        Dim ValidateObject As New AST401PF
        Dim ValidaterConrol As CustomValidator = Me.ListView1.InsertItem.FindControl("InsertDataValidator1")
        With ValidateObject
            .SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            .TRNDATEDateFormat = CType(CType(Me.ListView1.InsertItem.FindControl("TRNDATETextBox"), TextBox).Text, Date)
            .FNUMBER = CType(Me.ListView1.InsertItem.FindControl("FNUMBERTextBox"), TextBox).Text
            .TNUMBER = CType(Me.ListView1.InsertItem.FindControl("TNUMBERTextBox"), TextBox).Text
            .TDEPTSA = CType(Me.ListView1.InsertItem.FindControl("TDEPTSATextBox"), TextBox).Text
            Dim TrnCount As Integer = 0
            Try
                TrnCount = CType(Me.ListView1.InsertItem.FindControl("TRNCOUNTTextBox"), TextBox).Text
            Catch ex As Exception
                TrnCount = 0
            End Try
            .TRNCOUNT = TrnCount
        End With
        Dim GetErrMsg As String = ValidateObject.GetSaveCheckErrorMessage
        ValidaterConrol.Text = GetErrMsg
        args.IsValid = IsNothing(GetErrMsg)
    End Sub

End Class