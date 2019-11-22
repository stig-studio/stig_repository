using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace Local_LanSend
{
    public partial class AutherForm : Form
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

        public AutherForm()
        {
            InitializeComponent();

            this.MouseDown += delegate
            {
                this.Capture = false;
                var msg = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref msg);
            };
        }

        private void AutherForm_Load(object sender, EventArgs e)
        {
            string pathImage = Environment.CurrentDirectory;

            btnClose.Text = "";
            label5.Text = "";

            //pictureBox1.Image = Image.FromFile(pathImage + @"\Image\Contacts_24px.png");
            //btnClose.Image = Image.FromFile(pathImage + @"\Image\Delete_20px.png");
            //pictureBox2.Image = Image.FromFile(pathImage + @"\Image\Contacts_64px.png");
            //pictureBox3.Image = Image.FromFile(pathImage + @"\Image\Arrow_20px.png");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "")
                btnOK.Enabled = true;
            else
                btnOK.Enabled = false;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 20; i++)
            {

                if (comboBox1.Text == "kurator" + i.ToString() && textBox1.Text == "123" + i.ToString())
                {
                    File.AppendAllText("kurator", comboBox1.Text);
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Hide();
                    break;
                }
                else
                {
                    label5.Text = "Не правельный пароль";
                }
            }

            //MessageBox.Show("Введен не правельный пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text != "")
                {
                    for (int i = 0; i <= 20; i++)
                    {
                        if (comboBox1.Text == "kurator" + i.ToString() && textBox1.Text == "123" + i.ToString())
                        {
                            File.AppendAllText("kurator", comboBox1.Text);
                            Form1 f1 = new Form1();
                            f1.Show();
                            this.Hide();
                            break;
                        }
                        else
                        {
                            label5.Text = "Не правельный пароль";
                        }
                    }
                }
            }
        }
    }
}
