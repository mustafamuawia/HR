using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;

namespace HR_MS
{
    public partial class frmEditEmployeeFile : Adjust
    {
        public int EmpID;
        public Image PersonalPicture;
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");

        List<string> JobAndDept = new List<string>();
        List<ListTwoColumns> JobIDAndJobName = new List<ListTwoColumns>();
        List<ListTwoColumns> DeptIDAndDeptName = new List<ListTwoColumns>();


        public frmEditEmployeeFile()
        {
            InitializeComponent();
        }
        public void GetDepartmentAndJob(int Job)
        {
            //Initialize JobsList field

            SqlDataAdapter daJobs = new SqlDataAdapter("SELECT db_owner.Jobs.JobName, " +
            @"db_owner.Departments.DeptName FROM db_owner.Jobs INNER JOIN " +
            @"db_owner.Departments ON db_owner.Jobs.JobDepartmentID = db_owner.Departments.DeptID " +
            @"where db_owner.Jobs.JobID='" + Job + "'", SqlConn);

            DataTable dtJobs = new DataTable();

            daJobs.Fill(dtJobs);
            if (dtJobs.Rows.Count != 0)
            {
                JobAndDept.Add(dtJobs.Rows[0][1].ToString());
                JobAndDept.Add(dtJobs.Rows[0][0].ToString());
            }
        }

        private Image ByteArrayToImage(byte[] ImageBytesFromDatabase)
        {

            MemoryStream ms = new MemoryStream(ImageBytesFromDatabase);
            Image PersonalPicture = Image.FromStream(ms);
            return PersonalPicture;
        }

        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff);
            return ms.ToArray();
        }

        private void EnableInformationControls()
        {
            this.txtEmpName.Enabled = true;
            this.txtMobileNo.Enabled = true;
            this.cbNationality.Enabled = true;
            this.txtEmployeeEmail.Enabled = true;
            this.cbGender.Enabled = true;
            this.cbJob.Enabled = true;
            this.cbAdministrations.Enabled = true;
            this.dtpHireDate.Enabled = true;
            this.txtAddress.Enabled = true;
            this.btnSave.Enabled = true;
            this.chbSocialInsurance.Enabled = true;



        }

        private void EnableDetailsControls()
        {
            //this.btnQualifications.Enabled = true;
            this.btnOfficialDocuments.Enabled = true;
            //this.btnTraining.Enabled = true;
            //this.btnExperiences.Enabled = true;

        }
        private void DiasbleDetailsControls()
        {
            this.btnQualifications.Enabled = false;
            this.btnOfficialDocuments.Enabled = false;
            this.btnTraining.Enabled = false;
            this.btnExperiences.Enabled = false;
            this.btnOfficialDocuments.Enabled = false;
        }

        private void DisableInformationControls()
        {
            this.cbNationality.Enabled = false;
            this.txtMobileNo.Enabled = false;
            this.cbNationality.Enabled = false;
            this.txtEmployeeEmail.Enabled = false;
            this.cbGender.Enabled = false;
            this.cbJob.Enabled = false;
            this.cbAdministrations.Enabled = false;
            this.dtpHireDate.Enabled = false;
            this.txtAddress.Enabled = false;
            this.btnSave.Enabled = false;
            this.chbSocialInsurance.Enabled = false;
            this.chbDepartmentJob.Enabled = false;
            this.cbDepartments.Enabled = false;
        }

        private void ClearInformationControls()
        {
            this.txtFileID.Clear();
            this.txtEmpName.Clear();
            this.txtMobileNo.Clear();
            this.txtAddress.Clear();
            this.txtEmployeeEmail.Clear();
            this.cbGender.Text = "ذكر";



            if (this.cbDepartments.Items.Count != 0)
                this.cbDepartments.Text = this.cbDepartments.Items[0].ToString();
           
            if (this.cbJob.Items.Count != 0)
                this.cbJob.Text = this.cbJob.Items[0].ToString();
           
            if (this.cbAdministrations.Items.Count != 0)
                this.cbAdministrations.Text = this.cbAdministrations.Items[0].ToString();
        }

        private void frmHireEmployee_Load(object sender, EventArgs e)
        {

            //Initialize DepartmentList field
            SqlDataAdapter daGetAdministrations = new SqlDataAdapter(@"Select db_owner.Administrations.AdministrationName 
            from db_owner.Administrations", SqlConn);
            DataTable dtGetAdministrations = new DataTable();
            try
            {
                daGetAdministrations.Fill(dtGetAdministrations);

                foreach (DataRow DepRow in dtGetAdministrations.Rows)
                {
                    if (!this.cbAdministrations.Items.Contains(DepRow["AdministrationName"].ToString()))
                        this.cbAdministrations.Items.Add(DepRow["AdministrationName"].ToString());
                }
                if (this.cbAdministrations.Items.Count > 0)
                    this.cbAdministrations.Text = this.cbAdministrations.Items[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.cbNationality.Text = "سوداني";
            //            SqlDataAdapter daGetAdministrations = new SqlDataAdapter(@"Select DeptID,DeptName 
            //            from db_Owner.Departments where AdminDepID is not null", SqlConn);
            //            DataTable dtGetAdministrations = new DataTable();
            //            daGetAdministrations.Fill(dtGetAdministrations);
            //            foreach (DataRow DepRow in dtGetAdministrations.Rows)
            //            {
            //                DeptIDAndDeptName.Add(new ListTwoColumns { ID = Convert.ToInt32(DepRow["DeptID"]), Text = DepRow["DeptName"].ToString() });
            //                if (!this.cbDepartments.Items.Contains(DepRow["DeptName"].ToString()))
            //                this.cbDepartments.Items.Add(DepRow["DeptName"].ToString());
            //            }
            //            //Initialize JobsList field
            //            SqlDataAdapter daJobs = new SqlDataAdapter("Select JobID,JobName from db_Owner.Jobs", SqlConn);
            //            DataTable dtJobs = new DataTable();
            //            daJobs.Fill(dtJobs);
            //            foreach (DataRow JobsRow in dtJobs.Rows)
            //            {
            //                JobIDAndJobName.Add(new ListTwoColumns { ID = Convert.ToInt32(JobsRow["JobID"]), Text = JobsRow["JobName"].ToString() });
            //            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtEmpName.Text == "")
            {
                MessageBox.Show("الرجاء ادخال اسم الموظف");
                this.txtEmpName.Focus();
            }
            else
            {
                if (MessageBox.Show("هل تود تعديل سجل الموظف", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sqlIns = "UPDATE db_owner.Employees " +
                        @"SET EmpName=@Name , EmpGender=@Gender,EmpJobID=@JobID," +
                        @"EmpNationality=@Nationality," +
                        @"EmpAddress=@Address,EmpMobilePhoneNo=@MobileNo," +
                        @"EmpPicture=@Picture," +
                        @"EmpHiringDateID=@HireDate, EmpInsurance = @Insurance where EmpID='" + this.txtFileID.Text + "'";


                    SqlConn.Open();
                    try
                    {
                        SqlCommand cmdIns = new SqlCommand(sqlIns, SqlConn);
                        //cmdIns.Parameters.AddWithValue("@ID", this.txtFileID.Text);
                        cmdIns.Parameters.AddWithValue("@Name", this.txtEmpName.Text);
                        cmdIns.Parameters.AddWithValue("@Gender", this.cbGender.Text);
                        if (this.cbJob.Text != "")
                        {
                            SqlDataAdapter daGetJobID = new SqlDataAdapter(@"Select JobID from db_Owner.Jobs 
                                        where JobName='" + this.cbJob.Text + "'", SqlConn);
                            DataTable dtGetJobID = new DataTable();
                            daGetJobID.Fill(dtGetJobID);
                            cmdIns.Parameters.AddWithValue("@JobID", dtGetJobID.Rows[0]["JobID"].ToString());
                        }
                        else
                            cmdIns.Parameters.AddWithValue("@JobID", DBNull.Value);
                        cmdIns.Parameters.AddWithValue("@Nationality", this.cbNationality.Text);
                        cmdIns.Parameters.AddWithValue("@Address", this.txtAddress.Text);
                        cmdIns.Parameters.AddWithValue("@MobileNo", this.txtMobileNo.Text);
                        cmdIns.Parameters.AddWithValue("@Picture", imageToByteArray(this.picbPersonalPicure.Image));
                        cmdIns.Parameters.AddWithValue("@HireDate", this.dtpHireDate.Value);
                        cmdIns.Parameters.AddWithValue("@Status", "Active");
                        cmdIns.Parameters.AddWithValue("@Insurance", chbSocialInsurance.Checked);




                        cmdIns.ExecuteNonQuery();

                        cmdIns.Parameters.Clear();

                        cmdIns.Dispose();
                        cmdIns = null;
                        MessageBox.Show("تم التعديل بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        DisableInformationControls();
                        EnableDetailsControls();

                        this.btnSearch.Enabled = true;
                        this.btnEditEmployee.Enabled = true;
                        this.txtFileID.Enabled = true;
                        this.txtFileID.Enabled = false;
                        this.txtEmpName.Enabled = false;
                        this.cbAdministrations.Text = "";
                        this.btnAddPicture.Enabled = false;
                        this.btnOfficialDocuments.Enabled = false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    finally
                    {
                        SqlConn.Close();
                    }
                }
            }
            
        }


        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

            EnableInformationControls();
            DiasbleDetailsControls();
            //ClearInformationControls();
            this.btnOfficialDocuments.Enabled = true;
            this.btnSearch.Enabled = false;
            this.btnAddPicture.Enabled = true;
            this.btnEditEmployee.Enabled = false;
            this.btnCancelEditing.Enabled = true;

            //this.txtFileID.Text = this.EmpID.ToString();
            //if (this.picbPersonalPicure.Image != Properties.Resources.Picture)
            //    this.picbPersonalPicure.Image = Properties.Resources.Picture;

        }

        private void btnQualifications_Click(object sender, EventArgs e)
        {
            frmEmployeeQualifications frmQualification = new frmEmployeeQualifications(this.EmpID, this.txtEmpName.Text);
            frmQualification.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInformationControls();
        }


        private void btnOfficialDocuments_Click(object sender, EventArgs e)
        {
            frmEditEmployeeOfficialDocs frmEmpOfficialDocs = new frmEditEmployeeOfficialDocs(this.EmpID, this.txtEmpName.Text);
            frmEmpOfficialDocs.ShowDialog();
        }

        private void btnExperiences_Click(object sender, EventArgs e)
        {
            frmEmployeeExperiences frmExpeirince = new frmEmployeeExperiences(this.EmpID, this.txtEmpName.Text);
            frmExpeirince.ShowDialog();
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
                    this.EmpID = (int)dtGetEmpFilebyID.Rows[0]["EmpId"];
                    this.txtFileID.Enabled = false;

                    this.txtEmpName.Text = dtGetEmpFilebyID.Rows[0]["EmpName"].ToString();
                    this.txtEmployeeEmail.Text = dtGetEmpFilebyID.Rows[0]["EmpEmailAddress"].ToString();
                    this.cbGender.Text = dtGetEmpFilebyID.Rows[0]["EmpGender"].ToString();
                    this.dtpHireDate.Text = dtGetEmpFilebyID.Rows[0]["EmpHiringDateID"].ToString();
                    this.txtMobileNo.Text = dtGetEmpFilebyID.Rows[0]["EmpMobilePhoneNo"].ToString();
                    this.cbNationality.Text = dtGetEmpFilebyID.Rows[0]["EmpNationality"].ToString();
                    string SqlComm = @"SELECT db_owner.Jobs.JobName, db_owner.Departments.DeptName
                        FROM db_owner.Employees INNER JOIN
                        db_owner.Jobs ON db_owner.Employees.EmpJobID = db_owner.Jobs.JobID INNER JOIN
                        db_owner.Departments ON db_owner.Jobs.JobDepartmentID
                        = db_owner.Departments.DeptID 
                        where EmpID=" + dtGetEmpFilebyID.Rows[0]["EmpId"].ToString() + "";
                    SqlDataAdapter daGetDepartment = new SqlDataAdapter(SqlComm, SqlConn);
                    DataTable dtGetDepartment = new DataTable();
                    daGetDepartment.Fill(dtGetDepartment);
                    if (dtGetDepartment.Rows.Count != 0)
                    {
                        this.cbAdministrations.Text = dtGetDepartment.Rows[0]["DeptName"].ToString();
                        this.cbJob.Text = dtGetDepartment.Rows[0]["JobName"].ToString();
                    }
                    this.txtAddress.Text = dtGetEmpFilebyID.Rows[0]["EmpAddress"].ToString();
                    this.picbPersonalPicure.Image = ByteArrayToImage((byte[])dtGetEmpFilebyID.Rows[0]["EmpPicture"]);
                    this.txtEmpName.Enabled = false;
                    this.btnNameSearch.Enabled = false;
                    this.btnSearch.Enabled = true;
                    this.btnEditEmployee.Enabled = true;
                }
                else MessageBox.Show("لا يوجد ملف بهذا الرقم");
            }
        }

        public void btnNameSearch_Click(object sender, EventArgs e)
        {
            
            //if (this.txtEmpName.Text == "") MessageBox.Show("الرجاء إضافة اسم للبحث عنه");
            //else
            //{
            SqlDataAdapter daGetEmpFilebyName = new SqlDataAdapter(@"SELECT  Employees.EmpID, 
            Employees.EmpName, 
            Administrations.AdministrationName,
            Departments.DeptName,
            Jobs.JobName,
            Employees.EmpGender, 
            Employees.EmpNationality,
            Employees.EmpAddress, Employees.EmpPhoneNo,
            Employees.EmpMobilePhoneNo,
            Employees.EmpEmailAddress,
            Employees.EmpPicture, 
            Employees.EmpHiringDateID, 
            Employees.EmpStatus
            FROM Employees left JOIN
            Jobs ON Employees.EmpJobID = Jobs.JobID left JOIN
            Departments ON Jobs.JobDepartmentID =
            Departments.DeptID left JOIN
            Administrations ON Jobs.JobAdministarionID =
            Administrations.AdministrationID where EmpName LIKE ('%" + this.txtEmpName.Text + "%')", SqlConn);
            DataTable dtGetEmpFilebyName = new DataTable();
            daGetEmpFilebyName.Fill(dtGetEmpFilebyName);
            if (dtGetEmpFilebyName.Rows.Count == 1)
            {
                //GetDepartmentAndJob(Convert.ToInt32(dtGetEmpFilebyName.Rows[0]["EmpJobID"]));
                this.EmpID = (int)dtGetEmpFilebyName.Rows[0]["EmpId"];
                this.txtFileID.Text = dtGetEmpFilebyName.Rows[0]["EmpID"].ToString();
                this.txtEmpName.Text = dtGetEmpFilebyName.Rows[0]["EmpName"].ToString();
                this.txtEmployeeEmail.Text = dtGetEmpFilebyName.Rows[0]["EmpEmailAddress"].ToString();
                this.cbGender.Text = dtGetEmpFilebyName.Rows[0]["EmpGender"].ToString();
                this.dtpHireDate.Text = dtGetEmpFilebyName.Rows[0]["EmpHiringDateID"].ToString();
                this.txtMobileNo.Text = dtGetEmpFilebyName.Rows[0]["EmpMobilePhoneNo"].ToString();
                this.cbNationality.Text = dtGetEmpFilebyName.Rows[0]["EmpNationality"].ToString();
                this.txtAddress.Text = dtGetEmpFilebyName.Rows[0]["EmpAddress"].ToString();
                this.picbPersonalPicure.Image = ByteArrayToImage((byte[])dtGetEmpFilebyName.Rows[0]["EmpPicture"]);
                this.chbDepartmentJob.Checked = true;
                this.cbAdministrations.Text = Convert.ToString(dtGetEmpFilebyName.Rows[0]["AdministrationName"]);
                this.cbDepartments.Text = Convert.ToString(dtGetEmpFilebyName.Rows[0]["DeptName"]);
                this.cbJob.Text = Convert.ToString(dtGetEmpFilebyName.Rows[0]["JobName"]);




                //Disable Controls
                this.txtEmpName.Enabled = false;
                this.btnNameSearch.Enabled = false;
                this.btnSearch.Enabled = true;
                this.btnFileIDSearch.Enabled = false;
                this.txtFileID.Enabled = false;
                this.btnSearch.Enabled = true;
                this.txtEmpName.Enabled = false;
                this.txtFileID.Enabled = false;
                this.btnEditEmployee.Enabled = true;
                this.btnNameSearch.Enabled = false;
            }
            else if (dtGetEmpFilebyName.Rows.Count > 1)
            {
                DialogtSearchedEmpsbyName DialogMatchedNames = new DialogtSearchedEmpsbyName(dtGetEmpFilebyName,this.Name);
                DialogMatchedNames.ShowDialog();
              
            }
                
            else MessageBox.Show("لا يوجد موظف بهذا الاسم");
            

        }

        private void btnNewFileIDSearch_Click(object sender, EventArgs e)
        {
            ClearInformationControls();
            DisableInformationControls();
            this.picbPersonalPicure.Image = Properties.Resources.Picture;
            this.txtFileID.Enabled = true;
            this.btnNameSearch.Enabled = true;
            this.btnFileIDSearch.Enabled = true;
            this.txtEmpName.Enabled = true;
            this.PersonalPicture = null;
            this.btnSearch.Enabled = false;
        }

        private void cbJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter daJobs = new SqlDataAdapter("SELECT db_owner.Jobs.JobName" +
       @" FROM db_owner.Jobs INNER JOIN " +
       @"db_owner.Departments ON db_owner.Jobs.JobDepartmentID = db_owner.Departments.DeptID " +
       @"where db_owner.Departments.DeptName='" + this.cbAdministrations.Text + "'", SqlConn);
            DataTable dtJobs = new DataTable();

            daJobs.Fill(dtJobs);
            for (int index = 0; index < dtJobs.Rows.Count; index++)
            {
                if (!this.cbJob.Items.Contains(dtJobs.Rows[index][0].ToString()))
                {
                    this.cbJob.Items.Add(dtJobs.Rows[index][0].ToString());
                }
            }
            if (this.cbJob.Items.Count != 0)
            {
                this.cbJob.Text = this.cbJob.Items[0].ToString();
            }
            else this.cbJob.Text = "";
        }

        private void cbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Initialize DepartmentList field
            SqlDataAdapter daDepartments = new SqlDataAdapter("Select DeptID,DeptName " +
            @"from db_Owner.Departments where AdminDepID is not null", SqlConn);
            DataTable dtDepartments = new DataTable();
            daDepartments.Fill(dtDepartments);
            foreach (DataRow DepRow in dtDepartments.Rows)
            {
                DeptIDAndDeptName.Add(new ListTwoColumns { ID = Convert.ToInt32(DepRow["DeptID"]), Text = DepRow["DeptName"].ToString() });
                if (!this.cbAdministrations.Items.Contains(DepRow["DeptName"].ToString()))
                    this.cbAdministrations.Items.Add(DepRow["DeptName"].ToString());
            }
            SqlDataAdapter daJobs = new SqlDataAdapter("SELECT db_owner.Jobs.JobName" +
         @" FROM db_owner.Jobs INNER JOIN " +
         @"db_owner.Departments ON db_owner.Jobs.JobDepartmentID = db_owner.Departments.DeptID " +
         @"where db_owner.Departments.DeptName='" + this.cbAdministrations.Text + "'", SqlConn);


            DataTable dtJobs = new DataTable();

            daJobs.Fill(dtJobs);
            this.cbJob.Items.Clear();
            for (int index = 0; index < dtJobs.Rows.Count; index++)
            {
                if (!this.cbJob.Items.Contains(dtJobs.Rows[index][0].ToString()))
                {
                    this.cbJob.Items.Add(dtJobs.Rows[index][0].ToString());
                }
            }
            if (this.cbJob.Items.Count != 0)
            {
                this.cbJob.Text = this.cbJob.Items[0].ToString();
            }
            else this.cbJob.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbDepartments_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbJob_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            DialogPersonalPicureSource ImageSource = new DialogPersonalPicureSource(false);
            if (ImageSource.ShowDialog() == DialogResult.OK)
            {
                picbPersonalPicure.Image = this.PersonalPicture;
            }
        }

        private void btnCancelEditing_Click(object sender, EventArgs e)
        {
            this.btnCancelEditing.Enabled = false;
            this.btnEditEmployee.Enabled = true;
            this.btnSearch.Enabled = true;
            DisableInformationControls();
        }

        private void txtFileID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.btnFileIDSearch_Click(sender, e);
            }
        }

        private void txtEmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.btnNameSearch_Click(sender, e);
            }
        }

        private void btnNewDepartment_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAddDepartment"] != null)
                Application.OpenForms["frmAddDepartment"].Focus();
            else if (Application.OpenForms["frmAddDepartment"] == null)
            {
                frmAddDepartment frmAddDept = new frmAddDepartment();
                frmAddDept.Show();
                frmAddDept.MdiParent = Application.OpenForms["frmMain"];
                frmAddDept.WindowState = FormWindowState.Maximized;

            }
        }

        private void btnAddNewJob_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAddJob"] != null)
                Application.OpenForms["frmAddJob"].Focus();
            else if (Application.OpenForms["frmAddJob"] == null)
            {
                frmAddJob frmNewJob = new frmAddJob();
                frmNewJob.Show();
                frmNewJob.MdiParent = Application.OpenForms["frmMain"];
                frmNewJob.WindowState = FormWindowState.Maximized;
            }
        }


        private void chbDepartmentJob_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbDepartmentJob.Checked == true)
            {
                this.cbDepartments.Enabled = true;
                this.cbAdministrations.Enabled = false;

                SqlDataAdapter daGetAdministrationJobs = new SqlDataAdapter(@"SELECT Departments.DeptName
                FROM Departments INNER JOIN
                Jobs ON Departments.DeptID = Jobs.JobDepartmentID INNER JOIN
                Administrations ON Jobs.JobAdministarionID = Administrations.AdministrationID
                where db_owner.Administrations.AdministrationName ='" + this.cbAdministrations.Text + "'", SqlConn);
                //              SqlDataAdapter daGetAdministrationJobs = new SqlDataAdapter(@"SELECT FROM
                //            db_owner.Administrations INNER JOIN db_owner.Jobs ON 
                //            db_owner.Administrations.AdministrationID = db_owner.Jobs.JobAdministarionID
                //            where db_owner.Administrations.AdministrationName ='" + this.cbAdministrations.Text + "'", SqlConn);


                DataTable dtGetAdministrationJobs = new DataTable();
                try
                {
                    daGetAdministrationJobs.Fill(dtGetAdministrationJobs);
                    this.cbJob.Items.Clear();
                    for (int index = 0; index < dtGetAdministrationJobs.Rows.Count; index++)
                    {
                        if (!this.cbJob.Items.Contains(dtGetAdministrationJobs.Rows[index][0].ToString()))
                        {
                            this.cbJob.Items.Add(dtGetAdministrationJobs.Rows[index][0].ToString());
                        }
                    }
                    if (this.cbJob.Items.Count > 0)
                        this.cbJob.Text = this.cbJob.Items[0].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                this.cbDepartments.Enabled = false;
                this.cbAdministrations.Enabled = true;
                this.cbDepartments.Items.Clear();
                this.cbDepartments.Text = "";
                SqlDataAdapter daGetAdministrationJobs = new SqlDataAdapter(@"SELECT db_owner.Jobs.JobName FROM
           db_owner.Jobs  
            INNER JOIN db_owner.Administrations  ON 
            db_owner.Administrations.AdministrationID = db_owner.Jobs.JobAdministarionID
            where db_owner.Administrations.AdministrationName ='" + this.cbAdministrations.Text + "'", SqlConn);


                DataTable dtGetAdministrationJobs = new DataTable();
                try
                {
                    daGetAdministrationJobs.Fill(dtGetAdministrationJobs);
                    this.cbJob.Items.Clear();
                    if (dtGetAdministrationJobs.Rows.Count != 0)
                    {

                        for (int index = 0; index < dtGetAdministrationJobs.Rows.Count; index++)
                        {
                            if (!this.cbJob.Items.Contains(dtGetAdministrationJobs.Rows[index][0].ToString()))
                            {
                                this.cbJob.Items.Add(dtGetAdministrationJobs.Rows[index][0].ToString());
                            }
                        }
                        this.cbJob.Text = this.cbJob.Items[0].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cbSubDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter daJobs = new SqlDataAdapter(@"SELECT Jobs.JobName
                            FROM Jobs INNER JOIN
                            Departments ON Jobs.JobDepartmentID = Departments.DeptID
                            where Departments.DeptName = '" + this.cbDepartments.Text + "'", SqlConn);


            DataTable dtJobs = new DataTable();

            daJobs.Fill(dtJobs);
            if (chbDepartmentJob.Checked == true)
            {
                this.cbJob.Items.Clear();
                for (int index = 0; index < dtJobs.Rows.Count; index++)
                {
                    if (!this.cbJob.Items.Contains(dtJobs.Rows[index][0].ToString()))
                    {
                        this.cbJob.Items.Add(dtJobs.Rows[index][0].ToString());
                    }
                }
            }
        }

        private void cbAdministrations_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter daGetAdministrationJobs = new SqlDataAdapter(@"SELECT db_owner.Jobs.JobName FROM
           db_owner.Jobs  
            INNER JOIN db_owner.Administrations  ON 
            db_owner.Administrations.AdministrationID = db_owner.Jobs.JobAdministarionID
            where db_owner.Administrations.AdministrationName ='" + this.cbAdministrations.Text + "'", SqlConn);


            DataTable dtGetAdministrationJobs = new DataTable();
            try
            {
                daGetAdministrationJobs.Fill(dtGetAdministrationJobs);
                this.cbJob.Items.Clear();
                if (dtGetAdministrationJobs.Rows.Count != 0)
                {

                    for (int index = 0; index < dtGetAdministrationJobs.Rows.Count; index++)
                    {
                        if (!this.cbJob.Items.Contains(dtGetAdministrationJobs.Rows[index][0].ToString()))
                        {
                            this.cbJob.Items.Add(dtGetAdministrationJobs.Rows[index][0].ToString());
                        }
                    }
                    this.cbJob.Text = this.cbJob.Items[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SqlDataAdapter daGetAdministrationsAndDepartments = new SqlDataAdapter(@"SELECT 
            Administrations.AdministrationName, Departments.DeptName
            FROM Administrations INNER JOIN
            Departments ON Administrations.AdministrationID = Departments.AdminDepID
            where db_owner.Administrations.AdministrationName ='" + this.cbAdministrations.Text + "'", SqlConn);


            DataTable dtGetAdministrationsAndDepartment = new DataTable();
            try
            {
                daGetAdministrationsAndDepartments.Fill(dtGetAdministrationsAndDepartment);
                if (dtGetAdministrationsAndDepartment.Rows.Count > 0)
                {
                    this.cbDepartments.Items.Clear();

                    for (int index = 0; index < dtGetAdministrationsAndDepartment.Rows.Count; index++)
                    {
                        if (!this.cbDepartments.Items.Contains(dtGetAdministrationsAndDepartment.Rows[index][1].ToString()))
                        {
                            this.cbDepartments.Items.Add(dtGetAdministrationsAndDepartment.Rows[index][1].ToString());
                        }
                    }
                    if (this.cbDepartments.Items.Count > 0)
                        this.cbDepartments.Text = this.cbDepartments.Items[0].ToString();
                    this.chbDepartmentJob.Enabled = true;

                }
                else
                {
                    this.cbDepartments.Items.Clear();
                    this.cbDepartments.Text = "";
                    this.chbDepartmentJob.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Source);
            }
            //            SqlDataAdapter daGetSubDepartment = new SqlDataAdapter(@"SELECT db_owner.Departments.DeptName
            //            FROM db_owner.Administrations INNER JOIN
            //            Departments ON db_owner.Administrations.AdministrationID = Departments.AdminDepID
            //            where db_owner.Administrations.AdministrationName ='" + this.cbAdministrations.Text + "'", SqlConn);


            //            DataTable dtGetSubDepartment = new DataTable();

            //            daGetSubDepartment.Fill(dtGetSubDepartment);
            //            this.cbSubDepartments.Items.Clear();
            //            for (int index = 0; index < dtGetSubDepartment.Rows.Count; index++)
            //            {
            //                if (!this.cbSubDepartments.Items.Contains(dtGetSubDepartment.Rows[index][0].ToString()))
            //                {
            //                    this.cbSubDepartments.Items.Add(dtGetSubDepartment.Rows[index][0].ToString());
            //                }
            //            }
        }

        private void cbJob_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}