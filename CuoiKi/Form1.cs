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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ******************************************************************
        // 1. Play video
        private void button2_Click(object sender, EventArgs e)
        {
            Form_PlayVideo form_PlayVideo = new Form_PlayVideo();
            form_PlayVideo.ShowDialog();
        }
        
        // 2. Extract audio from video: Tách âm thanh từ video
        private void btnExtractAudioMp3_Click(object sender, EventArgs e)
        {
            Form_ExtractAudio form_ExtractAudio = new Form_ExtractAudio();
            form_ExtractAudio.ShowDialog();
        }

        // 3. Add img to audio: thêm img vào sound vừa tách
        private void btnAddImageToAudio_Click(object sender, EventArgs e)
        {
            Form_AddImageToAudio form_AddImageToAudio = new Form_AddImageToAudio();
            form_AddImageToAudio.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form_SpeedVideo form_SpeedVideo = new Form_SpeedVideo();
            form_SpeedVideo.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form_FormatConverter form_FormatConverter = new Form_FormatConverter();
            form_FormatConverter.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form_SplitVideo form_SplitVideo = new Form_SplitVideo();
            form_SplitVideo.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form_ConcatenateVideo form_ConcatenateVideo = new Form_ConcatenateVideo();
            form_ConcatenateVideo.ShowDialog();
        }
        // ******************************************************************


    }
}
