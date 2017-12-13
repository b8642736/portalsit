<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MessageSenderSingleForm.aspx.vb" Inherits="IM.MessageSenderSingleForm" %>

<%@ Register src="Controls/MessageSender.ascx" tagname="MessageSender" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:MessageSender ID="MessageSender1" runat="server" />
    
    </div>
    </form>
</body>
</html>
