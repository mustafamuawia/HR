namespace HR_MS
{
    partial class DialogIdentityCardDocScan
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
            this.picbPictureFace = new System.Windows.Forms.PictureBox();
            this.btnOpenFileFace = new System.Windows.Forms.Button();
            this.txtPicturePathFace = new System.Windows.Forms.TextBox();
            this.rbPictureFromFileFace = new System.Windows.Forms.RadioButton();
            this.rbPictureFromScannerFace = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChooseScannerFace = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picbPictureBack = new System.Windows.Forms.PictureBox();
            this.btnOpenFileBack = new System.Windows.Forms.Button();
            this.txtPicturePathBack = new System.Windows.Forms.TextBox();
            this.rbPictureFromFileBack = new System.Windows.Forms.RadioButton();
            this.btnChooseScannerBack = new System.Windows.Forms.Button();
            this.rbPictureFromScannerBack = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picbPictureFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbPictureBack)).BeginInit();
            this.SuspendLayout();
            // 
            // picbPictureFace
            // 
            this.picbPictureFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbPictureFace.Image = global::HR_MS.Properties.Resources.IDCardFace;
            this.picbPictureFace.Location = new System.Drawing.Point(340, 88);
            this.picbPictureFace.Name = "picbPictureFace";
            this.picbPictureFace.Size = new System.Drawing.Size(277, 176);
            this.picbPictureFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbPictureFace.TabIndex = 21;
            this.picbPictureFace.TabStop = false;
            // 
            // btnOpenFileFace
            // 
            this.btnOpenFileFace.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFileFace.Location = new System.Drawing.Point(437, 39);
            this.btnOpenFileFace.Name = "btnOpenFileFace";
            this.btnOpenFileFace.Size = new System.Drawing.Size(99, 30);
            this.btnOpenFileFace.TabIndex = 20;
            this.btnOpenFileFace.Text = "فتح";
            this.btnOpenFileFace.UseVisualStyleBackColor = true;
            this.btnOpenFileFace.Click += new System.EventHandler(this.btnOpenFileFace_Click);
            // 
            // txtPicturePathFace
            // 
            this.txtPicturePathFace.Enabled = false;
            this.txtPicturePathFace.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPicturePathFace.Location = new System.Drawing.Point(137, 39);
            this.txtPicturePathFace.Name = "txtPicturePathFace";
            this.txtPicturePathFace.Size = new System.Drawing.Size(278, 27);
            this.txtPicturePathFace.TabIndex = 19;
            // 
            // rbPictureFromFileFace
            // 
            this.rbPictureFromFileFace.AutoSize = true;
            this.rbPictureFromFileFace.Checked = true;
            this.rbPictureFromFileFace.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPictureFromFileFace.Location = new System.Drawing.Point(54, 39);
            this.rbPictureFromFileFace.Name = "rbPictureFromFileFace";
            this.rbPictureFromFileFace.Size = new System.Drawing.Size(81, 23);
            this.rbPictureFromFileFace.TabIndex = 18;
            this.rbPictureFromFileFace.TabStop = true;
            this.rbPictureFromFileFace.Text = "من ملف";
            this.rbPictureFromFileFace.UseVisualStyleBackColor = true;
            this.rbPictureFromFileFace.CheckedChanged += new System.EventHandler(this.rbPictureFromFileFace_CheckedChanged);
            // 
            // rbPictureFromScannerFace
            // 
            this.rbPictureFromScannerFace.AutoSize = true;
            this.rbPictureFromScannerFace.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPictureFromScannerFace.Location = new System.Drawing.Point(49, 88);
            this.rbPictureFromScannerFace.Name = "rbPictureFromScannerFace";
            this.rbPictureFromScannerFace.Size = new System.Drawing.Size(156, 23);
            this.rbPictureFromScannerFace.TabIndex = 17;
            this.rbPictureFromScannerFace.Text = "من الماسح الضوئي";
            this.rbPictureFromScannerFace.UseVisualStyleBackColor = true;
            this.rbPictureFromScannerFace.CheckedChanged += new System.EventHandler(this.rbPictureFromScannerFace_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(176, 442);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "إلغاء الأمر";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnChooseScannerFace
            // 
            this.btnChooseScannerFace.Enabled = false;
            this.btnChooseScannerFace.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseScannerFace.Location = new System.Drawing.Point(49, 117);
            this.btnChooseScannerFace.Name = "btnChooseScannerFace";
            this.btnChooseScannerFace.Size = new System.Drawing.Size(110, 30);
            this.btnChooseScannerFace.TabIndex = 14;
            this.btnChooseScannerFace.Text = "مسح ضوئي";
            this.btnChooseScannerFace.UseVisualStyleBackColor = true;
            this.btnChooseScannerFace.Click += new System.EventHandler(this.btnChooseScannerFace_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(49, 442);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "إضافة";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picbPictureBack
            // 
            this.picbPictureBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbPictureBack.Image = global::HR_MS.Properties.Resources.IDCardBack;
            this.picbPictureBack.Location = new System.Drawing.Point(340, 323);
            this.picbPictureBack.Name = "picbPictureBack";
            this.picbPictureBack.Size = new System.Drawing.Size(277, 174);
            this.picbPictureBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbPictureBack.TabIndex = 21;
            this.picbPictureBack.TabStop = false;
            // 
            // btnOpenFileBack
            // 
            this.btnOpenFileBack.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFileBack.Location = new System.Drawing.Point(437, 276);
            this.btnOpenFileBack.Name = "btnOpenFileBack";
            this.btnOpenFileBack.Size = new System.Drawing.Size(99, 30);
            this.btnOpenFileBack.TabIndex = 24;
            this.btnOpenFileBack.Text = "فتح";
            this.btnOpenFileBack.UseVisualStyleBackColor = true;
            this.btnOpenFileBack.Click += new System.EventHandler(this.btnOpenFileBack_Click);
            // 
            // txtPicturePathBack
            // 
            this.txtPicturePathBack.Enabled = false;
            this.txtPicturePathBack.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPicturePathBack.Location = new System.Drawing.Point(132, 276);
            this.txtPicturePathBack.Name = "txtPicturePathBack";
            this.txtPicturePathBack.Size = new System.Drawing.Size(278, 27);
            this.txtPicturePathBack.TabIndex = 23;
            // 
            // rbPictureFromFileBack
            // 
            this.rbPictureFromFileBack.AutoSize = true;
            this.rbPictureFromFileBack.Checked = true;
            this.rbPictureFromFileBack.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPictureFromFileBack.Location = new System.Drawing.Point(49, 276);
            this.rbPictureFromFileBack.Name = "rbPictureFromFileBack";
            this.rbPictureFromFileBack.Size = new System.Drawing.Size(81, 23);
            this.rbPictureFromFileBack.TabIndex = 22;
            this.rbPictureFromFileBack.TabStop = true;
            this.rbPictureFromFileBack.Text = "من ملف";
            this.rbPictureFromFileBack.UseVisualStyleBackColor = true;
            this.rbPictureFromFileBack.CheckedChanged += new System.EventHandler(this.rbPictureFromFileBack_CheckedChanged);
            // 
            // btnChooseScannerBack
            // 
            this.btnChooseScannerBack.Enabled = false;
            this.btnChooseScannerBack.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseScannerBack.Location = new System.Drawing.Point(49, 353);
            this.btnChooseScannerBack.Name = "btnChooseScannerBack";
            this.btnChooseScannerBack.Size = new System.Drawing.Size(110, 30);
            this.btnChooseScannerBack.TabIndex = 14;
            this.btnChooseScannerBack.Text = "مسح ضوئي";
            this.btnChooseScannerBack.UseVisualStyleBackColor = true;
            this.btnChooseScannerBack.Click += new System.EventHandler(this.btnChooseScannerBack_Click);
            // 
            // rbPictureFromScannerBack
            // 
            this.rbPictureFromScannerBack.AutoSize = true;
            this.rbPictureFromScannerBack.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPictureFromScannerBack.Location = new System.Drawing.Point(49, 324);
            this.rbPictureFromScannerBack.Name = "rbPictureFromScannerBack";
            this.rbPictureFromScannerBack.Size = new System.Drawing.Size(156, 23);
            this.rbPictureFromScannerBack.TabIndex = 17;
            this.rbPictureFromScannerBack.Text = "من الماسح الضوئي";
            this.rbPictureFromScannerBack.UseVisualStyleBackColor = true;
            this.rbPictureFromScannerBack.CheckedChanged += new System.EventHandler(this.rbPictureFromScannerBack_CheckedChanged);
            // 
            // DialogIdentityCardDocScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 509);
            this.Controls.Add(this.btnOpenFileBack);
            this.Controls.Add(this.txtPicturePathBack);
            this.Controls.Add(this.rbPictureFromFileBack);
            this.Controls.Add(this.picbPictureBack);
            this.Controls.Add(this.picbPictureFace);
            this.Controls.Add(this.btnOpenFileFace);
            this.Controls.Add(this.txtPicturePathFace);
            this.Controls.Add(this.rbPictureFromFileFace);
            this.Controls.Add(this.rbPictureFromScannerBack);
            this.Controls.Add(this.rbPictureFromScannerFace);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChooseScannerBack);
            this.Controls.Add(this.btnChooseScannerFace);
            this.Controls.Add(this.btnSave);
            this.Name = "DialogIdentityCardDocScan";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مصدر صورة البطاقة الشخصية";
            this.Load += new System.EventHandler(this.DialogIdentityCardDocScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picbPictureFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbPictureBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picbPictureFace;
        private System.Windows.Forms.Button btnOpenFileFace;
        private System.Windows.Forms.TextBox txtPicturePathFace;
        private System.Windows.Forms.RadioButton rbPictureFromFileFace;
        private System.Windows.Forms.RadioButton rbPictureFromScannerFace;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnChooseScannerFace;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox picbPictureBack;
        private System.Windows.Forms.Button btnOpenFileBack;
        private System.Windows.Forms.TextBox txtPicturePathBack;
        private System.Windows.Forms.RadioButton rbPictureFromFileBack;
        private System.Windows.Forms.Button btnChooseScannerBack;
        private System.Windows.Forms.RadioButton rbPictureFromScannerBack;
    }
}