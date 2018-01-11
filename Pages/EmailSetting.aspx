<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" Theme="MetroStyle" CodeFile="EmailSetting.aspx.cs" Inherits="Pages_EmailSetting" %>

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
                        <asp:Label ID="lblEmailServer" runat="server" Text="Email Server :"></asp:Label>
                    </div>

                    <div class="col3">
                        <asp:TextBox ID="txtEmailServer" runat="server" Width="200px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rvEmailServer" runat="server" ErrorMessage="Please enter IP server in correct format"
                            Text="&lt;img src='../Images/icon/Exclamation.gif' title='Please enter IP server in correct format!' /&gt;"
                            ValidationExpression="^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$"
                            ControlToValidate="txtEmailServer" EnableClientScript="False" ValidationGroup="VgSave">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <asp:Label ID="lblEmailPort" runat="server" Text="Email Port :"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtEmailPort" runat="server" Width="60px" TabIndex="1"></asp:TextBox>
                    </div>
                </div>


                <div class="row">
                    <div class="col2">
                        <asp:Label ID="lblSendEmailFrom" runat="server" Text="Send email from :"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtSendEmailFrom" runat="server" Width="200px" TabIndex="2"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rvEmailFrom" runat="server" ErrorMessage="Please enter email in correct format"
                            Text="&lt;img src='../Images/icon/Exclamation.gif' title='Please enter email in correct format!' /&gt;"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtSendEmailFrom" EnableClientScript="False" ValidationGroup="VgSave">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="col2">
                        <asp:Label ID="lblPassword" runat="server" Text="Password :"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtPassword" runat="server" Width="200px" TabIndex="3"></asp:TextBox>
                    </div>
                </div>


                <div class="row">
                    <div class="col12">
                        <asp:ValidationSummary ID="vsSave" runat="server" CssClass="errorValidation" EnableClientScript="False" ValidationGroup="VgSave" />
                        <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False"
                            ValidationGroup="vgShowMsg" />
                    </div>
                </div>

                <div class="row">
                    <div class="col12">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="ActionButton" OnClick="btnSave_Click" />
                        <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                        <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="vgShowMsg"
                            OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt">
                        </asp:CustomValidator>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

