using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserManagement_Support : System.Web.UI.Page
{
  
	public string username, loginid;
	protected void Page_Load(object sender, EventArgs e)
	{
		txtUserName.Text = AppSessions.UserName.ToString();
		TxtEmail.Text = AppSessions.LoginID.ToString();
	}
	protected void btnsubmit_Click(object sender, EventArgs e)
	{
		try
		{
			Forum_BAL frmbal = new Forum_BAL();
			Forum forum = new Forum();
			string post;
			int postedby;
			post =DDLsubject.SelectedItem.ToString()+txtDesc.Text;
			postedby = AppSessions.StudentID;
			forum.Post = post;
			forum.PostedBy = postedby;
			frmbal.Forum_Insert(forum);
		   
			Resetcontrols();
		}
		catch (Exception ex)
		{
			WebMsg.Show(ex.Message);
		}
		finally
		{
			WebMsg.Show("Will getback shortly!!!");
		}

	}
	public void Resetcontrols()
	{
		txtDesc.Text = "";
		DDLsubject.SelectedIndex = 0;
	}
}