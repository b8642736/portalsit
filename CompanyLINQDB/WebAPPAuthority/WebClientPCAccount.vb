Partial Public Class WebClientPCAccount

    Dim DBDataContext As New CompanyLINQDB.WebAPPAuthorityDataContext

#Region "相關Web群組群組帳號 屬性:About_WebGroupAccounts"
    ''' <summary>
    ''' 相關Web群組群組帳號
    ''' </summary>
    ''' <remarks></remarks>
    Private _About_WebGroupAccounts As List(Of WebGroupAccount)
    Private Shared _ALLWebLoginAccountToWebGroupAccount As List(Of WebClientPCAccountTOWebGroupAccount)
    ReadOnly Property About_WebGroupAccounts() As List(Of WebGroupAccount)
        Get
            If IsNothing(_ALLWebLoginAccountToWebGroupAccount) Then
                _ALLWebLoginAccountToWebGroupAccount = (From A In DBDataContext.WebClientPCAccountTOWebGroupAccount Select A).ToList
            End If
            If IsNothing(_About_WebGroupAccounts) Then
                _About_WebGroupAccounts = (From A In _ALLWebLoginAccountToWebGroupAccount Where A.ClientIP = Me.ClientIP Select A.WebGroupAccount).ToList
            End If
            Return _About_WebGroupAccounts
        End Get
    End Property
#End Region

#Region "電腦IP與備註說明 屬性:PCIPAndMemo1"
    ''' <summary>
    ''' 電腦IP與備註說明
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PCIPAndMemo1() As String
        Get
            Dim ReturnValue As String = "IP:" & Me.ClientIP.Trim
            If Not String.IsNullOrEmpty(Memo1) AndAlso Memo1.Trim.Length > 0 Then
                ReturnValue &= "(" & Me.Memo1.Trim & ")"
            End If
            Return ReturnValue
        End Get
    End Property
#End Region

End Class
