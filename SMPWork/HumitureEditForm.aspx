﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="HumitureEditForm.aspx.vb" Inherits="SMPWork.HumitureEditForm" %>
<%@ Register src="Controls/HumitureEdit/HumitureEdit.ascx" tagname="HumitureEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:HumitureEdit ID="HumitureEdit1" runat="server" />
</asp:Content>