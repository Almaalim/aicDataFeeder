<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="ReportViewer.aspx.cs" Inherits="Pages_ReportViewer" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="Stimulsoft.Report.Web" Namespace="Stimulsoft.Report.Web" TagPrefix="cc2" %>

<%@ Register Assembly="Stimulsoft.Report.WebFx" Namespace="Stimulsoft.Report.WebFx" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="pageDiv" runat="server">
        <table width="100%">
            <tr>
                <td align="center">
                    <asp:LinkButton ID="btnBackToReports" runat="server" CssClass="GenButton" Height="18px"
                        Text="Back" Width="70px" OnClick="btnBackToReportsPage_Click" meta:resourcekey="btnBackToReportsResource1"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>

    <cc1:StiWebViewerFx ID="StiWebViewerFx1" runat="server" Width="912px" Height="600px" Background="White" BrowserTitle="" CacheItemPriority="Low" ExitUrl="" ImageFormat="Png" ImageQuality="Normal" Localization="" LocalizationDirectory="" meta:resourcekey="StiWebViewerFx1Resource1"  ReportGuid="6bf1801628db4051" ServerTimeout="00:10:00" ThemeName="Office2013" />
    <%--Report=""  WebImageHost="Stimulsoft.Report.WebFx.StiWebImageHost"--%>
</asp:Content>

