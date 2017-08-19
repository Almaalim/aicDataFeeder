using System;
using System.Data;
using System.Data.SqlClient;

public class ErrorLogSql : DataLayerBase
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool Insert(ErrorLogPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[ErrorLog_Insert]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@ErrorPage", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.ErrorPage));
            sqlCommand.Parameters.Add(new SqlParameter("@ErrorFunction", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.ErrorFunction));
            sqlCommand.Parameters.Add(new SqlParameter("@ErrorMessage", SqlDbType.VarChar, 5000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.ErrorMessage));
            sqlCommand.Parameters.Add(new SqlParameter("@ErrorDate", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DateFun.SaveDB('S', pro.ErrorDate)));
            sqlCommand.Parameters.Add(new SqlParameter("@LoginUserID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.LoginUserID));
            sqlCommand.Parameters.Add(new SqlParameter("@LoginUserRole", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.LoginUserRole));
            
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