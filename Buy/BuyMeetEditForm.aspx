<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="BuyMeetEditForm.aspx.vb" Inherits="Buy.BuyMeetEditForm" %>
<%@ Register src="Controls/BuyMeetEdit.ascx" tagname="BuyMeetEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BuyMeetEdit ID="BuyMeetEdit1" runat="server" />
</asp:Content>
