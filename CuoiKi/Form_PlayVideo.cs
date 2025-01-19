using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKi
{
    public partial class Form_PlayVideo : Form
    {
        private string ffmpegPath = @"C:\ffmpeg\bin\ffmpeg.exe";
        private string ffplayPath = @"C:\ffmpeg\bin\ffplay.exe";
        public Form_PlayVideo()
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

        // Play video
        private void btnPlayVideo_Click(object sender, EventArgs e)
        {
            // Cách 1
            //if (lstVideos.SelectedItem == null)
            //{
            //    MessageBox.Show("Vui lòng chọn một video từ danh sách!");
            //    return;
            //}

            //string selectedVideo = lstVideos.SelectedItem.ToString();
            //axWindowsMediaPlayer1.URL = selectedVideo;
            //axWindowsMediaPlayer1.Ctlcontrols.play();

            // Cách 2
            if (lstVideos.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một video từ danh sách!");
                return;
            }

            string selectedVideo = lstVideos.SelectedItem.ToString();

            // Kiểm tra nếu file video tồn tại
            if (!File.Exists(selectedVideo))
            {
                MessageBox.Show("File video không tồn tại. Vui lòng kiểm tra lại!");
                return;
            }

            string ffplay = ffplayPath;
            string parameters = $"-autoexit \"{selectedVideo}\"";
            FFmpegHelper.RunExe("ffmpeg", parameters);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
