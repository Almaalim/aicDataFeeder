<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="pageDiv" runat="Server" class="LoginPanel">

        <div id="loginTD" runat="server">
            <div class="LoginLeft">

                <asp:Image ID="Image1" runat="server" CssClass="loginLogoSAr"
                    ImageUrl="~/images/Logo.png"  />
                <asp:Image ID="Image2" runat="server" CssClass="loginLogoMAr"
                    ImageUrl="~/images/LoginLogo.png"  />
                <asp:Image ID="Image3" runat="server" CssClass="loginLogoSEn"
                    ImageUrl="~/images/LogoEn.png"  />
                <asp:Image ID="Image4" runat="server" CssClass="loginLogoMEn"
                    ImageUrl="~/images/LoginLogoEn.png"  />

            </div>


            <div class="LoginRight">
                <div class="row">
                    <div class="col12 h2">
                        Login
                    </div>

                </div>
                <div class="row">
                    <div class="col12 h3">
                        Attendance System
                    </div>

                </div>
                <div class="row">
                    <div class="col12">
                        <asp:Label ID="lbltxtLoginID" runat="server" Text="Login ID :"
                            
                            Style="text-align: center; font-size: medium" Font-Bold="True"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col12 UserName">
                                            <asp:TextBox ID="txtLoginID" runat="server"  
                                                  ></asp:TextBox>
                                       
                                            <asp:RequiredFieldValidator ID="rfvtxtLoginID" runat="server" ControlToValidate="txtLoginID" CssClass="CustomValidator"
                                                EnableClientScript="False" Text="&lt;img src='Images/icon/Exclamation.gif' title='Login ID is required!' /&gt;"
                                                ValidationGroup="Save" ></asp:RequiredFieldValidator>
                                      </div>
            </div>
            <div class="row">
                <div class="col12">
                    <asp:Label ID="lblPassword" runat="server" Text="Password :"
                        Style="font-size: medium"
                        Font-Bold="True"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col12 PassWord">
                    <asp:TextBox ID="txtPassword" runat="server"   TextMode="Password"
                         ></asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfvtxtPassword" runat="server" ControlToValidate="txtPassword" CssClass="CustomValidator"
                        EnableClientScript="False" Text="&lt;img src='Images/icon/Exclamation.gif' title='Password is required!' /&gt;"
                        ValidationGroup="Save" ></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col12">
                    <asp:Button ID="btnLogin" runat="server" Text="login" CssClass="LoginBTN"
                        OnClick="btnLogin_Click" ValidationGroup="Save" 
                         />
                </div>
            </div>
            <div class="row">
                <div class="col4">
                    <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px" ></asp:TextBox>
                    <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None"
                        ValidationGroup="ShowMsg" OnServerValidate="ShowMsg_ServerValidate"
                        EnableClientScript="False" ControlToValidate="cvtxt">
                    </asp:CustomValidator>

                </div>
            </div>
            <div class="row">
                <div class="col12">

                    <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False" ValidationGroup="vgShowMsg" />
                </div>
            </div>
        </div>
    </div>
        </div>
</asp:Content>

