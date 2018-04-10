<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Culture="auto" meta:resourcekey="PageResource2" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="pageDiv" runat="Server" class="LoginPanel">

        <div id="loginTD" runat="server">
            <div class="LoginLeft">

                <asp:Image ID="Image1" runat="server" CssClass="loginLogoSAr"
                    ImageUrl="" meta:resourcekey="Image1Resource1" /> <%--~/images/Logo.png--%>
                <asp:Image ID="Image2" runat="server" CssClass="loginLogoMAr"
                    ImageUrl="" meta:resourcekey="Image2Resource1" /> <%--~/images/LoginLogo.png--%>
                <asp:Image ID="Image3" runat="server" CssClass="loginLogoSEn"
                    ImageUrl="" meta:resourcekey="Image3Resource1" /> <%--~/images/LogoEn.png--%>
                <asp:Image ID="Image4" runat="server" CssClass="loginLogoMEn"
                    ImageUrl="" meta:resourcekey="Image4Resource1" /> <%--~/images/LoginLogoEn.png--%>

            </div>

            <div class="LoginRight">
                <div class="row">
                    <div class="col12 h2">
                        <asp:Label ID="lblLogin" runat="server" Text="Login" meta:resourcekey="lblLoginResource2"></asp:Label>
                    </div>
                </div>

                <div class="row">
                    <div class="col12 h3">
                        <asp:Label ID="lblSystemName" runat="server" Text="Attendance System" meta:resourcekey="lblSystemNameResource2"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col12">
                        <asp:Label ID="lbltxtLoginID" runat="server" Text="Login ID :"
                            Style="text-align: center; font-size: medium" Font-Bold="True" meta:resourcekey="lbltxtLoginIDResource2"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col12 UserName">
                        <asp:TextBox ID="txtLoginID" runat="server" meta:resourcekey="txtLoginIDResource3"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rfvtxtLoginID" runat="server" ControlToValidate="txtLoginID" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='Images/icon/Exclamation.gif' title='Login ID is required!' /&gt;"
                            ValidationGroup="Save" meta:resourcekey="rfvtxtLoginIDResource2"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col12">
                        <asp:Label ID="lblPassword" runat="server" Text="Password :"
                            Style="font-size: medium"
                            Font-Bold="True" meta:resourcekey="lblPasswordResource2"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col12 PassWord">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" meta:resourcekey="txtPasswordResource2"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rfvtxtPassword" runat="server" ControlToValidate="txtPassword" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='Images/icon/Exclamation.gif' title='Password is required!' /&gt;"
                            ValidationGroup="Save" meta:resourcekey="rfvtxtPasswordResource2"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col12">
                        <asp:Button ID="btnLogin" runat="server" Text="login" CssClass="LoginBTN"
                            OnClick="btnLogin_Click" ValidationGroup="Save" meta:resourcekey="btnLoginResource2" />
                    </div>
                </div>
                <div class="row">
                    <div class="col4">
                        <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px" meta:resourcekey="cvtxtResource1"></asp:TextBox>
                        <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None"
                            ValidationGroup="ShowMsg" OnServerValidate="ShowMsg_ServerValidate"
                            EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvShowMsgResource1"></asp:CustomValidator>

                    </div>
                </div>
                <div class="row">
                    <div class="col12">

                        <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False" ValidationGroup="vgShowMsg" meta:resourcekey="vsShowMsgResource1" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

