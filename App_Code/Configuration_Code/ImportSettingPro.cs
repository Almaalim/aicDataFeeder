﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ImportSettingPro
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private string _DateType;
    public string DateType { get { return _DateType; } set { _DateType = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private bool _IpsSaveTransInFile;
    public bool IpsSaveTransInFile { get { return _IpsSaveTransInFile; } set { _IpsSaveTransInFile = value; } }

    private bool _IpsEncryptTransInFile;
    public bool IpsEncryptTransInFile { get { return _IpsEncryptTransInFile; } set { _IpsEncryptTransInFile = value; } }

    private bool _IpsRunProcess;
    public bool IpsRunProcess { get { return _IpsRunProcess; } set { _IpsRunProcess = value; } }

    private string _IpsImportScheduleTimes;
    public string IpsImportScheduleTimes { get { return _IpsImportScheduleTimes; } set { _IpsImportScheduleTimes = value; } }

    private string _IpsProcessScheduleTimes;
    public string IpsProcessScheduleTimes { get { return _IpsProcessScheduleTimes; } set { _IpsProcessScheduleTimes = value; } }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private string _TransactionBy;
    public string TransactionBy { get { return _TransactionBy; } set { _TransactionBy = value; } }

    private string _TransactionDate;
    public string TransactionDate { get { return _TransactionDate; } set { _TransactionDate = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}