using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Admission_printadmissionform : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["mb"]) && !string.IsNullOrEmpty(Request.QueryString["rn"]))
        {
            BAL_Admission oBAL_Admission = new BAL_Admission();
            DataSet ods = new DataSet();
            ods = oBAL_Admission.Admission_getadmissiondetail_byreferenceno(Convert.ToString(Request.QueryString["rn"]), Convert.ToString(Request.QueryString["mb"]));
            if (ods.Tables[0].Rows.Count > 0)
            {
                admissiongrade.Text = Convert.ToString(ods.Tables[0].Rows[0]["AdmissionGrade"]);
                referencenumber.Text = Convert.ToString(ods.Tables[0].Rows[0]["ReferenceNumber"]);
                nameoftheapplicant.Text = Convert.ToString(ods.Tables[0].Rows[0]["FirstName"]) + ' ' + Convert.ToString(ods.Tables[0].Rows[0]["LastName"]);

                StringBuilder oAddressBuilder = new StringBuilder();
                oAddressBuilder.Append(Convert.ToString(ods.Tables[0].Rows[0]["Addressline1"]));
                if (!string.IsNullOrEmpty(Convert.ToString(ods.Tables[0].Rows[0]["Addressline2"])))
                {
                    oAddressBuilder.Append(", ");
                    oAddressBuilder.Append(Convert.ToString(ods.Tables[0].Rows[0]["Addressline2"]));
                }
                oAddressBuilder.Append(", ");
                oAddressBuilder.Append(Convert.ToString(ods.Tables[0].Rows[0]["City"]));

                oAddressBuilder.Append(", ");
                oAddressBuilder.Append(Convert.ToString(ods.Tables[0].Rows[0]["State"]));

                oAddressBuilder.Append(", ");
                oAddressBuilder.Append(Convert.ToString(ods.Tables[0].Rows[0]["Country"]));

                address.Text = Convert.ToString(oAddressBuilder);

                telephonenumber.Text = Convert.ToString(ods.Tables[0].Rows[0]["TelephoneNo"]);
                emergencymobilenumber.Text = Convert.ToString(ods.Tables[0].Rows[0]["EmergencyMobileNo"]);
                gender.Text = Convert.ToString(ods.Tables[0].Rows[0]["Gender"]);
                dateofbirth.Text = Convert.ToString(ods.Tables[0].Rows[0]["DateOfBirth"]);
                placeofbirth.Text = Convert.ToString(ods.Tables[0].Rows[0]["PlaceOfBirth"]);

                if (Convert.ToString(ods.Tables[0].Rows[0]["Nationality"]) == "Other")
                    nationality.Text = Convert.ToString(ods.Tables[0].Rows[0]["OtherNationality"]);
                else
                    nationality.Text = Convert.ToString(ods.Tables[0].Rows[0]["Nationality"]);


                passportnumber.Text = Convert.ToString(ods.Tables[0].Rows[0]["PassportNumber"]);
                caste.Text = Convert.ToString(ods.Tables[0].Rows[0]["Caste"]);

                if (Convert.ToString(ods.Tables[0].Rows[0]["LastSchoolAttended"]) == "Other")
                    lastschoolattended.Text = Convert.ToString(ods.Tables[0].Rows[0]["OtherLastSchoolAttended"]);
                else
                    lastschoolattended.Text = Convert.ToString(ods.Tables[0].Rows[0]["LastSchoolAttended"]);

                fathername.Text = Convert.ToString(ods.Tables[0].Rows[0]["FatherName"]);
                fathergraduationdegree.Text = Convert.ToString(ods.Tables[0].Rows[0]["FatherGraduationdegree"]);
                fatherpostgraduationdegree.Text = Convert.ToString(ods.Tables[0].Rows[0]["FatherPostGraduationDegree"]);
                fatheroccupation.Text = Convert.ToString(ods.Tables[0].Rows[0]["FatherOccupation"]);
                fatherofficeaddress.Text = Convert.ToString(ods.Tables[0].Rows[0]["FatherOfficeAddress"]);
                fathermobilenumber.Text = Convert.ToString(ods.Tables[0].Rows[0]["FatherMobileNumber"]);
                fatheremailid.Text = Convert.ToString(ods.Tables[0].Rows[0]["FatherEmailId"]);
                fatherschoolattended.Text = Convert.ToString(ods.Tables[0].Rows[0]["FatherSchoolAttended"]);
                fathercollegeattended.Text = Convert.ToString(ods.Tables[0].Rows[0]["FatherCollegeAttended"]);

                mothername.Text = Convert.ToString(ods.Tables[0].Rows[0]["MotherName"]);
                mothergraduationdegree.Text = Convert.ToString(ods.Tables[0].Rows[0]["MotherGraduationdegree"]);
                motherpostgraduationdegree.Text = Convert.ToString(ods.Tables[0].Rows[0]["MotherPostGraduationDegree"]);
                motheroccupation.Text = Convert.ToString(ods.Tables[0].Rows[0]["MotherOccupation"]);
                motherofficeaddress.Text = Convert.ToString(ods.Tables[0].Rows[0]["MotherOfficeAddress"]);
                mothermobilenumber.Text = Convert.ToString(ods.Tables[0].Rows[0]["MotherMobileNumber"]);
                residencelandlinenumber.Text = Convert.ToString(ods.Tables[0].Rows[0]["ResidenceOrLandlineNumber"]);
                motheremailid.Text = Convert.ToString(ods.Tables[0].Rows[0]["MotherEmailId"]);
                motherschoolattended.Text = Convert.ToString(ods.Tables[0].Rows[0]["MotherSchoolAttended"]);
                mothercollegeattended.Text = Convert.ToString(ods.Tables[0].Rows[0]["MotherCollegeAttended"]);

                mobilenumberforcommunication.Text = Convert.ToString(ods.Tables[0].Rows[0]["MobileNumberForCommunication"]);
                emailidforcommunication.Text = Convert.ToString(ods.Tables[0].Rows[0]["EmailIdForCommunication"]);

                siblingname1.Text = Convert.ToString(ods.Tables[0].Rows[0]["Siblingname"]);
                siblingdateofbirth1.Text = Convert.ToString(ods.Tables[0].Rows[0]["Siblingage"]);
                siblingschool1.Text = Convert.ToString(ods.Tables[0].Rows[0]["Siblingschoolcollege"]);
                siblinggrade1.Text = Convert.ToString(ods.Tables[0].Rows[0]["Siblingschoolcollegegrade"]);
                siblingdivision1.Text = Convert.ToString(ods.Tables[0].Rows[0]["Siblingschoolcollegedivision"]);

                siblingname2.Text = Convert.ToString(ods.Tables[0].Rows[0]["Siblingnamesecond"]);
                siblingdateofbirth2.Text = Convert.ToString(ods.Tables[0].Rows[0]["Siblingagesecond"]);
                siblingschool2.Text = Convert.ToString(ods.Tables[0].Rows[0]["Siblingschoolcollegesecond"]);
                siblinggrade2.Text = Convert.ToString(ods.Tables[0].Rows[0]["Siblingschoolcollegegradesecond"]);
                siblingdivision2.Text = Convert.ToString(ods.Tables[0].Rows[0]["Siblingschoolcollegedivisionsecond"]);

                mothertongue.Text = Convert.ToString(ods.Tables[0].Rows[0]["MotherTongue"]);
                otherlanguagespokenathome.Text = Convert.ToString(ods.Tables[0].Rows[0]["OtherLanguagesSpokenAtHome"]);
                familytype.Text = Convert.ToString(ods.Tables[0].Rows[0]["IsNuclearOrJointFamily"]);
                howdidyouhereaboutais.Text = Convert.ToString(ods.Tables[0].Rows[0]["HowDoYouHearAboutAIS"]);
                optionafterseven.Text = Convert.ToString(ods.Tables[0].Rows[0]["OptionOfferedByAISafterGradeVII"]);
                optionafterten.Text = Convert.ToString(ods.Tables[0].Rows[0]["OptionOfferedByAISafterGradeX"]);
            }
        }
    }
}