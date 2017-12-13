<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="SampleStatusDetailSearchForm.aspx.vb" Inherits="SMPWork.SampleStatusDetailSearchForm" %>
<%@ Register src="Controls/SampleStatusReport/SampleStatusDetailSearch.ascx" tagname="SampleStatusDetailSearch" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SampleStatusDetailSearch ID="SampleStatusDetailSearch1" runat="server" />
</asp:Content>
