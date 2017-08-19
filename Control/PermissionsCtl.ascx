<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PermissionsCtl.ascx.cs"
    Inherits="PermissionsCtl" %>
<table border="1" cellspacing="0" cellpadding="0">
    <tr>
        <td colspan="2">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="center" class=".Logout">
                        <h4>
                            <bold>
                                <asp:Label ID="Label3" runat="server" Text="Permissions" meta:resourcekey="Label3Resource1" ></asp:Label>
                            <bold>
                        </h4>
                    </td>
                </tr>
                <%--<div id="divRole" runat="server" visible="false">
                    <tr>
                        <td class="td1align" colspan="2" valign="bottom">
                            <asp:ImageButton ID="imbCheckAll" runat="server" onclick="CheckAll_Click"  ImageUrl="~/Images/icon/CheckAll.png" meta:resourcekey="imbCheckAllResource1" />
                            <asp:ImageButton ID="imbUnCheckAll" runat="server" onclick="CheckAll_Click" 
                                ImageUrl="~/Images/icon/UnCheckAll.png" 
                                meta:resourcekey="imbUnCheckAllResource1"/>
                            <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="True" 
                                OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" Width="200px" 
                                Height="16px" meta:resourcekey="ddlRoleResource1">
                            </asp:DropDownList>
                        </td> 
                    </tr>
               </div>--%>
            </table>
        </td>
    </tr>
    <tr>
        <td class="td1Allalign" style="width:250px">
            <asp:Label ID="lblHomePerm" runat="server" Text="Home Page Permission :"></asp:Label>
        </td>
        <td class="td2Allalign" style="width:450px">
            <asp:CheckBoxList ID="cblHome" runat="server" RepeatDirection="Horizontal" Enabled="false">
                <asp:ListItem Text="View" Value="VHome" meta:resourcekey="SearchListItemResource"></asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="td1Allalign" style="width:250px">
            <asp:Label ID="lblAppUsrPerm" runat="server" Text="User Permission :"></asp:Label>
        </td>
        <td class="td2Allalign" style="width:450px">
            <asp:CheckBoxList ID="cblUsr" runat="server" RepeatDirection="Horizontal" Enabled="false">
                <asp:ListItem Text="View" Value="VUsr" meta:resourcekey="SearchListItemResource"></asp:ListItem>
                <asp:ListItem Text="Add" Value="IUsr" meta:resourcekey="AddListItemResource"></asp:ListItem>
                <asp:ListItem Text="Update" Value="UUsr" meta:resourcekey="UpdateListItemResource"></asp:ListItem>
                <asp:ListItem Text="Delete" Value="DUsr" meta:resourcekey="DeleteListItemResource"></asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="td1Allalign" style="width:250px">
            <asp:Label ID="lblDep" runat="server" Text="Department Permission :"></asp:Label>
        </td>
        <td class="td2Allalign" style="width:650px">
            <asp:CheckBoxList ID="cblDep" runat="server" RepeatDirection="Horizontal" Enabled="false">
                <asp:ListItem Text="View" Value="VDep" meta:resourcekey="SearchListItemResource"></asp:ListItem>
                <asp:ListItem Text="Add"    Value="IDep" meta:resourcekey="AddListItemResource"   ></asp:ListItem>
                <asp:ListItem Text="Update" Value="UDep" meta:resourcekey="UpdateListItemResource"></asp:ListItem>
                <asp:ListItem Text="Delete" Value="DDep" meta:resourcekey="DeleteListItemResource"></asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="td1Allalign" style="width:250px">
            <asp:Label ID="lblEmp" runat="server" Text="Employee Permission :"></asp:Label>
        </td>
        <td class="td2Allalign" style="width:650px">
            <asp:CheckBoxList ID="cblEmp" runat="server" RepeatDirection="Horizontal" Enabled="false">
                <asp:ListItem Text="View" Value="VEmp" meta:resourcekey="SearchListItemResource"></asp:ListItem>
                <asp:ListItem Text="Add"    Value="IEmp" meta:resourcekey="AddListItemResource"></asp:ListItem>
                <asp:ListItem Text="Update" Value="UEmp" meta:resourcekey="UpdateListItemResource"></asp:ListItem>
                <asp:ListItem Text="Delete" Value="DEmp" meta:resourcekey="DeleteListItemResource"></asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="td1Allalign" style="width:250px">
            <asp:Label ID="lblVac" runat="server" Text="Vacation Type Permission :"></asp:Label>
        </td>
        <td class="td2Allalign" style="width:650px">
            <asp:CheckBoxList ID="cblVac" runat="server" RepeatDirection="Horizontal" Enabled="false">
                <asp:ListItem Text="View" Value="VVac" meta:resourcekey="SearchListItemResource"></asp:ListItem>
                <asp:ListItem Text="Add"    Value="IVac" meta:resourcekey="AddListItemResource"></asp:ListItem>
                <asp:ListItem Text="Update" Value="UVac" meta:resourcekey="UpdateListItemResource"></asp:ListItem>
                <asp:ListItem Text="Delete" Value="DVac" meta:resourcekey="DeleteListItemResource"></asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>

    <tr>
        <td class="td1Allalign" style="width:250px">
            <asp:Label ID="lblVacEmp" runat="server" Text="Employee Vacation Permission :"></asp:Label>
        </td>
        <td class="td2Allalign" style="width:650px">
            <asp:CheckBoxList ID="cblVacEmp" runat="server" RepeatDirection="Horizontal" Enabled="false">
                <asp:ListItem Text="View" Value="VEmpVac" meta:resourcekey="SearchListItemResource"></asp:ListItem>
                <asp:ListItem Text="Add"    Value="IEmpVac" meta:resourcekey="AddListItemResource"></asp:ListItem>
                <asp:ListItem Text="Update" Value="UEmpVac" meta:resourcekey="UpdateListItemResource"></asp:ListItem>
                <asp:ListItem Text="Delete" Value="DEmpVac" meta:resourcekey="DeleteListItemResource"></asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="td1Allalign" style="width:250px">
            <asp:Label ID="lblMac" runat="server" Text="Machine Permission :"></asp:Label>
        </td>
        <td class="td2Allalign" style="width:650px">
            <asp:CheckBoxList ID="cblMac" runat="server" RepeatDirection="Horizontal" Enabled="false">
                <asp:ListItem Text="View" Value="VMac" meta:resourcekey="SearchListItemResource"></asp:ListItem>
                <asp:ListItem Text="Add" Value="IMac"    meta:resourcekey="AddListItemResource"></asp:ListItem>
                <asp:ListItem Text="Update" Value="UMac" meta:resourcekey="UpdateListItemResource"></asp:ListItem>
                <asp:ListItem Text="Delete" Value="DMac" meta:resourcekey="DeleteListItemResource"></asp:ListItem>
                <asp:ListItem Text="Status Machine" Value="SMac" meta:resourcekey="StatusMacListItemResource"></asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="td1Allalign" style="width:250px">
            <asp:Label ID="lblSet" runat="server" Text="System Configuration Permission :"></asp:Label>
        </td>
        <td class="td2Allalign" style="width:650px">
            <asp:CheckBoxList ID="cblSet" runat="server" RepeatDirection="Horizontal" Enabled="false">
                <%--<asp:ListItem Text="View" Value="VSet" meta:resourcekey="SearchListItemResource"></asp:ListItem>--%>
                <%--<asp:ListItem Text="Add" Value="ISet"    meta:resourcekey="AddListItemResource"></asp:ListItem>--%>
                <asp:ListItem Text="Update" Value="USet" meta:resourcekey="UpdateListItemResource"></asp:ListItem>
                <%--<asp:ListItem Text="Delete" Value="DSet" meta:resourcekey="DeleteListItemResource"></asp:ListItem>--%>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="td1Allalign" style="width:250px">
            <asp:Label ID="lblRep" runat="server" Text="Report Permission :"></asp:Label>
        </td>
        <td class="td2Allalign" style="width:650px">
            <asp:CheckBoxList ID="cblRep" runat="server" RepeatDirection="Horizontal"
                Enabled="false">
                <asp:ListItem Text="View" Value="VRep"></asp:ListItem>
                <asp:ListItem Text="Edit" Value="ERep" meta:resourcekey="liEditResource"></asp:ListItem>
                <asp:ListItem Text="Set To Default" Value="DefRep" meta:resourcekey="liSetDefaultResource"></asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
</table>
