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
    public partial class DialogIdentityCardDocScan : Adjust
    {
        Scan _scanFace,_scanBack;
        Image IdentityCardFace, IdentityCardBack;

        private void scanFace_TransferFinished(Scan sender, ArrayList scannedImages)
        {
            try
            {
                FillFaceWithImages(scannedImages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillFaceWithImages(ArrayList image)
        {
            try
            {
                IdentityCardFace = (Image)image[0];
                this.picbPictureFace.Image = (Image)image[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.Threading.Thread.Sleep(1000);
                this.Focus();
            }
        }

        private void scanBack_TransferFinished(Scan sender, ArrayList scannedImages)
        {
            try
            {
                FillBackWithImages(scannedImages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillBackWithImages(ArrayList image)
        {
            try
            {
                IdentityCardBack = (Image)image[0];
                this.picbPictureFace.Image = (Image)image[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.Threading.Thread.Sleep(1000);
                this.Focus();
            }
        }

        bool NewIdentCard;
        public DialogIdentityCardDocScan(bool NewIdent)
        {
            InitializeComponent();
            _scanFace = new Scan();
            _scanBack = new Scan();
            // Handle the event notifying the image trasfer is finished.
            _scanFace.TransferFinished += scanFace_TransferFinished;
            _scanBack.TransferFinished += scanBack_TransferFinished;
            NewIdentCard = NewIdent;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (NewIdentCard)
            {
                frmEmployeeOfficialDocuments frmEmpOfficialDocs = ((frmEmployeeOfficialDocuments)Application.OpenForms["frmEmployeeOfficialDocuments"]);
                if (this.IdentityCardFace == null && this.IdentityCardBack == null)
                {
                    MessageBox.Show("الرجاء تحديد صورة وجه وخلفية البطاقة الشخصية", "تنبيه");
                }
                else if (this.IdentityCardFace == null && this.IdentityCardBack != null)
                {
                    MessageBox.Show("الرجاء تحديد صورة وجه البطاقة الشخصية", "تنبيه");
                }
                else if (this.IdentityCardFace != null && this.IdentityCardBack == null)
                    MessageBox.Show("الرجاء تحديد صورة ظهر البطاقة الشخصية", "تنبيه");

                else if (MessageBox.Show("هل ترغب بإضافة صورة البطاقة الشخصية إلى سجل الموظف", "إغلاق", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    frmEmpOfficialDocs.picbIdentityCardFacePicture.Image = this.IdentityCardFace;
                    frmEmpOfficialDocs.picbIdentityCardBackPicture.Image = this.IdentityCardBack;
                    this.DialogResult = DialogResult.OK;
                }
            }
            if (!NewIdentCard)
            {
                frmEditEmployeeOfficialDocs frmEditEmpOfficialDocs = ((frmEditEmployeeOfficialDocs)Application.OpenForms["frmEditEmployeeOfficialDocs"]);
                if (this.IdentityCardFace == null && this.IdentityCardBack == null)
                {
                    MessageBox.Show("الرجاء تحديد صورة وجه وخلفية البطاقة الشخصية", "تنبيه");
                }
                else if (this.IdentityCardFace == null && this.IdentityCardBack != null)
                {
                    MessageBox.Show("الرجاء تحديد صورة وجه البطاقة الشخصية", "تنبيه");
                }
                else if (this.IdentityCardFace != null && this.IdentityCardBack == null)
                    MessageBox.Show("الرجاء تحديد صورة ظهر البطاقة الشخصية", "تنبيه");

                else if (MessageBox.Show("هل ترغب بتعديل صورة البطاقة الشخصية في سجل الموظف", "إغلاق", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    frmEditEmpOfficialDocs.picbIdentityCardFacePicture.Image = this.IdentityCardFace;
                    frmEditEmpOfficialDocs.picbIdentityCardBackPicture.Image = this.IdentityCardBack;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChooseScannerBack_Click(object sender, EventArgs e)
        {
            _scanBack.SelectDevice(Handle);
            _scanBack.SaveTo = SaveTo.ImageObject;

            // acquire images
            _scanBack.AcquireImagesAsync(Handle);

        }


        private void btnOpenFileFace_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            OpenFile.Multiselect = false;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                txtPicturePathFace.Text = OpenFile.FileName;
                IdentityCardFace = Image.FromFile(OpenFile.FileName);
                picbPictureFace.Image = Image.FromFile(OpenFile.FileName);
            }
        }

        private void btnChooseScannerFace_Click(object sender, EventArgs e)
        {
            _scanFace.SelectDevice(Handle);
            _scanFace.SaveTo = SaveTo.ImageObject;

            // acquire images
            _scanFace.AcquireImagesAsync(Handle);
        }

        private void rbPictureFromFileFace_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPictureFromFileFace.Checked == true)
            {
                btnChooseScannerFace.Enabled = false;
                btnOpenFileFace.Enabled = true;
            }
        }

        private void rbPictureFromScannerFace_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPictureFromScannerFace.Checked == true)
            {
                txtPicturePathFace.Text = "";
                btnOpenFileFace.Enabled = false;
                btnChooseScannerFace.Enabled = true;
            }
        }

        private void rbPictureFromFileBack_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPictureFromFileBack.Checked == true)
            {
                btnChooseScannerBack.Enabled = false;
                btnOpenFileBack.Enabled = true;
            }
        }

        private void rbPictureFromScannerBack_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPictureFromScannerBack.Checked == true)
            {
                txtPicturePathBack.Text = "";
                btnOpenFileBack.Enabled = false;
                btnChooseScannerBack.Enabled = true;
            }
        }

        private void btnOpenFileBack_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            OpenFile.Multiselect = false;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                txtPicturePathBack.Text = OpenFile.FileName;
                IdentityCardBack = Image.FromFile(OpenFile.FileName);
                picbPictureBack.Image = Image.FromFile(OpenFile.FileName);
            }
        }

        private void DialogIdentityCardDocScan_Load(object sender, EventArgs e)
        {

        }

    }
}