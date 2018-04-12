<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="EmployeeTransaction.aspx.cs" Inherits="Pages_EmployeeTransaction" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

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
                                <asp:ListItem Value="EmpID" Text="Employee ID" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                <asp:ListItem Value="EmpNameAr" Text="Employee Name (Ar)" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                <asp:ListItem Value="EmpNameEn" Text="Employee Name (En)" meta:resourcekey="ListItemResource4"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col1">
                            <asp:TextBox ID="txtSearch" runat="server" Enabled="False" meta:resourcekey="txtSearchResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvSearch" runat="server" ControlToValidate="txtSearch" CssClass="CustomValidator"
                                EnableClientScript="False" ValidationGroup="vgSearch" Text="&lt;img src='../Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;" meta:resourcekey="rvSearchResource1"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="eFilteredSearch" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtSearch" />
                            <cc1:TextBoxWatermarkExtender ID="eWatermarkSearch" runat="server" Enabled="True" TargetControlID="txtSearch" WatermarkText="can't type" WatermarkCssClass="watermarked" />
                        </div>
                        <div class="col1">
                            <asp:Label ID="lblMonth" runat="server" Text="Month:" Height="18px" meta:resourcekey="lblMonthResource1"></asp:Label>
                        </div>
                        <div class="col2">
                            <asp:DropDownList ID="ddlMonth" runat="server" meta:resourcekey="ddlMonthResource1">
                            </asp:DropDownList>
                        </div>
                        <div class="col1">
                            <asp:Label ID="lblYear" runat="server" Text="Year:" Height="18px" meta:resourcekey="lblYearResource1"></asp:Label>
                        </div>
                        <div class="col2">
                            <asp:DropDownList ID="ddlYear" runat="server" meta:resourcekey="ddlYearResource1">
                            </asp:DropDownList>
                        </div>
                        <div class="col1">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnSearch" OnClick="btnSearch_Click"
                                ValidationGroup="vgSearch" Enabled="False" meta:resourcekey="btnSearchResource1" />
                        </div>
                    </div>
                </asp:Panel>
                <div class="row">
                    <div class="col12">
                        <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CssClass="GridTable"
                            DataKeyNames="EmpID" Width="100%" GridLines="Horizontal" HorizontalAlign="Center"
                            CellPadding="4" AllowPaging="True" OnDataBound="grdData_DataBound"
                            OnRowDataBound="grdData_RowDataBound" OnSorting="grdData_Sorting" OnRowCreated="grdData_RowCreated"
                            OnPageIndexChanging="grdData_PageIndexChanging" ShowFooter="True" meta:resourcekey="grdDataResource1">
                            <Columns>
                                <asp:BoundField DataField="EmpID" HeaderText="Employee ID " SortExpression="EmpID" meta:resourcekey="BoundFieldResource1">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EmpNameAr" HeaderText="Employee Name (Ar)" SortExpression="EmpNameAr" meta:resourcekey="BoundFieldResource2">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EmpNameEn" HeaderText="Employee Name (En)" SortExpression="EmpNameEn" meta:resourcekey="BoundFieldResource3">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Date" SortExpression="TrnDate" meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <%# DisplayFun.GrdDisplayDate(Eval("TrnDate"), 'S')%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Time" InsertVisible="False"
                                    SortExpression="TrnTime" meta:resourcekey="TemplateFieldResource2">
                                    <ItemTemplate>
                                        <%# DisplayFun.GrdDisplayTime(Eval("TrnTime"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="TrnType" DataField="TrnType"
                                    ReadOnly="True" SortExpression="TrnType" meta:resourcekey="BoundFieldResource4"></asp:BoundField>
                                <asp:TemplateField HeaderText="Type" InsertVisible="False"
                                    SortExpression="TrnType1" meta:resourcekey="TemplateFieldResource3">
                                    <ItemTemplate>
                                        <%# DisplayFun.GrdDisplayTypeTrans(Eval("TrnType"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Location(En)" DataField="LocationEn"
                                    InsertVisible="False" ReadOnly="True" meta:resourcekey="BoundFieldResource5"></asp:BoundField>
                                <asp:BoundField HeaderText="Location(Ar)" DataField="LocationAr"
                                    InsertVisible="False" ReadOnly="True" meta:resourcekey="BoundFieldResource6"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

