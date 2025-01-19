using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace CuoiKi
{
    public partial class Form_LBP_Thai : Form
    {
        public Form_LBP_Thai()
        {
            InitializeComponent();
        }

        private string imagePath = "";
        private string videoPath = "";

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;
                    label3.Text = "Ảnh đã chọn: " + imagePath;

                    try
                    {
                        // Hiển thị ảnh trên PictureBox
                        pictureBox1.Image = Image.FromFile(imagePath);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Tùy chỉnh kích thước hiển thị
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể hiển thị ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAnhVideo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mkv";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    videoPath = openFileDialog.FileName;
                    label4.Text = "Video đã chọn: " + videoPath;
                }
            }
        }

        private async void btnTimAnhTuongDong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(imagePath) || string.IsNullOrEmpty(videoPath))
            {
                MessageBox.Show("Vui lòng chọn cả ảnh và video.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị Loading
            label5.Visible = true;
            label5.Text = "Đang xử lý...";
            btnTimAnhTuongDong.Enabled = false;

            try
            {
                // Xử lý tìm kiếm ảnh tương đồng trong một Task
                var result = await Task.Run(() => CalculateSimilarity(imagePath, videoPath));

                // Hiển thị kết quả
                textBox1.Text = result.result;

                if (result.bestFrame != null)
                {
                    pictureBox2.Image = MatToBitmap(result.bestFrame);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy frame tương đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ẩn Loading sau khi xử lý xong
                label5.Visible = false;
                btnTimAnhTuongDong.Enabled = true;
            }
        }


        private Bitmap MatToBitmap(Mat mat)
        {
            using (var ms = mat.ToMemoryStream())
            {
                return new Bitmap(ms);
            }
        }


        private (string result, Mat bestFrame) CalculateSimilarity(string imagePath, string videoPath)
        {
            try
            {
                Mat imageMat = Cv2.ImRead(imagePath, ImreadModes.Grayscale);

                if (imageMat.Empty())
                {
                    return ("Không thể đọc ảnh.", null);
                }

                VideoCapture capture = new VideoCapture(videoPath);
                Cv2.Resize(imageMat, imageMat, new OpenCvSharp.Size(640, 480));

                if (!capture.IsOpened())
                {
                    return ("Không thể mở video.", null);
                }

                int frameIndex = 0;
                double maxCorrelation = -1;
                int bestFrameIndex = -1;
                Mat bestFrame = null;

                while (true)
                {
                    Mat frame = new Mat();
                    bool success = capture.Read(frame);
                    if (!success) break;

                    frameIndex++;
                    Mat grayFrame = frame.CvtColor(ColorConversionCodes.BGR2GRAY);

                    if (imageMat.Size() != grayFrame.Size())
                    {
                        Cv2.Resize(grayFrame, grayFrame, imageMat.Size());
                    }

                    double similarity = CompareLBP(imageMat, grayFrame);
                    if (similarity > maxCorrelation)
                    {
                        maxCorrelation = similarity;
                        bestFrameIndex = frameIndex;
                        bestFrame = frame.Clone(); // Lưu frame tốt nhất
                    }
                }

                capture.Release();

                if (bestFrameIndex != -1)
                {
                    return ($"Độ tương đồng cao nhất là frame {bestFrameIndex} với điểm số {maxCorrelation}", bestFrame);
                }
                else
                {
                    return ("Không tìm thấy sự tương đồng trong video.", null);
                }
            }
            catch (Exception ex)
            {
                return ($"Lỗi khi xử lý ảnh hoặc video: {ex.Message}", null);
            }
        }


        private Mat CalculateLBP(Mat img)
        {
            // Đảm bảo ảnh ở dạng grayscale
            if (img.Channels() > 1)
            {
                Cv2.CvtColor(img, img, ColorConversionCodes.BGR2GRAY);
            }

            Mat lbp = new Mat(img.Rows, img.Cols, MatType.CV_8U, Scalar.All(0));

            // Duyệt qua các pixel trong ảnh (tránh biên)
            for (int i = 1; i < img.Rows - 1; i++)
            {
                for (int j = 1; j < img.Cols - 1; j++)
                {
                    byte centerPixel = img.At<byte>(i, j);
                    int lbpValue = 0;

                    // Đọc các pixel xung quanh pixel trung tâm (8 pixel xung quanh)
                    lbpValue |= (img.At<byte>(i - 1, j - 1) >= centerPixel ? 1 : 0) << 7;
                    lbpValue |= (img.At<byte>(i - 1, j) >= centerPixel ? 1 : 0) << 6;
                    lbpValue |= (img.At<byte>(i - 1, j + 1) >= centerPixel ? 1 : 0) << 5;
                    lbpValue |= (img.At<byte>(i, j + 1) >= centerPixel ? 1 : 0) << 4;
                    lbpValue |= (img.At<byte>(i + 1, j + 1) >= centerPixel ? 1 : 0) << 3;
                    lbpValue |= (img.At<byte>(i + 1, j) >= centerPixel ? 1 : 0) << 2;
                    lbpValue |= (img.At<byte>(i + 1, j - 1) >= centerPixel ? 1 : 0) << 1;
                    lbpValue |= (img.At<byte>(i, j - 1) >= centerPixel ? 1 : 0) << 0;

                    lbp.Set(i, j, (byte)lbpValue); // Lưu giá trị LBP vào ảnh
                }
            }

            return lbp;
        }


        private double CompareLBP(Mat img1, Mat img2)
        {
            // Tính LBP cho cả hai ảnh
            Mat lbp1 = CalculateLBP(img1);
            Mat lbp2 = CalculateLBP(img2);

            // Tính histogram thủ công cho ảnh LBP
            int[] hist1 = new int[256];
            int[] hist2 = new int[256];

            // Đếm giá trị của các pixel LBP và lưu vào histogram
            for (int i = 0; i < lbp1.Rows; i++)
            {
                for (int j = 0; j < lbp1.Cols; j++)
                {
                    byte pixelValue1 = lbp1.At<byte>(i, j);
                    byte pixelValue2 = lbp2.At<byte>(i, j);

                    hist1[pixelValue1]++;
                    hist2[pixelValue2]++;
                }
            }

            // Tính toán sự tương đồng giữa các histogram bằng cách so sánh các giá trị
            double correlation = CompareHistograms(hist1, hist2);

            return correlation;  // Giá trị càng gần 1, độ tương đồng càng cao
        }

        private double CompareHistograms(int[] hist1, int[] hist2)
        {
            // Tính toán độ tương đồng bằng công thức Correlation
            double mean1 = hist1.Average();
            double mean2 = hist2.Average();

            double numerator = 0.0;
            double denominator1 = 0.0;
            double denominator2 = 0.0;

            for (int i = 0; i < hist1.Length; i++)
            {
                numerator += (hist1[i] - mean1) * (hist2[i] - mean2);
                denominator1 += Math.Pow(hist1[i] - mean1, 2);
                denominator2 += Math.Pow(hist2[i] - mean2, 2);
            }

            double denominator = Math.Sqrt(denominator1) * Math.Sqrt(denominator2);
            return denominator == 0 ? 0 : numerator / denominator;
        }

        
    }
}
