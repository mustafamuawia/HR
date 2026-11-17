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
    public partial class DialogPersonalPicureSource : Adjust
    {
        Image PersonalPicture;

        Scan _scan;
        private void scan_TransferFinished(Scan sender, ArrayList scannedImages)
        {
            try
            {
                FillTabsWithImages(scannedImages);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillTabsWithImages(ArrayList image)
        {
            try
            {

                PersonalPicture = (Image)image[0];
                this.picbPicture.Image = (Image)image[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.Threading.Thread.Sleep(1000);
                this.Focus();
            }
        }
        bool NewImage;
        public DialogPersonalPicureSource(bool NewImg)
        {
            InitializeComponent();
            _scan = new Scan();
            // Handle the event notifying the image trasfer is finished.
            _scan.TransferFinished += scan_TransferFinished;
            NewImage = NewImg;
        }

        private void DialogImageSource_Load(object sender, EventArgs e)
        {
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

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            OpenFile.Multiselect = false;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                txtPicturePath.Text = OpenFile.FileName;
                PersonalPicture = Image.FromFile(OpenFile.FileName);
                picbPicture.Image = Image.FromFile(OpenFile.FileName);
            }

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
            if (NewImage)
            {
                frmHireEmployee frmHire = ((frmHireEmployee)Application.OpenForms["frmHireEmployee"]);
                if (PersonalPicture != null && rbPictureFromScanner.Checked == true)
                {
                    if (MessageBox.Show("إضافة", "إغلاق", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        frmHire.PersonalPicture = this.PersonalPicture;
                    this.DialogResult = DialogResult.OK;
                }
                else if (PersonalPicture != null && rbPictureFromFile.Checked == true)
                {
                    if (MessageBox.Show("إضافة", "إغلاق", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        frmHire.PersonalPicture = this.PersonalPicture;
                    this.DialogResult = DialogResult.OK;
                }
                else MessageBox.Show("الرجاء تحديد صورة");
            }
            else if (!NewImage)
            {
                frmEditEmployeeFile frmEdit = ((frmEditEmployeeFile)Application.OpenForms["frmEditEmployeeFile"]);
                if (PersonalPicture != null && rbPictureFromScanner.Checked == true)
                {
                    if (MessageBox.Show("إضافة", "إغلاق", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        frmEdit.PersonalPicture = this.PersonalPicture;
                    this.DialogResult = DialogResult.OK;
                }
                else if (PersonalPicture != null && rbPictureFromFile.Checked == true)
                {
                    if (MessageBox.Show("إضافة", "إغلاق", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        frmEdit.PersonalPicture = this.PersonalPicture;
                    this.DialogResult = DialogResult.OK;
                }
                else MessageBox.Show("الرجاء تحديد صورة");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}