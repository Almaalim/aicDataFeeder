﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="WorkTimeSetting.aspx.cs" Inherits="Pages_WorkTimeSetting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Control/SettingSideMenu.ascx" TagName="SettingSideMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Control/Calendar2.ascx" TagName="Calendar2" TagPrefix="uc" %>
<%@ Register Assembly="TimePickerServerControl" Namespace="TimePickerServerControl" TagPrefix="Almaalim" %>
<%@ Register Assembly="TextTimeServerControl" Namespace="TextTimeServerControl" TagPrefix="Almaalim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:SettingSideMenu ID="SideMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <asp:Panel ID="pnlSearch" runat="server" class="SearchPanel">
                    <table>
                        <tr>
                            <td valign="middle">&nbsp;
                                <asp:Label ID="lblSearch" runat="server" Text="Search By :"></asp:Label>
                                <asp:DropDownList ID="ddlSearch" runat="server" Width="261px" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged"
                                    AutoPostBack="True">
                                    <asp:ListItem Value="[none]" Text="[none]" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="WktNameAr" Text="Worktime Name (Ar)"></asp:ListItem>
                                    <asp:ListItem Value="WktNameEn" Text="Worktime Name (En)"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtSearch" runat="server" Width="500px" Enabled="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rvSearch" runat="server" ControlToValidate="txtSearch"
                                    EnableClientScript="False" ValidationGroup="vgSearch" Text="&lt;img src='Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;">
                                </asp:RequiredFieldValidator>
                                <ajaxToolkit:FilteredTextBoxExtender ID="eFilteredSearch" runat="server" Enabled="True"
                                    FilterType="Numbers" TargetControlID="txtSearch" />
                                <ajaxToolkit:TextBoxWatermarkExtender ID="eWatermarkSearch" runat="server" Enabled="True"
                                    TargetControlID="txtSearch" WatermarkText="can't type" WatermarkCssClass="watermarked" />
                                <%--&nbsp;--%>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="SearchButton" OnClick="btnSearch_Click"
                                    ValidationGroup="vgSearch" Enabled="False" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <div dir="ltr">
                    <table align="left" width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CssClass="vGrid"
                                    DataKeyNames="WktID" Width="100%" GridLines="Horizontal" HorizontalAlign="Center"
                                    CellPadding="4" AllowPaging="True" OnDataBound="grdData_DataBound" OnSelectedIndexChanged="grdData_SelectedIndexChanged"
                                    OnRowDataBound="grdData_RowDataBound" OnSorting="grdData_Sorting" OnRowCreated="grdData_RowCreated"
                                    OnPageIndexChanging="grdData_PageIndexChanging" ShowFooter="True" EnableModelValidation="True">
                                    <Columns>
                                        <asp:BoundField DataField="WktNameAr" HeaderText="Worktime Name (Ar)" SortExpression="WktNameAr">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="WktNameEn" HeaderText="Worktime Name (En)" SortExpression="WktNameEn">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="WktID" Visible="false" ReadOnly="True" SortExpression="WktID">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="WktIsActive" HeaderText="Worktime Status" SortExpression="WktIsActive">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:CommandField ButtonType="Button" SelectText="select" ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle CssClass="header" />
                                    <FooterStyle CssClass="footer" />
                                    <PagerStyle CssClass="pgr" />
                                    <SelectedRowStyle CssClass="selected" />
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="collapsePanelDataBorder">
                                <asp:Panel ID="pnlData" runat="server" CssClass="collapsePanelData">
                                    <table width="100%">
                                        <tr class="td2Allalign">
                                            <td colspan="6" class="collapsePanelButtonBorder">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="ActionButton" OnClick="btnAdd_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="ActionButton" Enabled="False"
                                                    OnClick="btnEdit_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="ActionButton" Enabled="False"
                                                    OnClick="btnDelete_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="ActionButton" OnClick="btnSave_Click"
                                                    ValidationGroup="vgSave" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="ActionButton" Enabled="False"
                                                    OnClick="btnCancel_Click" />
                                                &nbsp;&nbsp;
                                                <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                                                <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="vgShowMsg"
                                                    OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt">
                                                </asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                <asp:ValidationSummary ID="vsSave" runat="server" CssClass="errorValidation" EnableClientScript="False"
                                                    ValidationGroup="VgSave" />
                                                <asp:ValidationSummary runat="server" ID="vsCalShift" ValidationGroup="CalShift"
                                                    EnableClientScript="False" CssClass="errorValidation" />
                                                <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False"
                                                    ValidationGroup="vgShowMsg" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td class="td1Allalign">
                                                            <span class="RequiredField">*</span>
                                                            <asp:Label ID="lblWrokDays" runat="server" Text="Work Days :"></asp:Label>
                                                        </td>
                                                        <td class="td2Allalign">
                                                            <asp:CheckBox ID="chkEwrSat" runat="server" Enabled="False" Text="Saturday" />
                                                            &nbsp;&nbsp;
                                                            <asp:CheckBox ID="chkEwrSun" runat="server" Enabled="False" Text="Sunday" />
                                                            &nbsp;&nbsp;
                                                            <asp:CheckBox ID="chkEwrMon" runat="server" Enabled="False" Text="Monday" />
                                                            &nbsp;&nbsp;
                                                            <asp:CheckBox ID="chkEwrTue" runat="server" Enabled="False" Text="Tuesday" />
                                                            &nbsp;&nbsp;
                                                            <asp:CheckBox ID="chkEwrWed" runat="server" Enabled="False" Text="Wednesday" />
                                                            &nbsp;&nbsp;
                                                            <asp:CheckBox ID="chkEwrThu" runat="server" Enabled="False" Text="Thursday" />
                                                            &nbsp;&nbsp;
                                                            <asp:CheckBox ID="chkEwrFri" runat="server" Enabled="False" Text="Friday" />
                                                            <asp:CustomValidator ID="cvSelectWorkDays" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Select Work Days!' /&gt;"
                                                                ValidationGroup="Users" ErrorMessage="Select Work Days" OnServerValidate="SelectWorkDays_ServerValidate"
                                                                EnableClientScript="False" ControlToValidate="cvtxt"></asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td class="td1Allalign">
                                                            <span class="RequiredField">*</span>
                                                            <asp:Label ID="lblWktStatus" runat="server" Text="Worktime Status :"></asp:Label>
                                                        </td>
                                                        <td class="td2Allalign">
                                                            <asp:CheckBox ID="chkWktStatus" runat="server" Text="Active" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtWktID" Visible="false" runat="server" Width="10px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td class="td1Allalign">
                                                            <span class="RequiredField">*</span>
                                                            <asp:Label ID="lblStartDate" runat="server">Start Date :</asp:Label>
                                                        </td>
                                                        <td class="td2Allalign" valign="middle">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <uc:Calendar2 ID="calStartDate" runat="server" EnableTheming="True" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:CustomValidator ID="cvCalStartDateEmpty" runat="server" Text="&lt;img src='images/Exclamation.gif' title='Start Date is required!' /&gt;"
                                                                            ValidationGroup="VgSave" OnServerValidate="DateValidate_ServerValidate" EnableClientScript="False"
                                                                            ControlToValidate="cvtxt"></asp:CustomValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:CustomValidator ID="cvCompareDates" runat="server" Text="&lt;img src='images/message_exclamation.png' title='start date more than end date!' /&gt;"
                                                                            ValidationGroup="VgSave" ErrorMessage="start date more than end date!" OnServerValidate="DateValidate_ServerValidate"
                                                                            EnableClientScript="False" ControlToValidate="cvtxt"></asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td class="td1Allalign" valign="middle">
                                                            <asp:Label ID="lblEndDate" runat="server" Text="End Date :" meta:resourcekey="lblEndDateResource1"></asp:Label>
                                                        </td>
                                                        <td class="td1Allalign" valign="middle">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <uc:Calendar2 ID="calEndDate" runat="server" EnableTheming="True" />
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:Label ID="lblShift1" runat="server" Text="Shift (1) :"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift1NameAr" runat="server" Text="Shift Name (Ar) :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <asp:TextBox ID="txtShift1NameAr" runat="server" Width="168px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift1NameEn" runat="server" Text="Shift Name (En) :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <asp:TextBox ID="txtShift1NameEn" runat="server" Width="168px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift1In" runat="server" Text="Shift In :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <Almaalim:TimePicker ID="tpShift1In" runat="server" FormatTime="HHmm" CssClass="TimeCss"
                                                                            TimePickerValidationGroup="VgSave" TimePickerValidationText="&lt;img src='../Images/icon/Exclamation.gif' title='Time Shift 1 In is required!' /&gt;" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift1Out" runat="server" Text="Shift Out :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <Almaalim:TimePicker ID="tpShift1Out" runat="server" FormatTime="HHmm" CssClass="TimeCss"
                                                                            TimePickerValidationGroup="VgSave" TimePickerValidationText="&lt;img src='../Images/icon/Exclamation.gif' title='Time Shift 1 Out is required!' /&gt;" />
                                                                        <asp:CustomValidator ID="cvShift1Time" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Enter correct Shift 1 Time' /&gt;"
                                                                            ErrorMessage="Enter correct Shift 1 Time!" ValidationGroup="VgSave" OnServerValidate="Shift1Validate_ServerValidate"
                                                                            EnableClientScript="False" ControlToValidate="cvtxt">
                                                                        </asp:CustomValidator>
                                                                        <asp:CustomValidator ID="cvShift1Cal" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Enter correct Shift 1 Time' /&gt;"
                                                                            ErrorMessage="Enter correct Shift 1 Time!" ValidationGroup="CalShift" OnServerValidate="Shift1Validate_ServerValidate"
                                                                            EnableClientScript="False" ControlToValidate="cvtxt">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift1Duration" runat="server" Text="Duration :"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <Almaalim:TextTime ID="txtShift1Duration" runat="server" FormatTime="hhmm" CssClass="TimeCss" />
                                                                        <asp:CustomValidator ID="cvShift1Duration" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Shift 1 Duration is required!' /&gt;"
                                                                            ValidationGroup="VgSave" OnServerValidate="Shift1Validate_ServerValidate" EnableClientScript="False"
                                                                            ControlToValidate="cvtxt"></asp:CustomValidator>
                                                                        &nbsp;
                                                                        <asp:ImageButton ID="btnCalShift1Duration" runat="server" OnClick="btnCalShift1Duration_Click"
                                                                            ImageUrl="~/Images/icon/button_calculator.png" Enabled="False" ValidationGroup="CalShift"
                                                                            ToolTip="Calculater Shift 1 Duration" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblshift1GraceIn" runat="server" Text="Grace time In :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <Almaalim:TextTime ID="txtShift1GraceIn" runat="server" FormatTime="mm" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:CheckBox ID="chkShift2Set" runat="server" Text="" AutoPostBack="True" OnCheckedChanged="chkShift2Setting_CheckedChanged" />
                                                                        <asp:Label ID="lblShift2" runat="server" Text="Shift (2) :"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift2NameAr" runat="server" Text="Shift Name (Ar) :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <asp:TextBox ID="txtShift2NameAr" runat="server" Width="168px"></asp:TextBox>
                                                                        <asp:CustomValidator ID="cvOrderShfit2" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Shifts must be ordered by time' /&gt;"
                                                                            ErrorMessage="Shifts must be ordered by time!" ValidationGroup="VgSave" OnServerValidate="Shift2Validate_ServerValidate"
                                                                            EnableClientScript="False" ControlToValidate="cvtxt">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift2NameEn" runat="server" Text="Shift Name (En) :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <asp:TextBox ID="txtShift2NameEn" runat="server" Width="168px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift2In" runat="server" Text="Shift In :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <Almaalim:TimePicker ID="tpShift2In" runat="server" FormatTime="HHmm" CssClass="TimeCss"
                                                                            TimePickerValidationGroup="VgSave" TimePickerValidationText="&lt;img src='../Images/icon/Exclamation.gif' title='Time Shift 2 Out is required!' /&gt;" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift2Out" runat="server" Text="Shift Out :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <Almaalim:TimePicker ID="tpShift2Out" runat="server" FormatTime="HHmm" CssClass="TimeCss"
                                                                            TimePickerValidationGroup="VgSave" TimePickerValidationText="&lt;img src='../Images/icon/Exclamation.gif' title='Time Shift 2 In is required!' /&gt;" />
                                                                        <asp:CustomValidator ID="cvShift2Time" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Enter correct Shift 2 Time' /&gt;"
                                                                            ErrorMessage="Enter correct Shift 2 Time!" ValidationGroup="VgSave" OnServerValidate="Shift2Validate_ServerValidate"
                                                                            EnableClientScript="False" ControlToValidate="cvtxt">
                                                                        </asp:CustomValidator>
                                                                        <asp:CustomValidator ID="cvShift2Cal" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Enter correct Shift 2 Time' /&gt;"
                                                                            ErrorMessage="Enter correct Shift 2 Time!" ValidationGroup="CalShift" OnServerValidate="Shift2Validate_ServerValidate"
                                                                            EnableClientScript="False" ControlToValidate="cvtxt">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift2Duration" runat="server" Text="Duration :"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <Almaalim:TextTime ID="txtShift2Duration" runat="server" FormatTime="hhmm" CssClass="TimeCss" />
                                                                        <asp:CustomValidator ID="cvShift2Duration" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Shift 2 Duration is required!' /&gt;"
                                                                            ValidationGroup="VgSave" OnServerValidate="Shift2Validate_ServerValidate" EnableClientScript="False"
                                                                            ControlToValidate="cvtxt"></asp:CustomValidator>
                                                                        &nbsp;
                                                                        <asp:ImageButton ID="btnCalShift2Duration" runat="server" OnClick="btnCalShift2Duration_Click"
                                                                            ImageUrl="~/Images/icon/button_calculator.png" Enabled="False" ValidationGroup="CalShift"
                                                                            ToolTip="Calculater Shift 2 Duration" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift2GraceIn" runat="server" Text="Grace time In :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <Almaalim:TextTime ID="txtShift2GraceIn" runat="server" FormatTime="mm" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:CheckBox ID="chkShift3Set" runat="server" Text="" AutoPostBack="True" OnCheckedChanged="chkShift3Setting_CheckedChanged" />
                                                                        <asp:Label ID="lblShift3" runat="server" Text="Shift (3) :"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift3NameAr" runat="server" Text="Shift Name (Ar) :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <asp:TextBox ID="txtShift3NameAr" runat="server" Width="168px"></asp:TextBox>
                                                                        <asp:CustomValidator ID="cvOrderShfit3" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Shifts must be ordered by time' /&gt;"
                                                                            ErrorMessage="Shifts must be ordered by time!" ValidationGroup="VgSave" OnServerValidate="Shift3Validate_ServerValidate"
                                                                            EnableClientScript="False" ControlToValidate="cvtxt">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift3NameEn" runat="server" Text="Shift Name (En) :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <asp:TextBox ID="txtShift3NameEn" runat="server" Width="168px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift3In" runat="server" Text="Shift In :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <Almaalim:TimePicker ID="tpShift3In" runat="server" FormatTime="HHmm" CssClass="TimeCss"
                                                                            TimePickerValidationGroup="VgSave" TimePickerValidationText="&lt;img src='../Images/icon/Exclamation.gif' title='Time Shift 3 In is required!' /&gt;" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift3Out" runat="server" Text="Shift Out :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <Almaalim:TimePicker ID="tpShift3Out" runat="server" FormatTime="HHmm" CssClass="TimeCss"
                                                                            TimePickerValidationGroup="VgSave" TimePickerValidationText="&lt;img src='../Images/icon/Exclamation.gif' title='Time Shift 3 Out is required!' /&gt;" />
                                                                        <asp:CustomValidator ID="cvShift3Time" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Enter correct Shift 3 Time' /&gt;"
                                                                            ErrorMessage="Enter correct Shift 3 Time!" ValidationGroup="VgSave" OnServerValidate="Shift3Validate_ServerValidate"
                                                                            EnableClientScript="False" ControlToValidate="cvtxt">
                                                                        </asp:CustomValidator>
                                                                        <asp:CustomValidator ID="cvShift3Cal" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Enter correct Shift 3 Time' /&gt;"
                                                                            ErrorMessage="Enter correct Shift 3 Time!" ValidationGroup="CalShift" OnServerValidate="Shift3Validate_ServerValidate"
                                                                            EnableClientScript="False" ControlToValidate="cvtxt">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift3Duration" runat="server" Text="Duration :"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <Almaalim:TextTime ID="txtShift3Duration" runat="server" FormatTime="hhmm" CssClass="TimeCss" />
                                                                        <asp:CustomValidator ID="cvShift3Duration" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Shift 3 Duration is required!' /&gt;"
                                                                            ValidationGroup="VgSave" OnServerValidate="Shift3Validate_ServerValidate" EnableClientScript="False"
                                                                            ControlToValidate="cvtxt"></asp:CustomValidator>
                                                                        &nbsp;
                                                                        <asp:ImageButton ID="btnCalShift3Duration" runat="server" OnClick="btnCalShift3Duration_Click"
                                                                            ImageUrl="~/Images/icon/button_calculator.png" Enabled="False" ValidationGroup="CalShift"
                                                                            ToolTip="Calculater Shift 3 Duration" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td1Allalign">
                                                                        <asp:Label ID="lblShift3GraceIn" runat="server" Text="Grace time In :"></asp:Label>
                                                                    </td>
                                                                    <td class="td2Allalign">
                                                                        <Almaalim:TextTime ID="txtShift3GraceIn" runat="server" FormatTime="mm" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
