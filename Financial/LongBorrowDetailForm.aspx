<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="LongBorrowDetailForm.aspx.vb" Inherits="Financial.LongBorrowDetailForm" %>
<%@ Register src="ReportControl/LongBorrowDetail.ascx" tagname="LongBorrowDetail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:LongBorrowDetail ID="LongBorrowDetail1" runat="server" />
</asp:Content>
