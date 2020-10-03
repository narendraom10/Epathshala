/// <DevelopedBy>"Arpit Patel"</DevelopedBy>
/// <UpdatedBy>"Arpit Patel"</UpdatedBy>
/// <Date>28-October-2013</Date>
/// </summary>

using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;
using System.Net;


public partial class Teacher_StudentAttendance : System.Web.UI.Page
{
    #region "Declarations"
    SYS_Attendance_BLogic BSysAttendance = new SYS_Attendance_BLogic();
    SYS_Attendance PSysAttendance = new SYS_Attendance();
    SYS_BMS_BLogic BSysBMS = new SYS_BMS_BLogic();
    SYS_BMS PSysBMS = new SYS_BMS();
    SYS_Board_BLogic BLBoard = new SYS_Board_BLogic();
    SYS_Board PBoard = new SYS_Board();
    SYS_Medium_BLogic BlMedium = new SYS_Medium_BLogic();
    SYS_Standard_BLogic BStandard = new SYS_Standard_BLogic();
    SYS_Medium PMedium = new SYS_Medium();
    DropDownFill DFill = new DropDownFill();
    SYS_Division_BLogic BSysDivision = new SYS_Division_BLogic();
    SYS_Division PSysDivision = new SYS_Division();
    string AttendancePer = string.Empty;
    #endregion

    # region Properties
    # endregion

    #region "PageEvents"
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
            ViewState["SchoolID"] = AppSessions.SchoolID;
            ViewState["EmployeeID"] = AppSessions.EmpolyeeID;
            ViewState["RoleID"] = AppSessions.RoleID;
            if (ViewState["RoleID"].ToString() == Convert.ToString((int)EnumFile.Role.Teacher))
            {
                PnlAdminCriteria.Visible = false;
                PnlStandardDetails.Visible = true;
                ddlSorting.Enabled = true;
                ViewState["StandardID"] = AppSessions.StandardID;
                ViewState["DivisionID"] = AppSessions.DivisionID;
                ViewState["BMSID"] = AppSessions.BMSID;
                ViewState["BMSSDNameEduResource"] = AppSessions.BMS;
                lblBMSDesc.Text = ViewState["BMSSDNameEduResource"].ToString();
                this.BindGridData();
            }
            else
            {
                PnlAdminCriteria.Visible = true;
                PnlStandardDetails.Visible = false;
                this.GetBMS();
                txtDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            }

            lblAttendanceDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
        }
    }
    protected void GetBMS()
    {
        DropDownFill DdlFilling = new DropDownFill();
        DataSet dsBMS = new DataSet();
        dsBMS = BSysBMS.BAL_SYS_BMS_SelectAllBySchoolID(Convert.ToInt64(ViewState["SchoolID"]));
        if (dsBMS.Tables[0].Rows.Count > 0)
        {
            DdlFilling.BindDropDownByTable(ddlBMS, dsBMS.Tables[0], "BMS", "BMSID");
            ddlBMS.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlBMS.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlBMS.Enabled = true;
        }
    }
    #endregion

    #region "Control Events"

    protected void ddlSorting_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindGridData();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        this.ClearControls();
    }
    protected void ClearControls()
    {
        ddlBMS.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlDivision.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlDivision.Enabled = false;
        txtDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
        lblAttendanceDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
        DlStudentAttendance.DataSource = null;
        DlStudentAttendance.DataBind();
        ddlSorting.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlSorting.Enabled = false;
        AttendancePer = string.Empty;
        BtnFillAttedance.Enabled = false;
        lblPresentPerVal.Text = string.Empty;
        lblPresentPer.Width = ((int)EnumFile.AssignValue.Zero);
        lblAbsentPerVal.Text = string.Empty;
        lblAbsentPer.Width = ((int)EnumFile.AssignValue.Zero);
    }

    protected void ddlBMS_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBMS.SelectedValue != Convert.ToString((int)EnumFile.AssignValue.Zero))
        {
            ddlDivision.Items.Clear();
            DFill.BindDropDownByDynamic(ddlDivision, "SYS_Division", "Division", "DivisionID", "");
            ddlDivision.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlDivision.Enabled = true;
            ClearControlsForDDL();
        }
        else if (ddlBMS.SelectedValue == Convert.ToString((int)EnumFile.AssignValue.Zero))
        {
            ddlDivision.Items.Clear();
            ddlDivision.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlDivision.Enabled = false;
            ClearControlsForDDL();
        }
    }
    protected void ClearControlsForDDL()
    {
        try
        {
            txtDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            lblAttendanceDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            DlStudentAttendance.DataSource = null;
            DlStudentAttendance.DataBind();
            ddlSorting.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
            ddlSorting.Enabled = false;
            AttendancePer = string.Empty;
            BtnFillAttedance.Enabled = false;
            lblPresentPerVal.Text = string.Empty;
            lblPresentPer.Width = ((int)EnumFile.AssignValue.Zero);
            lblAbsentPerVal.Text = string.Empty;
            lblAbsentPer.Width = ((int)EnumFile.AssignValue.Zero);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void BtnFillAttedance_Click(object sender, EventArgs e)
    {
        DataTable dtAttendance = new DataTable();
        String xmldata;
        StringWriter sw = new StringWriter();
        try
        {
            dtAttendance = GetAttendanceTable();
            dtAttendance.TableName = "Attendance";
            dtAttendance.WriteXml(sw);
            xmldata = sw.ToString();
            if (ViewState["BMSID"] != null)
            {
                PSysAttendance.BMSID = int.Parse(ViewState["BMSID"].ToString());
            }

            if (ViewState["DivisionID"] != null)
            {
                PSysAttendance.DivisionId = int.Parse(ViewState["DivisionID"].ToString());
            }
            PSysAttendance.EmployeeID = int.Parse(ViewState["EmployeeID"].ToString());
            PSysAttendance.SchoolID = int.Parse(ViewState["SchoolID"].ToString());
            PSysAttendance.AttedanceDetails = xmldata;
            if (ViewState["RoleID"].ToString() == Convert.ToString((int)EnumFile.Role.Teacher))
            {
                BSysAttendance.BAL_StudentAttedance_Insert(PSysAttendance, "Insert");
            }
            else
            {
                PSysAttendance.AttendanceDate = Convert.ToDateTime(txtDate.Text);
                BSysAttendance.BAL_StudentAttedance_Admin_Update(PSysAttendance, "Insert");
            }

            this.BindGridData();

            //Send Message Related

            Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
            DataSet dsSettings = new DataSet();
            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("SendSMSToAbsentStudentsParent");

            if (Convert.ToBoolean(dsSettings.Tables[0].Rows[0]["value"].ToString()))
            {
                DataSet ods = BSysAttendance.BAL_SYS_GetAttendaceStudent(PSysAttendance, "Insert");
                DataTable dt = new DataTable();
                dt.Columns.Add("StudentID", typeof(string));
                dt.Columns.Add("MessageStatus", typeof(string));
                dt.Columns.Add("MessageResponse", typeof(string));
                foreach (DataRow odr in ods.Tables[0].Rows)
                {
                    bool SendStatus = false;
                    string strresponse = string.Empty;
                    SendStatus = SendSMS(Convert.ToString(odr["SentOnNumber"]), Convert.ToString(odr["SentMessage"]), ref strresponse);
                    if (SendStatus)
                        dt.Rows.Add(Convert.ToString(odr["StudentID"]), "Sent", strresponse);
                    else
                        dt.Rows.Add(Convert.ToString(odr["StudentID"]), "Not Sent", strresponse);
                }


                String xmldt;
                StringWriter swdt = new StringWriter();
                dt.TableName = "StatusUpdate";
                dt.WriteXml(swdt);
                xmldt = swdt.ToString();
                BSysAttendance.BAL_SYS_UpdateMessageStatus(xmldt);
            }
            //End Message
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "MessageAttendance", "<script> alert('Attendance taken successfully.')</script>", false);
        }
        catch (Exception Ex)
        {
            WebMsg.Show(Ex.Message);
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        BindGridData();
        lblAttendanceDate.Text = txtDate.Text;
    }

    #endregion

    #region "User Defined Functions"

    /// <summary>
    /// Method will be used to bind grid view.
    /// </summary>
    protected void BindGridData()
    {
        try
        {
            DataSet dsGrid = new DataSet();
            DateTime Date;
            if (ddlSorting.SelectedItem.Text == "RollNo")
            {
                PSysAttendance.SortBy = "S.RollNo";
            }
            else
            {
                PSysAttendance.SortBy = "Student";
            }

            if (ViewState["RoleID"].ToString() == Convert.ToString((int)EnumFile.Role.Teacher))
            {
                PSysAttendance.SchoolID = int.Parse(ViewState["SchoolID"].ToString());
                PSysAttendance.EmployeeID = int.Parse(ViewState["EmployeeID"].ToString());
                PSysAttendance.StandardID = int.Parse(ViewState["StandardID"].ToString());
                PSysAttendance.DivisionId = int.Parse(ViewState["DivisionID"].ToString());
                PSysAttendance.BMSID = int.Parse(ViewState["BMSID"].ToString());
                dsGrid = BSysAttendance.BAL_SYS_Attendance_TeacherWiseStudents(PSysAttendance, "GetStudents");
            }
            else
            {
                Date = Convert.ToDateTime(txtDate.Text);
                ViewState["BMSID"] = int.Parse(ddlBMS.SelectedValue);
                ViewState["DivisionID"] = int.Parse(ddlDivision.SelectedValue);
                PSysAttendance.BMSID = int.Parse(ViewState["BMSID"].ToString());
                PSysAttendance.DivisionId = int.Parse(ViewState["DivisionID"].ToString());
                PSysAttendance.SchoolID = int.Parse(ViewState["SchoolID"].ToString());
                PSysAttendance.EmployeeID = int.Parse(ViewState["EmployeeID"].ToString());
                PSysAttendance.AttendanceDate = Date;
                dsGrid = BSysAttendance.BAL_SYS_Attendance_Students(PSysAttendance, "GetStudents");
            }


            if (dsGrid.Tables[0].Rows.Count > Convert.ToInt32(EnumFile.AssignValue.Zero) && dsGrid.Tables[0] != null)
            {
                int Absent;
                BtnFillAttedance.Enabled = true;
                ddlSorting.Enabled = true;
                DlStudentAttendance.DataSource = dsGrid;
                DlStudentAttendance.DataBind();
                AttendancePer = dsGrid.Tables[0].Rows[0]["TotalAttendance"].ToString();
                if (AttendancePer != string.Empty)
                {
                    lblPresentPer.Width = (int.Parse(AttendancePer) * 2);
                    lblAbsentPer.Width = ((100 - int.Parse(AttendancePer)) * 2);

                    if (Convert.ToInt32(AttendancePer.ToString()) != 0)
                    {
                        lblPresentPerVal.Text = AttendancePer + "%";
                        lblPval.Text = AttendancePer + "%";
                    }
                    else
                    {
                        lblPresentPerVal.Text = string.Empty;
                        lblPval.Text = string.Empty;
                    }

                    Absent = 100 - int.Parse(AttendancePer);

                    if (Absent != 0)
                    {
                        lblAbsentPerVal.Text = ((100 - int.Parse(AttendancePer))).ToString() + "%";
                        lblAval.Text = ((100 - int.Parse(AttendancePer))).ToString() + "%";
                    }
                    else
                    {
                        lblAbsentPerVal.Text = string.Empty;
                        lblAval.Text = string.Empty;
                    }
                }
                else
                {
                    lblPresentPer.Width = 0;
                    lblAbsentPer.Width = 0;
                }
            }

        }
        catch (Exception Ex)
        {
            WebMsg.Show(Ex.Message);
        }
    }

    /// <summary>
    /// Method will be used to retrive details of absent students in datatable.
    /// </summary>
    /// <returns>Data Table</returns>
    protected DataTable GetAttendanceTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Student");
        dt.Columns.Add("StudentID");
        dt.Columns.Add("AttendanceID");
        dt.Columns.Add("ASID");

        int j = Convert.ToInt32(EnumFile.AssignValue.Zero);
        int StudentID = Convert.ToInt32(EnumFile.AssignValue.Zero);
        string StudentName = string.Empty;
        int AttendanceID = Convert.ToInt32(EnumFile.AssignValue.Zero);
        int ASID = Convert.ToInt32(EnumFile.AssignValue.Zero);
        foreach (DataListItem dl in DlStudentAttendance.Items)
        {

            CheckBox chk = (CheckBox)dl.FindControl("ChkAttendance");
            if (chk.Checked == false)
            {

                Label LbStudentId = (Label)dl.FindControl("LblStudentID");
                if (LbStudentId.Text != string.Empty && LbStudentId.Text != Convert.ToString((int)EnumFile.AssignValue.Zero))
                {
                    StudentID = int.Parse(LbStudentId.Text);
                }

                Label LblStudent = (Label)dl.FindControl("LblStudentName");
                StudentName = LblStudent.Text;

                Label LblAttendanceID = (Label)dl.FindControl("LblAttendanceID");
                if (LblAttendanceID.Text != string.Empty)
                {
                    AttendanceID = int.Parse(LblAttendanceID.Text);
                }

                Label LblASID = (Label)dl.FindControl("LblASID");
                if (LblASID.Text != string.Empty)
                {
                    ASID = int.Parse(LblASID.Text);
                }

                dt.Rows.Add();
                dt.Rows[j]["StudentID"] = StudentID;
                dt.Rows[j]["Student"] = StudentName;
                dt.Rows[j]["AttendanceID"] = AttendanceID;
                dt.Rows[j]["ASID"] = ASID;
                j = j + 1;
            }
        }

        return dt;
    }

    #endregion

    #region SendMessage
    public bool SendSMS(string Number, string Message, ref string strresponse)
    {
        bool SendStatus = false;
        try
        {
            string url = CreateURL(Number, Message);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string data = reader.ReadToEnd();
            strresponse = data;

            reader.Close();
            stream.Close();
            SendStatus = true;
        }
        catch (Exception e)
        {
            SendStatus = false;
        }
        return SendStatus;
    }
    public string CreateURL(string Number, string Message)
    {
        return "http://dndopen.loyalsmsindia.co.in/api/web2sms.php?workingkey=A0d7b05b976821af4e76c5b909e43316e&to=" + Number + "&sender=EPAATH&message=" + Message + "";

    }
    #endregion

}