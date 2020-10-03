/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Admin_SchoolList : BasePage
{

    #region "Declaration"
    School_BLogic obj_BAL_School;
    School obj_School;
    SYS_Status_BLogic BAL_SYS_Status;
    SYS_Status Prop_SYS_Status;
    #endregion

    //protected override void InitializeCulture()
    //{
    //    string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
    //    // 'set culture to current thread 
    //    System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
    //    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
    //    //call base class 
    //    base.InitializeCulture();
    //}

    # region "Properties"

    string SortDirection
    {
        get
        {
            object o = ViewState["SortDirection"];
            if (o == null)
                return String.Empty;
            else
                return (string)o;
        }
        set
        {
            ViewState["SortDirection"] = value;
        }
    }

    string SortField
    {
        get
        {
            object o = ViewState["SortField"];
            if (o == null)
                return String.Empty;
            else
                return (string)o;
        }
        set
        {
            ViewState["SortField"] = value;
        }
    }
    # endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            bindgrvSYS_Statusdetail();
            bindgrvSchooldetail();
        }
    }
    #endregion

    #region "Control Events"

    protected void gvEmpStdSubAllocationDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(gvSchooldetail, e.Row, this.Page);
        }
    }

    protected void gvEmpStdSubAllocationDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        else
            this.SortDirection = "ascending";


        this.SortField = e.SortExpression;
        bindgrvSchooldetail();

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, gvSchooldetail, this.SortDirection);
    }

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvSchooldetail.PageIndex = ((DropDownList)sender).SelectedIndex;
        bindgrvSchooldetail();
    }

    protected void DdlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrvSchooldetail();
    }

    protected void gvSchooldetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DropDownList DDLSelectPage = (DropDownList)gvSchooldetail.BottomPagerRow.FindControl("ddlPageSelector");
            DDLSelectPage.SelectedIndex = e.NewPageIndex;
            gvSchooldetail.PageIndex = e.NewPageIndex;
            bindgrvSchooldetail();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message.ToString());
        }
    }

    protected void ibtnView_Click(object sender, ImageClickEventArgs e)
    {
        //VisibleInvisible(PnlSearch, true);
        //VisibleInvisible(PnlActDeact, false);
        //VisibleInvisible(PnlRejApp, false);


        //Zero for View Details of classes
        OpenPageInViewAndEditMode(0);
    }

    protected void ibtnApproveSchDetails_Click(object sender, ImageClickEventArgs e)
    {
        VisibleInvisible(pnlSearch, true);

        VisibleInvisible(pnlActDeact, false);
        VisibleInvisible(pnlRejApp, false);


        //One for Edit Details of class
        OpenPageInViewAndEditMode(1);
    }

    protected void ibtnShowUsers_Click(object sender, ImageClickEventArgs e)
    {
        VisibleInvisible(pnlSearch, true);
        //VisibleInvisible(PnlView, false);
        //VisibleInvisible(PnlApprvSchoolDetails, false);
        //VisibleInvisible(PnlShowUser, true);
        //VisibleInvisible(PnlActDeact, false);
        //VisibleInvisible(PnlRejApp, false);
        int CountChecked = Convert.ToInt32(EnumFile.AssignValue.Zero);
        int tmp_SchoolID = Convert.ToInt32(EnumFile.AssignValue.Zero);
        int GridRowIndexVal = Convert.ToInt32(EnumFile.AssignValue.Zero);
        foreach (GridViewRow gr in gvSchooldetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                int StatusID;
                StatusID = Convert.ToInt32(gvSchooldetail.DataKeys[gr.RowIndex]["StatusID"]);
                if (StatusID == Convert.ToInt32(EnumFile.Status.Active) || StatusID == Convert.ToInt32(EnumFile.Status.Deactive))
                {
                    CountChecked = CountChecked + 1;
                    GridRowIndexVal = gr.RowIndex;
                }
            }
        }
        if (CountChecked == Convert.ToInt32(EnumFile.AssignValue.One))
        {

            tmp_SchoolID = Convert.ToInt32(gvSchooldetail.DataKeys[GridRowIndexVal]["SchoolID"]);
            Session["SchoolID"] = tmp_SchoolID;
            Page.RegisterStartupScript("Window", "<script language=\"javascript\">window.open('../UserManagement/UserList.aspx?MenuVisible=False&SchoolID= " + tmp_SchoolID + " ',' ','width=1000,height=760,scrollbars=1,left=1,top=1');</script>");
        }
        else
        {
            if (CountChecked > Convert.ToInt32(EnumFile.AssignValue.One))
            {
                WebMsg.Show("Please select only one record.");
            }
            if (CountChecked == Convert.ToInt32(EnumFile.AssignValue.Zero))
            {
                WebMsg.Show("Please select atleast one record.");
            }
        }

    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {

        RefreshAllPanels();

    }

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        RefreshAllPanels();
        ddlStatus.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        bindgrvSchooldetail();
        txtSchName.Text = string.Empty;
        txtState.Text = string.Empty;
        txtDistrict.Text = string.Empty;
        txtPincode.Text = string.Empty;
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        bindgrvSchooldetail();
    }

    protected void btnActDeactSub_Click(object sender, EventArgs e)
    {
        int CountChecked = Convert.ToInt32(EnumFile.AssignValue.Zero);
        string tmp_SchoolIDStr = string.Empty;
        foreach (GridViewRow gr in gvSchooldetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                int StatusID;
                StatusID = Convert.ToInt32(gvSchooldetail.DataKeys[gr.RowIndex]["StatusID"]);
                if (StatusID == Convert.ToInt32(EnumFile.Status.Active) || StatusID == Convert.ToInt32(EnumFile.Status.Deactive))
                {

                    if (CountChecked == Convert.ToInt32(EnumFile.AssignValue.Zero))
                    {
                        tmp_SchoolIDStr = gvSchooldetail.DataKeys[gr.RowIndex]["SchoolID"].ToString();
                    }
                    else
                    {
                        tmp_SchoolIDStr = tmp_SchoolIDStr + " , " + gvSchooldetail.DataKeys[gr.RowIndex]["SchoolID"].ToString();
                    }
                    CountChecked = CountChecked + 1;
                }
                else
                {
                    CountChecked = Convert.ToInt32(EnumFile.AssignValue.Zero);
                    break;
                }
            }
        }
        if (CountChecked > Convert.ToInt32(EnumFile.AssignValue.Zero))
        {
            try
            {

                int tmpstatusid = Convert.ToInt32(EnumFile.AssignValue.Zero);
                if (rbActive.Checked == true)
                {
                    tmpstatusid = Convert.ToInt32(EnumFile.Status.Active);
                }
                if (rbDeactive.Checked == true)
                {
                    tmpstatusid = Convert.ToInt32(EnumFile.Status.Deactive);
                }

                UdateStatusSchool(tmp_SchoolIDStr, tmpstatusid);

                string status = string.Empty;
                if (rbActive.Checked == true)
                {
                    status = "Active.";
                }
                else if (rbDeactive.Checked == true)
                {
                    status = "Deactive.";
                }
                string message = string.Format("Selected records successfully {0}", status);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('" + message + "')</script>", false);

            }
            catch (Exception ex)
            {
                WebMsg.Show(ex.Message);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Please select atleast one record to Active/Deactive.')</script>", false);
        }
    }

    protected void btnAppRejSubmit_Click(object sender, EventArgs e)
    {


        //int CountChecked = Convert.ToInt32(EnumFile.AssignValue.Zero);
        string tmp_SchoolIDStr = "";
        //foreach (GridViewRow gr in gvSchooldetail.Rows)
        //{
        //    CheckBox chk = new CheckBox();
        //    chk = (CheckBox)gr.FindControl("chkSelect");
        //    if (chk.Checked == true)
        //    {
        //        int StatusID;
        //        StatusID = Convert.ToInt32(gvSchooldetail.DataKeys[gr.RowIndex]["StatusID"]);
        //        if (StatusID == Convert.ToInt32(EnumFile.Status.Appiled) || StatusID == Convert.ToInt32(EnumFile.Status.Approve) || StatusID == Convert.ToInt32(EnumFile.Status.Reject))
        //        {

        //            if (CountChecked == Convert.ToInt32(EnumFile.AssignValue.Zero))
        //            {
        //                tmp_SchoolIDStr = gvSchooldetail.DataKeys[gr.RowIndex]["SchoolID"].ToString();
        //            }
        //            else
        //            {
        //                tmp_SchoolIDStr = tmp_SchoolIDStr + " , " + gvSchooldetail.DataKeys[gr.RowIndex]["SchoolID"].ToString();
        //            }
        //            CountChecked = CountChecked + 1;
        //        }
        //        else
        //        {
        //            CountChecked = Convert.ToInt32(EnumFile.AssignValue.Zero);
        //            break;

        //        }
        //    }
        //}
        //if (CountChecked > Convert.ToInt32(EnumFile.AssignValue.Zero))
        //{


        //    try
        //    {

        int tmpstatusid = Convert.ToInt32(EnumFile.AssignValue.Zero);
        if (rbActive1.Checked == true)
        {
            tmpstatusid = Convert.ToInt32(EnumFile.Status.Active);
        }
        if (rbDeactive1.Checked == true)
        {
            tmpstatusid = Convert.ToInt32(EnumFile.Status.Deactive);
        }
        if (rbApprove1.Checked == true)
        {
            tmpstatusid = Convert.ToInt32(EnumFile.Status.Approve);
        }
        if (rbReject1.Checked == true)
        {
            tmpstatusid = Convert.ToInt32(EnumFile.Status.Reject);
        }
        if (rbApplied1.Checked == true)
        {
            tmpstatusid = Convert.ToInt32(EnumFile.Status.Appiled);
        }

        foreach (GridViewRow gr in gvSchooldetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                tmp_SchoolIDStr = gvSchooldetail.DataKeys[gr.RowIndex]["SchoolID"].ToString();
                UdateStatusSchool(tmp_SchoolIDStr, tmpstatusid);
            }


        }
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record sucessfully updated.....')</script>", false);

        PnlChangeStatus.CssClass = "InVisible";
        uncheckstatusradiobutton();
        //rbApprove1.Checked = false;
        //rbReject1.Checked = false;
        //rbActive1.Checked = false;
        //rbDeactive1.Checked = false;
        //rbApplied1.Checked = false;




        //        string status = string.Empty;
        //        if (rbApprove.Checked == true)
        //        {
        //            status = "Approve.";
        //        }
        //        else if (rbReject.Checked == true)
        //        {
        //            status = "Rejected.";
        //        }
        //        string message = string.Format("Selected records successfully {0}", status);
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('" + message + "')</script>", false);

        //    }
        //    catch (Exception ex)
        //    {
        //        WebMsg.Show(ex.Message);
        //    }
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Please select atleast one record to Approve/Reject.')</script>", false);
        //    //WebMsg.Show("Please select atleast one record.");
        //}
    }

    protected void ibtnActiveDe_Click(object sender, ImageClickEventArgs e)
    {



    }

    #endregion

    #region "User Defined Functions"

    //Get First time look 
    private void RefreshAllPanels()
    {
        VisibleInvisible(pnlSearch, true);
        VisibleInvisible(pnlActDeact, false);
        VisibleInvisible(pnlRejApp, false);
    }

    //Bind Status to Dropdown
    private void bindgrvSYS_Statusdetail()
    {
        Prop_SYS_Status = new SYS_Status();
        BAL_SYS_Status = new SYS_Status_BLogic();
        Prop_SYS_Status.statusid = Convert.ToInt32(EnumFile.AssignValue.Zero);
        Prop_SYS_Status.status = string.Empty;
        DataSet dsSelect = new DataSet();
        dsSelect = BAL_SYS_Status.BAL_SYS_Status_Select(Prop_SYS_Status, "SelectAll");
        if (dsSelect.Tables.Count > Convert.ToInt32(EnumFile.AssignValue.Zero))
        {
            ddlStatus.Items.Clear();
            ddlStatus.DataSource = dsSelect;
            ddlStatus.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlStatus.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            ddlStatus.DataTextField = dsSelect.Tables[0].Columns["Status"].ToString();
            ddlStatus.DataValueField = dsSelect.Tables[0].Columns["StatusID"].ToString();
            ddlStatus.DataBind();
            ddlStatus.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        }
    }

    //For bind School Details
    private void bindgrvSchooldetail()
    {
        try
        {


            DataSet dsSelect = new DataSet();
            dsSelect = GetSchoolRecord(dsSelect);
            if (dsSelect.Tables.Count > Convert.ToInt32(EnumFile.AssignValue.Zero))
            {

                //if (DdlStatus.SelectedValue == "0")
                //{
                //    ImgBtnRejApp.Visible = true;
                //    ImgBtnApproveSchDetails.Visible = true;
                //    ImgBtnShowUsers.Visible = true;
                //    ImgBtnActiveDe.Visible = true;
                //}
                //else if (DdlStatus.SelectedValue == "1")
                //{
                //    ImgBtnRejApp.Visible = true;
                //    ImgBtnApproveSchDetails.Visible = false;
                //    ImgBtnShowUsers.Visible = false;
                //    ImgBtnActiveDe.Visible = false;
                //}
                //else if (DdlStatus.SelectedValue == "2" || DdlStatus.SelectedValue == "3")
                //{
                //    ImgBtnRejApp.Visible = true;
                //    ImgBtnApproveSchDetails.Visible = true;
                //    ImgBtnShowUsers.Visible = false;
                //    ImgBtnActiveDe.Visible = false;
                //}
                //else if (DdlStatus.SelectedValue == "4" || DdlStatus.SelectedValue == "5")
                //{
                //    ImgBtnRejApp.Visible = false;
                //    ImgBtnApproveSchDetails.Visible = false;
                //    ImgBtnShowUsers.Visible = true;
                //    ImgBtnActiveDe.Visible = true;
                //}

                GridViewOperations GrvOperation = new GridViewOperations();
                GrvOperation.BindGridWithSorting(gvSchooldetail, dsSelect, this.SortField, this.SortDirection);
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message.ToString());
        }
    }

    //GetSchool Details by search condition
    private DataSet GetSchoolRecord(DataSet dsSelect)
    {
        obj_BAL_School = new School_BLogic();
        string SearchCondition;
        if (ddlStatus.SelectedValue == Convert.ToString((int)EnumFile.AssignValue.Zero))
        {
            SearchCondition = " School.StatusID >" + ddlStatus.SelectedValue + "";
        }
        else
        {
            SearchCondition = " School.StatusID=" + ddlStatus.SelectedValue;
        }

        SearchCondition = SearchCondition + " and School.Name like '%" + txtSchName.Text + "%'";
        SearchCondition = SearchCondition + " and SYS_State.State like '%" + txtState.Text + "%'";
        SearchCondition = SearchCondition + " and SYS_District.District like '%" + txtDistrict.Text + "%'";
        SearchCondition = SearchCondition + " and convert(nvarchar(10),School.PinCode) like '%" + txtPincode.Text + "%'";

        dsSelect = obj_BAL_School.BAL_School_SelectAllOrBySchRegID("SelectAll", 0, SearchCondition);
        return dsSelect;
    }

    //For visible and invisible controls 
    private void VisibleInvisible(Panel PanlCtrl, bool action)
    {
        //PanlCtrl.Visible = action;


    }

    //For bind School name extender
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]

    public static string[] GetSchoolName(string prefixText, int count, string contextKey)
    {
        School_BLogic SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        dt = SchoolBLogic.BAL_SchoolAllName().Tables[0];

        int i = Convert.ToInt32(EnumFile.AssignValue.Zero);
        string expression;
        expression = "Name like '%" + prefixText + "%'";
        DataRow[] foundRows;

        // Use the Select method to find all rows matching the filter.
        foundRows = dt.Select(expression);
        string[] item = new string[foundRows.Count()];

        //DataView dataView = new DataView(dTable);
        //dataView.RowFilter = "Name LIKE '%"+"Hello"+"%'";
        foreach (DataRow dr in foundRows)
        {
            item.SetValue(dr["Name"].ToString(), i);
            i++;
        }
        return item;
    }

    //For bind State name extender
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]

    public static string[] GetState(string prefixText, int count, string contextKey)
    {
        SYS_State_BLogic StateBLogic = new SYS_State_BLogic();
        DataTable dt = new DataTable();
        dt = StateBLogic.BAL_SYS_State_SelectAll().Tables[0];

        int i = Convert.ToInt32(EnumFile.AssignValue.Zero);
        string expression;
        expression = "State like '%" + prefixText + "%'";
        DataRow[] foundRows;

        // Use the Select method to find all rows matching the filter.
        foundRows = dt.Select(expression);
        string[] item = new string[foundRows.Count()];

        //DataView dataView = new DataView(dTable);
        //dataView.RowFilter = "Name LIKE '%"+"Hello"+"%'";
        foreach (DataRow dr in foundRows)
        {
            item.SetValue(dr["State"].ToString(), i);
            i++;
        }
        return item;
    }

    //For bind District name extender
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]

    public static string[] GetDistrict(string prefixText, int count, string contextKey)
    {
        SYS_District_BLogic DistrictBLogic = new SYS_District_BLogic();
        DataTable dt = new DataTable();
        dt = DistrictBLogic.BAL_SYS_District_SelectAll().Tables[0];

        int i = Convert.ToInt32(EnumFile.AssignValue.Zero);
        string expression;
        expression = "District like '%" + prefixText + "%'";
        DataRow[] foundRows;

        // Use the Select method to find all rows matching the filter.
        foundRows = dt.Select(expression);
        string[] item = new string[foundRows.Count()];

        //DataView dataView = new DataView(dTable);
        //dataView.RowFilter = "Name LIKE '%"+"Hello"+"%'";
        foreach (DataRow dr in foundRows)
        {
            item.SetValue(dr["District"].ToString(), i);
            i++;
        }
        return item;
    }

    //For bind Pincode name extender
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]

    public static string[] GetPinCode(string prefixText, int count, string contextKey)
    {
        School_BLogic SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        dt = SchoolBLogic.BAL_SchoolAllName().Tables[0];

        int i = Convert.ToInt32(EnumFile.AssignValue.Zero);
        string expression;
        expression = "PinCode like '%" + prefixText + "%'";
        DataRow[] foundRows;

        // Use the Select method to find all rows matching the filter.
        foundRows = dt.Select(expression);
        string[] item = new string[foundRows.Count()];

        //DataView dataView = new DataView(dTable);
        //dataView.RowFilter = "Name LIKE '%"+"Hello"+"%'";
        foreach (DataRow dr in foundRows)
        {
            item.SetValue(dr["PinCode"].ToString(), i);
            i++;
        }
        return item;
    }

    private void OpenPageInViewAndEditMode(int mode)
    {
        int CountChecked = Convert.ToInt32(EnumFile.AssignValue.Zero);
        int GridRowIndexVal = Convert.ToInt32(EnumFile.AssignValue.Zero);
        int tmp_SchoolID;
        foreach (GridViewRow gr in gvSchooldetail.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                CountChecked = CountChecked + 1;
                GridRowIndexVal = gr.RowIndex;
            }
        }
        if (CountChecked == Convert.ToInt32(EnumFile.AssignValue.One))
        {
            //******For why use Session["TypeofPageView"] 
            //SchoolDetail.aspx which UI style you want to work page 
            //like only show details of page and another page with same 
            //details but gives functionality of approve class and active/deactive class   
            //******End why use Session["TypeofPageView"] 
            if (mode == Convert.ToInt32(EnumFile.AssignValue.Zero))
            {
                Session["TypeofPageView"] = "DetailsOnly";
            }
            else if (mode == Convert.ToInt32(EnumFile.AssignValue.One))
            {
                Session["TypeofPageView"] = "DetailsUpdate";
            }

            tmp_SchoolID = Convert.ToInt32(gvSchooldetail.DataKeys[GridRowIndexVal]["SchoolID"]);
            Page.RegisterStartupScript("Window", "<script language=\"javascript\">window.open('SchoolDetail.aspx?RegID= " + tmp_SchoolID + "&Status=" + ddlStatus.SelectedValue + " ',' ','width=1000,height=760,scrollbars=1,left=1,top=1');</script>");
        }
        else
        {
            if (CountChecked > Convert.ToInt32(EnumFile.AssignValue.One))
            {
                WebMsg.Show("Please select only one record.");
            }
            if (CountChecked == Convert.ToInt32(EnumFile.AssignValue.Zero))
            {
                WebMsg.Show("Please select atleast one record.");
            }
        }
    }

    private void UdateStatusSchool(string tmp_SchoolIDStr, int tmpstatusid)
    {
        obj_School = new School();
        obj_BAL_School = new School_BLogic();

        obj_School.schoolidStr = tmp_SchoolIDStr;
        obj_School.StatusID = tmpstatusid;
        obj_School.modifiedby = Convert.ToInt32(Session["EmpolyeeID"].ToString());
        obj_BAL_School.BAL_School_UpdateStatus(obj_School, "UpdateAllDetailsSchool");
        RefreshAllPanels();
        ddlStatus.SelectedValue = Convert.ToString((int)EnumFile.AssignValue.Zero);
        bindgrvSchooldetail();
    }
    #endregion

    int StatusID;
    protected void imbchangestatus_Click(object sender, ImageClickEventArgs e)
    {

        string status = "false";
        int rowcont = 0;
        foreach (GridViewRow gr in gvSchooldetail.Rows)
        {

            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");

            if (chk.Checked == true)
            {
                if (rowcont == 0)
                {
                    StatusID = Convert.ToInt32(gvSchooldetail.DataKeys[gr.RowIndex]["StatusID"]);
                }
                if (StatusID == Convert.ToInt32(gvSchooldetail.DataKeys[gr.RowIndex]["StatusID"]))
                {
                    status = "true";
                }
                else
                {
                    status = "false";
                    WebMsg.Show("Select records having same status type......");
                    break;
                }
                rowcont = rowcont + 1;
            }
        }

        if (status == "true")
        {
            if (PnlChangeStatus
                .CssClass == "Visible")
            {
                PnlChangeStatus.CssClass = "InVisible";
                uncheckstatusradiobutton();

            }
            else
            {
                PnlChangeStatus.CssClass = "Visible";
            }



            //PnlChangeStatus.CssClass = "Visible";
            if (StatusID == 1)
            {
                changestatus(true, true, false, false, false);
            }

            if (StatusID == 2)
            {
                changestatus(false, true, true, false, false);
            }
            if (StatusID == 3)
            {
                changestatus(true, false, false, false, true);
            }

            if (StatusID == 4)
            {
                changestatus(false, false, false, true, false);
            }

            if (StatusID == 5)
            {
                changestatus(false, true, true, false, true);

            }

        }
        else
        {
            PnlChangeStatus.CssClass = "InVisible";
            uncheckstatusradiobutton();
            //PnlChangeStatus.Visible = true;
        }
    }


    protected void chkheaderselect_checkedchanged(object sender, EventArgs e)
    {
        PnlChangeStatus.CssClass = "InVisible";
        uncheckstatusradiobutton();

    }


    public void changestatus(Boolean approvestatus, Boolean rejectstatus, Boolean activestatus, Boolean deactivestatus, Boolean appliedstatus)
    {
        rbApprove1.Visible = approvestatus;
        rbReject1.Visible = rejectstatus;
        rbActive1.Visible = activestatus;
        rbDeactive1.Visible = deactivestatus;
        rbApplied1.Visible = appliedstatus;

      


    }

    public void uncheckstatusradiobutton()
    {
        rbApprove1.Checked = false;
        rbReject1.Checked = false;
        rbActive1.Checked = false;
        rbDeactive1.Checked = false;
        rbApplied1.Checked = false;
    }
}