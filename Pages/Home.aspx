﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%--<%@ Register Assembly="AjaxSamples" Namespace="AjaxSamples" TagPrefix="as" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Control/Calendar2.ascx" TagName="Calendar2" TagPrefix="Cal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--script--%>
    <script type="text/javascript">
        function showPopup(devName) {
            document.getElementById(devName).style.display = 'block';
            document.getElementById(devName).style.visibility = 'visible';
        }

        function hidePopup(devName) {
            document.getElementById(devName).style.visibility = 'hidden';
            document.getElementById(devName).style.display = 'none';
        }
    </script>

    <script type="text/javascript" src="../FusionCharts/FusionCharts.js"></script>
    <%--script--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnChartsFilter" />
        </Triggers>

        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <div id="DivList" class="row" runat="server">
                    <div class="col1">
                        <asp:Label ID="lblDepChartsFilter" runat="server" Text=" Department:" meta:resourcekey="lblDepChartsFilterResource1" ></asp:Label>
                    </div>
                    <div class="col2">
                        <asp:DropDownList ID="ddlDepChartsFilter" runat="server" OnSelectedIndexChanged="ddlDepChartsFilter_SelectedIndexChanged" AutoPostBack="True" meta:resourcekey="ddlDepChartsFilterResource1" >
                        </asp:DropDownList>
                    </div>
                    <div class="col1">
                        <asp:Label ID="lblEmpChartsFilter" runat="server" Text=" Employee:" meta:resourcekey="lblEmpChartsFilterResource1" ></asp:Label>
                    </div>
                    <div class="col2">
                        <asp:DropDownList ID="ddlEmpChartsFilter" runat="server" meta:resourcekey="ddlEmpChartsFilterResource1" ></asp:DropDownList>
                    </div>
                </div>

                <div id="DivMonth" runat="server" class="row">
                    <div class="col1">
                        <asp:Label ID="lblTypeChartsFilter" runat="server" Text=" Type:" meta:resourcekey="lblTypeChartsFilterResource1" ></asp:Label>
                    </div>
                    <div class="col2">
                        <asp:DropDownList ID="ddlTypeChartsFilter" runat="server" OnSelectedIndexChanged="ddlTypeChartsFilter_SelectedIndexChanged" AutoPostBack="True" meta:resourcekey="ddlTypeChartsFilterResource1" >
                            <asp:ListItem Value="M" Text="Monthly" meta:resourcekey="ListItemResource1" ></asp:ListItem>
                            <asp:ListItem Value="D" Text="Daily" meta:resourcekey="ListItemResource2" ></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="DivMonth1" runat="server" class="col1">
                        <asp:Label ID="lblMonth" runat="server" Text="Month:" meta:resourcekey="lblMonthResource1" ></asp:Label>
                    </div>
                    <div id="DivMonth2" runat="server" class="col2">
                        <asp:DropDownList ID="ddlMonth" runat="server" meta:resourcekey="ddlMonthResource1" ></asp:DropDownList>
                    </div>
                    <div id="DivYear1" runat="server" class="col1">
                        <asp:Label ID="lblYear" runat="server" Text="Year:" meta:resourcekey="lblYearResource1" ></asp:Label>
                    </div>
                    <div id="DivYear2" runat="server" class="col2">
                        <asp:DropDownList ID="ddlYear" runat="server" meta:resourcekey="ddlYearResource1" ></asp:DropDownList>
                    </div>
                    <div id="DivDay1" runat="server" class="col1">
                        <asp:Label ID="lblDate" runat="server" Text="Date:" meta:resourcekey="lblDateResource1" ></asp:Label>
                    </div>
                    <div id="DivDay2" runat="server" class="col4">
                        <Cal:Calendar2 ID="calDate" runat="server" CalendarType="System" ValidationGroup="" InitialValue="true" />
                    </div>
                </div>

                <div class="row" runat="server">
                    <div class="col8">
                        <asp:LinkButton ID="btnChartsFilter" runat="server" CssClass="GenButton glyphicon glyphicon-search"
                            OnClick="btnChartsFilter_Click"
                            Text="&lt;img src=&quot;../images/Button_Icons/button_magnify.png&quot; /&gt; Search" meta:resourcekey="btnChartsFilterResource1" ></asp:LinkButton>
                    </div>
                </div>

                <div id="divChart" runat="server">
                    <div class="row">
                        <div class="col12 Heading">
                            <asp:Label ID="Label1" runat="server" Text="CHARTS" CssClass="h4" meta:resourcekey="Label1Resource1" ></asp:Label>

                        </div>
                    </div>

                    <div class="row" runat="server">
                        <div class="col6 chartBlue">
                            <asp:Literal ID="litChartWorkDurtion" runat="server" meta:resourcekey="litChartWorkDurtionResource1" ></asp:Literal>
                        </div>
                        <div class="col6 ChartYellow">
                            <asp:Literal ID="litChartBeginLateDurtion" runat="server" meta:resourcekey="litChartBeginLateDurtionResource1" ></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="row">

                    <div class="col4">
                    </div>
                </div>
                <div class="row" runat="server">
                    <div class="col6 ChartRed">
                        <asp:Literal ID="LitChartAbsentDays" runat="server" meta:resourcekey="LitChartAbsentDaysResource1" ></asp:Literal>
                    </div>
                    <div class="col6 chartPurple">
                        <asp:Literal ID="LitChartDurations" runat="server" meta:resourcekey="LitChartDurationsResource1" ></asp:Literal>
                    </div>
                </div>
                <div class="row">

                    <div class="col4">
                    </div>
                </div>
                <div class="row" runat="server">
                    <div class="col6 ChartRed">
                        <asp:Literal ID="LitChartCountRecByTime" runat="server" meta:resourcekey="LitChartCountRecByTimeResource1" ></asp:Literal>
                    </div>
                    <div class="col6 chartPurple">
                        <asp:Literal ID="LitChartCountRecByMachine" runat="server" meta:resourcekey="LitChartCountRecByMachineResource1" ></asp:Literal>
                    </div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

