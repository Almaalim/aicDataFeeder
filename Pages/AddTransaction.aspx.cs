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

public partial class Pages_AddTransaction : BasePage
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    DataTable dt;
    AddTransPro ProClass = new AddTransPro();
    AddTransSql SqlClass = new AddTransSql();
    DBFun DBCs = new DBFun();

    string MainPer = "Emp";
    string MainQuery = " SELECT * FROM EmpTrans WHERE EmpID = EmpID ";
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        //--Common Code----------------------------------------------------------------- //
        FormSession.FillSession("Employees", pageDiv);
        FormCtrl.RefreshGridEmpty(ref grdData, 20, "No Data Found", "لا توجد بيانات");
        //--Common Code----------------------------------------------------------------- //

        if (!IsPostBack)
        {
            btnAdd.Enabled = FormSession.PermUsr.Contains("I" + MainPer);
            pnlSearch.Enabled = grdData.Enabled = FormSession.PermUsr.Contains("V" + MainPer);
            FillGrid(MainQuery);

            DataItemStatus(false);

            //Fillddl();
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void Fillddl()
    //{
    //    dt = DBCs.FetchData("SELECT * FROM Department");
    //    if (!DBCs.IsNullOrEmpty(dt))
    //    {
    //        FormCtrl.PopulateDDL(ddlDepID, dt, "DepName" + FormSession.Language, "DepID", General.Msg("-Select Department-", "-اختر القسم-"));  //+ General.Lang()
    //        rvDepID.InitialValue = ddlDepID.Items[0].Text;
    //        ddlDepID.SelectedIndex = 1;
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region DataItem Events

    public void DataItemStatus(bool pStatus)
    {
        txtEmpID.Enabled = pStatus;
        calTrnDate.SetEnabled(pStatus);
        tpTrnTime.Enabled = pStatus;
        ddlTrnType.Enabled = pStatus;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void FillPropeties()
    {
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            ProClass.DateType = FormSession.DateType;
            ProClass.EmpID = txtEmpID.Text;
            //ProClass.TrnDate = Convert.ToBoolean(Convert.ToInt16(ddlEmpStatus.SelectedValue));
            ProClass.TrnDate = calTrnDate.getGDateDBFormat();
            ProClass.TrnTime = tpTrnTime.getDateTime();

            if (ddlTrnType.SelectedIndex > 0) { ProClass.TrnType = ddlTrnType.SelectedValue; }
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearData()
    {
        txtEmpID.Text = "";
        ddlTrnType.SelectedIndex = -1;
        calTrnDate.ClearDate();
        tpTrnTime.ClearTime();
        
        ViewState["CommandName"] = "";
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
            SearchItemStatus(false, false, "can't type");  /******/ Search();
        }
        else
        {
            if (ddlSearch.SelectedValue == "EmpID") { SearchItemStatus(true, false, "Type Employee ID here"); }

            ClearItem();
            FillGrid(MainQuery + " AND EmpID = '@@@@'");
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
            if (ddlSearch.SelectedValue == "EmpID") { SQ.Append(" AND EmpID = '" + txtSearch.Text + "'"); }
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
                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Employee added successfully", "تمت إضافة الموظف بنجاح"));
            }

            //if (ViewState["CommandName"].ToString() == "Edit")
            //{
            //    SqlClass.Update(ProClass);
            //    MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Employee updated successfully", "تم تعديل الموظف بنجاح"));
            //}

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
        txtEmpID.Enabled = false;
        ButtonAction(false, "00011");
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //string Q = " SELECT * FROM TransactionLog WHERE LogPkID = '" + txtEmpID.Text + "' ";
        //dt = DBCs.FetchData(Q);
        //if (!DBCs.IsNullOrEmpty(dt))
        //{
        //    MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("Deletion can not because of the presence of related records", "لا يمكن الحذف بسبب وجود سجلات مرتبطة"));
        //}
        //else
        //{
        //    ProClass.EmpID = txtEmpID.Text;
        //    SqlClass.Delete(ProClass);
        //    MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Employee deleted successfully", "تم حذف الموظف بنجاح"));

        //    ClearItem();
        //    Search();
        //}
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ButtonAction(true, "10000");
        DataItemStatus(false);

        if (ViewState["CommandName"].ToString() == "Add") { ClearData(); }
        if (ViewState["CommandName"].ToString() == "Edit") { PopulateData(txtEmpID.Text); }
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
                PopulateData(gridrow.Cells[0].Text);
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
            dt = DBCs.FetchData(MainQuery + " AND EmpID = '" + pID + "'");
            if (DBCs.IsNullOrEmpty(dt)) { return; }
            txtEmpID.Text = dt.Rows[0]["EmpID"].ToString();
            calTrnDate.SetGDate(dt.Rows[0]["TrnDate"], "dd/MM/yyyy");
            if (dt.Rows[0]["TrnTime"] != DBNull.Value) { tpTrnTime.SetTime(Convert.ToDateTime(dt.Rows[0]["TrnTime"])); }
            ddlTrnType.SelectedIndex = ddlTrnType.Items.IndexOf(ddlTrnType.Items.FindByValue(dt.Rows[0]["EmpStatus"].ToString()));
            
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
    protected void grdData_Sorting(object sender, GridViewSortEventArgs e) { ClearItem(); }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void grdData_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            e.Row.Cells[11].Visible = false;
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
    protected void ShowMsg_ServerValidate(Object source, ServerValidateEventArgs e) { e.IsValid = false; }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void EmpID_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        try
        {
            if (source.Equals(cvEmpID))
            {
                if (string.IsNullOrEmpty(txtEmpID.Text))
                {
                    General.ValidMsg(this, ref cvEmpID, false, "Employee ID is required!", "رقم الموظف مطلوب !");
                    e.IsValid = false;
                    return;
                }
                else
                {
                    if (ViewState["CommandName"].ToString() == "Add")
                    {
                        dt = DBCs.FetchData("SELECT * FROM EmployeesInfoView WHERE EmpID = '" + txtEmpID.Text + "'");
                        if (DBCs.IsNullOrEmpty(dt))
                        {
                            MessageFun.ValidMsg(this, ref cvEmpID, true, General.Msg("The Employee ID Not Found", "رقم الموظف غير موجود"));
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