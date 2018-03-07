<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" Theme="MetroStyle" CodeFile="EmailSetting.aspx.cs" Inherits="Pages_EmailSetting" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Src="~/Control/SettingSideMenu.ascx" TagName="SettingSideMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:SettingSideMenu ID="SideMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <div class="row">

                    <div class="col2">
                        <asp:Label ID="lblEmailServer" runat="server" Text="Email Server :" meta:resourcekey="lblEmailServerResource1"></asp:Label>
                    </div>

                    <div class="col3">
                        <asp:TextBox ID="txtEmailServer" runat="server" Width="200px" meta:resourcekey="txtEmailServerResource1"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rvEmailServer" runat="server" ErrorMessage="Please enter IP server in correct format"
                            Text="&lt;img src='../Images/icon/Exclamation.gif' title='Please enter IP server in correct format!' /&gt;"
                            ValidationExpression="^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$"
                            ControlToValidate="txtEmailServer" EnableClientScript="False" ValidationGroup="VgSave" meta:resourcekey="rvEmailServerResource1"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <asp:Label ID="lblEmailPort" runat="server" Text="Email Port :" meta:resourcekey="lblEmailPortResource1"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtEmailPort" runat="server" Width="60px" TabIndex="1" meta:resourcekey="txtEmailPortResource1"></asp:TextBox>
                    </div>
                </div>


                <div class="row">
                    <div class="col2">
                        <asp:Label ID="lblSendEmailFrom" runat="server" Text="Send email from :" meta:resourcekey="lblSendEmailFromResource1"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtSendEmailFrom" runat="server" Width="200px" TabIndex="2" meta:resourcekey="txtSendEmailFromResource1"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rvEmailFrom" runat="server" ErrorMessage="Please enter email in correct format"
                            Text="&lt;img src='../Images/icon/Exclamation.gif' title='Please enter email in correct format!' /&gt;"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtSendEmailFrom" EnableClientScript="False" ValidationGroup="VgSave" meta:resourcekey="rvEmailFromResource1"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="col2">
                        <asp:Label ID="lblPassword" runat="server" Text="Password :" meta:resourcekey="lblPasswordResource1"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtPassword" runat="server" Width="200px" TabIndex="3" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col2">
                        <asp:CheckBox ID="chkEmailCredential" runat="server" Text="Enable Credentials" meta:resourcekey="chkEmailCredentialResource1" />
                    </div>
                    <div class="col3">
                    </div>

                </div>
                <div class="row">
                    <div class="col2">
                        <asp:CheckBox ID="chkEnableSSL" runat="server" Text="Enable SSL" meta:resourcekey="chkEnableSSLResource1" />
                    </div>
                    <div class="col3">
                    </div>

                </div>

                <div class="row">
                    <div class="col12">
                        <asp:ValidationSummary ID="vsSave" runat="server" CssClass="errorValidation" EnableClientScript="False" ValidationGroup="VgSave" meta:resourcekey="vsSaveResource1" />
                        <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False"
                            ValidationGroup="vgShowMsg" meta:resourcekey="vsShowMsgResource1" />
                    </div>
                </div>

                <div class="row">
                    <div class="col12">
                        <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="GenButton  glyphicon glyphicon-floppy-disk" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1"></asp:LinkButton>
                        <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px" meta:resourcekey="cvtxtResource1"></asp:TextBox>
                        <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="vgShowMsg"
                            OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvShowMsgResource1"></asp:CustomValidator>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

