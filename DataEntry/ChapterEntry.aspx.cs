using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class DataEntry_ChapterEntry : System.Web.UI.Page
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

    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList[] disddl = { ddlSubject, ddlChapter, ddlTopic, ddlType };
        DisableDropDwon(disddl);

        if (ddlBoard.SelectedIndex > ((int)EnumFile.AssignValue.Zero) && ddlMedium.SelectedIndex > ((int)EnumFile.AssignValue.Zero) && ddlStandard.SelectedIndex > ((int)EnumFile.AssignValue.Zero))
        {
            obj_BAL_SYS_Role = new SYS_Role_BLogic();

            Int16 BoardID = Convert.ToInt16(ddlBoard.SelectedValue);
            Int16 MediumID = Convert.ToInt16(ddlMedium.SelectedValue);
            Int16 StandardID = Convert.ToInt16(ddlStandard.SelectedValue);
            int Bmsid = obj_BAL_SYS_Role.BAL_Select_BMS(BoardID, MediumID, StandardID);

            if (Bmsid > ((int)EnumFile.AssignValue.Zero))
            {
                ViewState["BMSID"] = Bmsid;
                DropDownList[] disddl1 = { ddlSubject };
                EnableDropDwon(disddl1);
            }
            else
            {
                DropDownList[] disddl2 = { ddlSubject, ddlChapter, ddlTopic, ddlType };
                DisableDropDwon(disddl2);
            }
        }
        else
        {
            DropDownList[] disddl3 = { ddlSubject, ddlChapter, ddlTopic, ddlType };
            DisableDropDwon(disddl3);
        }

    }

    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList[] disddl = { ddlMedium, ddlStandard, ddlSubject, ddlChapter, ddlTopic, ddlType };
        DisableDropDwon(disddl);

        if (ddlBoard.SelectedIndex > 0)
        {

            obj_BAL_SYS_Role = new SYS_Role_BLogic();
            Int16 BoardID = Convert.ToInt16(ddlBoard.SelectedValue);
            DataSet dsSelect = new DataSet();

            dsSelect = obj_BAL_SYS_Role.BAL_Select_Medium(BoardID);
            if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero) && dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                ddlMedium.DataSource = dsSelect.Tables[0];
                ddlMedium.DataTextField = "Medium";
                ddlMedium.DataValueField = "MediumID";
                ddlMedium.DataBind();
                ddlMedium.Items.Insert(0, new ListItem("-- Select --"));

                DropDownList[] disddl1 = { ddlMedium };
                EnableDropDwon(disddl1);
            }
        }
        else
        {
            DropDownList[] disddl1 = { ddlMedium, ddlStandard, ddlSubject, ddlChapter, ddlTopic, ddlType };
            DisableDropDwon(disddl1);
        }
    }

    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList[] disddl = { ddlStandard, ddlSubject, ddlChapter, ddlTopic, ddlType };
        DisableDropDwon(disddl);

        if (ddlMedium.SelectedIndex > ((int)EnumFile.AssignValue.Zero))
        {
            obj_BAL_SYS_Role = new SYS_Role_BLogic();
            Int16 BoardID = Convert.ToInt16(ddlBoard.SelectedValue);
            Int16 MediumID = Convert.ToInt16(ddlMedium.SelectedValue);

            DataSet dsSelect = new DataSet();

            dsSelect = obj_BAL_SYS_Role.BAL_Select_StandardALL(BoardID, MediumID);

            if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero) && dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                ddlStandard.DataSource = dsSelect.Tables[0];
                ddlStandard.DataTextField = "Standard";
                ddlStandard.DataValueField = "StandardID";
                ddlStandard.DataBind();
                ddlStandard.Items.Insert(0, new ListItem("-- Select --"));

                DropDownList[] disddl1 = { ddlStandard };
                EnableDropDwon(disddl1);
            }
        }
        else
        {
            DropDownList[] disddl2 = { ddlStandard, ddlSubject, ddlChapter, ddlTopic, ddlType };
            DisableDropDwon(disddl2);
        }
    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList[] disddl = { ddlChapter, ddlTopic, ddlType };
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
                ddlChapter.Items.Add(new ListItem((EnumFile.AssignValue.Other).ToString()));
                ddlChapter.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
                ViewState["TopicTable"] = (DataTable)dsSelect.Tables[1];

                DropDownList[] disddl1 = { ddlChapter };
                EnableDropDwon(disddl1);

            }

        }
        else
        {
            DropDownList[] disddl1 = { ddlChapter, ddlTopic, ddlType };
            DisableDropDwon(disddl1);
        }
    }

    protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisableDiv();

        DropDownList[] disddl = { ddlTopic, ddlType };
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
            DropDownList[] disddl2 = { ddlTopic, ddlType };
            DisableDropDwon(disddl2);
        }
        else
        {
            DisableDiv();
            DropDownList[] disddl3 = { ddlTopic, ddlType };
            DisableDropDwon(disddl3);
        }
    }

    protected void ddlTopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisableDiv();

        DropDownList[] disddl = { ddlType };
        DisableDropDwon(disddl);

        if (ddlTopic.SelectedIndex > ((int)EnumFile.AssignValue.Zero) && !ddlTopic.SelectedItem.ToString().Equals((EnumFile.AssignValue.Other).ToString()))
        {
            DropDownList[] disddl2 = { ddlType };
            EnableDropDwon(disddl2);

            obj_BAL_SYS_Role = new SYS_Role_BLogic();

            DataSet dsSelect = new DataSet();

            dsSelect = obj_BAL_SYS_Role.BAL_Select_FileType();
            if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero) && dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {

                ddlType.DataSource = dsSelect;
                ddlType.DataTextField = "FileType";
                ddlType.DataValueField = "FileTypeID";
                ddlType.DataBind();

            }
            ddlType.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));
            ddlType.Items.Add(new ListItem((EnumFile.AssignValue.Other).ToString()));

            DropDownList[] disddl1 = { ddlType };
            EnableDropDwon(disddl1);

        }
        else if (ddlTopic.SelectedIndex > ((int)EnumFile.AssignValue.Zero) && ddlTopic.SelectedItem.ToString().Equals((EnumFile.AssignValue.Other).ToString()))
        {
            DivTopicAdd.Visible = true;
            DropDownList[] disddl3 = { ddlType };
            DisableDropDwon(disddl3);
        }
        else
        {
            DropDownList[] disddl4 = { ddlType };
            DisableDropDwon(disddl4);
        }
    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisableDiv();

        if (ddlType.SelectedIndex > ((int)EnumFile.AssignValue.Zero) && !ddlType.SelectedItem.ToString().Equals((EnumFile.AssignValue.Other).ToString()))
        {
            fuChapters.Enabled = true;
        }
        else if (ddlType.SelectedIndex > ((int)EnumFile.AssignValue.Zero) && ddlType.SelectedItem.ToString().Equals((EnumFile.AssignValue.Other).ToString()))
        {
            FileTypeDiv.Visible = true;
            fuChapters.Enabled = false;
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

    protected void btnFileTypeAdd_Click(object sender, EventArgs e)
    {
        obj_SYS_Chapter = new SYS_Chapter();
        obj_BAL_SYS_Chapter = new SYS_Chapter_BLogic();

        obj_SYS_Chapter.filetype = TxtFileType.Text;
        obj_SYS_Chapter.employeeid = Convert.ToInt64(Session["EmpolyeeID"]);

        int Result = obj_BAL_SYS_Chapter.BAL_SYS_FileType_Insert(obj_SYS_Chapter);

        if (Result == ((int)EnumFile.Result.FileAdded))
        {
            WebMsg.Show("File type Added Successfully.");
        }
        else
        {
            WebMsg.Show("File type Details already exists.");
        }
        object s = new object();
        EventArgs ea = new EventArgs();
        ddlTopic_SelectedIndexChanged(s, ea);
    }

    protected void BtnUpload_Click(object sender, EventArgs e)
    {

        #region File Validation
        if (ddlType.SelectedItem.ToString().Equals("Activity"))
        {
            if (fuChapters.PostedFile.ContentLength > ((int)EnumFile.AssignValue.Zero))
            {
                string ext = System.IO.Path.GetExtension(fuChapters.PostedFile.FileName);
                ext = ext.ToLower();
                if (ext != ".pdf")
                {
                    WebMsg.Show("Please Select .pdf File only");
                    goto Exit;
                }
            }
        }
        else if (ddlType.SelectedItem.ToString().Equals("Video Presentation"))
        {
            if (fuChapters.PostedFile.ContentLength > ((int)EnumFile.AssignValue.Zero))
            {
                string ext = System.IO.Path.GetExtension(fuChapters.PostedFile.FileName);
                ext = ext.ToLower();
                if (ext != ".flv")
                {
                    if (ext != ".swf")
                    {
                        WebMsg.Show("Please Select .swf or .flv File only");
                        goto Exit;
                    }
                }
                else if (ext != ".swf")
                {
                    if (ext != ".flv")
                    {
                        WebMsg.Show("Please Select .swf or .flv File only");
                        goto Exit;
                    }
                }
            }
        }
        else if (ddlType.SelectedItem.ToString().Equals("Question Paper"))
        {
            if (fuChapters.PostedFile.ContentLength > ((int)EnumFile.AssignValue.Zero))
            {
                string ext = System.IO.Path.GetExtension(fuChapters.PostedFile.FileName);
                ext = ext.ToLower();
                if (ext != ".pdf")
                {
                    WebMsg.Show("Please Select .pdf File only");
                    goto Exit;
                }
            }
        }
        else if (ddlType.SelectedItem.ToString().Equals("Worksheet"))
        {
            if (fuChapters.PostedFile.ContentLength > ((int)EnumFile.AssignValue.Zero))
            {
                string ext = System.IO.Path.GetExtension(fuChapters.PostedFile.FileName);
                ext = ext.ToLower();
                if (ext != ".pdf")
                {
                    WebMsg.Show("Please Select .pdf File only");
                    goto Exit;
                }
            }
        }
        else if (ddlType.SelectedItem.ToString().Equals("Teacher Resource"))
        {
            if (fuChapters.PostedFile.ContentLength > ((int)EnumFile.AssignValue.Zero))
            {
                string ext = System.IO.Path.GetExtension(fuChapters.PostedFile.FileName);
                ext = ext.ToLower();
                if (ext != ".pdf")
                {
                    WebMsg.Show("Please Select .pdf File only");
                    goto Exit;
                }
            }
        }
        else if (ddlType.SelectedItem.ToString().Equals("Glossary"))
        {
            if (fuChapters.PostedFile.ContentLength > ((int)EnumFile.AssignValue.Zero))
            {
                string ext = System.IO.Path.GetExtension(fuChapters.PostedFile.FileName);
                ext = ext.ToLower();
                if (ext != ".pdf")
                {
                    WebMsg.Show("Please Select .pdf File only");
                    goto Exit;
                }
            }
        }
        #endregion

        obj_SYS_Chapter = new SYS_Chapter();
        obj_BAL_SYS_Chapter = new SYS_Chapter_BLogic();

        obj_SYS_Chapter.subjectid = Convert.ToInt16(ddlSubject.SelectedValue);
        obj_SYS_Chapter.chapterid = Convert.ToInt64(ddlChapter.SelectedValue);
        obj_SYS_Chapter.topicid = Convert.ToInt64(ddlTopic.SelectedValue);

        Int64 sctid = obj_BAL_SYS_Chapter.BAL_SYS_SCT_Insert(obj_SYS_Chapter);

        obj_SYS_Chapter.sctid = sctid;
        obj_SYS_Chapter.bmsid = Convert.ToInt64(ViewState["BMSID"]);

        Int64 bmssctid = obj_BAL_SYS_Chapter.BAL_SYS_BMS_SCT_Insert(obj_SYS_Chapter);

        String DirectoryPath = Server.MapPath("../EduResource/" + bmssctid);
        if (!Directory.Exists(DirectoryPath))
        {
            Directory.CreateDirectory(DirectoryPath);
        }

        String ResourcePath = Server.MapPath("../EduResource/" + bmssctid + "/" + ddlType.SelectedItem.ToString());
        if (!Directory.Exists(ResourcePath))
        {
            Directory.CreateDirectory(ResourcePath);
        }

        string FilePath = ResourcePath + "\\" + fuChapters.FileName;
        fuChapters.PostedFile.SaveAs(FilePath);
        WebMsg.Show("File Uploaded successfully.");
        object s = new object();
        EventArgs ea = new EventArgs();
        btnReset_Click(s, ea);

    Exit:
        return;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        DropDownList[] disddl = { ddlMedium, ddlStandard, ddlSubject, ddlChapter, ddlTopic, ddlType };
        DisableDropDwon(disddl);
        ddlBoard.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        DisableDiv();
    }

    #endregion

    #endregion

    #region User Define Function

    public void Fillddls()
    {
        obj_SYS_Role = new SYS_Role();
        obj_BAL_SYS_Role = new SYS_Role_BLogic();

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_SYS_Role.BAL_ACTIVE_BMSS();

        if (dsSelect.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {

            ddlBoard.DataSource = dsSelect.Tables[0];
            ddlBoard.DataTextField = "Board";
            ddlBoard.DataValueField = "BoardID";
            ddlBoard.DataBind();
            ddlBoard.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

            ddlMedium.DataSource = dsSelect.Tables[1];
            ddlMedium.DataTextField = "Medium";
            ddlMedium.DataValueField = "MediumID";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

            ddlStandard.DataSource = dsSelect.Tables[2];
            ddlStandard.DataTextField = "Standard";
            ddlStandard.DataValueField = "StandardID";
            ddlStandard.DataBind();
            ddlStandard.Items.Insert(((int)EnumFile.AssignValue.Zero), new ListItem("-- Select --"));

            ddlSubject.DataSource = dsSelect.Tables[3];
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
        TxtChapterIndex.Text = string.Empty;
        TxtChapterName.Text = string.Empty;
        TxtToipcIndex.Text = string.Empty;
        TxtTopicName.Text = string.Empty;
        TxtFileType.Text = string.Empty;
        DivChapterAdd.Visible = false;
        DivTopicAdd.Visible = false;
        fuChapters.Enabled = false;
        FileTypeDiv.Visible = false;

    }

    #endregion

}