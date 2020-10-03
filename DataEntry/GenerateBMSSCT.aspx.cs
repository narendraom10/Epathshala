using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class DataEntry_GenerateBMSSCT : System.Web.UI.Page
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

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fillddls();
        }
    }
    #endregion

    #region Control Events

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
                    TxtChapterIndex.Text = Convert.ToString(dsSelect.Tables[0].Rows.Count + 1);
                }
                else
                {
                    TxtChapterIndex.Text = "1";
                }
                ddlChapter.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
                ddlChapter.Items.Add(new ListItem((EnumFile.AssignValue.Other).ToString()));
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
        DisableDiv();

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
            ddlTopic.Items.Add(new ListItem((EnumFile.AssignValue.Other).ToString()));

            DropDownList[] disddl1 = { ddlTopic };
            EnableDropDwon(disddl1);
        }
        else if (ddlChapter.SelectedIndex > ((int)EnumFile.AssignValue.Zero) && ddlChapter.SelectedItem.ToString().Equals((EnumFile.AssignValue.Other).ToString()))
        {
            DivChapterAdd.Visible = true;
            DropDownList[] disddl2 = { ddlTopic };
            DisableDropDwon(disddl2);
        }
        else
        {
            DisableDiv();
            DropDownList[] disddl3 = { ddlTopic };
            DisableDropDwon(disddl3);
        }
    }

    protected void ddlTopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisableDiv();

        if (ddlTopic.SelectedIndex > ((int)EnumFile.AssignValue.Zero) && ddlTopic.SelectedItem.ToString().Equals((EnumFile.AssignValue.Other).ToString()))
        {
            DivTopicAdd.Visible = true;
            TxtToipcIndex.Text = "1";

        }
        else
        {
            DivTopicAdd.Visible = false;
        }
    }

    #endregion

    #region Button Events
    protected void BtnChapterAdd_Click(object sender, EventArgs e)
    {
        obj_SYS_Chapter = new SYS_Chapter();
        obj_BAL_SYS_Chapter = new SYS_Chapter_BLogic();
        obj_SYS_Chapter.bmsid = Convert.ToInt64(ViewState["BMSID"]);
        obj_SYS_Chapter.subjectid = Convert.ToInt16(ddlSubject.SelectedValue);
        obj_SYS_Chapter.chapterindex = Convert.ToInt16(TxtChapterIndex.Text);
        obj_SYS_Chapter.chapter = TxtChapterName.Text;
        obj_SYS_Chapter.employeeid = Convert.ToInt64(Session["EmpolyeeID"]);
        int Result = obj_BAL_SYS_Chapter.BAL_SYS_Chapter_Insert(obj_SYS_Chapter);
        if (Result == ((int)EnumFile.Result.FileAdded))
        {
            WebMsg.Show("Chapter Added Successfully.");
        }
        else
        {
            WebMsg.Show("Chapter Details already exists.");
        }
        object s = new object();
        EventArgs ea = new EventArgs();
        ddlSubject_SelectedIndexChanged(s, ea);
    }

    protected void BtnTopicAdd_Click(object sender, EventArgs e)
    {
        obj_SYS_Chapter = new SYS_Chapter();
        obj_BAL_SYS_Chapter = new SYS_Chapter_BLogic();

        obj_SYS_Chapter.chapterid = Convert.ToInt16(ddlChapter.SelectedValue);
        obj_SYS_Chapter.topicindex = Convert.ToInt16(TxtToipcIndex.Text);
        obj_SYS_Chapter.topic = TxtTopicName.Text;
        obj_SYS_Chapter.employeeid = Convert.ToInt64(Session["EmpolyeeID"]);

        int Result = obj_BAL_SYS_Chapter.BAL_SYS_Topic_Insert(obj_SYS_Chapter);

        if (Result == ((int)EnumFile.Result.FileAdded))
        {
            WebMsg.Show("Topic Added Successfully.");
        }
        else
        {
            WebMsg.Show("Topic Details already exists.");
        }

        object s = new object();
        EventArgs ea = new EventArgs();
        ddlSubject_SelectedIndexChanged(s, ea);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        DropDownList[] disddl = { ddlSubject, ddlChapter, ddlTopic };
        DisableDropDwon(disddl);
        ddlBoard.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        DisableDiv();
    }

    protected void BtnGenerate_Click(object sender, EventArgs e)
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

        DropDownList[] disddl = { ddlTopic };
        DisableDropDwon(disddl);
        ddlChapter.SelectedIndex = 0;
        
        

    }

    #endregion

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
        DivChapterAdd.Visible = false;
        DivTopicAdd.Visible = false;
    }

    public void DisableDiv()
    {
        //TxtChapterIndex.Text = string.Empty;
        TxtChapterName.Text = string.Empty;
        TxtToipcIndex.Text = string.Empty;
        TxtTopicName.Text = string.Empty;

        DivChapterAdd.Visible = false;
        DivTopicAdd.Visible = false;

    }

    #endregion

}