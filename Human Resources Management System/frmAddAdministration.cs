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
    public partial class frmAddAdministration : Adjest
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        int DepartmentID;

        public frmAddAdministration()
        {
            InitializeComponent();
        }

        private void InitializeDepartmentsTreeView()
    
    {
        this.tvDepartments.Nodes.Clear();
        SqlDataAdapter daGetDepartments = new SqlDataAdapter("SELECT  DeptName " +
       @"from db_Owner.Departments where AdminDepID is NULL", SqlConn);
        DataTable dtGetDepartments = new DataTable();
        daGetDepartments.Fill(dtGetDepartments);
        if (dtGetDepartments.Rows.Count != 0)
         for (int index = 0; index < dtGetDepartments.Rows.Count; index++)
            {
                this.tvDepartments.Nodes.Add(dtGetDepartments.Rows[index][0].ToString());
                 SqlDataAdapter daGetSubDepartments = new SqlDataAdapter("SELECT db_owner.Departments.DeptName "+
                 @"FROM db_owner.Departments INNER JOIN "+
                 @"db_owner.Departments AS Departments_1 ON "+
                 @"db_owner.Departments.AdminDepID = Departments_1.DeptID "+
                 @"where (Departments_1.DeptName = N'" + dtGetDepartments.Rows[index][0].ToString() + "')", SqlConn);

            DataTable dtGetSubDepartments  = new DataTable();
            daGetSubDepartments .Fill(dtGetSubDepartments);

                for (int CIndex =0; CIndex<dtGetSubDepartments.Rows.Count;CIndex++)
                {
                    this.tvDepartments.Nodes[index].Nodes.Add(dtGetSubDepartments.Rows[CIndex][0].ToString());
                }
            }
    }

        private void frmAddDepartment_Load(object sender, EventArgs e)
        {
            SqlDataAdapter daGetDeptID = new SqlDataAdapter("Select DeptID from db_Owner.Departments", SqlConn);
            DataTable dtGetDeptID = new DataTable();
            daGetDeptID.Fill(dtGetDeptID);
            if (dtGetDeptID.Rows.Count == 0)
            {
                DepartmentID = 1;
            }
            else
            {
                DepartmentID = Convert.ToInt32(dtGetDeptID.Rows[dtGetDeptID.Rows.Count - 1][0].ToString()) + 1;
            }
            txtAdministrationID.Text = DepartmentID.ToString();

            SqlDataAdapter daGetDepartments = new SqlDataAdapter("SELECT  DeptName " +
             @"from db_Owner.Departments where AdminDepID is null", SqlConn);
            //
            DataTable dtGetDepartments = new DataTable();
            daGetDepartments.Fill(dtGetDepartments);
            if (dtGetDepartments.Rows.Count != 0)
            {
                foreach (DataRow DepartmentRow in dtGetDepartments.Rows)
                    if (!this.cbAdminDepartments.Items.Contains(DepartmentRow["DeptName"].ToString()))
                        this.cbAdminDepartments.Items.Add(DepartmentRow["DeptName"].ToString());
            }
            if (this.cbAdminDepartments.Items.Count != 0)
                this.cbAdminDepartments.Text = this.cbAdminDepartments.Items[0].ToString();
            InitializeDepartmentsTreeView();
            //for (int index = 0; index < dtGetAllowances.Rows.Count; index++)
            //{
            //    this.tvDepartments.Nodes.Add(dtGetAllowances.Rows[index][0].ToString());
            //    SqlDataAdapter daGetSubDepartments = new SqlDataAdapter("SELECT db_owner.Departments.DeptName " +
            //    @"FROM db_owner.Departments INNER JOIN " +
            //    @"db_owner.Departments AS Departments_1 ON " +
            //    @"db_owner.Departments.AdminDepID = Departments_1.DeptID " +
            //    @"where (Departments_1.DeptName = N'" + dtGetAllowances.Rows[index][0].ToString() + "')", SqlConn);

            //    DataTable dtGetSubDepartments = new DataTable();
            //    daGetSubDepartments.Fill(dtGetSubDepartments);

            //    for (int CIndex = 0; CIndex < dtGetSubDepartments.Rows.Count; CIndex++)
            //    {
            //        this.tvDepartments.Nodes[index].Nodes.Add(dtGetSubDepartments.Rows[CIndex][0].ToString());
            //    }
            //}
        }

        private void btnAddNewDepartment_Click(object sender, EventArgs e)
        {
            SqlDataAdapter daGetDeptID = new SqlDataAdapter("Select DeptID from db_Owner.Departments", SqlConn);
            DataTable dtGetDeptID = new DataTable();
            daGetDeptID.Fill(dtGetDeptID);
            if (dtGetDeptID.Rows.Count == 0)
            {
                DepartmentID = 1;
            }
            else
            {
                DepartmentID = Convert.ToInt32(dtGetDeptID.Rows[dtGetDeptID.Rows.Count - 1][0].ToString()) + 1;
            }
            txtAdministrationID.Text = DepartmentID.ToString();
            this.txtAdminstrationName.Enabled = true;
            this.ChbSubDepartment.Enabled = true;
            this.btnCancelAddNewDepartment.Enabled = false;
            this.btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تود إضافة القسم", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                SqlConn.Open();
                try
                {
                    string sqlCommand = "Select DeptID from db_owner.Departments " +
                    @"Where DeptName='" + this.cbAdminDepartments.Text + "'";
                    SqlDataAdapter daGetDeparmentName = new SqlDataAdapter(sqlCommand, SqlConn);
                    DataTable dtGetDeparmentName = new DataTable();
                    daGetDeparmentName.Fill(dtGetDeparmentName);
                    string sqlIns;
                    if (this.ChbSubDepartment.Checked == true)
                    {
                        sqlIns = "INSERT INTO db_owner.Departments " +
                        @"(DeptID, DeptName, AdminDepID) " +
                        @" VALUES (@ID, @Name, @AdminDepID)";
                    }
                    else
                    {
                        sqlIns = "INSERT INTO db_owner.Departments " +
                           @"(DeptID, DeptName) " +
                           @" VALUES (@ID, @Name)";
                    }
                    SqlCommand cmdIns = new SqlCommand(sqlIns, SqlConn);
                    cmdIns.Parameters.AddWithValue("@ID", this.txtAdministrationID.Text);
                    cmdIns.Parameters.AddWithValue("@Name", this.txtAdminstrationName.Text);
                    if (this.ChbSubDepartment.Checked == true)
                    cmdIns.Parameters.AddWithValue("@AdminDepID", dtGetDeparmentName.Rows[0]["DeptID"].ToString());
                    cmdIns.ExecuteNonQuery();

                    cmdIns.Parameters.Clear();
                    cmdIns.CommandText = "SELECT @@IDENTITY";

                    cmdIns.Dispose();
                    cmdIns = null;
                    MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.btnCancelAddNewDepartment.Enabled = true;
                    this.btnSave.Enabled = false;
                    this.txtAdminstrationName.Enabled = false;
                    this.ChbSubDepartment.Enabled = false;
                    this.cbAdminDepartments.Enabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    SqlConn.Close();
                }
                InitializeDepartmentsTreeView();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChbSubDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChbSubDepartment.Checked == true)
            {
                this.cbAdminDepartments.Enabled = true;
            }
            else this.cbAdminDepartments.Enabled = false;
        }

        private void cbAdminDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter daGetDepartments = new SqlDataAdapter("SELECT  DeptName " +
            @"from db_Owner.Departments where AdminDepID is NULL", SqlConn);
            DataTable dtGetDepartments = new DataTable();
            daGetDepartments.Fill(dtGetDepartments);
            if (dtGetDepartments.Rows.Count != 0)
            {
                foreach (DataRow DepartmentRow in dtGetDepartments.Rows)
                    if (!this.cbAdminDepartments.Items.Contains(DepartmentRow["DeptName"].ToString()))
                        this.cbAdminDepartments.Items.Add(DepartmentRow["DeptName"].ToString());
            }
        }

        private void btnCancelAddNewDepartment_Click(object sender, EventArgs e)
        {
            this.txtAdminstrationName.Enabled = false;
            this.txtAdminstrationName.Clear();
            this.cbAdminDepartments.Enabled = false;
            this.ChbSubDepartment.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnAddNewDepartment.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEditDepartment"] != null)
                Application.OpenForms["frmEditDepartment"].Focus();
            else if (Application.OpenForms["frmEditDepartment"] == null)
            {
                frmEditDepartment frmHire = new frmEditDepartment();
                frmHire.Show();
                frmHire.MdiParent = Application.OpenForms["frmMain"];
                frmHire.WindowState = FormWindowState.Maximized;

            }
        }
    }
}