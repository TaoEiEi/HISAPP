using System;
using System.Drawing;
using System.Windows.Forms;

namespace DBC01
{
    partial class Form1
    {
        private System.Windows.Forms.TextBox txtApiUrlDesktop;
        private System.Windows.Forms.Button btnSetWallpaperFromApi;
        private NotifyIcon notifyIcon;
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtApiUrlDesktop = new TextBox();
            btnSetWallpaperFromApi = new Button();
            txtDefaultAPI = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            label4 = new Label();
            txtApiUrlComInfo = new TextBox();
            btn_SendComInfo = new Button();
            groupBox1 = new GroupBox();
            btnAuto02 = new Button();
            btnAuto01 = new Button();
            lbLastUpdate02 = new Label();
            lbLastUpdate01 = new Label();
            button3 = new Button();
            btnVersion01 = new Button();
            tbTimeAccess02 = new TextBox();
            tbTimeAccess01 = new TextBox();
            groupBox2 = new GroupBox();
            btnAuto11 = new Button();
            lbLastUpdate11 = new Label();
            button4 = new Button();
            tbTimeAccess11 = new TextBox();
            timer1 = new Timer(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtApiUrlDesktop
            // 
            txtApiUrlDesktop.Location = new Point(121, 26);
            txtApiUrlDesktop.Name = "txtApiUrlDesktop";
            txtApiUrlDesktop.PlaceholderText = "Enter API URL";
            txtApiUrlDesktop.Size = new Size(258, 27);
            txtApiUrlDesktop.TabIndex = 0;
            txtApiUrlDesktop.Text = "Background/GetBackground1";
            // 
            // btnSetWallpaperFromApi
            // 
            btnSetWallpaperFromApi.Location = new Point(385, 26);
            btnSetWallpaperFromApi.Name = "btnSetWallpaperFromApi";
            btnSetWallpaperFromApi.Size = new Size(74, 30);
            btnSetWallpaperFromApi.TabIndex = 1;
            btnSetWallpaperFromApi.Text = "Update";
            btnSetWallpaperFromApi.Click += btnSetWallpaperFromApi_Click;
            // 
            // txtDefaultAPI
            // 
            txtDefaultAPI.Location = new Point(78, 12);
            txtDefaultAPI.Name = "txtDefaultAPI";
            txtDefaultAPI.PlaceholderText = "Enter API URL";
            txtDefaultAPI.Size = new Size(364, 27);
            txtDefaultAPI.TabIndex = 2;
            txtDefaultAPI.Text = "http://161.200.36.225/DentAPI/api/";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 15);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 3;
            label1.Text = "API :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 29);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 4;
            label2.Text = "Desktop :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 79);
            label3.Name = "label3";
            label3.Size = new Size(96, 20);
            label3.TabIndex = 7;
            label3.Text = "screen saver :";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(121, 76);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Enter API URL";
            textBox2.Size = new Size(258, 27);
            textBox2.TabIndex = 5;
            textBox2.Text = "Background/GetBackground";
            // 
            // button1
            // 
            button1.Location = new Point(385, 76);
            button1.Name = "button1";
            button1.Size = new Size(74, 30);
            button1.TabIndex = 6;
            button1.Text = "Update";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 29);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 10;
            label4.Text = "Computer Info :";
            // 
            // txtApiUrlComInfo
            // 
            txtApiUrlComInfo.Location = new Point(121, 26);
            txtApiUrlComInfo.Name = "txtApiUrlComInfo";
            txtApiUrlComInfo.PlaceholderText = "Enter API URL";
            txtApiUrlComInfo.Size = new Size(258, 27);
            txtApiUrlComInfo.TabIndex = 8;
            txtApiUrlComInfo.Text = "Background/SaveComputerInfo";
            // 
            // btn_SendComInfo
            // 
            btn_SendComInfo.Location = new Point(385, 26);
            btn_SendComInfo.Name = "btn_SendComInfo";
            btn_SendComInfo.Size = new Size(74, 30);
            btn_SendComInfo.TabIndex = 9;
            btn_SendComInfo.Text = "Update";
            btn_SendComInfo.Click += btn_SendComInfo_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAuto02);
            groupBox1.Controls.Add(btnAuto01);
            groupBox1.Controls.Add(lbLastUpdate02);
            groupBox1.Controls.Add(lbLastUpdate01);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(btnVersion01);
            groupBox1.Controls.Add(tbTimeAccess02);
            groupBox1.Controls.Add(tbTimeAccess01);
            groupBox1.Controls.Add(txtApiUrlDesktop);
            groupBox1.Controls.Add(btnSetWallpaperFromApi);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Location = new Point(25, 61);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(831, 146);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Get";
            // 
            // btnAuto02
            // 
            btnAuto02.Location = new Point(612, 76);
            btnAuto02.Name = "btnAuto02";
            btnAuto02.Size = new Size(74, 30);
            btnAuto02.TabIndex = 15;
            btnAuto02.Text = "Auto";
            // 
            // btnAuto01
            // 
            btnAuto01.Location = new Point(612, 29);
            btnAuto01.Name = "btnAuto01";
            btnAuto01.Size = new Size(74, 30);
            btnAuto01.TabIndex = 14;
            btnAuto01.Text = "Start";
            btnAuto01.Click += btnAuto01_Click;
            // 
            // lbLastUpdate02
            // 
            lbLastUpdate02.AutoSize = true;
            lbLastUpdate02.Location = new Point(695, 79);
            lbLastUpdate02.Name = "lbLastUpdate02";
            lbLastUpdate02.Size = new Size(50, 20);
            lbLastUpdate02.TabIndex = 13;
            lbLastUpdate02.Text = "label5";
            // 
            // lbLastUpdate01
            // 
            lbLastUpdate01.AutoSize = true;
            lbLastUpdate01.Location = new Point(692, 32);
            lbLastUpdate01.Name = "lbLastUpdate01";
            lbLastUpdate01.Size = new Size(50, 20);
            lbLastUpdate01.TabIndex = 12;
            lbLastUpdate01.Text = "label5";
            // 
            // button3
            // 
            button3.Location = new Point(532, 74);
            button3.Name = "button3";
            button3.Size = new Size(74, 30);
            button3.TabIndex = 11;
            button3.Text = "Set";
            // 
            // btnVersion01
            // 
            btnVersion01.Location = new Point(532, 29);
            btnVersion01.Name = "btnVersion01";
            btnVersion01.Size = new Size(74, 30);
            btnVersion01.TabIndex = 10;
            btnVersion01.Text = "0";
            btnVersion01.Click += button2_Click;
            // 
            // tbTimeAccess02
            // 
            tbTimeAccess02.Location = new Point(465, 76);
            tbTimeAccess02.Name = "tbTimeAccess02";
            tbTimeAccess02.Size = new Size(61, 27);
            tbTimeAccess02.TabIndex = 9;
            tbTimeAccess02.Text = "60000";
            // 
            // tbTimeAccess01
            // 
            tbTimeAccess01.Location = new Point(465, 29);
            tbTimeAccess01.Name = "tbTimeAccess01";
            tbTimeAccess01.Size = new Size(61, 27);
            tbTimeAccess01.TabIndex = 8;
            tbTimeAccess01.Text = "60000";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAuto11);
            groupBox2.Controls.Add(lbLastUpdate11);
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(tbTimeAccess11);
            groupBox2.Controls.Add(txtApiUrlComInfo);
            groupBox2.Controls.Add(btn_SendComInfo);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(25, 213);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(831, 116);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Send";
            // 
            // btnAuto11
            // 
            btnAuto11.Location = new Point(612, 29);
            btnAuto11.Name = "btnAuto11";
            btnAuto11.Size = new Size(74, 30);
            btnAuto11.TabIndex = 16;
            btnAuto11.Text = "Auto";
            // 
            // lbLastUpdate11
            // 
            lbLastUpdate11.AutoSize = true;
            lbLastUpdate11.Location = new Point(695, 39);
            lbLastUpdate11.Name = "lbLastUpdate11";
            lbLastUpdate11.Size = new Size(50, 20);
            lbLastUpdate11.TabIndex = 13;
            lbLastUpdate11.Text = "label5";
            // 
            // button4
            // 
            button4.Location = new Point(532, 29);
            button4.Name = "button4";
            button4.Size = new Size(74, 30);
            button4.TabIndex = 11;
            button4.Text = "Set";
            // 
            // tbTimeAccess11
            // 
            tbTimeAccess11.Location = new Point(465, 29);
            tbTimeAccess11.Name = "tbTimeAccess11";
            tbTimeAccess11.Size = new Size(61, 27);
            tbTimeAccess11.TabIndex = 10;
            tbTimeAccess11.Text = "60000";
            // 
            // timer1
            // 
            timer1.Interval = 60000;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            ClientSize = new Size(868, 341);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(txtDefaultAPI);
            Name = "Form1";
            Text = "DBC01 - Desktop Background Updater";
            Resize += Form1_Resize;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void InitializeTrayIcon()
        {
            // สร้าง NotifyIcon
            notifyIcon = new NotifyIcon
            {
               // Icon = new Icon(@"resource\image\tooth_icon_resized_32x32.png"), // เพิ่มไอคอนของคุณที่นี่
                Icon = SystemIcons.Application, // ใช้ไอคอนเริ่มต้นของระบบ หรือเปลี่ยนเป็นไอคอนของคุณ
                Visible = true,
                Text = "Background App"
            };
            // เพิ่ม Context Menu
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Open", null, OpenApp); // เมนูสำหรับเปิดหน้าต่าง
            contextMenu.Items.Add("Exit", null, ExitApp); // เมนูสำหรับออกจากโปรแกรม

            notifyIcon.ContextMenuStrip = contextMenu;

            // ดับเบิ้ลคลิกที่ไอคอนเพื่อเปิดหน้าต่าง
            notifyIcon.DoubleClick += OpenApp;
             
        }
        private void OpenApp(object sender, EventArgs e)
        {
            //Form2 form2 = new Form2(); // Create an instance of Form2
            //form2.Show(); // Show Form2
            //this.Show(); // แสดงหน้าต่าง 
            //this.WindowState = FormWindowState.Normal; // คืนค่าหน้าต่างปกติ
            //this.BringToFront(); // นำหน้าต่างมาด้านหน้า
        }

        private void ExitApp(object sender, EventArgs e)
        {
            notifyIcon.Visible = false; // ซ่อน NotifyIcon
            Application.Exit(); // ปิดโปรแกรม
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // ซ่อนโปรแกรมแทนการปิด เมื่อผู้ใช้คลิกปิดหน้าต่าง
            e.Cancel = true;
            this.Hide();
        }




        private System.Windows.Forms.TextBox txtDefaultAPI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApiUrlComInfo;
        private System.Windows.Forms.Button btn_SendComInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbTimeAccess02;
        private System.Windows.Forms.TextBox tbTimeAccess01;
        private System.Windows.Forms.TextBox tbTimeAccess11;
        private System.Windows.Forms.Label lbLastUpdate02;
        private System.Windows.Forms.Label lbLastUpdate01;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnVersion01;
        private System.Windows.Forms.Label lbLastUpdate11;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnAuto01;
        private System.Windows.Forms.Button btnAuto02;
        private System.Windows.Forms.Button btnAuto11;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;
    }
}