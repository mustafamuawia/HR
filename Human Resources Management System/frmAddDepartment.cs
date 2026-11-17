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
    public partial class frmAddDepartment : Adjust
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        int DepartmentID, AdministratioID;


        public frmAddDepartment()
        {
            InitializeComponent();
        }

        private void InitializeDepartmentID()
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
            txtDepartmentID.Text = DepartmentID.ToString();
        }

        private void InitializeAdministrationID()
        {
            SqlDataAdapter daGetAdminID = new SqlDataAdapter(@"SELECT AdministrationID
            FROM db_owner.Administrations", SqlConn);
            DataTable dtGetAdminID = new DataTable();
            daGetAdminID.Fill(dtGetAdminID);
            if (dtGetAdminID.Rows.Count == 0)
            {
                AdministratioID = 1;
            }
            else
            {
                AdministratioID = Convert.ToInt32(dtGetAdminID.Rows[dtGetAdminID.Rows.Count - 1][0].ToString()) + 1;
            }
            txtAdministrationID.Text = AdministratioID.ToString();
        }
        private void InitializeAdministrationComboBox()
        {
            this.cbAdministrations.Items.Clear();
            SqlDataAdapter daGetAdminsNames = new SqlDataAdapter(@"SELECT AdministrationName
            FROM db_owner.Administrations", SqlConn);
            DataTable dtGetAdminsNames = new DataTable();
            daGetAdminsNames.Fill(dtGetAdminsNames);
            if (dtGetAdminsNames.Rows.Count != 0)
            {
                for (int index = 0; index < dtGetAdminsNames.Rows.Count; index++)
                {
                    this.cbAdministrations.Items.Add(dtGetAdminsNames.Rows[index]["AdministrationName"].ToString());
                }
                this.cbAdministrations.Text = this.cbAdministrations.Items[0].ToString();
            }

        }


        private void InitializeDepartmentsTreeView()
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
                    SqlDataAdapter daGetDepartments = new SqlDataAdapter(@"SELECT db_owner.Departments.DeptName 
                    FROM db_owner.Departments INNER JOIN 
                    db_owner.Administrations on 
                    db_owner.Departments.AdminDepID = db_owner.Administrations.AdministrationID  
                    where (db_owner.Administrations.AdministrationNAme 
                    = N'" + dtGetAdministrations.Rows[index][0].ToString() + "')", SqlConn);

                    DataTable dtGetDepartments = new DataTable();
                    daGetDepartments.Fill(dtGetDepartments);

                    for (int CIndex = 0; CIndex < dtGetDepartments.Rows.Count; CIndex++)
                    {
                        this.tvHierarchicalTree.Nodes[index].Nodes.Add(dtGetDepartments.Rows[CIndex][0].ToString());
                    }
                }
        }

        private void frmAddDepartment_Load(object sender, EventArgs e)
        {
            InitializeAdministrationID();
            InitializeDepartmentID();
            InitializeDepartmentsTreeView();
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
            txtDepartmentID.Text = DepartmentID.ToString();
            this.txtDepartmentName.Enabled = true;
            this.cbAdministrations.Enabled = true;
            this.btnCancelAddDept.Enabled = true;
            this.btnAddNewDepartment.Enabled = false;
            this.btnSaveDept.Enabled = true;

        }

        private void btnSaveDepartment_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تود إضافة القسم", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                SqlConn.Open();
                try
                {
                    //string sqlCommand = "Select DeptID from db_owner.Departments " +
                    //@"Where DeptName='" + this.cbAdminDepartments.Text + "'";
                    //SqlDataAdapter daGetDeparmentName = new SqlDataAdapter(sqlCommand, SqlConn);
                    //DataTable dtGetDeparmentName = new DataTable();
                    //daGetDeparmentName.Fill(dtGetDeparmentName);
                    //string sqlIns;
                    //if (this.ChbSubDepartment.Checked == true)
                    string GetAdminID = @"(SELECT AdministrationID
                    FROM db_owner.Administrations
                    where AdministrationName='"+this.cbAdministrations.Text+"')";
                    
                    string sqlIns = "INSERT INTO db_owner.Departments " +
                    @"(DeptID, DeptName, AdminDepID) " +
                    @" VALUES (@ID, @Name, "+GetAdminID+")";
                    //}
                    //else
                    //{
                    //    sqlIns = "INSERT INTO db_owner.Departments " +
                    //       @"(DeptID, DeptName) " +
                    //       @" VALUES (@ID, @Name)";
                    //}
                    SqlCommand cmdIns = new SqlCommand(sqlIns, SqlConn);
                    cmdIns.Parameters.AddWithValue("@ID", this.txtDepartmentID.Text);
                    cmdIns.Parameters.AddWithValue("@Name", this.txtDepartmentName.Text);
                    cmdIns.ExecuteNonQuery();

                    cmdIns.Parameters.Clear();
                    cmdIns.Dispose();
                    cmdIns = null;

                    MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.btnSaveDept.Enabled = false;
                    this.btnAddNewDepartment.Enabled = true;
                    this.btnCancelAddDept.Enabled = false;
                    this.txtDepartmentName.Clear();
                    this.txtDepartmentName.Enabled = false;
                    this.cbAdministrations.Enabled = false;

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

        private void btnCancelAddNewDepartment_Click(object sender, EventArgs e)
        {
            this.txtDepartmentName.Enabled = false;
            this.cbAdministrations.Enabled = false;
            this.btnCancelAddDept.Enabled = false;
            this.btnAddNewDepartment.Enabled = true;
            this.btnSaveDept.Enabled = false;
            this.txtDepartmentName.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEditDepartment"] != null)
                Application.OpenForms["frmEditDepartment"].Focus();
            else if (Application.OpenForms["frmEditDepartment"] == null)
            {
                frmEditDepartment frmEditAdminAndDept = new frmEditDepartment();
                frmEditAdminAndDept.Show();
                frmEditAdminAndDept.MdiParent = Application.OpenForms["frmMain"];
                frmEditAdminAndDept.WindowState = FormWindowState.Maximized;

            }
        }

        private void rbAddAdministration_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbAddAdministration.Checked == true)
            {
                this.gbAddAdministration.Enabled = true;
                this.gbAddDepartment.Enabled = false;
            }
        }

        private void rbAddDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbAddDepartment.Checked == true)
            {
                this.gbAddAdministration.Enabled = false;
                this.gbAddDepartment.Enabled = true;
                InitializeAdministrationComboBox();
            }
        }

        private void gbAddAdministration_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddNewAdmin_Click(object sender, EventArgs e)
        {
            SqlDataAdapter daGetAdminID = new SqlDataAdapter("Select AdministrationID from db_Owner.Administrations", SqlConn);
            DataTable dtGetAdminID = new DataTable();
            daGetAdminID.Fill(dtGetAdminID);
            if (dtGetAdminID.Rows.Count == 0)
            {
                AdministratioID = 1;
            }
            else
            {
                AdministratioID = Convert.ToInt32(dtGetAdminID.Rows[dtGetAdminID.Rows.Count - 1][0].ToString()) + 1;
            }
            this.btnCancelAddAdmin.Enabled = true;
            this.btnAddNewAdmin.Enabled = false;
            this.txtAdministrationName.Enabled = true;
            this.btnSaveAdmin.Enabled = true;
        }

        private void btnCancelAddAdmin_Click(object sender, EventArgs e)
        {
            this.btnCancelAddAdmin.Enabled = false;
            this.btnAddNewAdmin.Enabled = true;
            this.btnSaveAdmin.Enabled = false;
        }

        private void btnSaveAdmin_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تود إضافة الإدارة", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                SqlConn.Open();
                try
                {
                    string sqlIns = "INSERT INTO db_owner.Administrations " +
                           @"(AdministrationID, AdministrationName) " +
                           @" VALUES (@ID, @Name)";
                    SqlCommand cmdIns = new SqlCommand(sqlIns, SqlConn);
                    cmdIns.Parameters.AddWithValue("@ID", this.txtAdministrationID.Text);
                    cmdIns.Parameters.AddWithValue("@Name", this.txtAdministrationName.Text);

                    cmdIns.ExecuteNonQuery();

                    cmdIns.Parameters.Clear();

                    cmdIns.Dispose();
                    cmdIns = null;
                    MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.btnAddNewAdmin.Enabled = true;
                    this.btnSaveAdmin.Enabled = false;
                    this.txtAdministrationName.Enabled = false;

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
    }
}