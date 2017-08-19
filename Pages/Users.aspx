<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="Users.aspx.cs" Inherits="Pages_Users" %>

<%@ Register src="../Control/UsersSideMenu.ascx" tagname="UsersSideMenu" tagprefix="uc1" %>
<%@ Register Src="../Control/PermissionsCtl.ascx" TagName="PermissionsCtl" TagPrefix="uc3" %>
<%@ Register Src="~/Control/Calendar2.ascx" TagPrefix="uc" TagName="Calendar2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:UsersSideMenu ID="SideMenu" runat="server" />
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
                                    <asp:ListItem Value="UsrLoginID" Text="Login ID"></asp:ListItem>
                                    <asp:ListItem Value="UsrFullName" Text="Full Name"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtSearch" runat="server" Width="500px" Enabled="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rvSearch" runat="server" ControlToValidate="txtSearch"
                                    EnableClientScript="False" ValidationGroup="vgSearch" Text="&lt;img src='Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;">
                                </asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="eFilteredSearch" runat="server" Enabled="True" FilterType="Numbers"
                                    TargetControlID="txtSearch" />
                                <cc1:TextBoxWatermarkExtender ID="eWatermarkSearch" runat="server" Enabled="True"
                                    TargetControlID="txtSearch" WatermarkText="can't type" WatermarkCssClass="watermarked" />
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="SearchButton" OnClick="btnSearch_Click"
                                    ValidationGroup="vgSearch" Enabled="False" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <div dir="ltr">
                    <table align="left" width="100%" dir="ltr">
                        <tr>
                            <td>
                                <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    DataKeyNames="UsrLoginID" CssClass="vGrid" GridLines="Horizontal" Width="100%"
                                    AllowPaging="True" AllowSorting="false" HorizontalAlign="Center" OnDataBound="grdData_DataBound"
                                    OnSelectedIndexChanged="grdData_SelectedIndexChanged" OnRowDataBound="grdData_RowDataBound"
                                    OnSorting="grdData_Sorting" OnRowCreated="grdData_RowCreated" OnPageIndexChanging="grdData_PageIndexChanging"
                                    ShowFooter="True">
                                    <Columns>
                                        <asp:CommandField ButtonType="Button" SelectText="User Control" ShowSelectButton="True" />
                                        <asp:BoundField DataField="UsrLoginID" HeaderText="Login ID" SortExpression="UsrLoginID">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UsrFullName" HeaderText="Full Name" SortExpression="UsrFullName">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UsrStatus" HeaderText="" SortExpression="UsrStatus" Visible="false">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Status" SortExpression="UsrStatusText">
                                            <ItemTemplate>
                                                <%# getStatus(Eval("UsrStatus"))%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="UsrDescription" HeaderText="Description" SortExpression="UsrDescription">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
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
                                    <asp:HyperLink ID="hlkTitel" runat="server" Text="User Information" Width="140px"
                                        CssClass="collapsePanelTitelLink"></asp:HyperLink>
                                    <asp:Label ID="lblTitel" runat="server" Text="Label" Width="935px" CssClass="collapsePanelTitelLabel"></asp:Label>
                                    <asp:Image ID="imgTitel" runat="server" CssClass="collapsePanelImage" />
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="collapsePanelDataBorder">
                                <cc1:CollapsiblePanelExtender ID="epnlData" runat="server" Enabled="True" TargetControlID="pnlData"
                                    CollapsedSize="0" Collapsed="False" ExpandControlID="pnlTitel" CollapseControlID="pnlTitel"
                                    AutoCollapse="false" AutoExpand="false" CollapsedText="(Show Details...)" ExpandedText="(Hide Details)"
                                    ExpandDirection="Vertical" TextLabelID="lblTitel" ImageControlID="imgTitel" ExpandedImage="~/images/collapse.jpg"
                                    CollapsedImage="~/images/expand.jpg">
                                </cc1:CollapsiblePanelExtender>
                                <asp:Panel ID="pnlData" runat="server" CssClass="collapsePanelData">
                                    <table width="100%">
                                        <tr class="td2Allalign">
                                            <td colspan="4" class="collapsePanelButtonBorder">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="ActionButton" OnClick="btnAdd_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="ActionButton" Enabled="false"
                                                    OnClick="btnEdit_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="ActionButton" Enabled="false" 
                                                    OnClick="btnDelete_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="ActionButton" Enabled="false"
                                                    OnClick="btnSave_Click" ValidationGroup="vgSave" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="ActionButton" Enabled="false"
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
                                                <span class="RequiredRedStar">*</span>
                                                <asp:Label ID="lblUsrLoginID" runat="server" Text="Login ID :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtUsrLoginID" runat="server" Enabled="False" Width="168"></asp:TextBox>
                                                <asp:CustomValidator ID="cvUsrLoginID" runat="server" ValidationGroup="vgSave" OnServerValidate="UsrLoginID_ServerValidate"
                                                    Text="&lt;img src='Images/icon/Exclamation.gif' title='Login ID is required!' /&gt;"
                                                    EnableClientScript="False" ControlToValidate="cvtxt">
                                                </asp:CustomValidator>
                                            </td>
                                            <td class="td1Allalign">
                                                <span class="RequiredRedStar">*</span>
                                                <asp:Label ID="lblUsrPassword" runat="server" Text="Password :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtUsrPassword" runat="server" TextMode="Password" MaxLength="50"
                                                    Enabled="False" Width="168"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rvUsrPassword" runat="server" ControlToValidate="txtUsrPassword"
                                                    EnableClientScript="False" ValidationGroup="vgSave" Text="&lt;img src='Images/icon/Exclamation.gif' title='Password is required!' /&gt;">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblUsrFullName" runat="server" Text="Full Name :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtUsrFullName" runat="server" Enabled="False" Width="168"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="False"
                                                ControlToValidate="txtUsrFullName" ValidationGroup="vgSave" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Full Name is required!' /&gt;"
                                                ></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="td1Allalign">
                                                <span class="RequiredRedStar">*</span>
                                                <asp:Label ID="lblUsrStatus" runat="server" Text="Status :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:DropDownList ID="ddlUsrStatus" runat="server" Width="173px">
                                                    <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Active" Selected="True"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="RequiredRedStar">*</span>
                                                <asp:Label ID="lblUsrStartDate" runat="server" Text="Start Date :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <uc:Calendar2 ID="calUsrStartDate" runat="server" CalendarType="System" ValidationGroup="vgSave" />
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
                                                <span class="RequiredRedStar">*</span>
                                                <asp:Label ID="lblUsrEndDate" runat="server" Text="End Date :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <uc:Calendar2 ID="calUsrExpiryDate" runat="server" CalendarType="System" ValidationGroup="vgSave" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblUsrEmilID" runat="server" Text="E-Mail :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign" >
                                                <asp:TextBox ID="txtUsrEmail" runat="server" Width="168" Enabled="False"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rvEmailIDCorrect" runat="server" ErrorMessage="Please enter email in correct format"
                                                Text="&lt;img src='../Images/icon/Exclamation.gif' title='Please enter email in correct format!' /&gt;"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtUsrEmail"
                                                EnableClientScript="False" ValidationGroup="vgSave" ></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" EnableClientScript="False"
                                                ControlToValidate="txtUsrEmail" ValidationGroup="vgSave" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Email is required!' /&gt;"
                                                ></asp:RequiredFieldValidator>
                                            </td>

                                            <td class="td1Allalign">
                                                <asp:Label ID="lblUsrLang" runat="server" Text="User Language :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign" >
                                                <asp:DropDownList ID="ddlUsrLang"  runat="server"  Width="168px" >
                                                    <asp:ListItem Value="Ar" Text="Arabic"   Selected="True" ></asp:ListItem>
                                                    <asp:ListItem Value="En" Text="English"></asp:ListItem>
                                                </asp:DropDownList>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblUsrDescription" runat="server" Text="Description :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign" colspan="3">
                                                <asp:TextBox ID="txtUsrDescription" runat="server" Width="690" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <uc3:PermissionsCtl ID="PermCtl" runat="server" ShowRole="true" />
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
