using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;
using System.Globalization;
using System.Linq;


public partial class ActivityFeedbackReport : System.Web.UI.Page
{
    #region "Declaration"
    School_BLogic SchoolBLogic;
    SYS_TeacherActivityFeedback Obj_TeacherActivityFeedback = new SYS_TeacherActivityFeedback();
    SYS_Division_BLogic DivisionBLogic = new SYS_Division_BLogic();


    double Fivestar = 0.0;
    double Fourstar = 0.0;
    double Threestar = 0.0;
    double Twostar = 0.0;
    double OneStar = 0.0;
    int QuestionCount = 0;
    DropDownFill DdlFilling;

    int TotalRating1 = 0;
    int bmssctid;
    DataSet ds_ActivityFeedback = new DataSet();
    DataSet ds_QuestionAverage = new DataSet();
    DataTable dt_teacher;
    #endregion

    #region "Page Event"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindAllDDLSchool();
            lblPer.Text = "";
            // this.dpgSearchResultsPager.PageSize = 2;
            //--------------------------------------------
            switch (AppSessions.RoleID)
            {
                case (int)EnumFile.Role.S_Admin:
                    ddlSchool.SelectedIndex = ddlSchool.Items.IndexOf(ddlSchool.Items.FindByValue(AppSessions.SchoolID.ToString()));
                    ddlSchool.Enabled = false;
                    ddlSchool_SelectedIndexChanged(ddlSchool, e);
                    break;
                case (int)EnumFile.Role.Teacher:
                    ddlSchool.SelectedIndex = ddlSchool.Items.IndexOf(ddlSchool.Items.FindByValue(AppSessions.SchoolID.ToString()));
                    ddlSchool.Enabled = false;
                    ddlSchool_SelectedIndexChanged(ddlSchool, e);
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
    #endregion

    #region "User Defined Functions"

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

    private void BindDivision(DropDownList ddlDivision)
    {
        int StandardID;
        if (ddlStandard.SelectedIndex == 0)
        {
            StandardID = Convert.ToInt32(null);
        }
        else
        {
            StandardID = Convert.ToInt32(ddlStandard.SelectedValue);
        }
        DivisionBLogic = new SYS_Division_BLogic();
        DataSet dsResult = new DataSet();
        dsResult = DivisionBLogic.BAL_SYS_Division_SelectByBMSID(Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), StandardID, Convert.ToInt32(ddlSchool.SelectedValue.ToString()));

        DdlFilling = new DropDownFill();
        DdlFilling.BindDropDownByTable(ddlDivision, dsResult.Tables[0], "Division", "DivisionID");
        ddlDivision.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
        ddlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
        ddlDivision.SelectedIndex = 0;

    }

    private void DDLDisable(DropDownList ddl, bool enbDsbl)
    {
        ddl.SelectedIndex = 0;
        ddl.Enabled = enbDsbl;
    }

    protected void BindFeedback()
    {
        try
        {


            dt_teacher = new DataTable();

            dt_teacher = ds_ActivityFeedback.Tables[0];
            DataTable dt_student = ds_ActivityFeedback.Tables[1];

            DataColumn myDataColumn = new DataColumn();
            myDataColumn.ColumnName = "Type";
            myDataColumn.DataType = System.Type.GetType("System.String");
            dt_student.Columns.Add(myDataColumn);
            //_dt.Columns.Add(myDataColumn);


            for (int i = 0; i < dt_student.Rows.Count; i++)
            {
                dt_student.Rows[i]["Type"] = "student";
            }

            DataColumn DataColumnStudent = new DataColumn();
            DataColumnStudent.ColumnName = "Type";
            DataColumnStudent.DataType = System.Type.GetType("System.String");

            dt_teacher.Columns.Add(DataColumnStudent);


            for (int i = 0; i < dt_teacher.Rows.Count; i++)
            {
                dt_teacher.Rows[i]["Type"] = "teacher";
            }




            for (int i = 0; i < dt_student.Rows.Count; i++)
            {
                dt_teacher.ImportRow(dt_student.Rows[i]);
            }

            //DataTable result = dt_teacher.AsEnumerable().OrderBy(


            DataView myDataView = dt_teacher.DefaultView;
            myDataView.Sort = "Division";

            ListView1.DataSource = myDataView;


            ListView1.DataBind();




        }
        catch (Exception ex)
        {

        }

    }

    private void CalculateAverageRating()
    {
        try
        {
            double averagerating;
            int total = 0;
            int totalansdered = 0;

            if (ds_ActivityFeedback.Tables[2].Rows.Count > 0)
            {
                total = Convert.ToInt32(ds_ActivityFeedback.Tables[2].Rows[0]["Total"].ToString());
                totalansdered = Convert.ToInt32(ds_ActivityFeedback.Tables[2].Rows[0]["TotalRating"].ToString());
            }
            if (ds_ActivityFeedback.Tables[3].Rows.Count > 0)
            {
                total += Convert.ToInt32(ds_ActivityFeedback.Tables[2].Rows[0]["Total"].ToString());
                totalansdered += Convert.ToInt32(ds_ActivityFeedback.Tables[3].Rows[0]["TotalRating"].ToString());
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
        catch (Exception ex)
        { 
        }
       



    }

    private DataTable StudentFeedbackQuestionBind(string StudentID, string DivisionID)
    {
        DataTable dt = new DataTable();
        Feedback_BLogic objFeedback = new Feedback_BLogic();
        Obj_TeacherActivityFeedback.SchoolID = Convert.ToInt32(ddlSchool.SelectedValue);
        Obj_TeacherActivityFeedback.BMSSCTID = Convert.ToInt32(ViewState["BMSSCTID"].ToString());
        Obj_TeacherActivityFeedback.StudentID = Convert.ToInt32(StudentID);
        Obj_TeacherActivityFeedback.DivisionID = Convert.ToInt32(DivisionID);
        Obj_TeacherActivityFeedback.CreatedBy = Convert.ToInt32(StudentID);

        //if (ddlDivision.SelectedIndex != 0)
        //{
        dt = objFeedback.GetFeedbackDetailStudent(Obj_TeacherActivityFeedback);

        //}
        //else
        //{
        //    dt = objFeedback.GetFeedbackDetailStudent1(Obj_TeacherActivityFeedback);
        //}

        //if (dt.Rows.Count > 0)
        //{
        //    //Feedback.Text = dt.Rows[0]["Feedback"].ToString();
        //    return dt;
        //    //this.mp1.Show();
        //    //grdFeedback1.DataSource = dt;
        //    //grdFeedback1.DataBind();
        //    //grdFeedback1.Visible = true;
        //   // this.mp1.Show();
        //}
        return dt;

    }

    private DataTable TeacherFeedbackQuestionBind(string EmployeeID, string division)
    {
        DataTable dt = new DataTable();
        Feedback_BLogic objFeedback = new Feedback_BLogic();
        Obj_TeacherActivityFeedback.SchoolID = Convert.ToInt32(ddlSchool.SelectedValue);
        Obj_TeacherActivityFeedback.BMSSCTID = Convert.ToInt32(ViewState["BMSSCTID"].ToString());
        Obj_TeacherActivityFeedback.EmployeeID = Convert.ToInt32(EmployeeID);
        Obj_TeacherActivityFeedback.DivisionID = Convert.ToInt32(division);
        Obj_TeacherActivityFeedback.CreatedBy = Convert.ToInt32(EmployeeID);
        dt = objFeedback.GetFeedbackDetail(Obj_TeacherActivityFeedback);

        //if (ddlDivision.SelectedIndex != 0)
        //{
        //    Obj_TeacherActivityFeedback.DivisionID = Convert.ToInt32(ddlDivision.SelectedValue.ToString());
        //    dt = objFeedback.GetFeedbackDetail(Obj_TeacherActivityFeedback);

        //}
        //else
        //{

        //    dt = objFeedback.GetFeedbackDetail1(Obj_TeacherActivityFeedback);
        //}


        return dt;

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
                DdlFilling = new DropDownFill();
                DdlFilling.BindDropDownByTable(ddlSchool, dt, "Name", "SchoolID");
                ddlSchool.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSchool.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            }

        }
        DDLDisable(ddlBoard, false);

    }

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
            ViewState["BMSSCTID"] = bmssctid.ToString();

            if (ddlDivision.SelectedIndex != 0)
            {
                ds_ActivityFeedback = obj_Activity_Feedback_Rating.GetActivityFeedback(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(bmssctid), Convert.ToInt32(ddlDivision.SelectedValue), 2);
                ds_QuestionAverage = obj_Activity_Feedback_Rating.GetQuestionRatingAverage(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(bmssctid), Convert.ToInt32(ddlDivision.SelectedValue));
            }
            else
            {
                ds_ActivityFeedback = obj_Activity_Feedback_Rating.GetActivityFeedback(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(bmssctid), 0, 1);
                ds_QuestionAverage = obj_Activity_Feedback_Rating.GetQuestionRatingAverage(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(bmssctid), Convert.ToInt32(ddlDivision.SelectedValue));

            }




            //DataSet teacher = new DataSet();
            //teacher = obj_Activity_Feedback_Rating.GetActivityFeedbackTeacher(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(bmssctid),Convert.ToInt32(ddlDivision.SelectedValue));

            //ds_ActivityFeedback.Merge(teacher);

            double[] totalavg;
            int[] star;
            star = new int[6];

            DataTable dt_teacherRating = new DataTable();
            dt_teacherRating = ds_QuestionAverage.Tables[0];

            DataTable dt_studentRating = new DataTable();
            dt_studentRating = ds_QuestionAverage.Tables[1];



            //DataRow dr;

            //for (int i = 0; i < dt_studentRating.Rows.Count; i++)
            //{


            //    dr = dt_teacherRating.NewRow();
            //    dr["ActivityFeedbackID"] = dt_studentRating.Rows[i]["ActivityFeedbackID"].ToString();
            //    dr["SchoolID"] = dt_studentRating.Rows[i]["SchoolID"].ToString();
            //    dr["BMSSCTID"] = dt_studentRating.Rows[i]["BMSSCTID"].ToString();
            //    dr["ID"] = dt_studentRating.Rows[i]["ID"].ToString();
            //    dr["DivisionID"] = dt_studentRating.Rows[i]["DivisionID"].ToString();
            //    dr["Rating"] = dt_studentRating.Rows[i]["Rating"].ToString();

            //    dt_teacherRating.Rows.Add(dr);
            //}


            int total = 0;




            if (ds_ActivityFeedback.Tables[0].Rows.Count > 0)
            {
                for (int cnt = 0; cnt < ds_ActivityFeedback.Tables[0].Rows.Count; cnt++)
                {
                    if (ds_ActivityFeedback.Tables[0].Rows[cnt]["Rating"].ToString() != "0")
                    {
                        //total += ds_ActivityFeedback.Tables[0].Rows.Count;
                        total += 1;

                    }

                }
            }
            if (ds_ActivityFeedback.Tables[1].Rows.Count > 0)
            {
                //total += ds_ActivityFeedback.Tables[1].Rows.Count;

                for (int cnt = 0; cnt < ds_ActivityFeedback.Tables[1].Rows.Count; cnt++)
                {
                    if (ds_ActivityFeedback.Tables[1].Rows[cnt]["Rating"].ToString() != "0")
                    {
                        //total += ds_ActivityFeedback.Tables[0].Rows.Count;
                        total += 1;

                    }

                }
            }

            for (int q_avg = 0; q_avg < ds_ActivityFeedback.Tables[0].Rows.Count; q_avg++)
            {

                if (ds_ActivityFeedback.Tables[0].Rows[q_avg]["Rating"].ToString() == "1")
                {
                    OneStar += 1.0;
                    star[1] = Convert.ToInt32(Math.Round((OneStar * 100) / total));
                    lbl1star.Text = star[1].ToString() + "%";
                }
                if (ds_ActivityFeedback.Tables[0].Rows[q_avg]["Rating"].ToString() == "2")
                {
                    Twostar += 1.0;
                    star[2] = Convert.ToInt32(Math.Round((Twostar * 100) / total));
                    lbl2star.Text = star[2].ToString() + "%";
                }
                if (ds_ActivityFeedback.Tables[0].Rows[q_avg]["Rating"].ToString() == "3")
                {
                    Threestar += 1.0;
                    star[3] = Convert.ToInt32(Math.Round((Threestar * 100) / total));
                    lbl3star.Text = star[3].ToString() + "%";
                }
                if (ds_ActivityFeedback.Tables[0].Rows[q_avg]["Rating"].ToString() == "4")
                {
                    Fourstar += 1.0;
                    star[4] = Convert.ToInt32(Math.Round((Fourstar * 100) / total)); ;
                    lbl4star.Text = star[4].ToString() + "%";
                }
                if (ds_ActivityFeedback.Tables[0].Rows[q_avg]["Rating"].ToString() == "5")
                {
                    Fivestar += 1.0;
                    star[5] = Convert.ToInt32(Math.Round((Fivestar * 100) / total));
                    lbl5star.Text = star[5].ToString() + "%";
                }
            }


            for (int q_avg = 0; q_avg < ds_ActivityFeedback.Tables[1].Rows.Count; q_avg++)
            {

                if (ds_ActivityFeedback.Tables[1].Rows[q_avg]["Rating"].ToString() == "1")
                {
                    OneStar += 1.0;
                    star[1] = Convert.ToInt32((OneStar * 100) / total);
                    lbl1star.Text = star[1].ToString() + "%";
                }
                if (ds_ActivityFeedback.Tables[1].Rows[q_avg]["Rating"].ToString() == "2")
                {
                    Twostar += 1.0;
                    star[2] = Convert.ToInt32(Math.Round(Twostar * 100) / total);
                    lbl2star.Text = star[2].ToString() + "%";
                }
                if (ds_ActivityFeedback.Tables[1].Rows[q_avg]["Rating"].ToString() == "3")
                {
                    Threestar += 1.0;
                    star[3] = Convert.ToInt32((Threestar * 100) / total);
                    lbl3star.Text = star[3].ToString() + "%";
                }
                if (ds_ActivityFeedback.Tables[1].Rows[q_avg]["Rating"].ToString() == "4")
                {
                    Fourstar += 1.0;
                    star[4] = Convert.ToInt32((Fourstar * 100) / total);
                    lbl4star.Text = star[4].ToString() + "%";
                }
                if (ds_ActivityFeedback.Tables[1].Rows[q_avg]["Rating"].ToString() == "5")
                {
                    Fivestar += 1.0;
                    star[5] = Convert.ToInt32((Fivestar * 100) / total);
                    lbl5star.Text = star[5].ToString() + "%";
                }
            }

            #region commnet
         

            //for (int i = 0; i < dt_student.Rows.Count; i++)
            //{
            //    dt_teacher.ImportRow(dt_student.Rows[i]);
            //}


            //for (int q_avg = 0; q_avg < ds_QuestionAverage.Tables[0].Rows.Count; q_avg++)
            //{

            //    if (ds_QuestionAverage.Tables[0].Rows[q_avg]["Rating"].ToString() == "1")
            //    {
            //        OneStar += 1.0;
            //        star[1] = Convert.ToInt32(Math.Round((OneStar * 100) / ds_QuestionAverage.Tables[0].Rows.Count));
            //        lbl1star.Text = star[1].ToString() + "%";
            //    }
            //    if (ds_QuestionAverage.Tables[0].Rows[q_avg]["Rating"].ToString() == "2")
            //    {
            //        Twostar += 1.0;
            //        star[2] = Convert.ToInt32(Convert.ToDouble(Math.Round((Twostar * 100) / ds_QuestionAverage.Tables[0].Rows.Count)));
            //        lbl2star.Text = star[2].ToString() + "%";
            //    }
            //    if (ds_QuestionAverage.Tables[0].Rows[q_avg]["Rating"].ToString() == "3")
            //    {
            //        Threestar += 1.0;
            //        star[3] = Convert.ToInt32(Math.Round((Threestar * 100) / ds_QuestionAverage.Tables[0].Rows.Count));
            //        lbl3star.Text = star[3].ToString() + "%";
            //    }
            //    if (ds_QuestionAverage.Tables[0].Rows[q_avg]["Rating"].ToString() == "4")
            //    {
            //        Fourstar += 1.0;
            //        star[4] = Convert.ToInt32(Math.Round((Fourstar * 100) / ds_QuestionAverage.Tables[0].Rows.Count));
            //        lbl4star.Text = star[4].ToString() + "%";
            //    }
            //    if (ds_QuestionAverage.Tables[0].Rows[q_avg]["Rating"].ToString() == "5")

            //    {
            //        Fivestar += 1.0;
            //        star[5] = Convert.ToInt32(Math.Round((Fivestar * 100) / ds_QuestionAverage.Tables[0].Rows.Count));
            //        lbl5star.Text = star[5].ToString() + "%";
            //    }
            //}


            //for (int q_avg = 0; q_avg < ds_QuestionAverage.Tables[0].Rows.Count; q_avg++)
            //{

            //    if (ds_QuestionAverage.Tables[1].Rows[q_avg]["Rating"].ToString() == "1")
            //    {
            //        OneStar += 1.0;
            //        star[1] = Convert.ToInt32(Math.Round((OneStar * 100) / ds_QuestionAverage.Tables[1].Rows.Count));
            //        lbl1star.Text = star[1].ToString() + "%";
            //    }
            //    if (ds_QuestionAverage.Tables[1].Rows[q_avg]["Rating"].ToString() == "2")
            //    {
            //        Twostar += 1.0;
            //        star[2] = Convert.ToInt32(Convert.ToDouble(Math.Round((Twostar * 100) / ds_QuestionAverage.Tables[1].Rows.Count)));
            //        lbl2star.Text = star[2].ToString() + "%";
            //    }
            //    if (ds_QuestionAverage.Tables[1].Rows[q_avg]["Rating"].ToString() == "3")
            //    {
            //        Threestar += 1.0;
            //        star[3] = Convert.ToInt32(Math.Round((Threestar * 100) / ds_QuestionAverage.Tables[1].Rows.Count));
            //        lbl3star.Text = star[3].ToString() + "%";
            //    }
            //    if (ds_QuestionAverage.Tables[1].Rows[q_avg]["Rating"].ToString() == "4")
            //    {
            //        Fourstar += 1.0;
            //        star[4] = Convert.ToInt32(Math.Round((Fourstar * 100) / ds_QuestionAverage.Tables[1].Rows.Count));
            //        lbl4star.Text = star[4].ToString() + "%";
            //    }
            //    if (ds_QuestionAverage.Tables[1].Rows[q_avg]["Rating"].ToString() == "5")
            //    {
            //        Fivestar += 1.0;
            //        star[5] = Convert.ToInt32(Math.Round((Fivestar * 100) / ds_QuestionAverage.Tables[1].Rows.Count));
            //        lbl5star.Text = star[5].ToString() + "%";
            //    }
            //}

            //int rowcount = ds_ActivityFeedback.Tables[3].Rows.Count + ds_ActivityFeedback.Tables[4].Rows.Count;
            //int row_count = 0;

            // totalavg = new double[rowcount];
            ////star = new int[Convert.ToInt32(dt1.Rows[0]["QuestionCount"].ToString()) + 2];
            //star = new int[6];

            #endregion
            int rowcount = ds_ActivityFeedback.Tables[0].Rows.Count + ds_ActivityFeedback.Tables[1].Rows.Count;
            int row_count = 0;

            totalavg = new double[rowcount];
            //star = new int[Convert.ToInt32(dt1.Rows[0]["QuestionCount"].ToString()) + 2];
            star = new int[6];


            if (ds_ActivityFeedback.Tables[0].Rows.Count > 0)
            {
                QuestionCount = Convert.ToInt32(ds_ActivityFeedback.Tables[0].Rows[0]["count"].ToString());
                for (int cnt = 0; cnt < ds_ActivityFeedback.Tables[0].Rows.Count; cnt++)
                {
                    TotalRating1 = Convert.ToInt32(ds_ActivityFeedback.Tables[0].Rows[cnt]["Rating"].ToString());
                    if (TotalRating1 != 0)
                    {
                        totalavg[row_count] = (TotalRating1 / Convert.ToDouble(QuestionCount));
                        row_count = row_count + 1;
                    }
                }
            }

            if (ds_ActivityFeedback.Tables[1].Rows.Count > 0)
            {
                //QuestionCount = Convert.ToInt32(ds_ActivityFeedback.Tables[1].Rows[1]["count"].ToString());
                QuestionCount = Convert.ToInt32(ds_ActivityFeedback.Tables[1].Rows[0]["count"].ToString());

                for (int cnt = 0; cnt < ds_ActivityFeedback.Tables[1].Rows.Count; cnt++)
                {

                    TotalRating1 = Convert.ToInt32(ds_ActivityFeedback.Tables[1].Rows[cnt]["Rating"].ToString());
                    if (TotalRating1 != 0)
                    {
                        totalavg[row_count] += (TotalRating1 / Convert.ToDouble(QuestionCount));
                        row_count = row_count + 1;
                    }
                }
            }
            //if (ds_ActivityFeedback.Tables[3].Rows.Count > 0)
            //{
            //    QuestionCount = Convert.ToInt32(ds_ActivityFeedback.Tables[3].Rows[0]["QuestionCount"].ToString());
            //    for (int cnt = 0; cnt < ds_ActivityFeedback.Tables[3].Rows.Count; cnt++)
            //    {
            //        TotalRating1 = Convert.ToInt32(ds_ActivityFeedback.Tables[3].Rows[cnt]["Rating"].ToString());
            //        if (TotalRating1 != 0)
            //        {
            //            totalavg[row_count] = (TotalRating1 / Convert.ToDouble(ds_ActivityFeedback.Tables[3].Rows[cnt]["QuestionCount"].ToString()));
            //            row_count = row_count + 1;
            //        }
            //    }
            //}

            //if (ds_ActivityFeedback.Tables[4].Rows.Count > 0)
            //{
            //    QuestionCount = Convert.ToInt32(ds_ActivityFeedback.Tables[4].Rows[0]["QuestionCount"].ToString());

            //    for (int cnt = 0; cnt < ds_ActivityFeedback.Tables[4].Rows.Count; cnt++)
            //    {

            //        TotalRating1 = Convert.ToInt32(ds_ActivityFeedback.Tables[4].Rows[cnt]["Rating"].ToString());
            //        if (TotalRating1 != 0)
            //        {
            //            totalavg[row_count] += (TotalRating1 / Convert.ToDouble(ds_ActivityFeedback.Tables[3].Rows[cnt]["QuestionCount"].ToString()));
            //            row_count = row_count + 1;
            //        }
            //    }
            //}

            //for (int avgcnt = 0; avgcnt < totalavg.Length; avgcnt++)
            //{
            //    int roundavg = Convert.ToInt32(Math.Round(totalavg[avgcnt]));
            //    if (roundavg == 1)
            //    {
            //        OneStar += 1.0;
            //        star[roundavg] = Convert.ToInt32(Math.Round((OneStar * 100 / row_count)));
            //       // lbl1star.Text = star[roundavg].ToString() + "%";

            //    }
            //    else if (roundavg == 2)
            //    {
            //        Twostar += 1;
            //        star[roundavg] = Convert.ToInt32(Math.Round((Twostar * 100 / row_count)));
            //       // lbl2star.Text = star[roundavg].ToString() + "%";

            //    }
            //    else if (roundavg == 3)
            //    {
            //        Threestar += 1;
            //        star[roundavg] = Convert.ToInt32(Math.Round((Threestar * 100 / row_count)));
            //       // lbl3star.Text = star[roundavg].ToString() + "%";


            //    }
            //    else if (roundavg == 4)
            //    {
            //        Fourstar += 1;
            //        star[roundavg] = Convert.ToInt32(Math.Round((Fourstar * 100 / row_count)));
            //        //lbl4star.Text = star[roundavg].ToString() + "%";


            //    }
            //    else if (roundavg == 5)
            //    {
            //        Fivestar += 1;
            //        star[roundavg] = Convert.ToInt32(Math.Round((Fivestar * 100 / row_count)));
            //        //lbl5star.Text = star[roundavg].ToString() + "%";

            //    }
            //}

            pnlreport.Visible = true;
        }
        catch (Exception ex)
        {

        }
    }


    #endregion

    #region "control Events"

    protected void ListView1_DataBound(object sender, System.EventArgs e)
    {

        int currentPage = ((ListView1.FindControl("DataPager1") as DataPager).StartRowIndex / (ListView1.FindControl("DataPager1") as DataPager).PageSize) + 1;
        int totalPages = (ListView1.FindControl("DataPager1") as DataPager).TotalRowCount / (ListView1.FindControl("DataPager1") as DataPager).PageSize;


        DropDownList ddl = (DropDownList)(ListView1.FindControl("DataPager1") as DataPager).FindControl("ddlPageSelector");


        if (ddl.Items.Count == 0)
        {
            for (int i = 0; i < totalPages; i++)
            {
                ddl.Items.Add(i.ToString());
            }
        }

    }


    protected void PageJump_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        DropDownList PageJumpDDL = (DropDownList)sender;
        int pageNo = Convert.ToInt32(PageJumpDDL.SelectedValue);

        int startRowIndex = (pageNo - 1) * (ListView1.FindControl("DataPager1") as DataPager).PageSize;

        (ListView1.FindControl("DataPager1") as DataPager).SetPageProperties(startRowIndex, (ListView1.FindControl("DataPager1") as DataPager).PageSize, true);
    }


    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            int pagenumber = ((DropDownList)sender).SelectedIndex;


            (ListView1.FindControl("DataPager1") as DataPager).SetPageProperties(pagenumber, (ListView1.FindControl("DataPager1") as DataPager).PageSize, true);

            //(ListView1.FindControl("DataPager1") as DataPager).SetPageProperties();
            BindFeedbackQuestion();
            CalculateAverageRating();
            //// grdFeedback1.Visible = false;
            BindFeedback();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (AppSessions.RoleID == (int)EnumFile.Role.E_Admin)
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
        else if (AppSessions.RoleID == (int)EnumFile.Role.S_Admin)
        {
            //DDLDisable(ddlSchool, true);
            DDLDisable(ddlBoard, true);
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
        else if (AppSessions.RoleID == (int)EnumFile.Role.Teacher)
        {
            //TODO: Code here
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.Student)
        {
            //TODO : code here..
        }
    }

    protected void ListView1_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {

        if (e.CommandName == "Image")
        {
            LinkButton lkuparrow = (LinkButton)e.Item.FindControl("LinkButton1");
            LinkButton lkdownarrow = (LinkButton)e.Item.FindControl("LinkButton2");
            Label lbltype = (Label)e.Item.FindControl("lbltype");
            Label lblid = (Label)e.Item.FindControl("lblid");
            Label lbldivision = (Label)e.Item.FindControl("lbldivisionid");
            GridView grdFeedback1 = (GridView)e.Item.FindControl("grdFeedback1");

            if (lkuparrow.Visible == true)
            {
                lkuparrow.Visible = false;
                grdFeedback1.Visible = false;
            }
            else
            {
                lkuparrow.Visible = true;
            }

            if (lkdownarrow.Visible == true)
            {
                lkdownarrow.Visible = false;
                grdFeedback1.Visible = false;

            }
            else
            {
                lkdownarrow.Visible = true;
                grdFeedback1.Visible = true;

            }


            //if (lbltype.Text.ToLower() == "student")
            //{
            //  grdFeedback1.Visible = true;


            if (lbltype.Text.ToLower() == "teacher")
            {
                DataTable dt = TeacherFeedbackQuestionBind(lblid.Text, lbldivision.Text);
                if (dt.Rows.Count > 0)
                {
                    grdFeedback1.DataSource = dt;
                    grdFeedback1.DataBind();

                }
            }
            else
            {
                DataTable dt = StudentFeedbackQuestionBind(lblid.Text, lbldivision.Text);
                if (dt.Rows.Count > 0)
                {
                    grdFeedback1.DataSource = dt;
                    grdFeedback1.DataBind();

                }
            }
        }

        if (e.CommandName == "Image1")
        {
            LinkButton lkuparrow = (LinkButton)e.Item.FindControl("LinkButton3");
            LinkButton lkdownarrow = (LinkButton)e.Item.FindControl("LinkButton4");
            Label Feedback = (Label)e.Item.FindControl("Feedback");

            if (lkuparrow.Visible == true)
            {
                lkuparrow.Visible = false;
                Feedback.Visible = false;
            }
            else
            {
                lkuparrow.Visible = true;
            }

            if (lkdownarrow.Visible == true)
            {
                lkdownarrow.Visible = false;
                Feedback.Visible = false;

            }
            else
            {
                lkdownarrow.Visible = true;
                Feedback.Visible = true;

            }
        }
    }

    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (ListView1.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);


        BindFeedbackQuestion();
        CalculateAverageRating();
        // grdFeedback1.Visible = false;
        BindFeedback();

        //GridView grdFeedback1 = ListView1.FindControl("grdFeedback1");
        //if (lbltype.Text.ToLower() == "student")
        //{
        // grdFeedback1.Visible = true;


        //DataTable dt = StudentFeedbackQuestionBind("2");
        //if (dt.Rows.Count > 0)
        //{

        //    //(ListView1.FindControl("grdFeedback1") as GridView).DataSource = dt;
        //    //(ListView1.FindControl("grdFeedback1") as GridView).DataBind();


        //}
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
            DDLDisable(ddlDivision, false);
        }
        else
        {
            DDLDisable(ddlBoard, false);
            DDLDisable(ddlMedium, false);
            DDLDisable(ddlStandard, false);
            DDLDisable(ddlsubject, false);
            DDLDisable(ddltopic, false);
            DDLDisable(ddlchapter, false);
            DDLDisable(ddlDivision, false);
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
            //BindDivision(ddlDivision);
            DDLDisable(ddlDivision, true);
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
        BindDivision(ddlDivision);
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


    protected void btnview_Click(object sender, EventArgs e)
    {

        lbl1star.Text = "0%";
        lbl2star.Text = "0%";
        lbl3star.Text = "0%";
        lbl4star.Text = "0%";
        lbl5star.Text = "0%";
        lblPer.Text = "0%";
        ListView1.Visible = true;
        lblreview.Visible = true;

        BindFeedbackQuestion();
        CalculateAverageRating();
        // grdFeedback1.Visible = false;
        BindFeedback();
        lblBMSSCTname.Text = ddlSchool.SelectedItem.ToString() + ">>" + ddlBoard.SelectedItem.ToString() + ">>" + ddlMedium.SelectedItem.ToString() + ">>" + ddlStandard.SelectedItem.ToString() + ">>" + ddlchapter.SelectedItem.ToString() + ">>" + ddltopic.SelectedItem.ToString();

    }

    #endregion
}