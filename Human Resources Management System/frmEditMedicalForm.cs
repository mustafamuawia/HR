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
    public partial class frmEditMedicalForm : Adjust
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");

        public Image PersonalPicture;
        public int MedicalFormID;
        public int EmpID;

        public frmEditMedicalForm()
        {
            InitializeComponent();
        }

        private Image ByteArrayToImage(byte[] ImageBytesFromDatabase)
        {
            MemoryStream ms = new MemoryStream(ImageBytesFromDatabase);
            Image PersonalPicture = Image.FromStream(ms);
            return PersonalPicture;
        }

        private void frmEditMedicalForm_Load(object sender, EventArgs e)
        {

        }
        private void ClearInformationControls()
        {
            //    this.txtLoanID.Clear();
            //    listView1.Items.Clear();

        }
        public void btnNameSearch_Click(object sender, EventArgs e)
        {
//            SELECT     Employees.EmpName, Jobs.JobName, Departments.DeptName, Administrations.AdministrationName
//FROM         Employees INNER JOIN
//MedicalForms ON Employees.EmpID = MedicalForms.EmpID left JOIN
//Jobs ON Employees.EmpJobID = Jobs.JobID left JOIN
//Departments ON Jobs.JobDepartmentID = Departments.DeptID left JOIN
//Administrations 
//ON Jobs.JobAdministarionID = Administrations.AdministrationID 
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
            where Employees.EmpName LIKE ('%" + this.txtEmpName.Text + "%') " +
            @"and Employees.EmpID in (select empid from medicalforms)", SqlConn);
            DataTable dtGetEmpFilebyName = new DataTable();
            daGetEmpFilebyName.Fill(dtGetEmpFilebyName);
            if (dtGetEmpFilebyName.Rows.Count == 1)
            {
                //GetDepartmentAndJob(Convert.ToInt32(dtGetEmpFilebyName.Rows[0]["EmpJobID"]));
                this.EmpID = (int)dtGetEmpFilebyName.Rows[0]["EmpId"];
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
                
                this.btnSearchMedicalForm.Enabled = true;
                this.txtEmpName.Enabled = false;
                this.btnFileIDSearch.Enabled = false;
                this.txtEmpName.Enabled = false;
                this.txtFileID.Enabled = false;
                this.btnNameSearch.Enabled = false;
               
              }
            else if (dtGetEmpFilebyName.Rows.Count > 1)
            {
//                List<EmpName_Dept_Job> Employees = new List<EmpName_Dept_Job>();

//                foreach (DataRow EmpRow in dtGetEmpFilebyName.Rows)
//                {
//                    string SqlComm = @"SELECT db_owner.Jobs.JobName, db_owner.Departments.DeptName
//                        FROM db_owner.Employees INNER JOIN
//                        db_owner.Jobs ON db_owner.Employees.EmpJobID = db_owner.Jobs.JobID INNER JOIN
//                        db_owner.Departments ON db_owner.Jobs.JobDepartmentID
//                        = db_owner.Departments.DeptID 
//                        where EmpName='" + EmpRow["EmpName"].ToString() + "'";
//                    SqlDataAdapter daGetDepartment = new SqlDataAdapter(SqlComm, SqlConn);
//                    DataTable dtGetDepartment = new DataTable();
//                    daGetDepartment.Fill(dtGetDepartment);
//                    EmpName_Dept_Job Emp = new EmpName_Dept_Job();
//                    Emp.EmpName = EmpRow["EmpName"].ToString();
//                    if (dtGetDepartment.Rows.Count != 0)
//                    {
//                        Emp.EmpDept = dtGetDepartment.Rows[0]["DeptName"].ToString();
//                        Emp.EmpJob = dtGetDepartment.Rows[0]["JobName"].ToString();
//                    }
//                    Employees.Add(Emp);
//                }
                DialogtSearchedEmpsbyName DialogMatchedNames =
                    new DialogtSearchedEmpsbyName(dtGetEmpFilebyName,this.Name);
                DialogMatchedNames.ShowDialog();
                //Employees.Clear();
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
                    this.MedicalFormID = (int)dtGetEmpFilebyID.Rows[0]["EmpId"];
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
                    this.btnEditMedicalForm.Enabled = true;
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
            this.txtMedicalFormID.Enabled = false;
            this.txtMedicalFormID.Clear();
            this.PersonalPicture = null;
            this.btnSearch.Enabled = false;
            this.btnEditMedicalForm.Enabled = false;
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
            SqlCommand sqlUpdateMedicalForm = new SqlCommand(@"Update db_owner.MedicalForms
            set Date =  @Date, Notes = @Notes
            where MedicalFormID = '"+this.txtMedicalFormID.Text+"'", SqlConn);
            sqlUpdateMedicalForm.Parameters.AddWithValue("@Date", this.dtpDate.Value);
            sqlUpdateMedicalForm.Parameters.AddWithValue("@Notes", this.txtNotes.Text);

            try
            {
                SqlConn.Open();
                sqlUpdateMedicalForm.ExecuteNonQuery();
                sqlUpdateMedicalForm.Dispose();
                MessageBox.Show("تم الحفظ");
                this.dtpDate.Enabled = false;
                this.txtNotes.Enabled = false;
                this.btnCancel.Enabled        = false;
                this.btnDelete.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnEditMedicalForm.Enabled = true;
                this.btnSearchMedicalForm.Enabled = true;
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


        private void btnEditMedicalForm_Click(object sender, EventArgs e)
        {
            this.dtpDate.Enabled = true;
            this.txtNotes.Enabled = true;
            this.btnCancel.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnEditMedicalForm.Enabled = false;
            this.btnSearchMedicalForm.Enabled = false;
        }

        private void btnAddMedicalForm_Click()
        {

        }

        private void btnSearchMedicalForm_Click(object sender, EventArgs e)
        {
            SqlDataAdapter daGetMedicalForm = new SqlDataAdapter(@"Select MedicalForms.MedicalFormID,
            Employees.EmpName,MedicalForms.Date, MedicalForms.Notes
            FROM MedicalForms INNER JOIN
            Employees ON MedicalForms.EmpID = Employees.EmpID
            where Employees.EmpID= '" + this.EmpID.ToString() + "'", SqlConn);
            DataTable dtGetMedicalForm = new DataTable();
            daGetMedicalForm.Fill(dtGetMedicalForm);
            if (dtGetMedicalForm.Rows.Count == 1)
            {

                this.MedicalFormID = Convert.ToInt32(dtGetMedicalForm.Rows[0]["MedicalFormID"]);
                this.txtMedicalFormID.Text = this.MedicalFormID.ToString();
                this.dtpDate.Value = Convert.ToDateTime(dtGetMedicalForm.Rows[0]["Date"]).Date;
                this.txtNotes.Text = Convert.ToString(dtGetMedicalForm.Rows[0]["Notes"]);


                this.btnSearch.Enabled = true;
                this.txtEmpName.Enabled = false;
                this.btnNameSearch.Enabled = false;
                this.btnFileIDSearch.Enabled = false;
                this.txtEmpName.Enabled = false;
                this.txtFileID.Enabled = false;
                this.btnNameSearch.Enabled = false;
              }
            else if (dtGetMedicalForm.Rows.Count > 1)
            {
                DialogMedicalFormsSearch DialogMatchedNamesLoans = new DialogMedicalFormsSearch(dtGetMedicalForm);
                DialogMatchedNamesLoans.ShowDialog();

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.dtpDate.Enabled = false;
            this.txtNotes.Enabled = false;
            this.btnCancel.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnEditMedicalForm.Enabled = true;
            this.btnSearchMedicalForm.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand sqlUpdateMedicalForm = new SqlCommand(@"Delete from db_owner.MedicalForms
            where MedicalFormID='"+this.txtMedicalFormID.Text+"'", SqlConn);
            sqlUpdateMedicalForm.Parameters.AddWithValue("@Date", this.dtpDate.Value);
            sqlUpdateMedicalForm.Parameters.AddWithValue("@Notes", this.txtNotes.Text);

            try
            {
                SqlConn.Open();
                sqlUpdateMedicalForm.ExecuteNonQuery();
                sqlUpdateMedicalForm.Dispose();
                MessageBox.Show("تم الحذف");
                this.dtpDate.Enabled = false;
                this.txtNotes.Enabled = false;
                this.btnCancel.Enabled = false;
                this.btnDelete.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnEditMedicalForm.Enabled = true;
                this.btnSearchMedicalForm.Enabled = true;
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
}