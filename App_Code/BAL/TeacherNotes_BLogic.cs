using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for TeacherNotes_BLogic
/// </summary>
public class TeacherNotes_BLogic
{
    DataAccess DAL_SYS_Topic;
    ArrayList arrParameter;
	public TeacherNotes_BLogic()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataSet BAL_Load_SCT_BY_BMS(TeacherNotes TeacherNotes,string mode)
    {
        DAL_SYS_Topic = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("BMSID", TeacherNotes.BmsId));
        arrParameter.Add(new parameter("mode", mode));
        return DAL_SYS_Topic.DAL_Select("proc_LoadSCT", arrParameter);
    }

    public void BAL_Teacher_Note_Insert(TeacherNotes TeacherNotes, string mode)
    {
        DAL_SYS_Topic = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("mode", mode));
        arrParameter.Add(new parameter("TeacherNotes", TeacherNotes.Notes));
        DAL_SYS_Topic.DAL_InsertUpdate("Proc_Insert_TeacherNotes", arrParameter);
    }

    public DataSet BAL_Teacher_Note_Select(TeacherNotes TeacherNotes,string Mode)
    {
        DAL_SYS_Topic = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("BMSID", TeacherNotes.BmsId));
        arrParameter.Add(new parameter("Mode", Mode));
        return DAL_SYS_Topic.DAL_Select("Proc_Select_TeacherNotes", arrParameter);
    }
}