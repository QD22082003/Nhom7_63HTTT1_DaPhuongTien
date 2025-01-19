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
    public partial class Dao_Mute : Form
    {
        public Dao_Mute()
        {
            InitializeComponent();
        }
        string videoFileName = "";
        string resultPath = "";
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "File video|*.mp4;*.aiv; |All File| *.*;";
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
            string ffmpeg = @"D:\Hoc\Ki7\DaPhuongTien\ffmpeg-2024-12-16-git-d2096679d5-essentials_build\bin\ffmpeg.exe";
            string output = resultPath + @"\mute_videoa7.mp4";
            string para = $"-i {videoFileName} -an {output}";
            FFmpegHelper.RunExe("ffmpeg", para);
        }
    }
}
