using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.IO;

public partial class Admission_AddAdmission : System.Web.UI.Page
{
    #region "Declaration"

    Admission_BLogic oAdmission_BLogic;
    Admission oAdmission;
    string IFormat = "dd-MMM-yyyy";
    static DataTable Dt_SibligData = new DataTable();
    #endregion

    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            BindDocumentList();
            BindAdmissionGrageDropDown();
        }

    }

    #endregion

    #region Control Event

    /// <summary>
    /// Submit Data in Admission Table, Sibling Table, and Attached Document Table.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        oAdmission_BLogic = new Admission_BLogic();
        oAdmission = new Admission();
        
        oAdmission.FormNo = (!string.IsNullOrEmpty(TxtFormNo.Text)) ? TxtFormNo.Text.Trim() : null;
        oAdmission.AdmissionGrade = DdlAdmissionGrade.SelectedValue;
        oAdmission.FirstName = TxtFirstName.Text.Trim();
        oAdmission.MiddleName = TxtMiddleName.Text.Trim();
        oAdmission.LastName = TxtLastName.Text.Trim();
        oAdmission.MailingAddress = (!string.IsNullOrEmpty(TxtMailingAddress.Text)) ? TxtMailingAddress.Text.Trim() : null;

        if (Fu_PassportImage.HasFile)
        {
            //getting length of uploaded file
            int length = Fu_PassportImage.PostedFile.ContentLength;
            //create a byte array to store the binary image data
            byte[] imgbyte = new byte[length];
            //store the currently selected file in memeory
            HttpPostedFile img = Fu_PassportImage.PostedFile;
            //set the binary data
            img.InputStream.Read(imgbyte, 0, length);
            oAdmission.Photo = imgbyte;
        }

        oAdmission.TelephoneNo = (!string.IsNullOrEmpty(TxtTelephoneNo.Text)) ? TxtTelephoneNo.Text.Trim() : null;
        oAdmission.EmergencyMobileNo = (!string.IsNullOrEmpty(TxtMobileNo.Text)) ? TxtMobileNo.Text.Trim() : null;
        oAdmission.CommunicationEmailId = (!string.IsNullOrEmpty(TxtCommunicationMail.Text)) ? TxtCommunicationMail.Text.Trim() : null;
        oAdmission.Gender = RlstGender.SelectedValue;

        DateTime dt;
        if (DateTime.TryParse(TxtDateOfBirth.Text, out dt))
        {
            oAdmission.DateOfBirth = dt.ToString(IFormat);
        }

        oAdmission.PlaceOfBirth = (!string.IsNullOrEmpty(TxtPlaceOfBirth.Text)) ? TxtPlaceOfBirth.Text.Trim() : null;
        oAdmission.Nationality = (!string.IsNullOrEmpty(TxtNationality.Text)) ? TxtNationality.Text.Trim() : null;
        oAdmission.Religion = (!string.IsNullOrEmpty(TxtReligion.Text)) ? TxtReligion.Text.Trim() : null;
        oAdmission.Caste = (!string.IsNullOrEmpty(TxtCaste.Text)) ? TxtCaste.Text.Trim() : null;
        oAdmission.SubCaste = (!string.IsNullOrEmpty(TxtSubCaste.Text)) ? TxtSubCaste.Text.Trim() : null;
        oAdmission.LastSchoolAttended = (!string.IsNullOrEmpty(TxtLastSchoolAttended.Text)) ? TxtLastSchoolAttended.Text.Trim() : null;
        oAdmission.FatherName = (!string.IsNullOrEmpty(TxtFatherName.Text)) ? TxtFatherName.Text.Trim() : null;
        oAdmission.FatherEducation = (!string.IsNullOrEmpty(TxtFatherEducation.Text)) ? TxtFatherEducation.Text.Trim() : null;
        oAdmission.FatherOccupation = (!string.IsNullOrEmpty(TxtFatherOccupation.Text)) ? TxtFatherOccupation.Text.Trim() : null;
        oAdmission.FatherOfficeAddress = (!string.IsNullOrEmpty(TxtFatherOfficeAddress.Text)) ? TxtFatherOfficeAddress.Text.Trim() : null;
        oAdmission.FatherTelephoneNo = (!string.IsNullOrEmpty(TxtFatherTelephoneNo.Text)) ? TxtFatherTelephoneNo.Text.Trim() : null;
        oAdmission.FatherMobileNo = (!string.IsNullOrEmpty(TxtFatherMobileNo.Text)) ? TxtFatherMobileNo.Text.Trim() : null;
        oAdmission.FatherEmailId = (!string.IsNullOrEmpty(TxtFatherEmailId.Text)) ? TxtFatherEmailId.Text.Trim() : null;
        oAdmission.MotherName = (!string.IsNullOrEmpty(TxtMotherName.Text)) ? TxtMotherName.Text.Trim() : null;
        oAdmission.MotherEducation = (!string.IsNullOrEmpty(TxtMotherEducation.Text)) ? TxtMotherEducation.Text.Trim() : null;
        oAdmission.MotherOccupation = (!string.IsNullOrEmpty(TxtMotherOccupation.Text)) ? TxtMotherOccupation.Text.Trim() : null;
        oAdmission.MotherOfficeAddress = (!string.IsNullOrEmpty(TxtMotherOfficeAddress.Text)) ? TxtMotherOfficeAddress.Text.Trim() : null;
        oAdmission.MotherTelephoneNo = (!string.IsNullOrEmpty(TxtMotherTelephoneNo.Text)) ? TxtMotherTelephoneNo.Text.Trim() : null;
        oAdmission.MotherMobileNo = (!string.IsNullOrEmpty(TxtMotherMobileNo.Text)) ? TxtMotherMobileNo.Text.Trim() : null;
        oAdmission.MotherEmailId = (!string.IsNullOrEmpty(TxtMotherEmailId.Text)) ? TxtMotherEmailId.Text.Trim() : null;
        oAdmission.MotherTongue = (!string.IsNullOrEmpty(TxtMotherTongue.Text)) ? TxtMotherTongue.Text.Trim() : null;
        oAdmission.OtherLanguages = (!string.IsNullOrEmpty(TxtOtherLanguages.Text)) ? TxtOtherLanguages.Text.Trim() : null;
        oAdmission.IsNuclearorJointFamily = (!string.IsNullOrEmpty(TxtIsNuclearorJointFamily.Text)) ? TxtIsNuclearorJointFamily.Text.Trim() : null;
        oAdmission.HowDoYouHearAboutAIS = (!string.IsNullOrEmpty(TxtHowdoyouhearAboutAIS.Text)) ? TxtHowdoyouhearAboutAIS.Text.Trim() : null;
        oAdmission.CreatedBy = Convert.ToString(AppSessions.EmpolyeeID);
        oAdmission.SchoolId = Convert.ToString(AppSessions.SchoolID);

        bool IsInsert = oAdmission_BLogic.Admission_Insert(oAdmission);

        if (IsInsert)
        {
            // For Creating a multi insert statement string of sibling details

            DataSet tempDsAdmissionId = oAdmission_BLogic.GetLastAdmissionId();
            string LastAdmissionid = string.Empty;
            string InsertString; System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (tempDsAdmissionId != null && tempDsAdmissionId.Tables.Count > 0 && tempDsAdmissionId.Tables[0].Rows.Count > 0)
            {
                LastAdmissionid = tempDsAdmissionId.Tables[0].Rows[0][0].ToString();
            }

            if (GvSibling.Rows.Count > 0)
            {
                sb = new System.Text.StringBuilder();

                foreach (GridViewRow gvr in GvSibling.Rows)
                {
                    Label gvLblSiblingName = (Label)gvr.FindControl("LblSiblingName");
                    Label gvLblSiblingAge = (Label)gvr.FindControl("LblSiblingAge");
                    Label gvLblSiblingGender = (Label)gvr.FindControl("LblSiblingGender");
                    Label gvLblSiblingSchool = (Label)gvr.FindControl("LblSiblingLastSchool");
                    Label gvLblSiblingClass = (Label)gvr.FindControl("LblSiblingClass");

                    sb.Append("(" + LastAdmissionid + ",'" + gvLblSiblingName.Text + "'," + gvLblSiblingAge.Text + ",'" + gvLblSiblingGender.Text + "','" + gvLblSiblingSchool.Text + "','" + gvLblSiblingClass.Text + "'),");
                }

                InsertString = sb.ToString().Remove(sb.ToString().Length - 1, 1);
                oAdmission_BLogic.Admission_Sibling_Insert(InsertString);

                Dt_SibligData.Clear();
                GvSibling.DataSource = null; GvSibling.DataBind();
                sb.Clear(); InsertString = string.Empty;
            }



            if (ChklstAttachmentList.Items.Count > 0)
            {

                foreach (ListItem cbItem in ChklstAttachmentList.Items)
                {
                    if (cbItem.Selected)
                    {
                        sb.Append("(" + LastAdmissionid + "," + cbItem.Value + "),");
                    }
                }
                if (sb.ToString().Length > 0)
                {
                    InsertString = sb.ToString().Remove(sb.ToString().Length - 1, 1);
                    oAdmission_BLogic.Admission_Documents_Insert(InsertString);
                }
            }

            WebMsg.Show("Admission has been created successfully.");
            ResetControl();
        }
        else
        {
            WebMsg.Show("Admission has been created failed.");
        }

    }

    /// <summary>
    /// Reset All Control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ResetControl();

    }

    /// <summary>
    /// Add (Temporary) Sibling Record to Grid view.
    /// </summary>
    /// <param name="sender">Sender object who has initiated the request.</param>
    /// <param name="e">Argument of the event.</param>
    protected void BtnAddNewSibling_Click(object sender, EventArgs e)
    {

        if (Dt_SibligData.Columns.Count == 0)
        {
            Dt_SibligData.Columns.Add("SiblingId", typeof(string));
            Dt_SibligData.Columns.Add("SiblingName", typeof(string));
            Dt_SibligData.Columns.Add("SiblingAge", typeof(string));
            Dt_SibligData.Columns.Add("SiblingGender", typeof(string));
            Dt_SibligData.Columns.Add("SiblingSchool", typeof(string));
            Dt_SibligData.Columns.Add("SiblingClass", typeof(string));
        }


        DataRow dr = Dt_SibligData.NewRow();
        dr["SiblingId"] = Dt_SibligData.Rows.Count + 1;
        dr["SiblingName"] = TxtAddSiblingName.Text;
        dr["SiblingAge"] = txtAddSiblingAge.Text;
        if (RblstAddSiblingGender.SelectedIndex != -1) { dr["SiblingGender"] = RblstAddSiblingGender.SelectedItem.Value; } else { dr["SiblingGender"] = ""; }
        dr["SiblingSchool"] = TxtAddSiblingSchool.Text;
        dr["SiblingClass"] = TxtAddSiblingClass.Text;
        Dt_SibligData.Rows.Add(dr);

        GvSibling.DataSource = Dt_SibligData;
        GvSibling.DataBind();

        TxtAddSiblingName.Text = string.Empty;
        txtAddSiblingAge.Text = string.Empty;
        TxtAddSiblingSchool.Text = string.Empty;
        TxtAddSiblingClass.Text = string.Empty;
        RblstAddSiblingGender.SelectedIndex = -1;
        TxtAddSiblingName.Focus();

    }

    /// <summary>
    /// Deletes perticular row from SIBLING GRID VIEW.
    /// </summary>
    /// <param name="sender">sender who has invoked methos.</param>
    /// <param name="e">Argument of Event.</param>
    protected void GvSibling_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        Label Srno = (Label)GvSibling.Rows[e.RowIndex].FindControl("LblSiblingid");
        if (Srno != null)
        {
            foreach (DataRow drow in Dt_SibligData.Rows)
            {
                if (drow["SiblingId"].ToString() == Srno.Text)
                {
                    drow.Delete();
                    break;
                }
            }
            GvSibling.DataSource = Dt_SibligData;
            GvSibling.DataBind();
        }

    }
    #endregion

    #region UserDefine method

    /// <summary>
    /// Reset All Control in this form
    /// </summary>
    private void ResetControl()
    {
        TxtFormNo.Text = string.Empty;
        //
        TxtFirstName.Text = string.Empty;
        TxtMiddleName.Text = string.Empty;
        TxtLastName.Text = string.Empty;
        TxtMailingAddress.Text = string.Empty;
        //
        TxtTelephoneNo.Text = string.Empty;
        TxtCommunicationMail.Text = string.Empty;
        TxtMobileNo.Text = string.Empty;
        RlstGender.SelectedValue = string.Empty;
        //
        TxtPlaceOfBirth.Text = string.Empty;
        TxtNationality.Text = string.Empty;
        TxtReligion.Text = string.Empty;
        TxtCaste.Text = string.Empty;
        TxtSubCaste.Text = string.Empty;
        TxtLastSchoolAttended.Text = string.Empty;
        TxtFatherName.Text = string.Empty;
        TxtFatherEducation.Text = string.Empty;
        TxtFatherOccupation.Text = string.Empty;
        TxtFatherOfficeAddress.Text = string.Empty;
        TxtFatherTelephoneNo.Text = string.Empty;
        TxtFatherMobileNo.Text = string.Empty;
        TxtFatherEmailId.Text = string.Empty;
        TxtMotherName.Text = string.Empty;
        TxtMotherEducation.Text = string.Empty;
        TxtMotherOccupation.Text = string.Empty;
        TxtMotherOfficeAddress.Text = string.Empty;
        TxtMotherTelephoneNo.Text = string.Empty;
        TxtMotherMobileNo.Text = string.Empty;
        TxtMotherEmailId.Text = string.Empty;
        TxtMotherTongue.Text = string.Empty;
        TxtOtherLanguages.Text = string.Empty;
        TxtIsNuclearorJointFamily.Text = string.Empty;
        TxtHowdoyouhearAboutAIS.Text = string.Empty;
        DdlAdmissionGrade.SelectedIndex = -1;
        TabCon_Admission.ActiveTabIndex = 0;
        ChklstAttachmentList.SelectedIndex = -1;
    }

    /// <summary>
    /// Bind Admission Grade dropdown with BMS assigned to school
    /// </summary>
    private void BindAdmissionGrageDropDown()
    {
        DropDownFill DdlFilling = new DropDownFill();
        SYS_BMS_BLogic SYS_BMSBLogic = new SYS_BMS_BLogic();
        DataSet dsselectBMS = new DataSet();
        dsselectBMS = SYS_BMSBLogic.BAL_SYS_BMS_SelectAllBySchoolID(AppSessions.SchoolID);
        if (dsselectBMS.Tables.Count > ((int)EnumFile.AssignValue.Zero))
        {
            DdlFilling.BindDropDownByTable(DdlAdmissionGrade, dsselectBMS.Tables[0], "BMS", "BMSID");
        }
        else
        {
            DdlFilling.ClearDropDownListRef(DdlAdmissionGrade);
        }
    }

    /// <summary>
    /// Binds Document Master Documents list
    /// </summary>
    private void BindDocumentList()
    {
        DataAccess da = new DataAccess();
        DataTable dtAttachmentds = new DataTable();
        dtAttachmentds = da.GetDataTable("select * from AdmissionDocumentMaster");
        if (dtAttachmentds != null && dtAttachmentds.Rows.Count > 0)
        {
            ChklstAttachmentList.DataSource = dtAttachmentds;
            ChklstAttachmentList.DataTextField = "DisplayName";
            ChklstAttachmentList.DataValueField = "MasterDocumentId";

        }
        else
        {
            ChklstAttachmentList.DataSource = null;
        }
        ChklstAttachmentList.DataBind();

    }
    #endregion
  
}