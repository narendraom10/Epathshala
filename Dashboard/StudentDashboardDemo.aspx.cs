using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.IO;

public partial class Dashboard_StudentDashboardDemo : System.Web.UI.Page
{

    Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
    StudentDash obj_Student_Dashboard;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            //string Name = Request.QueryString["Name"];
            //string BMSID = Request.QueryString["BMSID"];

            if (Session["DemoUserName"] != null)
            {



                lblWelcome.Text = "Welcome " + Session["DemoUserName"].ToString();
                Session["ShowPaymentPages"] = "No";
                //Session["DemoBMS"] = BMSID.ToString();
                Session["BMSIDDemo"] = Session["DEMOBMSID"].ToString();
                // Session["StudentID"] = Name.ToString();
                BindSubjectList();

                //GetExpiryNotification();
                if (rbSubjectList.Items.Count > 0)
                {
                    if (AppSessions.SubjectID != 0)
                    {
                        rbSubjectList.SelectedValue = AppSessions.SubjectID.ToString();
                    }
                    else
                    {
                        rbSubjectList.SelectedIndex = 0;
                        Session["SubjectIDDemo"] = Convert.ToInt16(rbSubjectList.SelectedValue);
                    }
                    FillChapters_Topic();
                    //fill_Covered_Chapters_Topics();
                    fill_Covered_Syllabus();
                    //Fill_Chart_Data();
                }
            }

            else
            {
                Response.Redirect("../DemoPages/Home.aspx");
            }

           
        }
     

    }

    protected void BindSubjectList()
    {
        try
        {
            if (Session["ShowPaymentPages"] != null)
            {
                //Session["DemoBMS"] = AppSessions.BMSID;
            }
            else
            {
                //GetStudentDetailBMS();
            }
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            obj_Student_Dashboard = new StudentDash();
            ArrayList Alist = new ArrayList();

            //if (ViewState["ArrayList"] != null)
            //{
            //    Alist = (ArrayList)ViewState["ArrayList"];
            //    string PackageFDID = string.Empty;
            //    for (int i = 0; i < Alist.Count; i++)
            //    {
            //        if (PackageFDID != string.Empty)
            //        {
            //            PackageFDID = PackageFDID + "," + Alist[i].ToString();
            //        }
            //        else
            //        {
            //            PackageFDID = PackageFDID + Alist[i].ToString();
            //        }
            //    }

            //    obj_Student_Dashboard.BMSID = AppSessions.BMSID;
            //    obj_Student_Dashboard.PackageFDID = PackageFDID;
            //    obj_Student_Dashboard.Mode = "Selected";
            //    DataSet ds = new DataSet();
            //    //ds = obj_BAL_Student_Dashboard.BAL_Student_Subject_Select(obj_Student_Dashboard);
            //    ds = obj_BAL_Student_Dashboard.BAL_Student_Purchased_Package("", Convert.ToInt32(AppSessions.BMSID), Convert.ToInt32(AppSessions.StudentID));

            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("SubjectID", typeof(Int32));
            //    dt.Columns.Add("Subject", typeof(string));



            //    if (ds.Tables[0].Rows.Count > 0 && ds != null)
            //    {
            //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //        {

            //            if (ds.Tables[0].Rows[i]["PackageType"].ToString().ToLower() == "combo")
            //            {
            //                string[] subjects = ds.Tables[0].Rows[i]["subject"].ToString().Split(',');
            //                string[] subjectsid = ds.Tables[0].Rows[i]["subjectid"].ToString().Split(',');
            //                for (int subcnt = 0; subcnt < subjects.Length; subcnt++)
            //                {
            //                    DataRow dr = dt.NewRow();
            //                    dr["SubjectID"] = subjectsid[subcnt].ToString().Trim();
            //                    dr["Subject"] = subjects[subcnt].ToString().Trim();
            //                    dt.Rows.Add(dr);
            //                }
            //            }
            //            else
            //            {
            //                DataRow dr = dt.NewRow();
            //                dr["SubjectID"] = ds.Tables[0].Rows[i]["Subjectid"].ToString().Trim();
            //                dr["Subject"] = ds.Tables[0].Rows[i]["Subject"].ToString().Trim();
            //                dt.Rows.Add(dr);
            //            }

            //        }
            //        DataTable dt1 = dt.DefaultView.ToTable(true, "SubjectID", "Subject");
            //        DataView dv = dt1.DefaultView;
            //        dv.Sort = "Subject";
            //        dt = dv.ToTable();
            //        // dt = dt.DefaultView.ToTable(true);
            //        rbSubjectList.DataSource = dt;
            //        rbSubjectList.DataValueField = "SubjectID";
            //        rbSubjectList.DataTextField = "Subject";
            //        rbSubjectList.DataBind();
            //        rbSubjectList.SelectedIndex = 0;
            //    }
            //}

            //if (Session["DemoBMS"] != null)
            if (Session["BMSIDDemo"] != null)
            {
                obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSIDDemo"]);
                obj_Student_Dashboard.Mode = "All";
                DataSet ds = new DataSet();
                ds = obj_BAL_Student_Dashboard.BAL_Student_Subject_Select(obj_Student_Dashboard);
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    rbSubjectList.DataSource = ds.Tables[0];
                    rbSubjectList.DataValueField = "SubjectID";
                    rbSubjectList.DataTextField = "Subject";
                    rbSubjectList.DataBind();
                    rbSubjectList.SelectedIndex = 0;
                }
            }


        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }




    protected void ddlLanguage12_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lbtnSignOut_Click(object sender, EventArgs e)
    {

        Session["dtChapterDemo"] = null;
        Session["dtTopicDemo"] = null;
        Response.Redirect("../DemoPages/Home.aspx");
    }
    protected void rbSubjectList_SelectedIndexChanged(object sender, EventArgs e)
    {
        // BindSubjectList();
        if (rbSubjectList.Items.Count > 0)
        {
            Session["SubjectIDDemo"] = Convert.ToInt16(rbSubjectList.SelectedValue);
            FillChapters_Topic();
            fill_Covered_Chapters_Topics();
            // fill_Covered_Syllabus();
            // Fill_Chart_Data();
            //// Fill_Rescheduling_Chapter_Topic();
        }
    }

    public void FillChapters_Topic()
    {
        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();

        obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSIDDemo"]);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectIDDemo"]);


        //
        DataSet dsSettings = new DataSet();
        dsSettings = obj_BAL_Student_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings();
        //IsAllow_Enable_Settings(dsSettings);

        DataSet dsSelect = new DataSet();
        dsSelect = obj_BAL_Student_Dashboard.BAL_Select_Chapters_Topics_Demo(obj_Student_Dashboard);
        if (dsSelect.Tables.Count == ((int)EnumFile.AssignValue.One))
        {
            if (dsSelect.Tables[0].Rows[0]["NoRecord"].ToString().Equals("0"))
            {
                WebMsg.Show("No Chapter available.");
                DropDownList[] disddl = { ddlChapter, ddlTopic };
                DisableDropDwon(disddl);
            }
        }
        else if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero) && dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
        {
            ddlChapter.DataSource = dsSelect.Tables[0];
            ddlChapter.DataTextField = "Chapter";
            ddlChapter.DataValueField = "ChapterID";
            ddlChapter.DataBind();
            ddlChapter.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
            ddlChapter.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);

            DropDownList[] disddl = { ddlChapter, ddlTopic };
            EnableDropDwon(disddl);

            if (dsSelect.Tables[2].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                if (dsSelect.Tables[2].Rows[0]["ChapterID"].ToString().Equals(""))
                {
                    ddlChapter.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
                }
                else
                {
                    // ddlChapter.SelectedValue = dsSelect.Tables[2].Rows[0]["ChapterID"].ToString();
                }
            }
            DropDownList[] disddl1 = { ddlTopic };
            DisableDropDwon(disddl1);

            ViewState["TopicTable"] = (DataTable)dsSelect.Tables[1];

            ddlTopic.DataSource = dsSelect.Tables[1];
            ddlTopic.DataTextField = "Topic";
            ddlTopic.DataValueField = "TopicID";
            ddlTopic.DataBind();
            ddlTopic.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
            ddlTopic.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);

            if (dsSelect.Tables[3].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                if (dsSelect.Tables[3].Rows[0]["TopicID"].ToString().Equals(""))
                {
                    ddlTopic.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
                }
                else
                {
                    ViewState["TopicID"] = dsSelect.Tables[3].Rows[0]["TopicID"].ToString();
                    // ddlTopic.SelectedValue = dsSelect.Tables[3].Rows[0]["TopicID"].ToString();
                }
            }

        }
        else
        {
            DropDownList[] disddl = { ddlChapter, ddlTopic };
            DisableDropDwon(disddl);
        }

    }

    public void fill_Covered_Chapters_Topics()
    {
        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();

        obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSIDDemo"]);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectIDDemo"]);
        obj_Student_Dashboard.StudentID = Convert.ToInt64(Session["StudentID"]);

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_Student_Dashboard.BAL_Select_Covered_Chapters_Topics(obj_Student_Dashboard);

        if (dsSelect.Tables.Count == ((int)EnumFile.AssignValue.One))
        {
            if (dsSelect.Tables[0].Rows[0]["NoRecord"].ToString().Equals("0"))
            {
                lblLastChapterName.Text = "-";
                lblLastTopicName.Text = "-";
            }
        }
        else if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {
            if (dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                lblLastChapterName.Text = dsSelect.Tables[0].Rows[0]["Chapter"].ToString();
            }
            else
            {
                lblLastChapterName.Text = "-";
            }
            if (dsSelect.Tables[1].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                lblLastTopicName.Text = dsSelect.Tables[1].Rows[0]["Topic"].ToString();
            }
            else
            {
                lblLastTopicName.Text = "-";
            }
        }
        else
        {
            lblLastChapterName.Text = "-";
            lblLastTopicName.Text = "-";
        }
    }

    //public void fill_Covered_Syllabus()
    //{
    //    tvSyllabus.Nodes.Clear();

    //    obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
    //    obj_Student_Dashboard = new StudentDash();

    //    obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSIDDemo"]);
    //    obj_Student_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectIDDemo"]);
    //    obj_Student_Dashboard.StudentID = Convert.ToInt64(Session["StudentID"]);

    //    DataSet dsSelect = new DataSet();

    //    dsSelect = obj_BAL_Student_Dashboard.BAL_Select_Covered_Syllabus(obj_Student_Dashboard);

    //    if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
    //    {

    //        DataTable dtChapter = new DataTable();
    //        DataTable dtTopic = new DataTable();

    //        dtChapter = dsSelect.Tables[0];
    //        dtTopic = dsSelect.Tables[1];

    //        if (dtChapter.Rows.Count > ((int)EnumFile.AssignValue.Zero) && dtTopic.Rows.Count > ((int)EnumFile.AssignValue.Zero))
    //        {
    //            foreach (DataRow c in dtChapter.Rows)
    //            {
    //                TreeNode ParentNode = new TreeNode();
    //                ParentNode.Text = c["Chapter"].ToString();
    //                ParentNode.Value = c["ChapterID"].ToString();
    //                tvSyllabus.Nodes.Add(ParentNode);
    //                foreach (DataRow d in dtTopic.Select("ChapterID  = " + Convert.ToInt32(c["ChapterID"].ToString())))
    //                {
    //                    TreeNode ChildNode = new TreeNode();
    //                    ChildNode.Text = d["Topic"].ToString();
    //                    ChildNode.Value = d["TopicID"].ToString();
    //                    ParentNode.ChildNodes.Add(ChildNode);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            tvSyllabus.Nodes.Clear();
    //        }

    //    }
    //    else
    //    {
    //        tvSyllabus.Nodes.Clear();
    //    }

    //}

    public void fill_ALL_Covered_Chaptes_Topics()
    {

        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();

        obj_Student_Dashboard.BMSID = Convert.ToInt64(Session["BMSIDDemo"]);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectIDDemo"]);
        obj_Student_Dashboard.DivisionID = Convert.ToInt16(Session["DivisionID"]);
        obj_Student_Dashboard.StudentID = Convert.ToInt64(Session["StudentID"]);
        obj_Student_Dashboard.SchoolID = Convert.ToInt64(Session["SchoolID"]);

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_Student_Dashboard.BAL_Select_Covered_Syllabus(obj_Student_Dashboard);

        if (dsSelect.Tables.Count == ((int)EnumFile.AssignValue.One))
        {
            if (dsSelect.Tables[0].Rows[0]["NoRecord"].ToString().Equals("0"))
            {
                WebMsg.Show("No Chapter available.");

                DropDownList[] disddl = { ddlChapter, ddlTopic };
                DisableDropDwon(disddl);
            }
        }

        else if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero) && dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
        {

            ddlChapter.DataSource = dsSelect.Tables[0];
            ddlChapter.DataTextField = "Chapter";
            ddlChapter.DataValueField = "ChapterID";
            ddlChapter.DataBind();
            ddlChapter.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
            ddlChapter.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);

            DropDownList[] disddl = { ddlChapter, ddlTopic };
            EnableDropDwon(disddl);


            ViewState["TopicTable"] = (DataTable)dsSelect.Tables[1];

            ddlTopic.DataSource = dsSelect.Tables[1];
            ddlTopic.DataTextField = "Topic";
            ddlTopic.DataValueField = "TopicID";
            ddlTopic.DataBind();
            ddlTopic.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
            ddlTopic.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);

        }
        else
        {
            DropDownList[] disddl = { ddlChapter, ddlTopic };
            DisableDropDwon(disddl);
        }

    }

    #region Redio Button List Events
    //protected void rblChapters_SelectedIndexChanged(object sender, EventArgs e)
    //{
        //if (rblChapters.SelectedValue == ((int)EnumFile.Chapter.UnCoveredChapters).ToString())
        //{
        //    // FillChapters_Topic();
        //}
        //else if (rblChapters.SelectedValue == ((int)EnumFile.Chapter.CoveredChapters).ToString())
        //{
        //    //fill_ALL_Covered_Chaptes_Topics();
        //}
    //}
    #endregion
    //protected void rbSubjectList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //     BindSubjectList();
    //    if (rbSubjectList.Items.Count > 0)
    //    {
    //        AppSessions.SubjectID = Convert.ToInt16(rbSubjectList.SelectedValue);
    //        FillChapters_Topic();
    //        fill_Covered_Chapters_Topics();
    //        fill_Covered_Syllabus();
    //        //Fill_Chart_Data();
    //        //// Fill_Rescheduling_Chapter_Topic();
    //    }
    //}
    protected void ddlChapter_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlChapter.SelectedIndex > 0)
        {
            DataTable dt = (DataTable)ViewState["TopicTable"];
            if (dt.Rows.Count > Convert.ToInt32(EnumFile.AssignValue.Zero))
            {

                DataTable dtResult = dt.Clone();

                DataRow[] dr = dt.Select("ChapterID = " + Convert.ToInt32(ddlChapter.SelectedValue));

                //dt.AcceptChanges();
                foreach (DataRow drLoop in dr)
                {
                    //DataRow drRow = dtResult.NewRow();
                    //drRow =  dr1;
                    //dtResult.Rows.Add(drRow);
                    dtResult.ImportRow(drLoop);
                }

                ddlTopic.DataSource = dtResult;
                ddlTopic.DataTextField = "Topic";
                ddlTopic.DataValueField = "TopicID";
                ddlTopic.DataBind();
                ddlTopic.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
                ddlTopic.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);

                DropDownList[] disddl = { ddlTopic };
                EnableDropDwon(disddl);
            }
        }
        else
        {
            DropDownList[] disddl = { ddlTopic };
            DisableDropDwon(disddl);
        }
    }

    public void fill_Covered_Syllabus()
    {
        tvSyllabus.Nodes.Clear();
        DataTable dtChapter = new DataTable();
        DataTable dtTopic = new DataTable();


        if (Session["dtChapterDemo"] != null)
        {


            dtChapter = (DataTable)(Session["dtChapterDemo"]);
            dtTopic = (DataTable)(Session["dtTopicDemo"]);



            if (dtChapter.Rows.Count > ((int)EnumFile.AssignValue.Zero) && dtTopic.Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                foreach (DataRow c in dtChapter.Rows)
                {
                    TreeNode ParentNode = new TreeNode();
                    ParentNode.Text = c["Chapter"].ToString();
                    ParentNode.Value = c["ChapterID"].ToString();
                    tvSyllabus.Nodes.Add(ParentNode);
                    foreach (DataRow d in dtTopic.Select("ChapterID  = " + Convert.ToInt32(c["ChapterID"].ToString())))
                    {
                        TreeNode ChildNode = new TreeNode();
                        ChildNode.Text = d["Topic"].ToString();
                        ChildNode.Value = d["TopicID"].ToString();
                        ParentNode.ChildNodes.Add(ChildNode);
                    }
                }
            }



            lblLastChapterName.Text = Session["LastDemoChapter"].ToString();
            lblLastTopicName.Text = Session["LastDemoTopic"].ToString();

        }
        else
        {
            tvSyllabus.Nodes.Clear();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["DEMOBMSID"] != null)
        {
            Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard;
            Teacher_Dashboard obj_Teacher_Dashboard;

            obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
            obj_Teacher_Dashboard = new Teacher_Dashboard();

            obj_Teacher_Dashboard.BMSID = Convert.ToInt64(Session["DEMOBMSID"]);
            obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(Session["SubjectIDDemo"]);

            obj_Teacher_Dashboard.ChapterID = Convert.ToInt64(ddlChapter.SelectedValue);
            obj_Teacher_Dashboard.TopicID = Convert.ToInt64(ddlTopic.SelectedValue);

            DataSet dsDemoData = new DataSet();

            dsDemoData = obj_BAL_Teacher_Dashboard.BAL_Select_BMS_SCTID_Demo(obj_Teacher_Dashboard);

            int bmssctid = Convert.ToInt32(dsDemoData.Tables[0].Rows[0]["BMSSCTID"].ToString());
            string IsAllowForDemo = dsDemoData.Tables[0].Rows[0]["IsAllowForDemo"].ToString();


            if (bmssctid > (int)EnumFile.AssignValue.Zero)
            {
                if (IsAllowForDemo.ToString().Trim().ToLower() == "true")
                {
                    Session["DEMOChapterTopic"] = ddlChapter.SelectedItem.ToString() + " >> " + ddlTopic.SelectedItem.ToString();
                    Session["DEMOBMSSCTID"] = bmssctid;
                    Session["DemoChapter"] = ddlChapter.SelectedItem.ToString();
                    Session["DemoTopic"] = ddlTopic.SelectedItem.ToString();
                    Session["DemoChapterID"] = ddlChapter.SelectedValue.ToString();
                    Session["DemoTopicID"] = ddlTopic.SelectedValue.ToString();

                    String Path1 = Server.MapPath("../EduResource/" + bmssctid);
                    if (Directory.Exists(Path1))
                    {
                        //Response.Redirect("../DemoPages/viewDemoContent.aspx?type=topic&BMSSCTID="+ bmssctid.ToString().Trim() +"");

                        Response.Redirect("../DemoPages/EducationResourceDemo.aspx");

                    }
                    else
                    {
                        WebMsg.Show("No Educational resource available.");
                    }
                }
                else
                {
                    //WebMsg.Show("You have to register first for this content");
                    showme.Attributes["style"] = "visibility:visible;";
                    ModalPopupExtender1.Show();

                }
            }
            else
            {
                showme.Attributes["style"] = "visibility:visible;";
                ModalPopupExtender1.Show();
                

                //WebMsg.Show("You have to register first for this content");

            }
        }
        else
        {
            Response.Redirect("../DemoPages/Home.aspx");
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlChapter.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        DropDownList[] disddl = { ddlTopic };
        DisableDropDwon(disddl);
    }

    protected void tvSyllabus_SelectedNodeChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < tvSyllabus.Nodes.Count; i++)
        {
            foreach (TreeNode node in tvSyllabus.Nodes[i].ChildNodes)
            {
                if (node.Selected)
                {
                    Session["TopicID1"] = node.Value;
                    Session["ChapterID"] = node.Parent.Value;
                    //WebMsg.Show("ChapterID = " + ChapterID + " TopicID = " + TopicID);
                    Session["SubjectIDDemo"] = Convert.ToInt32(rbSubjectList.SelectedValue);
                    Session["Topic1"] = node.Text;
                    Session["Chapter"] = node.Parent.Text;
                    Session["Subject"] = rbSubjectList.SelectedItem.Text.ToString();
                    //mpTestResult.Show();
                }
                node.Selected = false;
            }
        }
        //Response.Redirect("StudentPreTestPostTestResult.aspx?Type=Student");
    }

    protected void btnsearcksubmit_Click(object sender, EventArgs e)
    {
        //Response.Redirect("SearchResult.aspx?key=" + txtkeyword.Text + "");
        WebMsg.Show("You have to register first to use this facility ");
    }



    public void DisableDropDwon(DropDownList[] disddl)
    {
        foreach (DropDownList dl in disddl)
        {
            dl.Enabled = false;
            dl.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        }
    }

    public void EnableDropDwon(DropDownList[] disddl)
    {
        foreach (DropDownList dl in disddl)
        {
            dl.Enabled = true;
            dl.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        }
    }


    protected void btnopenflv_Click(object sender, EventArgs e)
    {
        if (Session["ext"] != null && Session["myframesrc"] != null)
        {
            myframe.Attributes["style"] = "";
            myframe.Attributes["src"] = "../DemoPages/"  + Session["myframesrc"].ToString();
            mp1.Show(); 
            LblDisplay.Text = Session["DashboardTopic"].ToString();
        }
    }
    protected void close_Click(object sender, EventArgs e)
    {
        Response.Redirect("../DemoPages/StudentRegistrationForm.aspx");
    }
}