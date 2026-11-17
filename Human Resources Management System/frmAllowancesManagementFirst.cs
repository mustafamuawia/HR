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
    public partial class frmAllowancesManagementFirst : Adjust
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=sa;Password=123");
        public frmAllowancesManagementFirst()
        {
            InitializeComponent();
        }


        private void InitializeAllowancesComboBox()
        {
            this.cbAllowances.Items.Clear();
            SqlDataAdapter daGetAllowancesFirst = new SqlDataAdapter(@"SELECT COLUMN_NAME
            FROM INFORMATION_SCHEMA.COLUMNS
            WHERE TABLE_NAME = 'AllowancesFirst' AND TABLE_SCHEMA='db_owner'", SqlConn);
            DataTable dtGetAllowancesFirst = new DataTable();
            daGetAllowancesFirst.Fill(dtGetAllowancesFirst);
            if (dtGetAllowancesFirst.Rows.Count != 0)
            {
                for (int index = 7; index < dtGetAllowancesFirst.Rows.Count; index++)
                {
                    DataRow DeducstionsRow = dtGetAllowancesFirst.Rows[index];
                    string ColumnName = DeducstionsRow["COLUMN_NAME"].ToString().Replace('_', ' ');
                    this.cbAllowances.Items.Add(ColumnName);
                }
            }
            if (this.cbAllowances.Items.Count != 0)
                this.cbAllowances.Text = this.cbAllowances.Items[0].ToString();
        }

        private void InitializeAllowancesListBox()
        {
            this.lbAllowances.Items.Clear();
            SqlDataAdapter daGetAllowancesFirst = new SqlDataAdapter(@"SELECT COLUMN_NAME
                                    FROM INFORMATION_SCHEMA.COLUMNS
                                    WHERE TABLE_NAME = 'AllowancesFirst' AND TABLE_SCHEMA='db_owner'", SqlConn);
            DataTable dtGetAllowancesFirst = new DataTable();
            daGetAllowancesFirst.Fill(dtGetAllowancesFirst);
            if (dtGetAllowancesFirst.Rows.Count != 0)
            {
                for (int index = 1; index < dtGetAllowancesFirst.Rows.Count; index++)
                {
                    DataRow DeducstionsRow = dtGetAllowancesFirst.Rows[index];
                    string ColumnName = DeducstionsRow["COLUMN_NAME"].ToString().Replace('_', ' ');
                    this.lbAllowances.Items.Add(ColumnName);
                }
            }
        }

        private void frmAllowancesManagement_Load(object sender, EventArgs e)
        {
            InitializeAllowancesComboBox();
            InitializeAllowancesListBox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string ColumnName = this.txtAllowanceName.Text.TrimEnd(' ').Replace(' ', '_');
                string SqlString = @"ALTER TABLE [HR].[db_owner].[AllowancesFirst] ADD " + ColumnName + " money NULL";
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

            InitializeAllowancesListBox();
            InitializeAllowancesComboBox();
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
                this.cbAllowances.Enabled = true;
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
                this.cbAllowances.Enabled = false;
            }
        }

        private void cbAllowances_DropDown(object sender, EventArgs e)
        {

        }

        private void cbAllowances_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnEditAllowanceName_Click(object sender, EventArgs e)
        {
            this.txtNewAllowanceName.Enabled = true;
            this.cbAllowances.Enabled = false;
            this.txtNewAllowanceName.Text = this.cbAllowances.Text;
            this.btnDeleteAllowance.Enabled = false;
            this.btnCancel.Enabled = true;
        }

        private void btnDeleteAllowance_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("(" + this.cbAllowances.Text + ") هل تود حذف", "تنبيه",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string ColumnName = this.cbAllowances.Text.Replace(' ', '_');
                    string SqlString = @"ALTER TABLE db_owner.AllowancesFirst DROP COLUMN " + ColumnName + "";
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

                InitializeAllowancesListBox();
                InitializeAllowancesComboBox();
            }
        }

        private void btnSaveEditAllowance_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تود تعديل اسم (" + this.cbAllowances.Text + ")", "تنبيه",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string ColumnName = this.txtNewAllowanceName.Text.TrimEnd(' ').Replace(' ', '_');
                    string SqlString = "sp_rename 'db_owner.AllowancesFirst." + this.cbAllowances.Text.Replace(' ', '_') + "'," +
                                        @"'" + ColumnName + "'";

                    SqlCommand SqlComm = new SqlCommand(SqlString, SqlConn);
                    SqlConn.Open();
                    SqlComm.ExecuteNonQuery();

                    SqlComm.Parameters.Clear();

                    SqlComm.Dispose();
                    SqlComm = null;
                    MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.btnDeleteAllowance.Enabled = true;

                    InitializeAllowancesListBox();
                    InitializeAllowancesComboBox();
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
            this.cbAllowances.Enabled = true;
            this.btnCancel.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}