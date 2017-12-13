<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainSite.Master" CodeBehind="ZmlReplaceHistoryEditForm.aspx.vb" Inherits="ColdRollingProcess.ZmlReplaceHistoryEditForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="Controls\ZmlReplaceHistory.ascx" TagName="ZmlReplaceHistory" TagPrefix="uc1" %>
<%@ Register Src="Controls\SystemNote.ascx" TagName="SystemNote" TagPrefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%" AutoPostBack="True" CssClass ="ajax__myTab" >
        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate>ZML更換紀錄表</HeaderTemplate>

            <ContentTemplate><uc1:ZmlReplaceHistory ID="ZmlReplaceHistory1" runat="server" /></ContentTemplate>

        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2" Width="100%">
            <HeaderTemplate>片語設定</HeaderTemplate>

            <ContentTemplate><uc2:SystemNote ID="SystemNote1" runat="server"></uc2:SystemNote></ContentTemplate>

        </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>
