<Serializable()> _
Partial Public Class GuestSues
    <NonSerialized()> _
    Dim DBDataContext As New BusinessDataContext
    <NonSerialized()> _
    Dim WebAPPAuthorityDBDataContext As New WebAPPAuthorityDataContext
    <NonSerialized()> _
    Dim AS400DbDataContext As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

#Region "客戶名稱 屬性:CustomerName"
    ''' <summary>
    ''' 客戶名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CustomerName As String
        Get
            For Each EachItem As CompanyORMDB.SLS300LB.SL2CUAPF In CompanyORMDB.SLS300LB.SL2CUAPF.ALLSL2CUAPFs
                If EachItem.CUA01.Trim = Me.CustomerID.Trim Then
                    Return EachItem.CUA11
                End If
            Next
            Return Me.CustomerID
        End Get
    End Property
#End Region
#Region "承辦人姓名 屬性:UndertakerName"
    ''' <summary>
    ''' 承辦人姓名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property UndertakerName As String
        Get
            For Each EachItem As CompanyORMDB.PLT500LB.PTM010PF In CompanyORMDB.PLT500LB.PTM010PF.ALLInCompanyPTM010PFs
                If EachItem.PT0102.Trim = Me.Undertaker.Trim Then
                    Return EachItem.PT0101
                End If
            Next
            Return Me.Undertaker
        End Get
    End Property
#End Region
#Region "系統登入者姓名 屬性:WindowLoginNameName"
    ReadOnly Property WindowLoginNameName As String
        Get
            Dim LoginDatas() As String = Me.WindowLoginName.Split("\")
            If LoginDatas.Count < 2 Then
                Return Me.WindowLoginName
            End If
            Dim GetWebLoginAccount As CompanyLINQDB.WebLoginAccount = (From A In WebAPPAuthorityDBDataContext.WebLoginAccount Where A.WindowLoginName.Trim = LoginDatas(1).Trim Select A).FirstOrDefault
            If IsNothing(GetWebLoginAccount) Then
                Return Me.WindowLoginName
            End If
            Return GetWebLoginAccount.DisplayName
        End Get
    End Property
#End Region
#Region "結案代碼名稱 屬性:ProcessStateName"
    ''' <summary>
    ''' 結案代碼名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ProcessStateName As String
        Get
            Select Case True
                Case Me.ProcessState = 1
                    Return "未結案"
                Case Me.ProcessState = 2
                    Return "已結案"
                Case Else
                    Return "未知狀態!"
            End Select
        End Get
    End Property
#End Region

#Region "是否為最後一筆訊息編號 屬性:IsLastSubRecordNumber"
    ''' <summary>
    ''' 是否為最後一筆訊息編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsLastSubRecordNumber As Boolean
        Get
            Dim LastSubData = (From A In DBDataContext.GuestSues Where A.ID = Me.ID Select A Order By A.SubRecordNumber Descending).FirstOrDefault
            If IsNothing(LastSubData) OrElse LastSubData.SubRecordNumber = Me.SubRecordNumber Then
                Return True
            End If
            Return False
        End Get
    End Property
#End Region

#Region "取得新增案件可用序號 方法:GetNewInsertDataID"
    ''' <summary>
    ''' 取得新增案件可用序號
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetNewInsertDataID() As Integer
        Dim myDbDataContext As New BusinessDataContext
        Dim LastIDDataItem As GuestSues = (From A In myDbDataContext.GuestSues Select A Order By A.ID Descending).FirstOrDefault
        If IsNothing(LastIDDataItem) Then
            Return 1
        End If
        Return LastIDDataItem.ID + 1
    End Function
#End Region
#Region "取得新增訊息可用訊息編號 方法:GetNewInsertDataSubRecordNumber"
    ''' <summary>
    ''' 取得新增訊息可用訊息編號
    ''' </summary>
    ''' <param name="DataID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetNewInsertDataSubRecordNumber(ByVal DataID As Integer) As Integer
        Dim myDbDataContext As New BusinessDataContext
        Dim LastIDDataItem As GuestSues = (From A In myDbDataContext.GuestSues Where A.ID = DataID Select A Order By A.SubRecordNumber Descending).FirstOrDefault
        If IsNothing(LastIDDataItem) Then
            Return 1
        End If
        Return LastIDDataItem.SubRecordNumber + 1
    End Function
    ''' <summary>
    ''' 取得新增訊息可用訊息編號
    ''' </summary>
    ''' <param name="Data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetNewInsertDataSubRecordNumber(ByVal Data As GuestSues) As Integer
        Return GetNewInsertDataSubRecordNumber(Data.ID)
    End Function
#End Region

#Region "驗證資料是否有誤 方法:VaildDataIsHaveError"
    ''' <summary>
    ''' 驗證資料是否有誤
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function VaildDataIsHaveError() As String
        If String.IsNullOrEmpty(Me.ContectHuman) OrElse Me.ContectHuman.Trim.Length = 0 Then
            Return "連絡人資料不可空白"
        End If
        If String.IsNullOrEmpty(Me.Describe) OrElse Me.Describe.Trim.Length = 0 Then
            Return "案件描述資料不可空白"
        End If
        Dim QrySting As String = "Select Count(*) From @#SLS300LB.SL2CUAPF Where CUA01='" & Me.CustomerID & "'"
        If CType(AS400DbDataContext.SelectQuery(QrySting).Rows(0).Item(0), Integer) = 0 Then
            Return "客戶編號不正確:" & Me.CustomerID
        End If
        QrySting = "Select Count(*) From @#PLT500LB.PTM010PF Where PT0102='" & Me.Undertaker & "'"
        If CType(AS400DbDataContext.SelectQuery(QrySting).Rows(0).Item(0), Integer) = 0 Then
            Return "承辦人員工編號不正確:" & Me.Undertaker
        End If
        Return Nothing
    End Function
#End Region

#Region "取得案件編號的最終訊息 (Shared)方法:GetLastSubRecordForID"
    ''' <summary>
    ''' 取得案件編號的最終訊息編號
    ''' </summary>
    ''' <param name="FindID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetLastSubRecordForID(ByVal FindID As Integer) As GuestSues
        Dim myDBDataContext = New BusinessDataContext
        Dim GetLastItem As GuestSues = (From A In myDBDataContext.GuestSues Where A.ID = FindID Select A Order By A.SubRecordNumber Descending).FirstOrDefault
        If IsNothing(GetLastItem) Then
            Return Nothing
        End If
        Return GetLastItem
    End Function
#End Region

End Class
