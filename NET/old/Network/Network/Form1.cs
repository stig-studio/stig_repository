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

namespace Network
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public static double CalcSpeed(string url)
        {
            WebClient client = new WebClient();
            DateTime dt1 = DateTime.Now;
            byte [] data = client.DownloadData(url);
            DateTime dt2 = DateTime.Now;
            return (data.Length * 8) / (dt2 - dt1).TotalSeconds;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(Convert.ToInt32(textBox2.Text) + 1);
            ListViewItem item = new ListViewItem(new string[] { textBox2.Text, Convert.ToString(DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00")), Math.Round(CalcSpeed("https://www.google.ru/") / 1000, 2).ToString(), "Кбит/сек"});
            listView1.Items.Add(item);
            listView1.EnsureVisible(listView1.Items.Count - 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
