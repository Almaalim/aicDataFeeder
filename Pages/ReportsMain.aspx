<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="ReportsMain.aspx.cs" Inherits="Pages_ReportMain" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

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
        </Triggers>
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <table border="0" cellpadding="0" cellspacing="4" width="100%">
                    <tr>
                        <td>
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
                                                    <asp:Label ID="lblSelectedreport" runat="server" meta:resourcekey="lblSelectedreportResource1"></asp:Label>
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
                                            <asp:Panel ID="pnlEmployee" runat="server" Visible="False" meta:resourcekey="pnlEmployeeResource1">
                                                <tr>
                                                    <td colspan="4">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <span class="requiredStar">*</span>
                                                                    <asp:Label ID="lblIDSearch" runat="server" Text="Select Employee By :" meta:resourcekey="lblIDSearchResource1"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlIDSearch" runat="server" Width="150px" meta:resourcekey="ddlIDSearchResource1">
                                                                        <asp:ListItem Value="EmpID" Text="Employee ID" Selected="True" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                                        <asp:ListItem Value="EmpNameEn" Text="Employee Name (En)" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                                                        <asp:ListItem Value="EmpNameAr" Text="Employee Name (Ar)" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtIDSearch" runat="server" Width="150px" meta:resourcekey="txtIDSearchResource1"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CustomValidator ID="cvIDSearch" runat="server" ValidationGroup="vgView" OnServerValidate="IDSearch_ServerValidate"
                                                                        EnableClientScript="False" ControlToValidate="cvValid" meta:resourcekey="cvIDSearchResource1"></asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlDepartment" runat="server" Visible="False" meta:resourcekey="pnlDepartmentResource1">
                                                <tr>
                                                    <td class="td1align" valign="middle">
                                                        <asp:Label ID="lblDepartment" runat="server" Text="Department :" meta:resourcekey="lblDepartmentResource1"></asp:Label>
                                                    </td>
                                                    <td class="td2align" valign="middle">
                                                        <asp:DropDownList ID="ddlDepartment" runat="server" Width="168px" meta:resourcekey="ddlDepartmentResource1">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rvDepartment" runat="server" EnableClientScript="False"
                                                            ControlToValidate="ddlDepartment" ValidationGroup="vgView" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Department is required!' /&gt;" meta:resourcekey="rvDepartmentResource1"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlLocation" runat="server" Visible="False" meta:resourcekey="pnlLocationResource1">
                                                <tr>
                                                    <td class="td1align" valign="middle">
                                                        <asp:Label ID="lblLocation" runat="server" Text="Location :" meta:resourcekey="lblLocationResource1"></asp:Label>
                                                    </td>
                                                    <td class="td2align" valign="middle">
                                                        <asp:DropDownList ID="ddlLocation" runat="server" Width="168px" meta:resourcekey="ddlLocationResource1">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rvLocation" runat="server" EnableClientScript="False"
                                                            ControlToValidate="ddlLocation" ValidationGroup="vgView" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Location is required' /&gt;" meta:resourcekey="rvLocationResource1"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlMachine" runat="server" Visible="False" meta:resourcekey="pnlMachineResource1">
                                                <tr>
                                                    <td class="td1align" valign="middle">
                                                        <asp:Label ID="lblMachine" runat="server" Text="Machine :" meta:resourcekey="lblMachineResource1"></asp:Label>
                                                    </td>
                                                    <td class="td2align" valign="middle">
                                                        <asp:DropDownList ID="ddlMachine" runat="server" Width="168px" meta:resourcekey="ddlMachineResource1">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rvMachine" runat="server" EnableClientScript="False"
                                                            ControlToValidate="ddlMachine" ValidationGroup="vgView" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Machine is required' /&gt;" meta:resourcekey="rvMachineResource1"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlDateFromTo" runat="server" Visible="False" meta:resourcekey="pnlDateFromToResource1">
                                                <tr>
                                                    <td class="td1align" valign="middle">
                                                        <asp:Label ID="lblStartDate" runat="server" Text="Start Date :" meta:resourcekey="lblStartDateResource1"></asp:Label>
                                                    </td>
                                                    <td class="td2align" valign="middle">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <uc:Calendar2 ID="calStartDate" runat="server" CalendarType="System" ValidationGroup="vgView" />
                                                                </td>
                                                                <td valign="middle">
                                                                    <asp:CustomValidator ID="cvStartDate" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Start Date is required!' /&gt;"
                                                                        ValidationGroup="vgView" OnServerValidate="Date_ServerValidate" EnableClientScript="False"
                                                                        ControlToValidate="cvValid" meta:resourcekey="cvStartDateResource1"></asp:CustomValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:CustomValidator ID="cvCompareDates" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='start date more than end date!' /&gt;"
                                                                        ValidationGroup="vgView" ErrorMessage="start date more than end date!" OnServerValidate="Date_ServerValidate"
                                                                        EnableClientScript="False" ControlToValidate="cvValid" meta:resourcekey="cvCompareDatesResource1"></asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="td1align" valign="middle">
                                                        <asp:Label ID="lblEndDate" runat="server" Text="End Date :" meta:resourcekey="lblEndDateResource1"></asp:Label>
                                                    </td>
                                                    <td class="td2align" valign="middle">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <uc:Calendar2 ID="calEndDate" runat="server" CalendarType="System" ValidationGroup="vgView" />
                                                                </td>
                                                                <td valign="middle">
                                                                    <asp:CustomValidator ID="cvEndDate" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='End Date is required!' /&gt;"
                                                                        ValidationGroup="vgView" OnServerValidate="Date_ServerValidate" EnableClientScript="False"
                                                                        ControlToValidate="cvValid" meta:resourcekey="cvEndDateResource1"></asp:CustomValidator>
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
                                            CssClass="errorValidation" ShowSummary="False" meta:resourcekey="vsViewResource1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="borderButton">
                                        <asp:LinkButton ID="btnViewreport" runat="server" Text="View Report" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnViewreport_Click" ValidationGroup="vgView" meta:resourcekey="btnViewreportResource1"></asp:LinkButton>
                                        <asp:LinkButton ID="btnEditReport" runat="server" Text="Edit Report" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnEditReport_Click" Enabled="False" meta:resourcekey="btnEditReportResource1"></asp:LinkButton>
                                        <asp:LinkButton ID="btnSetAsDefault" runat="server" Text="Set As Default" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnSetAsDefault_Click" Enabled="False" meta:resourcekey="btnSetAsDefaultResource1"></asp:LinkButton>
                                        <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="GenButton glyphicon glyphicon-plus-sign" Visible="False" meta:resourcekey="btnCancelResource1"></asp:LinkButton>
                                        <asp:TextBox ID="cvValid" runat="server" Text="02120" Visible="False" Width="10px" meta:resourcekey="cvValidResource1"></asp:TextBox>
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
                    Height="30px" Width="250px" BrowserTitle="" ExitUrl="" ImageFormat="Png" ImageQuality="Normal" LocalizationDirectory="" meta:resourcekey="StiWebDesigner1Resource1" ReportGuid="72ce1edf9928430b" ServerTimeout="00:10:00" ShowWizardOnStartup="False" ThemeName="Office2013" Visible="False" WebImageHost="Stimulsoft.Report.Web.StiWebDesignerImageHost" />
            </td>
        </tr>
    </table>
</asp:Content>

