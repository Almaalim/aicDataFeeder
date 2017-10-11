using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;

public partial class MainMasterPage : System.Web.UI.MasterPage
{
    AppUsersPro AppPro = new AppUsersPro();
    AppUsersSql AppSql = new AppUsersSql();

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static string Titel = "";
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        FormSession.FillSession("", null);
        FillMenu();

        try { Response.AppendHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 2) + "; URL=../Login.aspx"); }
        catch (Exception ex) { }

        if (FormSession.Language == "Ar") { MainDiv.Attributes.Add("dir", "rtl"); } else { MainDiv.Attributes.Add("dir", "ltr"); }

        //int Index = InfoTab.FindPageIndex(FormSession.PageIndex);
        //InfoTab.ShowTabs(Index, Session["Language"].ToString(), (HtmlTableCell)MyHeader.FindControl("MenuHeader"));
        lblHeading.Text = Titel;
        
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static void ShowTitel(string pTitel) { Titel = pTitel; }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string getPageName() 
    { 
        string QS = "";
        System.IO.FileInfo PageFileInfo = new System.IO.FileInfo(Request.Url.AbsolutePath);
        if (Request.QueryString.Count != 0) { QS = "?" + Request.QueryString.ToString(); }
        return PageFileInfo.Name + QS;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*******************************************************************************************************************************/
    /*******************************************************************************************************************************/
    #region Menu Events

    protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
    {
        //string ss = e.Item.ToolTip;

        //string lang = (pgCs.Lang == "AR") ? "Ar" : "En";
        //string q = " SELECT MnuTextEn AS ID FROM Menu WHERE MnuText" + lang + " = '" + e.Item.Text + "'";
        //DataTable DT1 = DBCs.FetchData(new SqlCommand(q));
        //if (!DBCs.IsNullOrEmpty(DT1))
        //{
        //    if (DT1.Rows[0]["ID"] != DBNull.Value)
        //    {
        //        string menuCss = DT1.Rows[0]["ID"].ToString();
        //        menuCss = menuCss.Replace(" ", "");
        //        menuCss = Regex.Replace(menuCss, @"[^0-9a-zA-Z]+", "");
        //        e.Item.ToolTip = menuCss;
        //      //  e.Item.ToolTip = "SideMenuItem " + "icon" + menuCss;
        //       // e.Item.ToolTip = "SideMenuItem " + "icon448";
        //    }
        //}

        System.Xml.XmlElement node = (System.Xml.XmlElement)e.Item.DataItem;
        if (node.ChildNodes.Count != 0)
        {
            e.Item.Selectable = false;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
    protected void FillMenu()
    {
        DataSet MuenDS = new DataSet();

        if (Session["MenuDS"] == null)
        {
            string QMuen = CreateMenuQuery("USR", "");
            MuenDS = DBFun.FetchMenuData(QMuen);
            Session["MenuDS"] = MuenDS;
        }
        else
        {
            MuenDS = (DataSet)Session["MenuDS"];
        }

        xmlDataSource.Data = MuenDS.GetXml();
        FillSideMenu(MuenDS);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected string CreateMenuQuery(string Type, string EmpID)
    {
        StringBuilder QMuen = new StringBuilder();

        try
        {
            if (Type == "USR") { QMuen.Append(FindUsrMenu()); }
            //if ((Type == "USR" && !string.IsNullOrEmpty(EmpID)) || (Type == "EMP"))
            //{
            //    if (!string.IsNullOrEmpty(QMuen.ToString())) { QMuen.Append(" UNION ALL "); }
            //    QMuen.Append(FindEmpMenu());
            //}

            if (!string.IsNullOrEmpty(QMuen.ToString())) { QMuen.Append(" ORDER BY MnuOrder"); }
        }
        catch (Exception ex) { }

        return QMuen.ToString();
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
    protected string FindUsrMenu()
    {
        StringBuilder QMuen = new StringBuilder();

        string lang = (FormSession.Language == "AR") ? "Ar" : "En";
        string DescCol = (FormSession.Language == "AR") ? "MnuArabicDescription" : "MnuDescription";
        string LicPage = string.Empty; //LicDf.FindLicPage();
        string listPage = "'SubMenu'" + (string.IsNullOrEmpty(LicPage) ? "" : "," + LicPage);

        string MPerm = (General.IsNullOrEmpty(Session["Permissions"])) ? "0" : FormSession.orderPermission(Session["Permissions"].ToString());
        //string RPerm = (General.IsNullOrEmpty(Session["ReportPermissions"])) ? "0" : Session["ReportPermissions"].ToString();

        QMuen.Append(" SELECT MnuNumber,MnuID,MnuPermissionID,MnuImageURL,MnuText" + lang + " as MnuText,MnuTextEn as MnuTextEn,(MnuServer + '' + MnuURL) as MnuURL,MnuParentID,MnuVisible,MnuOrder,MnuPermissionID AS MnuDepth ");
        QMuen.Append(" FROM Menu WHERE MnuVisible = 'True' AND MnuType IN ('Menu') AND MenuPerm IN (" + MPerm + ") ");

        QMuen.Append(" UNION ALL ");
        QMuen.Append(" SELECT MnuNumber,MnuID,MnuPermissionID,MnuImageURL,MnuText" + lang + " as MnuText,MnuTextEn as MnuTextEn,(MnuServer + '' + MnuURL) as MnuURL,MnuParentID,MnuVisible,MnuOrder,MnuPermissionID AS MnuDepth ");
        QMuen.Append(" FROM Menu WHERE MnuVisible = 'True' AND MnuType IN (" + listPage + ") AND MenuPerm IN (" + MPerm + ") AND ( CHARINDEX('General',VerID) > 0) "); // OR CHARINDEX('" + pgCs.Version + "',VerID) > 0)

        //QMuen.Append(" UNION ALL ");
        //QMuen.Append(" SELECT MnuNumber,MnuID,MnuPermissionID,MnuImageURL,MnuText" + lang + " as MnuText,MnuTextEn as MnuTextEn,(MnuServer + '' + MnuURL) as MnuURL,MnuParentID,MnuVisible,MnuOrder,MnuPermissionID AS MnuDepth ");
        //QMuen.Append(" FROM Menu WHERE  MnuVisible ='True' AND MnuType IN ('Reports') AND RgpID IN (" + RPerm + ") AND ( CHARINDEX('General',VerID) > 0  "); //OR CHARINDEX('" + pgCs.Version + "',VerID) > 0)

        return QMuen.ToString();
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected string FindEmpMenu()
    {
        //StringBuilder QMuen = new StringBuilder();

        //string lang = (pgCs.Lang == "AR") ? "Ar" : "En";
        //string DescCol = (pgCs.Lang == "AR") ? "MnuArabicDescription" : "MnuDescription";
        //string listPage = "'ERS_MainMenu','ERS_SubMenu'";

        //Hashtable Reqht = pgCs.GetAllRequestPerm();
        //string ERSLic = LicDf.FetchLic("ER");
        //if (ERSLic == "1") { listPage += ",'ERS_LMainMenu','ERS_LMenu'"; }
        //if (ERSLic == "1" && Reqht.ContainsKey("VAC")) { listPage += ",'ERS_VACMenu'"; }
        //if (ERSLic == "1" && Reqht.ContainsKey("VAC")) { listPage += ",'ERS_VACMenu'"; }
        //if (ERSLic == "1" && Reqht.ContainsKey("COM")) { listPage += ",'ERS_COMMenu'"; }
        //if (ERSLic == "1" && Reqht.ContainsKey("JOB")) { listPage += ",'ERS_JOBMenu'"; }
        //if (ERSLic == "1" && Reqht.ContainsKey("EXC")) { listPage += ",'ERS_EXCMenu'"; }
        //if (ERSLic == "1" && Reqht.ContainsKey("ESH")) { listPage += ",'ERS_ESHMenu'"; }
        //if (ERSLic == "1" && LicDf.FetchLic("SS") == "1" && Reqht.ContainsKey("SWP")) { listPage += ",'ERS_SWPMenu'"; }

        //QMuen.Append(" SELECT MnuNumber,MnuID,MnuPermissionID,MnuImageURL,MnuText" + lang + " as MnuText,MnuTextEn as MnuTextEn,(MnuServer + '' + MnuURL) as MnuURL,MnuParentID,MnuVisible,MnuOrder,MnuPermissionID AS MnuDepth ");
        //QMuen.Append(" FROM Menu WHERE MnuVisible = 'True' AND MnuType IN (" + listPage + ") AND ( CHARINDEX('General',VerID) > 0 OR CHARINDEX('" + pgCs.Version + "',VerID) > 0) ");

        //return QMuen.ToString();
        return "";
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    protected void FillSideMenu(DataSet MuenDS)
    {
        //this part of side menu need to review 
        bool isFirst = true;
        string FirstItem = "";
        string SMultiItem = "<div class='square-mult'>";
        string EMultiItem = "</div>";
        string MultiItem = "";
        int iMultiItem = 0;

        DataTable DT = MuenDS.Tables[0];

        if (!DBFun.IsNullOrEmpty(DT))
        {
            DataRow[] DRs = DT.Select("MnuParentID = 0");

            foreach (DataRow DR in DRs)
            {
                DataRow[] SDRs = DT.Select("MnuParentID = " + DR["MnuNumber"].ToString() + "");
                if (SDRs.Length > 0)
                {
                    Label _lbl = new Label();
                    _lbl.ID = "lbl_" + DR["MnuNumber"].ToString();
                    _lbl.Text = DR["MnuText"].ToString();
                    _lbl.CssClass = "menu-subtitle";
                    divSideMenu.Controls.Add(_lbl);
                }

                isFirst = true;
                FirstItem = "";
                MultiItem = "";
                iMultiItem = 0;
                foreach (DataRow SDR in SDRs)
                {

                    string menuCss = SDR["MnuID"].ToString();
                    menuCss = menuCss.Replace(" ", "");
                    menuCss = Regex.Replace(menuCss, @"[^0-9a-zA-Z]+", "");
                    if (isFirst)
                    {

                        FirstItem = "<div class='square-big'>";
                        FirstItem += "<a title='" + SDR["MnuText"].ToString() + "' class='SideMenuItem " + "icon" + menuCss + "' href='" + SDR["MnuURL"].ToString().Replace("~", "..") + "'>" + SDR["MnuText"].ToString() + "</a>";
                        FirstItem += "</div>";
                        isFirst = false;
                    }
                    else
                    {

                        if (iMultiItem >= 4) { iMultiItem = 0; }
                        iMultiItem += 1;
                        if (iMultiItem == 1) { MultiItem += SMultiItem; }

                        MultiItem += "<div class='sub-square'>";
                        MultiItem += "<a title='" + SDR["MnuText"].ToString() + "' class='SideMenuItem " + "icon" + menuCss + "' href='" + SDR["MnuURL"].ToString().Replace("~", "..") + "'>" + SDR["MnuText"].ToString() + "</a>";
                        MultiItem += "</div>";

                        if (iMultiItem == 4) { MultiItem += EMultiItem; }
                    }
                }
                if (!string.IsNullOrEmpty(MultiItem) && iMultiItem < 4) { MultiItem += EMultiItem; }


                if (!string.IsNullOrEmpty(FirstItem)) { divSideMenu.Controls.Add(new LiteralControl("<div class='squares'>")); }
                if (!string.IsNullOrEmpty(FirstItem)) { divSideMenu.Controls.Add(new LiteralControl(FirstItem)); }
                if (!string.IsNullOrEmpty(MultiItem))
                {
                    //divSideMenu.Controls.Add(new LiteralControl(SMultiItem)); 
                    divSideMenu.Controls.Add(new LiteralControl(MultiItem));
                    //divSideMenu.Controls.Add(new LiteralControl(EMultiItem)); 
                }
                if (!string.IsNullOrEmpty(FirstItem)) { divSideMenu.Controls.Add(new LiteralControl("</div>")); }
            }
        }
    }

    #endregion
    /*******************************************************************************************************************************/
    /*******************************************************************************************************************************/

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void OnMenuItemDataBound2(object sender, MenuEventArgs e)
    //{
    //    if (SiteMap.CurrentNode != null)
    //    {
    //        if (e.Item.Text == SiteMap.CurrentNode.Title)
    //        {
    //            if (e.Item.Parent != null) { e.Item.Parent.Selected = true; }
    //            else { e.Item.Selected = true; }
    //        }
    //    }
    //}
    //public static string PageName()
    //{

    //    return getPageName();
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    protected void lnkChangePassword_Click(object sender, EventArgs e)
    {
        Server.Transfer(@"~/Pages/ChangePass.aspx");
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session["Permissions"] = null;
        Session.Contents.RemoveAll();
        Session.Abandon();
        Response.Redirect(@"~/Login.aspx");
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    protected void lnkChangeLang_Click(object sender, EventArgs e)
    {
        if (Session["Language"].ToString() == "Ar") { Session["Language"] = "En"; } else { Session["Language"] = "Ar"; }

        if (Session["Language"].ToString() == "Ar") { Session["MyTheme"] = "ThemeAr"; }
        if (Session["Language"].ToString() == "En") { Session["MyTheme"] = "ThemeEn"; }

        AppPro.UsrLoginID = FormSession.LoginID;
        AppPro.UsrLanguage = Session["Language"].ToString();
        AppPro.TransactionBy = FormSession.LoginID;
        AppSql.UpdateLanguage(AppPro);

        Server.Transfer(Request.FilePath);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
}
