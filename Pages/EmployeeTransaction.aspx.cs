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

public partial class Pages_EmployeeTransaction : BasePage
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    DataTable dt;
    EmployeePro ProClass = new EmployeePro();
    EmployeeSql SqlClass = new EmployeeSql();
    DBFun DBCs = new DBFun();
    DateFun DTCs = new DateFun();

    string MainPer = "Emp";
    string MainQuery = " SELECT * FROM EmpTransactionView WHERE EmpID = EmpID ";
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
            pnlSearch.Enabled = grdData.Enabled = FormSession.PermUsr.Contains("VT" + MainPer);
            FillGrid(MainQuery);

            //DataItemStatus(false);
            Fillddl();
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Fillddl()
    {
        try
        {
            DTCs.YearPopulateList(ref ddlYear);
            DTCs.MonthPopulateList(ref ddlMonth);
        }
        catch (Exception ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region DataItem Events

    void ClearData()
    {
        ViewState["CommandName"] = "";
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearItem()
    {
        grdData.SelectedIndex = -1;
        FillInfoLabel("", "");
        //DataItemStatus(false);
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
            else if (ddlSearch.SelectedValue == "EmpNameAr") { SearchItemStatus(true, false, "Type Employee Name (Ar) here"); }
            else if (ddlSearch.SelectedValue == "EmpNameEn") { SearchItemStatus(true, false, "Type Employee Name (En) here"); }

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
            if (ddlSearch.SelectedValue == "EmpNameAr") { SQ.Append(" AND EmpNameAr LIKE '%" + txtSearch.Text + "%'"); }
            if (ddlSearch.SelectedValue == "EmpNameEn") { SQ.Append(" AND EmpNameEn LIKE '%" + txtSearch.Text + "%'"); }
        }

        DateTime SDate = DateTime.Now;
        DateTime EDate = DateTime.Now;
        DTCs.FindMonthDates(ddlYear.SelectedValue, ddlMonth.SelectedValue, out SDate, out EDate);

        SQ.Append(" AND (TrnDate between '" + SDate + "' AND '" + EDate + "')");

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

    protected void ButtonAction(bool pSearch, string pBtn) //string pBtn = [ADD,Edit,Delete,Save,Cancel]
    {
        if (FormSession.PermUsr.Contains("VT" + MainPer)) { pnlSearch.Enabled = pSearch; } else { pnlSearch.Enabled = false; }
        if (FormSession.PermUsr.Contains("VT" + MainPer)) { grdData.Enabled = pSearch; } else { grdData.Enabled = false; }
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
                //PopulateData(gridrow.Cells[0].Text);
            }
        }
        catch (Exception e1) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void FillGrid(string Q)
    {
        dt = DBCs.FetchData(Q);
        if (!DBCs.IsNullOrEmpty(dt) && FormSession.PermUsr.Contains("VT" + MainPer))
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

        //epnlData.CollapsedText = pID + pName + "(Show Details...)";
        //epnlData.ExpandedText = pID + pName + "(Hide Details)";
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
            //e.Row.Cells[11].Visible = false;
        }
        catch { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string getStatus(object pValue)
    {
        if (pValue != null)
        {
            if (pValue.ToString() == "True") { return General.Msg("Active", "فعال"); }
            if (pValue.ToString() == "False") { return General.Msg("InActive", "غير فعال"); }
        }

        return null;
    }

    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}