using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class WorktimePro
{
    string _DateFormat;
    public string DateFormat { get { return _DateFormat; } set { if (_DateFormat != value) { _DateFormat = value; } } }

    private string _DateType;
    public string DateType { get { return _DateType; } set { _DateType = value; } }

    private string _WktID;
    public string WktID { get { return _WktID; } set { _WktID = value; } }

    private string _WktNameAr;
    public string WktNameAr { get { return _WktNameAr; } set { _WktNameAr = value; } }

    private string _WktNameEn;
    public string WktNameEn { get { return _WktNameEn; } set { _WktNameEn = value; } }

    private bool _WktSat;
    public bool WktSat
    { get { return _WktSat; } set { _WktSat = value; } }

    private bool _WktSun;
    public bool WktSun
    { get { return _WktSun; } set { _WktSun = value; } }

    private bool _WktMon;
    public bool WktMon
    { get { return _WktMon; } set { _WktMon = value; } }

    private bool _WktTue;
    public bool WktTue
    { get { return _WktTue; } set { _WktTue = value; } }

    private bool _WktWed;
    public bool WktWed
    { get { return _WktWed; } set { _WktWed = value; } }

    private bool _WktThu;
    public bool WktThu
    { get { return _WktThu; } set { _WktThu = value; } }

    private bool _WktFri;
    public bool WktFri
    { get { return _WktFri; } set { _WktFri = value; } }

    private string _MWktDesc;
    public string WktDesc { get { return _MWktDesc; } set { _MWktDesc = value; } }

    private string _WktStartDate;
    public string WktStartDate { get { return _WktStartDate; } set { _WktStartDate = value; } }

    private string _WktEndDate;
    public string WktEndDate { get { return _WktEndDate; } set { _WktEndDate = value; } }

    private int _WtpID;
    public int WtpID { get { return _WtpID; } set { _WtpID = value; } }

    private string _WktShift1NameAr;
    public string WktShift1NameAr { get { return _WktShift1NameAr; } set { _WktShift1NameAr = value; } }

    private string _WktShift1NameEn;
    public string WktShift1NameEn { get { return _WktShift1NameEn; } set { _WktShift1NameEn = value; } }

    private DateTime _WktShift1From;
    public DateTime WktShift1From { get { return _WktShift1From; } set { _WktShift1From = value; } }

    private DateTime _WktShift1To;
    public DateTime WktShift1To { get { return _WktShift1To; } set { _WktShift1To = value; } }

    private int _WktShift1Grace;
    public int WktShift1Grace { get { return _WktShift1Grace; } set { _WktShift1Grace = value; } }

    private int _WktShift1Duration;
    public int WktShift1Duration { get { return _WktShift1Duration; } set { _WktShift1Duration = value; } }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private string _WktShift2NameAr;
    public string WktShift2NameAr { get { return _WktShift2NameAr; } set { _WktShift2NameAr = value; } }

    private string _WktShift2NameEn;
    public string WktShift2NameEn { get { return _WktShift2NameEn; } set { _WktShift2NameEn = value; } }

    private DateTime _WktShift2From;
    public DateTime WktShift2From { get { return _WktShift2From; } set { _WktShift2From = value; } }

    private DateTime _WktShift2To;
    public DateTime WktShift2To { get { return _WktShift2To; } set { _WktShift2To = value; } }

    private int _WktShift2Grace;
    public int WktShift2Grace { get { return _WktShift2Grace; } set { _WktShift2Grace = value; } }

    private int _WktShift2Duration;
    public int WktShift2Duration { get { return _WktShift2Duration; } set { _WktShift2Duration = value; } }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private string _WktShift3NameAr;
    public string WktShift3NameAr { get { return _WktShift3NameAr; } set { _WktShift3NameAr = value; } }

    private string _WktShift3NameEn;
    public string WktShift3NameEn { get { return _WktShift3NameEn; } set { _WktShift3NameEn = value; } }

    private DateTime _WktShift3From;
    public DateTime WktShift3From { get { return _WktShift3From; } set { _WktShift3From = value; } }

    private DateTime _WktShift3To;
    public DateTime WktShift3To { get { return _WktShift3To; } set { _WktShift3To = value; } }

    private int _WktShift3Grace;
    public int WktShift3Grace { get { return _WktShift3Grace; } set { _WktShift3Grace = value; } }

    private int _WktShift3Duration;
    public int WktShift3Duration { get { return _WktShift3Duration; } set { _WktShift3Duration = value; } }
      
    //private string _CreatedBy;
    //public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }

    //private string _CreatedDate;
    //public string CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }

    //private string _ModifiedBy;
    //public string ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }

    //private string _ModifiedDate;
    //public string ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }

    //private string _DeletedBy;
    //public string DeletedBy { get { return _DeletedBy; } set { _DeletedBy = value; } }

    //private string _DeletedDate;
    //public string DeletedDate { get { return _DeletedDate; } set { _DeletedDate = value; } }

    //private bool _Deleted;
    //public bool Deleted { get { return _Deleted; } set { _Deleted = value; } }

    //private bool _WktIsActive;
    //public bool WktIsActive { get { return _WktIsActive; } set { _WktIsActive = value; } }

    private int _WktShiftCount;
    public int WktShiftCount { get { return _WktShiftCount; } set { _WktShiftCount = value; } }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private string _TransactionBy;
    public string TransactionBy { get { return _TransactionBy; } set { _TransactionBy = value; } }

    private string _TransactionDate;
    public string TransactionDate { get { return _TransactionDate; } set { _TransactionDate = value; } }

}