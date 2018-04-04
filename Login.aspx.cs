using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    DataTable dt;
    DateFun DTCs = new DateFun();
    DBFun DBCs = new DBFun();
    LicDf LCD = new LicDf();
    General Gens = new General();
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_PreInit(object sender, EventArgs e) 
    {
        Session["MetroStyle"] = "";
        string Applang = Session["Language"] != null ? Applang = Session["Language"].ToString() : Applang = Gens.getAppLanguage();
        Page.Theme = "Theme" + Applang;
        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(General.getCulture(Applang));
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e) 
    {
        //string ss = CryptorEngine.Encrypt("DF", true);
        /*** Check Version ********************************************/
        Session["ActiveVersion"] = LCD.FindActiveVersion(); // 
        /******************************************************************/

        Image1.ImageUrl = Page.ResolveUrl("~/images/Logo_" + Session["ActiveVersion"].ToString() + ".png");
        Image2.ImageUrl = Page.ResolveUrl("~/images/LoginLogo_" + Session["ActiveVersion"].ToString() + ".png");
        Image3.ImageUrl = Page.ResolveUrl("~/images/LogoEn_" + Session["ActiveVersion"].ToString() + ".png");
        Image4.ImageUrl = Page.ResolveUrl("~/images/LoginLogoEn_" + Session["ActiveVersion"].ToString() + ".png");

        /*** Check Connect ********************************************/
        if (!DBCs.isConnect()) { MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("No connection to the database", "لا يوجد اتصال بقاعدة البيانات")); return; }
        /******************************************************************/

        /*** Check License ********************************************/
        if (LCD.FetchLic("LC") != "1") { MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("There is no License to use this Application", "لا يوجد ترخيص لإستخدام هذا البرنامج")); return; }
        /******************************************************************/

        if (!IsPostBack) { txtLoginID.Text = txtPassword.Attributes["value"] = "admin"; }

        txtLoginID.Focus();

        if (Session["Language"] != null) { pageDiv.Attributes.Add("dir", General.getDir(Session["Language"].ToString())); }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected string getwidth() 
    {
        if (Session["Language"] != null) { if (Session["Language"].ToString() == "Ar") { return "15%"; } }
        return "25%";
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            dt = DBCs.FetchData(" SELECT * FROM ApplicationSetup");
            if (!DBCs.IsNullOrEmpty(dt))
            {
                if (dt.Rows[0]["AppCalendar"].ToString() == "H") { Session["DateFormat"] = "Hijri"; } else { Session["DateFormat"] = "Gregorian"; }
            }
            UserLogin();
        }
        catch (Exception e1)
        {
            DBCs.InsertError("Login.aspx", "btnLogin");
            
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void UserLogin()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        string loginDate = DateTime.Now.ToString("dd/MM/yyyy");
        Session["Permissions"] = null;
        StringBuilder Q = new StringBuilder();
        Q.Append("SELECT * FROM AppUsers WHERE UsrStatus = '1' AND UsrLoginID = @P1 ");
        if (txtLoginID.Text != "admin") { Q.Append(" AND GETDATE() BETWEEN UsrStartDate AND UsrExpireDate "); }
        DataTable dt = DBCs.FetchData(Q.ToString(), new string[] { txtLoginID.Text });
        if (!DBCs.IsNullOrEmpty(dt))
        {
            if (dt.Rows[0]["UsrPassword"].ToString() == txtPassword.Text) //CryptorEngine.Decrypt("", true)
            {
                try
                {
                    Session["UserName"]        = txtLoginID.Text;
                    Session["Permissions"]     = CryptorEngine.Decrypt(dt.Rows[0]["UsrPermission"].ToString(), true);
                    //Session["Permissions"] = dt.Rows[0]["UsrPermission"].ToString();
                    Session["PreferedCulture"] = "en-US";
                    Session["Language"]        = dt.Rows[0]["UsrLanguage"].ToString();
                    Session["Role"]            = "User";
                    Session["MyTheme"]         = "Theme" + Session["Language"].ToString();
                    //if (dt.Rows[0]["UsrDepartments"] != DBNull.Value) { Session["DepartmentList"] = CryptorEngine.Decrypt(dt.Rows[0]["UsrDepartments"].ToString(), true); } else { Session["UsrDepartments"] = ""; }
                    if (dt.Rows[0]["UsrDepartments"] != DBNull.Value) { Session["DepartmentList"] = dt.Rows[0]["UsrDepartments"].ToString(); } else { Session["UsrDepartments"] = ""; }

                    //string url = InfoTab.FindFirstTab(); //@"~/pages/SettingMachine.aspx"; //MachinePing.aspx"; //InfoTab.FindFirstTab(); //@"~/pages/MachinePing.aspx";//
                    //if (!string.IsNullOrEmpty(url)) { Response.Redirect(url, false); }
                    try { Response.Redirect("~/pages/Home.aspx", false); }
                    catch { MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("You do not have access,Please contact the Administrator", "لا يمكنك الدخول,الرجاء مراجعة مدير النظام")); }
                    //else
                    //{
                    //    MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("Wrong User Name Or Password", "لا يمكنك الدخول,الرجاء مراجعة مدير النظام"));
                    //}
                    return;
                }
                catch (Exception e1)
                {
                    DBCs.InsertError("Login.aspx", "UserLogin");
                }
            }
        }

        MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("Couldn't find your inserted data please check it again", "لا يمكننا الحصول على البيانات المدخله الرجاء التأكد من البيانات المدخله")); 
    } 
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*******************************************************************************************************************************/
    /*******************************************************************************************************************************/ 
    #region Custom Validate Events
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void ShowMsg_ServerValidate(Object source, ServerValidateEventArgs e) { e.IsValid = false; }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion
    /*******************************************************************************************************************************/
    /*******************************************************************************************************************************/

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
