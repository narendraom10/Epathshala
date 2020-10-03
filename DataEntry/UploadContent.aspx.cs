using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class DataEntry_UploadContent : System.Web.UI.Page
{

    #region Culture
    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }
    #endregion

    #region Variables
    SYS_Role_BLogic obj_BAL_SYS_Role;
    SYS_Role obj_SYS_Role;
    SYS_Chapter_BLogic obj_BAL_SYS_Chapter;
    SYS_Chapter obj_SYS_Chapter;

    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fillddls();
        }
    }

    #region Button Events
    
    protected void btnReset_Click(object sender, EventArgs e)
    {
        DropDownList[] disddl = { ddlSubject, ddlChapter, ddlTopic };
        DisableDropDwon(disddl);
        ddlBoard.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
    }

    protected void BtnUploadContent_Click(object sender, EventArgs e)
    {
        obj_SYS_Chapter = new SYS_Chapter();
        obj_BAL_SYS_Chapter = new SYS_Chapter_BLogic();

        obj_SYS_Chapter.subjectid = Convert.ToInt16(ddlSubject.SelectedValue);
        obj_SYS_Chapter.chapterid = Convert.ToInt64(ddlChapter.SelectedValue);
        obj_SYS_Chapter.topicid = Convert.ToInt64(ddlTopic.SelectedValue);

        Int64 sctid = obj_BAL_SYS_Chapter.BAL_SYS_SCT_Insert(obj_SYS_Chapter);

        obj_SYS_Chapter.sctid = sctid;
        obj_SYS_Chapter.bmsid = Convert.ToInt64(ViewState["BMSID"]);

        Int64 bmssctid = obj_BAL_SYS_Chapter.BAL_SYS_BMS_SCT_Insert(obj_SYS_Chapter);

        WebMsg.Show("Generated BMS SCT ID is = " + bmssctid);

    }

    #endregion

    #region DropDown Events

    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList[] disddl = { ddlSubject, ddlChapter, ddlTopic };
        DisableDropDwon(disddl);

        if (ddlBoard.SelectedIndex > ((int)EnumFile.AssignValue.Zero))
        {
            Int64 bmsID = Convert.ToInt16(ddlBoard.SelectedValue);

            ViewState["BMSID"] = bmsID;

            DropDownList[] disddl1 = { ddlSubject };
            EnableDropDwon(disddl1);

        }
        else
        {
            DropDownList[] disddl1 = { ddlSubject, ddlChapter, ddlTopic };
            DisableDropDwon(disddl1);
        }
    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList[] disddl = { ddlChapter, ddlTopic };
        DisableDropDwon(disddl);

        if (ddlSubject.SelectedIndex > ((int)EnumFile.AssignValue.Zero))
        {
            ddlChapter.Items.Clear();

            obj_SYS_Role = new SYS_Role();
            obj_BAL_SYS_Role = new SYS_Role_BLogic();

            DataSet dsSelect = new DataSet();

            dsSelect = obj_BAL_SYS_Role.BAL_Select_Chapters(Convert.ToInt64(ViewState["BMSID"]), Convert.ToInt32(ddlSubject.SelectedValue));

            if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
            {
                if (dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
                {
                    ddlChapter.DataSource = dsSelect.Tables[0];
                    ddlChapter.DataTextField = "Chapter";
                    ddlChapter.DataValueField = "ChapterID";
                    ddlChapter.DataBind();
                }
                ddlChapter.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
                //ddlChapter.Items.Add(new ListItem((EnumFile.AssignValue.Other).ToString()));
                ddlChapter.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
                ViewState["TopicTable"] = (DataTable)dsSelect.Tables[1];

                DropDownList[] disddl1 = { ddlChapter };
                EnableDropDwon(disddl1);

            }

        }
        else
        {
            DropDownList[] disddl1 = { ddlChapter, ddlTopic };
            DisableDropDwon(disddl1);
        }
    }

    protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList[] disddl = { ddlTopic };
        DisableDropDwon(disddl);

        if (ddlChapter.SelectedIndex > ((int)EnumFile.AssignValue.Zero) && !ddlChapter.SelectedItem.ToString().Equals((EnumFile.AssignValue.Other).ToString()))
        {
            DataTable dt = (DataTable)ViewState["TopicTable"];
            ddlTopic.Items.Clear();

            if (dt.Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                DataTable dtResult = dt.Clone();
                DataRow[] dr = dt.Select("ChapterID = " + Convert.ToInt32(ddlChapter.SelectedValue));
                foreach (DataRow drLoop in dr)
                {
                    dtResult.ImportRow(drLoop);
                }

                if (dtResult.Rows.Count > ((int)EnumFile.AssignValue.Zero))
                {
                    ddlTopic.DataSource = dtResult;
                    ddlTopic.DataTextField = "Topic";
                    ddlTopic.DataValueField = "TopicID";
                    ddlTopic.DataBind();
                }
            }
            ddlTopic.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
            //ddlTopic.Items.Add(new ListItem((EnumFile.AssignValue.Other).ToString()));

            DropDownList[] disddl1 = { ddlTopic };
            EnableDropDwon(disddl1);
        }
        else if (ddlChapter.SelectedIndex > ((int)EnumFile.AssignValue.Zero) && ddlChapter.SelectedItem.ToString().Equals((EnumFile.AssignValue.Other).ToString()))
        {
            //DivChapterAdd.Visible = true;
            DropDownList[] disddl2 = { ddlTopic };
            DisableDropDwon(disddl2);
        }
        else
        {
            DropDownList[] disddl3 = { ddlTopic };
            DisableDropDwon(disddl3);
        }
    }

    #endregion

    #region User Define Function

    public void Fillddls()
    {
        obj_SYS_Role = new SYS_Role();
        obj_BAL_SYS_Role = new SYS_Role_BLogic();

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_SYS_Role.BAL_Select_BMSList();

        if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {

            ddlBoard.DataSource = dsSelect.Tables[0];
            ddlBoard.DataTextField = "BMS";
            ddlBoard.DataValueField = "BMSID";
            ddlBoard.DataBind();
            ddlBoard.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

            ddlSubject.DataSource = dsSelect.Tables[1];
            ddlSubject.DataTextField = "Subject";
            ddlSubject.DataValueField = "SubjectID";
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

        }

    }

    public void DisableDropDwon(DropDownList[] disddl)
    {
        foreach (DropDownList dl in disddl)
        {
            dl.Enabled = false;
            dl.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        }

    }

    public void EnableDropDwon(DropDownList[] disddl)
    {
        foreach (DropDownList dl in disddl)
        {
            dl.Enabled = true;
            dl.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        }
    }
    #endregion
}