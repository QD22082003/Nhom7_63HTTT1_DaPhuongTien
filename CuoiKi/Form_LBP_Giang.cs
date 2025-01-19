using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; 
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKi
{
    public partial class Form_LBP_Giang : Form
    {
        private VideoCapture _videoCapture; // Đối tượng để đọc video
        private string _videoPath;         // Đường dẫn video
        private Mat _selectedImage;       // Ảnh đã chọn để so sánh
        public Form_LBP_Giang()
        {
            InitializeComponent();
        }

        // select video
        private void btnSelectVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Video Files|*.mp4;*.avi;*.mkv"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _videoPath = openFileDialog.FileName;
                lblVideoPath.Text = $"Video: {_videoPath}";
                _videoCapture = new VideoCapture(_videoPath); // Mở video

                // Đọc khung hình đầu tiên để hiển thị
                Mat frame = new Mat();
                _videoCapture.Read(frame);
                if (!frame.Empty())
                {
                    pictureBoxFrame.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame); // Hiển thị khung hình đầu tiên trong pictureBoxFrame
                }
            }
        }

        // select img
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                _selectedImage = Cv2.ImRead(imagePath); // Đọc ảnh đã chọn
                pictureBoxImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(_selectedImage); // Hiển thị ảnh trong PictureBox
                lblImagePath.Text = $"Ảnh: {imagePath}";
            }
        }

        // btn process 
        private void btnProcessVideo_Click(object sender, EventArgs e)
        {
            if (_videoCapture == null)
            {
                MessageBox.Show("Vui lòng chọn video trước.", "Thông báo");
                return;
            }

            if (_selectedImage == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh trước.", "Thông báo");
                return;
            }
            Mat frame = new Mat();
            int frameIndex = 0;
            double maxSimilarity = 0;
            int bestFrameIndex = -1;
            Mat bestFrame = null; // Khai báo biến để lưu trữ khung hình giống nhất

            // Tính LBP cho ảnh đã chọn
            float[] selectedImageHist = ComputeLBP(_selectedImage);

            while (true)
            {
                _videoCapture.Read(frame);  // Đọc khung hình tiếp theo từ video
                if (frame.Empty()) break; // Nếu không còn khung hình thì thoát vòng lặp

                if (frameIndex % 5 == 0) // Bỏ qua một số khung hình để giảm tải
                {
                    pictureBoxFrame.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
                    Application.DoEvents(); // Đảm bảo giao diện không bị treo

                    // Tính LBP cho khung hình và so sánh với ảnh
                    float[] frameHist = ComputeLBP(frame);
                    double distance = CompareHistograms(selectedImageHist, frameHist);

                    // Cập nhật log trong listBox và khoảng cách
                    this.Invoke((MethodInvoker)delegate
                    {
                        listBoxLog.Items.Add($"Khung hình {frameIndex}: Khoảng cách = {distance:F5}");

                        // Kiểm tra và giới hạn giá trị của progressBar.Value
                        if (frameIndex >= progressBar.Minimum && frameIndex <= progressBar.Maximum)
                        {
                            progressBar.Value = frameIndex; // Cập nhật tiến trình
                        }
                        else
                        {
                            progressBar.Value = progressBar.Maximum; // Nếu giá trị vượt quá, đặt về giá trị tối đa
                        }
                    });
                    // Lưu trữ khung hình có độ tương đồng cao nhất
                    double similarity = 1.0 / (1.0 + distance); // Chuyển khoảng cách thành độ tương đồng

                    if (similarity > maxSimilarity)
                    {
                        maxSimilarity = similarity;
                        bestFrameIndex = frameIndex;
                        bestFrame = frame.Clone(); // Lưu trữ khung hình giống nhất 
                    }
                }

                frameIndex++;
            }

            // Tắt progressBar và hiển thị kết quả
            this.Invoke((MethodInvoker)delegate
            {
                progressBar.Value = progressBar.Maximum; // Hoàn thành tiến trình
                MessageBox.Show($"Most similar frame: {bestFrameIndex} with similarity = {maxSimilarity:F2}", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Hiển thị ảnh kết quả (khung hình giống nhất)
                if (bestFrame != null)
                {
                    pictureBoxResult.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(bestFrame); // Hiển thị ảnh kết quả vào pictureBoxResult
                }
            });

            MessageBox.Show("Xử lý video hoàn tất!", "Thông báo");
        }

        // Hàm tính toán đặc trưng LBP
        private float[] ComputeLBP(Mat image)
        {
            Mat grayImage = new Mat();
            Cv2.CvtColor(image, grayImage, ColorConversionCodes.BGR2GRAY); // Chuyển ảnh sang thang độ xám

            // Khởi tạo histogram
            int[] hist = new int[256];
            IntPtr dataPtr = grayImage.Data;
            byte[] data = new byte[grayImage.Rows * grayImage.Cols * grayImage.Channels()];
            Marshal.Copy(dataPtr, data, 0, data.Length);

            // Tính LBP cho từng pixel 
            for (int y = 1; y < grayImage.Rows - 1; y++)
            {
                for (int x = 1; x < grayImage.Cols - 1; x++)
                {
                    byte center = data[y * grayImage.Cols + x]; // Giá trị mức xám của điểm trung tâm
                    byte lbpCode = 0; // Lưu mã LBP của pixel hiện tại

                    for (int i = -1; i <= 1; i++) // Xét các hàng lân cận (-1, 0, 1)
                    {
                        for (int j = -1; j <= 1; j++) // Xét các cột lân cận (-1, 0, 1)
                        {
                            if (i == 0 && j == 0) continue; // Bỏ qua điểm trung tâm
                            byte neighbor = data[(y + i) * grayImage.Cols + (x + j)]; // Giá trị mức xám của điểm lân cận
                            lbpCode <<= 1; // Dịch trái 1 bit để tạo mã nhị phân LBP
                            if (neighbor > center) // So sánh mức xám giữa điểm lân cận và điểm trung tâm
                                lbpCode |= 1; // Nếu điểm lân cận sáng hơn, gán giá trị 1
                        }
                    }

                    hist[lbpCode]++;
                }
            }

            // Chuẩn hóa histogram
            float[] normalizedHist = new float[256];
            int totalPixels = grayImage.Rows * grayImage.Cols;

            for (int i = 0; i < 256; i++)
                normalizedHist[i] = (float)hist[i] / totalPixels;

            return normalizedHist;
        }

        // Hàm so sánh histogram bằng khoảng cách Euclidean 
        private double CompareHistograms(float[] hist1, float[] hist2)
        {
            double distance = 0;
            for (int i = 0; i < hist1.Length; i++)
            {
                double numerator = Math.Pow(hist1[i] - hist2[i], 2);
                double denominator = hist1[i] + hist2[i] + 1e-10; // Tránh chia cho 0
                distance += numerator / denominator;
            }
            return distance;
        }

        //
    }
}
