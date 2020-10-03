using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class Dashboard_SearchResult : System.Web.UI.Page
{
    Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Key"] != null)
            {
                ViewState["searckkey"] = Request.QueryString["Key"];
                lblsearckkey.Text = Convert.ToString(ViewState["searckkey"]);
                DataTable dt = new DataTable();
                dt = obj_BAL_Teacher_Dashboard.BAL_BSMSearchResult(Convert.ToString(ViewState["searckkey"])).Tables[0];

                DataSet dsSettingsRemove = new DataSet();
                dsSettingsRemove = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("ShowChapterOnlyWithContent");

                List<DataRow> oDataRowList = new List<DataRow>();
                if (Convert.ToBoolean(dsSettingsRemove.Tables[0].Rows[0]["value"].ToString()))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        bool dirExists = false;
                        string Path1 = Server.MapPath("../EduResource/" + Convert.ToString(dr["BMSSCTID"]));
                        if (Directory.Exists(Path1))
                        {
                            dirExists = true;
                        }
                        if (!dirExists)
                            oDataRowList.Add(dr);
                    }
                    foreach (DataRow dr in oDataRowList)
                    {
                        dt.Rows.Remove(dr);
                    }
                }
                GvContentList.DataSource = dt;
                GvContentList.DataBind();
            }
        }
    }
    protected void GvContentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Int64 bmssctid = Convert.ToInt64(Convert.ToString(GvContentList.DataKeys[Convert.ToInt16(e.CommandArgument)].Values["BMSSCTID"]));
        string chapter = Convert.ToString(GvContentList.DataKeys[Convert.ToInt16(e.CommandArgument)].Values["Chapter"]);
        string topic = Convert.ToString(GvContentList.DataKeys[Convert.ToInt16(e.CommandArgument)].Values["Topic"]);
        string BMS = Convert.ToString(GvContentList.DataKeys[Convert.ToInt16(e.CommandArgument)].Values["BMS"]);

        if (bmssctid > (int)EnumFile.AssignValue.Zero)
        {
            Session["ChapterTopic"] = chapter + " >> " + topic;
            Session["Chapter"] = chapter;
            Session["BMSSCTID"] = bmssctid;
            String Path1 = Server.MapPath("../EduResource/" + bmssctid);

            this.Title = "Epathshala - " + bmssctid;
            if (Directory.Exists(Path1) == false)
            {
                Path1 = Server.MapPath("../EduResource/NoContent");
            }
            if (Directory.Exists(Path1))
            {
                SetBMSAndDivisionID(bmssctid, BMS);
                Response.Redirect("EducationalResource.aspx?Type=Teacher&frm=search&key=" + Convert.ToString(ViewState["searckkey"]) + "", false);
            }
            else
            {
                WebMsg.Show(bmssctid.ToString() + ": No Educational resource available.");
            }
        }
        else
        {
            WebMsg.Show(bmssctid.ToString() + ": No Educational resource available.");
        }
    }

    private void SetBMSAndDivisionID(Int64 bmssctid, string bms)
    {
        SYS_BMS_BLogic objBMSSCT = new SYS_BMS_BLogic();
        DataSet BmssctDs = new DataSet();
        if (!string.IsNullOrEmpty(Convert.ToString(bmssctid)))
        {
            BmssctDs = objBMSSCT.BAL_SYS_BMSSCT_ByGroupBMSSCTID(Convert.ToString(bmssctid));
            if (BmssctDs.Tables.Count > 0)
            {
                if (BmssctDs.Tables[0].Rows.Count > 0)
                {
                    AppSessions.BMSID = Convert.ToInt32(BmssctDs.Tables[0].Rows[0]["BMSID"]);
                    AppSessions.BMS = bms;
                }
            }
        }
    }
    protected void GvContentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GvContentList, "Select$" + e.Row.RowIndex);
            e.Row.ToolTip = "Click to select this row.";
        }
    }
}