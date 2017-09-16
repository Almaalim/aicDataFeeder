<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Header" %>


 
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
    
    
                                    <asp:ImageButton ID="lnkChangeLang" runat="server" 
                                        OnClick="lnkChangeLang_Click" Height ="16px" 
                                        ImageUrl="~/App_Themes/ThemeEn/images/english_icon.png" 
                                        meta:resourcekey="lnkChangeLangResource1"/>
                               
                                    <asp:ImageButton ID="lnkChangePassword" runat="server" 
                                        OnClick="lnkChangePassword_Click" Height ="16px" 
                                        ImageUrl="~/App_Themes/ThemeEn/images/Control/ChangePass16.png" 
                                        meta:resourcekey="lnkChangePasswordResource1" />
                              
                                    <asp:ImageButton ID="lnkLogout" runat="server" OnClick="lnkLogout_Click" 
                                        Height ="16px" ImageUrl="~/App_Themes/ThemeEn/images/logout16.png" 
                                        meta:resourcekey="lnkLogoutResource1" />
                                 
                                    <asp:LinkButton ID="lnkLogout2" runat="server" OnClick="lnkLogout_Click" 
                                        Height ="16px" meta:resourcekey="lnkLogout2Resource1"></asp:LinkButton>
                                
            <table border="0" cellspacing="0" cellpadding="0">
               <tr>
                  <td width="16%"></td>
                  <td id="MenuHeader" runat="server" height="25px" class="tdMenuHeader"></td>
               </tr>
            </table>
         