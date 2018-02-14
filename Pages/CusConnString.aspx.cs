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

public partial class Pages_CusConnString : BasePage
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
        //--Fill Session----------------------------------------------------------------- //
        //FormSession.FillSession("Settings", pageDiv);
        //--Fill Session----------------------------------------------------------------- //

        if (!IsPostBack)
        {
            PopulateUI(MainQuery);
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void imgRefgDB_Click(object sender, ImageClickEventArgs e) { FillDBs(); }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void imgRefTable_Click(object sender, ImageClickEventArgs e) { FillTables(); }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        UIClear();
        //BtnStatus("11");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "Exit();", true);
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ConnectDB()) { MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("please check for entries data connection ", "تأكد من معلومات الإتصال المدخلة")); return; }
            FillPropeties();
            bool ret = SqlClass.UpdateDBConn(ProClass);
            UIClear();
            
            //if (Request.QueryString["ID"] != null)
            //{
                Session["GetColumns"] = "Update";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "hideparentPopupSave('divPopup','SettingDB.aspx');", true);
            //}
            //else
            //{
            //    CtrlCs.ShowMsg(this, vsShowMsg, cvShowMsg, CtrlFun.TypeMsg.Success, "vgShowMsg", General.Msg("Saved data successfully", "تم حفظ البيانات بنجاح"));
            //}
        }
        catch (Exception ex)
        {
            MessageFun.ShowAdminMsg(this, ex.Message);
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void UIClear()
    {
        txtServerName.Text = "";
        txtUserName.Text = "";
        txtUsrPassword.Text = "";
        ddlDBName.SelectedIndex = -1;
        ddlTableName.SelectedIndex = -1;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void FillPropeties()
    {
        ProClass.DBServer = txtServerName.Text;
        ProClass.DBUsername= txtUserName.Text;
        ProClass.DBPassword = txtUsrPassword.Text;
        ProClass.DBName = ddlDBName.SelectedValue;
        ProClass.TableName = ddlTableName.SelectedValue;

        ProClass.TransactionBy = FormSession.LoginID;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void PopulateUI(string Query)
    {
        try
        {
            dt = DBCs.FetchData(Query);
            if (!DBCs.IsNullOrEmpty(dt))
            {
                txtServerName.Text = dt.Rows[0]["DBServer"].ToString();
                txtUserName.Text = dt.Rows[0]["DBUsername"].ToString();
                txtUsrPassword.Text = dt.Rows[0]["DBPassword"].ToString();

                FillDBs();
                FillTables();
                if (!string.IsNullOrEmpty(dt.Rows[0]["DBServer"].ToString()))
                {
                    ddlDBName.SelectedIndex = ddlDBName.Items.IndexOf(ddlDBName.Items.FindByValue(dt.Rows[0]["DBName"].ToString()));
                    ddlTableName.SelectedIndex = ddlTableName.Items.IndexOf(ddlTableName.Items.FindByValue(dt.Rows[0]["TableName"].ToString()));
                }
            }
        }
        catch (Exception Ex) { }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private bool ConnectDB()
    {
        string strPass = "";
        string strDB = "";
        if (!string.IsNullOrEmpty(txtUsrPassword.Text)) { strPass = "; PassWord = " + txtUsrPassword.Text; }
        if (ddlDBName.SelectedIndex > 0) { strDB = "; Initial Catalog = " + ddlDBName.SelectedItem; }
        string strConn = "Data Source=" + txtServerName.Text + strDB + "; User ID = " + txtUserName.Text + strPass;

        SqlConnection connection = new SqlConnection(strConn);
        try
        {
            using (connection)
            {
                connection.Open();
                return true;
            }
        }
        catch { return false; }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void FillDBs()
    {
        if (!string.IsNullOrEmpty(txtServerName.Text) && !string.IsNullOrEmpty(txtUserName.Text))
        {
            string strPass = "";
            if (!string.IsNullOrEmpty(txtUsrPassword.Text)) { strPass = "; PassWord = " + txtUsrPassword.Text; }
            string strConn = "Data Source=" + txtServerName.Text + "; User ID = " + txtUserName.Text + strPass;
            SqlConnection sqlConn = new SqlConnection(strConn);

            try
            {
                using (sqlConn)
                {
                    sqlConn.Open();
                    SqlCommand SqlCom = new SqlCommand("sp_databases", sqlConn);
                    SqlCom.CommandType = CommandType.StoredProcedure;

                    SqlDataReader SqlDR;
                    SqlDR = SqlCom.ExecuteReader();
                    ddlDBName.Items.Clear();
                    while (SqlDR.Read()) { ddlDBName.Items.Add(SqlDR.GetString(0)); }
                    sqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                sqlConn.Close();
                ddlDBName.Items.Clear();
            }
        }
        else { ddlDBName.Items.Clear(); }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void FillTables()
    {
        if (!string.IsNullOrEmpty(txtServerName.Text) && !string.IsNullOrEmpty(txtUserName.Text))
        {
            try
            {
                string strPass = "";
                string strDB = "";
                if (!string.IsNullOrEmpty(txtUsrPassword.Text)) { strPass = "; PassWord = " + txtUsrPassword.Text; }
                if (ddlDBName.SelectedIndex > 0) { strDB = "; Initial Catalog = " + ddlDBName.SelectedItem; }
                string strConn = "Data Source=" + txtServerName.Text + strDB + "; User ID = " + txtUserName.Text + strPass;

                List<string> TableNames = DisplayFun.GetTables(strConn);

                int i = 0;
                foreach (string sItim in TableNames)
                {
                    
                    ListItem lst = new ListItem(sItim, sItim);
                    ddlTableName.Items.Insert(i, lst);
                    i++;
                }
            }
            catch
            {
                ddlTableName.Items.Clear();
            }
        }
        else { ddlTableName.Items.Clear(); }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region Custom Validate Events
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void ShowMsg_ServerValidate(Object source, ServerValidateEventArgs e) { } //e.IsValid = false; 
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
}