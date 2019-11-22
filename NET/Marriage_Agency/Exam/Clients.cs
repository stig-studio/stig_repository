using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Exam {

    public partial class Clients : Form {
        
        public Clients() {
            InitializeComponent();
        }

        private void Clients_Load(object sender, EventArgs e) {

            b_source_clients.DataSource = data_bind.clients_list;
            data_grid_clients.DataSource = b_source_clients;

        }

        private void btn_add_client_Click( object sender, EventArgs e ) {

            StringBuilder builder = new StringBuilder();

            if ( txtb_surname.Text == "" )
                builder.Append( "Не заполнено поле *Фамилия\n" );
            if ( txtb_first_name.Text == "" )
                builder.Append( "Не заполнено поле *Имя\n" );
            if ( txtb_p_name.Text == "" )
                builder.Append( "Не заполнено поле *Отчество\n" );
            if ( dob_picker.Value >= DateTime.Now || ( DateTime.Now.Year - dob_picker.Value.Year ) < 18 )
                builder.Append( "Клиент не совершеннолетний\n" );
            if ( txtb_country.Text == "" )
                builder.Append( "Не заполнено поле *Страна\n" );
            if ( txtb_city.Text == "" )
                builder.Append( "Не заполнено поле *Город\n" );

            if ( builder.Length > 0 )
                MessageBox.Show( builder.ToString(), "!", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
            else {

                string f_name = txtb_surname.Text + " " + txtb_first_name.Text + " " + txtb_p_name.Text;

                Client client = new Client( f_name, dob_picker.Value.ToLongDateString(), cmb_sex.Text, txtb_country.Text, txtb_city.Text, Convert.ToDouble( numeric_height.Value ), Convert.ToDouble( numeric_weight.Value ), ( color_hair )cmb_color_hair.SelectedIndex, ( color_eye )cmb_color_eye.SelectedIndex );

                data_bind.clients_list.Add( client );

                txtb_surname.Text = "";
                txtb_first_name.Text = "";
                txtb_p_name.Text = "";

                dob_picker.Value = DateTime.Now;
                txtb_country.Text = "";
                txtb_city.Text = "";
                cmb_sex.SelectedIndex = 0;
                numeric_height.Value = 160;
                numeric_weight.Value = 50;
                cmb_color_hair.SelectedIndex = 0;
                cmb_color_eye.SelectedIndex = 0;

            }
        }

        private void btn_close_panel_Click( object sender, EventArgs e ) {
            panel_client.Visible = false;
        }
        
        private void btn_save_Click( object sender, EventArgs e ) {

            if( data_bind.clients_list.Count == 0 ) {
                MessageBox.Show( "Нет данных для записи в файл", "Запись в файл", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            save_file_dialog.Filter = "xml file (*.xml)|*.xml";
            save_file_dialog.FileName = "";

            if ( save_file_dialog.ShowDialog() == DialogResult.OK ) {

                if ( save_file_dialog.FileName != "" )
                    data_bind.save( save_file_dialog.FileName );
                else
                    MessageBox.Show( "Не указано название файла", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void btn_add_Click( object sender, EventArgs e ) {

            if ( panel_add_client.Visible == false ) {

                cmb_sex.SelectedIndex = 0;

                panel_add_client.Visible = true;

                cmb_color_hair.Items.Clear();

                foreach (var item in Enum.GetValues(typeof(color_hair)))
                    cmb_color_hair.Items.Add(item.ToString());

                cmb_color_hair.SelectedIndex = 0;

                cmb_color_eye.Items.Clear();

                foreach (var item in Enum.GetValues(typeof(color_eye)))
                    cmb_color_eye.Items.Add(item.ToString());

                cmb_color_eye.SelectedIndex = 0;
            }
            else panel_add_client.Visible = false;
        }

        private void btn_load_Click( object sender, EventArgs e ) {

            open_file_dialog.Filter = "xml files (*.xml) |*.xml|All files ( *.* )|*.*";
            open_file_dialog.FileName = "";

            if ( open_file_dialog.ShowDialog() == DialogResult.OK ) {
                if (open_file_dialog.FileName != "") {
                    data_bind.load(open_file_dialog.FileName);
                    data_grid_clients.DataSource = data_bind.clients_list;
                }
                else MessageBox.Show("Не указано название файла", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void del_tool_strip_Click( object sender, EventArgs e ) {
            if( MessageBox.Show( "Вы действительно хотите удалить клиента?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes )
                data_grid_clients.Rows.RemoveAt( data_grid_clients.CurrentRow.Index );
        }

        private void data_grid_clients_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e ) {

            if (e.Button == MouseButtons.Right) {

                int pos_x = Cursor.Position.X;
                int pos_y = Cursor.Position.Y;

                context_menu_strip.Show( pos_x, pos_y );

            }
            else if( e.Button == MouseButtons.Left ) {

                panel_client.Visible = true;

                lbl_fio_val.Text = data_grid_clients.SelectedCells[0].Value.ToString();
                lbl_dob_value.Text = data_grid_clients.SelectedCells[1].Value.ToString();
                lbl_sex_val.Text = data_grid_clients.SelectedCells[2].Value.ToString();
                lbl_country_val.Text = data_grid_clients.SelectedCells[3].Value.ToString();
                lbl_city_val.Text = data_grid_clients.SelectedCells[4].Value.ToString();
                lbl_height_val.Text = data_grid_clients.SelectedCells[5].Value.ToString();
                lbl_weight_val.Text = data_grid_clients.SelectedCells[6].Value.ToString();
                lbl_hair_val.Text = data_grid_clients.SelectedCells[7].Value.ToString();
                lbl_eye_val.Text = data_grid_clients.SelectedCells[8].Value.ToString();

                int month = DateTime.Parse(lbl_dob_value.Text).Month;
                int day = DateTime.Parse(lbl_dob_value.Text).Day;
                string img = "";

                switch (month) {
                    case 1: img = (day <= 20) ? "козерог" : "водолей"; break;
                    case 2: img = (day <= 19) ? "водолей" : "рыбы"; break;
                    case 3: img = (day <= 21) ? "рыбы" : "овен"; break;
                    case 4: img = (day <= 20) ? "овен" : "телец"; break;
                    case 5: img = (day <= 21) ? "телец" : "близнецы"; break;
                    case 6: img = (day <= 22) ? "близнецы" : "рак"; break;
                    case 7: img = (day <= 23) ? "рак" : "лев"; break;
                    case 8: img = (day <= 23) ? "лев" : "дева"; break;
                    case 9: img = (day <= 24) ? "дева" : "весы"; break;
                    case 10: img = (day <= 23) ? "весы" : "скорпион"; break;
                    case 11: img = (day <= 23) ? "скорпион" : "стрелец"; break;
                    case 12: img = (day <= 22) ? "стрелец" : "козерог"; break;
                }
                pic_zodiac.Image = Image.FromFile(Environment.CurrentDirectory + $@"\img\{img}.jpg");
                lbl_zodiac_val.Text = img;
            }
        }

        private void country_tool_strip_Click( object sender, EventArgs e ) {

            foreach ( Control item in panel_search.Controls ) {
                if ( item.Name != "btn_close_panel_search" )
                    panel_search.Controls.Remove( item );
            }

            if ( panel_search.Visible == false ) panel_search.Visible = true;

            Label lbl_search = new Label() {
                Name = "lbl_search",
                AutoSize = true,
                Location = new Point( 17, 53 ),
                Text = "Страна:"
            };

            panel_search.Controls.Add( lbl_search );

            TextBox txt_country = new TextBox() {
                Name = "txt_country",
                Width = 200,
                Height = 14,
                Location = new Point( lbl_search.Location.X + lbl_search.Width + 10, lbl_search.Location.Y )
            };

            panel_search.Controls.Add( txt_country );

            Button btn_find = new Button() {
                Name = "btn_find",
                Width = 100,
                Text = "Найти",
                Location = new Point( txt_country.Location.X + txt_country.Width - 99, txt_country.Location.Y + 30 ),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btn_find.FlatAppearance.BorderSize = 0;

            panel_search.Controls.Add( btn_find );

            btn_find.Click += btn_find_Click;

        }

        private void btn_find_Click( object sender, EventArgs e ) {

            string search_by = "";
            string txt_search = "";

            foreach (Control item in panel_search.Controls) {

                if ( item.Name == "txt_country" ) {
                    txt_search = item.Text;
                    search_by = "country";
                    break;
                }
                else if ( item.Name == "txt_city" ) {
                    txt_search = item.Text;
                    search_by = "city";
                    break;
                }
                else if ( item.Name == "numeric_h") {
                    txt_search = item.Text;
                    search_by = "height";
                    break;
                }
                else if ( item.Name == "numeric_w" ) {
                    txt_search = item.Text;
                    search_by = "weight";
                    break;
                }
                else if ( item.Name == "cmb_c_h" ) {
                    txt_search = item.Text;
                    search_by = "hair";
                    break;
                }
                else if ( item.Name == "cmb_c_e" ) {
                    txt_search = item.Text;
                    search_by = "eye";
                    break;
                }
                else if( item.Name == "cmb_img" ) {
                    txt_search = item.Text;
                    search_by = "zodiac";
                    break;
                }
            }

            if (txt_search == "" || txt_search == null) {
                MessageBox.Show("Не выбрано значение для поиска!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IEnumerable<Client> res = null;

            if ( search_by == "country" ) {
                res = from list in data_bind.clients_list
                      where list.country == txt_search
                      select list;
            }
            else if ( search_by == "city" ) {
                res = from list in data_bind.clients_list
                      where list.city == txt_search
                      select list;
            }
            else if ( search_by == "height" ) {
                res = from list in data_bind.clients_list
                      where list.height == Convert.ToDouble( txt_search )
                      select list;
            }
            else if ( search_by == "weight" ) {
                res = from list in data_bind.clients_list
                      where list.weight == Convert.ToDouble( txt_search )
                      select list;
            }
            else if ( search_by == "hair" ) {
                res = from list in data_bind.clients_list
                      where list.hair == ( color_hair )Enum.Parse( typeof( color_hair ), txt_search )
                      select list;
            }
            else if ( search_by == "eye" ) {
                res = from list in data_bind.clients_list
                      where list.eye == ( color_eye )Enum.Parse( typeof( color_eye ), txt_search )
                      select list;
            }
            else if ( search_by == "zodiac" ) {
                res = from list in data_bind.clients_list
                      where list.get_zodiac() == txt_search
                      select list;
            }

            if (res.Count() > 0) {

                BindingList<Client> res_list = new BindingList<Client>();

                foreach ( Client item in res ) {
                    res_list.Add( item );
                }

                data_grid_clients.DataSource = res_list;
            }
            else MessageBox.Show( "По вашему запросу ничего не найдено!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
        }

        private void city_tool_strip_Click( object sender, EventArgs e ) {

            foreach ( Control item in panel_search.Controls ) {
                if ( item.Name != "btn_close_panel_search" )
                    panel_search.Controls.Remove( item );
            }

            if ( panel_search.Visible == false ) panel_search.Visible = true;

            Label lbl_search = new Label() {
                Name = "lbl_search",
                AutoSize = true,
                Location = new Point( 17, 53 ),
                Text = "Город:"
            };

            panel_search.Controls.Add( lbl_search );

            TextBox txt_city = new TextBox() {
                Name = "txt_city",
                Width = 200,
                Height = 14,
                Location = new Point( lbl_search.Location.X + lbl_search.Width + 10, lbl_search.Location.Y )
            };

            panel_search.Controls.Add( txt_city );

            Button btn_find = new Button() {
                Name = "btn_find",
                Width = 100,
                Text = "Найти",
                Location = new Point( txt_city.Location.X + txt_city.Width - 99, txt_city.Location.Y + 30 ),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btn_find.FlatAppearance.BorderSize = 0;

            panel_search.Controls.Add( btn_find );

            btn_find.Click += btn_find_Click;
        }

        private void btn_update_list_Click( object sender, EventArgs e ) {
            data_grid_clients.DataSource = data_bind.clients_list;
        }

        private void button1_Click( object sender, EventArgs e ) {

            foreach ( Control item in panel_search.Controls ) {
                if ( item.Name != "btn_close_panel_search" )
                    panel_search.Controls.Remove( item );
            }
            panel_search.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e) {
            panel_search.Controls.Clear();
            panel_search.Visible = false;
        }

        private void height_tool_strip_Click( object sender, EventArgs e ) {

            foreach (Control item in panel_search.Controls) {
                if (item.Name != "btn_close_panel_search")
                    panel_search.Controls.Remove(item);
            }

            if ( panel_search.Visible == false ) panel_search.Visible = true;

            Label lbl_search = new Label() {
                Name = "lbl_search",
                AutoSize = true,
                Location = new Point(17, 53),
                Text = "Рост:"
            };

            panel_search.Controls.Add( lbl_search );

            NumericUpDown numeric_h = new NumericUpDown() {
                Name = "numeric_h",
                Width = 200,
                Height = 14,
                Minimum = 85,
                Maximum = 250,
                Value = 160,
                Location = new Point(lbl_search.Location.X + lbl_search.Width + 10, lbl_search.Location.Y)
            };

            panel_search.Controls.Add( numeric_h );

            Button btn_find = new Button()
            {
                Name = "btn_find",
                Width = 100,
                Text = "Найти",
                Location = new Point( numeric_h.Location.X + numeric_h.Width - 99, numeric_h.Location.Y + 30),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btn_find.FlatAppearance.BorderSize = 0;

            panel_search.Controls.Add( btn_find) ;

            btn_find.Click += btn_find_Click;
        }

        private void weight_tool_strip_Click( object sender, EventArgs e ) {

            foreach (Control item in panel_search.Controls) {
                if (item.Name != "btn_close_panel_search")
                    panel_search.Controls.Remove(item);
            }

            if ( panel_search.Visible == false ) panel_search.Visible = true;

            Label lbl_search = new Label() {
                Name = "lbl_search",
                AutoSize = true,
                Location = new Point( 17, 53 ),
                Text = "Вес:"
            };

            panel_search.Controls.Add( lbl_search );

            NumericUpDown numeric_w = new NumericUpDown() {
                Name = "numeric_w",
                Width = 200,
                Height = 14,
                Minimum = 35,
                Maximum = 250,
                Value = 50,
                Location = new Point( lbl_search.Location.X + lbl_search.Width + 10, lbl_search.Location.Y )
            };

            panel_search.Controls.Add( numeric_w );

            Button btn_find = new Button() {
                Name = "btn_find",
                Width = 100,
                Text = "Найти",
                Location = new Point( numeric_w.Location.X + numeric_w.Width - 99, numeric_w.Location.Y + 30 ),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btn_find.FlatAppearance.BorderSize = 0;

            panel_search.Controls.Add( btn_find );

            btn_find.Click += btn_find_Click;

        }

        private void hair_tool_strip_Click( object sender, EventArgs e ) {

            foreach (Control item in panel_search.Controls) {
                if (item.Name != "btn_close_panel_search")
                    panel_search.Controls.Remove(item);
            }

            if ( panel_search.Visible == false ) panel_search.Visible = true;

            Label lbl_search = new Label() {
                Name = "lbl_search",
                AutoSize = true,
                Location = new Point( 17, 53 ),
                Text = "Цвет волос:"
            };

            panel_search.Controls.Add( lbl_search );

            ComboBox cmb_c_h = new ComboBox() {
                Name = "cmb_c_h",
                Width = 200,
                Height = 14,
                Location = new Point( lbl_search.Location.X + lbl_search.Width + 10, lbl_search.Location.Y )
            };

            foreach ( var item in Enum.GetValues( typeof( color_hair ) ) )
                cmb_c_h.Items.Add( item.ToString() );

            cmb_c_h.SelectedIndex = 0;

            panel_search.Controls.Add( cmb_c_h );

            Button btn_find = new Button() {
                Name = "btn_find",
                Width = 100,
                Text = "Найти",
                Location = new Point( cmb_c_h.Location.X + cmb_c_h.Width - 99, cmb_c_h.Location.Y + 30 ),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btn_find.FlatAppearance.BorderSize = 0;

            panel_search.Controls.Add( btn_find );

            btn_find.Click += btn_find_Click;

        }

        private void eye_tool_strip_Click( object sender, EventArgs e ) {

            foreach (Control item in panel_search.Controls) {
                if (item.Name != "btn_close_panel_search")
                    panel_search.Controls.Remove(item);
            }

            if ( panel_search.Visible == false ) panel_search.Visible = true;

            Label lbl_search = new Label() {
                Name = "lbl_search",
                AutoSize = true,
                Location = new Point( 17, 53 ),
                Text = "Цвет глаз:"
            };

            panel_search.Controls.Add( lbl_search );

            ComboBox cmb_c_e = new ComboBox() {
                Name = "cmb_c_e",
                Width = 200,
                Height = 14,
                Location = new Point( lbl_search.Location.X + lbl_search.Width + 10, lbl_search.Location.Y )
            };

            foreach ( var item in Enum.GetValues( typeof( color_eye ) ) )
                cmb_c_e.Items.Add( item.ToString() );

            cmb_c_e.SelectedIndex = 0;

            panel_search.Controls.Add( cmb_c_e );

            Button btn_find = new Button() {
                Name = "btn_find",
                Width = 100,
                Text = "Найти",
                Location = new Point( cmb_c_e.Location.X + cmb_c_e.Width - 99, cmb_c_e.Location.Y + 30 ),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btn_find.FlatAppearance.BorderSize = 0;

            panel_search.Controls.Add( btn_find );

            btn_find.Click += btn_find_Click;

        }

        private void btn_close_panel_search_Click(object sender, EventArgs e) {
            
            foreach( Control item in panel_search.Controls ) {
                if ( item.Name != "btn_close_panel_search" )
                    panel_search.Controls.Remove( item );
            }

            panel_search.Visible = false;
        }

        private void zodiac_tool_strip_Click(object sender, EventArgs e) {

            foreach ( Control item in panel_search.Controls ) {
                if ( item.Name != "btn_close_panel_search" )
                    panel_search.Controls.Remove( item );
            }

            if ( panel_search.Visible == false ) panel_search.Visible = true;

            ComboBox cmb_img = new ComboBox() {
                Name = "cmb_img",
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point( 35, 25 )
            };
            
            foreach ( string file in Directory.GetFiles( Environment.CurrentDirectory + @"\img\", "*.jpg", SearchOption.TopDirectoryOnly ) ) {
                cmb_img.Items.Add( Path.GetFileNameWithoutExtension( file ) );
            }

            cmb_img.SelectedIndexChanged += Cmb_img_SelectedIndexChanged;
            cmb_img.SelectedIndex = 0;

            panel_search.Controls.Add( cmb_img );

            PictureBox p_zod = new PictureBox() {
                Name = "p_zod",
                Width = 100,
                Height = 100,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point( cmb_img.Location.X - 10, 50 )
            };

            p_zod.Image = Image.FromFile( Environment.CurrentDirectory + $@"\img\{cmb_img.Items[0]}.jpg" );

            panel_search.Controls.Add( p_zod );

            Button btn_find = new Button() {
                Name = "btn_find",
                Width = 100,
                Text = "Найти",
                Location = new Point( cmb_img.Location.X + 99, p_zod.Location.Y + 78 ),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btn_find.FlatAppearance.BorderSize = 0;

            panel_search.Controls.Add( btn_find );

            btn_find.Click += btn_find_Click;
        }

        private void Cmb_img_SelectedIndexChanged( object sender, EventArgs e ) {

            int ind = (sender as ComboBox).SelectedIndex;

            foreach( Control item in panel_search.Controls ) {
                if( item.Name == "p_zod" ) {
                    (item as PictureBox).Image = Image.FromFile(Environment.CurrentDirectory + $@"\img\{( sender as ComboBox ).Items[ind]}.jpg");
                    break;
                }
            }
        }

        private void panel_client_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}