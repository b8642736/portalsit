Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebService_autocomplete
    Inherits System.Web.Services.WebService

#Region "Ajax 自動完成客戶"
    <WebMethod()> _
    Public Function getCompanyInfo(ByVal prefixText As String, ByVal count As Int32) As String()
        Dim buyer_set As String()
        Try
            buyer_set = (From dr In DT_Buyer_set.AsEnumerable
                      Select dr.Field(Of String)("NAME")).ToArray

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try
        Dim result As String() = buyer_set.Where(Function(buyer) buyer.StartsWith(prefixText)).Take(count).ToArray()
        Return result
    End Function
#End Region

End Class