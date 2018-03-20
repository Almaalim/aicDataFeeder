<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="DBExportConn.aspx.cs" Inherits="Pages_DBExportConn" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="upnlMain" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <div class="row">
                    <div class="col12">
                        <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False"
                            ValidationGroup="vgSave" meta:resourcekey="vsSaveResource1" />
                        <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False"
                            ValidationGroup="vgShowMsg" meta:resourcekey="vsShowMsgResource1" />
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>

                        <asp:Label ID="lblServerName" runat="server" Text="Server Name :" meta:resourcekey="lblServerNameResource1"></asp:Label>
                    </div>

                    <div class="col3">
                        <asp:TextBox ID="txtServerName" runat="server" meta:resourcekey="txtServerNameResource1" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtTableName" runat="server" ControlToValidate="txtServerName" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Server Name is required!' /&gt;"
                            ValidationGroup="vgSave" meta:resourcekey="rfvtxtTableNameResource1"></asp:RequiredFieldValidator>
                    </div>

                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblUserName" runat="server" Text="Username :" meta:resourcekey="lblUserNameResource1"></asp:Label>
                    </div>

                    <div class="col3">
                        <asp:TextBox ID="txtUserName" runat="server" meta:resourcekey="txtUserNameResource1" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtDateField" runat="server" ControlToValidate="txtUserName" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Username is required!' /&gt;"
                            ValidationGroup="vgSave" meta:resourcekey="rfvtxtDateFieldResource1"></asp:RequiredFieldValidator>
                    </div>


                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblUsrPassword" runat="server" Text="Password :" meta:resourcekey="lblUsrPasswordResource1"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtUsrPassword" runat="server" meta:resourcekey="txtUsrPasswordResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtUsrPassword" runat="server" ControlToValidate="txtUsrPassword" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Password is required!' /&gt;"
                            ValidationGroup="vgSave" meta:resourcekey="rfvtxtUsrPasswordResource1"></asp:RequiredFieldValidator>
                    </div>


                </div>
                <div class="row">

                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblDBName" runat="server" Text="DB Name :" meta:resourcekey="lblDBNameResource1"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:DropDownList ID="ddlDBName" runat="server" meta:resourcekey="ddlDBNameResource1"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvtxtDBName" runat="server" ControlToValidate="ddlDBName" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='DB Name is required!' /&gt;"
                            ValidationGroup="vgSave" meta:resourcekey="rfvtxtDBNameResource1"></asp:RequiredFieldValidator>
                        <asp:ImageButton ID="imgRefgDB" ImageUrl="~/Images/Button_Icons/refresh-icon.png" runat="server" OnClick="imgRefgDB_Click" meta:resourcekey="imgRefgDBResource1" />
                    </div>

                </div>
                <div class="row">

                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblTable" runat="server" Text="Table Name :" meta:resourcekey="lblTableResource1"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:DropDownList ID="ddlTableName" runat="server" meta:resourcekey="ddlTableNameResource1"></asp:DropDownList>
                        <asp:ImageButton ID="imgRefTable" ImageUrl="~/Images/Button_Icons/refresh-icon.png" runat="server" OnClick="imgRefTable_Click" meta:resourcekey="imgRefTableResource1" />
                        <asp:RequiredFieldValidator ID="rfvddlTableName" runat="server" ControlToValidate="ddlTableName" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Table Name is required!' /&gt;"
                            ValidationGroup="vgSave" meta:resourcekey="rfvddlTableNameResource1"></asp:RequiredFieldValidator>

                    </div>

                </div>
                <div class="row">
                    <div class="col12">
                        <asp:LinkButton ID="btnSave" runat="server" Text="Save" ValidationGroup="vgSave" CssClass="GenButton glyphicon glyphicon-floppy-disk" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1"></asp:LinkButton>
                        <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px" meta:resourcekey="cvtxtResource1"></asp:TextBox>
                        <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="vgShowMsg" CssClass="CustomValidator"
                            OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvShowMsgResource1"></asp:CustomValidator>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

