<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="StandSampleStdDevEditForm.aspx.vb" Inherits="SMPWork.StandSampleStdDevEditForm" %>

<%@ Register src="Controls/StandSampleStdDevEdit/StandSampleStdDevEdit.ascx" tagname="StandSampleStdDevEdit" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <uc1:StandSampleStdDevEdit ID="StandSampleStdDevEdit1" runat="server" />

    
</asp:Content>
