<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="ElementMoniterForm.aspx.vb" Inherits="SMP.ElementMoniterForm" %>
<%@ Register src="~/control/ElementMoniter.ascx" tagname="ElementMoniter" tagprefix="uc1" %>
<%@ Register src="Control/ElementMoniter.ascx" tagname="ElementMoniter" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:ElementMoniter ID="ElementMoniter1" runat="server" />
</asp:Content>
