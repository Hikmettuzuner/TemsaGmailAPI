using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Tulpep.NotificationWindow;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    //public partial class : form yapısı ekledim

    public partial class Program : Form
    {

        public int ReservedValue;
        public int Description;
        private ContextMenuStrip contextMenuStrip1;
        private IContainer components;
        private ToolStripMenuItem hatırlatToolStripMenuItem;
        private ToolStripMenuItem çıkışToolStripMenuItem;
        private NotifyIcon notifyIcon1;
        private Label label1;
        private Button btnBaslattt;
        private System.Windows.Forms.Timer timer1;
        private Label label2;
        public int Desc;
        public int sayi;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label3;
        private Label label4;
        private System.Windows.Forms.Timer timer2;
        private PictureBox pictureBox1;
        private Button button2;
        public int dakika;

        public int hour;
        public int minu;


        [DllImport("wininet.dll")]
        public extern static bool InternetGetConnectedState(out int Description, int ReservedValue);


        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/calendar-dotnet-quickstart.json
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
        private Button button1;
        public static List<TakvimValue> dtDegerler = new List<TakvimValue>();







        public Program()
        {
            InitializeComponent();
        }



        static void Main(string[] args)
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Program());
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Program));
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hatırlatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnBaslattt = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hatırlatToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // hatırlatToolStripMenuItem
            // 
            this.hatırlatToolStripMenuItem.Name = "hatırlatToolStripMenuItem";
            this.hatırlatToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.hatırlatToolStripMenuItem.Text = "Hatırlat !";
            this.hatırlatToolStripMenuItem.Click += new System.EventHandler(this.hatırlatToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Settings";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "0";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnBaslattt
            // 
            this.btnBaslattt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnBaslattt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaslattt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBaslattt.Location = new System.Drawing.Point(332, 77);
            this.btnBaslattt.Name = "btnBaslattt";
            this.btnBaslattt.Size = new System.Drawing.Size(141, 48);
            this.btnBaslattt.TabIndex = 2;
            this.btnBaslattt.Text = "Hatırlat";
            this.btnBaslattt.UseVisualStyleBackColor = false;
            this.btnBaslattt.Click += new System.EventHandler(this.btnBaslattt_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "0";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(332, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(49, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(424, 40);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(49, 21);
            this.comboBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(329, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Saat ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(421, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dakika ";
            // 
            // timer2
            // 
            this.timer2.Interval = 400;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(332, 141);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 47);
            this.button2.TabIndex = 9;
            this.button2.Text = "Vazgeç";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Program
            // 
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(494, 237);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBaslattt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Program";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Etkinlik Hatırlatıcı";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Program_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Function();
            //List<TakvimValue> tablo = dtDegerler;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }


        public void Function()
        {
            UserCredential credential;
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("BUGÜN YAPILMASI GEREKENLER  " + credPath);
            }
            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.TimeMax = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString());
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            dtDegerler = new List<TakvimValue>();
            Events events = request.Execute();

            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.Value.ToString("HH:mm");
                    if (String.IsNullOrEmpty(when) && request.TimeMin <= Convert.ToDateTime(when))
                    {
                        when = Convert.ToDateTime(eventItem.Start).ToString("HH:mm");
                    }
                    TakvimValue degerlerRow = new TakvimValue();
                    degerlerRow.events = eventItem.Summary;
                    degerlerRow.when = when;
                    dtDegerler.Add(degerlerRow);
                }

                PopupNotifier popupG = new PopupNotifier();
                popupG.Image = Properties.Resources.a;
                popupG.AnimationDuration = 1000;
                popupG.AnimationInterval = 1;
                popupG.BodyColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popupG.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popupG.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
                popupG.ContentFont = new System.Drawing.Font("Tahoma", 13F);
                popupG.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
                popupG.ContentPadding = new Padding(0);
                popupG.Delay = 95000000;
                int height = 100;
                if (dtDegerler.Count > 3)
                    height = 30 * dtDegerler.Count;
                popupG.Size = new System.Drawing.Size(400, height);
                popupG.GradientPower = 100;
                popupG.HeaderHeight = 3;
                popupG.Scroll = true;
                popupG.ShowCloseButton = true;
                popupG.ShowGrip = true;

                popupG.OptionsMenu = new ContextMenuStrip();
                popupG.TitleText = "ETKİNLİK ADI / SAATİ";
                //popup.ContentText = dtDegerler[dtDegerler.Count - 1 - i].events;
                string context = "";
                for (int i = 0; i < dtDegerler.Count; i++)
                {
                    context += dtDegerler[i].events + " / " + dtDegerler[i].when;
                    //Alt satırı Geçer
                    if (i != dtDegerler.Count - 1)
                        context += @"
";
                }
                popupG.ContentText = context;
                popupG.Popup();
            }
            else
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.a;
                popup.AnimationDuration = 1000;
                popup.AnimationInterval = 1;
                popup.BodyColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
                popup.ContentFont = new System.Drawing.Font("Tahoma", 13F);
                popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
                popup.ContentPadding = new Padding(0);
                popup.Delay = 95000000;
                popup.GradientPower = 100;
                popup.HeaderHeight = 3;
                popup.Scroll = true;
                popup.ShowCloseButton = true;
                popup.ShowGrip = true;
                popup.OptionsMenu = new ContextMenuStrip();

                popup.ContentText = "Bugün Etkinliğiniz Bulunmamaktadır !" + @"
İyi Çalışmalar | TEMSA |";
                popup.Popup();

            }
        }

        public void EthernetFunc()
        {
            int Desc;
            MessageBox.Show(InternetGetConnectedState(out Desc, 0).ToString());
        }

        public void Hatirlat()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.okk;
            popup.AnimationDuration = 1000;
            popup.AnimationInterval = 1;
            popup.BodyColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 13F);
            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Delay = 2000;
            popup.GradientPower = 100;
            popup.HeaderHeight = 3;
            popup.Scroll = true;
            popup.ShowCloseButton = true;
            popup.ShowGrip = true;
            popup.OptionsMenu = new ContextMenuStrip();

            popup.ContentText = "Etkinlik Hatırlatma Saati Ayarlandı !" + @"
İyi Çalışmalar | TEMSA |";
            popup.Popup();
        }


        private void Program_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 24; i++)
            {
                comboBox1.Items.Add(i);
            }
            for (int k = 0; k < 60; k = k + 5)
            {
                comboBox2.Items.Add(k);

            }

            if (InternetGetConnectedState(out Desc, 0))
            {
              
                Function();
                this.Hide();
            }
            else
            {
                TimeOlay();
                this.Hide();
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.c;
                popup.AnimationDuration = 1000;
                popup.AnimationInterval = 1;
                popup.BodyColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
                popup.ContentFont = new System.Drawing.Font("Tahoma", 13F);
                popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
                popup.ContentPadding = new Padding(0);
                popup.Delay = 1700;
                popup.GradientPower = 100;
                popup.HeaderHeight = 3;
                popup.Scroll = true;
                popup.ShowCloseButton = true;
                popup.ShowGrip = true;
                popup.OptionsMenu = new ContextMenuStrip();
                popup.ContentText = "İNTERNET Bağlantınız Yok !" + @"
İyi Çalışmalar | TEMSA |";
                popup.Popup();
            }
        }


        private void hatırlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0))
            {
                this.Show();
            }
            else
            {
                basarisiz();
            }
            
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0))
            {              
                Function();
            }
            else
            {
                this.Hide();
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.c;
                popup.AnimationDuration = 1000;
                popup.AnimationInterval = 1;
                popup.BodyColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
                popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
                popup.ContentFont = new System.Drawing.Font("Tahoma", 13F);
                popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
                popup.ContentPadding = new Padding(0);
                popup.Delay = 1700;
                popup.GradientPower = 100;
                popup.HeaderHeight = 3;
                popup.Scroll = true;
                popup.ShowCloseButton = true;
                popup.ShowGrip = true;
                popup.OptionsMenu = new ContextMenuStrip();

                popup.ContentText = "İNTERNET Bağlantınız Yok !" + @"
İyi Çalışmalar | TEMSA |";
                popup.Popup();
            }
        }

        private void btnBaslattt_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null && comboBox2.SelectedValue == null)
            {
                if (comboBox1.SelectedIndex >= DateTime.Now.Hour)
                {
                    if(comboBox1.SelectedIndex == DateTime.Now.Hour && Convert.ToInt32(comboBox2.SelectedItem.ToString()) > DateTime.Now.Minute)
                    {
                        hour = comboBox1.SelectedIndex;
                        minu = Convert.ToInt32(comboBox2.SelectedItem.ToString());
                        timer2.Enabled = true;
                        Hatirlat();
                        this.Hide();
                    }
                    else
                    {
                        timer2.Enabled = false;
                        MessageBox.Show("Lütfen Dakika Diliminizi Kontrol Ediniz !");
                    }
                }
                else
                {
                    timer2.Enabled = false;
                    MessageBox.Show("Lütfen Saat Diliminizi Kontrol Ediniz !");
                }
            }
            else
            {
                timer2.Enabled = false;
                MessageBox.Show("Lütfen Saat Ve Dakika Seçiniz");
            }
        }

        public void TimeOlay()
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0))
            {
                timer1.Enabled = false;
                Function();
            }
            if(!InternetGetConnectedState(out Desc, 0))
            {
                timer1.Enabled = true;
                basarisiz();
            }
        }

        public void basarisiz()
        {
            this.Hide();
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.c;
            popup.AnimationDuration = 1000;
            popup.AnimationInterval = 1;
            popup.BodyColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentFont = new System.Drawing.Font("Tahoma", 13F);
            popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popup.ContentPadding = new Padding(0);
            popup.Delay = 1700;
            popup.GradientPower = 100;
            popup.HeaderHeight = 3;
            popup.Scroll = true;
            popup.ShowCloseButton = true;
            popup.ShowGrip = true;
            popup.OptionsMenu = new ContextMenuStrip();

            popup.ContentText = "İNTERNET Bağlantınız Yok !" + @"
İyi Çalışmalar | TEMSA |";
            popup.Popup();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Hour.ToString();
            label2.Text = DateTime.Now.Minute.ToString();
   
            if (DateTime.Now.Hour == hour && DateTime.Now.Minute == minu)
            {
                timer2.Enabled = false;
                btnBaslattt.Enabled = true;
                Function();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
  }
//foreach (TakvimValue Item in dtDegerler.OrderByDescending(p=>p.when))
//{
//    PopupNotifier popup = new PopupNotifier();
//    popup.Image = Properties.Resources.a;
//    popup.AnimationDuration = 1000;
//    popup.AnimationInterval = 1;
//    popup.BodyColor = System.Drawing.Color.FromArgb(0, 0, 0);
//    popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
//    popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
//    popup.ContentFont = new System.Drawing.Font("Tahoma", 13F);
//    popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
//    popup.ContentPadding = new Padding(0);
//    popup.Delay = 95000000;
//    popup.GradientPower = 100;
//    popup.HeaderHeight = 3;
//    popup.Scroll = true;
//    popup.ShowCloseButton = true;
//    popup.ShowGrip = true;
//    popup.OptionsMenu = new ContextMenuStrip();

//    popup.TitleText = "ETKİNLİK SAATİ" + " " + " " + "=" + Item.when;
//    popup.ContentText = Item.events;
//    popup.Popup();
//}