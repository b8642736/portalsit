Partial Public Class WebGroupAccount

    Dim DBDataContext As New CompanyLINQDB.WebAPPAuthorityDataContext

#Region "相關Web群組授權功能 屬性:About_WebSystemFunctions"
    Private _About_WebSystemFunctions As List(Of WebSystemFunction)
    Private Shared _ALLWebGroupAuthority As List(Of WebGroupAuthority)
    ''' <summary>
    ''' 相關Web群組授權功能
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property About_WebSystemFunctions() As List(Of WebSystemFunction)
        Get
            If IsNothing(_ALLWebGroupAuthority) Then
                _ALLWebGroupAuthority = (From A In DBDataContext.WebGroupAuthority Select A).ToList
            End If
            If IsNothing(_About_WebSystemFunctions) Then
                _About_WebSystemFunctions = (From A In _ALLWebGroupAuthority Where A.GroupCode = Me.GroupCode Select A.WebSystemFunction).ToList
            End If
            Return _About_WebSystemFunctions
        End Get
    End Property
#End Region

End Class
