<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="ReportsMain.aspx.cs" Inherits="Pages_ReportMain" %>

<%@ Register Src="~/Control/Calendar2.ascx" TagPrefix="uc" TagName="Calendar2" %>
<%@ Register Assembly="Stimulsoft.Report.WebFx" Namespace="Stimulsoft.Report.WebFx" TagPrefix="cc1" %>
<%@ Register Assembly="Stimulsoft.Report.WebDesign" Namespace="Stimulsoft.Report.Web" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnViewreport" />
            <asp:PostBackTrigger ControlID="btnEditReport" />
            <%--<asp:PostBackTrigger ControlID="btnExport" />--%>
            <%--<asp:PostBackTrigger ControlID="lstReport" />--%>
        </Triggers>
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td>
                            <asp:DataList ID="dltReport" runat="server" CaptionAlign="Top" RepeatColumns="4"
                                BorderStyle="None" OnItemCommand="dltReport_ItemCommand"
                                OnItemDataBound="dltReport_ItemDataBound"
                                RepeatDirection="Horizontal" RepeatLayout="Flow" Width="100%">
                                <AlternatingItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                <EditItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                <SelectedItemStyle BackColor="Red" Font-Bold="True" />

                                <ItemTemplate>

                                    <asp:LinkButton ID="lnkBtnEn" CommandArgument='<%# DataBinder.Eval(Container,"dataitem.RepID") %>' CssClass="ReportBtns glyphicon glyphicon-align-left reportsicon"
                                        runat="server" Text='<%# DataBinder.Eval(Container,getRepName()) %>'>
                                        <asp:ImageButton ID="Image1" runat="server" Height="30px" ImageUrl="~/images/reports-icon.png"
                                            Width="30px" CommandArgument='<%# DataBinder.Eval(Container,"dataitem.RepID") %>' />
                                    </asp:LinkButton>

                                </ItemTemplate>
                            </asp:DataList>
                            <%--<table width="100%" bgcolor="#c0c0c0" style="border-left-width: 1px; border-right-width: 1px;"
                                cellspacing="0">
                                <tr>
                                    <td align="center" bgcolor="#c0c0c0" class="Body_BG">
                                        <asp:ListBox ID="lstReport" runat="server" Width="100%" Height="110px" AutoPostBack="True"
                                            OnSelectedIndexChanged="lstReport_SelectedIndexChanged" CssClass="myListBox"
                                            Rows="20"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="border: 2px outset; height: 50px;" width="100%">
                            <table width="100%">
                                <tr>
                                    <td width="50%">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <h3>
                                                    <asp:Label ID="lblSelectedreport" runat="server"></asp:Label>
                                                </h3>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="border: 2px outset; height: 200px;" width="100%" valign="top">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <asp:Panel ID="pnlEmployee" runat="server" Visible="False">
                                                <tr>
                                                    <td colspan="4">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <span class="requiredStar">*</span>
                                                                    <asp:Label ID="lblIDSearch" runat="server" Text="Select Employee By :"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlIDSearch" runat="server" Width="150px">
                                                                        <asp:ListItem Value="EmpID" Text="Employee ID" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Value="EmpNameEn" Text="Employee Name (En)"></asp:ListItem>
                                                                        <asp:ListItem Value="EmpNameAr" Text="Employee Name (Ar)"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtIDSearch" runat="server" Width="150px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CustomValidator ID="cvIDSearch" runat="server" ValidationGroup="vgView" OnServerValidate="IDSearch_ServerValidate"
                                                                        EnableClientScript="False" ControlToValidate="cvValid"></asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlDepartment" runat="server" Visible="False">
                                                <tr>
                                                    <td class="td1align" valign="middle">
                                                        <asp:Label ID="lblDepartment" runat="server" Text="Department :"></asp:Label>
                                                    </td>
                                                    <td class="td2align" valign="middle">
                                                        <asp:DropDownList ID="ddlDepartment" runat="server" Width="168px">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rvDepartment" runat="server" EnableClientScript="False"
                                                            ControlToValidate="ddlDepartment" ValidationGroup="vgView" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Department is required!' /&gt;"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlLocation" runat="server" Visible="False">
                                                <tr>
                                                    <td class="td1align" valign="middle">
                                                        <asp:Label ID="lblLocation" runat="server" Text="Location :"></asp:Label>
                                                    </td>
                                                    <td class="td2align" valign="middle">
                                                        <asp:DropDownList ID="ddlLocation" runat="server" Width="168px">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rvLocation" runat="server" EnableClientScript="False"
                                                            ControlToValidate="ddlLocation" ValidationGroup="vgView" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Location is required' /&gt;"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlMachine" runat="server" Visible="False">
                                                <tr>
                                                    <td class="td1align" valign="middle">
                                                        <asp:Label ID="lblMachine" runat="server" Text="Machine :"></asp:Label>
                                                    </td>
                                                    <td class="td2align" valign="middle">
                                                        <asp:DropDownList ID="ddlMachine" runat="server" Width="168px">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rvMachine" runat="server" EnableClientScript="False"
                                                            ControlToValidate="ddlMachine" ValidationGroup="vgView" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Machine is required' /&gt;"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlDateFromTo" runat="server" Visible="False">
                                                <tr>
                                                    <td class="td1align" valign="middle">
                                                        <asp:Label ID="lblStartDate" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td class="td2align" valign="middle">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <uc:Calendar2 ID="calStartDate" runat="server" CalendarType="System"  ValidationGroup="vgView" />
                                                                </td>
                                                                <td valign="middle">
                                                                    <asp:CustomValidator ID="cvStartDate" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Start Date is required!' /&gt;"
                                                                        ValidationGroup="vgView" OnServerValidate="Date_ServerValidate" EnableClientScript="False"
                                                                        ControlToValidate="cvValid"></asp:CustomValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:CustomValidator ID="cvCompareDates" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='start date more than end date!' /&gt;"
                                                                        ValidationGroup="vgView" ErrorMessage="start date more than end date!" OnServerValidate="Date_ServerValidate"
                                                                        EnableClientScript="False" ControlToValidate="cvValid"></asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="td1align" valign="middle">
                                                        <asp:Label ID="lblEndDate" runat="server" Text="End Date :"></asp:Label>
                                                    </td>
                                                    <td class="td2align" valign="middle">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <uc:Calendar2 ID="calEndDate" runat="server" CalendarType="System"  ValidationGroup="vgView" />
                                                                </td>
                                                                <td valign="middle">
                                                                    <asp:CustomValidator ID="cvEndDate" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='End Date is required!' /&gt;"
                                                                        ValidationGroup="vgView" OnServerValidate="Date_ServerValidate" EnableClientScript="False"
                                                                        ControlToValidate="cvValid"></asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:ValidationSummary runat="server" ID="vsView" ValidationGroup="vgView" EnableClientScript="False"
                                            CssClass="errorValidation" ShowSummary="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="borderButton">
                                        <%--<asp:Button ID="btnViewreport" runat="server" CssClass="buttonBG" Text="View Report"
                                            Enabled="False" OnClick="btnViewreport_Click" Width="100px" ValidationGroup="vgView" />--%>
                                        <asp:LinkButton ID="btnViewreport" runat="server" Text="View Report" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnViewreport_Click" ValidationGroup="vgView"></asp:LinkButton>
                                        <%--<asp:Button ID="btnEditReport" runat="server" Text="Edit Report" CssClass="buttonBG"
                                            OnClick="btnEditReport_Click" Enabled="False" Width="100px" />--%>
                                        <asp:LinkButton ID="btnEditReport" runat="server" Text="Edit Report" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnEditReport_Click" Enabled="False"></asp:LinkButton>
                                        <%--<asp:Button ID="btnSetAsDefault" runat="server" Text="Set As Default" CssClass="buttonBG"
                                            Width="100px" OnClick="btnSetAsDefault_Click" Enabled="False" />--%>
                                        <asp:LinkButton ID="btnSetAsDefault" runat="server" Text="Set As Default" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnSetAsDefault_Click" Enabled="False"></asp:LinkButton>
                                        <%--<asp:Button ID="btnExport" runat="server" Text="Export" CssClass="buttonBG" OnClick="btnExport_Click"
                                            Enabled="False" Width="100px" Visible="False"  />--%>
                                        <%--<asp:Button ID="btnCancel" runat="server" CssClass="buttonBG" Text="Cancel" Visible="False"
                                            Width="100px" />--%>
                                        <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="GenButton glyphicon glyphicon-plus-sign" Visible="False"></asp:LinkButton>
                                        <asp:TextBox ID="cvValid" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                                        
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table border="0" cellpadding="0" cellspacing="4" width="100%">
        <tr>
            <td>
                <cc2:StiWebDesigner ID="StiWebDesigner1" runat="server" OnSaveReport="StiWebDesigner1_SaveReport"
                    Height="30px" Width="250px" />
            </td>
        </tr>
        <%--<tr>
            <td>
                <cc1:StiWebViewerFx ID="StiWebViewerFx1" runat="server" Width="912px" Height="600px"
                    Background="White" />
            </td>
        </tr>--%>
    </table>
</asp:Content>

