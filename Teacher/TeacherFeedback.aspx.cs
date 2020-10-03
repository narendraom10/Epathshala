/// <summary>
/// <DevelopedBy>"Bhavesh Prajapati"</DevelopedBy>
///<Date>"25-Mar-2014"</Date>
/// </summary>

using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class Teacher_TeacherFeedback : System.Web.UI.Page
{

    #region "Variables"
    SYS_BMS_BLogic BSysBMS = new SYS_BMS_BLogic();
    SYS_Role_BLogic obj_BAL_SYS_Role;
    #endregion

    # region Properties
    # endregion

    #region "Page Event"

    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropdown(ddlFeedbackSubject);
            FillBMSCombo(ddlBMS);
        }
    }
    #endregion

    #region "User Defined Function"

    private void BindDropdown(DropDownList ddlFeedbackSubject)
    {
        try
        {

            StringEnum stringEnum = new StringEnum(typeof(EnumFile.ProblemType));
            this.ddlFeedbackSubject.DataSource = stringEnum.GetListValues();
            this.ddlFeedbackSubject.DataValueField = "Key";
            this.ddlFeedbackSubject.DataTextField = "Value";
            this.ddlFeedbackSubject.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillBMSCombo(DropDownList ddlBMS)
    {
        try
        {
            DropDownFill DdlFilling = new DropDownFill();
            DataSet dsBMS = new DataSet();
            dsBMS = BSysBMS.BAL_SYS_BMS_SelectAll();
            if (dsBMS.Tables[0].Rows.Count > 0)
            {
                DdlFilling.BindDropDownByTable(ddlBMS, dsBMS.Tables[0], "BMS", "BMSID");
                ddlBMS.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
                ddlBMS.Items[0].Value = Convert.ToString((int)EnumFile.AssignValue.Zero);
                ddlBMS.Enabled = true;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    #endregion

    #region "Control Events"

    protected void ddlBMS_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBMS.SelectedIndex > ((int)EnumFile.AssignValue.Zero))
        {

            DropDownList[] disddl = { ddlSubject, ddlDivision };

            obj_BAL_SYS_Role = new SYS_Role_BLogic();
            Int64 BMSID = Convert.ToInt64(ddlBMS.SelectedValue);
            DataSet dsSelect = new DataSet();

            dsSelect = obj_BAL_SYS_Role.BAL_Allocated_Subject_Div_BasedonBMS(BMSID, Convert.ToInt64(Session["EmpolyeeID"]));

            if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero) && dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                ddlSubject.DataSource = dsSelect.Tables[0];
                ddlSubject.DataTextField = "Subject";
                ddlSubject.DataValueField = "SubjectID";
                ddlSubject.DataBind();
                ddlSubject.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                ddlDivision.DataSource = dsSelect.Tables[1];
                ddlDivision.DataTextField = "Division";
                ddlDivision.DataValueField = "DivisionID";
                ddlDivision.DataBind();
                ddlDivision.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

                DropDownList[] disddl1 = { ddlSubject, ddlDivision };
            }
        }
        else
        {
            DropDownList[] disddl = { ddlSubject, ddlDivision };
        }
    }

    #endregion
}