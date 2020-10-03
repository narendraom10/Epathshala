using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class Report_SubjectwiseSchoolPerformanceReport : System.Web.UI.Page
{
    School_BLogic SchoolBLogic = new School_BLogic();
    List<String> SchoolID_list;
    List<String> AcedemicYear_list;
    List<String> SubjectID_list;
    List<String> SubjectName_list;
    List<String> SchoolName_list;
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!IsPostBack)
        {
            FillSchoolDropdown();
            FillAcademicYearDropdown();
            FillSubjectList();

            //---------------------------------------------------
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

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    } 

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

    private void FillSubjectList()
    {
        SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        //dt = SchoolBLogic.BAL_SelectSubjectList("Select * from SYS_Subject");
        dt = SchoolBLogic.BAL_SelectSubjectList("select [Epathshala].[dbo].[SYS_Subject].SubjectID , [Epathshala].[dbo].[SYS_Subject].Subject  from    [Epathshala].[dbo].[SYS_Subject] where [Epathshala].[dbo].[SYS_Subject].SubjectID in(SELECT  distinct SubjectID FROM [Epathshala].[dbo].[vw_YearWiseSubjectWiseSchoolPerformance])");

        
        {
            if (dt.Rows.Count > 0)
            {
                ddlsubject.DataSource = dt;
                ddlsubject.DataTextField = "Subject";
                ddlsubject.DataValueField = "SubjectID";
                ddlsubject.DataBind();
            }
        }
    }



    private void LoadChartData1(DataTable initialDataSource)
    {
        int cnt = 0;
        for (int i = 4; i < initialDataSource.Columns.Count; i++)
        {
            foreach (DataRow dr in initialDataSource.Rows)
            {
                for (int i_subject = 0; i_subject < SubjectID_list.Count; i_subject++)
                {

                    Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(i_subject + -1.5, i_subject + 1.6, dr["Subject"].ToString());
                }
            }
            //cnt = 0;
            Series series = new Series();
            //foreach (DataRow dr in initialDataSource.Rows)
            //{
            //    int perc = Convert.ToInt16(dr[i]);
            //    series.Points.AddXY(dr["School"].ToString(), perc);
            series.LegendText = initialDataSource.Columns[i].ToString();
            //}

            series.Points.AddXY("", 10);
            Chart1.Series.Add(series);

        }

    }

    double cnt = 2;
    double cnt1 = 0;

    private void LoadChartData(DataTable initialDataSource)
    {
        int subcnt = 0;
        int rowcount = 0;
        for (int i = 4; i < initialDataSource.Columns.Count; i++)
        {
            Series series = new Series();
            for (int j_schoolcnt = 0; j_schoolcnt < SchoolID_list.Count; j_schoolcnt++)
            {
                cnt = 0;
                for (int j_subject = 0; j_subject < SubjectID_list.Count; j_subject++)
                {
                    Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(subcnt + 1 + -1.5, subcnt + 1 + 1.6, SubjectName_list.ToArray()[j_subject]);
                    int perc = Convert.ToInt16(j_subject);
                    series.Points.AddXY("", initialDataSource.Rows[rowcount][i].ToString());
                    subcnt = subcnt + 1;
                    rowcount = rowcount + 1;
                }
             }

           // Chart1.Series.Add(series);
            //cnt = 0;  
            //foreach (DataRow dr in initialDataSource.Rows)
            //{
            //    int perc = Convert.ToInt16(dr[i]);
            //    series.Points.AddXY(dr["School"].ToString(), perc);
            series.LegendText = initialDataSource.Columns[i].ToString();
            //}

           // series.Points.AddXY("", 10);
            Chart1.Series.Add(series);


            //double secondpoint = SubjectID_list.Count + 0.5;
            //Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0.6, secondpoint , SchoolName_list.ToArray()[0], 1, LabelMarkStyle.Box, GridTickTypes.All);
            //secondpoint = secondpoint + 0.1;
            //double diff = secondpoint - 0.6;

            //for (int j = 2; j < SchoolID_list.Count+1; j++)
            //{
                
            //    //cnt = SchoolName_list.Count * j + 0.4;
            //    //cnt1 = cnt - SchoolName_list.Count - 1 + 1.2;

                
            //    cnt = secondpoint +  diff ;
            //    cnt1 = Math.Truncate(cnt - SchoolName_list.Count - 0.5);
            //    Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            //    Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(secondpoint , cnt, SchoolName_list.ToArray()[j-1], 1, LabelMarkStyle.Box, GridTickTypes.All);
            //    Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -90;
            //    //secondpoint = Math.Round(cnt + 0.1 , 2) ;
            //    secondpoint = ((double)((int)((cnt + 0.1) * 1000.0))) / 1000.0;
            //    //Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(cnt1, cnt, "School", 1, LabelMarkStyle.Box, GridTickTypes.All);
            //}

            rowcount = 0;
        }


        double secondpoint = SubjectID_list.Count + 0.5;
        Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0.6, secondpoint, SchoolName_list.ToArray()[0], 1, LabelMarkStyle.Box, GridTickTypes.All);
        secondpoint = secondpoint + 0.1;
        double diff = secondpoint - 0.6;

        for (int j = 2; j < SchoolID_list.Count + 1; j++)
        {

            //cnt = SchoolName_list.Count * j + 0.4;
            //cnt1 = cnt - SchoolName_list.Count - 1 + 1.2;


            cnt = secondpoint + diff - 0.1;
            //cnt1 = Math.Truncate(cnt - SchoolName_list.Count - 0.5);
            Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(secondpoint, cnt, SchoolName_list.ToArray()[j - 1], 1, LabelMarkStyle.Box, GridTickTypes.All);
            Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -90;
            //secondpoint = Math.Round(cnt + 0.1 , 2) ;
            secondpoint = ((double)((int)((cnt + 0.1) * 1000.0))) / 1000.0;
            //Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(cnt1, cnt, "School", 1, LabelMarkStyle.Box, GridTickTypes.All);
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
            

        }
        catch (Exception ex)
        {
            Chart1.Visible = false;
            WebMsg.Show("Please select School and Acedemic year");
        }


    }



    protected void btnGo_Click(object sender, EventArgs e)
    {
        SchoolID_list = new List<string>();
        AcedemicYear_list = new List<string>();
        SubjectID_list = new List<string>();
        SubjectName_list = new List<string>();
        SchoolName_list = new List<string>();

        foreach (System.Web.UI.WebControls.ListItem item in ddlSchool.Items)
        {
            if (item.Selected)
            {
                SchoolID_list.Add(item.Value);
                SchoolName_list.Add(item.Text);
            }
        }

        foreach (System.Web.UI.WebControls.ListItem item in ddlAcademicYear.Items)
        {
            if (item.Selected)
            {
                AcedemicYear_list.Add(item.Text);
            }
        }

        foreach (System.Web.UI.WebControls.ListItem item in ddlsubject.Items)
        {
            if (item.Selected)
            {
                SubjectID_list.Add(item.Value);
                SubjectName_list.Add(item.Text);
            }
        }

        SchoolBLogic = new School_BLogic();
        DataSet ds = new DataSet();

        if (SchoolID_list.Count != 0 && AcedemicYear_list.Count != 0 && SubjectID_list.Count != 0)
        {
            string schoolid = null;
            string acedemicyear = null;
            string subjectid = null;
            for (int i = 0; i < SchoolID_list.Count; i++)
            {
                schoolid += "'" + SchoolID_list.ToArray()[i].ToString().Trim() + " ',";

            }

            for (int i = 0; i < AcedemicYear_list.Count; i++)
            {
                acedemicyear += "'" + AcedemicYear_list.ToArray()[i].ToString().Trim() + " ',";

            }

            for (int i = 0; i < SubjectID_list.Count; i++)
            {
                subjectid += "'" + SubjectID_list.ToArray()[i].ToString().Trim() + " ',";

            }
            //acedemicyear = " '2013-2014' ";
            schoolid = schoolid.Remove(schoolid.Length - 1);
            acedemicyear = acedemicyear.Remove(acedemicyear.Length - 1);
            subjectid = subjectid.Remove(subjectid.Length - 1);
            ds = SchoolBLogic.BAL_SelectSubjestwiseSchoolPerformance(schoolid, acedemicyear, subjectid);
        }


        if (ds != null)
        {
            BindChart(ds);
        }
    }



}