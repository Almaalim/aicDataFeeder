<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SettingSideMenu.ascx.cs" Inherits="Control_SettingSideMenu" %>

<script type="text/javascript" src="../JScript/sdmenu.js"></script>

<div style="float: left; width:150px" id="my_menu" class="sdmenu1" onclick="loadfun('my_menu');">
    <%--item--%>
    <div>
        <span>
            <center>
                <asp:Literal ID="litSetting" runat="server" Text="<%$ Resources:Menu, litSetting %>"
                    meta:resourcekey="litSettingResource1"></asp:Literal>
            </center>
        </span>
        <table width="100%" bgcolor="#c0c0c0" style="border-left-width: 1px; border-right-width: 1px;"
            cellspacing="0">
            <tr>
                <td align="center" bgcolor="#c0c0c0" class="Body_BG">
                    <img src="../Images/menuIcon/edit.jpeg" style="border-width: 0px;" />
                </td>
                <td align="center" width="85%">
                    <asp:LinkButton ID="btnImportDBConfig" runat="server" Enabled="False" OnClick="btnSideMenu_Click" PostBackUrl="~/Pages/SettingDB.aspx"
                        Text="<%$ Resources:Menu, btnImportDBConfig %>" ></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="center" bgcolor="#c0c0c0" class="Body_BG">
                    <img src="../Images/menuIcon/edit.jpeg" style="border-width: 0px;" />
                </td>
                <td align="center" width="85%">
                    <asp:LinkButton ID="btnWorktimeSet" runat="server" Enabled="False" OnClick="btnSideMenu_Click" PostBackUrl="~/Pages/WorkTimeSetting.aspx"
                        Text="<%$ Resources:Menu, btnWorktimeSet %>" ></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="center" bgcolor="#c0c0c0" class="Body_BG">
                    <img src="../Images/menuIcon/edit.jpeg" style="border-width: 0px;" />
                </td>
                <td align="center" width="85%">
                    <asp:LinkButton ID="btnImportTimeSch" runat="server" Enabled="False" OnClick="btnSideMenu_Click" PostBackUrl=""
                        Text="<%$ Resources:Menu, btnImportTimeSch %>" ></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="center" bgcolor="#c0c0c0" class="Body_BG">
                    <img src="../Images/menuIcon/edit.jpeg" style="border-width: 0px;" />
                </td>
                <td align="center" width="85%">
                    <asp:LinkButton ID="btnDatalogImport" runat="server" Enabled="False" OnClick="btnSideMenu_Click" PostBackUrl=""
                        Text="<%$ Resources:Menu, btnDatalogImport %>" ></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="center" bgcolor="#c0c0c0" class="Body_BG">
                    <img src="../Images/menuIcon/edit.jpeg" style="border-width: 0px;" />
                </td>
                <td align="center" width="85%">
                    <asp:LinkButton ID="btnEmailSetting" runat="server" Enabled="False" OnClick="btnSideMenu_Click" PostBackUrl="~/Pages/EmailSetting.aspx"
                        Text="<%$ Resources:Menu, btnEmailSetting %>" ></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</div>
