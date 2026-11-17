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
    public partial class frmAddMedicalForm : Form
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");

        public Image PersonalPicture;
        public int MedicalFormID;
        public int LoanID;

        public frmAddMedicalForm()
        {
            InitializeComponent();
        }

        private Image ByteArrayToImage(byte[] ImageBytesFromDatabase)
        {
            MemoryStream ms = new MemoryStream(ImageBytesFromDatabase);
            Image PersonalPicture = Image.FromStream(ms);
            return PersonalPicture;
        }

        private void frmMedicalForm_Load(object sender, EventArgs e)
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
                this.btnAddMedicalForm.Enabled = true;
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
                    this.btnAddMedicalForm.Enabled = true;
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
            this.txtMedicalFormID.Enabled = true;
            this.txtMedicalFormID.Clear();
            this.PersonalPicture = null;
            this.btnSearch.Enabled = false;
            this.btnAddMedicalForm.Enabled = false;
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
            SqlCommand sqlInsertMedicalForm = new SqlCommand(@"insert into db_owner.MedicalForms
            Values(@MedicalFormID,@EmpID,@Date,@FormStatus,@Notes)",SqlConn);
            sqlInsertMedicalForm.Parameters.AddWithValue("@MedicalFormID",this.txtMedicalFormID.Text);
            sqlInsertMedicalForm.Parameters.AddWithValue("@EmpID", this.txtFileID.Text);
            sqlInsertMedicalForm.Parameters.AddWithValue("@Date", this.dtpDate.Value.Date);
            sqlInsertMedicalForm.Parameters.AddWithValue("@FormStatus",false);
            sqlInsertMedicalForm.Parameters.AddWithValue("@Notes", this.txtNotes.Text);

            try
            {
                SqlConn.Open();
                sqlInsertMedicalForm.ExecuteNonQuery();
                sqlInsertMedicalForm.Dispose();

                this.btnAddMedicalForm.Enabled = true;
                this.txtNotes.Enabled = false;
                this.dtpDate.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnCancel.Enabled = false;
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
            SqlDataAdapter daGetMedicalFormID = new SqlDataAdapter(@"Select MedicalFormID from 
            db_Owner.MedicalForms"
              , SqlConn);
            DataTable dtGetMedicalFormID = new DataTable();
            daGetMedicalFormID.Fill(dtGetMedicalFormID);
            if (dtGetMedicalFormID.Rows.Count == 0)
            {
                MedicalFormID = 1;
            }
            else
            {
                MedicalFormID = Convert.ToInt32(dtGetMedicalFormID.Rows[dtGetMedicalFormID.Rows.Count - 1][0].ToString()) + 1;
            }
            this.txtMedicalFormID.Text = MedicalFormID.ToString();
            //EnableInformationControls();
            //DiasbleDetailsControls();
            ClearInformationControls();
            
            this.btnAddMedicalForm.Enabled = false;
            this.txtNotes.Enabled = true;
            this.txtNotes.Clear();
            this.dtpDate.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.txtMedicalFormID.Text = this.MedicalFormID.ToString();
            //if (this.picbPersonalPicure.Image != Properties.Resources.Picture)
            //    this.picbPersonalPicure.Image = Properties.Resources.Picture;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

     
    
    }
}