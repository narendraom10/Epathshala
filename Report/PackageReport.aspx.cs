using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Report_PackageReport : System.Web.UI.Page
{

    SYS_BMS_BLogic BSysBMS = new SYS_BMS_BLogic();
    static string strBMS = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        txtfromdate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        txttodate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        //lblbms.Text = string.Empty;

        if (!IsPostBack)
        {
            gvmedium.Visible = false;
            gvstandard.Visible = false;
            gvStudentList.Visible = false;

            Button exporttoexcel = (Button)gvboard.FindControl("btnexporttoexcel");
            exporttoexcel.Visible = true;

            GridView gridreport = (GridView)gvboard.FindControl("gridreport");
            gridreport.Width = 600;



            StageOneCalling();
        }
    }
    protected void btnsubmit_Click1(object sender, EventArgs e)
    {

    }


    protected void btnreset_Click(object sender, EventArgs e)
    {

    }

    private void StageOneCalling()
    {
        try
        {
            DataSet dtResult = new DataSet();

            dtResult = BSysBMS.Get_AllBoards_PackageReport();
            if (dtResult != null && dtResult.Tables.Count > 0 && dtResult.Tables[0].Rows.Count > 0)
            {
                lbltotalboard.Text = GetTotalIncome(dtResult).ToString();
            }
            gvboard.XMLReportFile = Server.MapPath("../ReportXMLFiles/PackageReportFirst.xml");
            gvboard.Search(dtResult.Tables[0]);
            Label lblfooter = (Label)gvboard.FindControl("lblfooter");
            lblfooter.Text = lblfooter.Text.Replace("amount:", "Amount(INR):").ToString().Substring(0, lblfooter.Text.Replace("amount:", "Amount(INR):").IndexOf("<br/>"));

            //lblfooter.Text = lblfooter.Text.ToString().Substring(0, lblfooter.Text.ToString().IndexOf("<br/>"));

            //CurrentReport = "Classwise Report";
            gvboard.Visible = true;
            //CommanCallUserControl(dtResult, "../ReportXMLFiles/ClasswiseCoveredSyllabus.xml");
        }
        catch (Exception)
        {


        }
    }


    protected double GetTotalIncome(DataSet ds)
    {
        double total = 0.0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            total = total + Convert.ToDouble(ds.Tables[0].Rows[i]["Amount"].ToString());
        }
        return total;
    }


    public void Displayselecteddata(Hashtable hashtable, object objsender)
    {
        ReportControl rpt = (ReportControl)objsender;

        if (rpt.ID == "gvboard")
        {
            div_general.Visible = true;
            gvboard.Visible = false;
            gvmedium.Visible = true;
            btnbackboard.Visible = true;
            Button exporttoexcel = (Button)gvmedium.FindControl("btnexporttoexcel");
            exporttoexcel.Visible = true;

            GridView gridreport = (GridView)gvmedium.FindControl("gridreport");
            gridreport.Width = 600;
            //gridreport.AllowSorting = false;

            //Label lblaverage = (Label)gvmedium.FindControl("lblaverage");
            //lblaverage.Visible = false;

            Label lbltotal = (Label)gvmedium.FindControl("lbltotal");
            lbltotal.Visible = false;

            this.BoardID = Convert.ToInt32(hashtable["BoardID"]);
            strBMS = hashtable["Board"].ToString() + " Board";
            //lblbms.Text = strBMS;
            lblboard.Text = hashtable["Board"].ToString();
            StageTwoCalling();
        }
        else if (rpt.ID == "gvmedium")
        {

            gvboard.Visible = false;
            gvmedium.Visible = false;
            btnbackboard.Visible = false;
            btnbackmedium.Visible = true;
            gvstandard.Visible = true;
            Button exporttoexcel = (Button)gvstandard.FindControl("btnexporttoexcel");
            exporttoexcel.Visible = true;
            //Label lblaverage = (Label)gvstandard.FindControl("lblaverage");
            //lblaverage.Visible = false;

            GridView gridreport = (GridView)gvstandard.FindControl("gridreport");
            gridreport.Width = 600;
            //gridreport.AllowSorting = false;


            Label lbltotal = (Label)gvstandard.FindControl("lbltotal");
            lbltotal.Visible = false;
            //this.BoardID = Convert.ToInt32(hashtable["BoardID"]);
            this.MediumID = Convert.ToInt32(hashtable["MediumID"]);
            this.BMSID = Convert.ToInt32(hashtable["BMSID"]);

            strBMS += " >> " + hashtable["Medium"].ToString() + " Medium";
            //lblbms.Text = strBMS;
            lblmedium.Text = "  " + hashtable["Medium"].ToString();
            StageThreeCalling();
        }
        else if (rpt.ID == "gvstandard")
        {
            gvStudentList.Visible = true;
            gvboard.Visible = false;
            gvmedium.Visible = false;
            gvstandard.Visible = false;
            btnstandard.Visible = true;
            btnbackmedium.Visible = false;
            Button exporttoexcel = (Button)gvStudentList.FindControl("btnexporttoexcel");
            exporttoexcel.Visible = true;
            //Label lblaverage = (Label)gvStudentList.FindControl("lblaverage");
            //lblaverage.Visible = false;

            GridView gridreport = (GridView)gvStudentList.FindControl("gridreport");
            gridreport.Width = 600;
            //gridreport.AllowSorting = false;

            Label lbltotal = (Label)gvStudentList.FindControl("lbltotal");
            lbltotal.Visible = false;
            this.StandardID = Convert.ToInt32(hashtable["StandardID"]);
            strBMS += " >> " + hashtable["Standard"].ToString() + " Standard ";

            //lblbms.Text = strBMS;
            lblstandard.Text = "  " + hashtable["Standard"].ToString();

            pnlfilter.Enabled = true;
            //select_sucessfulTransactionByStandardID
            StageForthCalling();
        }

    }

    private void StageTwoCalling()
    {
        try
        {
            DataSet dsmedium = new DataSet();
            dsmedium = BSysBMS.Get_AllMediumByBoardID_PackageReport(this.BoardID);
            lbltotalmedium.Text = GetTotalIncome(dsmedium).ToString();
            gvmedium.XMLReportFile = Server.MapPath("../ReportXMLFiles/PackageReportSecond.xml");
            gvmedium.Search(dsmedium.Tables[0]);
            Label lblfooter = (Label)gvmedium.FindControl("lblfooter");
            //lblfooter.Text = lblfooter.Text.ToString().Substring(0, lblfooter.Text.ToString().IndexOf("<br/>"));
            lblfooter.Text = lblfooter.Text.Replace("amount:", "Amount(INR):").ToString().Substring(0, lblfooter.Text.Replace("amount:", "Amount(INR):").IndexOf("<br/>"));


        }
        catch (Exception)
        {
        }
    }

    private void StageThreeCalling()
    {
        try
        {


            DataSet dsstandard = new DataSet();
            dsstandard = BSysBMS.GetAllStandard_BMS_PackageReport(this.BoardID, this.MediumID);
            lbltotalstandard.Text = GetTotalIncome(dsstandard).ToString();
            gvstandard.XMLReportFile = Server.MapPath("../ReportXMLFiles/PackageReportThird.xml");
            gvstandard.Search(dsstandard.Tables[0]);
            Label lblfooter = (Label)gvstandard.FindControl("lblfooter");
            //lblfooter.Text = lblfooter.Text.ToString().Substring(0, lblfooter.Text.ToString().IndexOf("<br/>"));
            lblfooter.Text = lblfooter.Text.Replace("amount:", "Amount(INR):").ToString().Substring(0, lblfooter.Text.Replace("amount:", "Amount(INR):").IndexOf("<br/>"));
            //lblfooter.Attributes.CssStyle.Add("border", "1px Solid green");
            //lblfooter.Attributes.CssStyle.Add("padding", "5px");
            ////lblfooter.Attributes.CssStyle.Add("color", "green");
            ////lblfooter.Attributes.CssStyle.Add("background-color", " #C8E4CB");
            //lblfooter.Attributes.CssStyle.Add("width", "100%");

            //style="border: 1px Solid green; padding: 5px;
            //                   color: White; background-color: #C8E4CB; color: green;
        }
        catch (Exception)
        {


        }

    }

    private void StageForthCalling()
    {
        try
        {
            DataSet dsstudent = new DataSet();
            dsstudent = BSysBMS.GetAllStudent_BMS_PackageReport(this.BoardID, this.MediumID, this.StandardID);
            dsstudent.Tables[0].Columns.Add("PackageName", typeof(string)).SetOrdinal(6);
            for (int i = 0; i < dsstudent.Tables[0].Rows.Count; i++)
            {
                string packagename = GetPackageName(dsstudent.Tables[0].Rows[i]["PackageID"].ToString());
                dsstudent.Tables[0].Rows[i]["PackageName"] = packagename;
            }
            lbltotalstudent.Text = GetTotalIncome(dsstudent).ToString();
            gvStudentList.XMLReportFile = Server.MapPath("../ReportXMLFiles/PackageReportForth.xml");
            gvStudentList.Search(dsstudent.Tables[0]);
            GridView gridreport = (GridView)gvboard.FindControl("gridreport");
            gridreport.RowDataBound += new GridViewRowEventHandler(gridreport_RowDataBound);


            Label lblfooter = (Label)gvStudentList.FindControl("lblfooter");
            //lblfooter.Attributes["style"] = "color:red";
            lblfooter.Text = lblfooter.Text.Replace("amount:", "Amount(INR):").ToString().Substring(0, lblfooter.Text.Replace("amount:", "Amount(INR):").IndexOf("<br/>"));
            //lblfooter.Attributes.CssStyle.Add("float", "right");

        }
        catch (Exception)
        {


        }
    }

    void gridreport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes.Remove("onclick");
        e.Row.Attributes.Remove("onmouseover");
        e.Row.Attributes.Remove("onmouseout");
    }

    private string GetPackageName(string packageid)
    {
        string Packagename = string.Empty;
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{

        DataSet dspackagename = BSysBMS.GetPackageName(packageid);
        for (int k = 0; k < dspackagename.Tables[0].Rows.Count; k++)
        {
            Packagename = Packagename + ", " + dspackagename.Tables[0].Rows[k]["PackageName"].ToString();
        }
        //}
        return Packagename.Substring(1);
    }

    public int BMSID
    {
        get
        {
            if (ViewState["BMSID"] == null || ViewState["BMSID"] == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["BMSID"].ToString());
            }
        }
        set
        {
            ViewState["BMSID"] = value;
        }
    }

    public int BoardID
    {
        get
        {
            if (ViewState["BoardID"] == null || ViewState["BoardID"] == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["BoardID"].ToString());
            }
        }
        set
        {
            ViewState["BoardID"] = value;
        }
    }

    public int MediumID
    {
        get
        {
            if (ViewState["MediumID"] == null || ViewState["MediumID"] == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["MediumID"].ToString());
            }
        }
        set
        {
            ViewState["MediumID"] = value;
        }
    }

    public int StandardID
    {
        get
        {
            if (ViewState["StandardID"] == null || ViewState["StandardID"] == string.Empty)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["StandardID"].ToString());
            }
        }
        set
        {
            ViewState["StandardID"] = value;
        }
    }
    protected void btnbackboard_Click(object sender, EventArgs e)
    {
        gvmedium.Visible = false;
        gvboard.Visible = true;
        btnbackboard.Visible = false;
        lblboard.Text = "-";
        //lblbms.Text = string.Empty;
    }
    protected void btnbackmedium_Click(object sender, EventArgs e)
    {
        try
        {
            gvstandard.Visible = false;
            gvmedium.Visible = true;
            btnbackmedium.Visible = false;
            btnbackboard.Visible = true;
            lblmedium.Text = "-";
            //string strBMS1 = strBMS.Replace(">>", ">");
            //string[] BMS = strBMS1.Split('>');
            //strBMS = BMS[0].ToString();
            //lblbms.Text = strBMS;
        }
        catch (Exception)
        {
        }

    }
    protected void btnstandard_Click(object sender, EventArgs e)
    {
        try
        {
            gvstandard.Visible = true;
            gvmedium.Visible = false;
            btnbackmedium.Visible = true;
            btnbackboard.Visible = false;
            btnstandard.Visible = false;
            gvStudentList.Visible = false;
            btnstandard.Visible = false;
            //string strBMS1 = strBMS.Replace(">>", ">");
            //string[] BMS = strBMS1.Split('>');
            //strBMS = BMS[0].ToString() + " >> " + BMS[1].ToString();
            //strBMS = strBMS.Replace(">", ">>");
            //lblbms.Text = strBMS;
            lblstandard.Text = "-";
            pnlfilter.Enabled = false;
        }
        catch (Exception)
        {
        }

    }
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        try
        {
            FilterData();
        }
        catch (Exception)
        {

        }
    }



    public void FilterData()
    {
        try
        {
            string SQLQuery = "SELECT TransactionMaster.TransactionID, TransactionMaster.PackageID, TransactionMaster.MediumID, TransactionMaster.StandardID, CAST(Student.FirstName AS varchar) + ' ' + CAST(Student.LastName AS varchar) AS [Student Name], TransactionMaster.BMSID, TransactionMaster.BoardID,  StudentPackageDetail.StudentID, CONVERT(VARCHAR(11), TransactionMaster.CreatedOn,106)   as [Purchased Date]  , CONVERT(VARCHAR(11), StudentPackageDetail.FromDate,106) as [From Date], CONVERT(VARCHAR(11), StudentPackageDetail.ValidTill ,106) as [End Date], TransactionMaster.Amount	 as Amount FROM         TransactionMaster INNER JOIN Student ON TransactionMaster.StudentID = Student.StudentID INNER JOIN StudentPackageDetail ON TransactionMaster.TransactionID = StudentPackageDetail.TransactionID WHERE     (TransactionMaster.Status = 'ok') AND (TransactionMaster.BMSID IN (SELECT     BMSID FROM          SYS_BMS WHERE      (BoardID = '" + this.BoardID + "') AND (MediumID = '" + this.MediumID + "') AND (StandardID = '" + this.StandardID + "')))";
            string expression = string.Empty;
            if (txtstudent.Text != string.Empty)
            {
                expression = " and CAST(Student.FirstName AS varchar) + ' ' + CAST(Student.LastName AS varchar) LIKE '%" + txtstudent.Text + "%' ";
            }

            if (ddldatefilter.SelectedIndex > 0)
            {
                if (ddldatefilter.SelectedValue.ToString() == "1")
                {
                    expression += " and TransactionMaster.CreatedOn >= '" + Convert.ToDateTime(txtFdate.Text).ToString("dd MMM yyyy") + "' AND TransactionMaster.CreatedOn <= '" + Convert.ToDateTime(txtTodate1.Text).ToString("dd MMM yyyy") + "'  ";
                }
                else if (ddldatefilter.SelectedValue.ToString() == "2")
                {
                    expression += " and StudentPackageDetail.FromDate >= '" + Convert.ToDateTime(txtFdate.Text).ToString("dd MMM yyyy") + "' AND StudentPackageDetail.FromDate <= '" + Convert.ToDateTime(txtTodate1.Text).ToString("dd MMM yyyy") + "'  ";

                }
                else if (ddldatefilter.SelectedValue.ToString() == "3")
                {
                    expression += " and StudentPackageDetail.ValidTill >= '" + Convert.ToDateTime(txtFdate.Text).ToString("dd MMM yyyy") + "' AND StudentPackageDetail.ValidTill <= '" + Convert.ToDateTime(txtTodate1.Text).ToString("dd MMM yyyy") + "'  ";

                }
            }

            SQLQuery = SQLQuery + expression;
            //GetFilteredData(SQLQuery);

            DataAccess ODataAccess = new DataAccess();
            DataTable dt = ODataAccess.GetDataTable(SQLQuery);
            DataSet dsstudent = new DataSet();
            dsstudent.Tables.Add(dt);
            dsstudent.Tables[0].Columns.Add("PackageName", typeof(string)).SetOrdinal(6);
            for (int i = 0; i < dsstudent.Tables[0].Rows.Count; i++)
            {
                string packagename = GetPackageName(dsstudent.Tables[0].Rows[i]["PackageID"].ToString());
                dsstudent.Tables[0].Rows[i]["PackageName"] = packagename;
            }

            if (txtpackagename.Text != string.Empty)
            {
                expression = "[PackageName] LIKE '%" + txtpackagename.Text + "%'";
                DataRow[] dr = dsstudent.Tables[0].Select(expression);
                DataTable dtResult = dr.CopyToDataTable();
                dsstudent = new DataSet();
                dsstudent.Tables.Add(dtResult);

            }


            lbltotalstudent.Text = GetTotalIncome(dsstudent).ToString();
            gvStudentList.XMLReportFile = Server.MapPath("../ReportXMLFiles/PackageReportForth.xml");
            gvStudentList.Search(dsstudent.Tables[0]);
            Label lblfooter = (Label)gvStudentList.FindControl("lblfooter");
            //lblfooter.Text = lblfooter.Text.ToString().Substring(0, lblfooter.Text.ToString().IndexOf("<br/>"));
            lblfooter.Text = lblfooter.Text.Replace("amount:", "Amount(INR):").ToString().Substring(0, lblfooter.Text.Replace("amount:", "Amount(INR):").IndexOf("<br/>"));





        }
        catch (Exception)
        {


        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            txtstudent.Text = string.Empty;
            txtpackagename.Text = string.Empty;
            ddldatefilter.SelectedIndex = 0;
            txtFdate.Text = string.Empty;
            txtTodate1.Text = string.Empty;
            string SQLQuery = "SELECT TransactionMaster.TransactionID, TransactionMaster.PackageID, TransactionMaster.MediumID, TransactionMaster.StandardID, CAST(Student.FirstName AS varchar) + ' ' + CAST(Student.LastName AS varchar) AS [Student Name], TransactionMaster.BMSID, TransactionMaster.BoardID,  StudentPackageDetail.StudentID, CONVERT(VARCHAR(11), TransactionMaster.CreatedOn,106)   as [Purchased Date]  , CONVERT(VARCHAR(11), StudentPackageDetail.FromDate,106) as [From Date], CONVERT(VARCHAR(11), StudentPackageDetail.ValidTill ,106) as [End Date], TransactionMaster.Amount	FROM         TransactionMaster INNER JOIN Student ON TransactionMaster.StudentID = Student.StudentID INNER JOIN StudentPackageDetail ON TransactionMaster.TransactionID = StudentPackageDetail.TransactionID WHERE     (TransactionMaster.Status = 'ok') AND (TransactionMaster.BMSID IN (SELECT     BMSID FROM          SYS_BMS WHERE      (BoardID = '" + this.BoardID + "') AND (MediumID = '" + this.MediumID + "') AND (StandardID = '" + this.StandardID + "')))";
            GetFilteredData(SQLQuery);
            //DataAccess ODataAccess = new DataAccess();
            //DataTable dt = ODataAccess.GetDataTable(SQLQuery);
            //DataSet dsstudent = new DataSet();
            //dsstudent.Tables.Add(dt);
            //gvStudentList.Search(dsstudent.Tables[0]);
            //Label lblfooter = (Label)gvStudentList.FindControl("lblfooter");
            //lblfooter.Text = lblfooter.Text.ToString().Substring(0, lblfooter.Text.ToString().IndexOf("<br/>"));
        }
        catch (Exception)
        {


        }

    }
    private void GetFilteredData(string SQLQuery)
    {
        DataAccess ODataAccess = new DataAccess();
        //DataTable Odt = ODataAccess.GetDataTable(SQLQuery);

        DataTable dt = ODataAccess.GetDataTable(SQLQuery);
        DataSet dsstudent = new DataSet();
        dsstudent.Tables.Add(dt);
        dsstudent.Tables[0].Columns.Add("PackageName", typeof(string)).SetOrdinal(6);
        for (int i = 0; i < dsstudent.Tables[0].Rows.Count; i++)
        {
            string packagename = GetPackageName(dsstudent.Tables[0].Rows[i]["PackageID"].ToString());
            dsstudent.Tables[0].Rows[i]["PackageName"] = packagename;
        }

        lbltotalstudent.Text = GetTotalIncome(dsstudent).ToString();
        gvStudentList.XMLReportFile = Server.MapPath("../ReportXMLFiles/PackageReportForth.xml");
        gvStudentList.Search(dsstudent.Tables[0]);
        Label lblfooter = (Label)gvStudentList.FindControl("lblfooter");
        //lblfooter.Text = lblfooter.Text.ToString().Substring(0, lblfooter.Text.ToString().IndexOf("<br/>"));
        lblfooter.Text = lblfooter.Text.Replace("amount:", "Amount(INR):").ToString().Substring(0, lblfooter.Text.Replace("amount:", "Amount(INR):").IndexOf("<br/>"));


        string strfootertext = lblfooter.Text;

    }
}