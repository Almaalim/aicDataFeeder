using System;
using System.Data;
using System.Data.SqlClient;

public class EmployeeSql : DataLayerBase
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool Insert(EmployeePro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[Employee_Insert]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@EmpID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpID));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpNameAr", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpNameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpNameEn", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpNameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpPositionAr", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpPositionAr));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpPositionEn", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpPositionEn));
            sqlCommand.Parameters.Add(new SqlParameter("@DepID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.DepID));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpMobileNo", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpMobileNo));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpEmailID", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpEmailID));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpStatus));

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
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool Update(EmployeePro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[Employee_Update]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@EmpID", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpID));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpNameAr", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpNameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpNameEn", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpNameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpPositionAr", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpPositionAr));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpPositionEn", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpPositionEn));
            sqlCommand.Parameters.Add(new SqlParameter("@DepID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.DepID));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpMobileNo", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpMobileNo));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpEmailID", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpEmailID));
            sqlCommand.Parameters.Add(new SqlParameter("@EmpStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpStatus));

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
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool Delete(EmployeePro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[Employee_Delete]",MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@EmpID"        , SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.EmpID));
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
}