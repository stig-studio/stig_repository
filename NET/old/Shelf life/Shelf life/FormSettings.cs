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

namespace Shelf_life
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            string pathImage = Environment.CurrentDirectory;

            try
            {
                pictureBox1.Image = Image.FromFile(pathImage + @"\Image\logoSettings.png");
                button1.Image = Image.FromFile(pathImage + @"\Image\right.png");

                StreamReader strReader = new StreamReader("pathFile");
                textBox1.Text = Convert.ToString(strReader.ReadToEnd());
                strReader.Close();
            }
            catch (Exception ex)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                this.textBox1.Text = Path.GetDirectoryName(openFileDialog1.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.AppendAllText("pathFile", textBox1.Text);
            Application.Restart();
        }
    }
}
