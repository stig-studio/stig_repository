using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Drawing.Printing;

namespace Shelf_life
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string pathImage = Environment.CurrentDirectory;

            btnAdd.Text = "";
            btnSettings.Text = "";
            btnUpdate.Text = "";
            btnSave.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            button10.Text = "";
            button11.Text = "";
            button12.Text = "";
            label9.Text = "0";

            try
            {

                btnAdd.Image = Image.FromFile(pathImage + @"\Image\Add.png");
                //btnSettings.Image = Image.FromFile(pathImage + @"\Image\Settings.png");
                btnSettings.Image = Image.FromFile(pathImage + @"\Image\Settings.png");

                btnUpdate.Image = Image.FromFile(pathImage + @"\Image\Update.png");
                btnSave.Image = Image.FromFile(pathImage + @"\Image\Save.png");
                button2.Image = Image.FromFile(pathImage + @"\Image\Close1.png");
                pictureBox1.Image = Image.FromFile(pathImage + @"\Image\Info1.png");
                button3.Image = Image.FromFile(pathImage + @"\Image\Close1.png");
                button4.Image = Image.FromFile(pathImage + @"\Image\Delete.png");
                button5.Image = Image.FromFile(pathImage + @"\Image\Delete.png");
                button6.Image = Image.FromFile(pathImage + @"\Image\Delete.png");
                button7.Image = Image.FromFile(pathImage + @"\Image\Delete.png");
                button8.Image = Image.FromFile(pathImage + @"\Image\Print.png");
                button9.Image = Image.FromFile(pathImage + @"\Image\Print.png");
                button10.Image = Image.FromFile(pathImage + @"\Image\Print.png");
                button11.Image = Image.FromFile(pathImage + @"\Image\Print.png");
                button12.Image = Image.FromFile(pathImage + @"\Image\tray1.png");

                panel2.Location = new Point(-370, 52);

                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd.MM.yyyy";
                dateTimePicker1.Text = DateTime.Now.ToString("dd.MM.yyyy");

                if (!File.Exists("pathFile"))
                {
                    FormSettings fSettings = new FormSettings();
                    fSettings.ShowDialog();
                }
                else
                {
                    string pathFile;

                    StreamReader strReader = new StreamReader("pathFile");
                    pathFile = Convert.ToString(strReader.ReadToEnd());
                    label3.Text = pathFile + @"\List of Products.xml";
                    strReader.Close();
                }

                XmlDocument xDoc = new XmlDocument();

                xDoc.Load(label3.Text);

                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("Name");
                        foreach (XmlNode childNode in xnode.ChildNodes)
                        {
                            if (childNode.Name == "Date")
                            {
                                ListViewItem item = new ListViewItem(new string[] { attr.Value, childNode.InnerText }, 0);
                                this.listView1.Items.Add(item);
                            }
                        }
                    }
                }

                for (int IndexCount = 0; IndexCount < listView1.Items.Count; IndexCount++)
                {
                    if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(-1).ToShortDateString()))
                    {
                        ListViewItem items2 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                        listView2.Items.Insert(0, items2);
                    }

                    if (listView1.Items[IndexCount].SubItems[1].Text == DateTime.Now.ToString("dd.MM.yyyy"))
                    {
                        ListViewItem items3 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                        listView3.Items.Insert(0, items3);
                    }

                    if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(+1).ToShortDateString()))
                    {
                        ListViewItem items4 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                        listView4.Items.Insert(0, items4);
                    }

                }

                File.Delete(label3.Text);

                XDocument xDoc1 = new XDocument();
                XElement XNomenklaturaElement1 = new XElement("Nomeklatura");

                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    XElement XTovar = new XElement("Tovar");

                    XAttribute TovarNameAttribute = new XAttribute("Name", listView1.Items[i].SubItems[0].Text);
                    XElement DateElement = new XElement("Date", listView1.Items[i].SubItems[1].Text);

                    XTovar.Add(TovarNameAttribute);
                    XTovar.Add(DateElement);
                    XNomenklaturaElement1.Add(XTovar);
                }

                xDoc1.Add(XNomenklaturaElement1);
                xDoc1.Save(label3.Text);

                listView1.Items.Clear();
                listView2.Items.Clear();
                listView3.Items.Clear();
                listView4.Items.Clear();

                XmlDocument xDocLoad = new XmlDocument();

                xDocLoad.Load(label3.Text);

                XmlElement xRoot1 = xDocLoad.DocumentElement;
                foreach (XmlNode xnode in xRoot1)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("Name");
                        foreach (XmlNode childNode in xnode.ChildNodes)
                        {
                            if (childNode.Name == "Date")
                            {
                                ListViewItem item = new ListViewItem(new string[] { attr.Value, childNode.InnerText }, 0);
                                this.listView1.Items.Add(item);
                            }
                        }
                    }
                }

                for (int IndexCount = 0; IndexCount < listView1.Items.Count; IndexCount++)
                {
                    if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(-1).ToShortDateString()))
                    {
                        ListViewItem items2 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                        listView2.Items.Insert(0, items2);
                    }

                    if (listView1.Items[IndexCount].SubItems[1].Text == DateTime.Now.ToString("dd.MM.yyyy"))
                    {
                        ListViewItem items3 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                        listView3.Items.Insert(0, items3);
                    }

                    if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(+1).ToShortDateString()))
                    {
                        ListViewItem items4 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                        listView4.Items.Insert(0, items4);
                    }

                    timer2.Start();
                    timer3.Start();

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Shelf life", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormSettings fSettings = new FormSettings();
            fSettings.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (panel2.Location == new Point(-370, 52))
            {
                panel2.Visible = true;

                panel4.Location = new Point(12, 203);
                panel5.Location = new Point(12, 343);
                panel6.Location = new Point(12, 483);

                for (int i = -370; i <= 12; i++)
                {
                    Application.DoEvents();
                    panel2.Location = new Point(i, 52);
                    Application.DoEvents();
                }
                return;
            }
            if (panel2.Location == new Point(12, 52))
            {
                panel2.Location = new Point(-370, 52);
                panel2.Visible = false;
                panel4.Location = new Point(12, 52);
                panel5.Location = new Point(12, 192);
                panel6.Location = new Point(12, 332);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ListViewItem item = new ListViewItem(new string[] { textBox1.Text, dateTimePicker1.Text }, 0);
            listView1.Items.Insert(0, item);

            if (panel3.Visible == true)
            {
                textBox2.Text += "Добавлен новый товар: " + textBox1.Text + " на дату: " + dateTimePicker1.Text + Environment.NewLine + "___________________________________________" + Environment.NewLine;
            }

            if (dateTimePicker1.Text == Convert.ToString(DateTime.Now.AddDays(-1).ToShortDateString()))
            {

                ListViewItem item1 = new ListViewItem(new string[] { textBox1.Text }, 0);
                listView2.Items.Insert(0, item1);

            }
            if (dateTimePicker1.Text == DateTime.Now.ToString("dd.MM.yyyy"))
            {

                ListViewItem item2 = new ListViewItem(new string[] { textBox1.Text }, 0);
                listView3.Items.Insert(0, item2);

            }
            if (dateTimePicker1.Text == DateTime.Now.AddDays(+1).ToShortDateString())
            {

                ListViewItem item3 = new ListViewItem(new string[] { textBox1.Text }, 0);
                listView4.Items.Insert(0, item3);

            }


            textBox1.Text = "";

            textBox2.SelectionStart = textBox2.Text.Length;
            textBox2.ScrollToCaret();

            XDocument xDoc = new XDocument();
            XElement XNomenklaturaElement = new XElement("Nomeklatura");

            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                XElement XTovar = new XElement("Tovar");

                XAttribute TovarNameAttribute = new XAttribute("Name", listView1.Items[i].SubItems[0].Text);
                XElement DateElement = new XElement("Date", listView1.Items[i].SubItems[1].Text);

                XTovar.Add(TovarNameAttribute);
                XTovar.Add(DateElement);
                XNomenklaturaElement.Add(XTovar);
            }

            xDoc.Add(XNomenklaturaElement);
            xDoc.Save(label3.Text);

            textBox1.Focus();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            listView1.Width += panel3.Width;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                this.button1.Enabled = true;
            }
            else
            {
                this.button1.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                XDocument xDoc = new XDocument();
                XElement XNomenklaturaElement = new XElement("Nomeklatura");

                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    XElement XTovar = new XElement("Tovar");

                    XAttribute TovarNameAttribute = new XAttribute("Name", listView1.Items[i].SubItems[0].Text);
                    XElement DateElement = new XElement("Date", listView1.Items[i].SubItems[1].Text);

                    XTovar.Add(TovarNameAttribute);
                    XTovar.Add(DateElement);
                    XNomenklaturaElement.Add(XTovar);
                }

                xDoc.Add(XNomenklaturaElement);
                xDoc.Save(label3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Shelf life", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (panel7.Visible == false)
            {
                panel7.Visible = true;

                panel3.Location = new Point(panel3.Location.X, 127);
                panel3.Height = panel3.Height - 75;

                int pan0 = panel7.Location.X - 260;
                int panX = panel7.Location.X;

                for (int pan3 = pan0; panX > pan3; panX--)
                {
                    Application.DoEvents();
                    panel7.Location = new Point(panX, panel7.Location.Y);
                    Application.DoEvents();
                }
                timer1.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel7.Location = new Point(panel7.Location.X + 260, panel7.Location.Y);

            panel3.Location = new Point(panel3.Location.X, 52);
            panel3.Height = panel3.Height + 75;
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel7.Visible == true)
            {
                panel7.Visible = false;
                panel7.Location = new Point(panel7.Location.X + 260, panel7.Location.Y);

                panel3.Location = new Point(panel3.Location.X, 52);
                panel3.Height = panel3.Height + 75;
            }
            timer1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.Delete(label3.Text);
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            listView4.Items.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                listView2.Items.Clear();
                listView3.Items.Clear();
                listView4.Items.Clear();

                XmlDocument xDoc = new XmlDocument();

                xDoc.Load(label3.Text);

                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("Name");
                        foreach (XmlNode childNode in xnode.ChildNodes)
                        {
                            if (childNode.Name == "Date")
                            {
                                ListViewItem item = new ListViewItem(new string[] { attr.Value, childNode.InnerText }, 0);
                                this.listView1.Items.Add(item);
                            }
                        }
                    }
                }

                for (int IndexCount = 0; IndexCount < listView1.Items.Count; IndexCount++)
                {
                    if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(-1).ToShortDateString()))
                    {
                        ListViewItem items2 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                        listView2.Items.Insert(0, items2);
                    }

                    if (listView1.Items[IndexCount].SubItems[1].Text == DateTime.Now.ToString("dd.MM.yyyy"))
                    {
                        ListViewItem items3 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                        listView3.Items.Insert(0, items3);
                    }

                    if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(+1).ToShortDateString()))
                    {
                        ListViewItem items4 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                        listView4.Items.Insert(0, items4);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            int y = listView1.Items.Count;

            for (int a = 0; a < 1000; a++ )
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(-1).ToShortDateString()))
                    {
                        listView1.Items[i].Remove();
                    }
                }
            }

            File.Delete(label3.Text);

            XDocument xDoc = new XDocument();
            XElement XNomenklaturaElement = new XElement("Nomeklatura");

            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                XElement XTovar = new XElement("Tovar");

                XAttribute TovarNameAttribute = new XAttribute("Name", listView1.Items[i].SubItems[0].Text);
                XElement DateElement = new XElement("Date", listView1.Items[i].SubItems[1].Text);

                XTovar.Add(TovarNameAttribute);
                XTovar.Add(DateElement);
                XNomenklaturaElement.Add(XTovar);
            }

            xDoc.Add(XNomenklaturaElement);
            xDoc.Save(label3.Text);

            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            listView4.Items.Clear();

            XmlDocument xDocLoad = new XmlDocument();

            xDocLoad.Load(label3.Text);

            XmlElement xRoot = xDocLoad.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("Name");
                    foreach (XmlNode childNode in xnode.ChildNodes)
                    {
                        if (childNode.Name == "Date")
                        {
                            ListViewItem item = new ListViewItem(new string[] { attr.Value, childNode.InnerText }, 0);
                            this.listView1.Items.Add(item);
                        }
                    }
                }
            }

            for (int IndexCount = 0; IndexCount < listView1.Items.Count; IndexCount++)
            {
                if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(-1).ToShortDateString()))
                {
                    ListViewItem items2 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                    listView2.Items.Insert(0, items2);
                }

                if (listView1.Items[IndexCount].SubItems[1].Text == DateTime.Now.ToString("dd.MM.yyyy"))
                {
                    ListViewItem items3 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                    listView3.Items.Insert(0, items3);
                }

                if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(+1).ToShortDateString()))
                {
                    ListViewItem items4 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                    listView4.Items.Insert(0, items4);
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            int y = listView1.Items.Count;

            for (int a = 0; a < 1000; a++)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[1].Text == DateTime.Now.ToString("dd.MM.yyyy"))
                    {
                        listView1.Items[i].Remove();
                    }
                }
            }

            File.Delete(label3.Text);

            XDocument xDoc = new XDocument();
            XElement XNomenklaturaElement = new XElement("Nomeklatura");

            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                XElement XTovar = new XElement("Tovar");

                XAttribute TovarNameAttribute = new XAttribute("Name", listView1.Items[i].SubItems[0].Text);
                XElement DateElement = new XElement("Date", listView1.Items[i].SubItems[1].Text);

                XTovar.Add(TovarNameAttribute);
                XTovar.Add(DateElement);
                XNomenklaturaElement.Add(XTovar);
            }

            xDoc.Add(XNomenklaturaElement);
            xDoc.Save(label3.Text);

            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            listView4.Items.Clear();

            XmlDocument xDocLoad = new XmlDocument();

            xDocLoad.Load(label3.Text);

            XmlElement xRoot = xDocLoad.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("Name");
                    foreach (XmlNode childNode in xnode.ChildNodes)
                    {
                        if (childNode.Name == "Date")
                        {
                            ListViewItem item = new ListViewItem(new string[] { attr.Value, childNode.InnerText }, 0);
                            this.listView1.Items.Add(item);
                        }
                    }
                }
            }

            for (int IndexCount = 0; IndexCount < listView1.Items.Count; IndexCount++)
            {
                if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(-1).ToShortDateString()))
                {
                    ListViewItem items2 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                    listView2.Items.Insert(0, items2);
                }

                if (listView1.Items[IndexCount].SubItems[1].Text == DateTime.Now.ToString("dd.MM.yyyy"))
                {
                    ListViewItem items3 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                    listView3.Items.Insert(0, items3);
                }

                if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(+1).ToShortDateString()))
                {
                    ListViewItem items4 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                    listView4.Items.Insert(0, items4);
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            int y = listView1.Items.Count;

            for (int a = 0; a < 1000; a++)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(+1).ToShortDateString()))
                    {
                        listView1.Items[i].Remove();
                    }
                }
            }

            File.Delete(label3.Text);

            XDocument xDoc = new XDocument();
            XElement XNomenklaturaElement = new XElement("Nomeklatura");

            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                XElement XTovar = new XElement("Tovar");

                XAttribute TovarNameAttribute = new XAttribute("Name", listView1.Items[i].SubItems[0].Text);
                XElement DateElement = new XElement("Date", listView1.Items[i].SubItems[1].Text);

                XTovar.Add(TovarNameAttribute);
                XTovar.Add(DateElement);
                XNomenklaturaElement.Add(XTovar);
            }

            xDoc.Add(XNomenklaturaElement);
            xDoc.Save(label3.Text);

            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            listView4.Items.Clear();

            XmlDocument xDocLoad = new XmlDocument();

            xDocLoad.Load(label3.Text);

            XmlElement xRoot = xDocLoad.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("Name");
                    foreach (XmlNode childNode in xnode.ChildNodes)
                    {
                        if (childNode.Name == "Date")
                        {
                            ListViewItem item = new ListViewItem(new string[] { attr.Value, childNode.InnerText }, 0);
                            this.listView1.Items.Add(item);
                        }
                    }
                }
            }

            for (int IndexCount = 0; IndexCount < listView1.Items.Count; IndexCount++)
            {
                if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(-1).ToShortDateString()))
                {
                    ListViewItem items2 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                    listView2.Items.Insert(0, items2);
                }

                if (listView1.Items[IndexCount].SubItems[1].Text == DateTime.Now.ToString("dd.MM.yyyy"))
                {
                    ListViewItem items3 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                    listView3.Items.Insert(0, items3);
                }

                if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(+1).ToShortDateString()))
                {
                    ListViewItem items4 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                    listView4.Items.Insert(0, items4);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            string printText = "";
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                printText += listView1.Items[i].SubItems[0].Text + "            ( " + listView1.Items[i].SubItems[1].Text + " )" + Environment.NewLine;
            }
            e.Graphics.DrawString(Environment.NewLine + "Список товаров на: " + DateTime.Now.ToString("dd.MM.yyyy") + Environment.NewLine + Environment.NewLine + printText, new Font("Segoe UI", 12, FontStyle.Regular), Brushes.Black, new Point(25, 0));
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            string printText = "";
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                printText += listView2.Items[i].SubItems[0].Text + Environment.NewLine;
            }
            e.Graphics.DrawString(Environment.NewLine + "Список просроченных товаров на: " + DateTime.Now.AddDays(-1).ToShortDateString() + Environment.NewLine + Environment.NewLine + printText, new Font("Segoe UI", 12, FontStyle.Regular), Brushes.Black, new Point(25, 0));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument2;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument3_PrintPage(object sender, PrintPageEventArgs e)
        {
            string printText = "";
            for (int i = 0; i < listView3.Items.Count; i++)
            {
                printText += listView3.Items[i].SubItems[0].Text + Environment.NewLine;
            }
            e.Graphics.DrawString(Environment.NewLine + "Список просроченных товаров на: " + DateTime.Now.ToString("dd.MM.yyyy") + Environment.NewLine + Environment.NewLine + printText, new Font("Segoe UI", 12, FontStyle.Regular), Brushes.Black, new Point(25, 0));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument3;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument4_PrintPage(object sender, PrintPageEventArgs e)
        {
            string printText = "";
            for (int i = 0; i < listView4.Items.Count; i++)
            {
                printText += listView4.Items[i].SubItems[0].Text + Environment.NewLine;
            }
            e.Graphics.DrawString(Environment.NewLine + "Список просроченных товаров на: " + DateTime.Now.AddDays(+1).ToShortDateString() + Environment.NewLine + Environment.NewLine + printText, new Font("Segoe UI", 12, FontStyle.Regular), Brushes.Black, new Point(25, 0));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument4;
            printPreviewDialog1.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                listView2.Items.Clear();
                listView3.Items.Clear();
                listView4.Items.Clear();

                XmlDocument xDoc = new XmlDocument();

                xDoc.Load(label3.Text);

                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("Name");
                        foreach (XmlNode childNode in xnode.ChildNodes)
                        {
                            if (childNode.Name == "Date")
                            {
                                ListViewItem item = new ListViewItem(new string[] { attr.Value, childNode.InnerText }, 0);
                                this.listView1.Items.Add(item);
                            }
                        }
                    }
                }

                for (int IndexCount = 0; IndexCount < listView1.Items.Count; IndexCount++)
                {
                    if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(-1).ToShortDateString()))
                    {
                        ListViewItem items2 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                        listView2.Items.Insert(0, items2);
                    }

                    if (listView1.Items[IndexCount].SubItems[1].Text == DateTime.Now.ToString("dd.MM.yyyy"))
                    {
                        ListViewItem items3 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                        listView3.Items.Insert(0, items3);
                    }

                    if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(+1).ToShortDateString()))
                    {
                        ListViewItem items4 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                        listView4.Items.Insert(0, items4);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (listView1.Items.Count != 0)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        int CursorsX = Cursor.Position.X;
                        int CursorsY = Cursor.Position.Y;

                        Point ptLowerLeft = new Point(10, CursorsY - 70);
                        ptLowerLeft = listView1.PointToScreen(ptLowerLeft);
                        contextMenuStrip1.Show(ptLowerLeft);
                    }

                    XDocument xDoc = new XDocument();
                    XElement XNomenklaturaElement = new XElement("Nomeklatura");

                    for (int i = 0; i < this.listView1.Items.Count; i++)
                    {
                        XElement XTovar = new XElement("Tovar");

                        XAttribute TovarNameAttribute = new XAttribute("Name", listView1.Items[i].SubItems[0].Text);
                        XElement DateElement = new XElement("Date", listView1.Items[i].SubItems[1].Text);

                        XTovar.Add(TovarNameAttribute);
                        XTovar.Add(DateElement);
                        XNomenklaturaElement.Add(XTovar);
                    }

                    xDoc.Add(XNomenklaturaElement);
                    xDoc.Save(label3.Text);

                    listView1.Items.Clear();
                    listView2.Items.Clear();
                    listView3.Items.Clear();
                    listView4.Items.Clear();

                    XmlDocument xDoc1 = new XmlDocument();

                    xDoc1.Load(label3.Text);

                    XmlElement xRoot1 = xDoc1.DocumentElement;
                    foreach (XmlNode xnode in xRoot1)
                    {
                        if (xnode.Attributes.Count > 0)
                        {
                            XmlNode attr = xnode.Attributes.GetNamedItem("Name");
                            foreach (XmlNode childNode in xnode.ChildNodes)
                            {
                                if (childNode.Name == "Date")
                                {
                                    ListViewItem item = new ListViewItem(new string[] { attr.Value, childNode.InnerText }, 0);
                                    this.listView1.Items.Add(item);
                                }
                            }
                        }
                    }

                    for (int IndexCount = 0; IndexCount < listView1.Items.Count; IndexCount++)
                    {
                        if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(-1).ToShortDateString()))
                        {
                            ListViewItem items2 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                            listView2.Items.Insert(0, items2);
                        }

                        if (listView1.Items[IndexCount].SubItems[1].Text == DateTime.Now.ToString("dd.MM.yyyy"))
                        {
                            ListViewItem items3 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                            listView3.Items.Insert(0, items3);
                        }

                        if (listView1.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(+1).ToShortDateString()))
                        {
                            ListViewItem items4 = new ListViewItem(new string[] { listView1.Items[IndexCount].SubItems[0].Text }, 0);
                            listView4.Items.Insert(0, items4);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items[Convert.ToInt32(label8.Text)].Remove();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label8.Text = listView1.FocusedItem.Index.ToString();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            FormMsg fMsg = new FormMsg();

            if (this.WindowState == FormWindowState.Minimized)
            {

                if (label9.Text == "0")
                {
                    label9.Text = "1";
                    fMsg.ShowDialog();
                }
            }
        }
    }
}
