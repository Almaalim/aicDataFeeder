<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="ExportDB.aspx.cs" Inherits="Pages_ExportDB" %>

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
                            ValidationGroup="vgSave" />
                        <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False"
                            ValidationGroup="vgShowMsg" />
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>

                        <asp:Label ID="lblServerName" runat="server" Text="Server Name :"></asp:Label>
                    </div>

                    <div class="col3">
                        <asp:TextBox ID="txtServerName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtTableName" runat="server" ControlToValidate="txtServerName" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Server Name is required!' /&gt;"
                            ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                    </div>

                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblUserName" runat="server" Text="Username :"></asp:Label>
                    </div>

                    <div class="col3">
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtDateField" runat="server" ControlToValidate="txtUserName" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Username is required!' /&gt;"
                            ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                    </div>


                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblUsrPassword" runat="server" Text="Password :"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtUsrPassword" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtUsrPassword" runat="server" ControlToValidate="txtUsrPassword" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Password is required!' /&gt;"
                            ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                    </div>


                </div>
                <div class="row">

                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblDBName" runat="server" Text="DB Name :"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:DropDownList ID="ddlDBName" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvtxtDBName" runat="server" ControlToValidate="ddlDBName" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='DB Name is required!' /&gt;"
                            ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                        <asp:ImageButton ID="imgRefgDB" ImageUrl="~/Images/Button_Icons/refresh-icon.png" runat="server" OnClick="imgRefgDB_Click" />
                    </div>

                </div>
                <div class="row">

                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblTable" runat="server" Text="Table Name :"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:DropDownList ID="ddlTableName" runat="server"></asp:DropDownList>
                        <asp:ImageButton ID="imgRefTable" ImageUrl="~/Images/Button_Icons/refresh-icon.png" runat="server" OnClick="imgRefTable_Click" />
                        <asp:RequiredFieldValidator ID="rfvddlTableName" runat="server" ControlToValidate="ddlTableName" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Table Name is required!' /&gt;"
                            ValidationGroup="vgSave"></asp:RequiredFieldValidator>

                    </div>

                </div>
                <div class="row">
                    <div class="col12">
                        <asp:LinkButton ID="btnSave" runat="server" Text="Save" ValidationGroup="vgSave" CssClass="GenButton glyphicon glyphicon-floppy-disk" OnClick="btnSave_Click"></asp:LinkButton>
                        <%--<asp:LinkButton ID="btnCancel" runat="server" Text="cancel" CssClass="GenButton glyphicon glyphicon-floppy-disk" OnClick="btnCancel_Click" OnClientClick="hideparentPopup('');"></asp:LinkButton>--%>
                        <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                        <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="vgShowMsg" CssClass="CustomValidator"
                            OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt">
                        </asp:CustomValidator>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

