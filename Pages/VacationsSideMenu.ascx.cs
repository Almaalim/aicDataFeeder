﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_VacationsSideMenu : System.Web.UI.UserControl
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void Page_Load(object sender, EventArgs e)
    {
        FormSession.FillSession("", null);
        PermSideMenu();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected void btnSideMenu_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        Response.Redirect(lb.PostBackUrl);
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void PermSideMenu()
    {
        btnVacationsType.Enabled = FormSession.getPerm("VVac");
        btnEmployeeVacations.Enabled = FormSession.getPerm("VEmpVac");
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void RedirectPage()
    {
        PermSideMenu();
        foreach (Control ctrl in this.Controls)
        {
            if (ctrl is LinkButton)
            {
                LinkButton lb = (LinkButton)ctrl;
                string id = lb.ID;
                if (lb.Enabled) { Response.Redirect(lb.PostBackUrl); break; }
            }
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}