<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LabRecordA2_Main.ascx.vb" Inherits="QualityControl.LabRecordA2_Main" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="LabRecordA2_Edit.ascx" tagname="LabRecordA2_Edit" tagprefix="uc1" %><%@ Register src="LabRecordA2_Print.ascx" tagname="LabRecordA2_Print" tagprefix="uc2" %><%@ Register src="LabRecordA2_Search.ascx" tagname="LabRecordA2_Search" tagprefix="uc3" %>
<P />

<link href="CSS/TabContainer.css" rel="stylesheet" type="text/css" />


<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"  Width="100%" CssClass="ajax__myTab" Height="1100px" AutoPostBack="True" >
   <cc1:TabPanel ID="TabPanel3" HeaderText="TabPanel3" runat="server">
        <HeaderTemplate>工作清單</HeaderTemplate>
        <ContentTemplate><uc3:LabRecordA2_Search ID="LabRecordA2_Search1" runat="server" ></uc3:LabRecordA2_Search>
        </ContentTemplate>
    </cc1:TabPanel>
    
    <cc1:TabPanel ID="TabPanel2" HeaderText="TabPanel2" runat="server">
        <HeaderTemplate>列印</HeaderTemplate>
        <ContentTemplate><uc2:LabRecordA2_Print ID="LabRecordA2_Print1" runat="server" ></uc2:LabRecordA2_Print>
        </ContentTemplate>
    </cc1:TabPanel>

    
</cc1:TabContainer>




