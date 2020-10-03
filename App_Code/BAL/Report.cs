using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public class Report
{
    DataAccess Dal_Report;
    public DataSet GetClasswiseCoveredDetails()
    {
        this.Dal_Report = new DataAccess();
        return this.Dal_Report.DAL_SelectALL("Proc_ClasswiseCoveredSyllabus");
    }
}
