<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="ChangePass.aspx.cs" Inherits="ChangePass" Title="Extractor Web - Change Password Page" EnableEventValidation="false" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblCurrentPass" runat="server" Text="Current Password : " meta:resourcekey="lblCurrentPassResource1" ></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtCurrentPass" runat="server" CssClass="txtbox" Width="250px" MaxLength="10" TextMode="Password" meta:resourcekey="txtCurrentPassResource1"></asp:TextBox>
                        <asp:CustomValidator ID="cvCurrentPass" runat="server" ValidationGroup="vgSave" OnServerValidate="Pass_ServerValidate"
                            Text="&lt;img src='../Images/icon/Exclamation.gif' title='Current Password is required!' /&gt;"
                            EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvCurrentPassResource1"></asp:CustomValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblNewPass" runat="server" Text="New Password :" meta:resourcekey="lblNewPassResource1" ></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" CssClass="txtbox" Width="250px" MaxLength="10" meta:resourcekey="txtNewPassResource1"></asp:TextBox>
                        <asp:CustomValidator ID="cvNewPass" runat="server" ValidationGroup="vgSave" OnServerValidate="Pass_ServerValidate"
                            Text="&lt;img src='../Images/icon/Exclamation.gif' title='New Password is required!' /&gt;"
                            EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvNewPassResource1"></asp:CustomValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblConfirmPass" runat="server" Text="Confirm Password :" meta:resourcekey="lblConfirmPassResource1"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password" CssClass="txtbox" Width="250px" MaxLength="10" meta:resourcekey="txtConfirmPassResource1"></asp:TextBox>
                        <asp:CustomValidator ID="cvConfirmPass" runat="server" ValidationGroup="vgSave" OnServerValidate="Pass_ServerValidate"
                            Text="&lt;img src='../Images/icon/Exclamation.gif' title='Confirm Password is required!' /&gt;"
                            EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvConfirmPassResource1"></asp:CustomValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col12">
                        <asp:Button ID="btnSave" runat="server" Text="Change" Width="103px" OnClick="btnSave_Click" ValidationGroup="vgSave" meta:resourcekey="btnSaveResource1" />
                        <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px" meta:resourcekey="cvtxtResource1"></asp:TextBox>
                        <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="ShowMsg" OnServerValidate="ShowMsg_ServerValidate"
                            EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvShowMsgResource1"></asp:CustomValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col12">
                        <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False" ValidationGroup="vgShowMsg" meta:resourcekey="vsShowMsgResource1" />
                        <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False" ValidationGroup="vgSave" meta:resourcekey="vsSaveResource1" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

