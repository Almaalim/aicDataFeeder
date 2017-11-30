using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;

public class DateFun
{
    private HttpContext cur;

    private CultureInfo arCul;
    private CultureInfo enCul;
    private string[] allFormats = { "yyyy/MM/dd", "yyyy/M/d", "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "yyyy-MM-dd", "yyyy-M-d", "dd-MM-yyyy", "d-M-yyyy", "dd-M-yyyy", "d-MM-yyyy", "yyyy MM dd", "yyyy M d", "dd MM yyyy", "d M yyyy", "dd M yyyy", "d MM yyyy" };
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    static GregorianCalendar Grn = new GregorianCalendar();
    static UmAlQuraCalendar Umq = new UmAlQuraCalendar();
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public enum CalenderType { G, H };

    string[] GMEn = { "", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    string[] GMAr = { "", "يناير", "فبراير", "مارس", "ابريل", "مايو", "يونيو", "يوليو", "اغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر" };

    string[] HMEn = { "", "Muharram", "Safar", "Rabii I", "Rabii II", "Jumada I", "Jumada II", "Rajab", "Sha'aban", "Ramadan", "Shawwal", "Dhu al-Qa'aida", "Dhual-Hijja" };
    string[] HMAr = { "", "محرم", "صفر", "ربيع اول", "ربيع ثاني", "جمادى الأول", "جمادى الثاني", "رجب", "شعبان", "رمضان", "شوال", "ذو القعدة", "ذو الحجة" };
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public DateTime HijToGrn(string pHdate)
    {      
        string[] PartDate = pHdate.Split('/');
        int day, month, year;
        Int32.TryParse(PartDate[0], out day);
        Int32.TryParse(PartDate[1], out month);
        Int32.TryParse(PartDate[2], out year);
        return new DateTime(year, month, day, Umq);
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string GrnToHij(DateTime pGdate)
    {
        int year  = Umq.GetYear(pGdate);
        int month = Umq.GetMonth(pGdate);
        int day   = Umq.GetDayOfMonth(pGdate);
        return fd(day.ToString()) + "/" + fd(month.ToString()) + "/" + year.ToString();
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string GrnToHij(string pGdate)
    {
        int year  = Umq.GetYear(Convert.ToDateTime(pGdate));
        int month = Umq.GetMonth(Convert.ToDateTime(pGdate));
        int day   = Umq.GetDayOfMonth(Convert.ToDateTime(pGdate));
        return day.ToString() + "/" + month.ToString() + "/" + year.ToString();
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public DateTime strTodt(string pStrDate)
    {
        if (!string.IsNullOrEmpty(pStrDate))
        {
            string[] partDT = pStrDate.Split(' ');

            string[] PartDate = partDT[0].Split('/');
            int day, month, year;
            Int32.TryParse(PartDate[0], out day);
            Int32.TryParse(PartDate[1], out month);
            Int32.TryParse(PartDate[2], out year);
            return new DateTime(year, month, day);
        }
        else { return new DateTime(); }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void YearPopulateList(ref DropDownList ddl, string pDateType, bool IsAll)
    {
        if (IsAll) { ListItem _li = new ListItem(General.Msg("All", "الكل"), "0"); /**/  ddl.Items.Add(_li); }

        if (pDateType == "Gregorian")
        {
            Int32 Y = Convert.ToInt32(FindCurrentYear("Gregorian"));

            int minYear = 1997; //DateTime.Now.Year - 5;
            int maxYear = Y + 10; //DateTime.Now.Year

            for (int i = maxYear; i >= minYear; i--) { ddl.Items.Add(i.ToString()); }

            ddl.Items.FindByValue(Y.ToString()).Selected = true;
        }
        else if (pDateType == "Hijri")
        {
            //string date = HDateNow("dd/MM/yyyy"); //GregToHijri(DateTime.Now.ToString("dd/MM/yyyy"));

            //string[] arrDate = date.Split('/');
            //Int32 Y = Convert.ToInt32(arrDate[0]);
            //Int32 M = Convert.ToInt32(arrDate[1]);
            //Int32 D = Convert.ToInt32(arrDate[2]);

            Int32 Y = Convert.ToInt32(FindCurrentYear("Hijri"));

            int minYear = 1400; //Y - 5;
            int maxYear = 1450;

            for (int i = maxYear; i >= minYear; i--) { ddl.Items.Add(i.ToString()); }

            ddl.Items.FindByValue(Y.ToString()).Selected = true;
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void PopulateGreYear(ref DropDownList ddl)
    {
        int minYear = DateTime.Now.Year - 70;
        int maxYear = DateTime.Now.Year + 10;
        for (int i = minYear; i <= maxYear; i++) { ddl.Items.Add(i.ToString()); }
        ddl.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void PopulateHijYear(ref DropDownList ddl)
    {
        string StrDate = GrnToHij(DateTime.Now);

        string[] PartDate = StrDate.Split('/');
        Int32 Y = Convert.ToInt32(PartDate[2]);
        int minYear = Y - 70;
        int maxYear = 1450;

        for (int i = minYear; i <= maxYear; i++) { ddl.Items.Add(i.ToString()); }
        ddl.Items.FindByValue(Y.ToString()).Selected = true;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void YearPopulateList(ref DropDownList ddl)
    {
        //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        //pgCs.FillDTSession();
        
        YearPopulateList(ref ddl, FormSession.DateType , false);
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void YearGPopulateList(ref DropDownList ddl)
    {
        //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        //pgCs.FillDTSession();
        YearPopulateList(ref ddl, "Gregorian", false);
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void YearHPopulateList(ref DropDownList ddl)
    {
        //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        YearPopulateList(ref ddl, "Hijri", false);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void PopulateGreMonth(ref DropDownList ddl)
    {
        string[] MonthsEn = { "", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        string[] MonthsAr = { "", "يناير", "فبراير", "مارس", "ابريل", "مايو", "يونيو", "يوليو", "اغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر" };
        ListItem item;

        ddl.Items.Clear();
        for (int i = 1; i < MonthsEn.Length; i++)
        {
            item = new ListItem();
            if (HttpContext.Current.Session["Language"].ToString() == "Ar") { item.Text = MonthsAr[i]; } else { item.Text = MonthsEn[i]; }
            item.Value = i.ToString();
            ddl.Items.Add(item);
        }
        ddl.SelectedIndex = DateTime.Now.Month - 1;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void PopulateHijMonth(ref DropDownList ddl)
    {
        string[] MonthsEn = { "", "Muharram", "Safar", "Rabii I", "Rabii II", "Jumada I", "Jumada II", "Rajab", "Sha'aban", "Ramadan", "Shawwal", "Dhu al-Qa'aida", "Dhual-Hijja" };
        string[] MonthsAr = { "", "محرم", "صفر", "ربيع اول", "ربيع ثاني", "جمادى الأول", "جمادى الثاني", "رجب", "شعبان", "رمضان", "شوال", "ذو القعدة", "ذو الحجة" };
        ListItem item;

        ddl.Items.Clear();
        for (int i = 1; i < MonthsEn.Length; i++)
        {
            item = new ListItem();
            if (HttpContext.Current.Session["Language"].ToString() == "Ar") { item.Text = MonthsAr[i]; } else { item.Text = MonthsEn[i]; }
            item.Value = i.ToString();
            ddl.Items.Add(item);
        }

        string date = GrnToHij(DateTime.Now);
        string[] arrDate = date.Split('/');
        Int32 M = Convert.ToInt32(arrDate[1]);
        ddl.SelectedIndex = M - 1;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void MonthPopulateList(ref DropDownList ddl, string pDateType, bool IsAll)
    {
        ListItem item = new ListItem();
        ddl.Items.Clear();

        if (IsAll) { ListItem _li = new ListItem(General.Msg("All", "الكل"), "0"); /**/  ddl.Items.Add(_li); }

        for (int i = 1; i < 13; i++)
        {
            item = new ListItem();

            if (pDateType == "Gregorian") { item.Text = General.Msg(GMEn[i], GMAr[i]); } else if (pDateType == "Hijri") { item.Text = General.Msg(HMEn[i], HMAr[i]); }
            item.Value = i.ToString();
            ddl.Items.Add(item);
        }

        if (pDateType == "Gregorian")
        {
            if (IsAll) { ddl.SelectedIndex = DateTime.Now.Month; } else { ddl.SelectedIndex = DateTime.Now.Month - 1; }
        }
        else if (pDateType == "Hijri")
        {
            string date = HDateNow("dd/MM/yyyy");// GregToHijri(DateTime.Now.ToString("dd/MM/yyyy"));
            string[] arrDate = date.Split('/');
            Int32 M = Convert.ToInt32(arrDate[1]);
            if (IsAll) { ddl.SelectedIndex = M; } else { ddl.SelectedIndex = M - 1; }
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////   
    public void MonthGPopulateList(ref DropDownList ddl)
    {
        MonthPopulateList(ref ddl, "Gregorian", false);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void MonthHPopulateList(ref DropDownList ddl)
    {
        MonthPopulateList(ref ddl, "Hijri", false);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void MonthPopulateList(ref DropDownList ddl)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        //pgCs.FillDTSession();

        MonthPopulateList(ref ddl, FormSession.DateType, false);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void MonthPopulateList(ref CheckBoxList _cbl, string DateType)
    {
        ListItem item = new ListItem();

        for (int i = 1; i < 13; i++)
        {
            item = new ListItem();

            if (DateType == "Gregorian") { item.Text = General.Msg(GMEn[i], GMAr[i]); } else if (DateType == "Hijri") { item.Text = General.Msg(HMEn[i], HMAr[i]); }
            item.Value = i.ToString();
            _cbl.Items.Add(item);
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string fd(string dt) { if (dt.Length < 2) { return "0" + dt; } else { return dt; } }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string FindCurrentYear(string DateType)
    {
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            if (DateType == "Gregorian") { return Grn.GetYear(DateTime.Now).ToString(); } else if (DateType == "Hijri") { return Umq.GetYear(DateTime.Now).ToString(); }

            return "0";
        }
        catch (Exception ex)
        {
            //ErrorSignal.FromCurrentContext().Raise(ex);
            return "0";
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string displayDateGrd(object pGre, string pDateType)
    {
        if (pGre == DBNull.Value) { return ""; }
        
        DateTime greg = (DateTime)pGre;
        
        if (pDateType == "Gregorian")
        {      
            return greg.ToString("dd/MM/yyyy");
        }
        else
        {
            int year  = Umq.GetYear(greg);
            int month = Umq.GetMonth(greg);
            int day   = Umq.GetDayOfMonth(greg);
            return fd(year.ToString()) + "/" + fd(month.ToString()) + "/" + fd(day.ToString());
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string GrdDisplayDate(object pDate,object pType)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        string DType = "Gregorian";

        if (pDate != DBNull.Value && pType != DBNull.Value) 
        { 
            DateTime date = (DateTime)pDate;
            if      (pType.ToString() == "S") { DType = HttpContext.Current.Session["DateFormat"].ToString(); }
            else if (pType.ToString() == "G") { DType = "Gregorian"; } 
            else if (pType.ToString() == "H") { DType = "Hijri"; }

            if (DType == "Gregorian") { return fd(Grn.GetDayOfMonth(date).ToString()) + "/" + fd(Grn.GetMonth(date).ToString()) + "/" + fd(Grn.GetYear(date).ToString()); }
            if (DType == "Hijri")     { return GrnToHij(Convert.ToDateTime(pDate)).ToString(); }
        } 
        else { return null; }

        return null;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string GrdDisplayDateTime(object pDate,object pType)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        string DType = "Gregorian";

        if (pDate != DBNull.Value && pType != DBNull.Value) 
        { 
            DateTime date = (DateTime)pDate;

            string Time = fd(Grn.GetHour(date).ToString()) + ":" + fd(Grn.GetMinute(date).ToString());
            
            if      (pType.ToString() == "S") { DType = HttpContext.Current.Session["DateFormat"].ToString(); }
            else if (pType.ToString() == "G") { DType = "Gregorian"; } 
            else if (pType.ToString() == "H") { DType = "Hijri"; }

            if (DType == "Gregorian") { return fd(Grn.GetDayOfMonth(date).ToString()) + "/" + fd(Grn.GetMonth(date).ToString()) + "/" + fd(Grn.GetYear(date).ToString()) + " " + Time; }
            if (DType == "Hijri")     { return GrnToHij(Convert.ToDateTime(pDate)).ToString() + " " + Time; }
        } 
        else { return null; }

        return null;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string GrdDisplayDate(object pDate)
    {
        string DateType = HttpContext.Current.Session["DateFormat"].ToString();

        if (pDate == DBNull.Value) { return ""; }
        
        DateTime date = (DateTime)pDate;
        
        if (DateType == "Gregorian") { return String.Format("{0:dd/MM/yyyy}", date); }
        else { return fd(Umq.GetYear(date).ToString()) + "/" + fd(Umq.GetMonth(date).ToString()) + "/" + fd(Umq.GetDayOfMonth(date).ToString()); }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string ToAnyFormat(string pDateType, object pDate)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        if (pDate != DBNull.Value)
        {
            if (pDateType == "Gregorian") { return (Convert.ToDateTime(pDate)).ToString("dd/MM/yyyy"); }
            else if (pDateType == "Hijri") { return GrnToHij(Convert.ToDateTime(pDate)).ToString(); }
            else { return string.Empty; }
        }
        else
        {
            return string.Empty;
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public int ConvertDateTimeToInt(string pDateType, string pDate)
    {
        string[] PartDate = pDate.Split('/'); //(General.ToAnyFormat(pDateType, pDate)).Split('/');
        string Y = PartDate[2];
        string M = PartDate[1];
        string D = PartDate[0];
        return (Convert.ToInt32(Y) * 10000) + (Convert.ToInt32(M) * 100) + Convert.ToInt32(D);
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string ToDefFormat(string pDate, string pDateType)
    {
        if (pDateType == "Gregorian") { return FormatGreg(pDate, "dd/MM/yyyy"); } else { return FormatHijri(pDate, "dd/MM/yyyy"); }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string ToDBFormat(string pDate, string pDateType)
    {
        if (pDateType == "Gregorian") { return FormatGreg(pDate, "MM/dd/yyyy"); } else { return FormatHijri(pDate, "MM/dd/yyyy"); }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string SelectDateFormat(string pDateType, string pDate)
    {
        string strValue = "";
        if (pDateType == "Gregorian")  { strValue = strTodt(String.Format("{0:dd/MM/yyyy}", pDate)).ToShortDateString(); }
        else if (pDateType == "Hijri") { strValue = HijToGrn(pDate).ToShortDateString(); }

        return strValue;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string SaveDB(Char pDateType, string pDate)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        string strValue = "";
        string DType = "Gregorian";

        if      (pDateType == 'S') { DType = HttpContext.Current.Session["DateFormat"].ToString(); } 
        else if (pDateType == 'G') { DType = "Gregorian"; } 
        else if (pDateType == 'H') { DType = "Hijri"; }


        if      (DType == "Gregorian")  { strValue = strTodt(String.Format("{0:dd/MM/yyyy}", pDate)).ToShortDateString(); }
        else if (DType == "Hijri")      { strValue = HijToGrn(pDate).ToShortDateString(); }

        return strValue;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public DateTime GetGregDateTime(string pDate,Char pDateType, string Time)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        DateTime DValue = new DateTime();
        string DType = "Gregorian";

        if      (pDateType == 'S') { DType = HttpContext.Current.Session["DateFormat"].ToString(); } 
        else if (pDateType == 'G') { DType = "Gregorian"; } 
        else if (pDateType == 'H') { DType = "Hijri"; }


        if      (DType == "Gregorian")  { DValue = strToDatetime(String.Format("{0:dd/MM/yyyy}", pDate), Time); }
        else if (DType == "Hijri")      { DValue = HijToGrnDatetime(pDate, Time); }

        return DValue;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////   
    public DateTime strToDatetime(string pStrDate,string Time)
    {
        if (!string.IsNullOrEmpty(pStrDate))
        {
            string[] PartDate = pStrDate.Split('/');
            int day, month, year;
            Int32.TryParse(PartDate[0], out day);
            Int32.TryParse(PartDate[1], out month);
            Int32.TryParse(PartDate[2], out year);

            if (Time == "T") { return new DateTime(year, month, day, 23, 59, 59); }
            else /* (Time == "F") */ { return new DateTime(year, month, day, 0, 0, 0); }  
        }
        else { return new DateTime(); }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    public DateTime HijToGrnDatetime(string pHdate,string Time)
    {      
        string[] PartDate = pHdate.Split('/');
        int day, month, year;
        Int32.TryParse(PartDate[0], out day);
        Int32.TryParse(PartDate[1], out month);
        Int32.TryParse(PartDate[2], out year);

        if (Time == "T") { return new DateTime(year, month, day, 23, 59, 59, Umq); }
        else /* (Time == "F") */ { return new DateTime(year, month, day, 0, 0, 0, Umq); } 
        
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string dtToStr_ddMMyyyy(DateTime pGdate)
    {
        int year  = pGdate.Year;
        int month = pGdate.Month;
        int day   = pGdate.Day;
        return fd(day.ToString()) + "/" + fd(month.ToString()) + "/" + fd(year.ToString());
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string FormatKAMCDate(string pDate)
    {
        if (!string.IsNullOrEmpty(pDate) && pDate.Length == 8)
        {
            string y = pDate.Substring(0, 4);
            string m = pDate.Substring(4, 2);
            string d = pDate.Substring(6, 2);
            
            return d + "/" + m + "/" + y;
        }
        return "";
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string HijriToGreg(string hijri)
    {

        if (hijri.Length <= 0)
        {
            cur.Trace.Warn("HijriToGreg :Date String is Empty");
            return "";
        }
        try
        {
            DateTime tempDate = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
            return tempDate.ToString("yyyy/MM/dd", enCul.DateTimeFormat);
        }
        catch (Exception ex)
        {
            cur.Trace.Warn("HijriToGreg :" + hijri.ToString() + "\n" + ex.Message);
            return "";
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Convert Hijri Date to it's equivalent Gregorian Date and return it in specified format
    /// </summary>
    /// <param name="hijri"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public string HijriToGreg(string hijri, string format)
    {
        if (hijri.Length <= 0)
        {
            cur.Trace.Warn("HijriToGreg :Date String is Empty");
            return "";
        }
        try
        {
            DateTime tempDate = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
            return tempDate.ToString(format, enCul.DateTimeFormat);
        }
        catch (Exception ex)
        {
            cur.Trace.Warn("HijriToGreg :" + hijri.ToString() + "\n" + ex.Message);
            return "";
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Convert Gregoian Date to it's equivalent Hijir Date
    /// </summary>
    /// <param name="greg"></param>
    /// <returns></returns>
    public string GregToHijri(string greg)
    {
        if (greg.Length <= 0)
        {

            cur.Trace.Warn("GregToHijri :Date String is Empty");
            return "";
        }
        try
        {
            DateTime tempDate = DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
            return tempDate.ToString("yyyy/MM/dd", arCul.DateTimeFormat);

        }
        catch (Exception ex)
        {
            cur.Trace.Warn("GregToHijri :" + greg.ToString() + "\n" + ex.Message);
            return "";
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Convert Hijri Date to it's equivalent Gregorian Date and return it in specified format
    /// </summary>
    /// <param name="greg"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public string GregToHijri(string greg, string format)
    {
        if (greg.Length <= 0)
        {
            cur.Trace.Warn("GregToHijri :Date String is Empty");
            return "";
        }
        try
        {
            DateTime tempDate = DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
            return tempDate.ToString(format, arCul.DateTimeFormat);

        }
        catch (Exception ex)
        {
            cur.Trace.Warn("GregToHijri :" + greg.ToString() + "\n" + ex.Message);
            return "";
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
	/// Return Formatted Hijri date string 
	/// </summary>
	/// <param name="date"></param>
	/// <param name="format"></param>
	/// <returns></returns>
	public string FormatHijri(string date, string format)
    {
        if (date.Length <= 0)
        {
            cur.Trace.Warn("Format :Date String is Empty");
            return "";
        }
        try
        {
            DateTime tempDate = DateTime.ParseExact(date, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
            return tempDate.ToString(format, arCul.DateTimeFormat);

        }
        catch (Exception ex)
        {
            cur.Trace.Warn("Date :\n" + ex.Message);
            return "";
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
    /// <summary>
	/// Return Today Hijri date and return it in yyyy/MM/dd format
	/// </summary>
	/// <returns></returns>
	public string HDateNow()
    {
        try
        {
            return DateTime.Now.ToString("yyyy/MM/dd", arCul.DateTimeFormat);
        }
        catch (Exception ex)
        {
            cur.Trace.Warn("HDateNow :\n" + ex.Message);
            return "";
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
    /// <summary>
    /// Return formatted today hijri date based on your format
    /// </summary>
    /// <param name="format"></param>
    /// <returns></returns>
    public string HDateNow(string format)
    {
        try
        {
            return DateTime.Now.ToString(format, arCul.DateTimeFormat);
        }
        catch (Exception ex)
        {
            cur.Trace.Warn("HDateNow :\n" + ex.Message);
            return "";
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
    /// <summary>
	/// Returned Formatted Gregorian date string
	/// </summary>
	/// <param name="date"></param>
	/// <param name="format"></param>
	/// <returns></returns>
	public string FormatGreg(string date, string format)
    {
        if (date.Length <= 0)
        {
            cur.Trace.Warn("Format :Date String is Empty");
            return "";
        }
        try
        {
            DateTime tempDate = DateTime.ParseExact(date, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
            return tempDate.ToString(format, enCul.DateTimeFormat);

        }
        catch (Exception ex)
        {
            cur.Trace.Warn("Date :\n" + ex.Message);
            return "";
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
    public void FindMonthDates(string DateType, string Year, string Month, out DateTime StartDate, out DateTime EndDate)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        DateTime SDate = DateTime.Now;
        DateTime EDate = DateTime.Now;
        int iYear = Convert.ToInt16(Year);
        int iMonth = Convert.ToInt16(Month);

        if (DateType == "Gregorian")
        {
            int LastDay = Grn.GetDaysInMonth(iYear, iMonth);
            SDate = new DateTime(iYear, iMonth, 1);
            EDate = new DateTime(iYear, iMonth, LastDay);
        }
        else
        {
            int LastDay = Umq.GetDaysInMonth(iYear, iMonth);
            string HStartDate = "1" + "/" + iMonth + "/" + iYear;
            string HEndDate = LastDay + "/" + iMonth + "/" + iYear;
            SDate = ConvertToDatetime((HStartDate), "Gregorian");
            EDate = ConvertToDatetime(HijriToGreg(HEndDate), "Gregorian");
        }

        StartDate = SDate;
        EndDate = EDate;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
    public void FindMonthDates(string Year, string Month, out DateTime StartDate, out DateTime EndDate)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        //pgCs.FillDTSession();

        DateTime SDate = DateTime.Now;
        DateTime EDate = DateTime.Now;
        FindMonthDates(FormSession.DateType, Year, Month, out SDate, out EDate);

        StartDate = SDate;
        EndDate = EDate;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
    public DateTime ConvertToDatetime(string Date, string DateType)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        if (DateType == "Gregorian")
        {
            return DateTime.ParseExact(Date, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
        }
        else if (DateType == "Hijri")
        {
            return DateTime.ParseExact(Date, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
        }

        return new DateTime();
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
    public string GDateNow(string format)
    {
        try
        {
            return DateTime.Now.ToString(format, enCul.DateTimeFormat);
        }
        catch (Exception ex)
        {
            cur.Trace.Warn("GDateNow :\n" + ex.Message);
            return "";
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
}
