using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.Xml.Linq;


namespace Local_LanSend
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr window, int index, int value);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr window, int index);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        public static void HideFromAltTab(IntPtr Handle)
        {
            SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle,
                GWL_EXSTYLE) | WS_EX_TOOLWINDOW);
        }

        public Form1()
        {
            InitializeComponent();

            this.MouseDown += delegate
            {
                this.Capture = false;
                var msg = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref msg);
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            button2.Text = "";
            button3.Text = "";
            NamePoint.Text = "";
            //btnPing.Text = "";
            btnTemplate.Text = "";
            btnSearch.Text = "";
            btnCheck.Text = "";
            labelChech.Text = "0";
            btnAddTemp.Text = "";
            btnFile.Text = "";
            button22.Text = "";
            //labelKurator.Text = "";

            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            button10.Text = "";
            button11.Text = "";
            button12.Text = "";
            button13.Text = "";
            button14.Text = "";
            button15.Text = "";
            button16.Text = "";
            button17.Text = "";
            button4.Text = "";
            labelCount.Text = "";
            btnUp.Text = "";
            label6.Text = "";

            string imagePath = Environment.CurrentDirectory;

            //button2.Image = Image.FromFile(imagePath + @"\Image\Delete_20px.png");
            //button3.Image = Image.FromFile(imagePath + @"\Image\Arrow_20px.png");
            //btnTemplate.Image = Image.FromFile(imagePath + @"\Image\File_24px.png");
            //pictureBox2.Image = Image.FromFile(imagePath + @"\Image\left_50px.png");
            //btnSearch.Image = Image.FromFile(imagePath + @"\Image\Search_18px.png");
            //btnCheck.Image = Image.FromFile(imagePath + @"\Image\Todo List_24px.png");
            //btnAddTemp.Image = Image.FromFile(imagePath + @"\Image\Plus_25px.png");
            //btnUp.Image = Image.FromFile(imagePath + @"\Image\Restart_24px.png");
            //btnFile.Image = Image.FromFile(imagePath + @"\Image\Add_25px.png");
            //pictureBox3.Image = Image.FromFile(imagePath + @"\Image\Add_64px.png");
            //button22.Image = Image.FromFile(imagePath + @"\Image\Close_10px.png");

            //button6.Image = Image.FromFile(imagePath + @"\Image\Close_10px.png");
            //button7.Image = Image.FromFile(imagePath + @"\Image\Close_10px.png");
            //button8.Image = Image.FromFile(imagePath + @"\Image\Close_10px.png");
            //button9.Image = Image.FromFile(imagePath + @"\Image\Close_10px.png");
            //button10.Image = Image.FromFile(imagePath + @"\Image\Close_10px.png");
            //button11.Image = Image.FromFile(imagePath + @"\Image\Close_10px.png");
            //button12.Image = Image.FromFile(imagePath + @"\Image\Close_10px.png");
            //button13.Image = Image.FromFile(imagePath + @"\Image\Close_10px.png");
            //button14.Image = Image.FromFile(imagePath + @"\Image\Close_10px.png");
            //button15.Image = Image.FromFile(imagePath + @"\Image\Close_10px.png");
            //button16.Image = Image.FromFile(imagePath + @"\Image\Close_10px.png");
            //button17.Image = Image.FromFile(imagePath + @"\Image\Close_10px.png");
            //button4.Image = Image.FromFile(imagePath + @"\Image\Max_20px.png");

            //AddToolStripMenuItem.Image = Image.FromFile(imagePath + @"\Image\Plusb_15px.png");
            //DeleteToolStrip.Image = Image.FromFile(imagePath + @"\Image\Trash_20px.png");

            //pictureBox1.Image = Image.FromFile(imagePath + @"\Image\Email_15px.png");

            
                XmlDocument xDoc = new XmlDocument();

                DataSet ds = new DataSet();
                ds.ReadXml(@"\\192.168.0.83\Obmen\SendMsg\MessageStatus.xml");
                ListViewItem item;
                foreach (DataRow dr in ds.Tables["Kiosk"].Rows)
                {
                    item = new ListViewItem(new string[] { dr["msg_name"].ToString(), dr["msg_ip"].ToString() });
                    listView1.Items.Add(item);
                }

                labelCount.Text = "Кол-во элементов: " + listView1.Items.Count.ToString();

            StreamReader strR2 = new StreamReader("kurator");
            labelKurator.Text = Convert.ToString(strR2.ReadToEnd());
            strR2.Close();
            File.Delete("kurator");

                if(File.Exists(@"\\192.168.0.83\Obmen\SendMsg\Kurator\" + labelKurator.Text + ".txt"))
                {
                    StreamReader strReader = new StreamReader(@"\\192.168.0.83\Obmen\SendMsg\Kurator\" + labelKurator.Text + ".txt");
                    button20.Visible = true;
                    button22.Visible = true;
                    btnFile.Visible = false;
                    button20.Text = Convert.ToString(strReader.ReadToEnd());
                    strReader.Close();
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NamePoint.Text = listView1.FocusedItem.Index.ToString();
            }
            catch(Exception ex)
            {

            }
        }

        //private void btnPing_Click(object sender, EventArgs e)
        //{
        //    Ping ping = new Ping();
        //    //Application.DoEvents();
        //    string ipAddress = this.labelAddr.Text;
        //    //Application.DoEvents();
        //    PingReply pingReply = ping.Send(ipAddress, 5000);
        //    //Application.DoEvents();
        //    string IPStatus = pingReply.Status.ToString();
        //    //Application.DoEvents();
        //    if (IPStatus == "Success")
        //    {
        //        labelStatus.Text = "Online";
        //        labelStatus.ForeColor = Color.Lime;
        //    }
        //    if (IPStatus == "TimedOut")
        //    {
        //        labelStatus.Text = "Offline ";
        //        labelStatus.ForeColor = Color.Red;
        //    }
        //}

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (listView1.Visible == true)
            {
                if (labelChech.Text == "0")
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        listView1.Items[i].Checked = true;
                    }
                    labelChech.Text = "1";
                }
                else if (labelChech.Text == "1")
                {
                    for (int a = 0; a < listView1.Items.Count; a++)
                    {
                        listView1.Items[a].Checked = false;
                    }
                    labelChech.Text = "0";
                }
            }
            else if(listView3.Visible == true)
            {
                if (labelChech.Text == "0")
                {
                    for (int i = 0; i < listView3.Items.Count; i++)
                    {
                        listView3.Items[i].Checked = true;
                    }
                    labelChech.Text = "1";
                }
                else if (labelChech.Text == "1")
                {
                    for (int a = 0; a < listView3.Items.Count; a++)
                    {
                        listView3.Items[a].Checked = false;
                    }
                    labelChech.Text = "0";
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listView2.Items.Clear();
                label6.Text = "Выполняется отправка сообщения...";

                if (listView1.Visible == true)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {

                        if (listView1.Items[i].Checked == true)
                        {
                            Ping ping = new Ping();
                            string ipAddress = listView1.Items[i].SubItems[1].Text;
                            PingReply pingReply = ping.Send(ipAddress);
                            string IPStatus = pingReply.Status.ToString();

                            Application.DoEvents();

                            if (IPStatus == "Success")
                            {
                                Application.DoEvents();
                                Process pr = new Process();
                                pr.StartInfo.FileName = @"c:\Windows\System32\cmd.exe";
                                pr.StartInfo.Arguments = @"/C msg.exe * /SERVER:" + listView1.Items[i].SubItems[1].Text + " /TIME:1200 " + textBox1.Text;
                                pr.StartInfo.CreateNoWindow = true;
                                pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                pr.Start();
                                Application.DoEvents();
                            }
                            else if (IPStatus == "TimedOut")
                            {
                                Application.DoEvents();

                                ListViewItem item = new ListViewItem(new string[] { "Сообщение на точку " + listView1.Items[i].SubItems[0].Text + " не отправленно", "0" });
                                listView2.Items.Add(item);

                                Application.DoEvents();
                            }
                        }

                    }

                    textBox1.Text = "";

                    for (int c = 0; c < listView2.Items.Count; c++)
                    {
                        if (listView2.Items[c].SubItems[1].Text == "1")
                        {
                            listView2.Items[c].ForeColor = Color.Lime;
                        }
                        else if (listView2.Items[c].SubItems[1].Text == "0")
                        {
                            listView2.Items[c].ForeColor = Color.Red;
                        }
                    }
                }

                else if(listView3.Visible == true)
                {
                    for (int i = 0; i < listView3.Items.Count; i++)
                    {

                        if (listView3.Items[i].Checked == true)
                        {
                            Ping ping = new Ping();
                            string ipAddress = listView3.Items[i].SubItems[1].Text;
                            PingReply pingReply = ping.Send(ipAddress);
                            string IPStatus = pingReply.Status.ToString();

                            Application.DoEvents();

                            if (IPStatus == "Success")
                            {

                                Application.DoEvents();

                                Process pr = new Process();
                                pr.StartInfo.FileName = @"c:\Windows\System32\cmd.exe";
                                pr.StartInfo.Arguments = @"/C msg.exe * /SERVER:" + listView3.Items[i].SubItems[1].Text + " /TIME:1200 " + textBox1.Text;
                                pr.StartInfo.CreateNoWindow = true;
                                pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                                pr.Start();

                                Application.DoEvents();
                                //pr.WaitForExit();

                                //ListViewItem item = new ListViewItem(new string[] { "Сообщение на точку " + listView3.Items[i].SubItems[0].Text + " отправленно", "1" });
                                //listView2.Items.Add(item);
                            }
                            else if (IPStatus == "TimedOut")
                            {
                                Application.DoEvents();

                                ListViewItem item = new ListViewItem(new string[] { "Сообщение на точку " + listView3.Items[i].SubItems[0].Text + " не отправленно", "0" });
                                listView2.Items.Add(item);

                                Application.DoEvents();
                            }
                        }
                    }

                    textBox1.Text = "";

                    for (int c = 0; c < listView2.Items.Count; c++)
                    {
                        if (listView2.Items[c].SubItems[1].Text == "1")
                        {
                            listView2.Items[c].ForeColor = Color.Lime;
                        }
                        else if (listView2.Items[c].SubItems[1].Text == "0")
                        {
                            listView2.Items[c].ForeColor = Color.Red;
                        }
                    }
                }

                label6.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (listView1.Visible == true)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Focus();
                    listView1.Items[i].Focused = false;
                    listView1.Items[i].Selected = false;
                    if (listView1.Items[i].SubItems[0].Text.ToLower() == textBox2.Text.ToLower())
                    {
                        listView1.Focus();
                        listView1.Items[i].Focused = true;
                        listView1.Items[i].Selected = true;
                    }
                }
            }
            else if(listView3.Visible == true)
            {
                for (int i = 0; i < listView3.Items.Count; i++)
                {
                    listView3.Focus();
                    listView3.Items[i].Focused = false;
                    listView3.Items[i].Selected = false;
                    if (listView3.Items[i].SubItems[0].Text.ToLower() == textBox2.Text.ToLower())
                    {
                        listView3.Focus();
                        listView3.Items[i].Focused = true;
                        listView3.Items[i].Selected = true;
                    }
                }
            }
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            if(panelTemplate.Visible == false)
            {
                panelTemplate.Visible = true;
                if(File.Exists("template1"))
                {
                    StreamReader strReader1 = new StreamReader("template1");
                    btnTemplate1.Visible = true;
                    button6.Visible = true;
                    btnTemplate1.Text = Convert.ToString(strReader1.ReadToEnd());
                    strReader1.Close();
                }
                else
                {
                    label2.Visible = true;
                }
                if(File.Exists("template2"))
                {
                    StreamReader strReader2 = new StreamReader("template2");
                    btnTemplate2.Visible = true;
                    button7.Visible = true;
                    btnTemplate2.Text = Convert.ToString(strReader2.ReadToEnd());
                    strReader2.Close();
                }
                if (File.Exists("template3"))
                {
                    StreamReader strReader3 = new StreamReader("template3");
                    btnTemplate3.Visible = true;
                    button8.Visible = true;
                    btnTemplate3.Text = Convert.ToString(strReader3.ReadToEnd());
                    strReader3.Close();
                }
                if (File.Exists("template4"))
                {
                    StreamReader strReader4 = new StreamReader("template4");
                    btnTemplate4.Visible = true;
                    button9.Visible = true;
                    btnTemplate4.Text = Convert.ToString(strReader4.ReadToEnd());
                    strReader4.Close();
                }
                if (File.Exists("template5"))
                {
                    StreamReader strReader5 = new StreamReader("template5");
                    btnTemplate5.Visible = true;
                    button10.Visible = true;
                    btnTemplate5.Text = Convert.ToString(strReader5.ReadToEnd());
                    strReader5.Close();
                }
                if (File.Exists("template6"))
                {
                    StreamReader strReader6 = new StreamReader("template6");
                    btnTemplate6.Visible = true;
                    button11.Visible = true;
                    btnTemplate6.Text = Convert.ToString(strReader6.ReadToEnd());
                    strReader6.Close();
                }
                if (File.Exists("template7"))
                {
                    StreamReader strReader7 = new StreamReader("template7");
                    btnTemplate7.Visible = true;
                    button12.Visible = true;
                    btnTemplate7.Text = Convert.ToString(strReader7.ReadToEnd());
                    strReader7.Close();
                }
                if (File.Exists("template8"))
                {
                    StreamReader strReader8 = new StreamReader("template8");
                    btnTemplate8.Visible = true;
                    button13.Visible = true;
                    btnTemplate8.Text = Convert.ToString(strReader8.ReadToEnd());
                    strReader8.Close();
                }
                if (File.Exists("template9"))
                {
                    StreamReader strReader9 = new StreamReader("template9");
                    btnTemplate9.Visible = true;
                    button14.Visible = true;
                    btnTemplate9.Text = Convert.ToString(strReader9.ReadToEnd());
                    strReader9.Close();
                }
                if (File.Exists("template10"))
                {
                    StreamReader strReader10 = new StreamReader("template10");
                    btnTemplate10.Visible = true;
                    button15.Visible = true;
                    btnTemplate10.Text = Convert.ToString(strReader10.ReadToEnd());
                    strReader10.Close();
                }
                if (File.Exists("template11"))
                {
                    StreamReader strReader11 = new StreamReader("template11");
                    btnTemplate11.Visible = true;
                    button16.Visible = true;
                    btnTemplate11.Text = Convert.ToString(strReader11.ReadToEnd());
                    strReader11.Close();
                }
                if (File.Exists("template12"))
                {
                    StreamReader strReader12 = new StreamReader("template12");
                    btnTemplate12.Visible = true;
                    button17.Visible = true;
                    btnTemplate12.Text = Convert.ToString(strReader12.ReadToEnd());
                    strReader12.Close();
                    btnAddTemp.Visible = false;
                }
            }
            else if(panelTemplate.Visible == true)
            {
                panelTemplate.Visible = false;
            }
        }

        private void btnAddTemp_Click(object sender, EventArgs e)
        {
            if(textBox3.Visible == false)
            {
                textBox3.Visible = true;
                button5.Visible = true;
                textBox3.Focus();
            }
            else if(textBox3.Visible == true)
            {
                textBox3.Visible = false;
                button5.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(btnTemplate1.Visible == false)
            {
                File.AppendAllText("template1", textBox3.Text);
                StreamReader strReader1 = new StreamReader("template1");
                string strTemplate1 = Convert.ToString(strReader1.ReadToEnd());
                strReader1.Close();
                btnTemplate1.Visible = true;
                button6.Visible = true;
                btnTemplate1.Text = strTemplate1;
                textBox3.Text = "";
                textBox3.Focus();
                label2.Visible = false;
                return;
            }
            if(btnTemplate2.Visible == false)
            {
                File.AppendAllText("template2", textBox3.Text);
                StreamReader strReader2 = new StreamReader("template2");
                string strTemplate2 = Convert.ToString(strReader2.ReadToEnd());
                strReader2.Close();
                btnTemplate2.Visible = true;
                button7.Visible = true;
                btnTemplate2.Text = strTemplate2;
                textBox3.Text = "";
                textBox3.Focus();
                return;
            }
            if (btnTemplate3.Visible == false)
            {
                File.AppendAllText("template3", textBox3.Text);
                StreamReader strReader3 = new StreamReader("template3");
                string strTemplate3 = Convert.ToString(strReader3.ReadToEnd());
                strReader3.Close();
                btnTemplate3.Visible = true;
                button8.Visible = true;
                btnTemplate3.Text = strTemplate3;
                textBox3.Text = "";
                textBox3.Focus();
                return;
            }
            if (btnTemplate4.Visible == false)
            {
                File.AppendAllText("template4", textBox3.Text);
                StreamReader strReader4 = new StreamReader("template4");
                string strTemplate4 = Convert.ToString(strReader4.ReadToEnd());
                strReader4.Close();
                btnTemplate4.Visible = true;
                button9.Visible = true;
                btnTemplate4.Text = strTemplate4;
                textBox3.Text = "";
                textBox3.Focus();
                return;
            }
            if (btnTemplate5.Visible == false)
            {
                File.AppendAllText("template5", textBox3.Text);
                StreamReader strReader5 = new StreamReader("template5");
                string strTemplate5 = Convert.ToString(strReader5.ReadToEnd());
                strReader5.Close();
                btnTemplate5.Visible = true;
                button10.Visible = true;
                btnTemplate5.Text = strTemplate5;
                textBox3.Text = "";
                textBox3.Focus();
                return;
            }
            if (btnTemplate6.Visible == false)
            {
                File.AppendAllText("template6", textBox3.Text);
                StreamReader strReader6 = new StreamReader("template6");
                string strTemplate6 = Convert.ToString(strReader6.ReadToEnd());
                strReader6.Close();
                btnTemplate6.Visible = true;
                button11.Visible = true;
                btnTemplate6.Text = strTemplate6;
                textBox3.Text = "";
                textBox3.Focus();
                return;
            }
            if (btnTemplate7.Visible == false)
            {
                File.AppendAllText("template7", textBox3.Text);
                StreamReader strReader7 = new StreamReader("template7");
                string strTemplate7 = Convert.ToString(strReader7.ReadToEnd());
                strReader7.Close();
                btnTemplate7.Visible = true;
                button12.Visible = true;
                btnTemplate7.Text = strTemplate7;
                textBox3.Text = "";
                textBox3.Focus();
                return;
            }
            if (btnTemplate8.Visible == false)
            {
                File.AppendAllText("template8", textBox3.Text);
                StreamReader strReader8 = new StreamReader("template8");
                string strTemplate8 = Convert.ToString(strReader8.ReadToEnd());
                strReader8.Close();
                btnTemplate8.Visible = true;
                button13.Visible = true;
                btnTemplate8.Text = strTemplate8;
                textBox3.Text = "";
                textBox3.Focus();
                return;
            }
            if (btnTemplate9.Visible == false)
            {
                File.AppendAllText("template9", textBox3.Text);
                StreamReader strReader9 = new StreamReader("template9");
                string strTemplate9 = Convert.ToString(strReader9.ReadToEnd());
                strReader9.Close();
                btnTemplate9.Visible = true;
                button14.Visible = true;
                btnTemplate9.Text = strTemplate9;
                textBox3.Text = "";
                textBox3.Focus();
                return;
            }
            if (btnTemplate10.Visible == false)
            {
                File.AppendAllText("template10", textBox3.Text);
                StreamReader strReader10 = new StreamReader("template10");
                string strTemplate10 = Convert.ToString(strReader10.ReadToEnd());
                strReader10.Close();
                btnTemplate10.Visible = true;
                button15.Visible = true;
                btnTemplate10.Text = strTemplate10;
                textBox3.Text = "";
                textBox3.Focus();
                return;
            }
            if (btnTemplate11.Visible == false)
            {
                File.AppendAllText("template11", textBox3.Text);
                StreamReader strReader11 = new StreamReader("template11");
                string strTemplate11 = Convert.ToString(strReader11.ReadToEnd());
                strReader11.Close();
                btnTemplate11.Visible = true;
                button16.Visible = true;
                btnTemplate11.Text = strTemplate11;
                textBox3.Text = "";
                textBox3.Focus();
                return;
            }
            if (btnTemplate12.Visible == false)
            {
                File.AppendAllText("template12", textBox3.Text);
                StreamReader strReader12 = new StreamReader("template12");
                string strTemplate12 = Convert.ToString(strReader12.ReadToEnd());
                strReader12.Close();
                btnTemplate12.Visible = true;
                button17.Visible = true;
                btnTemplate12.Text = strTemplate12;
                btnAddTemp.Visible = false;
                textBox3.Text = "";
                textBox3.Visible = false;
                button5.Visible = false;
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (btnTemplate2.Visible == false)
            {
                File.Delete("template1");
                btnTemplate1.Text = "";
                btnTemplate1.Visible = false;
                button6.Visible = false;
                label2.Visible = true;
            }
            else
            {
                btnTemplate1.Text = "";
                btnTemplate1.Text = btnTemplate2.Text;
                File.Delete("template1");
                File.AppendAllText("template1", btnTemplate1.Text);
                if (btnTemplate3.Visible == false)
                {
                    File.Delete("template2");
                    btnTemplate2.Text = "";
                    btnTemplate2.Visible = false;
                    button7.Visible = false;
                }
                else
                {
                    btnTemplate2.Text = "";
                    btnTemplate2.Text = btnTemplate3.Text;
                    File.Delete("template2");
                    File.AppendAllText("template2", btnTemplate2.Text);
                    if (btnTemplate4.Visible == false)
                    {
                        File.Delete("template3");
                        btnTemplate3.Text = "";
                        btnTemplate3.Visible = false;
                        button8.Visible = false;
                    }
                    else
                    {
                        btnTemplate3.Text = "";
                        btnTemplate3.Text = btnTemplate4.Text;
                        File.Delete("template3");
                        File.AppendAllText("template3", btnTemplate3.Text);
                        if (btnTemplate5.Visible == false)
                        {
                            File.Delete("template4");
                            btnTemplate4.Text = "";
                            btnTemplate4.Visible = false;
                            button9.Visible = false;
                        }
                        else
                        {
                            btnTemplate4.Text = "";
                            btnTemplate4.Text = btnTemplate5.Text;
                            File.Delete("template4");
                            File.AppendAllText("template4", btnTemplate4.Text);
                            if (btnTemplate6.Visible == false)
                            {
                                File.Delete("template5");
                                btnTemplate5.Text = "";
                                btnTemplate5.Visible = false;
                                button10.Visible = false;
                            }
                            else
                            {
                                btnTemplate5.Text = "";
                                btnTemplate5.Text = btnTemplate6.Text;
                                File.Delete("template5");
                                File.AppendAllText("template5", btnTemplate5.Text);
                                if (btnTemplate7.Visible == false)
                                {
                                    File.Delete("template6");
                                    btnTemplate6.Text = "";
                                    btnTemplate6.Visible = false;
                                    button11.Visible = false;
                                }
                                else
                                {
                                    btnTemplate6.Text = "";
                                    btnTemplate6.Text = btnTemplate7.Text;
                                    File.Delete("template6");
                                    File.AppendAllText("template6", btnTemplate6.Text);
                                    if(btnTemplate8.Visible == false)
                                    {
                                        File.Delete("template7");
                                        btnTemplate7.Text = "";
                                        btnTemplate7.Visible = false;
                                        button12.Visible = false;
                                    }
                                    else
                                    {
                                        btnTemplate7.Text = "";
                                        btnTemplate7.Text = btnTemplate8.Text;
                                        File.Delete("template7");
                                        File.AppendAllText("template7", btnTemplate7.Text);
                                        if(btnTemplate9.Visible == false)
                                        {
                                            File.Delete("template8");
                                            btnTemplate8.Text = "";
                                            btnTemplate8.Visible = false;
                                            button13.Visible = false;
                                        }
                                        else
                                        {
                                            btnTemplate8.Text = "";
                                            btnTemplate8.Text = btnTemplate9.Text;
                                            File.Delete("template8");
                                            File.AppendAllText("template8", btnTemplate8.Text);
                                            if(btnTemplate10.Visible == false)
                                            {
                                                File.Delete("template9");
                                                btnTemplate9.Text = "";
                                                btnTemplate9.Visible = false;
                                                button14.Visible = false;
                                            }
                                            else
                                            {
                                                btnTemplate9.Text = "";
                                                btnTemplate9.Text = btnTemplate10.Text;
                                                File.Delete("template9");
                                                File.AppendAllText("template9", btnTemplate9.Text);
                                                if(btnTemplate11.Visible == false)
                                                {
                                                    File.Delete("template10");
                                                    btnTemplate10.Text = "";
                                                    btnTemplate10.Visible = false;
                                                    button15.Visible = false;
                                                }
                                                else
                                                {
                                                    btnTemplate10.Text = "";
                                                    btnTemplate10.Text = btnTemplate11.Text;
                                                    File.Delete("template10");
                                                    File.AppendAllText("template10", btnTemplate10.Text);
                                                    if(btnTemplate12.Visible == false)
                                                    {
                                                        File.Delete("template11");
                                                        btnTemplate11.Text = "";
                                                        btnTemplate11.Visible = false;
                                                        button16.Visible = false;
                                                    }
                                                    else
                                                    {
                                                        btnTemplate11.Text = "";
                                                        btnTemplate11.Text = btnTemplate12.Text;
                                                        File.Delete("template11");
                                                        File.AppendAllText("template11", btnTemplate11.Text);
                                                        File.Delete("template12");
                                                        btnTemplate12.Text = "";
                                                        btnTemplate12.Visible = false;
                                                        button17.Visible = false;
                                                        btnAddTemp.Visible = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (btnTemplate3.Visible == false)
            {
                File.Delete("template2");
                btnTemplate2.Text = "";
                btnTemplate2.Visible = false;
                button7.Visible = false;
            }
            else
            {
                btnTemplate2.Text = "";
                btnTemplate2.Text = btnTemplate3.Text;
                File.Delete("template2");
                File.AppendAllText("template2", btnTemplate2.Text);
                if (btnTemplate4.Visible == false)
                {
                    File.Delete("template3");
                    btnTemplate3.Text = "";
                    btnTemplate3.Visible = false;
                    button8.Visible = false;
                }
                else
                {
                    btnTemplate3.Text = "";
                    btnTemplate3.Text = btnTemplate4.Text;
                    File.Delete("template3");
                    File.AppendAllText("template3", btnTemplate3.Text);
                    if (btnTemplate5.Visible == false)
                    {
                        File.Delete("template4");
                        btnTemplate4.Text = "";
                        btnTemplate4.Visible = false;
                        button9.Visible = false;
                    }
                    else
                    {
                        btnTemplate4.Text = "";
                        btnTemplate4.Text = btnTemplate5.Text;
                        File.Delete("template4");
                        File.AppendAllText("template4", btnTemplate4.Text);
                        if (btnTemplate6.Visible == false)
                        {
                            File.Delete("template5");
                            btnTemplate5.Text = "";
                            btnTemplate5.Visible = false;
                            button10.Visible = false;
                        }
                        else
                        {
                            btnTemplate5.Text = "";
                            btnTemplate5.Text = btnTemplate6.Text;
                            File.Delete("template5");
                            File.AppendAllText("template5", btnTemplate5.Text);
                            if (btnTemplate7.Visible == false)
                            {
                                File.Delete("template6");
                                btnTemplate6.Text = "";
                                btnTemplate6.Visible = false;
                                button11.Visible = false;
                            }
                            else
                            {
                                btnTemplate6.Text = "";
                                btnTemplate6.Text = btnTemplate7.Text;
                                File.Delete("template6");
                                File.AppendAllText("template6", btnTemplate6.Text);
                                if (btnTemplate8.Visible == false)
                                {
                                    File.Delete("template7");
                                    btnTemplate7.Text = "";
                                    btnTemplate7.Visible = false;
                                    button12.Visible = false;
                                }
                                else
                                {
                                    btnTemplate7.Text = "";
                                    btnTemplate7.Text = btnTemplate8.Text;
                                    File.Delete("template7");
                                    File.AppendAllText("template7", btnTemplate7.Text);
                                    if (btnTemplate9.Visible == false)
                                    {
                                        File.Delete("template8");
                                        btnTemplate8.Text = "";
                                        btnTemplate8.Visible = false;
                                        button13.Visible = false;
                                    }
                                    else
                                    {
                                        btnTemplate8.Text = "";
                                        btnTemplate8.Text = btnTemplate9.Text;
                                        File.Delete("template8");
                                        File.AppendAllText("template8", btnTemplate8.Text);
                                        if (btnTemplate10.Visible == false)
                                        {
                                            File.Delete("template9");
                                            btnTemplate9.Text = "";
                                            btnTemplate9.Visible = false;
                                            button14.Visible = false;
                                        }
                                        else
                                        {
                                            btnTemplate9.Text = "";
                                            btnTemplate9.Text = btnTemplate10.Text;
                                            File.Delete("template9");
                                            File.AppendAllText("template9", btnTemplate9.Text);
                                            if (btnTemplate11.Visible == false)
                                            {
                                                File.Delete("template10");
                                                btnTemplate10.Text = "";
                                                btnTemplate10.Visible = false;
                                                button15.Visible = false;
                                            }
                                            else
                                            {
                                                btnTemplate10.Text = "";
                                                btnTemplate10.Text = btnTemplate11.Text;
                                                File.Delete("template10");
                                                File.AppendAllText("template10", btnTemplate10.Text);
                                                if (btnTemplate12.Visible == false)
                                                {
                                                    File.Delete("template11");
                                                    btnTemplate11.Text = "";
                                                    btnTemplate11.Visible = false;
                                                    button16.Visible = false;
                                                }
                                                else
                                                {
                                                    btnTemplate11.Text = "";
                                                    btnTemplate11.Text = btnTemplate12.Text;
                                                    File.Delete("template11");
                                                    File.AppendAllText("template11", btnTemplate11.Text);
                                                    File.Delete("template12");
                                                    btnTemplate12.Text = "";
                                                    btnTemplate12.Visible = false;
                                                    button17.Visible = false;
                                                    btnAddTemp.Visible = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (btnTemplate4.Visible == false)
            {
                File.Delete("template3");
                btnTemplate3.Text = "";
                btnTemplate3.Visible = false;
                button8.Visible = false;
            }
            else
            {
                btnTemplate3.Text = "";
                btnTemplate3.Text = btnTemplate4.Text;
                File.Delete("template3");
                File.AppendAllText("template3", btnTemplate3.Text);
                if (btnTemplate5.Visible == false)
                {
                    File.Delete("template4");
                    btnTemplate4.Text = "";
                    btnTemplate4.Visible = false;
                    button9.Visible = false;
                }
                else
                {
                    btnTemplate4.Text = "";
                    btnTemplate4.Text = btnTemplate5.Text;
                    File.Delete("template4");
                    File.AppendAllText("template4", btnTemplate4.Text);
                    if (btnTemplate6.Visible == false)
                    {
                        File.Delete("template5");
                        btnTemplate5.Text = "";
                        btnTemplate5.Visible = false;
                        button10.Visible = false;
                    }
                    else
                    {
                        btnTemplate5.Text = "";
                        btnTemplate5.Text = btnTemplate6.Text;
                        File.Delete("template5");
                        File.AppendAllText("template5", btnTemplate5.Text);
                        if (btnTemplate7.Visible == false)
                        {
                            File.Delete("template6");
                            btnTemplate6.Text = "";
                            btnTemplate6.Visible = false;
                            button11.Visible = false;
                        }
                        else
                        {
                            btnTemplate6.Text = "";
                            btnTemplate6.Text = btnTemplate7.Text;
                            File.Delete("template6");
                            File.AppendAllText("template6", btnTemplate6.Text);
                            if (btnTemplate8.Visible == false)
                            {
                                File.Delete("template7");
                                btnTemplate7.Text = "";
                                btnTemplate7.Visible = false;
                                button12.Visible = false;
                            }
                            else
                            {
                                btnTemplate7.Text = "";
                                btnTemplate7.Text = btnTemplate8.Text;
                                File.Delete("template7");
                                File.AppendAllText("template7", btnTemplate7.Text);
                                if (btnTemplate9.Visible == false)
                                {
                                    File.Delete("template8");
                                    btnTemplate8.Text = "";
                                    btnTemplate8.Visible = false;
                                    button13.Visible = false;
                                }
                                else
                                {
                                    btnTemplate8.Text = "";
                                    btnTemplate8.Text = btnTemplate9.Text;
                                    File.Delete("template8");
                                    File.AppendAllText("template8", btnTemplate8.Text);
                                    if (btnTemplate10.Visible == false)
                                    {
                                        File.Delete("template9");
                                        btnTemplate9.Text = "";
                                        btnTemplate9.Visible = false;
                                        button14.Visible = false;
                                    }
                                    else
                                    {
                                        btnTemplate9.Text = "";
                                        btnTemplate9.Text = btnTemplate10.Text;
                                        File.Delete("template9");
                                        File.AppendAllText("template9", btnTemplate9.Text);
                                        if (btnTemplate11.Visible == false)
                                        {
                                            File.Delete("template10");
                                            btnTemplate10.Text = "";
                                            btnTemplate10.Visible = false;
                                            button15.Visible = false;
                                        }
                                        else
                                        {
                                            btnTemplate10.Text = "";
                                            btnTemplate10.Text = btnTemplate11.Text;
                                            File.Delete("template10");
                                            File.AppendAllText("template10", btnTemplate10.Text);
                                            if (btnTemplate12.Visible == false)
                                            {
                                                File.Delete("template11");
                                                btnTemplate11.Text = "";
                                                btnTemplate11.Visible = false;
                                                button16.Visible = false;
                                            }
                                            else
                                            {
                                                btnTemplate11.Text = "";
                                                btnTemplate11.Text = btnTemplate12.Text;
                                                File.Delete("template11");
                                                File.AppendAllText("template11", btnTemplate11.Text);
                                                File.Delete("template12");
                                                btnTemplate12.Text = "";
                                                btnTemplate12.Visible = false;
                                                button17.Visible = false;
                                                btnAddTemp.Visible = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (btnTemplate5.Visible == false)
            {
                File.Delete("template4");
                btnTemplate4.Text = "";
                btnTemplate4.Visible = false;
                button9.Visible = false;
            }
            else
            {
                btnTemplate4.Text = "";
                btnTemplate4.Text = btnTemplate5.Text;
                File.Delete("template4");
                File.AppendAllText("template4", btnTemplate4.Text);
                if (btnTemplate6.Visible == false)
                {
                    File.Delete("template5");
                    btnTemplate5.Text = "";
                    btnTemplate5.Visible = false;
                    button10.Visible = false;
                }
                else
                {
                    btnTemplate5.Text = "";
                    btnTemplate5.Text = btnTemplate6.Text;
                    File.Delete("template5");
                    File.AppendAllText("template5", btnTemplate5.Text);
                    if (btnTemplate7.Visible == false)
                    {
                        File.Delete("template6");
                        btnTemplate6.Text = "";
                        btnTemplate6.Visible = false;
                        button11.Visible = false;
                    }
                    else
                    {
                        btnTemplate6.Text = "";
                        btnTemplate6.Text = btnTemplate7.Text;
                        File.Delete("template6");
                        File.AppendAllText("template6", btnTemplate6.Text);
                        if (btnTemplate8.Visible == false)
                        {
                            File.Delete("template7");
                            btnTemplate7.Text = "";
                            btnTemplate7.Visible = false;
                            button12.Visible = false;
                        }
                        else
                        {
                            btnTemplate7.Text = "";
                            btnTemplate7.Text = btnTemplate8.Text;
                            File.Delete("template7");
                            File.AppendAllText("template7", btnTemplate7.Text);
                            if (btnTemplate9.Visible == false)
                            {
                                File.Delete("template8");
                                btnTemplate8.Text = "";
                                btnTemplate8.Visible = false;
                                button13.Visible = false;
                            }
                            else
                            {
                                btnTemplate8.Text = "";
                                btnTemplate8.Text = btnTemplate9.Text;
                                File.Delete("template8");
                                File.AppendAllText("template8", btnTemplate8.Text);
                                if (btnTemplate10.Visible == false)
                                {
                                    File.Delete("template9");
                                    btnTemplate9.Text = "";
                                    btnTemplate9.Visible = false;
                                    button14.Visible = false;
                                }
                                else
                                {
                                    btnTemplate9.Text = "";
                                    btnTemplate9.Text = btnTemplate10.Text;
                                    File.Delete("template9");
                                    File.AppendAllText("template9", btnTemplate9.Text);
                                    if (btnTemplate11.Visible == false)
                                    {
                                        File.Delete("template10");
                                        btnTemplate10.Text = "";
                                        btnTemplate10.Visible = false;
                                        button15.Visible = false;
                                    }
                                    else
                                    {
                                        btnTemplate10.Text = "";
                                        btnTemplate10.Text = btnTemplate11.Text;
                                        File.Delete("template10");
                                        File.AppendAllText("template10", btnTemplate10.Text);
                                        if (btnTemplate12.Visible == false)
                                        {
                                            File.Delete("template11");
                                            btnTemplate11.Text = "";
                                            btnTemplate11.Visible = false;
                                            button16.Visible = false;
                                        }
                                        else
                                        {
                                            btnTemplate11.Text = "";
                                            btnTemplate11.Text = btnTemplate12.Text;
                                            File.Delete("template11");
                                            File.AppendAllText("template11", btnTemplate11.Text);
                                            File.Delete("template12");
                                            btnTemplate12.Text = "";
                                            btnTemplate12.Visible = false;
                                            button17.Visible = false;
                                            btnAddTemp.Visible = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (btnTemplate6.Visible == false)
            {
                File.Delete("template5");
                btnTemplate5.Text = "";
                btnTemplate5.Visible = false;
                button10.Visible = false;
            }
            else
            {
                btnTemplate5.Text = "";
                btnTemplate5.Text = btnTemplate6.Text;
                File.Delete("template5");
                File.AppendAllText("template5", btnTemplate5.Text);
                if (btnTemplate7.Visible == false)
                {
                    File.Delete("template6");
                    btnTemplate6.Text = "";
                    btnTemplate6.Visible = false;
                    button11.Visible = false;
                }
                else
                {
                    btnTemplate6.Text = "";
                    btnTemplate6.Text = btnTemplate7.Text;
                    File.Delete("template6");
                    File.AppendAllText("template6", btnTemplate6.Text);
                    if (btnTemplate8.Visible == false)
                    {
                        File.Delete("template7");
                        btnTemplate7.Text = "";
                        btnTemplate7.Visible = false;
                        button12.Visible = false;
                    }
                    else
                    {
                        btnTemplate7.Text = "";
                        btnTemplate7.Text = btnTemplate8.Text;
                        File.Delete("template7");
                        File.AppendAllText("template7", btnTemplate7.Text);
                        if (btnTemplate9.Visible == false)
                        {
                            File.Delete("template8");
                            btnTemplate8.Text = "";
                            btnTemplate8.Visible = false;
                            button13.Visible = false;
                        }
                        else
                        {
                            btnTemplate8.Text = "";
                            btnTemplate8.Text = btnTemplate9.Text;
                            File.Delete("template8");
                            File.AppendAllText("template8", btnTemplate8.Text);
                            if (btnTemplate10.Visible == false)
                            {
                                File.Delete("template9");
                                btnTemplate9.Text = "";
                                btnTemplate9.Visible = false;
                                button14.Visible = false;
                            }
                            else
                            {
                                btnTemplate9.Text = "";
                                btnTemplate9.Text = btnTemplate10.Text;
                                File.Delete("template9");
                                File.AppendAllText("template9", btnTemplate9.Text);
                                if (btnTemplate11.Visible == false)
                                {
                                    File.Delete("template10");
                                    btnTemplate10.Text = "";
                                    btnTemplate10.Visible = false;
                                    button15.Visible = false;
                                }
                                else
                                {
                                    btnTemplate10.Text = "";
                                    btnTemplate10.Text = btnTemplate11.Text;
                                    File.Delete("template10");
                                    File.AppendAllText("template10", btnTemplate10.Text);
                                    if (btnTemplate12.Visible == false)
                                    {
                                        File.Delete("template11");
                                        btnTemplate11.Text = "";
                                        btnTemplate11.Visible = false;
                                        button16.Visible = false;
                                    }
                                    else
                                    {
                                        btnTemplate11.Text = "";
                                        btnTemplate11.Text = btnTemplate12.Text;
                                        File.Delete("template11");
                                        File.AppendAllText("template11", btnTemplate11.Text);
                                        File.Delete("template12");
                                        btnTemplate12.Text = "";
                                        btnTemplate12.Visible = false;
                                        button17.Visible = false;
                                        btnAddTemp.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (btnTemplate7.Visible == false)
            {
                File.Delete("template6");
                btnTemplate6.Text = "";
                btnTemplate6.Visible = false;
                button11.Visible = false;
            }
            else
            {
                btnTemplate6.Text = "";
                btnTemplate6.Text = btnTemplate7.Text;
                File.Delete("template6");
                File.AppendAllText("template6", btnTemplate6.Text);
                if (btnTemplate8.Visible == false)
                {
                    File.Delete("template7");
                    btnTemplate7.Text = "";
                    btnTemplate7.Visible = false;
                    button12.Visible = false;
                }
                else
                {
                    btnTemplate7.Text = "";
                    btnTemplate7.Text = btnTemplate8.Text;
                    File.Delete("template7");
                    File.AppendAllText("template7", btnTemplate7.Text);
                    if (btnTemplate9.Visible == false)
                    {
                        File.Delete("template8");
                        btnTemplate8.Text = "";
                        btnTemplate8.Visible = false;
                        button13.Visible = false;
                    }
                    else
                    {
                        btnTemplate8.Text = "";
                        btnTemplate8.Text = btnTemplate9.Text;
                        File.Delete("template8");
                        File.AppendAllText("template8", btnTemplate8.Text);
                        if (btnTemplate10.Visible == false)
                        {
                            File.Delete("template9");
                            btnTemplate9.Text = "";
                            btnTemplate9.Visible = false;
                            button14.Visible = false;
                        }
                        else
                        {
                            btnTemplate9.Text = "";
                            btnTemplate9.Text = btnTemplate10.Text;
                            File.Delete("template9");
                            File.AppendAllText("template9", btnTemplate9.Text);
                            if (btnTemplate11.Visible == false)
                            {
                                File.Delete("template10");
                                btnTemplate10.Text = "";
                                btnTemplate10.Visible = false;
                                button15.Visible = false;
                            }
                            else
                            {
                                btnTemplate10.Text = "";
                                btnTemplate10.Text = btnTemplate11.Text;
                                File.Delete("template10");
                                File.AppendAllText("template10", btnTemplate10.Text);
                                if (btnTemplate12.Visible == false)
                                {
                                    File.Delete("template11");
                                    btnTemplate11.Text = "";
                                    btnTemplate11.Visible = false;
                                    button16.Visible = false;
                                }
                                else
                                {
                                    btnTemplate11.Text = "";
                                    btnTemplate11.Text = btnTemplate12.Text;
                                    File.Delete("template11");
                                    File.AppendAllText("template11", btnTemplate11.Text);
                                    File.Delete("template12");
                                    btnTemplate12.Text = "";
                                    btnTemplate12.Visible = false;
                                    button17.Visible = false;
                                    btnAddTemp.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (btnTemplate8.Visible == false)
            {
                File.Delete("template7");
                btnTemplate7.Text = "";
                btnTemplate7.Visible = false;
                button12.Visible = false;
            }
            else
            {
                btnTemplate7.Text = "";
                btnTemplate7.Text = btnTemplate8.Text;
                File.Delete("template7");
                File.AppendAllText("template7", btnTemplate7.Text);
                if (btnTemplate9.Visible == false)
                {
                    File.Delete("template8");
                    btnTemplate8.Text = "";
                    btnTemplate8.Visible = false;
                    button13.Visible = false;
                }
                else
                {
                    btnTemplate8.Text = "";
                    btnTemplate8.Text = btnTemplate9.Text;
                    File.Delete("template8");
                    File.AppendAllText("template8", btnTemplate8.Text);
                    if (btnTemplate10.Visible == false)
                    {
                        File.Delete("template9");
                        btnTemplate9.Text = "";
                        btnTemplate9.Visible = false;
                        button14.Visible = false;
                    }
                    else
                    {
                        btnTemplate9.Text = "";
                        btnTemplate9.Text = btnTemplate10.Text;
                        File.Delete("template9");
                        File.AppendAllText("template9", btnTemplate9.Text);
                        if (btnTemplate11.Visible == false)
                        {
                            File.Delete("template10");
                            btnTemplate10.Text = "";
                            btnTemplate10.Visible = false;
                            button15.Visible = false;
                        }
                        else
                        {
                            btnTemplate10.Text = "";
                            btnTemplate10.Text = btnTemplate11.Text;
                            File.Delete("template10");
                            File.AppendAllText("template10", btnTemplate10.Text);
                            if (btnTemplate12.Visible == false)
                            {
                                File.Delete("template11");
                                btnTemplate11.Text = "";
                                btnTemplate11.Visible = false;
                                button16.Visible = false;
                            }
                            else
                            {
                                btnTemplate11.Text = "";
                                btnTemplate11.Text = btnTemplate12.Text;
                                File.Delete("template11");
                                File.AppendAllText("template11", btnTemplate11.Text);
                                File.Delete("template12");
                                btnTemplate12.Text = "";
                                btnTemplate12.Visible = false;
                                button17.Visible = false;
                                btnAddTemp.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (btnTemplate9.Visible == false)
            {
                File.Delete("template8");
                btnTemplate8.Text = "";
                btnTemplate8.Visible = false;
                button13.Visible = false;
            }
            else
            {
                btnTemplate8.Text = "";
                btnTemplate8.Text = btnTemplate9.Text;
                File.Delete("template8");
                File.AppendAllText("template8", btnTemplate8.Text);
                if (btnTemplate10.Visible == false)
                {
                    File.Delete("template9");
                    btnTemplate9.Text = "";
                    btnTemplate9.Visible = false;
                    button14.Visible = false;
                }
                else
                {
                    btnTemplate9.Text = "";
                    btnTemplate9.Text = btnTemplate10.Text;
                    File.Delete("template9");
                    File.AppendAllText("template9", btnTemplate9.Text);
                    if (btnTemplate11.Visible == false)
                    {
                        File.Delete("template10");
                        btnTemplate10.Text = "";
                        btnTemplate10.Visible = false;
                        button15.Visible = false;
                    }
                    else
                    {
                        btnTemplate10.Text = "";
                        btnTemplate10.Text = btnTemplate11.Text;
                        File.Delete("template10");
                        File.AppendAllText("template10", btnTemplate10.Text);
                        if (btnTemplate12.Visible == false)
                        {
                            File.Delete("template11");
                            btnTemplate11.Text = "";
                            btnTemplate11.Visible = false;
                            button16.Visible = false;
                        }
                        else
                        {
                            btnTemplate11.Text = "";
                            btnTemplate11.Text = btnTemplate12.Text;
                            File.Delete("template11");
                            File.AppendAllText("template11", btnTemplate11.Text);
                            File.Delete("template12");
                            btnTemplate12.Text = "";
                            btnTemplate12.Visible = false;
                            button17.Visible = false;
                            btnAddTemp.Visible = true;
                        }
                    }
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (btnTemplate10.Visible == false)
            {
                File.Delete("template9");
                btnTemplate9.Text = "";
                btnTemplate9.Visible = false;
                button14.Visible = false;
            }
            else
            {
                btnTemplate9.Text = "";
                btnTemplate9.Text = btnTemplate10.Text;
                File.Delete("template9");
                File.AppendAllText("template9", btnTemplate9.Text);
                if (btnTemplate11.Visible == false)
                {
                    File.Delete("template10");
                    btnTemplate10.Text = "";
                    btnTemplate10.Visible = false;
                    button15.Visible = false;
                }
                else
                {
                    btnTemplate10.Text = "";
                    btnTemplate10.Text = btnTemplate11.Text;
                    File.Delete("template10");
                    File.AppendAllText("template10", btnTemplate10.Text);
                    if (btnTemplate12.Visible == false)
                    {
                        File.Delete("template11");
                        btnTemplate11.Text = "";
                        btnTemplate11.Visible = false;
                        button16.Visible = false;
                    }
                    else
                    {
                        btnTemplate11.Text = "";
                        btnTemplate11.Text = btnTemplate12.Text;
                        File.Delete("template11");
                        File.AppendAllText("template11", btnTemplate11.Text);
                        File.Delete("template12");
                        btnTemplate12.Text = "";
                        btnTemplate12.Visible = false;
                        button17.Visible = false;
                        btnAddTemp.Visible = true;
                    }
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (btnTemplate11.Visible == false)
            {
                File.Delete("template10");
                btnTemplate10.Text = "";
                btnTemplate10.Visible = false;
                button15.Visible = false;
            }
            else
            {
                btnTemplate10.Text = "";
                btnTemplate10.Text = btnTemplate11.Text;
                File.Delete("template10");
                File.AppendAllText("template10", btnTemplate10.Text);
                if (btnTemplate12.Visible == false)
                {
                    File.Delete("template11");
                    btnTemplate11.Text = "";
                    btnTemplate11.Visible = false;
                    button16.Visible = false;
                }
                else
                {
                    btnTemplate11.Text = "";
                    btnTemplate11.Text = btnTemplate12.Text;
                    File.Delete("template11");
                    File.AppendAllText("template11", btnTemplate11.Text);
                    File.Delete("template12");
                    btnTemplate12.Text = "";
                    btnTemplate12.Visible = false;
                    button17.Visible = false;
                    btnAddTemp.Visible = true;
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (btnTemplate12.Visible == false)
            {
                File.Delete("template11");
                btnTemplate11.Text = "";
                btnTemplate11.Visible = false;
                button16.Visible = false;
            }
            else
            {
                btnTemplate11.Text = "";
                btnTemplate11.Text = btnTemplate12.Text;
                File.Delete("template11");
                File.AppendAllText("template11", btnTemplate11.Text);
                File.Delete("template12");
                btnTemplate12.Text = "";
                btnTemplate12.Visible = false;
                button17.Visible = false;
                btnAddTemp.Visible = true;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            File.Delete("template12");
            btnTemplate12.Text = "";
            btnTemplate12.Visible = false;
            button17.Visible = false;
            btnAddTemp.Visible = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text != "")
            {
                button5.Enabled = true;
            }
            else
            {
                button5.Enabled = false;
            }
        }

        private void btnTemplate1_Click(object sender, EventArgs e)
        {
            textBox1.Text = btnTemplate1.Text;
            panelTemplate.Visible = false;
        }

        private void btnTemplate2_Click(object sender, EventArgs e)
        {
            textBox1.Text = btnTemplate2.Text;
            panelTemplate.Visible = false;
        }

        private void btnTemplate3_Click(object sender, EventArgs e)
        {
            textBox1.Text = btnTemplate3.Text;
            panelTemplate.Visible = false;
        }

        private void btnTemplate4_Click(object sender, EventArgs e)
        {
            textBox1.Text = btnTemplate4.Text;
            panelTemplate.Visible = false;
        }

        private void btnTemplate5_Click(object sender, EventArgs e)
        {
            textBox1.Text = btnTemplate5.Text;
            panelTemplate.Visible = false;
        }

        private void btnTemplate6_Click(object sender, EventArgs e)
        {
            textBox1.Text = btnTemplate6.Text;
            panelTemplate.Visible = false;
        }

        private void btnTemplate7_Click(object sender, EventArgs e)
        {
            textBox1.Text = btnTemplate7.Text;
            panelTemplate.Visible = false;
        }

        private void btnTemplate8_Click(object sender, EventArgs e)
        {
            textBox1.Text = btnTemplate8.Text;
            panelTemplate.Visible = false;
        }

        private void btnTemplate9_Click(object sender, EventArgs e)
        {
            textBox1.Text = btnTemplate9.Text;
            panelTemplate.Visible = false;
        }

        private void btnTemplate10_Click(object sender, EventArgs e)
        {
            textBox1.Text = btnTemplate10.Text;
            panelTemplate.Visible = false;
        }

        private void btnTemplate11_Click(object sender, EventArgs e)
        {
            textBox1.Text = btnTemplate11.Text;
            panelTemplate.Visible = false;
        }

        private void btnTemplate12_Click(object sender, EventArgs e)
        {
            textBox1.Text = btnTemplate12.Text;
            panelTemplate.Visible = false;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {

                labelCount.Text = "";

                if (listView1.Visible == true)
                {

                    listView1.Items.Clear();

                    XmlDocument xDoc = new XmlDocument();

                    DataSet ds = new DataSet();
                    ds.ReadXml(@"\\192.168.0.83\Obmen\SendMsg\MessageStatus.xml");
                    ListViewItem item;
                    foreach (DataRow dr in ds.Tables["Kiosk"].Rows)
                    {
                        item = new ListViewItem(new string[] { dr["msg_name"].ToString(), dr["msg_ip"].ToString() });
                        listView1.Items.Add(item);
                    }

                    labelCount.Text = "Кол-во элементов: " + listView1.Items.Count.ToString();
                }
                if(listView3.Visible == true)
                {

                    listView3.Items.Clear();

                    XmlDocument xDoc = new XmlDocument();

                    DataSet ds = new DataSet();
                    ds.ReadXml(@"\\192.168.0.83\Obmen\SendMsg\Kurator\" + button20.Text + @".xml");
                    ListViewItem item;
                    foreach (DataRow dr in ds.Tables["Kiosk"].Rows)
                    {
                        item = new ListViewItem(new string[] { dr["msg_name"].ToString(), dr["msg_ip"].ToString() });
                        listView3.Items.Add(item);
                    }

                    labelCount.Text = "Кол-во элементов: " + listView3.Items.Count.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            this.WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;

        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                listView3.Visible = false;
                listView1.Visible = true;
                listView1.Items.Clear();

                XmlDocument xDoc = new XmlDocument();

                DataSet ds = new DataSet();
                ds.ReadXml(@"\\192.168.0.83\Obmen\SendMsg\MessageStatus.xml");
                ListViewItem item;
                foreach (DataRow dr in ds.Tables["Kiosk"].Rows)
                {
                    item = new ListViewItem(new string[] { dr["msg_name"].ToString(), dr["msg_ip"].ToString() });
                    listView1.Items.Add(item);
                }

                labelCount.Text = "Кол-во элементов: " + listView1.Items.Count.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
                panel2.Visible = true;
            else
                panel2.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
                button18.Enabled = true;
            else
                button18.Enabled = false;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            panel2.Visible = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            button20.Visible = true;
            button22.Visible = true;
            button20.Text = textBox4.Text;

            File.AppendAllText(@"\\192.168.0.83\Obmen\SendMsg\Kurator\" + labelKurator.Text + ".txt", textBox4.Text);

            textBox4.Text = "";
            panel2.Visible = false;
            btnFile.Visible = false;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            button20.Visible = false;
            button22.Visible = false;
            btnFile.Visible = true;

            listView3.Visible = false;
            listView1.Visible = true;

            File.Delete(@"\\192.168.0.83\Obmen\SendMsg\Kurator\" + labelKurator.Text + ".txt");
            File.Delete(@"\\192.168.0.83\Obmen\SendMsg\Kurator\" + button20.Text + ".xml");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            listView3.Visible = true;

            labelCount.Text = "";

            try
            {
                DataSet ds = new DataSet();
                if (File.Exists(@"\\192.168.0.83\Obmen\SendMsg\Kurator\" + button20.Text + ".xml"))
                {
                    listView3.Items.Clear();

                    ds.ReadXml(@"\\192.168.0.83\Obmen\SendMsg\Kurator\" + button20.Text + ".xml");
                    ListViewItem item;
                    foreach (DataRow dr in ds.Tables["Kiosk"].Rows)
                    {
                        item = new ListViewItem(new string[] { dr["msg_name"].ToString(), dr["msg_ip"].ToString() });
                        listView3.Items.Add(item);
                    }
                    labelCount.Text = "Кол-во элементов: " + listView3.Items.Count.ToString();
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (button20.Visible == true)
            {
                if (e.Button == MouseButtons.Right)
                {
                    int CursorsX = Cursor.Position.X;
                    int CursorsY = Cursor.Position.Y;

                    Point ptLowerLeft = new Point(CursorsX - 12, CursorsY + 7);
                    //ptLowerLeft = listView1.PointToScreen(ptLowerLeft);
                    contextMenuStrip1.Show(ptLowerLeft);
                }
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(new string[] { listView1.Items[Convert.ToInt32(NamePoint.Text)].SubItems[0].Text, listView1.Items[Convert.ToInt32(NamePoint.Text)].SubItems[1].Text });
            listView3.Items.Add(item);

            XDocument xDoc1 = new XDocument();
            XElement XKioskElement = new XElement("Kiosks");

            for (int a = 0; a < listView3.Items.Count; a++)
            {
                XElement XKiosk = new XElement("Kiosk");
                
                XElement nameElement = new XElement("msg_name", listView3.Items[a].SubItems[0].Text);
                XElement ipElement = new XElement("msg_ip", listView3.Items[a].SubItems[1].Text);

                XKiosk.Add(nameElement);
                XKiosk.Add(ipElement);
                XKioskElement.Add(XKiosk);
            }

            xDoc1.Add(XKioskElement);
            xDoc1.Save(@"\\192.168.0.83\Obmen\SendMsg\Kurator\" + button20.Text + ".xml");
        }

        private void listView3_MouseDown(object sender, MouseEventArgs e)
        {
            if (listView3.Visible == true)
            {
                if (listView3.Items.Count > 0)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        int CursorsX = Cursor.Position.X;
                        int CursorsY = Cursor.Position.Y;

                        Point ptLowerLeft = new Point(CursorsX - 12, CursorsY + 7);
                        contextMenuStrip2.Show(ptLowerLeft);
                    }
                }
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelAddr.Text = listView3.FocusedItem.Index.ToString();
        }

        private void DeleteToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                listView3.Items[Convert.ToInt32(labelAddr.Text)].Remove();

                XDocument xDoc1 = new XDocument();
                XElement XKioskElement = new XElement("Kiosks");

                for (int a = 0; a < listView3.Items.Count; a++)
                {
                    XElement XKiosk = new XElement("Kiosk");

                    XElement nameElement = new XElement("msg_name", listView3.Items[a].SubItems[0].Text);
                    XElement ipElement = new XElement("msg_ip", listView3.Items[a].SubItems[1].Text);

                    XKiosk.Add(nameElement);
                    XKiosk.Add(ipElement);
                    XKioskElement.Add(XKiosk);
                }

                xDoc1.Add(XKioskElement);
                xDoc1.Save(@"\\192.168.0.83\Obmen\SendMsg\Kurator\" + button20.Text + ".xml");

                labelCount.Text = "Кол-во элементов: " + listView3.Items.Count.ToString();

                if (listView3.Items.Count == 0)
                {
                    File.Delete(@"\\192.168.0.83\Obmen\SendMsg\Kurator\" + button20.Text + ".xml");
                    labelCount.Text = "";
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox2.Text != "")
                    {
                        if (listView1.Visible == true)
                        {
                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                listView1.Focus();
                                listView1.Items[i].Focused = false;
                                listView1.Items[i].Selected = false;
                                if (listView1.Items[i].SubItems[0].Text.ToLower() == textBox2.Text.ToLower())
                                {
                                    listView1.Focus();
                                    listView1.Items[i].Focused = true;
                                    listView1.Items[i].Selected = true;
                                }
                            }
                        }
                        else if (listView3.Visible == true)
                        {
                            for (int i = 0; i < listView3.Items.Count; i++)
                            {
                                listView3.Focus();
                                listView3.Items[i].Focused = false;
                                listView3.Items[i].Selected = false;

                                if (listView3.Items[i].SubItems[0].Text.ToLower() == textBox2.Text.ToLower())
                                {
                                    listView3.Focus();
                                    listView3.Items[i].Focused = true;
                                    listView3.Items[i].Selected = true;
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                label5.Visible = false;
            else
                label5.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            textBox2.Focus();
        }
    }
}