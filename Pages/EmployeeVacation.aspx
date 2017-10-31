<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="EmployeeVacation.aspx.cs" Inherits="EmployeeVacation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Control/Calendar2.ascx" TagPrefix="uc" TagName="Calendar2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <asp:Panel ID="pnlSearch" runat="server" class="SearchPanel">
                    <table>
                        <tr>
                            <td valign="middle">
                                &nbsp;
                                <asp:Label ID="lblSearch" runat="server" Text="Search By :"></asp:Label>
                                <asp:DropDownList ID="ddlSearch" runat="server" Width="261px" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged"
                                    AutoPostBack="True">
                                    <asp:ListItem Value="[none]" Text="[none]" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="EmpID" Text="Employee ID"></asp:ListItem>
                                    <asp:ListItem Value="VtpNameAr" Text="Vacation Name (Ar)"></asp:ListItem>
                                    <asp:ListItem Value="VtpNameEn" Text="Vacation Name (En)"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtSearch" runat="server" Width="500px" Enabled="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rvSearch" runat="server" ControlToValidate="txtSearch"
                                    EnableClientScript="False" ValidationGroup="vgSearch" Text="&lt;img src='Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;">
                                </asp:RequiredFieldValidator>
                                <ajaxToolkit:FilteredTextBoxExtender ID="eFilteredSearch" runat="server" Enabled="True"
                                    FilterType="Numbers" TargetControlID="txtSearch" />
                                <ajaxToolkit:TextBoxWatermarkExtender ID="eWatermarkSearch" runat="server" Enabled="True"
                                    TargetControlID="txtSearch" WatermarkText="can't type" WatermarkCssClass="watermarked" />
                                <%--&nbsp;--%>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="SearchButton" OnClick="btnSearch_Click"
                                    ValidationGroup="vgSearch" Enabled="False" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <div dir="ltr">
                    <table align="left" dir="ltr">
                        <tr>
                            <td>
                                <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CssClass="GridTable"
                                    DataKeyNames="EvrID" Width="100%" GridLines="Horizontal" HorizontalAlign="Center"
                                    CellPadding="4" AllowPaging="True" OnDataBound="grdData_DataBound" OnSelectedIndexChanged="grdData_SelectedIndexChanged"
                                    OnRowDataBound="grdData_RowDataBound" OnSorting="grdData_Sorting" OnRowCreated="grdData_RowCreated"
                                    OnPageIndexChanging="grdData_PageIndexChanging" ShowFooter="True" EnableModelValidation="True">
                                    <Columns>
                                        <asp:BoundField DataField="EmpID" HeaderText="Employee ID " SortExpression="EmpID">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EmpNameAr" HeaderText="Employee Name (Ar)" SortExpression="EmpNameAr">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EmpNameEn" HeaderText="Employee Name (En)" SortExpression="EmpNameEn">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
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
                                        <asp:BoundField DataField="EvrID" Visible="false" ReadOnly="True" SortExpression="EvrID">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Start Date" SortExpression="EvrStartDate" meta:resourcekey="TemplateFieldResource1">
                                            <ItemTemplate>
                                                <%# DateFun.GrdDisplayDate(Eval("EvrStartDate"), 'S')%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Date" SortExpression="EvrEndDate" meta:resourcekey="TemplateFieldResource1">
                                            <ItemTemplate>
                                                <%# DateFun.GrdDisplayDate(Eval("EvrEndDate"), 'S')%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ButtonType="Button" SelectText="select" ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle CssClass="header" />
                                    <FooterStyle CssClass="footer" />
                                    <PagerStyle CssClass="pgr" />
                                    <SelectedRowStyle CssClass="selected" />
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlTitel" runat="server" CssClass="collapsePanelTitelHeader">
                                    <asp:HyperLink ID="hlkTitel" runat="server" Text="Vacation Information" Width="202px"
                                        CssClass="collapsePanelTitelLink"></asp:HyperLink>
                                    <asp:Label ID="lblTitel" runat="server" Text="Label" Width="873px" CssClass="collapsePanelTitelLabel" />
                                    <asp:Image ID="imgTitel" runat="server" CssClass="collapsePanelImage" />
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="collapsePanelDataBorder">
                                <ajaxToolkit:CollapsiblePanelExtender ID="epnlData" runat="server" Enabled="True"
                                    TargetControlID="pnlData" CollapsedSize="0" Collapsed="true" ExpandControlID="pnlTitel"
                                    CollapseControlID="pnlTitel" AutoCollapse="false" AutoExpand="false" CollapsedText="(Show Details...)"
                                    ExpandedText="(Hide Details)" ExpandDirection="Vertical" TextLabelID="lblTitel"
                                    ImageControlID="imgTitel" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg">
                                </ajaxToolkit:CollapsiblePanelExtender>
                                <asp:Panel ID="pnlData" runat="server" CssClass="collapsePanelData">
                                    <table width="100%">
                                        <tr class="td2Allalign">
                                            <td colspan="4" class="collapsePanelButtonBorder">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="ActionButton" OnClick="btnAdd_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="ActionButton" Enabled="False"
                                                    OnClick="btnEdit_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="ActionButton" Enabled="False"
                                                    OnClick="btnDelete_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="ActionButton" Enabled="False"
                                                    OnClick="btnSave_Click" ValidationGroup="vgSave" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="ActionButton" Enabled="False"
                                                    OnClick="btnCancel_Click" />
                                                &nbsp;&nbsp;
                                                <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                                                <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="ShowMsg"
                                                    OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt">
                                                </asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr class="td2Allalign">
                                            <td colspan="4" class="td2Allalign" width="100%">
                                                <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False"
                                                    ValidationGroup="vgSave" />
                                                <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False"
                                                    ValidationGroup="vgShowMsg" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td1Allalign">
                                                <span class="RequiredField">*</span>
                                                <asp:Label ID="lblEmpID" runat="server" Text="Employee ID :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtEmpID" runat="server" Enabled="False" Width="168px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtEmpID" runat="server" ControlToValidate="txtEmpID"
                                                    EnableClientScript="False" Text="&lt;img src='images/Exclamation.gif' title='Employee ID is required!' /&gt;"
                                                    ValidationGroup="VGroup" meta:resourcekey="rfvddlVacTypeResource1"></asp:RequiredFieldValidator>
                                                <asp:CustomValidator ID="cvEmpID" runat="server" Text="&lt;img src='images/message_exclamation.png' title='!' /&gt;"
                                                    ValidationGroup="VGroup" ErrorMessage="this ID no there or no active!" OnServerValidate="EmpID_ServerValidate"
                                                    EnableClientScript="False" ControlToValidate="cvtxt" ></asp:CustomValidator>
                                            </td>
                                            <td class="td1Allalign">
                                                <span class="RequiredField">*</span>
                                                <asp:Label ID="lblVacationType" runat="server" Text="Vacation Type:"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:DropDownList ID="ddlVacType" runat="server" Width="171px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlVacType" runat="server" ControlToValidate="ddlVacType"
                                                    EnableClientScript="False" Text="&lt;img src='images/Exclamation.gif' title='Vacation Type is required!' /&gt;"
                                                    ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="RequiredField">*</span>
                                                <asp:Label ID="lblStartDate" runat="server" Text="Start Date :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <uc:Calendar2 ID="calStartDate" runat="server" CalendarType="System" ValidationGroup="vgSave" />
                                                        </td>
                                                        <td>
                                                            <asp:CustomValidator ID="cvCompareDates" runat="server" Text="&lt;img src='../Images/icon/Exclamation.gif' title='start date more than end date!' /&gt;"
                                                                ValidationGroup="vgSave" ErrorMessage="start date more than end date!" OnServerValidate="DateValidate_ServerValidate"
                                                                EnableClientScript="False" ControlToValidate="cvtxt" ></asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <span class="RequiredField">*</span>
                                                <asp:Label ID="lblEndDate" runat="server" Text="End Date :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <uc:Calendar2 ID="calEndDate" runat="server" CalendarType="System" ValidationGroup="vgSave" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr class="td2Allalign">
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblEvrPhone" runat="server" Text="Phone No :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtPhoneNo" runat="server" Enabled="False" Width="168"></asp:TextBox>
                                            </td>
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblAvailable" runat="server" Text="Available :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtAvailable" runat="server" Enabled="False" Width="168"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="td2Allalign">
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblEvrDesc" runat="server" Text="Description :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign" colspan="3">
                                                <asp:TextBox ID="txtEvrDesc" runat="server" Width="713px" Enabled="False"></asp:TextBox>
                                                <asp:TextBox ID="txtEvrID" runat="server" Width="10" Enabled="False" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
