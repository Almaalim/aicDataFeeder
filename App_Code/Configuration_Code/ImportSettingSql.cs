using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ImportSettingSql
/// </summary>
public class ImportSettingSql : DataLayerBase
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool InsertUpdate(ImportSettingPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[ImportSetting_InsertUpdate]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@IpsRunProcess", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.IpsRunProcess));
            sqlCommand.Parameters.Add(new SqlParameter("@IpsRunTodayProcess", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, false));
            sqlCommand.Parameters.Add(new SqlParameter("@IpsSaveTransInFile", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.IpsSaveTransInFile));
            sqlCommand.Parameters.Add(new SqlParameter("@IpsEncryptTransInFile", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.IpsEncryptTransInFile));
            sqlCommand.Parameters.Add(new SqlParameter("@IpsImportScheduleTimes", SqlDbType.VarChar, 8000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.IpsImportScheduleTimes));
            sqlCommand.Parameters.Add(new SqlParameter("@IpsProcessScheduleTimes", SqlDbType.VarChar, 8000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.IpsProcessScheduleTimes));
            
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
}