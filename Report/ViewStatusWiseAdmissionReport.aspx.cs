using System;
using System.Data;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

public partial class Report_ViewStatusWiseAdmissionReport : System.Web.UI.Page
{
    Admission_BLogic oAdmission_BLogic;
    Admission oAdmission;
    AdmissionPipeline oAdmissionPipeline;

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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["Status"] = "ALL";
            BindAdmissionGrid(Convert.ToString(ViewState["Status"]));
        }
    }

    private void BindAdmissionGrid(string status)
    {
        oAdmission = new Admission();
        oAdmission_BLogic = new Admission_BLogic();

        oAdmission.LastAdmissionStatus = (!string.IsNullOrEmpty(status)) ? status : null;

        DataSet ods = oAdmission_BLogic.Admission_Select_All(oAdmission);
        ViewState["ExportExcel"] = ods;

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.BindGridWithSorting(this.GvAdmission, ods, this.SortField, this.SortDirection);

        if (ods.Tables[0].Rows.Count == 0)
            dvExcel.Visible = false;
    }

    /// <summary>
    /// Fire event when chage dropdown selection from pagination
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 
    protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.GvAdmission.PageIndex = ((DropDownList)sender).SelectedIndex;
            this.BindAdmissionGrid(Convert.ToString(ViewState["Status"]));
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

    }

    /// <summary>
    /// Fire when page index changing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GvAdmission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DropDownList DDLSelectPage = (DropDownList)this.GvAdmission.BottomPagerRow.FindControl("ddlPageSelector");
            DDLSelectPage.SelectedIndex = e.NewPageIndex;
            this.GvAdmission.PageIndex = e.NewPageIndex;
            this.BindAdmissionGrid(Convert.ToString(ViewState["Status"]));
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// GridView sorting event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GvAdmission_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (e.SortExpression.Trim() == this.SortField)
            {
                this.SortDirection = this.SortDirection == "descending" ? "ascending" : "descending";
            }
            else
            {
                this.SortDirection = "ascending";
            }

            this.SortField = e.SortExpression;
            this.BindAdmissionGrid(Convert.ToString(ViewState["Status"]));
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    /// <summary>
    /// Event fire on pagination row created
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GvAdmission_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            GridViewOperations GrvOperation = new GridViewOperations();
            GrvOperation.SetPagerButtonStates(GvAdmission, e.Row, this.Page);
        }
    }

    protected void GvAdmission_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label LblStatus = (Label)e.Row.FindControl("LblAdmissionStatus");
            if (string.IsNullOrEmpty(LblStatus.Text))
                LblStatus.Text = "Not Started";
        }
    }

    protected void All_Click(object sender, EventArgs e)
    {
        ViewState["Status"] = "ALL";
        BindAdmissionGrid(Convert.ToString(ViewState["Status"]));
    }

    protected void Interaction_Click(object sender, EventArgs e)
    {
        ViewState["Status"] = "Interaction";
        BindAdmissionGrid("Interaction");
    }

    protected void Confirm_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["Status"] = "confirm";
        BindAdmissionGrid("confirm");
    }

    protected void Onhold_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["Status"] = "onhold";
        BindAdmissionGrid("onhold");
    }

    protected void Rejected_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["Status"] = "reject";
        BindAdmissionGrid("reject");
    }

    protected void btnGetHistory_Click(object sender, EventArgs e)
    {
        oAdmissionPipeline = new AdmissionPipeline();
        oAdmission_BLogic = new Admission_BLogic();

        oAdmissionPipeline.AdmissionId = hdnAdmissionID.Value;

        DataSet ods = oAdmission_BLogic.AdmissionPipeline_Select_StatusAndEmail(oAdmissionPipeline);

        GvStatusHistory.Visible = true;

        GvStatusHistory.DataSource = ods.Tables[0];
        GvStatusHistory.DataBind();

        GvMailHistory.Visible = true;

        GvMailHistory.DataSource = ods.Tables[1];
        GvMailHistory.DataBind();

        MdlHistory.Show();
    }

    protected void ExportAsExcel_Click(object sender, EventArgs e)
    {
        DataSet ods = (DataSet)ViewState["ExportExcel"];
        ExportDataTableToExcel(ods.Tables[0], ViewState["Status"] + "Admission.xls");
    }

    #region WebMethod
    [WebMethod()]
    public static string LoadMail(string AdmissionEmailID)
    {
        AdmissionPipeline oAdmissionPipeline = new AdmissionPipeline();
        Admission_BLogic oAdmission_BLogic = new Admission_BLogic();

        DataSet ods = oAdmission_BLogic.AdmissionPipeline_Select_StatusAndEmail_By_AdmissionEmailID(AdmissionEmailID);

        StringBuilder oBuilder = new StringBuilder();

        if (ods.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow odr in ods.Tables[0].Rows)
            {
                oBuilder.Append("<div class='dvsmallheader' style='width:50px;text-align:right;'><span>From</span></div><div class='dvsmallheader' style='width:86%; margin-top:0px;'>" + Convert.ToString(odr["MailFrom"]) + "</div><br />");
                oBuilder.Append("<div class='dvsmallheader' style='width:50px;text-align:right;'><span>To</span></div><div class='dvsmallheader' style='width:86%; margin-top:0px;'>" + Convert.ToString(odr["MailTo"]) + "</div><br />");
                oBuilder.Append("<div class='dvsmallheader' style='width:50px;text-align:right;'><span>Subject</span></div><div class='dvsmallheader' style='width:86%; margin-top:0px;'>" + Convert.ToString(odr["MailSubject"]) + "</div><br />");
                oBuilder.Append("<div class='dvsmallheader' style='margin-top:20px;'><span>Body</span></div><div class='dvsmallheader' style='display:block; width:97%; margin-top:0px;'>" + Convert.ToString(odr["Mailbody"]) + "</div><br />");
                oBuilder.Append("<div class='dvsmallheader'><span>Attachment</span></div><div class='dvsmallheader' style='display:block; width:97%; margin-top:0px;'>" + GetAttachmentHTML(odr) + "</div><br />");
            }
        }
        return Convert.ToString(oBuilder);
    }

    private static string GetAttachmentHTML(DataRow odr)
    {
        StringBuilder oBuilder = new StringBuilder();

        string[] Attachament = Convert.ToString(odr["MailDocument"]).Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

        if (Attachament.Length > 0)
        {
            foreach (string attachment in Attachament)
            {
                oBuilder.Append("<a href='" + attachment + "'>" + Path.GetFileName(attachment) + "</a><br />");
            }
        }
        else
        {
            oBuilder.Append("No Attachment");
        }

        return Convert.ToString(oBuilder);
    }

    /// <summary>
    ///Export Datatable as excel
    /// </summary>
    protected void ExportDataTableToExcel(DataTable table, string filename)
    {
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Buffer = true;
        Response.ContentType = "application/ms-excel";
        Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");

        Response.Charset = "utf-8";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        Response.Write("<font style='font-size:11.0pt; font-family:Calibri;'>");
        Response.Write("<BR><BR><BR>");
        Response.Write("<Table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:11.0pt; font-family:Calibri; background:white;'> ");

        Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
        Response.Write("<TR >");

        int columnscount = table.Columns.Count;

        for (int j = 0; j < columnscount; j++)
        {
            string column = table.Columns[j].ColumnName.ToString().Replace(" ", "");

            Response.Write("<Td style=\"background-color:#BDB76B;color:#000000;\" >");
            Response.Write("<B>");

            Response.Write(table.Columns[j].ColumnName.ToString());

            Response.Write("</B>");
            Response.Write("</Td>");
        }

        Response.Write("</TR>");
        foreach (DataRow row in table.Rows)
        {
            Response.Write("<TR>");

            for (int i = 0; i < table.Columns.Count; i++)
            {
                Response.Write("<Td>");
                Response.Write(row[i].ToString());
                Response.Write("</Td>");

            }
            Response.Write("</TR>");
        }
        Response.Write("</Table>");
        Response.Write("</font>");
        Response.Flush();
        Response.End();
    }

    #endregion
}