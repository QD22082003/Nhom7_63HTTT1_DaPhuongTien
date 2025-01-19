using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKi
{
    public partial class Dao_FileVideovsFileAudio : Form
    {
        string videoFileName = "";
        string audioFileName = "";
        string resultPath = "";
        public Dao_FileVideovsFileAudio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "File video|*.mp4;*.aiv; |All File| *.*;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                videoFileName = openFileDialog1.FileName;
                lbl_videoFileName.Text = videoFileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(videoFileName) || string.IsNullOrEmpty(audioFileName) || string.IsNullOrEmpty(resultPath))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ file video, file âm thanh và thư mục lưu kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ffmpeg = @"D:\Hoc\Ki7\DaPhuongTien\ffmpeg-2024-12-16-git-d2096679d5-essentials_build\bin\ffmpeg.exe";
            string output = $"{resultPath}\\VideoDaTron.mp4";
            string para = $"-i \"{videoFileName}\" -i \"{audioFileName}\" -c:v copy -c:a aac -strict experimental \"{output}\"";

            FFmpegHelper.RunExe("ffmpeg", para);

            MessageBox.Show("Đã trộn video và âm thanh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "File audio|*.mp3;*.wav;*.aac|All File|*.*;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                audioFileName = openFileDialog1.FileName;
                lbl_audioFileName.Text = audioFileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                resultPath = folderBrowserDialog1.SelectedPath;
                lbl_resultPath.Text = resultPath;
            }
        }
    }
}
