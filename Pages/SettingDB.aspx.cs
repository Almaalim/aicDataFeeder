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

public partial class Pages_SettingDB : BasePage
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    DataTable dt;
    DBFun DBCs = new DBFun();

    DBSettingPro ProClass = new DBSettingPro();
    DBSettingSql SqlClass = new DBSettingSql();

    string MainQuery = "SELECT * FROM DatabaseImport ";
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

            dt = DBCs.FetchData(Query);
            if (!DBCs.IsNullOrEmpty(dt))
            {
                txtTableName.Text       = dt.Rows[0]["TableName"].ToString();
                txtEmpField.Text        = dt.Rows[0]["EmployeeField"].ToString();
                txtDateField.Text       = dt.Rows[0]["DateField"].ToString();
                txtTimeField.Text       = dt.Rows[0]["TimeField"].ToString();
                txtInOutField.Text      = dt.Rows[0]["InOutField"].ToString();
                txtMachineIdField.Text  = dt.Rows[0]["MachineIdField"].ToString();
                txtLocationField.Text   = dt.Rows[0]["LocationField"].ToString();
                txtSchemaName.Text      = dt.Rows[0]["SchemaName"].ToString();
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

            ProClass.TableName = txtTableName.Text;
            ProClass.EmployeeField = txtEmpField.Text;
            ProClass.DateField = txtDateField.Text;
            ProClass.TimeField = txtTimeField.Text;
            ProClass.InOutField = txtInOutField.Text;
            ProClass.MachineIdField = txtMachineIdField.Text;
            ProClass.LocationField = txtLocationField.Text;
            ProClass.SchemaName = txtSchemaName.Text;

            ProClass.TransactionBy = FormSession.LoginID;
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearData()
    {
        txtTableName.Text = "";
        txtEmpField.Text = "";
        txtDateField.Text = "";
        txtTimeField.Text = "";
        txtInOutField.Text = "";
        txtMachineIdField.Text = "";
        txtLocationField.Text = "";
        txtSchemaName.Text = "";

        ViewState["CommandName"] = "";
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnSave_Click(object sender, EventArgs e)
    {
       if ( txtTableName.Text != "" || txtEmpField.Text!="" || txtDateField.Text !="" || txtTimeField.Text!="" || txtInOutField.Text !="" || txtMachineIdField.Text !="" || txtLocationField.Text !="" || txtSchemaName.Text !="")
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
            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Database setting Import added successfully", "تم تحديث اعدادات قاعد البيانات بنجاح "));
            }
      
        else
        {
          
            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("Please Fill All Records", "خطأ في ادخال البيانات "));
          
        }
       
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