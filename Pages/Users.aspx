<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" Theme="MetroStyle" CodeFile="Users.aspx.cs" Inherits="Pages_Users" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Src="../Control/PermissionsCtl.ascx" TagName="PermissionsCtl" TagPrefix="uc3" %>
<%@ Register Src="~/Control/Calendar2.ascx" TagPrefix="uc" TagName="Calendar2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <asp:Panel ID="pnlSearch" runat="server" class="SearchPanel" meta:resourcekey="pnlSearchResource1">
                    <div class="row">
                        <div class="col1">
                            <asp:Label ID="lblSearch" runat="server" Text="Search By :" meta:resourcekey="lblSearchResource1"></asp:Label>
                        </div>

                        <div class="col2">
                            <asp:DropDownList ID="ddlSearch" runat="server" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged"
                                AutoPostBack="True" meta:resourcekey="ddlSearchResource1">
                                <asp:ListItem Value="[none]" Text="[none]" Selected="True" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                <asp:ListItem Value="UsrLoginID" Text="Login ID" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                <asp:ListItem Value="UsrFullName" Text="Full Name" meta:resourcekey="ListItemResource3"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col2">
                            <asp:TextBox ID="txtSearch" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtSearchResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvSearch" runat="server" ControlToValidate="txtSearch" CssClass="CustomValidator"
                                EnableClientScript="False" ValidationGroup="vgSearch" Text="&lt;img src='../Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;" meta:resourcekey="rvSearchResource1"></asp:RequiredFieldValidator>

                            <cc1:FilteredTextBoxExtender ID="eFilteredSearch" runat="server" Enabled="True" FilterType="Numbers"
                                TargetControlID="txtSearch" />
                            <cc1:TextBoxWatermarkExtender ID="eWatermarkSearch" runat="server" Enabled="True"
                                TargetControlID="txtSearch" WatermarkText="can't type" WatermarkCssClass="watermarked" />
                        </div>

                        <div class="col3">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnSearch" OnClick="btnSearch_Click"
                                ValidationGroup="vgSearch" Enabled="False" meta:resourcekey="btnSearchResource1" />
                        </div>
                    </div>
                </asp:Panel>

                <div class="row">
                    <div class="col12">
                        <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            DataKeyNames="UsrLoginID" CssClass="GridTable" GridLines="Horizontal" Width="100%"
                            AllowPaging="True" HorizontalAlign="Center" OnDataBound="grdData_DataBound"
                            OnSelectedIndexChanged="grdData_SelectedIndexChanged" OnRowDataBound="grdData_RowDataBound"
                            OnSorting="grdData_Sorting" OnRowCreated="grdData_RowCreated" OnPageIndexChanging="grdData_PageIndexChanging"
                            ShowFooter="True" meta:resourcekey="grdDataResource1">
                            <Columns>
                                <asp:BoundField DataField="UsrLoginID" HeaderText="Login ID" SortExpression="UsrLoginID" meta:resourcekey="BoundFieldResource1">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UsrFullName" HeaderText="Full Name" SortExpression="UsrFullName" meta:resourcekey="BoundFieldResource2">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UsrStatus" SortExpression="UsrStatus" Visible="False" meta:resourcekey="BoundFieldResource3">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Status" SortExpression="UsrStatusText" meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <%# getStatus(Eval("UsrStatus"))%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="UsrDescription" HeaderText="Description" SortExpression="UsrDescription" meta:resourcekey="BoundFieldResource4">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Button" SelectText="Select" ControlStyle-Width="50px" ShowSelectButton="true" meta:resourcekey="CommandFieldResource1" />
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
                <div class="GreySetion">
                    <div class="row">
                        <div class="col12">
                            <asp:Panel ID="pnlTitel" runat="server" CssClass="collapsePanelTitelHeader" meta:resourcekey="pnlTitelResource1">
                                <asp:HyperLink ID="hlkTitel" runat="server" Text="User Information"
                                    CssClass="collapsePanelTitelLink" meta:resourcekey="hlkTitelResource1"></asp:HyperLink>
                                <asp:Label ID="lblTitel" runat="server" Text="Label" CssClass="collapsePanelTitelLabel" meta:resourcekey="lblTitelResource1"></asp:Label>
                                <asp:Image ID="imgTitel" runat="server" CssClass="collapsePanelImage" meta:resourcekey="imgTitelResource1" />
                            </asp:Panel>

                            <div class="collapsePanelDataBorder">
                                <cc1:CollapsiblePanelExtender ID="epnlData" runat="server" Enabled="True" TargetControlID="pnlData"
                                    CollapsedSize="0" ExpandControlID="pnlTitel" CollapseControlID="pnlTitel" CollapsedText="(Show Details...)" ExpandedText="(Hide Details)" TextLabelID="lblTitel" ImageControlID="imgTitel" ExpandedImage="~/images/collapse.jpg"
                                    CollapsedImage="~/images/expand.jpg">
                                </cc1:CollapsiblePanelExtender>
                                <asp:Panel ID="pnlData" runat="server" CssClass="collapsePanelData" meta:resourcekey="pnlDataResource1">
                                    <div class="row">
                                        <div class="col8">
                                            <asp:LinkButton ID="btnAdd" runat="server" Text="Add" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnAdd_Click" meta:resourcekey="btnAddResource1"></asp:LinkButton>

                                            <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CssClass="GenButton  glyphicon glyphicon-edit" Enabled="False"
                                                OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1"></asp:LinkButton>

                                            <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CssClass="GenButton glyphicon glyphicon-remove" Enabled="False"
                                                OnClick="btnDelete_Click" meta:resourcekey="btnDeleteResource1"></asp:LinkButton>

                                            <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="GenButton glyphicon glyphicon-floppy-disk" Enabled="False"
                                                OnClick="btnSave_Click" ValidationGroup="vgSave" meta:resourcekey="btnSaveResource1"></asp:LinkButton>

                                            <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="GenButton glyphicon glyphicon-remove-circle" Enabled="False"
                                                OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1"></asp:LinkButton>

                                            <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px" meta:resourcekey="cvtxtResource1"></asp:TextBox>
                                            <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="ShowMsg" CssClass="CustomValidator"
                                                OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvShowMsgResource1"></asp:CustomValidator>
                                        </div>
                                    </div>
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
                                            <asp:Label ID="lblUsrLoginID" runat="server" Text="Login ID :" meta:resourcekey="lblUsrLoginIDResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtUsrLoginID" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtUsrLoginIDResource1"></asp:TextBox>
                                            <asp:CustomValidator ID="cvUsrLoginID" runat="server" ValidationGroup="vgSave" OnServerValidate="UsrLoginID_ServerValidate" CssClass="CustomValidator"
                                                Text="&lt;img src='../Images/icon/Exclamation.gif' title='Login ID is required!' /&gt;"
                                                EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvUsrLoginIDResource1"></asp:CustomValidator>
                                        </div>
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblUsrPassword" runat="server" Text="Password :" meta:resourcekey="lblUsrPasswordResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtUsrPassword" runat="server" TextMode="Password" MaxLength="50"
                                                Enabled="False" meta:resourcekey="txtUsrPasswordResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvUsrPassword" runat="server" ControlToValidate="txtUsrPassword" CssClass="CustomValidator"
                                                EnableClientScript="False" ValidationGroup="vgSave" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Password is required!' /&gt;" meta:resourcekey="rvUsrPasswordResource1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <asp:Label ID="lblUsrFullName" runat="server" Text="Full Name :" meta:resourcekey="lblUsrFullNameResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtUsrFullName" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtUsrFullNameResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="False" CssClass="CustomValidator"
                                                ControlToValidate="txtUsrFullName" ValidationGroup="vgSave" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Full Name is required!' /&gt;" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblUsrStatus" runat="server" Text="Status :" meta:resourcekey="lblUsrStatusResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:DropDownList ID="ddlUsrStatus" runat="server" meta:resourcekey="ddlUsrStatusResource1">
                                                <asp:ListItem Value="0" Text="InActive" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Active" Selected="True" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblUsrStartDate" runat="server" Text="Start Date :" meta:resourcekey="lblUsrStartDateResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <uc:Calendar2 ID="calUsrStartDate" runat="server" CalendarType="System" ValidationGroup="vgSave" />
                                                    </td>
                                                    <td>
                                                        <asp:CustomValidator ID="cvCompareDates" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='start date more than end date!' /&gt;"
                                                            ValidationGroup="vgSave" ErrorMessage="start date more than end date!" OnServerValidate="DateValidate_ServerValidate" CssClass="CustomValidator"
                                                            EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvCompareDatesResource1"></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblUsrEndDate" runat="server" Text="End Date :" meta:resourcekey="lblUsrEndDateResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <uc:Calendar2 ID="calUsrExpiryDate" runat="server" CalendarType="System" ValidationGroup="vgSave" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <asp:Label ID="lblUsrEmilID" runat="server" Text="E-Mail :" meta:resourcekey="lblUsrEmilIDResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtUsrEmail" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtUsrEmailResource1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rvEmailIDCorrect" runat="server" ErrorMessage="Please enter email in correct format"
                                                Text="&lt;img src='../Images/icon/Exclamation.gif' title='Please enter email in correct format!' /&gt;"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtUsrEmail" CssClass="CustomValidator"
                                                EnableClientScript="False" ValidationGroup="vgSave" meta:resourcekey="rvEmailIDCorrectResource1"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" EnableClientScript="False" CssClass="CustomValidator"
                                                ControlToValidate="txtUsrEmail" ValidationGroup="vgSave" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Email is required!' /&gt;" meta:resourcekey="rfvtxtEmailResource1"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col2">
                                            <asp:Label ID="lblUsrLang" runat="server" Text="User Language :" meta:resourcekey="lblUsrLangResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:DropDownList ID="ddlUsrLang" runat="server" meta:resourcekey="ddlUsrLangResource1">
                                                <asp:ListItem Value="Ar" Text="Arabic" Selected="True" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                                <asp:ListItem Value="En" Text="English" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">

                                            <asp:Label ID="lblUsrDescription" runat="server" Text="Description :" meta:resourcekey="lblUsrDescriptionResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtUsrDescription" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtUsrDescriptionResource1"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col12">
                                            <uc3:PermissionsCtl ID="PermCtl" runat="server" ShowRole="true" />
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
