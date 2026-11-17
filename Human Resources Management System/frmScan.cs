using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bytescout.Scan;

namespace HR_MS
{
    public partial class frmScan : Adjust
    {
     private Scan _scan; // define Scan object

     public frmScan()
		{
            InitializeComponent();

            // Create new Scan object
            _scan = new Scan();
            // Handle the event notifying the image trasfer is finished.
            _scan.TransferFinished += scan_TransferFinished;
		}

		private void btnSelectDevice_Click(object sender, EventArgs e)
		{
         // Display TWAIN device selection dialog
			_scan.SelectDevice(Handle);
		}

		// Starts Asynchronous scan into images. When scan is finished then scanFace_TransferFinished event is called and array with images objects is passed into this event
		private void btnScanToImagesAsync_Click(object sender, EventArgs e)
		{
			// Set up Scan object to save images into array of Bitmap objects
            _scan.SaveTo = SaveTo.ImageObject;

            // acquire images
			_scan.AcquireImagesAsync(Handle);
		}

        // Acquire images into files automatically saved into specified folder with specified image format and filename.
        private void btnScanToFilesAsync_Click(object sender, EventArgs e)
		{
			// Set SDK to save images into files
            _scan.SaveTo = SaveTo.File;
            
			// _scanFace.FileNamingTemplate = "ScannedImage_{0:D2}"; // you can set output filename template

			// Set output format as JPG image format
            _scan.OutputFormat = OutputFormat.JPEG;

            // You can set output folder as well, by default output folder is the same where executable .exe is running            
            //_scanFace.OutputFolder = Path.GetTempPath();

            // acquire images
			_scan.AcquireImagesAsync(Handle);
		}

		// Displays ready-to-use options dialog for the scan SDK
        private void btnOptions_Click(object sender, EventArgs e)
		{
			Scan.ShowOptionsDialog(new Scan());
		}

        private void scan_TransferFinished(Scan sender, ArrayList scannedImages)
		{
			FillTabsWithImages(scannedImages);
		}

		// This method puts retrieved images into tabs on the form
		private void FillTabsWithImages(ArrayList images)
		{
			tabControl1.TabPages.Clear();

			for (int i = 0; i < images.Count; i++)
			{
				TabPage page = new TabPage();

				PictureBox pb = new PictureBox();
				pb.Dock = DockStyle.Fill;
				pb.SizeMode = PictureBoxSizeMode.StretchImage;

				if (images[i] is Image)
				{
					page.Text = "Image " + (i + 1).ToString();
					pb.Image = (Image)images[i];
				}
				else
				{
					page.Text = (String)images[i];
					pb.Image = Image.FromFile((String)images[i]);
				}

				page.Controls.Add(pb);

				tabControl1.TabPages.Add(page);
			}
		}

        private void frmScan_Load(object sender, EventArgs e)
        {

        }
    }
}
