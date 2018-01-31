<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="AddTransaction.aspx.cs" Inherits="Pages_AddTransaction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Control/Calendar2.ascx" TagPrefix="uc" TagName="Calendar2" %>
<%@ Register Assembly="TimePickerServerControl" Namespace="TimePickerServerControl" TagPrefix="Almaalimtp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
                                <asp:ListItem Value="EmpID" Text="Employee ID"></asp:ListItem>
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
                        <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" DataKeyNames="EmpID" Width="100%"
                            AllowPaging="True" HorizontalAlign="Center"
                            OnDataBound="grdData_DataBound" OnSelectedIndexChanged="grdData_SelectedIndexChanged"
                            OnRowDataBound="grdData_RowDataBound" OnSorting="grdData_Sorting" OnRowCreated="grdData_RowCreated"
                            OnPageIndexChanging="grdData_PageIndexChanging" ShowFooter="True"
                            EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="EmpID" HeaderText="ID" SortExpression="EmpID">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EmpNameAr" HeaderText="Name (Ar)" SortExpression="EmpNameAr">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="EmpNameEn" HeaderText="Name (En)" SortExpression="EmpNameEn" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Trans Date" SortExpression="TrnDate">
                                    <ItemTemplate>
                                        <%# DisplayFun.GrdDisplayDate(Eval("TrnDate"),'S')%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Trans Time" SortExpression="TrnTime">
                                    <ItemTemplate>
                                        <%# DisplayFun.GrdDisplayTime(Eval("TrnTime"))%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="DepID" HeaderText="Department ID" ReadOnly="True" SortExpression="DepID" Visible="false" />
                                <asp:BoundField DataField="DepNameAr" HeaderText="Department Name (Ar)" SortExpression="DepNameAr">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DepNameEn" HeaderText="Department Name (En)" SortExpression="DepNameEn" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
                <div class="GreySetion">

                    <asp:Panel ID="pnlTitel" runat="server" CssClass="collapsePanelTitelHeader">
                        <asp:HyperLink ID="hlkTitel" runat="server" Text="Employee Information" Width="202px" CssClass="collapsePanelTitelLink"></asp:HyperLink>
                        <asp:Label ID="lblTitel" runat="server" Text="Label" Width="873px" CssClass="collapsePanelTitelLabel"></asp:Label>
                        <asp:Image ID="imgTitel" runat="server" CssClass="collapsePanelImage" />
                    </asp:Panel>

                    <div class="collapsePanelDataBorder">
                        <cc1:CollapsiblePanelExtender ID="epnlData" runat="server" Enabled="True"
                            TargetControlID="pnlData"
                            CollapsedSize="0" Collapsed="False"
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
                                    <asp:Label ID="lblEmpID" runat="server" Text="Employee ID :"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:TextBox ID="txtEmpID" runat="server" Enabled="False"></asp:TextBox>
                                    <asp:CustomValidator ID="cvEmpID" runat="server" ValidationGroup="vgSave" OnServerValidate="EmpID_ServerValidate"
                                        Text="&lt;img src='Images/icon/Exclamation.gif' title='Employee ID is required!' /&gt;" CssClass="CustomValidator"
                                        EnableClientScript="False" ControlToValidate="cvtxt">
                                    </asp:CustomValidator>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col2">
                                    <span class="RequiredField">*</span>
                                    <asp:Label ID="lblTrnDate" runat="server" Text="Trans Date :"></asp:Label>
                                </div>
                                <div class="col3">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <uc:Calendar2 ID="calTrnDate" runat="server" CalendarType="System" ValidationGroup="vgSave" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col2">
                                    <span class="RequiredField">*</span>
                                    <asp:Label ID="lblTrnTime" runat="server" Text="Trans Time :"></asp:Label>
                                </div>
                                <div class="col3">
                                    <div class="col3">
                                        <Almaalimtp:TimePicker ID="tpTrnTime" runat="server" FormatTime="HHmm" CssClass="TimeCss"
                                            TimePickerValidationGroup="VgSave" TimePickerValidationText="&lt;img src='../Images/icon/Exclamation.gif' title='Trans Time is required!' /&gt;" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col2">
                                    <span class="RequiredField">*</span>
                                    <asp:Label ID="lblTrnType" runat="server" Text="Trans Type :"></asp:Label>
                                </div>
                                <div class="col3">
                                    <asp:DropDownList ID="ddlTrnType" runat="server">
                                    <asp:ListItem Text="- Select Trans Type -" Value="10" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="IN" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="OUT" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlTrnType" runat="server" ControlToValidate="ddlTrnType" CssClass="CustomValidator"
                                    EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Trans Type is required!' /&gt;"
                                    ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </asp:Panel>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

