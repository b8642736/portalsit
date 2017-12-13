<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/OtherMasterSit.Master" CodeBehind="AS400SQLQueryForm.aspx.vb" Inherits="OtherOperator.AS400SQLQueryForm" %>
<%@ Register src="Control/AS400SQLQuery.ascx" tagname="AS400SQLQuery" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AS400SQLQuery ID="AS400SQLQuery1" runat="server" />
</asp:Content>
