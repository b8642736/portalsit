<%@ Page Title="" Language="vb" AutoEventWireup="false"CodeBehind="LabRecordA2PreviewForm.aspx.vb" Inherits="QualityControl.LabRecordA2EditForm" %>

<%@ Register src="Controls/LabRecordA2_Edit/LabRecordA2_Main.ascx" tagname="LabRecordA2_Main" tagprefix="uc1" %>

<%@ Register src="Controls/LabRecordA2_Edit/LabRecordA2_Print.ascx" tagname="LabRecordA2_Print" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>   
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <uc2:LabRecordA2_Print ID="LabRecordA2_Print1" runat="server" />
         
    </div>
        
    </form>
</body>
</html>



