<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeVacation.aspx.cs" Inherits="EmployeeVacation" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Control/Calendar2.ascx" TagPrefix="uc" TagName="Calendar2" %>

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
                                <asp:ListItem Value="EmpID" Text="Employee ID" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                <asp:ListItem Value="VtpNameAr" Text="Vacation Name (Ar)" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                <asp:ListItem Value="VtpNameEn" Text="Vacation Name (En)" meta:resourcekey="ListItemResource4"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col2">
                            <asp:TextBox ID="txtSearch" runat="server" Width="500px" Enabled="False" meta:resourcekey="txtSearchResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvSearch" runat="server" ControlToValidate="txtSearch" CssClass="CustomValidator"
                                EnableClientScript="False" ValidationGroup="vgSearch" Text="&lt;img src='../Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;" meta:resourcekey="rvSearchResource1"></asp:RequiredFieldValidator>
                            <ajaxToolkit:FilteredTextBoxExtender ID="eFilteredSearch" runat="server" Enabled="True"
                                FilterType="Numbers" TargetControlID="txtSearch" />
                            <ajaxToolkit:TextBoxWatermarkExtender ID="eWatermarkSearch" runat="server" Enabled="True"
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
                        <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CssClass="GridTable"
                            DataKeyNames="EvrID" Width="100%" GridLines="Horizontal" HorizontalAlign="Center"
                            CellPadding="4" AllowPaging="True" OnDataBound="grdData_DataBound" OnSelectedIndexChanged="grdData_SelectedIndexChanged"
                            OnRowDataBound="grdData_RowDataBound" OnSorting="grdData_Sorting" OnRowCreated="grdData_RowCreated"
                            OnPageIndexChanging="grdData_PageIndexChanging" ShowFooter="True" meta:resourcekey="grdDataResource1">
                            <Columns>
                                <asp:BoundField DataField="EmpID" HeaderText="Employee ID " SortExpression="EmpID" meta:resourcekey="BoundFieldResource1">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EvrID" HeaderText="EvrID " SortExpression="EvrID" meta:resourcekey="BoundFieldResource2">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EmpNameAr" HeaderText="Employee Name (Ar)" SortExpression="EmpNameAr" meta:resourcekey="BoundFieldResource3">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EmpNameEn" HeaderText="Employee Name (En)" SortExpression="EmpNameEn" meta:resourcekey="BoundFieldResource4">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VtpNameAr" HeaderText="Vacation Name (Ar)" SortExpression="VtpNameAr" meta:resourcekey="BoundFieldResource5">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VtpNameEn" HeaderText="Vacation Name (En)" SortExpression="VtpNameEn" meta:resourcekey="BoundFieldResource6">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VtpID" HeaderText="Vacation ID" ReadOnly="True" SortExpression="VtpID" meta:resourcekey="BoundFieldResource7">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EvrID" Visible="False" ReadOnly="True" SortExpression="EvrID" meta:resourcekey="BoundFieldResource8">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Start Date" SortExpression="EvrStartDate" meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <%# DisplayFun.GrdDisplayDate(Eval("EvrStartDate"), 'S')%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End Date" SortExpression="EvrEndDate" meta:resourcekey="TemplateFieldResource2">
                                    <ItemTemplate>
                                        <%# DisplayFun.GrdDisplayDate(Eval("EvrEndDate"), 'S')%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Button" SelectText="select" ShowSelectButton="True" meta:resourcekey="CommandFieldResource1" />
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
                <div class="GreySetion">
                    <div class="row">
                        <div class="col12">
                            <asp:Panel ID="pnlTitel" runat="server" CssClass="collapsePanelTitelHeader" meta:resourcekey="pnlTitelResource1">
                                <asp:HyperLink ID="hlkTitel" runat="server" Text="Vacation Information"
                                    CssClass="collapsePanelTitelLink" meta:resourcekey="hlkTitelResource1"></asp:HyperLink>
                                <asp:Label ID="lblTitel" runat="server" Text="Label" CssClass="collapsePanelTitelLabel" meta:resourcekey="lblTitelResource1" />
                                <asp:Image ID="imgTitel" runat="server" CssClass="collapsePanelImage" meta:resourcekey="imgTitelResource1" />
                            </asp:Panel>

                            <div class="collapsePanelDataBorder">
                                <ajaxToolkit:CollapsiblePanelExtender ID="epnlData" runat="server" Enabled="True"
                                    TargetControlID="pnlData" CollapsedSize="0" Collapsed="True" ExpandControlID="pnlTitel"
                                    CollapseControlID="pnlTitel" CollapsedText="(Show Details...)"
                                    ExpandedText="(Hide Details)" TextLabelID="lblTitel"
                                    ImageControlID="imgTitel" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg">
                                </ajaxToolkit:CollapsiblePanelExtender>
                                <asp:Panel ID="pnlData" runat="server" CssClass="collapsePanelData" meta:resourcekey="pnlDataResource1">
                                    <div class="row">
                                        <div class="col8">
                                            <asp:LinkButton ID="btnAdd" runat="server" Text="Add" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnAdd_Click" meta:resourcekey="btnAddResource1"></asp:LinkButton>

                                            <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CssClass="GenButton  glyphicon glyphicon-edit" Enabled="False"
                                                OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1"></asp:LinkButton>

                                            <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CssClass="GenButton glyphicon glyphicon-remove" Enabled="False"
                                                OnClick="btnDelete_Click" meta:resourcekey="btnDeleteResource1"></asp:LinkButton>

                                            <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="GenButton glyphicon glyphicon-floppy-disk" Enabled="False"
                                                OnClick="btnSave_Click" ValidationGroup="vgSave" meta:resourcekey="btnSaveResource1" />

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
                                            <asp:Label ID="lblEmpID" runat="server" Text="Employee ID :" meta:resourcekey="lblEmpIDResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtEmpID" runat="server" Enabled="False" meta:resourcekey="txtEmpIDResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtEmpID" runat="server" ControlToValidate="txtEmpID"
                                                EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Employee ID is required!' /&gt;" CssClass="CustomValidator"
                                                ValidationGroup="VGroup" meta:resourcekey="rfvtxtEmpIDResource1"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="cvEmpID" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='!' /&gt;" CssClass="CustomValidator"
                                                ValidationGroup="VGroup" ErrorMessage="this ID no there or no active!" OnServerValidate="EmpID_ServerValidate"
                                                EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvEmpIDResource1"></asp:CustomValidator>
                                        </div>
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblVacationType" runat="server" Text="Vacation Type:" meta:resourcekey="lblVacationTypeResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:DropDownList ID="ddlVacType" runat="server" meta:resourcekey="ddlVacTypeResource1">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvddlVacType" runat="server" ControlToValidate="ddlVacType"
                                                EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Vacation Type is required!' /&gt;" CssClass="CustomValidator"
                                                ValidationGroup="vgSave" meta:resourcekey="rfvddlVacTypeResource1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblStartDate" runat="server" Text="Start Date :" meta:resourcekey="lblStartDateResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <uc:Calendar2 ID="calStartDate" runat="server" CalendarType="System" ValidationGroup="vgSave" />
                                            <asp:CustomValidator ID="cvCompareDates" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='start date more than end date!' /&gt;"
                                                ValidationGroup="vgSave" ErrorMessage="start date more than end date!" OnServerValidate="DateValidate_ServerValidate" CssClass="CustomValidator"
                                                EnableClientScript="False" ControlToValidate="cvtxt" meta:resourcekey="cvCompareDatesResource1"></asp:CustomValidator>
                                        </div>
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblEndDate" runat="server" Text="End Date :" meta:resourcekey="lblEndDateResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <uc:Calendar2 ID="calEndDate" runat="server" CalendarType="System" ValidationGroup="vgSave" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <asp:Label ID="lblEvrPhone" runat="server" Text="Phone No :" meta:resourcekey="lblEvrPhoneResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtPhoneNo" runat="server" Enabled="False" meta:resourcekey="txtPhoneNoResource1"></asp:TextBox>
                                        </div>
                                        <div class="col2">
                                            <asp:Label ID="lblAvailable" runat="server" Text="Available :" meta:resourcekey="lblAvailableResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtAvailable" runat="server" Enabled="False" meta:resourcekey="txtAvailableResource1"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <asp:Label ID="lblEvrDesc" runat="server" Text="Description :" meta:resourcekey="lblEvrDescResource1"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtEvrDesc" runat="server" Enabled="False" meta:resourcekey="txtEvrDescResource1"></asp:TextBox>
                                            <asp:TextBox ID="txtEvrID" runat="server" Width="10px" Enabled="False" Visible="False" meta:resourcekey="txtEvrIDResource1"></asp:TextBox>
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
