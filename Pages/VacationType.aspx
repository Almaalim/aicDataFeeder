<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="VacationType.aspx.cs" Inherits="VacationType" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <asp:Panel ID="pnlSearch" runat="server" class="SearchPanel">
                    <div class="row">
                        <div class="col1">
                            <asp:Label ID="lblSearch" runat="server" Text="Search By :"></asp:Label>
                        </div>

                        <div class="col2">
                            <asp:DropDownList ID="ddlSearch" runat="server" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="[none]" Text="[none]" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="VtpID" Text="Vacation ID"></asp:ListItem>
                                <asp:ListItem Value="VtpNameAr" Text="Vacation Name (Ar)"></asp:ListItem>
                                <asp:ListItem Value="VtpNameEn" Text="Vacation Name (En)"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col2">
                            <asp:TextBox ID="txtSearch" runat="server" Enabled="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvSearch" runat="server" CssClass="CustomValidator"
                                ControlToValidate="txtSearch" EnableClientScript="False" ValidationGroup="vgSearch"
                                Text="&lt;img src='Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;">
                            </asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="eFilteredSearch" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtSearch" />
                            <cc1:TextBoxWatermarkExtender ID="eWatermarkSearch" runat="server" Enabled="True" TargetControlID="txtSearch" WatermarkText="can't type" WatermarkCssClass="watermarked" />
                        </div>

                        <div class="col3">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnSearch" OnClick="btnSearch_Click" ValidationGroup="vgSearch" Enabled="False" />
                        </div>
                    </div>
                </asp:Panel>

                <div class="row">
                    <div class="col12">
                        <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CssClass="GridTable"
                            DataKeyNames="VtpID" Width="100%"
                            GridLines="Horizontal" HorizontalAlign="Center" CellPadding="4"
                            AllowPaging="True"
                            OnDataBound="grdData_DataBound" OnSelectedIndexChanged="grdData_SelectedIndexChanged"
                            OnRowDataBound="grdData_RowDataBound"
                            OnSorting="grdData_Sorting" OnRowCreated="grdData_RowCreated"
                            OnPageIndexChanging="grdData_PageIndexChanging" ShowFooter="True"
                            EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="VtpNameAr" HeaderText="Vacation Name (Ar)" SortExpression="VtpNameAr">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="VtpNameEn" HeaderText="Vacation Name (En)" SortExpression="VtpNameEn">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="VtpID" HeaderText="Vacation ID" ReadOnly="True" SortExpression="VtpID">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="VtpDescription" HeaderText="Description" SortExpression="VtpDescription" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Button" SelectText="select" ShowSelectButton="True" />

                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
                <div class="GreySetion">
                    <asp:Panel ID="pnlTitel" runat="server" CssClass="collapsePanelTitelHeader">
                        <asp:HyperLink ID="hlkTitel" runat="server" Text="Vacation Information" Width="202px" CssClass="collapsePanelTitelLink"></asp:HyperLink>
                        <asp:Label ID="lblTitel" runat="server" Text="Label" Width="873px" CssClass="collapsePanelTitelLabel" />
                        <asp:Image ID="imgTitel" runat="server" CssClass="collapsePanelImage" />
                    </asp:Panel>

                    <div class="collapsePanelDataBorder">
                        <cc1:CollapsiblePanelExtender ID="epnlData" runat="server" Enabled="True"
                            TargetControlID="pnlData"
                            CollapsedSize="0" Collapsed="true"
                            ExpandControlID="pnlTitel" CollapseControlID="pnlTitel" AutoCollapse="false" AutoExpand="false"
                            CollapsedText="(Show Details...)" ExpandedText="(Hide Details)" ExpandDirection="Vertical"
                            TextLabelID="lblTitel" ImageControlID="imgTitel" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg">
                        </cc1:CollapsiblePanelExtender>

                        <asp:Panel ID="pnlData" runat="server" CssClass="collapsePanelData">
                            <div class="row">
                                <div class="col8">
                                    <asp:LinkButton ID="btnAdd" runat="server" Text="Add" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnAdd_Click"></asp:LinkButton>

                                    <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CssClass="GenButton  glyphicon glyphicon-edit" Enabled="false"
                                        OnClick="btnEdit_Click"></asp:LinkButton>

                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CssClass="GenButton glyphicon glyphicon-remove" Enabled="false"
                                        OnClick="btnDelete_Click"></asp:LinkButton>

                                    <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="GenButton glyphicon glyphicon-floppy-disk" Enabled="false"
                                        OnClick="btnSave_Click" ValidationGroup="vgSave"></asp:LinkButton>

                                    <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="GenButton glyphicon glyphicon-remove-circle" Enabled="false"
                                        OnClick="btnCancel_Click"></asp:LinkButton>
                                    <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                                    <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" CssClass="CustomValidator"
                                        ValidationGroup="ShowMsg" OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col12">
                                    <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False" ValidationGroup="vgSave" />
                                    <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False" ValidationGroup="vgShowMsg" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col2">
                                    <span class="RequiredField">*</span>
                                    <asp:Label ID="lblVtpNameAr" runat="server" Text="Vacation Name (Ar) :"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:TextBox ID="txtVtpNameAr" runat="server" Enabled="False"></asp:TextBox>
                                    <asp:CustomValidator ID="cvVtpNameAr" runat="server" ValidationGroup="vgSave" OnServerValidate="VtpName_ServerValidate"
                                        Text="&lt;img src='Images/icon/Exclamation.gif' title='Vacation Name (Ar) is required!' /&gt;" CssClass="CustomValidator"
                                        EnableClientScript="False" ControlToValidate="cvtxt">
                                    </asp:CustomValidator>
                                </div>
                                <div class="col2">
                                    <asp:Label ID="lblVtpNameEn" runat="server" Text="Vacation Name (En) :"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:TextBox ID="txtVtpNameEn" runat="server" Enabled="False"></asp:TextBox>
                                    <asp:CustomValidator ID="cvVtpNameEn" runat="server" ValidationGroup="vgSave" OnServerValidate="VtpName_ServerValidate"
                                        Text="&lt;img src='Images/icon/Exclamation.gif' title='Vacation Name (En) is required!' /&gt;" CssClass="CustomValidator"
                                        EnableClientScript="False" ControlToValidate="cvtxt">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col2">
                                    <asp:Label ID="lblVtpStatus" runat="server" Text="Vacation Status :"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:CheckBox ID="chkVtpStatus" runat="server" Text="Active" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col2">
                                    <asp:Label ID="lblVtpDesc" runat="server" Text="Description :"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:TextBox ID="txtVtpDesc" runat="server"  Enabled="False"></asp:TextBox>
                                    <asp:TextBox ID="txtVtpID" runat="server" Width="10" Enabled="False" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                        </asp:Panel>
                    </div>

                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

