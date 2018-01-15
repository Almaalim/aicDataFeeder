﻿<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="ChangePass.aspx.cs" Inherits="ChangePassword" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           <div class="row">
                        </div>
                <div class="row">
                    <div class="col12">
                        <asp:ValidationSummary ID="vsSave" runat="server" ValidationGroup="vgSave"
                            EnableClientScript="False" CssClass="MsgValidation" 
                            meta:resourcekey="vsumAllResource1" />
                        </div>
                </div>
                <div class="row">
                    <div class="col3">
                        </div>
                    <div class="col2">
                                    <span class="RequiredField">*</span>
                                    <asp:Label ID="lblOldPassword" runat="server" Text="Old Password :" meta:resourcekey="lblOldPasswordResource1"></asp:Label>
                                </div>
                    <div class="col4">
                                    <asp:TextBox ID="txtCurrentPass" runat="server" TextMode="Password" meta:resourcekey="txtOldpasswordResource1"
                                        AutoCompleteType="Disabled"></asp:TextBox>
                          <%--<asp:RequiredFieldValidator runat="server" ID="reqOldpassword" ControlToValidate="txtOldpassword" CssClass="CustomValidator"
                                        Text="<img src='../images/Exclamation.gif' title='Old password is required' />"
                                        ValidationGroup="vgSave" EnableClientScript="False" Display="Dynamic" SetFocusOnError="True"
                                        meta:resourcekey="reqOldpasswordResource1"></asp:RequiredFieldValidator>--%>

                                       <asp:CustomValidator ID="cvOldpassword" runat="server" Text="&lt;img src='../images/Exclamation.gif' title='Old password is not correct!' /&gt;"
                                ValidationGroup="vgSave" OnServerValidate="Oldpassword_ServerValidate"
                                EnableClientScript="False" ControlToValidate="cvtxt" CssClass="CustomValidator"
                                meta:resourcekey="cvNewpasswordResource1"></asp:CustomValidator>
                                </div>
                    </div>
            <div class="row">
            <div class="col3">
                        </div>
                    <div class="col2">
                                    <span class="RequiredField">*</span>
                                    <asp:Label ID="lblNewPassword" runat="server" Text="New Password :" meta:resourcekey="lblNewPasswordResource1"></asp:Label>
                               </div>
                    <div class="col4">
                                    <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" meta:resourcekey="txtNewpasswordResource1" AutoCompleteType="Disabled"></asp:TextBox>
                                <%--    <asp:RequiredFieldValidator runat="server" ID="reqNew" ControlToValidate="txtNewpassword"
                                        Text="<img src='../images/Exclamation.gif' title='New password is required' />" CssClass="CustomValidator"
                                        ValidationGroup="vgSave" EnableClientScript="False" Display="Dynamic" SetFocusOnError="True"
                                        meta:resourcekey="reqNewpasswordResource1">
                                    </asp:RequiredFieldValidator>--%>
                                    <asp:CustomValidator ID="cvNewpassword" runat="server" Text="&lt;img src='../images/Exclamation.gif' title='Old password is not correct!' /&gt;"
                         ValidationGroup="vgSave" OnServerValidate="Pass_ServerValidate"
                         EnableClientScript="False" ControlToValidate="cvtxt" CssClass="CustomValidator"
                         meta:resourcekey="cvNewpasswordResource1"></asp:CustomValidator>
                                </div>
                </div>
                <div class="row">
                     <div class="col3">
                         </div>
                    <div class="col2">
                                    <span class="RequiredField">*</span><asp:Label ID="lblConfirmPassword" runat="server"
                                        Text="Confirm Password :" meta:resourcekey="lblConfirmPasswordResource1"></asp:Label>
                               </div>
                    <div class="col4">
                                   <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password" meta:resourcekey="txtConfirmpasswordResource1"
                                        AutoCompleteType="Disabled"></asp:TextBox>
                                  <%--  <asp:RequiredFieldValidator runat="server" ID="rfvConfirmpassword" ControlToValidate="txtConfirmpassword"
                                        Text="<img src='../images/Exclamation.gif' title='Confirm password is required' />" CssClass="CustomValidator"
                                        ValidationGroup="vgSave" EnableClientScript="False" Display="Dynamic" SetFocusOnError="True"
                                        meta:resourcekey="reqConfirmpasswordResource1"></asp:RequiredFieldValidator>--%>
                                 <asp:CustomValidator ID="cvConfirmpassword" runat="server" Text="&lt;img src='../images/Exclamation.gif' title='Old password is not correct!' /&gt;"
                                ValidationGroup="vgSave" OnServerValidate="Newpassword_ServerValidate"
                                EnableClientScript="False" ControlToValidate="cvtxt" CssClass="CustomValidator"
                                meta:resourcekey="cvNewpasswordResource1"></asp:CustomValidator>
                               </div>
            </div>
            <div class="row">
                <div class="col8">
                                        <asp:LinkButton ID="btnSave" runat="server" CssClass="GenButton glyphicon glyphicon-floppy-disk" OnClick="btnSave_Click"
                                           ValidationGroup="vgSave" Text="&lt;img src=&quot;../images/Button_Icons/button_storage.png&quot; /&gt; Save"
                                            meta:resourcekey="btnSaveResource1"></asp:LinkButton>
                                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="GenButton glyphicon glyphicon-remove-circle" OnClick="btnCancel_Click"
                                             Text="&lt;img src=&quot;../images/Button_Icons/button_Cancel.png&quot; /&gt; Cancel"
                                            meta:resourcekey="btnCancelResource1"></asp:LinkButton>
                                   </div>
                <div class="col4">
                                    <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False"
                                        Width="10px" meta:resourcekey="txtCustomValidatorResource1"></asp:TextBox>
                                    &nbsp;
                                    <asp:CustomValidator id="cvShowMsg" runat="server" Display="None" 
                                        ValidationGroup="ShowMsg" OnServerValidate="ShowMsg_ServerValidate"
                                        EnableClientScript="False" ControlToValidate="txtValid">
                                    </asp:CustomValidator>
                        <td colspan="2">
                        <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False" ValidationGroup="vgShowMsg" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="MsgValidation" EnableClientScript="False" ValidationGroup="vgSave" />
                    </td>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
