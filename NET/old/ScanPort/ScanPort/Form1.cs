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
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ScanPort
{
    public partial class Form1 : Form
    {
        public static ManualResetEvent connectDone = new ManualResetEvent(false);  

        public Form1()
        {
            InitializeComponent();
        }

        public void Scan()
        {
            int StartPort = Convert.ToInt32(this.textBox2.Text);
            int EndPort = Convert.ToInt32(this.textBox3.Text);
            int i;

            progressBar1.Maximum = EndPort - StartPort + 1;
            progressBar1.Value = 0;
            listView1.Items.Clear();

            string pathIP1 = Environment.CurrentDirectory;
            File.Delete(pathIP1 + "\\OpenPort");

            IPAddress IpAddr = IPAddress.Parse(textBox1.Text);
            for (i = StartPort; i <= EndPort; i++)
            {
                IPEndPoint IpEndP = new IPEndPoint(IpAddr, i);
                Socket MySoc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IAsyncResult asyncResult = MySoc.BeginConnect(IpEndP, new AsyncCallback(ConnectCallback), MySoc);

                if (!asyncResult.AsyncWaitHandle.WaitOne(30, false))
                {
                    MySoc.Close();
                    Application.DoEvents();
                    listView1.Items.Add("Порт " + i.ToString());
                    Application.DoEvents();
                    listView1.Items[i - StartPort].SubItems.Add("закрыт");
                    Application.DoEvents();
                    listView1.Items[i - StartPort].BackColor = Color.Bisque;
                    Application.DoEvents();
                    progressBar1.Value += 1;
                    Application.DoEvents();
                    listView1.EnsureVisible(listView1.Items.Count - 1);
                    Application.DoEvents();
                }
                else
                {
                    MySoc.Close();
                    Application.DoEvents();
                    listView1.Items.Add("Порт " + i.ToString());
                    Application.DoEvents();
                    listView1.Items[i - StartPort].SubItems.Add("открыт");
                    Application.DoEvents();
                    if (this.checkBox1.Checked == true)
                    {
                        string pathIP = Environment.CurrentDirectory;
                        File.AppendAllText(pathIP + "\\OpenPort", Convert.ToString(i) + Environment.NewLine);
                    }
                    listView1.Items[i - StartPort].BackColor = Color.LightGreen;
                    Application.DoEvents();
                    progressBar1.Value += 1;
                    Application.DoEvents();
                    listView1.EnsureVisible(listView1.Items.Count - 1);
                    Application.DoEvents();

                }
            }


            progressBar1.Value = 0;
        
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket SockClient = (Socket)ar.AsyncState;
                SockClient.EndConnect(ar);
                connectDone.Set();
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Scan();
        }
    }
}
