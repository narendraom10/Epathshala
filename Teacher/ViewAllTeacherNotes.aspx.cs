///<Summary>
///</Summary>

using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Teacher_ViewAllTeacherNotes : System.Web.UI.Page
{
    # region Variables
    TeacherNotes_BLogic BAL_TeacherNotes;
    TeacherNotes TeacherNotes;
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridData();
        }
    }
    # endregion

    # region Control events
    protected void gvAllNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ViewNote")
            {
                int index = int.Parse(e.CommandArgument.ToString());

                lblPopUpNote.Text = gvAllNotes.DataKeys[index]["Note"].ToString();
                lblPopUpSchoolName.Text = gvAllNotes.DataKeys[index]["Name"].ToString();
                lblPopUpBMSSCT.Text = gvAllNotes.DataKeys[index]["BMS_SCT"].ToString();


                this.ModalPopUpNotes.Show();
                this.upPopUp.Update();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void gvAllNotes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvAllNotes.PageIndex = e.NewPageIndex;
            BindGridData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void TxtSchoolName_TextChanged(object sender, EventArgs e)
    {
        if (TxtSchoolName.Text != string.Empty)
        {
            string Name = TxtSchoolName.Text;
            int k = Name.IndexOf("(");
            int l = Name.IndexOf(")");

            if (k > 0 & l > 0)
            {
                LtSchoolID.Text = Name.Substring(k + 1, (l - k) - 1);
                this.ViewState["SchoolID"] = LtSchoolID.Text;
            }
            else
            {
                WebMsg.Show("Please select the proper school name.");
            }
        }
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            BindGridData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControls();
        BindGridData();
    }
    # endregion 

    # region User defined functions
    protected void ClearControls()
    {
        try
        {
            TxtSchoolName.Text = string.Empty;
            LtSchoolID.Text = string.Empty;
            txtDate.Text = string.Empty;
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void BindGridData()
    {
        try
        {
            BAL_TeacherNotes = new TeacherNotes_BLogic();
            TeacherNotes = new TeacherNotes();
            DataSet dsTeacherNotes = new DataSet();

            dsTeacherNotes = BAL_TeacherNotes.BAL_Teacher_Note_Select(TeacherNotes, "ViewAllAdmin");
            if (dsTeacherNotes.Tables[0].Rows.Count > 0)
            {
                string Condition = string.Empty;

                if (LtSchoolID.Text != string.Empty)
                {
                    Condition = "SchoolID=" + LtSchoolID.Text;
                }

                if (txtDate.Text != string.Empty)
                {
                    if (Condition != string.Empty)
                    {
                        Condition = Condition + " And ";
                        Condition = Condition + "CreatedOn='" + Convert.ToDateTime(txtDate.Text).ToString() + "'";
                    }
                    else
                    {
                        Condition = "CreatedOn='" + Convert.ToDateTime(txtDate.Text).ToString() + "'";
                    }
                }

                DataView dv = new DataView(dsTeacherNotes.Tables[0]);
                dv.RowFilter = Condition;

                DataSet dsSelectSub = new DataSet();
                dsSelectSub.Tables.Add(dv.ToTable());

                gvAllNotes.DataSource = dsSelectSub.Tables[0];
                gvAllNotes.DataBind();
            }
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
    [System.Web.Services.WebMethodAttribute, System.Web.Script.Services.ScriptMethodAttribute]
    public static string[] GetSchoolName(string prefixText, int count, string contextKey)
    {
        School_BLogic SchoolBLogic = new School_BLogic();
        DataTable dt = new DataTable();
        dt = SchoolBLogic.BAL_SchoolAllNameWithID("AutoCompelete").Tables[0];

        int i = Convert.ToInt32(EnumFile.AssignValue.Zero);
        string expression;
        expression = "Name like '%" + prefixText + "%'";
        DataRow[] foundRows;
        foundRows = dt.Select(expression);
        string[] item = new string[foundRows.Count()];
        foreach (DataRow dr in foundRows)
        {
            item.SetValue(dr["Name"].ToString(), i);
            i++;
        }

        return item;
    }
    # endregion
}