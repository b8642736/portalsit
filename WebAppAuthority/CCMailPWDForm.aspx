<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="CCMailPWDForm.aspx.vb" Inherits="WebAppAuthority.CCMailPWDForm" %>

<%@ Register src="Control/CCMailPWD/CCMailPWD_Main.ascx" tagname="CCMailPWD_Main" tagprefix="uc1" %>

<%@ Register src="Control/GroupSearch.ascx" tagname="GroupSearch" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:CCMailPWD_Main ID="CCMailPWD_Main1" runat="server" />
    
 </asp:Content>
