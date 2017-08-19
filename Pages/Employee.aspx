<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="Employee" Title="Employee Page" EnableEventValidation="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
                                    <asp:ListItem Value="EmpID"     Text="Employee ID"></asp:ListItem>
                                    <asp:ListItem Value="EmpNameAr" Text="Employee Name (Ar)"></asp:ListItem>
                                    <asp:ListItem Value="EmpNameEn" Text="Employee Name (En)"></asp:ListItem>
                                    <asp:ListItem Value="DepID"     Text="Department ID" Enabled="false"></asp:ListItem>
                                    <asp:ListItem Value="DepNameAr" Text="Department Name (Ar)"></asp:ListItem>
                                    <asp:ListItem Value="DepNameEn" Text="Department Name (En)"></asp:ListItem>
                                    <asp:ListItem Value="SdpID"     Text="SubDepartment ID" Enabled="false"></asp:ListItem>
                                    <asp:ListItem Value="SdpNameAr" Text="SubDepartment Name (Ar)"></asp:ListItem>
                                    <asp:ListItem Value="SdpNameEn" Text="SubDepartment Name (En)"></asp:ListItem>
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
                    <table align="left" width="100%" dir="ltr">
                        <tr>  
                            <td>   
                                <asp:GridView ID="grdData" runat="server" AutoGenerateColumns="False" 
                                        CellPadding="4" DataKeyNames="EmpID" CssClass="vGrid"
                                        GridLines="Horizontal" Width="100%" 
                                        AllowPaging="True" HorizontalAlign="Center" 
                                        ondatabound="grdData_DataBound" onselectedindexchanged="grdData_SelectedIndexChanged" 
                                        onrowdatabound="grdData_RowDataBound" onsorting="grdData_Sorting" OnRowCreated="grdData_RowCreated" 
                                        onpageindexchanging="grdData_PageIndexChanging" ShowFooter="True" 
                                    EnableModelValidation="True">
                                    <Columns>
                                        <asp:BoundField DataField="EmpID" HeaderText="ID" SortExpression="EmpID">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle   HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EmpNameAr" HeaderText="Name (Ar)" SortExpression="EmpNameAr">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle   HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                         
                                        <asp:BoundField DataField="EmpNameEn" HeaderText="Name (En)" SortExpression="EmpNameEn" Visible="false">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        
                                        <asp:BoundField DataField="DepID" HeaderText="Department ID" ReadOnly="True" SortExpression="DepID" Visible="false" />
                                        <asp:BoundField DataField="DepNameAr" HeaderText="Department Name (Ar)" SortExpression="DepNameAr">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle   HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DepNameEn" HeaderText="Department Name (En)" SortExpression="DepNameEn" Visible="false">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="SdpID" HeaderText="SubDepartment ID" ReadOnly="True" SortExpression="SdpID" Visible="false" />
                                        <asp:BoundField DataField="SdpNameAr" HeaderText="SubDepartment Name (Ar)" SortExpression="SdpNameAr">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle   HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SdpNameEn" HeaderText="SubDepartment Name (En)" SortExpression="SdpNameEn" Visible="false">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="EmpStatus" HeaderText="" SortExpression="EmpStatus" Visible="false" />
                                        <asp:TemplateField HeaderText="Status" SortExpression="EmpStatusText">            
                                            <ItemTemplate>                                                                              
                                                <%# getStatus(Eval("EmpStatus"))%>                                                                                                          
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />                 
                                        </asp:TemplateField>

                                        <asp:CommandField ButtonType="Button" SelectText="select" ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle         CssClass="header"  />
                                    <FooterStyle         CssClass="footer" />
                                    <PagerStyle          CssClass="pgr" />
                                    <SelectedRowStyle    CssClass="selected"/>
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                            </td>
                        </tr> 
                  
                        <tr>
                            <td> 
                                <asp:Panel ID="pnlTitel" runat="server" CssClass="collapsePanelTitelHeader">
                                    <asp:HyperLink ID="hlkTitel" runat="server" Text="Employee Information" Width="202px" CssClass="collapsePanelTitelLink"></asp:HyperLink>
                                    <asp:Label ID="lblTitel" runat="server" Text="Label" Width="873px" CssClass="collapsePanelTitelLabel"></asp:Label>
                                    <asp:Image ID="imgTitel" runat="server" CssClass="collapsePanelImage"/>
                                </asp:Panel>
                            </td>
                        </tr>
                  
                        <tr>
                            <td class="collapsePanelDataBorder">   
                                <cc1:CollapsiblePanelExtender ID="epnlData" runat="server" Enabled="True" 
                                    TargetControlID="pnlData" 
                                    CollapsedSize="0"  Collapsed="False"
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
                                        
                                        <tr>
                                            <td class="td1Allalign">
                                                <span class="RequiredRedStar">*</span>
                                                <asp:Label ID="lblEmpID" runat="server" Text="Employee ID :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtEmpID" runat="server" Enabled="False" Width="168"></asp:TextBox>
                                                <asp:CustomValidator id="cvEmpID" runat="server" ValidationGroup="vgSave" OnServerValidate="EmpID_ServerValidate"
                                                    Text="&lt;img src='Images/icon/Exclamation.gif' title='Employee ID is required!' /&gt;" 
                                                    EnableClientScript="False" ControlToValidate="cvtxt">
                                                </asp:CustomValidator>
                                            </td>
                                            <td class="td1Allalign">
                                                <span class="RequiredRedStar">*</span>
                                                <asp:Label ID="lblEmpStatus" runat="server" Text="Status :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:DropDownList ID="ddlEmpStatus" runat="server" Width="173px">
                                                    <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Active" Selected="True"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr class="td2Allalign">
                                            <td class="td1Allalign">
                                                <span class="RequiredRedStar">*</span>
                                                <asp:Label ID="lblEmpNameAr" runat="server" Text="Employee Name (Ar) :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtEmpNameAr" runat="server" Enabled="False" Width="168"></asp:TextBox>
                                                <asp:CustomValidator id="cvEmpNameAr" runat="server" ValidationGroup="vgSave" OnServerValidate="EmpName_ServerValidate"
                                                    Text="&lt;img src='Images/icon/Exclamation.gif' title='Employee Name (Ar) is required!' /&gt;" 
                                                    EnableClientScript="False" ControlToValidate="cvtxt">
                                                </asp:CustomValidator>
                                            </td>
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblEmpNameEn" runat="server" Text="Employee Name (En) :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtEmpNameEn" runat="server" Enabled="False" Width="168"></asp:TextBox>
                                                <asp:CustomValidator id="cvEmpNameEn" runat="server" ValidationGroup="vgSave" OnServerValidate="EmpName_ServerValidate"
                                                    Text="&lt;img src='Images/icon/Exclamation.gif' title='Employee Name (En) is required!' /&gt;" 
                                                    EnableClientScript="False" ControlToValidate="cvtxt">
                                                </asp:CustomValidator>
                                            </td>
                                        </tr>

                                        <tr class="td2Allalign">
                                            <td class="td1Allalign">
                                                <span class="RequiredRedStar">*</span>
                                                <asp:Label ID="lblEmpPositionAr" runat="server" Text="Position Name (Ar) :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtEmpPositionAr" runat="server" Enabled="False" Width="168"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rvEmpPositionAr" runat="server" ValidationGroup="vgSave" ControlToValidate="txtEmpPositionAr"
                                                    EnableClientScript="False" Text="&lt;img src='Images/icon/Exclamation.gif' title='Position Name (Ar) is required' /&gt;">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblEmpPositionEn" runat="server" Text="Position Name (En) :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtEmpPositionEn" runat="server" Enabled="False" Width="168"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rvEmpPositionEn" runat="server" ValidationGroup="vgSave" ControlToValidate="txtEmpPositionEn"
                                                    EnableClientScript="False" Text="&lt;img src='Images/icon/Exclamation.gif' title='Position Name (En) is required' /&gt;"
                                                    Enabled="false">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="td1Allalign">
                                                <span class="RequiredRedStar">*</span>
                                                <asp:Label ID="lblDepID" runat="server" Text="Department :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:DropDownList ID="ddlDepID" runat="server" Width="173px"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rvDepID" runat="server" ValidationGroup="vgSave" ControlToValidate="ddlDepID"
                                                    EnableClientScript="False" Text="&lt;img src='Images/icon/Exclamation.gif' title='Department is required' /&gt;">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblUsrEmilID" runat="server" Text="E-Mail :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign" >
                                                <asp:TextBox ID="txtEmpEmail" runat="server" Width="168" Enabled="False"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rvEmailIDCorrect" runat="server" ErrorMessage="Please enter email in correct format"
                                                Text="&lt;img src='../Images/icon/Exclamation.gif' title='Please enter email in correct format!' /&gt;"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmpEmail"
                                                EnableClientScript="False" ValidationGroup="vgSave" meta:resourcekey="rvEmailIDCorrectResource1"></asp:RegularExpressionValidator>
                                            </td>
                                            <%--<td class="td1Allalign">
                                                <span class="RequiredRedStar">*</span>
                                                <asp:Label ID="lblSdpID" runat="server" Text="SubDepartment :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:DropDownList ID="ddlSdpID" runat="server" Width="173px"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rvSdpID" runat="server" ValidationGroup="vgSave" ControlToValidate="ddlSdpID"
                                                    EnableClientScript="False" Text="&lt;img src='Images/icon/Exclamation.gif' title='SubDepartment is required' /&gt;">
                                                </asp:RequiredFieldValidator>
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblEmpMobile" runat="server" Text="Mobile :" ></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtEmpMobile" runat="server" Width="168px" Enabled="False" onkeypress="return NumberOnly(event);"></asp:TextBox>
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

