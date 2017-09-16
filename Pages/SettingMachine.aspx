<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="SettingMachine.aspx.cs" Inherits="Pages_SettingMachine" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Control/Calendar2.ascx" TagPrefix="uc" TagName="Calendar2" %>
<%@ Register Src="~/Control/MachineSideMenu.ascx" TagName="MachineSideMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:MachineSideMenu ID="SideMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <asp:Panel ID="pnlSearch" runat="server" class="SearchPanel">
                    <div class="row">
                        <div class="col1">
                            <asp:Label ID="lblSearch" runat="server" Text="Search By :"></asp:Label>
                        </div>

                        <div class="col2">
                            <asp:DropDownList ID="ddlSearch" runat="server" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged"
                                AutoPostBack="True">
                                <asp:ListItem Value="[none]" Text="[none]" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="MtpNameAr" Text="Machine Type (Ar)"></asp:ListItem>
                                <asp:ListItem Value="MtpNameEn" Text="Machine Type (En)"></asp:ListItem>
                                <asp:ListItem Value="IPAddress" Text="IPAddress"></asp:ListItem>
                                <asp:ListItem Value="MachineNo" Text="Machine No"></asp:ListItem>
                                <asp:ListItem Value="LocationAr" Text="Location Name (Ar)"></asp:ListItem>
                                <asp:ListItem Value="LocationEn" Text="Location Name (En)"></asp:ListItem>
                                <asp:ListItem Value="MachineSerialNo" Text="Machine Serial No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col2">
                            <asp:TextBox ID="txtSearch" runat="server" Enabled="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvSearch" runat="server" ControlToValidate="txtSearch" CssClass="CustomValidator"
                                EnableClientScript="False" ValidationGroup="vgSearch" Text="&lt;img src='Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;">
                            </asp:RequiredFieldValidator>
                            <ajaxToolkit:FilteredTextBoxExtender ID="eFilteredSearch" runat="server" Enabled="True"
                                FilterType="Numbers" TargetControlID="txtSearch" />
                            <ajaxToolkit:TextBoxWatermarkExtender ID="eWatermarkSearch" runat="server" Enabled="True"
                                TargetControlID="txtSearch" WatermarkText="can't type" WatermarkCssClass="watermarked" />
                        </div>

                        <div class="col3">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="SearchButton" OnClick="btnSearch_Click"
                                ValidationGroup="vgSearch" Enabled="False" />
                        </div>
                    </div>
                </asp:Panel>
                <div class="row">
                    <div class="col12">
                        <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CssClass="vGrid"
                            DataKeyNames="MacID" Width="100%" GridLines="Horizontal" HorizontalAlign="Center"
                            CellPadding="4" AllowPaging="True" OnDataBound="grdData_DataBound" OnSelectedIndexChanged="grdData_SelectedIndexChanged"
                            OnRowDataBound="grdData_RowDataBound" OnSorting="grdData_Sorting" OnRowCreated="grdData_RowCreated"
                            OnPageIndexChanging="grdData_PageIndexChanging" ShowFooter="True" EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="MtpNameAr" HeaderText="Machine Type (Ar)" SortExpression="MtpNameAr">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MtpNameEn" HeaderText="Machine Type (En)" SortExpression="MtpNameEn">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MacID" Visible="false" ReadOnly="True" SortExpression="MacID">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IPAddress" HeaderText="IP Address" SortExpression="IPAddress">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LocationAr" HeaderText="Location Name (Ar)" SortExpression="LocationAr">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LocationEn" HeaderText="Location Name (En)" SortExpression="LocationEn">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MachineNo" HeaderText="Machine No" SortExpression="MachineNo">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MachineStatus" HeaderText="Machine Status" SortExpression="MachineStatus">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Button" SelectText="select" ShowSelectButton="True" />
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
                <div class="GreySetion">

                    <%--<ajaxToolkit:CollapsiblePanelExtender ID="epnlData" runat="server" Enabled="True"
                                    TargetControlID="pnlData" CollapsedSize="0" Collapsed="true" ExpandControlID="pnlTitel"
                                    CollapseControlID="pnlTitel" AutoCollapse="false" AutoExpand="false" CollapsedText="(Show Details...)"
                                    ExpandedText="(Hide Details)" ExpandDirection="Vertical" TextLabelID="lblTitel"
                                    ImageControlID="imgTitel" ExpandedImage="~/Images/collapse.jpg" CollapsedImage="~/Images/expand.jpg">
                                </ajaxToolkit:CollapsiblePanelExtender>--%>
                    <asp:Panel ID="pnlData" runat="server" CssClass="collapsePanelData">
                        <div class="row">
                            <div class="col8">
                                <asp:LinkButton ID="btnAdd" runat="server" Text="Add" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnAdd_Click"></asp:LinkButton>

                                <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CssClass="GenButton  glyphicon glyphicon-edit" Enabled="false"
                                    OnClick="btnEdit_Click"></asp:LinkButton>

                                <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CssClass="GenButton glyphicon glyphicon-remove" Enabled="false"
                                    OnClick="btnDelete_Click"></asp:LinkButton>

                                <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="GenButton glyphicon glyphicon-floppy-disk" Enabled="false"
                                    OnClick="btnSave_Click" ValidationGroup="vgSave"></asp:LinkButton>

                                <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="GenButton glyphicon glyphicon-remove-circle" Enabled="false"
                                    OnClick="btnCancel_Click"></asp:LinkButton>
                                <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                                <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="vgShowMsg" CssClass="CustomValidator"
                                    OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt">
                                </asp:CustomValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col12">
                                <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False"
                                    ValidationGroup="vgSave" />
                                <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False"
                                    ValidationGroup="vgShowMsg" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <span class="RequiredField">*</span>
                                <asp:Label ID="lblMtpID" runat="server" Text="Machine Type :"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:DropDownList ID="ddlMtpID" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlMtpID" runat="server" ControlToValidate="ddlMtpID" CssClass="CustomValidator"
                                    EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Machine Type is required!' /&gt;"
                                    ValidationGroup="vgSave"></asp:RequiredFieldValidator>


                            </div>
                            <div class="col2">
                                <span class="RequiredField">*</span>
                                <asp:Label ID="lblIPAddress" runat="server" Text="IP Address:"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtIPAddress" runat="server" Enabled="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtIPAddress" runat="server" ControlToValidate="txtIPAddress" CssClass="CustomValidator"
                                    EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='IP Address Type is required!' /&gt;"
                                    ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvIPAddress" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;" CssClass="CustomValidator"
                                    ValidationGroup="vgSave" ErrorMessage="this IP is already there please enter another IP!" OnServerValidate="IPAddress_ServerValidate"
                                    EnableClientScript="False" ControlToValidate="cvtxt"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                            </div>
                            <div class="col3">
                                <asp:CheckBox ID="chkMacStatus" Text="Active" runat="server" />
                            </div>

                            <div class="col2">
                                <span class="RequiredField">*</span>
                                <asp:Label ID="lblPort" runat="server" Text="Port :"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtPort" runat="server" Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblMachineNo" runat="server" Text="Machine No. :"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtMachineNo" runat="server" Enabled="False"  ></asp:TextBox>
                                <asp:CustomValidator ID="cvMachineNo" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;" CssClass="CustomValidator"
                                    ValidationGroup="vgSave" ErrorMessage="this Machine No is already there please enter another No.!" OnServerValidate="MachineNo_ServerValidate"
                                    EnableClientScript="False" ControlToValidate="cvtxt"></asp:CustomValidator>
                            </div>

                            <div class="col2">
                                <asp:Label ID="lblMacSerialNo" runat="server" Text="Machine Serial No. :"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtMacSerialNo" runat="server" Enabled="False"></asp:TextBox>
                                <asp:CustomValidator ID="cvMacSerialNo" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;" CssClass="CustomValidator"
                                    ValidationGroup="vgSave" ErrorMessage="this Machine serial No. is already there please enter another No.!" OnServerValidate="MachineNo_ServerValidate"
                                    EnableClientScript="False" ControlToValidate="cvtxt"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblMacLocationAr" runat="server" Text="Machine Location (Ar) :"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtMacLocationAr" runat="server" Enabled="False"  ></asp:TextBox>
                                <asp:CustomValidator ID="cvLocationAr" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;"
                                    ValidationGroup="vgSave" ErrorMessage="this Location Ar is already there please enter another Name!" OnServerValidate="cvLocation_ServerValidate"
                                    EnableClientScript="False" ControlToValidate="cvtxt"></asp:CustomValidator>
                            </div>

                            <div class="col2">
                                <span class="RequiredField">*</span>
                                <asp:Label ID="lblMacTypeTrn" runat="server" Text="Machine Type (Trans) :"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:DropDownList ID="ddlMacTrnType" runat="server">
                                    <asp:ListItem Text="- Select Trans Type -" Value="10" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="IN" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="OUT" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="IN/OUT" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlMacTrnType" runat="server" ControlToValidate="ddlMacTrnType" CssClass="CustomValidator"
                                    EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Machine Type (Trans) is required!' /&gt;"
                                    ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                <asp:Label ID="lblMacLocationEn" runat="server" Text="Machine Location (En) :"></asp:Label>
                            </div>
                            <div class="col3">
                                <asp:TextBox ID="txtMacLocationEn" runat="server" Enabled="False"></asp:TextBox>
                                <asp:CustomValidator ID="cvLocationEn" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;" CssClass="CustomValidator"
                                    ValidationGroup="vgSave" ErrorMessage="this Machine serial No. is already there please enter another No.!" OnServerValidate="MachineNo_ServerValidate"
                                    EnableClientScript="False" ControlToValidate="cvtxt"></asp:CustomValidator>
                                <asp:TextBox ID="txtMachineID" runat="server" Width="10" Enabled="False" Visible="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                            </div>
                            <div class="col3">
                                <asp:CheckBox ID="chkExportData" Text="Export Data" runat="server" />
                            </div>
                        </div>

                    </asp:Panel>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

