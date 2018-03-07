<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="SettingScheduleImport.aspx.cs" Inherits="Pages_SettingScheduleImport" %>

<%@ Register Src="~/Control/ScheduleTimes.ascx" TagName="ScheduleTimes" TagPrefix="ucTimes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <div class="row">
                <div class="col12">
                    <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False" ValidationGroup="vgShowMsg" />
                </div>
            </div>        
            <div class="row">
                <div class="col8">
                    <asp:LinkButton ID="btnModify" runat="server" CssClass="GenButton  glyphicon glyphicon-edit" OnClick="btnModify_Click"
                        Text="Edit" ></asp:LinkButton>
                    
                    <asp:LinkButton ID="btnSave" runat="server" CssClass="GenButton glyphicon glyphicon-floppy-disk"   
                        OnClick="btnSave_Click"  Text="Save" 
                        ValidationGroup="vgSave" ></asp:LinkButton>
                               
                    <asp:LinkButton ID="btnCancel" runat="server" CssClass="GenButton glyphicon glyphicon-remove-circle" OnClick="btnCancel_Click"
                            Text="Cancel" ></asp:LinkButton>
                </div>
                <div class="col4">
                    <asp:TextBox ID="txtValid" runat="server" Text="02120" Visible="False" Width="10px" ></asp:TextBox>
                                
                    <asp:CustomValidator id="cvShowMsg" runat="server" Display="None" 
                        ValidationGroup="vgShowMsg" OnServerValidate="ShowMsg_ServerValidate"
                        EnableClientScript="False" ControlToValidate="txtValid" ></asp:CustomValidator>
                </div>
            </div>
            <div class="row">
                <div class="col12">
                    <asp:CheckBox ID="chkIpsSaveTransInFile" runat="server" Text="Save imported data as a fle in a CSV format" />
                </div>
            </div>
            <div class="row">
                <div class="col12">
                    <asp:CheckBox ID="chkIpsEncryptTransInFile" runat="server" Text="Encrypt imported data in a CSV file" />
                </div>
            </div>
            <div class="row">
                <div class="col12">
                    <asp:CheckBox ID="chkIpsRunProcess" runat="server" Text="Run Process After Import" AutoPostBack="True" OnCheckedChanged="chkIpsRunProcess_CheckedChanged"/>
                </div>
            </div> 

             <div class="row">
                <div class="col6">
                    <span class="RequiredField">*</span>
                    <asp:Label ID="Label1" runat="server" Text="Import Schedule Times :" ></asp:Label>
                </div>
               
                <div id="divProcess1" runat="server" visible="False" class="col6">
                    <span class="RequiredField">*</span>
                    <asp:Label ID="Label2" runat="server" Text="Process Schedule Times :" ></asp:Label>
                </div>
                 
            </div>

            <div class="row">
                <div class="col6">
                    <ucTimes:ScheduleTimes runat="server" ID="ucImportTimes" ValidationGroupName="vgShowMsg"/>
                </div>
                <div id="divProcess2" runat="server" visible="False" class="col6">
                    <ucTimes:ScheduleTimes runat="server" ID="ucProcessTimes" ValidationGroupName="vgSave" Visible="false"/>
                </div>        
            </div>

                <%--<table>
                    <tr>
                        <td class="td1Allalign">
                            <asp:RadioButton ID="rdbImpOnce" Text="Import once :" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td2Allalign">
                            <asp:RadioButton ID="rdbImpEvery" Text="Import every :" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtEveryMnt" runat="server"></asp:TextBox>
                        </td>
                        <td class="td2Allalign">
                            <table>
                                <tr>
                                    <td class="td2Allalign" colspan="2">
                                        <asp:CheckBox ID="chkZeroEmp" Text="Leading zeros as a prefix in front of employee ID" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td1Allalign">
                                        <asp:Label ID="lblLenZero" runat="server" Text="Total Lingth:"></asp:Label>
                                    </td>
                                    <td class="td2Allalign">
                                        <asp:TextBox ID="txtLenthZero" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="td2Allalign">
                            <asp:RadioButton ID="rdbImpAt" Text="Import at :" runat="server" />
                        </td>
                        <td>
                            
                        </td>
                        <td class="td2Allalign">
                            <asp:CheckBox ID="CheckBox1" Text="Join Date & Time in the Time field" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" width="100%">
                            <asp:ValidationSummary ID="vsSave" runat="server" CssClass="errorValidation" EnableClientScript="False" ValidationGroup="VgSave"/>
                            
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="td1Allalign">
                            <asp:TextBox ID="cvtxt" runat="server" Text="02120" Visible="False" Width="10px"></asp:TextBox>
                            
                        </td>
                    </tr>
                </table>--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

