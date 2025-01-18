namespace CuoiKi
{
    partial class Ha_FormExtractFrames
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
            this.btnChonFile = new System.Windows.Forms.Button();
            this.btnChuyenVideoThanhListAnh = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(29, 62);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(92, 48);
            this.btnChonFile.TabIndex = 0;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // btnChuyenVideoThanhListAnh
            // 
            this.btnChuyenVideoThanhListAnh.Location = new System.Drawing.Point(363, 122);
            this.btnChuyenVideoThanhListAnh.Name = "btnChuyenVideoThanhListAnh";
            this.btnChuyenVideoThanhListAnh.Size = new System.Drawing.Size(189, 63);
            this.btnChuyenVideoThanhListAnh.TabIndex = 1;
            this.btnChuyenVideoThanhListAnh.Text = "Chuyển video thành list ảnh";
            this.btnChuyenVideoThanhListAnh.UseVisualStyleBackColor = true;
            this.btnChuyenVideoThanhListAnh.Click += new System.EventHandler(this.btnChuyenVideoThanhListAnh_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(138, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(631, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Ha_FormExtractFrames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnChuyenVideoThanhListAnh);
            this.Controls.Add(this.btnChonFile);
            this.Name = "Ha_FormExtractFrames";
            this.Text = "FormExtractFrames";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.Button btnChuyenVideoThanhListAnh;
        private System.Windows.Forms.TextBox textBox1;
    }
}