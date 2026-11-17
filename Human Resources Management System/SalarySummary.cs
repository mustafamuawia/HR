using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HR_MS
{
    class SalarySummary
    {
    public int EMPID { get; set; }
    public string EmployeeName { get; set; }
    public double AllowancesTotal { get; set; }
    public double DeductionsTotal { get; set; }
    public double NetSalary { get; set; }
    }
}
