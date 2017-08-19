<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="VacationType.aspx.cs" Inherits="VacationType" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>       
            <div id="pageDiv" runat="server">
                <asp:Panel ID="pnlSearch" runat="server" class="SearchPanel">
                    <table>
                        <tr>
                            <td valign="middle">
                                &nbsp;
                                <asp:Label ID="lblSearch" runat="server" Text="Search By :"></asp:Label>
                                
                                <asp:DropDownList ID="ddlSearch"  runat="server"  Width="261px" onselectedindexchanged="ddlSearch_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Value="[none]"    Text="[none]"   Selected="True" ></asp:ListItem>
                                    <asp:ListItem Value="VtpID"     Text="Vacation ID"></asp:ListItem>
                                    <asp:ListItem Value="VtpNameAr" Text="Vacation Name (Ar)"></asp:ListItem>
                                    <asp:ListItem Value="VtpNameEn" Text="Vacation Name (En)"></asp:ListItem>
                                </asp:DropDownList>
                               
                                <asp:TextBox ID="txtSearch" runat="server" Width="500px" Enabled="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rvSearch" runat="server" 
                                    ControlToValidate="txtSearch" EnableClientScript="False" ValidationGroup="vgSearch"
                                    Text="&lt;img src='Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;">
                                </asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender  ID="eFilteredSearch"  runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtSearch" />
                                <cc1:TextBoxWatermarkExtender ID="eWatermarkSearch" runat="server" Enabled="True" TargetControlID="txtSearch" WatermarkText="can't type" WatermarkCssClass="watermarked" />
                                <%--&nbsp;--%>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="SearchButton" onclick="btnSearch_Click" ValidationGroup="vgSearch" Enabled="False" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <div dir="ltr">
                    <table align="left" dir="ltr">
                        <tr>
                            <td>   
                                <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False"  CssClass="vGrid"
                                        DataKeyNames="VtpID" Width="100%"
                                        GridLines="Horizontal" HorizontalAlign="Center" CellPadding="4"
                                        AllowPaging="True"  
                                        ondatabound="grdData_DataBound" onselectedindexchanged="grdData_SelectedIndexChanged" 
                                        onrowdatabound="grdData_RowDataBound" 
                                        onsorting="grdData_Sorting" OnRowCreated="grdData_RowCreated" 
                                        onpageindexchanging="grdData_PageIndexChanging" ShowFooter="True" 
                                    EnableModelValidation="True">
                                    <Columns>
                                        <asp:BoundField DataField="VtpNameAr" HeaderText="Vacation Name (Ar)" SortExpression="VtpNameAr">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle   HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                         
                                        <asp:BoundField DataField="VtpNameEn" HeaderText="Vacation Name (En)" SortExpression="VtpNameEn">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="VtpID" HeaderText="Vacation ID" ReadOnly="True" SortExpression="VtpID">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                                        </asp:BoundField>
                                       
                                        <asp:BoundField DataField="VtpDescription" HeaderText="Description" SortExpression="VtpDescription" Visible="false">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:CommandField ButtonType="Button" SelectText="select" ShowSelectButton="True" />

                                    </Columns>
                                    <HeaderStyle CssClass="header"  />
                                    <FooterStyle CssClass="footer" />
                                    <PagerStyle CssClass="pgr" />
                                    <SelectedRowStyle    CssClass="selected"/>
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                            </td>
                        </tr>

                        <tr>
                            <td> 
                                <asp:Panel ID="pnlTitel" runat="server" CssClass="collapsePanelTitelHeader">
                                    <asp:HyperLink ID="hlkTitel" runat="server" Text="Vacation Information" Width="202px" CssClass="collapsePanelTitelLink"></asp:HyperLink> 
                                    <asp:Label ID="lblTitel" runat="server" Text="Label" Width="873px" CssClass="collapsePanelTitelLabel" /> 
                                    <asp:Image ID="imgTitel" runat="server" CssClass="collapsePanelImage"/>
                                </asp:Panel>
                            </td>
                        </tr>

                        <tr>
                            <td class="collapsePanelDataBorder">    
                                <cc1:CollapsiblePanelExtender ID="epnlData" runat="server" Enabled="True" 
                                    TargetControlID="pnlData" 
                                    CollapsedSize="0"  Collapsed="true"
                                    ExpandControlID="pnlTitel"   CollapseControlID="pnlTitel"  AutoCollapse="false"  AutoExpand="false"                      
                                    CollapsedText="(Show Details...)"  ExpandedText="(Hide Details)" ExpandDirection="Vertical"
                                    TextLabelID="lblTitel"  ImageControlID="imgTitel"  ExpandedImage="~/images/collapse.jpg"  CollapsedImage="~/images/expand.jpg">
                                </cc1:CollapsiblePanelExtender>  

                                <asp:Panel ID="pnlData" runat="server" CssClass="collapsePanelData"> 
                                    <table width="100%">      
                                        <tr class="td2Allalign">
                                            <td  colspan="4" class="collapsePanelButtonBorder">
                                                <asp:Button ID="btnAdd"    runat="server" Text="Add" CssClass="ActionButton" onclick="btnAdd_Click"/>
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnEdit"   runat="server" Text="Edit" CssClass="ActionButton" Enabled="False" onclick="btnEdit_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="ActionButton" Enabled="False" onclick="btnDelete_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnSave"   runat="server" Text="Save" CssClass="ActionButton" Enabled="False" onclick="btnSave_Click"  ValidationGroup="vgSave"/>
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="ActionButton" Enabled="False" onclick="btnCancel_Click" />
                                                &nbsp;&nbsp;
                                                <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                                                <asp:CustomValidator id="cvShowMsg" runat="server" Display="None" 
                                                    ValidationGroup="ShowMsg" OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt">
                                                </asp:CustomValidator>
                                            </td>
                                        </tr>

                                        <tr class="td2Allalign">
                                            <td colspan="4" class="td2Allalign" width="100%">
                                                <asp:ValidationSummary ID="vsSave"    runat="server" CssClass="MsgValidation" EnableClientScript="False" ValidationGroup="vgSave"/>
                                                <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess"    EnableClientScript="False" ValidationGroup="vgShowMsg"/>
                                            </td>
                                        </tr>
                                        
                                        <tr class="td2Allalign">
                                            <td class="td1Allalign">
                                                <span class="RequiredRedStar">*</span>
                                                <asp:Label ID="lblVtpNameAr" runat="server" Text="Vacation Name (Ar) :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtVtpNameAr" runat="server" Enabled="False" Width="168"></asp:TextBox>
                                                <asp:CustomValidator id="cvVtpNameAr" runat="server" ValidationGroup="vgSave" OnServerValidate="VtpName_ServerValidate"
                                                    Text="&lt;img src='Images/icon/Exclamation.gif' title='Vacation Name (Ar) is required!' /&gt;" 
                                                    EnableClientScript="False" ControlToValidate="cvtxt">
                                                </asp:CustomValidator>
                                            </td>
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblVtpNameEn" runat="server" Text="Vacation Name (En) :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtVtpNameEn" runat="server" Enabled="False" Width="168"></asp:TextBox>
                                                <asp:CustomValidator id="cvVtpNameEn" runat="server" ValidationGroup="vgSave" OnServerValidate="VtpName_ServerValidate"
                                                    Text="&lt;img src='Images/icon/Exclamation.gif' title='Vacation Name (En) is required!' /&gt;" 
                                                    EnableClientScript="False" ControlToValidate="cvtxt">
                                                </asp:CustomValidator>
                                            </td>
                                        </tr>

                                        <tr class="td2Allalign">
                                            <td class="td1Allalign">   
                                                <asp:Label ID="lblVtpStatus" runat="server" Text="Vacation Status :" ></asp:Label>
                                            </td>
                                            <td class="td2Allalign" colspan="2">
                                                <asp:CheckBox ID="chkVtpStatus" runat="server" Text= "Active" />
                                            </td>
                                        </tr>

                                        <tr class="td2Allalign">
                                            <td class="td1Allalign">   
                                                <asp:Label ID="lblVtpDesc" runat="server" Text="Description :" ></asp:Label>
                                            </td>
                                            <td class="td2Allalign" colspan="3">
                                                <asp:TextBox ID="txtVtpDesc" runat="server" Width="713px" Enabled="False"></asp:TextBox>
                                                <asp:TextBox ID="txtVtpID" runat="server" Width="10" Enabled="False" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>    
            </div> 
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

