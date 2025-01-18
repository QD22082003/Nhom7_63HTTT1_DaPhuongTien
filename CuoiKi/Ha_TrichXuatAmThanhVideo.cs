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
    public partial class Ha_TrichXuatAmThanhVideo : Form
    {
        public Ha_TrichXuatAmThanhVideo()
        {
            InitializeComponent();
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

        private void btnTrichxuatamthanhtuvideo_Click(object sender, EventArgs e)
        {
            // Lấy đường dẫn video từ TextBox
            string videoPath = textBox1.Text;

            // Kiểm tra xem tệp video có tồn tại hay không
            if (!File.Exists(videoPath))
            {
                MessageBox.Show("Tệp video không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo đường dẫn tệp âm thanh đầu ra
            string outputAudioPath = Path.ChangeExtension(videoPath, ".mp3");

            // Kiểm tra xem tệp âm thanh đã tồn tại hay chưa
            if (File.Exists(outputAudioPath))
            {
                MessageBox.Show($"Tệp âm thanh đã tồn tại:\n{outputAudioPath}\nVui lòng chọn video khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Nếu đã tồn tại, không thực hiện trích xuất nữa
            }

            // Lệnh FFmpeg để tách âm thanh từ video
            string arguments = $"-i \"{videoPath}\" -q:a 0 -map a \"{outputAudioPath}\"";

            // Gọi hàm từ Ha_FFmpegHelper để thực thi lệnh tách âm thanh
            Ha_FFmpegHelper.RunExe("ffmpeg", arguments);

            // Thông báo thành công
            if (File.Exists(outputAudioPath))
            {
                MessageBox.Show($"Đã tách âm thanh thành công!\nĐường dẫn âm thanh:\n{outputAudioPath}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể tách âm thanh. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
