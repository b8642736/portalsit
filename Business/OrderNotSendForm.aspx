<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="OrderNotSendForm.aspx.vb" Inherits="Business.OrderNotSendForm" %>
<%@ Register src="Controls/OrderNotSend/OrderNotSend.ascx" tagname="OrderNotSend" tagprefix="uc1" %>
<%@ Register src="Controls/NoMasterStock/NoMasterStock.ascx" tagname="NoMasterStock" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OrderNotSend ID="OrderNotSend1" runat="server" />
</asp:Content>
