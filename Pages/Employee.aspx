<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="Employee" Title="Employee Page" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
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
                                <asp:ListItem Value="EmpNameAr" Text="Employee Name (Ar)"></asp:ListItem>
                                <asp:ListItem Value="EmpNameEn" Text="Employee Name (En)"></asp:ListItem>
                                <asp:ListItem Value="DepID" Text="Department ID" Enabled="false"></asp:ListItem>
                                <asp:ListItem Value="DepNameAr" Text="Department Name (Ar)"></asp:ListItem>
                                <asp:ListItem Value="DepNameEn" Text="Department Name (En)"></asp:ListItem>
                                <asp:ListItem Value="SdpID" Text="SubDepartment ID" Enabled="false"></asp:ListItem>
                                <asp:ListItem Value="SdpNameAr" Text="SubDepartment Name (Ar)"></asp:ListItem>
                                <asp:ListItem Value="SdpNameEn" Text="SubDepartment Name (En)"></asp:ListItem>
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
                            CellPadding="4" DataKeyNames="EmpID" CssClass="vGrid"
                            GridLines="Horizontal" Width="100%"
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

                                <asp:BoundField DataField="DepID" HeaderText="Department ID" ReadOnly="True" SortExpression="DepID" Visible="false" />
                                <asp:BoundField DataField="DepNameAr" HeaderText="Department Name (Ar)" SortExpression="DepNameAr">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DepNameEn" HeaderText="Department Name (En)" SortExpression="DepNameEn" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="SdpID" HeaderText="SubDepartment ID" ReadOnly="True" SortExpression="SdpID" Visible="false" />
                                <asp:BoundField DataField="SdpNameAr" HeaderText="SubDepartment Name (Ar)" SortExpression="SdpNameAr">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SdpNameEn" HeaderText="SubDepartment Name (En)" SortExpression="SdpNameEn" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="EmpStatus" HeaderText="" SortExpression="EmpStatus" Visible="false" />
                                <asp:TemplateField HeaderText="Status" SortExpression="EmpStatusText">
                                    <ItemTemplate>
                                        <%# getStatus(Eval("EmpStatus"))%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>

                                <asp:CommandField ButtonType="Button" SelectText="select" ShowSelectButton="True" />
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
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblEmpStatus" runat="server" Text="Status :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:DropDownList ID="ddlEmpStatus" runat="server">
                                                <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Active" Selected="True"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblEmpNameAr" runat="server" Text="Employee Name (Ar) :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtEmpNameAr" runat="server" Enabled="False"></asp:TextBox>
                                            <asp:CustomValidator ID="cvEmpNameAr" runat="server" ValidationGroup="vgSave" OnServerValidate="EmpName_ServerValidate"
                                                Text="&lt;img src='Images/icon/Exclamation.gif' title='Employee Name (Ar) is required!' /&gt;" CssClass="CustomValidator"
                                                EnableClientScript="False" ControlToValidate="cvtxt">
                                            </asp:CustomValidator>
                                        </div>
                                        <div class="col2">
                                            <asp:Label ID="lblEmpNameEn" runat="server" Text="Employee Name (En) :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtEmpNameEn" runat="server" Enabled="False"></asp:TextBox>
                                            <asp:CustomValidator ID="cvEmpNameEn" runat="server" ValidationGroup="vgSave" OnServerValidate="EmpName_ServerValidate"
                                                Text="&lt;img src='Images/icon/Exclamation.gif' title='Employee Name (En) is required!' /&gt;" CssClass="CustomValidator"
                                                EnableClientScript="False" ControlToValidate="cvtxt">
                                            </asp:CustomValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblEmpPositionAr" runat="server" Text="Position Name (Ar) :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtEmpPositionAr" runat="server" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvEmpPositionAr" runat="server" ValidationGroup="vgSave" ControlToValidate="txtEmpPositionAr" CssClass="CustomValidator"
                                                EnableClientScript="False" Text="&lt;img src='Images/icon/Exclamation.gif' title='Position Name (Ar) is required' /&gt;">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col2">
                                            <asp:Label ID="lblEmpPositionEn" runat="server" Text="Position Name (En) :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtEmpPositionEn" runat="server" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvEmpPositionEn" runat="server" ValidationGroup="vgSave" ControlToValidate="txtEmpPositionEn"
                                                EnableClientScript="False" Text="&lt;img src='Images/icon/Exclamation.gif' title='Position Name (En) is required' /&gt;" CssClass="CustomValidator"
                                                Enabled="false">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblDepID" runat="server" Text="Department :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:DropDownList ID="ddlDepID" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rvDepID" runat="server" ValidationGroup="vgSave" ControlToValidate="ddlDepID" CssClass="CustomValidator"
                                                EnableClientScript="False" Text="&lt;img src='Images/icon/Exclamation.gif' title='Department is required' /&gt;">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col2">
                                            <asp:Label ID="lblUsrEmilID" runat="server" Text="E-Mail :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtEmpEmail" runat="server" Enabled="False"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rvEmailIDCorrect" runat="server" ErrorMessage="Please enter email in correct format"
                                                Text="&lt;img src='../Images/icon/Exclamation.gif' title='Please enter email in correct format!' /&gt;" CssClass="CustomValidator"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmpEmail"
                                                EnableClientScript="False" ValidationGroup="vgSave" meta:resourcekey="rvEmailIDCorrectResource1"></asp:RegularExpressionValidator>

                                            <%--<td class="td1Allalign">
                                                <span class="RequiredField">*</span>
                                                <asp:Label ID="lblSdpID" runat="server" Text="SubDepartment :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:DropDownList ID="ddlSdpID" runat="server" Width="173px"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rvSdpID" runat="server" ValidationGroup="vgSave" ControlToValidate="ddlSdpID"
                                                    EnableClientScript="False" Text="&lt;img src='Images/icon/Exclamation.gif' title='SubDepartment is required' /&gt;">
                                                </asp:RequiredFieldValidator>
                                            </td>--%>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <asp:Label ID="lblEmpMobile" runat="server" Text="Mobile :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtEmpMobile" runat="server"  Enabled="False" onkeypress="return NumberOnly(event);"></asp:TextBox>
                                        </div>
                                    </div>

                                </asp:Panel>
                            </div>

                        
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

