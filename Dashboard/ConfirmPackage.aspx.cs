///<Summary>
///</Summary>

using System;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Dashboard_ConfirmPackage : System.Web.UI.Page
{
    #region "Declarations"

    Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
    StudentDash obj_Student_Dashboard;

    Package_BLogic Blogic_Package;
    Package PPackage;

    Student_BLogic StudentBlogic;
    #endregion

    # region "Properties"
    # endregion

    # region "Page events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dsStudent = new DataSet();
            StudentBlogic = new Student_BLogic();
            decimal CurrencyRate = 0;
            dsStudent = StudentBlogic.BAL_Student_Select_PaymentInfo(AppSessions.StudentID);
            if (dsStudent.Tables[0].Rows.Count > 0)
            {
                CurrencyRate = Convert.ToDecimal(dsStudent.Tables[0].Rows[0]["Rate"].ToString());
            }


            lblStandard.Text = AppSessions.Standard;
            if (Session["Combo"] != null)
            {
                pnlCombo.Visible = true;
                DataTable dtCombo = new DataTable();
                dtCombo = (DataTable)Session["Combo"];
                if (dtCombo.Rows.Count > 0)
                {
                    dlCombo.DataSource = (DataTable)Session["Combo"];
                    dlCombo.DataBind();
                    ViewState["Combo"] = dtCombo;
                    decimal amount = 0;
                    for (int i = 0; i < dtCombo.Rows.Count; i++)
                    {
                        amount = amount + Convert.ToDecimal(dtCombo.Rows[i]["Price"].ToString());
                    }

                    if (CurrencyRate != 0)
                    {
                        decimal Finalamount = 0;
                        Finalamount = Math.Round(amount / CurrencyRate, 2);
                        lblComboAmountValue.Text = "$" + Finalamount.ToString();
                    }
                    else
                    {
                        lblComboAmountValue.Text = amount.ToString();
                    }
                }
            }
            if (Session["Single"] != null)
            {
                pnlSingle.Visible = true;
                DataTable dtSingle = new DataTable();
                dtSingle = (DataTable)Session["Single"];

                if (dtSingle.Rows.Count > 0)
                {
                    gvSubjects.DataSource = (DataTable)Session["Single"];
                    gvSubjects.DataBind();
                    decimal subjectAmount = 0;
                    ViewState["Single"] = dtSingle;

                    for (int i = 0; i < dtSingle.Rows.Count; i++)
                    {
                        subjectAmount = subjectAmount + Convert.ToDecimal(dtSingle.Rows[i]["Price"].ToString());
                    }

                    if (CurrencyRate != 0)
                    {
                        decimal Finalamount = 0;
                        Finalamount = Math.Round(subjectAmount / CurrencyRate, 2);
                        lblSubjectAmountValue.Text = "$" + Finalamount.ToString();
                    }
                    else
                    {
                        lblSubjectAmountValue.Text = subjectAmount.ToString();
                    }
                }
            }
        }
    }
    # endregion

    # region "Control events"
    protected void btnComboLogin_Click(object sender, EventArgs e)
    {
        Session["GoBack"] = "Yes";
        Response.Redirect("~/DashBoard/SelectPackage.aspx");
    }
    protected void btnBackToLogin_Click(object sender, EventArgs e)
    {
        Session["GoBack"] = "Yes";
        Response.Redirect("~/DashBoard/SelectPackage.aspx");
    }
    protected void btnComboSubmit_Click(object sender, EventArgs e)
    {
        Blogic_Package = new Package_BLogic();
        PPackage = new Package();
        DataTable dt = new DataTable();
        int t1 = 0;

        try
        {
            dt = (DataTable)ViewState["Combo"];
            if (dt.Rows.Count > 0)
            {
                PPackage.PackageFD_ID = Convert.ToInt64(dt.Rows[0]["ID"].ToString());
                PPackage.StudentID = AppSessions.StudentID;

                DataSet dsVerify = new DataSet();
                dsVerify = Blogic_Package.VerifyPackage(PPackage);
                if (dsVerify.Tables[0].Rows.Count <= 0)
                {
                    Session["CheckValidity"] = "Yes";
                    Blogic_Package.BAL_Package_Insert(PPackage);
                    //Response.Redirect("SineupPayment.aspx",false);
                    Response.Redirect("SignupPayment1.aspx", false);
                }
                else
                {
                    WebMsg.Show("Selected package already purchased");
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    public void GetSelectedpackagedetails()
    {
        try
        {



        }
        catch (Exception ex)
        { 
        
        }
            
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Blogic_Package = new Package_BLogic();
        PPackage = new Package();
        DataTable dt = new DataTable();
        int Count = 0;
        try
        {
            dt = (DataTable)ViewState["Single"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PPackage.PackageFD_ID = Convert.ToInt64(dt.Rows[i]["ID"].ToString());
                    PPackage.StudentID = AppSessions.StudentID;

                    DataSet dsVerify = new DataSet();
                    dsVerify = Blogic_Package.VerifyPackage(PPackage);
                    if (dsVerify.Tables[0].Rows.Count <= 0)
                    {
                        Session["CheckValidity"] = "Yes";
                        Blogic_Package.BAL_Package_Insert(PPackage);
                        Count = Count + 1;
                    }
                }

                if (Count > 0)
                {
                    //Response.Redirect("SineupPayment.aspx");
                    Response.Redirect("SignupPayment1.aspx");
                }
                else
                {
                    WebMsg.Show("Selected package already purchased");
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    # endregion

    # region "User defined functions"
    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }
    # endregion

}
