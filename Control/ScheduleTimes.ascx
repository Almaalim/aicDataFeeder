<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ScheduleTimes.ascx.cs" Inherits="Control_ScheduleTimes" %>

<%@ Register Assembly="TimePickerServerControl" Namespace="TimePickerServerControl" TagPrefix="Almaalim" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div runat="server" id="MainTable">
            <div class="row">
                <div class="col2">
                    <asp:Label ID="lblTimes" runat="server" Text="Time :" ></asp:Label>
                </div>
                <div class="col4">
                    <Almaalim:TimePicker ID="tpTimes" runat="server" FormatTime="HHmm" CssClass="TimeCss"
                        TimePickerValidationGroup="" TimePickerValidationText="" />
                </div>
            </div>
            
            <div class="row">
                <div class="col2">
                </div>
                <div class="col4">

                    <asp:ImageButton ID="btnAdd" runat="server"
                        ImageUrl="~/images/Wizard_Image/add.png" OnClick="btnAdd_Click" ToolTip="Add" />
                    &nbsp;
                                                              
                    <asp:ImageButton ID="btnRemove" runat="server"
                        ImageUrl="~/images/Wizard_Image/delete.png" OnClick="btnRemove_Click" ToolTip="Remove Time" />
                    
                    <asp:TextBox ID="txtCustomValid" runat="server" Text="02120" Visible="False"
                        Width="10px" ></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col2">
                </div>
                <div class="col4">
                    <asp:ListBox ID="lstTimes" runat="server" Enabled="False" Height="200px" ></asp:ListBox>  
                    
                    <asp:CustomValidator ID="cvTimes" runat="server" CssClass="CustomValidator"
                        ControlToValidate="txtCustomValid" EnableClientScript="False" OnServerValidate="Times_ServerValidate"
                        Text="&lt;img src='images/Exclamation.gif' title='Select Times' /&gt;" ></asp:CustomValidator>              
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
