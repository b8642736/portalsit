<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="StandSampleRangeEditForm.aspx.vb" Inherits="SMPWork.StandSampleRangeEditForm" %>
<%@ Register src="Controls/StandSampleRangeEdit/StandSampleRangeEdit.ascx" tagname="StandSampleRangeEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:StandSampleRangeEdit ID="StandSampleRangeEdit1" runat="server" />
</asp:Content>
