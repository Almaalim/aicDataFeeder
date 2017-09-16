﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calendar2.ascx.cs" Inherits="Control_Calendar2" %>

<style type="text/css">
   .CalTextStyle    { vertical-align:middle; border-style:none;   border-width:0;   }
   .CallstItemStyle { border-style: none; }
   .whole_calendar /* whole Calendar Header Div Style without textboxes*/
    {
        position:absolute;               
        overflow:auto;   
        background-color: #CCCCCC;
        border-color: #C4CBD1;
        border-style: Solid;
        border-width: 1px;
        z-index:999;
    }
   .CalenderTable
   {
       width:300px;
   }
</style>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="lblCalendar" runat="server" >
                        <table width="100%">
                            <tr>
                               <td class="calendarTxt" valign="middle">
                                    <asp:TextBox ID="txtDate" runat="server"  CssClass="CalTextStyle" Enabled="false"></asp:TextBox>
                                </td>
                                <td class="td1Allalign" valign="middle">
                                    <asp:TextBox ID="txtType" runat="server"   CssClass="CalTextStyle" Enabled="false" Visible="false"></asp:TextBox>
                                </td>
                                
                                <td class="td1Allalign" valign="middle" >
                                    <asp:ImageButton ID="imgbtnClearCalendar" runat="server"    ImageUrl="~/App_Themes/ThemeEn/images/Control/cross.png" OnClick="imgbtnClearCalendar_Click" />
                                </td>  

                                <td runat="server" id="tdGCal"  class="td1Allalign" valign="middle">
                                    <asp:ImageButton ID="imgbtnShowGCalendar" runat="server"   ImageUrl="~/App_Themes/ThemeEn/images/Control/G_calendar.png" OnClick="imgbtnShowCalendar_Click" />
                                </td>

                                <td runat="server" id="tdHCal" class="td1Allalign" valign="middle">
                                    <asp:ImageButton ID="imgbtnShowHCalendar" runat="server"   ImageUrl="~/App_Themes/ThemeEn/images/Control/H_calendar.png" OnClick="imgbtnShowCalendar_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="rvDate" runat="server" ControlToValidate="txtDate" CssClass="CustomValidator"
                        EnableClientScript="False" Text="&lt;img src='../Images/icon/Exclamation.gif' title='Date is required!' /&gt;">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="pnlCalendar" runat="server" CssClass="whole_calendar">
                        <table>
                            <tr>
                                
                                <td>
                                    <asp:DropDownList ID="ddlMonths" runat="server" AutoPostBack="True" 
                                        Width="90px" CssClass="clsDDL"
                                        OnSelectedIndexChanged="ddlMonths_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlYears" runat="server" AutoPostBack="True" Width="65px" CssClass="CallstItemStyle"
                                        OnSelectedIndexChanged="ddlYears_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Calendar ID="CalDate" runat="server" BackColor="White" Width="164px" DayNameFormat="FirstLetter"
                                        ForeColor="Black" Height="160px" Font-Size="8pt" Font-Names="Verdana" BorderColor="#CCCCCC"
                                        CellPadding="4" OnSelectionChanged="CalDate_SelectionChanged" 
                                        ShowNextPrevMonth="False" ShowTitle="False">
                                        <TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
                                        <SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
                                        <NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
                                        <DayHeaderStyle Font-Size="7pt" Font-Bold="True" BackColor="#CCCCCC"></DayHeaderStyle>
                                        <SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></SelectedDayStyle>
                                        <TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
                                        <WeekendDayStyle BackColor="LightSteelBlue"></WeekendDayStyle>
                                        <OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>
                                    </asp:Calendar>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
