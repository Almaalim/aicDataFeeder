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
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

public partial class Pages_EmailSetting : BasePage
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    DataTable dt;

    EmailSettingPro ProClass = new EmailSettingPro();
    EmailSettingSql SqlClass = new EmailSettingSql();

    string MainQuery = "SELECT * FROM EmailSetting ";
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        //--Common Code----------------------------------------------------------------- //
        FormSession.FillSession("Settings", pageDiv);
        //--Common Code----------------------------------------------------------------- //

        if (!IsPostBack)
        {
            PopulateUI(MainQuery);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void PopulateUI(string Query)
    {
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            dt = DBFun.FetchData(Query);
            if (!DBFun.IsNullOrEmpty(dt))
            {
                txtEmailServer.Text     = dt.Rows[0]["EmailServer"].ToString();
                txtEmailPort.Text       = dt.Rows[0]["EmailPort"].ToString();
                txtSendEmailFrom.Text   = dt.Rows[0]["EmailSender"].ToString();
                txtPassword.Text        = dt.Rows[0]["EmailPassword"].ToString();
            }
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void FillPropeties()
    {
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            ProClass.DateType = FormSession.DateType;

            ProClass.EmlServerID = txtEmailServer.Text;
            ProClass.EmlPortNo = txtEmailPort.Text;
            ProClass.EmlSenderEmail = txtSendEmailFrom.Text;
            ProClass.EmlSenderPassword = txtPassword.Text;

            ProClass.TransactionBy = FormSession.LoginID;
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearData()
    {
        txtEmailServer.Text = "";
        txtEmailPort.Text = "";
        txtSendEmailFrom.Text = "";
        txtPassword.Text = "";

        ViewState["CommandName"] = "";
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            ValidatorCollection ValidatorColl = Page.Validators;
            for (int k = 0; k < ValidatorColl.Count; k++)
            {
                if (!ValidatorColl[k].IsValid && !String.IsNullOrEmpty(ValidatorColl[k].ErrorMessage)) { vsSave.ShowSummary = true; return; }
                vsSave.ShowSummary = false;
            }
            return;
        }

        FillPropeties();
        SqlClass.InsertUpdate(ProClass);

        MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Database setting Import added successfully", "تم تحديث اعدادات البريد الالكتروني بنجاح "));

    }
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region Custom Validate Events
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void ShowMsg_ServerValidate(Object source, ServerValidateEventArgs e) { e.IsValid = false; }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
}