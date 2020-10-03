/// <summary>               
/// <Description>School performance report</Description>
/// <DevelopedBy>"Nilofar Dabhi"</DevelopedBy>
/// <DevelopedDate>"25-Aug-2014"</DevelopedDate>
/// <UpdatedBy>""</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class Report_SchoolwisePerformanceReport : System.Web.UI.Page
{

    #region "Declaration"

    School_BLogic SchoolBLogic = new School_BLogic();
    List<String> SchoolID_list;
    List<String> AcedemicYear_list;
    #endregion

    #region "Page event"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillSchoolDropdown();
            FillAcademicYearDropdown();
            switch (AppSessions.RoleID)
            {
                case (int)EnumFile.Role.E_Admin:
                    ddlSchool.UseSelectAllNode = true;
                    break;
                case (int)EnumFile.Role.S_Admin:
                    ddlSchool.UseSelectAllNode = false;
                    ddlSchool.SelectedIndex = ddlSchool.Items.IndexOf(ddlSchool.Items.FindByValue(AppSessions.SchoolID.ToString()));
                    for (int i = 0; i < ddlSchool.Items.Count; i++)
                    {
                        if (ddlSchool.Items[i].Selected)
                        {
                            ddlSchool.Items[i].Enabled = true;
                        }
                        else
                        {
                            ddlSchool.Items[i].Enabled = false;
                        }
                    }
                    //ddlSchool.Enabled = false;

                    break;
            }
            //---------------------------------------------------

        }

    }
    #endregion

    #region "Methods"

    /// <summary>
    /// This function will fetch data of all school from database and fill in school dropdown
    /// </summary>

    private void FillSchoolDropdown()
    {
        SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        dt = SchoolBLogic.BAL_SchoolAllNameWithID("Normal").Tables[0];
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {

                ddlSchool.DataSource = dt;
                ddlSchool.DataTextField = "Name";
                ddlSchool.DataValueField = "SchoolID";
                ddlSchool.DataBind();


            }
        }
    }

    /// <summary>
    /// This function will fetch the acedemic year from database and fill it in academic year drop down
    /// </summary>

    private void FillAcademicYearDropdown()
    {
        SchoolBLogic = new School_BLogic();
        DataSet ds = new DataSet();
        ds = SchoolBLogic.BAL_AllAcademicYear();
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlAcademicYear.DataSource = ds;
                ddlAcademicYear.DataTextField = "AcademicYear";
                ddlAcademicYear.DataBind();
            }
        }
    }

    /// <summary>
    /// This function recevies dataset and bind it with chart
    /// </summary>
    /// <param name="ds"></param>
    /// 


    private void LoadChartData(DataTable initialDataSource)
    {
        int cnt = 0;
        for (int i = 2; i < initialDataSource.Columns.Count; i++)
        {
            cnt = 0;
            Series series = new Series();
            //int y = 2;
            foreach (DataRow dr in initialDataSource.Rows)
            {
                int perc = Convert.ToInt16(dr[i]);

                series.Points.AddXY(dr["Name"].ToString(), perc);

                //series.IsVisibleInLegend = true;
                series.LegendText = initialDataSource.Columns[i].ToString();

                //Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(cnt + 0.5, cnt + 1.5, dr["Name"].ToString());
                //Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels[cnt].GridTicks = GridTickTypes.All;

                //cnt = cnt + 1;
            }
            //Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 5, "group2", 1, LabelMarkStyle.Box, GridTickTypes.All);



            Chart1.Series.Add(series);

        }

    }

    protected void BindChart(DataSet ds)
    {
        try
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                Chart1.Visible = true;
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                LoadChartData(dt);
            }


            //string[] x = new string[dt.Rows.Count];
            //int[] y = new int[dt.Rows.Count];


            //for (int i = 0; i < dt.Rows.Count; i++)
            //{

            //    x[i] = dt.Rows[i]["Name"].ToString();
            //    int result = Convert.ToInt16(dt.Rows[i]["Result"].ToString());
            //    y[i] = Convert.ToInt32(result);
            //}
            //Chart1.DataSource = ds;
            ////Chart1.Series[0].Points.DataBindXY(x, y);
            //Chart1.Series[0].ChartType = SeriesChartType.StackedColumn;

            //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
            //Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -90;

            //Chart1.Series[0].XValueMember = "Name";
            //Chart1.Series[0].YValueMembers = "Result"; 

            Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;





        }
        catch (Exception ex)
        {
            Chart1.Visible = false;
            WebMsg.Show("Please select School and Acedemic year");
        }


    }

    #endregion

    #region "Control Events"



    protected void btnGo_Click(object sender, EventArgs e)
    {
        SchoolID_list = new List<string>();
        AcedemicYear_list = new List<string>();

        foreach (System.Web.UI.WebControls.ListItem item in ddlSchool.Items)
        {
            if (item.Selected)
            {
                SchoolID_list.Add(item.Value);
            }
        }

        foreach (System.Web.UI.WebControls.ListItem item in ddlAcademicYear.Items)
        {
            if (item.Selected)
            {
                AcedemicYear_list.Add(item.Text);
            }
        }


        SchoolBLogic = new School_BLogic();
        DataSet ds = new DataSet();

        if (SchoolID_list.Count != 0 && AcedemicYear_list.Count != 0)
        {
            string schoolid = null;
            string acedemicyear = null;
            for (int i = 0; i < SchoolID_list.Count; i++)
            {
                schoolid += "'" + SchoolID_list.ToArray()[i].ToString().Trim() + " ',";

            }

            for (int i = 0; i < AcedemicYear_list.Count; i++)
            {
                acedemicyear += "'" + AcedemicYear_list.ToArray()[i].ToString().Trim() + " ',";

            }
            //acedemicyear = " '2013-2014' ";
            schoolid = schoolid.Remove(schoolid.Length - 1);
            acedemicyear = acedemicyear.Remove(acedemicyear.Length - 1);
            ds = SchoolBLogic.BAL_SelectSchoolPerformance(schoolid, acedemicyear);
        }


        if (ds != null)
        {
            BindChart(ds);
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
    }
    #endregion




}