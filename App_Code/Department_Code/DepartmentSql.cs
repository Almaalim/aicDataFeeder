using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

public class DepartmentSql : DataLayerBase
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool Insert(DepartmentPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[Departments_Insert]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@DepID", SqlDbType.Int, 8, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, pro.DepID));
            sqlCommand.Parameters.Add(new SqlParameter("@DepParentID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.DepParentID));
            sqlCommand.Parameters.Add(new SqlParameter("@DepNameAr", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.DepNameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@DepNameEn", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.DepNameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@DepDesc", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.DepDesc));
            sqlCommand.Parameters.Add(new SqlParameter("@DepStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.DepStatus));

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
    public bool Update(DepartmentPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[Departments_Update]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        
        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@DepID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.DepID));
            sqlCommand.Parameters.Add(new SqlParameter("@DepParentID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.DepParentID));
            sqlCommand.Parameters.Add(new SqlParameter("@DepNameAr", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.DepNameAr));
            sqlCommand.Parameters.Add(new SqlParameter("@DepNameEn", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.DepNameEn));
            sqlCommand.Parameters.Add(new SqlParameter("@DepDesc", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.DepDesc));
            sqlCommand.Parameters.Add(new SqlParameter("@DepStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.DepStatus));

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
    public bool Delete(DepartmentPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[Departments_Delete]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@DepID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.DepID));
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
}