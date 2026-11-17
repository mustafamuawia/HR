using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bytescout.Scan;
using System.Collections;


namespace HR_MS
{
    public partial class DialogQualificationDocScan : Adjust
    {
        Image QualificationImage;

        Scan _scan;
        public DialogQualificationDocScan()
        {
            InitializeComponent();
            _scan = new Scan();
            // Handle the event notifying the image trasfer is finished.
            _scan.TransferFinished += scan_TransferFinished;
        }
        private void scan_TransferFinished(Scan sender, ArrayList scannedImages)
        {
            try
            {
                FillTabsWithImages(scannedImages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.Threading.Thread.Sleep(1000);
                this.Focus();
            }
        }
        private void FillTabsWithImages(ArrayList image)
        {
            QualificationImage = (Image)image[0];
            this.picbPicture.Image = (Image)image[0];
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            OpenFile.Multiselect = false;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                txtPicturePath.Text = OpenFile.FileName;
                QualificationImage = Image.FromFile(OpenFile.FileName);
                picbPicture.Image = Image.FromFile(OpenFile.FileName);
            }
        }

        private void rbPictureFromFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPictureFromFile.Checked == true)
            {
                btnChooseScanner.Enabled = false;
                btnOpenFile.Enabled = true;
            }
        }

        private void rbPictureFromScanner_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPictureFromScanner.Checked == true)
            {
                txtPicturePath.Text = "";
                btnOpenFile.Enabled = false;
                btnChooseScanner.Enabled = true;
            }
        }

        private void DialogQualificationDocScan_Load(object sender, EventArgs e)
        {
        }

        private void btnChooseScanner_Click(object sender, EventArgs e)
        {
            _scan.SelectDevice(Handle);
            _scan.SaveTo = SaveTo.ImageObject;

            // acquire images
            _scan.AcquireImagesAsync(Handle);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmEmployeeQualifications frmQualification = ((frmEmployeeQualifications)Application.OpenForms["frmEmployeeQualifications"]);
            if (QualificationImage != null && rbPictureFromScanner.Checked == true)
            {
                if (MessageBox.Show("إضافة", "إغلاق", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    frmQualification.QualificationImages.Add(this.QualificationImage);
                    frmQualification.picbQualificationDoc.Image = this.QualificationImage;
                    frmQualification.PictureIndex = frmQualification.QualificationImages.IndexOf(this.QualificationImage);
                    this.DialogResult = DialogResult.OK;
                }
            }
            else if (QualificationImage != null && rbPictureFromFile.Checked == true)
            {
                if (MessageBox.Show("إضافة", "إغلاق", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    frmQualification.QualificationImages.Add(this.QualificationImage);
                    frmQualification.picbQualificationDoc.Image = this.QualificationImage;
                    frmQualification.PictureIndex = frmQualification.QualificationImages.IndexOf(this.QualificationImage);
                    this.DialogResult = DialogResult.OK;
                }
            }
            else MessageBox.Show("الرجاء تحديد صورة");
        }
    }
}
