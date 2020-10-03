using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;


public partial class DataEntry_ManageChapterSequence : System.Web.UI.Page
{
    #region  Culture
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

    #region page Load
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
        DropDownList[] disddl = { ddlSubject };
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
            DropDownList[] disddl1 = { ddlSubject };
            DisableDropDwon(disddl1);
            ClearGrid();
        }
    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlSubject.SelectedIndex > 0)
        //{
        //    BindGrid(); 
        //}
        //else
        //{
        //    ClearGrid();

        //}
    }

    #endregion

    #region Button Events

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlBoard.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        DropDownList[] disddl1 = { ddlSubject };
        DisableDropDwon(disddl1);
    }

    protected void ibtnSetSeq_Click(object sender, ImageClickEventArgs e)
    {
        if (IsValidSequence())
        {

            DataTable TbBmsSct = new DataTable("TbBmsSct");

            TbBmsSct.Columns.Add("BMSSCTID", typeof(Int64));
            TbBmsSct.Columns.Add("SequenceNo", typeof(Int32));
            TbBmsSct.Columns.Add("EmployeeID", typeof(Int64));

            for (int i = 0; i < grdChapter.Rows.Count; i++)
            {
                DataRow dr = TbBmsSct.NewRow();
                dr["BMSSCTID"] = Convert.ToInt64(grdChapter.DataKeys[i].Values["BMSSCTID"].ToString());
                TextBox tb1 = (TextBox)grdChapter.Rows[i].Cells[3].FindControl("TxtSequenceNo");
                dr["SequenceNo"] = Convert.ToInt32(tb1.Text);
                dr["EmployeeID"] = Convert.ToInt64(Session["EmpolyeeID"]);
                TbBmsSct.Rows.Add(dr);
            }

            if (TbBmsSct.Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
                try
                {
                    SYS_Chapter_BLogic obj = new SYS_Chapter_BLogic();

                    String xmldata;
                    StringWriter sw = new StringWriter();
                    TbBmsSct.TableName = "TbBmsSct";
                    TbBmsSct.WriteXml(sw);
                    xmldata = sw.ToString();
                    obj.BAL_SYS_ChapterSeq_Update(xmldata);

                    WebMsg.Show("Chapter Sequence Set Successfully.");

                }
                catch (Exception ex)
                {
                    WebMsg.Show("Error Updating Chapter Sequence.");
                }

            }
            else
            {
                WebMsg.Show("No Data to Set.");
            }
            //ClearAll();
        }
        else
        {
            WebMsg.Show(Convert.ToString(ViewState["MSG"]));
        }
    }

    protected void BtnGo_Click(object sender, EventArgs e)
    {
        this.SortField = "Chapter";
        this.SortDirection = "ascending";

        BindGrid();
    }

    protected void ImgBtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        ClearAll();
    }

    #endregion

    #region Grid Events
    protected void grdChapter_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "descending" ? "ascending" : "descending");
        else
            this.SortDirection = "ascending";


        this.SortField = e.SortExpression;
        BindGrid();

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.GrvSortingSetImage(e, grdChapter, this.SortDirection);
    }

    string SortDirection
    {
        get
        {
            object o = ViewState["SortDirection"];
            if (o == null)
                return String.Empty;
            else
                return (string)o;
        }
        set
        {
            ViewState["SortDirection"] = value;
        }
    }
    string SortField
    {
        get
        {
            object o = ViewState["SortField"];
            if (o == null)
                return String.Empty;
            else
                return (string)o;
        }
        set
        {
            ViewState["SortField"] = value;
        }
    }
    #endregion

    #endregion

    #region User Define Function

    public void BindGrid()
    {
        obj_SYS_Chapter = new SYS_Chapter();
        obj_BAL_SYS_Chapter = new SYS_Chapter_BLogic();

        obj_SYS_Chapter.bmsid = Convert.ToInt64(ViewState["BMSID"]);
        obj_SYS_Chapter.subjectid = Convert.ToInt16(ddlSubject.SelectedValue);

        DataSet ds = obj_BAL_SYS_Chapter.BAL_SYS_ChapterSeq_Select(obj_SYS_Chapter);

        GridViewOperations GrvOperation = new GridViewOperations();
        GrvOperation.BindGridWithSorting(grdChapter, ds, this.SortField, this.SortDirection);

        //if (ds.Tables.Count > 0)
        //{
        //    grdChapter.DataSource = ds;
        //    grdChapter.DataBind();
        //}


    }

    public void ClearGrid()
    {
        grdChapter.DataSource = null;
        grdChapter.DataBind();

    }

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
        //ClearGrid();
    }

    public void ClearAll()
    {
        ddlBoard.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
        DropDownList[] disddl1 = { ddlSubject };
        DisableDropDwon(disddl1);
        ClearGrid();
    }

    public bool IsValidSequence()
    {
        ViewState["MSG"] = "";
        bool result = true;
        if (grdChapter.Rows.Count > ((int)EnumFile.AssignValue.Zero))
        {
            for (int i = 0; i < grdChapter.Rows.Count; i++)
            {
                TextBox tb = (TextBox)grdChapter.Rows[i].Cells[3].FindControl("TxtSequenceNo");
                if (tb.Text == "")
                {
                    tb.Text = "0";
                    result = false;
                    ViewState["MSG"] = "Sequence number doesn't allow zero(0)";
                    goto exit;
                }
            }
            for (int i = 0; i < grdChapter.Rows.Count; i++)
            {
                TextBox tb1 = (TextBox)grdChapter.Rows[i].Cells[3].FindControl("TxtSequenceNo");
                Int32 seqno1 = Convert.ToInt32(tb1.Text);

                for (int j = 0; j < grdChapter.Rows.Count; j++)
                {
                    TextBox tb2 = (TextBox)grdChapter.Rows[j].Cells[3].FindControl("TxtSequenceNo");
                    Int32 seqno2 = Convert.ToInt32(tb2.Text);
                    if (i != j)
                    {
                        if (seqno1 == seqno2)
                        {
                            result = false;
                            ViewState["MSG"] = "Sequence number doesn't allow Duplicate value make it unique.";
                            goto exit;
                        }
                    }
                }
            }
        }
        else
        {
            result = false;
        }
    exit:
        return result;
    }

    #endregion
}