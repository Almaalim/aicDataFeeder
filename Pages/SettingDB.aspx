<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" Theme="MetroStyle" CodeFile="SettingDB.aspx.cs" Inherits="Pages_SettingDB" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Src="~/Control/SettingSideMenu.ascx" TagName="SettingSideMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:SettingSideMenu ID="SideMenu" runat="server" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--<link href="../CSS/PopupStyle.css" rel="stylesheet" type="text/css" />--%>
    <%--script--%>
    <%--<script type="text/javascript" src="../Script/GridEvent.js"></script>--%>
    <%--<script type="text/javascript" src="../Script/CheckKey.js"></script>
    <script type="text/javascript" src="../Script/ModalPopup.js"></script>
    <script type="text/javascript" src="../Script/DivPopup.js"></script>--%>
    <%--script--%>

    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <div class="row">
                    <div class="col12">
                        <asp:Button ID="btnConnDB" runat="server" Text="Database Connect" CssClass="ActionButton"
                            OnClick="btnConnDB_Click" meta:resourcekey="btnConnDBResource1" />
                    </div>
                </div>
                <div class="row">
                    <div class="col12">
                        <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False" ValidationGroup="vgSave" meta:resourcekey="vsSaveResource1" />
                        <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False" ValidationGroup="vgShowMsg" meta:resourcekey="vsShowMsgResource1" />
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblEmpField" runat="server" Text="Employee Field :" meta:resourcekey="lblEmpFieldResource1"></asp:Label>
                    </div>

                    <div class="col3">
                        <asp:DropDownList ID="ddlEmpField" runat="server" meta:resourcekey="ddlEmpFieldResource1"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvtxtEmpField" runat="server" ControlToValidate="ddlEmpField"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Employee Field is required!' /&gt;" CssClass="CustomValidator"
                            ValidationGroup="vgSave" meta:resourcekey="rfvtxtEmpFieldResource1"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblDateField" runat="server" Text="Date Field :" meta:resourcekey="lblDateFieldResource1"></asp:Label>
                    </div>

                    <div class="col3">
                        <asp:DropDownList ID="ddlDateField" runat="server" meta:resourcekey="ddlDateFieldResource1"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvtxtDateField" runat="server" ControlToValidate="ddlDateField" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Date Field is required!' /&gt;"
                            ValidationGroup="vgSave" meta:resourcekey="rfvtxtDateFieldResource1"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lbltimeField" runat="server" Text="Time Field :" meta:resourcekey="lbltimeFieldResource1"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:DropDownList ID="ddlTimeField" runat="server" meta:resourcekey="ddlTimeFieldResource1"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvtxtTimeField" runat="server" ControlToValidate="ddlTimeField" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Time Field is required!' /&gt;"
                            ValidationGroup="vgSave" meta:resourcekey="rfvtxtTimeFieldResource1"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblInOutField" runat="server" Text="In/Out Field :" meta:resourcekey="lblInOutFieldResource1"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:DropDownList ID="ddlInOutField" runat="server" meta:resourcekey="ddlInOutFieldResource1"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvtxtInOutField" runat="server" ControlToValidate="ddlInOutField" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='In/Out Field is required!' /&gt;"
                            ValidationGroup="vgSave" meta:resourcekey="rfvtxtInOutFieldResource1"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblMachineIdField" runat="server" Text="Machine ID Field :" meta:resourcekey="lblMachineIdFieldResource1"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:DropDownList ID="ddlMachineIdField" runat="server" meta:resourcekey="ddlMachineIdFieldResource1"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvtxtMachineIdField" runat="server" ControlToValidate="ddlMachineIdField" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Machine ID is required!' /&gt;"
                            ValidationGroup="vgSave" meta:resourcekey="rfvtxtMachineIdFieldResource1"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblLocationField" runat="server" Text="Location Field :" meta:resourcekey="lblLocationFieldResource1"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:DropDownList ID="ddlLocationField" runat="server" meta:resourcekey="ddlLocationFieldResource1"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvtxtLocationField" runat="server" ControlToValidate="ddlLocationField" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Location Field is required!' /&gt;"
                            ValidationGroup="vgSave" meta:resourcekey="rfvtxtLocationFieldResource1"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col2">
                        <asp:Label ID="lblSchemaName" runat="server" Text="Schema Name :" meta:resourcekey="lblSchemaNameResource1"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtSchemaName" runat="server" AutoCompleteType="Disabled" meta:resourcekey="txtSchemaNameResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtSchemaName" runat="server" ControlToValidate="txtSchemaName" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Schema Name is required!' /&gt;"
                            ValidationGroup="vgSave" meta:resourcekey="rfvtxtSchemaNameResource1"></asp:RequiredFieldValidator>
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
