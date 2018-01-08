<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="EmailSetting.aspx.cs" Inherits="Pages_EmailSetting" %>

<%@ Register Src="~/Control/SettingSideMenu.ascx" TagName="SettingSideMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:SettingSideMenu ID="SideMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <table align="left" width="100%" dir="ltr">
                    <tr>
                        <td class="td1Allalign">
                            <asp:Label ID="lblEmailServer" runat="server" Text="Email Server :"></asp:Label>
                        </td>
                        <td class="td2Allalign">
                            <asp:TextBox ID="txtEmailServer" runat="server" Width="200px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="rvEmailServer"  runat="server" ErrorMessage="Please enter IP server in correct format"
                                Text="&lt;img src='../Images/icon/Exclamation.gif' title='Please enter IP server in correct format!' /&gt;"
                                ValidationExpression="^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$" 
                                ControlToValidate="txtEmailServer" EnableClientScript="False" ValidationGroup="VgSave">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td1Allalign">
                            <asp:Label ID="lblEmailPort" runat="server" Text="Email Port :"></asp:Label>
                        </td>
                        <td class="td2Allalign">
                            <asp:TextBox ID="txtEmailPort" runat="server" Width="60px" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="td1Allalign">
                            <asp:Label ID="lblSendEmailFrom" runat="server" Text="Send email from :"></asp:Label>
                        </td>
                        <td class="td2Allalign">
                            <asp:TextBox ID="txtSendEmailFrom" runat="server" Width="200px" TabIndex="2"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="rvEmailFrom"  runat="server" ErrorMessage="Please enter email in correct format"
                                Text="&lt;img src='../Images/icon/Exclamation.gif' title='Please enter email in correct format!' /&gt;"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                ControlToValidate="txtSendEmailFrom" EnableClientScript="False" ValidationGroup="VgSave">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td1Allalign">
                            <asp:Label ID="lblPassword" runat="server" Text="Password :"></asp:Label>
                        </td>
                        <td class="td2Allalign">
                            <asp:TextBox ID="txtPassword" runat="server" Width="200px" TabIndex="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" width="100%">
                            <asp:ValidationSummary ID="vsSave" runat="server" CssClass="errorValidation" EnableClientScript="False" ValidationGroup="VgSave"/>
                            <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False"
                                ValidationGroup="vgShowMsg" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="td1Allalign">
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

