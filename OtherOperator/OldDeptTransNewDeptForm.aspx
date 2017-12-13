<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/OtherMasterSit.Master" CodeBehind="OldDeptTransNewDeptForm.aspx.vb" Inherits="OtherOperator.OldDeptTransNewDeptForm" %>
<%@ Register src="Control/OldDeptTransNewDept.ascx" tagname="OldDeptTransNewDept" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OldDeptTransNewDept ID="OldDeptTransNewDept2" runat="server" />
</asp:Content>
