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

public partial class ChangePass : BasePage
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    DataTable dt;

    AppUsersPro ProClass = new AppUsersPro();
    AppUsersSql SqlClass = new AppUsersSql();
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        //--Common Code----------------------------------------------------------------- //
        FormSession.FillSession("Home",pageDiv);
        //--Common Code----------------------------------------------------------------- //

        if (!string.IsNullOrEmpty(txtCurrentPass.Text)) { ViewState["CurrentPass"] = txtCurrentPass.Text; }
        if (ViewState["CurrentPass"] != null) { txtCurrentPass.Attributes["value"] = ViewState["CurrentPass"].ToString(); }

        if (!string.IsNullOrEmpty(txtNewPass.Text)) { ViewState["NewPass"] = txtNewPass.Text; }
        if (ViewState["NewPass"] != null) { txtNewPass.Attributes["value"] = ViewState["NewPass"].ToString(); }

        if (!string.IsNullOrEmpty(txtConfirmPass.Text)) { ViewState["ConfirmPass"] = txtConfirmPass.Text; }
        if (ViewState["ConfirmPass"] != null) { txtConfirmPass.Attributes["value"] = ViewState["ConfirmPass"].ToString(); }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
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


            ProClass.UsrLoginID  = FormSession.LoginID;
            ProClass.UsrPassword = txtNewPass.Text;

            SqlClass.UpdatePassword(ProClass);

            ClearUI();

            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Password updated successfully", "تم تعديل كلمة المرور بنجاح"));
        }
        catch (Exception Ex)
        {
            MessageFun.ShowAdminMsg(this, Ex.Message);
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void ClearUI()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        ViewState["CurrentPass"] = null;
        txtCurrentPass.Attributes["value"] = null;

        ViewState["NewPass"] = null;
        txtNewPass.Attributes["value"] = null;

        ViewState["ConfirmPass"] = null;
        txtConfirmPass.Attributes["value"] = null;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    /*####################################################################################################################################*/
    /*####################################################################################################################################*/
    #region Custom Validate Events
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void ShowMsg_ServerValidate(Object source, ServerValidateEventArgs e) { e.IsValid = false; }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Pass_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        try
        {
            if (source.Equals(cvCurrentPass))
            {
                if (string.IsNullOrEmpty(txtCurrentPass.Text))
                {
                    MessageFun.ValidMsg(this, ref cvCurrentPass, false, General.Msg("Current Password is required", "كلمة المرور الحالية مطلوبة"));
                    e.IsValid = false;
                    return;
                }
                else
                {
                    dt = DBFun.FetchData("SELECT UsrPassword FROM AppUsers WHERE UsrLoginID = '" + FormSession.LoginID + "'");

                    if (!DBFun.IsNullOrEmpty(dt)) 
                    {
                        if (dt.Rows[0][0].ToString() != txtCurrentPass.Text) 
                        { 
                            MessageFun.ValidMsg(this, ref cvCurrentPass, true, General.Msg("The Current password is incorrect", "كلمة المرور الحالية غير صحيحة"));
                            e.IsValid = false;
                            return;
                        }
                    }
                }
            }

            if (source.Equals(cvNewPass))
            {
                if (string.IsNullOrEmpty(txtNewPass.Text))
                {
                    MessageFun.ValidMsg(this, ref cvNewPass, false, General.Msg("New Password is required", "كلمة المرور الجديدة مطلوبة"));
                    e.IsValid = false;
                    return;
                }
            }

            if (source.Equals(cvConfirmPass))
            {
                if (string.IsNullOrEmpty(txtConfirmPass.Text))
                {
                    MessageFun.ValidMsg(this, ref cvConfirmPass, false, General.Msg("Confirm Password is required", " تأكيد كلمة المرور مطلوبة"));
                    e.IsValid = false;
                    return;
                }
                else
                {   
                    if (!string.IsNullOrEmpty(txtNewPass.Text) && txtNewPass.Text != txtConfirmPass.Text) 
                    {
                        MessageFun.ValidMsg(this, ref cvConfirmPass, true, General.Msg("Password and Confirm Password must be same", "كلمة المرور وتأكيد كلمة المرور غير متطابقتين"));
                        e.IsValid = false;
                        return;
                    }
                }
            }


        }
        catch { e.IsValid = false; }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion
    /*####################################################################################################################################*/
    /*####################################################################################################################################*/
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////   
}
