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

public partial class Pages_SettingScheduleImport : BasePage
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ImportSettingPro ProCs = new ImportSettingPro();
    ImportSettingSql SqlCs = new ImportSettingSql();

    string MainPer = "Set";
    General GenCs = new General();
    DBFun DBCs = new DBFun();
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            /*** Fill Session ************************************/
            FormSession.FillSession("Settings", pageDiv);
            /*** Fill Session ************************************/

            if (!IsPostBack)
            {
                /*** Common Code ************************************/
                BtnStatus("100");
                UIEnabled(false);
                /*** Common Code ************************************/

                Populate();
            }
        }
        catch (Exception ex) { }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Populate()
    {
        DataTable DT = DBCs.FetchData(new SqlCommand(" SELECT * FROM ImportSetting "));
        if (!DBCs.IsNullOrEmpty(DT))
        {
            chkIpsSaveTransInFile.Checked = Convert.ToBoolean(DT.Rows[0]["IpsSaveTransInFile"]);
            chkIpsEncryptTransInFile.Checked = Convert.ToBoolean(DT.Rows[0]["IpsEncryptTransInFile"]);
            chkIpsRunProcess.Checked = Convert.ToBoolean(DT.Rows[0]["IpsRunProcess"]);

            ShowProcess(chkIpsRunProcess.Checked);

            ucImportTimes.FillTimes(DT.Rows[0]["IpsImportScheduleTimes"].ToString());
            ucProcessTimes.FillTimes(DT.Rows[0]["IpsProcessScheduleTimes"].ToString());
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

    /*#############################################################################################################################*/
    /*#############################################################################################################################*/
    #region DataItem Events

    public void UIEnabled(bool pStatus)
    {
        chkIpsSaveTransInFile.Enabled = pStatus;
        chkIpsEncryptTransInFile.Enabled = pStatus;
        chkIpsRunProcess.Enabled = pStatus;
        ucImportTimes.Enabled(pStatus);
        ucProcessTimes.Enabled(pStatus);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void FillPropeties()
    {
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            ProCs.IpsSaveTransInFile = chkIpsSaveTransInFile.Checked;
            ProCs.IpsEncryptTransInFile = chkIpsEncryptTransInFile.Checked;
            ProCs.IpsRunProcess = chkIpsRunProcess.Checked;
            ProCs.IpsImportScheduleTimes = ucImportTimes.getTimes();

            if (!chkIpsRunProcess.Checked) { ProCs.IpsProcessScheduleTimes = ucProcessTimes.getTimes(); }

            ProCs.TransactionBy = FormSession.LoginID;
        }
        catch (Exception Ex) { MessageFun.ShowAdminMsg(this, Ex.Message); }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void ShowProcess(bool pStatus)
    {
        divProcess1.Visible = false;
        divProcess2.Visible = false;
        ucProcessTimes.isValid(false);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void chkIpsRunProcess_CheckedChanged(object sender, EventArgs e)
    {
        ShowProcess(chkIpsRunProcess.Checked);
    }

    #endregion
    /*#############################################################################################################################*/
    /*#############################################################################################################################*/

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*#############################################################################################################################*/
    /*#############################################################################################################################*/
    #region ButtonAction Events

    protected void btnModify_Click(object sender, EventArgs e)
    {
        ViewState["CommandName"] = "EDIT";
        UIEnabled(true);
        BtnStatus("011");
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //if (!CtrlCs.PageIsValid(this, vsSave)) { return; }
            if (!Page.IsValid) { return; }

            FillPropeties();
            SqlCs.InsertUpdate(ProCs);

            TaskSchedulerFun SF = new TaskSchedulerFun();
            SF.CreateScheduled(ProCs.IpsImportScheduleTimes, ProCs.IpsProcessScheduleTimes, ProCs.IpsRunProcess);

            UIEnabled(false);
            BtnStatus("100");

            Populate();
            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Setting save successfully", "تم حفظ البيانات بنجاح"));
        }
        catch (Exception Ex) { MessageFun.ShowAdminMsg(this, Ex.Message); }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        BtnStatus("100");
        UIEnabled(false);
        Populate();
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void BtnStatus(string pBtn) //string pBtn = [ADD,Modify,Save,Cancel]
    {
        if (FormSession.PermUsr.Contains("U" + MainPer)) { btnModify.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[0].ToString())); } else { btnModify.Enabled = false; }

        btnSave.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[1].ToString()));
        btnCancel.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[2].ToString()));
    }

    #endregion
    /*#############################################################################################################################*/
    /*#############################################################################################################################*/

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*#############################################################################################################################*/
    /*#############################################################################################################################*/
    #region Custom Validate Events
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void ShowMsg_ServerValidate(Object source, ServerValidateEventArgs e) { e.IsValid = false; }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion
    /*#############################################################################################################################*/
    /*#############################################################################################################################*/

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}