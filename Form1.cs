using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;// สำหรับ Newtonsoft.Json
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DBC01
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDCHANGE = 0x02;

        private HttpClient _httpClient;
        private string _currentBaseUrl = "";
        // private string _currentBaseUrl = "http://161.200.36.225/DentAPI/api/";


        public Form1()
        {
            InitializeComponent();
            InitializeTrayIcon();

            // สร้าง HttpClient ครั้งเดียวในฟอร์ม
            // _httpClient = new HttpClient { BaseAddress = new Uri(_currentBaseUrl) };
            _currentBaseUrl = txtDefaultAPI.Text;
            GetImageAction();
            btnAuto01_Click(this, EventArgs.Empty);
            this.WindowState = FormWindowState.Minimized;
            notifyIcon.Visible = true;
        }
        //http://161.200.36.225/DentAPI/api/
        private void btnSetWallpaperFromApi_Click(object sender, EventArgs e)
        {
            GetImageAction();
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

        private void SetDesktopWallpaper(string imagePath)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imagePath, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }

        static async Task SendComInfo(string apiUrl, string jsonData)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        //Console.WriteLine("Data sent successfully: " + response.StatusCode);
                        MessageBox.Show("Data sent successfully: " + response.StatusCode, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Console.WriteLine("Failed to send data. Status code: " + response.StatusCode);
                        MessageBox.Show("Failed to send data. Status code: " + response.StatusCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update wallpaper: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //เหลือ ปริมาณ HDD มีกี่ลูก ยีห้อ รุ่น ความจุ
        //แต่ละลูกมีกี่ Drive
        //แต่ละ Drive มีปริมาณ พื้นที่ /เหลือ
        private async void btn_SendComInfo_Click(object sender, EventArgs e)
        {
            var computerInfoGet = new ComputerInfo();
            //Computer Status Information
            // ชื่อเครื่องคอมพิวเตอร์v
            string computerName = Environment.MachineName;

            // ชื่อผู้ใช้งานปัจจุบัน
            string userName = Environment.UserName;

            // สถานะระบบปฏิบัติการ
            string osVersion = Environment.OSVersion.ToString();

            // ที่อยู่ IP
            string ipAddress = GetLocalIPAddress();

            // MAC Address
            var macAddress = GetMacAddress();

            // จำนวน Core ของ CPU
            int processorCount = Environment.ProcessorCount;

            // Memory ที่ใช้งานได้
            decimal workingSet = Environment.WorkingSet;

            // Total Physical Memory (RAM ทั้งหมด) ในหน่วย Byte
            ulong totalPhysicalMemory = computerInfoGet.TotalPhysicalMemory;
            double totalMemoryInGB = totalPhysicalMemory / (1024.0 * 1024.0 * 1024.0);

            //SystemInfo sscd = new SystemInfo
            //{
            //    ComputerName = computerName,
            //    UserName = userName,
            //    OsVersion = osVersion,
            //    ProcessorCount = processorCount,
            //    MemoryUsage = workingSet / (1024 * 1024) + " MB",
            //    IpAddress = ipAddress,
            //    MacAddress = macAddress,
            //    TotalMemoryInGb = totalMemoryInGB.ToString()
            //};

            ////Send computer info 
            //// แปลงข้อมูลเป็น JSON
            //string jsonData = JsonConvert.SerializeObject(sscd);

            //// URL ของ API ที่ต้องการส่งข้อมูลไป
            //string apiUrl = "https:/localhost:7030/api/" + txtApiUrlComInfo.Text; // เปลี่ยนเป็น URL ของคุณ
            ////  string apiUrl = "http://161.200.36.225/DentAPI/api/" +  txtApiUrlComInfo.Text.Trim();

            //// ส่งข้อมูลไปยัง API
            //await SendComInfo(apiUrl, jsonData);

            //Console.WriteLine("Data sent to API successfully.");
            //Console.ReadLine();
            ////show message 


            // URL ของ API
            //string url = "https://localhost:7030/api/Background/SaveComputerInfo";
            string url = txtDefaultAPI.Text + txtApiUrlComInfo.Text;

            // สร้างข้อมูลที่ต้องการส่งในรูปแบบ JSON
            var data = new
            {
                //dentAnnComputerInfoId = 8,
                //computerName = computerName,
                //userName = userName,
                //ipaddress = ipAddress,
                //osVersion = osVersion,
                //processorCount = processorCount,
                //memoryUsage = workingSet / (1024 * 1024) + " MB",
                //macAddress = macAddress


                dentAnnComputerInfoId = 8,
                computerName = computerName,
                userName = userName,
                ipaddress = ipAddress,
                osVersion = osVersion,
                processorCount = processorCount,
                memoryUsage = workingSet / (1024 * 1024) + " MB",
                macAddress = macAddress
            };

            // แปลงข้อมูลเป็น JSON
            string jsonData = JsonConvert.SerializeObject(data);

            using (var client = new HttpClient())
            {
                // ตั้งค่า Content-Type เป็น application/json
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                try
                {
                    // ส่ง HTTP POST Request
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // ตรวจสอบสถานะการตอบกลับ
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("API call successful!");
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response: " + responseBody);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Error Details: " + errorResponse);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occurred: " + ex.Message);
                }
            }

        }
        //public int GetNextIdComInfo()
        //{
        //    // หา ID ที่มากที่สุด หรือคืนค่า 0 หากไม่มี record
        //    var maxId = _context.DentAnnScreenAndImages.Any()
        //        ? _context.DentAnnScreenAndImages.Max(x => x.Id)
        //        : 0;

        //    // เริ่มต้นที่ 1 หากไม่มี record
        //    var nextId = maxId + 1;

        //    return nextId;
        //}

        static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "No IPv4 Address Found";
        }

        static string GetMacAddress()
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(nic => nic.OperationalStatus == OperationalStatus.Up &&
                                       nic.NetworkInterfaceType != NetworkInterfaceType.Loopback);
            if (networkInterfaces != null)
            {
                var address = networkInterfaces.GetPhysicalAddress();
                return string.Join(":", address.GetAddressBytes().Select(b => b.ToString("X2")));
            }
            return "No MAC Address Found";
        }
        public class SystemInfo
        {
            public string ComputerName { get; set; }
            public string UserName { get; set; }
            public string OsVersion { get; set; }
            public int ProcessorCount { get; set; }
            public string MemoryUsage { get; set; }
            public string IpAddress { get; set; }
            public string MacAddress { get; set; }
            public string TotalMemoryInGb { get; set; }
        }

        private void btnAuto01_Click(object sender, EventArgs e)
        {
            string st = tbTimeAccess01.Text;
            string statusStr = btnAuto01.Text;
            if (statusStr == "Start")
            {
                timer1.Start();
                btnAuto01.Text = "Stop";
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("หยุดการทำงานซ้ำ");
                btnAuto01.Text = "Start";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetImageAction();
        }

        private async void GetImageAction()
        {
            try
            {
                string apiUrl = _currentBaseUrl + txtApiUrlDesktop.Text.Trim();
                if (string.IsNullOrEmpty(apiUrl))
                {
                    MessageBox.Show("Please enter the API URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Check version 
                string apiUrl2 = _currentBaseUrl + "Background/check-version";
                // ตั้งค่า Base URL ของ API 
                VersionResponse statusStr = await CheckSingleVersion(btnVersion01.Text, apiUrl2);
                btnVersion01.Text = statusStr.Version.ToString();
                if (statusStr.Status == "outdated")
                {
                    // Download image from API
                    var imagePath = await DownloadImageFromApi(apiUrl);
                    // Set as desktop wallpaper
                    SetDesktopWallpaper(imagePath);
                    lbLastUpdate01.Text = DateTime.Now.ToString("F");
                    btnVersion01.Text = statusStr.LatestVersion;
                    this.Hide();
                    //  MessageBox.Show("Wallpaper has been updated from the API!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //  MessageBox.Show("This current version", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Failed to update wallpaper: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(tbTimeAccess01.Text);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //base.OnResize(e);

            // เมื่อย่อหน้าต่าง ซ่อนโปรแกรม
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
                //NotifyIcon df = new NotifyIcon
                //{
                //    Visible = true,
                //    Icon = SystemIcons.Application
                //};
            }

            ////notifyIcon.Icon = SystemIcons.Application;   // ใช้ไอคอนเริ่มต้นของระบบ หรือเปลี่ยนเป็นไอคอนของคุณ
            ////notifyIcon.Visible = true;
            ////notifyIcon.Text = "Background App";

            //NotifyIcon df = new NotifyIcon
            //{
            //    Visible = true,
            //    Icon  = SystemIcons.Application
            //};

        }


    }
    public class VersionResponse
    {
        public string Version { get; set; }
        public string Status { get; set; }
        public string LatestVersion { get; set; }
    }
}