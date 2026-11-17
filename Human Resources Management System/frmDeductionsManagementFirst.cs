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
    public partial class frmDeductionsManagementFirst : Adjust
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=sa;Password=123");
        public frmDeductionsManagementFirst()
        {
            InitializeComponent();
        }


        private void InitializeDeductionsComboBox()
        {
            this.cbDeductions.Items.Clear();
            SqlDataAdapter daGetDeductionsFirst = new SqlDataAdapter(@"SELECT COLUMN_NAME
                                    FROM INFORMATION_SCHEMA.COLUMNS
                                    WHERE TABLE_NAME = 'DeductionsFirst' AND TABLE_SCHEMA='db_owner'", SqlConn);
            DataTable dtGetDeductionsFirst = new DataTable();
            daGetDeductionsFirst.Fill(dtGetDeductionsFirst);
            if (dtGetDeductionsFirst.Rows.Count != 0)
            {
                for (int index = 9; index < dtGetDeductionsFirst.Rows.Count; index++)
                {
                    DataRow DeducstionsRow = dtGetDeductionsFirst.Rows[index];
                    string ColumnName = DeducstionsRow["COLUMN_NAME"].ToString().Replace('_', ' ');
                    this.cbDeductions.Items.Add(ColumnName);
                }
            }
            if (this.cbDeductions.Items.Count != 0)
                this.cbDeductions.Text = this.cbDeductions.Items[0].ToString();
        }
        private void InitializeDeductionsListBox()
        {
            this.lbDeductions.Items.Clear();
            SqlDataAdapter daGetDeductionsFirst = new SqlDataAdapter(@"SELECT COLUMN_NAME
                                    FROM INFORMATION_SCHEMA.COLUMNS
                                    WHERE TABLE_NAME = 'DeductionsFirst' AND TABLE_SCHEMA='db_owner'", SqlConn);
            DataTable dtGetDeductionsFirst = new DataTable();
            daGetDeductionsFirst.Fill(dtGetDeductionsFirst);
            if (dtGetDeductionsFirst.Rows.Count != 0)
            {
                if (dtGetDeductionsFirst.Rows.Count != 0)
                {
                    for (int index = 1; index < dtGetDeductionsFirst.Rows.Count; index++)
                    {
                        DataRow DeducstionsRow = dtGetDeductionsFirst.Rows[index];
                        string ColumnName = DeducstionsRow["COLUMN_NAME"].ToString().Replace('_', ' ');
                        this.lbDeductions.Items.Add(ColumnName);
                    }
                }
            }
        }
        private void frmDeductionsManagement_Load(object sender, EventArgs e)
        {
            InitializeDeductionsComboBox();
            InitializeDeductionsListBox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string ColumnName = this.txtAllowanceName.Text.TrimEnd(' ').Replace(' ', '_');
                string SqlString = @"ALTER TABLE [HR].[db_owner].[DeductionsFirst] ADD " + ColumnName + " money NULL";
                SqlCommand SqlComm = new SqlCommand(SqlString, SqlConn);
                SqlConn.Open();
                SqlComm.ExecuteNonQuery();

                SqlComm.Parameters.Clear();

                SqlComm.Dispose();
                SqlComm = null;
                MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                SqlConn.Close();
            }

            InitializeDeductionsListBox();
            InitializeDeductionsComboBox();
        }

        private void rbEditAllowance_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbEditAllowance.Checked == true)
            {
                this.txtAllowanceName.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnSaveEditAllowance.Enabled = true;
                this.btnEditAllowanceName.Enabled = true;
                this.btnDeleteAllowance.Enabled = true;
                //this.btnCancel.Enabled = true;
                this.cbDeductions.Enabled = true;
            }
        }

        private void rbAddAllowance_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbAddAllowance.Checked == true)
            {
                this.txtAllowanceName.Enabled = true;
                this.btnSave.Enabled = true;
                this.btnSaveEditAllowance.Enabled = false;
                this.btnDeleteAllowance.Enabled = false;
                this.btnEditAllowanceName.Enabled = false;
                this.btnCancel.Enabled = false;
                this.txtNewAllowanceName.Enabled = false;
                this.cbDeductions.Enabled = false;
            }
        }

        private void cbDeductions_DropDown(object sender, EventArgs e)
        {

        }

        private void cbDeductions_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnEditAllowanceName_Click(object sender, EventArgs e)
        {
            this.txtNewAllowanceName.Enabled = true;
            this.cbDeductions.Enabled = false;
            this.txtNewAllowanceName.Text = this.cbDeductions.Text;
            this.btnDeleteAllowance.Enabled = false;
            this.btnCancel.Enabled = true;
        }

        private void btnDeleteAllowance_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("(" + this.cbDeductions.Text + ") هل تود حذف", "تنبيه",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string ColumnName = this.cbDeductions.Text.Replace(' ', '_');
                    string SqlString = @"ALTER TABLE db_owner.DeductionsFirst DROP COLUMN " + ColumnName + "";
                    SqlCommand SqlComm = new SqlCommand(SqlString, SqlConn);
                    SqlConn.Open();
                    SqlComm.ExecuteNonQuery();

                    SqlComm.Parameters.Clear();

                    SqlComm.Dispose();
                    SqlComm = null;
                    MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    SqlConn.Close();
                }

                InitializeDeductionsListBox();
                InitializeDeductionsComboBox();
            }
        }

        private void btnSaveEditAllowance_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تود تعديل اسم (" + this.cbDeductions.Text + ")", "تنبيه",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string ColumnName = this.txtNewAllowanceName.Text.TrimEnd(' ').Replace(' ', '_');
                    string SqlString = "sp_rename 'db_owner.DeductionsFirst." + this.cbDeductions.Text.Replace(' ', '_') + "'," +
                                        @"'" + ColumnName + "'";

                    SqlCommand SqlComm = new SqlCommand(SqlString, SqlConn);
                    SqlConn.Open();
                    SqlComm.ExecuteNonQuery();

                    SqlComm.Parameters.Clear();

                    SqlComm.Dispose();
                    SqlComm = null;
                    MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.btnDeleteAllowance.Enabled = true;

                    InitializeDeductionsListBox();
                    InitializeDeductionsComboBox();
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
            this.btnDeleteAllowance.Enabled = true;
            this.btnEditAllowanceName.Enabled = true;
            this.txtNewAllowanceName.Enabled = false;
            this.txtNewAllowanceName.Text = "";
            this.cbDeductions.Enabled = true;
            this.btnCancel.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}