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
using System.Drawing;



public partial class Admin_SysConfigPage : System.Web.UI.Page
{
    #region Variables

    Student_DashBoard_BLogic obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
    int t1 = 0;
    #endregion

    #region "Page events"
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDDLFieldGroup(ddlFieldGroup);
        }
        else
        {

        }
    }
    #endregion

    #region "Control Events"
    
    protected void BttnOK_Click(object sender, EventArgs e)
    {
        string FieldGroup = ddlFieldGroup.Text;
        FillGvlstSysConfig(FieldGroup);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string Field = TxtBxField.Text;
        string Type = TxtBxType.Text;
        string value = TxtBxValue.Text;
        string FieldGroup = TxtBxFieldGroupPopup.Text;
        string Description = TxtBxDescription.Text;
        DataSet ds = new DataSet();
        try
        {
            ds = obj_BAL_Student_Dashboard.BAL_Insert_SysConfigFields(Field, Type, value, FieldGroup, Description);
            if (ds.Tables.Count > 0)
            {
                t1 = Convert.ToInt16(ds.Tables[0].Rows[0]["Status"].ToString());
                if (t1 == 2)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Data is entered successfully.')</script>");
                    FillDDLFieldGroup(ddlFieldGroup);
                    ClearControls();
                    mp1.Hide();
                }
                if (t1 == 1)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Duplicate data can not be entered.')</script>");
                    ClearControls();
                    mp1.Hide();
                }
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Data not entered.')</script>");
                ClearControls();
                mp1.Hide();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void BtnEditcntrl_Click(object sender, EventArgs e)
    {
        string Field = TxtBxFieldEdt.Text;
        string Type = TxtBxTypeEdt.Text;
        string value = TxtBxValueEdt.Text;
        string FieldGroup = TxtBxFieldGroupEdt.Text;
        string Description = TxtBxDescriptionEdt.Text;
        try
        {
            t1 = obj_BAL_Student_Dashboard.BAL_Edit_SysConfigFields(Field, Type, value, FieldGroup, Description);
            if (t1 > 0)
            {
                try
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Data is updated successfully.')</script>");
                    FillGvlstSysConfig(FieldGroup);
                    FillDDLFieldGroup(ddlFieldGroup);
                    ClearControls();
                    mp1.Hide();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Data is not entered.')</script>");
                ClearControls();
                mp1.Hide();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    
    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int index = GvlstSysConfig.SelectedRow.RowIndex;
            TxtBxFieldEdt.Text = GvlstSysConfig.SelectedRow.Cells[0].Text;
            TxtBxTypeEdt.Text = GvlstSysConfig.SelectedRow.Cells[1].Text;
            TxtBxValueEdt.Text = GvlstSysConfig.SelectedRow.Cells[2].Text;
            TxtBxFieldGroupEdt.Text = GvlstSysConfig.SelectedRow.Cells[3].Text;
            TxtBxDescriptionEdt.Text = GvlstSysConfig.SelectedRow.Cells[4].Text;
            mpEdit.Show();
        }
        catch (Exception ex)
        {

        }     
    }
    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GvlstSysConfig, "Select$" + e.Row.RowIndex);
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA';this.style.cursor = 'pointer';"); 
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show("Error in row data bound");
        }
    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        mp1.Hide();
        ClearControls();
    }

    #endregion

    #region "User Defined Function"

    private void FillDDLFieldGroup(DropDownList ddl)
    {
        ddl.Items.Clear();
        obj_BAL_Student_Dashboard.get_DDLFieldGroup(ddl);
    }
    private void FillGvlstSysConfig(string FieldGroup)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = obj_BAL_Student_Dashboard.get_GvlstSysConfig(FieldGroup);
            GvlstSysConfig.DataSource = ds;
            GvlstSysConfig.DataBind();
            GvlstSysConfig.Visible = true;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void ClearControls()
    {
        try
        {
            TxtBxField.Text = string.Empty;
            TxtBxFieldEdt.Text = string.Empty;
            TxtBxDescription.Text = string.Empty;
            TxtBxDescriptionEdt.Text = string.Empty;
            TxtBxFieldGroupEdt.Text = string.Empty;
            TxtBxFieldGroupPopup.Text = string.Empty;
            TxtBxType.Text = string.Empty;
            TxtBxTypeEdt.Text = string.Empty;
            TxtBxValue.Text = string.Empty;
            TxtBxValueEdt.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    #endregion
}
