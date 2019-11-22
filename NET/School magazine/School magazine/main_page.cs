using School_magazine.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace School_magazine {

    public partial class main_page : Form {

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        protected override CreateParams CreateParams {

            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public main_page() {

            this.SetStyle( ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true );
            this.UpdateStyles();

            InitializeComponent();
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void main_page_Load( object sender, EventArgs e ) {

            subjects_list.AutoResizeColumns( ColumnHeaderAutoResizeStyle.HeaderSize );

            timer_date_time.Start();
            timer_check_notice.Start();

            upload_notice_list();

            upload_schedule_for_today();

            upload_user_notes();

            this.lbl_date.Text = DateTime.Now.ToString( "dd.MM.yyyy" ); 
            this.lbl_time.Text = DateTime.Now.ToString( "HH:mm:ss" );
            
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void timer_date_time_Tick( object sender, EventArgs e ) {

            this.lbl_date.Text = DateTime.Now.ToString( "dd.MM.yyyy" ); 
            this.lbl_time.Text = DateTime.Now.ToString( "HH:mm:ss" ); 
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void main_page_FormClosing( object sender, FormClosingEventArgs e ) {
            
            sql_data.save_user_notes( txtb_user_note.Text );
            Application.Exit();
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_home_Click( object sender, EventArgs e ) {
            
            this.tab_panel.SelectTab( 0 );

            upload_notice_list();

            upload_schedule_for_today();

            upload_user_notes();
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_employees_Click( object sender, EventArgs e ) {

            upload_employees_list();

            this.tab_panel.SelectTab( 1 );
   
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_sheduling_Click( object sender, EventArgs e ) {

            upload_tab_shedule();

            this.tab_panel.SelectTab( 4 );
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_classes_Click( object sender, EventArgs e ) {

            upload_classes_list();

            this.tab_panel.SelectTab( 2 );

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_students_Click( object sender, EventArgs e ) {

            sql_data.get_classes_with_id();

            cmb_classes.DataSource = sql_data.data_set_classes.Tables["classes"];
            cmb_classes.DisplayMember = "class_name";
            cmb_classes.ValueMember = "id";

            cmb_classes.SelectedIndex = -1;

            this.tab_panel.SelectTab( 3 );
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_add_employee_Click( object sender, EventArgs e ) {

            new_employee empl = new new_employee();
            empl.ShowDialog();
            
            upload_employees_list();

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public void upload_employees_list() {

            sql_data.get_employees();

            if( sql_data.data_set_employees.Tables["employees"].Rows.Count == 0 ) return;

            panel_empl_items.Visible = false;
            panel_empl_items.Controls.Clear();

            int ch = 1;

            foreach ( DataRow item in sql_data.data_set_employees.Tables["employees"].Rows ) {

                EmployeeItem empl = new EmployeeItem { Name = $"empl_item{ch}" };

                empl.lbl_full_name_val.Text = item["full_name"].ToString();
                empl.lbl_dob_val.Text = DateTime.Parse( item["dob"].ToString() ).ToString( "dd.MM.yyyy" );
                empl.lbl_empl_val.Text = DateTime.Parse( item["empl"].ToString() ).ToString( "dd.MM.yyyy" );
                empl.lbl_dism_val.Text = ( item["dism"].ToString() != "" ) ? DateTime.Parse( item["dism"].ToString() ).ToString( "dd.MM.yyyy" ) : "";

                byte[] bytes = ( byte[] )item["photo"];
                MemoryStream stream = new MemoryStream( bytes );

                empl.pic_photo.Image = new Bitmap( stream );
                empl.lbl_addr_val.Text = item["addr"].ToString();
                empl.lbl_phone_val.Text = item["phone"].ToString();
                empl.lbl_educ_val.Text = item["educ"].ToString();

                empl.btn_edit.Tag = item["id"];
                empl.btn_edit.Click += Btn_edit_Click;

                empl.btn_user.Tag = item["id"];
                empl.btn_user.Click += Btn_user_Click;

                panel_empl_items.Controls.Add( empl );

                empl.Dock = DockStyle.Top;

                ch++;

            }

            panel_empl_items.Visible = true;
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void Btn_user_Click( object sender, EventArgs e ) {

            user_info info = new user_info( Convert.ToInt32( ( sender as Button ).Tag ) );
            info.ShowDialog();

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void Btn_edit_Click( object sender, EventArgs e ) {
            
            edit_employee edit_f = new edit_employee( Convert.ToInt32( ( sender as Button ).Tag ) );
            edit_f.ShowDialog();

            upload_employees_list();
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_add_notice_Click( object sender, EventArgs e ) {

            if( session_parameters.current_user.employee_id == 0 ) {

                MessageBox.Show( "Вам запрещено создавать объявления", "School magazine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            add_notice notice = new add_notice( session_parameters.current_user.employee_id );
            notice.ShowDialog();

            upload_notice_list();

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void upload_notice_list() {

            sql_data.get_notices();

            panel_notice_items.Visible = false;

            panel_notice_items.Controls.Clear();

            int ch = 1;

            foreach ( DataRow row in sql_data.data_set_notices.Tables["notices"].Rows ) {

                NoticeItem item = new NoticeItem { Name = $"notice{ch}" };

                item.title.Text = row["title"].ToString();
                item.text_notice.Text = row["text_notice"].ToString();
                item.date_notice.Text = DateTime.Parse( row["date_notice"].ToString() ).ToString( "dd.MM.yyyy" );
                item.author.Text = row["full_name"].ToString();

                item.Dock = DockStyle.Top;
                panel_notice_items.Controls.Add( item );

                ch++;
            }

            panel_notice_items.Visible = true;
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_show_schedule_Click( object sender, EventArgs e ) {

            upload_tab_shedule();

            this.tab_panel.SelectTab( 4 );
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void upload_classes_list() {

            List<Class> classes = sql_data.get_classes();

            list_classes.Items.Clear();

            if( classes.Count > 0 ) {

                foreach ( Class c in classes ) {
                    this.list_classes.Items.Add( new ListViewItem( new string[] { c.class_name, c.classroom_teacher } ) );
                }
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_add_class_Click( object sender, EventArgs e ) {

            add_classes _add_class = new add_classes();
            _add_class.ShowDialog();

            upload_classes_list();

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void upload_tab_shedule() {

            sql_data.get_classes_with_id();

            cmb_class.DataSource = sql_data.data_set_classes.Tables["classes"];
            cmb_class.DisplayMember = "class_name";
            cmb_class.ValueMember = "id";

            sql_data.get_employees();

            cmb_teacher.DataSource = sql_data.data_set_employees.Tables["employees"];
            cmb_teacher.DisplayMember = "full_name";
            cmb_teacher.ValueMember = "id";

            cmb_teacher.Text = "";

            cmb_semestr.SelectedIndex = 0;

            list_panel_mon.AutoResizeColumns( ColumnHeaderAutoResizeStyle.HeaderSize );
            list_panel_tue.AutoResizeColumns( ColumnHeaderAutoResizeStyle.HeaderSize );
            list_panel_wed.AutoResizeColumns( ColumnHeaderAutoResizeStyle.HeaderSize );
            list_panel_thu.AutoResizeColumns( ColumnHeaderAutoResizeStyle.HeaderSize );
            list_panel_fri.AutoResizeColumns( ColumnHeaderAutoResizeStyle.HeaderSize );
            list_panel_sat.AutoResizeColumns( ColumnHeaderAutoResizeStyle.HeaderSize );
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void upload_schedule_for_today() {

            List<Subject> subjects = sql_data.get_schedule_by_employee( session_parameters.current_user.employee_id );

            this.subjects_list.Items.Clear();

            foreach ( Subject s in subjects ) {
                this.subjects_list.Items.Add( new ListViewItem ( new string[] { s.number.ToString(), s.name } ) );
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_get_schedule_Click( object sender, EventArgs e ) {

            int teacher = Convert.ToInt32( cmb_teacher.SelectedValue );

            sql_data.get_schedule( Convert.ToInt32( cmb_class.SelectedValue ), Convert.ToInt32( cmb_semestr.SelectedIndex + 1 ), teacher );

            list_panel_mon.Items.Clear();
            list_panel_tue.Items.Clear();
            list_panel_wed.Items.Clear();
            list_panel_thu.Items.Clear();
            list_panel_fri.Items.Clear();
            list_panel_sat.Items.Clear();

            foreach ( DataRow r in sql_data.data_set_schedule.Tables["schedule"].Rows ) {

                if( ( int )r["day_of_week"] == 1 )
                    list_panel_mon.Items.Add( new ListViewItem( new string[] { r["number"].ToString(), r["name"].ToString() } ) );
                else if( ( int )r["day_of_week"] == 2 )
                    list_panel_tue.Items.Add( new ListViewItem( new string[] { r["number"].ToString(), r["name"].ToString() } ) );
                else if( ( int )r["day_of_week"] == 3 )
                    list_panel_wed.Items.Add( new ListViewItem( new string[] { r["number"].ToString(), r["name"].ToString() } ) );
                else if( ( int )r["day_of_week"] == 4 )
                    list_panel_thu.Items.Add( new ListViewItem( new string[] { r["number"].ToString(), r["name"].ToString() } ) );
                else if( ( int )r["day_of_week"] == 5 )
                    list_panel_fri.Items.Add( new ListViewItem( new string[] { r["number"].ToString(), r["name"].ToString() } ) );
                else if( ( int )r["day_of_week"] == 6 )
                    list_panel_sat.Items.Add( new ListViewItem( new string[] { r["number"].ToString(), r["name"].ToString() } ) );
            }

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_settings_Click( object sender, EventArgs e ) {

            
            upload_const_value();
            lbl_error.Text = "";

            this.tab_panel.SelectTab( 5 );
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_subjects_Click( object sender, EventArgs e ) {

            upload_list_subjects();
            this.tab_panel.SelectTab( 6 );
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void upload_list_subjects() {

            list_subjects.Items.Clear();

            List<Subject> subjects = sql_data.get_subjects();

            foreach ( Subject s in subjects ) {
                list_subjects.Items.Add( new ListViewItem( new string[] { s.name } ) );
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_add_new_subj_Click( object sender, EventArgs e ) {

            add_subjects f = new add_subjects();
            f.ShowDialog();

            upload_list_subjects();

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_edit_schedule_Click( object sender, EventArgs e ) {

            add_subject_for_schedule f = new add_subject_for_schedule();
            f.ShowDialog();
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void upload_const_value() {

            sql_data.get_const_values();

            dgv_const.DataSource = sql_data.data_set_const.Tables["const"];

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_save_admin_Click( object sender, EventArgs e ) {

            foreach ( DataGridViewRow row in dgv_const.Rows ) {
                
                if( row.Cells[1].Value.GetType().ToString() != "System.DBNull" && row.Cells[2].Value.GetType().ToString() != "System.DBNull"
                    && row.Cells[1].Value != null && row.Cells[2].Value != null ) {

                    string res = sql_data.update_const_value(
                            
                            ( row.Cells[0].Value.GetType().ToString() != "System.DBNull" ) ? Convert.ToInt32( row.Cells[0].Value ) : 0,
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString()
                            
                        );

                    if ( res != "" ) { lbl_error.Text = res; break; }

                }
                else if( row.Cells[0].Value.GetType().ToString() != "System.DBNull" && row.Cells[0].Value != null ) {

                    string res = sql_data.delete_const_value( Convert.ToInt32( row.Cells[0].Value ) );

                    if ( res != "" ) { lbl_error.Text = res; break; }
                }
            }
            
            upload_const_value();
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void upload_user_notes() {
            txtb_user_note.Text = sql_data.get_notes(); ;
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_add_const_Click( object sender, EventArgs e ) {

            dgv_const.AllowUserToAddRows = !dgv_const.AllowUserToAddRows;

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_add_student_Click( object sender, EventArgs e ) {

            add_new_student f = new add_new_student();
            f.ShowDialog();

            upload_students_list();
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_students_filter_Click( object sender, EventArgs e ) {
            upload_students_list( ( cmb_classes.SelectedIndex == -1 ) ? 0 : ( int )cmb_classes.SelectedValue );
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void upload_students_list( int _class = 0 ) {

            int ch = 1;

            panel_students_items.Controls.Clear();

            DataTable tb = sql_data.get_students( Convert.ToInt32( cmb_classes.SelectedValue ) );

            lbl_panel_students_count.Text = $"Количество учеников: {tb.Rows.Count}";

            foreach ( DataRow r in tb.Rows ) {

                StudentItem st = new StudentItem {

                    Name = $"stud_item_{ch}",
                    Tag = ( int )r[0]

                };
                
                st.lbl_full_name_val.Text = r[1].ToString();
                st.lbl_dob_val.Text = DateTime.Parse( r[2].ToString() ).ToString( "dd.MM.yyyy" );
                st.lbl_mother_value.Text = r[3].ToString();
                st.lbl_mother_phone_value.Text = r[4].ToString();
                st.lbl_father_value.Text = r[5].ToString();
                st.lbl_father_phone_value.Text = r[6].ToString();

                byte[] bytes = ( byte[] )r["photo"];
                MemoryStream stream = new MemoryStream( bytes );

                st.pic_photo.Image = new Bitmap( stream );

                st.lbl_addr_value.Text = r[8].ToString();
                st.lbl_phone_value.Text = r[9].ToString();
                st.lbl_class_value.Text = r[10].ToString();
                st.btn_edit.Tag = ( int )r[0];
                st.btn_edit.Click += Btn_edit_Click1;
                st.Dock = DockStyle.Top;

                panel_students_items.Controls.Add( st );

                ch++;
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void Btn_edit_Click1( object sender, EventArgs e ) {

            edit_student f = new edit_student( ( int )( sender as Button ).Tag );
            f.ShowDialog();
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_journal_Click( object sender, EventArgs e ) {

            if( dgv_lesson.DataSource == null ) {

                sql_data.get_classes_with_id();

                cmb_panel_journal_classes.DataSource = sql_data.data_set_classes.Tables["classes"];
                cmb_panel_journal_classes.DisplayMember = "class_name";
                cmb_panel_journal_classes.ValueMember = "id";
                cmb_panel_journal_classes.SelectedIndex = -1;

                lbl_lesson_subj.Text = "";

            }
            
            tab_panel.SelectTab( 7 );
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_panel_journal_open_Click( object sender, EventArgs e ) {

            if( cmb_panel_journal_classes.SelectedIndex == -1 || cmb_pan_journal_subj.SelectedIndex == -1 ) return;

            if ( pan_lesson.Visible == true ) {

                pan_lesson.Visible = false;
                return;
            }

            pan_lesson.Visible = true;
            list_lessons.AutoResizeColumns( ColumnHeaderAutoResizeStyle.HeaderSize );

            list_lessons.Items.Clear();

            List<Lesson> lessons = sql_data.get_lessons( ( int )cmb_pan_journal_subj.SelectedValue );

            if( lessons.Count > 0 ) {

                foreach ( Lesson l in lessons ) {
                    list_lessons.Items.Add( new ListViewItem( new string[] { l.id.ToString(), l.subj_id.ToString(), l.subj_name, l.lesson_date, l.lesson_topic } ) );
                }
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void btn_find_Click( object sender, EventArgs e ) {

            if( txtb_find.Text == "" ) return;

            upload_finded_list();
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        private void upload_finded_list() {

            int ch = 1;

            panel_students_items.Controls.Clear();

            DataTable tb = sql_data.find_students( txtb_find.Text );

            lbl_panel_students_count.Text = $"Количество учеников: {tb.Rows.Count}"; ;

            foreach ( DataRow r in tb.Rows ) {

                StudentItem st = new StudentItem {

                    Name = $"stud_item_{ch}",
                    Tag = ( int )r[0]

                };
                
                st.lbl_full_name_val.Text = r[1].ToString();
                st.lbl_dob_val.Text = DateTime.Parse( r[2].ToString() ).ToString( "dd.MM.yyyy" );
                st.lbl_mother_value.Text = r[3].ToString();
                st.lbl_mother_phone_value.Text = r[4].ToString();
                st.lbl_father_value.Text = r[5].ToString();
                st.lbl_father_phone_value.Text = r[6].ToString();

                byte[] bytes = ( byte[] )r["photo"];
                MemoryStream stream = new MemoryStream( bytes );

                st.pic_photo.Image = new Bitmap( stream );

                st.lbl_addr_value.Text = r[8].ToString();
                st.lbl_phone_value.Text = r[9].ToString();
                st.lbl_class_value.Text = r[10].ToString();
                st.btn_edit.Tag = ( int )r[0];
                st.btn_edit.Click += Btn_edit_Click1;
                st.Dock = DockStyle.Top;

                panel_students_items.Controls.Add( st );

                ch++;
            }
        }

        private void cmb_pan_journal_subj_SelectedIndexChanged( object sender, EventArgs e ) {

            if( cmb_panel_journal_classes.SelectedIndex == -1 || cmb_pan_journal_subj.SelectedIndex == -1 ) return;

        }

        private void btn_panel_journal_add_lesson_Click( object sender, EventArgs e ) {

            if( cmb_panel_journal_classes.SelectedIndex == -1 || cmb_pan_journal_subj.SelectedIndex == -1 ) return;

            new_lesson f = new new_lesson( ( int )cmb_panel_journal_classes.SelectedValue, ( int )cmb_pan_journal_subj.SelectedValue, cmb_panel_journal_classes.Text, cmb_pan_journal_subj.Text );
            f.ShowDialog();
        }

        private void btn_add_subj_Click( object sender, EventArgs e ) {

            if ( cmb_panel_journal_classes.SelectedIndex == -1 ) {
                MessageBox.Show( "Не выбран класс", "School magazine", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            add_subj_for_journal f = new add_subj_for_journal( ( int )cmb_panel_journal_classes.SelectedValue, cmb_panel_journal_classes.Text );
            f.ShowDialog();

        }

        private void cmb_panel_journal_classes_SelectionChangeCommitted( object sender, EventArgs e ) {

            if( cmb_panel_journal_classes.SelectedIndex == -1 ) return;

            DataTable dt = sql_data.get_subj_from_journal( ( int )cmb_panel_journal_classes.SelectedValue );

            cmb_pan_journal_subj.DataSource = dt;
            cmb_pan_journal_subj.DisplayMember = "subj_name";
            cmb_pan_journal_subj.ValueMember = "id";

            cmb_pan_journal_subj.SelectedIndex = -1;

        }

        private void list_lessons_SelectedIndexChanged( object sender, EventArgs e ) {

            if ( list_lessons.SelectedItems.Count > 0) {

                DataTable dt = sql_data.get_students_for_lesson( ( Convert.ToInt32( list_lessons.Items[list_lessons.FocusedItem.Index].SubItems[0].Text ) ) );

                dgv_lesson.DataSource = dt;

                session_parameters.lesson_id = Convert.ToInt32( list_lessons.Items[list_lessons.FocusedItem.Index].SubItems[0].Text );
                session_parameters.lesson_date = list_lessons.Items[list_lessons.FocusedItem.Index].SubItems[3].Text;

                lbl_lesson_subj.Text = $"  { list_lessons.Items[list_lessons.FocusedItem.Index].SubItems[3].Text }\n  { list_lessons.Items[list_lessons.FocusedItem.Index].SubItems[2].Text }\n  Тема: { list_lessons.Items[list_lessons.FocusedItem.Index].SubItems[4].Text }";

                btn_close_lesson.Visible = true;

                cmd_panel.Visible = true;

                pan_lesson.Visible = false;

                for ( int i = 0; i < dgv_lesson.Rows.Count; i++ ) {

                    dgv_lesson[0, i].ReadOnly = true;
                    dgv_lesson[1, i].ReadOnly = true;
                }
            }
        }

        private void btn_close_lesson_Click( object sender, EventArgs e ) {

            foreach ( DataGridViewRow row in dgv_lesson.Rows ) {

                MarkAndVisit mv = new MarkAndVisit {

                    lesson_id = session_parameters.lesson_id,
                    students_id = ( int )row.Cells[0].Value,
                    visit = ( row.Cells[2].Value.ToString() == "П" ) ? 1 : 0,
                    mark_homework = ( row.Cells[3].Value.ToString() != "" ) ? Convert.ToInt32( row.Cells[3].Value ) : 0,
                    mark_classwork = ( row.Cells[4].Value.ToString() != "" ) ? Convert.ToInt32( row.Cells[4].Value ) : 0,
                    mark_independent_work = ( row.Cells[5].Value.ToString() != "" ) ? Convert.ToInt32( row.Cells[5].Value ) : 0,
                    mark_test_work = ( row.Cells[6].Value.ToString() != "" ) ? Convert.ToInt32( row.Cells[6].Value ) : 0,
                    mark_exam = ( row.Cells[7].Value.ToString() != "" ) ? Convert.ToInt32( row.Cells[7].Value ) : 0,
                    
                };

                string res = sql_data.save_lesson( mv );

                if( res != "" ) {
                    MessageBox.Show( res, "School magazine", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return;
                }
            }

            MessageBox.Show( "Урок успешно закрыт", "School magazine", MessageBoxButtons.OK, MessageBoxIcon.Information );

            dgv_lesson.DataSource = null;

            cmb_panel_journal_classes.SelectedIndex = -1;
            cmb_pan_journal_subj.SelectedIndex = -1;
            cmd_panel.Visible = false;
            btn_close_lesson.Visible = false;
            lbl_lesson_subj.Text = "";
        }

        private void btn_is_present_Click( object sender, EventArgs e ) {

            foreach ( DataGridViewRow row in dgv_lesson.Rows ) {
                row.Cells[2].Value = "П";
            }
        }

        private void btn_not_present_Click( object sender, EventArgs e ) {

            foreach ( DataGridViewRow row in dgv_lesson.Rows ) {
                row.Cells[2].Value = "О";
            }

        }

        private void dgv_lesson_CellEndEdit( object sender, DataGridViewCellEventArgs e ) {

            try {

                if ( e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 ) {

                    if ( dgv_lesson[e.ColumnIndex, e.RowIndex].Value.ToString() != "" && ( Convert.ToInt32( dgv_lesson[ e.ColumnIndex, e.RowIndex].Value.ToString() ) < 1 || Convert.ToInt32( dgv_lesson[ e.ColumnIndex, e.RowIndex].Value.ToString() ) > 12 ) ) {

                        MessageBox.Show( "Не допустимое значение! Оценка должна быть в диапазоне от 1 до 12", "School magazine", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        dgv_lesson[e.ColumnIndex, e.RowIndex].Value = "";
                    }
                }
                else if( e.ColumnIndex == 2 ) {

                    if( dgv_lesson[ e.ColumnIndex, e.RowIndex].Value.ToString() != "П" && dgv_lesson[e.ColumnIndex, e.RowIndex].Value.ToString() != "О" ) {

                        MessageBox.Show( "Не допустимое значение!\n\nВведите:\nП - если ученик присутствует\nО - если ученик отсутствует", "School magazine", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        dgv_lesson[e.ColumnIndex, e.RowIndex].Value = "О";
                    }
                }
            }
            catch ( Exception ) { dgv_lesson[e.ColumnIndex, e.RowIndex].Value = ""; }
        }

        private void timer_check_notice_Tick( object sender, EventArgs e ) {
            upload_notice_list();
        }

        private void dgv_lesson_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {

            if ( e.ColumnIndex == 0 || e.ColumnIndex == 1  ) {
                dgv_lesson[e.ColumnIndex, e.RowIndex].ReadOnly = true;
            }
        }
    }
}