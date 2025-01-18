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
using CuoiKi;

namespace CuoiKi
{
    public partial class Ha_FormMergeImagestoVideo : Form
    {
        public Ha_FormMergeImagestoVideo()
        {
            InitializeComponent();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Chọn thư mục chứa danh sách ảnh";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btnChuyenListAnhThanhVideo_Click(object sender, EventArgs e)
        {
            // Lấy đường dẫn thư mục chứa ảnh từ TextBox
            string imagesDir = textBox1.Text;

            // Kiểm tra xem thư mục có tồn tại không
            if (!Directory.Exists(imagesDir))
            {
                MessageBox.Show("Thư mục không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Đường dẫn video đầu ra
            string outputVideoPath = Path.Combine(imagesDir, "output.mp4");

            // Lệnh FFmpeg để hợp ảnh thành video
            string arguments = $"-framerate 30 -i \"{imagesDir}\\frame_%04d.jpg\" -c:v libx264 \"{outputVideoPath}\"";

            // Gọi hàm từ FFmpegHelper để thực thi lệnh
            Ha_FFmpegHelper.RunExe("ffmpeg", arguments);

            // Kiểm tra nếu tệp video đã được tạo thành công
            if (File.Exists(outputVideoPath))
            {
                MessageBox.Show($"Video đã được hợp từ danh sách ảnh!\nĐường dẫn: {outputVideoPath}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể hợp danh sách ảnh thành video.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ha_FormMergeImagestoVideo_Load(object sender, EventArgs e)
        {

        }
    }
}
