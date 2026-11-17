using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HR_MS
{
    public partial class frmEditEmployeeAllowances : Form
    {
        public frmEditEmployeeAllowances(DataGridViewColumnCollection EmployeeColumns,DataGridViewRow EmployeeRow)
        {
            InitializeComponent();

            foreach (DataGridViewColumn EmployeeColumn in EmployeeColumns)
                MessageBox.Show(EmployeeColumn.HeaderText.ToString());
                //this.dgvSalaries.Columns.Add(EmployeeColumn);
            //this.dgvSalaries.Rows.Add(EmployeeRow);
        }

        private void frmEditEmployeeAllowances_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdateAllowances_Click(object sender, EventArgs e)
        {

        }
    }
}
