using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace HR_MS
{
    public partial class frmAddVacation : Adjust
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");

        public Image PersonalPicture;
        public int VacationID;


        public frmAddVacation()
        {
            InitializeComponent();
        }

        private Image ByteArrayToImage(byte[] ImageBytesFromDatabase)
        {
            MemoryStream ms = new MemoryStream(ImageBytesFromDatabase);
            Image PersonalPicture = Image.FromStream(ms);
            return PersonalPicture;
        }

        private void frmAddVacation_Load(object sender, EventArgs e)
        {

        }
        private void ClearInformationControls()
        {
            //    this.txtLoanID.Clear();
            //    listView1.Items.Clear();

        }
        public void btnNameSearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter daGetEmpFilebyName = new SqlDataAdapter(@"SELECT Employees.EmpID, 
            Employees.EmpName,
            Administrations.AdministrationName,
            Departments.DeptName, 
            Jobs.JobName,
            Employees.EmpPicture        
            FROM Employees left JOIN
            Jobs ON Employees.EmpJobID = Jobs.JobID left JOIN
            Departments ON Jobs.JobDepartmentID = Departments.DeptID left JOIN
            Administrations 
            ON Jobs.JobAdministarionID = Administrations.AdministrationID 
             where EmpName LIKE ('%" + this.txtEmpName.Text + "%')", SqlConn);
            DataTable dtGetEmpFilebyName = new DataTable();
            daGetEmpFilebyName.Fill(dtGetEmpFilebyName);
            if (dtGetEmpFilebyName.Rows.Count == 1)
            {
                this.txtFileID.Text = dtGetEmpFilebyName.Rows[0]["EmpID"].ToString();
                this.txtEmpName.Text = dtGetEmpFilebyName.Rows[0]["EmpName"].ToString();
                this.picbPersonalPicure.Image = ByteArrayToImage((byte[])dtGetEmpFilebyName.Rows[0]["EmpPicture"]);
                this.txtJob.Text = Convert.ToString(dtGetEmpFilebyName.Rows[0]["JobName"]);
                this.txtAdministration.Text = Convert.ToString(dtGetEmpFilebyName.Rows[0]["AdministrationName"]);
                this.txtDepartment.Text = Convert.ToString(dtGetEmpFilebyName.Rows[0]["DeptName"]);
                //this.MedicalFormID = Convert.ToInt32(dtGetEmpFilebyName.Rows[0]["MedicalFormID"]);
                //this.txtMedicalFormID.Text = this.MedicalFormID.ToString();
                //this.dtpDate.Value = Convert.ToDateTime(dtGetEmpFilebyName.Rows[0]["Date"]);

                this.btnSearch.Enabled = true;

                //if (dtGetAdministrationdAndDepartment.Rows.Count != 0)
                //{
                //    this.cbAdministrations.Text = dtGetAdministrationdAndDepartment.Rows[0]["DeptName"].ToString();
                //    this.cbJob.Text = dtGetAdministrationdAndDepartment.Rows[0]["JobName"].ToString();
                //}


                //Disable Controls
                this.txtEmpName.Enabled = false;
                this.btnNameSearch.Enabled = false;
                this.btnSearch.Enabled = true;
                this.btnFileIDSearch.Enabled = false;
                this.txtFileID.Enabled = false;
                this.btnSearch.Enabled = true;
                this.txtEmpName.Enabled = false;
                this.txtFileID.Enabled = false;
                this.btnNameSearch.Enabled = false;
                this.btnAddNoSalaryVacation.Enabled = true;
            }

            else if (dtGetEmpFilebyName.Rows.Count > 1)
            {
                DialogtSearchedEmpsbyName DialogMatchedNames =
                   new DialogtSearchedEmpsbyName(dtGetEmpFilebyName, this.Name);
                DialogMatchedNames.ShowDialog();
            }


            else MessageBox.Show("لا يوجد موظف بهذا الاسم");
        }

        private void btnFileIDSearch_Click(object sender, EventArgs e)
        {
            if (this.txtFileID.Text == "") MessageBox.Show("الرجاء إضافة رقم الملف للبحث عنه");
            else
            {
                SqlDataAdapter daGetEmpFilebyID = new SqlDataAdapter("SELECT EmpID," +
                    @"EmpName, EmpGender," +
                    @"EmpNationality, EmpAddress," +
                    @"EmpMobilePhoneNo, EmpEmailAddress, " +
                    @"EmpPicture, EmpHiringDateID " +
                    @" FROM db_owner.Employees " +
                    @"where EmpID =" + this.txtFileID.Text + "", SqlConn);
                DataTable dtGetEmpFilebyID = new DataTable();
                daGetEmpFilebyID.Fill(dtGetEmpFilebyID);
                if (dtGetEmpFilebyID.Rows.Count == 1)
                {
                    this.VacationID = (int)dtGetEmpFilebyID.Rows[0]["EmpId"];
                    this.txtFileID.Enabled = false;

                    this.txtEmpName.Text = dtGetEmpFilebyID.Rows[0]["EmpName"].ToString();

                    string SqlComm = @"SELECT db_owner.Jobs.JobName, db_owner.Departments.DeptName
                        FROM db_owner.Employees INNER JOIN
                        db_owner.Jobs ON db_owner.Employees.EmpJobID = db_owner.Jobs.JobID INNER JOIN
                        db_owner.Departments ON db_owner.Jobs.JobDepartmentID
                        = db_owner.Departments.DeptID 
                        where EmpID=" + dtGetEmpFilebyID.Rows[0]["EmpId"].ToString() + "";
                    SqlDataAdapter daGetDepartment = new SqlDataAdapter(SqlComm, SqlConn);
                    DataTable dtGetDepartment = new DataTable();
                    daGetDepartment.Fill(dtGetDepartment);

                    this.picbPersonalPicure.Image = ByteArrayToImage((byte[])dtGetEmpFilebyID.Rows[0]["EmpPicture"]);
                    this.txtEmpName.Enabled = false;
                    this.txtFileID.Clear();
                    this.txtEmpName.Clear();
                    //this.txtIncentive.Clear();
                    this.btnNameSearch.Enabled = false;
                    this.btnSearch.Enabled = true;
                    this.btnAddNoSalaryVacation.Enabled = true;
                }
                else MessageBox.Show("لا يوجد ملف بهذا الرقم");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearInformationControls();
            this.picbPersonalPicure.Image = Properties.Resources.Picture;
            this.txtFileID.Enabled = true;
            this.txtFileID.Clear();
            this.btnNameSearch.Enabled = true;
            this.btnFileIDSearch.Enabled = true;
            this.txtEmpName.Enabled = true;
            this.txtEmpName.Clear();
            this.txtVacationID.Enabled = true;
            this.txtVacationID.Clear();
            this.PersonalPicture = null;
            this.btnSearch.Enabled = false;
            this.btnAddNoSalaryVacation.Enabled = false;
            //this.btnSave.Enabled = false;
            //this.btnClear.Enabled = false;
            //this.btnCancel.Enabled = false;
            //this.cbMonths.Text = ArabicEgypt.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            //this.txtDeductionTotal.Clear();
            //this.txtMonthHalfDeduction.Clear();
            //this.txtMonthEndDeduction.Clear();
            //this.listView1.Items.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand sqlInsertVacationAttendance;
            SqlCommand sqlInsertVacation = new SqlCommand(@"insert into db_owner.NoSalaryVacation
            Values(@VacationID,@EmpID,@StartDate,@EndDate,@Notes)", SqlConn);
            sqlInsertVacation.Parameters.AddWithValue("@VacationID", this.txtVacationID.Text);
            sqlInsertVacation.Parameters.AddWithValue("@EmpID", this.txtFileID.Text);
            sqlInsertVacation.Parameters.AddWithValue("@StartDate", this.dtpFromDate.Value.Date);
            sqlInsertVacation.Parameters.AddWithValue("@EndDate", this.dtpEndDate.Value.Date);
            sqlInsertVacation.Parameters.AddWithValue("@Notes", this.txtNotes.Text);
            SqlDataAdapter daGetEmployeeList = new SqlDataAdapter(@"select رقم_الموظف from db_owner.attendancefirst
            where رقم_الموظف =  '" + this.txtFileID.Text + "'", SqlConn);
            DataTable dtGetEmployeeList = new DataTable();
            daGetEmployeeList.Fill(dtGetEmployeeList);
            if (dtGetEmployeeList.Rows.Count != 0)
            {
                sqlInsertVacationAttendance = new SqlCommand(@"update db_owner.attendancefirst
            set اجازة_بدون_مرتب = 1 where التاريخ between '" + dtpFromDate.Value.Date + "' " +
                            @"and '" + this.dtpEndDate.Value.Date + "' " +
                 @" and رقم_الموظف =  '" + this.txtFileID.Text + "'", SqlConn);
            }
            else
            {
                sqlInsertVacationAttendance = new SqlCommand(@"update db_owner.attendanceSecond
            set اجازة_بدون_مرتب = 1 where التاريخ between '" + dtpFromDate.Value.Date + "' " +
                @"and '" + this.dtpEndDate.Value.Date + "' " +
                 @" and رقم_الموظف =  '" + this.txtFileID.Text + "'", SqlConn);
            }
            try
            {
                SqlConn.Open();
                sqlInsertVacation.ExecuteNonQuery();
                sqlInsertVacationAttendance.ExecuteNonQuery();
                sqlInsertVacation.Dispose();
                sqlInsertVacationAttendance.Dispose();

                this.btnAddNoSalaryVacation.Enabled = true;
                this.txtNotes.Enabled = false;
                this.txtNotes.Clear();
                this.dtpFromDate.Enabled = false;
                this.dtpEndDate.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnCancel.Enabled = false;
                MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
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


        private void btnAddMedicalForm_Click(object sender, EventArgs e)
        {
            SqlDataAdapter daGetVacationID = new SqlDataAdapter(@"Select VacationID from 
            db_Owner.NoSalaryVacation"
              , SqlConn);
            DataTable dtGetVacationID = new DataTable();
            daGetVacationID.Fill(dtGetVacationID);
            if (dtGetVacationID.Rows.Count == 0)
            {
                VacationID = 1;
            }
            else
            {
                VacationID = Convert.ToInt32(dtGetVacationID.Rows[dtGetVacationID.Rows.Count - 1][0].ToString()) + 1;
            }
            this.txtVacationID.Text = VacationID.ToString();
            //EnableInformationControls();
            //DiasbleDetailsControls();
            ClearInformationControls();

            this.btnAddNoSalaryVacation.Enabled = false;
            this.txtNotes.Enabled = true;
            this.txtNotes.Clear();
            this.dtpFromDate.Enabled = true;
            this.dtpEndDate.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.txtVacationID.Text = this.VacationID.ToString();
            //if (this.picbPersonalPicure.Image != Properties.Resources.Picture)
            //    this.picbPersonalPicure.Image = Properties.Resources.Picture;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}