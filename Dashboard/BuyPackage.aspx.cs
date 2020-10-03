using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Net;
using System.Web.Script.Serialization;

public partial class Dashboard_BuyPackage : System.Web.UI.Page
{

    #region Declaration
    Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
    StudentDash obj_Student_Dashboard;
    #endregion

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetStudentpackagedetails();
            FillAllNotPurchasedPackageList();
            lblusername.Text = "Dear " + AppSessions.UserName + ",";
            lblmessage.Text = "Please subscribe following package to access all available educational resources.";
            //CheckForPackageOffer();
        }

    }
    #endregion

    #region Methods

    //protected void CheckForPackageOffer()
    //{
    //    bool IsAllowPackgeOffer = false;
    //    try
    //    {
    //        DataSet dsSettings = new DataSet();
    //        Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
    //        dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("IsAllowPackgeOffer");
    //        IsAllowPackgeOffer = Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["value"].ToString());
    //        AppSessions.IsAllowPackgeOffer = IsAllowPackgeOffer;
    //    }
    //    catch (Exception)
    //    {
    //    }


    //}

    protected void GetStudentpackagedetails()
    {
        try
        {
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            obj_Student_Dashboard = new StudentDash();
            obj_Student_Dashboard.StudentID = AppSessions.StudentID;
            DataSet ds = new DataSet();
            ds = obj_BAL_Student_Dashboard.BAL_Student_ExpiryNotification1(obj_Student_Dashboard);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["Price"].ToString() != "0")
                {
                    decimal cntnoofdays = Convert.ToDecimal((Convert.ToInt32(ds.Tables[0].Rows[i]["NoOfMonth"].ToString())) / 30);
                    int cntnoofmonth = Convert.ToInt32(Math.Round(cntnoofdays));
                    DateTime dtFromDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["FromDate"].ToString());
                    DateTime dtvalidtill = dtFromDate.AddMonths(cntnoofmonth).AddDays(-1);
                    ds.Tables[0].Rows[i]["NoOfMonth"] = cntnoofmonth.ToString();
                    ds.Tables[0].Rows[i]["ValidTill"] = dtvalidtill.ToString();
                }
            }
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {

                gvpurchasedpackages.Visible = true;
                gvpurchasedpackages.DataSource = ds.Tables[0];
                gvpurchasedpackages.DataBind();
            }
            gvpurchasedpackages.DataSource = ds.Tables[0];
            gvpurchasedpackages.DataBind();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void FillAllNotPurchasedPackageList()
    {
        try
        {
            string strcountryname = string.Empty;
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            DataSet ds = new DataSet();

            DataSet dsSettings = new DataSet();
            Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("IsMultiCurrency");
            string IsMultiCurrency = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();
            if (IsMultiCurrency.ToLower() == "yes")
            {
                strcountryname = GetCountryName();
                ds = obj_BAL_Student_Dashboard.BAL_Student_ALL_Not_Purchased_Package(AppSessions.BMSID, AppSessions.StudentID, Session["CurrencyType"].ToString());
            }
            else
            {
                strcountryname = "India";
                Session["CurrencyType"] = "INR";
                Session["country_name"] = "India";
                ds = obj_BAL_Student_Dashboard.BAL_Student_ALL_Not_Purchased_Package(AppSessions.BMSID, AppSessions.StudentID, Session["CurrencyType"].ToString());
            }
            
            //if (strcountryname.ToString().Trim().ToLower() == "india")
            //{
            
            //}
            //else if (strcountryname.ToString().Trim().ToLower() == "united states")
            //{
            //ds = obj_BAL_Student_Dashboard.BAL_Student_ALL_Not_Purchased_Package(AppSessions.BMSID, AppSessions.StudentID, "USD");
            //}
            bool IsPackageOffer = false;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns.Add("ValidTill", typeof(string));

                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["OfferEndDate"]) > DateTime.Now)
                    {
                        IsPackageOffer = true;
                        break;
                    }
                    {
                        IsPackageOffer = false;
                    }
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["OfferEndDate"]) > DateTime.Now)
                    {
                        decimal cntnoofdays = Convert.ToDecimal((Convert.ToInt32(ds.Tables[0].Rows[i]["NoOfMonth"].ToString())) / 30);
                        int cntnoofmonth = Convert.ToInt32(Math.Round(cntnoofdays));
                        DateTime dtFromDate = Convert.ToDateTime(DateTime.Today);
                        DateTime dtvalidtill = dtFromDate.AddMonths(cntnoofmonth);
                        dtvalidtill = dtvalidtill.AddDays(-1);

                        //ds.Tables[0].Rows[i]["ValidTill"] = dtvalidtill.ToString("dd-MMM-yyyy");

                        if (Convert.ToInt32(ds.Tables[0].Rows[i]["OfferDays"].ToString()) <= 29)
                        {
                            dtvalidtill = dtvalidtill.AddDays(Convert.ToInt32(ds.Tables[0].Rows[i]["OfferDays"].ToString()));
                            ds.Tables[0].Rows[i]["ValidTill"] = dtvalidtill.ToString("dd-MMM-yyyy");
                        }
                        else
                        {
                            decimal cntnoofofferdays = Convert.ToDecimal((Convert.ToInt32(ds.Tables[0].Rows[i]["OfferDays"].ToString())) / 30);
                            int cntnoofoffermonth = Convert.ToInt32(Math.Round(cntnoofofferdays));
                            ds.Tables[0].Rows[i]["ValidTill"] = dtvalidtill.AddMonths(cntnoofoffermonth).ToString("dd-MMM-yyyy");
                        }
                        ds.Tables[0].Rows[i]["NoOfMonth"] = cntnoofmonth.ToString();

                    }
                    else
                    {
                        decimal cntnoofdays = Convert.ToDecimal((Convert.ToInt32(ds.Tables[0].Rows[i]["NoOfMonth"].ToString())) / 30);
                        int cntnoofmonth = Convert.ToInt32(Math.Round(cntnoofdays));
                        DateTime dtFromDate = Convert.ToDateTime(DateTime.Today);
                        DateTime dtvalidtill = dtFromDate.AddMonths(cntnoofmonth);
                        dtvalidtill = dtvalidtill.AddDays(-1);
                        ds.Tables[0].Rows[i]["NoOfMonth"] = cntnoofmonth.ToString();
                        ds.Tables[0].Rows[i]["ValidTill"] = dtvalidtill.ToString("dd-MMM-yyyy");
                        ds.Tables[0].Rows[i]["OfferName"] = "N/A";
                    }
                }
                
            }
            if (ds.Tables.Count > 0 && ds != null)
            {
                if (IsPackageOffer)
                {

                    gvallpackage.DataSource = ds.Tables[0];
                    gvallpackage.DataBind();
                }
                else
                {
                    gvallpackage.DataSource = ds.Tables[0];
                    gvallpackage.DataBind();
                    gvallpackage.Columns[3].Visible = false;
                }
            }
            //if (IsForAllPackage)
            //{
            //    if (ds.Tables[0].Rows.Count > 0 && ds != null)
            //    {
            //        gvOffer.DataSource = ds.Tables[0];
            //        gvOffer.DataBind();
            //    }
            //    else
            //    {
            //        gvOffer.DataSource = ds.Tables[0];
            //        gvOffer.DataBind();
            //    }
            //}
            //else
            //{
            //    if (ds.Tables[0].Rows.Count > 0 && ds != null)
            //    {
            //        gvallpackage.DataSource = ds.Tables[0];
            //        gvallpackage.DataBind();
            //    }
            //    else
            //    {
            //        gvallpackage.DataSource = ds.Tables[0];
            //        gvallpackage.DataBind();
            //    }
            //}
        }
        catch (Exception ex)
        {
            //WebMsg.Show(ex.Message);
        }
    }

    #endregion

    #region Control Events

    protected void btnbuy_Click(object sender, EventArgs e)
    {
        fieldpanel.Visible = true;
        pnlpackageactivation.Visible = true;
        rbyes.Checked = true;


        string status = "false";
        foreach (GridViewRow gv in gvpurchasedpackages.Rows)
        {
            CheckBox chksingle = (CheckBox)gv.FindControl("chkpurchasedpackages");

            if (chksingle.Checked == true)
            {
                status = "true";
                break;
            }
        }


        if (status == "true")
        {
            txtdate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            txtdate.Attributes.Add("readonly", "readonly");
            fieldpanel.Visible = true;
            rbyes.Checked = true;
        }
        else
        {
            WebMsg.Show("Please select at least one record.....");
            fieldpanel.Visible = false;
        }

    }
    protected void btnactivate_Click(object sender, EventArgs e)
    {
        try
        {
            //txtdate.Text = DateTime.Today.ToString("dd MMM,yyyy");

            string PackageName = "";
            string subjectlist = "";
            string validity = "";
            string price = "";

            DataTable dt = new DataTable();
            dt.Columns.Add("PackageID", typeof(string));
            dt.Columns.Add("PackageName", typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("NoOfMonth", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("PackageType", typeof(string));
            dt.Columns.Add("ActivateOn", typeof(string));
            dt.Columns.Add("ExpiryDate", typeof(string));

            PackageName = (gvpurchasedpackages.SelectedRow.FindControl("lblpackagename") as Label).Text;
            subjectlist = (gvpurchasedpackages.SelectedRow.FindControl("lblsubject") as Label).Text;
            validity = (gvpurchasedpackages.SelectedRow.FindControl("lblnoofmonths") as Label).Text;
            price = (gvpurchasedpackages.SelectedRow.FindControl("lblComboPrice") as Label).Text;
            string PackageID = (gvpurchasedpackages.SelectedRow.FindControl("lblID") as Label).Text;

            DataRow dtrow = dt.NewRow();
            dtrow["PackageID"] = PackageID;
            dtrow["PackageName"] = PackageName;
            dtrow["Subject"] = subjectlist;
            dtrow["NoOfMonth"] = validity;
            dtrow["Price"] = price;
            dtrow["PackageType"] = "single";
            DateTime dateTime2;
            if (DateTime.TryParse(txtdate.Text, out dateTime2))
            {
                dtrow["ActivateOn"] = dateTime2;
            }
            else
            {
                dtrow["ActivateOn"] = DateTime.Today.ToString("dd/MMM/yyyy");
            }

            DateTime now = dateTime2;
            now = now.AddMonths(Convert.ToInt32(validity));
            if (Session["OfferPackageDays"] != null)
            {
                now = now.AddDays(Convert.ToInt32(Session["OfferPackageDays"]));
            }
            now = now.AddDays(-1);
            //now = now.Date.ToString("dd/MMM/yyyy");
            dtrow["ExpiryDate"] = now.Date.ToString("dd/MMM/yyyy");

            dt.Rows.Add(dtrow);
            Session["SelectedPackage"] = dt;
            //Response.Redirect("PackageConfirmation.aspx?PageIndex=1");
            Response.Redirect("PackagePaymentNew.aspx?PageIndex=1");

        }
        catch (Exception ex)
        {
        }


    }


    protected void RenewPackage()
    {
        try
        {
            string PackageID = (gvpurchasedpackages.SelectedRow.FindControl("lblID") as Label).Text;

            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            DataSet ds = new DataSet();

            //ds = obj_BAL_Student_Dashboard.BAL_Student_SelectNotAvailablePackage(Convert.ToInt32(AppSessions.BMSID), Convert.ToInt32(dt.Rows[i]["PackageID"].ToString()));
            //ds = obj_BAL_Student_Dashboard.BAL_Student_SelectNotAvailablePackage(Convert.ToInt32(AppSessions.BMSID), Convert.ToInt32(PackageID));
            ds = obj_BAL_Student_Dashboard.BAL_Student_CheckForPackageAvailablity(PackageID);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblnotavailablepackage.Text = "";
                    if (ds.Tables[0].Rows[0]["Price"].ToString() == "0")
                    {
                        lblnotavailablepackage.Text += ds.Tables[0].Rows[0]["PackageName"].ToString() + " Package is for demo only, you can not buy it." + "<br />";
                        lblnotavailablepackage.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                    {
                        lblnotavailablepackage.Text += ds.Tables[0].Rows[0]["PackageName"].ToString() + " Package is not available for renew." + "<br />";
                        lblnotavailablepackage.Visible = true;
                    }

                }
                else
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        if (Convert.ToDateTime(ds.Tables[1].Rows[0]["OfferEndDate"]) > DateTime.Now)
                        {
                            lblofferdetails.Text = "Congratulations! You will get Vacation offer(  " + ds.Tables[1].Rows[0]["OfferName"].ToString() + ") on renewal of this package";
                            lblofferdetails.ForeColor = System.Drawing.Color.Yellow;
                            lblofferdetails.Attributes.Add("font-size", "20px;");
                            Session["OfferPackageDays"] = ds.Tables[1].Rows[0]["OfferDays"].ToString();

                        }
                    }

                    fieldpanel.Visible = true;
                    pnlpackageactivation.Visible = true;
                    rbyes.Checked = true;
                    txtdate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                    txtdate.Attributes.Add("readonly", "readonly");
                    fieldpanel.Visible = true;
                    rbyes.Checked = true;
                }

            }


        }
        catch (Exception ex)
        {
        }
    }
    protected void rbno_CheckedChanged(object sender, EventArgs e)
    {
        if (rbno.Checked)
        {
            txtdate.Enabled = true;
            ibtnDate.Enabled = true;
        }

    }
    protected void rbyes_CheckedChanged(object sender, EventArgs e)
    {
        if (rbyes.Checked)
        {

            txtdate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            txtdate.Enabled = false;
            ibtnDate.Enabled = false;
        }

    }
    #endregion
    protected void btnreset_Click(object sender, EventArgs e)
    {

        fieldpanel.Visible = false;
        pnlpackageactivation.Visible = false;
        txtdate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
        txtdate.Enabled = false;
        ibtnDate.Enabled = false;
        rbyes.Checked = true;
        rbno.Checked = false;


    }
    protected void btnpurchasedpackage_Click(object sender, EventArgs e)
    {
        string PackageName = "";
        string subjectlist = "";
        string validity = "";
        string price = "";
        bool ischecked = false;

        DataTable dt = new DataTable();
        dt.Columns.Add("PackageID", typeof(string));
        dt.Columns.Add("PackageName", typeof(string));
        dt.Columns.Add("Subject", typeof(string));
        dt.Columns.Add("NoOfMonth", typeof(string));
        dt.Columns.Add("Price", typeof(string));
        dt.Columns.Add("PackageType", typeof(string));
        dt.Columns.Add("ActivateOn", typeof(string));

        dt.Columns.Add("ExpiryDate", typeof(string));

        int rowcount = 0;


        foreach (GridViewRow dl in gvallpackage.Rows)
        {
            CheckBox chkCombo = (CheckBox)dl.FindControl("chkAllPackage");
            //RadioButton chkCombo = (RadioButton)dl.FindControl("rdbUser");
            DateTime now = DateTime.Now;
            if (chkCombo.Checked == true)
            {
                Label lblpackagename = (Label)dl.FindControl("lblpackagename");
                Label lblsubject = (Label)dl.FindControl("lblsubject");
                Label lblnoofmonths = (Label)dl.FindControl("lblnoofmonths");
                Label lblprice = (Label)dl.FindControl("lblComboPrice");
                PackageName = lblpackagename.Text;
                subjectlist = lblsubject.Text;
                validity = lblnoofmonths.Text;
                price = lblprice.Text;

                DataRow dtrow = dt.NewRow();    // Create New Row
                dtrow["PackageID"] = gvallpackage.DataKeys[rowcount].Value.ToString();
                dtrow["PackageName"] = PackageName;            //Bind Data to Columns
                dtrow["Subject"] = subjectlist;
                dtrow["NoOfMonth"] = validity;
                dtrow["Price"] = price;

                dtrow["PackageType"] = "combo";

                dtrow["ActivateOn"] = DateTime.Today.ToString("dd/MMM/yyyy");
                //now = now.AddMonths(Convert.ToInt32(validity));
                now = now.AddDays(Convert.ToInt32(validity));
                now = now.AddDays(-1);
                //now = now.Date.ToString("dd/MMM/yyyy");
                dtrow["ExpiryDate"] = now.Date.ToString("dd/MMM/yyyy");
                dt.Rows.Add(dtrow);
                ischecked = true;
                //break;
            }
            rowcount = rowcount + 1;
        }
        Session["SelectedPackage"] = dt;
        if (ischecked)
        {
            //Response.Redirect("PackageConfirmation.aspx?PageIndex=1");
            Response.Redirect("PackagePaymentNew.aspx?PageIndex=1");
        }
        else
        {
            WebMsg.Show("Please select at least one package.");
        }
    }
    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string PackageName = "";
            string subjectlist = "";
            string validity = "";
            string price = "";
            DataTable dt = new DataTable();
            DateTime now = DateTime.Now;

            dt.Columns.Add("PackageID", typeof(string));
            dt.Columns.Add("PackageName", typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("NoOfMonth", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("PackageType", typeof(string));
            dt.Columns.Add("ActivateOn", typeof(string));
            dt.Columns.Add("ExpiryDate", typeof(string));
            dt.Columns.Add("Currency", typeof(string));

            PackageName = (gvallpackage.SelectedRow.FindControl("lblpackagename") as Label).Text;
            subjectlist = (gvallpackage.SelectedRow.FindControl("lblsubject") as Label).Text;
            validity = (gvallpackage.SelectedRow.FindControl("lblnoofmonths") as Label).Text;
            price = (gvallpackage.SelectedRow.FindControl("lblComboPrice") as Label).Text;
            string lblexpireon = (gvallpackage.SelectedRow.FindControl("lblexpireon") as Label).Text;
            string PackageID = (gvallpackage.SelectedRow.FindControl("lblID") as Label).Text;
            string Currency = (gvallpackage.SelectedRow.FindControl("lblCurrency") as Label).Text;

            DataRow dtrow = dt.NewRow();
            dtrow["PackageID"] = PackageID;
            dtrow["PackageName"] = PackageName;
            dtrow["Subject"] = subjectlist;
            dtrow["NoOfMonth"] = validity;
            dtrow["Price"] = price;
            dtrow["Currency"] = Currency;
            dtrow["PackageType"] = "single";
            dtrow["ActivateOn"] = DateTime.Today.ToString("dd/MMM/yyyy");

            //now = DateTime.Now.AddDays(Convert.ToInt32(validity));
            //int cntvalidtill = Convert.ToInt32(validity) * 30;
            now = DateTime.Now.AddMonths(Convert.ToInt32(validity));
            now = now.Date;
            now = now.AddDays(-1);
            //dtrow["ExpiryDate"] = now.ToString("dd/MMM/yyyy");
            dtrow["ExpiryDate"] = lblexpireon;
            dtrow["Currency"] = Currency;
            dt.Rows.Add(dtrow);
            Session["SelectedPackage"] = dt;
            Session["RedirectPageName"] = "buypackage";
            //Response.Redirect("PackageConfirmation.aspx?PageIndex=1");
            //if (Session["country_name"].ToString().ToLower() == "india")
            //{
            Response.Redirect("PackagePaymentNew.aspx?PageIndex=1");
        }
        catch (Exception)
        {

        }
        //}
    }
    protected void gvallpackage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //if (Session["country_name"] != null && Session["country_name"].ToString().ToLower() == "united states")
            e.Row.Cells[5].Text = "Price" + " (" + Session["CurrencyType"] + ")";

            //else if (Session["country_name"] != null && Session["country_name"].ToString().ToLower() == "india")
            //e.Row.Cells[5].Text = "Price" + " (INR)";

        }


        if (e.Row.RowType == DataControlRowType.DataRow)
            ((Label)e.Row.FindControl("lblComboPrice")).Text = Convert.ToDecimal(((DataRowView)e.Row.DataItem)["Price"]).ToString("F");

    }
    protected void gvpurchasedpackages_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((Label)e.Row.FindControl("lblComboPrice")).Text = Convert.ToDecimal(((DataRowView)e.Row.DataItem)["Price"]).ToString("F");
            ((Label)e.Row.FindControl("lblnoofmonths")).Text = ((DataRowView)e.Row.DataItem)["NoOfMonth"].ToString();

            ImageButton btn = e.Row.Cells[7].Controls[0] as ImageButton;

            if (((Label)e.Row.FindControl("lblComboPrice")).Text == "0.00")
            {
                btn.Visible = false;
                ((Label)e.Row.FindControl("lblnoofmonths")).Text = ((DataRowView)e.Row.DataItem)["NoOfMonth"].ToString() + " Day";

            }
            else
            {
                btn.Visible = true;
            }
        }

    }
    protected void gvpurchasedpackages_SelectedIndexChanged(object sender, EventArgs e)
    {

        //fieldpanel.Visible = true;
        //pnlpackageactivation.Visible = true;
        //rbyes.Checked = true;
        //txtdate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
        //txtdate.Attributes.Add("readonly", "readonly");
        //fieldpanel.Visible = true;
        //rbyes.Checked = true;
        Session["RedirectPageName"] = "buypackage";
        RenewPackage();
    }

    public string GetClientIPAddress()
    {
        //The X-Forwarded-For (XFF) HTTP header field is a de facto standard for identifying the originating IP address of a
        //client connecting to a web server through an HTTP proxy or load balancer
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(ip))
        {
            ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert(" + ip + ")", true);
            //ip = "117.247.91.16"; //Testing for India
            ip = "198.7.62.204"; // Testing for US
        }

        return ip;
    }

    public string GetCountryName()
    {
        Location location = new Location();
        try
        {
            string ipAddress = GetClientIPAddress();
            string url = "https://freegeoip.net/json/" + ipAddress;

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                location = new JavaScriptSerializer().Deserialize<Location>(json);
                List<Location> locations = new List<Location>();
                locations.Add(location);
            }
            Session["country_name"] = location.country_name.ToString();
            if (location.country_name.ToString().ToLower() == "india")
                Session["CurrencyType"] = "INR";
            if (location.country_name.ToString().ToLower() == "united states")
                Session["CurrencyType"] = "USD";
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert(" + ex.Message + ")", true);
        }
        return location.country_name.ToString();
    }
    public class Location
    {
        public string ip { get; set; }
        public string country_name { get; set; }
        public string region_code { get; set; }
        public string City { get; set; }
        public string region_name { get; set; }
        public string zip_code { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string time_zone { get; set; }
    }
}