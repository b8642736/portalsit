Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebAppAuthorityChangeDBService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function ChangeDBServer(ByVal SetDBServerConnectString As String) As Boolean
        Return CompanyLINQDB.ChangeDBServer(SetDBServerConnectString)
    End Function

End Class