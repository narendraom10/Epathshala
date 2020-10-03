<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printadmissionform.aspx.cs"
    Inherits="Admission_printadmissionform" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="form.css" type="text/css" />
    <style type="text/css">
        body
        {
            background: #cccccc;
            width: 100% !important;
            margin: auto;
        }
        page[size="A4"]
        {
            background: white;
            width: 21cm;
            display: block;
            margin: 0 auto;
            margin-bottom: 0.5cm;
            box-shadow: 0 0 0.1cm rgba(0, 0, 0, 0.1);
        }
        @media print
        {
            body, page[size="A4"]
            {
                margin: 0;
                box-shadow: 0;
            }
        }
    </style>
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-69363607-1', 'auto');
        ga('send', 'pageview');

</script>
</head>
<body>
    <form id="printform" runat="server">

    <page size="A4">
    <div>
     <img src="AIS_Banner.png" alt="AIS Logo" style="height: 130px; width: 20.95cm; border:1px solid black;"  />
        <div style="background-color: #E0E0E0; color: #000000; border: none; padding: 10px 0px 10px 0px;width: 20.95cm;
            font-size: 18px; font-weight: bold; font-family: Open Sans,Arial; text-align: center; border-right:1px solid black;border-left:1px solid black;">
            Admission Application Form 2016-2017
        </div>
        <div style="font-size: 13px; font-weight: bold; width: 20.65cm; padding: 10px 0px 10px 0px; display: inline-block;
            height: 50px; border:1px solid black;padding-right:0.30cm;">
            <table cellpadding="0" cellspacing="0" width="35%" style="color: #000000; 
                border-collapse: collapse; float: right; ">
                <tr>
                    <td style="width: 45%; padding: 3px; border: 1px solid black;">
                        Admission Grade
                    </td>
                    <td style="width: 55%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="admissiongrade" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 45%; padding: 3px; border: 1px solid black;">
                        Form Number
                    </td>
                    <td style="width: 55%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="referencenumber" Text="" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="background-color: #E0E0E0;color: #000000; border: none; padding: 5px 5px;
            font-size: 15px; font-weight: bold; font-family: Open Sans,Arial; text-align: left;
            padding-left: 25px; border-right:1px solid black;border-left:1px solid black;">
            INSTRUCTION            
        </div>
        <div style="font-size: 13px; font-weight: bold; padding: 15px 0px 5px 0px; color: #000000; border:1px solid black;">
            <table width="100%">
                <tr>
                    <td>
                        <ul style="padding-left: 20px;">
                            <li style="list-style-type: circle;">An attested copy of the child's birth certificate
                                to be attached with the original form at the time of submission. A copy of student's
                                passport information page to be attached for non- resident Indian.</li>
                            <li style="list-style-type: circle; padding-top: 5px;">A recent passport sized photograph
                                to be attached in the box provided on the admission form.</li>
                            <li style="list-style-type: circle; padding-top: 5px;">An official copy of the student's
                                scholastic record to be attached for admissions to Grade 1 and above.</li>
                            <li style="list-style-type: circle; padding-top: 5px;">Parents’ testimonials to be
                                attached with the original form.</li>
                            <li style="list-style-type: circle; padding-top: 5px; padding-bottom: 15px;">Recommendation
                                letter from the previous school for overseas students and a bonafide certificate
                                for students applying locally.</li>
                        </ul>
                    </td>
                </tr>
            </table>
        </div>
        <div style="background-color: #E0E0E0; color: #000000; border: none; padding: 5px 5px;
            font-size: 15px; font-weight: bold; font-family: Open Sans,Arial; text-align: left;
            padding-left: 25px; border-right:1px solid black;border-left:1px solid black;">
            PERSONAL INFORMATION
        </div>
        <div style="font-size: 13px; font-weight: bold; padding: 15px 15px 15px; border:1px solid black;">
            <table cellpadding="0" cellspacing="0" width="100%" style="color: #000000; border-collapse: collapse;">
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Name of the Applicant
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="nameoftheapplicant" Text="" runat="server" />
                    </td>
                </tr>
                    <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Gender
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="gender" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Date of Birth
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="dateofbirth" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Place of birth
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="placeofbirth" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Address
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="address" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Telephone Number
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="telephonenumber" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Emergency Mobile Number
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="emergencymobilenumber" Text="" runat="server" />
                    </td>
                </tr>
            
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Nationality
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="nationality" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Passport Number
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="passportnumber" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Caste
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="caste" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Last School Attended
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="lastschoolattended" Text="" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="background-color: #E0E0E0; color: #000000; border: none; padding: 5px 5px;
            font-size: 15px; font-weight: bold; font-family: Open Sans,Arial; text-align: left;
            padding-left: 25px; border-right:1px solid black;border-left:1px solid black;">
            FATHER'S INFORMATION
        </div>
        <div style="font-size: 13px; font-weight: bold; padding: 15px 15px 15px; border:1px solid black;"">
            <table cellpadding="0" cellspacing="0" width="100%" style="color: #000000; border-collapse: collapse;">
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Father's Name
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="fathername" Text="" runat="server" />
                    </td>
                </tr>
                
               
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Graduation Degree
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="fathergraduationdegree" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Post-Graduation Degree
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="fatherpostgraduationdegree" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Occupation
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="fatheroccupation" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Office Address
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="fatherofficeaddress" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Mobile Number
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="fathermobilenumber" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Email id
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="fatheremailid" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Name of the School attended
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="fatherschoolattended" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Name of the college attended
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="fathercollegeattended" Text="" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
         <p style="page-break-after:always;"></p>
        <div style="background-color: #E0E0E0; color: #000000; border: none; padding: 5px 5px;
            font-size: 15px; font-weight: bold; font-family: Open Sans,Arial; text-align: left;
            padding-left: 25px; border-right:1px solid black;border-left:1px solid black;">
            MOTHER'S INFORMATION
        </div>
        <div style="font-size: 13px; font-weight: bold; padding: 15px 15px 15px;border:1px solid black;"">
            <table cellpadding="0" cellspacing="0" width="100%" style="color: #000000; border-collapse: collapse;">
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Mother's Name
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="mothername" Text="" runat="server" />
                    </td>
                </tr>
                
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Graduation Degree
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="mothergraduationdegree" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Post-Graduation Degree
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="motherpostgraduationdegree" Text="" runat="server" />
                    </td>
                </tr>


                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Occupation
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="motheroccupation" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Office Address
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="motherofficeaddress" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Mobile Number
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="mothermobilenumber" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Residence/Landline Number
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="residencelandlinenumber" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Email id
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="motheremailid" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Name of the School attended
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="motherschoolattended" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Name of the college attended
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="mothercollegeattended" Text="" runat="server" />
                    </td>
                </tr>
            </table>
        </div>       
        <div style="background-color: #E0E0E0; color: #000000; border: none; padding: 5px 5px;
            font-size: 15px; font-weight: bold; font-family: Open Sans,Arial; text-align: left;
            padding-left: 25px; border-right:1px solid black;border-left:1px solid black;">
            COMMUNICATION INFORMATION
        </div>
        <div style="font-size: 13px; font-weight: bold; padding: 15px 15px 15px;border:1px solid black;"">
            <table cellpadding="0" cellspacing="0" width="100%" style="color: #000000; border-collapse: collapse;">
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Mobile number for communication
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="mobilenumberforcommunication" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Email id for communication
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="emailidforcommunication" Text="" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="background-color: #E0E0E0; color: #000000; border: none; padding: 5px 5px;
            font-size: 15px; font-weight: bold; font-family: Open Sans,Arial; text-align: left;
            padding-left: 25px; border-right:1px solid black;border-left:1px solid black;">
            SIBLING INFORMATION
        </div>
        <div style="font-size: 13px; font-weight: bold; padding: 15px 15px 15px;border:1px solid black;"">
            <table cellpadding="0" cellspacing="0" width="100%" style="color: #000000; border-collapse: collapse;">
                <tr>
                    <td style="width: 25%; padding: 3px; border: 1px solid black; font-weight: bold;">
                        Name
                    </td>
                    <td style="width: 15%; padding: 2px; border: 1px solid black; font-weight: bold;">
                        Date of Birth
                    </td>
                    <td style="width: 25%; padding: 2px; border: 1px solid black; font-weight: bold;">
                        School
                    </td>
                    <td style="width: 25%; padding: 2px; border: 1px solid black; font-weight: bold;">
                        Grade
                    </td>
                    <td style="width: 10%; padding: 2px; border: 1px solid black; font-weight: bold;">
                        Division
                    </td>
                </tr>
                <tr>
                    <td style="width: 25%; padding: 3px; border: 1px solid black;">
                        <asp:Label ID="siblingname1" Text="" runat="server" />&nbsp;
                    </td>
                    <td style="width: 10%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="siblingdateofbirth1" Text="" runat="server" />
                    </td>
                    <td style="width: 25%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="siblingschool1" Text="" runat="server" />
                    </td>
                    <td style="width: 20%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="siblinggrade1" Text="" runat="server" />
                    </td>
                    <td style="width: 15%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="siblingdivision1" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 25%; padding: 3px; border: 1px solid black;">
                        <asp:Label ID="siblingname2" Text="" runat="server" />&nbsp;
                    </td>
                    <td style="width: 10%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="siblingdateofbirth2" Text="" runat="server" />
                    </td>
                    <td style="width: 25%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="siblingschool2" Text="" runat="server" />
                    </td>
                    <td style="width: 20%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="siblinggrade2" Text="" runat="server" />
                    </td>
                    <td style="width: 15%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="siblingdivision2" Text="" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="background-color: #E0E0E0; color: #000000; border: none; padding: 5px 5px;
            font-size: 15px; font-weight: bold; font-family: Open Sans,Arial; text-align: left;
            padding-left: 25px; border-right:1px solid black;border-left:1px solid black;">
            OTHER INFORMATION
        </div>
        <div style="font-size: 13px; font-weight: bold; padding: 15px 15px 15px;border:1px solid black;"">
            <table cellpadding="0" cellspacing="0" width="100%" style="color: #000000; border-collapse: collapse;">
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Mother Tongue
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="mothertongue" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Other Languages spoken at home
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="otherlanguagespokenathome" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        Family Type
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="familytype" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        How did you hear about AIS
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="howdidyouhereaboutais" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="padding: 3px; border: 1px solid black;" colspan="2">
                        What options offered by AIS are you looking at for your child?
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        At the end of Grade VII
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="optionafterseven" Text="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; padding: 3px; border: 1px solid black;">
                        At the end of Grade X
                    </td>
                    <td style="width: 70%; padding: 2px; border: 1px solid black;">
                        <asp:Label ID="optionafterten" Text="" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="background-color: #E0E0E0; color: #000000; border: none; padding: 5px 5px;
            font-size: 15px; font-weight: bold; font-family: Open Sans,Arial; text-align: left;
            padding-left: 25px; border-right:1px solid black;border-left:1px solid black;">
            DECLARATION
        </div>
        <div style="font-size: 13px; font-weight: bold; padding: 15px 15px 15px; color: #000000;border:1px solid black;"">
            <table width="100%">
                <tr>
                    <td>
                        <ul style="padding-left: 20px;">
                            <li style="list-style-type: circle;">Applicants furnishing false, incomplete, or misleading
                                information will be subjected to rejection or dismissal without refund.</li>
                            <li style="list-style-type: circle; padding-top: 5px;">Any pressure or recommendation
                                brought on the school authorities will automatically disqualify the applicant.</li>
                            <li style="list-style-type: circle; padding-top: 5px;">I declare that all information
                                provided is correct and understand that false, inaccurate or misleading information
                                could result in the student's withdrawal from school.</li>
                            <li style="list-style-type: circle; padding-top: 5px;">Please refer instruction for
                                submission of document. Please note the documents are mandatory failing which the
                                admission stands cancelled.</li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top:15px; padding-left:15px;">
                          Parent's Signature : 1. ___________________________________  2. ___________________________________
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </page>

    <div style="text-align: center;" id="dvsubmit">
        <input type="submit" value="Print Admission Form" onclick="javascript:return PrintForm();" />
    </div>
    </form>
    <script type="text/javascript">
        function PrintForm() {
            document.getElementById('dvsubmit').innerHTML = '';
            window.print();
        }
    </script>
</body>
</html>
