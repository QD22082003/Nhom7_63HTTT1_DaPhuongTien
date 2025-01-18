namespace CuoiKi
{
    partial class Ha_FormInfoVideo
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLuuThongTinVideo = new System.Windows.Forms.Button();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(160, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(617, 22);
            this.textBox1.TabIndex = 5;
            // 
            // btnLuuThongTinVideo
            // 
            this.btnLuuThongTinVideo.Location = new System.Drawing.Point(372, 123);
            this.btnLuuThongTinVideo.Name = "btnLuuThongTinVideo";
            this.btnLuuThongTinVideo.Size = new System.Drawing.Size(223, 60);
            this.btnLuuThongTinVideo.TabIndex = 4;
            this.btnLuuThongTinVideo.Text = "Lưu thông tin video";
            this.btnLuuThongTinVideo.UseVisualStyleBackColor = true;
            this.btnLuuThongTinVideo.Click += new System.EventHandler(this.btnLuuThongTinVideo_Click);
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(12, 63);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(123, 37);
            this.btnChonFile.TabIndex = 3;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // Ha_FormInfoVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnLuuThongTinVideo);
            this.Controls.Add(this.btnChonFile);
            this.Name = "Ha_FormInfoVideo";
            this.Text = "Ha_FormInfoVideo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLuuThongTinVideo;
        private System.Windows.Forms.Button btnChonFile;
    }
}