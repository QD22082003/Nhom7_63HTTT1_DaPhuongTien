using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKi
{
    internal class FFmpegHelper
    {
        //
        public static void RunExe(string fileExe, string parameters)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = fileExe,
                    Arguments = parameters,
                    CreateNoWindow = true, // Không hiển thị cửa sổ console
                    UseShellExecute = false, // Không dùng shell mặc định
                    WindowStyle = ProcessWindowStyle.Hidden, // Ẩn cửa sổ
                    RedirectStandardError = true // Đọc lỗi từ ffmpeg
                };

                using (Process process = Process.Start(processStartInfo))
                {
                    string errorOutput = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    // Kiểm tra mã thoát của quá trình
                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show("Thực hiện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"FFmpeg đã gặp lỗi. Mã lỗi: {process.ExitCode}\nChi tiết: {errorOutput}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //
    }
}
