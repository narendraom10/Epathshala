using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text;
using System.Collections;

public partial class Admin_PackageRegistration : System.Web.UI.Page
{

    SYS_BMS_BLogic SYS_BMSBLogic;
    SYS_Subject_BLogic Subject_Blogic;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                GetDDLBMSDetails();
                //BindChkBoxSubject();
                SelectAllPackage();
                BindGrid();
                txtPackageName.Attributes.Add("onblur", "CallMethod()");

            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            GetData();
        }


    }

    public void SelectAllPackage()
    {
        try
        {
            DataAccess DAL_Select_All = new DataAccess();
            DataTable ds_selectpackage = new DataTable();
            ds_selectpackage = DAL_Select_All.GetDataTable("select * from PackageType order by Name");
            //DataSet ds =new DataSet();
            //ds.Tables.Add(ds_selectpackage);

            //ddlpackage.Items.Clear();
            //ddlpackage.Items.Insert(0, "-- Select --");
            //ddlpackage.Items[0].Value = "0";

            //ddlpackage.DataSource = ds_selectpackage;
            //ddlpackage.DataTextField="Name";
            //ddlpackage.DataValueField="PackageID";
            //ddlpackage.DataBind();

        }
        catch (Exception ex)
        {

        }
    }
    private void GetDDLBMSDetails()
    {
        try
        {
            DropDownFill DdlFilling = new DropDownFill();
            SYS_BMSBLogic = new SYS_BMS_BLogic();
            DataSet dsselectBMS = new DataSet();
            dsselectBMS = SYS_BMSBLogic.BAL_SYS_BMS_SelectAll();

            if (dsselectBMS.Tables.Count > ((int)EnumFile.AssignValue.Zero))
            {

                if (dsselectBMS.Tables[0].Rows.Count > 0)
                {
                    ddlBoardMediumStandard.Items.Clear();
                    ddlBoardMediumStandard.Items.Insert(0, "-- Select --");
                    ddlBoardMediumStandard.Items[0].Value = "0";
                    ddlBoardMediumStandard.DataSource = dsselectBMS.Tables[0];
                    ddlBoardMediumStandard.DataTextField = "BMS";
                    ddlBoardMediumStandard.DataValueField = "BMSID";
                    ddlBoardMediumStandard.DataBind();
                }
                else
                {
                    ddlBoardMediumStandard.Items.Clear();
                    ddlBoardMediumStandard.DataBind();
                    ddlBoardMediumStandard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                    ddlBoardMediumStandard.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                }
            }
        }
        catch (Exception ex)
        {

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


    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {

            EnterPackagedetail();
            txtPackageName.Text = "";
            txtdescription.Text = "";
            txtmonth.Text = "";
            PanelAdd.Visible = false;
            //rqdPackageName.Text = "";
            //lblAvailibility.Text = "";

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password has been sent to your email successfully.');window.location ='Login.aspx';", true);





        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    Package_BLogic package;
    int New_Package_ID = 0;
    public void EnterPackagedetail()
    {
        try
        {

            package = new Package_BLogic();
            Package Newpackage = new Package();
            //Newpackage.Name = txtPackageName.Text;
           // Newpackage.Description = txtdescription.Text;
            Newpackage.NoOfMonth = Convert.ToInt32(txtmonth.Text);

            string packageavailablity = checkpackagename(txtPackageName.Text.Trim());

            if (packageavailablity.Trim().ToLower() == "false")
            {
                New_Package_ID = package.InsertNewPackage(Newpackage);
                Session["New_Package_ID"] = New_Package_ID;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "<script> alert('Record inserted sucessfully') ;window.location ='PackageRegistration.aspx' </script>", false);

            }
            else
            {
                //lblAvailibility.Text = "Package already exist";
                txtPackageName.Text = "";
                txtdescription.Text = "";
                txtprice.Text = "";

                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Message", "alert('This package alredy exist........')",true);

            }



        }
        catch (Exception ex)
        {

        }




    }
    protected void ddlBoardMediumStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlBoardMediumStandard.SelectedIndex == 0)
            {
                chkAllSubject.Enabled = false;
                clstSubject.Enabled = false;
                txtprice.Enabled = false;

            }
            else
            {
                chkAllSubject.Enabled = true;
                clstSubject.Enabled = true;
                txtprice.Enabled = true;
                BindChkBoxSubject();
            }


        }
        catch (Exception ex)
        {

        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        try
        {
            package = new Package_BLogic();
            Package Newpackage = new Package();

            string subjectid = " ";
            string subjectname = " ";
            foreach (ListItem chk in clstSubject.Items)
            {
                if (chk.Selected == true)
                {
                    subjectid += chk.Value.ToString() + ",";
                    subjectname += chk.Text.ToString() + ",";
                }
            }

            subjectid = subjectid.Remove(subjectid.Length-1);
            subjectname = subjectname.Remove(subjectname.Length - 1);

            //foreach (ListItem chk in clstSubject.Items)
            //{
            //    if (chk.Selected == true)
            //    {
            Newpackage.PackageName = txtPackageName.Text;
            Newpackage.PackageDescription = txtdescription.Text;
            Newpackage.BMSID = Convert.ToInt32(ddlBoardMediumStandard.SelectedValue);
            Newpackage.SubjectID = subjectid;
            Newpackage.Subject = subjectname;
            //Newpackage.ID = Convert.ToInt32(Session["New_Package_ID"].ToString());
            Newpackage.NoOfMonth = Convert.ToInt32(txtmonth.Text);
            Newpackage.Price = Convert.ToDecimal(txtprice.Text);


            DateTime expirydatetime;

            if (DateTime.TryParse(txtdate.Text, out expirydatetime))
            {
                Newpackage.EndDate = expirydatetime;
            }

            //Newpackage.EndDate = Convert.ToDateTime(DateTime.Now);
            

            if (rbcombo.Checked)
                Newpackage.PackageType = rbcombo.Text;
            else
                Newpackage.PackageType = rbsignle.Text;

            New_Package_ID = package.InsertPackageFeesDetail(Newpackage);


            //    }
            //}

            WebMsg.Show("New Package insterted Sucessfully");


        }
        catch (Exception ex)
        {
            WebMsg.Show("New Package not insterted Sucessfully");
        }
        finally
        {
            // ddlpackage.SelectedIndex = 0;
            ddlBoardMediumStandard.SelectedIndex = 0;
            clstSubject.Items.Clear();
            txtprice.Text = "";
            chkAllSubject.Checked = false;


        }

    }
    protected void btnnewpackage_Click(object sender, EventArgs e)
    {

        // WebMsg.Show("Package registered sucessfully");
        PanelAdd.Visible = true;
        //  mp1.Show();

    }
    protected void ddlpackage_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlpackage.SelectedIndex == 0)
        //{
        //    ddlBoardMediumStandard.Enabled = false;



        //}
        //else
        //{
        //    ddlBoardMediumStandard.Enabled = true;
        //    Session["New_Package_ID"] = ddlpackage.SelectedValue.ToString();
        //}

    }
    #region WebMethod

    public string checkpackagename(string packagename)
    {

        Package_BLogic package = new Package_BLogic();

        bool IsExists = package.CheckPackageAvailablity(packagename);
        if (IsExists)
            return "True";
        else
            return "False";
    }
    #endregion

    [WebMethod]
    public static string CheckPackageExist(string res)
    {
        Package_BLogic package = new Package_BLogic();
        bool IsExists = package.CheckPackageAvailablity(res);
        if (IsExists)
            return "True";
        else
            return "False";
    }
    protected void btn_Click(object sender, EventArgs e)
    {

    }


    protected void btnClose_Click1(object sender, EventArgs e)
    {
        txtdescription.Text = "";
        txtmonth.Text = "";
        txtPackageName.Text = "";
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        //ddlpackage.SelectedIndex = 0;
        ddlBoardMediumStandard.SelectedIndex = 0;
        clstSubject.Items.Clear();
        clstSubject.Items.Clear();
        txtprice.Text = "";
        chkAllSubject.Checked = false;
    }
    protected void btn_Click1(object sender, EventArgs e)
    {

    }

    private void BindGrid()
    {
        DataAccess DAL_Select_All = new DataAccess();
        DataTable ds_selectpackage = new DataTable();
        ds_selectpackage = DAL_Select_All.GetDataTable("select * from PackageDetails order by PackageName");

        gvAll.DataSource = ds_selectpackage;
        gvAll.DataBind();
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        gvAll.PageIndex = e.NewPageIndex;
        gvAll.DataBind();
        SetData();
    }

    private void GetData()
    {
        ArrayList arr;
        if (ViewState["SelectedRecords"] != null)
            arr = (ArrayList)ViewState["SelectedRecords"];
        else
            arr = new ArrayList();
        CheckBox chkAll = (CheckBox)gvAll.HeaderRow
                            .Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvAll.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                if (!arr.Contains(gvAll.DataKeys[i].Value))
                {
                    arr.Add(gvAll.DataKeys[i].Value);
                }
            }
            else
            {
                CheckBox chk = (CheckBox)gvAll.Rows[i]
                                   .Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    if (!arr.Contains(gvAll.DataKeys[i].Value))
                    {
                        arr.Add(gvAll.DataKeys[i].Value);
                    }
                }
                else
                {
                    if (arr.Contains(gvAll.DataKeys[i].Value))
                    {
                        arr.Remove(gvAll.DataKeys[i].Value);
                    }
                }
            }
        }
        ViewState["SelectedRecords"] = arr;
    }

    private void SetData()
    {
        int currentCount = 0;
        CheckBox chkAll = (CheckBox)gvAll.HeaderRow.Cells[0].FindControl("chkAll");
        chkAll.Checked = true;
        ArrayList arr = (ArrayList)ViewState["SelectedRecords"];
        for (int i = 0; i < gvAll.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)gvAll.Rows[i].Cells[0].FindControl("chk");
            if (chk != null)
            {
                chk.Checked = arr.Contains(gvAll.DataKeys[i].Value);
                if (!chk.Checked)
                    chkAll.Checked = false;
                else
                    currentCount++;
            }
        }
        hfCount.Value = (arr.Count - currentCount).ToString();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int count = 0;
        SetData();
        gvAll.AllowPaging = false;
        //gvAll.DataBind();
        ArrayList arr = (ArrayList)ViewState["SelectedRecords"];
        count = arr.Count;
        for (int i = 0; i < gvAll.Rows.Count; i++)
        {
            if (arr.Contains(gvAll.DataKeys[i].Value))
            {
                DeleteRecord(gvAll.DataKeys[i].Value.ToString());
                arr.Remove(gvAll.DataKeys[i].Value);
            }
        }
        ViewState["SelectedRecords"] = arr;
        hfCount.Value = "0";
        gvAll.AllowPaging = true;
        BindGrid();
        SelectAllPackage();
        ShowMessage(count);
    }

    private void DeleteRecord(string PackageID)
    {

        string query = "delete from PackageDetails where PackageID=" + PackageID;
        DataAccess DAL_Select_All = new DataAccess();

        int value = DAL_Select_All.Excutenonquery(query);

    }

    private void ShowMessage(int count)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("alert('");
        // sb.Append(count.ToString());
        sb.Append(" records deleted.');");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(),
                        "script", sb.ToString());
    }
}