using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for QuesEntry_BLogic
/// </summary>
public class QuesEntry_BLogic
{
    DataAccess DAL_SYS_Package;
    ArrayList arrParameter;

	public QuesEntry_BLogic()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void BAL_Question_Insert(Int32 BMSID,Int32 SCTID,string Question,Int16 OPID1,string OP1,Int16 OPID2,string OP2,Int16 OPID3,string OP3,Int16 OPID4,
        string OP4, Int16 COPID, string COP, string Solution, int QuestionLevel, string TestType)
    {
        DAL_SYS_Package = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("SCTID", SCTID));
        arrParameter.Add(new parameter("Question", Question));
        arrParameter.Add(new parameter("OPID1", OPID1));
        arrParameter.Add(new parameter("OP1",OP1));
        arrParameter.Add(new parameter("OPID2", OPID2));
        arrParameter.Add(new parameter("OP2", OP2));
        arrParameter.Add(new parameter("OPID3", OPID3));
        arrParameter.Add(new parameter("OP3", OP3));
        arrParameter.Add(new parameter("OPID4", OPID4));
        arrParameter.Add(new parameter("OP4", OP4));
        arrParameter.Add(new parameter("COPID", COPID));
        arrParameter.Add(new parameter("COP", COP));
        arrParameter.Add(new parameter("Solution", Solution ));
        arrParameter.Add(new parameter("QuestionLevel", QuestionLevel ));
        arrParameter.Add(new parameter("TestType", TestType));

        DAL_SYS_Package.DAL_InsertUpdate("PROC_Insert_QuestionData", arrParameter);
    }

    public DataSet BAL_Question_Select(Int32 BMSID, Int32 SCTID, string QuestionLevel, string TestType)
    {
        DAL_SYS_Package = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("BMSID", BMSID));
        arrParameter.Add(new parameter("SCTID", SCTID));
        arrParameter.Add(new parameter("QuestionLevel", QuestionLevel));
        arrParameter.Add(new parameter("TestType", TestType));


        return DAL_SYS_Package.DAL_Select("Select_SYS_QuestionBank", arrParameter);

        
       // return DAL_SYS_Package.GetDataTable();
    }
}