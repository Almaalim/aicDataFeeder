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

public partial class Pages_SettingMachine : BasePage
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    DataTable dt;
    MachinePro ProClass = new MachinePro();
    MachineSql SqlClass = new MachineSql();
    DBFun DBCs = new DBFun();

    string MainPer = "Mac";
    string MainQuery = "SELECT * FROM MachineInfoView WHERE MacID = MacID ";
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {

        //--Common Code----------------------------------------------------------------- //
        FormSession.FillSession("Machines", pageDiv);
        FormCtrl.RefreshGridEmpty(ref grdData, 20, "No Data Found", "لا توجد بيانات");
        //--Common Code----------------------------------------------------------------- //

        if (!IsPostBack)
        {
            btnAdd.Enabled = FormSession.PermUsr.Contains("I" + MainPer);
            pnlSearch.Enabled = grdData.Enabled = FormSession.PermUsr.Contains("V" + MainPer);
            FillGrid(MainQuery);

            DataItemStatus(false);
            FillDDL();
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void FillDDL()
    {
        dt = DBCs.FetchData("SELECT * FROM MachineType WHERE MtpStatus = '1' ");
        if (!DBCs.IsNullOrEmpty(dt))
        {
            FormCtrl.PopulateDDL(ddlMtpID, dt, "MtpName" + FormSession.Language, "MtpID", General.Msg("-Select Machine type-", "-اختر نوع المكينة-"));
            rfvddlMtpID.InitialValue = ddlMtpID.Items[0].Text;
            ddlMtpID.SelectedIndex = 1;
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
        txtMachineID.Enabled = pStatus;
        ddlMtpID.Enabled = pStatus;
        txtIPAddress.Enabled = pStatus;
        chkMacStatus.Enabled = pStatus;
        txtPort.Enabled = pStatus;
        txtMachineNo.Enabled = pStatus;
        txtMacSerialNo.Enabled = pStatus;
        txtMacLocationAr.Enabled = pStatus;
        txtMacLocationEn.Enabled = pStatus;
        ddlMacTrnType.Enabled = pStatus;
        chkExportData.Enabled = pStatus;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void FillPropeties()
    {
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            ProClass.DateType = FormSession.DateType;
            if (ViewState["CommandName"].ToString() == "Edit") { ProClass.MacID = txtMachineID.Text; }

            if (ddlMtpID.SelectedIndex > 0) { ProClass.MtpID = ddlMtpID.SelectedValue; }
            ProClass.IPAddress = txtIPAddress.Text;
            ProClass.MachineStatus = chkMacStatus.Checked;
            ProClass.Port = txtPort.Text;
            ProClass.MachineNo = txtMachineNo.Text;
            ProClass.MachineSerialNo = txtMacSerialNo.Text;
            ProClass.LocationAr = txtMacLocationAr.Text;
            ProClass.LocationEn = txtMacLocationEn.Text;
            if (ddlMacTrnType.SelectedIndex > 0) { ProClass.MachineINOUTType = ddlMacTrnType.SelectedValue; }
            ProClass.MachineExport = chkExportData.Checked;

            ProClass.TransactionBy = FormSession.LoginID;
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearData()
    {
        txtMachineID.Text = "";
        ddlMtpID.SelectedIndex = -1;
        txtIPAddress.Text = "";
        chkMacStatus.Checked = false;
        txtPort.Text = "";
        txtMachineNo.Text = "";
        txtMacSerialNo.Text = "";
        txtMacLocationAr.Text = "";
        txtMacLocationEn.Text = "";
        ddlMacTrnType.SelectedIndex = -1;
        chkExportData.Checked = false;

        ViewState["CommandName"] = "";
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearMainItem()
    {
        grdData.SelectedIndex = -1;
        //FillInfoLabel("", "");
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
            if (ddlSearch.SelectedValue == "MtpNameAr") { SearchItemStatus(true, false, "Type Machine type (Ar) here"); }
            if (ddlSearch.SelectedValue == "MtpNameEn") { SearchItemStatus(true, false, "Type Machine type (En) here"); }
            else if (ddlSearch.SelectedValue == "IPAddress") { SearchItemStatus(true, false, "Type  IP Address here"); }
            else if (ddlSearch.SelectedValue == "MachineNo") { SearchItemStatus(true, false, "Type Machine No here"); }

            else if (ddlSearch.SelectedValue == "LocationAr") { SearchItemStatus(true, false, "Type Location Name (Ar) here"); }
            else if (ddlSearch.SelectedValue == "LocationEn") { SearchItemStatus(true, false, "Type Location Name (En) here"); }
            else if (ddlSearch.SelectedValue == "MachineSerialNo") { SearchItemStatus(true, false, "Type Machine Serial No here"); }

            ClearItem();
            //FillGrid(MainQuery + " AND MacID = '@@@@'");
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
            if (ddlSearch.SelectedValue == "MtpNameAr") { SQ.Append(" AND MtpNameAr LIKE '%" + txtSearch.Text + "%'"); }
            if (ddlSearch.SelectedValue == "MtpNameEn") { SQ.Append(" AND MtpNameEn LIKE '%" + txtSearch.Text + "%'"); }
            if (ddlSearch.SelectedValue == "IPAddress") { SQ.Append(" AND IPAddress LIKE '%" + txtSearch.Text + "%'"); }
            if (ddlSearch.SelectedValue == "MachineNo") { SQ.Append(" AND MachineNo LIKE '%" + txtSearch.Text + "%'"); }

            if (ddlSearch.SelectedValue == "LocationAr") { SQ.Append(" AND LocationAr LIKE '%" + txtSearch.Text + "%'"); }
            if (ddlSearch.SelectedValue == "LocationEn") { SQ.Append(" AND LocationEn LIKE '%" + txtSearch.Text + "%'"); }
            if (ddlSearch.SelectedValue == "MachineSerialNo") { SQ.Append(" AND MachineSerialNo LIKE '%" + txtSearch.Text + "%'"); }
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
                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Machine added successfully", "تمت إضافة المكينة بنجاح"));
            }

            if (ViewState["CommandName"].ToString() == "Edit")
            {
                SqlClass.Update(ProClass);
                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Machine updated successfully", "تم تعديل المكينة بنجاح"));
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
        string Q = " SELECT MacID FROM TransDump WHERE MacID = " + txtMachineID.Text + " ";

        dt = DBCs.FetchData(Q);
        if (!DBCs.IsNullOrEmpty(dt))
        {
            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("Deletion can not because of the presence of related records", "لا يمكن الحذف بسبب وجود سجلات مرتبطة"));
        }
        else
        {
            ProClass.MacID = txtMachineID.Text;
            SqlClass.Delete(ProClass);
            MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Machine deleted successfully", "تم حذف المكينة بنجاح"));

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
        if (ViewState["CommandName"].ToString() == "Edit") { PopulateData(txtMachineID.Text); }
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
            dt = DBCs.FetchData(MainQuery + " AND MacID = " + pID + "");
            if (DBCs.IsNullOrEmpty(dt)) { return; }
            txtMachineID.Text = dt.Rows[0]["MacID"].ToString();
            ddlMtpID.SelectedIndex = ddlMtpID.Items.IndexOf(ddlMtpID.Items.FindByValue(Convert.ToInt16(dt.Rows[0]["MtpID"]).ToString()));
            txtIPAddress.Text = dt.Rows[0]["IPAddress"].ToString();
            if (dt.Rows[0]["MachineStatus"] != DBNull.Value) { chkMacStatus.Checked = Convert.ToBoolean(dt.Rows[0]["MachineStatus"]); } else { chkMacStatus.Checked = false; }
            txtPort.Text = dt.Rows[0]["Port"].ToString();
            txtMachineNo.Text = dt.Rows[0]["MachineNo"].ToString();
            txtMacSerialNo.Text = dt.Rows[0]["MachineSerialNo"].ToString();
            txtMacLocationAr.Text = dt.Rows[0]["LocationAr"].ToString();
            txtMacLocationEn.Text = dt.Rows[0]["LocationEn"].ToString();
            ddlMacTrnType.SelectedIndex = ddlMacTrnType.Items.IndexOf(ddlMacTrnType.Items.FindByValue(Convert.ToInt16(dt.Rows[0]["MachineINOUTType"]).ToString()));
            if (dt.Rows[0]["MachineExport"] != DBNull.Value) { chkExportData.Checked = Convert.ToBoolean(dt.Rows[0]["MachineExport"]); } else { chkExportData.Checked = false; }
            
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
    //protected void FillInfoLabel(string pID, string pName)
    //{
    //    if (String.IsNullOrEmpty(pID) == false) { pID = "              ID : " + pID + "-----------"; }
    //    if (String.IsNullOrEmpty(pName) == false) { pName = "            Name : " + pName + "           "; }

    //    epnlData.CollapsedText = pID + pName + "(Show Details...)";
    //    epnlData.ExpandedText = pID + pName + "(Hide Details)";
    //}
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
    protected void IPAddress_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        string sqlUpdate = string.Empty;
        sqlUpdate = ViewState["CommandName"].ToString() == "Edit" ? " AND MacID != " + txtMachineID.Text : "";

        try
        {
            if (source.Equals(cvIPAddress))
            {
                if (!string.IsNullOrEmpty(txtIPAddress.Text))
                {
                    dt = DBCs.FetchData("SELECT * FROM MachineInfoView WHERE IPAddress = '" + txtIPAddress.Text + "' " + sqlUpdate);
                    if (!DBCs.IsNullOrEmpty(dt))
                    {
                        MessageFun.ValidMsg(this, ref cvIPAddress, true, General.Msg("IP Address already exists,Please enter different IP", "رقم IP موجود مسبقا ,من فضلك ادخل رقما آخر"));
                        e.IsValid = false;
                        return;
                    }
                }
            }
        }
        catch { e.IsValid = false; }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void MachineNo_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        string sqlUpdate = string.Empty;
        sqlUpdate = ViewState["CommandName"].ToString() == "Edit" ? " AND MacID != " + txtMachineID.Text : "";
        try
        {
            if (source.Equals(cvMachineNo))
            {
                if (!string.IsNullOrEmpty(txtMachineNo.Text))
                {
                    dt = DBCs.FetchData("SELECT * FROM MachineInfoView WHERE MachineNo = '" + txtMachineNo.Text + "' " + sqlUpdate);
                    if (!DBCs.IsNullOrEmpty(dt))
                    {
                        MessageFun.ValidMsg(this, ref cvMachineNo, true, General.Msg("Machine No. already exists,Please enter another No.", "رقم المكينة موجود مسبقا ,من فضلك ادخل رقما آخر"));
                        e.IsValid = false;
                        return;
                    }
                }
            }

            if (source.Equals(cvMacSerialNo))
            {
                if (!string.IsNullOrEmpty(txtMacSerialNo.Text))
                {
                    dt = DBCs.FetchData("SELECT * FROM MachineInfoView WHERE MachineSerialNo = '" + txtMacSerialNo.Text + "' " + sqlUpdate);
                    if (!DBCs.IsNullOrEmpty(dt))
                    {
                        MessageFun.ValidMsg(this, ref cvMacSerialNo, true, General.Msg("Machine Serial No. already exists,Please enter another No.", "رقم المكينة التسلسلي موجود مسبقا ,من فضلك ادخل رقما آخر"));
                        e.IsValid = false;
                        return;
                    }
                }
            }
        }
        catch { e.IsValid = false; }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void cvLocation_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        string sqlUpdate = string.Empty;
        sqlUpdate = ViewState["CommandName"].ToString() == "Edit" ? " AND MacID != " + txtMachineID.Text : "";
        try
        {
            if (source.Equals(cvLocationAr))
            {
                if (!string.IsNullOrEmpty(txtMacLocationAr.Text))
                {
                    dt = DBCs.FetchData("SELECT * FROM MachineInfoView WHERE LocationAr = '" + txtMacLocationAr.Text + "' " + sqlUpdate);
                    if (!DBCs.IsNullOrEmpty(dt))
                    {
                        MessageFun.ValidMsg(this, ref cvLocationAr, true, General.Msg("Location (Ar) already exists,Please enter another Name", "الموقع (ع) موجود مسبقا ,من فضلك ادخل اسم آخر"));
                        e.IsValid = false;
                        return;
                    }
                }
            }

            if (source.Equals(cvLocationEn))
            {
                if (!string.IsNullOrEmpty(txtMacLocationEn.Text))
                {
                    dt = DBCs.FetchData("SELECT * FROM MachineInfoView WHERE LocationEn = '" + txtMacLocationEn.Text + "' " + sqlUpdate);
                    if (!DBCs.IsNullOrEmpty(dt))
                    {
                        MessageFun.ValidMsg(this, ref cvLocationEn, true, General.Msg("Location (En) already exists,Please enter another No.", "الموقع (En) موجود مسبقا ,من فضلك ادخل رقما آخر"));
                        e.IsValid = false;
                        return;
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