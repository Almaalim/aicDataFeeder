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

    string MainQuery = "SELECT * FROM WorkingTime ";
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        //--Common Code----------------------------------------------------------------- //
        FormSession.FillSession("Settings", pageDiv);
        //--Common Code----------------------------------------------------------------- //

        if (!IsPostBack)
        {
            PopulateUI(MainQuery);
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void PopulateUI(string Query)
    {
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            TextTimeServerControl.TextTime.TimeTypeEnum Seconds = TextTimeServerControl.TextTime.TimeTypeEnum.Seconds;

            dt = DBFun.FetchData(Query);
            if (!DBFun.IsNullOrEmpty(dt))
            {
                chkEwrSat.Checked = Convert.ToBoolean(dt.Rows[0]["WktSat"]);
                chkEwrSun.Checked = Convert.ToBoolean(dt.Rows[0]["WktSun"]);
                chkEwrMon.Checked = Convert.ToBoolean(dt.Rows[0]["WktMon"]);
                chkEwrTue.Checked = Convert.ToBoolean(dt.Rows[0]["WktTue"]);
                chkEwrWed.Checked = Convert.ToBoolean(dt.Rows[0]["WktWed"]);
                chkEwrThu.Checked = Convert.ToBoolean(dt.Rows[0]["WktThu"]);
                chkEwrFri.Checked = Convert.ToBoolean(dt.Rows[0]["WktFri"]);

                calStartDate.setDBDate(dt.Rows[0]["WktStartDate"], "S");
                calEndDate.setDBDate(dt.Rows[0]["WktEndDate"], "S");

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

            }
        }
        catch (Exception Ex) { }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void FillPropeties()
    {
        //ProClass.DateFormat = dateType;
        //if (pAction == "Insert" || pAction == "Update")
        //{
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        try
        {
            ProClass.WktSat = chkEwrSat.Checked;
            ProClass.WktSun = chkEwrSat.Checked;
            ProClass.WktMon = chkEwrSat.Checked;
            ProClass.WktTue = chkEwrSat.Checked;
            ProClass.WktWed = chkEwrSat.Checked;
            ProClass.WktThu = chkEwrSat.Checked;
            ProClass.WktFri = chkEwrSat.Checked;
            
            ProClass.WktStartDate = calStartDate.getDate();
            ProClass.WktEndDate = calEndDate.getDate();
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
    void ClearData()
    {
        //txtEmailServer.Text = "";
        //txtEmailPort.Text = "";
        //txtSendEmailFrom.Text = "";
        //txtPassword.Text = "";

        //ViewState["CommandName"] = "";
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void DataItemEnabled(bool pStatus, bool pShift2, bool pShift3)
    {
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

        FillPropeties();
        SqlClass.InsertUpdate(ProClass);

        MessageFun.ShowMsg(this, MessageFun.TypeMsg.Success, General.Msg("WorkTime setting added successfully", "تم تحديث اعدادات وقت العمل بنجاح "));

    }
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
                if (String.IsNullOrEmpty(calStartDate.getDate())) { e.IsValid = false; } else { e.IsValid = true; }
            }
            else if (source.Equals(cvCompareDates))
            {
                if (!String.IsNullOrEmpty(calStartDate.getDate()) && !String.IsNullOrEmpty(calEndDate.getDate()))
                {
                    int iStartDate = DateFun.ConvertDateTimeToInt(FormSession.DateType, calStartDate.getDate());
                    int iEndDate = DateFun.ConvertDateTimeToInt(FormSession.DateType, calEndDate.getDate());
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