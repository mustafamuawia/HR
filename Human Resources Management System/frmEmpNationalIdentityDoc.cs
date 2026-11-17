using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.IO;

namespace HR_MS
{
    public partial class frmEmpNationalIdentityDoc : Adjest
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        private int EmpID;
        private int QualificationID;
        private string EmpName;
        public MyList<Image> QualificationImages = new MyList<Image>();
        int PictureIndex = 0;
        private void QualificationImages_OnAdd(object sender, EventArgs e)
        {
            if (QualificationImages.Count > 0)
            {
                this.btnNext.Enabled = true;
                this.btnPrevious.Enabled = true;

            }
        }

        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff);
            return ms.ToArray();
        }

        public frmEmpNationalIdentityDoc(int EmpID, string EmpName)
        {
            InitializeComponent();
            this.EmpID = EmpID;
            this.EmpName = EmpName;
            //this.picbQualificationDoc.Image = QualificationImages[];
        }

        private void frmEmployeeDetails_Load(object sender, EventArgs e)
        {
            //Initialize FileID field
            SqlDataAdapter daGetQualificationID = new SqlDataAdapter("Select empid from db_Owner.Employees", SqlConn);
            DataTable dtGetQualificationID = new DataTable();
            daGetQualificationID.Fill(dtGetQualificationID);
            QualificationID = (dtGetQualificationID.Rows.Count + 1);

            QualificationImages.OnAdd += new EventHandler(QualificationImages_OnAdd);
            this.txtFileID.Text = (EmpID + 1).ToString();
            this.txtEmpName.Text = EmpName;

        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            DialogQualificationDocScan DialogQualifScan = new DialogQualificationDocScan();
            DialogQualifScan.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (PictureIndex < QualificationImages.Count - 1)
            {
                PictureIndex++;
                picbQualificationDoc.Image = QualificationImages[PictureIndex];

            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (PictureIndex > 0)
            {
                PictureIndex--;
                picbQualificationDoc.Image = QualificationImages[PictureIndex];

            }
        }

        private void btnAddPicture_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تود إضافة سجل الموظف", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sqlIns = "INSERT INTO db_owner.EmployeesQualifications " +
                        @"(EmpQualificationID,EmpID,EmpQualificationDocPicture)" +
                        @" VALUES (@ID, @EmpID,@Picure)";
                
                SqlConn.Open();
                try
                {

                    for (int Index = 0; Index < QualificationImages.Count; Index++)
                    {
                        SqlCommand cmdIns = new SqlCommand(sqlIns, SqlConn);
                        cmdIns.Parameters.AddWithValue("@ID", QualificationID);
                        cmdIns.Parameters.AddWithValue("@EmpID", EmpID);
                        cmdIns.Parameters.AddWithValue("@Picure", imageToByteArray(QualificationImages[Index]));

                        cmdIns.ExecuteNonQuery();

                        cmdIns.Parameters.Clear();
                        cmdIns.CommandText = "SELECT @@IDENTITY";

                        cmdIns.Dispose();
                        cmdIns = null;
                    }
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
            }
        }

         }
}
