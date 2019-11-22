using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace Weather_Currency_Fuel {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            string pathImage = Environment.CurrentDirectory;

            this.btnLeft.Text = "";
            this.btnRight.Text = "";
            panel2.Width = 0;
            panel3.Location = new Point(0, -52);
            label10.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label17.Text = "";
            label18.Text = "";
            label22.Text = "";

            picWeather.Image = Image.FromFile(pathImage + @"\img\weather.jpg");
            btnLeft.Image = Image.FromFile(pathImage + @"\img\left.png");
            btnRight.Image = Image.FromFile(pathImage + @"\img\right.png");
            btnMenu.Image = Image.FromFile(pathImage + @"\img\Hamb.png");

            try {

                StreamReader strReaderTown = new StreamReader(pathImage + @"\town.txt");
                textBox1.Text = Convert.ToString(strReaderTown.ReadToEnd());
                strReaderTown.Close();

                string DateNow = DateTime.Now.ToString("yyyy-MM-dd");

                WebRequest request;
                request = WebRequest.Create(@"https://sinoptik.ua/погода-" + textBox1.Text + "/" + DateNow);
                using (var responce = request.GetResponse()) {

                    using (var stream = responce.GetResponseStream())
                    using (var reader = new StreamReader(stream)) {

                        string data = reader.ReadToEnd();
                        string dt = DateTime.Now.Year.ToString("0000") + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00");
                        string kv = "\"";
                        string linkURL =  kv + "//sinoptik.ua/погода-" + textBox1.Text + "/" + dt + kv;

                        string cls_day_link = @"<p class=""day-link"" data-link=" + linkURL + @">(?<DayWeek>[^<]+)</p>";

                        string day_week = new Regex(cls_day_link).Match(data).Groups["DayWeek"].Value;
                        string day = new Regex(@"<p class=""date "">(?<Day1>[^<]+)</p>").Match(data).Groups["Day1"].Value;
                        string month = new Regex(@"<p class=""month"">(?<month1>[^<]+)</p>").Match(data).Groups["month1"].Value;
                        string title = new Regex(@"<div class=""weatherIco d431"" title=(?<tit1>[^<]+)>").Match(data).Groups["tit1"].Value;
                        string min_temperature = new Regex(@"<div class=""min"">мин. [^<]*?<span>(?<tmpMin1>[^<]+)</span>[^<]*?</div>").Match(data).Groups["tmpMin1"].Value;
                        string max_temperature = new Regex(@"<div class=""max"">макс. [^<]*?<span>(?<tmpMax1>[^<]+)</span>[^<]*?</div>").Match(data).Groups["tmpMax1"].Value;
                        string current_temperature = new Regex(@"<p class=""today-temp"">(?<tempNow>[^<]+)</p>").Match(data).Groups["tempNow"].Value;
                        string description = new Regex(@"<div class=""description"">[^<]*?<!--noindex-->[^<]*?(?<desc>[^<]+)[^<]*?<!--/noindex-->[^<]*?</div>").Match(data).Groups["desc"].Value;

                        string lbl_temperature_1 = new Regex(@"<td class=""p1  "">(?<tmp1>[^<]+)</td>").Match(data).Groups["tmp1"].Value;

                        WebClient client = new WebClient();
                        var bytes = client.DownloadData("https://sinst.fwdcdn.com/img/weatherImg/m/d400.gif");
                        var str = new MemoryStream(bytes);
                        picSmallWeather.Image = Image.FromStream(str);

                        //string img1 = new Regex(@"<div class=""weatherIco d431"" title=(?<title1>[^<]+)>[^<]*?<img class=""weatherImg"" src=(?<linkPicture>[^<]+) alt="""">[^<]*?</div>").Match(data).Groups["linkPicture"].Value;
                        //string img1 = new Regex(@"<div class=""weatherIco d431"" title=(?<title1>[^<]+)>[^<]*?<img class=""weatherImg"" src=(?<linkPicture>[^<]+) alt="""">[^<]*?</div>").Match(data).Groups["linkPicture"].Value;
                        WebClient client1 = new WebClient();
                        //var bytes1 = client1.DownloadData("https:" + img1);
                        //MessageBox.Show(img1);









                        label12.Text = day_week;
                        label13.Text = day;
                        label14.Text = month;
                        label17.Text = min_temperature;
                        label17.Text = label17.Text.Substring(0, label17.Text.Length - 4);
                        label17.Text += "°C";
                        label22.Text = description;

                        label18.Text = max_temperature;
                        label18.Text = label18.Text.Substring(0, label18.Text.Length - 4);
                        label18.Text += "°C";
                        lblTemperature.Text = current_temperature;
                        lblTemperature.Text = lblTemperature.Text.Substring(0, lblTemperature.Text.Length - 6);
                        lblTemperature.Text += "°C";

                        label27.Text = lbl_temperature_1;                        

                    }
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            if (panel2.Width == 249) {
                for (int i = 250; i > 0; i--) {
                    panel2.Width = i;
                }
            }
            else {
                for (int i = 0; i < 250; i++) {
                    panel2.Width = i;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) {

            string town = Environment.CurrentDirectory;

            try {
                File.Delete(town + @"\town.txt");
                File.AppendAllText(town + @"\town.txt", textBox1.Text);
                for (int i = -52; i < 1; i++) {
                    panel3.Location = new Point(0, i);
                }

                label10.Text = "Данные сохранены. Перезапустите программу чтобы изменения вступили в силу.";
            }
            catch (Exception ex) {
                MessageBox.Show( ex.Message );
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            if (textBox1.Text.Length > 0)
                button4.Enabled = true;
            else
                button4.Enabled = false;
        }

        private void label11_Click(object sender, EventArgs e) {
            for (int i = 0; i > -52; i--) {
                panel3.Location = new Point(0, i);
            }
            label10.Text = "";
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            lblCity.Visible = false;
            lblTemperature.Visible = false;
            lblCity.Text = textBox1.Text;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(lblCity.Text, new Font("Segoe UI", 24), Brushes.White, new PointF(0, -10));
            e.Graphics.DrawString(lblTemperature.Text, new Font("Segoe UI", 14), Brushes.White, new PointF(20, 35));
        }
    }
}