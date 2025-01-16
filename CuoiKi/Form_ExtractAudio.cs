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
    public partial class Form_ExtractAudio : Form
    {
        private string ffmpegPath = @"C:\ffmpeg\bin\ffmpeg.exe";
        private string audioOutputFolder = ""; // Thư mục lưu file âm thanh

        public Form_ExtractAudio()
        {
            InitializeComponent();
        }

        // Select video
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true, // Cho phép chọn nhiều tệp
                Filter = "Video Files|*.mp4;*.avi;*.mkv", // Lọc chỉ tệp video
                Title = "Chọn các tệp video"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] selectedVideos = openFileDialog.FileNames;

                // Thêm video mới vào ListBox (không xóa danh sách cũ)
                foreach (string video in selectedVideos)
                {
                    // Kiểm tra nếu video đã có trong danh sách để tránh trùng lặp
                    if (!lstVideos.Items.Contains(video))
                    {
                        lstVideos.Items.Add(video);
                    }
                }
            }
        }

        // Extract audio
        private void btnExtractAudio_Click(object sender, EventArgs e)
        {
            if (lstVideos.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một video từ danh sách!");
                return;
            }

            if (string.IsNullOrEmpty(audioOutputFolder))
            {
                MessageBox.Show("Vui lòng chọn thư mục lưu file âm thanh trước!");
                return;
            }

            string selectedVideo = lstVideos.SelectedItem.ToString();
            string outputAudioPath = Path.Combine(audioOutputFolder, Path.GetFileNameWithoutExtension(selectedVideo) + ".mp3");

            // Kiểm tra nếu file âm thanh đã tồn tại
            if (File.Exists(outputAudioPath))
            {
                MessageBox.Show($"File âm thanh đã tồn tại tại: {outputAudioPath}\nVui lòng chọn video khác hoặc thay đổi thư mục lưu.");
                return;
            }

            string ffmpeg = ffmpegPath;
            string parameters = $"-i \"{selectedVideo}\" -vn -ar 44100 -ac 2 -ab 192k -f mp3 \"{outputAudioPath}\"";

            FFmpegHelper.RunExe(ffmpeg, parameters);
        }

        // Folder OuputAudio
        private void btnSelectAudioOutputFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Chọn thư mục để lưu file âm thanh";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    audioOutputFolder = folderBrowserDialog.SelectedPath;

                    // Hiển thị đường dẫn trên Label thay vì MessageBox
                    lblAudioOutputPath.Text = $"File audio: {audioOutputFolder}";
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
