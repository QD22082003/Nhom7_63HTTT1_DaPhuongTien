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
    public partial class Dao_CatVideo : Form
    {
        public Dao_CatVideo()
        {
            InitializeComponent();
        }
        string videoFileName = "";
        string resultPath = "";
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Dao_CatVideo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "File video|*.mp4;*.avi;|All File|*.*;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                videoFileName = openFileDialog1.FileName;
                lbl_videoFileName.Text = videoFileName;
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

        private void button3_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem file video và thư mục kết quả đã được chọn chưa
            if (string.IsNullOrEmpty(videoFileName) || string.IsNullOrEmpty(resultPath))
            {
                MessageBox.Show("Vui lòng chọn file video và thư mục lưu kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thời gian bắt đầu và kết thúc
            if (!double.TryParse(txt_startTime.Text, out double startTime) || !double.TryParse(txt_endTime.Text, out double endTime))
            {
                MessageBox.Show("Vui lòng nhập thời gian bắt đầu và kết thúc hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (startTime >= endTime)
            {
                MessageBox.Show("Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ffmpeg = @"D:\Hoc\Ki7\DaPhuongTien\ffmpeg-2024-12-16-git-d2096679d5-essentials_build\bin\ffmpeg.exe";
            string output = $"{resultPath}\\VideoDaCat.mp4";

            // Lệnh FFmpeg sửa đổi để đảm bảo cả âm thanh và hình ảnh được cắt
            string para = $"-i \"{videoFileName}\" -ss {startTime} -to {endTime} -c:v libx264 -c:a aac -strict experimental \"{output}\"";

            // Chạy lệnh
            FFmpegHelper.RunExe("ffmpeg", para);

            MessageBox.Show("Cắt video thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
