/// <summary>               
/// <Description>Report user control</Description>
/// <DevelopedBy>"Nilofar Dabhi"</DevelopedBy>
/// <DevelopedDate>"05-May-2014"</DevelopedDate>
/// <UpdatedBy>""</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>


using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Collections;
using System.Web.UI;
using Udev.UserMasterPage.Classes;
using System.IO;
using System.Web;


public partial class ReportControl : System.Web.UI.UserControl
{

    #region "Variable declaration"


    string strSQL = string.Empty;
    string language = string.Empty;
    public List<string> HiddenFields;
    public List<string> ColumnWidth;
    public List<string> alignment;
    private string _XMLFile = string.Empty;
    DataTable tblSearch;
    DataTable tblsearch2 = new DataTable();
    DataSet dsreportdetails = new DataSet();
    Hashtable hashtable = new Hashtable();
    DataTable dt = new DataTable();
    //string str_status;
    DataSet xmllanguage = new DataSet();
    string sortingcolumn = string.Empty;
    double finaltotal = 0;

    #endregion

    #region "Properties"

    /// <summary>
    /// Gets or Sets Title visibility
    /// </summary>
    public bool ShowTitle
    {
        get
        {
            return lblTitle.Visible;
        }
        set
        {
            lblTitle.Visible = value;
        }
    }



    public SortDirection dir
    {
        get
        {
            if (ViewState["dirState"] == null)
            {
                ViewState["dirState"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["dirState"];
        }

        set
        {
            ViewState["dirState"] = value;
        }

    }

    /// <summary>
    /// Get or sets footer text
    /// </summary>

    public string FooterText
    {
        get
        {
            return lblFooter.Text;
        }

        set
        {
            lblFooter.Text = value;
        }
    }


    /// <summary>
    /// Gets or Sets Connection string.
    /// </summary>
    public string ConnectionString
    {
        get
        {
            return ViewState["ConnectionString"].ToString();
        }
        set
        {
            ViewState["ConnectionString"] = value;
        }
    }

    /// <summary>
    /// Gets or Sets data table value for indexing in gridview.
    /// </summary>

    //public object tblsearch1
    //{
    //    get
    //    {
    //        return ViewState["TBLSEARCH"];
    //    }
    //    set
    //    {
    //        ViewState["TBLSEARCH"] = value;
    //    }
    //}

    public object searchstatus
    {
        get
        {
            return ViewState["searchstatus"];
        }
        set
        {
            ViewState["searchstatus"] = value;
        }
    }
    /// <summary>
    /// Get and sets XMLReportFile
    /// </summary>

    public string XMLReportFile
    {
        get { return ViewState["XMLReportFile"].ToString(); ; }
        set { ViewState["XMLReportFile"] = value; }
    }


    #endregion

    #region page load event

    /// <summary>
    /// Page Load event of the page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //DataSet xmllanguage = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {
                Session["Language"] = Session["LANG"].ToString();
                Session[Global.SESSION_KEY_CULTURE] = Session["LANG"].ToString();

            }
            catch (Exception ex)
            {
                WebMsg.Show("error in page load" + ex.Message.ToString());
            }


        }



    }
    #endregion


    #region "Methods"

    /// <summary>
    /// Get elements from XML file and return value to that XML tag
    /// </summary>
    /// <param name="strTagName"></param>
    /// <returns>Returns value of tag</returns>



    public string GetXMLElementByTagName(string strTagName)
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLReportFile);
            XmlNodeList list = doc.GetElementsByTagName(strTagName);
            return list.Item(0).InnerText.Trim().ToLower();

        }
        catch (Exception ex)
        {
            WebMsg.Show("error in Get xml element by tag name" + ex.Message.ToString());

            return string.Empty;
        }
    }


    /// <summary>
    ///  Get all the control setting    
    /// </summary>

    public void Getallinitialdata()
    {
        try
        {
            strSQL = GetXMLElementByTagName("SQL");
            lblTitle.Text = GetXMLElementByTagName("Title");
            HiddenFields = GetHiddenFields();
            ColumnWidth = GetColumnWidth();
            alignment = GetAlignment();
            language = Session["LANG"].ToString();
            //_Today = GetDate();
        }
        catch (Exception ex)
        {
            WebMsg.Show("error in get all initial data" + ex.Message.ToString());


        }


    }

    /// <summary>
    /// Get today's date
    /// </summary>
    /// <returns>today's date</returns>
    private System.DateTime GetDate()
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT GETDATE()", ConnectionString);
            tblSearch = new DataTable();
            da.Fill(tblSearch);
            return Convert.ToDateTime(tblSearch.Rows[0][0].ToString());
        }
        catch (Exception ex)
        {
            WebMsg.Show("error in get date" + ex.Message.ToString());
        }

        return Convert.ToDateTime(DateTime.Now);
    }

    /// <summary>
    /// Get all the hiddent field column names
    /// </summary>
    /// <returns>List of hidden columns  </returns>
    public List<string> GetHiddenFields()
    {
        try
        {
            List<string> HD = new List<string>();
            string strHiddenFields = GetXMLElementByTagName("HiddenFields");
            string[] str = SplitString(strHiddenFields, ",", ", ", " ,", " , ");
            foreach (string s in str)
            {
                HD.Add(s.Trim());
            }
            return HD;
        }
        catch (Exception ex)
        {
            WebMsg.Show("error in get hidden field" + ex.Message.ToString());

            return null;
        }
    }

    /// <summary>
    /// Get size of column width 
    /// </summary>
    /// <returns>List of column name and its width</returns>

    public List<string> GetColumnWidth()
    {
        try
        {

            List<string> colWidth = new List<string>();
            string strColumnWidth = GetXMLElementByTagName("ColumnWidth");
            string[] str = SplitString(strColumnWidth, ",", ", ", " ,", " , ");
            foreach (string s in str)
            {
                //string[] Col = SplitString(s, "=");
                colWidth.Add(s.Trim());
                //colWidth.Add(Conversion.Val(Col(1).Trim).ToString, Col(0).Trim);
            }
            return colWidth;
        }
        catch (Exception ex)
        {
            WebMsg.Show("error in get column width" + ex.Message.ToString());

            return null;
        }
    }

    /// <summary>
    /// Get alignment settings for columns
    /// </summary>
    /// <returns></returns>

    public List<string> GetAlignment()
    {
        try
        {

            List<string> alignment = new List<string>();
            string strAlignment = GetXMLElementByTagName("alignment");
            string[] str = SplitString(strAlignment, ",", ", ", " ,", " , ");
            foreach (string s in str)
            {
                //string[] Col = SplitString(s, "=");
                alignment.Add(s.Trim());
                //colWidth.Add(Conversion.Val(Col(1).Trim).ToString, Col(0).Trim);
            }
            return alignment;
        }
        catch (Exception ex)
        {
            WebMsg.Show("error in get all alignment" + ex.Message.ToString());

            return null;
        }
    }

    /// <summary>
    /// Split the given string
    /// </summary>
    /// <param name="strsplit">string to split</param>
    /// <param name="Seperator">Seperator from which string will split</param>
    /// <returns>String array of seperated string </returns>

    public string[] SplitString(string strsplit, params string[] Seperator)
    {

        return (strsplit.Split(Seperator, StringSplitOptions.RemoveEmptyEntries));
    }

    /// <summary>
    /// Get all the clause and header footer visibility setting from XML file and fill the grid report
    /// </summary>


    public string GetAllSettings()
    {
        try
        {
            string allowfooter = GetXMLElementByTagName("allowfooter").ToLower();
            if (allowfooter.Trim().ToLower() == "true")
            {
                lblFooter.Visible = true;
            }
            else
            {
                lblFooter.Visible = false;
            }

            string allowheader = GetXMLElementByTagName("allowheader").ToLower();
            if (allowheader.Trim().ToLower() == "true")
            {
                lblTitle.Visible = true;
            }
            else
            {
                lblTitle.Visible = false;
            }


            string ispaging = GetXMLElementByTagName("AllowPaging").ToLower();
            if (ispaging.Trim().Length > 2 && ispaging.Trim().ToLower() == "true")
            {
                gridreport.AllowPaging = true;
                gridreport.PageSize = int.Parse(GetXMLElementByTagName("pagesize"));
            }
            else
            {
                gridreport.AllowPaging = false;
            }

            string strGroupBy = GetXMLElementByTagName("GroupBy");
            if (strGroupBy.Trim().Length > 1)
            {
                strGroupBy = " Group By " + strGroupBy;
            }
            string strOrderBy = GetXMLElementByTagName("OrderBy");
            if (strOrderBy.Trim().Length > 3)
            {
                strOrderBy = " Order By " + strOrderBy;
            }

            string strWhere = GetXMLElementByTagName("Where");
            try
            {
                if (strWhere.Trim().Length > 3)
                {
                    strWhere = " where " + GetXMLElementByTagName("Where");
                }
            }


            catch (Exception ex)
            {
            }

            return strSQL + strWhere + strGroupBy + strOrderBy;
        }
        catch (Exception ex)
        {
            WebMsg.Show("error in get all settings" + ex.Message.ToString());
            return null;

        }


    }


    //string sortingcolumn = string.Empty;

    /// <summary>
    /// This method fills grid report when query need to be fetch from given XML file
    /// </summary>

    public void Search()
    {

        try
        {

            searchstatus = 0;
            Getallinitialdata();

            string SQLSTRING = GetAllSettings();


            if (SQLSTRING.Trim() != "")
            {

                GetTestTable(SQLSTRING);
                gridreport.DataSource = null;
                gridreport.DataBind();
                //ViewState["exportdata"] = tblSearch;
                Session["dtsearch"] = tblSearch;
                gridreport.DataSource = tblSearch;
                gridreport.DataBind();
                SetTotal();

                ALLSetting(tblSearch);
                gridreport.DataSource = tblSearch;
                gridreport.DataBind();

                #region keepit
                //grdSearchResult.Columns[i].HeaderText = grdSearchResult.Columns[i].HeaderText.Replace("_", ""); 
                //    if (sortingcolumn != null && sortingcolumn != "")
                //    {
                //        DataView dv = new DataView(tblSearch);
                //        string SortDir = string.Empty;
                //        if (dir == SortDirection.Ascending)
                //        {
                //            dir = SortDirection.Descending;
                //            SortDir = "Desc";
                //        }
                //        else
                //        {
                //            dir = SortDirection.Ascending;
                //            SortDir = "Asc";
                //        }
                //        dv.Sort = sortingcolumn + " " + SortDir;
                //        gridreport.DataSource = dv;
                //        gridreport.DataBind();
                //    }
                //    for (int j = 0; j < gridreport.Rows.Count; j++)
                //    {
                //        for (int i = 0; i < gridreport.Rows[0].Cells.Count; i++)
                //        {
                //            //string HeaderText = c.HeaderText.ToLower();
                //            string HeaderText = (((System.Web.UI.WebControls.DataControlFieldCell)(gridreport.Rows[j].Cells[i])).ContainingField).HeaderText.ToLower();
                //            try
                //            {
                //                switch (tblSearch.Columns[HeaderText].DataType.ToString().ToLower())
                //                {
                //                    case "system.string":
                //                        break;
                //                    case "system.decimal":
                //                        gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                //                        break;
                //                    case "system.int32":
                //                        gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                //                        break;
                //                    case "system.int64":
                //                        gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                //                        break;
                //                    case "system.byte":
                //                    case "system.boolean":
                //                        break;
                //                    default:
                //                        System.Diagnostics.Debugger.Break();
                //                        break;
                //                }
                //                if (ColumnWidth != null)
                //                {
                //                    foreach (string s in ColumnWidth)
                //                    {
                //                        string[] words = s.Split('=');
                //                        if (HeaderText.ToLower() == words[0].ToString().ToLower())
                //                        {
                //                            gridreport.Rows[j].Cells[i].Width = Convert.ToInt32(words[1]);
                //                            break;
                //                        }
                //                    }
                //                }
                //                if (alignment != null)
                //                {
                //                    foreach (string s in alignment)
                //                    {
                //                        string[] words = s.Split('=');
                //                        if (HeaderText.ToLower() == words[0].ToString().ToLower())
                //                        {
                //                            string stralignment = words[1];
                //                            if (stralignment.Trim().ToLower() == "right")
                //                            {
                //                                gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                //                            }
                //                            else if (stralignment.Trim().ToLower() == "left")
                //                            {
                //                                gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Left;
                //                            }
                //                            else if (stralignment.Trim().ToLower() == "center")
                //                            {
                //                                gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Center;
                //                            }
                //                            else if (stralignment.Trim().ToLower() == "justify")
                //                            {
                //                                gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Justify;
                //                            }
                //                        }
                //                    }
                //                }
                //                if (HiddenFields != null)
                //                {
                //                    foreach (string s in HiddenFields)
                //                    {
                //                        if (HeaderText.ToLower() == s.ToLower())
                //                        {
                //                            gridreport.Rows[j].Cells[i].Visible = false;
                //                            (((System.Web.UI.WebControls.DataControlFieldCell)(gridreport.Rows[j].Cells[i])).ContainingField).Visible = false;
                //                            break;
                //                        }
                //                    }
                //                }
                //            }
                //            catch (Exception ex)
                //            {
                //            }
                //        }
                //    }
                #endregion

            }
        }
        catch (Exception ex)
        {
            WebMsg.Show("error in search" + ex.Message.ToString());
        }


    }




    /// <summary>
    /// sets width of report column, alignment of the report column data and hide the visibility of column and dislpay data as per requirement
    /// </summary>
    /// <param name="dtSearch">Datatable to fill report </param>
    //DataTable dtsearch = new DataTable();


    public void ALLSetting(DataTable dtSearch)
    {
        if (sortingcolumn != null && sortingcolumn != "")
        {
            DataView dv = new DataView(dtSearch);

            string SortDir = string.Empty;
            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                SortDir = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                SortDir = "Asc";
            }

            dv.Sort = sortingcolumn + " " + SortDir;
            gridreport.DataSource = dv;

            gridreport.DataBind();
        }



        for (int j = 0; j < gridreport.Rows.Count; j++)
        {

            for (int i = 0; i < gridreport.Rows[0].Cells.Count; i++)
            {
                //string HeaderText = c.HeaderText.ToLower();
                string HeaderText = (((System.Web.UI.WebControls.DataControlFieldCell)(gridreport.Rows[j].Cells[i])).ContainingField).HeaderText.ToLower();

                try
                {
                    switch (dtSearch.Columns[HeaderText].DataType.ToString().ToLower())
                    {
                        case "system.string":
                            break;
                        case "system.decimal":
                            gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                            break;
                        case "system.int16":
                            gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                            break;
                        case "system.int32":
                            gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                            break;

                        case "system.int64":
                            gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                            break;
                        case "system.byte":
                        case "system.boolean":
                            break;
                        case "system.datetime":
                            break;
                        case "System.Diagnostics.Debugger":
                            break;
                        //default:
                        //    System.Diagnostics.Debugger.Break();
                        //    break;
                    }

                    if (ColumnWidth != null)
                    {
                        foreach (string s in ColumnWidth)
                        {
                            string[] words = s.Split('=');
                            if (HeaderText.ToLower() == words[0].ToString().ToLower())
                            {
                                gridreport.Rows[j].Cells[i].Width = Convert.ToInt32(words[1]);
                                break;
                            }
                        }
                    }
                    if (alignment != null)
                    {
                        foreach (string s in alignment)
                        {
                            string[] words = s.Split('=');
                            if (HeaderText.ToLower() == words[0].ToString().ToLower())
                            {
                                string stralignment = words[1];

                                if (stralignment.Trim().ToLower() == "right")
                                {
                                    gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                                }
                                else if (stralignment.Trim().ToLower() == "left")
                                {
                                    gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Left;
                                }
                                else if (stralignment.Trim().ToLower() == "center")
                                {
                                    gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Center;
                                }
                                else if (stralignment.Trim().ToLower() == "justify")
                                {
                                    gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Justify;
                                }
                            }
                        }
                    }

                    if (HiddenFields != null)
                    {

                        foreach (string s in HiddenFields)
                        {
                            if (HeaderText.ToLower() == s.ToLower())
                            {
                                gridreport.Rows[j].Cells[i].Visible = false;
                                (((System.Web.UI.WebControls.DataControlFieldCell)(gridreport.Rows[j].Cells[i])).ContainingField).Visible = false;
                                break;
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                }
            }
        }
    }


    /// <summary>
    /// This method fills grid report using given datatable
    /// </summary>
    /// <param name="dtSearch"></param>

    public void Search(DataTable dtSearch)
    {

        try
        {

            searchstatus = 1;

            Getallinitialdata();
            GetAllSettings();

            Session["dtsearch"] = dtSearch;
            gridreport.DataSource = null;
            gridreport.DataSource = dtSearch;
            gridreport.DataBind();
            SetTotal();
            ALLSetting(dtSearch);

            //if (sortingcolumn != null && sortingcolumn != "")
            //{
            //    DataView dv = new DataView(dtSearch);

            //    string SortDir = string.Empty;
            //    if (dir == SortDirection.Ascending)
            //    {
            //        dir = SortDirection.Descending;
            //        SortDir = "Desc";
            //    }
            //    else
            //    {
            //        dir = SortDirection.Ascending;
            //        SortDir = "Asc";
            //    }

            //    dv.Sort = sortingcolumn + " " + SortDir;
            //    gridreport.DataSource = dv;

            //    gridreport.DataBind();





            //}



            //for (int j = 0; j < gridreport.Rows.Count; j++)
            //{

            //    for (int i = 0; i < gridreport.Rows[0].Cells.Count; i++)
            //    {
            //        //string HeaderText = c.HeaderText.ToLower();
            //        string HeaderText = (((System.Web.UI.WebControls.DataControlFieldCell)(gridreport.Rows[j].Cells[i])).ContainingField).HeaderText.ToLower();

            //        try
            //        {
            //            switch (dtSearch.Columns[HeaderText].DataType.ToString().ToLower())
            //            {
            //                case "system.string":
            //                    break;
            //                case "system.decimal":
            //                    gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
            //                    break;
            //                case "system.int16":
            //                    gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
            //                    break;
            //                case "system.int32":
            //                    gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
            //                    break;

            //                case "system.int64":
            //                    gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
            //                    break;
            //                case "system.byte":
            //                case "system.boolean":
            //                    break;
            //                case "system.datetime":
            //                    break;
            //                case "System.Diagnostics.Debugger":
            //                    break;
            //                //default:
            //                //    System.Diagnostics.Debugger.Break();
            //                //    break;
            //            }

            //            if (ColumnWidth != null)
            //            {
            //                foreach (string s in ColumnWidth)
            //                {
            //                    string[] words = s.Split('=');
            //                    if (HeaderText.ToLower() == words[0].ToString().ToLower())
            //                    {
            //                        gridreport.Rows[j].Cells[i].Width = Convert.ToInt32(words[1]);
            //                        break;
            //                    }
            //                }
            //            }
            //            if (alignment != null)
            //            {
            //                foreach (string s in alignment)
            //                {
            //                    string[] words = s.Split('=');
            //                    if (HeaderText.ToLower() == words[0].ToString().ToLower())
            //                    {
            //                        string stralignment = words[1];

            //                        if (stralignment.Trim().ToLower() == "right")
            //                        {
            //                            gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
            //                        }
            //                        else if (stralignment.Trim().ToLower() == "left")
            //                        {
            //                            gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Left;
            //                        }
            //                        else if (stralignment.Trim().ToLower() == "center")
            //                        {
            //                            gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Center;
            //                        }
            //                        else if (stralignment.Trim().ToLower() == "justify")
            //                        {
            //                            gridreport.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Justify;
            //                        }
            //                    }
            //                }
            //            }

            //            if (HiddenFields != null)
            //            {

            //                foreach (string s in HiddenFields)
            //                {
            //                    if (HeaderText.ToLower() == s.ToLower())
            //                    {
            //                        gridreport.Rows[j].Cells[i].Visible = false;
            //                        (((System.Web.UI.WebControls.DataControlFieldCell)(gridreport.Rows[j].Cells[i])).ContainingField).Visible = false;
            //                        break;
            //                    }
            //                }
            //            }
            //        }

            //        catch (Exception ex)
            //        {
            //        }
            //    }
            //}
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message.ToString());
        }



    }

    /// <summary>
    /// Fill the table for required query
    /// </summary>
    /// <param name="strQuery"></param>

    private void GetTestTable(string strQuery)
    {
        try
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(strQuery, connection);
            tblSearch = new DataTable();
            da.Fill(tblSearch);
            ViewState["TBLSEARCH"] = tblSearch;

        }
        catch (Exception ex)
        {
            WebMsg.Show("error in get test table " + ex.Message.ToString());

        }

    }

    /// <summary>
    /// Get the total of required column value
    /// </summary>
    //double finaltotal = 0;


    public void SetTotal()
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLReportFile);
            string TotalColumn = string.Empty;
            XmlNodeList list = doc.GetElementsByTagName("Total");
            int rowcnt = 0;
            foreach (XmlElement item in list)
            {
                TotalColumn = item.InnerText;
            }
            if (TotalColumn.Length == 0) { lblFooter.Text = ""; return; }
            double total = 0;
            string columnname = "";
            foreach (GridViewRow dr in gridreport.Rows)
            {
                //int rowcnt = gridreport.Rows
                for (int j = 0; j < dr.Cells.Count; j++)
                {
                    columnname = ((System.Web.UI.WebControls.DataControlFieldCell)(dr.Cells[j])).ContainingField.HeaderText.ToLower();
                    if (columnname == TotalColumn.ToLower())
                    {
                        total += Double.Parse(dr.Cells[j].Text.ToString());
                        ViewState["granttotal"] = total;
                        //rowcnt = rowcnt+1;
                    }
                }
            }

            //foreach (GridViewRow dr in ((System.Data.DataTable)(gridreport.DataSource)).Rows)
            //{
            for (int i = 0; i < ((System.Data.DataTable)(gridreport.DataSource)).Rows.Count; i++)
            {
                for (int j = 0; j < ((System.Data.DataTable)(gridreport.DataSource)).Rows[0].ItemArray.Length; j++)
                {
                    columnname = ((System.Data.DataTable)(gridreport.DataSource)).Columns[j].ToString().ToLower();
                    if (columnname == TotalColumn.ToLower())
                    {
                        finaltotal += Double.Parse(((System.Data.DataTable)(gridreport.DataSource)).Rows[i].ItemArray[j].ToString());
                        ViewState["granttotal"] = total;
                        rowcnt = rowcnt + 1;
                        break;
                    }
                }
            }
            //int rowcnt = gridreport.Rows

            //}



            double avg = finaltotal / rowcnt;
            string footer = "Total " + TotalColumn.ToLower() + ": " + total.ToString() + "<br/>" + " Average " + TotalColumn.ToLower() + ": " + avg.ToString() + "<br/>" + "Grand Total " + TotalColumn.ToLower() + ": " + finaltotal.ToString();
            lblFooter.Text = footer;
            //lblFooter.Text = "Total " + TotalColumn.ToLower() + ": " + total.ToString();
            ////finaltotal += ViewState["grandtotal"]
            //lblaverage.Text = "Average " + avg.ToString();
            //lbltotal.Text = " Total " + finaltotal.ToString(); 

        }
        catch (Exception ex)
        {
            WebMsg.Show("Error in set total" + ex.Message.ToString());

        }


    }
    #endregion

    #region "Grid Report Events"



    /// <summary>
    /// set the row background color on mouse hover of grid report and change the cursor type
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridreport, "Select$" + e.Row.RowIndex);
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA';this.style.cursor = 'pointer';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");


                //gridreport.HeaderRow.Cells[0].Text = xmllanguage.Tables["Gujarati"].Rows[0]["Transatrion Date"].ToString();

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {


                xmllanguage = new DataSet();
                xmllanguage.ReadXml(ViewState["XMLReportFile"].ToString());
                GridViewRow gvr = e.Row;

                if (gvr.RowType == DataControlRowType.Header)
                {
                    Image img = new Image();
                    img.ImageUrl = "/Images/a1.png";

                    //DataTable dt = (DataTable)gridreport.DataSource;
                    DataTable dt = (DataTable)Session["dtsearch"];

                    int intCounter = 0;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        string colName = dc.ColumnName.ToString();
                        try
                        {
                            ((LinkButton)gvr.Cells[intCounter].Controls[0]).Text = xmllanguage.Tables[language.ToLower()].Rows[0][(colName.Replace("_", " ")).Replace(" ", "")].ToString();
                            //((LinkButton)gvr.Cells[intCounter].Controls[0]).Text = xmllanguage.Tables[language.ToLower()].Rows[0][colName.Replace("_", " ")].ToString();
                        }
                        catch (Exception)
                        {
                            ((LinkButton)gvr.Cells[intCounter].Controls[0]).Text = colName.Replace("_", " ");
                        }
                        intCounter += 1;


                    }
                    int i = 0;
                    foreach (DataColumn dc in dt.Columns)
                    {

                        foreach (string s in HiddenFields)
                        {
                            string HeaderText = dc.ColumnName.ToLower();
                            if (HeaderText.ToLower() == s.ToLower())
                            {

                                gvr.Cells[i].Visible = false;
                                //gridreport.Rows[0].Cells[HeaderText].Visible = false;
                                //(((System.Web.UI.WebControls.DataControlFieldCell)(gridreport.Rows[j].Cells[i])).ContainingField).Visible = false;
                                break;
                            }
                        }
                        i = i + 1;
                    }
                }
                //Image img = new Image();
                //img.ImageUrl = "~/Images/down-arrow-1.png";
                //gridreport.HeaderRow.Cells[0].Controls.Add(new LiteralControl(" "));
                //gridreport.HeaderRow.Cells[0].Controls.Add(img);
            }

        }
        catch (Exception ex)
        {

        }

        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    if (language.ToLower() == "gujarati")
        //    {
        //            for (int i = 0; i < e.Row.Cells.Count; i++)
        //            {
        //                e.Row.Cells[0].Text = xmllanguage.Tables["Gujarati"].Rows[0]["GUJTrasactionDate"].ToString();
        //                //gridreport.HeaderRow.Cells[0].Text = xmllanguage.Tables["Gujarati"].Rows[0]["GUJTrasactionDate"].ToString();
        //                //gridreport.HeaderRow.Cells[1].Text = xmllanguage.Tables["Gujarati"].Rows[0]["GUJLocation"].ToString();

        //            }
        //    }


        //}
    }


    /// <summary>
    /// On grid report row select fetch the row data and fill hastable to use it.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 

    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {

        foreach (GridViewRow row in gridreport.Rows)
        {
            if (row.RowIndex == gridreport.SelectedIndex)
            {
                for (int i = 0; i < gridreport.Rows[gridreport.SelectedIndex].Cells.Count; i++)
                {

                    hashtable.Add(((System.Web.UI.WebControls.DataControlFieldCell)(gridreport.Rows[gridreport.SelectedIndex].Cells[i])).ContainingField.HeaderText.Replace("\r\n", ""), gridreport.Rows[gridreport.SelectedIndex].Cells[i].Text);

                }

                break;
            }
            else
            {

            }
        }
        this.Page.GetType().InvokeMember("Displayselecteddata", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { hashtable, this });
    }



    /// <summary>
    /// paging in gridreport
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void gridreport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gridreport.PageIndex = e.NewPageIndex;
            DataTable dt = (DataTable)(Session["dtsearch"]);

            if (searchstatus.ToString() == "0")
            {
                Search();
            }

            else
            {
                Search(dt);
            }

        }
        catch (Exception ex)
        {
            WebMsg.Show("error in page index changing" + ex.Message.ToString());
        }
        finally
        {
        }
    }


    //protected void btnsubmit_Click(object sender, EventArgs e)
    //{
    //    gridreport.Visible = false;
    //}
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    gridreport.Visible = true;

    //}

    /// <summary>
    /// This event short report data in ascending or decending as per requirement
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gridreport_Sorting(object sender, GridViewSortEventArgs e)
    {

        //try
        //{
        //    DataTable dt = (DataTable)Session["dtsearch"];

        //    sortingcolumn = e.SortExpression;
        //    Search(dt);

        //    Image sortImage = new Image();
        //    int columnIndex = 0;
        //    if (dir.ToString().ToLower() == "ascending")
        //    {
        //        sortImage.ImageUrl = "~/Images/sort_down_green.png";
        //    }
        //    else
        //    {
        //        sortImage.ImageUrl = "~/Images/sort_up_green.png";
        //    }
        //    foreach (DataControlFieldHeaderCell headerCell in gridreport.HeaderRow.Cells)
        //    {
        //        if (headerCell.ContainingField.SortExpression == e.SortExpression)
        //        {
        //            columnIndex = gridreport.HeaderRow.Cells.GetCellIndex(headerCell);
        //        }
        //    }
        //    gridreport.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);


        //}
        //catch (Exception ex)
        //{
        //    WebMsg.Show("error in sorting" + ex.Message.ToString());

        //}


    }
    #endregion

    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    /* Verifies that the control is rendered */
    //}

    protected void UploadDataTableToExcel(DataTable dtEmp, string filename)
    {
        try
        {
            if (dtEmp.Rows.Count > 0)
            {
                string attachment = "attachment; filename=" + filename;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";
                string path = XMLReportFile;
                DataSet dt = new DataSet("rootStateIndividual");
                dt.ReadXml(path);
                DataTable dt1 = dt.Tables["Exporttoexcelsettings"];
                string tab = string.Empty;
                foreach (DataColumn dtcol in dtEmp.Columns)
                {
                    string column = dtcol.ColumnName.ToString().Replace(" ", "");
                    DataTable dt2 = dt1.DefaultView.ToTable(true, column);
                    if (dt2.Rows[0][0].ToString().ToLower() == "true")
                    {
                        if (dtcol.ColumnName.ToString().ToLower() == "perc")
                        {
                            Response.Write(tab + "Percentage");
                            tab = "\t";
                        }
                        else if (dtcol.ColumnName.ToString().ToLower() == "firstname")
                        {
                            Response.Write(tab + "Name");
                            tab = "\t";
                        }

                        else
                        {
                            Response.Write(tab + dtcol.ColumnName);
                            tab = "\t";
                        }

                    }
                }
                Response.Write("\n");
                int cnt = 0;
                foreach (DataRow dr in dtEmp.Rows)
                {
                    tab = "";
                    foreach (DataColumn dtcol in dtEmp.Columns)
                    {


                        string column = dtcol.ColumnName.ToString().Replace(" ", "");
                        DataTable dt2 = dt1.DefaultView.ToTable(true, column);
                        if (dt2.Rows[0][0].ToString().ToLower() == "true")
                        {
                            Response.Write(tab + Convert.ToString(dr[cnt]));
                            tab = "\t";
                        }
                        cnt = cnt + 1;
                    }
                    Response.Write("\n");
                    cnt = 0;
                }
                Response.End();
            }
        }
        catch (Exception ex)
        {
        }


    }

    private void ExporttoExcel(DataTable table)
    {
        try
        {


            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            //HttpContext.Current.Response.ContentType = "application/ms-word";
            HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");

            // HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.doc");
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
            HttpContext.Current.Response.Write("<font style='font-size:11.0pt; font-family:Calibri;'>");
            HttpContext.Current.Response.Write("<BR><BR><BR>");
            HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:11.0pt; font-family:Calibri; background:white;'> ");


            string path = XMLReportFile;
            DataSet dt = new DataSet("rootStateIndividual");
            dt.ReadXml(path);
            DataTable dt1 = dt.Tables["Exporttoexcelsettings"];
            string tab = string.Empty;
            string filename = dt1.Rows[0][0].ToString().Replace(" ", "") + ".xls";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            HttpContext.Current.Response.Write("<TR >");
            HttpContext.Current.Response.Write("<Td  style=\"background-color:#000000;color:#ffffff;\"  colspan=\"3\">");
            HttpContext.Current.Response.Write("<font style='font-size:14.0pt; font-family:Calibri; color: white'>");
            HttpContext.Current.Response.Write("<B>");
            HttpContext.Current.Response.Write(dt1.Rows[0][0].ToString());
            HttpContext.Current.Response.Write("</B>");
            HttpContext.Current.Response.Write("</Td>");
            HttpContext.Current.Response.Write("</TR>");
            HttpContext.Current.Response.Write("<TR >");
            int columnscount = table.Columns.Count;

            for (int j = 0; j < columnscount; j++)
            {

                string column = table.Columns[j].ColumnName.ToString().Replace(" ", "");
                DataTable dt2 = dt1.DefaultView.ToTable(true, column);

                if (dt2.Rows[0][0].ToString().ToLower() == "true")
                {
                    HttpContext.Current.Response.Write("<Td style=\"background-color:#BDB76B;color:#000000;\" >");
                    HttpContext.Current.Response.Write("<B>");
                    if (table.Columns[j].ColumnName.ToString().ToLower() == "perc")
                    {
                        HttpContext.Current.Response.Write("Percentage");
                    }
                    else if (table.Columns[j].ColumnName.ToString().ToLower() == "firstname")
                    {
                        HttpContext.Current.Response.Write("Name");
                    }
                    else
                    {
                        HttpContext.Current.Response.Write(table.Columns[j].ColumnName.ToString());
                    }


                    HttpContext.Current.Response.Write("</B>");
                    HttpContext.Current.Response.Write("</Td>");
                }

            }
            HttpContext.Current.Response.Write("</TR>");
            foreach (DataRow row in table.Rows)
            {
                HttpContext.Current.Response.Write("<TR>");

                for (int i = 0; i < table.Columns.Count; i++)
                {
                    string column = table.Columns[i].ColumnName.ToString().Replace(" ", "");
                    DataTable dt2 = dt1.DefaultView.ToTable(true, column);
                    if (dt2.Rows[0][0].ToString().ToLower() == "true")
                    {
                        HttpContext.Current.Response.Write("<Td>");
                        HttpContext.Current.Response.Write(row[i].ToString());
                        HttpContext.Current.Response.Write("</Td>");

                    }

                }

                HttpContext.Current.Response.Write("</TR>");
            }
            HttpContext.Current.Response.Write("</Table>");
            HttpContext.Current.Response.Write("</font>");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
        catch (Exception)
        {

        }
    }
    protected void btnexporttoexcel_Click(object sender, EventArgs e)
    {

        ExporttoExcel((DataTable)Session["dtsearch"]);


    }

    public void exporttoexcel()
    {

        try
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gridreport.AllowPaging = false;


            //To Export all pages
            gridreport.AllowPaging = false;
            DataTable dt = (DataTable)(Session["dtsearch"]);
            gridreport.DataSource = dt;

            gridreport.DataBind();


            //Change the Header Row back to white color
            gridreport.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells
            for (int i = 0; i < gridreport.HeaderRow.Cells.Count; i++)
            {
                gridreport.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
            }
            gridreport.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
        }

    }

}








