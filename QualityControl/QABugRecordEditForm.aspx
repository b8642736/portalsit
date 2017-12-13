<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="QABugRecordEditForm.aspx.vb" Inherits="QualityControl.QABugRecordEditForm" %>
<%@ Register src="Controls/QABugRecordEdit.ascx" tagname="QABugRecordEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:QABugRecordEdit ID="QABugRecordEdit1" runat="server" />
</asp:Content>
