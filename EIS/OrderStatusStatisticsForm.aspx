<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="OrderStatusStatisticsForm.aspx.vb" Inherits="EIS.OrderStatusStatisticsForm" %>
<%@ Register src="Controls/OrderStatusStatisticsSearch.ascx" tagname="OrderStatusStatisticsSearch" tagprefix="uc1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OrderStatusStatisticsSearch ID="OrderStatusStatisticsSearch1" runat="server" />
</asp:Content>
