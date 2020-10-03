using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class Report_ChartReportForStudentWiseExamResult : System.Web.UI.Page
{

    int SchoolID;
    int StudentID;
    int BMSID;
    int SubjectID;
    int DivisionID;
    DateTime FromDate;
    DateTime ToDate;
    string studentname;


    protected void Page_Load(object sender, EventArgs e)
    {
         
        if (!IsPostBack)
        {
            SchoolID = Convert.ToInt16(Request.QueryString["SchoolID"]);
            StudentID = Convert.ToInt16(Request.QueryString["StudentID"]);
            BMSID = Convert.ToInt16(Request.QueryString["BMSID"]);
            SubjectID = Convert.ToInt16(Request.QueryString["StudentID"]);
            DivisionID = Convert.ToInt16(Request.QueryString["DivisionID"]);
            FromDate = Convert.ToDateTime(Request.QueryString["FromDate"]);
            ToDate = Convert.ToDateTime(Request.QueryString["ToDate"]);
            //studentname = Request.QueryString["StudentName"].ToString();
            BindChart();
            
        }
    }

    protected void BindChart()
    {

        DataSet ds = new DataSet();
        ReportsForResult objRsultReport = new ReportsForResult();
        ds = objRsultReport.BAL_SYS_ResultStudentwiseSecond_Select(this.SchoolID, this.StudentID, this.BMSID, this.SubjectID, this.DivisionID, this.FromDate, this.ToDate);
        
        DataTable dt = new DataTable();
        
        
        dt = ds.Tables[0];

        string[] x = new string[dt.Rows.Count];
        decimal[] y = new decimal[dt.Rows.Count];

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            x[i] = dt.Rows[i][2].ToString();
            string perc = dt.Rows[i][3].ToString().Substring(0,dt.Rows[i][3].ToString().IndexOf("%"));
            y[i] = Convert.ToInt32(perc);
        }

        //BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = y });
        //BarChart1.CategoriesAxis = string.Join(",", x);
        //Chart1.Series[0].Points.DataBindXY(x, y);
        //Chart1.Series[0].ChartType = SeriesChartType.Column;
        //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
        lblstudentname.Text = studentname;
        //Chart1.Legends[0].Enabled = true;
    }

    //protected void GetStudentData()
    //{
    //    DataSet ds = new DataSet();
    //    ReportsForResult objRsultReport = new ReportsForResult();
    //    ds = objRsultReport.BAL_SYS_ResultStudentwiseSecond_Select(this.SchoolID, this.StudentID, this.BMSID, this.SubjectID, this.DivisionID, this.FromDate, this.ToDate);
    //}
}