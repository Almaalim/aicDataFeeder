<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MachineSideMenu.ascx.cs" Inherits="MachineSideMenu" %>

<script type="text/javascript" src="../JScript/sdmenu.js"></script>

<div style="float: left; width:150px" id="my_menu" class="sdmenu1" onclick="loadfun('my_menu');">
    <%--item--%>
    <div>
        <span>
            <center>
                <asp:Literal ID="litMachine" runat="server" Text="<%$ Resources:Menu, btnMachines %>"
                    ></asp:Literal>
            </center>
        </span>
        <table width="100%" bgcolor="#c0c0c0" style="border-left-width: 1px; border-right-width: 1px;"
            cellspacing="0">
            <tr>
                <td align="center" bgcolor="#c0c0c0" class="Body_BG">
                    <img src="../Images/menuIcon/new.jpeg" style="border-width: 0px;" />
                </td>
                <td align="center" width="85%">
                    <asp:LinkButton ID="btnMachines" runat="server" Enabled="False" OnClick="btnSideMenu_Click" PostBackUrl="~/Pages/SettingMachine.aspx"
                        Text="<%$ Resources:Menu, btnMachines %>" ></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="center" bgcolor="#c0c0c0" class="Body_BG">
                    <img src="../Images/menuIcon/edit.jpeg" style="border-width: 0px;" />
                </td>
                <td align="center" width="85%">
                    <asp:LinkButton ID="btnMachineStatus" runat="server" Enabled="False" OnClick="btnSideMenu_Click" PostBackUrl="~/Pages/MachinePing.aspx"
                        Text="<%$ Resources:Menu, btnMachineStatus %>" ></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</div>
