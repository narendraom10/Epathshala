/// <summary> 
/// <DevelopedBy>"SHEEL"</DevelopedBy>
/// <UpdatedBy></UpdatedBy>
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_StandardAllocation : System.Web.UI.Page
{
    #region "Declarations"
    UserList_BLogic BUserList = new UserList_BLogic();
    UserList PUserList = new UserList();
    DropDownFill DFill = new DropDownFill();
    SYS_Role_BLogic BSysRole = new SYS_Role_BLogic();
    SYS_Role PSysRole = new SYS_Role();

    SYS_Standard PSysStandard = new SYS_Standard();
    School_BLogic BSchool = new School_BLogic();
    Employee_BLogic BEmployee = new Employee_BLogic();
    Employee PEmployee = new Employee();
    SYS_Standard_BLogic BSysStandard = new SYS_Standard_BLogic();
    string GridCondition = string.Empty;
    School_BLogic SchoolBLogic = new School_BLogic();
    DropDownFill DdlFilling;


    #endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                PnlSearch.Visible = true;
                this.ViewState["UserRoleID"] = AppSessions.RoleID;
                if (Request.QueryString["SchoolID"] != "0" & Request.QueryString["SchoolID"] != null)
                {
                    this.ViewState["SchoolID"] = Request.QueryString["SchoolID"];
                }
                else
                {
                    this.ViewState["SchoolID"] = AppSessions.SchoolID;
                }
                LtSchoolID.Text = this.ViewState["SchoolID"].ToString();
                this.ViewState["SchoolName"] = AppSessions.SchoolName;
                ddlSchool.Text = this.ViewState["SchoolName"].ToString();
                if (this.ViewState["UserRoleID"].ToString() == "1")
                {
                    ddlSchool.Enabled = true;
                }
                if (AppSessions.BoardID != 0)
                {
                    this.ViewState["BoardID"] = AppSessions.BoardID;
                }
                if (AppSessions.MediumID != 0)
                {
                    this.ViewState["MediumID"] = AppSessions.MediumID;
                }
                FillSchoolDropdown(ddlSchool);
            }
        }
        catch (Exception Ex)
        {
            WebMsg.Show(Ex.Message);
        }
    }

    #endregion

    #region "Control Events"

    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int selectvalue = (int)(ViewState["selectvalue"]);
            this.GvStandard.PageIndex = ((DropDownList)sender).SelectedIndex;
            string SchoolID = ddlSchool.SelectedValue.ToString();
            FillGvStandardAll(SchoolID, selectvalue);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void BtnGo_Click(object sender, EventArgs e)
    {
        int selectvalue = 0;
        string SchoolID = ddlSchool.SelectedValue.ToString();
        if (rlstAllocated.SelectedValue == "0")
        {
            ViewState["selectvalue"] = 0;
            selectvalue = 0;
            FillGvStandardAll(SchoolID, selectvalue);
        }
        else if (rlstAllocated.SelectedValue == "1")
        {
            ViewState["selectvalue"] = 1;
            selectvalue = 1;
            FillGvStandardAll(SchoolID, selectvalue);
        }
        else
        {
            ViewState["selectvalue"] = 2;
            selectvalue = 2;
            FillGvStandardAll(SchoolID, selectvalue);
        }
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        try
        {
            rlstAllocated.ClearSelection();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void BtnActDeactSub_Click(object sender, EventArgs e)
    {
        try
        {
            int SchoolID = Convert.ToInt32(ddlSchool.SelectedValue); ;
            int StatusID = Convert.ToInt32(LtSchoolID.Text);
            string[] BMSIDCount = this.ViewState["BMSID"].ToString().Split(',');
            int t1 = 0;
            if (RdbAllocated.Checked == true)
            {
                for (int i = 0; i < BMSIDCount.Count(); i++)
                {
                    int BMSID = Convert.ToInt32(BMSIDCount[i].ToString());
                    BSysStandard.BAL_SYS_New_Standard_Insert(SchoolID, BMSID, StatusID);
                    t1++;
                }
                if (t1 == BMSIDCount.Count())
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Standard(s) successfully allocated.')</script>", false);
                }

            }
            else
            {
                t1 = 0;
                for (int i = 0; i < BMSIDCount.Count(); i++)
                {
                    int BMSID = Convert.ToInt32(BMSIDCount[i].ToString());
                    BSysStandard.BAL_SYS_New_Standard_Delete(SchoolID, BMSID);
                    t1++;
                }
                if (t1 == BMSIDCount.Count())
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Standard(s) successfully Deallocated.')</script>", false);
                }
            }
            PnlSearch.Visible = true;
            PnlActivateDeactivate.Visible = false;

            int selectvalue = (int)(ViewState["selectvalue"]);
            string SchoolIDnw = ddlSchool.SelectedValue.ToString();
            FillGvStandardAll(SchoolIDnw, selectvalue);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void ImgBtnActivate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        try
        {
            int Count = 0;
            if (PnlActivateDeactivate.Visible == true)
            {
                PnlActivateDeactivate.Visible = false;
                PnlSearch.Visible = true;
            }
            else
            {
                Count = this.GetCheckedData();
            }
            if (Count > ((int)EnumFile.AssignValue.Zero))
            {
                PnlActivateDeactivate.Visible = true;
                PnlSearch.Visible = false;
                this.GvStandard.Enabled = false;
            }
            else
            {
                //WebMsg.Show("Please select atleast one record.");
                //script type="text/javascript"
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Please select atleast one record.')</script>", false);
                //Response.Write("<script type='text/javascript' >alert('Please select atleast one record.');</script>");
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        dt = SchoolBLogic.BAL_SelectSubjectList("select StatusID from School where SchoolID='" + ddlSchool.SelectedValue.ToString() + "'");
        LtSchoolID.Text = dt.Rows[0]["StatusID"].ToString();


    }

    #endregion

    #region "User Defined Function"

    private void FillGvStandardAll(string SchoolID, int selectvalue)
    {
        try
        {
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            DataTable dtdata = new DataTable();
            dtdata.Columns.Add("Standard", typeof(string));
            dtdata.Columns.Add("Allocated", typeof(string));
            dtdata.Columns.Add("BMSID", typeof(string));

            //DataTable dt = ds1.Tables[0];
            if (selectvalue == 1) // Show ALLOCATED Standards
            {
                ds1 = BSysStandard.get_GvStandard(SchoolID, 'A');
                if (ds1 != null && ds1.Tables.Count > 0)
                {
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        DataRow dtrow = dtdata.NewRow();

                        dtrow["Standard"] = ds1.Tables[0].Rows[i]["Standard"].ToString();
                        dtrow["Allocated"] = "Yes";
                        dtrow["BMSID"] = ds1.Tables[0].Rows[i]["BMSID"].ToString();
                        dtdata.Rows.Add(dtrow);
                    }
                }
            }
            else if (selectvalue == 0) // Show UNALLOCATED Standards
            {
                ds1 = BSysStandard.get_GvStandard(SchoolID, 'D');
                if (ds1 != null && ds1.Tables.Count > 0)
                {
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        // First Logic ---------------------
                        //DataRow dtrow = dtdata.NewRow();
                        //int cnt = dt.Select("StandardID='" + ds2.Tables[0].Rows[i]["StandardID"].ToString() + "' ").Count();
                        //if (cnt < 1)
                        //{
                        //    dtrow["Standard"] = ds2.Tables[0].Rows[i]["Standard"].ToString();
                        //    dtrow["Allocated"] = "No";
                        //    dtrow["BMSID"] = ds2.Tables[0].Rows[i]["BMSID"].ToString();
                        //    dtdata.Rows.Add(dtrow);
                        //}
                        //-------------------
                        DataRow dtrow = dtdata.NewRow();
                        dtrow["Standard"] = ds1.Tables[0].Rows[i]["Standard"].ToString();
                        dtrow["Allocated"] = "No";
                        dtrow["BMSID"] = ds1.Tables[0].Rows[i]["BMSID"].ToString();
                        dtdata.Rows.Add(dtrow);

                    }
                }

            }
            else // Show ALL (ALLOCATED AND DEALLOCATED) Standards
            {
                ds1 = BSysStandard.get_GvStandard(SchoolID, 'A');
                ds2 = BSysStandard.getALL_GvStandard();

                if (ds2 != null && ds1 != null && ds1.Tables.Count > 0 && ds2.Tables.Count > 0)
                {
                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        DataRow dtrow = dtdata.NewRow();
                        int cnt = ds1.Tables[0].Select("BMSID='" + ds2.Tables[0].Rows[i]["BMSID"].ToString() + "' ").Count();
                        if (cnt >= 1)
                        {
                            dtrow["Standard"] = ds2.Tables[0].Rows[i]["Standard"].ToString();
                            dtrow["Allocated"] = "Yes";
                            dtrow["BMSID"] = ds2.Tables[0].Rows[i]["BMSID"].ToString();
                            dtdata.Rows.Add(dtrow);
                        }
                        else
                        {
                            dtrow["Standard"] = ds2.Tables[0].Rows[i]["Standard"].ToString();
                            dtrow["Allocated"] = "No";
                            dtrow["BMSID"] = ds2.Tables[0].Rows[i]["BMSID"].ToString();
                            dtdata.Rows.Add(dtrow);
                        }
                    }
                }
            }
            GvStandard.DataSource = dtdata;
            GvStandard.DataBind();
            GvStandard.Enabled = true;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void GvUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DropDownList DDLSelectPage = (DropDownList)this.GvStandard.BottomPagerRow.FindControl("ddlPageSelector");
            DDLSelectPage.SelectedIndex = e.NewPageIndex;
            this.GvStandard.PageIndex = e.NewPageIndex;
            int selectvalue = (int)(ViewState["selectvalue"]);
            string SchoolID = ddlSchool.SelectedValue.ToString();
            FillGvStandardAll(SchoolID, selectvalue);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void grvEmpStdSubAllocationDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                GridViewOperations GrvOperation = new GridViewOperations();
                GrvOperation.SetPagerButtonStates(this.GvStandard, e.Row, this.Page);
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected int GetCheckedData()
    {
        int Flag = 0;
        int Count = (int)EnumFile.AssignValue.Zero;
        string BMSID = string.Empty;
        try
        {
            foreach (GridViewRow gr in this.GvStandard.Rows)
            {
                CheckBox Chk = (CheckBox)gr.FindControl("ChkUserID");
                if (Chk.Checked == true)
                {
                    Count = Count + 1;
                    BMSID = BMSID + "," + GvStandard.DataKeys[gr.RowIndex]["BMSID"].ToString();
                }
            }
            BMSID = BMSID.Substring(1);
            if (Count > 0)
            {
                Flag = 1;
                this.ViewState["BMSID"] = BMSID;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return Flag;
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
            }
        }
    }

    #endregion
}