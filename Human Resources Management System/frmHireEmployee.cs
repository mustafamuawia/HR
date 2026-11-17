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
    public partial class frmHireEmployee : Adjust
    {
        public int EmpID;
        public Image PersonalPicture;
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");

        List<ListTwoColumns> JobIDAndJobName = new List<ListTwoColumns>();
        List<ListTwoColumns> DeptIDAndDeptName = new List<ListTwoColumns>();


        public frmHireEmployee()
        {
            InitializeComponent();
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
            this.cbAdministrations.Enabled = true;
            this.cbJob.Enabled = true;
            this.dtpHireDate.Enabled = true;
            this.txtAddress.Enabled = true;
            this.btnClear.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnAddPicture.Enabled = true;
            this.chbSocialInsurance.Enabled = true;
            this.cbSubDepartments.Enabled = true;

        }

        private void EnableDetailsControls()
        {
            this.btnQualifications.Enabled = true;
            this.btnOfficialDocuments.Enabled = true;
            this.btnTraining.Enabled = true;
            this.btnExperiences.Enabled = true;
            this.btnOfficialDocuments.Enabled = true;
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
            this.txtEmpName.Enabled = false;
            this.txtMobileNo.Enabled = false;
            this.cbNationality.Enabled = false;
            this.txtEmployeeEmail.Enabled = false;
            this.cbGender.Enabled = false;
            this.cbAdministrations.Enabled = false;
            this.cbJob.Enabled = false;
            this.cbAdministrations.Enabled = false;
            this.dtpHireDate.Enabled = false;
            this.txtAddress.Enabled = false;
            this.btnClear.Enabled = false;
            this.btnSave.Enabled = false;
            this.cbSubDepartments.Enabled = false;
            this.chbSocialInsurance.Enabled = false;

        }

        private void ClearInformationControls()
        {
            this.txtEmpName.Clear();
            this.txtMobileNo.Clear();
            this.txtAddress.Clear();
            this.txtEmployeeEmail.Clear();
            this.cbGender.Text = "ذكر";

        }

        private void frmHireEmployee_Load(object sender, EventArgs e)
        {
            //Initialize FileID field
            SqlDataAdapter daGetEmpID = new SqlDataAdapter("Select empid from db_Owner.Employees", SqlConn);
            DataTable dtGetEmpID = new DataTable();
            daGetEmpID.Fill(dtGetEmpID);
            if (dtGetEmpID.Rows.Count == 0)
            {
                EmpID = 1;
            }
            else
            {
                EmpID = Convert.ToInt32(dtGetEmpID.Rows[dtGetEmpID.Rows.Count - 1][0].ToString()) + 1;
            }
            txtFileID.Text = EmpID.ToString();

            //Initialize DepartmentList field
            SqlDataAdapter daDepartments = new SqlDataAdapter("Select DeptID,DeptName " +
                @"from db_Owner.Departments where db_owner.Departments.AdminDepID is null", SqlConn);
            DataTable dtDepartments = new DataTable();
            daDepartments.Fill(dtDepartments);
            foreach (DataRow DepRow in dtDepartments.Rows)
            {
                DeptIDAndDeptName.Add(new ListTwoColumns { ID = Convert.ToInt32(DepRow["DeptID"]), Text = DepRow["DeptName"].ToString() });
                if (!this.cbAdministrations.Items.Contains(DepRow["DeptName"]))
                    this.cbAdministrations.Items.Add(DepRow["DeptName"]);
            }
            //Initialize JobsList field
            SqlDataAdapter daJobs = new SqlDataAdapter("Select JobID,JobName from db_Owner.Jobs", SqlConn);
            DataTable dtJobs = new DataTable();
            daJobs.Fill(dtJobs);
            foreach (DataRow JobsRow in dtJobs.Rows)
            {
                JobIDAndJobName.Add(new ListTwoColumns { ID = Convert.ToInt32(JobsRow["JobID"]), Text = JobsRow["JobName"].ToString() });
            }
            this.cbNationality.Text = "سوداني";
            //    if (!this.cbJob.Items.Contains(JobsRow["JobName"]))
            //        this.cbJob.Items.Add(JobsRow["JobName"]);
            //}
            //this.cbGender.Text = this.cbGender.Items[0].ToString();

            //if (this.cbDepartments.Items.Count > 0)
            //{
            //    this.cbDepartments.Text = this.cbDepartments.Items[0].ToString();
            //}

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
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            DialogPersonalPicureSource ImageSource = new DialogPersonalPicureSource(true);
            if (ImageSource.ShowDialog() == DialogResult.OK)
            {
                picbPersonalPicure.Image = this.PersonalPicture;
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            SqlDataAdapter daGetEmpID = new SqlDataAdapter("Select empid from db_Owner.Employees", SqlConn);
            DataTable dtGetEmpID = new DataTable();
            daGetEmpID.Fill(dtGetEmpID);
            if (dtGetEmpID.Rows.Count == 0)
            {
                EmpID = 1;
            }
            else
            {
                EmpID = Convert.ToInt32(dtGetEmpID.Rows[dtGetEmpID.Rows.Count - 1][0].ToString()) + 1;
            }
            txtFileID.Text = EmpID.ToString();
            EnableInformationControls();
            DiasbleDetailsControls();
            ClearInformationControls();
            txtFileID.Text = EmpID.ToString();
            this.btnAddEmployee.Enabled = false;
            this.txtFileID.Text = this.EmpID.ToString();
            if (this.picbPersonalPicure.Image != Properties.Resources.Picture)
                this.picbPersonalPicure.Image = Properties.Resources.Picture;

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
            frmEmployeeOfficialDocuments frmEmpOfficialDocs = new frmEmployeeOfficialDocuments(this.EmpID, this.txtEmpName.Text);
            frmEmpOfficialDocs.ShowDialog();
        }

        private void btnExperiences_Click(object sender, EventArgs e)
        {
            frmEmployeeExperiences frmExpeirince = new frmEmployeeExperiences(this.EmpID, this.txtEmpName.Text);
            frmExpeirince.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                int JobID = 0, DeptId = 0;

                for (int index = 0; index < JobIDAndJobName.Count; index++)
                {
                    ListTwoColumns List = JobIDAndJobName[index];
                    if (List.Text == this.cbJob.Text)
                    {
                        JobID = List.ID;
                    }
                }
                for (int index = 0; index < DeptIDAndDeptName.Count; index++)
                {
                    ListTwoColumns List = DeptIDAndDeptName[index];
                    if (List.Text == this.cbAdministrations.Text)
                    {
                        DeptId = List.ID;
                    }
                }
                if (MessageBox.Show("هل تود إضافة سجل الموظف", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sqlIns = "INSERT INTO db_owner.Employees " +
                        @"(EmpID, EmpName, EmpGender,EmpJobID,EmpNationality,EmpAddress," +
                        @"EmpMobilePhoneNo,EmpEmailAddress,EmpPicture,EmpHiringDateID,EmpStatus,EmpInsurance)" +
                        @" VALUES (@ID, @Name,@Gender,@JobID,@Nationality,@Address," +
                        @"@MobileNo,@Email,@Picture,@HireDate,@Status,@Insurance)";

                    SqlConn.Open();
                    try
                    {
                        SqlCommand cmdIns = new SqlCommand(sqlIns, SqlConn);
                        cmdIns.Parameters.AddWithValue("@ID", EmpID);
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
                        cmdIns.Parameters.AddWithValue("@Email", this.txtEmployeeEmail.Text);
                        cmdIns.Parameters.AddWithValue("@Address", this.txtAddress.Text);
                        cmdIns.Parameters.AddWithValue("@MobileNo", this.txtMobileNo.Text);
                        cmdIns.Parameters.AddWithValue("@Picture", imageToByteArray(this.picbPersonalPicure.Image));
                        cmdIns.Parameters.AddWithValue("@HireDate", this.dtpHireDate.Value);
                        cmdIns.Parameters.AddWithValue("@Status", "Active");
                        cmdIns.Parameters.AddWithValue("@Insurance", chbSocialInsurance.Checked);

                        cmdIns.ExecuteNonQuery();

                        cmdIns.Parameters.Clear();

                        cmdIns.Dispose();

                        MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        DisableInformationControls();
                        EnableDetailsControls();
                        this.btnAddEmployee.Enabled = true;
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

        private void cbDepartments_DropDown(object sender, EventArgs e)
        {
            //        SqlDataAdapter daJobs = new SqlDataAdapter("SELECT db_owner.Jobs.JobName" +
            //@" FROM db_owner.Jobs INNER JOIN " +
            //@"db_owner.Departments ON db_owner.Jobs.JobDepartmentID = db_owner.Departments.DeptID " +
            //@"where db_owner.Departments.DeptName='" + this.cbDepartments.Text + "'", SqlConn);


            //        DataTable dtJobs = new DataTable();

            //        daJobs.Fill(dtJobs);
            //        this.cbJob.Items.Clear();
            //        for (int index = 0; index < dtJobs.Rows.Count; index++)
            //        {
            //            if (!this.cbJob.Items.Contains(dtJobs.Rows[index][0].ToString()))
            //            {
            //                this.cbJob.Items.Add(dtJobs.Rows[index][0].ToString());
            //            }
            //        }
        }

        private void cbDepartments_SelectedIndexChanged(object sender, EventArgs e)
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
                    this.cbSubDepartments.Items.Clear();

                    for (int index = 0; index < dtGetAdministrationsAndDepartment.Rows.Count; index++)
                    {
                        if (!this.cbSubDepartments.Items.Contains(dtGetAdministrationsAndDepartment.Rows[index][1].ToString()))
                        {
                            this.cbSubDepartments.Items.Add(dtGetAdministrationsAndDepartment.Rows[index][1].ToString());
                        }
                    }
                    if (this.cbSubDepartments.Items.Count > 0)
                        this.cbSubDepartments.Text = this.cbSubDepartments.Items[0].ToString();
                    if (btnAddEmployee.Enabled == true)
                    this.chbDepartmentJob.Enabled = false;
                    else this.chbDepartmentJob.Enabled = true;

                }
                else
                {
                    this.cbSubDepartments.Items.Clear();
                    this.cbSubDepartments.Text = "";
                    this.chbDepartmentJob.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.Source);
            }
        }

        private void cbSubDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter daJobs = new SqlDataAdapter(@"SELECT Jobs.JobName
                            FROM Jobs INNER JOIN
                            Departments ON Jobs.JobDepartmentID = Departments.DeptID
                            where Departments.DeptName = '" + this.cbSubDepartments.Text + "'", SqlConn);


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



        private void cbSubDepartments_DropDown(object sender, EventArgs e)
        {

        }

        private void chbDepartmentJob_CheckedChanged(object sender, EventArgs e)
        {

            if (this.chbDepartmentJob.Checked == true)
            {
                this.cbSubDepartments.Enabled = true;
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
                this.cbSubDepartments.Enabled = false;
                this.cbAdministrations.Enabled = true;
                this.cbSubDepartments.Items.Clear();
                this.cbSubDepartments.Text = "";
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
    }
}