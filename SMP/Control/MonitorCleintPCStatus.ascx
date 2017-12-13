<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MonitorCleintPCStatus.ascx.vb" Inherits="SMP.MonitorCleintPCStatus" %>
<p>
    用戶端電腦連線狀態顯示<asp:Button ID="Button1" runat="server" Height="24px" 
        Text="重新偵測電腦連線狀態" Width="168px" />
</p>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Timer ID="Timer1" runat="server" Interval="20000">
        </asp:Timer>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataSourceID="ODSPCStatus" PageSize="30" 
            Width="521px">
            <PagerSettings Position="Top" />
            <Columns>
                <asp:BoundField DataField="ClentPCName" HeaderText="電腦名稱" 
                    SortExpression="ClentPCName" />
                <asp:BoundField DataField="IsNetworkNormalDisplayText" HeaderText="連線測試結果" 
                    SortExpression="IsNetworkNormalDisplayText" />
                <asp:BoundField DataField="Memo1" HeaderText="備註說明1" SortExpression="Memo1" />
                <asp:BoundField DataField="PingErrorMessagee" HeaderText="連線錯誤訊息" 
                    SortExpression="PingErrorMessagee" />
            </Columns>
        </asp:GridView>
        <span lang="zh-tw">(每廿秒自動偵測一次) 最後更新時間</span>:<asp:Label ID="lbaLastUpdateTime" 
            runat="server"></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>
        <asp:ObjectDataSource ID="ODSPCStatus" runat="server" SelectMethod="Search" 
            TypeName="SMP.MonitorClientPCStatusDisplayItem"></asp:ObjectDataSource>
    
