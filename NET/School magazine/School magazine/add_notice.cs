using School_magazine.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace School_magazine {

    public partial class add_notice : Form {

        int id;

        public add_notice() {
            InitializeComponent();
        }

        public add_notice( int id ) {

            InitializeComponent();

            this.id = id;

        }

        private void btn_add_Click( object sender, EventArgs e ) {

            string res = sql_data.add_notice( this.txtb_title.Text, this.txtb_text_notice.Text, id );

            if( res != "" ) this.lbl_error.Text = res;
            else this.Close();

        }

        private void add_notice_Load( object sender, EventArgs e ) {
            this.lbl_error.Text = "";
        }
    }
}
