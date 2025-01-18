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
    public partial class Ha_FormExtractFrames : Form
    {
        public Ha_FormExtractFrames()
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

        private void btnChuyenVideoThanhListAnh_Click(object sender, EventArgs e)
        {
            //ffmpeg -i input.mp4 frames/output_%04d.jpg
            // Lấy đường dẫn video từ TextBox
            string videoPath = textBox1.Text;

            // Kiểm tra xem tệp video có tồn tại hay không
            if (!File.Exists(videoPath))
            {
                MessageBox.Show("Tệp video không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo thư mục để lưu ảnh đầu ra
            string outputDir = Path.Combine(Path.GetDirectoryName(videoPath), "frames");
            Directory.CreateDirectory(outputDir);

            // Lệnh FFmpeg để tách video thành danh sách ảnh
            string arguments = $"-i \"{videoPath}\" \"{outputDir}\\frame_%04d.jpg\"";

            // Gọi hàm từ FFmpegHelper để thực thi lệnh tách ảnh
            Ha_FFmpegHelper.RunExe("ffmpeg", arguments);

            MessageBox.Show($"Đã tách video thành danh sách ảnh trong thư mục:\n{outputDir}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //
    }
}
