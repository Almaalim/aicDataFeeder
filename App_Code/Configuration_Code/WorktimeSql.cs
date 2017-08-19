using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

public class WorktimeSql : DataLayerBase
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    SqlParameter param;
    DataTable dt;
    DateTime Date;
    SqlDataAdapter da = new SqlDataAdapter();

    ParameterDirection IN = ParameterDirection.Input;
    ParameterDirection OUT = ParameterDirection.Output;
    DataRowVersion DRV = DataRowVersion.Proposed;

    SqlDbType IntDB = SqlDbType.Int;
    SqlDbType VchDB = SqlDbType.VarChar;
    SqlDbType DtDB = SqlDbType.DateTime;
    SqlDbType BIT = SqlDbType.Bit;
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public Int32 InsertUpdate(WorktimePro pro)
    {
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.CommandText = "dbo.[WorkingTime_InsertUpdate]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Connection = MainConnection;

        try
        {
            //sqlCommand.Parameters.Add(new SqlParameter("@WktID", SqlDbType.Int, 10, OUT, false, 0, 0, "", DRV, pro.WktID));
            sqlCommand.Parameters.Add(new SqlParameter("@WktNameAr", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktNameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@WktNameEn", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktNameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@EwrSat", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktSat));
            sqlCommand.Parameters.Add(new SqlParameter("@EwrSun", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktSun));
            sqlCommand.Parameters.Add(new SqlParameter("@EwrMon", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktMon));
            sqlCommand.Parameters.Add(new SqlParameter("@EwrTue", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktTue));
            sqlCommand.Parameters.Add(new SqlParameter("@EwrWed", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktWed));
            sqlCommand.Parameters.Add(new SqlParameter("@EwrThu", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktThu));
            sqlCommand.Parameters.Add(new SqlParameter("@EwrFri", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktFri));
            sqlCommand.Parameters.Add(new SqlParameter("@WktStartDate", DtDB, 14, IN, false, 0, 0, "", DRV, SelectDateFormat(pro.DateType, pro.WktStartDate)));
            sqlCommand.Parameters.Add(new SqlParameter("@WktEndDate", DtDB, 14, IN, false, 0, 0, "", DRV, SelectDateFormat(pro.DateType, pro.WktEndDate)));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktDesc", SqlDbType.VarChar, 255, IN, false, 0, 0, "", DRV, pro.WktDesc));
            //sqlCommand.Parameters.Add(new SqlParameter("@WtpID", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WtpID));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktIsActive", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktIsActive));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShiftCount", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShiftCount));

            //shift1
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1From", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift1From));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1To", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift1To));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1NameAr", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktShift1NameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1NameEn", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktShift1NameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1Grace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift1Grace));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift1EndGrace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift1EndGrace));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1Duration", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift1Duration));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift1MiddleGrace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift1MiddleGrace));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift1IsOverNight", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktShift1IsOverNight));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift1IsOptional", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktShift1IsOptional));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift1FTHours", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift1FTHours));

            //shift2
            if (pro.WktShift2From != null && pro.WktShift2From != new DateTime())
            { sqlCommand.Parameters.Add(new SqlParameter("@WktShift2From", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift2From)); }
            if (pro.WktShift2To != null && pro.WktShift2To != new DateTime())
            { sqlCommand.Parameters.Add(new SqlParameter("@WktShift2To", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift2To)); }
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift2NameAr", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktShift2NameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift2NameEn", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktShift2NameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift2Grace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift2Grace));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift2Duration", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift2Duration));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift2MiddleGrace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift2MiddleGrace));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift2EndGrace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift2EndGrace));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift2IsOverNight", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktShift2IsOverNight));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift2IsOptional", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktShift2IsOptional));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift2FTHours", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift2FTHours));

            //shift3
            if (pro.WktShift3From != null && pro.WktShift3From != new DateTime())
            { sqlCommand.Parameters.Add(new SqlParameter("@WktShift3From", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift3From)); }
            if (pro.WktShift3To != null && pro.WktShift3To != new DateTime())
            { sqlCommand.Parameters.Add(new SqlParameter("@WktShift3To", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift3To)); }
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift3NameAr", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktShift3NameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift3NameEn", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktShift3NameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift3Grace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift3Grace));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift3Duration", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift3Duration));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift3MiddleGrace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift3MiddleGrace));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift3IsOverNight", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktShift3IsOverNight));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift3IsOptional", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktShift3IsOptional));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift3EndGrace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift3EndGrace));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift3FTHours", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift3FTHours));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktCreatedBy", SqlDbType.Char, 10, IN, false, 0, 0, "", DRV, pro.CreatedBy));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktCreatedDate", SqlDbType.DateTime, 14, IN, false, 0, 0, "", DRV, General.strTodt(pro.CreatedDate)));
            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy", VchDB, 50, IN, false, 0, 0, "", DRV, pro.TransactionBy));
            MainConnection.Open();

            int rowsAffected = sqlCommand.ExecuteNonQuery();
            rowsAffected = Convert.ToInt32(sqlCommand.Parameters["@WktID"].Value);
            return rowsAffected;
        }
        catch (Exception ex)
        {
            throw new Exception("WorkTime::Insert::Error occured.", ex);
        }
        finally
        {
            MainConnection.Close();
            sqlCommand.Dispose();
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string SelectDateFormat(string pDateType, string pDate)
    {
        //DateTime Date = Convert.ToDateTime(pDate);
        string strValue = "";
        if (pDateType == "Gregorian") { strValue = DateFun.strTodt(String.Format("{0:dd/MM/yyyy}", pDate)).ToShortDateString(); }
        else if (pDateType == "Hijri") { strValue = DateFun.HijToGrn(pDate).ToShortDateString(); }

        return strValue;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //public bool Update(WorktimePro pro)
    //{
    //    SqlCommand sqlCommand = new SqlCommand();
    //    sqlCommand.CommandText = "dbo.[WorkingTime_Update]";
    //    sqlCommand.CommandType = CommandType.StoredProcedure;
    //    sqlCommand.Connection = MainConnection;

    //    try
    //    {
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktID", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktID));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktNameAr", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktNameAr));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktNameEn", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktNameEn));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktDesc", SqlDbType.VarChar, 255, IN, false, 0, 0, "", DRV, pro.WktDesc));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WtpID", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WtpID));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktIsActive", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktIsActive));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktAddPercent", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktAddPercent));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShiftCount", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShiftCount));

    //        //shift1
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift1From", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift1From));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift1To", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift1To));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift1NameAr", SqlDbType.VarChar, 50, IN, false, 0, 0, "", DRV, pro.WktShift1NameAr));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift1NameEn", SqlDbType.VarChar, 50, IN, false, 0, 0, "", DRV, pro.WktShift1NameEn));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift1Grace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift1Grace));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift1EndGrace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift1EndGrace));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift1Duration", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift1Duration));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift1MiddleGrace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift1MiddleGrace));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift1IsOverNight", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktShift1IsOverNight));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift1IsOptional", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktShift1IsOptional));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift1FTHours", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift1FTHours));

    //        //shift2
    //        if (pro.WktShift2From != null && pro.WktShift2From != new DateTime())
    //        { sqlCommand.Parameters.Add(new SqlParameter("@WktShift2From", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift2From)); }

    //        if (pro.WktShift2To != null && pro.WktShift2To != new DateTime())
    //        { sqlCommand.Parameters.Add(new SqlParameter("@WktShift2To", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift2To)); }
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift2NameAr", SqlDbType.VarChar, 50, IN, false, 0, 0, "", DRV, pro.WktShift2NameAr));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift2NameEn", SqlDbType.VarChar, 50, IN, false, 0, 0, "", DRV, pro.WktShift2NameEn));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift2Grace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift2Grace));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift2Duration", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift2Duration));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift2MiddleGrace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift2MiddleGrace));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift2EndGrace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift2EndGrace));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift2IsOverNight", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktShift2IsOverNight));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift2IsOptional", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktShift2IsOptional));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift2FTHours", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift2FTHours));

    //        //shift3
    //        if (pro.WktShift3From != null && pro.WktShift3From != new DateTime())
    //        { sqlCommand.Parameters.Add(new SqlParameter("@WktShift3From", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift3From)); }

    //        if (pro.WktShift3To != null && pro.WktShift3To != new DateTime())
    //        { sqlCommand.Parameters.Add(new SqlParameter("@WktShift3To", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift3To)); }

    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift3NameAr", SqlDbType.VarChar, 50, IN, false, 0, 0, "", DRV, pro.WktShift3NameAr));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift3NameEn", SqlDbType.VarChar, 50, IN, false, 0, 0, "", DRV, pro.WktShift3NameEn));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift3Grace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift3Grace));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift3Duration", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift3Duration));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift3MiddleGrace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift3MiddleGrace));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift3IsOverNight", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktShift3IsOverNight));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift3IsOptional", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktShift3IsOptional));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift3EndGrace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift3EndGrace));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktShift3FTHours", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift3FTHours));

    //        sqlCommand.Parameters.Add(new SqlParameter("@WktModifiedBy", SqlDbType.Char, 10, IN, false, 0, 0, "", DRV, pro.ModifiedBy));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktModifiedDate", SqlDbType.DateTime, 14, IN, false, 0, 0, "", DRV, General.strTodt(pro.ModifiedDate)));

    //        MainConnection.Open();
    //        sqlCommand.ExecuteNonQuery();
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("WorkTime::Update::Error occured.", ex);
    //    }
    //    finally
    //    {
    //        MainConnection.Close();
    //        sqlCommand.Dispose();
    //    }
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //public bool DeleteUpdate(WorkTimes pro)
    //{
    //    SqlCommand sqlCommand = new SqlCommand();
    //    sqlCommand.CommandText = "dbo.[WorkingTime_DeleteByField]";
    //    sqlCommand.CommandType = CommandType.StoredProcedure;
    //    sqlCommand.Connection = MainConnection;

    //    try
    //    {
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktID", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktID));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktDeleted", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.Deleted));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktDeletedBy", SqlDbType.Char, 10, IN, false, 0, 0, "", DRV, pro.DeletedBy));
    //        sqlCommand.Parameters.Add(new SqlParameter("@WktDeletedDate", SqlDbType.DateTime, 14, IN, false, 0, 0, "", DRV, General.strTodt(pro.DeletedDate)));

    //        MainConnection.Open();
    //        sqlCommand.ExecuteNonQuery();
    //        return true;

    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("WorkTime::DeleteByField::Error occured.", ex);
    //    }
    //    finally
    //    {
    //        MainConnection.Close();
    //        sqlCommand.Dispose();
    //    }
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}