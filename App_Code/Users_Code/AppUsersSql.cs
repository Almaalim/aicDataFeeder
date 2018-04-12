using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

public class AppUsersSql : DataLayerBase
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
    SqlDbType ChrDB = SqlDbType.Char;

    DateFun DTCs = new DateFun();
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool Insert(AppUsersPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[AppUsers_Insert]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@UsrLoginID", VchDB, 50, IN, false, 0, 0, "", DRV, pro.UsrLoginID));
            sqlCommand.Parameters.Add(new SqlParameter("@UsrPassword", VchDB, 100, IN, false, 0, 0, "", DRV, pro.UsrPassword));
            sqlCommand.Parameters.Add(new SqlParameter("@UsrFullName", VchDB, 200, IN, false, 0, 0, "", DRV, pro.UsrFullName));
            
            if (!string.IsNullOrEmpty(pro.UsrStartDate))
            { 
                sqlCommand.Parameters.Add(new SqlParameter("@UsrStartDate", DtDB, 14, IN, false, 0, 0, "", DRV, pro.UsrStartDate));
                //sqlCommand.Parameters.Add(new SqlParameter("@UsrStartDateType", ChrDB, 1, IN, false, 0, 0, "", DRV, pro.UsrStartDateType));
            }

            if (!string.IsNullOrEmpty(pro.UsrExpiryDate))
            {
                sqlCommand.Parameters.Add(new SqlParameter("@UsrExpireDate", DtDB, 14, IN, false, 0, 0, "", DRV, pro.UsrExpiryDate));
                //sqlCommand.Parameters.Add(new SqlParameter("@UsrExpiryDateType", ChrDB, 1, IN, false, 0, 0, "", DRV, pro.UsrExpiryDateType));
            }
            sqlCommand.Parameters.Add(new SqlParameter("@UsrStatus", BitDB, 1, IN, false, 0, 0, "", DRV, pro.UsrStatus));
            sqlCommand.Parameters.Add(new SqlParameter("@UsrPermission", VchDB, 8000, IN, false, 0, 0, "", DRV, pro.UsrPermission));
            sqlCommand.Parameters.Add(new SqlParameter("@UsrLanguage", VchDB, 50, IN, false, 0, 0, "", DRV, pro.UsrLanguage));
            sqlCommand.Parameters.Add(new SqlParameter("@UsrEmailID", VchDB, 200, IN, false, 0, 0, "", DRV, pro.UsrEmailID));
            //sqlCommand.Parameters.Add(new SqlParameter("@UsrEmpID", VchDB, 100, IN, false, 0, 0, "", DRV, pro.UsrEmpID));
            sqlCommand.Parameters.Add(new SqlParameter("@UsrDescription", VchDB, 8000, IN, false, 0, 0, "", DRV, pro.UsrDescription));
            
            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy" , VchDB, 50 , IN, false, 0, 0, "", DRV, pro.TransactionBy));

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
    public bool Update(AppUsersPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[AppUsers_Update]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        
        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@UsrLoginID", VchDB, 50, IN, false, 0, 0, "", DRV, pro.UsrLoginID));
            sqlCommand.Parameters.Add(new SqlParameter("@UsrPassword", VchDB, 100, IN, false, 0, 0, "", DRV, pro.UsrPassword));
            sqlCommand.Parameters.Add(new SqlParameter("@UsrFullName", VchDB, 200, IN, false, 0, 0, "", DRV, pro.UsrFullName));

            if (!string.IsNullOrEmpty(pro.UsrStartDate))
            {
                sqlCommand.Parameters.Add(new SqlParameter("@UsrStartDate", DtDB, 14, IN, false, 0, 0, "", DRV, pro.UsrStartDate));  //DTCs.SaveDB(pro.UsrStartDateType,)
                //sqlCommand.Parameters.Add(new SqlParameter("@UsrStartDateType", ChrDB, 1, IN, false, 0, 0, "", DRV, pro.UsrStartDateType));
            }
            if (!string.IsNullOrEmpty(pro.UsrExpiryDate))
            {
                sqlCommand.Parameters.Add(new SqlParameter("@UsrExpireDate", DtDB, 14, IN, false, 0, 0, "", DRV, pro.UsrExpiryDate)); //DTCs.SaveDB(pro.UsrExpiryDateType,)
                //sqlCommand.Parameters.Add(new SqlParameter("@UsrExpiryDateType", ChrDB, 1, IN, false, 0, 0, "", DRV, pro.UsrExpiryDateType));
            }
            sqlCommand.Parameters.Add(new SqlParameter("@UsrStatus", BitDB, 1, IN, false, 0, 0, "", DRV, pro.UsrStatus));
            sqlCommand.Parameters.Add(new SqlParameter("@UsrPermission", VchDB, 8000, IN, false, 0, 0, "", DRV, pro.UsrPermission));
            sqlCommand.Parameters.Add(new SqlParameter("@UsrLanguage", VchDB, 50, IN, false, 0, 0, "", DRV, pro.UsrLanguage));
            sqlCommand.Parameters.Add(new SqlParameter("@UsrEmailID", VchDB, 200, IN, false, 0, 0, "", DRV, pro.UsrEmailID));
            //sqlCommand.Parameters.Add(new SqlParameter("@UsrEmpID", VchDB, 100, IN, false, 0, 0, "", DRV, pro.UsrEmpID));
            sqlCommand.Parameters.Add(new SqlParameter("@UsrDescription", VchDB, 8000, IN, false, 0, 0, "", DRV, pro.UsrDescription));
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
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool Delete(string UsrLoginID, string TransactionBy)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[AppUsers_Delete]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@UsrLoginID", VchDB, 50, IN, false, 0, 0, "", DRV, UsrLoginID));
            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy" , VchDB, 50 , IN, false, 0, 0, "", DRV, TransactionBy));
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
    public bool AppUser_Update_DepList(string UsrName, string DepList, string TransactionBy)
    {
        SqlCommand Sqlcmd = new SqlCommand("dbo.[AppUser_Update_DepList]", MainConnection);
        Sqlcmd.CommandType = CommandType.StoredProcedure;

        try
        {
            Sqlcmd.Parameters.Add(new SqlParameter("@UsrLoginID", VchDB, 200, IN, false, 0, 0, "", DRV, UsrName));
            Sqlcmd.Parameters.Add(new SqlParameter("@UsrDepartments", VchDB, 8000, IN, false, 0, 0, "", DRV, DepList));

            Sqlcmd.Parameters.Add(new SqlParameter("@TransactionBy", VchDB, 15, IN, false, 0, 0, "", DRV, TransactionBy));

            MainConnection.Open();
            Sqlcmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        finally
        {
            MainConnection.Close();
            Sqlcmd.Dispose();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool UpdateLanguage(AppUsersPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[AppUsers_UpdateLanguage]",MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@UsrLoginID", VchDB, 50, IN, false, 0, 0, "", DRV, pro.UsrLoginID));
            sqlCommand.Parameters.Add(new SqlParameter("@UsrLanguage", VchDB, 50, IN, false, 0, 0, "", DRV, pro.UsrLanguage));
            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy" , VchDB, 50 , IN, false, 0, 0, "", DRV, pro.TransactionBy));
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
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool UpdatePassword(AppUsersPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[AppUsers_UpdatePassword]",MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@UsrLoginID", VchDB, 50, IN, false, 0, 0, "", DRV, pro.UsrLoginID));
            sqlCommand.Parameters.Add(new SqlParameter("@UsrPassword", VchDB, 100, IN, false, 0, 0, "", DRV, pro.UsrPassword));
            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy" , VchDB, 50 , IN, false, 0, 0, "", DRV, pro.TransactionBy));
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
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool RoleInsert(AppUsersPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[RoleUserPermissions_Insert]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        
        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@RoleID",          IntDB, 10, OU, false, 0, 0, "", DRV, pro.RoleID));
            sqlCommand.Parameters.Add(new SqlParameter("@RoleNameEn",      VchDB, 100, IN, false, 0, 0, "", DRV, pro.RoleNameEn));          
            sqlCommand.Parameters.Add(new SqlParameter("@RoleNameAr",      VchDB, 100, IN, false, 0, 0, "", DRV, pro.RoleNameAr));           
            sqlCommand.Parameters.Add(new SqlParameter("@RolePermissions", VchDB, 8000, IN, false, 0, 0, "", DRV, pro.RolePermissions));
            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy" , VchDB, 50 , IN, false, 0, 0, "", DRV, pro.TransactionBy));
            
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
    public bool RoleUpdate(AppUsersPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[RoleUserPermissions_Update]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@RoleID",          IntDB, 10, IN, false, 0, 0, "", DRV, pro.RoleID));
            sqlCommand.Parameters.Add(new SqlParameter("@RoleNameEn",      VchDB, 100, IN, false, 0, 0, "", DRV, pro.RoleNameEn));          
            sqlCommand.Parameters.Add(new SqlParameter("@RoleNameAr",      VchDB, 100, IN, false, 0, 0, "", DRV, pro.RoleNameAr));           
            sqlCommand.Parameters.Add(new SqlParameter("@RolePermissions", VchDB, 8000, IN, false, 0, 0, "", DRV, pro.RolePermissions));
            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy" , VchDB, 50 , IN, false, 0, 0, "", DRV, pro.TransactionBy));
            
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
    public bool RoleDelete(AppUsersPro pro)
    {
        SqlCommand sqlCommand = new SqlCommand("dbo.[RoleUserPermissions_Delete]", MainConnection);
        sqlCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            sqlCommand.Parameters.Add(new SqlParameter("@RoleID", IntDB, 10, IN, false, 0, 0, "", DRV, pro.RoleID));
            sqlCommand.Parameters.Add(new SqlParameter("@TransactionBy" , VchDB, 50 , IN, false, 0, 0, "", DRV, pro.TransactionBy));
 
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