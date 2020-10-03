using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MyBaseControl
/// </summary>
public class MyBaseControl : System.Web.UI.UserControl
{
    public string ConnectionString
    {
        get { return ViewState["ConnectionString"] as string; }
        set { ViewState["ConnectionString"] = value; }
    }
    public string XMLReportFile
    {
        get { return ViewState["XMLReportFile"].ToString(); ; }
        set { ViewState["XMLReportFile"] = value; }
    }
  
}