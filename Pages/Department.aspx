<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Department.aspx.cs" Inherits="Department" Title="Extractor Web - Department Page" EnableEventValidation="false" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

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
                                <asp:ListItem Value="DepID" Text="Department ID" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                <asp:ListItem Value="DepNameAr" Text="Department Name (Ar)" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                <asp:ListItem Value="DepNameEn" Text="Department Name (En)" meta:resourcekey="ListItemResource4"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col2">
                            <asp:TextBox ID="txtSearch" runat="server" Enabled="False" meta:resourcekey="txtSearchResource1" AutoCompleteType="Disabled"></asp:TextBox>
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
                        <asp:GridView ID="grdMainData" runat="server" AutoGenerateColumns="False" CssClass="GridTable"
                            DataKeyNames="DepID" Width="100%"
                            GridLines="Horizontal" HorizontalAlign="Center" CellPadding="4"
                            AllowPaging="True"
                            OnDataBound="grdMainData_DataBound" OnSelectedIndexChanged="grdMainData_SelectedIndexChanged"
                            OnRowDataBound="grdMainData_RowDataBound"
                            OnSorting="grdMainData_Sorting" OnRowCreated="grdMainData_RowCreated"
                            OnPageIndexChanging="grdMainData_PageIndexChanging" ShowFooter="True" meta:resourcekey="grdMainDataResource1">
                            <Columns>
                                <asp:BoundField DataField="DepNameAr" HeaderText="Department Name (Ar)" SortExpression="DepNameAr" meta:resourcekey="BoundFieldResource1">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="DepNameEn" HeaderText="Department Name (En)" SortExpression="DepNameEn" meta:resourcekey="BoundFieldResource2">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="DepID" HeaderText="Department ID" ReadOnly="True" SortExpression="DepID" meta:resourcekey="BoundFieldResource3">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="DepDescription" HeaderText="Description" SortExpression="DepDescription" Visible="False" meta:resourcekey="BoundFieldResource4">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Button" SelectText="select" ShowSelectButton="false" meta:resourcekey="CommandFieldResource1" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="GreySetion">

                    <asp:Panel ID="pnlMainTitel" runat="server" CssClass="collapsePanelTitelHeader" meta:resourcekey="pnlMainTitelResource1">
                        <asp:HyperLink ID="hlkMainTitel" runat="server" Text="Department Information" Width="202px" CssClass="collapsePanelTitelLink" meta:resourcekey="hlkMainTitelResource1"></asp:HyperLink>
                        <asp:Label ID="lblMainTitel" runat="server" Text="Label" Width="873px" CssClass="collapsePanelTitelLabel" meta:resourcekey="lblMainTitelResource1" />
                        <asp:Image ID="imgMainTitel" runat="server" CssClass="collapsePanelImage" meta:resourcekey="imgMainTitelResource1" />
                    </asp:Panel>

                    <div class="collapsePanelDataBorder">
                        <cc1:CollapsiblePanelExtender ID="epnlMainData" runat="server" Enabled="True"
                            TargetControlID="pnlMainData"
                            CollapsedSize="0" Collapsed="True"
                            ExpandControlID="pnlMainTitel" CollapseControlID="pnlMainTitel"
                            CollapsedText="(Show Details...)" ExpandedText="(Hide Details)"
                            TextLabelID="lblMainTitel" ImageControlID="imgMainTitel" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg">
                        </cc1:CollapsiblePanelExtender>

                        <asp:Panel ID="pnlMainData" runat="server" CssClass="collapsePanelData" meta:resourcekey="pnlMainDataResource1">
                            <div class="row">
                                <div class="col8">
                                    <asp:LinkButton ID="btnMainAdd" runat="server" Text="Add" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnMainAdd_Click" meta:resourcekey="btnMainAddResource1"></asp:LinkButton>

                                    <asp:LinkButton ID="btnMainEdit" runat="server" Text="Edit" CssClass="GenButton  glyphicon glyphicon-edit" Enabled="False"
                                        OnClick="btnMainEdit_Click" meta:resourcekey="btnMainEditResource1"></asp:LinkButton>

                                    <asp:LinkButton ID="btnMainDelete" runat="server" Text="Delete" CssClass="GenButton glyphicon glyphicon-remove" Enabled="False"
                                        OnClick="btnMainDelete_Click" meta:resourcekey="btnMainDeleteResource1"></asp:LinkButton>

                                    <asp:LinkButton ID="btnMainSave" runat="server" Text="Save" CssClass="GenButton glyphicon glyphicon-floppy-disk" Enabled="False"
                                        OnClick="btnMainSave_Click" ValidationGroup="vgSave" meta:resourcekey="btnMainSaveResource1"></asp:LinkButton>

                                    <asp:LinkButton ID="btnMainCancel" runat="server" Text="Cancel" CssClass="GenButton glyphicon glyphicon-remove-circle" Enabled="False"
                                        OnClick="btnMainCancel_Click" meta:resourcekey="btnMainCancelResource1"></asp:LinkButton>
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
                                    <asp:Label ID="lblDepNameAr" runat="server" Text="Department Name (Ar) :" meta:resourcekey="lblDepNameArResource1"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:TextBox ID="txtDepNameAr" runat="server" Enabled="False" meta:resourcekey="txtDepNameArResource1" AutoCompleteType="Disabled"></asp:TextBox>
                                    <asp:CustomValidator ID="cvDepNameAr" runat="server" ValidationGroup="vgSave" OnServerValidate="DepName_ServerValidate"
                                        Text="&lt;img src='../Images/icon/Exclamation.gif' title='Department Name (Ar) is required!' /&gt;" CssClass="CustomValidator"
                                        EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvDepNameArResource1"></asp:CustomValidator>
                                </div>
                                <div class="col2">
                                    <asp:Label ID="lblDepNameEn" runat="server" Text="Department Name (En) :" meta:resourcekey="lblDepNameEnResource1"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:TextBox ID="txtDepNameEn" runat="server" Enabled="False" meta:resourcekey="txtDepNameEnResource1" AutoCompleteType="Disabled"></asp:TextBox>
                                    <asp:CustomValidator ID="cvDepNameEn" runat="server" ValidationGroup="vgSave" OnServerValidate="DepName_ServerValidate" CssClass="CustomValidator"
                                        Text="&lt;img src='../Images/icon/Exclamation.gif' title='Department Name (En) is required!' /&gt;"
                                        EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvDepNameEnResource1"></asp:CustomValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col2">
                                    <asp:Label ID="lblParentDep" runat="server" Text="Parent Department :" meta:resourcekey="lblParentDepResource1"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:DropDownList ID="ddlParentID" runat="server" meta:resourcekey="ddlParentIDResource1"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col2">
                                    <asp:Label ID="lblDepStatus" runat="server" Text="Department Status :" meta:resourcekey="lblDepStatusResource1"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:CheckBox ID="chkDepStatus" runat="server" Text="Active" meta:resourcekey="chkDepStatusResource1" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col2">
                                    <asp:Label ID="lblDepDesc" runat="server" Text="Description :" meta:resourcekey="lblDepDescResource1"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:TextBox ID="txtDepDesc" runat="server" Enabled="False" meta:resourcekey="txtDepDescResource1" AutoCompleteType="Disabled"></asp:TextBox>
                                    <asp:TextBox ID="txtDepID" runat="server" Width="10px" Enabled="False" Visible="False" meta:resourcekey="txtDepIDResource1"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

