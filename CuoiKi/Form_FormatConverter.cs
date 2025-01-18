using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKi
{
    public partial class Form_FormatConverter : Form
    {
        public Form_FormatConverter()
        {
            InitializeComponent();
        }

        private string ffmpegPath = @"D:\TLU\Hocky7\DaPhuongTien\Cuoiky\ffmpeg\\bin\ffmpeg.exe";

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string inputPath = label3.Text;
                string outputFolder = label4.Text;
                string selectedFormat = comboBox1.SelectedItem?.ToString(); // Lấy định dạng
                string outputFileName = textBox1.Text;


                // Kiểm tra đầu vào
                if (!File.Exists(inputPath))
                {
                    MessageBox.Show("Tệp video đầu vào không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(outputFolder) || !Directory.Exists(outputFolder))
                {
                    MessageBox.Show("Thư mục lưu video đầu ra không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(selectedFormat))
                {
                    MessageBox.Show("Vui lòng chọn định dạng đầu ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đường dẫn tệp đầu ra
                string outputPath = Path.Combine(outputFolder, $"{outputFileName}.{selectedFormat.ToLower()}");

                // Câu lệnh FFmpeg
                string args = $"-i \"{inputPath}\" \"{outputPath}\"";

                // Chạy FFmpeg
                FFmpegHelper.RunExe(ffmpegPath, args);

                // Thành công
                MessageBox.Show($"Chuyển đổi định dạng video thành công!\nVideo đã được lưu tại: {outputPath}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

    }
}
