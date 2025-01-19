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
    public partial class Form_ConcatenateVideo : Form
    {

        OpenFileDialog openFileDialog;

        public Form_ConcatenateVideo()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tệp video|*.mp4;*.avi;*.mkv;*.mov";
            openFileDialog.Multiselect = true;
        }

        private string ffmpegPath = @"D:\TLU\Hocky7\DaPhuongTien\Cuoiky\ffmpeg\\bin\ffmpeg.exe";

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra danh sách video trong ListBox
                if (listBox1.Items.Count == 0)
                {
                    MessageBox.Show("Bạn chưa chọn video nào!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra đầu vào: Thư mục lưu video đầu ra
                string outputFolder = label4.Text;
                if (string.IsNullOrWhiteSpace(outputFolder) || !Directory.Exists(outputFolder))
                {
                    MessageBox.Show("Thư mục đầu ra không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hộp thoại đặt tên tệp video đầu ra
                string outputFileName = textBox1.Text;
                if (string.IsNullOrWhiteSpace(outputFileName))
                {
                    MessageBox.Show("Bạn cần nhập tên cho video đầu ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đường dẫn file đầu ra
                string outputFilePath = Path.Combine(outputFolder, $"{outputFileName}.mp4");

                // Tạo tệp danh sách video
                string listFilePath = Path.Combine(outputFolder, "file-list.txt");
                using (StreamWriter writer = new StreamWriter(listFilePath))
                {
                    foreach (var item in listBox1.Items)
                    {
                        writer.WriteLine($"file '{item}'");
                    }
                }

                // Câu lệnh FFmpeg để ghép video
                string ffmpegArgs = $"-f concat -safe 0 -i \"{listFilePath}\" -c copy \"{outputFilePath}\"";

                // Chạy FFmpeg để ghép video
                FFmpegHelper.RunExe("ffmpeg", ffmpegArgs);

                // Thông báo thành công
                MessageBox.Show($"Video đã được ghép thành công và lưu tại: {outputFilePath}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Tệp video|*.mp4;*.avi;*.mkv;*.mov",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.AddRange(openFileDialog.FileNames); // Thêm các video mới
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
