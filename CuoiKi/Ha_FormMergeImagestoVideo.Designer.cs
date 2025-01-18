namespace CuoiKi
{
    partial class Ha_FormMergeImagestoVideo
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
            this.btnChuyenListAnhThanhVideo = new System.Windows.Forms.Button();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnChuyenListAnhThanhVideo
            // 
            this.btnChuyenListAnhThanhVideo.Location = new System.Drawing.Point(354, 117);
            this.btnChuyenListAnhThanhVideo.Name = "btnChuyenListAnhThanhVideo";
            this.btnChuyenListAnhThanhVideo.Size = new System.Drawing.Size(219, 59);
            this.btnChuyenListAnhThanhVideo.TabIndex = 5;
            this.btnChuyenListAnhThanhVideo.Text = "Chuyển List ảnh thành video";
            this.btnChuyenListAnhThanhVideo.UseVisualStyleBackColor = true;
            this.btnChuyenListAnhThanhVideo.Click += new System.EventHandler(this.btnChuyenListAnhThanhVideo_Click);
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(25, 64);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(98, 41);
            this.btnChonFile.TabIndex = 4;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(138, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(642, 22);
            this.textBox1.TabIndex = 3;
            // 
            // Ha_FormMergeImagestoVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnChuyenListAnhThanhVideo);
            this.Controls.Add(this.btnChonFile);
            this.Controls.Add(this.textBox1);
            this.Name = "Ha_FormMergeImagestoVideo";
            this.Text = "Ha_FormMergeImagestoVideo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChuyenListAnhThanhVideo;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.TextBox textBox1;
    }
}