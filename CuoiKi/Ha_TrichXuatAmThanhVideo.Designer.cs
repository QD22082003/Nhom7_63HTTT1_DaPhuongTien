namespace CuoiKi
{
    partial class Ha_TrichXuatAmThanhVideo
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
            this.btnTrichxuatamthanhtuvideo = new System.Windows.Forms.Button();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTrichxuatamthanhtuvideo
            // 
            this.btnTrichxuatamthanhtuvideo.Location = new System.Drawing.Point(361, 109);
            this.btnTrichxuatamthanhtuvideo.Name = "btnTrichxuatamthanhtuvideo";
            this.btnTrichxuatamthanhtuvideo.Size = new System.Drawing.Size(194, 46);
            this.btnTrichxuatamthanhtuvideo.TabIndex = 0;
            this.btnTrichxuatamthanhtuvideo.Text = "Trích xuất âm thanh từ video";
            this.btnTrichxuatamthanhtuvideo.UseVisualStyleBackColor = true;
            this.btnTrichxuatamthanhtuvideo.Click += new System.EventHandler(this.btnTrichxuatamthanhtuvideo_Click);
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(12, 53);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(91, 37);
            this.btnChonFile.TabIndex = 1;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(644, 22);
            this.textBox1.TabIndex = 2;
            // 
            // Ha_TrichXuatAmThanhVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnChonFile);
            this.Controls.Add(this.btnTrichxuatamthanhtuvideo);
            this.Name = "Ha_TrichXuatAmThanhVideo";
            this.Text = "Ha_TrichXuatAmThanhVideo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrichxuatamthanhtuvideo;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.TextBox textBox1;
    }
}