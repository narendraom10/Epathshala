<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuControl.ascx.cs" Inherits="MenuControl" %>
<script type="text/javascript">
    window.onload = function () {
        var winURL = window.location.href; // Will Fetch the url.
        var queryStringArray = winURL.split("/"); // Will Split the url.
        var count = (queryStringArray.length - 1); // Will fetch the last index of splited array.
        var queryStringParamArray = queryStringArray[count]; // Will store the last element of the array in string.
        //debugger;
        // Compare the last element and change the css class of relevant control.
        //        if (queryStringParamArray == "TeacherDashboard.aspx") {
        //            document.getElementById("ctl00_Menu1_liTeacherDashboard").className = "menuSelected Round";
        //            document.getElementById("ctl00_Menu1_lblTeacherDashboard").className = "menuSelectedColor";
        //        }
        //        else if (queryStringParamArray == "UserList.aspx") {
        //            //            document.getElementById("ctl00_Menu1_liStudentList").className = "menuSelected Round";
        //            //            document.getElementById("ctl00_Menu1_lblTeacherStdList").className = "menuSelectedColor";
        //            document.getElementById("ctl00_Menu1_liSchoolAdminUserList").className = "menuSelected Round";
        //            document.getElementById("ctl00_Menu1_lblsadminUserList").className = "menuSelectedColor";
        //        }
        //        else if (queryStringParamArray == "ReschedulingChapterTopic.aspx") {
        //            document.getElementById("ctl00_Menu1_liReschedulingChapterTopic").className = "menuSelected Round";
        //            document.getElementById("ctl00_Menu1_lblReschedulingChpTopic").className = "menuSelectedColor";
        //        }
        //        else if (queryStringParamArray == "TeacherNotes.aspx") {
        //            document.getElementById("ctl00_Menu1_liTeacherNotes").className = "menuSelected Round";
        //            document.getElementById("ctl00_Menu1_lblTeacherNotes").className = "menuSelectedColor";
        //        }
        //        else if (queryStringParamArray == "SchoolAdminDashboard.aspx") {
        //            document.getElementById("ctl00_Menu1_liSchooladminDashBoard").className = "menuSelected Round";
        //            document.getElementById("ctl00_Menu1_lblSadminDashboard").className = "menuSelectedColor";
        //        }
        //        else if (queryStringParamArray == "ViewSchoolProfile.aspx") {
        //            document.getElementById("ctl00_Menu1_liViewSchoolProfile").className = "menuSelected Round";
        //            document.getElementById("ctl00_Menu1_lblSchoolProfile").className = "menuSelectedColor";
        //        }
        //        else if (queryStringParamArray == "EmployeeRegistration.aspx") {
        //            document.getElementById("ctl00_Menu1_liEmployeeRegistration").className = "menuSelected Round";
        //            document.getElementById("ctl00_Menu1_lblEmpEnroll").className = "menuSelectedColor";
        //        }
        //        else if (queryStringParamArray == "TeacherClassAllocation.aspx") {
        //            document.getElementById("ctl00_Menu1_liTeacherClassAllocation").className = "menuSelected Round";
        //            document.getElementById("ctl00_Menu1_lblSadminStdAllocation").className = "menuSelectedColor";
        //        }
        //        else if (queryStringParamArray == "StudentAttendance.aspx") {
        //            document.getElementById("ctl00_Menu1_liStudentAttendance").className = "menuSelected Round";
        //            document.getElementById("ctl00_Menu1_lblStudentAttendance").className = "menuSelectedColor";
        //        }
        //        else if (queryStringParamArray == "UserLogInOut.aspx") {
        //            document.getElementById("ctl00_Menu1_liUserLogInOut").className = "menuSelected Round";
        //            document.getElementById("ctl00_Menu1_lblSadminSessionOut").className = "menuSelectedColor";
        //        }
        //        else if (queryStringParamArray == "StudentDashboard.aspx") {
        //            document.getElementById("ctl00_Menu1_liStudDashboard").className = "menuSelected Round";
        //            document.getElementById("ctl00_Menu1_lblStudDashboard").className = "menuSelectedColor";
        //        }
        //        else if (queryStringParamArray == "ReschedulingChapterTopicStudent.aspx") {
        //            document.getElementById("ctl00_Menu1_liStudentRescheduling").className = "menuSelected Round";
        //            document.getElementById("ctl00_Menu1_lblStudentRescheduling").className = "menuSelectedColor";
        //        }
        //        else if (queryStringParamArray == "StudentProfile.aspx") {
        //            document.getElementById("ctl00_Menu1_liProfile").className = "menuSelected Round";
        //            document.getElementById("ctl00_Menu1_liProfile").className = "menuSelectedColor";
        //        }
    }

    //    $(document).load(function () {
    //        alert('Hi');
    //    });

</script>
<script type="text/javascript">
    //    $(function () {
    //        //////           $(document).tooltip( "option", "hide", { effect: "explode", duration: 1000 } );
    //        $(document).tooltip("option", "show", { effect: "blind", duration: 2000 });

    //        //            $(document).tooltip({ track: true });

    //        ////         
    //    });
</script>
<asp:MultiView ID="MenuCtrl" runat="server">
    <asp:View ID="ViewEAdmin" runat="server">
        <ul id="qm0" class="qmmc11">
            <li id="liEpathDashboard" runat="server" style="border-right: 1px solid #000000;"><a
                href="../Dashboard/EpathAdminDashboard.aspx">
                <asp:Label ID="lblEAdminDashBoard" runat="server" Text="DashBoard" meta:resourceKey="lblEAdminDashBoard"></asp:Label>
            </a></li>
            <li id="liManageSchool" runat="server" style="border-right: 1px solid #000000;"><a
                href="#">
                <asp:Label ID="LblManageSchool" runat="server" Text="Manage School"></asp:Label></a>
                <ul class="roundMenuItem">
                    <li><a href="../SchoolManagement/SchoolList.aspx" target="_self">
                        <asp:Label ID="lblEadminSchoolList" runat="server" meta:resourceKey="lblEadminSchoolListlnk"
                            Text="School List"></asp:Label>
                    </a></li>
                    <li><a href="../Registration/SchoolRegistration.aspx" target="_self">
                        <asp:Label ID="lblSchoolRegistration" runat="server" Text="School Registration" meta:resourceKey="lblSchoolRegistration"></asp:Label></a></li>
                    <li><a href="../Admin/StandardAllocation.aspx" target="_self">
                        <asp:Label ID="lblStandardAllocation" runat="server" Text="Standard Allocation" meta:resourceKey="lblStandardAllocation"></asp:Label></a></li>
                </ul>
            </li>
            <li id="liManageUsers" runat="server" style="border-right: 1px solid #000000;"><a
                href="#">
                <asp:Label ID="lblManageUsers" runat="server" Text="Manage Users" meta:resourceKey="lblManageUsers"></asp:Label></a>
                <ul class="roundMenuItem">
                    <li><a href="../UserManagement/UserList_New.aspx" target="_self">
                        <asp:Label ID="lblEadminUserList" runat="server" meta:resourceKey="lblEadminUserListResource1"
                            Text="User List"></asp:Label>
                    </a></li>
                    <li><a href="../UserManagement/UserLogInOut.aspx" target="_self">
                        <asp:Label ID="lblEadminLogoutUser" runat="server" meta:resourceKey="lblEadminLogoutUserResource1"
                            Text="Logout user session"></asp:Label>
                    </a></li>
                    <li><a href="../Admin/TeacherClassAllocation.aspx" target="_self">
                        <asp:Label ID="lblClassAllo" runat="server" Text="Standard Allocation"></asp:Label>
                    </a></li>
                    <%-- <li id="lilsubjectallocation" runat="server" style="border-right: 1px solid #000000;">
                            <a href="../Registration/SchoolRegistration.aspx" target="_self">
                                <asp:Label ID="lblsubjectallocation" runat="server" Text="Subject Allocation" meta:resourceKey="lblsubjectallocation"></asp:Label>
                            </a></li>--%>
                </ul>
            </li>
            <li id="liManageMaster" runat="server" style="border-right: 1px solid #000000;"><a
                href="#">
                <asp:Label ID="lblMastersManage" runat="server" Text="Manage Masters" meta:resourceKey="lblMastersManage"></asp:Label>
            </a>
                <ul class="roundMenuItem" style="width: 500px;">
                    <li style="float: left; width: 250px; position: relative;"><a href="../Admin/Board.aspx"
                        target="_self">
                        <asp:Label ID="lblBoardManage" runat="server" meta:resourceKey="lblBoardManage" Text="Manage Board"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 250px; position: relative;"><a href="../Admin/Medium.aspx"
                        target="_self">
                        <asp:Label ID="lblMediumManage" runat="server" meta:resourceKey="lblMediumManage"
                            Text="Manage Medium"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 250px; position: relative;"><a href="../Admin/Standard.aspx"
                        target="_self">
                        <asp:Label ID="lblStandardManage" runat="server" meta:resourceKey="lblStandardManage"
                            Text="Manage Standard"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 250px; position: relative;"><a href="../Admin/BMS.aspx"
                        target="_self">
                        <asp:Label ID="lblBMSManage" runat="server" meta:resourceKey="lblBMSManage" Text="Manage BMS"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 250px; position: relative;"><a href="../Admin/Division.aspx"
                        target="_self">
                        <asp:Label ID="lblDivisionManage" runat="server" meta:resourceKey="lblDivisionManage"
                            Text="Manage Division"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 250px; position: relative;"><a href="../Admin/Subject.aspx"
                        target="_self">
                        <asp:Label ID="lblSubjectManage" runat="server" meta:resourceKey="lblSubjectManage"
                            Text="Manage Subject"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 250px; position: relative;"><a href="../Admin/Chapter.aspx"
                        target="_self">
                        <asp:Label ID="lblChapterManage" runat="server" meta:resourceKey="lblChapterManage"
                            Text="Manage Chapter"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 250px; position: relative;"><a href="../Admin/Topic.aspx"
                        target="_self">
                        <asp:Label ID="lblTopicManage" runat="server" meta:resourceKey="lblTopicManage" Text="Manage Topic"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 250px; position: relative;"><a href="../Admin/District.aspx"
                        target="_self">
                        <asp:Label ID="lblDistrictManage" runat="server" meta:resourceKey="lblDistrictManage"
                            Text="Manage District"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 250px; position: relative;"><a href="../Admin/State.aspx"
                        target="_self">
                        <asp:Label ID="lblStateManage" runat="server" meta:resourceKey="lblStateManage" Text="Manage State"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 250px; position: relative;"><a href="../Admin/Country.aspx"
                        target="_self">
                        <asp:Label ID="lblCountryManage" runat="server" meta:resourceKey="lblCountryManage"
                            Text="Manage Country"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 250px; position: relative;"><a href="../Admin/Role.aspx"
                        target="_self">
                        <asp:Label ID="lblRoleManage" runat="server" meta:resourceKey="lblRoleManage" Text="Manage Role"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 250px; position: relative;"><a href="../Admin/SchoolType.aspx"
                        target="_self">
                        <asp:Label ID="lblSchoolTypeManage" runat="server" meta:resourceKey="lblSchoolTypeManage"
                            Text="Manage SchoolType"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 250px; position: relative;"><a href="../Report/QuestionEntry.aspx"
                        target="_self">
                        <asp:Label ID="Label19" runat="server" meta:resourceKey="lblFeedbackQuestionnaire1"
                            Text="Question Entry"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 250px; position: relative;"><a href="../Admin/FeedbackQuestionnaire.aspx"
                        target="_self">
                        <asp:Label ID="lblFeedbackQuestionnaire0" runat="server" meta:resourceKey="lblFeedbackQuestionnaire"
                            Text="Feedback Questionnaire"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 250px; position: relative;"><a href="../Admin/ViewTeacherFeedBack.aspx"
                        target="_self">
                        <asp:Label ID="lblFeedBackReport0" runat="server" meta:resourceKey="lblFeedBackReport"
                            Text="FeedBack"></asp:Label>
                    </a></li>
                </ul>
            </li>
            <li id="liManageChapter" runat="server" style="border-right: 1px solid #000000;"><a
                href="#">
                <asp:Label ID="lblManageChapter" runat="server" Text="Manage Chapter" meta:resourceKey="lblManageChapter"></asp:Label></a>
                <ul class="roundMenuItem">
                    <li><a href="../DataEntry/GenerateBMSSCT.aspx" target="_self">
                        <asp:Label ID="lblGenerateBMSSCT" runat="server" meta:resourceKey="lblGenerateBMSSCTResource1"
                            Text="Generate BMS SCT"></asp:Label>
                    </a></li>
                    <li><a href="../DataEntry/ChapterEntry.aspx" target="_self">
                        <asp:Label ID="lblTeacherUploadChapter" runat="server" meta:resourceKey="lblTeacherUploadChapterResource1"
                            Text="Upload Chapter"></asp:Label>
                    </a></li>
                    <li><a href="../DataEntry/ManageChapterSequence.aspx" target="_self">
                        <asp:Label ID="lblManageChapterSeq" runat="server" meta:resourceKey="lblManageChapterSeqResource1"
                            Text="Chapter Sequence"></asp:Label>
                    </a></li>
                </ul>
            </li>
            <li id="liRescheduling" runat="server" style="border-right: 1px solid #000000;"><a
                href="#">
                <asp:Label ID="lblReschedul" runat="server" Text="Rescheduling Approval" meta:resourceKey="lblReschedul"></asp:Label></a>
                <ul class="roundMenuItem">
                    <li><a href="../Admin/Rescheduling.aspx" target="_self">
                        <asp:Label ID="lblReschedulingApproval" runat="server" meta:resourceKey="lblReschedulingApproval"
                            Text="Teacher Rescheduling Approval"></asp:Label>
                    </a></li>
                    <li><a href="../Admin/ReschedulingStudent.aspx" target="_self">
                        <asp:Label ID="lblStudentReschedulingApproval" runat="server" meta:resourceKey="lblStudentReschedulingApproval"
                            Text="Student Rescheduling Approval"></asp:Label>
                    </a></li>
                </ul>
            </li>
            <%-- <li id="liManageServer" runat="server" style="border-right: 1px solid #000000;"><a
                href="../Admin/SysConfigPage.aspx">
                <asp:Label ID="lblServer" runat="server" Text="Manage Server" meta:resourceKey="lblServer"></asp:Label>
            </a></li>--%>
            <li id="liRPT" runat="server" style="border-right: 1px solid #000000;"><a href="#">
                <asp:Label ID="lblRPT" runat="server" Text="Track Report" meta:resourceKey="lblRPT"></asp:Label></a>
                <ul class="roundMenuItem" style="width: 520px;">
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/ClasswiseCoveredSyllabusNew.aspx"
                        target="_self">
                        <asp:Label ID="Label22" runat="server" meta:resourceKey="Label2" Text="Covered Syllabus Report"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 260px; position: relative;"><a href="../Report/SchoolwiseStudentGenderReportNew.aspx"
                        target="_self">
                        <asp:Label ID="Label23" runat="server" meta:resourceKey="Label3" Text="Gender Report"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/AgewiseStudentReportF.aspx"
                        target="_self">
                        <asp:Label ID="Label24" runat="server" meta:resourceKey="lblAgewisestudentReport"
                            Text="Agewise Student Report"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 260px; position: relative;"><a href="../Report/ClassroomWiseAttendanceF.aspx"
                        target="_self">
                        <asp:Label ID="Label25" runat="server" meta:resourceKey="Label4" Text="Attendance Report"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/ClassRoomWiseMonthlyAttendanceRpt.aspx"
                        target="_self">
                        <asp:Label ID="Label26" runat="server" meta:resourcekey="Label10Resource1" Text="Monthly Attendance Report"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 260px; position: relative;"><a href="../Report/TeacherTrackReport.aspx"
                        target="_self">
                        <asp:Label ID="Label27" runat="server" meta:resourceKey="lblTeacherTrackRPT" Text="Teacher Wise Report"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/TeachersTrack.aspx"
                        target="_self">
                        <asp:Label ID="Label28" runat="server" meta:resourceKey="lblTeacherWiseTrackRPT"
                            Text="Teacher's Track Report"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 260px; position: relative;"><a href="../Report/ClassRoomWiseActivity.aspx"
                        target="_self">
                        <asp:Label ID="Label29" runat="server" meta:resourceKey="lblClassRoomTrackRPT" Text="Class Room Wise Report"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/ClassRoomTrack.aspx"
                        target="_self">
                        <asp:Label ID="Label30" runat="server" meta:resourceKey="lblClassRoomwiseRPT" Text="Class Room Track Report"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 260px; position: relative;"><a href="../Report/SubjectWiseReportF.aspx"
                        target="_self">
                        <asp:Label ID="Label31" runat="server" meta:resourceKey="lblSubjectWiseReport" Text="Subject wise exam result"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/StudentWiseReportF.aspx"
                        target="_self">
                        <asp:Label ID="Label32" runat="server" meta:resourceKey="lblStudentWise" Text="Student wise exam result"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 260px; position: relative;"><a href="../Report/SchoolExamReports.aspx"
                        target="_self">
                        <asp:Label ID="Label33" runat="server" meta:resourceKey="lblSchoolExamReports" Text="School wise exam result"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/ActivityFeedbackReport.aspx"
                        target="_self">
                        <asp:Label ID="Label34" runat="server" meta:resourceKey="lblActivityFeedbackReport"
                            Text="Activity Feedback Report"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 260px; position: relative;"><a href="../Report/SchoolwisePerformanceReport.aspx"
                        target="_self">
                        <asp:Label ID="Label35" runat="server" meta:resourceKey="lblschoolperformanceReport"
                            Text="School Performance Report"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/SubjectwiseSchoolPerformanceReport.aspx"
                        target="_self" style="border-right: none;">
                        <asp:Label ID="Label36" runat="server" meta:resourceKey="lblsubjectwiseschoolperformanceReport"
                            Text="Subjectwise School Performance Report"></asp:Label>
                    </a></li>
                </ul>
            </li>
            <li id="lisetting" runat="server" style="border-right: 1px solid #000000;"><a href="#">
                <asp:Label ID="lblsetting" runat="server" Text="Settings"></asp:Label></a>
                <ul class="roundMenuItem">
                    <li id="liManageServer" runat="server" style="border-right: 1px solid #000000;"><a
                        href="../Admin/SysConfigPage.aspx">
                        <asp:Label ID="lblServer" runat="server" Text="Manage Server" meta:resourceKey="lblServer"></asp:Label>
                    </a></li>
                    <li id="limanageOffers" runat="server" style="border-right: 1px solid #000000;"><a
                        href="../Admin/ManageOffers.aspx">
                        <asp:Label ID="Label5" runat="server" Text="Manage Offers"></asp:Label>
                    </a></li>
                    <li id="liManageQuotes" runat="server" style="border-right: 1px solid #000000;"><a
                        href="../Admin/ManageQuotes.aspx">
                        <asp:Label ID="Label8" runat="server" Text="Manage Quotes"></asp:Label>
                    </a></li>
                </ul>
            </li>
            <li id="li6" runat="server" style="border-right: 1px solid #000000;"><a href="#">
                <asp:Label ID="lblPackage" runat="server" Text="Package"></asp:Label></a>
                <ul class="roundMenuItem">
                    <li id="lipackageregistration" runat="server" style="border-right: 1px solid #000000;">
                        <a href="../Admin/PackageRegistration.aspx">
                            <asp:Label ID="lblpackageregistration" runat="server" Text="Package Registration"></asp:Label>
                        </a></li>

                          <li id="liRefund" runat="server" style="border-right: 1px solid #000000;">
                        <a href="../Admin/RefundAmount.aspx">
                            <asp:Label ID="lblrefund" runat="server" Text="Refund Payment"></asp:Label>
                        </a></li>

                </ul>
            </li>
            <li id="li7" runat="server"><a href="../SitePages/Contact_Us.aspx" target="_self">
                <asp:Label ID="Label14" runat="server" Text="Contact Us" meta:resourceKey="lblContactUS"></asp:Label>
            </a></li>
        </ul>
    </asp:View>
    <asp:View ID="ViewSdmin" runat="server">
        <ul id="qm1" class="qmmc11">
            <li id="liSchooladminDashBoard" runat="server" style="border-right: 1px solid #000000;">
                <a href="../Dashboard/SchoolAdminDashboard.aspx">
                    <asp:Label ID="lblSadminDashboard" runat="server" Text="DashBoard" meta:resourceKey="lblSadminDashboardResource1"></asp:Label>
                </a></li>
            <li id="liViewSchoolProfile" runat="server" style="border-right: 1px solid #000000;">
                <a href="../SchoolAdmin/ViewSchoolProfile.aspx" target="_self">
                    <asp:Label ID="lblSchoolProfile" runat="server" Text="School Profile" meta:resourceKey="lblSchoolProfileResource1"
                        ToolTip="View/update School Profile"></asp:Label>
                </a></li>
            <li id="liEmployeeRegistration" runat="server" style="border-right: 1px solid #000000;">
                <a href="../SchoolAdmin/EmployeeRegistration.aspx" target="_self">
                    <asp:Label ID="lblEmpEnroll" runat="server" Text="Employee Enrollment" meta:resourceKey="lblEmpEnrollResource1"
                        ToolTip="View/Update Employee Enrollment"></asp:Label>
                </a></li>
            <li id="liSchoolAdminUserList" runat="server" style="border-right: 1px solid #000000;">
                <a href="../UserManagement/UserList_New.aspx" target="_self">
                    <asp:Label ID="lblsadminUserList" runat="server" Text="User List" meta:resourceKey="lblsadminUserListResource1"></asp:Label></a>
            </li>
            <li id="liStudent" runat="server" style="border-right: 1px solid #000000;"><a href="#">
                <asp:Label ID="Label21" runat="server" Text="Student"></asp:Label></a>
                <ul class="roundMenuItem">
                    <li id="liStudentAttendance" runat="server" style="border-right: 1px solid #000000;">
                        <a href="../Teacher/StudentAttendance.aspx" target="_self">
                            <asp:Label ID="lblStudentAttendance" runat="server" Text="Student Attendance" meta:resourceKey="lblStudentAttendanceResource1"
                                ToolTip="Student attendance"></asp:Label></a> </li>
                    <li id="liStudentRegistration" runat="server" style="border-right: 1px solid #000000;">
                        <a href="../Registration/StudentRegistration.aspx" target="_self">
                            <asp:Label ID="lblStudentRegistration" runat="server" meta:resourceKey="lblStudentRegistration"
                                Text="Student Registration"></asp:Label>
                        </a></li>
                    <li id="liPromotStudent" runat="server" style="border-right: 1px solid #000000;"><a
                        href="../Dashboard/PromoteBatch.aspx" target="_self">
                        <asp:Label ID="Label20" runat="server" Text="Promote Batch"></asp:Label>
                    </a></li>
                    <li style="border-right: 1px solid #000000;"><a href="../Registration/BulkStudentRegistration.aspx"
                        target="_self">
                        <asp:Label ID="Label15" runat="server" Text="Bulk Student Registration"></asp:Label>
                    </a></li>
                    <li style="border-right: 1px solid #000000;"><a href="../Admission/AddAdmission.aspx"
                        target="_self">
                        <asp:Label ID="Label17" runat="server" Text="New Admission"></asp:Label>
                    </a></li>
                    <li style="border-right: 1px solid #000000;"><a href="../Admission/ViewAdmission.aspx"
                        target="_self">
                        <asp:Label ID="Label18" runat="server" Text="Manage Admission"></asp:Label>
                    </a></li>
                    <li style="border-right: 1px solid #000000;"><a href="../Report/ViewStatusWiseAdmissionReport.aspx"
                        target="_self">
                        <asp:Label ID="Label1" runat="server" Text="Status wise Admission report"></asp:Label>
                    </a></li>
                    <li style="border-right: 1px solid #000000;"><a href="../SchoolAdmin/ManageDocument.aspx"
                        target="_self">
                        <asp:Label ID="Label53" runat="server" Text="Manage Admission Document"></asp:Label>
                    </a></li>
                </ul>
            </li>
            <li id="liTeacherClassAllocation" runat="server" style="border-right: 1px solid #000000;">
                <a href="../SchoolAdmin/TeacherClassAllocation.aspx" target="_self">
                    <asp:Label ID="lblSadminStdAllocation" runat="server" Text="Standard Allocation"
                        meta:resourceKey="lblSadminStdAllocationResource1"></asp:Label>
                </a></li>
            <li id="li3" runat="server" style="border-right: 1px solid #000000;"><a href="#">
                <asp:Label ID="Label37" runat="server" Text="Track Report" meta:resourceKey="lblRPT"></asp:Label></a>
                <ul class="roundMenuItem" style="width: 520px;">
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/ClasswiseCoveredSyllabusNew.aspx"
                        target="_self">
                        <asp:Label ID="Label38" runat="server" meta:resourceKey="Label2" Text="Covered Syllabus Report"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 260px; position: relative;"><a href="../Report/SchoolwiseStudentGenderReportNew.aspx"
                        target="_self">
                        <asp:Label ID="Label39" runat="server" meta:resourceKey="Label3" Text="Gender Report"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/AgewiseStudentReportF.aspx"
                        target="_self">
                        <asp:Label ID="Label40" runat="server" meta:resourceKey="lblAgewisestudentReport"
                            Text="Agewise Student Report"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 260px; position: relative;"><a href="../Report/ClassroomWiseAttendanceF.aspx"
                        target="_self">
                        <asp:Label ID="Label41" runat="server" meta:resourceKey="Label4" Text="Attendance Report"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/ClassRoomWiseMonthlyAttendanceRpt.aspx"
                        target="_self">
                        <asp:Label ID="Label42" runat="server" meta:resourcekey="Label10Resource1" Text="Monthly Attendance Report"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 260px; position: relative;"><a href="../Report/TeacherTrackReport.aspx"
                        target="_self">
                        <asp:Label ID="Label43" runat="server" meta:resourceKey="lblTeacherTrackRPT" Text="Teacher Wise Report"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/TeachersTrack.aspx"
                        target="_self">
                        <asp:Label ID="Label44" runat="server" meta:resourceKey="lblTeacherWiseTrackRPT"
                            Text="Teacher's Track Report"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 260px; position: relative;"><a href="../Report/ClassRoomWiseActivity.aspx"
                        target="_self">
                        <asp:Label ID="Label45" runat="server" meta:resourceKey="lblClassRoomTrackRPT" Text="Class Room Wise Report"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/ClassRoomTrack.aspx"
                        target="_self">
                        <asp:Label ID="Label46" runat="server" meta:resourceKey="lblClassRoomwiseRPT" Text="Class Room Track Report"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 260px; position: relative;"><a href="../Report/SubjectWiseReportF.aspx"
                        target="_self">
                        <asp:Label ID="Label47" runat="server" meta:resourceKey="lblSubjectWiseReport" Text="Subject wise exam result"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/StudentWiseReportF.aspx"
                        target="_self">
                        <asp:Label ID="Label48" runat="server" meta:resourceKey="lblStudentWise" Text="Student wise exam result"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 260px; position: relative;"><a href="../Report/SchoolExamReports.aspx"
                        target="_self">
                        <asp:Label ID="Label49" runat="server" meta:resourceKey="lblSchoolExamReports" Text="School wise exam result"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/ActivityFeedbackReport.aspx"
                        target="_self">
                        <asp:Label ID="Label50" runat="server" meta:resourceKey="lblActivityFeedbackReport"
                            Text="Activity Feedback Report"></asp:Label>
                    </a></li>
                    <li style="float: right; width: 260px; position: relative;"><a href="../Report/SchoolwisePerformanceReport.aspx"
                        target="_self">
                        <asp:Label ID="Label51" runat="server" meta:resourceKey="lblschoolperformanceReport"
                            Text="School Performance Report"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 260px; position: relative;"><a href="../Report/SubjectwiseSchoolPerformanceReport.aspx"
                        target="_self" style="border-right: none;">
                        <asp:Label ID="Label52" runat="server" meta:resourceKey="lblsubjectwiseschoolperformanceReport"
                            Text="Subjectwise School Performance Report"></asp:Label>
                    </a></li>
                </ul>
            </li>
            <li id="liUserLogInOut" runat="server" style="border-right: 1px solid #000000;"><a
                href="../UserManagement/UserLogInOut.aspx" target="_self">
                <asp:Label ID="lblSadminSessionOut" runat="server" Text="End session" meta:resourceKey="lblEadminLogoutUserResource1"></asp:Label>
            </a></li>
            <li><a href="../SchoolAdmin/ManageTemplate.aspx" target="_self">
                <asp:Label ID="Label13" runat="server" Text="Manage Template"></asp:Label>
            </a></li>
            <li id="li9" runat="server"><a href="../SitePages/Contact_Us.aspx" target="_self">
                <asp:Label ID="Label16" runat="server" meta:resourceKey="lblContactUS" Text="Contact Us"></asp:Label>
            </a></li>
        </ul>
    </asp:View>
    <asp:View ID="ViewTeacher" runat="server">
        <ul id="qm2" class="qmmc11">
            <li id="liTeacherDashboard" runat="server" style="border-right: 1px solid #000000;">
                <a href="../Dashboard/TeacherDashboard.aspx" target="_self">
                    <asp:Label ID="lblTeacherDashboard" runat="server" Text="Dashboard" meta:resourceKey="lblTeacherDashboardResource1"></asp:Label>
                </a></li>
            <li id="liStudentList" runat="server" style="border-right: 1px solid #000000;"><a
                href="../UserManagement/UserList_New.aspx" target="_self">
                <asp:Label ID="lblTeacherStdList" runat="server" Text="Student List" meta:resourceKey="lblTeacherStdListResource1"></asp:Label></a></li>
            <li id="liReschedulingChapterTopic" runat="server" style="border-right: 1px solid #000000;">
                <a href="../Teacher/ReschedulingChapterTopic.aspx" target="_self">
                    <asp:Label ID="lblReschedulingChpTopic" runat="server" Text="Rescheduling" meta:resourceKey="lblReschedulingChpTopicResource1"></asp:Label></a></li>
            <li id="liExam" runat="server" style="border-right: 1px solid #000000;"><a href="#">
                <asp:Label ID="lblExam" runat="server" Text="Exam" meta:resourceKey="lblExam"></asp:Label></a>
                <ul>
                    <li><a href="../Exam/ExamEntry.aspx" target="_self">
                        <asp:Label ID="lblExamEntry" runat="server" meta:resourceKey="lblExamEntry" Text="Exam Entry"></asp:Label>
                    </a></li>
                    <li><a href="../Exam/ResultEntry.aspx" target="_self">
                        <asp:Label ID="lblResultEntry" runat="server" meta:resourceKey="lblResultEntry" Text="Result Entry"></asp:Label>
                    </a></li>
                    <li><a href="../Exam/ExamSummaryReport.aspx" target="_self">
                        <asp:Label ID="lblSummaryReport" runat="server" meta:resourceKey="lblSummaryReport"
                            Text="Summary Report"></asp:Label>
                    </a></li>
                </ul>
            </li>
            <li id="liTeacherNotes" runat="server" style="border-right: 1px solid #000000;"><a
                href="../Teacher/TeacherNotes.aspx" target="_self">
                <asp:Label ID="lblTeacherNotes" runat="server" Text="Teacher's Note" meta:resourceKey="lblTeacherNotesResource1"></asp:Label>
            </a></li>
            <li id="li1" runat="server" style="border-right: 1px solid #000000;"><a href="#">
                <asp:Label ID="Label2" runat="server" Text="Report" meta:resourceKey="Label1"></asp:Label>
            </a>
                <ul class="roundMenuItem">
                    <li><a href="../Report/ClasswiseCoveredSyllabusNew.aspx" target="_self">
                        <asp:Label ID="Label3" runat="server" meta:resourceKey="Label2" Text="Covered Syllabus Report"></asp:Label>
                    </a></li>
                    <%--<li style="float: right; width: 260px; position: relative;"><a href="../Report/SchoolwiseStudentGenderReportNew.aspx"
                        target="_self">
                        <asp:Label ID="Label3" runat="server" meta:resourceKey="Label3" Text="Gender Report"></asp:Label>
                    </a></li>--%>
                    <%--<li style="float: left; width: 260px; position: relative;"><a href="../Report/AgewiseStudentReportF.aspx"
                        target="_self">
                        <asp:Label ID="lblAgewisestudentReport" runat="server" meta:resourceKey="lblAgewisestudentReport"
                            Text="Agewise Student Report"></asp:Label>
                    </a></li>--%>
                    <li><a href="../Report/ClassroomWiseAttendanceF.aspx" target="_self">
                        <asp:Label ID="Label4" runat="server" meta:resourceKey="Label4" Text="Attendance Report"></asp:Label>
                    </a></li>
                    <li><a href="../Report/ClassRoomWiseMonthlyAttendanceRpt.aspx" target="_self">
                        <asp:Label ID="Label10" runat="server" meta:resourcekey="Label10Resource1" Text="Monthly Attendance Report"></asp:Label>
                    </a></li>
                    <%--<li style="float: right; width: 260px; position: relative;"><a href="../Report/TeacherTrackReport.aspx"
                        target="_self">
                        <asp:Label ID="Label5" runat="server" meta:resourceKey="lblTeacherTrackRPT" Text="Teacher Wise Report"></asp:Label>
                    </a></li>--%>
                    <%--<li style="float: left; width: 260px; position: relative;"><a href="../Report/TeachersTrack.aspx"
                        target="_self">
                        <asp:Label ID="Label13" runat="server" meta:resourceKey="lblTeacherWiseTrackRPT"
                            Text="Teacher's Track Report"></asp:Label>
                    </a></li>--%>
                    <%--<li style="float: right; width: 260px; position: relative;"><a href="../Report/ClassRoomWiseActivity.aspx"
                        target="_self">
                        <asp:Label ID="Label8" runat="server" meta:resourceKey="lblClassRoomTrackRPT" Text="Class Room Wise Report"></asp:Label>
                    </a></li>--%>
                    <%-- <li style="float: left; width: 260px; position: relative;"><a href="../Report/ClassRoomTrack.aspx"
                        target="_self">
                        <asp:Label ID="Label15" runat="server" meta:resourceKey="lblClassRoomwiseRPT" Text="Class Room Track Report"></asp:Label>
                    </a></li>--%>
                    <li><a href="../Report/SubjectWiseReportF.aspx" target="_self">
                        <asp:Label ID="Label6" runat="server" meta:resourceKey="lblSubjectWiseReport" Text="Subject wise exam result"></asp:Label>
                    </a></li>
                    <li><a href="../Report/StudentWiseReportF.aspx" target="_self">
                        <asp:Label ID="Label7" runat="server" meta:resourceKey="lblStudentWise" Text="Student wise exam result"></asp:Label>
                    </a></li>
                    <li><a href="../Report/SchoolExamReports.aspx" target="_self">
                        <asp:Label ID="lblSchoolExamReportsL" runat="server" meta:resourceKey="lblSchoolExamReportsteacher"
                            Text="Exam result Report"></asp:Label>
                    </a></li>
                    <li><a href="../Report/ActivityFeedbackReport.aspx" target="_self">
                        <asp:Label ID="lblActivityFeedbackReport" runat="server" meta:resourceKey="lblActivityFeedbackReport"
                            Text="Activity Feedback Report"></asp:Label>
                    </a></li>
                    <%--<li style="float: right; width: 260px; position: relative;"><a href="../Report/SchoolwisePerformanceReport.aspx"
                        target="_self">
                        <asp:Label ID="Label17" runat="server" meta:resourceKey="lblschoolperformanceReport"
                            Text="School Performance Report"></asp:Label>
                    </a></li>--%>
                    <%--<li style="float: left; width: 260px; position: relative;"><a href="../Report/SubjectwiseSchoolPerformanceReport.aspx"
                        target="_self" style="border-right: none;">
                        <asp:Label ID="Label18" runat="server" meta:resourceKey="lblsubjectwiseschoolperformanceReport"
                            Text="Subjectwise School Performance Report"></asp:Label>
                    </a></li>--%>
                </ul>
            </li>
            <li id="li2" runat="server"><a href="../SitePages/Contact_Us.aspx" target="_self">
                <asp:Label ID="Label9" runat="server" meta:resourceKey="lblContactUS" Text="Contact Us"></asp:Label>
            </a></li>
        </ul>
    </asp:View>
    <asp:View ID="ViewStudent" runat="server">
        <ul id="qm3" class="qmmc11">
            <li id="liStudDashboard" runat="server" style="border-right: 1px solid #000000;"><a
                href="../Dashboard/StudentDashboard.aspx" target="_self">
                <asp:Label ID="lblStudDashboard" runat="server" meta:resourceKey="lblStudDashboardResource1"
                    Text="Dashboard"></asp:Label>
            </a></li>
            <li id="liProfile" runat="server" style="border-right: 1px solid #000000;"><a href="../Student/StudentProfile.aspx"
                target="_self">
                <asp:Label ID="lblProfile" runat="server" meta:resourceKey="lblProfile" Text="Profile"></asp:Label>
            </a></li>
            <li id="liStudentPackage" runat="server" style="border-right: 1px solid #000000;"
                visible="false"><a href="../DashBoard/StudentCourses.aspx" target="_self">
                    <asp:Label ID="lblStudentPackage" runat="server" meta:resourceKey="lblStudentPackage"
                        Text="Student Packages"></asp:Label>
                </a></li>
            <li id="liSelectPackage" runat="server" style="border-right: 1px solid #000000;"><a
                href="../DashBoard/BuyPackage.aspx" target="_self">
                <asp:Label ID="lblSelectPackage" runat="server" meta:resourceKey="lblSelectPackage"
                    Text="Buy Package"></asp:Label>
            </a></li>
            <li id="li5" runat="server" style="border-right: 1px solid #000000;"><a href="#"
                target="_self">
                <asp:Label ID="Label11" runat="server" meta:resourceKey="lblReport" Text="Report"></asp:Label>
            </a>
                <ul>
                    <li id="liReport" runat="server"><a href="../Report/StudentPackageReport.aspx" target="_self">
                        <asp:Label ID="lblstudentreport" runat="server" Text="Student Report"></asp:Label>
                    </a></li>
                    <li><a href="../Report/SubjectWiseReportF.aspx" target="_self">
                        <asp:Label ID="Label59" runat="server" meta:resourceKey="lblSubjectWiseReport" Text="Subject wise exam result"></asp:Label>
                    </a></li>
                    <%--<li><a href="../Report/StudentWiseReportF.aspx"
                        target="_self">
                        <asp:Label ID="Label5" runat="server" meta:resourceKey="lblStudentWise" Text="Student wise exam result"></asp:Label>
                    </a></li>--%>
                </ul>
            </li>
            <li id="li4" runat="server"><a href="../SitePages/Contact_Us.aspx" target="_self">
                <asp:Label ID="Label60" runat="server" meta:resourceKey="lblContactUS" Text="Contact Us"></asp:Label>
            </a></li>
        </ul>
    </asp:View>
      <asp:View ID="ViewParent" runat="server">
         <ul id="qm4" class="qmmc11">
         
            <li id="li8" runat="server" style="border-right: 1px solid #000000;">
                <a href="../Dashboard/ParentDashboard.aspx" target="_self">
                    <asp:Label ID="Label12" runat="server" Text="Dashboard" meta:resourceKey="lblTeacherDashboardResource1"></asp:Label>
                </a></li>

              <li id="li10" runat="server" style="border-right: 1px solid #000000;"><a href="../Student/StudentProfile.aspx"
                target="_self">
                <asp:Label ID="Label54" runat="server" Text="Profile" meta:resourceKey="lblProfile"></asp:Label></a></li>
            <%--<li id="li11" runat="server" style="border-right: 1px solid #000000;"><a
                href="../DashBoard/StudentCourses.aspx" target="_self">
                <asp:Label ID="Label55" runat="server" Text="Student Packages" meta:resourceKey="lblStudentPackage"></asp:Label></a></li>
            <li id="li12" runat="server" style="border-right: 1px solid #000000;"><a
                href="../DashBoard/SelectPackage.aspx" target="_self">

           
                <asp:Label ID="Label56" runat="server" Text="Buy Package" meta:resourceKey="lblSelectPackage"></asp:Label></a></li>--%>

<%--              <li id="li99" runat="server" style="border-right: 1px solid #000000;"><a href="#"
                target="_self">
                <asp:Label ID="Label55" runat="server" meta:resourceKey="lblReport" Text="Report"></asp:Label>
            </a>
                <ul>
                    
                    <li><a href="../Report/SubjectWiseReportF.aspx" target="_self">
                        <asp:Label ID="Label56" runat="server" meta:resourceKey="lblSubjectWiseReport" Text="Subject wise exam result"></asp:Label>
                    </a></li>--%>
            <%-- <li id="li13" runat="server" style="border-right: 1px solid #000000;"><a href="../Report/StudentChapterWisePerformance.aspx"
                target="_self">
                <asp:Label ID="Label57" runat="server" Text="Chapter wise performance report" meta:resourceKey="lblReport"></asp:Label>
            </a></li> --%>    
             <%--         <li><a href="../Report/ClassRoomWiseMonthlyAttendanceRpt.aspx" target="_self">
                        <asp:Label ID="Label57" runat="server" meta:resourcekey="Label10Resource1" Text="Monthly Attendance Report"></asp:Label>
                    </a></li>
                </ul>
            </li>--%>

            
            <li id="li14" runat="server"><a href="../SitePages/Contact_Us.aspx" target="_self">
                <asp:Label ID="Label58" runat="server" Text="Contact Us" meta:resourceKey="lblContactUS"></asp:Label>
            </a></li>
             </ul>
        </asp:View>
</asp:MultiView>
