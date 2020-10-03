using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary> 
/// <DevelopedBy>"SHEEL"</DevelopedBy>
/// <DevelopedDate>"25-8-2014"</DevelopedDate>
/// <UpdatedBy></UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
public partial class QuestionEntry : System.Web.UI.Page
{

    #region Variables

    Student_DashBoard_BLogic obj_BAL_Student_Dashboard =new Student_DashBoard_BLogic();
    QuesEntry_BLogic obj_QuesEntry_BLogic;

    #endregion

    #region "Page events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDDLBMS(ddlBMSList);
        }
        else
        {
            
        }
    }

    #endregion

    #region "Control Events"

    protected void btnQuestionReset_Click(object sender, EventArgs e)
    {
        EnableControls(true);
        ClearAllDDLList();
        QuestionEntryDiv.Visible = false;
    }
    protected void BtnCancelQues_Click(object sender, ImageClickEventArgs e)
    {
        ClearQuesEntryFields();
    }
    protected void BtnQuesSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!ValidationMethod())
        {
            return;
        }
        SaveQues();
    }
    protected void BttnCheck_Click(object sender, EventArgs e)
    {
        LblQusPrint.Text = HttpUtility.HtmlDecode(Ques.Value);

        LtrlOptionAPrint.Text = HttpUtility.HtmlDecode(TxtAnswer1.Text);
        LtrlOptionBPrint.Text = HttpUtility.HtmlDecode(TxtAnswer2.Text);
        LtrlOptionCPrint.Text = HttpUtility.HtmlDecode(TxtAnswer3.Text);
        LtrlOptionDPrint.Text = HttpUtility.HtmlDecode(TxtAnswer4.Text);

        LtrlSolPrint.Text = HttpUtility.HtmlDecode(TxtSolution.Value);   
    }
    protected void ddlBMSList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBMSList.SelectedIndex > 0)
        {
            int BMSID = Convert.ToInt32(ddlBMSList.SelectedValue);
            ddlSCTList.Enabled = true;
            FillddlSCT(ddlSCTList, BMSID);
        }
        else
        {
            DisplayCustomMessageInValidationSummary("Please Select Board, Medium, Standard, Subject.", "QuesEntry");
            ClearAllDDLList();
            //DiVQuesEntry.Visible = false;
        }
    }

    #endregion

    #region "User defined functions"

    private void FillDDLBMS(DropDownList ddl)
    {
        ddl.Items.Clear();
        obj_BAL_Student_Dashboard.get_DDLBMS(ddl);
    }
    private void FillddlSCT(DropDownList ddl,int BMSID)
    {
        ddl.Items.Clear();
        obj_BAL_Student_Dashboard.get_DDLSCT(ddl,BMSID);
    }
    private void DisplayCustomMessageInValidationSummary(string message, string ValidationGroup)
    {
        RequiredFieldValidator Validator = new RequiredFieldValidator();
        Validator.ErrorMessage = message;
        Validator.ValidationGroup = ValidationGroup;
        Validator.IsValid = false;
        Validator.Visible = false;
        this.Page.Form.Controls.Add(Validator);
    }
    public void ClearAllDDLList()
    {
        ddlBMSList.SelectedIndex = 0;
        ddlSCTList.SelectedIndex = 0;
        ddlQuesLevel.SelectedIndex = 0;
        ddlQuesTypeList.SelectedIndex = 0;
        ddlSCTList.Enabled = false;
    }
    public void EnableControls(bool value)
    {
        ddlBMSList.Enabled = value;
        ddlSCTList.Enabled = value;
        ddlQuesLevel.Enabled = value;
        ddlQuesTypeList.Enabled = value;
    }
    public void DisableControls(bool value)
    {
        ddlBMSList.Enabled = value;
        ddlSCTList.Enabled = value;
        ddlQuesLevel.Enabled = value;
        ddlQuesTypeList.Enabled = value;
    }
    public void ClearQuesEntryFields()
    {
        Ques.InnerText = "";
        TxtSolution.InnerText = "";
        TxtAnswer1.Text = "";
        TxtAnswer2.Text = "";
        TxtAnswer3.Text = "";
        TxtAnswer4.Text = "";
        RbOption1.Checked = false;
        RbOption2.Checked = false;
        RbOption3.Checked = false;
        RbOption4.Checked = false;
    }
    protected void btnQuestionSave_Click(object sender, EventArgs e)
    {
        DisableControls(false);
        QuestionEntryDiv.Visible = true;
    }
    private void SaveQues()
    {

        Int32 bmsid = Convert.ToInt32(ddlBMSList.SelectedValue);
        Int32 sctid = Convert.ToInt32(ddlSCTList.SelectedValue);
        string Question = string.Empty;
        Question = Ques.InnerText.ToString();
        Int16 op1 = 1;
        string option1 = string.Empty;
        option1 = TxtAnswer1.Text;

        Int16 op2 = 2;
        string option2 = string.Empty;
        option2 = TxtAnswer2.Text;

        Int16 op3 = 3;
        string option3 = string.Empty;
        option3 = TxtAnswer3.Text;

        Int16 op4 = 4;
        string option4 = string.Empty;
        option4 = TxtAnswer4.Text;

        Int16 copid = 0 ;
        string cans = string.Empty;
        if (RbOption1.Checked)
        {
            copid = 1;
            cans = TxtAnswer1.Text;
        }
        else if (RbOption2.Checked)
        {
            copid = 2;
            cans = TxtAnswer2.Text;
        }
        else if (RbOption3.Checked)
        {
            copid = 3;
            cans = TxtAnswer3.Text;
        }
        else if (RbOption4.Checked)
        {
            copid = 4;
            cans = TxtAnswer4.Text;
        }

        string sol = string.Empty;
        sol = TxtSolution.InnerText.ToString();

        int Qlevel = Convert.ToInt16(ddlQuesLevel.SelectedValue);

        string QType = string.Empty;
        QType = ddlQuesTypeList.SelectedValue.ToString();

        // insert Function 

        obj_QuesEntry_BLogic = new QuesEntry_BLogic();
        obj_QuesEntry_BLogic.BAL_Question_Insert(bmsid, sctid, Question, op1, option1, op2, option2, op3, option3, op4, option4,copid, cans, sol, Qlevel, QType);
        ClearQuesEntryFields();
    }
    private bool ValidationMethod()
    {
        bool status = false;

        if (Ques.InnerText.ToString().Equals("") || Ques.InnerText == "")
        {
            DisplayCustomMessageInValidationSummary("Please Enter the Question.", "QuesEntryPart");
            status = false;

        }
        else if (Ques.InnerText != "")
        {
            status = true;
        }


            if ((TxtAnswer1.Text == "" || TxtAnswer1.Text.ToString().Equals(""))
                && (TxtAnswer2.Text == "" || TxtAnswer2.Text.ToString().Equals(""))
                && (TxtAnswer3.Text == "" || TxtAnswer3.Text.ToString().Equals(""))
                && (TxtAnswer4.Text == "" || TxtAnswer4.Text.ToString().Equals("")))
            {
                DisplayCustomMessageInValidationSummary("Please Enter the Answer.", "QuesEntryPart");
                status = false;
            }
            if (RbOption1.Checked == false && RbOption2.Checked == false && RbOption3.Checked == false && RbOption4.Checked == false)
            {
                DisplayCustomMessageInValidationSummary("Please Choose the Option.", "QuesEntryPart");
                status = false;
            }
            if (RbOption1.Checked == true || RbOption2.Checked == true || RbOption3.Checked == true || RbOption4.Checked == true)
            {
                if (TxtAnswer1.Text != "" && TxtAnswer2.Text != "" && TxtAnswer3.Text != "" && TxtAnswer4.Text != "")
                {
                    status = true;
                }
            }
      
       return status;
    }

    #endregion
}