using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;
using System.Globalization;
using System.Data;

public partial class Report_ClassRoomWiseMonthlyAttendanceRpt : System.Web.UI.Page
{

    #region "Declaration"

    DropDownFill DdlFilling;
    SYS_Division_BLogic DivisionBLogic = new SYS_Division_BLogic();
    ClassroomWiseAttendance Obj_Dal_ClassroomWiseAttendance;
    School_BLogic SchoolBLogic = new School_BLogic();
    string connectionstring;


    #endregion

    #region Page Load

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
            txtDate.Text = DateTime.Today.ToString("MMM-yyyy");
            FillSchoolDropdown(ddlSchool);

            //--------------------------------------------
            switch (AppSessions.RoleID)
            {
                case (int)EnumFile.Role.S_Admin:
                    ddlSchool.SelectedIndex = ddlSchool.Items.IndexOf(ddlSchool.Items.FindByValue(AppSessions.SchoolID.ToString()));
                    ddlSchool.Enabled = false;
                    ddlSchool_SelectedIndexChanged(ddlSchool, e);
                    break;
                case (int)EnumFile.Role.Teacher:
                    ddlSchool.SelectedIndex = ddlSchool.Items.IndexOf(ddlSchool.Items.FindByValue(AppSessions.SchoolID.ToString()));
                    ddlSchool.Enabled = false;
                    ddlSchool_SelectedIndexChanged(ddlSchool, e);
                    break;
            }
            //---------------------------------------------------
        }
    }

    #endregion

    #region "Control Events"

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
    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSchool.SelectedIndex != 0)
        {
            DataSet ds = new DataSet();

            SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
            ds = objSys_Board.BAL_SYS_Board_BySchoolID(Convert.ToInt32(ddlSchool.SelectedValue));

            DropDownFill DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlBoard, ds.Tables[0], "Board", "BoardID");
            ddlBoard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlBoard.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
            Session["SchoolID"] = Convert.ToInt32(ddlSchool.SelectedValue);
            Session["SchoolName"] = ddlSchool.SelectedItem.ToString();
            ddlDisable(ddlBoard, true);
        }
        else
        {
            ddlDisable(ddlBoard, false);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlDivision, false);
        }
    }

    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBoard.SelectedValue != "0")
        {
            DataSet ds = new DataSet();

            SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
            ds = objSys_Board.BAL_SYS_Medium_BySchoolIDBoardID(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue));

            DropDownFill DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlMedium, ds.Tables[0], "Medium", "MediumID");
            ddlMedium.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlDisable(ddlMedium, true);
            ddlMedium.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
        }
        else
        {
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlDivision, false);
        }
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMedium.SelectedIndex != 0)
        {
            BindStandard(1);
            ddlDisable(ddlStandard, true);
            ddlDisable(ddlDivision, true);
        }
        else
        {
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlDivision, false);
        }
    }

    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStandard.SelectedIndex != 0)
        {
            BindDivision(ddlDivision);
            ddlDisable(ddlDivision, true);
        }
        else
        {
            ddlDisable(ddlDivision, false);
        }
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        ddlSchool.Enabled = false;
        ddlBoard.Enabled = false;
        ddlMedium.Enabled = false;
        ddlStandard.Enabled = false;
        ddlDivision.Enabled = false;
        grdAtt.Visible = true;
        btnexporttoexcel.Visible = true;
        DataSet ds = new DataSet();
        this.Obj_Dal_ClassroomWiseAttendance = new ClassroomWiseAttendance();
        ds = this.Obj_Dal_ClassroomWiseAttendance.GetClasswiseMonthlyAttendance(Convert.ToInt32(ddlSchool.SelectedValue), Get_DDMMYYYY(txtDate.Text), Convert.ToInt64(ViewState["BMSID"]), Convert.ToInt32(ddlDivision.SelectedValue));
        ViewState["reportdatatable"] = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdAtt.DataSource = ds.Tables[0];
            grdAtt.DataBind();
        }
        else
        {
            grdAtt.DataSource = null;
            grdAtt.DataBind();
        }
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {

        if (AppSessions.RoleID == (int)EnumFile.Role.E_Admin)
        {
            ddlDisable(ddlSchool, true);
            ddlDisable(ddlBoard, false);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlDivision, false);
            grdAtt.DataSource = null;
            grdAtt.DataBind();
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.S_Admin)
        {
            //ddlDisable(ddlSchool, true);
            ddlDisable(ddlBoard, true);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlDivision, false);
            grdAtt.DataSource = null;
            grdAtt.DataBind();
        }
        else if (AppSessions.RoleID == (int)EnumFile.Role.Teacher)
        {
            //ddlDisable(ddlSchool, true);
            ddlDisable(ddlBoard, true);
            ddlDisable(ddlMedium, false);
            ddlDisable(ddlStandard, false);
            ddlDisable(ddlDivision, false);
            grdAtt.DataSource = null;
            grdAtt.DataBind();
        }

    }


    #endregion

    #region "User Defined Functions"

    private void ddlDisable(DropDownList ddlDropDown, bool status)
    {
        ddlDropDown.Enabled = status;
        ddlDropDown.SelectedIndex = 0;
    }

    private void BindStandard(int Step)
    {
        DataSet ds = new DataSet();

        SYS_Board_BLogic objSys_Board = new SYS_Board_BLogic();
        ds = objSys_Board.BAL_SYS_Std_BySchoolIDBoardIDMediumid(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue));

        DdlFilling = new DropDownFill();
        if (Step <= 1)
        {
            if (ds.Tables.Count > 0)
            {
                DdlFilling.BindDropDownByTable(ddlStandard, ds.Tables[0], "Standard", "StandardID");
                ddlStandard.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlStandard.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlDisable(ddlStandard, true);
            }
        }
    }

    private void BindDivision(DropDownList ddlDivision)
    {
        if (ddlStandard.SelectedIndex != 0)
        {
            DivisionBLogic = new SYS_Division_BLogic();
            Int64 bmsid = 0;
            bmsid = DivisionBLogic.BAL_SYS_SelectBMSID(Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue));
            ViewState["BMSID"] = bmsid;

            DivisionBLogic = new SYS_Division_BLogic();

            DataSet dsResult = new DataSet();
            dsResult = DivisionBLogic.BAL_SYS_Division_SelectByBMSID(Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlStandard.SelectedValue), Convert.ToInt32(Session["SchoolID"]));


            DdlFilling = new DropDownFill();
            DdlFilling.BindDropDownByTable(ddlDivision, dsResult.Tables[0], "Division", "DivisionID");
            ddlDivision.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlDivision.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
        }
    }

    public static DateTime Get_DDMMYYYY(String dat)
    {
        IFormatProvider culture = new CultureInfo("en-US", true);
        DateTime dt = DateTime.Parse(dat, culture, DateTimeStyles.AssumeLocal);
        return dt;
    }

    #endregion

    protected void btnexporttoexcel_Click(object sender, EventArgs e)
    {
        //UploadDataTableToExcel((DataTable)(ViewState["reportdatatable"]), "Monthlyattendencereport.xls");


        ExporttoExcel((DataTable)(ViewState["reportdatatable"]));
    }


    private void ExporttoExcel(DataTable table)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        //HttpContext.Current.Response.ContentType = "application/ms-word";
        HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");

        // HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.doc");
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        HttpContext.Current.Response.Write("<font style='font-size:11.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:11.0pt; font-family:Calibri; background:white;'> ");



        string filename = "Monthlyattendancereport.xls";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
        HttpContext.Current.Response.Write("<TR >");
        HttpContext.Current.Response.Write("<Td  style=\"background-color:#000000;color:#ffffff;\"  colspan=\"3\">");
        HttpContext.Current.Response.Write("<font style='font-size:14.0pt; font-family:Calibri; color: white'>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Monthly Attendance Report");
        HttpContext.Current.Response.Write("</B>");
        HttpContext.Current.Response.Write("</Td>");
        HttpContext.Current.Response.Write("</TR>");
        HttpContext.Current.Response.Write("<TR >");
        int columnscount = table.Columns.Count;

        for (int j = 0; j < columnscount; j++)
        {

            string column = table.Columns[j].ColumnName.ToString().Replace(" ", "");
            //DataTable dt2 = dt1.DefaultView.ToTable(true, column);

            //if (dt2.Rows[0][0].ToString().ToLower() == "true")
            //{


            HttpContext.Current.Response.Write("<Td style=\"background-color:#BDB76B;color:#000000;\" >");
            HttpContext.Current.Response.Write("<B>");


            HttpContext.Current.Response.Write(table.Columns[j].ColumnName.ToString());


            HttpContext.Current.Response.Write("</B>");
            HttpContext.Current.Response.Write("</Td>");
        }


        HttpContext.Current.Response.Write("</TR>");
        foreach (DataRow row in table.Rows)
        {
            HttpContext.Current.Response.Write("<TR>");

            for (int i = 0; i < table.Columns.Count; i++)
            {
                HttpContext.Current.Response.Write("<Td>");
                HttpContext.Current.Response.Write(row[i].ToString());
                HttpContext.Current.Response.Write("</Td>");

            }
            HttpContext.Current.Response.Write("</TR>");
        }
        HttpContext.Current.Response.Write("</Table>");
        HttpContext.Current.Response.Write("</font>");
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }
    #region old export to excel code
    protected void UploadDataTableToExcel(DataTable dtEmp, string filename)
    {
        try
        {
            string attachment = "attachment; filename=" + filename;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.ms-excel";
            string tab = string.Empty;
            foreach (DataColumn dtcol in dtEmp.Columns)
            {
                //if (dtcol.ColumnName.ToString().ToLower() == "school" || dtcol.ColumnName.ToString().ToLower() == "employee" || dtcol.ColumnName.ToString().ToLower() == "remark")
                //{
                Response.Write(tab + dtcol.ColumnName);
                tab = "\t";
                // }

            }
            Response.Write("\n");
            foreach (DataRow dr in dtEmp.Rows)
            {
                tab = "";
                for (int j = 0; j < dtEmp.Columns.Count; j++)
                {
                    // if (dtEmp.Columns[j].ColumnName.ToString().ToLower() == "school" || dtEmp.Columns[j].ColumnName.ToString().ToLower() == "employee" || dtEmp.Columns[j].ColumnName.ToString().ToLower() == "remark")
                    // {
                    Response.Write(tab + Convert.ToString(dr[j]));
                    tab = "\t";
                    // }

                }
                Response.Write("\n");
            }
            Response.End();
        }
        catch (Exception ex)
        {
        }

    }
    #endregion

}