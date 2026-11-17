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
    public partial class frmEmployeeQualifications : Adjust
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        private int EmpID;
        private int QualificationID;
        private string EmpName;
        public MyList<Image> QualificationImages = new MyList<Image>();
        public int PictureIndex = 0;
        private void QualificationImages_OnAdd(object sender, EventArgs e)
        {
            if (QualificationImages.Count > -1)
            {
                this.btnDeleteImage.Enabled = true;
            }
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

        private void QualificationImages_OnRemove(object sender, EventArgs e)
        {
            if (QualificationImages.Count <= 1)
            {
                this.btnDeleteImage.Enabled = false;

            }
            if (QualificationImages.Count <= 2)
            {
                this.btnNext.Enabled = false;
                this.btnPrevious.Enabled = false;
            }
        }

        public frmEmployeeQualifications(int EmpID, string EmpName)
        {
            InitializeComponent();
            this.EmpID = EmpID;
            this.EmpName = EmpName;
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


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تود إضافة المؤهلات إلى سجل الموظف", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                        cmdIns.Parameters.AddWithValue("@ID", QualificationID + Index);
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

        private void frmEmployeeQualifications_Load(object sender, EventArgs e)
        {
            //Initialize FileID field
            SqlDataAdapter daGetEmpID = new SqlDataAdapter("Select empid from db_Owner.Employees", SqlConn);
            DataTable dtGetEmpID = new DataTable();
            daGetEmpID.Fill(dtGetEmpID);
            txtFileID.Text = (dtGetEmpID.Rows.Count + 1).ToString();

            QualificationImages.OnAdd += new EventHandler(QualificationImages_OnAdd);
            QualificationImages.OnRemove += new EventHandler(QualificationImages_OnRemove);
            this.txtFileID.Text = EmpID.ToString();
            this.txtEmpName.Text = EmpName;
            this.cbQualificationType.Text = this.cbQualificationType.Items[0].ToString();
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تود حذف هذه الصورة", "تنبيه", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (this.QualificationImages.Count <= 1)
                {
                    this.QualificationImages.Remove(this.picbQualificationDoc.Image);
                    this.picbQualificationDoc.Image = Properties.Resources.Education;
                }
                else
                {

                    if (this.QualificationImages.IndexOf(this.picbQualificationDoc.Image) == this.QualificationImages.Count - 1)
                    {
                        this.QualificationImages.Remove(this.picbQualificationDoc.Image);
                        this.picbQualificationDoc.Image = this.QualificationImages[this.QualificationImages.Count - 1];
                    }
                    else if (this.QualificationImages.IndexOf(this.picbQualificationDoc.Image) == 0)
                    {
                        this.QualificationImages.Remove(this.picbQualificationDoc.Image);
                        this.picbQualificationDoc.Image = this.QualificationImages[0];
                    }
                    else
                    {
                        int index = this.QualificationImages.IndexOf(this.picbQualificationDoc.Image);
                        this.QualificationImages.Remove(this.picbQualificationDoc.Image);
                        this.picbQualificationDoc.Image = this.QualificationImages[index];
                    }
                }

            }
        }
    }
}