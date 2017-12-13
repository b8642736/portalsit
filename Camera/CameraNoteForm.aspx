<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MainMaster.Master" CodeBehind="CameraNoteForm.aspx.vb" Inherits="WebCamera.Camera1NoteForm" %>
<%@ Register src="CameraNote/CameraNote.ascx" tagname="CameraNote" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CameraNote ID="Camera1Note1" runat="server" />
</asp:Content>
