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
    public partial class DialogEditSearchedEmpsbyNamePanalties : Adjust
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        List<string> JobAndDept = new List<string>();

        //Get department name and job by using job ID


        public DialogEditSearchedEmpsbyNamePanalties(List<EmpName_Dept_Job> EmployeesMatchedNames)
        {
            InitializeComponent();
       

            for (int Index = 0; Index < EmployeesMatchedNames.Count; Index++)
            {
                dgvMatchedNames.Rows.Add(EmployeesMatchedNames[Index].EmpName,
                    EmployeesMatchedNames[Index].EmpDept, EmployeesMatchedNames[Index].EmpJob);
            }
        }

        private void DialogEditJob_Load(object sender, EventArgs e)
        {


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.dgvMatchedNames.SelectedRows.Count > 0)
            {
                frmEditPenalties frmEditEmployeesPanalties = (frmEditPenalties)Application.OpenForms["frmEditPenalties"];
                frmEditEmployeesPanalties.txtEmpName.Text = this.dgvMatchedNames.SelectedRows[0].Cells["EmployeeName"].Value.ToString();
                frmEditEmployeesPanalties.btnNameSearch_Click(sender, e);
                this.Close();
            }
        }

        private void dgvMatchedNames_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvMatchedNames.SelectedRows.Count > 0)
            {
                frmEditPenalties frmEditEmployeesPanalties = (frmEditPenalties)Application.OpenForms["frmEditPenalties"];
                frmEditEmployeesPanalties.txtEmpName.Text = this.dgvMatchedNames.SelectedRows[0].Cells["EmployeeName"].Value.ToString();
                frmEditEmployeesPanalties.btnNameSearch_Click(sender, e);
                this.Close();
            }
        }
    }
}
