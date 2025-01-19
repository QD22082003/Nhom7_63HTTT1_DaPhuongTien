namespace CuoiKi
{
    partial class Form_LBP_Giang
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.lblVideoPath = new System.Windows.Forms.Label();
            this.pictureBoxFrame = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnProcessVideo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSelectVideo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1046, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Ảnh kết quả";
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.Location = new System.Drawing.Point(933, 348);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(311, 239);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxResult.TabIndex = 22;
            this.pictureBoxResult.TabStop = false;
            // 
            // lblImagePath
            // 
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.Location = new System.Drawing.Point(158, 303);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(95, 16);
            this.lblImagePath.TabIndex = 21;
            this.lblImagePath.Text = "Chưa chọn ảnh";
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(21, 295);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(131, 32);
            this.btnSelectImage.TabIndex = 20;
            this.btnSelectImage.Text = "Chọn ảnh";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(21, 333);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(331, 254);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 19;
            this.pictureBoxImage.TabStop = false;
            // 
            // listBoxLog
            // 
            this.listBoxLog.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 16;
            this.listBoxLog.Location = new System.Drawing.Point(933, 45);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(311, 244);
            this.listBoxLog.TabIndex = 18;
            // 
            // lblVideoPath
            // 
            this.lblVideoPath.AutoSize = true;
            this.lblVideoPath.Location = new System.Drawing.Point(158, 20);
            this.lblVideoPath.Name = "lblVideoPath";
            this.lblVideoPath.Size = new System.Drawing.Size(107, 16);
            this.lblVideoPath.TabIndex = 17;
            this.lblVideoPath.Text = "Chưa chọn video";
            // 
            // pictureBoxFrame
            // 
            this.pictureBoxFrame.Location = new System.Drawing.Point(21, 50);
            this.pictureBoxFrame.Name = "pictureBoxFrame";
            this.pictureBoxFrame.Size = new System.Drawing.Size(331, 239);
            this.pictureBoxFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFrame.TabIndex = 16;
            this.pictureBoxFrame.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(449, 295);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(460, 42);
            this.progressBar.TabIndex = 15;
            // 
            // btnProcessVideo
            // 
            this.btnProcessVideo.BackColor = System.Drawing.Color.PaleGreen;
            this.btnProcessVideo.Location = new System.Drawing.Point(614, 247);
            this.btnProcessVideo.Name = "btnProcessVideo";
            this.btnProcessVideo.Size = new System.Drawing.Size(133, 42);
            this.btnProcessVideo.TabIndex = 14;
            this.btnProcessVideo.Text = "Xử lý video";
            this.btnProcessVideo.UseVisualStyleBackColor = false;
            this.btnProcessVideo.Click += new System.EventHandler(this.btnProcessVideo_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(120, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 8);
            this.button2.TabIndex = 13;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnSelectVideo
            // 
            this.btnSelectVideo.Location = new System.Drawing.Point(21, 12);
            this.btnSelectVideo.Name = "btnSelectVideo";
            this.btnSelectVideo.Size = new System.Drawing.Size(131, 32);
            this.btnSelectVideo.TabIndex = 12;
            this.btnSelectVideo.Text = "Chọn video";
            this.btnSelectVideo.UseVisualStyleBackColor = true;
            this.btnSelectVideo.Click += new System.EventHandler(this.btnSelectVideo_Click);
            // 
            // Form_LBP_Giang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 623);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.lblImagePath);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.lblVideoPath);
            this.Controls.Add(this.pictureBoxFrame);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnProcessVideo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSelectVideo);
            this.Name = "Form_LBP_Giang";
            this.Text = "Form_LBP_Giang";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Label lblImagePath;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Label lblVideoPath;
        private System.Windows.Forms.PictureBox pictureBoxFrame;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnProcessVideo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSelectVideo;
    }
}