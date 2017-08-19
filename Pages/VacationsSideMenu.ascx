<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VacationsSideMenu.ascx.cs" Inherits="Pages_VacationsSideMenu" %>

<script type="text/javascript" src="../JScript/sdmenu.js"></script>

<div style="float: left; width:150px" id="my_menu" class="sdmenu1" onclick="loadfun('my_menu');">
    <%--item--%>
    <div>
        <span>
            <center>
                <asp:Literal ID="litVacation" runat="server" Text="<%$ Resources:Menu, litVacation %>"
                    meta:resourcekey="litVacationResource1"></asp:Literal>
            </center>
        </span>
        <table width="100%" bgcolor="#c0c0c0" style="border-left-width: 1px; border-right-width: 1px;"
            cellspacing="0">
            <tr>
                <td align="center" bgcolor="#c0c0c0" class="Body_BG">
                    <img src="../Images/menuIcon/edit.jpeg" style="border-width: 0px;" />
                </td>
                <td align="center" width="85%">
                    <asp:LinkButton ID="btnVacationsType" runat="server" Enabled="False" OnClick="btnSideMenu_Click" PostBackUrl="~/Pages/VacationType.aspx"
                        Text="<%$ Resources:Menu, btnVacationsType %>" ></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="center" bgcolor="#c0c0c0" class="Body_BG">
                    <img src="../Images/menuIcon/edit.jpeg" style="border-width: 0px;" />
                </td>
                <td align="center" width="85%">
                    <asp:LinkButton ID="btnEmployeeVacations" runat="server" Enabled="False" OnClick="btnSideMenu_Click" PostBackUrl="~/Pages/EmployeeVacation.aspx"
                        Text="<%$ Resources:Menu, btnEmployeeVacations %>" ></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</div>
