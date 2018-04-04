<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="SettingMachine.aspx.cs" Inherits="Pages_SettingMachine" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Control/Calendar2.ascx" TagPrefix="uc" TagName="Calendar2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                <asp:ListItem Value="MtpNameAr" Text="Machine Type (Ar)" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                <asp:ListItem Value="MtpNameEn" Text="Machine Type (En)" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                <asp:ListItem Value="IPAddress" Text="IPAddress" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                <asp:ListItem Value="MachineNo" Text="Machine No" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                <asp:ListItem Value="LocationAr" Text="Location Name (Ar)" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                <asp:ListItem Value="LocationEn" Text="Location Name (En)" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                <asp:ListItem Value="MachineSerialNo" Text="Machine Serial No" meta:resourcekey="ListItemResource8"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col2">
                            <asp:TextBox ID="txtSearch" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtSearchResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvSearch" runat="server" ControlToValidate="txtSearch" CssClass="CustomValidator"
                                EnableClientScript="False" ValidationGroup="vgSearch" Text="&lt;img src='Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;" meta:resourcekey="rvSearchResource1"></asp:RequiredFieldValidator>
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
                            DataKeyNames="MacID" Width="100%" GridLines="Horizontal" HorizontalAlign="Center"
                            CellPadding="4" AllowPaging="True" OnDataBound="grdData_DataBound" OnSelectedIndexChanged="grdData_SelectedIndexChanged"
                            OnRowDataBound="grdData_RowDataBound" OnSorting="grdData_Sorting" OnRowCreated="grdData_RowCreated"
                            OnPageIndexChanging="grdData_PageIndexChanging" ShowFooter="True" meta:resourcekey="grdDataResource1">
                            <Columns>
                                <asp:BoundField DataField="MtpNameAr" HeaderText="Machine Type (Ar)" SortExpression="MtpNameAr" meta:resourcekey="BoundFieldResource1">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MtpNameEn" HeaderText="Machine Type (En)" SortExpression="MtpNameEn" meta:resourcekey="BoundFieldResource2">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MacID" Visible="False" ReadOnly="True" SortExpression="MacID" meta:resourcekey="BoundFieldResource3">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IPAddress" HeaderText="IP Address" SortExpression="IPAddress" meta:resourcekey="BoundFieldResource4">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LocationAr" HeaderText="Location Name (Ar)" SortExpression="LocationAr" meta:resourcekey="BoundFieldResource5">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LocationEn" HeaderText="Location Name (En)" SortExpression="LocationEn" meta:resourcekey="BoundFieldResource6">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MachineNo" HeaderText="Machine No" SortExpression="MachineNo" meta:resourcekey="BoundFieldResource7">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MachineStatus" HeaderText="Machine Status" SortExpression="MachineStatus" meta:resourcekey="BoundFieldResource8">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Button" SelectText="select" ShowSelectButton="false" meta:resourcekey="CommandFieldResource1" />
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
                <div class="GreySetion">

                    <asp:Panel ID="pnlData" runat="server" CssClass="collapsePanelData" meta:resourcekey="pnlDataResource1">
                        <div class="row">
                            <div class="col8">
                                <asp:LinkButton ID="btnAdd" runat="server" Text="Add" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnAdd_Click" meta:resourcekey="btnAddResource1"></asp:LinkButton>

                                <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CssClass="GenButton  glyphicon glyphicon-edit" Enabled="False"
                                    OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1"></asp:LinkButton>

                                <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CssClass="GenButton glyphicon glyphicon-remove" Enabled="False"
                                    OnClick="btnDelete_Click" meta:resourcekey="btnDeleteResource1"></asp:LinkButton>

                                <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="GenButton glyphicon glyphicon-floppy-disk" Enabled="False"
                                    OnClick="btnSave_Click" ValidationGroup="vgSave" meta:resourcekey="btnSaveResource1"></asp:LinkButton>

                                <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="GenButton glyphicon glyphicon-remove-circle" Enabled="False"
                                    OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1"></asp:LinkButton>
                                <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px" meta:resourcekey="cvtxtResource1"></asp:TextBox>
                                <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="vgShowMsg" CssClass="CustomValidator"
                                    OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvShowMsgResource1"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col12">
                                <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False"
                                    ValidationGroup="vgSave" meta:resourcekey="vsSaveResource1" />
                                <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False"
                                    ValidationGroup="vgShowMsg" meta:resourcekey="vsShowMsgResource1" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <span class="RequiredField">*</span>
                                <asp:Label ID="lblMtpID" runat="server" Text="Machine Type :" meta:resourcekey="lblMtpIDResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:DropDownList ID="ddlMtpID" runat="server" meta:resourcekey="ddlMtpIDResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlMtpID" runat="server" ControlToValidate="ddlMtpID" CssClass="CustomValidator"
                                    EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Machine Type is required!' /&gt;"
                                    ValidationGroup="vgSave" meta:resourcekey="rfvddlMtpIDResource1"></asp:RequiredFieldValidator>


                            </div>
                            <div class="col2">
                                <span class="RequiredField">*</span>
                                <asp:Label ID="lblIPAddress" runat="server" Text="IP Address:" meta:resourcekey="lblIPAddressResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtIPAddress" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtIPAddressResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtIPAddress" runat="server" ControlToValidate="txtIPAddress" CssClass="CustomValidator"
                                    EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='IP Address Type is required!' /&gt;"
                                    ValidationGroup="vgSave" meta:resourcekey="rfvtxtIPAddressResource1"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvIPAddress" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;" CssClass="CustomValidator"
                                    ValidationGroup="vgSave" ErrorMessage="this IP is already there please enter another IP!" OnServerValidate="IPAddress_ServerValidate"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvIPAddressResource1"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                            </div>
                            <div class="col3">
                                <asp:CheckBox ID="chkMacStatus" Text="Active" runat="server" meta:resourcekey="chkMacStatusResource1" />
                            </div>

                            <div class="col2">
                                <span class="RequiredField">*</span>
                                <asp:Label ID="lblPort" runat="server" Text="Port :" meta:resourcekey="lblPortResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtPort" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtPortResource1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblMachineNo" runat="server" Text="Machine No. :" meta:resourcekey="lblMachineNoResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtMachineNo" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtMachineNoResource1"  ></asp:TextBox>
                                <asp:CustomValidator ID="cvMachineNo" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;" CssClass="CustomValidator"
                                    ValidationGroup="vgSave" ErrorMessage="this Machine No is already there please enter another No.!" OnServerValidate="MachineNo_ServerValidate"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvMachineNoResource1"></asp:CustomValidator>
                            </div>

                            <div class="col2">
                                <asp:Label ID="lblMacSerialNo" runat="server" Text="Machine Serial No. :" meta:resourcekey="lblMacSerialNoResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtMacSerialNo" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtMacSerialNoResource1"></asp:TextBox>
                                <asp:CustomValidator ID="cvMacSerialNo" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;" CssClass="CustomValidator"
                                    ValidationGroup="vgSave" ErrorMessage="this Machine serial No. is already there please enter another No.!" OnServerValidate="MachineNo_ServerValidate"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvMacSerialNoResource1"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblMacLocationAr" runat="server" Text="Machine Location (Ar) :" meta:resourcekey="lblMacLocationArResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtMacLocationAr" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtMacLocationArResource1"  ></asp:TextBox>
                                <asp:CustomValidator ID="cvLocationAr" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;"
                                    ValidationGroup="vgSave" ErrorMessage="this Location Ar is already there please enter another Name!" OnServerValidate="cvLocation_ServerValidate"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvLocationArResource1"></asp:CustomValidator>
                            </div>

                            <div class="col2">
                                <span class="RequiredField">*</span>
                                <asp:Label ID="lblMacTypeTrn" runat="server" Text="Machine Type (Trans) :" meta:resourcekey="lblMacTypeTrnResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:DropDownList ID="ddlMacTrnType" runat="server" meta:resourcekey="ddlMacTrnTypeResource1">
                                    <asp:ListItem Text="- Select Trans Type -" Value="10" Selected="True" meta:resourcekey="ListItemResource9"></asp:ListItem>
                                    <asp:ListItem Text="IN" Value="1" meta:resourcekey="ListItemResource10"></asp:ListItem>
                                    <asp:ListItem Text="OUT" Value="0" meta:resourcekey="ListItemResource11"></asp:ListItem>
                                    <asp:ListItem Text="IN/OUT" Value="2" meta:resourcekey="ListItemResource12"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlMacTrnType" runat="server" ControlToValidate="ddlMacTrnType" CssClass="CustomValidator"
                                    EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Machine Type (Trans) is required!' /&gt;"
                                    ValidationGroup="vgSave" meta:resourcekey="rfvddlMacTrnTypeResource1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblMacLocationEn" runat="server" Text="Machine Location (En) :" meta:resourcekey="lblMacLocationEnResource1"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtMacLocationEn" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtMacLocationEnResource1"></asp:TextBox>
                                <asp:CustomValidator ID="cvLocationEn" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;" CssClass="CustomValidator"
                                    ValidationGroup="vgSave" ErrorMessage="this Machine serial No. is already there please enter another No.!" OnServerValidate="MachineNo_ServerValidate"
                                    EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvLocationEnResource1"></asp:CustomValidator>
                                <asp:TextBox ID="txtMachineID" runat="server" Width="10px" Enabled="False" Visible="False" AutoCompleteType="Disabled" meta:resourcekey="txtMachineIDResource1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                            </div>
                            <div class="col3">
                                <asp:CheckBox ID="chkExportData" Text="Export Data" runat="server" meta:resourcekey="chkExportDataResource1" />
                            </div>
                        </div>

                    </asp:Panel>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

