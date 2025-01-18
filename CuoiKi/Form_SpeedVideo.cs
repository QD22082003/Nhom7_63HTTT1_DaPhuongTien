using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKi
{
    public partial class Form_SpeedVideo : Form
    {
        public Form_SpeedVideo()
        {
            InitializeComponent();
        }

        private string ffmpegPath = @"D:\TLU\Hocky7\DaPhuongTien\Cuoiky\ffmpeg\\bin\ffmpeg.exe";


        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mkv;*.mov";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    label3.Text = openFileDialog.FileName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Chọn thư mục để lưu video đầu ra";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    label4.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string inputPath = label3.Text;
                string outputPath = label4.Text;
                double speedFactor = Double.Parse(comboBox1.Text);
                string outputFileName = textBox1.Text;

                // Kiểm tra các giá trị đầu vào
                if (!File.Exists(inputPath))
                {
                    MessageBox.Show("Tệp video đầu vào không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(outputPath))
                {
                    MessageBox.Show("Bạn cần nhập đường dẫn cho tệp video đầu ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string outputFile = Path.Combine(outputPath, $"{outputFileName}.mp4");

                // Tạo lệnh FFmpeg
                string args = $"-i \"{inputPath}\" -vf \"setpts={1 / speedFactor}*PTS\" \"{outputFile}\"";

                // Chạy lệnh FFmpeg
                FFmpegHelper.RunExe(ffmpegPath, args);

                // Thành công
                MessageBox.Show("Chỉnh tốc độ video thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
