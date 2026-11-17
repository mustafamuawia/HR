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
    public partial class frmEmployeeExperiences : Adjust
    {
        SqlConnection SqlConn = new SqlConnection("Data source=" + Properties.Settings.Default["DatabaseServer"].ToString() + ";initial catalog=" + Properties.Settings.Default["DatabaseName"].ToString() + ";User ID=empadmin;Password=123");
        private int EmpID;
        private int ExperienceDocID;
        private string EmpName;
        public MyList<Image> ExperienceDocsImages = new MyList<Image>();
        public int PictureIndex = 0;
        private void ExperienceDocsImages_OnAdd(object sender, EventArgs e)
        {
            if (ExperienceDocsImages.Count > -1)
            {
                this.btnDeleteImage.Enabled = true;
            }
            if (ExperienceDocsImages.Count > 0)
            {
                this.btnNext.Enabled = true;
                this.btnPrevious.Enabled = true;
            }
        }

        private void ExperienceDocsImages_OnRemove(object sender, EventArgs e)
        {
            if (ExperienceDocsImages.Count <= 1)
            {
                this.btnDeleteImage.Enabled = false;

            }
            if (ExperienceDocsImages.Count <= 2)
            {
                this.btnNext.Enabled = false;
                this.btnPrevious.Enabled = false;
            }
        }

        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff);
            return ms.ToArray();
        }

        public frmEmployeeExperiences(int EmpID, string EmpName)
        {
            InitializeComponent();
            this.EmpID = EmpID;
            this.EmpName = EmpName;
        }

        private void frmEmployeeDetails_Load(object sender, EventArgs e)
        {
            //Initialize FileID field
            SqlDataAdapter daGetExpeirinceDocID = new SqlDataAdapter("Select empid from db_Owner.Employees", SqlConn);
            DataTable dtGetExpeirinceDocID = new DataTable();
            daGetExpeirinceDocID.Fill(dtGetExpeirinceDocID);
            ExperienceDocID = (dtGetExpeirinceDocID.Rows.Count + 1);

            ExperienceDocsImages.OnAdd += new EventHandler(ExperienceDocsImages_OnAdd);
            ExperienceDocsImages.OnRemove += new EventHandler(ExperienceDocsImages_OnRemove);
            this.txtFileID.Text = EmpID.ToString();
            this.txtEmpName.Text = EmpName;

        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            DialogExperienceDocsScan DialogExpDocScan = new DialogExperienceDocsScan();
            DialogExpDocScan.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (PictureIndex < ExperienceDocsImages.Count - 1)
            {
                if (PictureIndex < ExperienceDocsImages.Count - 1)
                    this.btnNext.Enabled = false;
                if (PictureIndex > 0)
                    this.btnPrevious.Enabled = true;
                PictureIndex++;
                picbExpeirinceDoc.Image = ExperienceDocsImages[PictureIndex];

            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (PictureIndex > 0)
            {
                if (PictureIndex < 0)
                {
                    this.btnPrevious.Enabled = false;
                    this.btnNext.Enabled = true;
                }
                                   
                PictureIndex--;
                picbExpeirinceDoc.Image = ExperienceDocsImages[PictureIndex];

            }
        }

        private void btnAddPicture_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تود إضافة سجل الموظف", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sqlIns = "INSERT INTO db_owner.EmployeesExperinces " +
                        @"(EmpExperinceID,EmpID,EmpExperinceID)" +
                        @" VALUES (@ID, @EmpID,@Picure)";
                
                SqlConn.Open();
                try
                {

                    for (int Index = 0; Index < ExperienceDocsImages.Count; Index++)
                    {
                        SqlCommand cmdIns = new SqlCommand(sqlIns, SqlConn);
                        cmdIns.Parameters.AddWithValue("@ID", ExperienceDocID + Index);
                        cmdIns.Parameters.AddWithValue("@EmpID", EmpID);
                        cmdIns.Parameters.AddWithValue("@Picure", imageToByteArray(ExperienceDocsImages[Index]));

                        cmdIns.ExecuteNonQuery();

                        cmdIns.Parameters.Clear();
                        cmdIns.CommandText = "SELECT @@IDENTITY";

                        cmdIns.Dispose();
                        cmdIns = null;
                    }
                    MessageBox.Show("تم الحفظ بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تود حذف هذه الصورة", "تنبيه", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (this.ExperienceDocsImages.Count <= 1)
                {
                    this.ExperienceDocsImages.Remove(this.picbExpeirinceDoc.Image);
                    this.picbExpeirinceDoc.Image = Properties.Resources.Education;
                }
                else
                {

                    if (this.ExperienceDocsImages.IndexOf(this.picbExpeirinceDoc.Image) == this.ExperienceDocsImages.Count - 1)
                    {
                        this.ExperienceDocsImages.Remove(this.picbExpeirinceDoc.Image);
                        this.picbExpeirinceDoc.Image = this.ExperienceDocsImages[this.ExperienceDocsImages.Count - 1];
                    }
                    else if (this.ExperienceDocsImages.IndexOf(this.picbExpeirinceDoc.Image) == 0)
                    {
                        this.ExperienceDocsImages.Remove(this.picbExpeirinceDoc.Image);
                        this.picbExpeirinceDoc.Image = this.ExperienceDocsImages[0];
                    }
                    else
                    {
                        int index = this.ExperienceDocsImages.IndexOf(this.picbExpeirinceDoc.Image);
                        this.ExperienceDocsImages.Remove(this.picbExpeirinceDoc.Image);
                        this.picbExpeirinceDoc.Image = this.ExperienceDocsImages[index];
                    }
                }

            }
        }

         }
}
