<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="WorkTimeSetting.aspx.cs" Inherits="Pages_WorkTimeSetting" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Control/SettingSideMenu.ascx" TagName="SettingSideMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Control/Calendar2.ascx" TagName="Calendar2" TagPrefix="uc" %>
<%@ Register Assembly="TimePickerServerControl" Namespace="TimePickerServerControl" TagPrefix="Almaalimtp" %>
<%@ Register Assembly="TextTimeServerControl" Namespace="TextTimeServerControl" TagPrefix="Almaalimtt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:SettingSideMenu ID="SideMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <asp:Panel ID="pnlSearch" runat="server" class="SearchPanel" meta:resourcekey="pnlSearchResource1">
                    <div class="row">
                        <div class="col1">
                            <asp:Label ID="lblSearch" runat="server" Text="Search By :" meta:resourcekey="lblSearchResource1"></asp:Label>
                        </div>

                        <div class="col2">
                            <asp:DropDownList ID="ddlSearch" runat="server" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged"
                                AutoPostBack="True" meta:resourcekey="ddlSearchResource1">
                                <asp:ListItem Value="[none]" Text="[none]" Selected="True" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                <asp:ListItem Value="WktNameAr" Text="Worktime Name (Ar)" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                <asp:ListItem Value="WktNameEn" Text="Worktime Name (En)" meta:resourcekey="ListItemResource3"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col2">
                            <asp:TextBox ID="txtSearch" runat="server" Enabled="False" meta:resourcekey="txtSearchResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvSearch" runat="server" ControlToValidate="txtSearch" CssClass="CustomValidator"
                                EnableClientScript="False" ValidationGroup="vgSearch" Text="&lt;img src='../Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;" meta:resourcekey="rvSearchResource1"></asp:RequiredFieldValidator>
                            <ajaxToolkit:FilteredTextBoxExtender ID="eFilteredSearch" runat="server" Enabled="True"
                                FilterType="Numbers" TargetControlID="txtSearch" />
                            <ajaxToolkit:TextBoxWatermarkExtender ID="eWatermarkSearch" runat="server" Enabled="True"
                                TargetControlID="txtSearch" WatermarkText="can't type" WatermarkCssClass="watermarked" />
                        </div>

                        <div class="col3">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="SearchButton" OnClick="btnSearch_Click"
                                ValidationGroup="vgSearch" Enabled="False" meta:resourcekey="btnSearchResource1" />
                        </div>
                    </div>
                </asp:Panel>
                <div class="row">
                    <div class="col12">
                        <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CssClass="GridTable"
                            DataKeyNames="WktID" Width="100%" GridLines="Horizontal" HorizontalAlign="Center"
                            CellPadding="4" AllowPaging="True" OnDataBound="grdData_DataBound" OnSelectedIndexChanged="grdData_SelectedIndexChanged"
                            OnRowDataBound="grdData_RowDataBound" OnSorting="grdData_Sorting" OnRowCreated="grdData_RowCreated"
                            OnPageIndexChanging="grdData_PageIndexChanging" ShowFooter="True" meta:resourcekey="grdDataResource1">
                            <Columns>
                                <asp:BoundField DataField="WktNameAr" HeaderText="Worktime Name (Ar)" SortExpression="WktNameAr" meta:resourcekey="BoundFieldResource1">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="WktNameEn" HeaderText="Worktime Name (En)" SortExpression="WktNameEn" meta:resourcekey="BoundFieldResource2">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="WktID" Visible="False" ReadOnly="True" SortExpression="WktID" meta:resourcekey="BoundFieldResource3">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="WktIsActive" HeaderText="Worktime Status" SortExpression="WktIsActive" meta:resourcekey="BoundFieldResource4">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Button" SelectText="select" ShowSelectButton="True" meta:resourcekey="CommandFieldResource1" />
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
                <asp:Panel ID="pnlData" runat="server" CssClass="collapsePanelData" meta:resourcekey="pnlDataResource1">
                    <div class="GreySetion">
                        <div class="row">
                            <div class="col8">
                                <asp:LinkButton ID="btnAdd" runat="server" Text="Add" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnAdd_Click" meta:resourcekey="btnAddResource1"></asp:LinkButton>
                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CssClass="GenButton  glyphicon glyphicon-edit" Enabled="False"
                                                    OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1"></asp:LinkButton>
                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CssClass="GenButton glyphicon glyphicon-remove" Enabled="False"
                                                    OnClick="btnDelete_Click" meta:resourcekey="btnDeleteResource1"></asp:LinkButton>
                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="GenButton glyphicon glyphicon-floppy-disk" OnClick="btnSave_Click"
                                                    ValidationGroup="vgSave" meta:resourcekey="btnSaveResource1"></asp:LinkButton>
                                &nbsp;&nbsp;
                                                <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="GenButton glyphicon glyphicon-remove-circle" Enabled="False"
                                                    OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1"></asp:LinkButton>
                                &nbsp;&nbsp;
                                                <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px" meta:resourcekey="cvtxtResource1"></asp:TextBox>
                                <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="vgShowMsg" CssClass="CustomValidator"
                                    OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvShowMsgResource1"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col12">
                                <asp:ValidationSummary ID="vsSave" runat="server" CssClass="errorValidation" EnableClientScript="False"
                                    ValidationGroup="VgSave" meta:resourcekey="vsSaveResource1" />
                                <asp:ValidationSummary runat="server" ID="vsCalShift" ValidationGroup="CalShift"
                                    EnableClientScript="False" CssClass="errorValidation" meta:resourcekey="vsCalShiftResource1" />
                                <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False"
                                    ValidationGroup="vgShowMsg" meta:resourcekey="vsShowMsgResource1" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <span class="RequiredField">*</span>
                                <asp:Label ID="lblWorkNameAr" runat="server" Text="Work Name (Ar):" meta:resourcekey="lblWorkNameArResource1" ></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtWorkNameAr" runat="server" meta:resourcekey="txtWorkNameArResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvWorkNameAr" runat="server" ValidationGroup="VgSave" ControlToValidate="txtWorkNameAr" CssClass="CustomValidator"
                                    EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Work Name (Ar) is required' /&gt;" meta:resourcekey="rfvWorkNameArResource1"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col2">
                                <asp:Label ID="lblWorkNameEn" runat="server" Text="Work Name (En) :" meta:resourcekey="lblWorkNameEnResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtWorkNameEn" runat="server" meta:resourcekey="txtWorkNameEnResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvWorkNameEn" runat="server" ValidationGroup="VgSave" ControlToValidate="txtWorkNameEn" CssClass="CustomValidator"
                                    EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Work Name (En) is required' /&gt;" meta:resourcekey="rfvWorkNameEnResource1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <span class="RequiredField">*</span>
                                <asp:Label ID="lblWrokDays" runat="server" Text="Work Days :" meta:resourcekey="lblWrokDaysResource1"></asp:Label>
                            </div>
                            <div class="col10">
                                <asp:CheckBox ID="chkEwrSat" runat="server" Enabled="False" Text="Saturday" meta:resourcekey="chkEwrSatResource1" />
                                &nbsp;&nbsp;
                                                            <asp:CheckBox ID="chkEwrSun" runat="server" Enabled="False" Text="Sunday" meta:resourcekey="chkEwrSunResource1" />
                                &nbsp;&nbsp;
                                                            <asp:CheckBox ID="chkEwrMon" runat="server" Enabled="False" Text="Monday" meta:resourcekey="chkEwrMonResource1" />
                                &nbsp;&nbsp;
                                                            <asp:CheckBox ID="chkEwrTue" runat="server" Enabled="False" Text="Tuesday" meta:resourcekey="chkEwrTueResource1" />
                                &nbsp;&nbsp;
                                                            <asp:CheckBox ID="chkEwrWed" runat="server" Enabled="False" Text="Wednesday" meta:resourcekey="chkEwrWedResource1" />
                                &nbsp;&nbsp;
                                                            <asp:CheckBox ID="chkEwrThu" runat="server" Enabled="False" Text="Thursday" meta:resourcekey="chkEwrThuResource1" />
                                &nbsp;&nbsp;
                                                            <asp:CheckBox ID="chkEwrFri" runat="server" Enabled="False" Text="Friday" meta:resourcekey="chkEwrFriResource1" />
                                <asp:CustomValidator ID="cvSelectWorkDays" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Select Work Days!' /&gt;"
                                    ValidationGroup="Users" ErrorMessage="Select Work Days" OnServerValidate="SelectWorkDays_ServerValidate" CssClass="CustomValidator"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvSelectWorkDaysResource1"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <span class="RequiredField">*</span>
                                <asp:Label ID="lblWktStatus" runat="server" Text="Worktime Status :" meta:resourcekey="lblWktStatusResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:CheckBox ID="chkWktStatus" runat="server" Text="Active" meta:resourcekey="chkWktStatusResource1" />

                                <asp:TextBox ID="txtWktID" Visible="False" runat="server" Width="10px" meta:resourcekey="txtWktIDResource1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <span class="RequiredField">*</span>
                                <asp:Label ID="lblStartDate" runat="server" meta:resourcekey="lblStartDateResource1">Start Date :</asp:Label>
                            </div>
                            <div class="col3">
                                <uc:Calendar2 ID="calStartDate" runat="server" EnableTheming="True" />

                                <asp:CustomValidator ID="cvCalStartDateEmpty" runat="server" Text="&lt;img src='images/Exclamation.gif' title='Start Date is required!' /&gt;"
                                    ValidationGroup="VgSave" OnServerValidate="DateValidate_ServerValidate" EnableClientScript="False" CssClass="CustomValidator"
                                    ControlToValidate="cvtxt" meta:resourcekey="cvCalStartDateEmptyResource1"></asp:CustomValidator>

                                <asp:CustomValidator ID="cvCompareDates" runat="server" Text="&lt;img src='images/message_exclamation.png' title='start date more than end date!' /&gt;"
                                    ValidationGroup="VgSave" ErrorMessage="start date more than end date!" OnServerValidate="DateValidate_ServerValidate" CssClass="CustomValidator"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvCompareDatesResource1"></asp:CustomValidator>
                            </div>

                            <div class="col2">
                                <asp:Label ID="lblEndDate" runat="server" Text="End Date :" meta:resourcekey="lblEndDateResource1" ></asp:Label>
                            </div>
                            <div class="col3">
                                <uc:Calendar2 ID="calEndDate" runat="server" EnableTheming="True" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col12 h3">
                                <asp:Label ID="lblShift1" runat="server" Text="Shift (1) :" meta:resourcekey="lblShift1Resource1" ></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblShift1NameAr" runat="server" Text="Shift Name (Ar) :" meta:resourcekey="lblShift1NameArResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtShift1NameAr" runat="server" meta:resourcekey="txtShift1NameArResource1"></asp:TextBox>
                            </div>

                            <div class="col2">
                                <asp:Label ID="lblShift1NameEn" runat="server" Text="Shift Name (En) :" meta:resourcekey="lblShift1NameEnResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtShift1NameEn" runat="server" meta:resourcekey="txtShift1NameEnResource1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblShift1In" runat="server" Text="Shift In :" meta:resourcekey="lblShift1InResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <Almaalimtp:TimePicker ID="tpShift1In" runat="server" FormatTime="HHmm" CssClass="TimeCss"
                                    TimePickerValidationGroup="VgSave" TimePickerValidationText="&lt;img src='../Images/icon/Exclamation.gif' title='Time Shift 1 In is required!' /&gt;" meta:resourcekey="tpShift1InResource1" />
                            </div>

                            <div class="col2">
                                <asp:Label ID="lblShift1Out" runat="server" Text="Shift Out :" meta:resourcekey="lblShift1OutResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <Almaalimtp:TimePicker ID="tpShift1Out" runat="server" FormatTime="HHmm" CssClass="TimeCss"
                                    TimePickerValidationGroup="VgSave" TimePickerValidationText="&lt;img src='../Images/icon/Exclamation.gif' title='Time Shift 1 Out is required!' /&gt;" meta:resourcekey="tpShift1OutResource1" />
                                <asp:CustomValidator ID="cvShift1Time" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Enter correct Shift 1 Time' /&gt;"
                                    ErrorMessage="Enter correct Shift 1 Time!" ValidationGroup="VgSave" OnServerValidate="Shift1Validate_ServerValidate" CssClass="CustomValidator"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvShift1TimeResource1"></asp:CustomValidator>
                                <asp:CustomValidator ID="cvShift1Cal" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Enter correct Shift 1 Time' /&gt;"
                                    ErrorMessage="Enter correct Shift 1 Time!" ValidationGroup="CalShift" OnServerValidate="Shift1Validate_ServerValidate" CssClass="CustomValidator"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvShift1CalResource1"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblShift1Duration" runat="server" Text="Duration :" meta:resourcekey="lblShift1DurationResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <Almaalimtt:TextTime ID="txtShift1Duration" runat="server" FormatTime="hhmm" CssClass="TimeCss" meta:resourcekey="txtShift1DurationResource1" TextTimeValidationGroup="" TextTimeValidationText="" />
                                <asp:CustomValidator ID="cvShift1Duration" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Shift 1 Duration is required!' /&gt;"
                                    ValidationGroup="VgSave" OnServerValidate="Shift1Validate_ServerValidate" EnableClientScript="False" CssClass="CustomValidator"
                                    ControlToValidate="cvtxt" meta:resourcekey="cvShift1DurationResource1"></asp:CustomValidator>

                                <asp:ImageButton ID="btnCalShift1Duration" runat="server" OnClick="btnCalShift1Duration_Click"
                                    ImageUrl="~/Images/icon/button_calculator.png" Enabled="False" ValidationGroup="CalShift"
                                    ToolTip="Calculater Shift 1 Duration" meta:resourcekey="btnCalShift1DurationResource1" />
                            </div>

                            <div class="col2">
                                <asp:Label ID="lblshift1GraceIn" runat="server" Text="Grace time In :" meta:resourcekey="lblshift1GraceInResource1"></asp:Label>
                            </div>

                            <div class="col3">
                                <Almaalimtt:TextTime ID="txtShift1GraceIn" runat="server" FormatTime="mm" meta:resourcekey="txtShift1GraceInResource1" TextTimeValidationGroup="" TextTimeValidationText="" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col12 h3">
                                <asp:CheckBox ID="chkShift2Set" runat="server" AutoPostBack="True" OnCheckedChanged="chkShift2Setting_CheckedChanged" meta:resourcekey="chkShift2SetResource1" />
                                <asp:Label ID="lblShift2" runat="server" Text="Shift (2) :" meta:resourcekey="lblShift2Resource1"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblShift2NameAr" runat="server" Text="Shift Name (Ar) :" meta:resourcekey="lblShift2NameArResource1"></asp:Label>
                            </div>

                            <div class="col3">
                                <asp:TextBox ID="txtShift2NameAr" runat="server" meta:resourcekey="txtShift2NameArResource1"></asp:TextBox>
                                <asp:CustomValidator ID="cvOrderShfit2" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Shifts must be ordered by time' /&gt;"
                                    ErrorMessage="Shifts must be ordered by time!" ValidationGroup="VgSave" OnServerValidate="Shift2Validate_ServerValidate" CssClass="CustomValidator"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvOrderShfit2Resource1"></asp:CustomValidator>
                            </div>

                            <div class="col2">
                                <asp:Label ID="lblShift2NameEn" runat="server" Text="Shift Name (En) :" meta:resourcekey="lblShift2NameEnResource1"></asp:Label>
                            </div>

                            <div class="col3">
                                <asp:TextBox ID="txtShift2NameEn" runat="server" meta:resourcekey="txtShift2NameEnResource1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblShift2In" runat="server" Text="Shift In :" meta:resourcekey="lblShift2InResource1"></asp:Label>
                            </div>

                            <div class="col3">
                                <Almaalimtp:TimePicker ID="tpShift2In" runat="server" FormatTime="HHmm" CssClass="TimeCss"
                                    TimePickerValidationGroup="VgSave" TimePickerValidationText="&lt;img src='../Images/icon/Exclamation.gif' title='Time Shift 2 Out is required!' /&gt;" meta:resourcekey="tpShift2InResource1" />
                            </div>

                            <div class="col2">
                                <asp:Label ID="lblShift2Out" runat="server" Text="Shift Out :" meta:resourcekey="lblShift2OutResource1"></asp:Label>
                            </div>

                            <div class="col3">
                                <Almaalimtp:TimePicker ID="tpShift2Out" runat="server" FormatTime="HHmm" CssClass="TimeCss"
                                    TimePickerValidationGroup="VgSave" TimePickerValidationText="&lt;img src='../Images/icon/Exclamation.gif' title='Time Shift 2 In is required!' /&gt;" meta:resourcekey="tpShift2OutResource1" />
                                <asp:CustomValidator ID="cvShift2Time" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Enter correct Shift 2 Time' /&gt;"
                                    ErrorMessage="Enter correct Shift 2 Time!" ValidationGroup="VgSave" OnServerValidate="Shift2Validate_ServerValidate" CssClass="CustomValidator"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvShift2TimeResource1"></asp:CustomValidator>
                                <asp:CustomValidator ID="cvShift2Cal" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Enter correct Shift 2 Time' /&gt;"
                                    ErrorMessage="Enter correct Shift 2 Time!" ValidationGroup="CalShift" OnServerValidate="Shift2Validate_ServerValidate" CssClass="CustomValidator"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvShift2CalResource1"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblShift2Duration" runat="server" Text="Duration :" meta:resourcekey="lblShift2DurationResource1"></asp:Label>
                            </div>

                            <div class="col3">
                                <Almaalimtt:TextTime ID="txtShift2Duration" runat="server" FormatTime="hhmm" CssClass="TimeCss" meta:resourcekey="txtShift2DurationResource1" TextTimeValidationGroup="" TextTimeValidationText="" />
                                <asp:CustomValidator ID="cvShift2Duration" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Shift 2 Duration is required!' /&gt;"
                                    ValidationGroup="VgSave" OnServerValidate="Shift2Validate_ServerValidate" EnableClientScript="False" CssClass="CustomValidator"
                                    ControlToValidate="cvtxt" meta:resourcekey="cvShift2DurationResource1"></asp:CustomValidator>

                                <asp:ImageButton ID="btnCalShift2Duration" runat="server" OnClick="btnCalShift2Duration_Click"
                                    ImageUrl="~/Images/icon/button_calculator.png" Enabled="False" ValidationGroup="CalShift"
                                    ToolTip="Calculater Shift 2 Duration" meta:resourcekey="btnCalShift2DurationResource1" />
                            </div>

                            <div class="col2">
                                <asp:Label ID="lblShift2GraceIn" runat="server" Text="Grace time In :" meta:resourcekey="lblShift2GraceInResource1"></asp:Label>
                            </div>

                            <div class="col3">
                                <Almaalimtt:TextTime ID="txtShift2GraceIn" runat="server" FormatTime="mm" meta:resourcekey="txtShift2GraceInResource1" TextTimeValidationGroup="" TextTimeValidationText="" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col12 h3">
                                <asp:CheckBox ID="chkShift3Set" runat="server" AutoPostBack="True" OnCheckedChanged="chkShift3Setting_CheckedChanged" meta:resourcekey="chkShift3SetResource1" />
                                <asp:Label ID="lblShift3" runat="server" Text="Shift (3) :" meta:resourcekey="lblShift3Resource1"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblShift3NameAr" runat="server" Text="Shift Name (Ar) :" meta:resourcekey="lblShift3NameArResource1"></asp:Label>
                            </div>

                            <div class="col3">
                                <asp:TextBox ID="txtShift3NameAr" runat="server" meta:resourcekey="txtShift3NameArResource1"></asp:TextBox>
                                <asp:CustomValidator ID="cvOrderShfit3" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Shifts must be ordered by time' /&gt;"
                                    ErrorMessage="Shifts must be ordered by time!" ValidationGroup="VgSave" OnServerValidate="Shift3Validate_ServerValidate"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvOrderShfit3Resource1"></asp:CustomValidator>
                            </div>

                            <div class="col2">
                                <asp:Label ID="lblShift3NameEn" runat="server" Text="Shift Name (En) :" meta:resourcekey="lblShift3NameEnResource1"></asp:Label>
                            </div>

                            <div class="col3">
                                <asp:TextBox ID="txtShift3NameEn" runat="server" meta:resourcekey="txtShift3NameEnResource1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblShift3In" runat="server" Text="Shift In :" meta:resourcekey="lblShift3InResource1"></asp:Label>
                            </div>

                            <div class="col3">
                                <Almaalimtp:TimePicker ID="tpShift3In" runat="server" FormatTime="HHmm" CssClass="TimeCss"
                                    TimePickerValidationGroup="VgSave" TimePickerValidationText="&lt;img src='../Images/icon/Exclamation.gif' title='Time Shift 3 In is required!' /&gt;" meta:resourcekey="tpShift3InResource1" />
                            </div>

                            <div class="col2">
                                <asp:Label ID="lblShift3Out" runat="server" Text="Shift Out :" meta:resourcekey="lblShift3OutResource1"></asp:Label>
                            </div>

                            <div class="col3">
                                <Almaalimtp:TimePicker ID="tpShift3Out" runat="server" FormatTime="HHmm" CssClass="TimeCss"
                                    TimePickerValidationGroup="VgSave" TimePickerValidationText="&lt;img src='../Images/icon/Exclamation.gif' title='Time Shift 3 Out is required!' /&gt;" meta:resourcekey="tpShift3OutResource1" />
                                <asp:CustomValidator ID="cvShift3Time" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Enter correct Shift 3 Time' /&gt;"
                                    ErrorMessage="Enter correct Shift 3 Time!" ValidationGroup="VgSave" OnServerValidate="Shift3Validate_ServerValidate" CssClass="CustomValidator"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvShift3TimeResource1"></asp:CustomValidator>
                                <asp:CustomValidator ID="cvShift3Cal" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='Enter correct Shift 3 Time' /&gt;"
                                    ErrorMessage="Enter correct Shift 3 Time!" ValidationGroup="CalShift" OnServerValidate="Shift3Validate_ServerValidate" CssClass="CustomValidator"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvShift3CalResource1"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblShift3Duration" runat="server" Text="Duration :" meta:resourcekey="lblShift3DurationResource1"></asp:Label>
                            </div>

                            <div class="col3">
                                <Almaalimtt:TextTime ID="txtShift3Duration" runat="server" FormatTime="hhmm" CssClass="TimeCss" meta:resourcekey="txtShift3DurationResource1" TextTimeValidationGroup="" TextTimeValidationText="" />
                                <asp:CustomValidator ID="cvShift3Duration" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Shift 3 Duration is required!' /&gt;"
                                    ValidationGroup="VgSave" OnServerValidate="Shift3Validate_ServerValidate" EnableClientScript="False" CssClass="CustomValidator"
                                    ControlToValidate="cvtxt" meta:resourcekey="cvShift3DurationResource1"></asp:CustomValidator>

                                <asp:ImageButton ID="btnCalShift3Duration" runat="server" OnClick="btnCalShift3Duration_Click"
                                    ImageUrl="~/Images/icon/button_calculator.png" Enabled="False" ValidationGroup="CalShift"
                                    ToolTip="Calculater Shift 3 Duration" meta:resourcekey="btnCalShift3DurationResource1" />
                            </div>

                            <div class="col2">
                                <asp:Label ID="lblShift3GraceIn" runat="server" Text="Grace time In :" meta:resourcekey="lblShift3GraceInResource1"></asp:Label>
                            </div>

                            <div class="col3">
                                <Almaalimtt:TextTime ID="txtShift3GraceIn" runat="server" FormatTime="mm" meta:resourcekey="txtShift3GraceInResource1" TextTimeValidationGroup="" TextTimeValidationText="" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
