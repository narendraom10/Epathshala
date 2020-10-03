using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;

public partial class ActivityFeedbackNew : System.Web.UI.Page
{
    SYS_TeacherActivityFeedback Obj_TeacherActivityFeedback = new SYS_TeacherActivityFeedback();

    School_BLogic SchoolBLogic;


    double Fivestar = 0.0;
    double Fourstar = 0.0;
    double Threestar = 0.0;
    double Twostar = 0.0;
    double OneStar = 0.0;
    int QuestionCount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindAllDDLSchool();
            lblPer.Text = "";

        }

        DataTable dt = new DataTable();
        Feedback_BLogic objFeedback = new Feedback_BLogic();
        Obj_TeacherActivityFeedback.SchoolID = AppSessions.SchoolID;
        Obj_TeacherActivityFeedback.BMSSCTID = Convert.ToInt32(31);
        Obj_TeacherActivityFeedback.StudentID = AppSessions.StudentID;
        Obj_TeacherActivityFeedback.DivisionID = AppSessions.DivisionID;
        Obj_TeacherActivityFeedback.CreatedBy = 2;

        dt = objFeedback.GetFeedbackDetailStudent(Obj_TeacherActivityFeedback);
        if (dt.Rows.Count > 0)
        {
            //Feedback.Text = dt.Rows[0]["Feedback"].ToString();

            grdFeedback1.DataSource = dt;
            grdFeedback1.DataBind();
        }
        else
        {

        }
        //modalpop.Show();
    }


    protected void btnshowpopup_Click(object sender, EventArgs e)
    {
        modalpop.Show();
        DataTable dt = new DataTable();
        Feedback_BLogic objFeedback = new Feedback_BLogic();
        Obj_TeacherActivityFeedback.SchoolID = AppSessions.SchoolID;
        Obj_TeacherActivityFeedback.BMSSCTID = Convert.ToInt32(31);
        Obj_TeacherActivityFeedback.StudentID = AppSessions.StudentID;
        Obj_TeacherActivityFeedback.DivisionID = AppSessions.DivisionID;
        Obj_TeacherActivityFeedback.CreatedBy = 2;

        dt = objFeedback.GetFeedbackDetailStudent(Obj_TeacherActivityFeedback);
        if (dt.Rows.Count > 0)
        {
            //Feedback.Text = dt.Rows[0]["Feedback"].ToString();

            grdFeedback1.DataSource = dt;
            grdFeedback1.DataBind();
        }
        else
        {

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
    private void BindAllDDLSchool()
    {
        SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        dt = SchoolBLogic.BAL_SchoolAllNameWithID("Normal").Tables[0];
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                DropDownFill DdlFilling = new DropDownFill();
                DdlFilling.BindDropDownByTable(ddlSchool, dt, "Name", "SchoolID");
                ddlSchool.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSchool.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            }

        }
        DDLDisable(ddlBoard, false);

    }



    int TotalRating1 = 0;
    int bmssctid;
    DataSet ds_ActivityFeedback = new DataSet();

    private void BindFeedbackQuestion()
    {
        try
        {
            ActivityFeedbackRaing obj_Activity_Feedback_Rating = new ActivityFeedbackRaing();


            SYS_Role_BLogic obj_SYS_Role_BLogic = new SYS_Role_BLogic();
            int BMSID = obj_SYS_Role_BLogic.BAL_Select_BMS(Convert.ToInt16(ddlBoard.SelectedValue), Convert.ToInt16(ddlMedium.SelectedValue), Convert.ToInt16(ddlStandard.SelectedValue));


            Teacher_Dashboard obj_Teacher_Dashboard;
            Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard;

            obj_Teacher_Dashboard = new Teacher_Dashboard();
            obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();


            obj_Teacher_Dashboard.BMSID = Convert.ToInt64(BMSID);
            obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(ddlsubject.SelectedValue.ToString());

            obj_Teacher_Dashboard.ChapterID = Convert.ToInt64(ddlchapter.SelectedValue.ToString());
            obj_Teacher_Dashboard.TopicID = Convert.ToInt64(ddltopic.SelectedValue.ToString());


            bmssctid = obj_BAL_Teacher_Dashboard.BAL_Select_BMS_SCTID(obj_Teacher_Dashboard);

           // ds_ActivityFeedback = obj_Activity_Feedback_Rating.GetActivityFeedback(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(bmssctid));


            double[] totalavg;
            int[] star;

            int rowcount = ds_ActivityFeedback.Tables[3].Rows.Count + ds_ActivityFeedback.Tables[4].Rows.Count;
            int row_count = 0;

            totalavg = new double[rowcount];
            //star = new int[Convert.ToInt32(dt1.Rows[0]["QuestionCount"].ToString()) + 2];
            star = new int[6];

            if (ds_ActivityFeedback.Tables[3].Rows.Count > 0)
            {
                QuestionCount = Convert.ToInt32(ds_ActivityFeedback.Tables[3].Rows[0]["QuestionCount"].ToString());
                for (int cnt = 0; cnt < ds_ActivityFeedback.Tables[3].Rows.Count; cnt++)
                {
                    TotalRating1 = Convert.ToInt32(ds_ActivityFeedback.Tables[3].Rows[cnt]["Rating"].ToString());
                    if (TotalRating1 != 0)
                    {
                        totalavg[row_count] = (TotalRating1 / Convert.ToDouble(ds_ActivityFeedback.Tables[3].Rows[cnt]["Rating"].ToString()));
                        row_count = row_count + 1;
                    }
                }
            }

            if (ds_ActivityFeedback.Tables[4].Rows.Count > 0)
            {
                QuestionCount = Convert.ToInt32(ds_ActivityFeedback.Tables[4].Rows[0]["QuestionCount"].ToString());

                for (int cnt = 0; cnt < ds_ActivityFeedback.Tables[4].Rows.Count; cnt++)
                {

                    TotalRating1 = Convert.ToInt32(ds_ActivityFeedback.Tables[4].Rows[cnt]["Rating"].ToString());
                    if (TotalRating1 != 0)
                    {
                        totalavg[row_count] += (TotalRating1 / Convert.ToDouble(ds_ActivityFeedback.Tables[4].Rows[cnt]["QuestionCount"].ToString()));
                        row_count = row_count + 1;
                    }
                }
            }

            for (int avgcnt = 0; avgcnt < totalavg.Length; avgcnt++)
            {
                int roundavg = Convert.ToInt32(Math.Round(totalavg[avgcnt]));
                if (roundavg == 1)
                {
                    OneStar += 1.0;
                    star[roundavg] = Convert.ToInt32(Math.Round((OneStar * 100 / row_count)));
                    lbl1star.Text = star[roundavg].ToString() + "%";

                }
                else if (roundavg == 2)
                {
                    Twostar += 1;
                    star[roundavg] = Convert.ToInt32(Math.Round((Twostar * 100 / row_count)));
                    lbl2star.Text = star[roundavg].ToString() + "%";

                }
                else if (roundavg == 3)
                {
                    Threestar += 1;
                    star[roundavg] = Convert.ToInt32(Math.Round((Threestar * 100 / row_count)));
                    lbl3star.Text = star[roundavg].ToString() + "%";


                }
                else if (roundavg == 4)
                {
                    Fourstar += 1;
                    star[roundavg] = Convert.ToInt32(Math.Round((Fourstar * 100 / row_count)));
                    lbl4star.Text = star[roundavg].ToString() + "%";


                }
                else if (roundavg == 5)
                {
                    Fivestar += 1;
                    star[roundavg] = Convert.ToInt32(Math.Round((Fivestar * 100 / row_count)));
                    lbl5star.Text = star[roundavg].ToString() + "%";

                }
            }

            pnlreport.Visible = true;
        }
        catch (Exception ex)
        {

        }
    }



    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSchool.SelectedValue != "0")
        {
            DataSet ds = new DataSet();

            SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
            ds = objSys_Board.BAL_SYS_Board_BySchoolID(Convert.ToInt32(ddlSchool.SelectedValue));

            DropDownFill DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlBoard, ds.Tables[0], "Board", "BoardID");

            DDLDisable(ddlBoard, true);
            DDLDisable(ddlMedium, false);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
        }
        else
        {
            DDLDisable(ddlBoard, false);
            DDLDisable(ddlMedium, false);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
        }
    }
    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBoard.SelectedValue != "0")
        {
            DataSet ds = new DataSet();

            SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
            ds = objSys_Board.BAL_SYS_Medium_BySchoolIDBoardID(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue));

            DropDownFill DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlMedium, ds.Tables[0], "Medium", "MediumID");



            DDLDisable(ddlMedium, true);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
        }
        else
        {

            DDLDisable(ddlMedium, false);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
        }
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMedium.SelectedValue != "0")
        {
            BindSubjectChapterTopic(1);
        }
        else
        {

            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
        }
    }
    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubjectChapterTopic(2);
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubjectChapterTopic(3);

    }
    protected void ddlchapter_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubjectChapterTopic(4);

    }
    protected void ddltopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindSubjectChapterTopic(5);
    }

    private void BindSubjectChapterTopic(int Step)
    {

        DataSet ds = new DataSet();

        SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
        ds = objSys_Board.BAL_SYS_StdSubChapTopic_BySchoolIDBoardIDMediumid(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(ddlsubject.SelectedValue), Convert.ToInt32(ddlchapter.SelectedValue));

        DropDownFill DdlFilling = new DropDownFill();
        if (Step <= 1)
        {
            if (ds.Tables.Count > 0)
            {
                DdlFilling.BindDropDownByTable(ddlStandard, ds.Tables[0], "Standard", "StandardID");
                DDLDisable(ddlStandard, true);
            }
        }
        if (Step <= 2)
        {
            if (ds.Tables.Count > 1)
            {
                DdlFilling.BindDropDownByTable(ddlsubject, ds.Tables[1], "Subject", "SubjectID");
                DDLDisable(ddlsubject, true);
                DDLDisable(ddlchapter, true);
                DDLDisable(ddltopic, true);
            }
        }
        if (Step <= 3)
        {
            if (ds.Tables.Count > 2)
            {
                DdlFilling.BindDropDownByTable(ddlchapter, ds.Tables[2], "Chapter", "ChapterID");
                DDLDisable(ddlchapter, true);
                DDLDisable(ddltopic, true);
            }
        }
        if (Step <= 4)
        {
            if (ds.Tables.Count > 3)
            {
                DdlFilling.BindDropDownByTable(ddltopic, ds.Tables[3], "Topic", "TopicID");
                DDLDisable(ddltopic, true);
            }
        }

    }

    private void DDLDisable(DropDownList ddl, bool enbDsbl)
    {
        ddl.SelectedIndex = 0;
        ddl.Enabled = enbDsbl;
    }
    protected void btnview_Click(object sender, EventArgs e)
    {

        lbl1star.Text = "0%";
        lbl2star.Text = "0%";
        lbl3star.Text = "0%";
        lbl4star.Text = "0%";
        lbl5star.Text = "0%";
        lblPer.Text = "0%";
        ListView1.Visible = true;
        
        BindFeedbackQuestion();
        CalculateAverageRating();
        BindFeedback();


    }

    protected void BindFeedback()
    {
        try
        {
            //ActivityFeedbackRaing obj_Activity_Feedback_Rating = new ActivityFeedbackRaing();
            //DataSet ds_ActivityFeedback = new DataSet();

            DataTable _dt = new DataTable();
            _dt = ds_ActivityFeedback.Tables[0];
            DataTable dt_1 = ds_ActivityFeedback.Tables[1];
            for (int i = 0; i < dt_1.Rows.Count; i++)
            {
                _dt.ImportRow(dt_1.Rows[i]);
            }

            ListView1.DataSource = _dt;
            ListView1.DataBind();

        }
        catch (Exception ex)
        {

        }

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        DDLDisable(ddlSchool, true);
        DDLDisable(ddlBoard, false);
        DDLDisable(ddlMedium, false);
        DDLDisable(ddlStandard, false);
        DDLDisable(ddlsubject, false);
        DDLDisable(ddlchapter, false);
        DDLDisable(ddltopic, false);
        pnlreport.Visible = false;
        ListView1.Visible = false;
        lbl1star.Text = "0%";
        lbl2star.Text = "0%";
        lbl3star.Text = "0%";
        lbl4star.Text = "0%";
        lbl5star.Text = "0%";
    }

    protected void lnkFirstName_Click(object sender, EventArgs e)
    {
        modalpop.Show();
    }

    private void CalculateAverageRating()
    {
        double averagerating;
        int total = 0;
        int totalansdered = 0;

        if (ds_ActivityFeedback.Tables[6].Rows.Count > 0)
        {
            total = Convert.ToInt32(ds_ActivityFeedback.Tables[6].Rows[0]["Total"].ToString());
            totalansdered = Convert.ToInt32(ds_ActivityFeedback.Tables[6].Rows[0]["TotalRating"].ToString());
        }
        if (ds_ActivityFeedback.Tables[5].Rows.Count > 0)
        {
            total += Convert.ToInt32(ds_ActivityFeedback.Tables[5].Rows[0]["Total"].ToString());
            totalansdered += Convert.ToInt32(ds_ActivityFeedback.Tables[5].Rows[0]["TotalRating"].ToString());
        }

        if (QuestionCount > 0)
        {
            averagerating = Math.Round(Convert.ToDouble((totalansdered / QuestionCount) * 100) / total);
            lblPer.Text = "       | " + averagerating.ToString() + "%";
            if (averagerating <= 20)
            {
                ratingFeedback.CurrentRating = 1;
            }
            else if (averagerating > 20 && averagerating <= 40)
            {
                ratingFeedback.CurrentRating = 2;
            }
            else if (averagerating > 40 && averagerating <= 60)
            {
                ratingFeedback.CurrentRating = 3;
            }
            else if (averagerating > 60 && averagerating <= 80)
            {
                ratingFeedback.CurrentRating = 4;
            }
            else if (averagerating > 80 && averagerating <= 100)
            {
                ratingFeedback.CurrentRating = 5;
            }
        }



    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        modalpop.Show();
    }
}