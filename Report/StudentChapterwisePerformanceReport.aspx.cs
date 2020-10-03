using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Web.Services;
using System.Text;

public partial class Report_StudentChapterwisePerformanceReport : System.Web.UI.Page
{
	Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
	StudentDash obj_Student_Dashboard;
	ReportsForResult obj_bal_Report_for_result;

    public int subjectID = 1;
	protected void Page_Load(object sender, EventArgs e)
	    {
		if (!IsPostBack)
		{
			BindSubjectList();
			 
			   
		   
			subjectID = Convert.ToInt32(ddlsubject.SelectedValue);

			int StudentID = Convert.ToInt32(Session["StudentID"].ToString());
            
			GetReportdata(StudentID, subjectID);
		}

	}
	protected void BindSubjectList()
	{
		try
		{
			 
			ViewState["StudentBMS"] = AppSessions.BMSID;
			 
			obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
			obj_Student_Dashboard = new StudentDash();
			ArrayList Alist = new ArrayList();


			if (ViewState["ArrayList"] != null)
			{
				Alist = (ArrayList)ViewState["ArrayList"];
				string PackageFDID = string.Empty;
				for (int i = 0; i < Alist.Count; i++)
				{
					if (PackageFDID != string.Empty)
					{
						PackageFDID = PackageFDID + "," + Alist[i].ToString();
					}
					else
					{
						PackageFDID = PackageFDID + Alist[i].ToString();
					}
				}

				obj_Student_Dashboard.BMSID = AppSessions.BMSID;
				obj_Student_Dashboard.PackageFDID = PackageFDID;
				obj_Student_Dashboard.Mode = "Selected";
				DataSet ds = new DataSet();
				ds = obj_BAL_Student_Dashboard.BAL_Student_Subject_Select(obj_Student_Dashboard);

				if (ds.Tables[0].Rows.Count > 0 && ds != null)
				{
					ddlsubject.DataSource = ds.Tables[0];
					ddlsubject.DataValueField = "SubjectID";
					ddlsubject.DataTextField = "Subject";
					ddlsubject.DataBind();
					ddlsubject.SelectedIndex = 0;
				}

				//ddlsubject.Items.Insert(0, "Select");
			}

			if (ViewState["StudentBMS"] != null)
			{
				obj_Student_Dashboard.BMSID = Convert.ToInt64(ViewState["StudentBMS"]);
				obj_Student_Dashboard.Mode = "All";
				DataSet ds = new DataSet();
				ds = obj_BAL_Student_Dashboard.BAL_Student_Subject_Select(obj_Student_Dashboard);
				if (ds.Tables[0].Rows.Count > 0 && ds != null)
				{
					ddlsubject.DataSource = ds.Tables[0];
					ddlsubject.DataValueField = "SubjectID";
					ddlsubject.DataTextField = "Subject";
					ddlsubject.DataBind();

				}
				//ddlsubject.Items.Insert(0, "Select");
				ddlsubject.SelectedIndex = 0;
			}
		}
		catch (Exception ex)
		{
			WebMsg.Show(ex.Message);
		}
	}
	protected void btnreport_Click(object sender, EventArgs e)
	{

		int SubjectID = Convert.ToInt32(ddlsubject.SelectedValue);

		int StudentID = Convert.ToInt32(Session["StudentID"].ToString());
		GetReportdata(StudentID, SubjectID);
	}
	public String tableData;

	
	private  void GetReportdata(int studentid, int subjectid)
	{

		try
		{
			DataSet dsResult = new DataSet();
			ReportsForResult Report_Bal = new ReportsForResult();
		  
		   
			string data;

			dsResult = Report_Bal.BAL_SYS_ResultRPTByStudentSubDetails(studentid, subjectid);

			if (dsResult.Tables[0].Rows.Count > 0)
			{

			   
				int count = dsResult.Tables[0].Rows.Count;


				for (int i = 0; i < count; i++)
				{
					string examDate = dsResult.Tables[0].Rows[i]["ExamDate"].ToString();
					string chapterIndex = dsResult.Tables[0].Rows[i]["ChapterIndex"].ToString();
					string chapterName = dsResult.Tables[0].Rows[i]["Chapter"].ToString();
					string percentageObtained = dsResult.Tables[0].Rows[i]["ObtainedPercentage"].ToString();
					int examid = Convert.ToInt16(dsResult.Tables[0].Rows[i]["ExamID"]);

					//tableData += "<tr><td  class=\"col-md-2 \">" + examDate + "</td><td class=\"col-md-2 \">" + chapterIndex + "</td><td class=\"col-md-4 \">" + chapterName + "</td><td class=\"col-md-2 \">" + percentageObtained + "</td><td class=\"col-md-2 \" id=\"click" + i + "\"><asp:Button class=\"btn btn-outline-success\"  Text=\"Details\" runat=\"server\" OnClick=\"GetExamdetails(" + examid + ")\"/></td></tr>";

                    tableData += "<tr><td>" + examDate + "</td><td>" + chapterIndex + "</td><td>" + chapterName + "</td><td>" + percentageObtained + "</td><td><button type=\"button\" class=\"btn btn-link\" data-toggle=\"modal\" data-target=\"#myModal\" onclick=\"GetExamdetails(" + examid + ")\">Details</button></td></tr>";
                    //WebMsg.Show(tableData);
				}

			}
			else
			{
                tableData = "<tr><td><bold>" + "Chapter Test not taken" + "</bold></td></tr>";
			}
				
		}
		catch (Exception ex)
		{
			WebMsg.Show("" + ex.Message.ToString());
		}
		 
	}

   

	[WebMethod]

	public static string GetResultsByExamid(int ExamId)
	{
        WebMsg.Show("codebehind");
        ReportsForResult obj_bal_Report_for_result = new ReportsForResult();
		DataSet dsResult = new DataSet();

		dsResult = obj_bal_Report_for_result.BAL_SYS_GetResultByExamid(ExamId);

		StringBuilder oBuilder = new StringBuilder();
        
		string totalscore = "<p class=\"lead\">Total Score:"+" "+  dsResult.Tables[1].Rows[0]["Result"].ToString()+" "+"/10</p>";
		oBuilder.Append(totalscore);
		int i = 0;
		foreach (DataRow odr in dsResult.Tables[0].Rows)
		{
		i=i+1;
        //string divtag = "<div style=\"display: inline-block\"";
        //string question = divtag+"<span class=\"bg-info lead\">Q" + i + ":" + odr["Question"] + "</span></div>";

        string question = "<div style=\"display: inline-block\" class=\"text-primary\">Q" + i + ":</div><div style=\"display: inline-block\" class=\"text-primary\" >" + odr["Question"] + "</div>"; 


		oBuilder.Append( question);
        string givenanswer = "<p>Given Answer:" + odr["GivenAnswer"] + "</p>"; 
        oBuilder.Append(givenanswer);
        string crctanswer = "<p>Correct Answer:" + odr["Answer"] + "</p>"; 
		oBuilder.Append(crctanswer);
        string score = "<p class=\"text-danger\">Score:" + odr["Score"] + "</p><hr/>";
		oBuilder.Append(score);
		}
			return Convert.ToString(oBuilder);

		 
	}


    [WebMethod]
    public static List<object> GetPerformanceChartdata(int subjectid)
    {
        StringBuilder sb = new StringBuilder();
        List<object> iData = new List<object>();
        List<string> labels = new List<string>();
        List<string> lst_dataItem_1 = new List<string>();
        try
        {

            //int subjectid = Convert.ToInt16(AppSessions.SubjectID);
            //int subjectid = 1;
            int studentid = Convert.ToInt32(AppSessions.StudentID);
            int bmsid = Convert.ToInt32(AppSessions.BMSID);


            DataTable dtexam = new DataTable();
            dtexam.Columns.Add("Chapter", typeof(string));
            dtexam.Columns.Add("ObtainedPercentage", typeof(string));


            DataSet dsResult = new DataSet();
            ReportsForResult Report_Bal = new ReportsForResult();


            string data;

            // dsResult = Report_Bal.BAL_SYS_ResultRPTByStudentSubDetails(studentid, subjectid,bmsid);
            dsResult = Report_Bal.BAL_SYS_Student_Performance_Chart(studentid, subjectid, bmsid);

            //sb.Append("[");

            if (dsResult.Tables[0].Rows.Count > 0 && dsResult != null)
            {
                for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                {
                    //int count = dsResult.Tables[0].Rows.Count;
                    //DataRow dr = dtexam.NewRow();

                    //dr["Chapter"] = dsResult.Tables[0].Rows[0]["Chapter"].ToString();
                    //dr["ObtainedPercentage"] = dsResult.Tables[0].Rows[0]["ObtainedPercentage"].ToString(); ;
                    //dtexam.Rows.Add(dr);
                    //sb.Append("{");
                    //System.Threading.Thread.Sleep(50);
                    //string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                    //sb.Append(string.Format("text :'{0}', value:{1}, color: '{2}'", dsResult.Tables[0].Rows[0]["Chapter"].ToString(), dsResult.Tables[0].Rows[0]["ObtainedPercentage"].ToString(), color));
                    //sb.Append("},");
                    labels.Add(dsResult.Tables[0].Rows[i]["Chapter"].ToString());
                    // lst_dataItem_1.Add(Convert.ToInt32(dsResult.Tables[0].Rows[i]["ObtainedPercentage"]));
                    if (dsResult.Tables[0].Rows[i]["ObtainedPercentage"].ToString().Length > 0)
                    {
                        lst_dataItem_1.Add(dsResult.Tables[0].Rows[i]["ObtainedPercentage"].ToString());
                    }
                    else
                    {
                        lst_dataItem_1.Add(null);
                    }


                }
                iData.Add(labels);
                iData.Add(lst_dataItem_1);
            }

            else
            {
                DataRow dr = dtexam.NewRow();
                dr["chapter"] = "";
                dr["ObtainedPercentage"] = "";
                dtexam.Rows.Add(dr);

            }
            //sb = sb.Remove(sb.Length - 1, 1);
            //sb.Append("]");


        }
        catch (Exception ex)
        {
            WebMsg.Show("" + ex.Message.ToString());
        }
        //return sb.ToString();
        return iData;
    }
}