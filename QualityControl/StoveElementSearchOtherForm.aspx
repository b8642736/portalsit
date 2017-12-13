<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="StoveElementSearchOtherForm.aspx.vb" Inherits="QualityControl.StoveElementSearchOtherForm" %>
<%@ Register src="Controls/StoveElementSearchOther.ascx" tagname="StoveElementSearchOther" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:StoveElementSearchOther ID="StoveElementSearchOther1" runat="server" />
</asp:Content>
