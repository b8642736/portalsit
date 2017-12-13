<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="PickGoodDetailSearchForm.aspx.vb" Inherits="Business.PickGoodDetailSearchForm" %>
<%@ Register src="Controls/PickGoodDetail/PickGoodDetailSearch.ascx" tagname="PickGoodDetailSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PickGoodDetailSearch ID="PickGoodDetailSearch1" runat="server" />
</asp:Content>
