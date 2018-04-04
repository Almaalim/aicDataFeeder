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

public partial class EmployeeVacation : BasePage
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    DataTable dt;
    EmpVacRelPro ProClass = new EmpVacRelPro();
    EmpVacRelSql SqlClass = new EmpVacRelSql();
    DBFun DBCs = new DBFun();
    DateFun DTCs = new DateFun();

    string MainPer = "EmpVac";
    string MainQuery = "SELECT * FROM EmpVacRelInfo WHERE EvrID = EvrID ";
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        //--Common Code----------------------------------------------------------------- //
        FormSession.FillSession("EmpVacation", pageDiv);
        FormCtrl.RefreshGridEmpty(ref grdData, 20, "No Data Found", "لا توجد بيانات");
        //--Common Code----------------------------------------------------------------- //

        if (!IsPostBack)
        {
            btnAdd.Enabled = FormSession.PermUsr.Contains("I" + MainPer);
            pnlSearch.Enabled = grdData.Enabled = FormSession.PermUsr.Contains("V" + MainPer);
            FillGrid(MainQuery);

            DataItemStatus(false);
            Fillddl();
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Fillddl()
    {
        dt = DBCs.FetchData("SELECT VtpID, VtpNameAr, VtpNameEn FROM VacationType WHERE VtpStatus = '1' ");
        if (!DBCs.IsNullOrEmpty(dt))
        {
            FormCtrl.PopulateDDL(ddlVacType, dt, "VtpName" + FormSession.Language, "VtpID", General.Msg("-Select Vacation type-", "-اختر نوع الإجازة-"));
            rfvddlVacType.InitialValue = ddlVacType.Items[0].Text;
            ddlVacType.SelectedIndex = 0;
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
        txtEvrID.Enabled = false;
        txtEmpID.Enabled = pStatus;
        ddlVacType.Enabled = pStatus;
        calStartDate.SetEnabled(pStatus);
        calEndDate.SetEnabled(pStatus);
        txtPhoneNo.Enabled = pStatus;
        txtAvailable.Enabled = pStatus;
        txtEvrDesc.Enabled = pStatus;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void FillPropeties()
    {
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            ProClass.DateType = FormSession.DateType;
            if (ViewState["CommandName"].ToString() == "Edit") { ProClass.EvrID = txtEvrID.Text; }

            ProClass.EmpID = txtEmpID.Text;
            if (ddlVacType.SelectedIndex > 0) { ProClass.VtpID = ddlVacType.SelectedValue; }
            ProClass.EvrStartDate = calStartDate.getGDateDBFormat();
            ProClass.EvrEndDate = calEndDate.getGDateDBFormat();
            ProClass.EvrPhone = txtPhoneNo.Text;
            ProClass.EvrAvailability = txtAvailable.Text;
            ProClass.EvrDescription = txtEvrDesc.Text;

            ProClass.TransactionBy = FormSession.LoginID;
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearData()
    {
        txtEvrID.Text = "";
        txtEmpID.Text = "";
        ddlVacType.SelectedIndex = -1;
        calStartDate.ClearDate();
        calEndDate.ClearDate();
        txtPhoneNo.Text = "";
        txtAvailable.Text = "";
        txtEvrDesc.Text = "";
        ViewState["CommandName"] = "";
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
            if (ddlSearch.SelectedValue == "EmpID")     { SearchItemStatus(true, false, "Type Employee ID here"); }
            else if (ddlSearch.SelectedValue == "EmpNameAr") { SearchItemStatus(true, false, "Type Employee Name (Ar) here"); }
            else if (ddlSearch.SelectedValue == "EmpNameEn") { SearchItemStatus(true, false, "Type Employee Name (En) here"); }

            else if (ddlSearch.SelectedValue == "VtpID") { SearchItemStatus(true, false, "Type Vacation ID here"); }
            else if (ddlSearch.SelectedValue == "VtpNameAr") { SearchItemStatus(true, false, "Type Vacation Name (Ar) here"); }
            else if (ddlSearch.SelectedValue == "VtpNameEn") { SearchItemStatus(true, false, "Type Vacation Name (En) here"); }

            ClearData();
            FillGrid(MainQuery + "  EmpID = '@@@@'");
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
            if (ddlSearch.SelectedValue == "EmpNameAr") { SQ.Append(" AND EmpNameAr LIKE '%" + txtSearch.Text + "%'"); }
            if (ddlSearch.SelectedValue == "EmpNameEn") { SQ.Append(" AND EmpNameEn LIKE '%" + txtSearch.Text + "%'"); }

            if (ddlSearch.SelectedValue == "VtpID") { SQ.Append(" AND VtpID = " + txtSearch.Text + ""); }
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
                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Vacation added for employee successfully", "تمت إضافة الإجازة للموظف بنجاح"));
            }

            if (ViewState["CommandName"].ToString() == "Edit")
            {
                SqlClass.Update(ProClass);
                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Vacation updated for employee successfully", "تم تعديل الإجازة للموظف بنجاح"));
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
        //string Q = " SELECT VtpID FROM EmpVacRel WHERE EvrID = " + txtEvrID.Text + " ";

        //dt = DBFun.FetchData(Q);
        //if (!DBFun.IsNullOrEmpty(dt))
        //{
        //    MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("Deletion can not because of the presence of related records", "لا يمكن الحذف بسبب وجود سجلات مرتبطة"));
        //}
        //else
        //{
            ProClass.VtpID = txtEvrID.Text;
            SqlClass.Delete(ProClass);
            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Vacation deleted for employee successfully", "تم حذف الإجازة للموظف بنجاح"));

            ClearItem();
            Search();
        //}
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ButtonAction(true, "10000");
        DataItemStatus(false);

        if (ViewState["CommandName"].ToString() == "Add") { ClearData(); }
        if (ViewState["CommandName"].ToString() == "Edit") { PopulateData(txtEvrID.Text); }
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
            dt = DBCs.FetchData(MainQuery + " AND EvrID = " + pID + "");
            if (DBCs.IsNullOrEmpty(dt)) { return; }
            txtEvrID.Text = dt.Rows[0]["EvrID"].ToString();
            txtEmpID.Text = dt.Rows[0]["EmpID"].ToString();
            ddlVacType.SelectedIndex = ddlVacType.Items.IndexOf(ddlVacType.Items.FindByValue(Convert.ToInt16(dt.Rows[0]["VtpID"]).ToString()));

            calStartDate.SetGDate(dt.Rows[0]["EvrStartDate"], "dd/MM/yyyy");
            calEndDate.SetGDate(dt.Rows[0]["EvrEndDate"], "dd/MM/yyyy");

            txtPhoneNo.Text = dt.Rows[0]["EvrPhone"].ToString();
            txtAvailable.Text = dt.Rows[0]["EvrAvailability"].ToString();
            txtEvrDesc.Text = dt.Rows[0]["EvrDescription"].ToString();
            
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
            //e.Row.Cells[5].Visible = false; //To hide ID column in grid view
            //e.Row.Cells[6].Visible = false;
        }
        catch { }
    }

    public bool FindNestingDates(string DateType, string StartDate, string EndDate, string EmpID)
    {
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            DateTime SDate = DTCs.ConvertToDatetime(StartDate, DateType);
            DateTime EDate = DTCs.ConvertToDatetime(EndDate, DateType);
            DateTime Date = SDate;
            int Days = Convert.ToInt32((Date - SDate).TotalDays + 1);

            StringBuilder Q = new StringBuilder();
            Q.Append(" SELECT EmpID FROM EmpVacRel WHERE EmpID = @P1 AND @P2 BETWEEN EvrStartDate AND EvrEndDate AND ISNULL(EvrDeleted,0) = 0 ");

            for (int i = 0; i < Days; i++)
            {
                Date = SDate.AddDays(i);

                DataTable DT = DBCs.FetchData(Q.ToString(), new string[] { EmpID, Date.ToString() });
                if (!DBCs.IsNullOrEmpty(DT)) { return true; }
            }
            return false;
        }
        catch (Exception ex) { return true; }
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
    protected void EmpID_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        string sqlUpdate = ViewState["CommandName"].ToString() == "Edit" ? " AND EvrID != " + txtEvrID.Text : "";

        try
        {
            if (ViewState["CommandName"].ToString() == "Add" || ViewState["CommandName"].ToString() == "Edit")
            {
                if (source.Equals(cvEmpID))
                {
                    if (!string.IsNullOrEmpty(txtEmpID.Text))
                    {
                        dt = DBCs.FetchData("SELECT * FROM EmployeesInfoView WHERE EmpID = '" + txtEmpID.Text + "' ");
                        if (!DBCs.IsNullOrEmpty(dt))
                        {
                            MessageFun.ValidMsg(this, ref cvEmpID, true, General.Msg("Employee ID entered donot exists or not Active,Please enter different ID", "رقم الموظف غير موجود أو غير فعال ,من فضلك اختر رقما آخر"));
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
    protected void DateValidate_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        try
        {
            if (source.Equals(cvCompareDates))
            {
                if (!String.IsNullOrEmpty(calStartDate.getGDateDBFormat()) && !String.IsNullOrEmpty(calEndDate.getGDateDBFormat()))
                {
                    int iStartDate = DTCs.ConvertDateTimeToInt(calStartDate.getGDate(), FormSession.DateType);
                    int iEndDate = DTCs.ConvertDateTimeToInt(calEndDate.getGDate(), FormSession.DateType);
                    if (iStartDate > iEndDate) { e.IsValid = false; } else { e.IsValid = true; }
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