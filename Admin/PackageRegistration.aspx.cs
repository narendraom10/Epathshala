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

    #region Declaration
    SYS_BMS_BLogic SYS_BMSBLogic;
    SYS_Subject_BLogic Subject_Blogic;
    string packageid = string.Empty;
    Package_BLogic package;
    int New_Package_ID = 0;
    int selectedcnt = 0;
    #endregion

    #region PageEvents
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                GetDDLBMSDetails();
                BindGrid();
                txtPackageName.Attributes.Add("onblur", "CallMethod()");
                txtdate.Attributes.Add("readonly", "readonly");
            }
            catch (Exception ex)
            {
            }
        }

    }
    #endregion

    #region Control Events

    protected void Save(object sender, EventArgs e)
    {
        try
        {
            package = new Package_BLogic();
            Package Newpackage = new Package();
            Newpackage.PackageFD_ID = Convert.ToInt64(ViewState["packageid"].ToString());
            Newpackage.PackageName = txtpackagenameedit.Text;
            Newpackage.PackageDescription = txtpackagedecriptionedit.Text;
            Newpackage.NoOfMonth = Convert.ToInt32(txtnoofmonthedit.Text);
            Newpackage.Price = Convert.ToDecimal(txtpriceedit.Text);

            DateTime expirydatetime;

            if (DateTime.TryParse(txtdateedit.Text, out expirydatetime))
            {
                Newpackage.EndDate = expirydatetime;
            }

            if (rbtrue.Checked)
            {
                Newpackage.IsActive = true;
            }
            else
            {
                Newpackage.IsActive = false;
            }

            New_Package_ID = package.UpdatePackageDetail(Newpackage);
            WebMsg.Show("Package Update Sucessfully");
            BindGrid();
            ClearFields();
        }
        catch (Exception ex)
        {
        }
    }
    protected void Edit(object sender, EventArgs e)
    {

        try
        {
            Label lbldicription = null;
            Label lblBMS = null;
            Label lblIsActive = null;
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                txtpackagenameedit.Text = row.Cells[1].Text;
                txtpriceedit.Text = row.Cells[3].Text;
                lbldicription = (Label)gvAll.Rows[row.RowIndex].FindControl("lbldicription");
                lblBMS = (Label)gvAll.Rows[row.RowIndex].FindControl("lblBMS");
                lblIsActive = (Label)gvAll.Rows[row.RowIndex].FindControl("lblisactive");
                txtpackagedecriptionedit.Text = lbldicription.Text;
                lblDisplayBMSEdit.Text = lblBMS.Text;
                txtdateedit.Text = row.Cells[6].Text;
                txtnoofmonthedit.Text = row.Cells[4].Text;
                lblsubjectlist.Text = row.Cells[2].Text;
                packageid = gvAll.DataKeys[row.RowIndex].Value.ToString();
                ViewState["packageid"] = packageid;
                txtdateedit.Attributes.Add("readonly", "readonly");
                string isactive = lblIsActive.Text;

                if (isactive.ToLower() == "true")
                {
                    rbtrue.Checked = true;
                    rbfalse.Checked = false;
                }
                else
                {
                    rbfalse.Checked = true;
                    rbtrue.Checked = false;
                }

                popup.Show();
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

            int subjectcount = 0;
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
                    subjectcount = subjectcount + 1;
                }
            }

            subjectid = subjectid.Remove(subjectid.Length - 1);
            subjectname = subjectname.Remove(subjectname.Length - 1);

            Newpackage.PackageName = txtPackageName.Text;
            Newpackage.PackageDescription = txtdescription.Text;
            Newpackage.BMSID = Convert.ToInt32(ddlBoardMediumStandard.SelectedValue);
            Newpackage.SubjectID = subjectid;
            Newpackage.Subject = subjectname;
            //Newpackage.ID = Convert.ToInt32(Session["New_Package_ID"].ToString());
            Newpackage.NoOfMonth = Convert.ToInt32(txtmonth.Text);
            Newpackage.Price = Convert.ToDecimal(txtprice.Text);
            if (rbyes.Checked)
            {
                Newpackage.IsActive = true;
            }
            else
            {
                Newpackage.IsActive = false;
            }

            DateTime expirydatetime;

            if (DateTime.TryParse(txtdate.Text, out expirydatetime))
            {
                Newpackage.EndDate = expirydatetime;
            }

            if (subjectcount > 1)
            {
                Newpackage.PackageType = "Combo";
            }
            else
            {
                Newpackage.PackageType = "Single";
            }

            New_Package_ID = package.InsertPackageFeesDetail(Newpackage);
            WebMsg.Show("New Package insterted Sucessfully");
            BindGrid();
            ClearFields();
        }
        catch (Exception ex)
        {
            WebMsg.Show("New Package not insterted Sucessfully");
        }
        finally
        {

        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClearFields();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            for (int i = 0; i < gvAll.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvAll.Rows[i].Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    DeleteRecord(gvAll.DataKeys[i].Value.ToString());
                    count = count + 1;
                }
            }
            BindGrid();
            ShowMessage(count);
        }
        catch (Exception ex)
        {
        }
    }
    #endregion

    #region Methods

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

    protected void ClearFields()
    {
        txtPackageName.Text = string.Empty;
        txtdescription.Text = string.Empty;
        txtdate.Text = string.Empty;
        txtmonth.Text = string.Empty;
        txtprice.Text = string.Empty;
        ddlBoardMediumStandard.SelectedIndex = 0;
        clstSubject.Items.Clear();
        chkAllSubject.Checked = false;
        rbyes.Checked = true;
        rbno.Checked = false;
    }

    protected void ClearFieldsEdit()
    {
        ClearFields();
        txtpackagenameedit.Text = string.Empty;
        lblDisplayBMSEdit.Text = string.Empty;
        lblsubjectlist.Text = string.Empty;
        txtpriceedit.Text = string.Empty;
        txtpackagedecriptionedit.Text = string.Empty;
        txtmonth.Text = string.Empty;
        txtdateedit.Text = string.Empty;
        txtnoofmonthedit.Text = string.Empty;
        rbtrue.Checked = true;
        rbfalse.Checked = false;

    }

    private void BindGrid()
    {
        try
        {
            DataAccess DAL_Select_All = new DataAccess();
            DataTable ds_selectpackage = new DataTable();
            ds_selectpackage = DAL_Select_All.GetDataTable("SELECT     PackageDetails.*, SYS_BMS.BMS FROM PackageDetails INNER JOIN SYS_BMS ON PackageDetails.BMSID = SYS_BMS.BMSID order by CreatedDateTime Desc");
            if (ds_selectpackage != null)
            {
                gvAll.DataSource = ds_selectpackage;
                gvAll.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    //private void GetData()
    //{
    //    ArrayList arr;
    //    if (ViewState["SelectedRecords"] != null)
    //        arr = (ArrayList)ViewState["SelectedRecords"];
    //    else
    //        arr = new ArrayList();
    //    CheckBox chkAll = (CheckBox)gvAll.HeaderRow
    //                        .Cells[0].FindControl("chkAll");
    //    for (int i = 0; i < gvAll.Rows.Count; i++)
    //    {
    //        if (chkAll.Checked)
    //        {
    //            if (!arr.Contains(gvAll.DataKeys[i].Value))
    //            {
    //                arr.Add(gvAll.DataKeys[i].Value);
    //            }
    //        }
    //        else
    //        {
    //            CheckBox chk = (CheckBox)gvAll.Rows[i]
    //                               .Cells[0].FindControl("chk");
    //            if (chk.Checked)
    //            {
    //                if (!arr.Contains(gvAll.DataKeys[i].Value))
    //                {
    //                    arr.Add(gvAll.DataKeys[i].Value);
    //                }
    //            }
    //            else
    //            {
    //                if (arr.Contains(gvAll.DataKeys[i].Value))
    //                {
    //                    arr.Remove(gvAll.DataKeys[i].Value);
    //                }
    //            }
    //        }
    //    }
    //    ViewState["SelectedRecords"] = arr;
    //}

    //private void SetData()
    //{
    //    int currentCount = 0;
    //    CheckBox chkAll = (CheckBox)gvAll.HeaderRow.Cells[0].FindControl("chkAll");
    //    chkAll.Checked = true;
    //    ArrayList arr = (ArrayList)ViewState["SelectedRecords"];
    //    for (int i = 0; i < gvAll.Rows.Count; i++)
    //    {
    //        CheckBox chk = (CheckBox)gvAll.Rows[i].Cells[0].FindControl("chk");
    //        if (chk != null)
    //        {
    //            chk.Checked = arr.Contains(gvAll.DataKeys[i].Value);
    //            if (!chk.Checked)
    //                chkAll.Checked = false;
    //            else
    //                currentCount++;
    //        }
    //    }
    //    hfCount.Value = (arr.Count - currentCount).ToString();
    //}

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
        sb.Append(" Record(s) Deleted Sucessfully');");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(),
                        "script", sb.ToString());

    }

    #endregion
}