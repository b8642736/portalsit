<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="OrderProduceAssignForm.aspx.vb" Inherits="EIS.OrderProduceAssignForm" %>
<%@ Register src="Controls/OrderProduceAssignSearch.ascx" tagname="OrderProduceAssignSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OrderProduceAssignSearch ID="OrderProduceAssignSearch1" runat="server" />
</asp:Content>
