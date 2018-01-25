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

public partial class Department : BasePage
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    DataTable   dt;
    DepartmentPro ProClass = new DepartmentPro();
    DepartmentSql SqlClass = new DepartmentSql();
    DBFun DBCs = new DBFun();
    DateFun DTCs = new DateFun();

    string MainPer   = "Dep";
    string MainQuery = "SELECT * FROM Department WHERE DepID = DepID ";
    //string SubQuery  = "SELECT * FROM SubDepartments WHERE SdpID = SdpID ";
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        //--Common Code----------------------------------------------------------------- //
        FormSession.FillSession("Departments", pageDiv);
        FormCtrl.RefreshGridEmpty(ref grdMainData, 20, "No Data Found","لا توجد بيانات");
        //FormCtrl.RefreshGridEmpty(ref grdSubData , 20, "No Data Found","لا توجد بيانات");
        //--Common Code----------------------------------------------------------------- //

        if (!IsPostBack)
        {
            btnMainAdd.Enabled = FormSession.PermUsr.Contains("I" + MainPer);
            pnlSearch.Enabled = grdMainData.Enabled = FormSession.PermUsr.Contains("V" + MainPer);
            FillMainGrid(MainQuery);
            //FillSubGrid(SubQuery + " AND SdpID = -1");
            
            DataMainItemStatus(false);
            //DataSubItemStatus(false);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearItem()
    {
        ClearMainItem();
        //ClearSubItem();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region Main DataItem Events

    public void DataMainItemStatus(bool pStatus)
    {
        txtDepID.Enabled     = false;
        txtDepNameAr.Enabled = pStatus;
        txtDepNameEn.Enabled = pStatus;
        txtDepDesc.Enabled   = pStatus;
        ddlParentID.Enabled = pStatus;
        chkDepStatus.Enabled = pStatus;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void FillMainPropeties()
    {
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            ProClass.DateType    = FormSession.DateType;
            if (ViewState["CommandName"].ToString() == "Edit") { ProClass.DepID  = txtDepID.Text; }
            
            ProClass.DepNameAr  = txtDepNameAr.Text;
            ProClass.DepNameEn = txtDepNameEn.Text;
            ProClass.DepDesc = txtDepDesc.Text;
            if (ddlParentID.SelectedIndex > 0) { ProClass.DepParentID = Convert.ToInt32(ddlParentID.SelectedValue); }
            ProClass.DepStatus = Convert.ToBoolean(chkDepStatus.Checked);

            ProClass.TransactionBy = FormSession.LoginID;
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearMainData()
    {
        txtDepID.Text     = "";
        txtDepNameAr.Text = "";
        txtDepNameEn.Text = "";
        txtDepDesc.Text   = "";
      
        //ClearSubData();
        ViewState["CommandName"]   = "";
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void  ClearMainItem()
    {
        grdMainData.SelectedIndex = -1;
        FillMainInfoLabel("", "");
        DataMainItemStatus(false);
        ButtonMainAction(true, "10000");
        ClearMainData();
    }

    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region Sub DataItem Events

    //public void DataSubItemStatus(bool pStatus)
    //{
    //    txtSdpID.Enabled        = false;
    //    txtSubDepID.Enabled     = false;
    //    txtSdpNameAr.Enabled    = pStatus;
    //    txtSdpNameEn.Enabled    = pStatus;
    //    txtSdpDesc.Enabled      = pStatus;
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //void FillSubPropeties()
    //{
    //    try
    //    {
    //        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

    //        ProClass.DateType    = FormSession.DateType;
    //        if (ViewState["SubCommandName"].ToString() == "Edit") { ProClass.SdpID  = txtSdpID.Text; }
    //        ProClass.DepID     = txtDepID.Text;
    //        ProClass.SdpNameAr = txtSdpNameAr.Text;
    //        if (!string.IsNullOrEmpty(txtSdpNameEn.Text)) { ProClass.SdpNameEn = txtSdpNameEn.Text; }
    //        if (!string.IsNullOrEmpty(txtSdpDesc.Text))   { ProClass.SdpDesc   = txtSdpDesc.Text; }

    //        ProClass.CreatedBy    = ProClass.ModifiedBy   = FormSession.LoginID;
    //        ProClass.CreatedDate  = ProClass.ModifiedDate = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
    //    }
    //    catch (Exception Ex) { }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //void ClearSubData()
    //{
    //    txtSdpID.Text        = "";
    //    txtSubDepID.Text     = "";
    //    txtSdpNameAr.Text    = "";
    //    txtSdpNameEn.Text    = "";
    //    txtSdpDesc.Text      = "";
    //    ViewState["SubCommandName"]   = "";
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //void ClearSubItem()
    //{
    //    grdSubData.SelectedIndex = -1;   
    //    FillSubInfoLabel("", "");
    //    DataSubItemStatus(false);
    //    ButtonSubAction(true, "00000");
    //    ClearSubData();
    //}

    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region SearchItem Events

    public void SearchItemStatus(bool pBtn,bool pFiltered,string pTxtMark)
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
            if      (ddlSearch.SelectedValue == "DepID")     { SearchItemStatus(true, false, "Type Department ID here"); }
            else if (ddlSearch.SelectedValue == "DepNameAr") { SearchItemStatus(true, false, "Type Department Name (Ar) here"); }
            else if (ddlSearch.SelectedValue == "DepNameEn") { SearchItemStatus(true, false, "Type Department Name (En) here"); }

            ClearItem();
            FillMainGrid(MainQuery + " AND DepID = -1");
            //FillSubGrid(SubQuery   + " AND SdpID = -1");
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
            if (ddlSearch.SelectedValue == "DepID")     { SQ.Append(" AND DepID = " + txtSearch.Text + ""); }
            if (ddlSearch.SelectedValue == "DepNameAr") { SQ.Append(" AND DepNameAr LIKE '%" + txtSearch.Text + "%'"); }
            if (ddlSearch.SelectedValue == "DepNameEn") { SQ.Append(" AND DepNameEn LIKE '%" + txtSearch.Text + "%'"); }
        }

        FillMainGrid(SQ.ToString());
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
    #region Main ButtonAction Events

    protected void btnMainSave_Click(object sender, EventArgs e)
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
            FillMainPropeties();

            if (ViewState["CommandName"].ToString() == "Add")
            {
                SqlClass.Insert(ProClass);
                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Department added successfully", "تمت إضافة القسم بنجاح"));
            }

            if (ViewState["CommandName"].ToString() == "Edit")
            {
                SqlClass.Update(ProClass);
                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Department updated successfully", "تم تعديل القسم بنجاح"));
            }

            ClearMainItem();
            //ButtonSubAction(true,"00000");
            Search();
        }
        catch (Exception Ex) { MessageFun.ShowAdminMsg(this, Ex.Message); }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnMainAdd_Click(object sender, EventArgs e)
    {
        ClearMainItem();
        DataMainItemStatus(true);
        ButtonMainAction(false,"00011");

        ViewState["CommandName"] = "Add";

        //ClearSubItem();
        //FillSubGrid(SubQuery + " AND SdpID = -1");
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnMainEdit_Click(object sender, EventArgs e)
    {
        ViewState["CommandName"] = "Edit";
        DataMainItemStatus(true);
        ButtonMainAction(false,"00011");

        //ClearSubItem();
        //FillSubGrid(SubQuery + " AND Sdp = -1");
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnMainDelete_Click(object sender, EventArgs e)
    {
        string Q = " SELECT DepID FROM Department WHERE DepParentID = " + txtDepID.Text + " "
                 + " UNION SELECT DepID FROM EmployeesInfoView WHERE DepID = " + txtDepID.Text + " ";

        dt = DBCs.FetchData(Q);
        if (!DBCs.IsNullOrEmpty(dt))
        {
            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("Deletion can not because of the presence of related records", "لا يمكن الحذف بسبب وجود سجلات مرتبطة"));
        }
        else
        {
            ProClass.DepID = txtDepID.Text;
            SqlClass.Delete(ProClass);
            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Department deleted successfully", "تم حذف القسم بنجاح"));

            ClearItem();
            Search();
            //FillSubGrid(SubQuery + " AND SdpID = -1");
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnMainCancel_Click(object sender, EventArgs e)
    {
        ButtonMainAction(true,"10000");
        //ButtonSubAction(true,"00000");
        DataMainItemStatus(false);

        if (ViewState["CommandName"].ToString() == "Add") { ClearMainData(); }
        if (ViewState["CommandName"].ToString() == "Edit") { PopulateMainData(txtDepID.Text);  }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
    protected void ButtonMainAction(bool pSearch,string pBtn) //string pBtn = [ADD,Edit,Delete,Save,Cancel]
    {
        if (FormSession.PermUsr.Contains("V" + MainPer)) { pnlSearch.Enabled = pSearch; } else { pnlSearch.Enabled = false; }
        if (FormSession.PermUsr.Contains("V" + MainPer)) { grdMainData.Enabled = pSearch; } else { grdMainData.Enabled = false; }

        if (FormSession.PermUsr.Contains("I" + MainPer)) { btnMainAdd.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[0].ToString())); } else { btnMainAdd.Enabled = false; }
        if (FormSession.PermUsr.Contains("U" + MainPer)) { btnMainEdit.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[1].ToString())); } else { btnMainEdit.Enabled = false; }
        if (FormSession.PermUsr.Contains("D" + MainPer)) { btnMainDelete.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[2].ToString())); } else { btnMainDelete.Enabled = false; }

        btnMainCancel.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[3].ToString()));
        btnMainSave.Enabled   = Convert.ToBoolean(Convert.ToInt32(pBtn[4].ToString()));
    }

    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region Sub ButtonAction Events

    //protected void btnSubSave_Click(object sender, EventArgs e)
    //{
    //    if (!Page.IsValid)
    //    {
    //        ValidatorCollection ValidatorColl = Page.Validators;
    //        for (int k = 0; k < ValidatorColl.Count; k++)
    //        {
    //            if (!ValidatorColl[k].IsValid && !String.IsNullOrEmpty(ValidatorColl[k].ErrorMessage)) { vsSubSave.ShowSummary = true; return; }
    //            vsSubSave.ShowSummary = false;
    //        }
    //        return;
    //    }

    //    try
    //    {
    //        FillSubPropeties();

    //        if (ViewState["SubCommandName"].ToString() == "Save")
    //        {
    //            SqlClass.SubInsert(ProClass);
    //            MessageFun.ShowMsg(this, vsSubShowMsg, cvSubShowMsg, MessageFun.TypeMsg.Success, "vgSubShowMsg", General.Msg("SubDepartment added successfully", "تمت إضافة القسم الفرعي بنجاح"));
    //        }

    //        if (ViewState["SubCommandName"].ToString() == "Edit")
    //        {
    //            SqlClass.SubUpdate(ProClass);
    //            MessageFun.ShowMsg(this, vsSubShowMsg, cvSubShowMsg, MessageFun.TypeMsg.Success, "vgSubShowMsg", General.Msg("SubDepartment updated successfully", "تم تعديل القسم الفرعي بنجاح"));
    //        }


    //        ClearSubItem();
    //        FillSubGrid(SubQuery + " AND DepID = " + txtDepID.Text);

    //        ButtonMainAction(true,"11100");
    //    }
    //    catch (Exception Ex) { MessageFun.ShowAdminMsg(this, vsSubShowMsg, cvSubShowMsg, "vgSubShowMsg", Ex.Message); }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void btnSubAdd_Click(object sender, EventArgs e)
    //{
    //    ClearSubItem();
    //    DataSubItemStatus(true);
    //    ButtonSubAction(false,"00011");
        
    //    ViewState["SubCommandName"] = "Save";
        
    //    DataMainItemStatus(false);
    //    ButtonMainAction(false,"00000");
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void btnSubEdit_Click(object sender, EventArgs e)
    //{
    //    ViewState["SubCommandName"] = "Edit";
    //    DataSubItemStatus(true);
    //    ButtonSubAction(false,"00011");

    //    DataMainItemStatus(false);
    //    ButtonMainAction(false,"00000");
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void btnSubDelete_Click(object sender, EventArgs e)
    //{
    //    string Q = " SELECT SdpID FROM InfoView WHERE SdpID = " + txtSdpID.Text + " ";
    //    dt = DBFun.FetchData(Q);
    //    if (!DBFun.IsNullOrEmpty(dt))
    //    {
    //        MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("Deletion can not because of the presence of related records", "لا يمكن الحذف بسبب وجود سجلات مرتبطة"));
    //    }
    //    else
    //    {
    //        ProClass.SdpID = txtSdpID.Text;
    //        SqlClass.SubDelete(ProClass);
    //        MessageFun.ShowMsg(this, vsSubShowMsg, cvSubShowMsg, MessageFun.TypeMsg.Success, "SubShowMsg", General.Msg("SubDepartment deleted successfully", "تم حذف القسم الفرعي بنجاح"));

    //        ClearSubItem();
    //        FillSubGrid(SubQuery + " AND DepID = " + txtDepID.Text);

    //        ButtonMainAction(true, "11000");
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void btnSubCancel_Click(object sender, EventArgs e)
    //{
    //    ButtonMainAction(true,"11000");
    //    ButtonSubAction(true,"10000");
    //    DataSubItemStatus(false);

    //    if (ViewState["SubCommandName"].ToString() == "Save") { ClearSubData(); }
    //    if (ViewState["SubCommandName"].ToString() == "Edit") { PopulateSubData(txtSdpID.Text);  }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
    //protected void ButtonSubAction(bool pSearch,string pBtn) //string pBtn = [ADD,Edit,Delete,Save,Cancel]
    //{
    //    if (FormSession.Perm.Contains("S" + MainPer)) { pnlSearch.Enabled    = pSearch; } else { pnlSearch.Enabled  = false; }
    //    if (FormSession.Perm.Contains("S" + MainPer)) { grdSubData.Enabled   = pSearch; } else { grdSubData.Enabled = false; }
        
    //    if (FormSession.Perm.Contains("I" + MainPer)) { btnSubAdd.Enabled    = Convert.ToBoolean(Convert.ToInt32(pBtn[0].ToString())); } else { btnSubAdd.Enabled    = false; }
    //    if (FormSession.Perm.Contains("U" + MainPer)) { btnSubEdit.Enabled   = Convert.ToBoolean(Convert.ToInt32(pBtn[1].ToString())); } else { btnSubEdit.Enabled   = false; }
    //    if (FormSession.Perm.Contains("D" + MainPer)) { btnSubDelete.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[2].ToString())); } else { btnSubDelete.Enabled = false; }

    //    btnSubCancel.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[3].ToString()));
    //    btnSubSave.Enabled   = Convert.ToBoolean(Convert.ToInt32(pBtn[4].ToString()));
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
    //protected void btnSubSearch_Click(object sender, EventArgs e){ Response.Redirect("SubDepartmentSearch.aspx"); }

    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region Main GridView Events
    
    protected void grdMainData_DataBound(object sender, EventArgs e)  { }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdMainData_SelectedIndexChanged(object sender, EventArgs e)
    {  
        try
        {
            GridViewRow gridrow = grdMainData.SelectedRow;
            if (FormCtrl.isGridEmpty(gridrow.Cells[0].Text))
            {
                FormCtrl.FillGridEmpty(ref grdMainData,20,"No Data Found","لا توجد بيانات");
            }
            else
            {
                PopulateMainData(gridrow.Cells[2].Text);
            }
        }
        catch (Exception e1) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void PopulateMainData(string pID)
    {
        try
        {
            dt = DBCs.FetchData(MainQuery + " AND DepID = " + pID + "");
            if (DBCs.IsNullOrEmpty(dt)) { return; }
            txtDepID.Text     = dt.Rows[0]["DepID"].ToString();
            txtDepNameAr.Text = dt.Rows[0]["DepNameAr"].ToString();
            txtDepNameEn.Text = dt.Rows[0]["DepNameEn"].ToString();
            ddlParentID.SelectedIndex = ddlParentID.Items.IndexOf(ddlParentID.Items.FindByValue(dt.Rows[0]["DepParentID"].ToString()));
            txtDepDesc.Text   = dt.Rows[0]["DepDesc"].ToString();
            if (dt.Rows[0]["DepStatus"] != DBNull.Value) { chkDepStatus.Checked = Convert.ToBoolean(dt.Rows[0]["DepStatus"]); }
            ButtonMainAction(true,"11100");

            //FillSubGrid(SubQuery + " AND DepID = " + txtDepID.Text);
           // ButtonAction(true, "11100");
        }
        catch (Exception Ex) { }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void FillMainGrid(string Q)
    {
        dt = DBCs.FetchData(Q);
        if (!DBCs.IsNullOrEmpty(dt) && FormSession.PermUsr.Contains("V" + MainPer))
        {
            grdMainData.DataSource = (DataTable)dt;
            grdMainData.DataBind();
        }
        else
        {
            FormCtrl.FillGridEmpty(ref grdMainData,20,"No Data Found","لا توجد بيانات");
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdMainData_RowDataBound(object sender, GridViewRowEventArgs e) { FormCtrl.GridSelectedRow(this, this.grdMainData, e.Row); }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void FillMainInfoLabel(string pID, string pName)
    {
        if (String.IsNullOrEmpty(pID) == false)   { pID   = "              ID : " + pID + "-----------";    }
        if (String.IsNullOrEmpty(pName) == false) { pName = "            Name : " + pName + "           ";  }

        epnlMainData.CollapsedText = pID + pName + "(Show Details...)";
        epnlMainData.ExpandedText  = pID + pName + "(Hide Details)";
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdMainData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdMainData.PageIndex = e.NewPageIndex;
        ClearMainItem();
        Search();
        
        //ClearSubItem();
        //FillSubGrid(SubQuery + " AND SdpID = -1 ");
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdMainData_Sorting(object sender, GridViewSortEventArgs e)
    {
        //grdMainData.SelectedIndex = -1;
        //ClearMainData();
        //ButtonMainAction(true,"10000");
        //FillMainInfoLabel("", "");  
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdMainData_RowCreated(object sender, GridViewRowEventArgs e)
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
    #region Sub GridView Events
    
    //protected void grdSubData_DataBound(object sender, EventArgs e)  { }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void grdSubData_SelectedIndexChanged(object sender, EventArgs e)
    //{  
    //    try
    //    {
    //        GridViewRow gridrow = grdSubData.SelectedRow;
    //        if (FormCtrl.isGridEmpty(gridrow.Cells[0].Text))
    //        {
    //            FormCtrl.FillGridEmpty(ref grdSubData,20,"No Data Found","لا توجد بيانات");
    //        }
    //        else
    //        {
    //            PopulateSubData(gridrow.Cells[2].Text);
    //        }
    //    }
    //    catch (Exception e1) { }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void PopulateSubData(string pID)
    //{
    //    try
    //    {
    //        dt = DBFun.FetchData(SubQuery + " AND SdpID = " + pID + "");
    //        if (DBFun.IsNullOrEmpty(dt)) { return; }
    //        txtSdpID.Text     = dt.Rows[0]["SdpID"].ToString();
    //        txtSubDepID.Text  = dt.Rows[0]["DepID"].ToString();
    //        txtSdpNameAr.Text = dt.Rows[0]["SdpNameAr"].ToString();
    //        txtSdpNameEn.Text = dt.Rows[0]["SdpNameEn"].ToString();   
    //        txtSdpDesc.Text   = dt.Rows[0]["SdpDesc"].ToString();
    //        ButtonSubAction(true,"11100");

    //        FillSubGrid(SubQuery + " AND DepID = " + txtDepID.Text);
    //    }
    //    catch (Exception Ex) { }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //public void FillSubGrid(string Q)
    //{
    //    dt = DBFun.FetchData(Q);
    //    if (!DBFun.IsNullOrEmpty(dt) && FormSession.Perm.Contains("S" + MainPer))
    //    {
    //        grdSubData.DataSource = (DataTable)dt;
    //        grdSubData.DataBind();
    //    }
    //    else
    //    {
    //        FormCtrl.FillGridEmpty(ref grdSubData,20,"No Data Found","لا توجد بيانات");
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void grdSubData_RowDataBound(object sender, GridViewRowEventArgs e) { FormCtrl.GridSelectedRow(this, this.grdSubData, e.Row); } 
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void FillSubInfoLabel(string pID, string pName)
    //{
    //    if (String.IsNullOrEmpty(pID) == false)   { pID   = "              ID : " + pID + "-----------";    }
    //    if (String.IsNullOrEmpty(pName) == false) { pName = "            Name : " + pName + "           ";  }

    //    epnlSubData.CollapsedText = pID + pName + "(Show Details...)";
    //    epnlSubData.ExpandedText  = pID + pName + "(Hide Details)";
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void grdSubData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    grdSubData.PageIndex = e.NewPageIndex;
    //    ClearSubItem();
    //    FillSubGrid(SubQuery + " AND DepID = " + txtDepID.Text);
    //    ButtonSubAction(true,"10000");
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void grdSubData_Sorting(object sender, GridViewSortEventArgs e)
    //{
        //grdMainData.SelectedIndex = -1;
        //ClearMainData();
        //ButtonMainAction(true,"10000");
        //FillMainInfoLabel("", "");  
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void grdSubData_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        e.Row.Cells[2].Visible = false; //To hide ID column in grid view
    //        e.Row.Cells[3].Visible = false;
    //        e.Row.Cells[5].Visible = false;
    //    }
    //    catch { }
    //}

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
    protected void DepName_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        string sqlUpdate = ViewState["CommandName"].ToString() == "Edit" ? " AND DepID != " + txtDepID.Text : "";

        try
        {
            if (ViewState["CommandName"].ToString() == "Add" || ViewState["CommandName"].ToString() == "Edit")
            {
                if (source.Equals(cvDepNameAr))
                {
                    if (string.IsNullOrEmpty(txtDepNameAr.Text))
                    {
                        General.ValidMsg(this, ref cvDepNameAr, false, "Department Name (Ar) is required!", "اسم القسم بالعربي مطلوب !");
                        e.IsValid = false;
                        return;
                    }
                    else
                    {
                        dt = DBCs.FetchData(MainQuery + " AND DepNameAr = '" + txtDepNameAr.Text + "' " + sqlUpdate);
                        if (!DBCs.IsNullOrEmpty(dt))
                        {
                            MessageFun.ValidMsg(this, ref cvDepNameAr, true, General.Msg("Department Name (Ar) already exists", "اسم القسم بالعربي موجود مسبقا"));
                            e.IsValid = false;
                            return;
                        }
                    }
                }

                if (source.Equals(cvDepNameEn))
                {
                    if (!string.IsNullOrEmpty(txtDepNameEn.Text))
                    {
                        dt = DBCs.FetchData(MainQuery + " AND DepNameEn = '" + txtDepNameEn.Text + "' " + sqlUpdate);
                        if (!DBCs.IsNullOrEmpty(dt))
                        {
                            MessageFun.ValidMsg(this, ref cvDepNameEn, true, General.Msg("Department Name (En) already exists", "اسم القسم بالانجليزي موجود مسبقا"));
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
    //protected void SubDepName_ServerValidate(Object source, ServerValidateEventArgs e)
    //{
    //    string sqlUpdate = ViewState["SubCommandName"].ToString() == "Edit" ? " AND SdpID != " + txtSdpID.Text : "";

    //    try
    //    {
    //        if (ViewState["SubCommandName"].ToString() == "Save" || ViewState["SubCommandName"].ToString() == "Edit")
    //        {
    //            if (source.Equals(cvSdpNameAr))
    //            {
    //                if (string.IsNullOrEmpty(txtSdpNameAr.Text))
    //                {
    //                    General.ValidMsg(this, ref cvSdpNameAr, false, "SubDepartment Name (Ar) is required!", "اسم القسم الفرعي بالعربي مطلوب !");
    //                    e.IsValid = false;
    //                    return;
    //                }
    //                else
    //                {
    //                    dt = DBFun.FetchData(SubQuery + " AND SdpNameAr = '" + txtSdpNameAr.Text + "' " + sqlUpdate);
    //                    if (!DBFun.IsNullOrEmpty(dt))
    //                    {
    //                        MessageFun.ValidMsg(this, ref cvSdpNameAr, true, General.Msg("SubDepartment Name (Ar) already exists", "اسم القسم الفرعي بالعربي موجود مسبقا"));
    //                        e.IsValid = false;
    //                        return;
    //                    }
    //                }
    //            }

    //            if (source.Equals(cvSdpNameEn))
    //            {
    //                if (!string.IsNullOrEmpty(txtSdpNameEn.Text))
    //                {
    //                    dt = DBFun.FetchData(SubQuery + " AND SdpNameEn = '" + txtSdpNameEn.Text + "' " + sqlUpdate);
    //                    if (!DBFun.IsNullOrEmpty(dt))
    //                    {
    //                        MessageFun.ValidMsg(this, ref cvSdpNameEn, true, General.Msg("SubDepartment Name (En) already exists", "اسم القسم الفرعي بالانجليزي موجود مسبقا"));
    //                        e.IsValid = false;
    //                        return;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    catch { e.IsValid = false; }
    //}

    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
}
