using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dz_grb {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private void scroll_Scroll( object sender, ScrollEventArgs e ) {

            lbl_red.Text = scroll_red.Value.ToString();
            lbl_green.Text = scroll_green.Value.ToString();
            lbl_blue.Text = scroll_blue.Value.ToString();

            panel_res_rgb.BackColor = Color.FromArgb( scroll_red.Value, scroll_green.Value, scroll_blue.Value );

        }
    }
}