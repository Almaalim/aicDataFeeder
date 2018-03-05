<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="SettingScheduleImport.aspx.cs" Inherits="Pages_SettingScheduleImport" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Src="~/Control/ScheduleTimes.ascx" TagName="ScheduleTimes" TagPrefix="ucTimes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="upnlMain" runat="server">
        <ContentTemplate>
            <div id="pageDiv" runat="server">
                <div class="row">
                    <div class="col12">
                        <asp:ValidationSummary ID="vsShowMsg" runat="server" CssClass="MsgSuccess" EnableClientScript="False" ValidationGroup="vgShowMsg" meta:resourcekey="vsShowMsgResource1" />
                    </div>
                </div>
                <div class="row">
                    <div class="col8">
                        <asp:LinkButton ID="btnModify" runat="server" CssClass="GenButton  glyphicon glyphicon-edit" OnClick="btnModify_Click"
                            Text="Edit" meta:resourcekey="btnModifyResource1"></asp:LinkButton>

                        <asp:LinkButton ID="btnSave" runat="server" CssClass="GenButton glyphicon glyphicon-floppy-disk"
                            OnClick="btnSave_Click" Text="Save"
                            ValidationGroup="vgSave" meta:resourcekey="btnSaveResource1"></asp:LinkButton>

                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="GenButton glyphicon glyphicon-remove-circle" OnClick="btnCancel_Click"
                            Text="Cancel" meta:resourcekey="btnCancelResource1"></asp:LinkButton>
                    </div>
                    <div class="col4">
                        <asp:TextBox ID="txtValid" runat="server" Text="02120" Visible="False" Width="10px" meta:resourcekey="txtValidResource1"></asp:TextBox>

                        <asp:CustomValidator ID="cvShowMsg" runat="server" Display="None"
                            ValidationGroup="vgShowMsg" OnServerValidate="ShowMsg_ServerValidate"
                            EnableClientScript="False" ControlToValidate="txtValid" meta:resourcekey="cvShowMsgResource1"></asp:CustomValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col12">
                        <asp:CheckBox ID="chkIpsSaveTransInFile" runat="server" Text="Save imported data as a fle in a CSV format" meta:resourcekey="chkIpsSaveTransInFileResource1" />
                    </div>
                </div>
                <div class="row">
                    <div class="col12">
                        <asp:CheckBox ID="chkIpsEncryptTransInFile" runat="server" Text="Encrypt imported data in a CSV file" meta:resourcekey="chkIpsEncryptTransInFileResource1" />
                    </div>
                </div>
                <div class="row">
                    <div class="col12">
                        <asp:CheckBox ID="chkIpsRunProcess" runat="server" Text="Run Process After Import" AutoPostBack="True" OnCheckedChanged="chkIpsRunProcess_CheckedChanged" meta:resourcekey="chkIpsRunProcessResource1" />
                    </div>
                </div>

                <div class="row">
                    <div class="col6">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="Label1" runat="server" Text="Import Schedule Times :" meta:resourcekey="Label1Resource1"></asp:Label>
                    </div>

                    <div id="divProcess1" runat="server" visible="False" class="col6">
                        <span class="RequiredField">*</span>
                        <asp:Label ID="Label2" runat="server" Text="Process Schedule Times :" meta:resourcekey="Label2Resource1"></asp:Label>
                    </div>

                </div>

                <div class="row">
                    <div class="col6">
                        <ucTimes:ScheduleTimes runat="server" ID="ucImportTimes" ValidationGroupName="vgShowMsg" />
                    </div>
                    <div id="divProcess2" runat="server" visible="False" class="col6">
                        <ucTimes:ScheduleTimes runat="server" ID="ucProcessTimes" ValidationGroupName="vgSave" Visible="False" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

