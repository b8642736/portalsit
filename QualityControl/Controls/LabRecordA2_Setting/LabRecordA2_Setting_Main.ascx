<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LabRecordA2_Setting_Main.ascx.vb" Inherits="QualityControl.LabRecordA2_Setting_Main" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<%@ Register Src="LabRecordA2_Setting_Assay_DAT.ascx" TagName="LabRecordA2_Setting_Assay_DAT" TagPrefix="uc1" %>



<%@ Register Src="LabRecordA2_Setting_Assay_RES_V2.ascx" TagName="LabRecordA2_Setting_Assay_RES_V2" TagPrefix="uc2" %>



<%@ Register Src="LabRecordA2_Setting_Remark_DAT.ascx" TagName="LabRecordA2_Setting_Remark_DAT" TagPrefix="uc3" %>



<%@ Register Src="LabRecordA2_Setting_Remark_RES_V2.ascx" TagName="LabRecordA2_Setting_Remark_RES_V2" TagPrefix="uc4" %>



<%@ Register Src="LabRecordA2_Setting_Preview.ascx" TagName="LabRecordA2_Setting_Preview" TagPrefix="uc5" %>



<%@ Register src="LabRecordA2_Setting_Remark_RES_ASSAY.ascx" tagname="LabRecordA2_Setting_Remark_RES_ASSAY" tagprefix="uc6" %>



<link href="CSS/TabContainer.css" rel="stylesheet" type="text/css" />


<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%" CssClass="ajax__myTab" Height="600px" AutoPostBack="True">
    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
        <HeaderTemplate>[1]檢驗項目-基本檔</HeaderTemplate>
        <ContentTemplate>
            <uc1:LabRecordA2_Setting_Assay_DAT ID="LabRecordA2_Setting_Assay_DAT1" runat="server" />
        </ContentTemplate>
    </cc1:TabPanel>

    <cc1:TabPanel runat="server" HeaderText="TabPanel20" ID="TabPanel20">
        <HeaderTemplate>[2]檢驗項目-對照檔</HeaderTemplate>

        <ContentTemplate>


            <uc2:LabRecordA2_Setting_Assay_RES_V2 ID="LabRecordA2_Setting_Assay_RES_V21" runat="server" />


        </ContentTemplate>


    </cc1:TabPanel>

    <cc1:TabPanel runat="server" HeaderText="TabPanel30" ID="TabPanel30">
        <HeaderTemplate>[3]片語-基本檔</HeaderTemplate>

        <ContentTemplate>

            <uc3:LabRecordA2_Setting_Remark_DAT ID="LabRecordA2_Setting_Remark_DAT1" runat="server" />

        </ContentTemplate>
    </cc1:TabPanel>

    <cc1:TabPanel runat="server" HeaderText="TabPanel40" ID="TabPanel40">
        <HeaderTemplate>[4]片語-對照檔</HeaderTemplate>

        <ContentTemplate>



            <uc4:LabRecordA2_Setting_Remark_RES_V2 ID="LabRecordA2_Setting_Remark_RES_V21" runat="server" />



        </ContentTemplate>
    </cc1:TabPanel>



    <cc1:TabPanel runat="server" HeaderText="TabPanel50" ID="TabPanel50">
        <HeaderTemplate>[5]片語-條件檢查</HeaderTemplate>

        <ContentTemplate>
         


            <uc6:LabRecordA2_Setting_Remark_RES_ASSAY ID="LabRecordA2_Setting_Remark_RES_ASSAY1" runat="server" />
         


        </ContentTemplate>
    </cc1:TabPanel>

    
    <cc1:TabPanel runat="server" HeaderText="TabPanel60" ID="TabPanel60">
        <HeaderTemplate >[6]設定值預覽</HeaderTemplate>
        <ContentTemplate >
            <uc5:LabRecordA2_Setting_Preview ID="LabRecordA2_Setting_Preview1" runat="server" />
        </ContentTemplate>
        </cc1:TabPanel> 

</cc1:TabContainer>

