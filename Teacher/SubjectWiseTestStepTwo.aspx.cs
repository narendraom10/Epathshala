using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Teacher_SubjectWiseTestStepTwo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["rdu"]))
        {
            TrackLog_Utils obj = new TrackLog_Utils();
            DataSet dsCheckLog = new DataSet();
            bool AllowToAssessment = false;
            if (AppSessions.StudentID == 0)
            {
                dsCheckLog = obj.SELECTExamTrackLogOtherEmployee(AppSessions.BMSID, AppSessions.SchoolID, AppSessions.DivisionID, AppSessions.EmpolyeeID);
                if (dsCheckLog.Tables.Count > 0)
                {
                    if (dsCheckLog.Tables[0].Rows.Count > 0)
                    {
                        if (dsCheckLog.Tables[0].Rows[0]["Activity"].ToString() == "Assessment" || dsCheckLog.Tables[0].Rows[0]["Activity"].ToString() == "Pretest")
                        {
                            AllowToAssessment = false;
                            WebMsg.Show("Assessment for the class is alredy running");
                        }
                        else
                        {
                            AllowToAssessment = true;
                        }
                    }
                    else
                    {
                        AllowToAssessment = true;
                    }
                }
            }
            else
            {
                AllowToAssessment = true;
            }
            if (AllowToAssessment)
            {
                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "EducationResourcepage", "lnkDisplay", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, "Posttest", "Take Test", Convert.ToInt32(Session["BMSSCTID"]));
            }
            DataSet dsCheckLogToTrackLog = new DataSet();
            dsCheckLogToTrackLog = obj.SELECTExamTrackLogOtherEmployee(AppSessions.BMSID, AppSessions.SchoolID, AppSessions.DivisionID, AppSessions.EmpolyeeID);
            if (dsCheckLogToTrackLog.Tables.Count > 0)
            {
                if (dsCheckLogToTrackLog.Tables[0].Rows.Count > 0)
                {
                    if (dsCheckLogToTrackLog.Tables[0].Rows[0]["Activity"].ToString() == "Posttest" || dsCheckLogToTrackLog.Tables[0].Rows[0]["Activity"].ToString() == "Pretest")
                    {
                        Hashtable Question = (Hashtable)Application["Exam_TeacherSheResult"];
                        if (Question == null)
                        {
                            Question = new Hashtable();
                        }
                        else
                        {
                            if (Session["TrackLogID"] != null)
                            {
                                try
                                {
                                    Question.Remove(Session["TrackLogID"].ToString());
                                    Application.Lock();
                                    Application["Exam_TeacherSheResult"] = Question;
                                    Application.UnLock();
                                }
                                catch (Exception ex)
                                { }
                            }

                        }
                        Session["TrackLogID"] = dsCheckLogToTrackLog.Tables[0].Rows[0]["TrackLogID"].ToString();
                        TrackLog_Utils.LogGroupBMSSCTID(Convert.ToString(Session["TrackLogID"]), AppSessions.EmpolyeeID, Convert.ToString(Session["BMSSCTIIDlist"]));
                    }
                }
            }
            myframe.Attributes["src"] = Request.QueryString["rdu"];
        }
    }
}