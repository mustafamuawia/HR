using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace HR_MS
{
    public partial class DialogMedicalFormsSearch : Adjust
    {
        CultureInfo ArabicEgypt = new CultureInfo("en-US");
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        public DialogMedicalFormsSearch(DataTable dtMedicalForms)
        {
            InitializeComponent();
           
                for (int i=0;i<dtMedicalForms.Rows.Count;i++)
                {
                    DataRow row = dtMedicalForms.Rows[i];
                    dgvMatched.Rows.Add(row["MedicalFormID"].ToString(), Convert.ToString(row["EmpName"]),
                    Convert.ToDateTime(row["Date"]).ToShortDateString(), Convert.ToString(row["Notes"]));
                }
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.dgvMatched.SelectedRows.Count > 0)
            {
                frmEditMedicalForm frmEdtMediccalForms = (frmEditMedicalForm)Application.OpenForms["frmEditMedicalForm"];
                //frmEdtMediccalForms.MedicalFormID =
                frmEdtMediccalForms.txtMedicalFormID.Text = dgvMatched.SelectedRows[0].Cells[0].Value.ToString();
                frmEdtMediccalForms.dtpDate.Value = Convert.ToDateTime(dgvMatched.SelectedRows[0].Cells[2].Value);
                frmEdtMediccalForms.txtNotes.Text = dgvMatched.SelectedRows[0].Cells[3].Value.ToString();
                frmEdtMediccalForms.btnNameSearch_Click(sender, e);
                frmEdtMediccalForms.btnEditMedicalForm.Enabled = true;
                this.Close();
            }
        }

        private void DialogLoansSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
