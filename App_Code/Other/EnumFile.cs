/// <summary>               
/// <Description>Summary description for EnumFile</Description>
/// <DevelopedBy>"Bhavesh Prajapati"</DevelopedBy>
/// <DevelopedDate>"01-Nov-2013"</DevelopedDate>
/// <UpdatedBy></UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class EnumFile
{
    public EnumFile()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Class contains Language ID
    /// </summary>
    public enum Language
    {
        English = 1,
        Gujarati = 2,
        Hindi = 3,
        Marathi = 4
    };

    /// <summary>
    /// Class contain topic status
    /// </summary>
    public enum Result
    {
        TopicCovered = 0,
        TopicNotCovered = 1,
        FileAdded = 1
    };

    /// <summary>
    /// Class contain table row status
    /// </summary>
    public enum TableRow
    {
        RowFound = 0,
        RowNotFound = 1
    };

    /// <summary>
    /// Class Contain ClassTeacher status
    /// </summary>
    public enum ClassTeacher
    {
        IsClassTeacher = 1,
        IsNotClassTeacher = 0
    };

    /// <summary>
    /// Class Contains School Status
    /// </summary>
    public enum Status
    {
        Appiled = 1,
        Approve = 2,
        Reject = 3,
        Active = 4,
        Deactive = 5
    };

    /// <summary>
    /// Class Contains AssignValue
    /// </summary>
    public enum AssignValue
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four= 4,
        Other
    };

    /// <summary>
    /// Class Contains Role ID
    /// </summary>
    public enum Role
    {
        Zero = 0,
        E_Admin = 1,
        S_Admin = 2,
        Teacher = 3,
        Student = 4,
        Parent= 16
    };

    /// <summary>
    /// Class Contains Chapter Status
    /// </summary>
    public enum Chapter
    {
        UnCoveredChapters = 1,
        CoveredChapters = 2
    };

    public enum TypeID
    {
        MultipleChoice = 1,
        ReArrange = 2,
        MatchFollowing = 3,
        Underline = 4,
        FillBank = 5,
        TrueFalse = 6,
        ChooseCorrectAnswer = 7,
        OneWordAnswer = 8,
        OneLineAnswer = 9
    };

    public enum SMTP
    {
        SMTPHOST,
        SMTPPORT,
        SMTPEmailAddress,
        USERNAME,
        PASSWORD,
        ENABLESSL
    };


    public enum ProblemType
    {
        [StringValue("Hardware Problem")]
        Hardware = 1,
        [StringValue("Software Problem")]
        Software = 2,
        [StringValue("Content Problem")]
        Content = 3

    }

    public enum Activity
    {
        [DescriptionAttribute("User already logged in.")]
        UserAlreadyLoggedIn,
        [DescriptionAttribute("Login successful")]
        LoginSuccess,
        [DescriptionAttribute("Login Failed")]
        LoginFailed,
        [DescriptionAttribute("Logout successful")]
        LogoutSuccess,

        [DescriptionAttribute("Activity selected for the classroom")]
        ActivitySelected,
        [DescriptionAttribute("Activity changed for the classroom")]
        ActivityChanged,

        [DescriptionAttribute("Activity started")]
        ActivityStarted,
        [DescriptionAttribute("Reset activity")]
        ResetActivity,
        [DescriptionAttribute("View attendance")]
        ViewAttendance,
        [DescriptionAttribute("Take attendance")]
        TakeAttendance,
        [DescriptionAttribute("Morning prayer started")]
        Morningprayer,
        [DescriptionAttribute("Evening prayer started")]
        Eveningprayer,
        [DescriptionAttribute("Quit morning/evening prayer")]
        Quitprayer,

        [DescriptionAttribute("Education resource page loaded")]
        EducationResourcePage,
        [DescriptionAttribute("All activity finished")]
        AllActivityFinished,
        [DescriptionAttribute("Activity closed")]
        ActivityClosed,

        [DescriptionAttribute("Exam entry page loaded")]
        ExamEntryPage,
        [DescriptionAttribute("Exam created successfully")]
        ExamCreatedSuccessfully,
        [DescriptionAttribute("Reset exam name")]
        ResetExamName,

        [DescriptionAttribute("Result entry page loaded")]
        ResultEntryPage,
        [DescriptionAttribute("Student list populated for the exam")]
        StudentListPopulatedForExam,
        [DescriptionAttribute("Reset exam result.")]
        ResetExamResult,
        [DescriptionAttribute("Exam result saved")]
        ExamResultSaved,
        [DescriptionAttribute("Exam result generated to PDF")]
        ExportToPDF,

        [DescriptionAttribute("Reschedule page loaded")]
        ReschedulePageLoad,
        [DescriptionAttribute("Rescheduling request submited")]
        ReschedulingRequestSubmited,
        [DescriptionAttribute("Reset rescheduling request")]
        ResetReschedulingRequest,

        [DescriptionAttribute("Redirected to package selection")]
        PackageSelection,

        [DescriptionAttribute("Session Started")]
        SessionStarted,
        [DescriptionAttribute("Session Ended")]
        SessionEnded,

        [DescriptionAttribute("Logged In")]
        LoggedIn,
        [DescriptionAttribute("Logged Out")]
        LoggedOut,

        [DescriptionAttribute("Subject Explored")]
        SubjectExplored,
        [DescriptionAttribute("Chapters/Topics Explored")]
        ChapterExplored,
        [DescriptionAttribute("Search Execute")]
        SearchExecute,
        [DescriptionAttribute(" Resource Explored")]
        ResourceExplored,

        [DescriptionAttribute("Accessed Profile Section of MyAccount Page")]
        MyAccountAccessedProfileSection,
        [DescriptionAttribute("Updated Profile Section")]
        MyAccountProfileSectionUpdated,
        [DescriptionAttribute("Cancelled Updating Profile Details")]
        MyAccountCancelEditupdateProfileSection,
        [DescriptionAttribute("Accessed Change Password Section of MyAccount")]
        AccessedMyAccountChangePassword,
        [DescriptionAttribute("Changed Password from MyAccount Change Password Section")]
        MyAccountChangedPassword
    }

    public enum AccessedPages
    {
        [DescriptionAttribute("Initial/Home Page is Loaded")]
        Homepage,
        [DescriptionAttribute("Student Dashboard Page")]
        StudentDashboard,
        [DescriptionAttribute("MyAccount Page")]
        AccessMyAccount,
        [DescriptionAttribute("About Us Page")]
        StudentPanelAboutUs,
        [DescriptionAttribute("Buy Package Page")]
        BuyPackage,
        [DescriptionAttribute("Report > Package Report Page")]
        StudentPackageReport,
        [DescriptionAttribute("Report > Exam Result Page")]
        StudentExamResult,
        [DescriptionAttribute("Privacy Policy Page")]
        StudentPrivacyPolicy,
        [DescriptionAttribute("Terms and Condition Page")]
        StudentTermsandCondition,
        [DescriptionAttribute("Cancellation Policy Page")]
        StudentCancellationPolicy,
        [DescriptionAttribute("FAQs Page")]
        StudentFAQs
    }
    public enum Events
    {
        [DescriptionAttribute("Load")]
        Load,
        [DescriptionAttribute("Clicked")]
        Click,
        [DescriptionAttribute("Double Click")]
        DoubleClick,
        [DescriptionAttribute("Mouse Hovered")]
        MouseHover
    }
}