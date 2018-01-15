<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Pages_ChangePassword" %>--%>

<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits=" Pages_ChangePassword" Title="Extractor Web - Change Password Page" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>


            <div id="pageDiv" runat="server">
                <table align="center" class="style1" style="border: thin solid #008080">
                    <tr>
                        <td colspan="3"
                            style="border-bottom: thin solid #008080; font-weight: 700; text-align: center;">Change Password </td>
                    </tr>
                    <tr>
                        <td class="style5">&nbsp;</td>
                        <td class="style4">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style6">Enter Current Password :
                        </td>
                        <td class="style4">
                            <asp:TextBox ID="txtCurrentPass" runat="server" CssClass="txtbox" Width="250px" MaxLength="10" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:CustomValidator ID="cvOldpassword" runat="server" Text="&lt;img src='../images/Exclamation.gif' title='Old password is not correct!' /&gt;"
                                ValidationGroup="vgSave" OnServerValidate="Oldpassword_ServerValidate"
                                EnableClientScript="False" ControlToValidate="cvtxt" CssClass="CustomValidator"
                                meta:resourcekey="cvNewpasswordResource1">

                            </asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6">Enter New Password :</td>
                        <td class="style4">
                            <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" CssClass="txtbox" Width="250px" MaxLength="10"></asp:TextBox>
                        </td>
                        <td>
                      
                     <asp:CustomValidator ID="cvNewpassword" runat="server" Text="&lt;img src='../images/Exclamation.gif' title='Old password is not correct!' /&gt;"
                         ValidationGroup="vgSave" OnServerValidate="Pass_ServerValidate"
                         EnableClientScript="False" ControlToValidate="cvtxt" CssClass="CustomValidator"
                         meta:resourcekey="cvNewpasswordResource1"></asp:CustomValidator>


                        </td>
                    </tr>
                    <tr>
                        <td class="style6">Confirm Password : </td>
                        <td class="style4">
                          
                            <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password" CssClass="txtbox" Width="250px" MaxLength="10"></asp:TextBox>
                        </td>
                        <td>
                            <asp:CustomValidator ID="cvConfirmpassword" runat="server" Text="&lt;img src='../images/Exclamation.gif' title='Old password is not correct!' /&gt;"
                                ValidationGroup="vgSave" OnServerValidate="Newpassword_ServerValidate"
                                EnableClientScript="False" ControlToValidate="cvtxt" CssClass="CustomValidator"
                                meta:resourcekey="cvNewpasswordResource1"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">&nbsp;</td>
                        <td class="style4">
                            <asp:Button ID="btnSave" runat="server" Text="Change Password"
                                OnClick="btnSave_Click" Width="117px" ValidationGroup="vgSave" />
                            <asp:Button ID="btncancel" runat="server" Text="Cancel"
                                OnClick="btnCancel_Click" Width="116px" ValidationGroup="vgSave" />
                            <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                        </td>

                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style5">&nbsp;</td>
                        <td class="style2" colspan="2">
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False" ValidationGroup="vgShowMsg" />
                        <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False" ValidationGroup="vgSave" />
                    </td>
                </table>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
