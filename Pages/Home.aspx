<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--script--%>
    <script type="text/javascript" src="../FusionCharts/FusionCharts.js"></script>
    <%--script--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <div id="divChart" runat="server">
                    <div class="row">
                        <div class="col12 Heading">
                            <asp:Label ID="Label1" runat="server" Text="CHARTS" CssClass="h4" meta:resourcekey="Label1Resource1"></asp:Label>

                        </div>
                    </div>

                    <div class="row" runat="server">
                        <div class="col6 chartBlue">
                            <%--<asp:Literal ID="litChartWorkDurtion" runat="server" meta:resourcekey="litChartWorkDurtionResource1"></asp:Literal>--%>
                            <asp:Literal ID="litChartErrorsImport" runat="server"></asp:Literal>
                        </div>
                        <div class="col6 ChartYellow">
                            <%--<asp:Literal ID="litChartBeginLateDurtion" runat="server" meta:resourcekey="litChartBeginLateDurtionResource1"></asp:Literal>--%>
                            <asp:Literal ID="litChartImportByMachine" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="row">

                    <div class="col4">
                    </div>
                </div>
                <div class="row" runat="server">
                    <div class="col6 ChartRed">
                        <%--<asp:Literal ID="LitChartAbsentDays" runat="server" meta:resourcekey="LitChartAbsentDaysResource1"></asp:Literal>--%>
                        <asp:Literal ID="litChartImportByTime" runat="server"></asp:Literal>
                    </div>
                    <div class="col6 chartPurple">
                        <%--<asp:Literal ID="LitChartDurations" runat="server" meta:resourcekey="LitChartDurationsResource1"></asp:Literal>--%>
                        <asp:Literal ID="litChartRateImportByTime" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

