using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

public class MachineSql : DataLayerBase
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool Insert(MachinePro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[Machine_Insert]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@MacID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, pro.MacID));
            sqlCommand.Parameters.Add(new SqlParameter("@MtpID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.MtpID));
            sqlCommand.Parameters.Add(new SqlParameter("@MachineNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.MachineNo));
            sqlCommand.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.IPAddress));
            sqlCommand.Parameters.Add(new SqlParameter("@Port", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.Port));
            sqlCommand.Parameters.Add(new SqlParameter("@MachineSerialNo", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.MachineSerialNo));
            sqlCommand.Parameters.Add(new SqlParameter("@LocationAr", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.LocationAr));
            sqlCommand.Parameters.Add(new SqlParameter("@LocationEn", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.LocationEn));
            sqlCommand.Parameters.Add(new SqlParameter("@MachineStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.MachineStatus));
            sqlCommand.Parameters.Add(new SqlParameter("@MachineINOUTType", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.MachineINOUTType));
            sqlCommand.Parameters.Add(new SqlParameter("@MachineExport", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.MachineExport));
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
    public bool Update(MachinePro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[Machine_Update]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@MacID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, pro.MacID));
            sqlCommand.Parameters.Add(new SqlParameter("@MtpID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.MtpID));
            sqlCommand.Parameters.Add(new SqlParameter("@MachineNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.MachineNo));
            sqlCommand.Parameters.Add(new SqlParameter("@IPAddress", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.IPAddress));
            sqlCommand.Parameters.Add(new SqlParameter("@Port", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.Port));
            sqlCommand.Parameters.Add(new SqlParameter("@MachineSerialNo", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.MachineSerialNo));
            sqlCommand.Parameters.Add(new SqlParameter("@LocationAr", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.LocationAr));
            sqlCommand.Parameters.Add(new SqlParameter("@LocationEn", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.LocationEn));
            sqlCommand.Parameters.Add(new SqlParameter("@MachineStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.MachineStatus));
            sqlCommand.Parameters.Add(new SqlParameter("@MachineINOUTType", SqlDbType.Char, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.MachineINOUTType));
            sqlCommand.Parameters.Add(new SqlParameter("@MachineExport", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.MachineExport));
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
    public bool Delete(MachinePro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[Machine_DELETE]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@MacID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pro.MacID));
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