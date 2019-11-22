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

    public partial class add_subj_for_journal : Form {

        private int class_id;

        public add_subj_for_journal() {
            InitializeComponent();
        }

        public add_subj_for_journal( int class_id, string class_name ) {

            InitializeComponent();

            lbl_error.Text = "";

            this.class_id = class_id;
            lbl_class_value.Text = class_name;

            sql_data.get_subjects_data();

            cmb_subj.DataSource = sql_data.data_set_subjects.Tables["subjects"];
            cmb_subj.DisplayMember = "name";
            cmb_subj.ValueMember = "id";
            cmb_subj.SelectedIndex = -1;

        }

        private void btn_add_Click( object sender, EventArgs e ) {

            if( cmb_subj.SelectedIndex == -1 ) {

                lbl_error.Text = "Не выбран предмет";
                return;
            }

            string res = sql_data.add_subj_for_journal( class_id, ( int )cmb_subj.SelectedValue );

            if( res != "" ) lbl_error.Text = res;
            else this.Close();

        }
    }
}