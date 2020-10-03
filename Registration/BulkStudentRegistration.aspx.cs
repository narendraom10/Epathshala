using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Xml;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Text;

public partial class Registration_BulkStudentRegistration : System.Web.UI.Page
{
    #region Declaration

    Student_BLogic BAL_Student;
    SYS_BMS_BLogic SYS_BMSBLogic;
    OleDbConnection oledbConn;

    #endregion

    #region Page Load Method

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetBMSTableInViewstate();
            SetDivisionTableInViewState();
        }
    }

    #endregion

    #region Control Event

    protected void btndownload_Click(object sender, EventArgs e)
    {
        string FilePath = Server.MapPath("~/Documents");
        string FileName = "Student_Template_" + DateTime.Now.ToString("ddMMyyyhhmmss") + ".xls";

        Application xlsApp = new Application();
        Workbook xlsWorkbook;
        Worksheet xlsWorksheet;
        object oMissing = System.Reflection.Missing.Value;

        //Create new workbook
        xlsWorkbook = xlsApp.Workbooks.Add(true);

        //Get the first worksheet
        xlsWorksheet = (Worksheet)(xlsWorkbook.Worksheets[1]);

        CreateHeader(xlsWorksheet);

        SetBMSValue(xlsWorksheet);
        SetMaleFemaleValue(xlsWorksheet);
        SetDivValue(xlsWorksheet);


        xlsApp.DisplayAlerts = false;
        xlsWorkbook.Close(true, Path.Combine(FilePath, FileName), null);
        xlsApp.Quit();

        xlsWorksheet = null;
        xlsWorkbook = null;
        xlsApp = null;

        FileInfo file = new FileInfo(Path.Combine(FilePath, FileName));
        if (file.Exists)
        {
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=" + FileName);
            Response.AddHeader("Content-Type", "application/Excel");
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.WriteFile(file.FullName);
            Response.End();
        }
        else
        {
            Response.Write("This file does not exist.");
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if ((fufile.PostedFile != null) && (fufile.PostedFile.ContentLength > 0))
        {
            string savefilepath = Server.MapPath("~/Documents");
            string savefilename = fufile.PostedFile.FileName;
            string savefilefullpath = Path.Combine(savefilepath, savefilename);
            fufile.PostedFile.SaveAs(savefilefullpath);

            string path = System.IO.Path.GetFullPath(savefilefullpath);
            if (Path.GetExtension(path) == ".xls")
            {
                oledbConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;");
            }
            else if (Path.GetExtension(path) == ".xlsx")
            {
                oledbConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1;\";");
            }
            oledbConn.Open();
            OleDbCommand cmd = new OleDbCommand();

            cmd.Connection = oledbConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Sheet1$]";

            DataSet ds = new DataSet();

            OleDbDataAdapter oleda = new OleDbDataAdapter(cmd);
            oleda.Fill(ds);

            for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
            {
                if (ds.Tables[0].Rows[i][1] == DBNull.Value && ds.Tables[0].Rows[i][2] == DBNull.Value)
                {
                    ds.Tables[0].Rows[i].Delete();
                }
            }
            ds.Tables[0].Rows[0].Delete();
            ds.Tables[0].Rows[1].Delete();
            ds.Tables[0].Rows[2].Delete();

            ds.Tables[0].AcceptChanges();

            ViewState["IsValid"] = true;

            grvData.DataSource = ds.Tables[0];
            grvData.DataBind();

            btnImport.Visible = true;

            ViewState["ImportTable"] = ds.Tables[0];

            oledbConn.Close();

            gvresult.Visible = false;
        }
    }
    protected void grvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string BMS = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BMS"));
            string Division = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Division"));
            string FirstName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FirstName"));
            string ContactNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ContactNo"));
            string MobileNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo"));
            string Email = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EmailID"));
            string RollNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RollNo"));
            string DateOfBirth = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DateOfBirth"));

            Regex regex = new Regex(@"\d{8,12}");
            if (!string.IsNullOrEmpty(ContactNo))
            {
                Match matchcn = regex.Match(ContactNo);
                if (!matchcn.Success)
                {
                    e.Row.Cells[8].Style["background"] = "red";
                    ViewState["IsValid"] = false;
                }
            }

            if (!string.IsNullOrEmpty(MobileNo))
            {
                Match matchmn = regex.Match(MobileNo);
                if (!matchmn.Success)
                {
                    e.Row.Cells[9].Style["background"] = "red";
                    ViewState["IsValid"] = false;
                }
            }

            Regex regexemail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!string.IsNullOrEmpty(MobileNo))
            {
                Match matchem = regexemail.Match(Email);
                if (!matchem.Success)
                {
                    e.Row.Cells[10].Style["background"] = "red";
                    ViewState["IsValid"] = false;
                }
            }

            Regex regexnumber = new Regex(@"\d{1,10}");
            if (!string.IsNullOrEmpty(RollNo))
            {
                Match matchrn = regexnumber.Match(RollNo);
                if (!matchrn.Success)
                {
                    e.Row.Cells[7].Style["background"] = "red";
                    ViewState["IsValid"] = false;
                }
            }

            if (!string.IsNullOrEmpty(DateOfBirth))
            {
                DateTime dt;
                if (DateTime.TryParse(DateOfBirth, out dt))
                {
                    System.Web.UI.WebControls.Label lbldateofbirth = (System.Web.UI.WebControls.Label)e.Row.FindControl("GV_LblGRDateOfBirth");
                    lbldateofbirth.Text = dt.ToString("dd-MMM-yyyy");
                }
                else
                {
                    e.Row.Cells[12].Style["background"] = "red";
                    ViewState["IsValid"] = false;
                }
            }

            if (string.IsNullOrEmpty(BMS))
            {
                e.Row.Cells[1].Style["background"] = "red";
                ViewState["IsValid"] = false;
            }

            if (string.IsNullOrEmpty(Division))
            {
                e.Row.Cells[2].Style["background"] = "red";
                ViewState["IsValid"] = false;
            }

            if (string.IsNullOrEmpty(FirstName))
            {
                e.Row.Cells[3].Style["background"] = "red";
                ViewState["IsValid"] = false;
            }
        }
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(ViewState["IsValid"]))
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = (System.Data.DataTable)ViewState["ImportTable"];
            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                sb.Append("(" + AppSessions.SchoolID + "," + GetBMSID(Convert.ToString(row["BMS"])) + "," + GetDivisionID(Convert.ToString(row["Division"])) + ",Null," + Rim(Convert.ToString(row["FirstName"]), true) + "," + Rim(Convert.ToString(row["MiddleName"]), true) + "," + Rim(Convert.ToString(row["LastName"]), true) + "," + Rim(Convert.ToString(row["Address"]), true) + "," + CheckNull(Convert.ToString(row["RollNo"])) + "," + CheckNull(Convert.ToString(row["ContactNo"])) + "," + CheckNull(Convert.ToString(row["MobileNo"])) + "," + Rim(Convert.ToString(row["EmailID"])) + "," + Rim(Convert.ToString(row["GRNo"])) + "," + ((!string.IsNullOrEmpty(Convert.ToString(row["DateOfBirth"]))) ? Rim(Convert.ToDateTime(row["DateOfBirth"]).ToString("dd-MMM-yyyy")) : "Null") + "," + Rim(GetMaleFemaleChar(Convert.ToString(row["Gender"]).ToLower())) + "," + Rim(Convert.ToString(row["BloodGroup"]), true) + "," + AppSessions.EmpolyeeID + "),");
            }
            string InsertStatement = sb.ToString().Remove(sb.ToString().Length - 1, 1);

            BAL_Student = new Student_BLogic();

            DataSet dsResult = BAL_Student.Insert_Student_Bulk(InsertStatement);

            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    ViewState["dsResult"] = dsResult.Tables[0];

                    gvresult.Visible = true;
                    gvresult.DataSource = dsResult.Tables[0];
                    gvresult.DataBind();
                    mdlresult.Show();
                }
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Student has been imported failed.');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Student has been imported failed.');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please resolve the red cell data in excel and try again.');", true);
        }
    }
    protected void btnDownloadExcel_Click(object sender, EventArgs e)
    {
        UploadDataTableToExcel((System.Data.DataTable)ViewState["dsResult"], "StudentImportResult.xls");
    }


    #endregion

    #region UserDefine Method

    /// <summary>
    /// Create Header of Excel sheet.
    /// </summary>
    private void CreateHeader(Worksheet xlsWorksheet)
    {
        xlsWorksheet.Range["A1"].Value = "Particular";
        xlsWorksheet.Range["A1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGreen));
        Microsoft.Office.Interop.Excel.Range erA = xlsWorksheet.get_Range("A:A", System.Type.Missing);
        erA.ColumnWidth = 30;

        xlsWorksheet.Range[xlsWorksheet.Cells[4, 1], xlsWorksheet.Cells[4, 8]].Merge();
        xlsWorksheet.Range[xlsWorksheet.Cells[4, 1], xlsWorksheet.Cells[4, 8]].Value = "Start putting data from row no 5";
        xlsWorksheet.Range[xlsWorksheet.Cells[4, 1], xlsWorksheet.Cells[4, 8]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        xlsWorksheet.Range[xlsWorksheet.Cells[4, 1], xlsWorksheet.Cells[4, 15]].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.Green));
        xlsWorksheet.Range[xlsWorksheet.Cells[4, 1], xlsWorksheet.Cells[4, 15]].Font.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.White));

        xlsWorksheet.Range["A2"].Value = "Type";
        xlsWorksheet.Range["A2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGreen));
        xlsWorksheet.Range["A3"].Value = "Optional or Mandatory(O/M)";
        xlsWorksheet.Range["A3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGreen));

        xlsWorksheet.Range["B1"].Value = "BMS";
        xlsWorksheet.Range["B1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));
        xlsWorksheet.Range["B1"].RowHeight = 30;
        Microsoft.Office.Interop.Excel.Range erB = xlsWorksheet.get_Range("B:B", System.Type.Missing);
        erB.ColumnWidth = 50;
        xlsWorksheet.Range["B2"].Value = "List";
        xlsWorksheet.Range["B2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGray));
        xlsWorksheet.Range["B3"].Value = "Mandatory";
        xlsWorksheet.Range["B3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.Red));


        xlsWorksheet.Range["C1"].Value = "Division";
        xlsWorksheet.Range["C1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));
        Microsoft.Office.Interop.Excel.Range erC = xlsWorksheet.get_Range("C:C", System.Type.Missing);
        erC.ColumnWidth = 15;
        xlsWorksheet.Range["C2"].Value = "List";
        xlsWorksheet.Range["C2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGray));
        xlsWorksheet.Range["C3"].Value = "Mandatory";
        xlsWorksheet.Range["C3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.Red));

        xlsWorksheet.Range["D1"].Value = "FirstName";
        xlsWorksheet.Range["D1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));
        Microsoft.Office.Interop.Excel.Range erD = xlsWorksheet.get_Range("D:D", System.Type.Missing);
        erD.ColumnWidth = 22;
        xlsWorksheet.Range["D2"].Value = "Input(Max-60 Character)";
        xlsWorksheet.Range["D2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGray));
        xlsWorksheet.Range["D3"].Value = "Mandatory";
        xlsWorksheet.Range["D3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.Red));

        xlsWorksheet.Range["E1"].Value = "MiddleName";
        xlsWorksheet.Range["E1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));
        Microsoft.Office.Interop.Excel.Range erE = xlsWorksheet.get_Range("E:E", System.Type.Missing);
        erE.ColumnWidth = 22;
        xlsWorksheet.Range["E2"].Value = "Input(Max-60 Character)";
        xlsWorksheet.Range["E2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGray));
        xlsWorksheet.Range["E3"].Value = "Optional";
        xlsWorksheet.Range["E3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));


        xlsWorksheet.Range["F1"].Value = "LastName";
        xlsWorksheet.Range["F1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));
        Microsoft.Office.Interop.Excel.Range erF = xlsWorksheet.get_Range("F:F", System.Type.Missing);
        erF.ColumnWidth = 22;
        xlsWorksheet.Range["F2"].Value = "Input(Max-60 Character]";
        xlsWorksheet.Range["F2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGray));
        xlsWorksheet.Range["F3"].Value = "Optional";
        xlsWorksheet.Range["F3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));

        xlsWorksheet.Range["G1"].Value = "Address";
        xlsWorksheet.Range["G1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));
        Microsoft.Office.Interop.Excel.Range erG = xlsWorksheet.get_Range("G:G", System.Type.Missing);
        erG.ColumnWidth = 22;
        xlsWorksheet.Range["G2"].Value = "Input(Max-255 Character)";
        xlsWorksheet.Range["G2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGray));
        xlsWorksheet.Range["G3"].Value = "Optional";
        xlsWorksheet.Range["G3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));

        xlsWorksheet.Range["H1"].Value = "RollNo";
        xlsWorksheet.Range["H1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));
        Microsoft.Office.Interop.Excel.Range erH = xlsWorksheet.get_Range("H:H", System.Type.Missing);
        erH.ColumnWidth = 22;
        xlsWorksheet.Range["H2"].Value = "Input(Small-Integer)";
        xlsWorksheet.Range["H2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGray));
        xlsWorksheet.Range["H3"].Value = "Optional";
        xlsWorksheet.Range["H3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));

        xlsWorksheet.Range["I1"].Value = "ContactNo";
        xlsWorksheet.Range["I1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));
        Microsoft.Office.Interop.Excel.Range erI = xlsWorksheet.get_Range("I:I", System.Type.Missing);
        erI.ColumnWidth = 22;
        xlsWorksheet.Range["I2"].Value = "Input(Number)";
        xlsWorksheet.Range["I2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGray));
        xlsWorksheet.Range["I3"].Value = "Optional";
        xlsWorksheet.Range["I3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));

        xlsWorksheet.Range["J1"].Value = "MobileNo";
        xlsWorksheet.Range["J1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));
        Microsoft.Office.Interop.Excel.Range erJ = xlsWorksheet.get_Range("J:J", System.Type.Missing);
        erJ.ColumnWidth = 30;
        xlsWorksheet.Range["J2"].Value = "Input(Communication Number)";
        xlsWorksheet.Range["J2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGray));
        xlsWorksheet.Range["J3"].Value = "Optional";
        xlsWorksheet.Range["J3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));

        xlsWorksheet.Range["K1"].Value = "EmailID";
        xlsWorksheet.Range["K1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));
        Microsoft.Office.Interop.Excel.Range erK = xlsWorksheet.get_Range("K:K", System.Type.Missing);
        erK.ColumnWidth = 22;
        xlsWorksheet.Range["K2"].Value = "Input(Max-100 Character)";
        xlsWorksheet.Range["K2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGray));
        xlsWorksheet.Range["K3"].Value = "Optional";
        xlsWorksheet.Range["K3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));

        xlsWorksheet.Range["L1"].Value = "GRNo";
        xlsWorksheet.Range["L1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));
        Microsoft.Office.Interop.Excel.Range erL = xlsWorksheet.get_Range("L:L", System.Type.Missing);
        erL.ColumnWidth = 22;
        xlsWorksheet.Range["L2"].Value = "Input(Max-20 Character)";
        xlsWorksheet.Range["L2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGray));
        xlsWorksheet.Range["L3"].Value = "Optional";
        xlsWorksheet.Range["L3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));

        xlsWorksheet.Range["M1"].Value = "DateOfBirth";
        xlsWorksheet.Range["M1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));
        Microsoft.Office.Interop.Excel.Range erM = xlsWorksheet.get_Range("M:M", System.Type.Missing);
        erM.ColumnWidth = 22;
        erM.EntireColumn.NumberFormat = "dd-MMM-yyyy";
        xlsWorksheet.Range["M2"].Value = "Input(dd-MMM-yyyy)";
        xlsWorksheet.Range["M2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGray));
        xlsWorksheet.Range["M3"].Value = "Optional";
        xlsWorksheet.Range["M3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));

        xlsWorksheet.Range["N1"].Value = "Gender";
        xlsWorksheet.Range["N1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));
        Microsoft.Office.Interop.Excel.Range erN = xlsWorksheet.get_Range("N:N", System.Type.Missing);
        erN.ColumnWidth = 15;
        xlsWorksheet.Range["N2"].Value = "List";
        xlsWorksheet.Range["N2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGray));
        xlsWorksheet.Range["N3"].Value = "Optional";
        xlsWorksheet.Range["N3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));

        xlsWorksheet.Range["O1"].Value = "BloodGroup";
        xlsWorksheet.Range["O1"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));
        Microsoft.Office.Interop.Excel.Range erO = xlsWorksheet.get_Range("O:O", System.Type.Missing);
        erO.ColumnWidth = 22;
        xlsWorksheet.Range["O2"].Value = "Input(Max-6 Character)";
        xlsWorksheet.Range["O2"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightGray));
        xlsWorksheet.Range["O3"].Value = "Optional";
        xlsWorksheet.Range["O3"].Interior.Color = System.Drawing.ColorTranslator.ToOle((System.Drawing.Color.LightSkyBlue));

        SetBorder(xlsWorksheet);

    }

    private static void SetBorder(Worksheet xlsWorksheet)
    {
        for (int i = 1; i <= 4; i++)
        {
            for (char c = 'A'; c <= 'O'; c++)
            {
                xlsWorksheet.Range["" + Convert.ToString(c) + "" + i + ""].BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
                Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin,
                Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
                Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
            }
        }
    }

    /// <summary>
    /// Set BMS Value in XX column of excel sheet.
    /// </summary>
    private void SetBMSValue(Worksheet xlsWorksheet)
    {
        SYS_BMS_BLogic BSysBMS = new SYS_BMS_BLogic();
        DataSet dsBMS = new DataSet();

        dsBMS = BSysBMS.BAL_SYS_BMS_SelectAllBySchoolID(AppSessions.SchoolID);
        if (dsBMS.Tables[0].Rows.Count > 0)
        {
            int i = 1;
            foreach (DataRow oDr in dsBMS.Tables[0].Rows)
            {
                xlsWorksheet.Range["XX" + i + ""].Value = Convert.ToString(oDr["BMS"]);
                i++;
            }
        }
        SetBMSDropDown(xlsWorksheet, dsBMS.Tables[0].Rows.Count);
    }

    /// <summary>
    /// Set BMS Value at A2:A65536 column of excel sheet.
    /// </summary>
    private static void SetBMSDropDown(Worksheet xlsWorksheet, int count)
    {
        string formula = "='Sheet1'!$XX$1:$XX$" + count;
        xlsWorksheet.Range["B5:B65536"].Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertStop,
                         Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, formula, Type.Missing);
    }

    /// <summary>
    /// Set Male-Female Value in YY column of excel sheet.
    /// </summary>
    private void SetMaleFemaleValue(Worksheet xlsWorksheet)
    {
        xlsWorksheet.Range["YY1"].Value = "Male";
        xlsWorksheet.Range["YY2"].Value = "Female";
        SetMaleFemaleDropDown(xlsWorksheet);
    }

    /// <summary>
    /// Set BMS Value at M2:M65536 column of excel sheet.
    /// </summary>
    private static void SetMaleFemaleDropDown(Worksheet xlsWorksheet)
    {
        string formula = "='Sheet1'!$YY$1:$YY$2";
        xlsWorksheet.Range["N5:N65536"].Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertStop,
                             Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, formula, Type.Missing);
    }

    /// <summary>
    /// Set Division Value in ZZ column of excel sheet.
    /// </summary>
    private static void SetDivValue(Worksheet xlsWorksheet)
    {
        SYS_BMS_BLogic BSysBMS = new SYS_BMS_BLogic();
        DataSet dsDivision = new DataSet();

        dsDivision = BSysBMS.BAL_SYS_BMS_FillDivisionBySchoolBMSID(AppSessions.SchoolID);
        if (dsDivision.Tables[0].Rows.Count > 0)
        {
            int i = 1;
            foreach (DataRow oDr in dsDivision.Tables[0].Rows)
            {
                xlsWorksheet.Range["ZZ" + i + ""].Value = Convert.ToString(oDr["Division"]);
                i++;
            }
        }
        SeDivisionDropDown(xlsWorksheet, dsDivision.Tables[0].Rows.Count);
    }

    /// <summary>
    /// Set BMS Value at B2:B65536 column of excel sheet.
    /// </summary>
    private static void SeDivisionDropDown(Worksheet xlsWorksheet, int count)
    {
        string formula = "='Sheet1'!$ZZ$1:$ZZ$" + count;
        xlsWorksheet.Range["C5:C65536"].Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertStop,
                             Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, formula, Type.Missing);
    }

    /// <summary>
    /// ' Solution and add '' around string and append N if IsUnicode=true, default value of IsUnicode=false.
    /// </summary>
    public string Rim(string strRim, bool IsUnicode = false)
    {
        try
        {
            strRim = "'" + strRim.Trim().Replace("'", "''") + "'";
            strRim = (IsUnicode == true) ? "N" + strRim : strRim;
            return strRim;
        }
        catch (Exception)
        {
            return "''";
        }
    }

    /// <summary>
    /// Return M if pass value Male, Return F if pass value Female.
    /// </summary>
    private string GetMaleFemaleChar(string Full)
    {
        string MFChar = string.Empty;

        if (Full.ToLower() == "male")
            MFChar = "M";
        else if (Full.ToLower() == "female")
            MFChar = "F";

        return MFChar;
    }

    /// <summary>
    /// Input BMS string and return BMSID.
    /// </summary>
    public string GetBMSID(string BMS)
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        dt = (System.Data.DataTable)ViewState["BMSTable"];
        DataRow[] dr = ((System.Data.DataTable)ViewState["BMSTable"]).Select("BMS = '" + BMS + "'");
        return Convert.ToString(dr[0]["BMSID"]);
    }

    /// <summary>
    /// Input Division string and return DivisionID.
    /// </summary>
    public string GetDivisionID(string Division)
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        dt = (System.Data.DataTable)ViewState["DivisionTable"];
        DataRow[] dr = ((System.Data.DataTable)ViewState["DivisionTable"]).Select("Division = '" + Division + "'");
        return Convert.ToString(dr[0]["DivisionID"]);
    }

    /// <summary>
    ///Set Division Table in Viewstate
    /// </summary>
    private void SetDivisionTableInViewState()
    {
        SYS_BMSBLogic = new SYS_BMS_BLogic();
        DataSet dsDivision = new DataSet();
        dsDivision = SYS_BMSBLogic.BAL_SYS_BMS_FillDivisionBySchoolBMSID(AppSessions.SchoolID);
        ViewState["DivisionTable"] = dsDivision.Tables[0];
    }

    /// <summary>
    ///Set BMS Table in Viewstate           
    /// </summary>
    private void SetBMSTableInViewstate()
    {
        SYS_BMSBLogic = new SYS_BMS_BLogic();
        DataSet dsselectBMS = new DataSet();
        dsselectBMS = SYS_BMSBLogic.BAL_SYS_BMS_SelectAllBySchoolID(AppSessions.SchoolID);
        ViewState["BMSTable"] = dsselectBMS.Tables[0];
    }

    /// <summary>
    ///Export Datatable as excel
    /// </summary>
    protected void UploadDataTableToExcel(System.Data.DataTable dtEmp, string filename)
    {
        string attachment = "attachment; filename=" + filename;
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";

        string tab = string.Empty;
        foreach (DataColumn dtcol in dtEmp.Columns)
        {
            Response.Write(tab + dtcol.ColumnName);
            tab = "\t";
        }
        Response.Write("\n");
        foreach (DataRow dr in dtEmp.Rows)
        {
            tab = "";
            for (int j = 0; j < dtEmp.Columns.Count; j++)
            {
                Response.Write(tab + Convert.ToString(dr[j]));
                tab = "\t";
            }
            Response.Write("\n");
        }
        Response.End();
    }

    private string CheckNull(string p)
    {
        if (!string.IsNullOrEmpty(p))
            return p;
        else
            return "Null";

    }

    #endregion
}