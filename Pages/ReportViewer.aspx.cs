using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Web;
using System.Data.SqlClient;
using Stimulsoft.Report.Dictionary;
using System.Data;

public partial class Pages_ReportViewer : BasePage
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //PageFun pgCs = new PageFun();
    General GenCs = new General();
    DBFun DBCs = new DBFun();
    //CtrlFun CtrlCs = new CtrlFun();
    DateFun DTCs = new DateFun();
    //ReportFun RepCs = new ReportFun();

    string appDirectory = HttpContext.Current.Server.MapPath(string.Empty);
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        //StiWebViewerFxOptions.Toolbar.ShowOpenButton = false;
        //StiWebViewerFxOptions.Toolbar.ShowSaveButton = false;

        try
        {
            /*** Fill Session ************************************/
            FormSession.FillSession("Reports", pageDiv);
            /*** Fill Session ************************************/
            if (Request.QueryString["ID"] != null)
            {
                string ID = Request.QueryString["ID"].ToString();
                if (!string.IsNullOrEmpty(ID))
                {
                    string[] IDs = ID.Split('_');
                    string RepID = IDs[0];
                    //RepParametersPro RepProCs = RepCs.FillFavReportParam(FavID, RepID, pgCs.LoginID, pgCs.Lang, pgCs.DateType);
                    //Session["RepProCs"] = RepProCs;
                }
            }

            if (Session["RepProCs"] == null) { Response.Redirect(@"~/Pages/ReportsMain.aspx?ID=" + "1"); }
            ShowReport();
        }
        catch (Exception ex) { }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void ShowReport()
    {
        if (Session["RepProCs"] != null)
        {
            StiReport Rep = new StiReport();
            ReportPro RepProCs = new ReportPro();
            RepProCs = (ReportPro)Session["RepProCs"];

            ViewState["RepID"] = RepProCs.RepID;
            //ViewState["RgpID"] = RepProCs.RgpID;
            ViewState["RepOrientation"] = RepProCs.RepOrientation;
            //Rep = RepCs.CreateReport(RepProCs);

            Rep.LoadFromString(RepProCs.RepTemp);
            Rep.Dictionary.Databases.Clear();
            Rep.Dictionary.Databases.Add(new Stimulsoft.Report.Dictionary.StiSqlDatabase("Connection", General.ConnString));
            //(report.GetComponentByName("ReportTitleBand1") as StiReportTitleBand).PrintOn = StiPrintOnType.AllPages;
            Rep.GetSubReport += new StiGetSubReportEventHandler(rep_GetSubReport);
            Rep.Dictionary.Synchronize();
            Rep.Compile();

            /////// Fill Parameters to Report
            if (!string.IsNullOrEmpty(RepProCs.Date)) { Rep["ParamDate"] = DTCs.ConvertToDatetime(RepProCs.Date, "Gregorian"); }
            if (!string.IsNullOrEmpty(RepProCs.DateFrom)) { Rep["ParamDateFrom"] = DTCs.ConvertToDatetime(RepProCs.DateFrom, "Gregorian"); }
            if (!string.IsNullOrEmpty(RepProCs.DateTo)) { Rep["ParamDateTo"] = DTCs.ConvertToDatetime(RepProCs.DateTo, "Gregorian"); }

            if (!string.IsNullOrEmpty(RepProCs.MacID)) { Rep["MacID"] = RepProCs.MacID; }
            if (!string.IsNullOrEmpty(RepProCs.EmpID)) { Rep["EmpID"] = RepProCs.EmpID; }
            if (!string.IsNullOrEmpty(RepProCs.DepID)) { Rep["DepID"] = RepProCs.DepID; }

            Rep.Render(false);


            ////// View report
            //Rep.Render();
            //StiWebViewerFx1.Report = Rep;
            StiWebViewer1.Report = Rep;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void rep_GetSubReport(object sender, StiGetSubReportEventArgs e)
    {
        string RepOrientation = ViewState["RepOrientation"].ToString();

        StiReport HRep = new StiReport();

        DataTable HDT = DBCs.FetchData(" SELECT * FROM Report WHERE RepType = 'Header_" + FormSession.Version + "' AND RepOrientation ='" + RepOrientation + "'");
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
    public static object GetPropValue(object src, string propName)
    {
        return src.GetType().GetProperty(propName).GetValue(src, null);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnBackToReportsPage_Click(object sender, EventArgs e)
    {
        Response.Redirect(@"~/Pages/ReportsMain.aspx?ID=" + "1");
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void StiWebViewerFx1_PreInit(object sender, StiWebViewerFx.StiPreInitEventArgs e)
    //{
    //    e.WebDesigner.Localization = "en";        
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void StiWebViewerFx1_PreInit(object sender, Stimulsoft.Report.WebFx.StiWebViewerFx.StiPreInitEventArgs e)
    //{
    //    //StiWebViewerFx1.Localization = FormSession.Language; //Session["Language"].ToString();
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}