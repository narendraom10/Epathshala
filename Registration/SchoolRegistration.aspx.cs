/// <DevelopedBy>"NarendraSinh Vaghela"</DevelopedBy>
/// <UpdatedBy>"Arpit Patel","Sheel Thakur"</UpdatedBy>
/// <Date>15-October-2013</Date>
/// </summary>
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Globalization;
using Udev.UserMasterPage.Classes;

public partial class Registration_SchoolRegistration : System.Web.UI.Page
{

    #region "Declaration"

    SYS_Country_BLogic BLCountry = new SYS_Country_BLogic();
    SYS_State_BLogic BLState = new SYS_State_BLogic();
    SYS_District_BLogic BLDistrict = new SYS_District_BLogic();
    SYS_Board_BLogic BLBoard = new SYS_Board_BLogic();
    SYS_Medium_BLogic BlMedium = new SYS_Medium_BLogic();
    SYS_Standard_BLogic BStandard = new SYS_Standard_BLogic();
    SYS_SchoolType_BLogic BSchoolType = new SYS_SchoolType_BLogic();
    School_BLogic BSchoolBlogic = new School_BLogic();
    SYS_BMS_BLogic BBMS = new SYS_BMS_BLogic();
    SYS_Country PCountry = new SYS_Country();
    SYS_State PState = new SYS_State();
    SYS_District PDistrict = new SYS_District();
    SYS_Board PBoard = new SYS_Board();
    SYS_Medium PMedium = new SYS_Medium();
    School PSchool = new School();
    #endregion

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }

    #region "Page Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GetCoutries();
                GetBoards();
                GetSChoolTypes();
            }
        }
        catch (Exception)
        {

        }
    }

    #endregion

    #region "Control Events"
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            fsSchoolInfo.Visible = true;
            fsSchoolGeneralInfo.Visible = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            fsSchoolInfo.Visible = false;
            fsSchoolGeneralInfo.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region "User Defined Functions"

    protected void GetCoutries()
    {
        try
        {
            DataSet dsCountries = new DataSet();
            PCountry.countryid = ((int)EnumFile.AssignValue.Zero);
            dsCountries = BLCountry.BAL_SYS_Country_Select(PCountry, "Select");
            ddlCountry.DataSource = dsCountries;
            ddlCountry.DataTextField = dsCountries.Tables[0].Columns["Country"].ToString();
            ddlCountry.DataValueField = dsCountries.Tables[0].Columns["CountryID"].ToString();
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
            ddlCountry.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
        }
        catch (Exception)
        {

        }
    }

    protected void GetState()
    {
        try
        {
            DataSet dsState = new DataSet();
            PState.stateid = ((int)EnumFile.AssignValue.Zero);
            dsState = BLState.BAL_SYS_State_Select(PState, "Select");
            ddlState.DataSource = dsState;
            ddlState.DataTextField = dsState.Tables[0].Columns["State"].ToString();
            ddlState.DataValueField = dsState.Tables[0].Columns["StateID"].ToString();
            ddlState.DataBind();
            ddlState.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
            ddlState.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
        }
        catch (Exception)
        {

        }
    }

    protected void GetDistrict()
    {
        try
        {
            DataSet dsDistrict = new DataSet();
            PDistrict.districtid = ((int)EnumFile.AssignValue.Zero);
            dsDistrict = BLDistrict.BAL_SYS_District_Select(PDistrict, "Select");
            ddlDistrict.DataSource = dsDistrict;
            ddlDistrict.DataTextField = dsDistrict.Tables[0].Columns["District"].ToString();
            ddlDistrict.DataValueField = dsDistrict.Tables[0].Columns["DistrictID"].ToString();
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
            ddlDistrict.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
        }
        catch (Exception)
        {

        }
    }

    protected void GetBoards()
    {
        try
        {
            DataSet dsBoards = new DataSet();
            PBoard.boardid = ((int)EnumFile.AssignValue.Zero);
            dsBoards = BLBoard.BAL_SYS_Board_Select(PBoard, "Select");
            ddlBoard.DataSource = dsBoards;
            ddlBoard.DataTextField = dsBoards.Tables[0].Columns["Board"].ToString();
            ddlBoard.DataValueField = dsBoards.Tables[0].Columns["BoardID"].ToString();
            ddlBoard.DataBind();
            ddlBoard.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
            ddlBoard.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
        }
        catch (Exception)
        {

        }
    }

    protected void GetMediums()
    {
        try
        {
            DataSet dsMedium = new DataSet();
            PMedium.mediumid = ((int)EnumFile.AssignValue.Zero);
            dsMedium = BlMedium.BAL_SYS_Medium_Select(PMedium, "Select");
            ddlMedium.DataSource = dsMedium;
            ddlMedium.DataTextField = dsMedium.Tables[0].Columns["Medium"].ToString();
            ddlMedium.DataValueField = dsMedium.Tables[0].Columns["MediumID"].ToString();
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
            ddlMedium.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
        }
        catch (Exception)
        {

        }
    }

    protected void GetSChoolTypes()
    {
        try
        {
            ddlSchlType.Items.Clear();
            BSchoolType.BindList(ddlSchlType, "Select");
        }
        catch (Exception)
        {

        }
    }
    #endregion

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCountry.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlState.Items.Clear();
                BLState.BindListByID(ddlState, "ByCountryID", int.Parse(ddlCountry.SelectedValue));
                ddlState.Enabled = true;
            }
            else if (ddlCountry.SelectedValue == ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlState.Items.Clear();
                ddlState.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
                ddlState.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlState.Enabled = false;
                ddlDistrict.Items.Clear();
                ddlDistrict.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
                ddlDistrict.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlDistrict.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlState.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlDistrict.Items.Clear();
                BLDistrict.BindListByID(ddlDistrict, "ByStateID", int.Parse(ddlState.SelectedValue));
                ddlDistrict.Enabled = true;
            }
            else if (ddlState.SelectedValue == ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlDistrict.Items.Clear();
                ddlDistrict.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
                ddlDistrict.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlDistrict.Enabled = false;
            }
        }
        catch (Exception)
        {

        }
    }

    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlBoard.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlMedium.Items.Clear();
                BlMedium.BindMediumByBoardID(ddlMedium, "GetMediumByBoardID", int.Parse(ddlBoard.SelectedValue));
                ddlMedium.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlMedium.Enabled = true;
                clstStandardList.Items.Clear();
            }
            else if (ddlBoard.SelectedValue == ((int)EnumFile.AssignValue.Zero).ToString())
            {
                ddlMedium.Items.Clear();
                ddlMedium.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
                ddlMedium.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
                ddlMedium.Enabled = false;
                clstStandardList.Items.Clear();
            }
        }
        catch (Exception)
        {

        }
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlMedium.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
            {
                clstStandardList.Items.Clear();
                //BStandard.BindListByID(GvStandards, "GetStandardByBoardMediumID", int.Parse(DdlBoard.SelectedValue), int.Parse(DdlMedium.SelectedValue));
                BStandard.BindListByID(dlStandard, "GetStandardByBoardMediumID", int.Parse(ddlBoard.SelectedValue), int.Parse(ddlMedium.SelectedValue));
            }
            else if (ddlMedium.SelectedValue == ((int)EnumFile.AssignValue.Zero).ToString())
            {
                clstStandardList.Items.Clear();
            }
        }
        catch (Exception)
        {

        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtTempSchoolInfo = new DataTable();
            int j = 0;
            int DataTableID = 1;

            if (ViewState["TempSchoolInfo"] == null)
            {
                dtTempSchoolInfo.Columns.Add("ID");
                dtTempSchoolInfo.Columns.Add("Board");
                dtTempSchoolInfo.Columns.Add("BoardID");
                dtTempSchoolInfo.Columns.Add("Medium");
                dtTempSchoolInfo.Columns.Add("MediumID");
                dtTempSchoolInfo.Columns.Add("Standard");
                dtTempSchoolInfo.Columns.Add("StandardID");
                dtTempSchoolInfo.Columns.Add("SchoolType");
                dtTempSchoolInfo.Columns.Add("SchoolTypeID");
                dtTempSchoolInfo.Columns.Add("StartTime");
                dtTempSchoolInfo.Columns.Add("EndTime");
                dtTempSchoolInfo.Columns.Add("BMSID");
                dtTempSchoolInfo.Columns.Add("Students");
            }
            else
            {

                dtTempSchoolInfo = (DataTable)ViewState["TempSchoolInfo"];
                j = dtTempSchoolInfo.Rows.Count;
                DataTableID = dtTempSchoolInfo.Rows.Count + 1;
            }

            foreach (DataListItem Item in dlStandard.Items)
            {
                CheckBox Chk = (CheckBox)Item.FindControl("chkStandard");
                if (Chk.Checked == true)
                {
                    TextBox tx = (TextBox)Item.FindControl("txtSemister");
                    int student = ((int)EnumFile.AssignValue.Zero);
                    if (tx.Text != string.Empty)
                    {
                        student = int.Parse(tx.Text);
                    }

                    Label lbStdId = (Label)Item.FindControl("lblStdId");
                    string StdID = lbStdId.Text;
                    DataView dv = new DataView();
                    if (dtTempSchoolInfo.Rows.Count > ((int)EnumFile.AssignValue.Zero))
                    {
                        dv = new DataView(dtTempSchoolInfo);
                        dv.RowFilter = "BoardID = " + ddlBoard.SelectedValue + " and MediumID=" + ddlMedium.SelectedValue + " and StandardID=" + StdID;
                    }
                    if (dv.Count == ((int)EnumFile.AssignValue.Zero))
                    {
                        Label lb = (Label)Item.FindControl("lblStandard");
                        string Std = lb.Text;
                        dtTempSchoolInfo.Rows.Add();
                        dtTempSchoolInfo.Rows[j]["ID"] = DataTableID;
                        dtTempSchoolInfo.Rows[j]["BoardID"] = int.Parse(ddlBoard.SelectedValue);
                        dtTempSchoolInfo.Rows[j]["Board"] = ddlBoard.SelectedItem.Text;
                        dtTempSchoolInfo.Rows[j]["MediumID"] = int.Parse(ddlMedium.SelectedValue);
                        dtTempSchoolInfo.Rows[j]["Medium"] = ddlMedium.SelectedItem.Text;
                        dtTempSchoolInfo.Rows[j]["StandardID"] = StdID;
                        dtTempSchoolInfo.Rows[j]["Standard"] = Std;
                        dtTempSchoolInfo.Rows[j]["SchoolType"] = ddlSchlType.SelectedItem.Text;
                        dtTempSchoolInfo.Rows[j]["SchoolTypeID"] = int.Parse(ddlSchlType.SelectedValue);
                        dtTempSchoolInfo.Rows[j]["StartTime"] = txtStartTimeHH.Text + ":" + txtStartTimeMM.Text + int.Parse(ddlStartTime.SelectedValue);
                        dtTempSchoolInfo.Rows[j]["EndTime"] = txtEndTimeHH.Text + ":" + txtEndTimeMM.Text + int.Parse(ddlEndTime.SelectedValue);
                        dtTempSchoolInfo.Rows[j]["Students"] = student;
                        j = j + 1;
                        DataTableID = DataTableID + 1;
                    }
                }
            }

            if (dtTempSchoolInfo.Rows.Count > 0 && dtTempSchoolInfo != null)
            {
                gvSchoolInfo.DataSource = dtTempSchoolInfo;
                gvSchoolInfo.DataBind();
            }

            ViewState["TempSchoolInfo"] = dtTempSchoolInfo;
            this.ClearSchoolInfo();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtSchInfo = new DataTable("SchoolInfo");
            if (ViewState["TempSchoolInfo"] != null)
            {
                dtSchInfo = (DataTable)ViewState["TempSchoolInfo"];

                if (dtSchInfo.Rows.Count > 0 && dtSchInfo != null)
                {
                    for (int i = 0; i < dtSchInfo.Rows.Count; i++)
                    {
                        DataSet dsBMS = new DataSet();
                        dsBMS = BBMS.GetDataByBoardMediumStandard(int.Parse(dtSchInfo.Rows[i]["BoardID"].ToString()), int.Parse(dtSchInfo.Rows[i]["MediumID"].ToString()), int.Parse(dtSchInfo.Rows[i]["StandardID"].ToString()), "SelectByBoardMediumStd");
                        dtSchInfo.Rows[i]["BMSID"] = int.Parse(dsBMS.Tables[0].Rows[0]["BMSID"].ToString());
                    }
                }

                String xmldata;
                StringWriter sw = new StringWriter();
                dtSchInfo.WriteXml(sw);
                xmldata = sw.ToString();

                PSchool.name = txtSchName.Text;
                PSchool.address = txtAddress.Text;
                PSchool.ploteno = txtPloatNo.Text;
                PSchool.blockno = txtBlockNoSurvey.Text;
                PSchool.countryid = int.Parse(ddlCountry.SelectedValue);
                PSchool.stateid = int.Parse(ddlState.SelectedValue);
                PSchool.districtid = int.Parse(ddlDistrict.SelectedValue);
                PSchool.city = txtCity.Text;
                if (txtMobileNo.Text != "")
                {
                    PSchool.mobileno = Int64.Parse(txtMobileNo.Text);
                }
                if (txtLandline.Text != string.Empty)
                {
                    PSchool.landlineno = Int64.Parse(txtLandline.Text);
                }

                if (txtPincode.Text != string.Empty)
                {
                    PSchool.pincode = Int64.Parse(txtPincode.Text);
                }
                if (txtFaxNo.Text != string.Empty)
                {
                    PSchool.faxno = Int64.Parse(txtFaxNo.Text);
                }
                PSchool.schoolstartyear = txtSchoolStartyear.Text;
                PSchool.emailid = txtSchlMailID.Text;
                PSchool.websiteurl = txtSchlWebsite.Text;
                PSchool.schoolregbms = xmldata;
                PSchool.createdby = 1;
                PSchool.comment = "";

                BSchoolBlogic.BAL_School_Insert(PSchool, "Insert");
                ClearControls();
                Response.Redirect("~/SchoolManagement/SchoolList.aspx");
            }
            else
            {
                lblStatus.Text = "Please add the above details first";
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        this.ClearSchoolInfo();
    }

    protected void ClearSchoolInfo()
    {
        ddlSchlType.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlBoard.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlMedium.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlMedium.Enabled = false;
        txtStartTimeHH.Text = string.Empty;
        txtStartTimeMM.Text = string.Empty;
        txtEndTimeHH.Text = string.Empty;
        txtEndTimeMM.Text = string.Empty;
        dlStandard.DataSource = null;
        dlStandard.DataBind();
    }

    protected void ClearControls()
    {
        txtSchName.Text = string.Empty;
        txtAddress.Text = string.Empty;
        txtBlockNoSurvey.Text = string.Empty;
        txtPloatNo.Text = string.Empty;
        ddlCountry.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlState.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlState.Enabled = false;
        ddlDistrict.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlDistrict.Enabled = false;
        txtCity.Text = string.Empty;
        txtPincode.Text = string.Empty;
        txtLandline.Text = string.Empty;
        txtMobileNo.Text = string.Empty;
        txtFaxNo.Text = string.Empty;
        txtSchoolStartyear.Text = string.Empty;
        txtSchlMailID.Text = string.Empty;
        txtSchlWebsite.Text = string.Empty;
        ddlSchlType.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlBoard.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlMedium.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlMedium.Enabled = false;
        txtStartTimeHH.Text = string.Empty;
        txtStartTimeMM.Text = string.Empty;
        txtEndTimeHH.Text = string.Empty;
        txtEndTimeMM.Text = string.Empty;
        dlStandard.DataSource = null;
        dlStandard.DataBind();
        fsSchoolInfo.Visible = false;
        fsSchoolGeneralInfo.Visible = true;
        lblStatus.Text = string.Empty;
    }

    //protected void GvStandards_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    //try
    //    //{
    //    //    ArrayList AlistStudents;
    //    //    ArrayList AlistStdID;
    //    //    if (ViewState["AlistStdID"] == null)
    //    //    {
    //    //        AlistStdID = new ArrayList();
    //    //    }
    //    //    else
    //    //    {
    //    //        AlistStdID = (ArrayList)ViewState["AlistStdID"];
    //    //    }

    //    //    if (ViewState["AlistStudents"] == null)
    //    //    {
    //    //        AlistStudents = new ArrayList();
    //    //    }
    //    //    else
    //    //    {
    //    //        AlistStudents = (ArrayList)ViewState["AlistStudents"];
    //    //    }


    //    //    foreach (GridViewRow gr in GvStandards.Rows)
    //    //    {

    //    //        CheckBox Chk = (CheckBox)gr.FindControl("ChkStandard");
    //    //        if (Chk.Checked == true)
    //    //        {
    //    //            AlistStdID.Add(GvStandards.Rows[gr.RowIndex].Cells[0].Text);
    //    //            TextBox tx = (TextBox)gr.FindControl("TxtStudents");
    //    //            AlistStudents.Add(tx.Text);
    //    //        }
    //    //    }

    //    //    ViewState["AlistStdID"] = AlistStdID;
    //    //    ViewState["AlistStudents"] = AlistStudents;

    //    //    GvStandards.PageIndex = e.NewPageIndex;
    //    //    BStandard.BindListByID(GvStandards, "GetStandardByBoardMediumID", int.Parse(DdlBoard.SelectedValue), int.Parse(DdlMedium.SelectedValue));

    //    //    foreach (GridViewRow gr in GvStandards.Rows)
    //    //    {

    //    //        for (int i = 0; i < AlistStdID.Count; i++)
    //    //        {
    //    //            if (AlistStdID[i].ToString() == GvStandards.Rows[gr.RowIndex].Cells[0].Text)
    //    //            {
    //    //                  CheckBox Chk = (CheckBox)gr.FindControl("ChkStandard");
    //    //                  Chk.Checked = true;
    //    //                  TextBox tx = (TextBox)gr.FindControl("TxtStudents");
    //    //                  tx.Text = AlistStudents[i].ToString();
    //    //            }
    //    //        }
    //    //    }
    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    WebMsg.Show(ex.Message);
    //    //}
    //}
    protected void GvSchoolInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // int Row=
        string ID = e.CommandArgument.ToString();
        DataTable dtDelete = new DataTable();
        dtDelete = (DataTable)ViewState["TempSchoolInfo"];
        if (dtDelete != null)
        {
            foreach (DataRow dr in dtDelete.Rows)
            {
                if (dr["ID"].ToString() == ID)
                {
                    dr.Delete();
                    break;
                }
            }
            dtDelete.AcceptChanges();
        }

        ViewState["TempSchoolInfo"] = dtDelete;

        gvSchoolInfo.DataSource = dtDelete;
        gvSchoolInfo.DataBind();

    }

    protected void gvSchoolInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["TempSchoolInfo"];

        gvSchoolInfo.PageIndex = e.NewPageIndex;
        gvSchoolInfo.DataSource = dt;
        gvSchoolInfo.DataBind();
    }
}