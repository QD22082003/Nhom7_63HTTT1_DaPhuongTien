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
    public partial class Ha_FormInfoVideo : Form
    {
        public Ha_FormInfoVideo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video files (*.mp4;*.avi;*.mkv)|*.mp4;*.avi;*.mkv|All files (*.*)|*.*";
                openFileDialog.Title = "Chọn tệp video";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnLuuThongTinVideo_Click(object sender, EventArgs e)
        {
            // Lấy đường dẫn video từ TextBox
            string videoPath = textBox1.Text;

            // Kiểm tra xem tệp video có tồn tại hay không
            if (!File.Exists(videoPath))
            {
                MessageBox.Show("Tệp video không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy thư mục và tên tệp đầu vào
            string videoDirectory = Path.GetDirectoryName(videoPath);
            string videoFileNameWithoutExtension = Path.GetFileNameWithoutExtension(videoPath);

            // Tạo đường dẫn cho tệp .txt (cùng thư mục với video)
            string outputPath = Path.Combine(videoDirectory, $"{videoFileNameWithoutExtension}_info.txt");

            // Lệnh FFmpeg để lấy thông tin video và lưu vào tệp
            string arguments = $"-i \"{videoPath}\" -hide_banner -f null - 2> \"{outputPath}\"";

            // Sử dụng FFmpegHelper để thực thi lệnh
            Ha_FFmpegHelper.RunExe("cmd.exe", $"/C ffmpeg {arguments}");

            // Kiểm tra nếu tệp đã được tạo thành công
            if (File.Exists(outputPath))
            {
                MessageBox.Show($"Thông tin video đã được lưu tại:\n{outputPath}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể lấy thông tin video.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
