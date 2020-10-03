///<Summary>
///</Summary>

using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Teacher_TeacherNotes : System.Web.UI.Page
{
    #region "Declarations"

    TeacherNotes_BLogic BAL_TeacherNotes;
    TeacherNotes TeacherNotes;
    #endregion

    # region Properties
    # endregion

    #region "PageEvents"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["EmployeeID"] = AppSessions.EmpolyeeID;
            ViewState["BMSID"] = AppSessions.BMSID;
            ViewState["SchoolID"] = AppSessions.SchoolID;
            LoadSCT();
            SetInitialRow();
            BindGridData();
        }
    }
    #endregion

    #region "ControlEvents"

    protected void lnlAddRow_Click(object sender, EventArgs e)
    {
        try
        {
            GenerateDataTable();
            DataTable dtAddRow = new DataTable();
            dtAddRow = (DataTable)ViewState["TeachrNote"];
            int j = Convert.ToInt32(EnumFile.AssignValue.Zero);
            foreach (GridViewRow gr in gvTeacherNote.Rows)
            {
                Label lb = (Label)gr.FindControl("lblNo");
                TextBox tx = (TextBox)gr.FindControl("txtNote");
                dtAddRow.Rows.Add();
                dtAddRow.Rows[j]["Note"] = tx.Text;
                j = j + 1;
            }

            dtAddRow.Rows.Add();
            dtAddRow.Rows[j]["Note"] = string.Empty;
            ViewState["TempData"] = dtAddRow;
            gvTeacherNote.DataSource = dtAddRow;
            gvTeacherNote.DataBind();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }


    protected void lnlDelete_Click(object sender, EventArgs e)
    {
        ArrayList Alist = new ArrayList();
        foreach (GridViewRow gr in gvTeacherNote.Rows)
        {
            CheckBox chk = (CheckBox)gr.FindControl("chkSelect");
            if (chk.Checked == true)
            {
                Alist.Add(gr.RowIndex);
            }
        }

        if (Alist.Count > ((int)EnumFile.AssignValue.Zero))
        {
            DataTable dt = (DataTable)ViewState["TempData"];
            for (int i = 0; i < Alist.Count; i++)
            {
                gvTeacherNote.DeleteRow(int.Parse(Alist[i].ToString()));
            }
        }
        else
        {
            WebMsg.Show("Please select one record.");
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void gvTeacherNote_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteRow")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                DataTable dt = (DataTable)ViewState["TempData"];
                dt.Rows[index - 1].Delete();
                gvTeacherNote.DataSource = dt;
                gvTeacherNote.DataBind();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            BAL_TeacherNotes = new TeacherNotes_BLogic();
            TeacherNotes = new TeacherNotes();
            DataTable dtNotes = new DataTable();
            dtNotes = GetNotes();
            String xmldata;
            StringWriter sw = new StringWriter();


            dtNotes.TableName = "TeacherNotes";
            dtNotes.WriteXml(sw);
            xmldata = sw.ToString();

            TeacherNotes.Notes = xmldata;
            BAL_TeacherNotes.BAL_Teacher_Note_Insert(TeacherNotes, "Insert");
            ClearControls();
            BindGridData();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    #endregion

    #region "UserDefined Functions"

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }

    protected void BindGridData()
    {
        try
        {
            BAL_TeacherNotes = new TeacherNotes_BLogic();
            TeacherNotes = new TeacherNotes();
            TeacherNotes.BmsId = int.Parse(ViewState["BMSID"].ToString());
            DataSet dsTeacherNotes = new DataSet();
            dsTeacherNotes = BAL_TeacherNotes.BAL_Teacher_Note_Select(TeacherNotes, "ViewTeacher");
            if (dsTeacherNotes.Tables[0].Rows.Count > 0)
            {
                gvNotes.DataSource = dsTeacherNotes.Tables[0];
                gvNotes.DataBind();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void LoadSCT()
    {
        try
        {
            BAL_TeacherNotes = new TeacherNotes_BLogic();
            TeacherNotes = new TeacherNotes();
            TeacherNotes.BmsId = int.Parse(ViewState["BMSID"].ToString());
            DataSet ds = new DataSet();
            ds = BAL_TeacherNotes.BAL_Load_SCT_BY_BMS(TeacherNotes,"TeacherNote");
            if (ds.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                ddlBMSSCT.Items.Clear();
                ddlBMSSCT.DataSource = ds.Tables[0];
                ddlBMSSCT.DataTextField = "SCT";
                ddlBMSSCT.DataValueField = "BMSSCTID";
                ddlBMSSCT.DataBind();
                ddlBMSSCT.Items.Insert(((int)EnumFile.AssignValue.Zero), "-- Select --");
                ddlBMSSCT.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

    }

    protected void SetInitialRow()
    {
        try
        {
            GenerateDataTable();
            DataTable dtTeacherNotes = new DataTable();
            dtTeacherNotes = (DataTable)ViewState["TeachrNote"];
            dtTeacherNotes.Rows.Add();
            gvTeacherNote.DataSource = dtTeacherNotes;
            gvTeacherNote.DataBind();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void GenerateDataTable()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No");
            dt.Columns.Add("Note");
            ViewState["TeachrNote"] = dt;
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void ClearControls()
    {
        try
        {
            ddlBMSSCT.SelectedValue = ((int)EnumFile.AssignValue.Zero).ToString();
            SetInitialRow();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected DataTable GetNotes()
    {
        DataTable dtData = new DataTable();
        try
        {

            dtData.Columns.Add("BMSSCTID");
            dtData.Columns.Add("Note");
            dtData.Columns.Add("EmployeeID");
            int j = 0;
            foreach (GridViewRow gr in this.gvTeacherNote.Rows)
            {
                TextBox tx = (TextBox)gr.FindControl("txtNote");
                dtData.Rows.Add();
                dtData.Rows[j]["BMSSCTID"] = ddlBMSSCT.SelectedValue;
                dtData.Rows[j]["Note"] = tx.Text;
                dtData.Rows[j]["EmployeeID"] = int.Parse(ViewState["EmployeeID"].ToString());
                j = j + 1;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

        return dtData;
    }

    #endregion
}