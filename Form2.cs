using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBC01
{
    public partial class Form2 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDCHANGE = 0x02;

        private const string masterApiUrl = "";
        private const string api = "";
        public Form2()
        {
            CreateBaseFolder();
            InitializeComponent();
            InitializeWebView();
            MoveFormToRight();
            GetImageAction();
            StartAuto();
        }

        private void CreateBaseFolder()
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyApp");

            // ตรวจสอบและสร้างโฟลเดอร์หากยังไม่มี
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }


        private async void InitializeWebView()
        {
            await webView21.EnsureCoreWebView2Async();
            string html = "<html><body><h1>แสดง HTML</h1><p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "<p>นี่คือตัวอย่างการใช้ WebView2</p></br>" +
                          "</body></html>";
            webView21.NavigateToString(html);
        }

        private void StartAuto()
        {
            string statusStr = label3.Text;
            if (statusStr == "Start")
            {
                timer1.Start();
                // MessageBox.Show("เริ่มการทำงานซ้ำทุก 1 นาที");
                label3.Text = "Stop";
            }
            else
            {
                timer1.Stop();
                // MessageBox.Show("หยุดการทำงานซ้ำ");
                label3.Text = "Start";
            }
        }

        private void MoveFormToRight()
        {
            // ดึงขนาดของหน้าจอปัจจุบัน
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;

            // คำนวณตำแหน่งให้ Form อยู่มุมขวา
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(screen.Width - this.Width, 0);
            // คำนวณตำแหน่งให้ Form อยู่มุมขวาล่าง
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(screen.Width - this.Width, screen.Height - this.Height);
        }
        private async void GetImageAction()
        {
            try
            {
                string apiUrl = "http://161.200.36.225/DentAPI/api/Background/GetBackground1";
                if (string.IsNullOrEmpty(apiUrl))
                {
                    MessageBox.Show("Please enter the API URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Check version 
                string apiUrl2 = "http://161.200.36.225/DentAPI/api/" + "Background/check-version";
                // ตั้งค่า Base URL ของ API 
                VersionResponse statusStr = await CheckSingleVersion(label1.Text, apiUrl2);
                //btnVersion01.Text = statusStr.Version.ToString();
                if (statusStr.Status == "outdated")
                {
                    // Download image from API
                    var imagePath = await DownloadImageFromApi(apiUrl);
                    // Set as desktop wallpaper
                    SetDesktopWallpaper(imagePath);
                    label2.Text = DateTime.Now.ToString("F");
                    label1.Text = statusStr.LatestVersion;
                    pictureBox1.Image = Image.FromFile(imagePath);
                    webView21.NavigateToString("html");
                }
                else
                {
                     
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Failed to update wallpaper: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<string> DownloadImageFromApi(string apiUrl)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                // Save downloaded image to temporary path
                var tempPath = Path.Combine(Path.GetTempPath(), "background.jpg");
                await using var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None);
                await response.Content.CopyToAsync(fs);
                return tempPath;
            }
            return null;
        }
        private void SetDesktopWallpaper(string imagePath)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imagePath, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }
        private static async Task<VersionResponse> CheckSingleVersion(string version, string apiUrl)
        {
            using (var client = new HttpClient())
            {
                var requestBody = new { version = version };
                string jsonData = JsonConvert.SerializeObject(requestBody);
                // ตั้งค่า Content-Type เป็น application/json
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                try
                {
                    // ส่ง HTTP POST Request
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    // ตรวจสอบสถานะการตอบกลับ
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        // แปลง JSON เป็น C# Object
                        var result = JsonConvert.DeserializeObject<VersionResponse>(responseContent);
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetImageAction();
        }
    }
}