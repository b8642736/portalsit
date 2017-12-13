<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="StoveElementEditForm.aspx.vb" Inherits="SMPWork.StoveElementEditForm" %>
<%@ Register src="Controls/StoveElementEdit/StoveElementEdit.ascx" tagname="StoveElementEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:StoveElementEdit ID="StoveElementEdit1" runat="server" />
</asp:Content>
