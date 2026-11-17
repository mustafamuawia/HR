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
    public partial class DialogPanaltiesSearch : Adjust
    {
        CultureInfo ArabicEgypt = new CultureInfo("en-US");
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        public DialogPanaltiesSearch(DataTable Panalties)
        {
            InitializeComponent();
            foreach (DataRow PanaltyRow in Panalties.Rows)
            {
                string strGetPanalties = @"SELECT Panalties.PanaltyID, Employees.EmpName, Panalties.Date,
                Panalties.DeductionsTotal, Panalties.Note
                FROM         Employees INNER JOIN
                Panalties ON Employees.EmpID = Panalties.EmpID
                where PanaltyID= '" + PanaltyRow["PanaltyID"].ToString() +"'";

                SqlDataAdapter daGetPanalties = new SqlDataAdapter(strGetPanalties, SqlConn);
                DataTable dtGetPanalties = new DataTable();
                daGetPanalties.Fill(dtGetPanalties);
                for (int i=0;i<dtGetPanalties.Rows.Count;i++)
                {
                    DataRow row = dtGetPanalties.Rows[i];


                    dgvMatchedNames.Rows.Add(row["PanaltyID"].ToString(), row["EmpName"].ToString(),
                    DateTime.Parse(row["Date"].ToString()).ToShortDateString(), double.Parse(row["DeductionsTotal"].ToString()).ToString("0,0.00", ArabicEgypt), row["Note"].ToString());
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.dgvMatchedNames.SelectedRows.Count > 0)
            {
                frmEditPenalties frmEdtPanalties = (frmEditPenalties)Application.OpenForms["frmEditPenalties"];
                SqlDataAdapter daGetPanaltyDeductions = new SqlDataAdapter(@"Select Month,MonthHalfDedction
                ,MonthEndDedction
            from db_Owner.PanaltiesDeductions
            where PanaltyID= '" + dgvMatchedNames.SelectedRows[0].Cells[0].Value.ToString()+ "'", SqlConn);
                DataTable dtGetPanaltyDeductions = new DataTable();
                daGetPanaltyDeductions.Fill(dtGetPanaltyDeductions);
                for (int i = 0; i < dtGetPanaltyDeductions.Rows.Count; i++)
                {
                    ListViewItem lv = new ListViewItem(dtGetPanaltyDeductions.Rows[i]["Month"].ToString());
                    lv.SubItems.Add(double.Parse(dtGetPanaltyDeductions.Rows[i]["MonthHalfDedction"].ToString()).ToString("0,0.00", ArabicEgypt));
                    lv.SubItems.Add(double.Parse(dtGetPanaltyDeductions.Rows[i]["MonthEndDedction"].ToString()).ToString("0,0.00", ArabicEgypt));
                    frmEdtPanalties.listView1.Items.Add(lv);
                }
                frmEdtPanalties.dtpDate.Value = Convert.ToDateTime(dgvMatchedNames.SelectedRows[0].Cells[2].Value);
                frmEdtPanalties.PanaltyID = Convert.ToInt32(dgvMatchedNames.SelectedRows[0].Cells[0].Value.ToString());
                frmEdtPanalties.txtPanaltyID.Text = Convert.ToInt32(dgvMatchedNames.SelectedRows[0].Cells[0].Value).ToString();
                frmEdtPanalties.txtDeductionTotal.Text = dgvMatchedNames.SelectedRows[0].Cells[3].Value.ToString();
                frmEdtPanalties.txtNote.Text = dgvMatchedNames.SelectedRows[0].Cells[4].Value.ToString();
                //frmDialywrkrsEditFiles.btnNameSearch_Click(sender, e);
                frmEdtPanalties.btnEditPanalty.Enabled = true;
                this.Close();
            }
        }

        private void DialogPanaltiesSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
