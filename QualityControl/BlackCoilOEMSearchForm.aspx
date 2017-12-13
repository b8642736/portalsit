<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="BlackCoilOEMSearchForm.aspx.vb" Inherits="QualityControl.BlackCoilOEMSearchForm" %>
<%@ Register src="Controls/BlackCoilOEMSearch.ascx" tagname="BlackCoilOEMSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BlackCoilOEMSearch ID="BlackCoilOEMSearch1" runat="server" />
</asp:Content>
