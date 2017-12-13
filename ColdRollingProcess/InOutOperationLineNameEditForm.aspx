<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="InOutOperationLineNameEditForm.aspx.vb" Inherits="ColdRollingProcess.InOutOperationLineNameEditForm" %>
<%@ Register src="Controls/InOutOperationLineNameEdit.ascx" tagname="InOutOperationLineNameEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:InOutOperationLineNameEdit ID="InOutOperationLineNameEdit1" 
        runat="server" />
</asp:Content>
