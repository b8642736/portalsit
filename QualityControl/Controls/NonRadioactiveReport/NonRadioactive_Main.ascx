<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NonRadioactive_Main.ascx.vb" Inherits="QualityControl.NonRadioactive_Main" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="NonRadioactive_Edit.ascx" tagname="NonRadioactive_Edit" tagprefix="uc1" %>
<%@ Register src="NonRadioactive_Print.ascx" tagname="NonRadioactive_Print" tagprefix="uc2" %>
<%@ Register src="NonRadioactive_Search.ascx" tagname="NonRadioactive_Search" tagprefix="uc3" %>
<P />

<link href="CSS/TabContainer.css" rel="stylesheet" type="text/css" />


<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"  Width="100%" CssClass="ajax__myTab" Height="1100px" AutoPostBack="True" >
   <cc1:TabPanel ID="TabPanel3" HeaderText="TabPanel3" runat="server">
        <HeaderTemplate>查詢</HeaderTemplate>
        <ContentTemplate><uc3:NonRadioactive_Search ID="NonRadioactive_Search1" runat="server" >
            </uc3:NonRadioactive_Search>
        </ContentTemplate>
    </cc1:TabPanel>
     <cc1:TabPanel ID="TabPanel1" HeaderText="TabPanel1" runat="server">
        <HeaderTemplate>編修</HeaderTemplate>
        <ContentTemplate><uc1:NonRadioactive_Edit ID="NonRadioactive_Edit1" runat="server" /></ContentTemplate>
    </cc1:TabPanel>

    <cc1:TabPanel ID="TabPanel2" HeaderText="TabPanel2" runat="server">
        <HeaderTemplate>列印</HeaderTemplate>
        <ContentTemplate><uc2:NonRadioactive_Print ID="NonRadioactive_Print1" runat="server" /></ContentTemplate>
    </cc1:TabPanel>

    
</cc1:TabContainer>




