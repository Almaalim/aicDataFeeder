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

    DateFun DTCs = new DateFun();
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public Int32 Insert(WorktimePro pro)
    {
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.CommandText = "dbo.[WorkingTime_Insert]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Connection = MainConnection;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@WktID", IntDB, 10, OUT, false, 0, 0, "", DRV, pro.WktID));
            sqlCommand.Parameters.Add(new SqlParameter("@WktNameAr", VchDB, 100, IN, false, 0, 0, "", DRV, pro.WktNameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@WktNameEn", VchDB, 100, IN, false, 0, 0, "", DRV, pro.WktNameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@WktSat", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktSat));
            sqlCommand.Parameters.Add(new SqlParameter("@WktSun", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktSun));
            sqlCommand.Parameters.Add(new SqlParameter("@WktMon", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktMon));
            sqlCommand.Parameters.Add(new SqlParameter("@WktTue", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktTue));
            sqlCommand.Parameters.Add(new SqlParameter("@WktWed", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktWed));
            sqlCommand.Parameters.Add(new SqlParameter("@WktThu", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktThu));
            sqlCommand.Parameters.Add(new SqlParameter("@WktFri", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktFri));
            sqlCommand.Parameters.Add(new SqlParameter("@WktStartDate", DtDB, 14, IN, false, 0, 0, "", DRV, pro.WktStartDate));
            sqlCommand.Parameters.Add(new SqlParameter("@WktEndDate", DtDB, 14, IN, false, 0, 0, "", DRV, pro.WktEndDate));
            sqlCommand.Parameters.Add(new SqlParameter("@WktIsActive", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktIsActive));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShiftCount", IntDB, 10, IN, false, 0, 0, "", DRV, pro.WktShiftCount));

            //shift1
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1From", DtDB, 10, IN, false, 0, 0, "", DRV, pro.WktShift1From));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1To", DtDB, 10, IN, false, 0, 0, "", DRV, pro.WktShift1To));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1NameAr", VchDB, 100, IN, false, 0, 0, "", DRV, pro.WktShift1NameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1NameEn", VchDB, 100, IN, false, 0, 0, "", DRV, pro.WktShift1NameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1Grace", IntDB, 10, IN, false, 0, 0, "", DRV, pro.WktShift1Grace));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1Duration", IntDB, 10, IN, false, 0, 0, "", DRV, pro.WktShift1Duration));

            //shift2
            if (pro.WktShift2From != null && pro.WktShift2From != new DateTime())
            { sqlCommand.Parameters.Add(new SqlParameter("@WktShift2From", DtDB, 10, IN, false, 0, 0, "", DRV, pro.WktShift2From)); }
            if (pro.WktShift2To != null && pro.WktShift2To != new DateTime())
            { sqlCommand.Parameters.Add(new SqlParameter("@WktShift2To", DtDB, 10, IN, false, 0, 0, "", DRV, pro.WktShift2To)); }
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift2NameAr", VchDB, 100, IN, false, 0, 0, "", DRV, pro.WktShift2NameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift2NameEn", VchDB, 100, IN, false, 0, 0, "", DRV, pro.WktShift2NameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift2Grace", IntDB, 10, IN, false, 0, 0, "", DRV, pro.WktShift2Grace));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift2Duration", IntDB, 10, IN, false, 0, 0, "", DRV, pro.WktShift2Duration));

            //shift3
            if (pro.WktShift3From != null && pro.WktShift3From != new DateTime())
            { sqlCommand.Parameters.Add(new SqlParameter("@WktShift3From", DtDB, 10, IN, false, 0, 0, "", DRV, pro.WktShift3From)); }
            if (pro.WktShift3To != null && pro.WktShift3To != new DateTime())
            { sqlCommand.Parameters.Add(new SqlParameter("@WktShift3To", DtDB, 10, IN, false, 0, 0, "", DRV, pro.WktShift3To)); }
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift3NameAr", VchDB, 100, IN, false, 0, 0, "", DRV, pro.WktShift3NameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift3NameEn", VchDB, 100, IN, false, 0, 0, "", DRV, pro.WktShift3NameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift3Grace", IntDB, 10, IN, false, 0, 0, "", DRV, pro.WktShift3Grace));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift3Duration", IntDB, 10, IN, false, 0, 0, "", DRV, pro.WktShift3Duration));
            
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
    public Int32 Update(WorktimePro pro)
    {
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.CommandText = "dbo.[WorkingTime_Update]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Connection = MainConnection;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@WktID", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktID));
            sqlCommand.Parameters.Add(new SqlParameter("@WktNameAr", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktNameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@WktNameEn", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktNameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@WktSat", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktSat));
            sqlCommand.Parameters.Add(new SqlParameter("@WktSun", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktSun));
            sqlCommand.Parameters.Add(new SqlParameter("@WktMon", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktMon));
            sqlCommand.Parameters.Add(new SqlParameter("@WktTue", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktTue));
            sqlCommand.Parameters.Add(new SqlParameter("@WktWed", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktWed));
            sqlCommand.Parameters.Add(new SqlParameter("@WktThu", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktThu));
            sqlCommand.Parameters.Add(new SqlParameter("@WktFri", BIT, 1, IN, false, 0, 0, "", DRV, pro.WktFri));
            sqlCommand.Parameters.Add(new SqlParameter("@WktStartDate", DtDB, 14, IN, false, 0, 0, "", DRV, pro.WktStartDate));
            sqlCommand.Parameters.Add(new SqlParameter("@WktEndDate", DtDB, 14, IN, false, 0, 0, "", DRV, pro.WktEndDate));
            sqlCommand.Parameters.Add(new SqlParameter("@WktIsActive", SqlDbType.Bit, 1, IN, false, 0, 0, "", DRV, pro.WktIsActive));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShiftCount", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShiftCount));

            //shift1
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1From", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift1From));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1To", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift1To));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1NameAr", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktShift1NameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1NameEn", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktShift1NameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1Grace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift1Grace));
            //sqlCommand.Parameters.Add(new SqlParameter("@WktShift1EndGrace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift1EndGrace));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift1Duration", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift1Duration));

            //shift2
            if (pro.WktShift2From != null && pro.WktShift2From != new DateTime())
            { sqlCommand.Parameters.Add(new SqlParameter("@WktShift2From", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift2From)); }
            if (pro.WktShift2To != null && pro.WktShift2To != new DateTime())
            { sqlCommand.Parameters.Add(new SqlParameter("@WktShift2To", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift2To)); }
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift2NameAr", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktShift2NameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift2NameEn", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktShift2NameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift2Grace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift2Grace));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift2Duration", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift2Duration));


            //shift3
            if (pro.WktShift3From != null && pro.WktShift3From != new DateTime())
            { sqlCommand.Parameters.Add(new SqlParameter("@WktShift3From", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift3From)); }
            if (pro.WktShift3To != null && pro.WktShift3To != new DateTime())
            { sqlCommand.Parameters.Add(new SqlParameter("@WktShift3To", SqlDbType.DateTime, 10, IN, false, 0, 0, "", DRV, pro.WktShift3To)); }
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift3NameAr", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktShift3NameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift3NameEn", SqlDbType.VarChar, 100, IN, false, 0, 0, "", DRV, pro.WktShift3NameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift3Grace", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift3Grace));
            sqlCommand.Parameters.Add(new SqlParameter("@WktShift3Duration", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktShift3Duration));

            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy", VchDB, 50, IN, false, 0, 0, "", DRV, pro.TransactionBy));

            MainConnection.Open();

            int rowsAffected = sqlCommand.ExecuteNonQuery();
            rowsAffected = Convert.ToInt32(sqlCommand.Parameters["@WktID"].Value);
            return rowsAffected;
        }
        catch (Exception ex)
        {
            throw new Exception("WorkTime::Update::Error occured.", ex);
        }
        finally
        {
            MainConnection.Close();
            sqlCommand.Dispose();
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool Delete(WorktimePro pro)
    {
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.CommandText = "dbo.[WorkingTime_Delete]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Connection = MainConnection;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@WktID", SqlDbType.Int, 10, IN, false, 0, 0, "", DRV, pro.WktID));
            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy", VchDB, 50, IN, false, 0, 0, "", DRV, pro.TransactionBy));

            MainConnection.Open();
            sqlCommand.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("WorkTime::Delete::Error occured.", ex);
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
        if (pDateType == "Gregorian") { strValue = DTCs.strTodt(String.Format("{0:dd/MM/yyyy}", pDate)).ToShortDateString(); }
        else if (pDateType == "Hijri") { strValue = DTCs.HijToGrn(pDate).ToShortDateString(); }

        return strValue;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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