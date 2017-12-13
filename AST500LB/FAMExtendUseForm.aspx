<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="FAMExtendUseForm.aspx.vb" Inherits="AST500LB.FAMExtendUseForm" %>
<%@ Register src="Controls/MonthWroks/FAMExtendUse.ascx" tagname="FAMExtendUse" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:FAMExtendUse ID="FAMExtendUse1" runat="server" />
</asp:Content>
