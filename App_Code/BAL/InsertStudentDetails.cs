using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class InsertStudentDetails
{
    DataAccess DAL_StudentDetails;
    ArrayList arrParameter;
    public InsertStudentDetails()
	{

	}
    public void BAL_StudentDetails_Insert(StudentDetails StudentDetails)
    {
        DAL_StudentDetails = new DataAccess();

        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("FirstName", StudentDetails.FirstName));
        arrParameter.Add(new parameter("LastName", StudentDetails.LastName));
        arrParameter.Add(new parameter("ContactNo", StudentDetails.ContactNo));
        arrParameter.Add(new parameter("DateOfBirth", StudentDetails.DateOfBirth));
        arrParameter.Add(new parameter("Gender", StudentDetails.Gender));
        arrParameter.Add(new parameter("SchoolID", StudentDetails.SchoolID));
        arrParameter.Add(new parameter("School", StudentDetails.School));
        arrParameter.Add(new parameter("LoginID", StudentDetails.LoginID));
        arrParameter.Add(new parameter("BoardID", StudentDetails.BoardID));
        arrParameter.Add(new parameter("MediumID", StudentDetails.MediumID));
        arrParameter.Add(new parameter("StandardID", StudentDetails.StandardID));
        arrParameter.Add(new parameter("Password", StudentDetails.Password));

        DAL_StudentDetails.DAL_InsertUpdate("sp_1", arrParameter);
    }
   
    public DataSet selectschooldetail()
    {
        DAL_StudentDetails = new DataAccess();
        arrParameter = new ArrayList();
     
        return DAL_StudentDetails.DAL_Select("sch_proc", arrParameter);

    }

    public DataSet selectboarddetail()
    {
        DAL_StudentDetails = new DataAccess();
        arrParameter = new ArrayList();

        return DAL_StudentDetails.DAL_Select("Board_procedure", arrParameter);
    }

    public DataSet getMediumbyBoard(int BoardID)
    {
        DAL_StudentDetails = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("BoardId", BoardID));

        return DAL_StudentDetails.DAL_Select("sp_getmedium", arrParameter);
    }
    public DataSet SelectMedium()
    {
        DAL_StudentDetails = new DataAccess();
        arrParameter = new ArrayList();
        return DAL_StudentDetails.DAL_Select("Medium_Procedure", arrParameter);
    }
    public DataSet SelectStandard()
    {
        DAL_StudentDetails = new DataAccess();
        arrParameter = new ArrayList();
        return DAL_StudentDetails.DAL_Select("Standard_Procedure", arrParameter);
    }
   
    public DataSet getStandardbyBoardMedium(int BoardID, int MediumID)
    {
        DAL_StudentDetails = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("BoardId", BoardID));
        arrParameter.Add(new parameter("MediumID", MediumID));

        return DAL_StudentDetails.DAL_Select("sp_getstandard", arrParameter);
    }
 
    public DataSet selectloginid(StudentDetails StudentDetails)
    {
        DAL_StudentDetails = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("LoginID", StudentDetails.LoginID));

        return DAL_StudentDetails.DAL_Select("Reg_Proc", arrParameter);
    }

    public DataSet logindetails(StudentDetails StudentDetails)
    {
        DAL_StudentDetails = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("LoginID", StudentDetails.LoginID));
        arrParameter.Add(new parameter("Password", StudentDetails.Password));

        return DAL_StudentDetails.DAL_Select("login_proc", arrParameter);
    }

    public DataSet profiledetail(StudentDetails StudentDetails)
    {
        DAL_StudentDetails = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("LoginID", StudentDetails.LoginID));

        return DAL_StudentDetails.DAL_Select("Details_Proc1", arrParameter);
    }

    public void UpdateDetail(StudentDetails StudentDetails)
    {
        DAL_StudentDetails = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("FirstName", StudentDetails.FirstName));
        arrParameter.Add(new parameter("LastName", StudentDetails.LastName));
        arrParameter.Add(new parameter("ContactNo", StudentDetails.ContactNo));
        arrParameter.Add(new parameter("DateOfBirth", StudentDetails.DateOfBirth));
        arrParameter.Add(new parameter("Gender", StudentDetails.Gender));
        arrParameter.Add(new parameter("LoginID", StudentDetails.LoginID));
        arrParameter.Add(new parameter("School", StudentDetails.School));
        arrParameter.Add(new parameter("BoardID", StudentDetails.BoardID));
        arrParameter.Add(new parameter("MediumID", StudentDetails.MediumID));
        arrParameter.Add(new parameter("StandardID", StudentDetails.StandardID));

        DAL_StudentDetails.DAL_InsertUpdate("UpdateDetails_sp", arrParameter);
    }
}