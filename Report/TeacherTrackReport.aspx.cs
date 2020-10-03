using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;
using System.Globalization;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;
using System.Xml;

public partial class Report_TeacherTrackReport : System.Web.UI.Page
{
    #region "Declaration"


    DropDownFill DdlFilling;
    School_BLogic SchoolBLogic = new School_BLogic();
    SYS_Division_BLogic DivisionBLogic = new SYS_Division_BLogic();
    TrackLogRPT_BLogic obj_TracklogRPT;
    string connectionstring;
    #endregion
    #region "Page Events"

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFdate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            txtTodate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            FillSchoolDropdown(ddlSchool);

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

    #endregion

    #region "User Defined Functions"

    private void FillSchoolDropdown(DropDownList ddlSchool)
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
                //ddlDisable(ddlBoard, false);
            }
        }
    }
    private void ddlDisable(DropDownList dropdown, bool status)
    {
        dropdown.Enabled = status;
        dropdown.SelectedIndex = 0;
    }
    private void BindSubjectChapterTopic(int Step)
    {

        DataSet ds = new DataSet();

        SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
        ds = objSys_Board.BAL_SYS_StdSubChapTopic_BySchoolIDBoardIDMediumid(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(ddlSubject.SelectedValue), Convert.ToInt32(ddlChapter.SelectedValue));

        DdlFilling = new DropDownFill();
        if (Step <= 1)
        {
            if (ds.Tables.Count > 0)
            {
                DdlFilling.BindDropDownByTable(ddlStandard, ds.Tables[0], "Standard", "StandardID");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlStandard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlStandard.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                    //ddlDisable(ddlStandard, true);
                }
            }
        }
        if (Step <= 2)
        {
            if (ds.Tables.Count > 1)
            {
                DdlFilling.BindDropDownByTable(ddlSubject, ds.Tables[1], "Subject", "SubjectID");
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddlSubject.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlSubject.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                }
            }
        }
        if (Step <= 3)
        {
            if (ds.Tables.Count > 2)
            {
                DdlFilling.BindDropDownByTable(ddlChapter, ds.Tables[2], "Chapter", "ChapterID");
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddlChapter.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlChapter.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                }
                //DDLDisable(ddlchapter, true);
                //DDLDisable(ddltopic, true);
            }
        }
        if (Step <= 4)
        {
            if (ds.Tables.Count > 3)
            {
                DdlFilling.BindDropDownByTable(ddlTopic, ds.Tables[3], "Topic", "TopicID");
                if (ds.Tables[3].Rows.Count > 0)
                {
                    ddlTopic.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlTopic.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                }
                //DDLDisable(ddltopic, true);
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
        dsResult = DivisionBLogic.BAL_SYS_Division_SelectByBMSID(Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), StandardID, Convert.ToInt32(ddlSchool.SelectedValue));

        DdlFilling = new DropDownFill();
        DdlFilling.BindDropDownByTable(ddlDivision, dsResult.Tables[0], "Division", "DivisionID");
        ddlDivision.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
        ddlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);

    }

    #endregion
    #region "Control Events"

    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSchool.SelectedIndex != 0)
        {
            DataSet ds = new DataSet();

            SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
            ds = objSys_Board.BAL_SYS_Board_BySchoolID(Convert.ToInt32(ddlSchool.SelectedValue));

            DropDownFill DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlBoard, ds.Tables[0], "Board", "BoardID");
            ddlBoard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlBoard.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            Session["ReportSchoolID"] = Convert.ToInt32(ddlSchool.SelectedValue);
            Session["ReportSchoolName"] = ddlSchool.SelectedItem.ToString();
            ddlDisable(ddlBoard, true);
        }
        else
        {
            ddlDisable(ddlBoard, false);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlSubject, false);
            ddlDisable(ddlSubject, false);
            ddlDisable(ddlChapter, false);
            ddlDisable(ddlTopic, false);
            ddlDisable(ddlDivision, false);
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
            ddlMedium.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlMedium.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlDisable(ddlMedium, true);
            //ddlMedium.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
        }
        else
        {
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlSubject, false);
            ddlDisable(ddlChapter, false);
            ddlDisable(ddlTopic, false);
            ddlDisable(ddlDivision, false);
        }
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMedium.SelectedIndex != 0)
        {
            BindSubjectChapterTopic(1);
            ddlDisable(ddlStandard, true);
            ddlDisable(ddlSubject, true);
            ddlDisable(ddlChapter, true);
            //BindDivision(ddlDivision); // Changed 
            //ddlDisable(ddlTopic, true);
            ddlDisable(ddlDivision, true);
        }
        else
        {
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlSubject, false);
            ddlDisable(ddlChapter, false);
            ddlDisable(ddlTopic, false);
            ddlDisable(ddlDivision, false);
        }
    }
    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStandard.SelectedIndex != 0)
        {
            BindSubjectChapterTopic(2);
            BindDivision(ddlDivision);
            ddlDisable(ddlTopic, false);
            ddlDisable(ddlDivision, true);
            BindDivision(ddlDivision);
        }
        else
        {
            ddlSubject.SelectedIndex = 0;
            ddlChapter.SelectedIndex = 0;
            ddlDivision.SelectedIndex = 0;
            ddlDisable(ddlTopic, false);
        }
    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubject.SelectedIndex != 0)
        {
            BindSubjectChapterTopic(3);
            ddlDisable(ddlTopic, false);
            ddlDivision.SelectedIndex = 0;
        }
        else
        {
            ddlChapter.SelectedIndex = 0;
            ddlDisable(ddlTopic, false);
            ddlDivision.SelectedIndex = 0;
        }
    }
    protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChapter.SelectedIndex != 0)
        {
            BindSubjectChapterTopic(4);
            ddlDisable(ddlTopic, true);
            ddlDivision.SelectedIndex = 0;
        }
        else
        {
            ddlDisable(ddlTopic, false);
            ddlDivision.SelectedIndex = 0;
        }
    }
    protected void ddlTopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTopic.SelectedIndex == 0)
        {
            ddlDivision.SelectedIndex = 0;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (AppSessions.RoleID == (int)EnumFile.Role.E_Admin)
        {
            ddlDisable(ddlSchool, true);
            ddlDisable(ddlBoard, false);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlSubject, false);
            ddlDisable(ddlChapter, false);
            ddlDisable(ddlTopic, false);
            ddlDisable(ddlDivision, false);
            ReportControl1.Visible = false;
            ReportControl2.Visible = false;
            div1.Visible = false;
            FirstRpt.Visible = true;
            secondRpt.Visible = false;
            thirdRpt.Visible = false;
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.S_Admin)
        {
            //ddlDisable(ddlSchool, true);
            ddlDisable(ddlBoard, true);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlSubject, false);
            ddlDisable(ddlChapter, false);
            ddlDisable(ddlTopic, false);
            ddlDisable(ddlDivision, false);
            ReportControl1.Visible = false;
            ReportControl2.Visible = false;
            div1.Visible = false;
            FirstRpt.Visible = true;
            secondRpt.Visible = false;
            thirdRpt.Visible = false;
        }
        
      

    }

    #endregion
    protected void btnGo_Click(object sender, EventArgs e)
    {
        obj_TracklogRPT = new TrackLogRPT_BLogic();

        DataSet dsResult = obj_TracklogRPT.BAL_Select_TeacherWiseTrackLog(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt16(ddlDivision.SelectedValue), Convert.ToDateTime(txtFdate.Text), Convert.ToDateTime(txtTodate.Text));

        if (dsResult.Tables.Count > 0)
        {
            ReportControl1.Visible = true;
            CommanCallUserControl(dsResult.Tables[0], "../ReportXMLFiles/TeacherTrackRPT.xml", 1);

        }
        else
        {
            WebMsg.Show("No data found.");
        }
    }

    private void CommanCallUserControl(DataTable dt, string reporttype, int control)
    {
        GetConnectionStringSTRING obj = new GetConnectionStringSTRING();
        connectionstring = obj.BAL_EpathshalaString();



        try
        {
            if (control == 1)
            {
                ReportControl1.ConnectionString = connectionstring;


                //reporttype = Server.MapPath("Files/MonthlySummary.xml");
                ReportControl1.XMLReportFile = Server.MapPath(reporttype);

                ReportControl1.Search(dt);
            }
            else if (control == 2)
            {
                ReportControl2.ConnectionString = connectionstring;


                //reporttype = Server.MapPath("Files/MonthlySummary.xml");
                ReportControl2.XMLReportFile = Server.MapPath(reporttype);

                ReportControl2.Search(dt);
            }
            else if (control == 3)
            {
                //ReportControl3.ConnectionString = connectionstring;


                ////reporttype = Server.MapPath("../ReportXMLFiles/TeacherTrackRPTEmpWiseBMSSCT.xml");
                //ReportControl3.XMLReportFile = Server.MapPath(reporttype);

                //ReportControl3.Search(dt);

                StringBuilder ReportString = new StringBuilder();
                //Header

                //XML to Dataset
                DataSet xmllanguage = new DataSet();
                xmllanguage.ReadXml(Server.MapPath("../ReportXMLFiles/TeacherTrackRPTEmpWiseBMSSCT.xml"));
                //End XML to Dataset

                //HiddenFields list get
                List<string> HiddenFields;
                HiddenFields = GetHiddenFields();
                //End HiddenFields list get

                DataTable dtTableHeder = dt.DefaultView.ToTable(true, "SessionID");
                for (int i = 0; i < dtTableHeder.Rows.Count; i++)
                {
                    CreadeRowColumMainTable(ReportString);


                    //ReportString.Append(xmllanguage.Tables[Session["LANG"].ToString().ToLower()].Rows[0]["Session"].ToString()+" : "+dtTableHeder.Rows[i]["SessionID"].ToString());
                    ReportString.Append(xmllanguage.Tables[Session["Varnindra"].ToString().ToLower()].Rows[0]["Session"].ToString() + " : " + dtTableHeder.Rows[i]["SessionID"].ToString());
                    CloseTDTR(ReportString);

                    OpenTDTR(ReportString);
                    DataView dv1 = dt.DefaultView;
                    dv1.RowFilter = " SessionID = '" + dtTableHeder.Rows[i]["SessionID"].ToString() + "'";
                    DataTable dtNew = dv1.ToTable();




                    ReportString.Append("<table class=\"GridViewCss\" cellspacing=\"2\" cellpadding=\"2\" border=\"1\" style=\"border-width:1px;border-style:None;width:100%;\" rules=\"all\">");

                    ReportString.Append("<tr class=\"GridViewHeadercss\">");



                    for (int j = 0; j < dtNew.Columns.Count; j++)
                    {
                        if (HiddenFields != null)
                        {

                            foreach (string s in HiddenFields)
                            {
                                if (dtNew.Columns[j].ToString().ToLower() != s.ToLower())
                                {
                                    string Columen = dtNew.Columns[j].ToString().Trim().Replace(" ", "");
                                    string str = xmllanguage.Tables[Session["Varnindra"].ToString().ToLower()].Rows[0][Columen].ToString();
                                    ReportString.Append("<th scope=\"col\">" + str + "</th>");

                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                    ReportString.Append("</tr>");
                    for (int ij = 0; ij < dtNew.Rows.Count; ij++)
                    {
                        ReportString.Append("<tr class=\"GridViewItem\">");
                        for (int ro = 0; ro < dtNew.Columns.Count; ro++)
                        {
                            if (HiddenFields != null)
                            {

                                foreach (string s in HiddenFields)
                                {
                                    if (dtNew.Columns[ro].ToString().ToLower() != s.ToLower())
                                    {
                                        ReportString.Append("<td>" + dtNew.Rows[ij][ro].ToString() + "</td>"); break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        ReportString.Append("</tr>");
                    }
                    ReportString.Append("</table>");

                    CloseRowColumnMainTable(ReportString);

                }

                div1.InnerHtml = ReportString.ToString();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show("" + ex.Message.ToString());
        }
    }
    /// <summary>
    /// Get all the hiddent field column names
    /// </summary>
    /// <returns>List of hidden columns  </returns>
    public List<string> GetHiddenFields()
    {
        try
        {
            List<string> HD = new List<string>();
            string strHiddenFields = GetXMLElementByTagName("HiddenFields");
            string[] str = SplitString(strHiddenFields, ",", ", ", " ,", " , ");
            foreach (string s in str)
            {
                HD.Add(s.Trim());
            }
            return HD;
        }
        catch (Exception ex)
        {
            WebMsg.Show("Error in getting the hidden field" + ex.Message.ToString());

            return null;
        }
    }
    /// <summary>
    /// Get elements from XML file and return value to that XML tag
    /// </summary>
    /// <param name="strTagName"></param>
    /// <returns>Returns value of tag</returns>



    public string GetXMLElementByTagName(string strTagName)
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("../ReportXMLFiles/TeacherTrackRPTEmpWiseBMSSCT.xml"));
            XmlNodeList list = doc.GetElementsByTagName(strTagName);
            return list.Item(0).InnerText.Trim().ToLower();

        }
        catch (Exception ex)
        {
            WebMsg.Show("Error in getting the xml element by tag name" + ex.Message.ToString());

            return string.Empty;
        }
    }

    /// <summary>
    /// Split the given string
    /// </summary>
    /// <param name="strsplit">string to split</param>
    /// <param name="Seperator">Seperator from which string will split</param>
    /// <returns>String array of seperated string </returns>

    public string[] SplitString(string strsplit, params string[] Seperator)
    {

        return (strsplit.Split(Seperator, StringSplitOptions.RemoveEmptyEntries));
    }
    private static void OpenTDTR(StringBuilder ReportString)
    {
        ReportString.Append("<tr>");

        ReportString.Append("<td align=\"Center\">");
    }

    private static void CloseTDTR(StringBuilder ReportString)
    {
        ReportString.Append("</td>");

        ReportString.Append("</tr>");
    }

    private static void CloseRowColumnMainTable(StringBuilder ReportString)
    {
        ReportString.Append("</td>");

        ReportString.Append("</tr>");

        ReportString.Append("</table>");
    }

    private static void CreadeRowColumMainTable(StringBuilder ReportString)
    {
        ReportString.Append("<table style=\"text-align: center;\" width=\"100%\" class=\"tblControls\">");

        ReportString.Append("<tr>");

        ReportString.Append("<td align=\"Center\">");
    }

    public void Displayselecteddata(Hashtable hashtable, object objsender)
    {
        if (ReportControl1.Visible == true)
        {
            ReportControl1.Visible = false;
            ReportControl2.Visible = true;
            FirstRpt.Visible = true;
            secondRpt.Visible = true;
            btnback.Visible = true;

            slblSchoolValue.Text = ddlSchool.SelectedItem.Text;
            slblTeacherValue.Text = hashtable["Teacher"].ToString();
            //slblDurationValue.Text = hashtable["\r\nTotal Activity Duration"].ToString();
            slblDurationValue.Text = hashtable["Total Activity Duration"].ToString();
            slblDateValue.Text = hashtable["ActivityDate"].ToString();

            obj_TracklogRPT = new TrackLogRPT_BLogic();

            DataSet dsResult = obj_TracklogRPT.BAL_Select_TeacherWiseBMSSCTWiseBYEmpIDTrackLog(Convert.ToInt32(hashtable["EmployeeID"].ToString()), Convert.ToDateTime(hashtable["ActivityDate"].ToString()));

            if (dsResult.Tables.Count > 0)
            {
                CommanCallUserControl(dsResult.Tables[0], "../ReportXMLFiles/TeacherTrackRPTEmpWise.xml", 2);
            }
            else
            {
                WebMsg.Show("No data found.");
            }
        }
        else if (ReportControl2.Visible == true)
        {
            ReportControl2.Visible = false;
            div1.Visible = true;
            secondRpt.Visible = false;
            thirdRpt.Visible = true;
            tlblSchoolValue.Text = slblSchoolValue.Text;
            tlblTeacherValue.Text = slblTeacherValue.Text;
            tlblDurationValue.Text = hashtable["Total Activity Duration"].ToString();
            tlblDateValue.Text = slblDateValue.Text;

            string BMSString = hashtable["BMS_SCT"].ToString();
            string[] lines = Regex.Split(BMSString, "&gt;&gt;");
            tlblboardValue.Text = lines[0];
            tlblmediumValue.Text = lines[1];
            tlblStandardValue.Text = lines[2];
            tlblSubjectValue.Text = lines[3];
            tlblChapterValue.Text = lines[4];
            tlblTopicValue.Text = lines[5];


            obj_TracklogRPT = new TrackLogRPT_BLogic();

            DataSet dsResult = obj_TracklogRPT.BAL_Select_TeacherWiseBMSSCTWiseBYEmpIDBMSSCTIDTrackLog(Convert.ToInt32(hashtable["BMSSCTID"].ToString()), Convert.ToInt32(hashtable["DivisionID"].ToString()), Convert.ToInt32(hashtable["EmployeeID"].ToString()), Convert.ToDateTime(hashtable["ActivityDate"].ToString()));

            if (dsResult.Tables.Count > 0)
            {
                CommanCallUserControl(dsResult.Tables[0], "../ReportXMLFiles/TeacherTrackRPTEmpWiseBMSSCT.xml", 3);
            }
            else
            {
                WebMsg.Show("No data found.");
            }
        }

    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        if (ReportControl1.Visible)
        {
            btnback.Visible = false;
        }
        else if (ReportControl2.Visible)
        {
            ReportControl2.Visible = false;
            ReportControl1.Visible = true;
            btnback.Visible = false;
            secondRpt.Visible = false;
            FirstRpt.Visible = true;
        }
        else if (div1.Visible)
        {
            div1.Visible = false;
            ReportControl2.Visible = true;
            btnback.Visible = true;
            thirdRpt.Visible = false;
            secondRpt.Visible = true;

        }
    }
}