﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddTransPro
/// </summary>
public class AddTransPro
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private string _DateType;
    public string DateType { get { return _DateType; } set { _DateType = value; } }

    private string _EmpID;
    public string EmpID { get { return _EmpID; } set { _EmpID = value; } }

    private string _TrnDate;
    public string TrnDate { get { return _TrnDate; } set { _TrnDate = value; } }

    private DateTime _TrnTime;
    public DateTime TrnTime { get { return _TrnTime; } set { _TrnTime = value; } }

    private string _TrnType;
    public string TrnType { get { return _TrnType; } set { _TrnType = value; } }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}