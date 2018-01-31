using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

public class AddTransSql : DataLayerBase
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
    SqlDbType ChrDB = SqlDbType.Char;

    DateFun DTCs = new DateFun();
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool Insert(AddTransPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.CommandText = "dbo.[AddTrans_Insert]";
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Connection = MainConnection;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@EmpID", VchDB, 15, IN, false, 0, 0, "", DRV, pro.EmpID));
            sqlCommand.Parameters.Add(new SqlParameter("@TrnDate", DtDB, 14, IN, false, 0, 0, "", DRV, pro.TrnDate));
            sqlCommand.Parameters.Add(new SqlParameter("@TrnTime", DtDB, 14, IN, false, 0, 0, "", DRV,  pro.TrnTime));
            sqlCommand.Parameters.Add(new SqlParameter("@TrnType", ChrDB, 1, IN, false, 0, 0, "", DRV, pro.TrnType));
            
            MainConnection.Open();

            sqlCommand.ExecuteNonQuery();
            
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("AddTrans::Insert::Error occured.", ex);
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
}