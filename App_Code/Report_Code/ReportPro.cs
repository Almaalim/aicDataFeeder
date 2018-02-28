﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ReportPro
{
	private string _DateType;
    public  string DateType { get { return _DateType; } set { _DateType = value; } }

    private string _RepID;
    public string RepID { get { return _RepID; } set { _RepID = value; } }

    private string _RepTemp;
    public string RepTemp { get { return _RepTemp; } set { _RepTemp = value; } }

    private string _Lang;
    public string Lang { get { return _Lang; } set { _Lang = value; } }

    private string _CreatedBy;
    public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }

    private string _CreatedDate;
    public string CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }

    private string _ModifiedBy;
    public string ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }

    private string _ModifiedDate;
    public string ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    string _Date;
    public string Date { get { return _Date; } set { if (_Date != value) { _Date = value; } } }

    string _DateFrom;
    public string DateFrom { get { return _DateFrom; } set { if (_DateFrom != value) { _DateFrom = value; } } }

    string _DateTo;
    public string DateTo { get { return _DateTo; } set { if (_DateTo != value) { _DateTo = value; } } }

    string _WktID;
    public string WktID { get { return _WktID; } set { if (_WktID != value) { _WktID = value; } } }

    string _MacID;
    public string MacID { get { return _MacID; } set { if (_MacID != value) { _MacID = value; } } }

    string _EmpID;
    public string EmpID { get { return _EmpID; } set { if (_EmpID != value) { _EmpID = value; } } }

    string _DepID;
    public string DepID { get { return _DepID; } set { if (_DepID != value) { _DepID = value; } } }

    string _CatID;
    public string CatID { get { return _CatID; } set { if (_CatID != value) { _CatID = value; } } }

    string _UsrName;
    public string UsrName { get { return _UsrName; } set { if (_UsrName != value) { _UsrName = value; } } }

    string _ExcID;
    public string ExcID { get { return _ExcID; } set { if (_ExcID != value) { _ExcID = value; } } }

    string _VtpID;
    public string VtpID { get { return _VtpID; } set { if (_VtpID != value) { _VtpID = value; } } }

    string _Permissions;
    public string Permissions { get { return _Permissions; } set { if (_Permissions != value) { _Permissions = value; } } }

    string _MonthDate;
    public string MonthDate { get { return _MonthDate; } set { if (_MonthDate != value) { _MonthDate = value; } } }

    string _YearDate;
    public string YearDate { get { return _YearDate; } set { if (_YearDate != value) { _YearDate = value; } } }

    string _DaysCount;
    public string DaysCount { get { return _DaysCount; } set { if (_DaysCount != value) { _DaysCount = value; } } }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    string _RepName;
    public string RepName { get { return _RepName; } set { if (_RepName != value) { _RepName = value; } } }

    string _RepLang;
    public string RepLang { get { return _RepLang; } set { if (_RepLang != value) { _RepLang = value; } } }

    string _RepUser;
    public string RepUser { get { return _RepUser; } set { if (_RepUser != value) { _RepUser = value; } } }

    string _RepOrientation;
    public string RepOrientation { get { return _RepOrientation; } set { if (_RepOrientation != value) { _RepOrientation = value; } } }

    string _RepDesc;
    public string RepDesc { get { return _RepDesc; } set { if (_RepDesc != value) { _RepDesc = value; } } }

    string _RepPanels;
    public string RepPanels { get { return _RepPanels; } set { if (_RepPanels != value) { _RepPanels = value; } } }

    string _ProcedureName;
    public string ProcedureName { get { return _ProcedureName; } set { if (_ProcedureName != value) { _ProcedureName = value; } } }

    string _ProcedureParameters;
    public string ProcedureParameters { get { return _ProcedureParameters; } set { if (_ProcedureParameters != value) { _ProcedureParameters = value; } } }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private string _TransactionBy;
    public string TransactionBy { get { return _TransactionBy; } set { _TransactionBy = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
}