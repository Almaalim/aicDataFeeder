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

public partial class Pages_WorkTimeSetting : BasePage
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    DataTable dt;

    WorktimePro ProClass = new WorktimePro();
    WorktimeSql SqlClass = new WorktimeSql();
    DBFun DBCs = new DBFun();
    DateFun DTCs = new DateFun();

    string MainPer = "Set";
    string MainQuery = "SELECT * FROM WorkingTime ";
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        //--Common Code----------------------------------------------------------------- //
        FormSession.FillSession("Settings", pageDiv);
        FormCtrl.RefreshGridEmpty(ref grdData, 20, "No Data Found", "لا توجد بيانات");
        //--Common Code----------------------------------------------------------------- //

        if (!IsPostBack)
        {
            btnAdd.Enabled = FormSession.PermUsr.Contains("U" + MainPer);
            pnlSearch.Enabled = grdData.Enabled = FormSession.PermUsr.Contains("U" + MainPer);
            //PopulateData(MainQuery);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearItem()
    {
        grdData.SelectedIndex = -1;
        //FillInfoLabel("", "");
        DataItemEnabled(false, false, false); ;
        ButtonAction(true, "10000");
        ClearData();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region DataItem Events

    void FillPropeties()
    {
        //ProClass.DateFormat = dateType;
        //if (pAction == "Insert" || pAction == "Update")
        //{
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            if (ViewState["CommandName"].ToString() == "Edit") { ProClass.WktID = txtWktID.Text; }

            ProClass.WktSat = chkEwrSat.Checked;
            ProClass.WktSun = chkEwrSun.Checked;
            ProClass.WktMon = chkEwrMon.Checked;
            ProClass.WktTue = chkEwrTue.Checked;
            ProClass.WktWed = chkEwrWed.Checked;
            ProClass.WktThu = chkEwrThu.Checked;
            ProClass.WktFri = chkEwrFri.Checked;

            ProClass.WktIsActive = chkWktStatus.Checked;
            ProClass.WktStartDate = calStartDate.getGDateDBFormat();
            ProClass.WktEndDate = calEndDate.getGDateDBFormat();
            ProClass.WktShiftCount = FindShiftCount();

            ////Shift 1
            if (!string.IsNullOrEmpty(txtShift1NameAr.Text)) { ProClass.WktShift1NameAr = txtShift1NameAr.Text; }
            if (!string.IsNullOrEmpty(txtShift1NameEn.Text)) { ProClass.WktShift1NameEn = txtShift1NameEn.Text; }
            ProClass.WktShift1From = tpShift1In.getDateTime();
            ProClass.WktShift1To = tpShift1Out.getDateTime();
            ProClass.WktShift1Duration = txtShift1Duration.getTimeInSecond();
            int sGraceTime1 = txtShift1GraceIn.getTimeInSecond();    /****/ ProClass.WktShift1Grace = (sGraceTime1 > 0) ? sGraceTime1 : 0;

            ////Shift 2
            if (chkShift2Set.Checked)
            {
                if (!string.IsNullOrEmpty(txtShift2NameAr.Text)) { ProClass.WktShift2NameAr = txtShift2NameAr.Text; }
                if (!string.IsNullOrEmpty(txtShift2NameEn.Text)) { ProClass.WktShift2NameEn = txtShift2NameEn.Text; }
                if (tpShift2In.getIntTime() >= 0) { ProClass.WktShift2From = tpShift2In.getDateTime(); }
                if (tpShift2Out.getIntTime() >= 0) { ProClass.WktShift2To = tpShift2Out.getDateTime(); }
                int sGraceTime2 = txtShift2GraceIn.getTimeInSecond();    /****/ ProClass.WktShift2Grace = (sGraceTime2 > 0) ? sGraceTime2 : 0;
                int Duration2 = txtShift2Duration.getTimeInSecond();    /****/ ProClass.WktShift2Duration = (Duration2 > 0) ? Duration2 : 0;
            }

            ////Shift 3
            if (chkShift3Set.Checked)
            {
                if (!string.IsNullOrEmpty(txtShift3NameAr.Text)) { ProClass.WktShift3NameAr = txtShift3NameAr.Text; }
                if (!string.IsNullOrEmpty(txtShift3NameEn.Text)) { ProClass.WktShift3NameEn = txtShift3NameEn.Text; }
                if (tpShift3In.getIntTime() >= 0) { ProClass.WktShift3From = tpShift3In.getDateTime(); }
                if (tpShift3Out.getIntTime() >= 0) { ProClass.WktShift3To = tpShift3Out.getDateTime(); }
                int sGraceTime3 = txtShift3GraceIn.getTimeInSecond();    /****/ ProClass.WktShift3Grace = (sGraceTime3 > 0) ? sGraceTime3 : 0;
                int Duration3 = txtShift3Duration.getTimeInSecond();    /****/ ProClass.WktShift3Duration = (Duration3 > 0) ? Duration3 : 0;
            }

            ProClass.TransactionBy = FormSession.LoginID;
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearMainItem()
    {
        grdData.SelectedIndex = -1;
        //FillInfoLabel("", "");
        DataItemEnabled(false, false, false);
        ButtonAction(true, "10000");
        ClearData();
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ClearData()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        txtWktID.Text = "";

        chkEwrSat.Checked = false;
        chkEwrSun.Checked = false;
        chkEwrMon.Checked = false;
        chkEwrTue.Checked = false;
        chkEwrWed.Checked = false;
        chkEwrThu.Checked = false;
        chkEwrFri.Checked = false;

        chkWktStatus.Checked = false;
        calStartDate.ClearDate();
        calEndDate.ClearDate();

        ////Shift 1
        txtShift1NameAr.Text = "";
        txtShift1NameEn.Text = "";
        tpShift1In.ClearTime();
        tpShift1Out.ClearTime();
        txtShift1Duration.ClearTime();
        txtShift1GraceIn.ClearTime();

        ////Shift 2
        txtShift2NameAr.Text = "";
        txtShift2NameEn.Text = "";
        tpShift2In.ClearTime();
        tpShift2Out.ClearTime();
        txtShift2Duration.ClearTime();
        txtShift2GraceIn.ClearTime();

        ////Shift 3
        txtShift3NameAr.Text = "";
        txtShift3NameEn.Text = "";
        tpShift3In.ClearTime();
        tpShift3Out.ClearTime();
        txtShift3Duration.ClearTime();
        txtShift3GraceIn.ClearTime();

        ViewState["CommandName"] = "";
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void DataItemEnabled(bool pStatus, bool pShift2, bool pShift3)
    {
        chkEwrSat.Enabled = pStatus;
        chkEwrSun.Enabled = pStatus;
        chkEwrMon.Enabled = pStatus;
        chkEwrTue.Enabled = pStatus;
        chkEwrWed.Enabled = pStatus;
        chkEwrThu.Enabled = pStatus;
        chkEwrFri.Enabled = pStatus;

        chkWktStatus.Enabled = pStatus;
        calStartDate.SetEnabled(pStatus);
        calEndDate.SetEnabled(pStatus);
        FindShiftCount();

        chkShift2Set.Enabled = pStatus;
        chkShift3Set.Enabled = pStatus;

        //shift 1 info
        txtShift1NameAr.Enabled = pStatus;
        txtShift1NameEn.Enabled = pStatus;
        tpShift1In.Enabled = pStatus;
        tpShift1Out.Enabled = pStatus;
        txtShift1GraceIn.Enabled = pStatus;
        txtShift1Duration.Enabled = pStatus;

        //shift 2 info
        txtShift2NameAr.Enabled = pShift2;
        txtShift2NameEn.Enabled = pShift2;
        tpShift2In.Enabled = pShift2;
        tpShift2Out.Enabled = pShift2;
        txtShift2GraceIn.Enabled = pShift2;
        txtShift2Duration.Enabled = pShift2;

        //shift 3 info
        txtShift3NameAr.Enabled = pShift3;
        txtShift3NameEn.Enabled = pShift3;
        tpShift3In.Enabled = pShift3;
        tpShift3Out.Enabled = pShift3;
        txtShift3GraceIn.Enabled = pShift3;
        txtShift3Duration.Enabled = pShift3;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
            if (ddlSearch.SelectedValue == "WktNameAr") { SearchItemStatus(true, false, "Type Worktime Name (Ar) here"); }
            if (ddlSearch.SelectedValue == "WktNameEn") { SearchItemStatus(true, false, "Type Worktime Name (En) here"); }

            ClearItem();
            FillGrid(MainQuery + "  WktID = '@@@@'");
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
            if (ddlSearch.SelectedValue == "WktNameAr") { SQ.Append(" AND WktNameAr LIKE '%" + txtSearch.Text + "%'"); }
            if (ddlSearch.SelectedValue == "WktNameEn") { SQ.Append(" AND WktNameEn LIKE '%" + txtSearch.Text + "%'"); }
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
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            TextTimeServerControl.TextTime.TimeTypeEnum Seconds = TextTimeServerControl.TextTime.TimeTypeEnum.Seconds;

            dt = DBCs.FetchData(MainQuery + " AND WktID = " + pID + "");
            if (DBCs.IsNullOrEmpty(dt)) { return; }

            txtWktID.Text = dt.Rows[0]["WktID"].ToString();
            chkWktStatus.Checked = Convert.ToBoolean(dt.Rows[0]["WktIsActive"]);

            chkEwrSat.Checked = Convert.ToBoolean(dt.Rows[0]["WktSat"]);
            chkEwrSun.Checked = Convert.ToBoolean(dt.Rows[0]["WktSun"]);
            chkEwrMon.Checked = Convert.ToBoolean(dt.Rows[0]["WktMon"]);
            chkEwrTue.Checked = Convert.ToBoolean(dt.Rows[0]["WktTue"]);
            chkEwrWed.Checked = Convert.ToBoolean(dt.Rows[0]["WktWed"]);
            chkEwrThu.Checked = Convert.ToBoolean(dt.Rows[0]["WktThu"]);
            chkEwrFri.Checked = Convert.ToBoolean(dt.Rows[0]["WktFri"]);

            calStartDate.SetGDate(dt.Rows[0]["WktStartDate"], "S");
            calEndDate.SetGDate(dt.Rows[0]["WktEndDate"], "S");

            //Shift 1
            txtShift1NameAr.Text = dt.Rows[0]["WktShift1NameAr"].ToString();
            txtShift1NameEn.Text = dt.Rows[0]["WktShift1NameEn"].ToString();
            if (dt.Rows[0]["WktShift1From"] != DBNull.Value) { tpShift1In.SetTime(Convert.ToDateTime(dt.Rows[0]["WktShift1From"])); }
            if (dt.Rows[0]["WktShift1To"] != DBNull.Value) { tpShift1Out.SetTime(Convert.ToDateTime(dt.Rows[0]["WktShift1To"])); }
            if (dt.Rows[0]["WktShift1Duration"] != DBNull.Value) { txtShift1Duration.SetTime(Convert.ToInt32(dt.Rows[0]["WktShift1Duration"]), Seconds); }
            if (dt.Rows[0]["WktShift1Grace"] != DBNull.Value) { txtShift1GraceIn.SetTime(Convert.ToInt32(dt.Rows[0]["WktShift1Grace"]), Seconds); }

            //Shift 2
            if (chkShift2Set.Checked)
            {
                txtShift2NameAr.Text = dt.Rows[0]["WktShift2NameAr"].ToString();
                txtShift2NameEn.Text = dt.Rows[0]["WktShift2NameEn"].ToString();
                if (dt.Rows[0]["WktShift2From"] != DBNull.Value) { tpShift2In.SetTime(Convert.ToDateTime(dt.Rows[0]["WktShift2From"])); }
                if (dt.Rows[0]["WktShift2To"] != DBNull.Value) { tpShift2Out.SetTime(Convert.ToDateTime(dt.Rows[0]["WktShift2To"])); }
                if (dt.Rows[0]["WktShift2Duration"] != DBNull.Value) { txtShift2Duration.SetTime(Convert.ToInt32(dt.Rows[0]["WktShift2Duration"]), Seconds); }
                if (dt.Rows[0]["WktShift2Grace"] != DBNull.Value) { txtShift2GraceIn.SetTime(Convert.ToInt32(dt.Rows[0]["WktShift2Grace"]), Seconds); }
            }
            //Shift 3
            if (chkShift2Set.Checked)
            {
                txtShift3NameAr.Text = dt.Rows[0]["WktShift3NameAr"].ToString();
                txtShift3NameEn.Text = dt.Rows[0]["WktShift3NameEn"].ToString();
                if (dt.Rows[0]["WktShift3From"] != DBNull.Value) { tpShift3In.SetTime(Convert.ToDateTime(dt.Rows[0]["WktShift3From"])); }
                if (dt.Rows[0]["WktShift3To"] != DBNull.Value) { tpShift3Out.SetTime(Convert.ToDateTime(dt.Rows[0]["WktShift3To"])); }
                if (dt.Rows[0]["WktShift3Duration"] != DBNull.Value) { txtShift3Duration.SetTime(Convert.ToInt32(dt.Rows[0]["WktShift3Duration"]), Seconds); }
                if (dt.Rows[0]["WktShift3Grace"] != DBNull.Value) { txtShift3GraceIn.SetTime(Convert.ToInt32(dt.Rows[0]["WktShift3Grace"]), Seconds); }
            }

            ButtonAction(true, "11100");
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void FillGrid(string Q)
    {
        dt = DBCs.FetchData(Q);
        if (!DBCs.IsNullOrEmpty(dt) && FormSession.PermUsr.Contains("U" + MainPer))
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
                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Worktime added successfully", "تمت إضافة وقت العمل بنجاح"));
            }

            if (ViewState["CommandName"].ToString() == "Edit")
            {
                SqlClass.Update(ProClass);
                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Worktime updated successfully", "تم تعديل وقت العمل بنجاح"));
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
        DataItemEnabled(true, chkShift2Set.Checked, chkShift3Set.Checked);
        ButtonAction(false, "00011");

        ViewState["CommandName"] = "Add";
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        ViewState["CommandName"] = "Edit";
        DataItemEnabled(true, chkShift2Set.Checked, chkShift3Set.Checked);
        ButtonAction(false, "00011");
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string Q = " SELECT MacID FROM TransDump WHERE MacID = " + txtWktID.Text + " ";
        try
        {
            dt = DBCs.FetchData(Q);
            if (!DBCs.IsNullOrEmpty(dt))
            {
                MessageFun.ShowMsg(this, MessageFun.TypeMsg.Error, General.Msg("Deletion can not because of the presence of related records", "لا يمكن الحذف بسبب وجود سجلات مرتبطة"));
            }
            else
            {
                ProClass.WktID = txtWktID.Text;
                bool resExc = SqlClass.Delete(ProClass);
                if (resExc) { MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("Worktime deleted successfully", "تم حذف وقت العمل بنجاح")); }

                ClearItem();
                Search();
            }
        }
        catch (Exception Ex) { MessageFun.ShowAdminMsg(this, Ex.Message); }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ButtonAction(true, "10000");
        DataItemEnabled(false, false, false);

        if (ViewState["CommandName"].ToString() == "Add") { ClearData(); }
        if (ViewState["CommandName"].ToString() == "Edit") { PopulateData(txtWktID.Text); }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
    protected void ButtonAction(bool pSearch, string pBtn) //string pBtn = [ADD,Edit,Delete,Save,Cancel]
    {
        if (FormSession.PermUsr.Contains("U" + MainPer)) { pnlSearch.Enabled = pSearch; } else { pnlSearch.Enabled = false; }
        if (FormSession.PermUsr.Contains("U" + MainPer)) { grdData.Enabled = pSearch; } else { grdData.Enabled = false; }

        if (FormSession.PermUsr.Contains("U" + MainPer)) { btnAdd.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[0].ToString())); } else { btnAdd.Enabled = false; }
        if (FormSession.PermUsr.Contains("U" + MainPer)) { btnEdit.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[1].ToString())); } else { btnEdit.Enabled = false; }
        if (FormSession.PermUsr.Contains("U" + MainPer)) { btnDelete.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[2].ToString())); } else { btnDelete.Enabled = false; }

        btnCancel.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[3].ToString()));
        btnSave.Enabled = Convert.ToBoolean(Convert.ToInt32(pBtn[4].ToString()));
    }

    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void chkShift2Setting_CheckedChanged(object sender, EventArgs e)
    {
        DataItemEnabled(true, chkShift2Set.Checked, chkShift3Set.Checked);
        if (!chkShift2Set.Checked)
        {
            //shift 2 info  
            txtShift2NameAr.Text = "";
            txtShift2NameEn.Text = "";
            tpShift2In.ClearTime();
            tpShift2Out.ClearTime();
            txtShift2GraceIn.ClearTime();
            txtShift2Duration.ClearTime();
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void chkShift3Setting_CheckedChanged(object sender, EventArgs e)
    {
        DataItemEnabled(true, chkShift2Set.Checked, chkShift3Set.Checked);
        if (!chkShift3Set.Checked)
        {
            //shift 3 info  
            txtShift3NameAr.Text = "";
            txtShift3NameEn.Text = "";
            tpShift3In.ClearTime();
            tpShift3Out.ClearTime();
            txtShift3GraceIn.ClearTime();
            txtShift3Duration.ClearTime();
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected int FindShiftCount()
    {
        int Count = 1;
        if (chkShift2Set.Checked) { Count = 2; }
        if (chkShift3Set.Checked) { Count = 3; }

        return Count;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnCalShift1Duration_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) { return; }

        int Duration = 0;
        int FromTime = tpShift1In.getIntTime();
        int ToTime = tpShift1Out.getIntTime();


        if (FromTime >= 2400) { FromTime = FromTime - 2400; }
        if (ToTime >= 2400) { ToTime = ToTime - 2400; }

        FromTime = Convert.ToInt32(countDigit(FromTime.ToString()).Substring(0, 2)) * 60 + Convert.ToInt32(countDigit(FromTime.ToString()).Substring(2, 2));
        ToTime = Convert.ToInt32(countDigit(ToTime.ToString()).Substring(0, 2)) * 60 + Convert.ToInt32(countDigit(ToTime.ToString()).Substring(2, 2));


        Duration = ToTime - FromTime;
        txtShift1Duration.SetTime(Duration, TextTimeServerControl.TextTime.TimeTypeEnum.Minutes);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnCalShift2Duration_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) { return; }

        int Duration = 0;
        int FromTime = tpShift2In.getIntTime();
        int ToTime = tpShift2Out.getIntTime();

        if (FromTime >= 2400) { FromTime = FromTime - 2400; }
        if (ToTime >= 2400) { ToTime = ToTime - 2400; }

        FromTime = Convert.ToInt32(countDigit(FromTime.ToString()).Substring(0, 2)) * 60 + Convert.ToInt32(countDigit(FromTime.ToString()).Substring(2, 2));
        ToTime = Convert.ToInt32(countDigit(ToTime.ToString()).Substring(0, 2)) * 60 + Convert.ToInt32(countDigit(ToTime.ToString()).Substring(2, 2));

        Duration = ToTime - FromTime;
        txtShift2Duration.SetTime(Duration, TextTimeServerControl.TextTime.TimeTypeEnum.Minutes);

    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnCalShift3Duration_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) { return; }

        int Duration = 0;
        int FromTime = tpShift3In.getIntTime();
        int ToTime = tpShift3Out.getIntTime();

        if (FromTime >= 2400) { FromTime = FromTime - 2400; }
        if (ToTime >= 2400) { ToTime = ToTime - 2400; }

        FromTime = Convert.ToInt32(countDigit(FromTime.ToString()).Substring(0, 2)) * 60 + Convert.ToInt32(countDigit(FromTime.ToString()).Substring(2, 2));
        ToTime = Convert.ToInt32(countDigit(ToTime.ToString()).Substring(0, 2)) * 60 + Convert.ToInt32(countDigit(ToTime.ToString()).Substring(2, 2));

        Duration = ToTime - FromTime;
        txtShift3Duration.SetTime(Duration, TextTimeServerControl.TextTime.TimeTypeEnum.Minutes);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected string countDigit(string pTime)
    {
        if (pTime.Length == 1) { return "000" + pTime; }
        else if (pTime.Length == 2) { return "00" + pTime; }
        else if (pTime.Length == 3) { return "0" + pTime; }
        else { return pTime; }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    if (!Page.IsValid)
    //    {
    //        ValidatorCollection ValidatorColl = Page.Validators;
    //        for (int k = 0; k < ValidatorColl.Count; k++)
    //        {
    //            if (!ValidatorColl[k].IsValid && !String.IsNullOrEmpty(ValidatorColl[k].ErrorMessage)) { vsSave.ShowSummary = true; return; }
    //            vsSave.ShowSummary = false;
    //        }
    //        return;
    //    }

    //    FillPropeties();
    //    SqlClass.InsertUpdate(ProClass);

    //    MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("WorkTime setting added successfully", "تم تحديث اعدادات وقت العمل بنجاح "));

    //}
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*##############################################################################################################################*/
    /*##############################################################################################################################*/
    #region Custom Validate Events
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void ShowMsg_ServerValidate(Object source, ServerValidateEventArgs e) { e.IsValid = false; }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void DateValidate_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        try
        {
            if (source.Equals(cvCalStartDateEmpty))
            {
                if (String.IsNullOrEmpty(calStartDate.getGDateDBFormat())) { e.IsValid = false; } else { e.IsValid = true; }
            }
            else if (source.Equals(cvCompareDates))
            {
                if (!String.IsNullOrEmpty(calStartDate.getGDateDBFormat()) && !String.IsNullOrEmpty(calEndDate.getGDateDBFormat()))
                {
                    int iStartDate = DTCs.ConvertDateTimeToInt(FormSession.DateType, calStartDate.getGDateDBFormat());
                    int iEndDate = DTCs.ConvertDateTimeToInt(FormSession.DateType, calEndDate.getGDateDBFormat());
                    if (iStartDate > iEndDate) { e.IsValid = false; } else { e.IsValid = true; }
                }
            }
        }
        catch { e.IsValid = false; }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void SelectWorkDays_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        try
        {
            if (!chkEwrSat.Checked && !chkEwrSun.Checked && !chkEwrMon.Checked && !chkEwrTue.Checked && !chkEwrWed.Checked && !chkEwrThu.Checked && !chkEwrFri.Checked)
            {
                e.IsValid = false;
            }
            else { e.IsValid = true; }
        }
        catch { e.IsValid = false; }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Shift1Validate_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        try
        {
            if (source.Equals(cvShift1Duration))
            {
                if (txtShift1Duration.getTimeInSecond() <= 0) { e.IsValid = false; } else { e.IsValid = true; }
            }
            else if (source.Equals(cvShift1Time) || source.Equals(cvShift1Cal))
            {
                if (tpShift2In.getIntTime() >= 0 && tpShift1Out.getIntTime() >= 0)
                {
                    int FromTime = tpShift1In.getIntTime();
                    int ToTime = tpShift1Out.getIntTime();

                    if (FromTime >= 2400) { FromTime = FromTime - 2400; }
                    if (ToTime >= 2400) { ToTime = ToTime - 2400; }

                    if (ToTime > FromTime) { e.IsValid = true; } else { e.IsValid = false; }
                }
                else { e.IsValid = false; }
            }
        }
        catch
        {
            e.IsValid = false;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Shift2Validate_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        try
        {
            if (chkShift2Set.Checked)
            {

                if (source.Equals(cvShift2Duration))
                {
                    if (txtShift2Duration.getTimeInSecond() <= 0) { e.IsValid = false; } else { e.IsValid = true; }
                }
                else if (source.Equals(cvShift2Time) || source.Equals(cvShift2Cal))
                {
                    if (tpShift2In.getIntTime() >= 0 && tpShift2Out.getIntTime() >= 0)
                    {
                        int FromTime = tpShift2In.getIntTime();
                        int ToTime = tpShift2Out.getIntTime();

                        if (FromTime >= 2400) { FromTime = FromTime - 2400; }
                        if (ToTime >= 2400) { ToTime = ToTime - 2400; }

                        if (ToTime > FromTime) { e.IsValid = true; } else { e.IsValid = false; }
                    }
                    else { e.IsValid = false; }
                }

                else if (source.Equals(cvOrderShfit2))
                {
                    if (chkShift2Set.Checked)
                    {
                        if (tpShift1Out.getIntTime() >= 0 && tpShift2In.getIntTime() >= 0)
                        {
                            int ToTime1 = tpShift1Out.getIntTime();
                            int FromTime2 = tpShift2In.getIntTime();

                            if (ToTime1 > FromTime2) { e.IsValid = false; } else { e.IsValid = true; }
                        }
                    }
                }
            }
        }
        catch
        {
            e.IsValid = false;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Shift3Validate_ServerValidate(Object source, ServerValidateEventArgs e)
    {
        try
        {
            if (chkShift3Set.Checked)
            {
                if (source.Equals(cvShift3Duration))
                {
                    if (txtShift3Duration.getTimeInSecond() <= 0) { e.IsValid = false; } else { e.IsValid = true; }
                }
                else if (source.Equals(cvShift3Time) || source.Equals(cvShift3Cal))
                {
                    if (tpShift3In.getIntTime() >= 0 && tpShift3Out.getIntTime() >= 0)
                    {
                        int FromTime = tpShift3In.getIntTime();
                        int ToTime = tpShift3Out.getIntTime();

                        if (FromTime >= 2400) { FromTime = FromTime - 2400; }
                        if (ToTime >= 2400) { ToTime = ToTime - 2400; }

                        if (ToTime > FromTime) { e.IsValid = true; } else { e.IsValid = false; }
                    }
                    else { e.IsValid = false; }
                }

                else if (source.Equals(cvOrderShfit3))
                {
                    if (chkShift3Set.Checked)
                    {
                        if (tpShift1Out.getIntTime() >= 0 && tpShift1Out.getIntTime() >= 0 && tpShift3In.getIntTime() >= 0)
                        {
                            int ToTime1 = tpShift1Out.getIntTime();
                            int FromTime2 = tpShift2In.getIntTime();
                            int ToTime2 = tpShift2Out.getIntTime();
                            int FromTime3 = tpShift3In.getIntTime();

                            if (ToTime1 > FromTime3 || ToTime2 > FromTime3) { e.IsValid = false; }
                            else { e.IsValid = true; }
                        }
                    }
                }
            }
        }
        catch
        {
            e.IsValid = false;
        }
    }
    #endregion
    /*##############################################################################################################################*/
    /*##############################################################################################################################*/

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
}