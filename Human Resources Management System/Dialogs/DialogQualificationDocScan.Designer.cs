namespace HR_MS
{
    partial class DialogQualificationDocScan
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
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtPicturePath = new System.Windows.Forms.TextBox();
            this.rbPictureFromFile = new System.Windows.Forms.RadioButton();
            this.rbPictureFromScanner = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChooseScanner = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picbPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picbPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFile.Location = new System.Drawing.Point(416, 21);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(99, 30);
            this.btnOpenFile.TabIndex = 12;
            this.btnOpenFile.Text = "فتح";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtPicturePath
            // 
            this.txtPicturePath.Enabled = false;
            this.txtPicturePath.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPicturePath.Location = new System.Drawing.Point(116, 21);
            this.txtPicturePath.Name = "txtPicturePath";
            this.txtPicturePath.Size = new System.Drawing.Size(278, 27);
            this.txtPicturePath.TabIndex = 11;
            // 
            // rbPictureFromFile
            // 
            this.rbPictureFromFile.AutoSize = true;
            this.rbPictureFromFile.Checked = true;
            this.rbPictureFromFile.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPictureFromFile.Location = new System.Drawing.Point(33, 21);
            this.rbPictureFromFile.Name = "rbPictureFromFile";
            this.rbPictureFromFile.Size = new System.Drawing.Size(81, 23);
            this.rbPictureFromFile.TabIndex = 10;
            this.rbPictureFromFile.TabStop = true;
            this.rbPictureFromFile.Text = "من ملف";
            this.rbPictureFromFile.UseVisualStyleBackColor = true;
            this.rbPictureFromFile.CheckedChanged += new System.EventHandler(this.rbPictureFromFile_CheckedChanged);
            // 
            // rbPictureFromScanner
            // 
            this.rbPictureFromScanner.AutoSize = true;
            this.rbPictureFromScanner.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPictureFromScanner.Location = new System.Drawing.Point(33, 76);
            this.rbPictureFromScanner.Name = "rbPictureFromScanner";
            this.rbPictureFromScanner.Size = new System.Drawing.Size(156, 23);
            this.rbPictureFromScanner.TabIndex = 9;
            this.rbPictureFromScanner.Text = "من الماسح الضوئي";
            this.rbPictureFromScanner.UseVisualStyleBackColor = true;
            this.rbPictureFromScanner.CheckedChanged += new System.EventHandler(this.rbPictureFromScanner_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(169, 357);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "إلغاء الأمر";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnChooseScanner
            // 
            this.btnChooseScanner.Enabled = false;
            this.btnChooseScanner.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseScanner.Location = new System.Drawing.Point(33, 105);
            this.btnChooseScanner.Name = "btnChooseScanner";
            this.btnChooseScanner.Size = new System.Drawing.Size(110, 30);
            this.btnChooseScanner.TabIndex = 6;
            this.btnChooseScanner.Text = "مسح ضوئي";
            this.btnChooseScanner.UseVisualStyleBackColor = true;
            this.btnChooseScanner.Click += new System.EventHandler(this.btnChooseScanner_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(42, 357);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "إضافة";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picbPicture
            // 
            this.picbPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbPicture.Image = global::HR_MS.Properties.Resources.Education;
            this.picbPicture.Location = new System.Drawing.Point(310, 67);
            this.picbPicture.Name = "picbPicture";
            this.picbPicture.Size = new System.Drawing.Size(289, 339);
            this.picbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbPicture.TabIndex = 13;
            this.picbPicture.TabStop = false;
            // 
            // DialogQualificationDocScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 418);
            this.Controls.Add(this.picbPicture);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtPicturePath);
            this.Controls.Add(this.rbPictureFromFile);
            this.Controls.Add(this.rbPictureFromScanner);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChooseScanner);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DialogQualificationDocScan";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مصدر صورة المؤهل الأكاديمي";
            this.Load += new System.EventHandler(this.DialogQualificationDocScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picbPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtPicturePath;
        private System.Windows.Forms.RadioButton rbPictureFromFile;
        private System.Windows.Forms.RadioButton rbPictureFromScanner;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnChooseScanner;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox picbPicture;
    }
}