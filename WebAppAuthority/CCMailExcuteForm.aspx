<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebAuthorityMaster.Master" CodeBehind="CCMailExcuteForm.aspx.vb" Inherits="WebAppAuthority.CCMailExcuteForm" %>

<%@ Register src="Control/CCMailPWD/CCMailPWD_Main.ascx" tagname="CCMailPWD_Main" tagprefix="uc1" %>

<%@ Register src="Control/GroupSearch.ascx" tagname="GroupSearch" tagprefix="uc2" %>

<%@ Register src="Control/CCMailExcute/CCMailExcute_Main.ascx" tagname="CCMailExcute_Main" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc3:CCMailExcute_Main ID="CCMailExcute_Main1" runat="server" />
    
 </asp:Content>
