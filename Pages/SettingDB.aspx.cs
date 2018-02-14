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
using System.Collections.Generic;

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
            GetFields();
            PopulateUI(MainQuery);

            //if (Session["GetColumns"] == null) { Session["GetColumns"] = "NotUpdate"; }

            //if (Session["GetColumns"].ToString() == "Update")
            //{
            //    GetFields();
            //    Session["GetColumns"] = "NotUpdate";
            //}
            //else { }
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void FillDDLs(DataTable dt)
    {
        FormCtrl.PopulateDDL(ddlEmpField, dt, "name", "name", General.Msg("-Select Column-", "-اختر الحقل-"));
        FormCtrl.PopulateDDL(ddlDateField, dt, "name", "name", General.Msg("-Select Column-", "-اختر الحقل-"));
        FormCtrl.PopulateDDL(ddlInOutField, dt, "name", "name", General.Msg("-Select Column-", "-اختر الحقل-"));
        FormCtrl.PopulateDDL(ddlLocationField, dt, "name", "name", General.Msg("-Select Column-", "-اختر الحقل-"));
        FormCtrl.PopulateDDL(ddlMachineIdField, dt, "name", "name", General.Msg("-Select Column-", "-اختر الحقل-"));
        FormCtrl.PopulateDDL(ddlTimeField, dt, "name", "name", General.Msg("-Select Column-", "-اختر الحقل-"));


        //int i = 0;
        //foreach (DataColumn column in ds.Tables[0].Columns)
        //{
        //    ListItem lst = new ListItem(column.ColumnName, column.ColumnName);

        //    ddlEmpField.Items.Insert(i, lst);
        //    ddlDateField.Items.Insert(i, lst);
        //    ddlInOutField.Items.Insert(i, lst);
        //    ddlLocationField.Items.Insert(i, lst);
        //    ddlMachineIdField.Items.Insert(i, lst);
        //    ddlTimeField.Items.Insert(i, lst);

        //    //ddlDateField.DataSource = ds.Tables[0];
        //    //ddlDateField.DataTextField = ds.Tables[0].Columns.ToString();

        //    //ddlEmpField.DataSource = ds.Tables[0];
        //    //ddlEmpField.DataTextField = ds.Tables[0].Columns.ToString();

        //    //ddlInOutField.DataSource = ds.Tables[0];
        //    //ddlInOutField.DataTextField = ds.Tables[0].Columns.ToString();

        //    //ddlLocationField.DataSource = ds.Tables[0];
        //    //ddlLocationField.DataTextField = ds.Tables[0].Columns.ToString();

        //    //ddlMachineIdField.DataSource = ds.Tables[0];
        //    //ddlMachineIdField.DataTextField = ds.Tables[0].Columns.ToString();

        //    //ddlTimeField.DataSource = ds.Tables[0];
        //    //ddlTimeField.DataTextField = ds.Tables[0].Columns.ToString();

        //    i++;
        //}
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void GetFields()
    {
        dt = DBCs.FetchData(MainQuery);
        if (!DBCs.IsNullOrEmpty(dt))
        {
            if (string.IsNullOrEmpty(dt.Rows[0]["DBServer"].ToString())){ return; }
            else
            {
                try
                {
                    string strDB = "; Initial Catalog = " + dt.Rows[0]["DBName"].ToString();
                    string strUser = "; User ID = " + dt.Rows[0]["DBUsername"].ToString();
                    string strPass = "; PassWord = " + dt.Rows[0]["DBPassword"].ToString();
                    string strConn = "Data Source=" + dt.Rows[0]["DBServer"].ToString() + strDB + strUser + strPass;

                    string sTableName = dt.Rows[0]["TableName"].ToString();

                    DataTable dsFields = DBCs.GetFields(strConn, sTableName);

                    FillDDLs(dsFields);
                }
                catch { }
            }
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
                ddlDateField.SelectedItem.Text = dt.Rows[0]["DateField"].ToString();
                ddlEmpField.SelectedItem.Text = dt.Rows[0]["EmployeeField"].ToString();
                ddlInOutField.SelectedItem.Text = dt.Rows[0]["InOutField"].ToString();
                ddlLocationField.SelectedItem.Text = dt.Rows[0]["LocationField"].ToString();
                ddlMachineIdField.SelectedItem.Text = dt.Rows[0]["MachineIdField"].ToString();
                ddlTimeField.SelectedItem.Text = dt.Rows[0]["TimeField"].ToString();

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

            ProClass.EmployeeField = ddlEmpField.SelectedValue;
            ProClass.DateField = ddlDateField.SelectedValue;
            ProClass.TimeField = ddlTimeField.SelectedValue;
            ProClass.InOutField = ddlInOutField.SelectedValue;
            ProClass.MachineIdField = ddlMachineIdField.SelectedValue;
            ProClass.LocationField = ddlLocationField.SelectedValue;
            ProClass.SchemaName = txtSchemaName.Text;

            ProClass.TransactionBy = FormSession.LoginID;
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearData()
    {
        ddlEmpField.SelectedIndex = -1;
        ddlDateField.SelectedIndex = -1;
        ddlTimeField.SelectedIndex = -1;
        ddlInOutField.SelectedIndex = -1;
        ddlMachineIdField.SelectedIndex = -1;
        ddlLocationField.SelectedIndex = -1;
        txtSchemaName.Text = "";

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
        MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Save added successfully", "تم حفظ البيانات بنجاح "));
        //else { MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("Please Fill All Records", "خطأ في ادخال البيانات ")); }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnConnDB_Click(object sender, EventArgs e)
    {
        //lblNamePopup.Text = General.Msg("Connection Setting", "اعداد قاعدة البيانات");
        //ifrmPopup.Attributes.Add("src", "CusConnString.aspx");

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "showPopup('');", true);
        Response.Redirect("~/pages/ExportDB.aspx", false);
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
    protected void ShowMsg_ServerValidate(Object source, ServerValidateEventArgs e) { e.IsValid = false; } //e.IsValid = false; 
                                                                                                           /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                                                                                           /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
}