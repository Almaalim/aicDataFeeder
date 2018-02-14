<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" Theme="MetroStyle" CodeFile="SettingDB.aspx.cs" Inherits="Pages_SettingDB" %>

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
                            OnClick="btnConnDB_Click" />
                    </div>
                </div>
                <div class="row">
                    <div class="col12">
                        <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False" ValidationGroup="vgSave" />
                        <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False" ValidationGroup="vgShowMsg" />
                    </div>
                </div>
                <div class="row">
                    <%--<div class="col2">
                        <span class="RequiredField">*</span>
                   
                        <asp:Label ID="lblTableName" runat="server" Text="Table Name :"></asp:Label>
                    </div>

                    <div class="col3">
                        <asp:TextBox ID="txtTableName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtTableName" runat="server" ControlToValidate="txtTableName" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Table Name is required!' /&gt;"
                            ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                    </div>--%>
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblEmpField" runat="server" Text="Employee Field :"></asp:Label>
                    </div>

                    <div class="col3">
                        <asp:DropDownList ID="ddlEmpField" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvtxtEmpField" runat="server" ControlToValidate="ddlEmpField"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Employee Field is required!' /&gt;" CssClass="CustomValidator"
                            ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblDateField" runat="server" Text="Date Field :"></asp:Label>
                    </div>

                    <div class="col3">
                        <asp:DropDownList ID="ddlDateField" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvtxtDateField" runat="server" ControlToValidate="ddlDateField" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Date Field is required!' /&gt;"
                            ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lbltimeField" runat="server" Text="Time Field :"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:DropDownList ID="ddlTimeField" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvtxtTimeField" runat="server" ControlToValidate="ddlTimeField" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Time Field is required!' /&gt;"
                            ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblInOutField" runat="server" Text="In/Out Field :"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:DropDownList ID="ddlInOutField" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvtxtInOutField" runat="server" ControlToValidate="ddlInOutField" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='In/Out Field is required!' /&gt;"
                            ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblMachineIdField" runat="server" Text="Machine ID Field :"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:DropDownList ID="ddlMachineIdField" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvtxtMachineIdField" runat="server" ControlToValidate="ddlMachineIdField" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Machine ID is required!' /&gt;"
                            ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col2">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="lblLocationField" runat="server" Text="Location Field :"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:DropDownList ID="ddlLocationField" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvtxtLocationField" runat="server" ControlToValidate="ddlLocationField" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Location Field is required!' /&gt;"
                            ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col2">
                        <asp:Label ID="lblSchemaName" runat="server" Text="Schema Name :"></asp:Label>
                    </div>
                    <div class="col3">
                        <asp:TextBox ID="txtSchemaName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtSchemaName" runat="server" ControlToValidate="txtSchemaName" CssClass="CustomValidator"
                            EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Schema Name is required!' /&gt;"
                            ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col12">
                        <asp:LinkButton ID="btnSave" runat="server" Text="Save" ValidationGroup="vgSave" CssClass="GenButton glyphicon glyphicon-floppy-disk" OnClick="btnSave_Click"></asp:LinkButton>
                        <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                        <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="vgShowMsg" CssClass="CustomValidator"
                            OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt">
                        </asp:CustomValidator>
                    </div>
                </div>
            </div>
            <%--<div id='divBackground'></div>
            <div id='divPopup' class="divPopup" style="height: 500px; width: 680px;">
                <div id='divPopupHead' class="divPopupHead">
                    <asp:Label ID="lblNamePopup"
                        runat="server" CssClass="lblNamePopup"></asp:Label>
                </div>
                <div id='divClosePopup' class="divClosePopup" onclick="hidePopup('divPopup')"><ahref='#'>X</a></div>
                <div id='divPopupContent' class="divPopupContent">
                    <center>
                        <iframe id="ifrmPopup" runat="server" height="500px" width="670px" scrolling="no" frameborder="0" style="margin-left: 10px; background-color: #4E6877"></iframe>
                    </center>
                </div>
            </div>--%>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
