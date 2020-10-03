using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

public partial class Report_StudentChapterWisePerformance : System.Web.UI.Page
{

    Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
    StudentDash obj_Student_Dashboard;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSubjectList();
        }

    }
    protected void BindSubjectList()
    {
        try
        {
            //if (Session["ShowPaymentPages"] != null)
            //{
                ViewState["StudentBMS"] = AppSessions.BMSID;
            //}
            //else
            //{
            //    GetStudentDetailBMS();
            //}
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            obj_Student_Dashboard = new StudentDash();
            ArrayList Alist = new ArrayList();


            if (ViewState["ArrayList"] != null)
            {
                Alist = (ArrayList)ViewState["ArrayList"];
                string PackageFDID = string.Empty;
                for (int i = 0; i < Alist.Count; i++)
                {
                    if (PackageFDID != string.Empty)
                    {
                        PackageFDID = PackageFDID + "," + Alist[i].ToString();
                    }
                    else
                    {
                        PackageFDID = PackageFDID + Alist[i].ToString();
                    }
                }

                obj_Student_Dashboard.BMSID = AppSessions.BMSID;
                obj_Student_Dashboard.PackageFDID = PackageFDID;
                obj_Student_Dashboard.Mode = "Selected";
                DataSet ds = new DataSet();
                ds = obj_BAL_Student_Dashboard.BAL_Student_Subject_Select(obj_Student_Dashboard);

                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    ddlsubject.DataSource = ds.Tables[0];
                    ddlsubject.DataValueField = "SubjectID";
                    ddlsubject.DataTextField = "Subject";
                    ddlsubject.DataBind();
                    ddlsubject.SelectedIndex = 0;
                }

                ddlsubject.Items.Insert(0, "Select");
            }

            if (ViewState["StudentBMS"] != null)
            {
                obj_Student_Dashboard.BMSID = Convert.ToInt64(ViewState["StudentBMS"]);
                obj_Student_Dashboard.Mode = "All";
                DataSet ds = new DataSet();
                ds = obj_BAL_Student_Dashboard.BAL_Student_Subject_Select(obj_Student_Dashboard);
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    ddlsubject.DataSource = ds.Tables[0];
                    ddlsubject.DataValueField = "SubjectID";
                    ddlsubject.DataTextField = "Subject";
                    ddlsubject.DataBind();

                }
                ddlsubject.Items.Insert(0, "Select");
                ddlsubject.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void GetStudentDetailBMS()
    {
        DataSet dsData = new DataSet();
        DataSet dsLogin = new DataSet();
        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();
        ArrayList Alist = new ArrayList();
        int BMSID = 0;
        try
        {
            obj_Student_Dashboard.StudentID = AppSessions.StudentID;
            dsData = obj_BAL_Student_Dashboard.BAL_Validate_Student(obj_Student_Dashboard);
            if (dsData != null && dsData.Tables.Count > 0)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    string SubjectID = dsData.Tables[0].Rows[0]["SubjectID"].ToString();
                    if (SubjectID != string.Empty)
                    {
                        for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
                        {
                            Alist.Add(dsData.Tables[0].Rows[i]["PackageFD_ID"].ToString());
                        }
                        ViewState["ArrayList"] = Alist;
                        Session["UserPackage"] = "Single";
                    }
                    else
                    {
                        BMSID = Convert.ToInt32(dsData.Tables[0].Rows[0]["BMSID"].ToString());
                        ViewState["StudentBMS"] = BMSID;
                        Session["UserPackage"] = "Combo";
                    }
                }
                else if (dsData.Tables[0].Rows.Count > 1)
                {
                    Response.Redirect("~/DashBoard/SelectPackage.aspx");
                }
            }
            else
            {
                Response.Redirect("~/DashBoard/SelectPackage.aspx");
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    private void BindGridData()
    {
        try
        {
            DataSet dsResult = new DataSet();
            Student_DashBoard_BLogic Student_BAL = new Student_DashBoard_BLogic();
            int SubjectID = Convert.ToInt32(Session["SubjectID"].ToString());
            int ChapterID = Convert.ToInt32(Session["ChapterID"].ToString());
            int TopicID = Convert.ToInt32(Session["TopicID1"].ToString());

            int BMSID = Convert.ToInt32(Session["BMSID"].ToString());
            int StudentID = Convert.ToInt32(Session["StudentID"].ToString());
            string TestType = string.Empty;

            dsResult = Student_BAL.BAL_SelectStudentTestResultwithDetails(SubjectID, ChapterID, TopicID, BMSID, StudentID, TestType);
            if (dsResult.Tables[0].Rows.Count > 0)
            {

                int Right = 0;
                int Wrong = 0;
                int count = dsResult.Tables[0].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (dsResult.Tables[0].Rows[i]["Result"].ToString() == "True")
                    {
                        Right++;
                    }
                    else if (dsResult.Tables[0].Rows[i]["Result"].ToString() == "False")
                    {
                        Wrong++;
                    }
                }
                double per = Convert.ToDouble((100 * Right) / count);
            }
            else
            {
            }
        }
        catch (Exception)
        {
            grchapterwiseperformance.DataSource = null;
            grchapterwiseperformance.DataBind();
        }

    }
    DataSet dsResult = new DataSet();
    DataTable dt1 = new DataTable("tblTest");
    DataTable dt2;
    protected void btnreport_Click(object sender, EventArgs e)
    {

        try
        {
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            obj_Student_Dashboard = new StudentDash();

            obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSID"]);
            obj_Student_Dashboard.SubjectID = Convert.ToInt16(ddlsubject.SelectedValue);
            obj_Student_Dashboard.StudentID = Convert.ToInt64(Session["StudentID"]);

            DataSet dsSettings = new DataSet();

            DataSet dsSelect = new DataSet();
            dsSelect = obj_BAL_Student_Dashboard.BAL_Select_Covered_Syllabus(obj_Student_Dashboard);


            dt1.Columns.Add("Chapter", typeof(string));
            dt1.Columns.Add("Persentage", typeof(string));

            if (dsSelect.Tables[1].Rows.Count > 0)
            {
                for (int j = 0; j < dsSelect.Tables[0].Rows.Count; j++)
                {

                    dt2 = new DataTable("tblTest1");

                    dt2.Columns.Add("Chapter", typeof(string));
                    dt2.Columns.Add("ChapterID", typeof(string));
                    dt2.Columns.Add("TopicID", typeof(string));

                    for (int i = 0; i < dsSelect.Tables[1].Rows.Count; i++)
                    {
                        if (dsSelect.Tables[0].Rows[j]["ChapterID"].ToString() == dsSelect.Tables[1].Rows[i]["ChapterID"].ToString())
                        {
                            DataRow dr;
                            dr = dt2.NewRow();
                            dr["Chapter"] = dsSelect.Tables[0].Rows[j]["Chapter"].ToString();
                            dr["ChapterID"] = dsSelect.Tables[0].Rows[j]["ChapterID"].ToString();
                            dr["TopicID"] = dsSelect.Tables[1].Rows[i]["TopicID"].ToString();
                            dt2.Rows.Add(dr);

                        }
                    }
                    BindGridData1(dt2);
                    Right = 0;
                    Wrong = 0;
                }
            }
            else
            {
                DataTable dt = new DataTable();
                grchapterwiseperformance.DataSource = dt;
                grchapterwiseperformance.DataBind();

            }
        }
        catch (Exception)
        {
            grchapterwiseperformance.DataSource = null;
            grchapterwiseperformance.DataBind();
        }

    }


    int Right = 0;
    int Wrong = 0;

    private void BindGridData1(DataTable dt)
    {
        try
        {
            DataSet dsResult = new DataSet();
            double per = 0.0;

            if (dt.Rows.Count > 0)
            {
                int count = 1;
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    int ChapterID = Convert.ToInt32(dt.Rows[k]["ChapterID"]);
                    int TopicID = Convert.ToInt32(dt.Rows[k]["TopicID"]);

                    Student_DashBoard_BLogic Student_BAL = new Student_DashBoard_BLogic();
                    int SubjectID = Convert.ToInt32(ddlsubject.SelectedValue);


                    int BMSID = Convert.ToInt32(Session["BMSID"].ToString());
                    int StudentID = Convert.ToInt32(Session["StudentID"].ToString());
                    string TestType = string.Empty;

                    TestType = "Posttest";

                    dsResult = Student_BAL.BAL_SelectStudentTestResultwithDetails(SubjectID, ChapterID, TopicID, BMSID, StudentID, TestType);

                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        count += dsResult.Tables[0].Rows.Count;
                        for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                        {
                            if (dsResult.Tables[0].Rows[i]["Result"].ToString() == "True")
                            {
                                Right++;
                            }
                            else if (dsResult.Tables[0].Rows[i]["Result"].ToString() == "False")
                            {
                                Wrong++;
                            }
                        }
                    }
                    per = Convert.ToDouble((100 * Right) / (count - 1));
                }
                if (Right == 0 && Wrong == 0)
                {

                }
                else
                {
                    DataRow dr;
                    dr = dt1.NewRow();
                    dr["Chapter"] = dt.Rows[0]["Chapter"].ToString();
                    dr["Persentage"] = per.ToString() + "%";
                    dt1.Rows.Add(dr);
                    grchapterwiseperformance.DataSource = dt1;
                    grchapterwiseperformance.DataBind();
                }

                if (dt1.Rows.Count == 0)
                {
                    grchapterwiseperformance.DataSource = dt1;
                    grchapterwiseperformance.DataBind();
                }

            }
        }
        catch (Exception)
        {
            grchapterwiseperformance.DataSource = null;
            grchapterwiseperformance.DataBind();
        }
    }
}
