﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data;
using Class_EZ_Lic;

/// <summary>
/// Summary description for LicDf
/// </summary>
public class LicDf : DataLayerBase
{
    DBFun DBCs = new DBFun();
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //public enum VerEnum { General, Al_JoufUN, ImamUN, GACA, BorderGuard, Al_Maalim }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public LicDf() { }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string DetermineCompName(string IP)
    {
        IPAddress myIP = IPAddress.Parse(IP);
        IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
        List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
        return compName.First();
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string getClientPCName()
    {
        string ClientPCName = "";

        try
        {

            IPAddress myIP = IPAddress.Parse(HttpContext.Current.Request.UserHostName);
            IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
            ClientPCName = GetIPHost.HostName.ToString();
        }
        catch { }

        return ClientPCName;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string FetchLic(string Lic)
    {
        string ClientPCName = getClientPCName();
        //string ClientPCName = "";
        //string ClientPCName = "Ameen.Almaalim.local";
        return FetchLic(Lic, General.ConnString, ClientPCName);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string FindLicPage()
    {
        //string ClientPCName = getClientPCName();
        ////string ClientPCName = "";
        ////string ClientPCName = "Ameen.Almaalim.local";
        //return FindAMSLicPage(General.ConnString, ClientPCName);
        return "";
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string FindActiveVersion() { return GetActiveVersion(General.ConnString); }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //public static string FetchVerName(VerEnum name) { return name.ToString(); }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string FetchLic(string Lic, string pSCon, string ClientName)
    {
        //string ClientPCName = getClientPCName();
        //string ClientPCName = "";
        string ClientPCName = "NAGHASH.Almaalim.local";
        
        //return EZLic.FetchEZLic(Lic, General.ConnString, ClientPCName);
        
        return "1";
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public string GetActiveVersion(string pSCon)
    {
        string sVer = "";
        DataTable dt = DBCs.FetchData("SELECT AppVerID FROM ApplicationSetup");
        if (!DBCs.IsNullOrEmpty(dt))
        {
            sVer = CryptorEngine.Decrypt(dt.Rows[0]["AppVerID"].ToString(), true);
        }

        return sVer;
    }
}