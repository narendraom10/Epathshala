///<Summary>
///</Summary>
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Udev.UserMasterPage.Classes;
using System.Globalization;
using System.IO;

public partial class Admin_ClassRoomTrackRPT : System.Web.UI.Page
{

    #region Culture
    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        if (Request.Form["ddlLanguage"] != null)
        {
            String selectedLanguage = Request.Form["ddlLanguage"];
            this.UICulture = selectedLanguage;
            this.Culture = selectedLanguage;

            Session[Global.SESSION_KEY_CULTURE] = selectedLanguage;
            Session["LANG"] = selectedLanguage;
            System.Threading.Thread.CurrentThread.CurrentCulture =
            CultureInfo.CreateSpecificCulture(selectedLanguage);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new
            CultureInfo(selectedLanguage);
        }
        base.InitializeCulture();
    }
    #endregion

    #region Variables
    TrackLogRPT_BLogic obj_TracklogRPT;
    #endregion

    # region "Properties"
    #endregion

    #region Page Events



    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds_BMS = new DataSet();
        if (!IsPostBack)
        {
            txtFdate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            obj_TracklogRPT = new TrackLogRPT_BLogic();
            ds_BMS = obj_TracklogRPT.BAL_Select_Active_Schools_BMS();

            if (ds_BMS.Tables.Count > ((int)EnumFile.AssignValue.Zero) && ds_BMS.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                ddlSchool.DataSource = ds_BMS.Tables[0];
                ddlSchool.DataTextField = "Name";
                ddlSchool.DataValueField = "SchoolID";
                ddlSchool.DataBind();
                ddlSchool.Items.Insert(((int)EnumFile.AssignValue.Zero), new System.Web.UI.WebControls.ListItem("-- Select --"));

                DropDownList[] disddl = { ddlSchool };
                EnableDropDwon(disddl);

                ViewState["BMSTable"] = (DataTable)ds_BMS.Tables[1];

                ddlBoard.DataSource = ds_BMS.Tables[1];
                ddlBoard.DataTextField = "BMS";
                ddlBoard.DataValueField = "BMSID";
                ddlBoard.DataBind();
                ddlBoard.Items.Insert(((int)EnumFile.AssignValue.Zero), new System.Web.UI.WebControls.ListItem("-- Select --"));

                ddlDivision.DataSource = ds_BMS.Tables[2];
                ddlDivision.DataTextField = "Division";
                ddlDivision.DataValueField = "DivisionID";
                ddlDivision.DataBind();
                ddlDivision.Items.Insert(((int)EnumFile.AssignValue.Zero), new System.Web.UI.WebControls.ListItem("-- Select --"));

            }
            else
            {
                DropDownList[] disddl = { ddlSchool, ddlBoard, ddlDivision };
                DisableDropDwon(disddl);
            }
        }
    }
    #endregion

    #region Control Events

    #region Button Events

    protected void btnOk_Click(object sender, EventArgs e)
    {
        obj_TracklogRPT = new TrackLogRPT_BLogic();

        DataSet dsResult = obj_TracklogRPT.BAL_Select_ClassRoom_TrackLog(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(ddlBoard.SelectedValue), Convert.ToInt16(ddlDivision.SelectedValue), Convert.ToDateTime(txtFdate.Text));

        if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
        {
            dataDiv.Visible = true;
            lblActivityLogDate1.Text = txtFdate.Text;
            lblSchoolName1.Text = dsResult.Tables[0].Rows[0]["Name"].ToString();
            lblStd1.Text = dsResult.Tables[0].Rows[0]["Standard"].ToString();
            lblDiv1.Text = dsResult.Tables[0].Rows[0]["Division"].ToString();

            GridReportList.DataSource = dsResult.Tables[1];
            GridReportList.DataBind();
        }
        else
        {
            ClearControls();
            WebMsg.Show("No Data Found.");
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=ClassRoomTrackReport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        StringWriter StringWriter = new System.IO.StringWriter();
        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        ContentDiv.RenderControl(HtmlTextWriter);
        Response.Write(StringWriter.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    #endregion

    #region Drop down Events

    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList[] disddl = { ddlBoard, ddlDivision };
        DisableDropDwon(disddl);

        if (ddlSchool.SelectedIndex > 0)
        {
            DataTable dt = (DataTable)ViewState["BMSTable"];
            ddlBoard.Items.Clear();

            if (dt.Rows.Count > 0)
            {
                DataTable dtResult = dt.Clone();
                DataRow[] dr = dt.Select("SchoolID = " + Convert.ToInt32(ddlSchool.SelectedValue));
                foreach (DataRow drLoop in dr)
                {
                    dtResult.ImportRow(drLoop);
                }

                if (dtResult.Rows.Count > 0)
                {
                    ddlBoard.DataSource = dtResult;
                    ddlBoard.DataTextField = "BMS";
                    ddlBoard.DataValueField = "BMSID";
                    ddlBoard.DataBind();
                }
            }
            ddlBoard.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select --"));

            DropDownList[] disddl1 = { ddlBoard };
            EnableDropDwon(disddl1);
        }
        else
        {
            ClearControls();
            DropDownList[] disddl3 = { ddlBoard, ddlDivision };
            DisableDropDwon(disddl3);
        }
    }

    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList[] disddl = { ddlDivision };
        DisableDropDwon(disddl);

        if (ddlBoard.SelectedIndex > 0)
        {
            DropDownList[] disddl1 = { ddlDivision };
            EnableDropDwon(disddl1);
        }
        else
        {
            ClearControls();
            DropDownList[] disddl3 = { ddlDivision };
            DisableDropDwon(disddl3);
        }
    }

    #endregion

    #endregion

    #region User Defined Functions

    public void DisableDropDwon(DropDownList[] disddl)
    {
        foreach (DropDownList dl in disddl)
        {
            dl.Enabled = false;
            dl.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);
        }
    }

    public void EnableDropDwon(DropDownList[] disddl)
    {
        foreach (DropDownList dl in disddl)
        {
            dl.Enabled = true;
            dl.SelectedIndex = Convert.ToInt32(EnumFile.AssignValue.Zero);
        }
    }

    public void ClearControls()
    {
        DropDownList[] disddl3 = { ddlSchool, ddlBoard, ddlDivision };
        DisableDropDwon(disddl3);

        DropDownList[] disddl = { ddlSchool };
        EnableDropDwon(disddl);

        //txtFdate.Text = DateTime.Today.ToString("dd-MMM-yyyy");

        GridReportList.DataSource = null;
        GridReportList.DataBind();

        dataDiv.Visible = false;
    }

    #endregion

}