using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

public class DBSettingSql : DataLayerBase
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ParameterDirection IN  = ParameterDirection.Input;
    ParameterDirection OU  = ParameterDirection.Output;
    DataRowVersion     DRV = DataRowVersion.Proposed;

    SqlDbType IntDB = SqlDbType.Int;
    SqlDbType VchDB = SqlDbType.VarChar;
    SqlDbType DtDB  = SqlDbType.DateTime;
    SqlDbType BitDB = SqlDbType.Bit;
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool InsertUpdate(DBSettingPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[DatabaseImport_InsertUpdate]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            //sqlCommand.Parameters.Add(new SqlParameter("@TableName", VchDB, 500, IN, false, 0, 0, "", DRV, pro.TableName));
            sqlCommand.Parameters.Add(new SqlParameter("@EmployeeField", VchDB, 500, IN, false, 0, 0, "", DRV, pro.EmployeeField));
            sqlCommand.Parameters.Add(new SqlParameter("@DateField", VchDB, 500, IN, false, 0, 0, "", DRV, pro.DateField));
            sqlCommand.Parameters.Add(new SqlParameter("@TimeField", VchDB, 500, IN, false, 0, 0, "", DRV, pro.TimeField));
            sqlCommand.Parameters.Add(new SqlParameter("@InOutField", VchDB, 500, IN, false, 0, 0, "", DRV, pro.InOutField));
            sqlCommand.Parameters.Add(new SqlParameter("@MachineIdField", VchDB, 500, IN, false, 0, 0, "", DRV, pro.MachineIdField));
            sqlCommand.Parameters.Add(new SqlParameter("@LocationField", VchDB, 500, IN, false, 0, 0, "", DRV, pro.LocationField));
            sqlCommand.Parameters.Add(new SqlParameter("@SchemaName", VchDB, 500, IN, false, 0, 0, "", DRV, pro.SchemaName));
            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy", VchDB, 50, IN, false, 0, 0, "", DRV, pro.TransactionBy));

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
    public bool UpdateDBConn(DBSettingPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[DatabaseImport_UpdateDBConn]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@TableName", VchDB, 500, IN, false, 0, 0, "", DRV, pro.TableName));
            sqlCommand.Parameters.Add(new SqlParameter("@DBServer", VchDB, 500, IN, false, 0, 0, "", DRV, pro.DBServer));
            sqlCommand.Parameters.Add(new SqlParameter("@DBUsername", VchDB, 100, IN, false, 0, 0, "", DRV, pro.DBUsername));
            sqlCommand.Parameters.Add(new SqlParameter("@DBPassword", VchDB, 100, IN, false, 0, 0, "", DRV, pro.DBPassword));
            sqlCommand.Parameters.Add(new SqlParameter("@DBName", VchDB, 100, IN, false, 0, 0, "", DRV, pro.DBName));
            
            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy", VchDB, 50, IN, false, 0, 0, "", DRV, pro.TransactionBy));

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

