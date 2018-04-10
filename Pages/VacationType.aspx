<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="VacationType.aspx.cs" Inherits="VacationType" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

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
                            <asp:DropDownList ID="ddlSearch" runat="server" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged" AutoPostBack="True" meta:resourcekey="ddlSearchResource1">
                                <asp:ListItem Value="[none]" Text="[none]" Selected="True" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                <asp:ListItem Value="VtpID" Text="Vacation ID" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                <asp:ListItem Value="VtpNameAr" Text="Vacation Name (Ar)" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                <asp:ListItem Value="VtpNameEn" Text="Vacation Name (En)" meta:resourcekey="ListItemResource4"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col2">
                            <asp:TextBox ID="txtSearch" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtSearchResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvSearch" runat="server" CssClass="CustomValidator"
                                ControlToValidate="txtSearch" EnableClientScript="False" ValidationGroup="vgSearch"
                                Text="&lt;img src='../Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;" meta:resourcekey="rvSearchResource1"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="eFilteredSearch" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtSearch" />
                            <cc1:TextBoxWatermarkExtender ID="eWatermarkSearch" runat="server" Enabled="True" TargetControlID="txtSearch" WatermarkText="can't type" WatermarkCssClass="watermarked" />
                        </div>

                        <div class="col3">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnSearch" OnClick="btnSearch_Click" ValidationGroup="vgSearch" Enabled="False" meta:resourcekey="btnSearchResource1" />
                        </div>
                    </div>
                </asp:Panel>

                <div class="row">
                    <div class="col12">
                        <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CssClass="GridTable"
                            DataKeyNames="VtpID" Width="100%" GridLines="Horizontal" HorizontalAlign="Center" CellPadding="4"
                            AllowPaging="True" OnDataBound="grdData_DataBound" OnSelectedIndexChanged="grdData_SelectedIndexChanged"
                            OnRowDataBound="grdData_RowDataBound" OnSorting="grdData_Sorting" OnRowCreated="grdData_RowCreated"
                            OnPageIndexChanging="grdData_PageIndexChanging" ShowFooter="True" meta:resourcekey="grdDataResource1">
                            <Columns>
                                <asp:BoundField DataField="VtpNameAr" HeaderText="Vacation Name (Ar)" SortExpression="VtpNameAr" meta:resourcekey="BoundFieldResource1">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="VtpNameEn" HeaderText="Vacation Name (En)" SortExpression="VtpNameEn" meta:resourcekey="BoundFieldResource2">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="VtpID" HeaderText="Vacation ID" ReadOnly="True" SortExpression="VtpID" meta:resourcekey="BoundFieldResource3">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="VtpDescription" HeaderText="Description" SortExpression="VtpDescription" Visible="False" meta:resourcekey="BoundFieldResource4">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Button" ControlStyle-Width="50px" SelectText="select" ShowSelectButton="true" meta:resourcekey="CommandFieldResource1" />

                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
                <div class="GreySetion">
                    <asp:Panel ID="pnlTitel" runat="server" CssClass="collapsePanelTitelHeader" meta:resourcekey="pnlTitelResource1">
                        <asp:HyperLink ID="hlkTitel" runat="server" Text="Vacation Information" Width="202px" CssClass="collapsePanelTitelLink" meta:resourcekey="hlkTitelResource1"></asp:HyperLink>
                        <asp:Label ID="lblTitel" runat="server" Text="Label" Width="873px" CssClass="collapsePanelTitelLabel" meta:resourcekey="lblTitelResource1" />
                        <asp:Image ID="imgTitel" runat="server" CssClass="collapsePanelImage" meta:resourcekey="imgTitelResource1" />
                    </asp:Panel>

                    <div class="collapsePanelDataBorder">
                        <cc1:CollapsiblePanelExtender ID="epnlData" runat="server" Enabled="True"
                            TargetControlID="pnlData"
                            CollapsedSize="0" Collapsed="True"
                            ExpandControlID="pnlTitel" CollapseControlID="pnlTitel"
                            CollapsedText="(Show Details...)" ExpandedText="(Hide Details)"
                            TextLabelID="lblTitel" ImageControlID="imgTitel" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg">
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
                                    <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" CssClass="CustomValidator"
                                        ValidationGroup="ShowMsg" OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvShowMsgResource1"></asp:CustomValidator>
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
                                    <asp:Label ID="lblVtpNameAr" runat="server" Text="Vacation Name (Ar) :" meta:resourcekey="lblVtpNameArResource1"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:TextBox ID="txtVtpNameAr" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtVtpNameArResource1"></asp:TextBox>
                                    <asp:CustomValidator ID="cvVtpNameAr" runat="server" ValidationGroup="vgSave" OnServerValidate="VtpName_ServerValidate"
                                        Text="&lt;img src='../Images/icon/Exclamation.gif' title='Vacation Name (Ar) is required!' /&gt;" CssClass="CustomValidator"
                                        EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvVtpNameArResource1"></asp:CustomValidator>
                                </div>
                                <div class="col2">
                                    <asp:Label ID="lblVtpNameEn" runat="server" Text="Vacation Name (En) :" meta:resourcekey="lblVtpNameEnResource1"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:TextBox ID="txtVtpNameEn" runat="server" Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtVtpNameEnResource1"></asp:TextBox>
                                    <asp:CustomValidator ID="cvVtpNameEn" runat="server" ValidationGroup="vgSave" OnServerValidate="VtpName_ServerValidate"
                                        Text="&lt;img src='../Images/icon/Exclamation.gif' title='Vacation Name (En) is required!' /&gt;" CssClass="CustomValidator"
                                        EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvVtpNameEnResource1"></asp:CustomValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col2">
                                    <asp:Label ID="lblVtpStatus" runat="server" Text="Vacation Status :" meta:resourcekey="lblVtpStatusResource1"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:CheckBox ID="chkVtpStatus" runat="server" Text="Active" meta:resourcekey="chkVtpStatusResource1" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col2">
                                    <asp:Label ID="lblVtpDesc" runat="server" Text="Description :" meta:resourcekey="lblVtpDescResource1"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:TextBox ID="txtVtpDesc" runat="server"  Enabled="False" AutoCompleteType="Disabled" meta:resourcekey="txtVtpDescResource1"></asp:TextBox>
                                    <asp:TextBox ID="txtVtpID" runat="server" Width="10px" Enabled="False" Visible="False" meta:resourcekey="txtVtpIDResource1"></asp:TextBox>
                                </div>
                            </div>

                        </asp:Panel>
                    </div>

                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

