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
    public partial class Form_AddImageToAudio : Form
    {
        private string ffmpegPath = @"C:\ffmpeg\bin\ffmpeg.exe";

        private string videoOutputFolder = ""; // Thư mục lưu file video
        private string selectedAudioPath = ""; // Đường dẫn file âm thanh
        private string selectedImagePath = ""; // Đường dẫn file ảnh

        public Form_AddImageToAudio()
        {
            InitializeComponent();
        }

        // Add img to sound
        private void btnAddImageToAudio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(videoOutputFolder))
            {
                MessageBox.Show("Vui lòng chọn thư mục lưu file video trước!");
                return;
            }

            if (string.IsNullOrEmpty(selectedAudioPath))
            {
                MessageBox.Show("Vui lòng chọn một file âm thanh trước!");
                return;
            }

            if (string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Vui lòng chọn một file ảnh trước!");
                return;
            }

            // Đường dẫn video đầu ra
            string outputVideoPath = Path.Combine(videoOutputFolder, "output_with_image.mp4");

            // Kiểm tra nếu file video đã tồn tại
            if (File.Exists(outputVideoPath))
            {
                MessageBox.Show($"File video đã tồn tại tại: {outputVideoPath}\nVui lòng chọn video khác hoặc thay đổi thư mục lưu.");
                return;
            }

                
            string optimizedImagePath = OptimizeImage(selectedImagePath);

            // Tạo tham số lệnh cho FFmpeg
            string ffmpeg = ffmpegPath;
            //string parameters = $"-loop 1 -i \"{selectedImagePath}\" -i \"{selectedAudioPath}\" -shortest -c:v libx264 -c:a aac -b:a 192k -pix_fmt yuv420p \"{outputVideoPath}\"";
            string parameters = $"-loop 1 -i \"{optimizedImagePath}\" -i \"{selectedAudioPath}\" -shortest -c:v libx264 -preset ultrafast -crf 23 -c:a aac -b:a 192k -pix_fmt yuv420p \"{outputVideoPath}\"";
            // Gọi FFmpeg để thực hiện quá trình tạo video
            FFmpegHelper.RunExe(ffmpeg, parameters);
        }
        

        // Save video output
        private void btnSelectVideoOutputFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Chọn thư mục để lưu file video";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    videoOutputFolder = folderBrowserDialog.SelectedPath;

                    // Hiển thị đường dẫn trên Label thay vì MessageBox
                    lblVideoOutputPath.Text = $"File video: {videoOutputFolder}";
                }
            }
        }

        // Select audio
        private void btnSelectAudioFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Audio Files|*.mp3;*.wav;*.aac",
                Title = "Chọn một file âm thanh"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedAudioPath = openFileDialog.FileName;
                lblAudioFilePath.Text = $"File âm thanh: {selectedAudioPath}";
            }
        }

        // select img
        private void btnSelectImageFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.png",
                Title = "Chọn một file ảnh"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                lblImageFilePath.Text = $"File ảnh: {selectedImagePath}";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // Hàm tối ưu hóa ảnh 
        private string OptimizeImage(string inputImagePath)
        {
            string optimizedImagePath = Path.Combine(Path.GetTempPath(), "optimized_image.jpg");

            using (Image image = Image.FromFile(inputImagePath))
            {
                int targetWidth = 1920; // Độ rộng tối đa (hoặc bạn có thể thay đổi)
                int targetHeight = 1080; // Chiều cao tối đa (hoặc bạn có thể thay đổi)

                // Tính toán kích thước mới giữ nguyên tỷ lệ
                double scale = Math.Min((double)targetWidth / image.Width, (double)targetHeight / image.Height);
                int newWidth = (int)(image.Width * scale);
                int newHeight = (int)(image.Height * scale);

                using (Bitmap resizedImage = new Bitmap(image, new Size(newWidth, newHeight)))
                {
                    // Nén ảnh khi lưu (chỉ dùng cho JPEG)
                    var encoder = GetEncoder(System.Drawing.Imaging.ImageFormat.Jpeg);
                    var encoderParameters = new System.Drawing.Imaging.EncoderParameters(1);
                    encoderParameters.Param[0] = new System.Drawing.Imaging.EncoderParameter(
                        System.Drawing.Imaging.Encoder.Quality, 80L); // Giảm chất lượng ảnh xuống 80%

                    resizedImage.Save(optimizedImagePath, encoder, encoderParameters);
                }
            }

            return optimizedImagePath;
        }

        // Lấy encoder cho định dạng JPEG
        private System.Drawing.Imaging.ImageCodecInfo GetEncoder(System.Drawing.Imaging.ImageFormat format)
        {
            return System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders()
                .FirstOrDefault(c => c.FormatID == format.Guid);
        }


    }
}
