///<Summary>
///</Summary>

using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Teacher_AttenceSheet : System.Web.UI.Page
{
    # region Variables
    SYS_Attendance_BLogic Obj_BAl_Attendance;
    SYS_Attendance Prop_SYS_Attendance = new SYS_Attendance();
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindGVSYS_Attedancedetail();
        }
    }
    # endregion 

    # region Control events
    protected void btnFillAttence_Click(object sender, EventArgs e)
    {
        try
        {
            AttendanceInfo();
            SYS_Attendance_BLogic Obj_BAl_Attendance = new SYS_Attendance_BLogic();
            DataTable dtTempAttendanceInfo = new DataTable();
            dtTempAttendanceInfo = (DataTable)ViewState["TempAttendanceInfo"];
            String xmldata;
            StringWriter sw = new StringWriter();
            dtTempAttendanceInfo.TableName = "TempTable";
            dtTempAttendanceInfo.WriteXml(sw);
            xmldata = sw.ToString();
            Prop_SYS_Attendance.AttedanceDetails = xmldata;
            Prop_SYS_Attendance.EmployeeID = int.Parse(Session["EmpolyeeID"] as string);
            Prop_SYS_Attendance.DivisionId = int.Parse(Session["DivisionID"] as string);
            Prop_SYS_Attendance.BMSID = int.Parse(Session["BMSID"] as string);
            // Prop_SYS_Attendance.StudentId = int.Parse(Session["StudentID"] as string);
            Obj_BAl_Attendance.BAL_StudentAttedance_Insert(Prop_SYS_Attendance, "Insert");
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

    }
    # endregion

    # region User defined functions
   private void bindGVSYS_Attedancedetail()
   {
       try
       {

           Obj_BAl_Attendance = new SYS_Attendance_BLogic();
           Prop_SYS_Attendance.EmployeeID = int.Parse(Session["EmpolyeeID"] as string);
           Prop_SYS_Attendance.DivisionId = int.Parse(Session["DivisionID"] as string);
           Prop_SYS_Attendance.BMSID = int.Parse(Session["BMSID"] as string);
           DataSet dsSelect = new DataSet();
           dsSelect = Obj_BAl_Attendance.BAL_SYS_Attendance_SelectAll(Prop_SYS_Attendance, "Select");

           if (dsSelect.Tables.Count > Convert.ToInt32(EnumFile.AssignValue.Zero))
           {
               gvAttence.DataSource = dsSelect;
               gvAttence.DataBind();
               Session["StudentID"] = dsSelect.Tables[0].Rows[0]["StudentID"].ToString();
           }
       }
       catch (Exception ex)
       {
           WebMsg.Show(ex.Message.ToString());
       }
   }
   public void AttendanceInfo()
   {
       string Tmp_Absent = "A";
       string Tmp_Present = "P";
       try
       {
           DataTable dtTempAttendanceInfo = new DataTable();
           if (ViewState["TempAttendanceInfo"] == null)
           {
               dtTempAttendanceInfo.Columns.Add("Status");
               dtTempAttendanceInfo.Columns.Add("StudentID");
               dtTempAttendanceInfo.Columns.Add("CreatedByEmployeeID");
           }
           else
           {
               dtTempAttendanceInfo = (DataTable)ViewState["TempAttendanceInfo"];
           }

           DataRow dr;

           //for (int j = 0; j < GvAttence.Rows.Count; j++)
           //{
           foreach (GridViewRow gr in gvAttence.Rows)
           {
               int j = gr.RowIndex;
               dr = dtTempAttendanceInfo.Rows.Add();
               Prop_SYS_Attendance.StudentId = Convert.ToInt32(gvAttence.DataKeys[gr.RowIndex]["StudentID"]);
               CheckBox chk = (CheckBox)gr.FindControl("ChkAttence");
               if (chk.Checked == true)
               {
                   Prop_SYS_Attendance.Status = Convert.ToChar(Tmp_Absent);
               }
               else
               {
                   Prop_SYS_Attendance.Status = Convert.ToChar(Tmp_Present);
               }
               dtTempAttendanceInfo.Rows[j]["Status"] = Prop_SYS_Attendance.Status;
               dtTempAttendanceInfo.Rows[j]["StudentID"] = Prop_SYS_Attendance.StudentId;
               dtTempAttendanceInfo.Rows[j]["CreatedByEmployeeID"] = int.Parse(Session["EmpolyeeID"] as string);

               //}

           }
           ViewState["TempAttendanceInfo"] = dtTempAttendanceInfo;
       }
       catch (Exception ex)
       {
           WebMsg.Show(ex.Message);
       }

   }
   protected override void InitializeCulture()
   {
       string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
       // 'set culture to current thread 
       System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
       System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
       //call base class 
       base.InitializeCulture();
   }
   # endregion
}