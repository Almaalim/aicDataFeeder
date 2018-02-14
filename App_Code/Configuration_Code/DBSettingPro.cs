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

public class DBSettingPro
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	private string _DateType;
    public string DateType { get { return _DateType; } set { _DateType = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private string _TableName;
    public string TableName { get { return _TableName; } set { _TableName = value; } }

    private string _EmployeeField;
    public string EmployeeField { get { return _EmployeeField; } set { _EmployeeField = value; } }

    private string _DateField;
    public string DateField { get { return _DateField; } set { _DateField = value; } }

    private string _TimeField;
    public string TimeField { get { return _TimeField; } set { _TimeField = value; } }

    private string _InOutField;
    public string InOutField { get { return _InOutField; } set { _InOutField = value; } }

    private string _MachineIdField;
    public string MachineIdField { get { return _MachineIdField; } set { _MachineIdField = value; } }

    private string _LocationField;
    public string LocationField { get { return _LocationField; } set { _LocationField = value; } }

    private string _SchemaName;
    public string SchemaName { get { return _SchemaName; } set { _SchemaName = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private string _TransactionBy;
    public string TransactionBy { get { return _TransactionBy; } set { _TransactionBy = value; } }

    private string _TransactionDate;
    public string TransactionDate { get { return _TransactionDate; } set { _TransactionDate = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private string _DBServer;
    public string DBServer { get { return _DBServer; } set { _DBServer = value; } }

    private string _DBUsername;
    public string DBUsername { get { return _DBUsername; } set { _DBUsername = value; } }

    private string _DBPassword;
    public string DBPassword { get { return _DBPassword; } set { _DBPassword = value; } }

    private string _DBName;
    public string DBName { get { return _DBName; } set { _DBName = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}