using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HR_MS
{
    class DialyWorkersSalarySummary
    {
    public int EMPID { get; set; }
    public string EmployeeName { get; set; }
    public double Salary { get; set; }
    public double Deduction { get; set; }
    public double AttendanceDeduction { get; set; }
    public double NetSalary { get; set; }
    }
}
