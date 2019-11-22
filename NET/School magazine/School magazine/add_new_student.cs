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

    public partial class add_new_student : Form {

        public add_new_student() {
            InitializeComponent();
        }
        
        private void add_new_student_Load( object sender, EventArgs e ) {

            sql_data.get_classes_with_id();
            
            cmb_classes.DataSource = sql_data.data_set_classes.Tables["classes"];
            cmb_classes.DisplayMember = "class_name";
            cmb_classes.ValueMember = "id";

            cmb_classes.SelectedIndex = -1;

            lbl_error.Text = "";

        }

        private void btn_add_Click( object sender, EventArgs e ) {

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

            FileInfo file = new FileInfo( this.txtb_photo.Text );

            byte[] img_bytes = null;

            if( txtb_photo.Text != "" ) {

                if( file.Exists ) {

                    using (  FileStream stream = file.Open( FileMode.Open ) ) {

                        using ( BinaryReader reader = new BinaryReader( stream ) ) {
                            img_bytes = reader.ReadBytes( ( int ) file.Length );
                        }
                    }
                }
            }

            File.Delete( txtb_photo.Text );

            Student student = new Student {

                last_name = txtb_last_name.Text,
                first_name = txtb_first_name.Text,
                patr_name = txtb_patr_name.Text,
                dob = txtb_dob.Text,
                mother = txtb_mother.Text,
                mother_phone = txtb_mother_phone.Text,
                father = txtb_father.Text,
                father_phone = txtb_father_phone.Text,
                bytes_photo = img_bytes,
                addr = txtb_addr.Text,
                phone = txtb_phone.Text,
                class_id = ( int )cmb_classes.SelectedValue

            };

            string res = sql_data.add_student( student );

            if( res != "" ) lbl_error.Text = res;
            else this.Close();

        }

        private void dtp_dob_ValueChanged( object sender, EventArgs e ) {
            txtb_dob.Text = dtp_dob.Value.ToString( "dd.MM.yyyy" );
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
    }
}