using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

public class EmpVacRelSql : DataLayerBase
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool Insert(EmpVacRelPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[EmpVacRel_Insert]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@EvrID", SqlDbType.Int, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, pro.EvrID));
            sqlCommand.Parameters.Add(new SqlParameter("@VtpID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.VtpID));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpID));
            sqlCommand.Parameters.Add(new SqlParameter("@EvrStartDate", SqlDbType.DateTime, 14, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, SelectDateFormat(pro.DateType, pro.EvrStartDate)));
            sqlCommand.Parameters.Add(new SqlParameter("@EvrEndDate", SqlDbType.DateTime, 14, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, SelectDateFormat(pro.DateType, pro.EvrEndDate)));
            sqlCommand.Parameters.Add(new SqlParameter("@EvrDescription", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EvrDescription));
            sqlCommand.Parameters.Add(new SqlParameter("@EvrPhone", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EvrPhone));
            sqlCommand.Parameters.Add(new SqlParameter("@EvrAvailability", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EvrAvailability));

            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.TransactionBy));

            MainConnection.Open();

            sqlCommand.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            MainConnection.Close();
            sqlCommand.Dispose();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool Update(EmpVacRelPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[EmpVacRel_Update]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        
        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@EvrID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EvrID));
            sqlCommand.Parameters.Add(new SqlParameter("@VtpID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.VtpID));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpID));
            sqlCommand.Parameters.Add(new SqlParameter("@EvrStartDate", SqlDbType.DateTime, 14, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, SelectDateFormat(pro.DateType, pro.EvrStartDate)));
            sqlCommand.Parameters.Add(new SqlParameter("@EvrEndDate", SqlDbType.DateTime, 14, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, SelectDateFormat(pro.DateType, pro.EvrEndDate)));
            sqlCommand.Parameters.Add(new SqlParameter("@EvrDescription", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EvrDescription));
            sqlCommand.Parameters.Add(new SqlParameter("@EvrPhone", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EvrPhone));
            sqlCommand.Parameters.Add(new SqlParameter("@EvrAvailability", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EvrAvailability));

            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.TransactionBy));
            MainConnection.Open();

            sqlCommand.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            MainConnection.Close();
            sqlCommand.Dispose();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool Delete(EmpVacRelPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[EmpVacRel_Delete]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@EvrID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EvrID));
            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.TransactionBy));

            MainConnection.Open();
            sqlCommand.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            MainConnection.Close();
            sqlCommand.Dispose();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string SelectDateFormat(string pDateType, string pDate)
    {
        //DateTime Date = Convert.ToDateTime(pDate);
        string strValue = "";
        if (pDateType == "Gregorian") { strValue = DateFun.strTodt(String.Format("{0:dd/MM/yyyy}", pDate)).ToShortDateString(); }
        else if (pDateType == "Hijri") { strValue = DateFun.HijToGrn(pDate).ToShortDateString(); }

        return strValue;
    }
}