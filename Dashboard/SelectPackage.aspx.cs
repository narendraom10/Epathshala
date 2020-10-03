///<Summary>
///</Summary>
using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Dashboard_SelectPackage : System.Web.UI.Page
{

    #region "Declarations"

    Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
    StudentDash obj_Student_Dashboard;
    Package_BLogic Blogic_Package;
    Package PPackage;
    #endregion

    # region Properties
    # endregion

    #region "Page events"

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }

    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    this.Page.MasterPageFile = "";
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ShowPaymentPages"] == null)
            {
                if (Session["CheckValidity"] == null)
                {
                    //btnLoginBack.Visible = true;
                    lblMsg.Text = "Dear " + AppSessions.UserName.ToString() + ",";
                    lblMsg.Visible = true;
                }
                else
                {
                    btnHomeBack.Visible = true;
                }

                lblStandard.Text = AppSessions.Standard;
                FillComboPackageList();
                BindSinglePackage();
                //BindSubjectList();
                //BindComboList();
                BindComboSubjectList();

                if (Session["GoBack"] != null)
                {
                    if (Session["Combo"] != null)
                    {
                        btnCombo_Click(null, null);
                        DataTable dtCombo = new DataTable();
                        dtCombo = (DataTable)Session["Combo"];
                        if (dtCombo.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtCombo.Rows.Count; i++)
                            {
                                for (int j = 0; j < dlCombo.Rows.Count; j++)
                                {
                                    if (dtCombo.Rows[i]["Name"].ToString() == ((Label)dlCombo.Rows[j].FindControl("lblPackageType")).Text)
                                    {
                                        //CheckBox chk = dlCombo.Rows[j].Cells[0].FindControl("chkPackage") as CheckBox;
                                        RadioButton chk = dlCombo.Rows[j].Cells[0].FindControl("rdbUser") as RadioButton;
                                        chk.Checked = true;
                                    }
                                }
                            }
                        }
                    }

                    if (Session["Single"] != null)
                    {
                        btnSingle_Click(null, null);
                        DataTable dtSingle = new DataTable();
                        dtSingle = (DataTable)Session["Single"];
                        if (dtSingle.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtSingle.Rows.Count; i++)
                            {
                                for (int j = 0; j < gvSubjects.Rows.Count; j++)
                                {
                                    if (dtSingle.Rows[i]["ID"].ToString() == ((RadioButton)gvSubjects.Rows[j].FindControl("rdbSilver")).Text)
                                    {
                                        RadioButton rbSilver = gvSubjects.Rows[j].FindControl("rdbSilver") as RadioButton;
                                        rbSilver.Checked = true;
                                    }

                                    if (dtSingle.Rows[i]["ID"].ToString() == ((RadioButton)gvSubjects.Rows[j].FindControl("rdbGold")).Text)
                                    {
                                        RadioButton rbGold = gvSubjects.Rows[j].FindControl("rdbGold") as RadioButton;
                                        rbGold.Checked = true;
                                    }

                                    if (dtSingle.Rows[i]["ID"].ToString() == ((RadioButton)gvSubjects.Rows[j].FindControl("rdbPlatinum")).Text)
                                    {
                                        RadioButton rbPlatinum = gvSubjects.Rows[j].FindControl("rdbPlatinum") as RadioButton;
                                        rbPlatinum.Checked = true;
                                    }
                                }

                            }
                        }
                    }
                }
            }
            else
            {
                WebMsg.Show("The service is not available.");
                Response.Redirect("~/Dashboard/StudentDashboard.aspx", true);
            }
        }
    }

    #endregion

    #region "Control Events"

    protected void btnCombo_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["HaveCombo"] != null)
            {
                pnlCombo.Visible = true;
            }
            else
            {
                WebMsg.Show("The Combo is not available.");
            }
            pnlSingle.Visible = false;
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void btnSingle_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["HaveSubject"] != null)
            {
                pnlSingle.Visible = true;
            }
            else
            {
                WebMsg.Show("The Package is not available.");
            }

            pnlCombo.Visible = false;

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void btnComboSubmit_Click(object sender, EventArgs e)
    {
        try
        {



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

            int rowcount = 0;


            foreach (GridViewRow dl in dlCombo.Rows)
            {
                CheckBox chkCombo = (CheckBox)dl.FindControl("chkComboPackage");
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
                    dtrow["PackageID"] = dlCombo.DataKeys[rowcount].Value.ToString();
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


                    //break;

                }

                rowcount = rowcount + 1;
            }
            Session["SelectedPackage"] = dt;
            if (dt.Rows.Count > 0)
                //Response.Redirect("PackageConfirmation.aspx?PageIndex=0");
                Response.Redirect("PackagePaymentNew.aspx?PageIndex=0");
            else
                WebMsg.Show("Please select atleast one package.");
            //Response.Redirect("PackageConfirmation.aspx?PackageName=" + PackageName + "&SubjectList=" + subjectlist + "&Validity= " + validity + "&Price=" + price + "&PackageType=Single");
            //Blogic_Package = new Package_BLogic();
            //PPackage = new Package();
            //DataTable dt = new DataTable();

            //try
            //{
            //    dt = GenerateComboDataTable();
            //    if (dt.Rows.Count == 1)
            //    {
            //        Session["Combo"] = dt;
            //        Session["Single"] = null;
            //        Response.Redirect("ConfirmPackage.aspx");
            //    }
            //    else
            //    {
            //        WebMsg.Show("Please select atleast one package.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    WebMsg.Show(ex.Message);
            //}
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
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

        DateTime now = DateTime.Now;
        int rowcount = 0;
        foreach (GridViewRow dl in gvSubjects.Rows)
        {
            //CheckBox chkCombo = (CheckBox)dl.FindControl("chkPackage");
            CheckBox chksingle = (CheckBox)dl.FindControl("chksinglepackage");

            if (chksingle.Checked == true)
            {
                Label lblpackagename = (Label)dl.FindControl("lblpackagename");
                Label lblsubject = (Label)dl.FindControl("lblsubject");
                Label lblnoofmonths = (Label)dl.FindControl("lblnoofmonths");
                Label lblprice = (Label)dl.FindControl("lblprice");
                PackageName = lblpackagename.Text;
                subjectlist = lblsubject.Text;
                validity = lblnoofmonths.Text;
                price = lblprice.Text;

                DataRow dtrow = dt.NewRow();    // Create New Row
                dtrow["PackageID"] = gvSubjects.DataKeys[rowcount].Value.ToString();

                dtrow["PackageName"] = PackageName;            //Bind Data to Columns
                dtrow["Subject"] = subjectlist;
                dtrow["NoOfMonth"] = validity;
                dtrow["Price"] = price;
                dtrow["PackageType"] = "single";
                dtrow["ActivateOn"] = DateTime.Today.ToString("dd/MMM/yyyy");
                //now = now.AddMonths(Convert.ToInt32(validity));
                now = now.AddDays(Convert.ToInt32(validity));
                now = now.Date;
                now = now.AddDays(-1);
                dtrow["ExpiryDate"] = now.ToString();
                dt.Rows.Add(dtrow);

            }
            rowcount = rowcount + 1;

        }
        Session["SelectedPackage"] = dt;

        //Response.Redirect("PackageConfirmation.aspx?PageIndex=0");
        Response.Redirect("PackagePaymentNew.aspx?PageIndex=0");
        //Response.Redirect("PackageConfirmation.aspx?PackageName=" + PackageName + "&SubjectList=" + subjectlist + "&Validity= " + validity + "&Price=" + price + "&PackageType=Single");
        //Blogic_Package = new Package_BLogic();
        //PPackage = new Package();
        //DataTable dt = new DataTable();

        //try
        //{
        //    dt = GenerateSubjectDataTable();
        //    if (dt.Rows.Count > 0)
        //    {
        //        if (Check())
        //        {
        //            Session["Single"] = dt;
        //            Session["Combo"] = null;
        //            Response.Redirect("ConfirmPackage.aspx");
        //        }
        //    }
        //    else
        //    {
        //        WebMsg.Show("Please select atleast one subject.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    WebMsg.Show(ex.Message);
        //}
    }



    protected void btnHomeBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentDashboard.aspx");
    }

    protected void btnLoginBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }

    #endregion

    #region "User Defined Functions"


    protected void FillComboPackageList()
    {
        try
        {
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            DataSet ds = new DataSet();
            ds = obj_BAL_Student_Dashboard.BAL_Student_Package("Combo", AppSessions.BMSID);
            ds.Tables[0].Columns.Add("ValidTill", typeof(string));


            bool IsPackageOffer = false;
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



            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                
                dlCombo.DataSource = ds.Tables[0];
                dlCombo.DataBind();
                if (IsPackageOffer)
                {
                    ViewState["HaveCombo"] = "Yes";
                   
                }
                else
                {
                    dlCombo.Columns[3].Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void BindComboList()
    {
        try
        {
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            obj_Student_Dashboard = new StudentDash();
            DataSet ds = new DataSet();
            obj_Student_Dashboard.BMSID = AppSessions.BMSID;
            obj_Student_Dashboard.Mode = "Combo";
            ds = obj_BAL_Student_Dashboard.BAL_Student_Subject_Select(obj_Student_Dashboard);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                ViewState["HaveCombo"] = "Yes";
                dlCombo.DataSource = ds.Tables[0];
                dlCombo.DataBind();
                //AppSessions.SubjectID = Convert.ToInt16(rbSubjectList.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void BindComboSubjectList()
    {
        try
        {
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            obj_Student_Dashboard = new StudentDash();
            obj_Student_Dashboard.BMSID = AppSessions.BMSID;
            obj_Student_Dashboard.Mode = "All";
            DataSet ds = new DataSet();
            ds = obj_BAL_Student_Dashboard.BAL_Student_Subject_Select(obj_Student_Dashboard);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                string Subject = string.Empty;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Subject == string.Empty)
                    {
                        Subject = Subject + ds.Tables[0].Rows[i]["Subject"].ToString();
                    }
                    else
                    {
                        Subject = Subject + "," + ds.Tables[0].Rows[i]["Subject"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void BindSinglePackage()
    {
        try
        {
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            DataSet ds = new DataSet();
            ds = obj_BAL_Student_Dashboard.BAL_Student_Package("Single", AppSessions.BMSID);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                ViewState["HaveSubject"] = "Yes";
                gvSubjects.DataSource = ds.Tables[0];
                gvSubjects.DataBind();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void BindSubjectList()
    {
        try
        {
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            obj_Student_Dashboard = new StudentDash();
            obj_Student_Dashboard.BMSID = AppSessions.BMSID;
            obj_Student_Dashboard.Mode = "Single";
            DataSet ds = new DataSet();
            ds = obj_BAL_Student_Dashboard.BAL_Student_Subject_Select(obj_Student_Dashboard);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                ViewState["HaveSubject"] = "Yes";
                gvSubjects.DataSource = ds.Tables[0];
                gvSubjects.DataBind();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected DataTable GenerateComboDataTable()
    {
        DataTable dtCombo = new DataTable();
        dtCombo.Columns.Add("ID");
        dtCombo.Columns.Add("Name");
        dtCombo.Columns.Add("Price");
        try
        {
            int j = 0;
            foreach (GridViewRow dl in dlCombo.Rows)
            {
                //CheckBox chkCombo = (CheckBox)dl.FindControl("chkPackage");
                RadioButton chkCombo = (RadioButton)dl.FindControl("rdbUser");

                if (chkCombo.Checked == true)
                {
                    Label lbID = (Label)dl.FindControl("lblID");
                    Label lbName = (Label)dl.FindControl("lblPackageType");
                    Label lbPrice = (Label)dl.FindControl("lblComboPrice");
                    dtCombo.Rows.Add();
                    dtCombo.Rows[j]["ID"] = lbID.Text;
                    dtCombo.Rows[j]["Name"] = lbName.Text;
                    dtCombo.Rows[j]["Price"] = lbPrice.Text;
                    j = j + 1;
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return dtCombo;
    }

    protected DataTable GenerateSubjectDataTable()
    {

        DataTable dtSubject = new DataTable();
        dtSubject.Columns.Add("ID");
        dtSubject.Columns.Add("Subject");
        dtSubject.Columns.Add("Name");
        dtSubject.Columns.Add("Price");
        try
        {
            foreach (GridViewRow gr in gvSubjects.Rows)
            {
                RadioButton rbSilver = (RadioButton)gr.FindControl("rdbSilver");
                RadioButton rbGold = (RadioButton)gr.FindControl("rdbGold");
                RadioButton rbPlatinum = (RadioButton)gr.FindControl("rdbPlatinum");
                Label lbSubject = (Label)gr.FindControl("lblSubject");

                string PID = string.Empty;
                string Package = string.Empty;
                decimal Price = 0;
                bool Flag = false;

                if (rbSilver.Checked == true)
                {
                    Flag = true;
                    PID = rbSilver.Text;
                    Package = "Silver";
                    Label lbPrice = (Label)gr.FindControl("lblSilverPrice");
                    Price = Convert.ToDecimal(lbPrice.Text);
                }
                else if (rbGold.Checked == true)
                {
                    Flag = true;
                    PID = rbGold.Text;
                    Package = "Gold";
                    Label lbPrice = (Label)gr.FindControl("lblGoldPrice");
                    Price = Convert.ToDecimal(lbPrice.Text);
                }
                else if (rbPlatinum.Checked == true)
                {
                    Flag = true;
                    PID = rbPlatinum.Text;
                    Package = "Platinum";
                    Label lbPrice = (Label)gr.FindControl("lblPlatinumPrice");
                    Price = Convert.ToDecimal(lbPrice.Text);
                }

                if (Flag == true)
                {
                    Flag = false;
                    DataRow dr = dtSubject.NewRow();
                    dr["ID"] = PID;
                    dr["Subject"] = lbSubject.Text;
                    dr["Name"] = Package;
                    dr["Price"] = Price;
                    dtSubject.Rows.Add(dr);
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

        return dtSubject;
    }

    protected bool Check()
    {
        bool Flag = true;
        try
        {
            int SCount = 0;
            int GCount = 0;
            int PCount = 0;
            int gvRows = gvSubjects.Rows.Count;

            foreach (GridViewRow gr in gvSubjects.Rows)
            {
                RadioButton rbSilver = (RadioButton)gr.FindControl("rdbSilver");
                if (rbSilver.Checked == true)
                {
                    SCount = SCount + 1;
                }

                RadioButton rbGold = (RadioButton)gr.FindControl("rdbGold");
                if (rbGold.Checked == true)
                {
                    GCount = GCount + 1;
                }

                RadioButton rbPlatinum = (RadioButton)gr.FindControl("rdbPlatinum");
                if (rbPlatinum.Checked == true)
                {
                    PCount = PCount + 1;
                }
            }

            if (gvRows == SCount)
            {
                Flag = false;
                WebMsg.Show("Please select a combo package rather than selecting all the silver packages.That will be cheaper for you.");
            }
            else if (gvRows == GCount)
            {
                Flag = false;
                WebMsg.Show("Please select a combo package rather than selecting all the gold packages.That will be cheaper for you.");
            }
            else if (gvRows == PCount)
            {
                Flag = false;
                WebMsg.Show("Please select a combo package rather than selecting all the platinum packages.That will be cheaper for you.");
            }


        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return Flag;
    }


    #endregion


    protected void OnSelectedIndexChanged(object sender, EventArgs e)
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


        PackageName = (dlCombo.SelectedRow.FindControl("lblpackagename") as Label).Text;
        subjectlist = (dlCombo.SelectedRow.FindControl("lblsubject") as Label).Text;
        validity = (dlCombo.SelectedRow.FindControl("lblnoofmonths") as Label).Text;
        price = (dlCombo.SelectedRow.FindControl("lblComboPrice") as Label).Text;
        string lblexpireon = (dlCombo.SelectedRow.FindControl("lblexpireon") as Label).Text;
        string PackageID = (dlCombo.SelectedRow.FindControl("lblID") as Label).Text;


        DataRow dtrow = dt.NewRow();    // Create New Row
        dtrow["PackageID"] = PackageID;
        dtrow["PackageName"] = PackageName;  //Bind Data to Columns
        dtrow["Subject"] = subjectlist;
        dtrow["NoOfMonth"] = validity;
        dtrow["Price"] = price;
        dtrow["PackageType"] = "single";
        dtrow["ActivateOn"] = DateTime.Today.ToString("dd/MMM/yyyy");
        //now = now.AddMonths(Convert.ToInt32(validity));

        //now = DateTime.Now.AddDays(Convert.ToInt32(validity));
        now = DateTime.Now.AddMonths(Convert.ToInt32(validity));
        now = now.Date;
        now = now.AddDays(-1);
        //dtrow["ExpiryDate"] = now.ToString("dd/MMM/yyyy");
        dtrow["ExpiryDate"] = lblexpireon;
        dt.Rows.Add(dtrow);
        Session["SelectedPackage"] = dt;
        Session["RedirectPageName"] = "selectpackage";
        //Response.Redirect("PackageConfirmation.aspx?PageIndex=0");
        Response.Redirect("PackagePaymentNew.aspx?PageIndex=0");


    }


    protected void dlCombo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
            ((Label)e.Row.FindControl("lblComboPrice")).Text = Convert.ToDecimal(((DataRowView)e.Row.DataItem)["Price"]).ToString("F");

    }
}