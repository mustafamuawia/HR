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
    public partial class frmEditJobs : Adjust
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        int JobID;
        List<ListTwoColumns> DeptIDAndDeptName = new List<ListTwoColumns>();
        public frmEditJobs()
        {
            InitializeComponent();
            
        }
        private void InitializeJobComponents()
        {
            SqlDataAdapter daGetAdminJobs = new SqlDataAdapter(@"SELECT Departments.DeptName
                        FROM Departments INNER JOIN
                        Jobs ON Departments.DeptID = Jobs.JobDepartmentID
                        where Jobs.JobName='"+this.cbAdminJobs+"'", SqlConn);
              DataTable dtGetAdminJobs = new DataTable();
            daGetAdminJobs.Fill(dtGetAdminJobs);
            if (dtGetAdminJobs.Rows.Count != 0)
            {
                this.chbIsDepartmentJob.Checked = true;
                this.cbDepartments.Text = dtGetAdminJobs.Rows[0]["DeptName"].ToString();
            }

        }
        private void InitializeDepartmentsAndJobsComboBox()
        {
            this.cbAdminJobs.Items.Clear();
            SqlDataAdapter daGetAdminJobs = new SqlDataAdapter("SELECT db_owner.Jobs.JobName " +
                         @"FROM db_owner.Departments INNER JOIN db_owner.Jobs " +
                         @"ON db_owner.Departments.DeptID = db_owner.Jobs.JobAdministarionID " +
                         @"where (db_owner.Departments.DeptName = '" +this.cbAdministrations.Text+ "')", SqlConn);
            DataTable dtGetAdminJobs = new DataTable();
            daGetAdminJobs.Fill(dtGetAdminJobs);
            if (dtGetAdminJobs.Rows.Count != 0)
            {
                for (int index = 0; index < dtGetAdminJobs.Rows.Count; index++)
                {
                    this.cbAdminJobs.Items.Add(dtGetAdminJobs.Rows[index]["JobName"].ToString());
                }
                this.cbAdminJobs.Text = this.cbAdminJobs.Items[0].ToString();
              
            }
        }

        private void InitializeAdministrationsComboBox()
        {
            this.cbAdministrations.Items.Clear();
            SqlDataAdapter daGetDepartments = new SqlDataAdapter("SELECT  DeptName " +
                        @"from db_Owner.Departments where AdminDepID is NULL", SqlConn);
            DataTable dtGetDepartments = new DataTable();
            daGetDepartments.Fill(dtGetDepartments);
            if (dtGetDepartments.Rows.Count != 0)
                for (int index = 0; index < dtGetDepartments.Rows.Count; index++)
                {
                    this.cbAdministrations.Items.Add(dtGetDepartments.Rows[index]["DeptName"].ToString());
                }
            if (this.cbAdministrations.Items.Count > 0)
            {
                this.cbAdministrations.Text = this.cbAdministrations.Items[0].ToString();
            }
        }

        private void InitializeDepartmentsAndJobsTreeView()
        {
            this.tvJobs.Nodes.Clear();
            SqlDataAdapter daGetDepartments = new SqlDataAdapter("SELECT  DeptName " +
            @"from db_Owner.Departments where AdminDepID is NULL", SqlConn);
            DataTable dtGetDepartments = new DataTable();
            daGetDepartments.Fill(dtGetDepartments);
            if (dtGetDepartments.Rows.Count != 0)
                for (int index = 0; index < dtGetDepartments.Rows.Count; index++)
                {
                    this.tvJobs.Nodes.Add(dtGetDepartments.Rows[index][0].ToString());
                    SqlDataAdapter daGetSubDepartments = new SqlDataAdapter("SELECT db_owner.Departments.DeptName " +
                    @"FROM db_owner.Departments INNER JOIN " +
                    @"db_owner.Departments AS Departments_1 ON " +
                    @"db_owner.Departments.AdminDepID = Departments_1.DeptID " +
                    @"where (Departments_1.DeptName = N'" + dtGetDepartments.Rows[index][0].ToString() + "')", SqlConn);
                    SqlDataAdapter daGetAdminJobs = new SqlDataAdapter("SELECT db_owner.Jobs.JobName " +
                        @"FROM db_owner.Departments INNER JOIN db_owner.Jobs " +
                        @"ON db_owner.Departments.DeptID = db_owner.Jobs.JobAdministarionID " +
                        @"where (db_owner.Departments.DeptName = N'" + dtGetDepartments.Rows[index]["DeptName"] + "')", SqlConn);
                    DataTable dtGetAdminJobs = new DataTable();
                    daGetAdminJobs.Fill(dtGetAdminJobs);
                    for (int SubCIndex = 0; SubCIndex < dtGetAdminJobs.Rows.Count; SubCIndex++)
                    {
                        this.tvJobs.Nodes[index].Nodes.Add("(-" + dtGetAdminJobs.Rows[SubCIndex][0].ToString() + "-)");
                    }
                    DataTable dtGetSubDepartments = new DataTable();
                    daGetSubDepartments.Fill(dtGetSubDepartments);

                    for (int CIndex = 0; CIndex < dtGetSubDepartments.Rows.Count; CIndex++)
                    {
                        this.tvJobs.Nodes[index].Nodes.Add(dtGetSubDepartments.Rows[CIndex][0].ToString());
                        SqlDataAdapter daGetJobs = new SqlDataAdapter("SELECT db_owner.Jobs.JobName " +
                        @"FROM db_owner.Departments INNER JOIN db_owner.Jobs " +
                        @"ON db_owner.Departments.DeptID = db_owner.Jobs.JobDepartmentID " +
                        @"where (db_owner.Departments.DeptName = N'" + dtGetSubDepartments.Rows[CIndex]["DeptName"] + "')", SqlConn);
                        DataTable dtGetetJobs = new DataTable();
                        daGetJobs.Fill(dtGetetJobs);
                        for (int SubCIndex = 0; SubCIndex < dtGetetJobs.Rows.Count; SubCIndex++)
                        {
                            this.tvJobs.Nodes[index].Nodes[CIndex].Nodes.Add("(-" + dtGetetJobs.Rows[SubCIndex][0].ToString() + "-)");
                        }
                    }
                }
        }

        private void frmEditJobs_Load(object sender, EventArgs e)
        {
            InitializeAdministrationsComboBox();
            InitializeDepartmentsAndJobsTreeView();
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
            this.btnSave.Enabled = true;
            this.cbDepartments.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int DeptId = 0;

            for (int index = 0; index < DeptIDAndDeptName.Count; index++)
            {
                ListTwoColumns List = DeptIDAndDeptName[index];
                if (List.Text == this.cbDepartments.Text)
                {
                    DeptId = List.ID;
                }
            }
            if (MessageBox.Show("هل تود إضافة الوصف الوظيفي", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sqlIns = @"Update db_owner.Jobs 
                    set  JobName =@Name ,JobDepartmentID= 
                    (Select DeptID from db_owner.Departments
                    where DeptName='" + this.txtJobID.Text + "') " +
                    @"where db_owner.Jobs.JobID= '"+this.txtJobID.Text+"'";
                SqlConn.Open();
                try
                {
                    SqlCommand cmdIns = new SqlCommand(sqlIns, SqlConn);
                    cmdIns.Parameters.AddWithValue("@ID", JobID);
                    cmdIns.Parameters.AddWithValue("@Name", this.txtJobName.Text);
                    cmdIns.Parameters.AddWithValue("@Department", DeptId);

                    cmdIns.ExecuteNonQuery();

                    cmdIns.Parameters.Clear();

                    cmdIns.Dispose();
                    cmdIns = null;
                    MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.btnSave.Enabled = false;
                    this.cbDepartments.Enabled = false;
                    this.txtJobName.Enabled = false;
                    this.btnEditJob.Enabled = true;
                    this.btnCancelEditJob.Enabled = false;
                    this.txtJobName.Text = "";
                    this.cbDepartments.Enabled = false;
                    this.cbDepartments.Items.Clear();
                    this.cbDepartments.Text = "";
                    InitializeDepartmentsAndJobsTreeView();
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

        private void btnEditJob_Click(object sender, EventArgs e)
        {
            this.cbAdminJobs.Enabled = false;
            this.txtJobName.Enabled = true;
            this.cbDepartments.Enabled = true;
            this.btnCancelEditJob.Enabled = true;
            this.btnEditJob.Enabled = false;
            this.txtJobName.Text = this.cbAdminJobs.Text;
            this.btnSave.Enabled = true;
            this.cbAdministrations.Enabled = false;
            this.btnDeleteJob.Enabled = true;
                   

        }

        private void btnCancelEditJob_Click(object sender, EventArgs e)
        {
            this.cbAdminJobs.Enabled = true;
            this.txtJobName.Enabled = true;
            this.cbDepartments.Enabled = false;
            this.btnCancelEditJob.Enabled = false;
            this.btnEditJob.Enabled = true;
            this.txtJobName.Enabled = false;
            this.cbAdministrations.Enabled = true;
            this.btnDeleteJob.Enabled = true;
        }

        private void cbDepartments_DropDown(object sender, EventArgs e)
        {
            MessageBox.Show("");
            SqlDataAdapter daDepartments = new SqlDataAdapter(@"SELECT DeptName
            FROM db_owner.Departments", SqlConn);
            DataTable dtDepartments = new DataTable();
            daDepartments.Fill(dtDepartments);
            foreach (DataRow DepartmentRow in dtDepartments.Rows)
            {
                if (!this.cbDepartments.Items.Contains(DepartmentRow["DeptName"]))
                    this.cbDepartments.Items.Add(DepartmentRow["DeptName"]);
            }
            InitializeDepartmentsAndJobsTreeView();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cbAdministrations_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeDepartmentsAndJobsComboBox();
        }

        private void cbAllJobs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
             
    }
}