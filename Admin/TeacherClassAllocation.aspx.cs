
/// <summary> 
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>

using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Admin_TeacherClassAllocation : System.Web.UI.Page
{

    #region "Declaration"
    Employee_BLogic BAL_Employee;
    //Employee Employee;
    SYS_BMS_BLogic SYS_BMSBLogic;
    SYS_Subject_BLogic Subject_Blogic;
    EmployeeStandardDetail_BLogic BAL_EmployeeStandardDetail;
    EmployeeStandardDetail EmployeeStandardDetail;

    School_BLogic SchoolBLogic = new School_BLogic();
    DropDownFill DdlFilling;

    #endregion

    # region Properties

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
            FillSchoolDropdown(ddlSchool);
            FillSchoolDropdown(ddlSchoolAdd);
            ibtnDelete.Attributes.Add("onclick", "if(confirm('Are you sure to delete?')){}else{return false}");
            GetDDLBMSDetails();
            bindgrvEmployeedetail();
            bindDdlEmployeedetailAdd();
            bindDdlEmployeedetailEdit();
            BindDivisionCheckBoxList();
            BindSubjectCheckBoxList();
            ViewState["FirstLod"] = ((int)EnumFile.AssignValue.Zero).ToString();
            BindEmpStdSubDetailsGrid();
        }
    }
    #endregion

    #region "Control Events"

    protected void gvEmpStdSubAllocationDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        else
            this.SortDirection = "ascending";

        this.SortField = e.SortExpression;
        BindEmpStdSubDetailsGrid();
        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, gvEmpStdSubAllocationDetails, this.SortDirection);
    }

    protected void gvEmpStdSubAllocationDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(gvEmpStdSubAllocationDetails, e.Row, this.Page);
        }
    }

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvEmpStdSubAllocationDetails.PageIndex = ((DropDownList)sender).SelectedIndex;
        BindEmpStdSubDetailsGrid();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {


        int count = ((int)EnumFile.AssignValue.Zero);
        string divisionidstr = string.Empty;
        string subjectidstr = string.Empty;
        string subjectidForDeletestr = string.Empty;
        foreach (ListItem chk in clstDivisionEdit.Items)
        {
            if (chk.Selected == true)
            {
                if (count == ((int)EnumFile.AssignValue.Zero))
                {
                    divisionidstr = chk.Value;
                }
                else
                {
                    divisionidstr = divisionidstr + " , " + chk.Value;
                }
                count = count + 1;
            }

        }
        if (count == ((int)EnumFile.AssignValue.Zero))
        {
            WebMsg.Show("Please select atleast one Division");
        }
        else
        {
            count = ((int)EnumFile.AssignValue.Zero);
            foreach (ListItem chk in clstSubjectEdit.Items)
            {
                if (chk.Selected == true)
                {
                    if (count == ((int)EnumFile.AssignValue.Zero))
                    {
                        subjectidstr = chk.Value;
                    }
                    else
                    {
                        subjectidstr = subjectidstr + " , " + chk.Value;
                    }
                    count = count + 1;
                }
                else if (chk.Selected == false)
                {
                    if (subjectidForDeletestr == string.Empty)
                    {
                        subjectidForDeletestr = chk.Value;
                    }
                    else
                    {
                        subjectidForDeletestr = subjectidForDeletestr + " , " + chk.Value;
                    }
                }
            }
            if (count == ((int)EnumFile.AssignValue.Zero) && subjectidForDeletestr == string.Empty)
            {
                WebMsg.Show("Please select atleast one Subject");
            }
            else
            {
                try
                {
                    BAL_EmployeeStandardDetail = new EmployeeStandardDetail_BLogic();
                    EmployeeStandardDetail = new EmployeeStandardDetail();
                    DataSet dsselectErrors = new DataSet();
                    EmployeeStandardDetail.bmsid = Convert.ToInt32(ddlBoardMediumStandardEdit.SelectedValue.ToString());
                    EmployeeStandardDetail.employeeid = Convert.ToInt32(ddlEmployeeEdit.SelectedValue.ToString());
                    if (divisionidstr == string.Empty)
                    { divisionidstr = ((int)EnumFile.AssignValue.Zero).ToString(); }
                    EmployeeStandardDetail.divisionidstr = divisionidstr;
                    if (subjectidstr == string.Empty)
                    { subjectidstr = ((int)EnumFile.AssignValue.Zero).ToString(); }
                    EmployeeStandardDetail.subjectidstr = subjectidstr;
                    if (subjectidForDeletestr == string.Empty)
                    { subjectidForDeletestr = ((int)EnumFile.AssignValue.Zero).ToString(); }
                    EmployeeStandardDetail.subjectidForDeletestr = subjectidForDeletestr;
                    dsselectErrors = BAL_EmployeeStandardDetail.BAL_EmployeeStandardDetail_InsertUpdate(EmployeeStandardDetail, "Update");
                    if (dsselectErrors.Tables.Count > ((int)EnumFile.AssignValue.Zero))
                    {
                        if (dsselectErrors.Tables[1].Rows.Count > ((int)EnumFile.AssignValue.Zero))
                        {
                            if (Convert.ToInt32(dsselectErrors.Tables[1].Rows[0][0].ToString()) == ((int)EnumFile.AssignValue.Zero))
                            {
                                WebMsg.Show("Record updated complete.");
                            }
                            else
                            {
                            }
                        }
                        if (dsselectErrors.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
                        {
                            //string ErrorMsg = "Following Combination already exist.";
                            //for (int i = 0; i < dsselectErrors.Tables[0].Rows.Count; i++)
                            //{
                            //    ErrorMsg = ErrorMsg + ">>" + (i + 1) + ". " + dsselectErrors.Tables[0].Rows[i][1].ToString() + "---" + dsselectErrors.Tables[0].Rows[i][2].ToString();
                            //}
                            WebMsg.Show("Record updated complete.");
                        }
                    }
                    RefreshControls();
                    clstSubject.Items.Clear();
                    clstSubject.DataBind();
                }
                catch (Exception ex)
                { WebMsg.Show(ex.Message); }

            }
        }
        //RefreshControls();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        AllPanelInvisible();
        pnlSearch.CssClass = "Visible";
        RefreshSearchControls();
    }

    protected void ddlEmployeeAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        AllPanelInvisible();
        pnlAdd.CssClass = "Visible";
    }

    protected void ddlBoardMediumStandardAdd_SelectedIndexChanged(object sender, EventArgs e)
    {

        AllPanelInvisible();
        pnlAdd.CssClass = "Visible";
        if (ddlBoardMediumStandardAdd.SelectedIndex == ((int)EnumFile.AssignValue.Zero))
        {
            clstSubjectAdd.Items.Clear();
            clstSubjectAdd.DataBind();
        }
        else
        {
            //BindChkListSubjectAdd();
            BindSubjectCheckBoxList();
        }
    }

    protected void btnResetAdd_Click(object sender, EventArgs e)
    {
        AllPanelInvisible();
        pnlAdd.CssClass = "Visible";
        ddlEmployeeAdd.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlBoardMediumStandardAdd.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        bindDdlEmployeedetailAdd();
        BindChkListSubjectAdd();
        BindDivisionCheckBoxList();
        BindSubjectCheckBoxList();


    }

    protected void btnResetEdit_Click(object sender, EventArgs e)
    {
        RefreshControls();
        ddlEmployeeEdit.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlBoardMediumStandardEdit.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        bindDdlEmployeedetailEdit();
        BindChkListSubjectEdit();
        BindDivisionCheckBoxList();
        BindSubjectCheckBoxList();
    }

    protected void btnYesNoSub_Click(object sender, EventArgs e)
    {
        int CountChecked = ((int)EnumFile.AssignValue.Zero);
        int EmpStdSubDetailsID = ((int)EnumFile.AssignValue.Zero);
        int bmsid = ((int)EnumFile.AssignValue.Zero);
        int Divid = ((int)EnumFile.AssignValue.Zero);
        bool IsclassTeacher = false;
        if (rbYes.Checked == true)
        {
            IsclassTeacher = true;
        }
        else if (rbNo.Checked == true)
        {
            IsclassTeacher = false;
        }

        try
        {
            BAL_EmployeeStandardDetail = new EmployeeStandardDetail_BLogic();
            EmployeeStandardDetail = new EmployeeStandardDetail();
            foreach (GridViewRow gr in gvEmpStdSubAllocationDetails.Rows)
            {
                CheckBox chk = new CheckBox();
                chk = (CheckBox)gr.FindControl("chkSelect");
                if (chk.Checked == true)
                {

                    EmpStdSubDetailsID = Convert.ToInt32(gvEmpStdSubAllocationDetails.DataKeys[gr.RowIndex]["EmployeeID"].ToString());
                    bmsid = Convert.ToInt32(gvEmpStdSubAllocationDetails.DataKeys[gr.RowIndex]["BMSID"].ToString());
                    Divid = Convert.ToInt32(gvEmpStdSubAllocationDetails.DataKeys[gr.RowIndex]["DivisionID"].ToString());
                    CountChecked = CountChecked + 1;
                    EmployeeStandardDetail.employeeid = EmpStdSubDetailsID;
                    EmployeeStandardDetail.bmsid = bmsid;
                    EmployeeStandardDetail.divisionid = Divid;
                    EmployeeStandardDetail.isclassteacher = IsclassTeacher;
                    BAL_EmployeeStandardDetail.BAL_EmployeeStandardDetailUpdateTeachrType(EmployeeStandardDetail);
                }
            }

            WebMsg.Show("record updated.");
            RefreshControls();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ibtnIsClassTeacher_Click(object sender, ImageClickEventArgs e)
    {

        int CountChecked = ((int)EnumFile.AssignValue.Zero);
        foreach (GridViewRow gr in gvEmpStdSubAllocationDetails.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                CountChecked = CountChecked + 1;
            }
        }
        if (CountChecked == ((int)EnumFile.AssignValue.Zero))
        {
            WebMsg.Show("Please select atleast one record to update.");
        }
        else
        {


            pnlSearch.Visible = false;
            gvEmpStdSubAllocationDetails.Enabled = false;
        }


    }

    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {

        int CountChecked = ((int)EnumFile.AssignValue.Zero);
        string EmpStdSubDetailsID = string.Empty;
        foreach (GridViewRow gr in gvEmpStdSubAllocationDetails.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                if (CountChecked == ((int)EnumFile.AssignValue.Zero))
                {
                    EmpStdSubDetailsID = gvEmpStdSubAllocationDetails.DataKeys[gr.RowIndex]["EmpStdID"].ToString();
                }
                else
                {
                    EmpStdSubDetailsID = EmpStdSubDetailsID + " , " + gvEmpStdSubAllocationDetails.DataKeys[gr.RowIndex]["EmpStdID"].ToString();
                }
                CountChecked = CountChecked + 1;
            }
        }
        if (CountChecked == ((int)EnumFile.AssignValue.Zero))
        {
            WebMsg.Show("Please select atleast one record to delete.");
        }
        else
        {
            try
            {
                BAL_EmployeeStandardDetail = new EmployeeStandardDetail_BLogic();
                BAL_EmployeeStandardDetail.BAL_EmployeeStandardDetail_Delete(EmpStdSubDetailsID);
                WebMsg.Show("record deleted.");
                RefreshControls();
            }
            catch (Exception ex)
            {
                WebMsg.Show(ex.Message);
            }
        }

    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        BindEmpStdSubDetailsGrid();
    }

    protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (pnlEdit.CssClass == "Visible")
        {
            pnlEdit.CssClass = "InVisible";
            pnlSearch.CssClass = "Visible";
        }
        else
        {


            int CountChecked = ((int)EnumFile.AssignValue.Zero);
            int GRrowIndex = ((int)EnumFile.AssignValue.Zero);
            foreach (GridViewRow gr in gvEmpStdSubAllocationDetails.Rows)
            {
                CheckBox chk = new CheckBox();
                chk = (CheckBox)gr.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    CountChecked = CountChecked + 1;
                    GRrowIndex = gr.RowIndex;
                }
            }
            if (CountChecked == ((int)EnumFile.AssignValue.Zero) || CountChecked > ((int)EnumFile.AssignValue.One))
            {
                WebMsg.Show("Please select one record to update.");
            }
            else
            {
                AllPanelInvisible();
                pnlEdit.CssClass = "Visible";

                ddlBoardMediumStandardEdit.SelectedValue = gvEmpStdSubAllocationDetails.DataKeys[GRrowIndex]["BMSID"].ToString();
                clstDivisionEdit.SelectedValue = gvEmpStdSubAllocationDetails.DataKeys[GRrowIndex]["DivisionID"].ToString();
                ddlEmployeeEdit.SelectedValue = gvEmpStdSubAllocationDetails.DataKeys[GRrowIndex]["EmployeeID"].ToString();
                ddlBoardMediumStandardEdit.Enabled = false;
                clstDivisionEdit.Enabled = false;

                //BindChkBoxSubjectEdit(); //Original-1

                DropDownFill DdlFilling = new DropDownFill(); //Change-1
                DdlFilling.BindCheckBoxListByDynamic(clstSubjectEdit, "SYS_Subject", "Subject", "SubjectID", " IsActive = 1"); //Change-1

                ddlEmployeeEdit.Enabled = false;

                string subjectStr = gvEmpStdSubAllocationDetails.DataKeys[GRrowIndex]["SubjectID"].ToString();
                string[] sname = subjectStr.Split(',');
                for (int i = 0; i < sname.Length; i++)
                {
                    foreach (ListItem chk in clstSubjectEdit.Items)
                    {
                        if (chk.Value == sname[i].Replace(" ", ""))
                        {
                            chk.Selected = true;
                        }
                    }

                }
                gvEmpStdSubAllocationDetails.Enabled = false;

            }
        }
    }

    protected void gvEmpStdSubAllocationDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DropDownList DDLSelectPage = (DropDownList)gvEmpStdSubAllocationDetails.BottomPagerRow.FindControl("ddlPageSelector");
            DDLSelectPage.SelectedIndex = e.NewPageIndex;
            gvEmpStdSubAllocationDetails.PageIndex = e.NewPageIndex;
            BindEmpStdSubDetailsGrid();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message.ToString());
        }
    }

    protected void ddlBoardMediumStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBoardMediumStandard.SelectedIndex == ((int)EnumFile.AssignValue.Zero))
        {
        }
        else
        {
            BindChkBoxSubject();
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int count = ((int)EnumFile.AssignValue.Zero);
        string divisionidstr = "";
        string subjectidstr = "";
        foreach (ListItem chk in clstDivisionAdd.Items)
        {
            if (chk.Selected == true)
            {
                if (count == ((int)EnumFile.AssignValue.Zero))
                {
                    divisionidstr = chk.Value;
                }
                else
                {
                    divisionidstr = divisionidstr + " , " + chk.Value;
                }
                count = count + 1;

            }
        }
        int count1 = ((int)EnumFile.AssignValue.Zero);
        foreach (ListItem chk in clstSubjectAdd.Items)
        {
            if (chk.Selected == true)
            {
                if (count1 == 0)
                {
                    subjectidstr = chk.Value;
                }
                else
                {
                    subjectidstr = subjectidstr + " , " + chk.Value;
                }
                count1 = count1 + 1;
            }
        }


        if (count1 == ((int)EnumFile.AssignValue.Zero) || count == ((int)EnumFile.AssignValue.Zero))
        {

            if (count == ((int)EnumFile.AssignValue.Zero))
            {
                DisplayCustomMessageInValidationSummary("Please select atleast one Division.", "StdSubAllocationAdd");

            }
            if (count1 == ((int)EnumFile.AssignValue.Zero))
            {
                DisplayCustomMessageInValidationSummary("Please select atleast one Subject.", "StdSubAllocationAdd");
            }
            pnlAdd.CssClass = "Visible";
            pnlSearch.CssClass = "InVisible";
        }
        else
        {
            try
            {
                BAL_EmployeeStandardDetail = new EmployeeStandardDetail_BLogic();
                EmployeeStandardDetail = new EmployeeStandardDetail();
                DataSet dsselectErrors = new DataSet();
                EmployeeStandardDetail.bmsid = Convert.ToInt32(ddlBoardMediumStandardAdd.SelectedValue.ToString());
                EmployeeStandardDetail.employeeid = Convert.ToInt32(ddlEmployeeAdd.SelectedValue.ToString());
                if (divisionidstr == string.Empty)
                { divisionidstr = ((int)EnumFile.AssignValue.Zero).ToString(); }
                EmployeeStandardDetail.divisionidstr = divisionidstr;
                if (subjectidstr == string.Empty)
                { subjectidstr = ((int)EnumFile.AssignValue.Zero).ToString(); }
                EmployeeStandardDetail.subjectidstr = subjectidstr;
                EmployeeStandardDetail.subjectidForDeletestr = string.Empty;
                dsselectErrors = BAL_EmployeeStandardDetail.BAL_EmployeeStandardDetail_InsertUpdate(EmployeeStandardDetail, "Insert");
                if (dsselectErrors.Tables.Count > ((int)EnumFile.AssignValue.Zero))
                {
                    if (dsselectErrors.Tables[1].Rows.Count > ((int)EnumFile.AssignValue.Zero))
                    {
                        if (Convert.ToInt32(dsselectErrors.Tables[1].Rows[0][0].ToString()) == ((int)EnumFile.AssignValue.Zero))
                        {

                            WebMsg.Show("Record inserted complete.");
                            RefreshSearchControls();
                            RefreshControls();
                        }
                        else
                        {
                        }
                    }
                    if (dsselectErrors.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
                    {
                        string ErrorMsg = "Following Combination already exist.";
                        for (int i = 0; i < dsselectErrors.Tables[0].Rows.Count; i++)
                        {
                            ErrorMsg = ErrorMsg + ">>" + (i + 1) + ". " + dsselectErrors.Tables[0].Rows[i][1].ToString() + "---" + dsselectErrors.Tables[0].Rows[i][2].ToString();
                        }
                        WebMsg.Show(ErrorMsg);
                    }
                }
                pnlAdd.CssClass = "InVisible";
                pnlSearch.CssClass = "Visible";
            }
            catch (Exception ex)
            { WebMsg.Show(ex.Message); }


        }


    }

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        RefreshSearchControls();
        RefreshControls();
    }

    #endregion

    #region "User Defined Functions"

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }

    private void BindDivisionCheckBoxList()
    {
        DropDownFill DdlFilling = new DropDownFill();
        DdlFilling.BindCheckBoxListByDynamic(clstDivision, "SYS_Division", "Division", "DivisionID", " IsActive = 1");

        DdlFilling.BindCheckBoxListByDynamic(clstDivisionAdd, "SYS_Division", "Division", "DivisionID", " IsActive = 1");

        DdlFilling.BindCheckBoxListByDynamic(clstDivisionEdit, "SYS_Division", "Division", "DivisionID", " IsActive = 1");
    }

    private void BindSubjectCheckBoxList()
    {
        DropDownFill DdlFilling = new DropDownFill();
        DdlFilling.BindCheckBoxListByDynamic(clstSubject, "SYS_Subject", "Subject", "SubjectID", " IsActive = 1");

        DdlFilling.BindCheckBoxListByDynamic(clstSubjectAdd, "SYS_Subject", "Subject", "SubjectID", " IsActive = 1");

        DdlFilling.BindCheckBoxListByDynamic(clstSubjectEdit, "SYS_Subject", "Subject", "SubjectID", " IsActive = 1");
    }

    private void bindgrvEmployeedetail()
    {
        DropDownFill DdlFilling = new DropDownFill();
        BAL_Employee = new Employee_BLogic();
        DataSet dsSelect = new DataSet();
        dsSelect = BAL_Employee.BAL_Employee_SelectBySchoolID(Convert.ToInt32(this.ViewState["SchoolID"]), "SelectAll");
        if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {

            DdlFilling.BindDropDownByTable(ddlEmployee, dsSelect.Tables[0], "employeeName", "EmployeeID");
        }
        else
        {
            DdlFilling.ClearDropDownListRef(ddlEmployee);
        }
    }

    private void bindDdlEmployeedetailAdd()
    {
        DropDownFill DdlFilling = new DropDownFill();
        BAL_Employee = new Employee_BLogic();
        DataSet dsSelect = new DataSet();
        dsSelect = BAL_Employee.BAL_Employee_SelectBySchoolID(Convert.ToInt32(this.ViewState["SchoolID"]), "SelectAll");
        if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {

            DdlFilling.BindDropDownByTable(ddlEmployeeAdd, dsSelect.Tables[0], "employeeName", "EmployeeID");
        }
        else
        {
            DdlFilling.ClearDropDownListRef(ddlEmployeeAdd);
        }
    }

    private void bindDdlEmployeedetailEdit()
    {
        DropDownFill DdlFilling = new DropDownFill();
        BAL_Employee = new Employee_BLogic();
        DataSet dsSelect = new DataSet();
        dsSelect = BAL_Employee.BAL_Employee_SelectBySchoolID(Convert.ToInt32(this.ViewState["SchoolID"]), "SelectAll");
        if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {

            DdlFilling.BindDropDownByTable(ddlEmployeeEdit, dsSelect.Tables[0], "employeeName", "EmployeeID");
        }
        else
        {
            DdlFilling.ClearDropDownListRef(ddlEmployeeEdit);
        }
    }

    private void GetDDLBMSDetails()
    {
        DropDownFill DdlFilling = new DropDownFill();
        SYS_BMSBLogic = new SYS_BMS_BLogic();
        DataSet dsselectBMS = new DataSet();
        dsselectBMS = SYS_BMSBLogic.BAL_SYS_BMS_SelectAllBySchoolID(Convert.ToInt64(this.ViewState["SchoolID"]));
        if (dsselectBMS.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {

            DdlFilling.BindDropDownByTable(ddlBoardMediumStandard, dsselectBMS.Tables[0], "BMS", "BMSID");
            DdlFilling.BindDropDownByTable(ddlBoardMediumStandardAdd, dsselectBMS.Tables[0], "BMS", "BMSID");
            DdlFilling.BindDropDownByTable(ddlBoardMediumStandardEdit, dsselectBMS.Tables[0], "BMS", "BMSID");
        }
        else
        {
            DdlFilling.ClearDropDownListRef(ddlBoardMediumStandard);
            DdlFilling.ClearDropDownListRef(ddlBoardMediumStandardAdd);
            DdlFilling.ClearDropDownListRef(ddlBoardMediumStandardEdit);
        }
    }

    private void RefreshControls()
    {
        AllPanelInvisible();
        pnlSearch.CssClass = "Visible";


        ddlBoardMediumStandard.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlEmployee.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();


        ddlBoardMediumStandardAdd.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlEmployeeAdd.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();

        ddlBoardMediumStandardEdit.Enabled = true;
        ddlEmployeeEdit.Enabled = true;
        ddlBoardMediumStandardEdit.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlEmployeeEdit.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();

        clstSubjectAdd.Items.Clear();
        clstSubjectEdit.Items.Clear();
        clstSubject.Items.Clear();

        GetDDLBMSDetails();
        bindgrvEmployeedetail();
        BindDivisionCheckBoxList();
        BindSubjectCheckBoxList();
        BindEmpStdSubDetailsGrid();

    }

    private void BindEmpStdSubDetailsGrid()
    {
        try
        {
            gvEmpStdSubAllocationDetails.Enabled = true;
            BAL_EmployeeStandardDetail = new EmployeeStandardDetail_BLogic();
            DataSet dsSelect = new DataSet();

            string SearchCondition = string.Empty;
            if (Convert.ToInt32(ddlBoardMediumStandard.SelectedValue) > ((int)EnumFile.AssignValue.Zero))
            {
                SearchCondition = " and EmployeeStandardDetail.BMSID = " + ddlBoardMediumStandard.SelectedValue;
            }
            if (Convert.ToInt32(ddlEmployee.SelectedValue) > ((int)EnumFile.AssignValue.Zero))
            {
                SearchCondition = SearchCondition + " and EmployeeStandardDetail.EmployeeID = " + ddlEmployee.SelectedValue;
            }
            int count = ((int)EnumFile.AssignValue.Zero);
            string divisionIDList = string.Empty;
            foreach (ListItem chk in clstDivision.Items)
            {
                if (chk.Selected == true)
                {
                    if (count == ((int)EnumFile.AssignValue.Zero))
                    {
                        divisionIDList = chk.Value.ToString();
                    }
                    else
                    {
                        divisionIDList = divisionIDList + " , " + chk.Value.ToString();
                    }
                    count = count + 1;

                }
            }
            if (count > ((int)EnumFile.AssignValue.Zero))
            {
                SearchCondition = SearchCondition + " and EmployeeStandardDetail.DivisionID IN (" + divisionIDList + ") ";
            }
            count = ((int)EnumFile.AssignValue.Zero);
            string SubjectIDList = string.Empty;
            foreach (ListItem chk in clstSubject.Items)
            {
                if (chk.Selected == true)
                {
                    if (count == ((int)EnumFile.AssignValue.Zero))
                    {
                        SubjectIDList = chk.Value.ToString();
                    }
                    else
                    {
                        SubjectIDList = SubjectIDList + " , " + chk.Value.ToString();
                    }
                    count = count + 1;

                }
            }
            if (count > ((int)EnumFile.AssignValue.Zero))
            {
                SearchCondition = SearchCondition + " and EmployeeStandardDetail.SubjectID IN (" + SubjectIDList + ") ";
            }
            if (rbtnIsClassTecorNo.SelectedValue.ToString() == ((int)EnumFile.ClassTeacher.IsNotClassTeacher).ToString() || rbtnIsClassTecorNo.SelectedValue.ToString() == ((int)EnumFile.ClassTeacher.IsClassTeacher).ToString())
            {
                SearchCondition = SearchCondition + " and EmployeeStandardDetail.IsClassTeacher = " + rbtnIsClassTecorNo.SelectedValue.ToString() + string.Empty;
            }
            dsSelect = BAL_EmployeeStandardDetail.BAL_EmployeeStandardDetail_SelectBySchoolID(Convert.ToInt32(this.ViewState["SchoolID"]), SearchCondition);
            string EmployeeDDlSelectedValue = ddlEmployee.SelectedValue.ToString();
            if (ViewState["FirstLod"] == ((int)EnumFile.AssignValue.Zero).ToString())
            {
                DataView dataView = new DataView(dsSelect.Tables[0]);
                DataTable dtTemp = dataView.ToTable(true, "EmployeeID", "EmpName");
                DropDownFill DdlFilling = new DropDownFill();

                DdlFilling.BindDropDownByTable(ddlEmployee, dtTemp, "EmpName", "EmployeeID");
                ViewState["FirstLod"] = "1";
            }
            ddlEmployee.SelectedValue = EmployeeDDlSelectedValue;
            if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
            {
                GridViewOperations GrvOperation = new GridViewOperations();
                GrvOperation.BindGridWithSorting(gvEmpStdSubAllocationDetails, dsSelect, this.SortField, this.SortDirection);

            }
            else
            {
                gvEmpStdSubAllocationDetails.DataSource = null;
                gvEmpStdSubAllocationDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    private void BindChkBoxSubject()
    {
        DropDownFill DdlFilling = new DropDownFill();
        Subject_Blogic = new SYS_Subject_BLogic();
        DataSet dsselect = Subject_Blogic.BAL_SYS_Subject_SelectByBMSID(Convert.ToInt64(ddlBoardMediumStandard.SelectedValue.ToString()));
        if (dsselect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {
            DdlFilling.BindCheckBoxListByTable(clstSubject, dsselect.Tables[0], "Subject", "SubjectID");
        }
        else
        {
            clstSubject.Items.Clear();
            clstSubject.DataBind();
        }
    }

    private void BindChkBoxSubjectEdit()
    {
        DropDownFill DdlFilling = new DropDownFill();
        Subject_Blogic = new SYS_Subject_BLogic();
        DataSet dsselect = Subject_Blogic.BAL_SYS_Subject_SelectByBMSID(Convert.ToInt64(ddlBoardMediumStandardEdit.SelectedValue.ToString()));
        if (dsselect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {
            DdlFilling.BindCheckBoxListByTable(clstSubjectEdit, dsselect.Tables[0], "Subject", "SubjectID");
        }
        else
        {
            clstSubjectEdit.Items.Clear();
            clstSubjectEdit.DataBind();
        }
    }

    private void DisplayCustomMessageInValidationSummary(string message, string ValidationGroup)
    {
        RequiredFieldValidator Validator = new RequiredFieldValidator();
        Validator.ErrorMessage = message;
        Validator.ValidationGroup = ValidationGroup;

        Validator.IsValid = false;
        this.Page.Form.Controls.Add(Validator);
        Validator.Visible = false;

    }

    private void BindChkListSubjectAdd()
    {
        DropDownFill DdlFilling = new DropDownFill();
        Subject_Blogic = new SYS_Subject_BLogic();
        DataSet dsselect = Subject_Blogic.BAL_SYS_Subject_SelectByBMSID(Convert.ToInt64(ddlBoardMediumStandardAdd.SelectedValue.ToString()));
        if (dsselect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {
            DdlFilling.BindCheckBoxListByTable(clstSubjectAdd, dsselect.Tables[0], "Subject", "SubjectID");
        }
        else
        {
            clstSubject.Items.Clear();
            clstSubject.DataBind();
        }
    }

    private void BindChkListSubjectEdit()
    {
        DropDownFill DdlFilling = new DropDownFill();
        Subject_Blogic = new SYS_Subject_BLogic();
        DataSet dsselect = Subject_Blogic.BAL_SYS_Subject_SelectByBMSID(Convert.ToInt64(ddlBoardMediumStandardEdit.SelectedValue.ToString()));
        if (dsselect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {
            DdlFilling.BindCheckBoxListByTable(clstSubjectEdit, dsselect.Tables[0], "Subject", "SubjectID");
        }
        else
        {
            clstSubjectEdit.Items.Clear();
            clstSubjectEdit.DataBind();
        }
    }

    private void AllPanelInvisible()
    {
        pnlSearch.CssClass = "InVisible";
        pnlISClassTeach.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlAdd.CssClass = "InVisible";
    }

    private void RefreshSearchControls()
    {
        gvEmpStdSubAllocationDetails.Enabled = true;
        ddlEmployee.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlBoardMediumStandard.Enabled = true;
        ddlEmployee.Enabled = true;
        ddlBoardMediumStandard.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
        ddlEmployee.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();

        clstSubject.Enabled = true;
        clstDivision.Enabled = true;
        rbtnIsClassTecorNo.Items[0].Selected = false;
        rbtnIsClassTecorNo.Items[1].Selected = false;
        clstSubject.Items.Clear();
        GetDDLBMSDetails();
        BindDivisionCheckBoxList();
        BindSubjectCheckBoxList();
        BindEmpStdSubDetailsGrid();
    }
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

                DdlFilling = new DropDownFill();
                DdlFilling.BindDropDownByTable(ddlSchoolAdd, dt, "Name", "SchoolID");
                ddlSchoolAdd.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlSchoolAdd.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            }
        }
    }

    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ViewState["SchoolID"] = ddlSchool.SelectedItem.Value;
        SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        dt = SchoolBLogic.BAL_SelectSubjectList("select StatusID from School where SchoolID='" + this.ViewState["SchoolID"] + "'");

        GetDDLBMSDetails();
        bindgrvEmployeedetail();
        bindDdlEmployeedetailAdd();
        bindDdlEmployeedetailEdit();
        BindDivisionCheckBoxList();
        BindSubjectCheckBoxList();
        ViewState["FirstLod"] = ((int)EnumFile.AssignValue.Zero).ToString();
        BindEmpStdSubDetailsGrid();
        // LtSchoolID.Text = dt.Rows[0]["StatusID"].ToString();
    }
    protected void ddlSchoolAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        AllPanelInvisible();
        pnlAdd.CssClass = "Visible";
        this.ViewState["SchoolID"] = ddlSchoolAdd.SelectedItem.Value;

        SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        dt = SchoolBLogic.BAL_SelectSubjectList("select StatusID from School where SchoolID='" + this.ViewState["SchoolID"] + "'");

        GetDDLBMSDetails();
        //bindgrvEmployeedetail();
        bindDdlEmployeedetailAdd();
        //bindDdlEmployeedetailEdit();
        BindDivisionCheckBoxList();
        BindSubjectCheckBoxList();
        //ViewState["FirstLod"] = ((int)EnumFile.AssignValue.Zero).ToString();
        //BindEmpStdSubDetailsGrid();
        // LtSchoolID.Text = dt.Rows[0]["StatusID"].ToString();
    }
    #endregion

}