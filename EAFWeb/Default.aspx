<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="EAFWeb._Default" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register src="Controls/DailyReportMaker.ascx" tagname="DailyReportMaker" tagprefix="uc1" %>
<%@ Register src="Controls/ClientStationExcelFileTransMoniter.ascx" tagname="clientstationexcelfiletransmoniter" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
    <style type="text/css">

	.ad9c5c1ce6-bc49-4eb6-9802-ac7761f751a8-0 {border-color:#000000;border-left-width:0;border-right-width:0;border-top-width:0;border-bottom-width:0;}
	.fcc3756aa1-0161-4779-9fac-891ff683aa7d-0 {font-size:9pt;color:#000000;font-family:新細明體;font-weight:normal;text-decoration:underline;}
	.fcc3756aa1-0161-4779-9fac-891ff683aa7d-1 {font-size:9pt;color:#000000;font-family:新細明體;font-weight:normal;}
	.style1
    {   
        width: 188px;
    }
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
            BorderStyle="None" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="0">報表製作</asp:ListItem>
            <asp:ListItem Value="1">EAF(Excel)作業監控軟體安裝</asp:ListItem>
        </asp:RadioButtonList>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="ReportView" runat="server">
        <uc1:DailyReportMaker ID="DailyReportMaker1" runat="server" />
    </asp:View>
    <asp:View ID="MoniterSoftView" runat="server">
        <uc2:ClientStationExcelFileTransMoniter ID="ClientStationExcelFileTransMoniter1" 
            runat="server" />
    </asp:View>
</asp:MultiView>
    
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
