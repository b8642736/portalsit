<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/OtherMasterSit.Master" CodeBehind="AS400DBPFToVBClassForm.aspx.vb" Inherits="OtherOperator.AS400DBPFToVBClassForm" validateRequest=false %>
<%@ Register src="Control/AS400DBPFToVBClass.ascx" tagname="AS400DBPFToVBClass" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AS400DBPFToVBClass ID="AS400DBPFToVBClass1" runat="server" />
</asp:Content>
