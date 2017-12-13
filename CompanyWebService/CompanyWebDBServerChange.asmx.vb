Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class DBServerChange
    Inherits System.Web.Services.WebService


#Region "使用資料庫伺服器名稱 屬性:UseDBServerName"
    ''' <summary>
    ''' 使用資料庫伺服器名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property UseDBServerName() As DBServerNameEnum
        Get
            If IsNothing(Me.Application.Item("_UseDBServerName")) Then
                Me.Application.Item("_UseDBServerName") = DBServerNameEnum.MainDBServer
            End If
            Return Me.Application.Item("_UseDBServerName")
        End Get
        Set(ByVal value As DBServerNameEnum)
            Me.Application.Item("_UseDBServerName") = value
        End Set
    End Property
#End Region


    <WebMethod()> _
    Public Function SetDBConnect(ByVal SetServer As DBServerNameEnum) As Boolean
        Dim SMP_CDBS As New SMPChangeDBService.SMPChangeDBService
        Dim OtherOperator_CDBS As New OtherOperatorChangeDBService.OtherOperatorChangeDBService
        Dim PortalSit_CDBS As New PortalSitChangeDBService.PortalSitChangeDBService
        Dim WebAppAuthority_CDBS As New WebAppAuthorityChangeDBAuthority.WebAppAuthorityChangeDBService

        SMP_CDBS.Credentials = System.Net.CredentialCache.DefaultCredentials
        OtherOperator_CDBS.Credentials = System.Net.CredentialCache.DefaultCredentials
        PortalSit_CDBS.Credentials = System.Net.CredentialCache.DefaultCredentials
        WebAppAuthority_CDBS.Credentials = System.Net.CredentialCache.DefaultCredentials

        Me.UseDBServerName = SetServer
        Dim ReturnValue As Boolean = True
        Try
            ReturnValue = ReturnValue And SMP_CDBS.ChangeDBServer(System.Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("DBServer" & SetServer & "ConnString").ToString)
            ReturnValue = ReturnValue And OtherOperator_CDBS.ChangeDBServer(System.Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("DBServer" & SetServer & "ConnString").ToString)
            ReturnValue = ReturnValue And PortalSit_CDBS.ChangeDBServer(System.Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("DBServer" & SetServer & "ConnString").ToString)
            ReturnValue = ReturnValue And WebAppAuthority_CDBS.ChangeDBServer(System.Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("DBServer" & SetServer & "ConnString").ToString)
        Catch ex As Exception
            ReturnValue = False
        End Try

        Return ReturnValue
    End Function

    Public Enum DBServerNameEnum
        MainDBServer = 0
        BackupDBServer1 = 1
        BackupDBServer2 = 2
    End Enum

End Class