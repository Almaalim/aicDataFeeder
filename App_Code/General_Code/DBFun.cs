using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Collections;

public class DBFun
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    static SqlDataAdapter da = new SqlDataAdapter();
    static SqlConnection con;
    static DataTable dt;
    ErrorLogPro ProClass = new ErrorLogPro();
    ErrorLogSql SqlClass = new ErrorLogSql();
    static string ConName = "constring";

    DateFun DTCs = new DateFun();
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void OpenCon()
    {
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings[ConName].ConnectionString);
            if (con.State != ConnectionState.Open) { con.Open(); }
        }
        catch (Exception ex) { throw ex; }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void CloseCon()
    {
        try
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
        }
        catch (Exception ex) { throw ex; }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool isConnect()
    {
        string Conn = General.ConnString;
        System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(Conn);
        try
        {
            using (sqlConn)
            {
                sqlConn.Open();
                sqlConn.Close();
                sqlConn.Dispose();
                return true;
            }
        }
        catch (Exception ex)
        {
            sqlConn.Close();
            return false;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public DataTable DaFetchDataQuery(string pQuery) //
    {
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings[ConName].ConnectionString);
            OpenCon();
            da.SelectCommand = new SqlCommand(pQuery, con);
            da.SelectCommand.CommandType = CommandType.Text;

            SqlDataReader dr = da.SelectCommand.ExecuteReader(CommandBehavior.CloseConnection);
            dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            CloseCon();
            return dt;
        }
        catch (Exception ex) { throw ex; }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public DataTable FetchData(string pQuery)
    {
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings[ConName].ConnectionString);
            OpenCon();
            da.SelectCommand = new SqlCommand("FetchData", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Query", SqlDbType.VarChar, 8000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pQuery);
            da.SelectCommand.Parameters.Add(param);
            
            SqlDataReader dr = da.SelectCommand.ExecuteReader(CommandBehavior.CloseConnection);
            dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            CloseCon();
            return dt;
        }
        catch (Exception ex) { throw ex; }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public DataTable FetchData(string Query, string[] Param)
    {
        try
        {
            if (string.IsNullOrEmpty(Query) || Param.Length <= 0) { return new DataTable(); }

            SqlCommand cmd = new SqlCommand(Query);     
            for (int i = 0; i < Param.Length; i++) { cmd.Parameters.AddWithValue("@P" + (i+1).ToString(), Param[i]); }
            
            OpenCon();
            cmd.CommandType = CommandType.Text;
            cmd.Connection  = con;
            
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable FDT = new DataTable();
            FDT.Load(dr);
            dr.Close();
            return FDT;
        }
        catch (Exception ex) { throw ex; }
        finally 
        { 
            CloseCon(); 
            con.Dispose();
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public DataTable FetchData(SqlCommand cmd)
    {
        try
        {
            OpenCon();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable FDT = new DataTable();
            FDT.Load(dr);
            dr.Close();
            //CloseCon();
            return FDT;
        }
        catch (Exception ex) { throw ex; }
        finally
        {
            CloseCon();
            con.Dispose();
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public DataSet FetchMenuData(string pQuery)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[ConName].ConnectionString);

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(pQuery, con);

        da.Fill(ds);
        da.Dispose();

        ds.DataSetName = "Menus";
        ds.Tables[0].TableName = "Menu";
        DataRelation relation = new DataRelation("ParentChild", ds.Tables["Menu"].Columns["MnuID"], ds.Tables["Menu"].Columns["MnuParentID"], false);
        relation.Nested = true;
        ds.Relations.Add(relation);

        return ds;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public int InsertData(string pQuery)
    {
        try
        {
            if (string.IsNullOrEmpty(pQuery)) { return 0; }
            con = new SqlConnection(ConfigurationManager.ConnectionStrings[ConName].ConnectionString);
            OpenCon();

            da.InsertCommand = new SqlCommand("ExecuteData", con);
            da.InsertCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Query", SqlDbType.VarChar, 8000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pQuery);
            da.InsertCommand.Parameters.Add(param);

            int rowsAffected = Convert.ToInt32(da.InsertCommand.ExecuteScalar());
            CloseCon();
            return rowsAffected;
        }
        catch (Exception ex) { return 1; }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public int ExecuteData(string pQuery)
    {
        if (string.IsNullOrEmpty(pQuery)) { return 0; }
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[ConName].ConnectionString);
        OpenCon();

        da.InsertCommand = new SqlCommand("ExecuteData", con);
        da.InsertCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter param = new SqlParameter("@Query", SqlDbType.VarChar, 8000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, pQuery);
        da.InsertCommand.Parameters.Add(param);

        int rowsAffected = da.InsertCommand.ExecuteNonQuery();
        CloseCon();
        return rowsAffected;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool IsNullOrEmpty(DataTable dt)
    {
        if (dt == null) { return true; }
        if (dt.Rows.Count == 0) { return true; }
        return false;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void InsertError(string errorPage,string errorFunction)
    {
        string errorMessage = "";
        string userID = ((string)HttpContext.Current.Session["UserName"]);
        string userRole = Convert.ToString(HttpContext.Current.Session["Role"]);
        //string errorPage = "EmployeMaster.aspx";
        //string errorFunction = "btnSaveInsert";
        DateTime dtError = DateTime.Now;

        StringBuilder errorQuery = new StringBuilder();
        errorQuery.Append("INSERT INTO [ErrorLog]([ErrorPage],[ErrorFunction], [ErrorMessage], [ErrorDate] ,[LoginUserID],[LoginUserRole]) VALUES ('" + errorPage + "','" + errorFunction + "'");
        errorQuery.Append(",'" + errorMessage + "', '" + DTCs.HijToGrn(DTCs.GrnToHij(dtError)) + "','" + userID + "','" + userRole + "')");

        //errorQuery.Append("INSERT INTO [ErrorLog]([ErrorPage],[ErrorFunction], [ErrorMessage], [ErrorDate] ,[LoginUserID],[LoginUserRole]) VALUES (@P1, @P2");
        //errorQuery.Append(", @P3, @P4, @P5, @P6)");

        //DataTable dt = DBFun.FetchData(errorQuery.ToString(), new string[] { errorPage, errorFunction, errorMessage, DateFun.HijToGrn(DateFun.GrnToHij(dtError)).ToString(), userID, userRole });

        Int32 returnValue = ExecuteData(errorQuery.ToString());
    }

    //protected void FillObjectErrorLog(string ErPage, string ErFun, string)
    //{
    //    ProClass.ErrorPage = 
    //}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public DataTable GetFields(string ConnString, string pTable)
    {
        DataTable FieldNames = new DataTable();
        SqlConnection Conn = new SqlConnection(ConnString);
        try
        {
            using (Conn)
            {
                Conn.Open();

                string Query = "SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('" + pTable + "')";
                SqlCommand cmd = new SqlCommand(Query, Conn);
                FieldNames = FetchData(cmd);

                //SqlDataAdapter da = new SqlDataAdapter(Query, Conn);

                //da.Fill(FieldNames);
                //da.Dispose();

                Conn.Close();
                return FieldNames;
            }
        }
        catch { Conn.Close(); return FieldNames; }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}