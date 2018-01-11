﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class ReadImage : System.Web.UI.Page
{
    DataTable dt;
    DBFun DBCs = new DBFun();

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            string ID   = (Request.QueryString["ID"] != null) ? Request.QueryString["ID"] : "";
            string Type = (Request.QueryString["Type"] != null) ? Request.QueryString["Type"] : "";

            
            if (Type == "Visitors")    { dt = DBCs.FetchData("SELECT TOP 1 VisImage FROM VisitorsCard WHERE VisIdentityNo='" + ID + "' ORDER BY VisCardID DESC"); }          
            if (Type == "VisitorsTmp") { dt = DBCs.FetchData("SELECT photo FROM TempImage WHERE Type = 'Visitors'  AND EmpID ='" + ID + "'"); }

            if (Type == "Employee")    { dt = DBCs.FetchData("SELECT image FROM EmployeeMaster WHERE EmpNationalID ='" + ID + "'"); }
            if (Type == "EmployeeTmp") { dt = DBCs.FetchData("SELECT photo FROM TempImage WHERE Type = 'Employee'  AND EmpID ='" + ID + "'"); }  

            if (Type == "Logo")        { dt = DBCs.FetchData("SELECT AppLogo FROM ApplicationSetup"); }
            if (Type == "LogoTmp")     { dt = DBCs.FetchData("SELECT photo FROM TempImage WHERE Type = 'Logo' AND EmpID ='" + ID + "'"); }
     
            //ReadImage

            if (DBCs.IsNullOrEmpty(dt)) { return; }
            if (Type == "Visitors" || Type == "Company" || Type == "Student" || Type == "Employee" )
            {
                Response.BinaryWrite(CryptoImage.DecryptBytes((Byte[])dt.Rows[0][0]));
                Response.End();
            }
            else
            {
                Response.BinaryWrite((Byte[])dt.Rows[0][0]);
                Response.End();
            }
        }
        catch (Exception e1) { }
    }
}
