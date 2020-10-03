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
    $(function () {
        //////           $(document).tooltip( "option", "hide", { effect: "explode", duration: 1000 } );
        $(document).tooltip("option", "show", { effect: "blind", duration: 2000 });

        //            $(document).tooltip({ track: true });

        ////         
    });
    </script>
<asp:MultiView ID="MenuCtrl" runat="server">
    <div class="newmenuwrap">
        <asp:View ID="ViewEAdmin" runat="server">
            <ul id="qm0" class="qmmc11">
                <%--<li id="li6" runat="server" style="border-right: 1px solid #000000;"><a href="../SitePages/HomePage.aspx"
                target="_self">
                <asp:Label ID="Label13" runat="server" Text="Home" meta:resourceKey="lblHome"></asp:Label>
            </a></li>--%>
                <li id="liEpathDashboard" runat="server" style="border-right: 1px solid #000000;"><a
                    href="../Dashboard/EpathAdminDashboard.aspx">
                    <asp:Label ID="lblEAdminDashBoard" runat="server" Text="DashBoard" meta:resourceKey="lblEAdminDashBoard"></asp:Label>
                </a></li>
                <li id="liManageUsers" runat="server" style="border-right: 1px solid #000000;"><a
                    href="#">
                    <asp:Label ID="lblManageUsers" runat="server" Text="Manage Users" meta:resourceKey="lblManageUsers"></asp:Label></a>
                    <ul class="roundMenuItem">
                        <li><a href="../SchoolManagement/SchoolList.aspx" target="_self">
                            <asp:Label ID="lblEadminSchoolList" runat="server" Text="School List" meta:resourceKey="lblEadminSchoolListlnk"></asp:Label></a>
                        </li>
                        <li><a href="../UserManagement/UserList.aspx" target="_self">
                            <asp:Label ID="lblEadminUserList" runat="server" Text="User List" meta:resourceKey="lblEadminUserListResource1"></asp:Label></a></li>
                        <li><a href="../UserManagement/UserLogInOut.aspx" target="_self">
                            <asp:Label ID="lblEadminLogoutUser" runat="server" Text="Logout user session" meta:resourceKey="lblEadminLogoutUserResource1"></asp:Label>
                        </a></li>
                    </ul>
                </li>
                <li id="liManageChapter" runat="server" style="border-right: 1px solid #000000;"><a
                    href="#">
                    <asp:Label ID="lblManageChapter" runat="server" Text="Manage Chapter" meta:resourceKey="lblManageChapter"></asp:Label></a>
                    <ul class="roundMenuItem">
                        <li><a href="../DataEntry/GenerateBMSSCT.aspx" target="_self">
                            <asp:Label ID="lblGenerateBMSSCT" runat="server" Text="Generate BMS SCT" meta:resourceKey="lblGenerateBMSSCTResource1"></asp:Label>
                        </a></li>
                        <li><a href="../DataEntry/ChapterEntry.aspx" target="_self">
                            <asp:Label ID="lblTeacherUploadChapter" runat="server" Text="Upload Chapter" meta:resourceKey="lblTeacherUploadChapterResource1"></asp:Label>
                        </a></li>
                        <li><a href="../DataEntry/ManageChapterSequence.aspx" target="_self">
                            <asp:Label ID="lblManageChapterSeq" runat="server" Text="Chapter Sequence" meta:resourceKey="lblManageChapterSeqResource1"></asp:Label>
                        </a></li>
                    </ul>
                </li>
                <li id="liManageMaster" runat="server" style="border-right: 1px solid #000000;"><a
                    href="#">
                    <asp:Label ID="lblMastersManage" runat="server" Text="Manage Masters" meta:resourceKey="lblMastersManage"></asp:Label></a>
                    <ul class="roundMenuItem" style="width: 500px;">
                        <li style="float: left; width: 250px; position: relative;"><a href="../Admin/Board.aspx"
                            target="_self">
                            <asp:Label ID="lblBoardManage" runat="server" Text="Manage Board" meta:resourceKey="lblBoardManage"></asp:Label>
                        </a></li>
                        <li style="float: right; width: 250px; position: relative;"><a href="../Admin/Medium.aspx"
                            target="_self">
                            <asp:Label ID="lblMediumManage" runat="server" Text="Manage Medium" meta:resourceKey="lblMediumManage"></asp:Label>
                        </a></li>
                        <li style="float: left; width: 250px; position: relative;"><a href="../Admin/Standard.aspx"
                            target="_self">
                            <asp:Label ID="lblStandardManage" runat="server" Text="Manage Standard" meta:resourceKey="lblStandardManage"></asp:Label>
                        </a></li>
                        <li style="float: right; width: 250px; position: relative;"><a href="../Admin/BMS.aspx"
                            target="_self">
                            <asp:Label ID="lblBMSManage" runat="server" Text="Manage BMS" meta:resourceKey="lblBMSManage"></asp:Label>
                        </a></li>
                        <li style="float: left; width: 250px; position: relative;"><a href="../Admin/Division.aspx"
                            target="_self">
                            <asp:Label ID="lblDivisionManage" runat="server" Text="Manage Division" meta:resourceKey="lblDivisionManage"></asp:Label>
                        </a></li>
                        <li style="float: right; width: 250px; position: relative;"><a href="../Admin/Subject.aspx"
                            target="_self">
                            <asp:Label ID="lblSubjectManage" runat="server" Text="Manage Subject" meta:resourceKey="lblSubjectManage"></asp:Label>
                        </a></li>
                        <li style="float: left; width: 250px; position: relative;"><a href="../Admin/Chapter.aspx"
                            target="_self">
                            <asp:Label ID="lblChapterManage" runat="server" Text="Manage Chapter" meta:resourceKey="lblChapterManage"></asp:Label>
                        </a></li>
                        <li style="float: right; width: 250px; position: relative;"><a href="../Admin/Topic.aspx"
                            target="_self">
                            <asp:Label ID="lblTopicManage" runat="server" Text="Manage Topic" meta:resourceKey="lblTopicManage"></asp:Label>
                        </a></li>
                        <li style="float: left; width: 250px; position: relative;"><a href="../Admin/District.aspx"
                            target="_self">
                            <asp:Label ID="lblDistrictManage" runat="server" Text="Manage District" meta:resourceKey="lblDistrictManage"></asp:Label>
                        </a></li>
                        <li style="float: right; width: 250px; position: relative;"><a href="../Admin/State.aspx"
                            target="_self">
                            <asp:Label ID="lblStateManage" runat="server" Text="Manage State" meta:resourceKey="lblStateManage"></asp:Label>
                        </a></li>
                        <li style="float: left; width: 250px; position: relative;"><a href="../Admin/Country.aspx"
                            target="_self">
                            <asp:Label ID="lblCountryManage" runat="server" Text="Manage Country" meta:resourceKey="lblCountryManage"></asp:Label>
                        </a></li>
                        <li style="float: right; width: 250px; position: relative;"><a href="../Admin/Role.aspx"
                            target="_self">
                            <asp:Label ID="lblRoleManage" runat="server" Text="Manage Role" meta:resourceKey="lblRoleManage"></asp:Label>
                        </a></li>
                        <li style="float: left; width: 250px; position: relative;"><a href="../Admin/SchoolType.aspx"
                            target="_self">
                            <asp:Label ID="lblSchoolTypeManage" runat="server" Text="Manage SchoolType" meta:resourceKey="lblSchoolTypeManage"></asp:Label>
                        </a></li>
                        <li style="float: left; width: 250px; position: relative;">
                            <a href="../Report/QuestionEntry.aspx" target="_self">
                            <asp:Label ID="Label19" runat="server" 
                                meta:resourceKey="lblFeedbackQuestionnaire1" Text="Question Entry"></asp:Label>
                            </a></li>
                         <li style="float: right; width: 250px; position: relative;">
                             <a href="../Admin/FeedbackQuestionnaire.aspx" target="_self">
                             <asp:Label ID="lblFeedbackQuestionnaire0" runat="server" 
                                 meta:resourceKey="lblFeedbackQuestionnaire" Text="Feedback Questionnaire"></asp:Label>
                             </a></li>
                        <li style="float: right; width: 250px; position: relative;">
                            <a href="../Admin/ViewTeacherFeedBack.aspx" target="_self">
                            <asp:Label ID="lblFeedBackReport0" runat="server" 
                                meta:resourceKey="lblFeedBackReport" Text="FeedBack"></asp:Label>
                            </a></li>
                    </ul>
                </li>
                <li id="liRescheduling" runat="server" style="border-right: 1px solid #000000;"><a
                    href="#">
                    <asp:Label ID="lblReschedul" runat="server" Text="Rescheduling Approval" meta:resourceKey="lblReschedul"></asp:Label></a>
                    <ul class="roundMenuItem">
                        <li><a href="../Admin/Rescheduling.aspx" target="_self">
                            <asp:Label ID="lblReschedulingApproval" runat="server" Text="Teacher Rescheduling Approval"
                                meta:resourceKey="lblReschedulingApproval"></asp:Label></a> </li>
                        <li><a href="../Admin/ReschedulingStudent.aspx" target="_self">
                            <asp:Label ID="lblStudentReschedulingApproval" runat="server" Text="Student Rescheduling Approval"
                                meta:resourceKey="lblStudentReschedulingApproval"></asp:Label></a> </li>
                    </ul>
                </li>
                <li id="liRPT" runat="server" style="border-right: 1px solid #000000;"><a href="#">
                    <asp:Label ID="lblRPT" runat="server" Text="Track Report" meta:resourceKey="lblRPT"></asp:Label></a>
                    <ul class="roundMenuItem">
                        <li><a href="../Report/TeacherTrackReport.aspx" target="_self">
                            <asp:Label ID="lblTeacherTrackRPT" runat="server" Text="Teacher Wise Report" meta:resourceKey="lblTeacherTrackRPT"></asp:Label></a>
                        </li>
                        <li><a href="../Report/ClassRoomWiseActivity.aspx" target="_self">
                            <asp:Label ID="lblClassRoomTrackRPT" runat="server" Text="Class Room Wise Report"
                                meta:resourceKey="lblClassRoomTrackRPT"></asp:Label></a> </li>
                        <li><a href="../Admin/SchoolExamReports.aspx" target="_self">
                            <asp:Label ID="lblSchoolExamReports" runat="server" Text="School Wise Exam Result"
                                meta:resourceKey="lblSchoolExamReports"></asp:Label></a></li>
                        <li><a href="../Report/SubjectWiseReportF.aspx" target="_self">
                            <asp:Label ID="lblSubjectWiseReport" runat="server" Text="Subject wise exam result"
                                meta:resourceKey="lblSubjectWiseReport"></asp:Label></a></li>
                        <li><a href="../Report/StudentWiseReportF.aspx" target="_self">
                            <asp:Label ID="lblStudentWise" runat="server" Text="Student wise exam result" meta:resourceKey="lblStudentWise"></asp:Label></a></li>
                    </ul>
                </li>
                <li id="liManageSchool" runat="server" style="border-right: 1px solid #000000;"><a href="#">
                    <asp:Label ID="LblManageSchool" runat="server" Text="Manage School"></asp:Label></a>
                    <ul class="roundMenuItem">
                    <li><a href="../Registration/SchoolRegistration.aspx" target="_self">
                   <%-- id="liSchoolRegistration" runat="server" style="border-right: 1px solid #000000;">--%>
                        <asp:Label ID="lblSchoolRegistration" runat="server" Text="School Registration" 
                        meta:resourceKey="lblSchoolRegistration"></asp:Label></a></li>
                     <li><a href="../Admin/StandardAllocation.aspx" target="_self">
                        <asp:Label ID="lblStandardAllocation" runat="server" Text="Standard Allocation" 
                        meta:resourceKey="lblStandardAllocation"></asp:Label></a></li>
                    </ul>
                </li>

                   <li id="lisubjectallocation" runat="server" >
                    <a href="../Registration/SchoolRegistration.aspx" target="_self">
                        <asp:Label ID="lblsubjectallocation" runat="server" Text="Subject Allocation" meta:resourceKey="lblsubjectallocation"></asp:Label></a>
                </li>
                <%--<li id="liManageServer" runat="server" style="border-right: 1px solid #000000;"><a
                    href="../Utility/ManageServerConfig.aspx">
                    <asp:Label ID="lblServer" runat="server" Text="Manage Server" meta:resourceKey="lblServer"></asp:Label>
                </a></li>--%>
                <li id="liManageServer" runat="server" style="border-right: 1px solid #000000;"><a
                    href="../Admin/SysConfigPage.aspx">
                    <asp:Label ID="lblServer" runat="server" Text="Manage Server" meta:resourceKey="lblServer"></asp:Label>
                </a></li>
                <li id="li7" runat="server"><a href="../SitePages/Contact_Us.aspx" target="_self">
                    <asp:Label ID="Label14" runat="server" Text="Contact Us" meta:resourceKey="lblContactUS"></asp:Label>
                </a></li>
            </ul>
        </asp:View>
    </div>
    <asp:View ID="ViewSdmin" runat="server">
        <ul id="qm1" class="qmmc11">
            <%--<li id="li8" runat="server" style="border-right: 1px solid #000000; margin-left: 20px;">
                <a href="../SitePages/HomePage.aspx" target="_self">
                    <asp:Label ID="Label15" runat="server" Text="Home" meta:resourceKey="lblHome"></asp:Label>
                </a></li>--%>
            <li id="liSchooladminDashBoard" runat="server" style="border-right: 1px solid #000000;">
                <a href="../Dashboard/SchoolAdminDashboard.aspx">
                    <asp:Label ID="lblSadminDashboard" runat="server" Text="DashBoard" meta:resourceKey="lblSadminDashboardResource1"></asp:Label>
                </a></li>
            <li id="liViewSchoolProfile" runat="server" style="border-right: 1px solid #000000;">
                <a href="../SchoolAdmin/ViewSchoolProfile.aspx" target="_self">
                    <asp:Label ID="lblSchoolProfile" runat="server" Text="School Profile" ToolTip="View/update School Profile"
                        meta:resourceKey="lblSchoolProfileResource1"></asp:Label></a></li>
            <li id="liEmployeeRegistration" runat="server" style="border-right: 1px solid #000000;">
                <a href="../SchoolAdmin/EmployeeRegistration.aspx" target="_self">
                    <asp:Label ID="lblEmpEnroll" runat="server" Text="Employee Enrollment" ToolTip="View/Update Employee Enrollment"
                        meta:resourceKey="lblEmpEnrollResource1"></asp:Label></a></li>
            <li id="liSchoolAdminUserList" runat="server" style="border-right: 1px solid #000000;">
                <a href="../UserManagement/UserList.aspx" target="_self">
                    <asp:Label ID="lblsadminUserList" runat="server" Text="User List" meta:resourceKey="lblsadminUserListResource1"></asp:Label>
                </a></li>
           
            <li id="liStudentAttendance" runat="server" style="border-right: 1px solid #000000;">
                <a href="../Teacher/StudentAttendance.aspx" target="_self">
                    <asp:Label ID="lblStudentAttendance" runat="server" Text="Student Attendance" ToolTip="Student attendance"
                        meta:resourceKey="lblStudentAttendanceResource1"></asp:Label></a></li>
            <li id="liUserLogInOut" runat="server" style="border-right: 1px solid #000000;"><a
                href="../UserManagement/UserLogInOut.aspx" target="_self">
                <asp:Label ID="lblSadminSessionOut" runat="server" Text="End session" meta:resourceKey="lblEadminLogoutUserResource1"></asp:Label>
            </a></li>
            <li id="liStudentRegistration" runat="server" style="border-right: 1px solid #000000;">
                <a href="../Registration/StudentRegistration.aspx" target="_self">
                    <asp:Label ID="lblStudentRegistration" runat="server" Text="Student Registration"
                        meta:resourceKey="lblStudentRegistration"></asp:Label>
                </a></li>
            <li id="li9" runat="server"><a href="../SitePages/Contact_Us.aspx" target="_self">
                <asp:Label ID="Label16" runat="server" Text="Contact Us" meta:resourceKey="lblContactUS"></asp:Label>
            </a></li>
        </ul>
    </asp:View>
    <asp:View ID="ViewTeacher" runat="server">
        <ul id="qm2" class="qmmc11">
            <%--<li id="liHome" runat="server" style="border-right: 1px solid #000000; margin-left: 20px;">
                <a href="../SitePages/HomePage.aspx" target="_self">
                    <asp:Label ID="lblHome" runat="server" Text="Home" meta:resourceKey="lblHome"></asp:Label>
                </a></li>--%>
            <li id="liTeacherDashboard" runat="server" style="border-right: 1px solid #000000;">
                <a href="../Dashboard/TeacherDashboard.aspx" target="_self">
                    <asp:Label ID="lblTeacherDashboard" runat="server" Text="Dashboard" meta:resourceKey="lblTeacherDashboardResource1"></asp:Label>
                </a></li>
            <li id="liStudentList" runat="server" style="border-right: 1px solid #000000;"><a
                href="../UserManagement/UserList.aspx" target="_self">
                <asp:Label ID="lblTeacherStdList" runat="server" Text="Student List" meta:resourceKey="lblTeacherStdListResource1"></asp:Label>
            </a></li>
            <li id="liReschedulingChapterTopic" runat="server" style="border-right: 1px solid #000000;">
                <a href="../Teacher/ReschedulingChapterTopic.aspx" target="_self">
                    <asp:Label ID="lblReschedulingChpTopic" runat="server" Text="Rescheduling" meta:resourceKey="lblReschedulingChpTopicResource1"></asp:Label>
                </a></li>
            <li id="liExam" runat="server" style="border-right: 1px solid #000000;"><a href="#">
                <asp:Label ID="lblExam" runat="server" Text="Exam" meta:resourceKey="lblExam"></asp:Label></a>
                <ul>
                    <li><a href="../Exam/ExamEntry.aspx" target="_self">
                        <asp:Label ID="lblExamEntry" runat="server" Text="Exam Entry" meta:resourceKey="lblExamEntry"></asp:Label>
                    </a></li>
                    <li><a href="../Exam/ResultEntry.aspx" target="_self">
                        <asp:Label ID="lblResultEntry" runat="server" Text="Result Entry" meta:resourceKey="lblResultEntry"></asp:Label>
                    </a></li>
                    <li><a href="../Exam/ExamSummaryReport.aspx" target="_self">
                        <asp:Label ID="lblSummaryReport" runat="server" Text="Summary Report" meta:resourceKey="lblSummaryReport"></asp:Label>
                    </a></li>
                </ul>
            </li>
            <li id="liTeacherNotes" runat="server" style="border-right: 1px solid #000000;"><a
                href="../Teacher/TeacherNotes.aspx" target="_self">
                <asp:Label ID="lblTeacherNotes" runat="server" Text="Teacher's Note" meta:resourceKey="lblTeacherNotesResource1"></asp:Label>
            </a></li>
            <li id="li1" runat="server" style="border-right: 1px solid #000000;"><a href="#">
                <asp:Label ID="Label1" runat="server" Text="Report" meta:resourceKey="Label1"></asp:Label></a>
                <ul class="roundMenuItem" style="width: 500px;">
                    <li style="float: left; width: 250px; position: relative;"><a href="../Report/ClasswiseCoveredSyllabusNew.aspx"
                        target="_self">
                        <asp:Label ID="Label2" runat="server" Text="Covered Syllabus Report" meta:resourceKey="Label2"></asp:Label>
                    </a></li>
                   
                    <li style="float: right; width: 250px; position: relative;"><a href="../Report/SchoolwiseStudentGenderReportNew.aspx"
                        target="_self">
                        <asp:Label ID="Label3" runat="server" Text="Gender Report" meta:resourceKey="Label3"></asp:Label>
                    </a></li>
                 
                    <li style="float: left; width: 250px; position: relative;"><a href="../Report/AgewiseStudentReportF.aspx"
                        target="_self">
                        <asp:Label ID="lblAgewisestudentReport" runat="server" Text="Agewise Student Report"
                            meta:resourceKey="lblAgewisestudentReport"></asp:Label></a></li>
                    
                    <li style="float: right; width: 250px; position: relative;"><a href="../Report/ClassroomWiseAttendanceF.aspx"
                        target="_self">
                        <asp:Label ID="Label4" runat="server" Text="Attendance Report" meta:resourceKey="Label4"></asp:Label>
                    </a></li>
                    <li style="float: left; width: 250px; position: relative;"><a href="../Report/ClassRoomWiseMonthlyAttendanceRpt.aspx"
                        target="_self">
                        <asp:Label ID="Label10" runat="server" Text="Monthly Attendance Report"></asp:Label>
                    </a></li>
                 
                    <li style="float: right; width: 250px; position: relative;"><a href="../Report/TeacherTrackReport.aspx"
                        target="_self">
                        <asp:Label ID="Label5" runat="server" Text="Teacher Wise Report" meta:resourceKey="lblTeacherTrackRPT"></asp:Label></a>
                    </li>
                    <li style="float: left; width: 250px; position: relative;"><a href="../Report/TeachersTrack.aspx"
                        target="_self">
                        <asp:Label ID="Label13" runat="server" Text="Teacher's Track Report" meta:resourceKey="lblTeacherWiseTrackRPT"></asp:Label></a>
                    </li>
                    <li style="float: right; width: 250px; position: relative;"><a href="../Report/ClassRoomWiseActivity.aspx"
                        target="_self">
                        <asp:Label ID="Label8" runat="server" Text="Class Room Wise Report" meta:resourceKey="lblClassRoomTrackRPT"></asp:Label></a>
                    </li>
                    <li style="float: left; width: 250px; position: relative;"><a href="../Report/ClassRoomTrack.aspx"
                        target="_self">
                        <asp:Label ID="Label15" runat="server" Text="Class Room Track Report" meta:resourceKey="lblClassRoomwiseRPT"></asp:Label></a>
                    </li>
                 
                    <%--<li><a href="../Admin/SchoolExamReports.aspx" target="_self">
                        <asp:Label ID="Label5" runat="server" Text="School Wise Exam Result" meta:resourceKey="lblSchoolExamReports"></asp:Label></a></li>--%>
                    <li style="float: right; width: 250px; position: relative;"><a href="../Report/SubjectWiseReportF.aspx"
                        target="_self">
                        <asp:Label ID="Label6" runat="server" Text="Subject wise exam result" meta:resourceKey="lblSubjectWiseReport"></asp:Label></a></li>
                    <li style="float: left; width: 250px; position: relative;"><a href="../Report/StudentWiseReportF.aspx"
                        target="_self">
                        <asp:Label ID="Label7" runat="server" Text="Student wise exam result" meta:resourceKey="lblStudentWise"></asp:Label></a></li>
                    <li style="float: right; width: 250px; position: relative;"><a href="../Report/SchoolExamReports.aspx"
                        target="_self">
                        <asp:Label ID="lblSchoolExamReportsL" runat="server" Text="School wise exam result"
                            meta:resourceKey="lblSchoolExamReports"></asp:Label></a></li>
                    <li style="float: left; width: 250px; position: relative;"><a href="../Report/ActivityFeedbackReport.aspx"
                        target="_self">
                        <asp:Label ID="lblActivityFeedbackReport" runat="server" Text="Activity Feedback Report"
                            meta:resourceKey="lblActivityFeedbackReport"></asp:Label></a></li>
                    <li style="float: right; width: 250px; position: relative;"><a href="../Report/SchoolwisePerformanceReport.aspx"
                        target="_self">
                        <asp:Label ID="Label17" runat="server" Text="School Performance Report" meta:resourceKey="lblschoolperformanceReport"></asp:Label></a></li>
                    <li style="float: left; width: 250px; position: relative;"><a href="../Report/SubjectwiseSchoolPerformanceReport.aspx"
                        target="_self">
                        <asp:Label ID="Label18" runat="server" Text="Subjectwise School Performance Report"
                            meta:resourceKey="lblsubjectwiseschoolperformanceReport"></asp:Label></a></li>
                </ul>
            </li>
            <li id="li2" runat="server"><a href="../SitePages/Contact_Us.aspx" target="_self">
                <asp:Label ID="Label9" runat="server" Text="Contact Us" meta:resourceKey="lblContactUS"></asp:Label>
            </a></li>
        </ul>
    </asp:View>
    <asp:View ID="ViewStudent" runat="server">
        <ul id="qm3" class="qmmc11">
            <%-- <li id="li3" runat="server" style="border-right: 1px solid #000000;"><a href="../SitePages/HomePage.aspx"
                target="_self">
                <asp:Label ID="Label10" runat="server" Text="Home" meta:resourceKey="lblHome"></asp:Label>
            </a></li>--%>
            <li id="liStudDashboard" runat="server" style="border-right: 1px solid #000000;"><a
                href="../Dashboard/StudentDashboard.aspx" target="_self">
                <asp:Label ID="lblStudDashboard" runat="server" Text="Dashboard" meta:resourceKey="lblStudDashboardResource1"></asp:Label>
            </a></li>
            <%--   <li id="liStudentRescheduling" runat="server" class="roundMenuItem"><a class="qmparent"
                href="../Student/ReschedulingChapterTopicStudent.aspx" target="_self">
                <asp:Label ID="lblStudentRescheduling" runat="server" Text="Rescheduling"></asp:Label></a></li>--%>
            <li id="liProfile" runat="server" style="border-right: 1px solid #000000;"><a href="../Student/StudentProfile.aspx"
                target="_self">
                <asp:Label ID="lblProfile" runat="server" Text="Profile" meta:resourceKey="lblProfile"></asp:Label></a></li>
            <li id="liStudentPackage" runat="server" style="border-right: 1px solid #000000;"><a
                href="../DashBoard/StudentCourses.aspx" target="_self">
                <asp:Label ID="lblStudentPackage" runat="server" Text="Student Packages" meta:resourceKey="lblStudentPackage"></asp:Label></a></li>
            <li id="liSelectPackage" runat="server" style="border-right: 1px solid #000000;"><a
                href="../DashBoard/SelectPackage.aspx" target="_self">

           
                <asp:Label ID="lblSelectPackage" runat="server" Text="Buy Package" meta:resourceKey="lblSelectPackage"></asp:Label></a></li>
            <li id="li5" runat="server" style="border-right: 1px solid #000000;"><a href="../Report/StudentChapterWisePerformance.aspx"
                target="_self">
                <asp:Label ID="Label12" runat="server" Text="Report" meta:resourceKey="lblReport"></asp:Label>
            </a></li>
            <li id="li4" runat="server"><a href="../SitePages/Contact_Us.aspx" target="_self">
                <asp:Label ID="Label11" runat="server" Text="Contact Us" meta:resourceKey="lblContactUS"></asp:Label>
            </a></li>
        </ul>
    </asp:View>
    <%-- <asp:View ID="ViewEAdmin" runat="server">
        <div class="menu">
            <ul>
                <li class="round">
                    <asp:Label ID="lblManageChapter" runat="server" Text="Manage Users"></asp:Label>
                    <ul>
                        <li><a href="../SchoolManagement/SchoolList.aspx" target="_self">
                            <asp:Label ID="lblEadminSchoolList" runat="server" Text="School List" meta:resourceKey="lblEadminSchoolListlnk"></asp:Label></a>
                        </li>
                        <li><a href="../UserManagement/UserList.aspx" target="_self">
                            <asp:Label ID="lblEadminUserList" runat="server" Text="User List" meta:resourceKey="lblEadminUserListResource1"></asp:Label></a></li>
                        <li><a href="../UserManagement/UserLogInOut.aspx" target="_self">
                            <asp:Label ID="lblEadminLogoutUser" runat="server" Text="Logout user session" meta:resourceKey="lblEadminLogoutUserResource1"></asp:Label>
                        </a></li>
                    </ul>
                </li>
                <li class="round">
                    <asp:Label ID="lblManageUsers" runat="server" Text="Manage Chapter"></asp:Label>
                    <ul>
                        <li><a href="../DataEntry/GenerateBMSSCT.aspx" target="_self">
                            <asp:Label ID="lblGenerateBMSSCT" runat="server" Text="Generate BMS SCT" meta:resourceKey="lblGenerateBMSSCTResource1"></asp:Label>
                        </a></li>
                        <li><a href="../DataEntry/ChapterEntry.aspx" target="_self">
                            <asp:Label ID="lblTeacherUploadChapter" runat="server" Text="Upload Chapter" meta:resourceKey="lblTeacherUploadChapterResource1"></asp:Label>
                        </a></li>
                        <li><a href="../DataEntry/ManageChapterSequence.aspx" target="_self">
                            <asp:Label ID="lblManageChapterSeq" runat="server" Text="Chapter Sequence" meta:resourceKey="lblManageChapterSeqResource1"></asp:Label>
                        </a></li>
                    </ul>
                </li>
                <li class="round">
                    <asp:Label ID="lblMastersManage" runat="server" Text="Manage Masters"></asp:Label>
                    <ul>
                        <li><a href="../Admin/Board.aspx" target="_self">
                            <asp:Label ID="lblBoardManage" runat="server" Text="Manage Board"></asp:Label>
                        </a></li>
                        <li><a href="../Admin/Medium.aspx" target="_self">
                            <asp:Label ID="lblMediumManage" runat="server" Text="Manage Medium"></asp:Label>
                        </a></li>
                        <li><a href="../Admin/Standard.aspx" target="_self">
                            <asp:Label ID="lblStandardManage" runat="server" Text="Manage Standard"></asp:Label>
                        </a></li>
                         <li><a href="../Admin/BMS.aspx" target="_self">
                            <asp:Label ID="lblBMSManage" runat="server" Text="Manage BMS"></asp:Label>
                        </a></li>
                        <li><a href="../Admin/Division.aspx" target="_self">
                            <asp:Label ID="lblDivisionManage" runat="server" Text="Manage Division"></asp:Label>
                        </a></li>
                        <li><a href="../Admin/Subject.aspx" target="_self">
                            <asp:Label ID="lblSubjectManage" runat="server" Text="Manage Subject"></asp:Label>
                        </a></li>
                        <li><a href="../Admin/Chapter.aspx" target="_self">
                            <asp:Label ID="lblChapterManage" runat="server" Text="Manage Chapter"></asp:Label>
                        </a></li>
                        <li><a href="../Admin/Topic.aspx" target="_self">
                            <asp:Label ID="lblTopicManage" runat="server" Text="Manage Topic"></asp:Label>
                        </a></li>
                        <li><a href="../Admin/District.aspx" target="_self">
                            <asp:Label ID="lblDistrictManage" runat="server" Text="Manage District"></asp:Label>
                        </a></li>
                        <li><a href="../Admin/State.aspx" target="_self">
                            <asp:Label ID="lblStateManage" runat="server" Text="Manage State"></asp:Label>
                        </a></li>
                        <li><a href="../Admin/Country.aspx" target="_self">
                            <asp:Label ID="lblCountryManage" runat="server" Text="Manage Country"></asp:Label>
                        </a></li>
                        <li><a href="../Admin/Role.aspx" target="_self">
                            <asp:Label ID="lblRoleManage" runat="server" Text="Manage Role"></asp:Label>
                        </a></li>
                        <li><a href="../Admin/SchoolType.aspx" target="_self">
                            <asp:Label ID="lblSchoolTypeManage" runat="server" Text="Manage SchoolType"></asp:Label>
                        </a></li>
                    </ul>
                </li>
            </ul>
        </div>
    </asp:View>
    <asp:View ID="ViewSdmin" runat="server">
        <div class="menu">
            <ul>
                <li class="round"><a href="../Dashboard/SchoolAdminDashboard.aspx">
                    <asp:Label ID="lblSadminDashboard" runat="server" Text="DashBoard" meta:resourceKey="lblSadminDashboardResource1"></asp:Label>
                </a></li>
                <li class="round"><a href="../UserManagement/UserList.aspx" target="_self">
                    <asp:Label ID="lblsadminUserList" runat="server" Text="User List" meta:resourceKey="lblsadminUserListResource1"></asp:Label>
                </a></li>
                <li class="round"><a href="../SchoolAdmin/TeacherClassAllocation.aspx" target="_self">
                    <asp:Label ID="lblSadminStdAllocation" runat="server" Text="Standard Allocation"
                        meta:resourceKey="lblSadminStdAllocationResource1"></asp:Label></a></li>
                <li class="round"><a href="../SchoolAdmin/ViewSchoolProfile.aspx" target="_self">
                    <asp:Label ID="lblSchoolProfile" runat="server" Text="School Profile" ToolTip="View/update School Profile"
                        meta:resourceKey="lblSchoolProfileResource1"></asp:Label></a></li>
                <li class="round"><a href="../Teacher/StudentAttendance.aspx" target="_self">
                    <asp:Label ID="lblStudentAttendance" runat="server" Text="Student Attendance" ToolTip="Student attendance"
                        meta:resourceKey="lblStudentAttendanceResource1"></asp:Label></a></li>
                <li class="round"><a href="../UserManagement/UserLogInOut.aspx" target="_self">
                    <asp:Label ID="lblSadminSessionOut" runat="server" Text="Logout user session" meta:resourceKey="lblEadminLogoutUserResource1"></asp:Label>
                </a></li>
            </ul>
        </div>
    </asp:View>
    <asp:View ID="ViewTeacher" runat="server">
        <div class="menu">
            <ul>
                <li class="round"><a href="../Dashboard/TeacherDashboard.aspx" target="_self">
                    <asp:Label ID="lblTeacherDashboard" runat="server" Text="Dashboard" meta:resourceKey="lblTeacherDashboardResource1"></asp:Label>
                </a></li>
                <li class="round"><a href="../UserManagement/UserList.aspx" target="_self">
                    <asp:Label ID="lblTeacherStdList" runat="server" Text="Student List" meta:resourceKey="lblTeacherStdListResource1"></asp:Label>
                </a></li>
                <li class="round"><a href="../Teacher/ReschedulingChapterTopic.aspx" target="_self">
                    <asp:Label ID="lblReschedulingChpTopic" runat="server" Text="Rescheduling"></asp:Label>
                </a></li>
            </ul>
        </div>
    </asp:View>
    <asp:View ID="ViewStudent" runat="server">
        <div class="menu">
            <ul>
                <li class="round"><a href="#" target="_self">
                    <asp:Label ID="lblStudDashboard" runat="server" Text="Dashboard" meta:resourceKey="lblStudDashboardResource1"></asp:Label>
                </a></li>
            </ul>
        </div>
    </asp:View>--%>
</asp:MultiView>