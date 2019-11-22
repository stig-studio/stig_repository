using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Shelf_life
{
    public partial class FormMsg : Form
    {
        public FormMsg()
        {
            InitializeComponent();
        }

        private void FormMsg_Load(object sender, EventArgs e)
        {
            label4.Text = "";
            string pathImage = Environment.CurrentDirectory;

            try
            {
            
                button1.Text = "";

                button1.Image = Image.FromFile(pathImage + @"\Image\Close1.png");

                this.StartPosition = FormStartPosition.Manual;
                Size sz = SystemInformation.PrimaryMonitorSize;
                this.Location = new Point(sz.Width - this.Width, (sz.Height - 45) - this.Height);

                string pathFile;

                StreamReader strReader = new StreamReader("pathFile");
                pathFile = Convert.ToString(strReader.ReadToEnd());
                strReader.Close();

                listView1.Items.Clear();
                listView2.Items.Clear();
                listView3.Items.Clear();
                listView4.Items.Clear();

                XmlDocument xDoc = new XmlDocument();

                xDoc.Load(pathFile + @"\List of Products.xml");

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
                                this.listView4.Items.Add(item);
                            }
                        }
                    }
                }

                for (int IndexCount = 0; IndexCount < listView4.Items.Count; IndexCount++)
                {
                    if (listView4.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(-1).ToShortDateString()))
                    {
                        ListViewItem items1 = new ListViewItem(new string[] { listView4.Items[IndexCount].SubItems[0].Text }, 0);
                        listView1.Items.Insert(0, items1);
                    }

                    if (listView4.Items[IndexCount].SubItems[1].Text == DateTime.Now.ToString("dd.MM.yyyy"))
                    {
                        ListViewItem items2 = new ListViewItem(new string[] { listView4.Items[IndexCount].SubItems[0].Text }, 0);
                        listView2.Items.Insert(0, items2);
                    }

                    if (listView4.Items[IndexCount].SubItems[1].Text == Convert.ToString(DateTime.Now.AddDays(+1).ToShortDateString()))
                    {
                        ListViewItem items3 = new ListViewItem(new string[] { listView4.Items[IndexCount].SubItems[0].Text }, 0);
                        listView3.Items.Insert(0, items3);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.f1.label9.Text = "0";
            this.Close();
        }
    }
}
