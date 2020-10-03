using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Student_WebUserControl : System.Web.UI.UserControl
{
    ReportsForResult obj_bal_Report_for_result;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //int Examid = 25;
        //BindGrid(Examid);
    }

    public void BindGrid(int ExamId)
    {
        obj_bal_Report_for_result = new ReportsForResult();
        DataSet dsResult = new DataSet();

        dsResult = obj_bal_Report_for_result.BAL_SYS_GetResultByExamid(ExamId);
        GrdExamResult.DataSource = dsResult.Tables[0];
        GrdExamResult.DataBind();
    }
}