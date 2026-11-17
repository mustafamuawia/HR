using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HR_MS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void AddEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmHireEmployee"] != null)
                Application.OpenForms["frmHireEmployee"].Focus();
            else if (Application.OpenForms["frmHireEmployee"] == null)
            {
                frmHireEmployee frmHire = new frmHireEmployee();


                frmHire.Show();
                frmHire.MdiParent = this;
                frmHire.WindowState = FormWindowState.Maximized;

            }

        }

        private void DatabaseSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmDatabaseSettings"] != null)
                Application.OpenForms["frmDatabaseSettings"].Focus();
            else if (Application.OpenForms["frmDatabaseSettings"] == null)
            {
                frmDatabaseSettings frmDBSet = new frmDatabaseSettings();
                frmDBSet.Show();
                frmDBSet.MdiParent = this;
                frmDBSet.WindowState = FormWindowState.Maximized;



            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void EditEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEditEmployeeFile"] != null)
                Application.OpenForms["frmEditEmployeeFile"].Focus();
            else if (Application.OpenForms["frmEditEmployeeFile"] == null)
            {
                frmEditEmployeeFile frmEditEmpFile = new frmEditEmployeeFile();
                frmEditEmpFile.Show();
                frmEditEmpFile.MdiParent = this;
                frmEditEmpFile.WindowState = FormWindowState.Maximized;
            }

        }

        private void AddjobToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddNewDeptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAddDepartment"] != null)
                Application.OpenForms["frmAddDepartment"].Focus();
            else if (Application.OpenForms["frmAddDepartment"] == null)
            {
                frmAddDepartment frmAddDept = new frmAddDepartment();
                frmAddDept.Show();
                frmAddDept.MdiParent = this;
                frmAddDept.WindowState = FormWindowState.Maximized;
            }
        }

        private void EditDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEditDepartment"] != null)
                Application.OpenForms["frmEditDepartment"].Focus();
            else if (Application.OpenForms["frmEditDepartment"] == null)
            {
                frmEditDepartment frmAddDept = new frmEditDepartment();
                frmAddDept.Show();
                frmAddDept.MdiParent = this;
                frmAddDept.WindowState = FormWindowState.Maximized;
            }
        }


        private void EditJobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEditJobs"] != null)
                Application.OpenForms["frmEditJobs"].Focus();
            else if (Application.OpenForms["frmEditJobs"] == null)
            {
                frmEditJobs frmEditJbs = new frmEditJobs();
                frmEditJbs.Show();
                frmEditJbs.MdiParent = this;
                frmEditJbs.WindowState = FormWindowState.Maximized;
            }
        }

        private void AllowancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAllowancesManagement"] != null)
                Application.OpenForms["frmAllowancesManagement"].Focus();
            else if (Application.OpenForms["frmAllowancesManagement"] == null)
            {
                frmAllowancesManagementSecond frmAllowncesMng2nd = new frmAllowancesManagementSecond();
                frmAllowncesMng2nd.Show();
                frmAllowncesMng2nd.MdiParent = this;
                frmAllowncesMng2nd.WindowState = FormWindowState.Maximized;
            }
        }

        private void AddJobToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAddJob"] != null)
                Application.OpenForms["frmAddJob"].Focus();
            else if (Application.OpenForms["frmAddJob"] == null)
            {
                frmAddJob frmAddJb = new frmAddJob();

                frmAddJb.Show();

                frmAddJb.MdiParent = this;
                frmAddJb.WindowState = FormWindowState.Maximized;
            }
        }

        private void DeductionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmDeductionsManagementSecond"] != null)
                Application.OpenForms["frmDeductionsManagementSecond"].Focus();
            else if (Application.OpenForms["frmDeductionsManagementSecond"] == null)
            {
                frmDeductionsManagementSecond frmDeductionsMng2nd = new frmDeductionsManagementSecond();
                frmDeductionsMng2nd.Show();
                frmDeductionsMng2nd.MdiParent = this;
                frmDeductionsMng2nd.WindowState = FormWindowState.Maximized;
            }
        }

        private void EmployeesAllowancesManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEmployeesAllowancesFirst"] != null)
                Application.OpenForms["frmEmployeesAllowancesFirst"].Focus();
            else if (Application.OpenForms["frmEmployeesAllowancesFirst"] == null)
            {
                frmEmployeesAllowancesFirst frmAllowances1st = new frmEmployeesAllowancesFirst();
                frmAllowances1st.Show();
                frmAllowances1st.MdiParent = this;
                frmAllowances1st.WindowState = FormWindowState.Maximized;
            }
        }

        private void DeductionsAdjustToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEmployeesDeductionsFirst"] != null)
                Application.OpenForms["frmEmployeesDeductionsFirst"].Focus();
            else if (Application.OpenForms["frmEmployeesDeductionsFirst"] == null)
            {
                frmEmployeesDeductionsFirst frmDeductions = new frmEmployeesDeductionsFirst();
                frmDeductions.Show();
                frmDeductions.MdiParent = this;
                frmDeductions.WindowState = FormWindowState.Maximized;
            }
        }

        private void SalariesPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrintSalariesFirst frmPrintSal = new frmPrintSalariesFirst();
            frmPrintSal.ShowDialog();
        }

        private void DeleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmDeleteEmployee"] != null)
                Application.OpenForms["frmDeleteEmployee"].Focus();
            else if (Application.OpenForms["frmDeleteEmployee"] == null)
            {
                frmDeleteEmployee frmDelete = new frmDeleteEmployee();
                frmDelete.Show();
                frmDelete.MdiParent = this;
                frmDelete.WindowState = FormWindowState.Maximized;
            }
        }

        private void AddDialyWorkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAddDialyWorkers"] != null)
                Application.OpenForms["frmAddDialyWorkers"].Focus();
            else if (Application.OpenForms["frmAddDialyWorkers"] == null)
            {
                frmAddDialyWorkers frmDAddDialyWrkers = new frmAddDialyWorkers();
                frmDAddDialyWrkers.Show();
                frmDAddDialyWrkers.MdiParent = this;
                frmDAddDialyWrkers.WindowState = FormWindowState.Maximized;
            }
        }

        private void DialyWorkersSalariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmDialyWorkersAllowances"] != null)
                Application.OpenForms["frmDialyWorkersAllowances"].Focus();
            else if (Application.OpenForms["frmDialyWorkersAllowances"] == null)
            {
                frmDialyWorkersAllowances frmDAddDialyWrkersSal = new frmDialyWorkersAllowances();
                frmDAddDialyWrkersSal.Show();
                frmDAddDialyWrkersSal.MdiParent = this;
                frmDAddDialyWrkersSal.WindowState = FormWindowState.Maximized;
            }
        }

        private void PrintDaialyWorkersSalariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrintDialyworkersSalaries frmPrintDialyWrkrsSal = new frmPrintDialyworkersSalaries();
            frmPrintDialyWrkrsSal.ShowDialog();
        }

        private void MonthIncentiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrintEmployeesMonthlyIncentive frmPrintMonthIncentive = new frmPrintEmployeesMonthlyIncentive();
            frmPrintMonthIncentive.ShowDialog();

        }

        private void FirstPartAllowancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAllowancesManagementFirst"] != null)
                Application.OpenForms["frmAllowancesManagementFirst"].Focus();
            else if (Application.OpenForms["frmAllowancesManagementFirst"] == null)
            {
                frmAllowancesManagementFirst frmAllowncesMng1st = new frmAllowancesManagementFirst();
                frmAllowncesMng1st.Show();
                frmAllowncesMng1st.MdiParent = this;
                frmAllowncesMng1st.WindowState = FormWindowState.Maximized;
            }
        }

        private void SecondPartMonthIncentiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrintTempMonthlyIncentive frmPrintMonthIncentive = new frmPrintTempMonthlyIncentive();
            frmPrintMonthIncentive.ShowDialog();
        }

        private void FirstPartDeductionsManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmDeductionsManagement"] != null)
                Application.OpenForms["frmDeductionsManagement"].Focus();
            else if (Application.OpenForms["frmDeductionsManagement"] == null)
            {
                frmDeductionsManagementFirst frmDeductionsMng1st = new frmDeductionsManagementFirst();
                frmDeductionsMng1st.Show();
                frmDeductionsMng1st.MdiParent = this;
                frmDeductionsMng1st.WindowState = FormWindowState.Maximized;
            }
        }

        private void SecondPartEditEmployeesAllowancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEmployeesAllowancesSecond"] != null)
                Application.OpenForms["frmEmployeesAllowancesSecond"].Focus();
            else if (Application.OpenForms["frmEmployeesAllowancesSecond"] == null)
            {
                frmEmployeesAllowancesSecond frmAllowances2nd = new frmEmployeesAllowancesSecond();
                frmAllowances2nd.Show();
                frmAllowances2nd.MdiParent = this;
                frmAllowances2nd.WindowState = FormWindowState.Maximized;
            }
        }

        private void SecondPartEditEmployeesDeductionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEmployeesDeductionsSecond"] != null)
                Application.OpenForms["frmEmployeesDeductionsSecond"].Focus();
            else if (Application.OpenForms["frmEmployeesDeductionsSecond"] == null)
            {
                frmEmployeesDeductionsSecond frmDeductions2nd = new frmEmployeesDeductionsSecond();
                frmDeductions2nd.Show();
                frmDeductions2nd.MdiParent = this;
                frmDeductions2nd.WindowState = FormWindowState.Maximized;
            }

        }

        private void AttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEmployeesAttendanceFirst"] != null)
                Application.OpenForms["frmEmployeesAttendanceFirst"].Focus();
            else if (Application.OpenForms["frmEmployeesAttendanceFirst"] == null)
            {
                frmEmployeesAttendanceFirst frmAttendance1st = new frmEmployeesAttendanceFirst();
                frmAttendance1st.Show();
                frmAttendance1st.MdiParent = this;
                frmAttendance1st.WindowState = FormWindowState.Maximized;
            }
        }

        private void TempAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEmployeesAttendanceSecond"] != null)
                Application.OpenForms["frmEmployeesAttendanceSecond"].Focus();
            else if (Application.OpenForms["frmEmployeesAttendanceSecond"] == null)
            {
                frmEmployeesAttendanceSecond frmAttendance2nd = new frmEmployeesAttendanceSecond();
                frmAttendance2nd.Show();
                frmAttendance2nd.MdiParent = this;
                frmAttendance2nd.WindowState = FormWindowState.Maximized;
            }
        }

        private void DialyWorkersAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmDialyworkersAttendance"] != null)
                Application.OpenForms["frmDialyworkersAttendance"].Focus();
            else if (Application.OpenForms["frmDialyworkersAttendance"] == null)
            {
                frmDialyworkersAttendance frmDialywrkrsAttendance = new frmDialyworkersAttendance();
                frmDialywrkrsAttendance.Show();
                frmDialywrkrsAttendance.MdiParent = this;
                frmDialywrkrsAttendance.WindowState = FormWindowState.Maximized;
            }
        }

        private void TempSalariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrintSalariesSecond frmSalaries2nd = new frmPrintSalariesSecond();
            frmSalaries2nd.ShowDialog();


        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            List<string> Tables = new List<string>();
            Tables.Add("AllowancesFirst");
            Tables.Add("AllowancesSecond");
            Tables.Add("DeductionsFirst");
            Tables.Add("DeductionsSecond");
            Tables.Add("AttendanceFirst");
            Tables.Add("AttendanceSecond");
//            UPDATE db_owner.AllowancesFirst
//SET db_owner.AllowancesFirst.المرتب_الأساسي = a.المرتب_الأساسي,
//db_owner.AllowancesFirst.غلاء_المعيشة = a.غلاء_المعيشة,
//db_owner.AllowancesFirst.بدل_سكن = a.بدل_سكن,
//db_owner.AllowancesFirst.بدل_الترحيل = a.بدل_الترحيل,
//db_owner.AllowancesFirst.حافز_نصف_شهري = a.حافز_نصف_شهري,
//db_owner.AllowancesFirst.منحة = a.منحة
//--db_owner.AllowancesFirst.حافز_اداء = a.حافز_اداء
//FROM db_owner.AllowancesFirst 
//INNER JOIN
//db_owner.Allowancessecond as a on  
//db_owner.AllowancesFirst.رقم_الموظف =  a.رقم_الموظف
//where a.الشهر = 'اغسطس'
//--and db_owner.AllowancesFirst.الشهر = 'اغسطس'
//--and db_owner.AllowancesFirst.الشهر = 'سبتمبر'
//--and db_owner.AllowancesFirst.الشهر = 'اكتوبر'
//--and db_owner.AllowancesFirst.الشهر = 'نوفمبر'
//and db_owner.AllowancesFirst.الشهر = 'ديسمبر'
//and a.اسم_الموظف = 'هشام هجو'
//and AllowancesFirst.اسم_الموظف = 'هشام هجو'
            //            use hr_restaurant
            //DELETE 
            //FROM attendancesecond 
            //WHERE 
            //  (غياب IS NULL or غياب = 0) and 
            //  (غياب_بعذر IS NULL OR غياب_بعذر = 0) and 
            //  (خروج_قبل_الزمن IS NULL OR خروج_قبل_الزمن = 0)
            //    DBCC CHECKIDENT('attendancesecond', RESEED, 0)

            System.Data.SqlClient.SqlConnection SqlConn = new System.Data.SqlClient.SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
            System.Data.SqlClient.SqlCommand SqlComm = new System.Data.SqlClient.SqlCommand();
            foreach (string tablename in Tables)
            {
                SqlComm.CommandText = @"UPDATE db_owner." + tablename + " " +
            @"SET اسم_الموظف = db_owner.Employees.EmpName
            FROM db_owner." + tablename + " " +
            @"INNER JOIN
            db_owner.Employees ON db_owner." + tablename + "" +
                @".رقم_الموظف = db_owner.Employees.EmpID";
                SqlComm.Connection = SqlConn;
                try
                {
                    SqlConn.Open();
                    SqlComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    SqlConn.Close();
                }
            }
        }

        private void DialyEmployeesEditFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEditDialyWorkersFiles"] != null)
                Application.OpenForms["frmEditDialyWorkersFiles"].Focus();
            else if (Application.OpenForms["frmEditDialyWorkersFiles"] == null)
            {
                frmEditDialyWorkersFiles frmDialywrkrsEditFiles = new frmEditDialyWorkersFiles();
                frmDialywrkrsEditFiles.Show();
                frmDialywrkrsEditFiles.MdiParent = this;
                frmDialywrkrsEditFiles.WindowState = FormWindowState.Maximized;
            }
        }

        private void addpenaltyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmPenalty"] != null)
                Application.OpenForms["frmPenalty"].Focus();
            else if (Application.OpenForms["frmPenalty"] == null)
            {
                frmPenalty frmEmployeesPanalties = new frmPenalty();
                frmEmployeesPanalties.Show();
                frmEmployeesPanalties.MdiParent = this;

                frmEmployeesPanalties.WindowState = FormWindowState.Maximized;
            }

        }

        private void EditPenaltiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEditPenalties"] != null)
                Application.OpenForms["frmEditPenalties"].Focus();
            else if (Application.OpenForms["frmEditPenalties"] == null)
            {
                frmEditPenalties frmEditEmployeesPanalties = new frmEditPenalties();
                frmEditEmployeesPanalties.Show();
                frmEditEmployeesPanalties.MdiParent = this;

                frmEditEmployeesPanalties.WindowState = FormWindowState.Maximized;
            }
        }

        private void AddLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["frmLoans"] != null)
                Application.OpenForms["frmLoans"].Focus();
            else if (Application.OpenForms["frmLoans"] == null)
            {
                frmLoans frmEditEmployeesLoans = new frmLoans();
                frmEditEmployeesLoans.Show();
                frmEditEmployeesLoans.MdiParent = this;

                frmEditEmployeesLoans.WindowState = FormWindowState.Maximized;
            }
        }

        private void EditLoansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEditLoans"] != null)
                Application.OpenForms["frmEditLoans"].Focus();
            else if (Application.OpenForms["frmEditLoans"] == null)
            {
                frmEditLoans frmEdtLoans = new frmEditLoans();
                frmEdtLoans.Show();
                frmEdtLoans.MdiParent = this;

                frmEdtLoans.WindowState = FormWindowState.Maximized;
            }
        }

        private void NewMedicalFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmMedicalForm"] != null)
                Application.OpenForms["frmMedicalForm"].Focus();
            else if (Application.OpenForms["frmMedicalForm"] == null)
            {
                frmAddMedicalForm frmMedical = new frmAddMedicalForm();
                frmMedical.Show();
                frmMedical.MdiParent = this;

                frmMedical.WindowState = FormWindowState.Maximized;
            }
        }

        private void EditMedicalFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEditMedicalForm"] != null)
                Application.OpenForms["frmEditMedicalForm"].Focus();
            else if (Application.OpenForms["frmEditMedicalForm"] == null)
            {
                frmEditMedicalForm frmEdtMedical = new frmEditMedicalForm();
                frmEdtMedical.Show();
                frmEdtMedical.MdiParent = this;

                frmEdtMedical.WindowState = FormWindowState.Maximized;
            }
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmDeleteDialyWorker"] != null)
                Application.OpenForms["frmDeleteDialyWorker"].Focus();
            else if (Application.OpenForms["frmDeleteDialyWorker"] == null)
            {
                frmDeleteDialyWorker frmDeleteDialy = new frmDeleteDialyWorker();
                frmDeleteDialy.Show();
                frmDeleteDialy.MdiParent = this;

                frmDeleteDialy.WindowState = FormWindowState.Maximized;
            }
        }

        private void VacationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NoSalaryVacationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAddVacation"] != null)
                Application.OpenForms["frmAddVacation"].Focus();
            else if (Application.OpenForms["frmAddVacation"] == null)
            {
                frmAddVacation frmAddVac = new frmAddVacation();
                frmAddVac.Show();
                frmAddVac.MdiParent = this;
                frmAddVac.WindowState = FormWindowState.Maximized;
            }
        }

        private void PrinEmployeestWorkIncentiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrinEmployeesWorkIncentive frmPrintWorkIncentive = new frmPrinEmployeesWorkIncentive();
            frmPrintWorkIncentive.ShowDialog();
           
        }
    }
}