<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentDetail.ascx.cs"
    Inherits="Student_Report_StudentDetail" %>
<div id="banner1">
    <table id="pnlStudentDetails" runat="server" class="modalPopup RoundTop InnerTableStyle tblControls"
        cellpadding="0" cellspacing="0" width="100%" style="border: none; padding:0px; margin:0px;">
        <tr>
            <td colspan="2">
                <fieldset id="fldpersonal" runat="server">
                    <div class="Studentusercontrol">
                        <asp:Label ID="lblpe" runat="server" Text="Personal Details" Font-Bold="True" meta:resourcekey="lblpeResource1"></asp:Label>
                    </div>
                    <div>
                        <table width="100%" class="tblControls" cellpadding="1" cellspacing="1">
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblFirstName" runat="server" Text="First Name" ForeColor="#BF0000"
                                        meta:resourcekey="lblFirstNameResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name" ForeColor="#BF0000"
                                        meta:resourcekey="lblMiddleNameResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLastName" runat="server" Text="Last Name" ForeColor="#BF0000" meta:resourcekey="lblLastNameResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblName" runat="server" Text="Name:" ForeColor="#000" meta:resourcekey="lblNameResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFirstNameValue" runat="server" ForeColor="#333" meta:resourcekey="lblFirstNameValueResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblMiddleNameValue" runat="server" ForeColor="#333" meta:resourcekey="lblMiddleNameValueResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLastNameValue" runat="server" ForeColor="#333" meta:resourcekey="lblLastNameValueResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAddress" runat="server" Text="Address:" ForeColor="#000" meta:resourcekey="lblAddressResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAddressValue" runat="server" ForeColor="#333" meta:resourcekey="lblAddressValueResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDoB" runat="server" Text="DateofBirth:" ForeColor="#000" meta:resourcekey="lblDoBResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDoBValue" runat="server" ForeColor="#333" meta:resourcekey="lblDoBValueResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblGender" runat="server" Text="Gender:" ForeColor="#000" meta:resourcekey="lblGenderResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblGenderValue" runat="server" ForeColor="#333" meta:resourcekey="lblGenderValueResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblContactNo" runat="server" Text="Contact number:" ForeColor="#000"
                                        meta:resourcekey="lblContactNoResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblContactNoValue" runat="server" ForeColor="#333" meta:resourcekey="lblContactNoValueResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEmailID" runat="server" Text="Email ID:" ForeColor="#000" meta:resourcekey="lblEmailIDResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEmailIDValue" runat="server" ForeColor="#333" meta:resourcekey="lblEmailIDValueResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblBloodGrroup" runat="server" Text="Blood Group:" ForeColor="#000"
                                        meta:resourcekey="lblBloodGrroupResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblBloodGroupValue" runat="server" ForeColor="#333" meta:resourcekey="lblBloodGroupValueResource1"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
                <fieldset id="fldschool" runat="server">
                    <div class="Studentusercontrol">
                        <asp:Label ID="lblschool" runat="server" Text="School Details" Font-Bold="True" meta:resourcekey="lblschoolResource1"></asp:Label>
                    </div>
                    <div>
                        <table width="100%" class="tblControls" cellpadding="1" cellspacing="1">
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblBoard" runat="server" Text="Board" ForeColor="#BF0000" meta:resourcekey="lblBoardResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblMedium" runat="server" Text="Medium" ForeColor="#BF0000" meta:resourcekey="lblMediumResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblStandard" runat="server" Text="Standard" ForeColor="#BF0000" meta:resourcekey="lblStandardResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblBMS1" runat="server" Text="BMS:" ForeColor="#000" meta:resourcekey="lblBMS1Resource1"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="lblBMSValue1" runat="server" ForeColor="#333" meta:resourcekey="lblBMSValue1Resource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSchool1" runat="server" Text="School:" ForeColor="#000" meta:resourcekey="lblSchool1Resource1"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="lblSchoolValue1" runat="server" ForeColor="#333" meta:resourcekey="lblSchoolValue1Resource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblGrNo" runat="server" Text="GR. No:" ForeColor="#000" meta:resourcekey="lblGrNoResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblGrNoValue" runat="server" ForeColor="#333" meta:resourcekey="lblGrNoValueResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRollNo" runat="server" Text="Roll No:" ForeColor="#000" meta:resourcekey="lblRollNoResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRollNoValue" runat="server" ForeColor="#333" meta:resourcekey="lblRollNoValueResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCurrentYear" runat="server" Text="Academic Year:" ForeColor="#000"
                                        meta:resourcekey="lblCurrentYearResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCurrentYearValue" runat="server" ForeColor="#333" meta:resourcekey="lblCurrentYearValueResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDiv" runat="server" Text="Division:" ForeColor="#000" meta:resourcekey="lblDivResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDivValue" runat="server" ForeColor="#333" meta:resourcekey="lblDivValueResource1"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
            </td>
        </tr>
    </table>
</div>
