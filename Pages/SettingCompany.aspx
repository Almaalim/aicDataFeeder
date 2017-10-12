<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="SettingCompany.aspx.cs" Inherits="SettingCompany" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%--<%@ Register Src="../Control/ConfigurationSideMenu.ascx" TagName="ConfigurationSideMenu" TagPrefix="CSM" %>--%>
<%@ Register Src="../Control/ImageCtl.ascx" TagName="ImageCtl" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <%--<CSM:ConfigurationSideMenu ID="ConfigurationSideMenu1" runat="server" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMain" runat="server" DefaultButton="btnSave">
                <div id="pageDiv" runat="server" class="td2Allalign">
                 <div class="row">
                            <div class="col2">
                                            <span class="requiredStar">*</span>
                                            <asp:Label ID="lblAppCompany" runat="server" Text="Company Name :"
                                                meta:resourcekey="lblAppCompanyResource1"></asp:Label>
                                        </div>
                            <div class="col3">
                                            <asp:TextBox ID="txtAppCompany" runat="server"  
                                                meta:resourcekey="txtAppCompanyResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvtxtAppCompany" runat="server" ControlToValidate="txtAppCompany" CssClass="CustomValidator"
                                                EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Company Name is required!' /&gt;"
                                                ValidationGroup="vgSave" meta:resourcekey="rvtxtAppCompanyResource1"></asp:RequiredFieldValidator>
                                        </div>
                        
                            <div class="col2">
                                            <asp:Label ID="lblAppDisplay" runat="server" Text="Display Name :"
                                                meta:resourcekey="lblAppDisplayResource1"></asp:Label>
                                          </div>
                            <div class="col3">
                                            <asp:TextBox ID="txtAppDisplay" runat="server"  
                                                meta:resourcekey="txtAppDisplayResource1"></asp:TextBox>
                                       </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                            <asp:Label ID="lblAppAddress1" runat="server" Text="Address 1 :"
                                                meta:resourcekey="lblAppAddress1Resource1"></asp:Label>
                                    </div>
                            <div class="col3">
                                            <asp:TextBox ID="txtAppAddress1" runat="server"  
                                                meta:resourcekey="txtAppAddress1Resource1"></asp:TextBox>
                                              </div>
                        
                            <div class="col2">
                                            <asp:Label ID="lblAppAddress2" runat="server" Text="Address 1 :"
                                                meta:resourcekey="lblAppAddress2Resource1"></asp:Label>
                                       </div>
                            <div class="col3">
                                            <asp:TextBox ID="txtAppAddress2" runat="server"  
                                                meta:resourcekey="txtAppAddress2Resource1"></asp:TextBox>
                                           </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                            <asp:Label ID="lblAppCity" runat="server" Text="City :"
                                                meta:resourcekey="lblAppCityResource1"></asp:Label>
                                        </div>
                            <div class="col3">
                                            <asp:TextBox ID="txtAppCity" runat="server"  
                                                meta:resourcekey="txtAppCityResource1"></asp:TextBox>
                                        </div>
                        
                            <div class="col2">
                                            <asp:Label ID="lblAppCountry" runat="server" Text="Country :"
                                                meta:resourcekey="lblAppCountryResource1"></asp:Label>
                                         </div>
                            <div class="col3">
                                            <asp:TextBox ID="txtAppCountry" runat="server"  
                                                meta:resourcekey="txtAppCountryResource1"></asp:TextBox>
                                                         </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                            <asp:Label ID="lblAppPOBox" runat="server" Text="P.O Box :"
                                                meta:resourcekey="lblAppPOBoxResource1"></asp:Label>
                                   </div>
                            <div class="col3">
                                            <asp:TextBox ID="txtAppPOBox" runat="server"  
                                                meta:resourcekey="txtAppPOBoxResource1"></asp:TextBox>
                                       </div>
                        
                            <div class="col2">
                                            <asp:Label ID="lblAppTelNo1" runat="server" Text="Phone No 1 :"
                                                meta:resourcekey="lblAppTelNo1Resource1"></asp:Label>
                                         </div>
                            <div class="col3">
                                            <asp:TextBox ID="txtAppTelNo1" runat="server"  
                                                meta:resourcekey="txtAppTelNo1Resource1"></asp:TextBox>
                                                  </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                            <asp:Label ID="lblAppTelNo2" runat="server" Text="Phone No 2 :"
                                                meta:resourcekey="lblAppTelNo2Resource1"></asp:Label>
                                       </div>
                            <div class="col3">
                                            <asp:TextBox ID="txtAppTelNo2" runat="server"  
                                                meta:resourcekey="txtAppTelNo2Resource1"></asp:TextBox>
                                        </div>
                        
                            <div class="col2">
                                            <asp:Label ID="lblAppFax" runat="server" Text="Fax No :"
                                                meta:resourcekey="lblAppFaxResource1"></asp:Label>
                                        </div>
                            <div class="col3">
                                            <asp:TextBox ID="txtAppFax" runat="server"  
                                                meta:resourcekey="txtAppFaxResource1"></asp:TextBox>
                                         </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                            <asp:Label ID="lblAppUrl" runat="server" Text="URL :"
                                                meta:resourcekey="lblAppUrlResource1"></asp:Label>
                                      </div>
                            <div class="col3">
                                            <asp:TextBox ID="txtAppUrl" runat="server"  
                                                meta:resourcekey="txtAppUrlResource1"></asp:TextBox>
                                      </div>
                        
                            <div class="col2">
                                            <asp:Label ID="lblAppEmail" runat="server" Text="Email :"
                                                meta:resourcekey="lblAppEmailResource1"></asp:Label>
                                          </div>
                            <div class="col3">
                                            <asp:TextBox ID="txtAppEmail" runat="server"  
                                                meta:resourcekey="txtAppEmailResource1"></asp:TextBox>
                                       </div>
                        </div>
                        <div class="row">
                            <div class="col2">
                                            <span class="requiredStar">*</span>
                                            <asp:Label ID="lblAppCalendar" runat="server" Text="Calendar :"
                                                meta:resourcekey="lblAppCalendarResource1"></asp:Label>
                                        </div>
                            <div class="col3">
                                            <asp:DropDownList ID="ddlAppCalendar" runat="server" Width="173px"
                                                meta:resourcekey="ddlAppCalendarResource1">
                                                <asp:ListItem Text="-Select Calendar-" Value="0"
                                                    meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                <asp:ListItem Text="Gregorian" Value="G" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                                <asp:ListItem Text="Hijri" Value="H" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rvddlAppCalendar" runat="server" ControlToValidate="ddlAppCalendar" CssClass="CustomValidator"
                                                EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Calendar is required!' /&gt;"
                                                ValidationGroup="vgSave" InitialValue="0"
                                                meta:resourcekey="rvddlAppCalendarResource1"></asp:RequiredFieldValidator>
                                       </div>
                        </div>
                        <div class="row">
                          <div class="col12">
                           
                                            <uc3:ImageCtl ID="imgLogo" runat="server" txtID="txtAppCompany" Type="Logo"
                                                CaptureEnable="false" ValidationGroup="vgSave"
                                                TitelEn="Logo" TitelAr="الشعار"
                                                EmptyIDMsgEn="Please enter the Company Name to select the image"
                                                EmptyIDMsgAr="من فضلك ادخل اسم للشركة لاختيار صورة" />
                                       </div>
                        </div>
                        <div class="row">
                          <div class="col12">
                                    <asp:LinkButton ID="btnSave" runat="server" CssClass="GenButton glyphicon glyphicon-floppy-disk" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgSave" Width="80px"
                                        meta:resourcekey="btnSaveResource1"></asp:LinkButton>
                                    <asp:LinkButton ID="btnCancel" runat="server" CssClass="GenButton glyphicon glyphicon-remove-circle" Text="Cancel" OnClick="btnCancel_Click" Width="80px"
                                        meta:resourcekey="btnCancelResource1"></asp:LinkButton>
                                    <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False"
                                        Width="10px" meta:resourcekey="cvtxtResource1"></asp:TextBox>
                                    <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" CssClass="CustomValidator"
                                        ValidationGroup="ShowMsg" OnServerValidate="ShowMsg_ServerValidate"
                                        EnableClientScript="False" ControlToValidate="cvtxt"
                                        meta:resourcekey="cvShowMsgResource1"></asp:CustomValidator>
                               </div>
                        </div>
                        <div class="row">
                          <div class="col12">
                                <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation"
                                    EnableClientScript="False" ValidationGroup="vgSave"
                                    meta:resourcekey="vsSaveResource1" />
                                <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess"
                                    EnableClientScript="False" ValidationGroup="vgShowMsg"
                                    meta:resourcekey="vsShowMsgResource1" />
                            </div>
                            </div>
                    
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

