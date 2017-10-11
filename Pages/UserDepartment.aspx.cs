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

public partial class Pages_UserDepartment : BasePage
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    DataTable dt;
    AppUsersPro ProClass = new AppUsersPro();
    AppUsersSql SqlClass = new AppUsersSql();

    string MainPer = "Usr";
    string MainQuery = "SELECT UsrLoginID,UsrFullName,UsrDepartments FROM AppUsers WHERE UsrStatus = 1 ";
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //--Common Code----------------------------------------------------------------- //
            FormSession.FillSession("Users", pageDiv);
            FormCtrl.RefreshGridEmpty(ref grdMainData, 20, "No Data Found", "لا توجد بيانات");
            //--Common Code----------------------------------------------------------------- //

            /*** TreeView Code ***********************************/
            FillTree();
            /*** TreeView Code ***********************************/

            if (!IsPostBack)
            {
                btnMainEdit.Enabled = FormSession.PermUsr.Contains("I" + MainPer);
                pnlSearch.Enabled = grdMainData.Enabled = FormSession.PermUsr.Contains("V" + MainPer);
                FillMainGrid(MainQuery);
                DataMainItemStatus(false);

                trvDept.Attributes.Add("onclick", "OnCheckBoxCheckChanged(event)");
            }
        }
        catch (Exception Ex) { MessageFun.ShowAdminMsg(this, Ex.Message); }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearItem()
    {
        grdMainData.SelectedIndex = -1;
        FillMainInfoLabel("", "");
        DataMainItemStatus(false);
        ButtonMainAction(true, "000");

        txtID.Text = "";
        ViewState["Departments"] = null;
        trvDept.CheckedNodes.Clear();
        trvDept.DataBind();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region Main DataItem Events

    public void DataMainItemStatus(bool pStatus)
    {
        txtID.Enabled = txtID.Visible = false;
        trvDept.Enabled = pStatus;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void FillMainPropeties()
    {
        //try
        //{
        //    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        //    ProClass.DateType = FormSession.DateType;
        //    if (ViewState["CommandName"].ToString() == "Edit") { ProClass.DepID = txtDepID.Text; }

        //    ProClass.DepNameAr = txtDepNameAr.Text;
        //    ProClass.DepNameEn = txtDepNameEn.Text;
        //    ProClass.DepDesc = txtDepDesc.Text;
        //    if (ddlParentID.SelectedIndex > 0) { ProClass.DepParentID = Convert.ToInt32(ddlParentID.SelectedValue); }
        //    ProClass.DepStatus = Convert.ToBoolean(chkDepStatus.Checked);

        //    ProClass.TransactionBy = FormSession.LoginID;
        //}
        //catch (Exception Ex) { }
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
            if (ddlSearch.SelectedValue == "UsrLoginID") { SearchItemStatus(true, false, "Type Username here"); }
            else if (ddlSearch.SelectedValue == "DepNameAr") { SearchItemStatus(true, false, "Type Department Name (Ar) here"); }
            else if (ddlSearch.SelectedValue == "DepNameEn") { SearchItemStatus(true, false, "Type Department Name (En) here"); }

            ClearItem();
            FillMainGrid(MainQuery + " AND UsrLoginID = -1");
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
            if (ddlSearch.SelectedValue == "UsrLoginID") { SQ.Append(" AND UsrLoginID LIKE '%" + txtSearch.Text + "%'"); }
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


    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*#############################################################################################################################*/
    /*#############################################################################################################################*/
    #region TreeView Events

    protected void trvDept_SelectedNodeChanged(object sender, EventArgs e) { }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void trvDept_DataBound(object sender, EventArgs e)
    {
        trvDept.CollapseAll();
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void trvDept_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
    {
        try
        {
            if (ViewState["Departments"] != null)
            {
                int iNode = Convert.ToInt32(e.Node.Value);
                string Departments = ViewState["Departments"].ToString();

                if (!string.IsNullOrEmpty(Departments))
                {
                    string[] DepartmentsSet = Departments.Split(',');
                    if (DepartmentsSet.Contains(iNode.ToString())) { e.Node.Checked = true; } else { e.Node.Checked = false; }
                }
            }
        }
        catch (Exception Ex) { MessageFun.ShowAdminMsg(this, Ex.Message); }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void FillTree()
    {
        DataSet ds = new DataSet();
        ds = FormCtrl.FillBrcDepTreeDS("General");
        xmlDataSource2.Data = ds.GetXml();
    }

    #endregion
    /*#############################################################################################################################*/
    /*#############################################################################################################################*/

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
            if (ViewState["CommandName"].ToString() == "Edit")
            {
                string DepList = "";
                foreach (TreeNode node in trvDept.CheckedNodes)
                {
                    if (string.IsNullOrEmpty(DepList)) { DepList = node.Value; } else { DepList += "," + node.Value; }
                }

                string DepListEnc = CryptorEngine.Encrypt(DepList, true);
                SqlClass.AppUser_Update_DepList(txtID.Text, DepListEnc, FormSession.LoginID);

                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("User updated successfully", "تم تعديل المستخدم بنجاح"));
            }

            ClearItem();
            trvDept.CheckedNodes.Clear();
            trvDept_TreeNodeDataBound(null, null);

            ButtonMainAction(true, "000");
            
            Search();
        }
        catch (Exception Ex) { MessageFun.ShowAdminMsg(this, Ex.Message); }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnMainAdd_Click(object sender, EventArgs e)
    {
        //ClearItem();
        //DataMainItemStatus(true);
        //ButtonMainAction(false, "00011");

        //ViewState["CommandName"] = "Add";

        //ClearSubItem();
        //FillSubGrid(SubQuery + " AND SdpID = -1");
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnMainEdit_Click(object sender, EventArgs e)
    {
        ViewState["CommandName"] = "Edit";
        DataMainItemStatus(true);
        ButtonMainAction(false, "011");

        //ClearSubItem();
        //FillSubGrid(SubQuery + " AND Sdp = -1");
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnMainDelete_Click(object sender, EventArgs e)
    {
        //string Q = " SELECT DepID FROM Department WHERE DepParentID = " + txtDepID.Text + " "
        //         + " UNION SELECT DepID FROM EmployeesInfoView WHERE DepID = " + txtDepID.Text + " ";

        //dt = DBFun.FetchData(Q);
        //if (!DBFun.IsNullOrEmpty(dt))
        //{
        //    MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("Deletion can not because of the presence of related records", "لا يمكن الحذف بسبب وجود سجلات مرتبطة"));
        //}
        //else
        //{
        //    ProClass.DepID = txtDepID.Text;
        //    SqlClass.Delete(ProClass);
        //    MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Department deleted successfully", "تم حذف القسم بنجاح"));

        //    ClearItem();
        //    Search();
        //    //FillSubGrid(SubQuery + " AND SdpID = -1");
        //}
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnMainCancel_Click(object sender, EventArgs e)
    {
        ButtonMainAction(true, "000");
        DataMainItemStatus(false);
        ClearItem();

        trvDept.CheckedNodes.Clear();
        trvDept_TreeNodeDataBound(null, null);
        trvDept.CollapseAll();

        //if (ViewState["CommandName"].ToString() == "Add") { ClearItem(); }
        //if (ViewState["CommandName"].ToString() == "Edit") { PopulateMainData(txtDepID.Text); }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
    protected void ButtonMainAction(bool pSearch, string pBtn) //string pBtn = [Edit,Save,Cancel]
    {
        if (FormSession.PermUsr.Contains("V" + MainPer)) { pnlSearch.Enabled = pSearch; } else { pnlSearch.Enabled = false; }
        if (FormSession.PermUsr.Contains("V" + MainPer)) { grdMainData.Enabled = pSearch; } else { grdMainData.Enabled = false; }

        //if (FormSession.PermUsr.Contains("I" + MainPer)) { btnMainAdd.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[0].ToString())); } else { btnMainAdd.Enabled = false; }
        if (FormSession.PermUsr.Contains("U" + MainPer)) { btnMainEdit.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[0].ToString())); } else { btnMainEdit.Enabled = false; }
        //if (FormSession.PermUsr.Contains("D" + MainPer)) { btnMainDelete.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[2].ToString())); } else { btnMainDelete.Enabled = false; }

        btnMainSave.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[1].ToString()));
        btnMainCancel.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[2].ToString()));
    }

    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region Main GridView Events

    protected void grdMainData_DataBound(object sender, EventArgs e) { }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdMainData_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ClearItem();
            DataMainItemStatus(false);
            
            GridViewRow gridrow = grdMainData.SelectedRow;
            if (FormCtrl.isGridEmpty(gridrow.Cells[0].Text))
            {
                FormCtrl.FillGridEmpty(ref grdMainData, 20, "No Data Found", "لا توجد بيانات");
            }
            else
            {
                PopulateMainData(gridrow.Cells[2].Text);
                ButtonMainAction(true, "100");
            }
        }
        catch (Exception Ex) { MessageFun.ShowAdminMsg(this, Ex.Message); }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void PopulateMainData(string pID)
    {
        try
        {
            DataTable dt = (DataTable)ViewState["grdDataDT"];
            DataRow[] DRs = dt.Select("UsrLoginID = '" + pID + "'");

            txtID.Text = DRs[0]["UsrLoginID"].ToString();

            string UsrDepartmentsEnc = DRs[0]["UsrDepartments"].ToString();
            string UsrDepartmentsDec = CryptorEngine.Decrypt(UsrDepartmentsEnc, true);

            ViewState["Departments"] = UsrDepartmentsDec;

            ///////////////////////////////////////////

            trvDept.DataBind();
            trvDept.ExpandAll();

            ///////////////////////////////////////////
        }
        catch (Exception Ex) { MessageFun.ShowAdminMsg(this, Ex.Message); }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void FillMainGrid(string Q)
    {
        dt = DBFun.FetchData(Q);
        if (!DBFun.IsNullOrEmpty(dt) && FormSession.PermUsr.Contains("S" + MainPer))
        {
            grdMainData.DataSource = (DataTable)dt;
            ViewState["grdDataDT"] = (DataTable)dt;
            grdMainData.DataBind();
        }
        else
        {
            FormCtrl.FillGridEmpty(ref grdMainData, 20, "No Data Found", "لا توجد بيانات");
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdMainData_RowDataBound(object sender, GridViewRowEventArgs e) { FormCtrl.GridSelectedRow(this, this.grdMainData, e.Row); }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void FillMainInfoLabel(string pID, string pName)
    {
        if (String.IsNullOrEmpty(pID) == false) { pID = "              ID : " + pID + "-----------"; }
        if (String.IsNullOrEmpty(pName) == false) { pName = "            Name : " + pName + "           "; }

        epnlMainData.CollapsedText = pID + pName + "(Show Details...)";
        epnlMainData.ExpandedText = pID + pName + "(Hide Details)";
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdMainData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdMainData.PageIndex = e.NewPageIndex;
        ClearItem();
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
        //try
        //{
        //    e.Row.Cells[2].Visible = false; //To hide ID column in grid view
        //    e.Row.Cells[4].Visible = false;
        //}
        //catch { }
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
    protected void tree_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        try
        {
            if (trvDept.CheckedNodes.Count == 0)
            {
                General.ValidMsg(this, ref cvDepartment, false, "Department is required", "يجب اختيار قسم");
            }
        }
        catch (Exception Ex)
        {
            e.IsValid = false;
            MessageFun.ShowAdminMsg(this, Ex.Message);
        }
    }

    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
}