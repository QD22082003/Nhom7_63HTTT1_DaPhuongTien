namespace CuoiKi
{
    partial class Form_ExtractAudio
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
            this.btnExtractAudio = new System.Windows.Forms.Button();
            this.btnSelectAudioOutputFolder = new System.Windows.Forms.Button();
            this.lblAudioOutputPath = new System.Windows.Forms.Label();
            this.lstVideos = new System.Windows.Forms.ListBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExtractAudio
            // 
            this.btnExtractAudio.BackColor = System.Drawing.Color.PaleGreen;
            this.btnExtractAudio.Location = new System.Drawing.Point(395, 88);
            this.btnExtractAudio.Name = "btnExtractAudio";
            this.btnExtractAudio.Size = new System.Drawing.Size(152, 39);
            this.btnExtractAudio.TabIndex = 4;
            this.btnExtractAudio.Text = "2. Tách âm thanh";
            this.btnExtractAudio.UseVisualStyleBackColor = false;
            this.btnExtractAudio.Click += new System.EventHandler(this.btnExtractAudio_Click);
            // 
            // btnSelectAudioOutputFolder
            // 
            this.btnSelectAudioOutputFolder.Location = new System.Drawing.Point(395, 133);
            this.btnSelectAudioOutputFolder.Name = "btnSelectAudioOutputFolder";
            this.btnSelectAudioOutputFolder.Size = new System.Drawing.Size(152, 39);
            this.btnSelectAudioOutputFolder.TabIndex = 7;
            this.btnSelectAudioOutputFolder.Text = "Chọn thư mục để lưu";
            this.btnSelectAudioOutputFolder.UseVisualStyleBackColor = true;
            this.btnSelectAudioOutputFolder.Click += new System.EventHandler(this.btnSelectAudioOutputFolder_Click);
            // 
            // lblAudioOutputPath
            // 
            this.lblAudioOutputPath.AutoSize = true;
            this.lblAudioOutputPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudioOutputPath.Location = new System.Drawing.Point(553, 144);
            this.lblAudioOutputPath.Name = "lblAudioOutputPath";
            this.lblAudioOutputPath.Size = new System.Drawing.Size(46, 15);
            this.lblAudioOutputPath.TabIndex = 9;
            this.lblAudioOutputPath.Text = "link lưu";
            // 
            // lstVideos
            // 
            this.lstVideos.FormattingEnabled = true;
            this.lstVideos.Location = new System.Drawing.Point(12, 43);
            this.lstVideos.Name = "lstVideos";
            this.lstVideos.Size = new System.Drawing.Size(377, 173);
            this.lstVideos.TabIndex = 10;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSelectFolder.Location = new System.Drawing.Point(395, 43);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(152, 39);
            this.btnSelectFolder.TabIndex = 11;
            this.btnSelectFolder.Text = "Chọn video";
            this.btnSelectFolder.UseVisualStyleBackColor = false;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(135, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "Danh sách video";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(395, 178);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(152, 39);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Form_ExtractAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 288);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.lstVideos);
            this.Controls.Add(this.lblAudioOutputPath);
            this.Controls.Add(this.btnSelectAudioOutputFolder);
            this.Controls.Add(this.btnExtractAudio);
            this.Name = "Form_ExtractAudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tách âm thanh từ video";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExtractAudio;
        private System.Windows.Forms.Button btnSelectAudioOutputFolder;
        private System.Windows.Forms.Label lblAudioOutputPath;
        private System.Windows.Forms.ListBox lstVideos;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBack;
    }
}