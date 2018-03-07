<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="LogImport.aspx.cs" Inherits="Pages_LogImport" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Src="~/Control/SettingSideMenu.ascx" TagName="SettingSideMenu" TagPrefix="uc1" %>

<%@ Register Src="../Control/PermissionsCtl.ascx" TagName="PermissionsCtl" TagPrefix="uc3" %>
<%@ Register Src="~/Control/Calendar2.ascx" TagPrefix="uc" TagName="Calendar2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:SettingSideMenu ID="SideMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <asp:Panel ID="pnlSearch" runat="server" class="SearchPanel" meta:resourcekey="pnlSearchResource1">
                    <div class="row">
                <div class="col1">
                    <asp:Label ID="lblMonth" runat="server" Text="Month:" meta:resourcekey="lblMonthResource1" ></asp:Label>
                </div>
                <div class="col2">
                    <asp:DropDownList ID="ddlMonth" runat="server" meta:resourcekey="ddlMonthResource1"  ></asp:DropDownList>
                </div>
                <div class="col1">
                    <asp:Label ID="lblYear" runat="server" Text="Year:" meta:resourcekey="lblYearResource1" ></asp:Label>
                </div>
                <div class="col2">
                    <asp:DropDownList ID="ddlYear" runat="server" meta:resourcekey="ddlYearResource1"   >
                    </asp:DropDownList>
                </div>
                <div class="col1">
                    <asp:ImageButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" ImageUrl="../images/Button_Icons/button_magnify.png" meta:resourcekey="btnSearchResource1"  />
                </div>
            </div>
                </asp:Panel>

                <div class="row">
                    <div class="col12">
                        <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            DataKeyNames="ImlID" CssClass="GridTable" GridLines="Horizontal" Width="100%"
                            AllowPaging="True" HorizontalAlign="Center" OnDataBound="grdData_DataBound"
                            OnSelectedIndexChanged="grdData_SelectedIndexChanged" OnRowDataBound="grdData_RowDataBound"
                            OnSorting="grdData_Sorting" OnRowCreated="grdData_RowCreated" OnPageIndexChanging="grdData_PageIndexChanging"
                            ShowFooter="True" meta:resourcekey="grdDataResource1">
                            <Columns>
                                <asp:BoundField DataField="ImlID" HeaderText="ImlID" SortExpression="ImlID" Visible="False" meta:resourcekey="BoundFieldResource1">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IplID" HeaderText="IplID" SortExpression="IplID" Visible="False" meta:resourcekey="BoundFieldResource2">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ImlStartDT" HeaderText="Start Date" SortExpression="ImlStartDT" meta:resourcekey="BoundFieldResource3">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ImlEndDT" HeaderText="End Date" SortExpression="ImlEndDT" meta:resourcekey="BoundFieldResource4">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MacIP" HeaderText="Machine IP" SortExpression="MacIP" meta:resourcekey="BoundFieldResource5">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MtpName" HeaderText="Machine Name" SortExpression="MtpName" meta:resourcekey="BoundFieldResource6">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ImlErrMsg" HeaderText="Message" SortExpression="ImlErrMsg" meta:resourcekey="BoundFieldResource7" >
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

