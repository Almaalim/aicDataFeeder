﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="ReportsMain.aspx.cs" Inherits="Pages_ReportMain" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="~/Control/Calendar2.ascx" TagPrefix="uc" TagName="Calendar2" %>
<%@ Register Assembly="Stimulsoft.Report.WebFx" Namespace="Stimulsoft.Report.WebFx" TagPrefix="cc1" %>
<%@ Register Assembly="Stimulsoft.Report.WebDesign" Namespace="Stimulsoft.Report.Web" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript">

        $('#menuTd1').bind("DOMSubtreeModified", function () {

            var colors = ["009ad7", "ffaa31", "68af27", "c22439", "005683", "622695", "d13f2a"];
            $(".ReportBtns").each(function (i) {
                $(this).css('background-color', '#' + colors[i % colors.length]);
            });
        });
    </script>

    <script type="text/javascript">
        function showPopup(dev1, dev2, dev3, devShow) {
            hidePopup('', '', dev3);
            if (devShow != '') { document.getElementById(devShow).style.visibility = 'visible'; document.getElementById(devShow).style.display = 'block'; }
            if (dev1 != '') { document.getElementById(dev1).style.visibility = 'visible'; document.getElementById(dev1).style.display = 'block'; }
        }

    function hidePopup(dev1, dev2, dev3) {
        if (dev1 != '') { document.getElementById(dev1).style.visibility = 'hidden'; document.getElementById(dev1).style.display = 'none'; }
        if (dev2 != '') { document.getElementById(dev2).style.visibility = 'hidden'; document.getElementById(dev2).style.display = 'none'; }
        if (dev3 != '') { document.getElementById(dev3).style.visibility = 'hidden'; document.getElementById(dev3).style.display = 'none'; }
        //document.getElementById('<%= hdnShow.ClientID %>').value = null;
    }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Block">
        <%--UpdateMode="Conditional"--%>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnViewreport" />
            <asp:PostBackTrigger ControlID="btnEditReport" />
        </Triggers>
        <ContentTemplate>
            <div id="pageDiv" runat="server"></div>
            <div class="row">
                <div class="col12">
                    <asp:HiddenField ID="hdnShow" runat="server" />
                </div>
            </div>
            <%--<div id="pageDiv" runat="server">--%>
            <div class="row">
                <div class="col12">
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:DataList ID="dltReport" runat="server" CaptionAlign="Top" RepeatColumns="4"
                            BorderStyle="None" OnItemCommand="dltReport_ItemCommand"
                            OnItemDataBound="dltReport_ItemDataBound"
                            RepeatDirection="Horizontal" RepeatLayout="Flow" Width="100%" meta:resourcekey="dltReportResource1">
                            <AlternatingItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                            <EditItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <SelectedItemStyle BackColor="Red" Font-Bold="True" />

                            <ItemTemplate>

                                <asp:LinkButton ID="lnkBtnEn" CommandArgument='<%# DataBinder.Eval(Container,"dataitem.RepID") %>' CssClass="ReportBtns glyphicon glyphicon-align-left reportsicon"
                                    runat="server" Text='<%# DataBinder.Eval(Container,getRepName()) %>' meta:resourcekey="lnkBtnEnResource1">
                                    <asp:ImageButton ID="Image1" runat="server" Height="30px" ImageUrl="~/images/reports-icon.png"
                                        Width="30px" CommandArgument='<%# DataBinder.Eval(Container,"dataitem.RepID") %>' meta:resourcekey="Image1Resource1" />
                                </asp:LinkButton>

                            </ItemTemplate>
                        </asp:DataList>
                    </asp:Panel>
                </div>
            </div>

            <%--Popup--%>
            <div id="DivPopup" class="popup" data-popup="popup-1" runat="server">
                <div class="popup-inner">
                    <a class="popup-close" data-popup-close="popup-1" href="#" onclick="hidePopup('ctl00_ContentPlaceHolder1_DivPopup','','ctl00_ContentPlaceHolder1_pnlDateFromTo')">x</a>
                    <div class="popup-wrap">
                        <div class="row">
                            <div class="col12">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <h3 class="h3">
                                            <asp:Label ID="lblSelectedreport" runat="server"></asp:Label>
                                        </h3>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div class="row">
                        </div>

                        <div class="row">
                            <div class="col2">
                                <asp:ValidationSummary runat="server" ID="vsView" ValidationGroup="vgView" EnableClientScript="False" CssClass="CustomValidator" ShowSummary="False" />
                            </div>
                        </div>

                        <div class="GreySetion">
                            <asp:Panel ID="pnlDateFromTo" runat="server" >
                                <div class="row">
                                    <div class="col2">
                                        <span class="requiredStar">*</span>
                                        <asp:Label ID="lblStartDate" runat="server" Text="Start Date :"></asp:Label>
                                    </div>
                                    <div class="col4">
                                        <uc:Calendar2 ID="calStartDate" runat="server" CalendarType="System" ValidationRequired="true" ValidationGroup="vgView" CalTo="calEndDate"/>
                                        <%--CalTo="calEndDate"--%>

                                        <%--<asp:CustomValidator ID="cvStartDate" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Start Date is required!' /&gt;" CssClass="CustomValidator"
                                            ValidationGroup="vgView" OnServerValidate="Date_ServerValidate" EnableClientScript="False"
                                            ControlToValidate="cvValid"></asp:CustomValidator>--%>

                                        <%--<asp:CustomValidator ID="cvCompareDates" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='start date more than end date!' /&gt;" CssClass="CustomValidator"
                                            ValidationGroup="vgView" ErrorMessage="start date more than end date!" OnServerValidate="Date_ServerValidate"
                                            EnableClientScript="False" ControlToValidate="cvValid"></asp:CustomValidator>--%>
                                    </div>
                                    <div class="col2">
                                        <span class="requiredStar">*</span>
                                        <asp:Label ID="lblEndDate" runat="server" Text="End Date :"></asp:Label>
                                    </div>
                                    <div class="col4">
                                        <uc:Calendar2 ID="calEndDate" runat="server" CalendarType="System" ValidationGroup="vgView" />

                                        <%--<asp:CustomValidator ID="cvEndDate" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='End Date is required!' /&gt;" CssClass="CustomValidator"
                                            ValidationGroup="vgView" OnServerValidate="Date_ServerValidate" EnableClientScript="False"
                                            ControlToValidate="cvValid"></asp:CustomValidator>--%>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlEmployee" runat="server" Visible="False">
                                <div class="row">
                                    <div class="col2">
                                        <span class="requiredStar">*</span>
                                        <asp:Label ID="lblIDSearch" runat="server" Text="Select Employee By :"></asp:Label>
                                    </div>
                                    <div class="col4">
                                        <asp:DropDownList ID="ddlIDSearch" runat="server">
                                            <asp:ListItem Value="EmpID" Text="Employee ID" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="EmpNameEn" Text="Employee Name (En)"></asp:ListItem>
                                            <asp:ListItem Value="EmpNameAr" Text="Employee Name (Ar)"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col4">
                                        <asp:TextBox ID="txtIDSearch" runat="server"></asp:TextBox>

                                        <asp:CustomValidator ID="cvIDSearch" runat="server" ValidationGroup="vgView" OnServerValidate="IDSearch_ServerValidate" CssClass="CustomValidator"
                                            EnableClientScript="False" ControlToValidate="cvValid"></asp:CustomValidator>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlDepartment" runat="server" Visible="False">
                                <div class="row">
                                    <div class="col2">
                                        <span class="requiredStar">*</span>
                                        <asp:Label ID="lblDepartment" runat="server" Text="Department :"></asp:Label>
                                    </div>
                                    <div class="col4">
                                        <asp:DropDownList ID="ddlDepartment" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rvDepartment" runat="server" EnableClientScript="False" CssClass="CustomValidator"
                                            ControlToValidate="ddlDepartment" ValidationGroup="vgView" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Department is required!' /&gt;"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlLocation" runat="server" Visible="False">
                                <div class="row">
                                    <div class="col2">
                                        <asp:Label ID="lblLocation" runat="server" Text="Location :"></asp:Label>
                                    </div>
                                    <div class="col4">
                                        <asp:DropDownList ID="ddlLocation" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rvLocation" runat="server" EnableClientScript="False" CssClass="CustomValidator"
                                            ControlToValidate="ddlLocation" ValidationGroup="vgView" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Location is required' /&gt;"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlMachine" runat="server" Visible="False">
                                <div class="row">
                                    <div class="col2">
                                        <span class="requiredStar">*</span>
                                        <asp:Label ID="lblMachine" runat="server" Text="Machine :"></asp:Label>
                                    </div>
                                    <div class="col4">
                                        <asp:DropDownList ID="ddlMachine" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rvMachine" runat="server" EnableClientScript="False"
                                            ControlToValidate="ddlMachine" ValidationGroup="vgView" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Machine is required' /&gt;"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </asp:Panel>

                            <div class="row">
                                <div class="col8">
                                    <asp:LinkButton ID="btnViewreport" runat="server" CssClass="GenButton  glyphicon glyphicon-search" Text="View Report"
                                        Enabled="False" OnClick="btnViewreport_Click" ValidationGroup="vgView"></asp:LinkButton>

                                    <asp:LinkButton ID="btnEditReport" runat="server" Text="Edit Report"
                                        OnClick="btnEditReport_Click" Enabled="False" CssClass="GenButton  glyphicon glyphicon-edit"></asp:LinkButton>

                                    <asp:LinkButton ID="btnSetAsDefault" runat="server" Text="Set As Default" CssClass="GenButton glyphicon glyphicon-plus-sign"
                                        OnClick="btnSetAsDefault_Click" Enabled="False"></asp:LinkButton>
                                    <asp:LinkButton ID="btnCancel" runat="server" CssClass="GenButton glyphicon glyphicon-remove-circle" Text="Cancel" Visible="False"></asp:LinkButton>
                                </div>

                                <div class="col4">
                                    <asp:TextBox ID="cvValid" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>

                                    <%--<asp:CustomValidator ID="cvShowMsg" runat="server" Display="None"
                                        ValidationGroup="ShowMsg" OnServerValidate="ShowMsg_ServerValidate"
                                        EnableClientScript="False" ControlToValidate="txtValid">
                                    </asp:CustomValidator> --%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--Popup--%>

            <%--<div class="row">
                <div class="col12">
                    <a class="GenButton  glyphicon glyphicon-search" href="#popup1"><%# General.Msg("Fill Parameters", "ادخال المحددات")%> Fill Parameters</a>--%>
                    <%--This is link which opens popup and href should be same as popup id as mentioned above  title="Fill Parameters"--%>


                    <%--<asp:Button ID="btnExport" runat="server" Text="Export" CssClass="buttonBG" OnClick="btnExport_Click"
                                            Enabled="False" Width="100px" Visible="False"  />--%>
                <%--</div>
            </div>--%>

            <%--</div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="row">
        <div class="col12">
            <cc2:StiWebDesigner ID="StiWebDesigner1" runat="server" OnSaveReport="StiWebDesigner1_SaveReport"
                Height="30px" Width="250px" />
        </div>
    </div>
    <div id="popup1" class="overlay">
        <%--The popup Div--%>
        <a class="close" href="#">&times;</a>
        <div class="row">
            <div class="col12">
                <%--<cc1:StiWebViewerFx ID="StiWebViewerFx1" runat="server" Width="100%" Height="600px"
                    Background="White" />--%>
            </div>
        </div>
    </div>
</asp:Content>

