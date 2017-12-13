<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="HRLeaveDetailForm.aspx.vb" Inherits="Personnel.HRLeaveDetailForm" %>
<%@ Register src="Controls/HRLeaveDetail.ascx" tagname="HRLeaveDetail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HRLeaveDetail ID="HRLeaveDetail1" runat="server" />
</asp:Content>
