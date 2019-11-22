using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exam {

    public partial class main_form : Form {

        public main_form() {
            InitializeComponent();
        }

        private void client_list_tool_strip_Click(object sender, EventArgs e) {

            Clients clients = new Clients {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            clients.Show();
        }

        private void about_tool_strip_Click( object sender, EventArgs e ) {
            About about = new About();
            about.Show();
        }

        private void exit_tool_strip_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void main_form_KeyDown(object sender, KeyEventArgs e) {
            if ( e.KeyCode == Keys.F11 ) this.WindowState = FormWindowState.Maximized;
        }
    }
}