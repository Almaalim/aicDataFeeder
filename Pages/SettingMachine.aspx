<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="SettingMachine.aspx.cs" Inherits="Pages_SettingMachine" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Control/Calendar2.ascx" TagPrefix="uc" TagName="Calendar2" %>
<%@ Register src="~/Control/MachineSideMenu.ascx" tagname="MachineSideMenu" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:MachineSideMenu ID="SideMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <asp:Panel ID="pnlSearch" runat="server" class="SearchPanel">
                    <table>
                        <tr>
                            <td valign="middle">
                                &nbsp;
                                <asp:Label ID="lblSearch" runat="server" Text="Search By :"></asp:Label>
                                <asp:DropDownList ID="ddlSearch" runat="server" Width="261px" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged"
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
                    <table align="left" dir="ltr">
                        <tr>
                            <td>
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
                                <%--<ajaxToolkit:CollapsiblePanelExtender ID="epnlData" runat="server" Enabled="True"
                                    TargetControlID="pnlData" CollapsedSize="0" Collapsed="true" ExpandControlID="pnlTitel"
                                    CollapseControlID="pnlTitel" AutoCollapse="false" AutoExpand="false" CollapsedText="(Show Details...)"
                                    ExpandedText="(Hide Details)" ExpandDirection="Vertical" TextLabelID="lblTitel"
                                    ImageControlID="imgTitel" ExpandedImage="~/Images/collapse.jpg" CollapsedImage="~/Images/expand.jpg">
                                </ajaxToolkit:CollapsiblePanelExtender>--%>
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
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="ActionButton" Enabled="False"
                                                    OnClick="btnSave_Click" ValidationGroup="vgSave" />
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
                                        <tr class="td2Allalign">
                                            <td colspan="6" class="td2Allalign" width="100%">
                                                <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False"
                                                    ValidationGroup="vgSave" />
                                                <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False"
                                                    ValidationGroup="vgShowMsg" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td1Allalign">
                                                <span class="RequiredField">*</span>
                                                <asp:Label ID="lblMtpID" runat="server" Text="Machine Type :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:DropDownList ID="ddlMtpID" runat="server" Width="171px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlMtpID" runat="server" ControlToValidate="ddlMtpID"
                                                    EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Machine Type is required!' /&gt;"
                                                    ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                                                
                                                
                                            </td>
                                            <td class="td1Allalign">
                                                <span class="RequiredField">*</span>
                                                <asp:Label ID="lblIPAddress" runat="server" Text="IP Address:"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtIPAddress" runat="server" Enabled="False" Width="168px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtIPAddress" runat="server" ControlToValidate="txtIPAddress"
                                                    EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='IP Address Type is required!' /&gt;"
                                                    ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                                                <asp:CustomValidator ID="cvIPAddress" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;"
                                                    ValidationGroup="vgSave" ErrorMessage="this IP is already there please enter another IP!" OnServerValidate="IPAddress_ServerValidate"
                                                    EnableClientScript="False" ControlToValidate="cvtxt" ></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkMacStatus" Text="Active" runat="server" />
                                            </td>
                                        </tr>
                                        <tr class="td2Allalign">
                                            <td class="td1Allalign">
                                                <span class="RequiredField">*</span>
                                                <asp:Label ID="lblPort" runat="server" Text="Port :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtPort" runat="server" Enabled="False" Width="80"></asp:TextBox>
                                            </td>
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblMachineNo" runat="server" Text="Machine No. :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtMachineNo" runat="server" Enabled="False" Width="110"></asp:TextBox>
                                                <asp:CustomValidator ID="cvMachineNo" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;"
                                                    ValidationGroup="vgSave" ErrorMessage="this Machine No is already there please enter another No.!" OnServerValidate="MachineNo_ServerValidate"
                                                    EnableClientScript="False" ControlToValidate="cvtxt" ></asp:CustomValidator>
                                            </td>
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblMacSerialNo" runat="server" Text="Machine Serial No. :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtMacSerialNo" runat="server" Width="168px" Enabled="False"></asp:TextBox>
                                                <asp:CustomValidator ID="cvMacSerialNo" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;"
                                                    ValidationGroup="vgSave" ErrorMessage="this Machine serial No. is already there please enter another No.!" OnServerValidate="MachineNo_ServerValidate"
                                                    EnableClientScript="False" ControlToValidate="cvtxt" ></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr class="td2Allalign">
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblMacLocationAr" runat="server" Text="Machine Location (Ar) :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtMacLocationAr" runat="server" Enabled="False" Width="200"></asp:TextBox>
                                                <asp:CustomValidator ID="cvLocationAr" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;"
                                                    ValidationGroup="vgSave" ErrorMessage="this Location Ar is already there please enter another Name!" OnServerValidate="cvLocation_ServerValidate"
                                                    EnableClientScript="False" ControlToValidate="cvtxt" ></asp:CustomValidator>
                                            </td>
                                            <td class="td1Allalign">
                                                <span class="RequiredField">*</span>
                                                <asp:Label ID="lblMacTypeTrn" runat="server" Text="Machine Type (Trans) :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:DropDownList ID="ddlMacTrnType" runat="server" Width="171px">
                                                    <asp:ListItem Text="- Select Trans Type -" Value="10" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="IN" Value="1" ></asp:ListItem>
                                                    <asp:ListItem Text="OUT" Value="0" ></asp:ListItem>
                                                    <asp:ListItem Text="IN/OUT" Value="2" ></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlMacTrnType" runat="server" ControlToValidate="ddlMacTrnType"
                                                    EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Machine Type (Trans) is required!' /&gt;"
                                                    ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblMacLocationEn" runat="server" Text="Machine Location (En) :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtMacLocationEn" runat="server" Enabled="False" Width="200"></asp:TextBox>
                                                <asp:CustomValidator ID="cvLocationEn" runat="server" Text="&lt;img src='../Images/icon/message_exclamation.png' title='!' /&gt;"
                                                    ValidationGroup="vgSave" ErrorMessage="this Machine serial No. is already there please enter another No.!" OnServerValidate="MachineNo_ServerValidate"
                                                    EnableClientScript="False" ControlToValidate="cvtxt" ></asp:CustomValidator>
                                                <asp:TextBox ID="txtMachineID" runat="server" Width="10" Enabled="False" Visible="false"></asp:TextBox>
                                            </td>
                                            <td class="td1Allalign">
                                                <asp:CheckBox ID="chkExportData" Text="Export Data" runat="server" />
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

