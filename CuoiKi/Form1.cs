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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            Ha_FormInfoVideo extractAudioForm = new Ha_FormInfoVideo();
            extractAudioForm.Show();
        }

        private void btnListAnh_Click(object sender, EventArgs e)
        {
            Ha_FormExtractFrames extractAudioForm = new Ha_FormExtractFrames();
            extractAudioForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ha_FormMergeImagestoVideo extractAudioForm = new Ha_FormMergeImagestoVideo();
            extractAudioForm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Ha_TrichXuatAmThanhVideo extractAudioForm = new Ha_TrichXuatAmThanhVideo();
            extractAudioForm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
        }
    }
}
