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

public partial class VacationType : BasePage
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    DataTable dt;
    VacationPro ProClass = new VacationPro();
    VacationSql SqlClass = new VacationSql();
    DBFun DBCs = new DBFun();

    string MainPer = "Vac";
    string MainQuery = "SELECT * FROM VacationType WHERE VtpID = VtpID ";
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        //--Common Code----------------------------------------------------------------- //
        FormSession.FillSession("Vacation", pageDiv);
        FormCtrl.RefreshGridEmpty(ref grdData, 20, "No Data Found", "لا توجد بيانات");
        //FormCtrl.RefreshGridEmpty(ref grdSubData , 20, "No Data Found","لا توجد بيانات");
        //--Common Code----------------------------------------------------------------- //

        if (!IsPostBack)
        {
            btnAdd.Enabled = FormSession.PermUsr.Contains("I" + MainPer);
            pnlSearch.Enabled = grdData.Enabled = FormSession.PermUsr.Contains("V" + MainPer);
            FillGrid(MainQuery);
            //FillSubGrid(SubQuery + " AND SdpID = -1");

            DataItemStatus(false);
            //DataSubItemStatus(false);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearItem()
    {
       ClearData();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region DataItem Events

    public void DataItemStatus(bool pStatus)
    {
        txtVtpID.Enabled = false;
        txtVtpNameAr.Enabled = pStatus;
        txtVtpNameEn.Enabled = pStatus;
        txtVtpDesc.Enabled = pStatus;
        chkVtpStatus.Enabled = pStatus;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void FillPropeties()
    {
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            ProClass.DateType = FormSession.DateType;
            if (ViewState["CommandName"].ToString() == "Edit") { ProClass.VtpID = txtVtpID.Text; }

            ProClass.VtpNameAr = txtVtpNameAr.Text;
            ProClass.VtpNameEn = txtVtpNameEn.Text;
            ProClass.VtpDesc = txtVtpDesc.Text;
            ProClass.VtpStatus = Convert.ToBoolean(chkVtpStatus.Checked);

            ProClass.TransactionBy = FormSession.LoginID;
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearData()
    {
        txtVtpID.Text = "";
        txtVtpNameAr.Text = "";
        txtVtpNameEn.Text = "";
        txtVtpDesc.Text = "";
        chkVtpStatus.Checked = false;
        ViewState["CommandName"] = "";
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearMainItem()
    {
        grdData.SelectedIndex = -1;
        FillInfoLabel("", "");
        DataItemStatus(false);
        ButtonAction(true, "10000");
        ClearData();
    }

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
            if (ddlSearch.SelectedValue == "VtpID") { SearchItemStatus(true, false, "Type Vacation ID here"); }
            else if (ddlSearch.SelectedValue == "VtpNameAr") { SearchItemStatus(true, false, "Type Vacation Name (Ar) here"); }
            else if (ddlSearch.SelectedValue == "VtpNameEn") { SearchItemStatus(true, false, "Type Vacation Name (En) here"); }

            ClearData();
            FillGrid(MainQuery + " AND VtpID = -1");
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
            if (ddlSearch.SelectedValue == "VtpID")     { SQ.Append(" AND VtpID = " + txtSearch.Text + ""); }
            if (ddlSearch.SelectedValue == "VtpNameAr") { SQ.Append(" AND VtpNameAr LIKE '%" + txtSearch.Text + "%'"); }
            if (ddlSearch.SelectedValue == "VtpNameEn") { SQ.Append(" AND VtpNameEn LIKE '%" + txtSearch.Text + "%'"); }
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
                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Vacation added successfully", "تمت إضافة الإجازة بنجاح"));
            }

            if (ViewState["CommandName"].ToString() == "Edit")
            {
                SqlClass.Update(ProClass);
                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Vacation updated successfully", "تم تعديل الإجازة بنجاح"));
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
        ButtonAction(false, "00011");
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string Q = " SELECT VtpID FROM EmpVacRel WHERE VtpID = " + txtVtpID.Text + " ";

        dt = DBCs.FetchData(Q);
        if (!DBCs.IsNullOrEmpty(dt))
        {
            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("Deletion can not because of the presence of related records", "لا يمكن الحذف بسبب وجود سجلات مرتبطة"));
        }
        else
        {
            ProClass.VtpID = txtVtpID.Text;
            SqlClass.Delete(ProClass);
            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Vacation deleted successfully", "تم حذف الإجازة بنجاح"));

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
        if (ViewState["CommandName"].ToString() == "Edit") { PopulateData(txtVtpID.Text); }
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
                PopulateData(gridrow.Cells[2].Text);
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
            dt = DBCs.FetchData(MainQuery + " AND VtpID = " + pID + "");
            if (DBCs.IsNullOrEmpty(dt)) { return; }
            txtVtpID.Text = dt.Rows[0]["VtpID"].ToString();
            txtVtpNameAr.Text = dt.Rows[0]["VtpNameAr"].ToString();
            txtVtpNameEn.Text = dt.Rows[0]["VtpNameEn"].ToString();
            txtVtpDesc.Text = dt.Rows[0]["VtpDescription"].ToString();
            if (dt.Rows[0]["VtpStatus"] != DBNull.Value) { chkVtpStatus.Checked = Convert.ToBoolean(dt.Rows[0]["VtpStatus"]); }
            ButtonAction(true, "11100");
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void FillGrid(string Q)
    {
        dt = DBCs.FetchData(Q);
        if (!DBCs.IsNullOrEmpty(dt) && FormSession.PermUsr.Contains("V" + MainPer))
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
        if (String.IsNullOrEmpty(pID) == false) { pID = "              ID : " + pID + "-----------"; }
        if (String.IsNullOrEmpty(pName) == false) { pName = "            Name : " + pName + "           "; }

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
        //grdData.SelectedIndex = -1;
        //ClearData();
        //ButtonAction(true,"10000");
        //FillInfoLabel("", "");  
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdData_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            e.Row.Cells[2].Visible = false; //To hide ID column in grid view
            e.Row.Cells[4].Visible = false;
        }
        catch { }
    }

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
    protected void ShowMsg_ServerValidate(Object source, ServerValidateEventArgs e) { e.IsValid = false; }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void VtpName_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        string sqlUpdate = ViewState["CommandName"].ToString() == "Edit" ? " AND VtpID != " + txtVtpID.Text : "";

        try
        {
            if (ViewState["CommandName"].ToString() == "Add" || ViewState["CommandName"].ToString() == "Edit")
            {
                if (source.Equals(cvVtpNameAr))
                {
                    if (string.IsNullOrEmpty(txtVtpNameAr.Text))
                    {
                        General.ValidMsg(this, ref cvVtpNameAr, false, "Vacation Name (Ar) is required!", "اسم الإجازة بالعربي مطلوبة !");
                        e.IsValid = false;
                        return;
                    }
                    else
                    {
                        dt = DBCs.FetchData(MainQuery + " AND VtpNameAr = '" + txtVtpNameAr.Text + "' " + sqlUpdate);
                        if (!DBCs.IsNullOrEmpty(dt))
                        {
                            MessageFun.ValidMsg(this, ref cvVtpNameAr, true, General.Msg("Vacation Name (Ar) already exists", "اسم الإجازة بالعربي موجود مسبقا"));
                            e.IsValid = false;
                            return;
                        }
                    }
                }

                if (source.Equals(cvVtpNameEn))
                {
                    if (!string.IsNullOrEmpty(txtVtpNameEn.Text))
                    {
                        dt = DBCs.FetchData(MainQuery + " AND VtpNameEn = '" + txtVtpNameEn.Text + "' " + sqlUpdate);
                        if (!DBCs.IsNullOrEmpty(dt))
                        {
                            MessageFun.ValidMsg(this, ref cvVtpNameEn, true, General.Msg("Vacation Name (En) already exists", "اسم الإجازة بالانجليزي موجود مسبقا"));
                            e.IsValid = false;
                            return;
                        }
                    }
                }
            }
        }
        catch { e.IsValid = false; }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    

    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
}