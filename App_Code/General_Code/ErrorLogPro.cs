using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ErrorLogPro
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private string _DateType;
    public string DateType { get { return _DateType; } set { _DateType = value; } }

    private string _ErrorPage;
    public string ErrorPage { get { return _ErrorPage; } set { _ErrorPage = value; } }

    private string _ErrorFunction;
    public string ErrorFunction { get { return _ErrorFunction; } set { _ErrorFunction = value; } }

    private string _ErrorMessage;
    public string ErrorMessage { get { return _ErrorMessage; } set { _ErrorMessage = value; } }

    private string _ErrorDate;
    public string ErrorDate { get { return _ErrorDate; } set { _ErrorDate = value; } }
    
    private string _LoginUserID;
    public string LoginUserID { get { return _LoginUserID; } set { _LoginUserID = value; } }

    private string _LoginUserRole;
    public string LoginUserRole { get { return _LoginUserRole; } set { _LoginUserRole = value; } }

}