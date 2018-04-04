using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Web;
using System.Data.SqlClient;
using Stimulsoft.Report.Dictionary;

public partial class Pages_ReportMain : BasePage
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ReportPro ProClass = new ReportPro();
    ReportSql SqlClass = new ReportSql();

    DBFun DBCs = new DBFun();
    DateFun DTCs = new DateFun();

    DataTable dt;
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        //---Common Code ----------------------------------------------------------------- //
        string Type = (Request.QueryString["ID"] != null) ? Request.QueryString["ID"] : "";
        FormSession.FillSession("Reports", pageDiv);
        //---Common Code ----------------------------------------------------------------- //

        if (ViewState["pnlshow"] != null)
        {
            if (!string.IsNullOrEmpty(hdnShow.Value))
            {
                //string ss = hdnShow.Value;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "hidePopup('','','" + pnlDateFromTo.ClientID + "');", true);
                //hdnShow.Value = ss;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "showPopup('" + DivPopup.ClientID + "','','" + pnlDateFromTo.ClientID + "','" + hdnShow.Value + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key33", "hidePopup('','','" + pnlDateFromTo.ClientID + "');", true);
            }
        }


        if (!IsPostBack)
        {
            if (!FormSession.PermUsr.Contains("Reports")) { Response.Redirect(@"~/Login.aspx"); }
            MainMasterPage.ShowTitel(General.Msg("Reports", "التقارير"));

            ScriptManager.RegisterStartupScript(this, this.GetType(), "key55", "hidePopup('" + DivPopup.ClientID + "','','" + pnlDateFromTo.ClientID + "');", true);
            lblSelectedreport.Text = General.Msg("Please select Report", "من فضلك اختر التقرير");

            FillReports("1");
            btnEventsEnable(false);
            dltReport.RepeatColumns = 4;

            //ScriptManager.RegisterStartupScript(CalendarUpdatePanel, typeof(string), "ShowPopup" + this.DivCal.ClientID, "if (document.getElementById('" + this.DivCal.ClientID + "') != 'undefined' && document.getElementById('" + this.DivCal.ClientID + "') != null) { document.getElementById('" + this.DivCal.ClientID + "').style.display = 'none'; }", true);

            //ShowPanels();
            calStartDate.SetEnabled(true);
            calEndDate.SetEnabled(true);

            //calDate.SetEnabled(true);
            //calStartDate.SetEnabled(true);
            //calEndDate.SetEnabled(true);

            /*FillReportsGroups();*/
            //FillIssue();
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*#############################################################################################################################*/
    /*#############################################################################################################################*/
    #region Reports Groups Events

    //private void FillReportsGroups()
    //{
    //    DataTable GDT = DBCs.FetchData(" SELECT * FROM ReportGroup ORDER BY RgpID ");
    //    if (!DBCs.IsNullOrEmpty(GDT))
    //    {
    //        foreach (DataRow DR in GDT.Rows)
    //        {
    //            if (FormSession.getPerm(new string[] { "Rep" + DR["RgpID"] }))
    //            {
    //                ListItem _liReport = new ListItem(DR["RgpName" + FormSession.Language].ToString(), DR["RgpID"].ToString());
    //                lstReportsGroups.Items.Add(_liReport);
    //            }
    //        }
    //    }
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void lstReportsGroups_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Clear();

    //    lstReport.Items.Clear();
    //    lblSelectedreport.Text = General.Msg("Please select Report", "من فضلك اختر التقرير");

    //    StiWebViewerFx1.Report = null;
    //    btnEditReport.Enabled = btnSetAsDefault.Enabled = btnViewreport.Enabled = false;
    //    pnlDateFromTo.Visible = pnlEmployee.Visible = false;
    //    pnlDepartment.Visible = rvDepartment.Enabled = false;
    //    pnlLocation.Visible = rvLocation.Enabled = false;
    //    pnlMachine.Visible = rvMachine.Enabled = false;

    //    UpdatePanel1.Update();

    //    if (lstReportsGroups.SelectedIndex > -1)
    //    {
    //        string RgpID = lstReportsGroups.SelectedValue;

    //        DataTable RepDT = DBCs.FetchData(" SELECT * FROM Report WHERE RgpID = " + RgpID + "");
    //        if (!DBCs.IsNullOrEmpty(RepDT))
    //        {
    //            FillReports(RgpID);
    //            FillDLL();
    //        }
    //    }

    //    UpdatePanel1.Update();
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void FillReports(string RgpID)
    {
        StringBuilder RQ = new StringBuilder();
        RQ.Append(" SELECT * FROM Report WHERE RepVisible = 'True' AND RgpID = 1 ");

        //RQ.Append(" AND ( CHARINDEX('General',VerID) > 0 OR CHARINDEX(@P2,VerID) > 0) ");
        //RQ.Append(" AND RepID NOT IN (SELECT RepGeneralID FROM Report WHERE RepGeneralID IS NOT NULL AND CHARINDEX(@P2,VerID) > 0 )");

        DataTable DT = DBCs.FetchData(RQ.ToString());
        if (!DBCs.IsNullOrEmpty(DT))
        {
            dltReport.DataSource = DT;
            dltReport.DataBind();
        }

        //DataTable RepDT = DBCs.FetchData(" SELECT * FROM Report WHERE RepVisible = 'True' AND RgpID = " + RgpID + "");
        //if (!DBCs.IsNullOrEmpty(RepDT))
        //{
        //    foreach (DataRow DR in RepDT.Rows)
        //    {
        //        ListItem _liReport = new ListItem(DR["RepName" + FormSession.Language].ToString(), DR["RepID"].ToString());
        //        lstReport.Items.Add(_liReport);
        //    }
        //}
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void dltReport_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string RepID = e.CommandArgument.ToString();
        ViewState["RepID"] = Session["RepID"] = RepID;

        /////////////////Change Style/////////////////////////
        foreach (DataListItem item in dltReport.Items)
        {
            System.Web.UI.WebControls.LinkButton lnkRef = (System.Web.UI.WebControls.LinkButton)item.FindControl("lnkBtnEn");
            System.Web.UI.WebControls.Image imgRef = (System.Web.UI.WebControls.Image)item.FindControl("Image1");
            if (lnkRef != null && imgRef != null)
            {
                lnkRef.Font.Bold = false;
            }
        }

        System.Web.UI.WebControls.LinkButton lnkCurrRef = (System.Web.UI.WebControls.LinkButton)e.Item.FindControl("lnkBtnEn");
        System.Web.UI.WebControls.Image imgCurrRef = (System.Web.UI.WebControls.Image)e.Item.FindControl("Image1");
        lnkCurrRef.Font.Bold = true;
        /////////////////
        string pnlshow = "";
        Clear();
        //StiWebViewerFx1.Report = null;

        calStartDate.SetValidationEnabled(false);
        calEndDate.SetValidationEnabled(false);

        //ddlMonth.SelectedIndex = ddlMonth.Items.IndexOf(ddlMonth.Items.FindByValue(DTCs.FindCurrentMonth()));
        //ddlYear.SelectedIndex = ddlYear.Items.IndexOf(ddlYear.Items.FindByValue(DTCs.FindCurrentYear()));

        ViewState["pnlshow"] = null;

        //RepParametersPro RepProCs = new RepParametersPro();
        //RepProCs.RepID = RepID;
        //RepProCs.RepLang = pgCs.Lang;
        //RepProCs = RepCs.GetReportInfo(RepProCs);

        //lblTitleReport.Text = RepProCs.RepName;
        //txtDescReport.Text = RepProCs.RepDesc;

        //int RepPanels = Convert.ToInt32(RepProCs.RepPanels);

        //if (CheckBitWise(RepPanels, 1))
        //{
        //    pnlshow = pnlDate.ClientID;
        //    calDate.SetValidationEnabled(true);
        //}

        //if (CheckBitWise(RepPanels, 2))
        //{
        //    pnlshow = pnlDateFromTo.ClientID;
        //    calStartDate.SetValidationEnabled(true);
        //    calEndDate.SetValidationEnabled(true);
        //}

        //pnlWorkTime.Visible = CheckBitWise(RepPanels, 4);
        //pnlMachine.Visible = CheckBitWise(RepPanels, 8);
        //pnlEmployee.Visible = CheckBitWise(RepPanels, 16);
        //pnlDepartmnets.Visible = CheckBitWise(RepPanels, 32); /**/ if (pnlDepartmnets.Visible) { FillTree("0"); }
        //pnlCategory.Visible = CheckBitWise(RepPanels, 64);
        //pnlUsers.Visible = CheckBitWise(RepPanels, 128);
        //pnlMonth.Visible = CheckBitWise(RepPanels, 256);
        //if (CheckBitWise(RepPanels, 512))
        //{
        //    pnlshow = pnlDate.ClientID;
        //    calDate.SetEnabled(false);
        //    calDate.SetValidationEnabled(true);
        //    calDate.SetTodayDate();
        //}
        //pnlVacType.Visible = CheckBitWise(RepPanels, 1024);
        //pnlExcType.Visible = CheckBitWise(RepPanels, 2048);
        //pnlDaysCount.Visible = CheckBitWise(RepPanels, 4096);

        
        
        btnEditReport.Enabled = btnSetAsDefault.Enabled = btnViewreport.Enabled = false;

        //if (lstReport.SelectedIndex > -1)
        //{
        //string RepID = lstReport.SelectedValue;
        //string reportTitel = lstReport.SelectedItem.ToString();
        //lblSelectedreport.Text = General.Msg("Report Selected : " + reportTitel, "التقرير المحدد : " + reportTitel);

        DataTable RepDT = DBCs.FetchData(" SELECT * FROM Report WHERE  RepID = '" + RepID + "'");
        if (!DBCs.IsNullOrEmpty(RepDT))
        {
            //RepDT.Rows[0]["RepID"].ToString()
            ViewState["RepID"] = RepID;
            ViewState["ReportNameEn"] = RepDT.Rows[0]["RepNameEn"].ToString();
            ViewState["ReportNameAr"] = RepDT.Rows[0]["RepNameAr"].ToString();
            ViewState["pnlPermissions"] = Convert.ToInt32(RepDT.Rows[0]["RepPanels"]);

            int pnlPermissions = Convert.ToInt32(RepDT.Rows[0]["RepPanels"]);
            //pnlDateFromTo.Visible = CheckBitWise(pnlPermissions, 1);
            if (CheckBitWise(pnlPermissions, 2)) { pnlshow = pnlDateFromTo.ClientID; /**/ calStartDate.SetValidationEnabled(true); /**/ calEndDate.SetValidationEnabled(true); }
            pnlEmployee.Visible = CheckBitWise(pnlPermissions, 2);
            pnlDepartment.Visible = rvDepartment.Enabled = CheckBitWise(pnlPermissions, 4);
            pnlLocation.Visible = rvLocation.Enabled = CheckBitWise(pnlPermissions, 8);
            pnlMachine.Visible = rvMachine.Enabled = CheckBitWise(pnlPermissions, 16);
            //pnlEmpType.Visible = CheckBitWise(pnlPermissions, 32);
            FillPerm();

            FillDLL();

            lblSelectedreport.Text = General.Msg(ViewState["ReportNameEn"].ToString(), ViewState["ReportNameAr"].ToString());

            //btnViewreport.Enabled = true;

            btnEventsEnable(true);
            hdnShow.Value = pnlshow;
            ViewState["pnlshow"] = pnlshow;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key22", "showPopup('" + DivPopup.ClientID + "','','" + pnlDateFromTo.ClientID + "','" + pnlshow + "');", true);
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void dltReport_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        //if ((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.Item))
        //{
        //    e.Item.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.dltReport, "Select$" + e.Item.ItemIndex);
        //}
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected string getRepName() { return General.Msg("dataitem.RepNameEn", "dataitem.RepNameAr"); }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion
    /*#############################################################################################################################*/
    /*#############################################################################################################################*/

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void FillPerm()
    {
        btnEditReport.Enabled = FormSession.getPerm("ReptEdit");
        btnSetAsDefault.Enabled = FormSession.getPerm("RepSetToDef");
        //btnExport.Enabled = FormSession.getPerm("ReptUpload");
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void FillDLL()
    {
        dt = DBCs.FetchData("SELECT * FROM Department ");
        if (!DBCs.IsNullOrEmpty(dt)) { FormCtrl.PopulateDDL(ddlDepartment, dt, "DepName" + General.Lang(), "DepID", General.Msg("-Select Department-", "-اختر الإدارة-")); }

        dt = DBCs.FetchData("SELECT * FROM Machine WHERE MachineStatus = 1");
        if (!DBCs.IsNullOrEmpty(dt)) { FormCtrl.PopulateDDL(ddlLocation, dt, "Location" + General.Lang(), "MacID", General.Msg("-Select Location-", "-اختر الموقع-")); }

        dt = DBCs.FetchData("SELECT * FROM MachineInfoView ");
        if (!DBCs.IsNullOrEmpty(dt)) { FormCtrl.PopulateDDL(ddlMachine, dt, "MtpName" + General.Lang(), "MacID", General.Msg("-Select Machine-", "-اختر المكينة-")); }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool CheckBitWise(int panelPermission, int permission) { if ((panelPermission | permission) == panelPermission) { return true; } else { return false; } }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void lstReport_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Clear();

    //    StiWebViewerFx1.Report = null;
    //    btnEditReport.Enabled = btnSetAsDefault.Enabled = btnViewreport.Enabled = false;

    //    //UpdatePanel1.Update();

    //    if (lstReport.SelectedIndex > -1)
    //    {
    //        string RepID = lstReport.SelectedValue;
    //        string reportTitel = lstReport.SelectedItem.ToString();
    //        lblSelectedreport.Text = General.Msg("Report Selected : " + reportTitel, "التقرير المحدد : " + reportTitel);

    //        DataTable RepDT = DBCs.FetchData(" SELECT * FROM Report WHERE  RepID = '" + RepID + "'");
    //        if (!DBCs.IsNullOrEmpty(RepDT))
    //        {
    //            //RepDT.Rows[0]["RepID"].ToString()
    //            ViewState["RepID"] = RepID;
    //            ViewState["ReportNameEn"] = RepDT.Rows[0]["RepNameEn"].ToString();
    //            ViewState["ReportNameAr"] = RepDT.Rows[0]["RepNameAr"].ToString();
    //            ViewState["pnlPermissions"] = Convert.ToInt32(RepDT.Rows[0]["RepPanels"]);

    //            int pnlPermissions = Convert.ToInt32(RepDT.Rows[0]["RepPanels"]);
    //            pnlDateFromTo.Visible = CheckBitWise(pnlPermissions, 1);
    //            pnlEmployee.Visible = CheckBitWise(pnlPermissions, 2);
    //            pnlDepartment.Visible = rvDepartment.Enabled = CheckBitWise(pnlPermissions, 4);
    //            pnlLocation.Visible = rvLocation.Enabled = CheckBitWise(pnlPermissions, 8);
    //            pnlMachine.Visible = rvMachine.Enabled = CheckBitWise(pnlPermissions, 16);
    //            //pnlEmpType.Visible = CheckBitWise(pnlPermissions, 32);

    //            FillPerm();

    //            btnViewreport.Enabled = true;
    //        }
    //    }
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Clear()
    {
        lblSelectedreport.Text = "";
        calStartDate.ClearDate();
        calEndDate.ClearDate();

        ddlIDSearch.SelectedIndex = -1;
        txtIDSearch.Text = "";
        ddlDepartment.SelectedIndex = -1;
        ddlLocation.SelectedIndex = ddlMachine.SelectedIndex = -1;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnViewreport_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            ValidatorCollection ValidatorColl = Page.Validators;
            for (int k = 0; k < ValidatorColl.Count; k++)
            {
                if (!ValidatorColl[k].IsValid && !String.IsNullOrEmpty(ValidatorColl[k].ErrorMessage)) { vsView.ShowSummary = true; return; }
                vsView.ShowSummary = false;
            }
            return;
        }

        try { ShowReport(); }
        catch (Exception e1) { }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void ShowReport()
    {
        try
        {
            Session["RepProCs"] = null;

            FillParameter(ViewState["RepID"].ToString());

            Session["RepProCs"] = ViewState["RepProCs"];
        }
        catch (Exception Ex) { }

        Response.Redirect(@"~/Pages/ReportViewer.aspx");

        //StiWebViewerFx1.Report = null;

        //if (ViewState["RepID"].ToString() != null)
        //{
        //    string RepID = ViewState["RepID"].ToString();

        //    string RepTemp = "";
        //    DataTable RepDT = DBCs.FetchData(" SELECT * FROM Report WHERE RepID = '" + RepID + "'");
        //    if (!DBCs.IsNullOrEmpty(RepDT))
        //    {
        //        RepTemp = RepDT.Rows[0]["RepTemp" + FormSession.Language].ToString();
        //        string RepOrientation = RepDT.Rows[0]["RepOrientation"].ToString();
        //        ViewState["RepOrientation"] = RepDT.Rows[0]["RepOrientation"].ToString();

        //        StiReport StiRep = new StiReport();
        //        StiRep.LoadFromString(RepTemp);
        //        StiRep.Dictionary.Databases.Clear();
        //        StiRep.Dictionary.Databases.Add(new Stimulsoft.Report.Dictionary.StiSqlDatabase("Connection", General.ConnString));
        //        StiRep.GetSubReport += new StiGetSubReportEventHandler(rep_GetSubReport);
        //        StiRep.Dictionary.Synchronize();
        //        StiRep.Compile();

        //        ///////////////// Fill Parameters to Report ///////////////////
        //        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        //        if (pnlDateFromTo.Visible)
        //        {
        //            StiRep["ParamDateFrom"] = DTCs.GetGregDateTime(calStartDate.getGDateDBFormat(), 'S', "F");
        //            StiRep["ParamDateTo"] = DTCs.GetGregDateTime(calEndDate.getGDateDBFormat(), 'S', "T");
        //        }

        //        if (pnlEmployee.Visible) { StiRep["EmpID"] = ViewState["EmpID"].ToString(); }
        //        if (pnlDepartment.Visible) { StiRep["DepID"] = ddlDepartment.SelectedValue; }
        //        if (pnlLocation.Visible) { StiRep["MacID"] = ddlLocation.SelectedValue; }
        //        if (pnlMachine.Visible) { StiRep["MacID"] = Convert.ToInt32(ddlMachine.SelectedValue); }

        //        //StiRep["DateFormat"] = "";
        //        //StiRep["DateType"] = "";

        //        //StiRep.Render();
        //        //StiWebViewerFx1.Report = StiRep;
        //    }
        //}
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void FillParameter(string RepID)
    {
        ViewState["RepProCs"] = "";

        if (ViewState["RepID"].ToString() != null)
        {
            RepID = ViewState["RepID"].ToString();
        }

        ReportPro RepProCs = new ReportPro();
        RepProCs.RepID = RepID;
        RepProCs.RepUser = FormSession.LoginID;
        RepProCs.DateType = FormSession.DateType;
        RepProCs.RepLang = FormSession.Language;

        string RepTemp = "";
        DataTable RepDT = DBCs.FetchData(" SELECT * FROM Report WHERE RepID = '" + RepID + "'");
        if (!DBCs.IsNullOrEmpty(RepDT))
        {
            RepProCs.RepTemp = RepDT.Rows[0]["RepTemp" + FormSession.Language].ToString();
            RepProCs.RepOrientation = RepDT.Rows[0]["RepOrientation"].ToString();
            //ViewState["RepOrientation"] = RepDT.Rows[0]["RepOrientation"].ToString();

            ///////////////// Fill Parameters to Report ///////////////////

            if (pnlDateFromTo.Visible && !string.IsNullOrEmpty(calStartDate.getGDate())) { RepProCs.DateFrom = calStartDate.getGDateDefFormat(); }
            if (pnlDateFromTo.Visible && !string.IsNullOrEmpty(calEndDate.getGDate())) { RepProCs.DateTo = calEndDate.getGDateDefFormat(); }
                //DTCs.GetGregDateTime(calEndDate.getGDateDBFormat(), 'S', "T");

            if (pnlEmployee.Visible) { RepProCs.EmpID = ViewState["EmpID"].ToString(); }
            if (pnlDepartment.Visible) { RepProCs.DepID = ddlDepartment.SelectedValue; }
            if (pnlLocation.Visible) { RepProCs.MacID = ddlLocation.SelectedValue; }
            if (pnlMachine.Visible) { RepProCs.MacID = ddlMachine.SelectedValue; } //Convert.ToInt32(ddlMachine.SelectedValue);

        }
        ViewState["RepProCs"] = RepProCs;

        //RepProCs = RepCs.GetReportInfo(RepProCs);

        //if (pnlDate.Visible && !string.IsNullOrEmpty(calDate.getGDate())) { RepProCs.Date = calDate.getGDateDefFormat(); }
        //if (pnlDateFromTo.Visible && !string.IsNullOrEmpty(calStartDate.getGDate())) { RepProCs.DateFrom = calStartDate.getGDateDefFormat(); }
        //if (pnlDateFromTo.Visible && !string.IsNullOrEmpty(calEndDate.getGDate())) { RepProCs.DateTo = calEndDate.getGDateDefFormat(); }

        //if (pnlMonth.Visible && ddlMonth.SelectedIndex >= 0)
        //{
        //    DateTime SDate = DateTime.Now;
        //    DateTime EDate = DateTime.Now;
        //    DTCs.FindMonthDates(ddlYear.SelectedValue, ddlMonth.SelectedValue, out SDate, out EDate);

        //    RepProCs.DateFrom = SDate.ToString("dd/MM/yyyy");
        //    RepProCs.DateTo = EDate.ToString("dd/MM/yyyy");

        //    RepProCs.MonthDate = ddlMonth.SelectedValue;
        //    RepProCs.YearDate = ddlYear.SelectedValue;
        //}

        //if (pnlWorkTime.Visible) { RepProCs.WktID = ViewState["WorkTimeParam"].ToString(); }
        //if (pnlMachine.Visible) { RepProCs.MacID = ViewState["MachineParam"].ToString(); }
        //if (pnlEmployee.Visible) { RepProCs.EmpID = Employee(); }
        //if (pnlDepartmnets.Visible) { RepProCs.DepID = ViewState["DepartmentParam"].ToString(); }
        //if (pnlCategory.Visible) { RepProCs.CatID = ViewState["CategoryParam"].ToString(); }
        //if (pnlUsers.Visible) { RepProCs.UsrName = ddlUserName.SelectedValue.ToString(); RepProCs.Permissions = Permission(); }
        //if (pnlVacType.Visible) { RepProCs.VtpID = ViewState["VacationParam"].ToString(); }
        //if (pnlExcType.Visible) { RepProCs.ExcID = ViewState["ExcuseParam"].ToString(); }
        //if (pnlDaysCount.Visible) { RepProCs.DaysCount = txtDaysCount.Text; }

        //ViewState["RepProCs"] = RepProCs;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void rep_GetSubReport(object sender, StiGetSubReportEventArgs e)
    {
        string RepOrientation = ViewState["RepOrientation"].ToString();

        StiReport HRep = new StiReport();

        DataTable HDT = DBCs.FetchData(" SELECT * FROM Report WHERE RepType = 'Header' AND RepOrientation ='" + RepOrientation + "'");
        if (!DBCs.IsNullOrEmpty(HDT))
        {
            string RepHeader = HDT.Rows[0]["RepTemp" + FormSession.Language].ToString();

            if (e.SubReportName == "SubReport1") { HRep.LoadFromString(RepHeader); }

            HRep.Dictionary.Databases.Clear();
            HRep.Dictionary.Databases.Add(new Stimulsoft.Report.Dictionary.StiSqlDatabase("Connection", General.ConnString));
            e.Report = HRep;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void btnEventsEnable(bool status)
    {
        btnSetAsDefault.Enabled = status;
        btnViewreport.Enabled = status;
        //btnExport.Enabled = status;
        btnEditReport.Enabled = status;
        btnCancel.Enabled = status;
        //btnExport.Enabled = status;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*#############################################################################################################################*/
    /*#############################################################################################################################*/
    #region Report Events

    protected void btnSetAsDefault_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["RepID"].ToString() != null)
            {
                string RepID = ViewState["RepID"].ToString();

                DataTable RepDT = DBCs.FetchData(" SELECT * FROM Report WHERE RepID = '" + RepID + "'");
                if (!DBCs.IsNullOrEmpty(RepDT))
                {
                    string repStr = RepDT.Rows[0]["RepTempDef" + FormSession.Language].ToString();

                    ProClass.RepID = RepID;
                    ProClass.RepTemp = repStr;
                    ProClass.Lang = FormSession.Language;
                    ProClass.ModifiedBy = FormSession.LoginID;

                    SqlClass.UpdateTemplate(ProClass);
                }
            }
        }
        catch (Exception e1) { }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnUploadReport_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    string type = fileUpload.PostedFile.ContentType.ToString();
        //    fileUpload.SaveAs(Server.MapPath(@"../Reports/EditedReports/") + fileUpload.FileName);
        //    fileUpload.SaveAs(Server.MapPath(@"../Reports/DefaultReports/") + fileUpload.FileName);
        //    Server.Transfer("Reports.aspx");
        //}
        //catch (Exception e1) { }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //if (ViewState["RepID"].ToString() != null)
        //{
        //    string reportName;
        //    if (lstReport.SelectedIndex > -1) { reportName = lstReport.SelectedValue; }
        //    else if (lstHeaderReport.SelectedIndex > -1) { reportName = lstHeaderReport.SelectedValue; }
        //    else { return; }

        //    string sourceFilename = string.Empty;
        //    string destinationFilename = string.Empty;
        //    sourceFilename = Server.MapPath(@"..\Reports\EditedReports\" + FormSession.Language + "\\") + reportName + "";
        //    destinationFilename = "attachment; filename=" + reportName;
        //    Response.ContentType = "text/plain";
        //    Response.AppendHeader("Content-Disposition", destinationFilename);
        //    Response.TransmitFile(sourceFilename);
        //    Response.End();
        //}
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
    protected void btnEditReport_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["RepID"].ToString() != null)
            {
                string RepID = ViewState["RepID"].ToString();
                DataTable RepDT = DBCs.FetchData(" SELECT * FROM Report WHERE RepID = '" + RepID + "'");
                if (!DBCs.IsNullOrEmpty(RepDT))
                {
                    string repStr = RepDT.Rows[0]["RepTemp" + FormSession.Language].ToString();
                    if (string.IsNullOrEmpty(repStr)) { return; }

                    StiReport report = new StiReport();
                    report.LoadFromString(repStr);
                    report.Dictionary.Databases.Clear();
                    report.Dictionary.Databases.Add(new StiSqlDatabase("Connection", General.ConnString));
                    report.Dictionary.Synchronize();
                    report.Compile();
                    StiWebDesigner1.Design(report);
                    ////this.InvokeRefreshPreview();
                }
            }
        }
        catch (Exception ex) { }
    }

    #endregion
    /*#############################################################################################################################*/
    /*#############################################################################################################################*/

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

    /*#############################################################################################################################*/
    /*#############################################################################################################################*/
    #region StiWeb Events

    protected void StiWebDesigner1_PreInit(object sender, StiWebDesigner.StiPreInitEventArgs e)
    {
        e.WebDesigner.Localization = FormSession.Language;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void StiWebViewerFx1_PreInit(object sender, Stimulsoft.Report.WebFx.StiWebViewerFx.StiPreInitEventArgs e)
    //{
    //    StiWebViewerFx1.Localization = FormSession.Language;
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void StiWebDesigner1_SaveReport(object sender, StiWebDesigner.StiSaveReportEventArgs e)
    {
        try
        {
            if (ViewState["RepID"].ToString() != null)
            {

                string RepID = ViewState["RepID"].ToString();
                StiReport report = e.Report;
                string repStr = e.Report.SaveToString().ToString();

                ProClass.RepID = RepID;
                ProClass.RepTemp = repStr;
                ProClass.Lang = FormSession.Language;
                ProClass.ModifiedBy = FormSession.LoginID;

                SqlClass.UpdateTemplate(ProClass);
                //ShowMsg("Report Updated Successfully", "تم تحديث التقرير بنجاح");
            }
        }
        catch (Exception e1)
        {
            //ShowMsg("Transaction failed to commit please contact your administrator", "النظام غير قادر على رفع التقرير, الرجاء الاتصال بمدير النظام");
        }
    }

    #endregion
    /*#############################################################################################################################*/
    /*#############################################################################################################################*/

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

    /*#############################################################################################################################*/
    /*#############################################################################################################################*/
    #region Custom Validate Events

    protected void ShowMsg_ServerValidate(Object source, ServerValidateEventArgs e) { e.IsValid = false; }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Date_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        //try
        //{
        //    if (pnlDateFromTo.Visible)
        //    {
        //        if (source.Equals(cvStartDate)) { if (string.IsNullOrEmpty(calStartDate.getGDateDBFormat())) { e.IsValid = false; } else { e.IsValid = true; } }
        //        if (source.Equals(cvEndDate)) { if (string.IsNullOrEmpty(calEndDate.getGDateDBFormat())) { e.IsValid = false; } else { e.IsValid = true; } }
        //        if (source.Equals(cvCompareDates))
        //        {
        //            try
        //            {
        //                if (!String.IsNullOrEmpty(calStartDate.getGDateDBFormat()) && !String.IsNullOrEmpty(calEndDate.getGDateDBFormat()))
        //                {
        //                    int iStartDate = DTCs.ConvertDateTimeToInt(FormSession.DateType, calStartDate.getGDateDBFormat());
        //                    int iEndDate = DTCs.ConvertDateTimeToInt(FormSession.DateType, calEndDate.getGDateDBFormat());
        //                    if (iStartDate > iEndDate) { e.IsValid = false; } else { e.IsValid = true; }
        //                }
        //            }
        //            catch
        //            {
        //                e.IsValid = false;
        //            }
        //        }
        //    }
        //}
        //catch { e.IsValid = false; }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void IDSearch_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        try
        {
            if (source.Equals(cvIDSearch) && pnlEmployee.Visible)
            {
                if (string.IsNullOrEmpty(txtIDSearch.Text))
                {
                    General.ValidMsg(this, ref cvIDSearch, false, "You must enter a value in the search text", "يجب إدخال قيمة في مربع البحث");
                    e.IsValid = false;
                    return;
                }
                else
                {
                    DataTable DT = new DataTable();
                    if (ddlIDSearch.SelectedValue == "EmpID") { DT = DBCs.FetchData("SELECT EmpID FROM EmployeesInfoView WHERE EmpID     = '" + txtIDSearch.Text + "'"); }
                    else if (ddlIDSearch.SelectedValue == "EmpNameEn") { DT = DBCs.FetchData("SELECT EmpID FROM EmployeesInfoView WHERE EmpNameEn = '" + txtIDSearch.Text + "'"); }
                    else if (ddlIDSearch.SelectedValue == "EmpNameAr") { DT = DBCs.FetchData("SELECT EmpID FROM EmployeesInfoView WHERE EmpNameAr = '" + txtIDSearch.Text + "'"); }

                    ViewState["EmpID"] = "";
                    if (DBCs.IsNullOrEmpty(DT))
                    {
                        MessageFun.ValidMsg(this, ref cvIDSearch, true, General.Msg("Employee ID does not exist", "رقم الموظف غير موجود"));
                        e.IsValid = false;
                        return;
                    }
                    else
                    {
                        ViewState["EmpID"] = DT.Rows[0]["EmpID"].ToString();
                    }
                }
            }
        }
        catch { e.IsValid = false; }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    #endregion
    /*#############################################################################################################################*/
    /*#############################################################################################################################*/

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
}