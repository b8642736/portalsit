<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ClientStationExcelFileTransMoniter.ascx.vb" Inherits="EAFWeb.ClientStationExcelFileTransMoniter" %>
<style type="text/css">
    .style1
    {   
        width: 140px;
    }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            <span lang="zh-tw">EAF工作站Excel監控程式:</span></td>
        <td>
            <asp:HyperLink ID="HyperLink1" runat="server" 
                
                
                NavigateUrl="http://10.1.4.12/eaffileupload/eaffileupload.application">安裝軟體</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td class="style1" align="right">
            <span lang="zh-tw">工作站基本條件:</span></td>
        <td>
            <span lang="zh-tw">1.Win98以上<br />
            2.RAM:建議256M以上</span></td>
    </tr>
    <tr>
        <td class="style1" align="right">
            <span lang="zh-tw">使用說明:</span></td>
        <td>
            <span lang="zh-tw">1.安裝完成後會產生如下圖,EAF(紅色圖示),表正系統已啟動執行中=&gt;</span><asp:Image 
                ID="Image1" runat="server" ImageUrl="~/Controls/PIC1.jpg" />
            <br />
            <span lang="zh-tw">2.請於下次系統開機時記得再次啟動此軟體如下圖:<br />
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Controls/PIC2.jpg" 
                Height="265px" Width="215px" />
            <br />
            3.查看資料傳送狀況可於右下EAF(紅色圖示),使用滑鼠快速點兩下顯示如下圖:<br />
            <asp:Image ID="Image3" runat="server" Height="166px" 
                ImageUrl="~/Controls/pic3.jpg" Width="431px" />
            <br />
            4.如發生異常無法轉檔之狀況可手動刪除異常檔案使用作業如下圖:<br />
            <asp:Image ID="Image4" runat="server" Height="166px" 
                ImageUrl="~/Controls/pic4.jpg" Width="431px" />
            </span></td>
    </tr>
     <tr>
        <td class="style1" align="right">
            <span lang="zh-tw">Excel程式碼:</span></td>
        <td>
            <span lang="zh-tw">１.請變更Excel檔加入附件程式碼以配合此軟體=&gt;<asp:HyperLink ID="HyperLink2" 
                runat="server" NavigateUrl="~/Controls/ExcelFileModify.rtf"><span 
                lang="zh-tw">附件</span></asp:HyperLink>
            </span></td>
    </tr>

</table>
