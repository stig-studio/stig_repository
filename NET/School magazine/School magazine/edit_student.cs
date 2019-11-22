using School_magazine.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace School_magazine {

    public partial class edit_student : Form {

        private int id;
        Student st;

        public edit_student() {
            InitializeComponent();
        }

        public edit_student( int id ) {

            this.id = id;

            InitializeComponent();
        }

        private void edit_student_Load( object sender, EventArgs e ) {

            sql_data.get_classes_with_id();

            cmb_classes.DataSource = sql_data.data_set_classes.Tables["classes"];
            cmb_classes.DisplayMember = "class_name";
            cmb_classes.ValueMember = "id";

            st = sql_data.get_studet_by_id( id );

            txtb_last_name.Text = st.last_name;
            txtb_first_name.Text = st.first_name;
            txtb_patr_name.Text = st.patr_name;
            txtb_dob.Text = st.dob;
            txtb_mother.Text = st.mother;
            txtb_mother_phone.Text = st.mother_phone;
            txtb_father.Text = st.father;
            txtb_father_phone.Text = st.father_phone;
            pic_photo.Image = st.photo;
            txtb_addr.Text = st.addr;
            txtb_phone.Text = st.phone;
            cmb_classes.SelectedValue = st.class_id;

            lbl_error.Text = "";
        }

        private void btn_photo_choise_Click( object sender, EventArgs e ) {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();

            if ( dialog.FileName != "") {

                FileInfo img_Info = new FileInfo( dialog.FileName );
                File.Copy( dialog.FileName, Environment.CurrentDirectory + $@"\{ img_Info.Name }", true );

                this.txtb_photo.Text = Environment.CurrentDirectory + $@"\{ img_Info.Name }";
                pic_photo.Image = Image.FromFile( dialog.FileName );
            }

        }

        private void dtp_dob_ValueChanged( object sender, EventArgs e ) {
            txtb_dob.Text = dtp_dob.Value.ToString( "dd.MM.yyyy" );
        }

        private void btn_edit_Click( object sender, EventArgs e ) {

            if( txtb_last_name.Text == "" ) {

                lbl_error.Text = @"Поле ""фамилия"" не можеть быть пустым";
                return;
            }

            if( txtb_first_name.Text == "" ) {

                lbl_error.Text = @"Поле ""имя"" не можеть быть пустым";
                return;
            }

            if( txtb_patr_name.Text == "" ) {

                lbl_error.Text = @"Поле ""отчество"" не можеть быть пустым";
                return;
            }

            if( txtb_dob.Text == "" ) {

                lbl_error.Text = @"Поле ""дата рождения"" не можеть быть пустым";
                return;
            }

            if( txtb_dob.Text == "" ) {

                lbl_error.Text = @"Поле ""дата рождения"" не можеть быть пустым";
                return;
            }

            if( cmb_classes.SelectedIndex == -1 ) {

                lbl_error.Text = @"Не выбран класс";
                return;
            }
            
            byte[] img_bytes = null;

            if ( txtb_photo.Text != "" ) {

                FileInfo file = new FileInfo( this.txtb_photo.Text );

                if( file.Exists ) {

                    using (  FileStream stream = file.Open( FileMode.Open ) ) {

                        using ( BinaryReader reader = new BinaryReader( stream ) ) {
                            img_bytes = reader.ReadBytes( ( int ) file.Length );
                        }
                    }
                    File.Delete( txtb_photo.Text );
                }
            }
            
            st.last_name = txtb_last_name.Text;
            st.first_name = txtb_first_name.Text;
            st.patr_name = txtb_patr_name.Text;
            st.dob = txtb_dob.Text;
            st.mother = txtb_mother.Text;
            st.mother_phone = txtb_mother_phone.Text;
            st.father = txtb_father.Text;
            st.father_phone = txtb_father_phone.Text;
            st.bytes_photo = ( img_bytes != null ) ? img_bytes : st.bytes_photo;
            st.addr = txtb_addr.Text;
            st.phone = txtb_phone.Text;
            st.class_id = ( int )cmb_classes.SelectedValue;

            string res = sql_data.update_student( st );

            if( res != "" ) lbl_error.Text = res;
            else this.Close();

        }
    }
}