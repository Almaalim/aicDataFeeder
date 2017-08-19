<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="ChangePass.aspx.cs" Inherits="ChangePass" Title="Extractor Web - Change Password Page" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
   
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <table align="left" width="100%" dir="ltr">
                    <tr>
	                    <td valign="top">
	                        <table style="width: 100%; height: 271px;" >
	                            <tr>
	                               <td style="text-align: center">
                                        <center style="height: 187px">
                                            <br />
                                            <table cellspacing="10" dir="ltr" style="border: thick double #800000; height: 21px; width: 470px;" bgcolor="#FFFBD6">
                                                <tr>
                                                    <th>
                                                        <span class="RequiredRedStar">*</span>
                                                        <asp:Label ID="lblCurrentPass" runat="server" Text="Current Password : " CssClass="label" ForeColor="#990000"></asp:Label>
                                                    </th>
                                
                                                    <td align="left">
                                                        <asp:TextBox ID="txtCurrentPass" runat="server" CssClass="txtbox" Width="250px" MaxLength="10" TextMode="Password"></asp:TextBox>
                                                        <asp:CustomValidator id="cvCurrentPass" runat="server" ValidationGroup="vgSave" OnServerValidate="Pass_ServerValidate"
                                                            Text="&lt;img src='Images/icon/Exclamation.gif' title='Current Password is required!' /&gt;" 
                                                            EnableClientScript="False" ControlToValidate="cvtxt">
                                                        </asp:CustomValidator>
                                                    </td>
                                                </tr>
                       
                                                <tr>
                                                    <th>
                                                        <span class="RequiredRedStar">*</span>
                                                        <asp:Label ID="lblNewPass" runat="server" Text="New Password :" CssClass="label" ForeColor="#990000"></asp:Label>
                                                    </th>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtNewPass" runat="server" TextMode ="Password" CssClass="txtbox" Width="250px" MaxLength="10"></asp:TextBox>
                                                        <asp:CustomValidator id="cvNewPass" runat="server" ValidationGroup="vgSave" OnServerValidate="Pass_ServerValidate"
                                                            Text="&lt;img src='Images/icon/Exclamation.gif' title='New Password is required!' /&gt;" 
                                                            EnableClientScript="False" ControlToValidate="cvtxt">
                                                        </asp:CustomValidator>
                                                    </td>
                                                </tr>
                             
                                                <tr>
                                                    <th>
                                                    <span class="RequiredRedStar">*</span>
                                                        <asp:Label ID="lblConfirmPass" runat="server" Text="Confirm Password :" CssClass="label" ForeColor="#990000"></asp:Label>
                                                    </th>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtConfirmPass" runat="server" TextMode ="Password" CssClass="txtbox" Width="250px" MaxLength="10"></asp:TextBox>
                                                        <asp:CustomValidator id="cvConfirmPass" runat="server" ValidationGroup="vgSave" OnServerValidate="Pass_ServerValidate"
                                                            Text="&lt;img src='Images/icon/Exclamation.gif' title='Confirm Password is required!' /&gt;" 
                                                            EnableClientScript="False" ControlToValidate="cvtxt">
                                                        </asp:CustomValidator>
                                                    </td>
                                                </tr>
                          
                                                <tr>
                                                    <td>
                                                       <asp:Button ID="btnSave" runat="server"  Text="Change"  Width="103px" onclick="btnSave_Click" ValidationGroup="vgSave" />   
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                                                        <asp:CustomValidator id="cvShowMsg" runat="server" Display="None" ValidationGroup="ShowMsg" OnServerValidate="ShowMsg_ServerValidate"
                                                            EnableClientScript="False" ControlToValidate="cvtxt">
                                                        </asp:CustomValidator>
                                                    </td>
                                                </tr>
                                            
                                                <tr>
                                                    <td colspan = "2">
                                                        <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False" ValidationGroup="vgShowMsg" />
                                                        <asp:ValidationSummary ID="vsSave"    runat="server" CssClass="MsgValidation" EnableClientScript="False" ValidationGroup="vgSave"/>
                                                    </td>   
                                                </tr> 
                                            </table>
                                            <br />      
                                        </center>
                                    </td>
	                            </tr>
	                        </table>
	                    </td>
	                </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

