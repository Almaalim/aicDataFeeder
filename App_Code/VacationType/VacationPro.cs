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

public class VacationPro
{
    private string _DateType;
    public string  DateType { get { return _DateType; } set { _DateType = value; } }

    protected string _VtpID;
    public string VtpID { get { return _VtpID; } set { _VtpID = value; } }

    private string _VtpNameAr;
    public string VtpNameAr { get { return _VtpNameAr; } set { _VtpNameAr = value; } }

    private string _VtpNameEn;
    public string VtpNameEn { get { return _VtpNameEn; } set { _VtpNameEn = value; } }

    private string _VtpDesc;
    public string VtpDesc { get { return _VtpDesc; } set { _VtpDesc = value; } }
    
    private bool _VtpStatus;
    public bool VtpStatus { get { return _VtpStatus; } set { _VtpStatus = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////
    private string _TransactionBy;
    public string TransactionBy { get { return _TransactionBy; } set { _TransactionBy = value; } }

}
