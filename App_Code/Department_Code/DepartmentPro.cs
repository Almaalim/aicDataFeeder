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

public class DepartmentPro
{
    private string _DateType;
    public string  DateType { get { return _DateType; } set { _DateType = value; } }

    protected string _DepID;
    public string DepID { get { return _DepID; } set { _DepID = value; } }

    private string _DepNameAr;
    public string DepNameAr { get { return _DepNameAr; } set { _DepNameAr = value; } }

    private string _DepNameEn;
    public string DepNameEn { get { return _DepNameEn; } set { _DepNameEn = value; } }

    private string _DepDesc;
    public string DepDesc { get { return _DepDesc; } set { _DepDesc = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////
    protected int _DepParentID;
    public int DepParentID { get { return _DepParentID; } set { _DepParentID = value; } }

    private bool _DepStatus;
    public bool DepStatus { get { return _DepStatus; } set { _DepStatus = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////
    private string _TransactionBy;
    public string TransactionBy { get { return _TransactionBy; } set { _TransactionBy = value; } }

}
