<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="NonRadioactiveSearchForm.aspx.vb" Inherits="QualityControl.NonRadioactiveSearchForm" %>

<%@ Register src="Controls/NonRadioactiveReport/NonRadioactive_Main.ascx" tagname="NonRadioactive_Main" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:NonRadioactive_Main ID="NonRadioactive_Main1" runat="server" />
    
</asp:Content>
