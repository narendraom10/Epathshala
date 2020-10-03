using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class Exam_Print_PDF : System.Web.UI.Page
{
    # region Variables
    # endregion

    # region Properties
    # endregion

    # region Page events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["StudentResult"];
            GridStudentListReport.Visible = false;
            GridStudentList.Visible = false;
            string page = Request.QueryString["page"].ToString();
            if (page.ToString().Equals("ResultEntry"))
            {
                GridStudentList.Visible = true;
                GridStudentList.DataSource = dt;
                GridStudentList.DataBind();
            }
            else if (page.ToString().Equals("SummaryReport"))
            {
                GridStudentListReport.Visible = true;
                GridStudentListReport.DataSource = dt;
                GridStudentListReport.DataBind();
            }

            lblExamName.Text = Session["ExamName"].ToString();
            if (!Session["ExamName"].ToString().Equals(""))
            {
                lblExamName.Text = Session["ExamName"].ToString();
            }
            else
            {
                lblExam.Text = "";
                lblExamName.Text = "";
            }

            LblChapName.Text = Session["ChapName"].ToString();
            LblTopicName.Text = Session["TopicName"].ToString();
            if (!Session["ToatlQues"].ToString().Equals(""))
            {
                lblTotQue1.Text = Session["ToatlQues"].ToString();
            }
            else
            {
                lblTotQue.Text = "";
                lblTotQue1.Text = "";
            }
            if (!Session["ToatlMarks"].ToString().Equals(""))
            {
                LblTotMarks1.Text = Session["ToatlMarks"].ToString();
            }
            else
            {
                LblTotMarks.Text = "";
                LblTotMarks1.Text = "";
            }
        }
    }
    
    # endregion

    # region Control events

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Result.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        ContentDiv.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 5f, 5f, 50f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=ExportSummaryReport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        StringWriter StringWriter = new System.IO.StringWriter();
        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        ContentDiv.RenderControl(HtmlTextWriter);
        Response.Write(StringWriter.ToString());
        Response.End();
    }

    # endregion

    # region User defined function
    # endregion
   
}