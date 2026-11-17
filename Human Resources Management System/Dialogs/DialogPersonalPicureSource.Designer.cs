namespace HR_MS
{
    partial class DialogPersonalPicureSource
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
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbPictureFromScanner = new System.Windows.Forms.RadioButton();
            this.rbPictureFromFile = new System.Windows.Forms.RadioButton();
            this.btnChooseScanner = new System.Windows.Forms.Button();
            this.txtPicturePath = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.picbPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picbPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPicture.Location = new System.Drawing.Point(324, 207);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(110, 30);
            this.btnAddPicture.TabIndex = 0;
            this.btnAddPicture.Text = "إضافة";
            this.btnAddPicture.UseVisualStyleBackColor = true;
            this.btnAddPicture.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(165, 207);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "إلغاء الأمر";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbPictureFromScanner
            // 
            this.rbPictureFromScanner.AutoSize = true;
            this.rbPictureFromScanner.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPictureFromScanner.Location = new System.Drawing.Point(306, 134);
            this.rbPictureFromScanner.Name = "rbPictureFromScanner";
            this.rbPictureFromScanner.Size = new System.Drawing.Size(156, 23);
            this.rbPictureFromScanner.TabIndex = 2;
            this.rbPictureFromScanner.Text = "من الماسح الضوئي";
            this.rbPictureFromScanner.UseVisualStyleBackColor = true;
            this.rbPictureFromScanner.CheckedChanged += new System.EventHandler(this.rbPictureFromScanner_CheckedChanged);
            // 
            // rbPictureFromFile
            // 
            this.rbPictureFromFile.AutoSize = true;
            this.rbPictureFromFile.Checked = true;
            this.rbPictureFromFile.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPictureFromFile.Location = new System.Drawing.Point(381, 14);
            this.rbPictureFromFile.Name = "rbPictureFromFile";
            this.rbPictureFromFile.Size = new System.Drawing.Size(81, 23);
            this.rbPictureFromFile.TabIndex = 2;
            this.rbPictureFromFile.TabStop = true;
            this.rbPictureFromFile.Text = "من ملف";
            this.rbPictureFromFile.UseVisualStyleBackColor = true;
            this.rbPictureFromFile.CheckedChanged += new System.EventHandler(this.rbPictureFromFile_CheckedChanged);
            // 
            // btnChooseScanner
            // 
            this.btnChooseScanner.Enabled = false;
            this.btnChooseScanner.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseScanner.Location = new System.Drawing.Point(165, 134);
            this.btnChooseScanner.Name = "btnChooseScanner";
            this.btnChooseScanner.Size = new System.Drawing.Size(110, 30);
            this.btnChooseScanner.TabIndex = 0;
            this.btnChooseScanner.Text = "مسح ضوئي";
            this.btnChooseScanner.UseVisualStyleBackColor = true;
            this.btnChooseScanner.Click += new System.EventHandler(this.btnChooseScanner_Click);
            // 
            // txtPicturePath
            // 
            this.txtPicturePath.Enabled = false;
            this.txtPicturePath.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPicturePath.Location = new System.Drawing.Point(184, 43);
            this.txtPicturePath.Name = "txtPicturePath";
            this.txtPicturePath.Size = new System.Drawing.Size(278, 27);
            this.txtPicturePath.TabIndex = 3;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFile.Location = new System.Drawing.Point(48, 43);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(99, 30);
            this.btnOpenFile.TabIndex = 4;
            this.btnOpenFile.Text = "فتح";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // picbPicture
            // 
            this.picbPicture.Image = global::HR_MS.Properties.Resources.Picture;
            this.picbPicture.Location = new System.Drawing.Point(12, 92);
            this.picbPicture.Name = "picbPicture";
            this.picbPicture.Size = new System.Drawing.Size(135, 145);
            this.picbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbPicture.TabIndex = 5;
            this.picbPicture.TabStop = false;
            // 
            // DialogPersonalPicureSource
            // 
            this.AcceptButton = this.btnAddPicture;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(475, 249);
            this.Controls.Add(this.picbPicture);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtPicturePath);
            this.Controls.Add(this.rbPictureFromFile);
            this.Controls.Add(this.rbPictureFromScanner);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChooseScanner);
            this.Controls.Add(this.btnAddPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogPersonalPicureSource";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "مصدر الصورة";
            this.Load += new System.EventHandler(this.DialogImageSource_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picbPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPicture;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbPictureFromScanner;
        private System.Windows.Forms.RadioButton rbPictureFromFile;
        private System.Windows.Forms.Button btnChooseScanner;
        private System.Windows.Forms.TextBox txtPicturePath;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.PictureBox picbPicture;
    }
}