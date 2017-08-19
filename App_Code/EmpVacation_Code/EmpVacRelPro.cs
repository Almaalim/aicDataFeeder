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

public class EmpVacRelPro
{
    private string _DateType;
    public string  DateType { get { return _DateType; } set { _DateType = value; } }

    protected string _EvrID;
    public string EvrID { get { return _EvrID; } set { _EvrID = value; } }

    private string _VtpID;
    public string VtpID { get { return _VtpID; } set { _VtpID = value; } }

    private string _EmpID;
    public string EmpID { get { return _EmpID; } set { _EmpID = value; } }

    private string _EvrStartDate;
    public string EvrStartDate { get { return _EvrStartDate; } set { _EvrStartDate = value; } }

    private string _EvrEndDate;
    public string EvrEndDate { get { return _EvrEndDate; } set { _EvrEndDate = value; } }

    private string _EvrDescription;
    public string EvrDescription { get { return _EvrDescription; } set { _EvrDescription = value; } }

    private string _EvrPhone;
    public string EvrPhone { get { return _EvrPhone; } set { _EvrPhone = value; } }

    private string _EvrAvailability;
    public string EvrAvailability { get { return _EvrAvailability; } set { _EvrAvailability = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////
    private string _TransactionBy;
    public string TransactionBy { get { return _TransactionBy; } set { _TransactionBy = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////
}
