<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Department.aspx.cs" Inherits="Department" Title="Extractor Web - Department Page" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <asp:Panel ID="pnlSearch" runat="server" class="SearchPanel">
                    <div class="row">
                        <div class="col1">
                            <asp:Label ID="lblSearch" runat="server" Text="Search By :"></asp:Label>
                        </div>

                        <div class="col2">
                            <asp:DropDownList ID="ddlSearch" runat="server" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="[none]" Text="[none]" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="DepID" Text="Department ID"></asp:ListItem>
                                <asp:ListItem Value="DepNameAr" Text="Department Name (Ar)"></asp:ListItem>
                                <asp:ListItem Value="DepNameEn" Text="Department Name (En)"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col2">
                            <asp:TextBox ID="txtSearch" runat="server" Enabled="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvSearch" runat="server" CssClass="CustomValidator"
                                ControlToValidate="txtSearch" EnableClientScript="False" ValidationGroup="vgSearch"
                                Text="&lt;img src='Images/icon/Exclamation.gif' title='You must enter a value to search!' /&gt;">
                            </asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="eFilteredSearch" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtSearch" />
                            <cc1:TextBoxWatermarkExtender ID="eWatermarkSearch" runat="server" Enabled="True" TargetControlID="txtSearch" WatermarkText="can't type" WatermarkCssClass="watermarked" />
                        </div>

                        <div class="col3">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnSearch" OnClick="btnSearch_Click" ValidationGroup="vgSearch" Enabled="False" />
                        </div>
                    </div>
                </asp:Panel>

                <div class="row">
                    <div class="col12">
                        <asp:GridView ID="grdMainData" runat="server" AutoGenerateColumns="False" CssClass="vGrid"
                            DataKeyNames="DepID" Width="100%"
                            GridLines="Horizontal" HorizontalAlign="Center" CellPadding="4"
                            AllowPaging="True"
                            OnDataBound="grdMainData_DataBound" OnSelectedIndexChanged="grdMainData_SelectedIndexChanged"
                            OnRowDataBound="grdMainData_RowDataBound"
                            OnSorting="grdMainData_Sorting" OnRowCreated="grdMainData_RowCreated"
                            OnPageIndexChanging="grdMainData_PageIndexChanging" ShowFooter="True"
                            EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="DepNameAr" HeaderText="Department Name (Ar)" SortExpression="DepNameAr">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="DepNameEn" HeaderText="Department Name (En)" SortExpression="DepNameEn">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="DepID" HeaderText="Department ID" ReadOnly="True" SortExpression="DepID">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>

                                <asp:BoundField DataField="DepDescription" HeaderText="Description" SortExpression="DepDescription" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Button" SelectText="select" ShowSelectButton="True" />

                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
                <div class="GreySetion">
                     
                            <asp:Panel ID="pnlMainTitel" runat="server" CssClass="collapsePanelTitelHeader">
                                <asp:HyperLink ID="hlkMainTitel" runat="server" Text="Department Information" Width="202px" CssClass="collapsePanelTitelLink"></asp:HyperLink>
                                <asp:Label ID="lblMainTitel" runat="server" Text="Label" Width="873px" CssClass="collapsePanelTitelLabel" />
                                <asp:Image ID="imgMainTitel" runat="server" CssClass="collapsePanelImage" />
                            </asp:Panel>

                            <div class="collapsePanelDataBorder">
                                <cc1:CollapsiblePanelExtender ID="epnlMainData" runat="server" Enabled="True"
                                    TargetControlID="pnlMainData"
                                    CollapsedSize="0" Collapsed="true"
                                    ExpandControlID="pnlMainTitel" CollapseControlID="pnlMainTitel" AutoCollapse="false" AutoExpand="false"
                                    CollapsedText="(Show Details...)" ExpandedText="(Hide Details)" ExpandDirection="Vertical"
                                    TextLabelID="lblMainTitel" ImageControlID="imgMainTitel" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg">
                                </cc1:CollapsiblePanelExtender>

                                <asp:Panel ID="pnlMainData" runat="server" CssClass="collapsePanelData">
                                    <div class="row">
                                        <div class="col8">
                                            <asp:LinkButton ID="btnMainAdd" runat="server" Text="Add" CssClass="GenButton glyphicon glyphicon-plus-sign" OnClick="btnMainAdd_Click"></asp:LinkButton>

                                            <asp:LinkButton ID="btnMainEdit" runat="server" Text="Edit" CssClass="GenButton  glyphicon glyphicon-edit" Enabled="false"
                                                OnClick="btnMainEdit_Click"></asp:LinkButton>

                                            <asp:LinkButton ID="btnMainDelete" runat="server" Text="Delete" CssClass="GenButton glyphicon glyphicon-remove" Enabled="false"
                                                OnClick="btnMainDelete_Click"></asp:LinkButton>

                                            <asp:LinkButton ID="btnMainSave" runat="server" Text="Save" CssClass="GenButton glyphicon glyphicon-floppy-disk" Enabled="false"
                                                OnClick="btnMainSave_Click" ValidationGroup="vgSave"></asp:LinkButton>

                                            <asp:LinkButton ID="btnMainCancel" runat="server" Text="Cancel" CssClass="GenButton glyphicon glyphicon-remove-circle" Enabled="false"
                                                OnClick="btnMainCancel_Click"></asp:LinkButton>
                                            <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                                            <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None" CssClass="CustomValidator"
                                                ValidationGroup="ShowMsg" OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt">
                                            </asp:CustomValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col12">
                                            <asp:ValidationSummary ID="vsSave" runat="server" CssClass="MsgValidation" EnableClientScript="False" ValidationGroup="vgSave" />
                                            <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False" ValidationGroup="vgShowMsg" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <span class="RequiredField">*</span>
                                            <asp:Label ID="lblDepNameAr" runat="server" Text="Department Name (Ar) :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtDepNameAr" runat="server" Enabled="False"></asp:TextBox>
                                            <asp:CustomValidator ID="cvDepNameAr" runat="server" ValidationGroup="vgSave" OnServerValidate="DepName_ServerValidate"
                                                Text="&lt;img src='Images/icon/Exclamation.gif' title='Department Name (Ar) is required!' /&gt;" CssClass="CustomValidator"
                                                EnableClientScript="False" ControlToValidate="cvtxt">
                                            </asp:CustomValidator>
                                        </div>
                                        <div class="col2">
                                            <asp:Label ID="lblDepNameEn" runat="server" Text="Department Name (En) :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtDepNameEn" runat="server" Enabled="False"></asp:TextBox>
                                            <asp:CustomValidator ID="cvDepNameEn" runat="server" ValidationGroup="vgSave" OnServerValidate="DepName_ServerValidate" CssClass="CustomValidator"
                                                Text="&lt;img src='Images/icon/Exclamation.gif' title='Department Name (En) is required!' /&gt;"
                                                EnableClientScript="False" ControlToValidate="cvtxt">
                                            </asp:CustomValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <asp:Label ID="lblParentDep" runat="server" Text="Parent Department :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:DropDownList ID="ddlParentID" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <asp:Label ID="lblDepStatus" runat="server" Text="Department Status :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:CheckBox ID="chkDepStatus" runat="server" Text="Active" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col2">
                                            <asp:Label ID="lblDepDesc" runat="server" Text="Description :"></asp:Label>
                                        </div>
                                        <div class="col3">
                                            <asp:TextBox ID="txtDepDesc" runat="server" Enabled="False"></asp:TextBox>
                                            <asp:TextBox ID="txtDepID" runat="server" Width="10" Enabled="False" Visible="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>

                                <%--vvvvvvvvvvvv--%>

                                <%--<tr>
                            <td>  
                                <asp:GridView ID="grdSubData" runat="server" AutoGenerateColumns="False" DataKeyNames="SdpID" Width="100%"
                                        GridLines="Horizontal" HorizontalAlign="Center"  CellPadding="4" CssClass="vGrid"
                                        AllowPaging="True" AllowSorting="false"  
                                        ondatabound="grdSubData_DataBound" onselectedindexchanged="grdSubData_SelectedIndexChanged" 
                                        onrowdatabound="grdSubData_RowDataBound" onsorting="grdSubData_Sorting" OnRowCreated="grdSubData_RowCreated" 
                                        onpageindexchanging="grdSubData_PageIndexChanging" ShowFooter="True">
                                    <Columns>
                                        <asp:BoundField DataField="SdpNameAr" HeaderText="SubDepartment Name (Ar)" SortExpression="SdpNameAr">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SdpNameEn" HeaderText="SubDepartment Name (En)" SortExpression="SdpNameEn">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="SdpID" HeaderText="SdpID"  SortExpression="SdpID" ReadOnly="True" />
                                        <asp:BoundField DataField="DepID" HeaderText="Dep ID" SortExpression="DepID" ReadOnly="True" />

                                        <asp:BoundField DataField="SdpDesc" HeaderText="Description" SortExpression="SdpDesc" Visible="false">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>

                                        <asp:CommandField ButtonType="Button" SelectText="User Control" ShowSelectButton="True" />
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
                                <asp:Panel ID="pnlSubTitel" runat="server" CssClass="collapsePanelTitelHeader">
                                    <asp:HyperLink ID="hlkSubTitel" runat="server" Text="SubDepartment Information" Width="220px" CssClass="collapsePanelTitelLink"></asp:HyperLink>
                                    <asp:Label ID="lblSubTitel" runat="server" Text="Label" Width="745px" CssClass="collapsePanelTitelLabel"/>
                                    <asp:Image ID="imgSubTitel" runat="server" CssClass="collapsePanelImage"/>
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnSubSearch" runat="server" Text="Search..." Width="90px" onclick="btnSubSearch_Click" />
                                </asp:Panel>
                            </td>
                        </tr>
       
                        <tr>
                            <td class="collapsePanelDataBorder">   
                                <cc1:CollapsiblePanelExtender ID="epnlSubData" runat="server" Enabled="True" 
                                    TargetControlID="pnlSubData" 
                                    CollapsedSize="0" Collapsed="false"
                                    ExpandControlID="pnlSubTitel" CollapseControlID="pnlSubTitel" AutoCollapse="false" AutoExpand="false"                      
                                    CollapsedText="(Show Details...)" ExpandedText="(Hide Details)" ExpandDirection="Vertical"
                                    TextLabelID="lblSubTitel" ImageControlID="imgSubTitel" ExpandedImage="~/images/collapse.jpg" CollapsedImage="~/images/expand.jpg">
                                </cc1:CollapsiblePanelExtender>
                  
                                <asp:Panel ID="pnlSubData" runat="server" CssClass="collapsePanelData">
                                    <table width="100%">
                                        <tr class="td2Allalign">
                                            <td  colspan="4" class="collapsePanelButtonBorder">
                                                <asp:Button ID="btnSubAdd"    runat="server" Text="Add" CssClass="ActionButton" onclick="btnSubAdd_Click" Enabled="False"/>
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnSubEdit"   runat="server" Text="Edit" CssClass="ActionButton" Enabled="False" onclick="btnSubEdit_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnSubDelete" runat="server" Text="Delete" CssClass="ActionButton" Enabled="False" onclick="btnSubDelete_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnSubSave"   runat="server" Text="Save" CssClass="ActionButton" Enabled="False" onclick="btnSubSave_Click"  ValidationGroup="vgSubSave"/>
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnSubCancel" runat="server" Text="Cancel" CssClass="ActionButton" Enabled="False" onclick="btnSubCancel_Click" />
                                                <asp:CustomValidator id="cvSubShowMsg" runat="server" Display="None" 
                                                    ValidationGroup="vgSubShowMsg" OnServerValidate="ShowMsg_ServerValidate" EnableClientScript="False" ControlToValidate="cvtxt">
                                                </asp:CustomValidator>
                                            </td>
                                        </tr>

                                        <tr class="td2Allalign">
                                            <td colspan="4" class="td2Allalign" width="100%">
                                                <asp:ValidationSummary ID="vsSubSave"    runat="server" CssClass="MsgValidation" EnableClientScript="False" ValidationGroup="vgSubSave"/>
                                                <asp:ValidationSummary ID="vsSubShowMsg" runat="server" CssClass="MsgSuccess"    EnableClientScript="False" ValidationGroup="vgSubShowMsg"/>
                                            </td>
                                        </tr>

                                        <tr class="td2Allalign">
                                            <td class="td1Allalign">
                                                <span class="RequiredField">*</span>
                                                <asp:Label ID="lblSdpNameAr" runat="server" Text="SubDepartment Name (Ar) :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtSdpNameAr" runat="server" Enabled="False" Width="168"></asp:TextBox>
                                                <asp:CustomValidator id="cvSdpNameAr" runat="server" ValidationGroup="vgSubSave" OnServerValidate="SubDepName_ServerValidate"
                                                    Text="&lt;img src='Images/icon/Exclamation.gif' title='SubDepartment Name (Ar) is required!' /&gt;" 
                                                    EnableClientScript="False" ControlToValidate="cvtxt">
                                                </asp:CustomValidator>
                                            </td>
                                            <td class="td1Allalign">
                                                <asp:Label ID="lblSdpNameEn" runat="server" Text="SubDepartment Name (En) :"></asp:Label>
                                            </td>
                                            <td class="td2Allalign">
                                                <asp:TextBox ID="txtSdpNameEn" runat="server" Enabled="False" Width="168"></asp:TextBox>
                                                <asp:CustomValidator id="cvSdpNameEn" runat="server" ValidationGroup="vgSubSave" OnServerValidate="SubDepName_ServerValidate"
                                                    Text="&lt;img src='Images/icon/Exclamation.gif' title='SubDepartment Name (En) is required!' /&gt;" 
                                                    EnableClientScript="False" ControlToValidate="cvtxt">
                                                </asp:CustomValidator>
                                            </td>
                                        </tr>

                                        <tr class="td2Allalign">
                                            <td class="td1Allalign">   
                                                <asp:Label ID="lblSdpDesc" runat="server" Text="Description :" ></asp:Label>
                                            </td>
                                            <td class="td2Allalign" colspan="3">
                                                <asp:TextBox ID="txtSdpDesc"  runat="server" Width="725px" Enabled="False"></asp:TextBox>
                                                <asp:TextBox ID="txtSubDepID" runat="server" Width="2px" Enabled="False" Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="txtSdpID"    runat="server" Width="2px" Enabled="False" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>--%>
                           
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

