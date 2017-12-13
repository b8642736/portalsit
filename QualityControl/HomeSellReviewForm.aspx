<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="HomeSellReviewForm.aspx.vb" Inherits="QualityControl.HomeSellReviewForm" %>
<%@ Register src="Controls/HomeSellReview/HomeSellReview.ascx" tagname="HomeSellReview" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HomeSellReview ID="HomeSellReview1" runat="server" />
</asp:Content>
