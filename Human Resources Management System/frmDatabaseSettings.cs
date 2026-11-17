using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
namespace HR_MS
{
    public partial class frmDatabaseSettings : Adjust
    {
        public frmDatabaseSettings()
        {
            InitializeComponent();
        }

        private void frmDatabaseSettings_Load(object sender, EventArgs e)
        {

        }


        private void cbDataBases_DropDown(object sender, EventArgs e)
        {

            try
            {
                DataTable tables = new DataTable("Tables");
                SqlConnection connection = new SqlConnection("Data Source=" + this.cbServerName.Text +"\\"+ this.cbInistanceName.Text+ ";user id=sa;password=123");
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM sys.databases";
                connection.Open();
                tables.Load(command.ExecuteReader(CommandBehavior.CloseConnection));

                foreach (DataRow row in tables.Rows)
                    if (!this.cbDataBases.Items.Contains(row[0].ToString()))
                        this.cbDataBases.Items.Add(row[0].ToString());
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading available databases: " + ex.ToString());
            }

        }

        private void btnConnectionTest_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=" + this.cbServerName.Text + "\\" + this.cbInistanceName.Text + ";user id=EmpAdmin;password=123;initial catalog=" + this.cbDataBases.Text + "");
            try
            {
                connection.Open();
            }

            catch
            {
                // Connection failed
                MessageBox.Show("فشل في الاتصال");
                return;
            }
            MessageBox.Show("اتصال ناجح!");
            //  Close the connection 

            connection.Close();
        }

        private void btnGetDatabaseServers_Click(object sender, EventArgs e)
        {

            DataTable dtSqlServers = new DataTable();
            dtSqlServers = SmoApplication.EnumAvailableSqlServers();
          
            foreach (DataRow Server in dtSqlServers.Rows)
            {
                this.cbServerName.Items.Add(Server["Server"]);
                this.cbInistanceName.Items.Add(Server["Instance"]);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.DatabaseServer = this.cbServerName.Text+"\\"+this.cbInistanceName.Text;
                Properties.Settings.Default.DatabaseName = this.cbDataBases.Text;
                Properties.Settings.Default.Save();
            }
            catch
            {
                MessageBox.Show("لم تتم عملية الحفظ");
                return;
            }
            if (MessageBox.Show("تم الحفظ بنجاح هل تود الخروج", " ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();

        }

        private void cbDataBases_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbInistanceName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbServerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

           
   }
}