using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Collections;

/// <summary> 
/// <DevelopedBy>"Shailendrasinh"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"Shailendrasinh"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public class SYS_Rescheduling_BLogic
{
   
    DataAccess DAL_SYS_Status;
    ArrayList arrParameter;

	public SYS_Rescheduling_BLogic()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet BAL_SYS_Rescheduling_Details(SYS_Rescheduling Prop_SYS_Rescheduling, String mode)
    {
        DataSet ds = new DataSet();
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();
        return DAL_SYS_Status.DAL_Select("Proc_Select_Rescheduling", arrParameter);
    }

    public DataSet BAL_SYS_Rescheduling_Details_Student(SYS_Rescheduling Prop_SYS_Rescheduling, String mode)
    {
        DataSet ds = new DataSet();
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();
        return DAL_SYS_Status.DAL_Select("Proc_Select_Rescheduling_Student", arrParameter);
    }

    public DataSet BAL_SYS_Rescheduling_Update(SYS_Rescheduling Prop_SYS_Rescheduling)
    {
        DataSet ds = new DataSet();
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("ReSchedulingID", Prop_SYS_Rescheduling.ReSchedulingID));
        arrParameter.Add(new parameter("BMSSCTID", Prop_SYS_Rescheduling.BMSSCTID));
        arrParameter.Add(new parameter("EmployeeID", Prop_SYS_Rescheduling.EmployeeID));
        arrParameter.Add(new parameter("StartDate", Prop_SYS_Rescheduling.StartDate));
        arrParameter.Add(new parameter("EndDate", Prop_SYS_Rescheduling.EndDate));
        return DAL_SYS_Status.DAL_Select("Proc_Update_Rescheduling", arrParameter);
    }

    public DataSet BAL_SYS_Rescheduling_Update_Student(SYS_Rescheduling Prop_SYS_Rescheduling)
    {
        DataSet ds = new DataSet();
        DAL_SYS_Status = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("SReSchedulingID", Prop_SYS_Rescheduling.SReSchedulingID));
        arrParameter.Add(new parameter("BMSSCTID", Prop_SYS_Rescheduling.BMSSCTID));
        arrParameter.Add(new parameter("StudentID", Prop_SYS_Rescheduling.StudentID));
        arrParameter.Add(new parameter("StartDate", Prop_SYS_Rescheduling.StartDate));
        arrParameter.Add(new parameter("EndDate", Prop_SYS_Rescheduling.EndDate));
        return DAL_SYS_Status.DAL_Select("Proc_Update_Rescheduling_Student", arrParameter);
    }
}