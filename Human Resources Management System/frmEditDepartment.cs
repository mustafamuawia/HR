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
    public partial class frmEditDepartment : Adjust
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");

        public frmEditDepartment()
        {
            InitializeComponent();
        }

        private void InitializeDepartmentsComboBox()
        {
            this.cbDepartments.Items.Clear();
            SqlDataAdapter daGetDepartments = new SqlDataAdapter("SELECT  DeptName " +
           @"from db_Owner.Departments inner join
db_Owner.Administrations on
db_Owner.Departments.AdminDepID = db_Owner.Administrations.AdministrationID
where db_Owner.Administrations.AdministrationName = '" + this.cbAdministrations.Text + "' ", SqlConn);
            DataTable dtGetDepartments = new DataTable();
            daGetDepartments.Fill(dtGetDepartments);
            if (dtGetDepartments.Rows.Count != 0)
            {
                foreach (DataRow DepartmentRow in dtGetDepartments.Rows)
                    if (!this.cbDepartments.Items.Contains(DepartmentRow["DeptName"].ToString()))
                        this.cbDepartments.Items.Add(DepartmentRow["DeptName"].ToString());
                this.cbDepartments.Text = this.cbDepartments.Items[0].ToString();
            }
        }
        private void InitializeAdministrationComboBox(string ComboBoxName)
        {
            ComboBox AdministrationComboBox;
            if (ComboBoxName == "cbAllAdministrations")
                AdministrationComboBox = (ComboBox)this.Controls["gbAdministrations"].Controls[ComboBoxName];
            else
                AdministrationComboBox = (ComboBox)this.Controls["gbDepartments"].Controls[ComboBoxName];
            AdministrationComboBox.Items.Clear();
            SqlDataAdapter daGetAdminsNames = new SqlDataAdapter(@"SELECT AdministrationName
                        FROM db_owner.Administrations", SqlConn);
            DataTable dtGetAdminsNames = new DataTable();
            daGetAdminsNames.Fill(dtGetAdminsNames);
            if (dtGetAdminsNames.Rows.Count != 0)
            {
                for (int index = 0; index < dtGetAdminsNames.Rows.Count; index++)
                {
                    AdministrationComboBox.Items.Add(dtGetAdminsNames.Rows[index]["AdministrationName"].ToString());
                }
                AdministrationComboBox.Text = AdministrationComboBox.Items[0].ToString();
            }

        }
        

        private void InitializeHierarchicalTreeTreeView()
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
            InitializeAdministrationComboBox("cbAllAdministrations");
            InitializeHierarchicalTreeTreeView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (this.cbDepartments.Text == this.cbAllAdministrations.Text)
            //    MessageBox.Show("لا يمكن للقسم أن يكون تحت نفسه", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else if (MessageBox.Show("هل تود تعديل القسم", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    SqlConn.Open();
            //    try
            //    {
            //        string sqlCommand = "Select DeptID from db_owner.Departments " +
            //        @"Where DeptName='" + this.cbDepartments.Text + "'";
            //        SqlDataAdapter daGetDeparmentName = new SqlDataAdapter(sqlCommand, SqlConn);
            //        DataTable dtGetDeparmentName = new DataTable();
            //        daGetDeparmentName.Fill(dtGetDeparmentName);
            //        string sqlIns;
            //        if (this.ChbSubDepartment.Checked == true)
            //        {
            //            sqlIns = "Update db_owner.Departments " +
            //            @"set DeptName =@Name , AdminDepID = @AdminDepID  " +
            //            @"where DeptID ='" + this.txtDepartmentID.Text + "'";
            //        }
            //        else
            //        {
            //            sqlIns = "Update db_owner.Departments " +
            //               @"set DeptName =@Name , AdminDepID = null  " +
            //            @"where DeptID ='" + this.txtDepartmentID.Text + "'";
            //        }
            //        SqlCommand cmdIns = new SqlCommand(sqlIns, SqlConn);
            //        cmdIns.Parameters.AddWithValue("@ID", this.txtDepartmentID.Text);
            //        cmdIns.Parameters.AddWithValue("@Name", this.txtNewDepartmentName.Text);
            //        if (this.ChbSubDepartment.Checked == true)
            //            cmdIns.Parameters.AddWithValue("@AdminDepID", Convert.ToInt32(dtGetDeparmentName.Rows[0]["DeptID"]));
            //        else cmdIns.Parameters.AddWithValue("@AdminDepID", DBNull.Value);
            //        cmdIns.ExecuteNonQuery();

            //        cmdIns.Parameters.Clear();
            //        cmdIns.CommandText = "SELECT @@IDENTITY";

            //        cmdIns.Dispose();
            //        cmdIns = null;
            //        MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //        this.btnCancelAddNewDepartment.Enabled = false;
            //        this.btnSave.Enabled = false;
            //        this.txtNewDepartmentName.Enabled = false;
            //        this.ChbSubDepartment.Enabled = false;
            //        this.cbDepartments.Enabled = false;
            //        this.btnDeleteDepartment.Enabled = true;
            //        this.cbAllAdministrations.Enabled = true;
            //        InitializeAllDepartmentsComboBox();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message.ToString());
            //    }
            //    finally
            //    {
            //        SqlConn.Close();
            //    }
            //    InitializeDepartmentsTreeView();
            //}
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChbSubDepartment_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.ChbSubDepartment.Checked == true)
            //{
            //    this.cbDepartments.Enabled = true;
            //    SqlDataAdapter daGetDepartments = new SqlDataAdapter("SELECT  DeptName " +
            //    @"from db_Owner.Departments where AdminDepID is NULL " +
            //    @"AND Deptname<>'" + this.cbAllAdministrations.Text + "'", SqlConn);
            //    DataTable dtGetDepartments = new DataTable();
            //    daGetDepartments.Fill(dtGetDepartments);
            //    if (dtGetDepartments.Rows.Count != 0)
            //    {
            //        foreach (DataRow DepartmentRow in dtGetDepartments.Rows)
            //            if (!this.cbDepartments.Items.Contains(DepartmentRow["DeptName"].ToString()))
            //                this.cbDepartments.Items.Add(DepartmentRow["DeptName"].ToString());
            //    }
            //}
            //else this.cbDepartments.Enabled = false;
        }

        private void btnCancelAddNewDepartment_Click(object sender, EventArgs e)
        {
            //this.txtNewDepartmentName.Enabled = false;
            //this.txtNewDepartmentName.Clear();
            //this.cbDepartments.Enabled = false;
            //this.ChbSubDepartment.Enabled = false;
            //this.btnSave.Enabled = false;
            //this.btnDeleteDepartment.Enabled = true;
            //this.btnCancelAddNewDepartment.Enabled = false;
            //this.cbAllAdministrations.Enabled = true;
        }

        private void btnEditDepartment_Click(object sender, EventArgs e)
        {

        }
        
        private void rbAdministrations_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbAdministrations.Checked == true)
            {
                this.gbAdministrations.Enabled = true;
                this.gbDepartments.Enabled = false;
                InitializeAdministrationComboBox("cbAllAdministrations");
            }

        }

        private void rbDepartments_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbDepartments.Checked == true)
            {
                this.gbAdministrations.Enabled = false;
                this.gbDepartments.Enabled = true;
                InitializeAdministrationComboBox("cbAdministrations");
                InitializeDepartmentsComboBox();
            }
        }

        private void btnSaveAdministraion_Click(object sender, EventArgs e)
        {
            string SqlUpdate = @"Update db_owner.Administrations 
                    SET AdministrationName = @Name 
where AdministrationName = '" + this.cbAllAdministrations.Text + "'";
            SqlCommand SqlComm = new SqlCommand(SqlUpdate, SqlConn);
            SqlComm.Parameters.AddWithValue("@Name", this.txtNewAdminName.Text);
            try
            {
                SqlConn.Open();
            SqlComm.ExecuteNonQuery();

            SqlComm.Parameters.Clear();

            SqlComm.Dispose();
            SqlComm = null;
            MessageBox.Show("تم التعديل بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
            this.btnEditAdministrationName.Enabled = true;
            this.btnSaveAdministraion.Enabled = false;
            this.btnCancelEditAdminName.Enabled = false;
            this.txtNewAdminName.Enabled = false;
            this.txtNewAdminName.Clear();
            this.cbAllAdministrations.Enabled = true;
            InitializeHierarchicalTreeTreeView();
            InitializeAdministrationComboBox("cbAllAdministrations");
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

        private void btnEditAdministrationName_Click(object sender, EventArgs e)
        {
            this.btnEditAdministrationName.Enabled = false;
            this.btnSaveAdministraion.Enabled = true;
            this.btnCancelEditAdminName.Enabled = true;
            this.txtNewAdminName.Enabled = true;
            this.txtNewAdminName.Text = this.cbAllAdministrations.Text;
            this.cbAllAdministrations.Enabled = false;
        }

        private void btnCancelEditAdminName_Click(object sender, EventArgs e)
        {
            this.btnEditAdministrationName.Enabled = true;
            this.txtNewAdminName.Enabled = false;
            this.txtNewAdminName.Clear();
            this.cbAllAdministrations.Enabled = true;
            this.btnSaveAdministraion.Enabled = false;
            this.btnCancelEditAdminName.Enabled = false;
        }

        private void btnEditDeptName_Click(object sender, EventArgs e)
        {
            this.cbAdministrations.Enabled = false;
            this.cbDepartments.Enabled = false;
            this.txtNewDepartmentName.Enabled = true;
            this.txtNewDepartmentName.Text = this.cbDepartments.Text;
            this.btnEditDeptAdmin.Enabled = false;
            this.btnCalcelEditDept.Enabled = true;
            this.btnEditDeptName.Enabled = false;
        }

        private void btnCalcelEditDept_Click(object sender, EventArgs e)
        {
            this.cbAdministrations.Enabled = true;
            this.cbDepartments.Enabled = true;
            this.txtNewDepartmentName.Enabled = false;
            this.txtNewDepartmentName.Clear();
            this.btnEditDeptAdmin.Enabled = true;
            this.btnCalcelEditDept.Enabled = false;
            this.btnEditDeptName.Enabled = true;
            this.cbNewAdministration.Enabled = false;
            this.cbNewAdministration.Items.Clear();
        }

        private void btnEditDeptAdmin_Click(object sender, EventArgs e)
        {
            this.cbAdministrations.Enabled = false;
            this.cbDepartments.Enabled = false;
            this.btnEditDeptAdmin.Enabled = false;
            this.btnCalcelEditDept.Enabled = true;
            this.btnEditDeptName.Enabled = false;
            this.cbNewAdministration.Enabled = true;
            InitializeAdministrationComboBox("cbNewAdministration");
        }

        private void cbAdministrations_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeDepartmentsComboBox();
        }

        private void btnDelAdministration_Click(object sender, EventArgs e)
        {
            string SqlUpdate = @"delete from db_owner.Administrations 
                   
where AdministrationName = '" + this.cbAllAdministrations.Text + "'";
            SqlCommand SqlComm = new SqlCommand(SqlUpdate, SqlConn);
            SqlComm.Parameters.AddWithValue("@Name", this.txtNewAdminName.Text);
            try
            {
                SqlConn.Open();
                SqlComm.ExecuteNonQuery();

                SqlComm.Parameters.Clear();

                SqlComm.Dispose();
                SqlComm = null;
                MessageBox.Show("تم التعديل بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
                this.btnEditAdministrationName.Enabled = true;
                this.btnSaveAdministraion.Enabled = false;
                this.btnCancelEditAdminName.Enabled = false;
                this.txtNewAdminName.Enabled = false;
                this.txtNewAdminName.Clear();
                this.cbAllAdministrations.Enabled = true;
                InitializeHierarchicalTreeTreeView();
                InitializeAdministrationComboBox("cbAllAdministrations");
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

        private void btnSaveDepartment_Click(object sender, EventArgs e)
        {
            if (this.txtNewDepartmentName.Enabled == true)
            {
                string SqlUpdate = @"Update db_owner.Departments 
                    SET DeptName = @Name where DeptName = '"+this.cbDepartments.Text+"'";

                SqlCommand SqlComm = new SqlCommand(SqlUpdate, SqlConn);
                SqlComm.Parameters.AddWithValue("@Name", this.txtNewDepartmentName.Text);
                try
                {
                    SqlConn.Open();
                    SqlComm.ExecuteNonQuery();

                    SqlComm.Parameters.Clear();

                    SqlComm.Dispose();
                    SqlComm = null;
                    MessageBox.Show("تم التعديل بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.cbAdministrations.Enabled = true;
                    this.cbNewAdministration.Enabled = false;
                    this.cbDepartments.Enabled = true;
                    this.txtNewDepartmentName.Enabled = false;
                    this.txtNewDepartmentName.Clear();
                    this.btnEditDeptAdmin.Enabled = true;
                    this.btnCalcelEditDept.Enabled = false;
                    this.btnEditDeptName.Enabled = true;
                    InitializeHierarchicalTreeTreeView();
                    InitializeDepartmentsComboBox();
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
            else if (this.cbNewAdministration.Enabled == true)
            {

                string SqlUpdate = @"Update db_owner.Departments 
                    SET AdminDepID = (select administrationID from db_owner.Administrations
                    where AdministrationName='"+this.cbNewAdministration.Text+"')"+
                    @" where DeptName='"+this.cbDepartments.Text+"'";

                SqlCommand SqlComm = new SqlCommand(SqlUpdate, SqlConn);
                
                try
                {
                    SqlConn.Open();
                    SqlComm.ExecuteNonQuery();

                  
                    SqlComm.Dispose();
                    SqlComm = null;
                    MessageBox.Show("تم التعديل بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.cbAdministrations.Enabled = true;
                    this.cbNewAdministration.Enabled = false;
                    this.cbDepartments.Enabled = true;
                    this.txtNewDepartmentName.Enabled = false;
                    this.txtNewDepartmentName.Clear();
                    this.btnEditDeptAdmin.Enabled = true;
                    this.btnCalcelEditDept.Enabled = false;
                    this.btnEditDeptName.Enabled = true;
                    InitializeHierarchicalTreeTreeView();
                    InitializeDepartmentsComboBox();
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

        private void cbAllAdministrations_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}