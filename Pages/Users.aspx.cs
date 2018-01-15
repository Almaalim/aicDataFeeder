using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Text;

public partial class Pages_Users : BasePage
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    DataTable dt;
    AppUsersPro ProClass = new AppUsersPro();
    AppUsersSql SqlClass = new AppUsersSql();
    DBFun DBCs = new DBFun();
    DateFun DTCs = new DateFun();

    string MainPer   = "Usr";
    string MainQuery = " SELECT * FROM AppUsers WHERE UsrLoginID = UsrLoginID ";
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        //--Common Code----------------------------------------------------------------- //
        FormSession.FillSession("Users", pageDiv);
        FormCtrl.RefreshGridEmpty(ref grdData, 20, "No Data Found", "لا توجد بيانات");
        //--Common Code----------------------------------------------------------------- //

        if (!string.IsNullOrEmpty(txtUsrPassword.Text)) { ViewState["Pass"] = txtUsrPassword.Text; }
        if (ViewState["Pass"] != null) { txtUsrPassword.Attributes["value"] = ViewState["Pass"].ToString(); }

        if (!IsPostBack)
        {
            btnAdd.Enabled = FormSession.PermUsr.Contains("I" + MainPer);
            pnlSearch.Enabled = grdData.Enabled = FormSession.PermUsr.Contains("V" + MainPer);
            FillGrid(MainQuery);

            DataItemStatus(false);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region DataItem Events

    public void DataItemStatus(bool pStatus)
    {
        txtUsrLoginID.Enabled = pStatus;
        txtUsrPassword.Enabled = pStatus;
        txtUsrFullName.Enabled = pStatus;
        txtUsrEmail.Enabled = pStatus;
        calUsrStartDate.SetEnabled(pStatus);
        calUsrExpiryDate.SetEnabled(pStatus);
        ddlUsrStatus.Enabled = pStatus;
        ddlUsrLang.Enabled = pStatus;
        txtUsrDescription.Enabled = pStatus;
        PermCtl.EnablePermissions(pStatus, true);
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void FillPropeties()
    {
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            ProClass.DateType = FormSession.DateType;
            ProClass.UsrLoginID = txtUsrLoginID.Text;
            ProClass.UsrPassword = txtUsrPassword.Text;
            if (!string.IsNullOrEmpty(txtUsrFullName.Text)) { ProClass.UsrFullName = txtUsrFullName.Text; }
            if (ddlUsrStatus.SelectedIndex > 0) { ProClass.UsrStatus = Convert.ToBoolean(Convert.ToInt16(ddlUsrStatus.SelectedValue)); }
            if (!string.IsNullOrEmpty(txtUsrDescription.Text)) { ProClass.UsrDescription = txtUsrDescription.Text; }
            ProClass.UsrEmailID = txtUsrEmail.Text;
            ProClass.UsrLanguage = ddlUsrLang.SelectedValue;
            ProClass.UsrPermission = CryptorEngine.Encrypt(PermCtl.getPermissions(), true);
            ProClass.UsrStartDate = calUsrStartDate.getGDateDBFormat();
            ProClass.UsrExpiryDate = calUsrExpiryDate.getGDateDBFormat();

            ProClass.TransactionBy = FormSession.LoginID;
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearData()
    {
        txtUsrLoginID.Text = "";
        txtUsrPassword.Attributes["value"] = "";
        txtUsrFullName.Text = "";
        ddlUsrStatus.SelectedIndex = -1;
        ddlUsrLang.SelectedIndex = -1;
        txtUsrEmail.Text = "";
        txtUsrDescription.Text = "";
        ViewState["CommandName"] = "";
        calUsrStartDate.ClearDate();
        calUsrExpiryDate.ClearDate();
        PermCtl.Clear();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearItem()
    {
        grdData.SelectedIndex = -1;
        FillInfoLabel("", "");
        DataItemStatus(false);
        ButtonAction(true, "10000");
        ClearData();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string getStatus(object pValue)
    {
        if (pValue != null)
        { 
            if (pValue.ToString() == "True" )  { return General.Msg("Active", "فعال"); }
            if (pValue.ToString() == "False" ) { return General.Msg("InActive", "غير فعال"); }
        }
        
        return null;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region SearchItem Events

    public void SearchItemStatus(bool pBtn, bool pFiltered, string pTxtMark)
    {
        btnSearch.Enabled = pBtn;
        txtSearch.Enabled = pBtn;
        eWatermarkSearch.WatermarkText = pTxtMark;
        eFilteredSearch.Enabled = pFiltered;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSearch.Text = "";

        if (ddlSearch.SelectedValue == "[none]")
        {
            SearchItemStatus(false, false, "can't type");
            Search();
        }
        else
        {
            if (ddlSearch.SelectedValue == "UsrLoginID") { SearchItemStatus(true, false, "Type User ID here"); }
            else if (ddlSearch.SelectedValue == "UsrFullName") { SearchItemStatus(true, false, "Type User Name here"); }

            ClearItem();
            FillGrid(MainQuery + " AND UsrLoginID = '@@@@'");
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlSearch.SelectedIndex > 0)
        {
            if (!Page.IsValid) { return; }
            ClearItem();
        }

        Search();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Search()
    {
        StringBuilder SQ = new StringBuilder();
        SQ.Append(MainQuery);
        if (ddlSearch.SelectedIndex > 0)
        {
            if (ddlSearch.SelectedValue == "UsrLoginID") { SQ.Append(" AND UsrLoginID = '" + txtSearch.Text + "'"); }
            if (ddlSearch.SelectedValue == "UsrFullName") { SQ.Append(" AND UsrFullName LIKE '%" + txtSearch.Text + "%'"); }
        }

        FillGrid(SQ.ToString());
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearSearch()
    {
        txtSearch.Text = "";
        ddlSearch.SelectedIndex = -1;
    }

    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region ButtonAction Events

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

        try
        {
            FillPropeties();

            if (ViewState["CommandName"].ToString() == "Add")
            {
                SqlClass.Insert(ProClass);
                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("User added successfully", "تمت إضافة المستخدم بنجاح"));
            }

            if (ViewState["CommandName"].ToString() == "Edit")
            {
                SqlClass.Update(ProClass);
                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("User updated successfully", "تم تعديل المستخدم بنجاح"));
            }

            ClearItem();
            Search();
        }
        catch (Exception Ex) { MessageFun.ShowAdminMsg(this, Ex.Message); }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ClearItem();
        DataItemStatus(true);
        ButtonAction(false, "00011");
        ViewState["CommandName"] = "Add";
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        ViewState["CommandName"] = "Edit";
        DataItemStatus(true);
        txtUsrLoginID.Enabled = false;
        if (txtUsrLoginID.Text == "admin" || txtUsrLoginID.Text == FormSession.LoginID)
        {
            //ddlUsrStatus.Enabled = false; cblUsr.Enabled = false; cblDep.Enabled = false; cblEmp.Enabled = false; cblStd.Enabled = false; cblRep.Enabled = false;
        }

        ButtonAction(false, "00011");
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (txtUsrLoginID.Text == "admin")
        {
            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("You can not delete a User : system administrator", "لا يمكن حذف المستخدم : مدير النظام"));
            return;
        }

        if (txtUsrLoginID.Text == FormSession.LoginID)
        {
            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("You can not delete the current user of the system", "لا يمكن حذف المستخدم الحالي للنظام"));
            return;
        }

        string Q = " SELECT LogTransactionBy FROM TransactionLog WHERE LogTransactionBy = '" + txtUsrLoginID.Text + "' ";

        dt = DBCs.FetchData(Q);
        if (!DBCs.IsNullOrEmpty(dt))
        {
            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("Deletion can not because of the presence of related records", "لا يمكن الحذف بسبب وجود سجلات مرتبطة"));
        }
        else
        {
            FillPropeties();
            SqlClass.Delete(ProClass);
            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("User deleted successfully", "تم حذف المستخدم بنجاح"));

            ClearItem();
            Search();
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ButtonAction(true, "10000");
        DataItemStatus(false);

        if (ViewState["CommandName"].ToString() == "Add") { ClearData(); }
        if (ViewState["CommandName"].ToString() == "Edit") { PopulateData(txtUsrLoginID.Text); }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
    protected void ButtonAction(bool pSearch, string pBtn) //string pBtn = [ADD,Edit,Delete,Save,Cancel]
    {
        if (FormSession.PermUsr.Contains("V" + MainPer)) { pnlSearch.Enabled = pSearch; } else { pnlSearch.Enabled = false; }
        if (FormSession.PermUsr.Contains("V" + MainPer)) { grdData.Enabled = pSearch; } else { grdData.Enabled = false; }

        if (FormSession.PermUsr.Contains("I" + MainPer)) { btnAdd.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[0].ToString())); } else { btnAdd.Enabled = false; }
        if (FormSession.PermUsr.Contains("U" + MainPer)) { btnEdit.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[1].ToString())); } else { btnEdit.Enabled = false; }
        if (FormSession.PermUsr.Contains("D" + MainPer)) { btnDelete.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[2].ToString())); } else { btnDelete.Enabled = false; }

        btnCancel.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[3].ToString()));
        btnSave.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[4].ToString()));
    }

    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region GridView Events

    protected void grdData_DataBound(object sender, EventArgs e) { }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdData_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gridrow = grdData.SelectedRow;
            if (FormCtrl.isGridEmpty(gridrow.Cells[0].Text))
            {
                FormCtrl.FillGridEmpty(ref grdData, 20, "No Data Found", "لا توجد بيانات");
            }
            else
            {
                PopulateData(gridrow.Cells[1].Text);
            }
        }
        catch (Exception e1) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void PopulateData(string pID)
    {
        try
        {
            dt = DBCs.FetchData(MainQuery + " AND UsrLoginID = '" + pID + "'");
            if (DBCs.IsNullOrEmpty(dt)) { return; }
            txtUsrLoginID.Text = dt.Rows[0]["UsrLoginID"].ToString();
            txtUsrPassword.Attributes["value"] = dt.Rows[0]["UsrPassword"].ToString();
            txtUsrFullName.Text = dt.Rows[0]["UsrFullName"].ToString();
            
            calUsrStartDate.SetGDate(dt.Rows[0]["UsrStartDate"], "S");
            calUsrExpiryDate.SetGDate(dt.Rows[0]["UsrExpiryDate"], "S");

            ddlUsrStatus.SelectedIndex = ddlUsrStatus.Items.IndexOf(ddlUsrStatus.Items.FindByValue(Convert.ToInt16(dt.Rows[0]["UsrStatus"]).ToString()));
            ddlUsrLang.SelectedIndex = ddlUsrLang.Items.IndexOf(ddlUsrLang.Items.FindByValue(dt.Rows[0]["UsrLanguage"].ToString()));
            txtUsrEmail.Text = dt.Rows[0]["UsrEmailID"].ToString();
            txtUsrDescription.Text = dt.Rows[0]["UsrDescription"].ToString();
            
            PermCtl.PopulatePermissions(CryptorEngine.Decrypt(dt.Rows[0]["UsrPermission"].ToString(), true), txtUsrLoginID.Text);
            
            ButtonAction(true, "11100");
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void FillGrid(string Q)
    {
        dt = DBCs.FetchData(Q);
        if (!DBCs.IsNullOrEmpty(dt) && FormSession.PermUsr.Contains("V" + MainPer)) //
        {
            grdData.DataSource = (DataTable)dt;
            grdData.DataBind();
        }
        else
        {
            FormCtrl.FillGridEmpty(ref grdData, 20, "No Data Found", "لا توجد بيانات");
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdData_RowDataBound(object sender, GridViewRowEventArgs e) { FormCtrl.GridSelectedRow(this, this.grdData, e.Row); }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void FillInfoLabel(string pID, string pName)
    {
        if (string.IsNullOrEmpty(pID) == false) { pID = "              ID : " + pID + "-----------"; }
        if (string.IsNullOrEmpty(pName) == false) { pName = "            Name : " + pName + "           "; }

        epnlData.CollapsedText = pID + pName + "(Show Details...)";
        epnlData.ExpandedText = pID + pName + "(Hide Details)";
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdData.PageIndex = e.NewPageIndex;
        ClearItem();
        Search();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdData_Sorting(object sender, GridViewSortEventArgs e)
    {
        ClearItem();

        //string sortExpression = e.SortExpression;

        //if (GridViewSortDirection == SortDirection.Ascending)
        //{
        //    GridViewSortDirection = SortDirection.Descending;
        //    SortGridView(sortExpression, DESCENDING);
        //}
        //else
        //{
        //    GridViewSortDirection = SortDirection.Ascending;
        //    SortGridView(sortExpression, ASCENDING); 
        //}   
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdData_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            e.Row.Cells[0].Visible = false;
        }
        catch { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region Custom Validate Events
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void ShowMsg_ServerValidate(Object source, ServerValidateEventArgs e) { } //e.IsValid = false;
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void DateValidate_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        try
        {
            if (source.Equals(cvCompareDates))
            {
                if (!String.IsNullOrEmpty(calUsrStartDate.getGDateDBFormat()) && !String.IsNullOrEmpty(calUsrExpiryDate.getGDateDBFormat()))
                {
                    int iStartDate = DTCs.ConvertDateTimeToInt(FormSession.DateType, calUsrStartDate.getGDateDBFormat());
                    int iEndDate = DTCs.ConvertDateTimeToInt(FormSession.DateType, calUsrExpiryDate.getGDateDBFormat());
                    if (iStartDate > iEndDate) { e.IsValid = false; } else { e.IsValid = true; }
                }
            }
        }
        catch { e.IsValid = false; }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    protected void UsrLoginID_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        try
        {
            if (source.Equals(cvUsrLoginID))
            {
                if (string.IsNullOrEmpty(txtUsrLoginID.Text))
                {
                    General.ValidMsg(this, ref cvUsrLoginID, false, "Login ID is required!", "اسم دخول المستخدم مطلوب !");
                    e.IsValid = false;
                    return;
                }
                else
                {
                    if (ViewState["CommandName"].ToString() == "Save")
                    {
                        dt = DBCs.FetchData(MainQuery + " AND UsrLoginID = '" + txtUsrLoginID.Text + "'");
                        if (!DBCs.IsNullOrEmpty(dt))
                        {
                            MessageFun.ValidMsg(this, ref cvUsrLoginID, true, General.Msg("The Login ID already exists", "اسم الدخول موجود مسبقا"));
                            e.IsValid = false;
                            return;
                        }
                    }
                }
            }
        }
        catch { e.IsValid = false; }
    }

    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
}