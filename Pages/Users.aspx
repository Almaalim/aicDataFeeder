<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" Theme="MetroStyle"
    CodeFile="Users.aspx.cs" Inherits="Pages_Users" %>

<%@ Register Src="../Control/UsersSideMenu.ascx" TagName="UsersSideMenu" TagPrefix="uc1" %>
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
                    <div class="row">
                        <div class="col1">
                            <asp:Label ID="lblSearch" runat="server" Text="Search By :"></asp:Label>
                        </div>

                        <div class="col2">
                            <asp:DropDownList ID="ddlSearch" runat="server" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged"
                                AutoPostBack="True">
                                <asp:ListItem Value="[none]" Text="[none]" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="UsrLoginID" Text="Login ID"></asp:ListItem>
                                <asp:ListItem Value="UsrFullName" Text="Full Name"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col2">
                            <asp:TextBox ID="txtSearch" runat="server" Enabled="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvSearch" runat="server" ControlToValidate="txtSearch" CssClass="CustomValidator"
                                EnableClientScript="False" ValidationGroup="vgSearch" Text="&lt;img src='Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;">
                            </asp:RequiredFieldValidator>

                            <cc1:FilteredTextBoxExtender ID="eFilteredSearch" runat="server" Enabled="True" FilterType="Numbers"
                                TargetControlID="txtSearch" />
                            <cc1:TextBoxWatermarkExtender ID="eWatermarkSearch" runat="server" Enabled="True"
                                TargetControlID="txtSearch" WatermarkText="can't type" WatermarkCssClass="watermarked" />
                        </div>

                        <div class="col3">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnSearch" OnClick="btnSearch_Click"
                                ValidationGroup="vgSearch" Enabled="False" />
                        </div>
                    </div>
                </asp:Panel>

                <div class="row">
                    <div class="col12">
                        <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            DataKeyNames="UsrLoginID" CssClass="GridTable" GridLines="Horizontal" Width="100%"
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

                        </asp:GridView>
                    </div>
                </div>
                <div class="GreySetion">
                    <div class="row">
                        <div class="col12">
                            <asp:Panel ID="pnlTitel" runat="server" CssClass="collapsePanelTitelHeader">
                                <asp:HyperLink ID="hlkTitel" runat="server" Text="User Information"
                                    CssClass="collapsePanelTitelLink"></asp:HyperLink>
                                <asp:Label ID="lblTitel" runat="server" Text="Label" CssClass="collapsePanelTitelLabel"></asp:Label>
                                <asp:Image ID="imgTitel" runat="server" CssClass="collapsePanelImage" />
                            </asp:Panel>

                            <div class="collapsePanelDataBorder">
                                <cc1:CollapsiblePanelExtender ID="epnlData" runat="server" Enabled="True" TargetControlID="pnlData"
                                    CollapsedSize="0" Collapsed="False" ExpandControlID="pnlTitel" CollapseControlID="pnlTitel"
                                    AutoCollapse="false" AutoExpand="false" CollapsedText="(Show Details...)" ExpandedText="(Hide Details)"
                                    ExpandDirection="Vertical" TextLabelID="lblTitel" ImageControlID="imgTitel" ExpandedImage="~/images/collapse.jpg"
                                    CollapsedImage="~/images/expand.jpg">
                                </cc1:CollapsiblePanelExtender>
                                <asp:Panel ID="pnlData" runat="server" CssClass="collapsePanelData">
                                    <div class="row">
                                        <div class="col8">
                                            <asp:LinkButton ID="btnAdd" runat="server" Text="Add" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnAdd_Click" ></asp:LinkButton>
                                        
                                                <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CssClass="GenButton  glyphicon glyphicon-edit" Enabled="false"
                                                    OnClick="btnEdit_Click" ></asp:LinkButton>
                                           
                                                <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CssClass="GenButton glyphicon glyphicon-remove" Enabled="false"
                                                    OnClick="btnDelete_Click" ></asp:LinkButton>
                                             
                                                <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="GenButton glyphicon glyphicon-floppy-disk" Enabled="false"
                                                    OnClick="btnSave_Click" ValidationGroup="vgSave" ></asp:LinkButton>
                                        
                                                <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="GenButton glyphicon glyphicon-remove-circle" Enabled="false"
                                                    OnClick="btnCancel_Click" ></asp:LinkButton>
                                         
                                                <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                                            <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" ValidationGroup="ShowMsg" CssClass="CustomValidator"
                                                OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt">
                                            </asp:CustomValidator>
                                        </div>
                                        </div>
                                    <div class="row">
                                        <div class="col12">
                                            <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False" 
                                                ValidationGroup="vgSave" />
                                            <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False"
                                                ValidationGroup="vgShowMsg" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblUsrLoginID" runat="server" Text="Login ID :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtUsrLoginID" runat="server" Enabled="False"></asp:TextBox>
                                            <asp:CustomValidator ID="cvUsrLoginID" runat="server" ValidationGroup="vgSave" OnServerValidate="UsrLoginID_ServerValidate" CssClass="CustomValidator"
                                                Text="&lt;img src='Images/icon/Exclamation.gif' title='Login ID is required!' /&gt;"
                                                EnableClientScript="False" ControlToValidate="cvtxt">
                                            </asp:CustomValidator>
                                        </div>
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblUsrPassword" runat="server" Text="Password :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtUsrPassword" runat="server" TextMode="Password" MaxLength="50"
                                                Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvUsrPassword" runat="server" ControlToValidate="txtUsrPassword" CssClass="CustomValidator"
                                                EnableClientScript="False" ValidationGroup="vgSave" Text="&lt;img src='Images/icon/Exclamation.gif' title='Password is required!' /&gt;">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <asp:Label ID="lblUsrFullName" runat="server" Text="Full Name :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtUsrFullName" runat="server" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="False" CssClass="CustomValidator"
                                                ControlToValidate="txtUsrFullName" ValidationGroup="vgSave" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Full Name is required!' /&gt;"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblUsrStatus" runat="server" Text="Status :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:DropDownList ID="ddlUsrStatus" runat="server">
                                                <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Active" Selected="True"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblUsrStartDate" runat="server" Text="Start Date :"></asp:Label>
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
                                                            EnableClientScript="False" ControlToValidate="cvtxt"></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblUsrEndDate" runat="server" Text="End Date :"></asp:Label>
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
                                            <asp:Label ID="lblUsrEmilID" runat="server" Text="E-Mail :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtUsrEmail" runat="server" Enabled="False"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rvEmailIDCorrect" runat="server" ErrorMessage="Please enter email in correct format"
                                                Text="&lt;img src='../Images/icon/Exclamation.gif' title='Please enter email in correct format!' /&gt;"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtUsrEmail" CssClass="CustomValidator"
                                                EnableClientScript="False" ValidationGroup="vgSave"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" EnableClientScript="False" CssClass="CustomValidator"
                                                ControlToValidate="txtUsrEmail" ValidationGroup="vgSave" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Email is required!' /&gt;"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col2">
                                            <asp:Label ID="lblUsrLang" runat="server" Text="User Language :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:DropDownList ID="ddlUsrLang" runat="server">
                                                <asp:ListItem Value="Ar" Text="Arabic" Selected="True"></asp:ListItem>
                                                <asp:ListItem Value="En" Text="English"></asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">

                                            <asp:Label ID="lblUsrDescription" runat="server" Text="Description :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtUsrDescription" runat="server" Enabled="False"></asp:TextBox>
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
