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
    public partial class Form_SplitVideo : Form
    {
        public Form_SplitVideo()
        {
            InitializeComponent();
        }

        private string ffmpegPath = @"D:\TLU\Hocky7\DaPhuongTien\Cuoiky\ffmpeg\\bin\ffmpeg.exe";

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy đường dẫn tệp video và thư mục đầu ra
                string inputPath = label3.Text;
                string outputFolder = label4.Text;
                int numParts = (int)numericUpDown1.Value;  // Số phần cắt
                string partDuration = maskedTextBox1.Text;  // Thời gian mỗi phần từ MaskedTextBox

                // Kiểm tra các đầu vào
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

                if (string.IsNullOrWhiteSpace(partDuration) || partDuration.Length != 8 || partDuration[2] != ':' || partDuration[5] != ':')
                {
                    MessageBox.Show("Vui lòng nhập thời gian mỗi phần theo định dạng hh:mm:ss!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Chuyển đổi thời gian cắt mỗi phần thành giây (hh:mm:ss)
                string[] timeParts = partDuration.Split(':');
                int hours = int.Parse(timeParts[0]);
                int minutes = int.Parse(timeParts[1]);
                int seconds = int.Parse(timeParts[2]);
                int totalDurationInSeconds = (hours * 3600) + (minutes * 60) + seconds;

                // Tạo chuỗi lệnh FFmpeg để cắt video
                StringBuilder ffmpegArgs = new StringBuilder();
                ffmpegArgs.Append($"-i \"{inputPath}\" ");

                // Thêm mỗi phần cắt vào chuỗi lệnh
                for (int i = 0; i < numParts; i++)
                {
                    int startTimeInSeconds = i * totalDurationInSeconds;
                    string startTime = TimeSpan.FromSeconds(startTimeInSeconds).ToString(@"hh\:mm\:ss");
                    string outputPath = Path.Combine(outputFolder, $"part{i + 1}.mp4");

                    // Thêm phần cắt vào chuỗi lệnh
                    ffmpegArgs.Append($"-ss {startTime} -t {partDuration} -c copy \"{outputPath}\" ");
                }

                // Chạy FFmpeg để cắt video
                FFmpegHelper.RunExe("ffmpeg", ffmpegArgs.ToString());

                // Thông báo thành công
                MessageBox.Show($"Video đã được chia thành {numParts} phần thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
