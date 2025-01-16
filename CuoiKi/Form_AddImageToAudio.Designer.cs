namespace CuoiKi
{
    partial class Form_AddImageToAudio
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
            this.btnAddImageToAudio = new System.Windows.Forms.Button();
            this.btnSelectVideoOutputFolder = new System.Windows.Forms.Button();
            this.lblVideoOutputPath = new System.Windows.Forms.Label();
            this.btnSelectAudioFile = new System.Windows.Forms.Button();
            this.lblAudioFilePath = new System.Windows.Forms.Label();
            this.btnSelectImageFile = new System.Windows.Forms.Button();
            this.lblImageFilePath = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddImageToAudio
            // 
            this.btnAddImageToAudio.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAddImageToAudio.Location = new System.Drawing.Point(245, 79);
            this.btnAddImageToAudio.Name = "btnAddImageToAudio";
            this.btnAddImageToAudio.Size = new System.Drawing.Size(187, 39);
            this.btnAddImageToAudio.TabIndex = 5;
            this.btnAddImageToAudio.Text = "3. Thêm ảnh vào âm thanh";
            this.btnAddImageToAudio.UseVisualStyleBackColor = false;
            this.btnAddImageToAudio.Click += new System.EventHandler(this.btnAddImageToAudio_Click);
            // 
            // btnSelectVideoOutputFolder
            // 
            this.btnSelectVideoOutputFolder.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSelectVideoOutputFolder.Location = new System.Drawing.Point(245, 124);
            this.btnSelectVideoOutputFolder.Name = "btnSelectVideoOutputFolder";
            this.btnSelectVideoOutputFolder.Size = new System.Drawing.Size(187, 39);
            this.btnSelectVideoOutputFolder.TabIndex = 8;
            this.btnSelectVideoOutputFolder.Text = "Chọn thư mục để lưu";
            this.btnSelectVideoOutputFolder.UseVisualStyleBackColor = false;
            this.btnSelectVideoOutputFolder.Click += new System.EventHandler(this.btnSelectVideoOutputFolder_Click);
            // 
            // lblVideoOutputPath
            // 
            this.lblVideoOutputPath.AutoSize = true;
            this.lblVideoOutputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideoOutputPath.Location = new System.Drawing.Point(438, 135);
            this.lblVideoOutputPath.Name = "lblVideoOutputPath";
            this.lblVideoOutputPath.Size = new System.Drawing.Size(46, 15);
            this.lblVideoOutputPath.TabIndex = 10;
            this.lblVideoOutputPath.Text = "link lưu";
            // 
            // btnSelectAudioFile
            // 
            this.btnSelectAudioFile.Location = new System.Drawing.Point(245, 169);
            this.btnSelectAudioFile.Name = "btnSelectAudioFile";
            this.btnSelectAudioFile.Size = new System.Drawing.Size(187, 39);
            this.btnSelectAudioFile.TabIndex = 17;
            this.btnSelectAudioFile.Text = "Chọn file âm thanh ";
            this.btnSelectAudioFile.UseVisualStyleBackColor = true;
            this.btnSelectAudioFile.Click += new System.EventHandler(this.btnSelectAudioFile_Click);
            // 
            // lblAudioFilePath
            // 
            this.lblAudioFilePath.AutoSize = true;
            this.lblAudioFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudioFilePath.Location = new System.Drawing.Point(438, 180);
            this.lblAudioFilePath.Name = "lblAudioFilePath";
            this.lblAudioFilePath.Size = new System.Drawing.Size(46, 15);
            this.lblAudioFilePath.TabIndex = 19;
            this.lblAudioFilePath.Text = "link lưu";
            // 
            // btnSelectImageFile
            // 
            this.btnSelectImageFile.Location = new System.Drawing.Point(245, 214);
            this.btnSelectImageFile.Name = "btnSelectImageFile";
            this.btnSelectImageFile.Size = new System.Drawing.Size(187, 39);
            this.btnSelectImageFile.TabIndex = 20;
            this.btnSelectImageFile.Text = "Chọn ảnh";
            this.btnSelectImageFile.UseVisualStyleBackColor = true;
            this.btnSelectImageFile.Click += new System.EventHandler(this.btnSelectImageFile_Click);
            // 
            // lblImageFilePath
            // 
            this.lblImageFilePath.AutoSize = true;
            this.lblImageFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageFilePath.Location = new System.Drawing.Point(438, 225);
            this.lblImageFilePath.Name = "lblImageFilePath";
            this.lblImageFilePath.Size = new System.Drawing.Size(46, 15);
            this.lblImageFilePath.TabIndex = 21;
            this.lblImageFilePath.Text = "link lưu";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(245, 259);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(187, 39);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(192, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 22);
            this.label1.TabIndex = 23;
            this.label1.Text = "Chức năng thêm ảnh vào file âm thanh";
            // 
            // Form_AddImageToAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 357);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblImageFilePath);
            this.Controls.Add(this.btnSelectImageFile);
            this.Controls.Add(this.lblAudioFilePath);
            this.Controls.Add(this.btnSelectAudioFile);
            this.Controls.Add(this.lblVideoOutputPath);
            this.Controls.Add(this.btnSelectVideoOutputFolder);
            this.Controls.Add(this.btnAddImageToAudio);
            this.Name = "Form_AddImageToAudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm ảnh vào âm thanh";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddImageToAudio;
        private System.Windows.Forms.Button btnSelectVideoOutputFolder;
        private System.Windows.Forms.Label lblVideoOutputPath;
        private System.Windows.Forms.Button btnSelectAudioFile;
        private System.Windows.Forms.Label lblAudioFilePath;
        private System.Windows.Forms.Button btnSelectImageFile;
        private System.Windows.Forms.Label lblImageFilePath;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
    }
}