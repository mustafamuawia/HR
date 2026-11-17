namespace HR_MS
{
    partial class frmScan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnScanToImagesAsync = new System.Windows.Forms.Button();
            this.btnScanToFilesAsync = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(12, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(575, 418);
            this.tabControl1.TabIndex = 1;
            // 
            // btnScanToImagesAsync
            // 
            this.btnScanToImagesAsync.Location = new System.Drawing.Point(167, 12);
            this.btnScanToImagesAsync.Name = "btnScanToImagesAsync";
            this.btnScanToImagesAsync.Size = new System.Drawing.Size(134, 31);
            this.btnScanToImagesAsync.TabIndex = 2;
            this.btnScanToImagesAsync.Text = "Scan to images Async";
            this.btnScanToImagesAsync.UseVisualStyleBackColor = true;
            this.btnScanToImagesAsync.Click += new System.EventHandler(this.btnScanToImagesAsync_Click);
            // 
            // btnScanToFilesAsync
            // 
            this.btnScanToFilesAsync.Location = new System.Drawing.Point(321, 12);
            this.btnScanToFilesAsync.Name = "btnScanToFilesAsync";
            this.btnScanToFilesAsync.Size = new System.Drawing.Size(134, 31);
            this.btnScanToFilesAsync.TabIndex = 3;
            this.btnScanToFilesAsync.Text = "Scan to Files Async";
            this.btnScanToFilesAsync.UseVisualStyleBackColor = true;
            this.btnScanToFilesAsync.Click += new System.EventHandler(this.btnScanToFilesAsync_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(12, 12);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(134, 31);
            this.btnOptions.TabIndex = 5;
            this.btnOptions.Text = "Show Options dialog...";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // frmScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 492);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnScanToFilesAsync);
            this.Controls.Add(this.btnScanToImagesAsync);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmScan";
            this.Text = "frmScan";
            this.Load += new System.EventHandler(this.frmScan_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnScanToImagesAsync;
        private System.Windows.Forms.Button btnScanToFilesAsync;
        private System.Windows.Forms.Button btnOptions;
    }
}