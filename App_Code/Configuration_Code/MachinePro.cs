using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class MachinePro
{
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private string _DateType;
    public  string DateType { get { return _DateType; } set { _DateType = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private string _MacID;
    public string MacID { get { return _MacID; } set { _MacID = value; } }

    private string _MtpID;
    public string MtpID { get { return _MtpID; } set { _MtpID = value; } }

    private string _MachineNo;
    public string MachineNo { get { return _MachineNo; } set { _MachineNo = value; } }

    private string _IPAddress;
    public string IPAddress { get { return _IPAddress; } set { _IPAddress = value; } }

    private string _Port;
    public string Port { get { return _Port; } set { _Port = value; } }

    private string _MachineSerialNo;
    public string MachineSerialNo { get { return _MachineSerialNo; } set { _MachineSerialNo = value; } }

    private string _LocationAr;
    public string LocationAr { get { return _LocationAr; } set { _LocationAr = value; } }

    private string _LocationEn;
    public string LocationEn { get { return _LocationEn; } set { _LocationEn = value; } }

    private bool _MachineStatus;
    public bool MachineStatus { get { return _MachineStatus; } set { _MachineStatus = value; } }

    private string _MachineINOUTType;
    public string MachineINOUTType { get { return _MachineINOUTType; } set { _MachineINOUTType = value; } }

    private bool _MachineExport;
    public bool MachineExport { get { return _MachineExport; } set { _MachineExport = value; } }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private string _TransactionBy;
    public string TransactionBy { get { return _TransactionBy; } set { _TransactionBy = value; } }

    private string _TransactionDate;
    public string TransactionDate { get { return _TransactionDate; } set { _TransactionDate = value; } }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}