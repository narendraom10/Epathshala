using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Dashboard_LeavingCertificate : System.Web.UI.Page
{
    DataTable DTschooladdress;
    DataAccess ODataAccess;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblschoolname.Text = AppSessions.SchoolName;
            DTschooladdress = new DataTable();
            ODataAccess = new DataAccess();
            DTschooladdress = ODataAccess.GetDataTable("Select * from School where schoolID='"+ Convert.ToInt32(AppSessions.SchoolID) +"' ");
            lbladdress.Text = DTschooladdress.Rows[0]["Address"].ToString();

            lblname.Text = "Nilofar Pratik Dabhi";
            lblmothername.Text = "Meena Dabhi";
            lblcaste.Text = "General";
            lbldateofbirth.Text = DateTime.Now.ToString("dd MMM yyyy");
            lbllastschool.Text = "Shree vishudhhanand vidhya mandir";
            lbldateofadmission.Text = DateTime.Now.ToString("dd MMM yyyy");
            lbldateofleaving.Text = DateTime.Now.ToString("dd MMM yyyy");
            lblRFL.Text = "For Heigher Education";
            lblprogress.Text = "Good";
            lbldate.Text = "Date " + DateTime.Now.ToString("dd MMM yyyy");
            lblCurrentStandard.Text = "Nineth";




        }
        catch (Exception ex)
        { 
        
        }
        
        
    }
}