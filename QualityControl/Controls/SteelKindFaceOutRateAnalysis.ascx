<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SteelKindFaceOutRateAnalysis.ascx.vb" Inherits="QualityControl.SteelKindFaceOutRateAnalysis" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 75px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            期間:</td>
        <td>
            民國<asp:TextBox ID="tbStartYear" runat="server" style="margin-bottom: 0px" 
                Width="40px"></asp:TextBox>
            年<asp:TextBox ID="tbStartMonth" runat="server" style="margin-bottom: 0px" 
                Width="40px"></asp:TextBox>
            月~民國<asp:TextBox ID="tbEndYear" runat="server" Width="40px"></asp:TextBox>
            年<asp:TextBox ID="tbEndMonth" runat="server" style="margin-bottom: 0px" 
                Width="40px"></asp:TextBox>
            月</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="tbSearch" runat="server" Text="查詢" Width="100px" />
            <asp:Button ID="tbSearchToExcel" runat="server" Text="Excel查詢下載" 
                Width="100px" />
        </td>
    </tr>

</table>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="ODSSearchResult" EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="鋼種" HeaderText="鋼種" SortExpression="鋼種" />
        <asp:BoundField DataField="BA-HCR-產出率" HeaderText="BA-HCR-產出率" 
            SortExpression="BA-HCR-產出率" />
        <asp:BoundField DataField="BA-HCR-一級品率" HeaderText="BA-HCR-一級品率" 
            SortExpression="BA-HCR-一級品率" />
        <asp:BoundField DataField="BA-HCR-全程合格率" HeaderText="BA-HCR-全程合格率" 
            SortExpression="BA-HCR-全程合格率" />
        <asp:BoundField DataField="BA-LCR-產出率" HeaderText="BA-LCR-產出率" 
            SortExpression="BA-LCR-產出率" />
        <asp:BoundField DataField="BA-LCR-一級品率" HeaderText="BA-LCR-一級品率" 
            SortExpression="BA-LCR-一級品率" />
        <asp:BoundField DataField="BA-LCR-全程合格率" HeaderText="BA-LCR-全程合格率" 
            SortExpression="BA-LCR-全程合格率" />
        <asp:BoundField DataField="2B-HCR-產出率" HeaderText="2B-HCR-產出率" 
            SortExpression="2B-HCR-產出率" />
        <asp:BoundField DataField="2B-HCR-一級品率" HeaderText="2B-HCR-一級品率" 
            SortExpression="2B-HCR-一級品率" />
        <asp:BoundField DataField="2B-HCR-全程合格率" HeaderText="2B-HCR-全程合格率" 
            SortExpression="2B-HCR-全程合格率" />
        <asp:BoundField DataField="2B-LCR-產出率" HeaderText="2B-LCR-產出率" 
            SortExpression="2B-LCR-產出率" />
        <asp:BoundField DataField="2B-LCR-一級品率" HeaderText="2B-LCR-一級品率" 
            SortExpression="2B-LCR-一級品率" />
        <asp:BoundField DataField="2B-LCR-全程合格率" HeaderText="2B-LCR-全程合格率" 
            SortExpression="2B-LCR-全程合格率" />
        <asp:BoundField DataField="2D-產出率" HeaderText="2D-產出率" 
            SortExpression="2D-產出率" />
        <asp:BoundField DataField="2D-一級品率" HeaderText="2D-一級品率" 
            SortExpression="2D-一級品率" />
        <asp:BoundField DataField="2D-全程合格率" HeaderText="2D-全程合格率" 
            SortExpression="2D-全程合格率" />
        <asp:BoundField DataField="SH-產出率" HeaderText="SH-產出率" 
            SortExpression="SH-產出率" />
        <asp:BoundField DataField="SH-一級品率" HeaderText="SH-一級品率" 
            SortExpression="SH-一級品率" />
        <asp:BoundField DataField="SH-全程合格率" HeaderText="SH-全程合格率" 
            SortExpression="SH-全程合格率" />
        <asp:BoundField DataField="NO1-產出率" HeaderText="NO1-產出率" 
            SortExpression="NO1-產出率" />
        <asp:BoundField DataField="NO1-一級品率" HeaderText="NO1-一級品率" 
            SortExpression="NO1-一級品率" />
        <asp:BoundField DataField="NO1-全程合格率" HeaderText="NO1-全程合格率" 
            SortExpression="NO1-全程合格率" />
        <asp:BoundField DataField="產出率合計" HeaderText="產出率合計" SortExpression="產出率合計" />
        <asp:BoundField DataField="一級品率合計" HeaderText="一級品率合計" 
            SortExpression="一級品率合計" />
        <asp:BoundField DataField="全程合格率合計" HeaderText="全程合格率合計" 
            SortExpression="全程合格率合計" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ODSSearchResult" runat="server" SelectMethod="Search" 
    TypeName="QualityControl.SteelKindFaceOutRateAnalysis">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfSQLString" Name="SQLString" 
            PropertyName="Value" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hfSQLString" runat="server" />


