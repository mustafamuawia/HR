using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HR_MS
{
    public partial class frmAddJob : Adjust
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        int JobID;
        List<ListTwoColumns> DeptIDAndDeptName = new List<ListTwoColumns>();
        public frmAddJob()
        {
            InitializeComponent();
        }

        private void InitializeAdministrationsComboBox()
        {
            this.cbAdministrations.Items.Clear();
            SqlDataAdapter daGetAdministrations = new SqlDataAdapter("SELECT  AdministrationName " +
            @"from db_Owner.Administrations", SqlConn);
            DataTable dtGetAdministrations = new DataTable();
            daGetAdministrations.Fill(dtGetAdministrations);
            if (dtGetAdministrations.Rows.Count != 0)
                for (int index = 0; index < dtGetAdministrations.Rows.Count; index++)
                {
                    this.cbAdministrations.Items.Add(dtGetAdministrations.Rows[index]["AdministrationName"].ToString());
                }
            if (this.cbAdministrations.Items.Count > 0)
            {
                this.cbAdministrations.Text = this.cbAdministrations.Items[0].ToString();
            }
        }

        private void InitializeDepartmentsComboBox()
        {
            this.cbDepartments.Items.Clear();
            SqlDataAdapter daGetDepartments = new SqlDataAdapter(@"SELECT  db_Owner.Departments.DeptName 
            from db_Owner.Departments inner join 
            db_owner.Administrations on
            db_owner.departments.AdminDepID = db_owner.Administrations.AdministrationID
            where db_owner.administrations.AdministrationName = 
            '"+this.cbAdministrations.Text+"'", SqlConn);
            DataTable dtGetDepartments = new DataTable();
            daGetDepartments.Fill(dtGetDepartments);
            if (dtGetDepartments.Rows.Count != 0)
                for (int index = 0; index < dtGetDepartments.Rows.Count; index++)
                {
                    this.cbDepartments.Items.Add(dtGetDepartments.Rows[index]["DeptName"].ToString());
                }
            if (this.cbDepartments.Items.Count > 0)
            {
                this.cbDepartments.Text = this.cbDepartments.Items[0].ToString();
            }
        }


        private void InitializetvHierarchicalTree()
        {
            this.tvHierarchicalTree.Nodes.Clear();
             SqlDataAdapter daGetAdministrations = new SqlDataAdapter("SELECT  AdministrationName " +
           @"from db_Owner.Administrations", SqlConn);
            DataTable dtGetAdministrations = new DataTable();
            daGetAdministrations.Fill(dtGetAdministrations);
            if (dtGetAdministrations.Rows.Count != 0)
                for (int index = 0; index < dtGetAdministrations.Rows.Count; index++)
                {
                    this.tvHierarchicalTree.Nodes.Add(dtGetAdministrations.Rows[index][0].ToString());
                    SqlDataAdapter daGetDepartments = new SqlDataAdapter("SELECT db_owner.Departments.DeptName " +
                    @"FROM db_owner.Departments INNER JOIN " +
                    @"db_owner.Administrations ON " +
                    @"db_owner.Departments.AdminDepID = db_owner.Administrations.AdministrationID " +
                    @"where (db_owner.Administrations.AdministrationName = N'" + dtGetAdministrations.Rows[index][0].ToString() + "')", SqlConn);
                    SqlDataAdapter daGetAdminJobs = new SqlDataAdapter("SELECT db_owner.Jobs.JobName " +
                        @"FROM db_owner.Jobs  INNER JOIN  db_owner.Administrations " +
                        @"ON db_owner.Administrations.AdministrationID = db_owner.Jobs.JobAdministarionID " +
                        @"where (db_owner.Administrations.AdministrationName = "+
                        @"N'" + dtGetAdministrations.Rows[index]["AdministrationName"] + "')", SqlConn);
                    DataTable dtGetAdminJobs = new DataTable();
                    daGetAdminJobs.Fill(dtGetAdminJobs);
                    for (int SubCIndex = 0; SubCIndex < dtGetAdminJobs.Rows.Count; SubCIndex++)
                    {
                        this.tvHierarchicalTree.Nodes[index].Nodes.Add("(-" + dtGetAdminJobs.Rows[SubCIndex][0].ToString() + "-)");
                    }
                    DataTable dtGetDepartments = new DataTable();
                    daGetDepartments.Fill(dtGetDepartments);

                    for (int CIndex = 0; CIndex < dtGetDepartments.Rows.Count; CIndex++)
                    {
                        this.tvHierarchicalTree.Nodes[index].Nodes.Add(dtGetDepartments.Rows[CIndex][0].ToString());
                        SqlDataAdapter daGetDepartmentsJobs = new SqlDataAdapter("SELECT db_owner.Jobs.JobName " +
                        @"FROM db_owner.Departments INNER JOIN db_owner.Jobs " +
                        @"ON db_owner.Departments.DeptID = db_owner.Jobs.JobDepartmentID " +
                        @"where (db_owner.Departments.DeptName = N'" + dtGetDepartments.Rows[CIndex]["DeptName"] + "')", SqlConn);
                        DataTable dtGetDepartmentsJobs = new DataTable();
                        daGetDepartmentsJobs.Fill(dtGetDepartmentsJobs);
                        for (int SubCIndex = 0; SubCIndex < dtGetDepartmentsJobs.Rows.Count; SubCIndex++)
                        {
                            this.tvHierarchicalTree.Nodes[index].Nodes[CIndex].Nodes.Add("(-" + dtGetDepartmentsJobs.Rows[SubCIndex][0].ToString() + "-)");
                        }
                    }
                }
        }

        private void frmAddDepartment_Load(object sender, EventArgs e)
        {
            SqlDataAdapter daGetJobID = new SqlDataAdapter("Select JobID from db_Owner.Jobs", SqlConn);
            DataTable dtGetJobID = new DataTable();
            daGetJobID.Fill(dtGetJobID);
            if (dtGetJobID.Rows.Count == 0)
            {
                JobID = 1;
            }
            else
            {
                JobID = Convert.ToInt32(dtGetJobID.Rows[dtGetJobID.Rows.Count - 1][0].ToString()) + 1;
            }
            txtJobID.Text = JobID.ToString();
            //if (this.cbDepartments.Items.Count > 0)
            //{
            //    this.cbDepartments.Text = this.cbDepartments.Items[0].ToString();
            //}
            InitializetvHierarchicalTree();
            InitializeAdministrationsComboBox();

        }

        private void btnAddNewDepartment_Click(object sender, EventArgs e)
        {
            SqlDataAdapter daGetDeptID = new SqlDataAdapter("Select JobID from db_Owner.Jobs", SqlConn);
            DataTable dtGetDeptID = new DataTable();
            daGetDeptID.Fill(dtGetDeptID);
            if (dtGetDeptID.Rows.Count == 0)
            {
                JobID = 1;
            }
            else
            {
                JobID = Convert.ToInt32(dtGetDeptID.Rows[dtGetDeptID.Rows.Count - 1][0].ToString()) + 1;
            }
            txtJobID.Text = JobID.ToString();
            this.txtJobName.Enabled = true;
            this.btnAddNewJob.Enabled = false;
            this.cbAdministrations.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnCancelEditing.Enabled = true;
            this.chbDepartment.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.cbAdministrations.Text=="")
                MessageBox.Show("حقل الإدارة لا بد أن يحتوي على بيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (this.txtJobName.Text == "")
                MessageBox.Show("حقل الوظيفة لا بد أن يحتوي على بيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
       else if (MessageBox.Show("هل تود إضافة الوصف الوظيفي", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
//                SqlDataAdapter daDepartments = new SqlDataAdapter(@"SELECT db_owner.Departments.DeptID 
//                      FROM db_owner.Departments 
//                            where db_owner.Departments.DeptName = '" + this.cbDepartments.Text + "'", SqlConn);
//                DataTable dtDepartments = new DataTable();
//                daDepartments.Fill(dtDepartments);
                string sqlIns="";
           if (this.chbDepartment.Checked == true)
                sqlIns = @"INSERT INTO db_owner.Jobs
                                 (JobID,JobName,JobDepartmentID,JobAdministarionID)
                                values (@ID ,@Name,(SELECT db_owner.Departments.DeptID 
                                FROM db_owner.Departments 
                                where db_owner.Departments.DeptName = '" + this.cbDepartments.Text + "'),"+
                                @"null)";
           else if (this.chbDepartment.Checked == false)
               sqlIns = @"INSERT INTO db_owner.Jobs
                                 (JobID,JobName,JobDepartmentID, JobAdministarionID)
                                 values (@ID ,@Name,null ,(SELECT db_owner.Administrations.AdministrationID 
                                 FROM db_owner.Administrations where 
                                 db_owner.Administrations.AdministrationName=
                                  '" + this.cbAdministrations.Text + "'))";
                SqlConn.Open();
                try
                {
                    SqlCommand cmdIns = new SqlCommand(sqlIns, SqlConn);
                    cmdIns.Parameters.AddWithValue("@ID", JobID);
                    cmdIns.Parameters.AddWithValue("@Name", this.txtJobName.Text);
                   
                    cmdIns.ExecuteNonQuery();

                    cmdIns.Parameters.Clear();

                    cmdIns.Dispose();
                    cmdIns = null;
                    MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.btnAddNewJob.Enabled = true;
                    this.btnSave.Enabled = false;
                    this.cbDepartments.Enabled = false;
                    this.txtJobName.Enabled = false;
                    this.cbAdministrations.Enabled = false;
                    this.chbDepartment.Enabled = false;
                    InitializetvHierarchicalTree();
                    InitializeAdministrationsComboBox();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelEditing_Click(object sender, EventArgs e)
        {
            this.txtJobName.Text = "";
            this.txtJobName.Enabled = false;
            this.cbDepartments.Enabled = false;
            this.cbAdministrations.Text = "";
            this.cbAdministrations.Enabled = false;
            this.btnAddNewJob.Enabled = true;
            this.btnCancelEditing.Enabled = false;
        }

        private void cbAdministration_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SqlDataAdapter daDepartments = new SqlDataAdapter("SELECT db_owner.Departments.DeptName " +
            //        @"FROM db_owner.Departments INNER JOIN " +
            //        @"db_owner.Administrations ON " +
            //        @"db_owner.Departments.AdminDepID = db_owner.Administrations.AdministrationID " +
            //        @"where (db_owner.Administrations.AdministrationName = N'" + this.cbAdministrations.Text + "')", SqlConn);
            //DataTable dtDepartments = new DataTable();
            //daDepartments.Fill(dtDepartments);
            //if (dtDepartments.Rows.Count != 0)
            //{
            //    foreach (DataRow DepRow in dtDepartments.Rows)
            //    {
            //        if (!this.cbDepartments.Items.Contains(DepRow["DeptName"]))
            //            this.cbDepartments.Items.Add(DepRow["DeptName"].ToString());
            //        this.cbDepartments.Text = this.cbDepartments.Items[0].ToString();
            //    }
            //}
        }

        private void cbAdministration_DropDown(object sender, EventArgs e)
        {
            InitializeAdministrationsComboBox();
        }

        private void chbDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbDepartment.Checked == true)
            {
                this.cbAdministrations.Enabled = false;
                this.cbDepartments.Enabled = true;
                InitializeDepartmentsComboBox();
            }
            else if (this.chbDepartment.Checked == false)
            {
                this.cbAdministrations.Enabled = true;
                this.cbDepartments.Enabled = false;
                this.cbDepartments.Items.Clear();
            }
        }
    }
}