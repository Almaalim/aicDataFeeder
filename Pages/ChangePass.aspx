<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" Theme="MetroStyle" CodeFile="ChangePass.aspx.cs" Inherits="ChangePass" Title="Extractor Web - Change Password Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblCurrentPass" runat="server" Text="Current Password : " ></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtCurrentPass" runat="server" CssClass="txtbox" Width="250px" MaxLength="10" TextMode="Password"></asp:TextBox>
                        <asp:CustomValidator ID="cvCurrentPass" runat="server" ValidationGroup="vgSave" OnServerValidate="Pass_ServerValidate"
                            Text="&lt;img src='../Images/icon/Exclamation.gif' title='Current Password is required!' /&gt;"
                            EnableClientScript="False" ControlToValidate="cvtxt">
                        </asp:CustomValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblNewPass" runat="server" Text="New Password :" ></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" CssClass="txtbox" Width="250px" MaxLength="10"></asp:TextBox>
                        <asp:CustomValidator ID="cvNewPass" runat="server" ValidationGroup="vgSave" OnServerValidate="Pass_ServerValidate"
                            Text="&lt;img src='../Images/icon/Exclamation.gif' title='New Password is required!' /&gt;"
                            EnableClientScript="False" ControlToValidate="cvtxt">
                                                        </asp:CustomValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblConfirmPass" runat="server" Text="Confirm Password :"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password" CssClass="txtbox" Width="250px" MaxLength="10"></asp:TextBox>
                        <asp:CustomValidator ID="cvConfirmPass" runat="server" ValidationGroup="vgSave" OnServerValidate="Pass_ServerValidate"
                            Text="&lt;img src='../Images/icon/Exclamation.gif' title='Confirm Password is required!' /&gt;"
                            EnableClientScript="False" ControlToValidate="cvtxt">
                                                        </asp:CustomValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col12">
                        <asp:Button ID="btnSave" runat="server" Text="Change" Width="103px" OnClick="btnSave_Click" ValidationGroup="vgSave" />
                        <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                        <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="ShowMsg" OnServerValidate="ShowMsg_ServerValidate"
                            EnableClientScript="False" ControlToValidate="cvtxt">
                        </asp:CustomValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col12">
                        <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False" ValidationGroup="vgShowMsg" />
                        <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False" ValidationGroup="vgSave" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

