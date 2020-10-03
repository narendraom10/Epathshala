using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Report_ClassroomTrack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            FillSchool(ddlSchool);
            txtDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
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

    private void FillSchool(DropDownList ddl)
    {
        ddl.Items.Clear();
        string cs = ConfigurationManager.AppSettings["EpathshalaCon"];

        DataAccess da = new DataAccess();
        System.Data.SqlClient.SqlCommand cmd = da.GetCommandBySQL("SELECT Distinct School_ID, School FROM vw_TrackLog WHERE School_ID is not null");
        if (cmd != null)
        {
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null && dr.HasRows)
            {

                ddl.Items.Add(new ListItem("--SELECT--", "-1"));
                while (dr.Read())
                {
                    ddl.Items.Add(new ListItem(dr["School"].ToString(), dr["School_ID"].ToString()));
                }
                dr.Close();
            }
        }

    }

    private void FillBMS(DropDownList ddl, string School_ID)
    {
        ddl.Items.Clear();

        //string cs = ConfigurationManager.AppSettings["EpathshalaCon"];
        DataAccess da = new DataAccess();
        System.Data.SqlClient.SqlCommand cmd = da.GetCommandBySQL("SELECT Distinct BMS_ID, BMS FROM vw_TrackLog WHERE BMS_ID > 0 AND School_ID= " + School_ID);
        if (cmd != null)
        {
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null && dr.HasRows)
            {
                ddl.Items.Add(new ListItem("--SELECT--", "-1"));
                while (dr.Read())
                {
                    ddl.Items.Add(new ListItem(dr["BMS"].ToString(), dr["BMS_ID"].ToString()));
                }
                dr.Close();
            }
        }
    }

    private void FillDivision(DropDownList ddl, string School_ID, string BMS_ID)
    {
        ddl.Items.Clear();

        //string cs = ConfigurationManager.AppSettings["EpathshalaCon"];
        DataAccess da = new DataAccess();
        System.Data.SqlClient.SqlCommand cmd = da.GetCommandBySQL("SELECT Distinct Division_ID, Division FROM vw_TrackLog WHERE Division_ID > 0 AND School_ID= " + School_ID + " AND BMS_ID = " + BMS_ID);
        if (cmd != null)
        {
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null && dr.HasRows)
            {
                ddl.Items.Add(new ListItem("--SELECT--", "-1"));
                while (dr.Read())
                {
                    ddl.Items.Add(new ListItem(dr["Division"].ToString(), dr["Division_ID"].ToString()));
                }
                dr.Close();
            }
        }
    }

    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBMS(ddlBMS, ddlSchool.SelectedItem.Value.ToString());
    }
    protected void ddlBMS_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDivision(ddlDivision, ddlSchool.SelectedItem.Value.ToString(), ddlBMS.SelectedItem.Value.ToString());
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string sql = "SELECT * FROM vw_TrackLog WHERE (DATEDIFF(day, Activity_Date,'" + txtDate.Text.ToString() + "') = 0) ";
        sql += " AND School_ID = " + ddlSchool.SelectedItem.Value.ToString();
        sql += " AND BMS_ID = " + ddlBMS.SelectedItem.Value.ToString();
        sql += " AND Division_ID = " + ddlDivision.SelectedItem.Value.ToString();

        DataAccess da = new DataAccess();
        DataTable dt = da.GetDataTable(sql);
        ViewState["classroomreport"] = dt;
        gvwReport.DataSource = null;
        gvwReport.DataBind();

        if (dt != null)
        {
            //btnexporttoexcel.Visible = true;

            gvwReport.DataSource = dt;
            gvwReport.DataBind();
        }
    }
    protected void btnexporttoexcel_Click(object sender, EventArgs e)
    {
        //string strFilename = "Classroom track report.xls";
        //UploadDataTableToExcel((DataTable)(ViewState["classroomreport"]), strFilename);
        ExporttoExcel((DataTable)(ViewState["classroomreport"]));

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



        string filename = "Classroomtrackreport.xls";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
        HttpContext.Current.Response.Write("<TR >");
        HttpContext.Current.Response.Write("<Td  style=\"background-color:#000000;color:#ffffff;\"  colspan=\"3\">");
        HttpContext.Current.Response.Write("<font style='font-size:14.0pt; font-family:Calibri; color: white'>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Classroom Track Report");
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
           
            if (table.Columns[j].ColumnName.ToString().ToLower() == "activity_date" || table.Columns[j].ColumnName.ToString().ToLower() == "employee" || table.Columns[j].ColumnName.ToString().ToLower() == "activity" || table.Columns[j].ColumnName.ToString().ToLower() == "time_difference" || table.Columns[j].ColumnName.ToString().ToLower() == "remark")
            {
                HttpContext.Current.Response.Write("<Td style=\"background-color:#BDB76B;color:#000000;\" >");
                HttpContext.Current.Response.Write("<B>");
                if (table.Columns[j].ColumnName.ToString().ToLower() == "activity_date")
                {
                    HttpContext.Current.Response.Write("Time");
                }
                else if (table.Columns[j].ColumnName.ToString().ToLower() == "time_difference")
                {
                    HttpContext.Current.Response.Write("Duration");
                }
                else
                {
                    HttpContext.Current.Response.Write(table.Columns[j].ColumnName.ToString());
                }

            }
            HttpContext.Current.Response.Write("</B>");
            HttpContext.Current.Response.Write("</Td>");
        }

        //}
        HttpContext.Current.Response.Write("</TR>");
        foreach (DataRow row in table.Rows)
        {
            HttpContext.Current.Response.Write("<TR>");

            for (int i = 0; i < table.Columns.Count; i++)
            {


                if (table.Columns[i].ColumnName.ToString().ToLower() == "activity_date" || table.Columns[i].ColumnName.ToString().ToLower() == "employee" || table.Columns[i].ColumnName.ToString().ToLower() == "activity" || table.Columns[i].ColumnName.ToString().ToLower() == "time_difference" || table.Columns[i].ColumnName.ToString().ToLower() == "remark")
                {
                    HttpContext.Current.Response.Write("<Td>");
                    if (table.Columns[i].ColumnName.ToString().ToLower() == "activity_date")
                    {
                        HttpContext.Current.Response.Write(Convert.ToDateTime(row[i]).TimeOfDay);
                    }
                    else
                    {
                        HttpContext.Current.Response.Write(row[i].ToString());
                    }
                    HttpContext.Current.Response.Write("</Td>");


                }
               
                  
                   

             

            }

            HttpContext.Current.Response.Write("</TR>");
        }
        HttpContext.Current.Response.Write("</Table>");
        HttpContext.Current.Response.Write("</font>");
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }

    #region Old export to excel report code

    protected void UploadDataTableToExcel(DataTable dtreport, string filename)
    {
        try
        {
            if (dtreport.Rows.Count > 0)
            {
                string attachment = "attachment; filename=" + filename;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";
                string tab = string.Empty;
                foreach (DataColumn dtcol in dtreport.Columns)
                {
                    if (dtcol.ColumnName.ToString().ToLower() == "activity_date" || dtcol.ColumnName.ToString().ToLower() == "employee" || dtcol.ColumnName.ToString().ToLower() == "activity" || dtcol.ColumnName.ToString().ToLower() == "time_difference" || dtcol.ColumnName.ToString().ToLower() == "remark")
                    {
                        if (dtcol.ColumnName.ToString().ToLower() == "activity_date")
                        {
                            Response.Write(tab + "Time");
                            tab = "\t";
                        }
                        else if (dtcol.ColumnName.ToString().ToLower() == "time_difference")
                        {
                            Response.Write(tab + "Duration");
                            tab = "\t";
                        }
                        else
                        {
                            Response.Write(tab + dtcol.ColumnName);
                            tab = "\t";
                        }

                    }
                }
                Response.Write("\n");
                foreach (DataRow dr in dtreport.Rows)
                {
                    tab = "";
                    for (int j = 0; j < dtreport.Columns.Count; j++)
                    {
                        if (dtreport.Columns[j].ColumnName.ToString().ToLower() == "activity_date" || dtreport.Columns[j].ColumnName.ToString().ToLower() == "employee" || dtreport.Columns[j].ColumnName.ToString().ToLower() == "activity" || dtreport.Columns[j].ColumnName.ToString().ToLower() == "time_difference" || dtreport.Columns[j].ColumnName.ToString().ToLower() == "remark")
                        {
                            if (dtreport.Columns[j].ColumnName.ToString().ToLower() == "activity_date")
                            {
                                Response.Write(tab + Convert.ToDateTime(dr[j]).TimeOfDay);
                                // DateTime dt = Convert.ToDateTime(dr[j]);
                                tab = "\t";
                            }

                            else
                            {
                                Response.Write(tab + Convert.ToString(dr[j]));
                                tab = "\t";
                            }

                        }

                    }
                    Response.Write("\n");
                }
                Response.End();

            }

        }
        catch (Exception ex)
        {
        }

    }
    #endregion
}