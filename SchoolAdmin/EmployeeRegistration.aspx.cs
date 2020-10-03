/// <summary>               
/// <Description>Employee Registration</Description>
/// <DevelopedBy>"Bhavesh Prajapati"</DevelopedBy>
/// <DevelopedDate>"24-Nov-2013"</DevelopedDate>
/// <UpdatedBy>""</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;
using System.Data.SqlClient;

public partial class SchoolAdmin_EmployeeRegistration : System.Web.UI.Page
{
    #region "Declaration"
    Employee_BLogic BAL_Employee = new Employee_BLogic();
    Employee Employee = new Employee();
    #endregion

    #region "Properties"
    string SortDirection
    {
        get
        {
            object o = this.ViewState["SortDirection"];
            if (o == null)
            {
                return string.Empty;
            }
            else
            {
                return (string)o;
            }
        }

        set
        {
            this.ViewState["SortDirection"] = value;
        }
    }

    string SortField
    {
        get
        {
            object o = this.ViewState["SortField"];
            if (o == null)
            {
                return string.Empty;
            }
            else
            {
                return (string)o;
            }
        }

        set
        {
            this.ViewState["SortField"] = value;
        }
    }
    #endregion

    #region "PageLoad"
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

        if (!this.IsPostBack)
        {
            ibtnDelete.Attributes.Add("onclick", "if(confirm('Are you sure to delete?')){}else{return false}");
            this.BindGridEmployeeDetails();
            ViewState["FileLoacation"] = string.Empty;
        }
        else
        {
            //imgPhoto.ImageUrl = ViewState["FileLoacation"].ToString();
        }
    }

    #endregion

    #region "Grid Operation"

    protected void BindGridEmployeeDetails()
    {
        DataSet dsSelect = new DataSet();
        string SearchCondition = string.Empty;
        if (pnlSearch.CssClass == "Visible")
        {
            if (txtSearchFirstName.Text != string.Empty)
            {
                SearchCondition = "and Employee.FirstName like '%" + txtSearchFirstName.Text + "%'";
            }

            if (txtSearchMiddleName.Text != string.Empty)
            {
                SearchCondition = SearchCondition + "and Employee.MiddleName like '%" + txtSearchMiddleName.Text + "%'";
            }

            if (txtSearchLastName.Text != string.Empty)
            {
                SearchCondition = SearchCondition + "and Employee.LastName like '%" + txtSearchLastName.Text + "%'";
            }

            if (txtSearchDOB.Text != string.Empty)
            {
                SearchCondition = SearchCondition + "and Employee.DateOfBirth = '" + txtSearchDOB.Text + "'";
            }

            if (rlstSearchGender.SelectedValue != string.Empty)
            {
                SearchCondition = SearchCondition + "and Employee.Gender = '" + rlstSearchGender.SelectedValue + "'";
            }

            if (txtSearchBloodGroup.Text != string.Empty)
            {
                SearchCondition = SearchCondition + "and Employee.BloodGroup like '%" + txtSearchBloodGroup.Text + "%'";
            }

            if (txtSearchQualification.Text != string.Empty)
            {
                SearchCondition = SearchCondition + "and Employee.Qualification like '%" + txtSearchQualification.Text + "%'";
            }

            if (txtSearchDesignation.Text != string.Empty)
            {
                SearchCondition = SearchCondition + "and Employee.Designation like '%" + txtSearchDesignation.Text + "%'";
            }
            if (rlstActive.SelectedValue == "0")
            {
                SearchCondition = SearchCondition + SearchCondition + "and IsActive=0";
            }
            else if (rlstActive.SelectedValue == "1")
            {
                SearchCondition = SearchCondition + SearchCondition + "and IsActive=1";
            }
        
        }
      

        dsSelect = this.BAL_Employee.BAL_EmployeeDetailsBySchoolID(Convert.ToInt32(this.Session["SchoolID"]), SearchCondition);

        if (dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
        {
            GridViewOperations GvOperation = new GridViewOperations();
            GvOperation.BindGridWithSorting(this.gvEmployeeDetails, dsSelect, this.SortField, this.SortDirection);
            int row = dsSelect.Tables[0].Rows.Count;
            ViewState["EmployeeID"] = dsSelect.Tables[0].Rows[row - 1]["EmployeeID"];
        }
        else
        {
            gvEmployeeDetails.DataSource = null;
            gvEmployeeDetails.DataBind();
        }
    }

    protected void gvEmployeeDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DropDownList DDLSelectPage = (DropDownList)gvEmployeeDetails.BottomPagerRow.FindControl("ddlPageSelector");
            DDLSelectPage.SelectedIndex = e.NewPageIndex;
            gvEmployeeDetails.PageIndex = e.NewPageIndex;
            this.BindGridEmployeeDetails();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message.ToString());
        }
    }

    protected void gvEmployeeDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(this.gvEmployeeDetails, e.Row, this.Page);
        }
    }

    protected void gvEmployeeDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
        {
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        }
        else
        {
            this.SortDirection = "ascending";
        }

        this.SortField = e.SortExpression;
        this.BindGridEmployeeDetails();
        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, this.gvEmployeeDetails, this.SortDirection);
    }

    #endregion

    #region "Control Events"

    protected void btn_upload_FILE_Click1(object sender, EventArgs e)
    {
        ViewState["url"] = FilePhoto.FileBytes;
        string fpath = Server.MapPath("~\\SchoolAdmin\\EmployeePhoto\\");
        if (!Directory.Exists(fpath))
        {
            var dir = new DirectoryInfo("~\\SchoolAdmin\\");
            dir.CreateSubdirectory("EmployeePhoto");
        }
        else
        {
            string schoolName = AppSessions.SchoolName;
            string UserName = txtAddFirstName.Text + "_" + txtAddLastName.Text;
            string FileName = schoolName + "_" + UserName;
            string FilePathName = FilePhoto.FileName;
            string Extension = Path.GetExtension(FilePathName);
            string FileNewName = FileName + Extension;
            string FileLocation;
            FileLocation = fpath + FilePathName;
            if (File.Exists(FileLocation))
            {
                string UserName1 = txtAddFirstName.Text + "_" + txtAddMiddleName.Text + "_" + txtAddLastName.Text;
                string FileName1 = schoolName + "_" + UserName1;
                string FilePathName1 = FilePhoto.FileName;
                string Extension1 = Path.GetExtension(FilePathName1);
                string FileNewName1 = FileName1 + Extension1;
                string FileLocation1 = fpath + FilePathName1;
                FilePhoto.SaveAs(FileLocation1);

                imgPhoto.ImageUrl = "~\\SchoolAdmin\\EmployeePhoto\\" + FilePathName;
            }
            else
            {
                FilePhoto.SaveAs(FileLocation);
                imgPhoto.ImageUrl = "~\\SchoolAdmin\\EmployeePhoto\\" + FilePathName;
            }
            pnlEdit.CssClass = "InVisible";
            pnlSearch.CssClass = "InVisible";
            pnlAdd.CssClass = "Visible";
        }
    }

    protected void btn_update_FILE_Click(object sender, EventArgs e)
    {
        FormView1.Visible = false;
        imgUpdate.Visible = true;
        ViewState["PhotoUrl"] = fupUpdateFileUploadPhoto.FileBytes;
        string fpath = Server.MapPath("~\\SchoolAdmin\\EmployeePhoto\\");
        if (!Directory.Exists(fpath))
        {
            var dir = new DirectoryInfo("~\\SchoolAdmin\\");
            dir.CreateSubdirectory("EmployeePhoto");
        }
        else
        {
            string firstname = txtUpdateFirstName.Text;
            string schoolName = AppSessions.SchoolName;
            string UserName = txtUpdateFirstName.Text + "_" + txtUpdateLastName.Text;
            string FileName = schoolName + "_" + UserName;
            string FilePathName = fupUpdateFileUploadPhoto.FileName;
            string Extension = Path.GetExtension(FilePathName);
            string FileNewName = FileName + Extension;
            string FileLocation;
            //FileLocation = fpath + FilePathName;
            FileLocation = fpath + FileNewName;
            if (File.Exists(FileLocation))
            {
                string UserName1 = txtUpdateFirstName.Text + "_" + txtUpdateMiddleName.Text + "_" + txtUpdateLastName.Text;
                string FileName1 = schoolName + "_" + UserName1;
                string FilePathName1 = fupUpdateFileUploadPhoto.FileName;
                string Extension1 = Path.GetExtension(FilePathName1);
                string FileNewName1 = FileName1 + Extension1;
                string FileLocation1 = fpath + FileNewName1;
                fupUpdateFileUploadPhoto.SaveAs(FileLocation1);
                imgUpdate.ImageUrl = "~\\SchoolAdmin\\EmployeePhoto\\" + FileNewName1;
                imgUpdate.Visible = true;
            }
            else
            {
                fupUpdateFileUploadPhoto.SaveAs(FileLocation);
                imgUpdate.ImageUrl = "~\\SchoolAdmin\\EmployeePhoto\\" + FileNewName;
                imgUpdate.Visible = true;
            }
            //pnlEdit.CssClass = "Visible";
            //pnlSearch.CssClass = "InVisible";
            //pnlAdd.CssClass = "InVisible";
        }
    }

    protected void ibtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        this.RefreshAddControls();
    }

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        this.RefreshSearchControls();
    }

    protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        imgUpdate.Visible = false;
        FormView1.Visible = true;
        DataSet dsSelect = new DataSet();
        string SearchCondition = string.Empty;
        string IFormat = "dd-MMM-yyyy";
        int CoundChecked = (int)EnumFile.AssignValue.Zero;
        int GRrowIndex = (int)EnumFile.AssignValue.Zero;
        foreach (GridViewRow gr in gvEmployeeDetails.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                CoundChecked = CoundChecked + 1;
                GRrowIndex = gr.RowIndex;
            }
        }

        if (CoundChecked == (int)EnumFile.AssignValue.Zero || CoundChecked > (int)EnumFile.AssignValue.One)
        {
            WebMsg.Show("Please select one record to Update.");
        }
        else
        {


            this.InvisiblePanels();
            pnlEdit.CssClass = "Visible";
            int employeeid = Convert.ToInt32(gvEmployeeDetails.DataKeys[GRrowIndex]["EmployeeID"].ToString());
            this.ViewState["EmployeeID"] = employeeid;
            SearchCondition = "and Employee.EmployeeID= " + Convert.ToString(employeeid);
            dsSelect = dsSelect = this.BAL_Employee.BAL_EmployeeDetailsBySchoolID(Convert.ToInt32(this.Session["SchoolID"]), SearchCondition);

            FormView1.DataSource = dsSelect;
            FormView1.DataBind();
            txtUpdateFirstName.Text = dsSelect.Tables[0].Rows[0]["FirstName"].ToString();
            txtUpdateMiddleName.Text = dsSelect.Tables[0].Rows[0]["MiddleName"].ToString();
            txtUpdateLastName.Text = dsSelect.Tables[0].Rows[0]["LastName"].ToString();
            txtUpdateDOB.Text = Convert.ToDateTime(dsSelect.Tables[0].Rows[0]["DateOfBirth"].ToString()).ToString(IFormat);
            rlstUpdateGender.SelectedValue = dsSelect.Tables[0].Rows[0]["Gender"].ToString();
            txtUpdateBloodGroup.Text = dsSelect.Tables[0].Rows[0]["BloodGroup"].ToString();
            txtUpdatePermanentAddress.Text = dsSelect.Tables[0].Rows[0]["Address"].ToString();
            txtUpdateContactNo.Text = dsSelect.Tables[0].Rows[0]["ContactNo"].ToString();
            txtUpdateEmail.Text = dsSelect.Tables[0].Rows[0]["EmailID"].ToString();
            txtUpdateQualification.Text = dsSelect.Tables[0].Rows[0]["Qualification"].ToString();
            txtUpdateDesignation.Text = dsSelect.Tables[0].Rows[0]["Designation"].ToString();
            if (dsSelect.Tables[0].Rows[0]["Image"].ToString() != string.Empty)
            {
                byte[] ImageBytes = (byte[])dsSelect.Tables[0].Rows[0]["Image"];
                ViewState["ImageBytes"] = ImageBytes;
                if (ImageBytes.Length == 0)
                {
                    FormView1.Visible = false;
                    imgUpdate.Visible = true;
                    imgUpdate.ImageUrl = "~/SchoolAdmin/EmployeePhoto/NoPhoto.jpg";
                }
            }
            else
            {
                FormView1.Visible = false;
                imgUpdate.Visible = true;
                imgUpdate.ImageUrl = "~/SchoolAdmin/EmployeePhoto/NoPhoto.jpg";
            }

            ////fupUpdateFileUploadPhoto.FileContent.Read(buffer, 0, buffer.Length);
            ddlUpdateSecurityQues.SelectedIndex = Convert.ToInt32(dsSelect.Tables[0].Rows[0]["SecurityQuestion"].ToString());
            txtUpdateSecAns.Text = dsSelect.Tables[0].Rows[0]["SecurityAnswer"].ToString();
        }
    }

    protected void btnAddSave_Click(object sender, EventArgs e)
    {
        try
        {
            string schoolName = AppSessions.SchoolName;
            string IFormat = "dd-MMM-yyyy";
            int EmpCode = Convert.ToInt32(ViewState["EmployeeID"]);
            EmpCode++;
            this.Employee.code = schoolName + "00" + EmpCode;
            this.Employee.roleid = AppSessions.RoleID;
            this.Employee.schoolid = Convert.ToInt32(this.Session["SchoolID"]);
            this.Employee.firstname = txtAddFirstName.Text;
            this.Employee.middlename = txtAddMiddleName.Text;
            this.Employee.lastname = txtAddLastName.Text;
            if (rlstAddGender.SelectedIndex == (int)EnumFile.AssignValue.Zero)
            {
                this.Employee.gender = 'M';
            }
            else if (rlstAddGender.SelectedIndex == (int)EnumFile.AssignValue.One)
            {
                this.Employee.gender = 'F';
            }

            this.Employee.dateofbirth = Convert.ToDateTime(DateTime.Parse(txtAddDOB.Text).ToString(IFormat));
            this.Employee.bloodgroup = txtAddBloodGroup.Text;
            this.Employee.address = txtAddPermanentAddress.Text;
            this.Employee.emailid = txtAddEmail.Text;
            this.Employee.contactno = Convert.ToInt32(txtAddContactNumber.Text);
            this.Employee.qualification = txtAddQualification.Text;
            this.Employee.designation = txtAddDesignation.Text;
            this.Employee.securityquestion = ddlAddSecurityQues.SelectedIndex;
            this.Employee.securityanswer = txtAddSecAns.Text;
            this.Employee.loginid = txtAddFirstName.Text + txtAddLastName.Text;
            this.Employee.password = "1234";

            string UserName = txtAddFirstName.Text + "_" + txtAddLastName.Text;
            string FileName = schoolName + "_" + UserName;
            string UserName1 = txtAddFirstName.Text + "_" + txtAddMiddleName.Text + "_" + txtAddLastName.Text;
            string FileName1 = schoolName + "_" + UserName1;

            byte[] mybytes = (byte[])ViewState["url"];
            this.Employee.image1 = mybytes;

            this.Employee.createdby = AppSessions.EmpolyeeID;
            this.Employee.modifiedby = AppSessions.EmpolyeeID;

            this.BAL_Employee.BAL_Employee_Insert(this.Employee, "Insert");
            this.RefreshSearchControls();

            //WebMsg.Show("Record Inserted");
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Recodrd inserted sucessfully');", true);


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
        }
    }

    protected void btnSearchGo_Click(object sender, EventArgs e)
    {
        this.BindGridEmployeeDetails();
    }

    int CoundChecked = (int)EnumFile.AssignValue.Zero;

    protected void ImgBtnActivate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        try
        {

            int Count = 0;

            if (PnlActivateDeactivate.Visible == true)
            {
                PnlActivateDeactivate.Visible = false;
                pnlSearch.CssClass = "Visible";
                pnlAdd.CssClass = "InVisible";

            }
            else
            {
                PnlActivateDeactivate.Visible = true;
                InvisiblePanels();

            }

            //if (Count > ((int)EnumFile.AssignValue.Zero))
            //{
            //    PnlActivateDeactivate.Visible = true;
            //    pnlSearch.Visible = false;

            //    //this.GvUserList.Enabled = false;
            //}
            //else
            //{
            //    WebMsg.Show("Please select atleast one record.");
            //}


            ////PnlActivateDeactivate.Visible = true;
            ////pnlAdd.Visible = false;
            ////pnlEdit.Visible = false;
            ////pnlSearch.Visible = false;



            //int GRrowIndex = (int)EnumFile.AssignValue.Zero;


            //if (CoundChecked == (int)EnumFile.AssignValue.Zero || CoundChecked > (int)EnumFile.AssignValue.One)
            //{
            //    WebMsg.Show("Please select one record to Update.");
            //}
            //else
            //{
            //    WebMsg.Show("Record updated sucessfully");
            //}



        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected int GetCheckedData()
    {
        int Flag = 0;
        string ActiveDeactive = string.Empty;
        string ActiveDeactiveStudent = string.Empty;
        int Count = (int)EnumFile.AssignValue.Zero;
        int SCount = (int)EnumFile.AssignValue.Zero;

        try
        {
            foreach (GridViewRow gr in this.gvEmployeeDetails.Rows)
            {
                CheckBox Chk = (CheckBox)gr.FindControl("chkSelect");

                if (Chk.Checked == true)
                {
                    if (this.gvEmployeeDetails.DataKeys[gr.RowIndex]["RoleID"].ToString() == "4")
                    {
                        if (SCount == 0)
                        {
                            ActiveDeactiveStudent = this.gvEmployeeDetails.DataKeys[gr.RowIndex]["UserID"].ToString();
                        }
                        else
                        {
                            ActiveDeactiveStudent = ActiveDeactiveStudent + "," + this.gvEmployeeDetails.DataKeys[gr.RowIndex]["UserID"].ToString();
                        }

                        SCount = SCount + 1;
                    }
                    else
                    {
                        if (Count == 0)
                        {
                            ActiveDeactive = this.gvEmployeeDetails.DataKeys[gr.RowIndex]["UserID"].ToString();
                        }
                        else
                        {
                            ActiveDeactive = ActiveDeactive + "," + this.gvEmployeeDetails.DataKeys[gr.RowIndex]["UserID"].ToString();
                        }

                        Count = Count + 1;
                    }
                }
            }

            if (Count > 0 || SCount > 0)
            {
                Flag = 1;
                this.ViewState["ActiveDeactiveUsers"] = ActiveDeactive;
                this.ViewState["ActiveDeactiveStudents"] = ActiveDeactiveStudent;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

        return Flag;
    }

    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        int CountChecked = (int)EnumFile.AssignValue.Zero;
        int GrRowIndex = (int)EnumFile.AssignValue.Zero;
        foreach (GridViewRow gr in gvEmployeeDetails.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gr.FindControl("chkselect");
            if (chk.Checked == true)
            {
                CountChecked++;
                GrRowIndex = gr.RowIndex;
            }
        }

        if (CountChecked == (int)EnumFile.AssignValue.Zero)
        {
            WebMsg.Show("Please select Atleast one record to Delete.");
        }
        else
        {
            this.Employee.employeeid = Convert.ToInt32(gvEmployeeDetails.DataKeys[GrRowIndex]["EmployeeID"].ToString());
            this.BAL_Employee.BAL_Employee_Delete(this.Employee, Convert.ToInt32(this.Session["SchoolID"]), "Delete");
            WebMsg.Show("Record Deleted");
            this.BindGridEmployeeDetails();
            this.RefreshSearchControls();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string IFormat = "dd-MMM-yyyy";
        this.Employee.code = "Epath";
        this.Employee.roleid = AppSessions.RoleID;
        this.Employee.employeeid = Convert.ToInt32(this.ViewState["EmployeeID"]);
        this.Employee.schoolid = Convert.ToInt32(this.Session["SchoolID"]);
        this.Employee.firstname = txtUpdateFirstName.Text;
        this.Employee.middlename = txtUpdateMiddleName.Text;
        this.Employee.lastname = txtUpdateLastName.Text;
        if (rlstUpdateGender.SelectedIndex == (int)EnumFile.AssignValue.Zero)
        {
            this.Employee.gender = 'M';
        }
        else if (rlstUpdateGender.SelectedIndex == (int)EnumFile.AssignValue.One)
        {
            this.Employee.gender = 'F';
        }

        this.Employee.dateofbirth = Convert.ToDateTime(DateTime.Parse(txtUpdateDOB.Text).ToString(IFormat));
        this.Employee.bloodgroup = txtUpdateBloodGroup.Text;
        this.Employee.address = txtUpdatePermanentAddress.Text;
        this.Employee.emailid = txtUpdateEmail.Text;
        this.Employee.contactno = Convert.ToInt32(txtUpdateContactNo.Text);
        this.Employee.qualification = txtUpdateQualification.Text;
        this.Employee.designation = txtUpdateDesignation.Text;
        this.Employee.securityquestion = ddlUpdateSecurityQues.SelectedIndex;
        this.Employee.securityanswer = txtUpdateSecAns.Text;
        ////Employee.loginid = AppSessions.EmpolyeeID.ToString();
        ////Employee.password = "1234";
        byte[] IsNull = (byte[])ViewState["PhotoUrl"];
        if (IsNull == null)
        {
            this.Employee.image1 = (byte[])ViewState["ImageBytes"];
        }
        else
        {
            this.Employee.image1 = (byte[])ViewState["PhotoUrl"];
        }
        //// Employee.lastlogindate = txtLastLoginDate.Text;
        ////Employee.attemptcount = txtAttemptCount.Text;
        //// Employee.isactive = txtIsActive.Text;
        //// Employee.createdon = txtCreatedOn.Text;
        this.Employee.createdby = AppSessions.EmpolyeeID;
        ////Employee.modifiedon = txtModifiedOn.Text;
        this.Employee.modifiedby = AppSessions.EmpolyeeID;
        ////Employee.allowmultiplesession = txtAllowMultipleSession.Text;
        this.BAL_Employee.BAL_Employee_Update(this.Employee, "Update");
        this.RefreshSearchControls();
        WebMsg.Show("Record Updated");
    }

    protected void btnSearchReset_Click(object sender, EventArgs e)
    {
        this.InvisiblePanels();
        pnlSearch.CssClass = "Visible";
        txtSearchFirstName.Text = string.Empty;
        txtSearchMiddleName.Text = string.Empty;
        txtSearchLastName.Text = string.Empty;
        txtSearchDOB.Text = string.Empty;
        rlstSearchGender.ClearSelection();
        txtSearchBloodGroup.Text = string.Empty;
        rlstActive.ClearSelection();
        ////txtSearchPermanentAddress.Text = string.Empty;
        ////txtSearchContactNumber.Text = string.Empty;
        ////txtSearchEmail.Text = string.Empty;
        txtSearchQualification.Text = string.Empty;
        //txtSearchDesignation.Text = string.Empty;
        BindGridEmployeeDetails();
    }

    protected void btnAddReset_Click(object sender, EventArgs e)
    {
        this.RefreshAddControls();
    }

    protected void btnUpdateReset_Click(object sender, EventArgs e)
    {
        this.RefreshControls();
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.RefreshSearchControls();
    }

    #endregion

    #region "User Definded Function"

    protected void RefreshSearchControls()
    {
        this.BindGridEmployeeDetails();
        this.InvisiblePanels();
        pnlSearch.CssClass = "Visible";
        txtSearchFirstName.Text = string.Empty;
        txtSearchMiddleName.Text = string.Empty;
        txtSearchLastName.Text = string.Empty;
        txtSearchDOB.Text = string.Empty;
        rlstSearchGender.ClearSelection();
        txtSearchBloodGroup.Text = string.Empty;
        ////txtSearchPermanentAddress.Text = string.Empty;
        ////txtSearchContactNumber.Text = string.Empty;
        ////txtSearchEmail.Text = string.Empty;
        txtSearchQualification.Text = string.Empty;
        txtSearchDesignation.Text = string.Empty;
    }

    protected void RefreshControls()
    {
        this.InvisiblePanels();
        pnlEdit.CssClass = "Visible";
        txtUpdateFirstName.Text = string.Empty;
        txtUpdateMiddleName.Text = string.Empty;
        txtUpdateLastName.Text = string.Empty;
        txtUpdateDOB.Text = string.Empty;
        rlstUpdateGender.ClearSelection();
        txtUpdateBloodGroup.Text = string.Empty;
        txtUpdatePermanentAddress.Text = string.Empty;
        txtUpdateContactNo.Text = string.Empty;
        txtUpdateEmail.Text = string.Empty;
        txtUpdateQualification.Text = string.Empty;
        txtUpdateDesignation.Text = string.Empty;
        FormView1.DataSource = null;
        FormView1.DataBind();
        imgUpdate.ImageUrl = "~/SchoolAdmin/EmployeePhoto/NoPhoto.jpg";
        imgUpdate.Visible = true;
        txtUpdatePhotoPath.Text = string.Empty;
        ddlUpdateSecurityQues.SelectedIndex = (int)EnumFile.AssignValue.Zero;
        txtUpdateSecAns.Text = string.Empty;
    }

    protected void InvisiblePanels()
    {
        pnlAdd.CssClass = "InVisible";
        pnlEdit.CssClass = "InVisible";
        pnlSearch.CssClass = "InVisible";
    }

    protected void RefreshAddControls()
    {
        this.BindGridEmployeeDetails();
        pnlAdd.CssClass = "Visible";
        pnlEdit.CssClass = "Invisible";
        pnlSearch.CssClass = "Invisible";
        txtAddFirstName.Text = string.Empty;
        txtAddMiddleName.Text = string.Empty;
        txtAddLastName.Text = string.Empty;
        txtAddDOB.Text = string.Empty;
        rlstAddGender.ClearSelection();
        txtAddBloodGroup.Text = string.Empty;
        txtAddPermanentAddress.Text = string.Empty;
        txtAddContactNumber.Text = string.Empty;
        txtAddEmail.Text = string.Empty;
        txtAddQualification.Text = string.Empty;
        txtAddDesignation.Text = string.Empty;
        txtAddFilePath.Text = string.Empty;
        imgPhoto.ImageUrl = "~/SchoolAdmin/EmployeePhoto/NoPhoto.jpg";
        ddlAddSecurityQues.SelectedIndex = (int)EnumFile.AssignValue.Zero;
        txtAddSecAns.Text = string.Empty;
    }

    #endregion

    protected void BtnActDeactSub_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gr in gvEmployeeDetails.Rows)
            {
                CheckBox chk = new CheckBox();
                chk = (CheckBox)gr.FindControl("chkSelect");
                if (chk.Checked == true)
                {
                    CoundChecked = CoundChecked + 1;
                }
            }

            

            if (CoundChecked == (int)EnumFile.AssignValue.Zero)
            {
                //WebMsg.Show("Please select one record to Update.");
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please select one record to Update.');", true);
            }
            else
            {
                int GRrowIndex = (int)EnumFile.AssignValue.Zero;
                Boolean status;

                if (RdbActive.Checked == true)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                foreach (GridViewRow gr in gvEmployeeDetails.Rows)
                {
                    CheckBox chk = new CheckBox();
                    chk = (CheckBox)gr.FindControl("chkSelect");
                    if (chk.Checked == true)
                    {
                        CoundChecked = CoundChecked + 1;
                        GRrowIndex = gr.RowIndex;
                        int employeeid = Convert.ToInt32(gvEmployeeDetails.DataKeys[GRrowIndex]["EmployeeID"].ToString());
                        this.BAL_Employee.BAL_Employee_ChangeStatus(employeeid, Convert.ToInt32(this.Session["SchoolID"]), status);
                    }
                }
                this.BindGridEmployeeDetails();
                this.RefreshSearchControls();
                PnlActivateDeactivate.Visible = false;
                pnlSearch.CssClass = "InVisible";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record updated sucessfully.');", true);
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
}