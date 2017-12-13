<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SPMAccDepSelectEditForm.aspx.vb" Inherits="Accounting.SPMAccDepSelectEditForm" %>
<%@ Register src="Controls/SPMAccDepSelectEdit.ascx" tagname="SPMAccDepSelectEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SPMAccDepSelectEdit ID="SPMAccDepSelectEdit1" runat="server" />
</asp:Content>
