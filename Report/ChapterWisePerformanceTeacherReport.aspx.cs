using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ChapterWiseTeacherReport : System.Web.UI.Page
{
    SYS_Role_BLogic obj_BAL_SYS_Role;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            obj_BAL_SYS_Role = new SYS_Role_BLogic();
            //Int64 BMSID = Convert.ToInt64(ddlBoard.SelectedValue);
            //lblBMS.Text = Session["BMS"].ToString();
            DataSet dsSelect = new DataSet();

            //dsSelect = obj_BAL_SYS_Role.BAL_Allocated_Subject_Div_BasedonBMS(Convert.ToInt64(Session["BMSID"]), Convert.ToInt64(Session["EmpolyeeID"]));
            dsSelect = obj_BAL_SYS_Role.BAL_Select_Employee_BMS_SelectAll(Convert.ToInt64(Session["EmpolyeeID"]));
            

            if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
            {
                Session["ds_BMS"] = dsSelect;
                ddlBoard.DataSource = dsSelect.Tables[0];
                ddlBoard.DataTextField = "BMS";
                ddlBoard.DataValueField = "BMSID";
                ddlBoard.DataBind();
                ddlBoard.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
            }
        }
        



    }
    protected void btnreport_Click(object sender, EventArgs e)
    {

    }
    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsSelect = new DataSet();
        obj_BAL_SYS_Role = new SYS_Role_BLogic();

        if (ddlBoard.SelectedIndex != 0)
        {
            dsSelect = obj_BAL_SYS_Role.BAL_Allocated_Subject_Div_BasedonBMS(Convert.ToInt64(ddlBoard.SelectedValue), Convert.ToInt64(Session["EmpolyeeID"]));

            if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
            {
                ddlSubject.DataSource = dsSelect.Tables[0];
                ddlSubject.DataTextField = "Subject";
                ddlSubject.DataValueField = "SubjectID";
                ddlSubject.DataBind();
                ddlSubject.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                ddlDivision.DataSource = dsSelect.Tables[1];
                ddlDivision.DataTextField = "Division";
                ddlDivision.DataValueField = "DivisionID";
                ddlDivision.DataBind();
                ddlDivision.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));


                ddlchapter.SelectedIndex = 0;
                ddlchapter.Enabled = false;
                ddlSubject.Enabled = true;

                ddlDivision.SelectedIndex = 0;
                ddlDivision.Enabled = true;

                //DropDownList[] disddl1 = { ddlSubject, ddlDivision };
                //EnableDropDwon(disddl1);
            }

        }
        else
        {
           
            ddlSubject.SelectedIndex = 0;
            ddlSubject.Enabled = false;
            ddlDivision.SelectedIndex = 0;
            ddlDivision.Enabled = false;
        }

        

    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {

            if (ddlSubject.SelectedIndex != 0)
            {
                obj_BAL_SYS_Role = new SYS_Role_BLogic();
                DataSet dsSelect = new DataSet();
                dsSelect = obj_BAL_SYS_Role.BAL_Select_Chapters(Convert.ToInt64(ddlBoard.SelectedValue), Convert.ToInt32(ddlSubject.SelectedValue));
                ddlchapter.Enabled = true;
                ddlchapter.DataSource = dsSelect.Tables[0];
                ddlchapter.DataTextField = "Chapter";
                ddlchapter.DataValueField = "ChapterID";
                ddlchapter.DataBind();
                ddlchapter.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
            }
            else
            {
                ddlchapter.SelectedIndex = 0;
                ddlchapter.Enabled = false;
            }
            
            
        }
        catch (Exception ex)
        { 
        }
        

    }
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlchapter_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
}