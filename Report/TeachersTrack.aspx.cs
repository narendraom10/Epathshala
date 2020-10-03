using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Report_TeachersTrack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            FillSchool(ddlSchool);
            txtDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
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

    private void FillEmployee(DropDownList ddl, string School_ID)
    {
        ddl.Items.Clear();

        //string cs = ConfigurationManager.AppSettings["EpathshalaCon"];
        DataAccess da = new DataAccess();
        System.Data.SqlClient.SqlCommand cmd = da.GetCommandBySQL("SELECT Distinct Employee_ID, Employee + ' - ' + Login_ID As Employee FROM vw_TrackLog WHERE BMS_ID > 0 AND School_ID= " + School_ID);
        if (cmd != null)
        {
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null && dr.HasRows)
            {
                ddl.Items.Add(new ListItem("--SELECT--", "-1"));
                while (dr.Read())
                {
                    ddl.Items.Add(new ListItem(dr["Employee"].ToString(), dr["Employee_ID"].ToString()));
                }
                dr.Close();
            }
        }
    }



    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillEmployee(ddlEmployee, ddlSchool.SelectedItem.Value.ToString());
    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string sql = "SELECT * FROM vw_TrackLog WHERE (DATEDIFF(day, Activity_Date,'" + txtDate.Text.ToString() + "') = 0) ";
        sql += " AND School_ID = " + ddlSchool.SelectedItem.Value.ToString();
        sql += " AND Employee_ID = " + ddlEmployee.SelectedItem.Value.ToString();

        DataAccess da = new DataAccess();
        DataTable dt = da.GetDataTable(sql);
        gvwReport.DataSource = null;
        gvwReport.DataBind();
        Session["dtsearch"] = dt;
        if (dt != null)
        {
            gvwReport.DataSource = dt;
            gvwReport.DataBind();
        }
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
        string filename = "Teachertrackreport.xls";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
        HttpContext.Current.Response.Write("<TR >");
        HttpContext.Current.Response.Write("<Td  style=\"background-color:#000000;color:#ffffff;\"  colspan=\"3\">");
        HttpContext.Current.Response.Write("<font style='font-size:14.0pt; font-family:Calibri; color: white'>");
        HttpContext.Current.Response.Write("<B>");
        HttpContext.Current.Response.Write("Teacher Track Report");
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

            if (table.Columns[j].ColumnName.ToString().ToLower() == "school" || table.Columns[j].ColumnName.ToString().ToLower() == "employee" || table.Columns[j].ColumnName.ToString().ToLower() == "remark")
            {
                HttpContext.Current.Response.Write("<Td style=\"background-color:#BDB76B;color:#000000;\" >");
                HttpContext.Current.Response.Write("<B>");
                HttpContext.Current.Response.Write(table.Columns[j].ColumnName.ToString());


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


                if (table.Columns[i].ColumnName.ToString().ToLower() == "school" || table.Columns[i].ColumnName.ToString().ToLower() == "employee" || table.Columns[i].ColumnName.ToString().ToLower() == "remark")
                {
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(row[i].ToString());
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
    protected void btnexporttoexcel_Click(object sender, EventArgs e)
    {
        ExporttoExcel((DataTable)(Session["dtsearch"]));
        //string strFilename = "TeacherTrackReport.xls";
        //UploadDataTableToExcel((DataTable)(Session["dtsearch"]), strFilename);
        //Response.Clear();
        //Response.Clear();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        //Response.Charset = "";
        //Response.ContentType = "application/vnd.ms-excel";
        //using (StringWriter sw = new StringWriter())
        //{
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

        //    //To Export all pages
        //    //gvwReport.AllowPaging = false;
        //    //DataTable dt = (DataTable)(Session["dtsearch"]);
        //    //gvwReport.DataSource = dt;

        //    //gvwReport.DataBind();
        //    ////this.Search();

        //    //gvwReport.HeaderRow.BackColor = System.Drawing.Color.White;

        //    //foreach (TableCell cell in gvwReport.HeaderRow.Cells)
        //    //{
        //    //    cell.BackColor = gvwReport.HeaderStyle.BackColor;

        //    //}
        //    //foreach (GridViewRow row in gvwReport.Rows)
        //    //{
        //    //    row.BackColor = System.Drawing.Color.White;
        //    //    foreach (TableCell cell in row.Cells)
        //    //    {
        //    //        if (row.RowIndex % 2 == 0)
        //    //        {
        //    //            cell.BackColor = gvwReport.AlternatingRowStyle.BackColor;
        //    //        }
        //    //        else
        //    //        {
        //    //            cell.BackColor = gvwReport.RowStyle.BackColor;
        //    //        }
        //    //        cell.CssClass = "textmode";
        //    //    }
        //    //}



        //    gvwReport.RenderControl(hw);

        //    //style to format numbers to string
        //    string style = @"<style> .textmode { } </style>";
        //    Response.Write(style);
        //    Response.Output.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();
        //}
    }

    //public override void VerifyRenderingInServerForm(Control control)
    //{

    //}

    #region oldexporttoexcdelcode
    protected void UploadDataTableToExcel(DataTable dtEmp, string filename)
    {
        string attachment = "attachment; filename=" + filename;
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = string.Empty;
        foreach (DataColumn dtcol in dtEmp.Columns)
        {
            if (dtcol.ColumnName.ToString().ToLower() == "school" || dtcol.ColumnName.ToString().ToLower() == "employee" || dtcol.ColumnName.ToString().ToLower() == "remark")
            {
                Response.Write(tab + dtcol.ColumnName);
                tab = "\t";
            }

        }
        Response.Write("\n");
        foreach (DataRow dr in dtEmp.Rows)
        {
            tab = "";
            for (int j = 0; j < dtEmp.Columns.Count; j++)
            {
                if (dtEmp.Columns[j].ColumnName.ToString().ToLower() == "school" || dtEmp.Columns[j].ColumnName.ToString().ToLower() == "employee" || dtEmp.Columns[j].ColumnName.ToString().ToLower() == "remark")
                {
                    Response.Write(tab + Convert.ToString(dr[j]));
                    tab = "\t";
                }

            }
            Response.Write("\n");
        }
        Response.End();
    }
    #endregion
}