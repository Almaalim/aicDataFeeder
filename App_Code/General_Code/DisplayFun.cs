using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for DisplayFun
/// </summary>
public class DisplayFun
{
    DateFun DTCs = new DateFun();
    DBFun DBCs = new DBFun();

    static GregorianCalendar Grn = new GregorianCalendar();
    static UmAlQuraCalendar Umq = new UmAlQuraCalendar();
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static string GrdDisplayDate(object pDate, object pType)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        string DType = "Gregorian";

        if (pDate != DBNull.Value && pType != DBNull.Value)
        {
            DateTime date = (DateTime)pDate;
            if (pType.ToString() == "S") { DType = HttpContext.Current.Session["DateFormat"].ToString(); }
            else if (pType.ToString() == "G") { DType = "Gregorian"; }
            else if (pType.ToString() == "H") { DType = "Hijri"; }

            if (DType == "Gregorian") { return fd(Grn.GetDayOfMonth(date).ToString()) + "/" + fd(Grn.GetMonth(date).ToString()) + "/" + fd(Grn.GetYear(date).ToString()); }
            if (DType == "Hijri") { return GrnToHij(Convert.ToDateTime(pDate)).ToString(); }
        }
        else { return null; }

        return null;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static string GrdDisplayDayStatus(object pStatus)
    {
        try
        {
            if (pStatus.ToString().Trim() == "A") { return General.Msg("Absent", "غائب"); }
            else if (pStatus.ToString().Trim() == "P") { return General.Msg("Present", "حاضر"); }
            else if (pStatus.ToString().Trim() == "N") { return General.Msg("No work", "لا يوجد عمل"); }
            else if (pStatus.ToString().Trim() == "H") { return General.Msg("Holiday", "عطلة"); }
            else if (pStatus.ToString().Trim() == "WE") { return General.Msg("Week end", "نهاية الأسبوع"); }
            else if (pStatus.ToString().Trim() == "UE") { return General.Msg("UnPaid Vacation", "إجازة غير مدفوعة"); }
            else if (pStatus.ToString().Trim() == "CM") { return General.Msg("Commission", "إنتداب"); }
            else if (pStatus.ToString().Trim() == "JB") { return General.Msg("Job Assignment", "مهمة عمل"); }
            else if (pStatus.ToString().Trim() == "T") { return General.Msg("In Process", "تحت الإجراء"); }
            else if (pStatus.ToString().Trim() == "NP") { return General.Msg("Not Processed", "لم تتم المعالجة"); }

            else if (pStatus.ToString().Trim() == "IN") { return General.Msg("IN Only", "دخول فقط"); }
            else if (pStatus.ToString().Trim() == "OU") { return General.Msg("OUT Only", "خروج فقط"); }
            else if (pStatus.ToString().Trim() == "OI") { return General.Msg("OUT-IN", "خروج-دخول"); }
            else { return string.Empty; }
        }
        catch (Exception e1)
        {
            //ErrorSignal.FromCurrentContext().Raise(e1);
            return string.Empty;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static string GrnToHij(DateTime pGdate)
    {
        int year = Umq.GetYear(pGdate);
        int month = Umq.GetMonth(pGdate);
        int day = Umq.GetDayOfMonth(pGdate);
        return fd(day.ToString()) + "/" + fd(month.ToString()) + "/" + year.ToString();
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static string fd(string dt) { if (dt.Length < 2) { return "0" + dt; } else { return dt; } }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static string GrdDisplayTime(object pTime)
    {
        try
        {
            if (pTime == DBNull.Value) { return string.Empty; }
            return String.Format("{0:HH:mm:ss}", pTime);
        }
        catch (Exception ex)
        {
            return string.Empty;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static string GrdDisplayTypeTrans(object pType)
    {
        try
        {
            if (pType.ToString() == "1") { return General.Msg("IN", "دخول"); }
            else if (pType.ToString() == "0") { return General.Msg("OUT", "خروج"); }
            else { return ""; }
        }
        catch (Exception ex)
        {
            return string.Empty;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static List<string> GetTables(string connectionString)
    {
        List<string> TableNames = new List<string>();
        SqlConnection connection = new SqlConnection(connectionString);
        try
        {
            using (connection)
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");

                foreach (DataRow row in schema.Rows)
                {
                    TableNames.Add(row[2].ToString());
                }
                connection.Close();
                return TableNames;
            }
        }
        catch { connection.Close(); return TableNames; }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static string GrdDisplayTrnType(object pStatus)
    {
        try
        {
            if (pStatus.ToString().Trim() == "1") { return General.Msg("IN", "دخول"); }
            else if (pStatus.ToString().Trim() == "0") { return General.Msg("Out", "خروج"); }
            
            else { return string.Empty; }
        }
        catch (Exception e1)
        {
            //ErrorSignal.FromCurrentContext().Raise(e1);
            return string.Empty;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
