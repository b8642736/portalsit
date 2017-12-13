<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="ProductStock._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        #ProductStockProcessControls1
        {
            height: 130px;
            width: 227px;
        }
        #Object1
        {
            height: 188px;
            width: 522px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<%--    <object id="Object1" classid="ProductStockProcessControls.dll#ProductStockProcessControls.UserControl1" />
--%>
    <object id="Object1" classid="ActiveXControls.dll#ActiveXControls.CIPHERLabBarcordReader" />

    </div>
    </form>
</body>
</html>
