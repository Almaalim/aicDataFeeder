<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="SettingDB.aspx.cs" Inherits="Pages_SettingDB" %>

<%@ Register Src="~/Control/SettingSideMenu.ascx" TagName="SettingSideMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:SettingSideMenu ID="SideMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <table>
                    <tr>
                        <td>
                        </td>
                        <td class="td2Allalign">
                            <asp:Button ID="btnConnDB" runat="server" Text="Database Connect" CssClass="ActionButton"
                                Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td1Allalign">
                            <span class="RequiredField">*</span>
                            <asp:Label ID="lblTableName" runat="server" Text="Table Name :"></asp:Label>
                        </td>
                        <td class="td2Allalign">
                            <asp:TextBox ID="txtTableName" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtTableName" runat="server" ControlToValidate="txtTableName"
                                EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Table Name is required!' /&gt;"
                                ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td1Allalign">
                            <span class="RequiredField">*</span>
                            <asp:Label ID="lblEmpField" runat="server" Text="Employee Field :"></asp:Label>
                        </td>
                        <td class="td2Allalign">
                            <asp:TextBox ID="txtEmpField" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtEmpField" runat="server" ControlToValidate="txtEmpField"
                                EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Employee Field is required!' /&gt;"
                                ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td1Allalign">
                            <span class="RequiredField">*</span>
                            <asp:Label ID="lblDateField" runat="server" Text="Date Field :"></asp:Label>
                        </td>
                        <td class="td2Allalign">
                            <asp:TextBox ID="txtDateField" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtDateField" runat="server" ControlToValidate="txtDateField"
                                EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Date Field is required!' /&gt;"
                                ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td1Allalign">
                            <span class="RequiredField">*</span>
                            <asp:Label ID="lbltimeField" runat="server" Text="Time Field :"></asp:Label>
                        </td>
                        <td class="td2Allalign">
                            <asp:TextBox ID="txtTimeField" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtTimeField" runat="server" ControlToValidate="txtTimeField"
                                EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Time Field is required!' /&gt;"
                                ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td1Allalign">
                            <span class="RequiredField">*</span>
                            <asp:Label ID="lblInOutField" runat="server" Text="In/Out Field :"></asp:Label>
                        </td>
                        <td class="td2Allalign">
                            <asp:TextBox ID="txtInOutField" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtInOutField" runat="server" ControlToValidate="txtInOutField"
                                EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='In/Out Field is required!' /&gt;"
                                ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td1Allalign">
                            <span class="RequiredField">*</span>
                            <asp:Label ID="lblMachineIdField" runat="server" Text="Machine ID Field :"></asp:Label>
                        </td>
                        <td class="td2Allalign">
                            <asp:TextBox ID="txtMachineIdField" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtMachineIdField" runat="server" ControlToValidate="txtMachineIdField"
                                EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Machine ID is required!' /&gt;"
                                ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td1Allalign">
                            <span class="RequiredField">*</span>
                            <asp:Label ID="lblLocationField" runat="server" Text="Location Field :"></asp:Label>
                        </td>
                        <td class="td2Allalign">
                            <asp:TextBox ID="txtLocationField" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtLocationField" runat="server" ControlToValidate="txtLocationField"
                                EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Location Field is required!' /&gt;"
                                ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td1Allalign">
                            <asp:Label ID="lblSchemaName" runat="server" Text="Schema Name :"></asp:Label>
                        </td>
                        <td class="td2Allalign">
                            <asp:TextBox ID="txtSchemaName" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtSchemaName" runat="server" ControlToValidate="txtSchemaName"
                                EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Schema Name is required!' /&gt;"
                                ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr class="td2Allalign">
                        <td colspan="2" class="td2Allalign" width="100%">
                            <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False"
                                ValidationGroup="vgSave" />
                            <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False"
                                ValidationGroup="vgShowMsg" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="ActionButton" onclick="btnSave_Click"/>
                            <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                            <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="vgShowMsg"
                                OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt">
                            </asp:CustomValidator>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
