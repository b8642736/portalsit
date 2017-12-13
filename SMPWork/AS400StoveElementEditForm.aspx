<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="AS400StoveElementEditForm.aspx.vb" Inherits="SMPWork.AS400StoveElementEditForm" %>
<%@ Register src="Controls/AS400StoveElementEdit/AS400StoveElementEdit.ascx" tagname="AS400StoveElementEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AS400StoveElementEdit ID="AS400StoveElementEdit1" runat="server" />
</asp:Content>
