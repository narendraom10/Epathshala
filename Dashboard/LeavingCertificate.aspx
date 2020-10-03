<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeavingCertificate.aspx.cs"
    Inherits="Dashboard_LeavingCertificate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePathshala</title>
    <%-- <style type="text/css">
        table
        {
            border-collapse: collapse;
            border: 1px solid black;
        }
    </style>--%>
    <style type="text/css">
        .LabelWidth
        {
            width: 15%;
            height:33px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 15px 50px 50px 50px;">
        <div>
            <table width="100%">
                <tr style="font-size: large; font-weight: bold;">
                    <td align="center" colspan="2">
                        <asp:Label ID="lblschoolname" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lbladdress" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblcertificate" runat="server" Text="Leaving Certificate"></asp:Label>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td class="LabelWidth">
                        <asp:Label ID="lblNameLabel" runat="server" Text="Student Name:"></asp:Label>
                    </td>
                    <td style="border-bottom: 1px solid black; margin-bottom">
                        <asp:Label ID="lblname" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="LabelWidth">
                        <asp:Label ID="lblMotherNameLabel" runat="server" Text="Mother Name:"></asp:Label>
                    </td>
                    <td style="border-bottom: 1px solid black;">
                        <asp:Label ID="lblmothername" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="LabelWidth">
                        <asp:Label ID="lblCastLabel" runat="server" Text="Caste:"></asp:Label>
                    </td>
                    <td style="border-bottom: 1px solid black;">
                        <asp:Label ID="lblcaste" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="LabelWidth">
                        <asp:Label ID="lblPlaceOfBirthLabel" runat="server" Text="Place of Birth:"></asp:Label>
                    </td>
                    <td style="border-bottom: 1px solid black;">
                        <asp:Label ID="lbldateofbirth" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="LabelWidth">
                        <asp:Label ID="lblLastSchoolLabel" runat="server" Text="Last School Attend:"></asp:Label>
                    </td>
                    <td style="border-bottom: 1px solid black;" s>
                        <asp:Label ID="lbllastschool" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="LabelWidth">
                        <asp:Label ID="lbldateofadmissionLabel" runat="server" Text="Date of Admission:"></asp:Label>
                    </td>
                    <td style="border-bottom: 1px solid black;">
                        <asp:Label ID="lbldateofadmission" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="LabelWidth">
                        <asp:Label ID="lblProgressLabel" runat="server" Text="Progress:"></asp:Label>
                    </td>
                    <td style="border-bottom: 1px solid black;">
                        <asp:Label ID="lblprogress" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="LabelWidth">
                        <asp:Label ID="lblDOLLabel" runat="server" Text="Date of Leaving:"></asp:Label>
                    </td>
                    <td style="border-bottom: 1px solid black;">
                        <asp:Label ID="lbldateofleaving" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="LabelWidth">
                        <asp:Label ID="lblReasonForLeaving" runat="server" Text="Reason For Leaving:"></asp:Label>
                    </td>
                    <td style="border-bottom: 1px solid black;">
                        <asp:Label ID="lblRFL" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="LabelWidth">
                        <asp:Label ID="currentStandard" runat="server" Text="Standard in which studying:"></asp:Label>
                    </td>
                    <td style="border-bottom: 1px solid black;">
                        <asp:Label ID="lblCurrentStandard" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div style="padding-top: 50px;">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lbldate" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblsignature" runat="server" Text="Signature"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
