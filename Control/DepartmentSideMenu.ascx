<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentSideMenu.ascx.cs" Inherits="DepartmentSideMenu" %>

<script type="text/javascript" src="../JScript/sdmenu.js"></script>

<div style="float: left; width:150px" id="my_menu" class="sdmenu1" onclick="loadfun('my_menu');">
    <%--Cards--%>
    <div>
        <span>
            <center>
                <asp:LinkButton ID="btnDepartment" runat="server" Enabled="False" OnClick="btnSideMenu_Click" PostBackUrl="~/Pages/Department.aspx"
                        Text="<%$ Resources:Menu, btnDepartment %>">
                    </asp:LinkButton>
            </center>
        </span>
        <span>
            <center>
                <asp:LinkButton ID="btnDepRelation" runat="server" Enabled="False" OnClick="btnSideMenu_Click" PostBackUrl="~/Pages/Department.aspx"
                        Text="<%$ Resources:Menu, btnDepRelation %>">
                    </asp:LinkButton>
            </center>
        </span>
    </div>
</div>