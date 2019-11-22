using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace School_magazine.models {

    public static class sql_data {

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static SqlConnection connection { get; set; }
        public static DataSet data_set { get; set; }
        public static DataSet data_set_employees { get; set; }
        public static DataSet data_set_education { get; set; }
        public static DataSet data_set_notices { get; set; }
        public static DataSet data_set_classes { get; set; }
        public static DataSet data_set_schedule { get; set; }
        public static DataSet data_set_subjects { get; set; }
        public static DataSet data_set_const { get; set; }
        public static DataSet data_set_students { get; set; }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // проверка существования базы данных
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static void database_exist() {

            string sql_query = $@"
            
                IF DB_ID( N'SchoolMagaz' ) IS NULL
	                CREATE DATABASE SchoolMagaz
            ";

            connection = new SqlConnection( "Server=localhost;Integrated security=SSPI;database=master" );
            connection.Open();

            SqlCommand cmd = new SqlCommand( sql_query, connection );

            try {
                cmd.ExecuteNonQuery();
            }
            catch ( Exception ex ) {
                MessageBox.Show( ex.Message, "School magazine", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            finally {
                connection.Close();
            }

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // проверка существования таблиц
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static void table_exist() {

            string sql_query = $@"
            
            IF OBJECT_ID( N'Education' ) IS NULL
            BEGIN

	            CREATE TABLE Education (
		
		            id INT IDENTITY PRIMARY KEY NOT NULL,
                    descr NVARCHAR( 50 ) NOT NULL

	            )

	            INSERT INTO Education VALUES
                    ( 'начальное образование' ),
                    ( 'среднее ( общее ) образование' ),
                    ( 'среднее ( полное ) образование' ),
                    ( 'среднее ( профессиональное ) образование' ),
                    ( 'бакалавриат высшего образования' ),
                    ( 'магистратура' ),
                    ( 'аспирантура' ),
                    ( 'докторантура' )

            END
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            IF OBJECT_ID( N'Employees' ) IS NULL
            BEGIN
                CREATE TABLE Employees (
                    
                    id INT IDENTITY PRIMARY KEY NOT NULL,
                    last_name NVARCHAR( 50 ) NOT NULL,
                    first_name NVARCHAR( 50 ) NOT NULL,
                    patronymic_name NVARCHAR( 50 ) NOT NULL,
                    birthday DATE NOT NULL,
                    employment_date DATE NOT NULL,
                    dismissal_date DATE,
                    photo VARBINARY( MAX ),
                    addr NVARCHAR( 50 ),
                    phone_number NVARCHAR( 20 ),
                    education INT FOREIGN KEY REFERENCES Education( id )
                    
                )
                
            END
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            IF OBJECT_ID( N'Users' ) IS NULL
            BEGIN

                CREATE TABLE Users (
                    
                    id INT IDENTITY PRIMARY KEY NOT NULL,
                    employee_id INT FOREIGN KEY REFERENCES Employees( id ),
                    _login NVARCHAR( 50 ) NOT NULL,
                    _pass NVARCHAR( 50 ) NOT NULL,
                    is_admin BIT NOT NULL
                )
                
                INSERT INTO dbo.Users VALUES
                    ( null, N'admin', N'admin', 1 )
                
            END
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            IF OBJECT_ID( N'Subjects' ) IS NULL
            BEGIN
                
                CREATE TABLE Subjects (
                    
                    id INT IDENTITY PRIMARY KEY NOT NULL,
                    name NVARCHAR( 50 ) NOT NULL
                    
                )
                
            END
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            IF OBJECT_ID( N'Classes' ) IS NULL
            BEGIN
                
                CREATE TABLE Classes (
                    
                    id INT PRIMARY KEY IDENTITY NOT NULL,
                    name NVARCHAR( 50 ) NOT NULL,
                    classroom_teacher INT FOREIGN KEY REFERENCES Employees( id )
                    
                )
                
            END
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            IF OBJECT_ID( N'Notification' ) IS NULL
            BEGIN
                
                CREATE TABLE Notification (
                    
                    id INT PRIMARY KEY IDENTITY NOT NULL,
                    title NVARCHAR( 50 ) NOT NULL,
                    text_notice NVARCHAR( max ) NOT NULL,
                    date_notice DATE NOT NULL,
                    author INT FOREIGN KEY REFERENCES Employees( id )
                    
                )
            
            END
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            IF OBJECT_ID( N'Subjects' ) IS NULL
            BEGIN
                
                CREATE TABLE Subjects (
                    
                    id INT PRIMARY KEY IDENTITY NOT NULL,
                    subj_name NVARCHAR( 50 ) NOT NULL
                    
                )
                
                -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
                
                INSERT [dbo].[Subjects] VALUES (N'Алгебра')
                INSERT [dbo].[Subjects] VALUES (N'Англійська мова ')
                INSERT [dbo].[Subjects] VALUES (N'Астрономія')
                INSERT [dbo].[Subjects] VALUES (N'Біологія')
                INSERT [dbo].[Subjects] VALUES (N'Біологія і екологія')
                INSERT [dbo].[Subjects] VALUES (N'Всесвітня історія')
                INSERT [dbo].[Subjects] VALUES (N'Географія')
                INSERT [dbo].[Subjects] VALUES (N'Геометрія')
                INSERT [dbo].[Subjects] VALUES (N'Громадянська освіта')
                INSERT [dbo].[Subjects] VALUES (N'Дизайн і технології')
                INSERT [dbo].[Subjects] VALUES (N'Екологія')
                INSERT [dbo].[Subjects] VALUES (N'Економіка')
                INSERT [dbo].[Subjects] VALUES (N'Зарубіжна література')
                INSERT [dbo].[Subjects] VALUES (N'Захист Вітчизни')
                INSERT [dbo].[Subjects] VALUES (N'Інформатика')
                INSERT [dbo].[Subjects] VALUES (N'Історія')
                INSERT [dbo].[Subjects] VALUES (N'Історія України')
                INSERT [dbo].[Subjects] VALUES (N'Історія України та всесвітня історія')
                INSERT [dbo].[Subjects] VALUES (N'Людина і світ')
                INSERT [dbo].[Subjects] VALUES (N'Математика')
                INSERT [dbo].[Subjects] VALUES (N'Мистецтво')
                INSERT [dbo].[Subjects] VALUES (N'Музичне мистецтво')
                INSERT [dbo].[Subjects] VALUES (N'німецька мова')
                INSERT [dbo].[Subjects] VALUES (N'Образотворче мистецтво')
                INSERT [dbo].[Subjects] VALUES (N'Основи здоров’я')
                INSERT [dbo].[Subjects] VALUES (N'Основи правознавства')
                INSERT [dbo].[Subjects] VALUES (N'Польська мова')
                INSERT [dbo].[Subjects] VALUES (N'Природознавство')
                INSERT [dbo].[Subjects] VALUES (N'Технології')
                INSERT [dbo].[Subjects] VALUES (N'Трудове навчання')
                INSERT [dbo].[Subjects] VALUES (N'Українська література')
                INSERT [dbo].[Subjects] VALUES (N'Українська мова ')
                INSERT [dbo].[Subjects] VALUES (N'Фізика')
                INSERT [dbo].[Subjects] VALUES (N'Фізика і астрономія')
                INSERT [dbo].[Subjects] VALUES (N'Фізична культура')
                INSERT [dbo].[Subjects] VALUES (N'Фізкультура')
                INSERT [dbo].[Subjects] VALUES (N'Хімія')
                INSERT [dbo].[Subjects] VALUES (N'Художня культура')
                INSERT [dbo].[Subjects] VALUES (N'Я досліджую світ')
                INSERT [dbo].[Subjects] VALUES (N'Я у світі')
                
                -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
                
            END
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            IF OBJECT_ID( N'Schedule' ) IS NULL
            BEGIN
                
                CREATE TABLE Schedule (
                    
                    id INT PRIMARY KEY IDENTITY NOT NULL,
                    class_id INT FOREIGN KEY REFERENCES Classes( id ) NOT NULL,
                    day_of_week INT CHECK( day_of_week BETWEEN 1 AND 7 ),
                    semester INT CHECK( semester BETWEEN 1 AND 2 ),
                    number INT NOT NULL CHECK( number BETWEEN 1 AND 10 ),
                    subject_id INT FOREIGN KEY REFERENCES Subjects( id ) NOT NULL,
                    teacher_id INT FOREIGN KEY REFERENCES Employees( id ) NOT NULL
                    
                )
                
            END
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            IF OBJECT_ID( N'ConstantValues' ) IS NULL
            BEGIN
                
                CREATE TABLE ConstantValues (
                    
                    id INT PRIMARY KEY IDENTITY NOT NULL,
                    const_name NVARCHAR( MAX ) NOT NULL,
                    value NVARCHAR( MAX ) NOT NULL
                    
                )
                
                INSERT INTO dbo.ConstantValues VALUES( 'Семестр', '1' )
                
            END
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            IF OBJECT_ID( N'UserNotes' ) IS NULL
            BEGIN
                
                CREATE TABLE UserNotes (
	                
	                id INT IDENTITY PRIMARY KEY NOT NULL,
                    user_id INT FOREIGN KEY REFERENCES Users( id ) NOT NULL,
                    note_text NVARCHAR( MAX )
                    
                )
                
            END
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            IF OBJECT_ID( N'Students' ) IS NULL
            BEGIN
                
                CREATE TABLE Students (
	                
	                id INT IDENTITY PRIMARY KEY NOT NULL,
                    last_name NVARCHAR( 50 ) NOT NULL,
                    first_name NVARCHAR( 50 ) NOT NULL,
                    patronymic_name NVARCHAR( 50 ) NOT NULL,
                    birthday DATE NOT NULL,
                    mother NVARCHAR( 100 ) NOT NULL,
                    mother_phone NVARCHAR( 20 ) NOT NULL,
                    father NVARCHAR( 100 ) NOT NULL,
                    father_phone NVARCHAR( 20 ) NOT NULL,
                    photo VARBINARY( MAX ),
                    addr NVARCHAR( 50 ),
                    phone_number NVARCHAR( 20 ),
                    class_id INT FOREIGN KEY REFERENCES Classes( id ) NOT NULL
                    
                )
                
            END
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            IF OBJECT_ID( N'ClassJournal' ) IS NULL
            BEGIN

                CREATE TABLE ClassJournal (
        
                    id INT PRIMARY KEY IDENTITY NOT NULL,
                    class_id INT FOREIGN KEY REFERENCES Classes( id ) NOT NULL
                    
                )

            END

            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            IF OBJECT_ID( N'SubjectJournal' ) IS NULL
            BEGIN
                
                CREATE TABLE SubjectJournal (
                    
                    id INT PRIMARY KEY IDENTITY NOT NULL,
                    journal_id INT FOREIGN KEY REFERENCES ClassJournal( id ) NOT NULL,
                    subj_id INT FOREIGN KEY REFERENCES Subjects( id ) NOT NULL
                    
                )
                
            END
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            IF OBJECT_ID( N'Lessons' ) IS NULL
            BEGIN
                
                CREATE TABLE Lessons (
                    
                    id INT PRIMARY KEY IDENTITY NOT NULL,
                    subj_jour_id INT FOREIGN KEY REFERENCES SubjectJournal( id ) NOT NULL,
                    lesson_date DATE NOT NULL,
                    lesson_topic NVARCHAR( 100 ),
                    lesson_report NVARCHAR( MAX )
                    
                )
                
            END
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            IF OBJECT_ID( N'MarksAndVisits' ) IS NULL
            BEGIN
                
                CREATE TABLE MarksAndVisits (
                    
                    id INT PRIMARY KEY IDENTITY NOT NULL,
                    lesson_id INT FOREIGN KEY REFERENCES Lessons( id ) NOT NULL,
                    students_id INT FOREIGN KEY REFERENCES Students( id ) NOT NULL,
                    visit BIT NOT NULL,
                    mark_homework INT CHECK( mark_homework BETWEEN 1 AND 12 ),
                    mark_classwork INT CHECK( mark_classwork BETWEEN 1 AND 12 ),
                    mark_independent_work INT CHECK( mark_independent_work BETWEEN 1 AND 12 ),
                    mark_test_work INT CHECK( mark_test_work BETWEEN 1 AND 12 ),
                    mark_exam INT CHECK( mark_exam BETWEEN 1 AND 12 )
                    
                )
                
            END
            
            -- + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
            
            ";
            
            try {

                connection = new SqlConnection( ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString );
                connection.Open();

                SqlCommand cmd = new SqlCommand( sql_query, connection );
                cmd.ExecuteNonQuery();

            }
            catch ( Exception ex ) {
                MessageBox.Show( ex.Message, "School magazine", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            finally {
                connection.Close();
            }

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // авторизация
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string signin( string login, string pass ) {

            string sql_query = $@"
                
                DECLARE @id         INT
                DECLARE @login      NVARCHAR( 50 )
                DECLARE @pass       NVARCHAR( 50 )
                DECLARE @empl       INT
                DECLARE @is_admin   INT
                
                SELECT
                    @id = u.id, @login = u._login
                FROM dbo.Users u
                WHERE
                    u._login = '{ login }'
                
                IF( @login IS NOT NULL )
                BEGIN
                    SELECT
                        @empl = u.employee_id, @is_admin = u.is_admin, @pass = u._pass
                    FROM dbo.Users u
                    WHERE u._login = @login AND u._pass = '{ pass }'
                    
                    IF( @pass IS NULL )
                        PRINT 'Неправильный пароль'
                
                END
                ELSE
                    PRINT 'Неправильное имя пользователя'
                
                DECLARE @semestr NVARCHAR( MAX )
                SELECT @semestr = c.value FROM dbo.ConstantValues c WHERE c.const_name LIKE 'Семестр'
                
                SELECT @id id, @login login, @empl employee_id, @is_admin is_admin, @semestr semestr
                
            ";

            SqlCommand cmd = new SqlCommand( sql_query, connection );
            SqlDataAdapter data_adapter = new SqlDataAdapter( cmd );

            string msg = "";

            connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs e ) { msg = e.Message; };

            data_set = new DataSet();

            data_adapter.Fill( data_set, "user_login" );

            var row = data_set.Tables["user_login"].Rows[0];

            if ( msg == "" ) {

                session_parameters.current_user = new User {

                    Id = Convert.ToInt32( row["id"] ),
                    employee_id = ( row["employee_id"].GetType().ToString() != "System.DBNull" ) ? Convert.ToInt32( row["employee_id"] ) : 0,
                    Login = row["login"].ToString(),
                    IsAdmin = Convert.ToBoolean( row["is_admin"] )

                };

                session_parameters.semestr = Convert.ToInt32( row["semestr"] );
            }
            else session_parameters.current_user = null;

            return msg;
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить список сотрудников
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static void get_employees() {

            string query = $@"
            
            SELECT
                e.id id,
                ( e.last_name + ' ' + e.first_name + ' ' + e.patronymic_name ) full_name,
                e.birthday dob,
                e.employment_date empl,
                COALESCE( CAST( e.dismissal_date AS NVARCHAR ), '' ) dism,
                e.photo photo,
                e.addr addr,
                e.phone_number phone,
                ed.descr educ
            FROM dbo.Employees e
            INNER JOIN
                dbo.Education ed ON ed.id = e.education
            ORDER BY
	            full_name DESC
            
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );

            data_set_employees = new DataSet();

            adapter.Fill( data_set_employees, "employees" );
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // добавление нового сотрудника
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string add_new_employees( string l_name, string f_name, string p_name, string dob, string empl, string dism, byte[] photo, string addr, string phone, int educ ) {

            string msg = "";

            string query = $@"
            
                INSERT INTO dbo.Employees VALUES (
                
                    '{ l_name }',
                    '{ f_name }',
                    '{ p_name }',
                    '{ dob }',
                    { ((empl != "") ? $"'{ empl }'" : "null") },
                    { ((dism != "") ? $"'{ dism }'" : "null") },
                    @photo,
                    '{ addr }',
                    '{ phone }',
                    { educ }
                
                )
            ";

            SqlCommand cmd = new SqlCommand( query, sql_data.connection );

            SqlParameter param = new SqlParameter {

                ParameterName = "photo",
                IsNullable = true,
                SqlDbType = SqlDbType.VarBinary,
                Value = photo

            };

            try {

                connection.Open();

                cmd.Parameters.Add( param );
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs e ) { msg = e.Message; };

                cmd.ExecuteNonQuery();

                return msg;

            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить значения таблицы Education
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static void get_education() {

            string query = $@"
            
                SELECT
                    e.id,
                    e.descr
                FROM dbo.Education e
                ORDER BY
                    e.descr
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );

            data_set_education = new DataSet();

            adapter.Fill( data_set_education, "education" );

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить сотрудника по ID
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static Employee get_employee_by_id( int id ) {

            string query = $@"

                SELECT * FROM dbo.Employees e WHERE e.id = { id }
            ";

            DataSet data_set_tmp = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter( query, connection );
            adapter.Fill( data_set_tmp, "empl" );

            var row = data_set_tmp.Tables["empl"].Rows[0];

            byte[] bytes = ( byte[] )row["photo"];
            MemoryStream stream = new MemoryStream( bytes );

            return new Employee {

                id = Convert.ToInt32( row[0] ),
                l_name = row[1].ToString(),
                f_name = row[2].ToString(),
                p_name = row[3].ToString(),
                dob = DateTime.Parse( row[4].ToString() ).ToString( "dd.MM.yyyy" ),
                employment_date = DateTime.Parse( row[5].ToString() ).ToString( "dd.MM.yyyy" ),
                dismissal_date = ( row[6].ToString() != "" ) ? DateTime.Parse( row[6].ToString() ).ToString( "dd.MM.yyyy" ) : "",
                photo = new System.Drawing.Bitmap( stream ),
                bytes_photo = ( byte[] )row[7],
                addr = row[8].ToString(),
                phone = row[9].ToString(),
                education = Convert.ToInt32( row[10] )

            };
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // обновить информацию о сотруднике
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string update_employee( Employee e ) {

            string query = $@"
            
                UPDATE dbo.Employees
                SET
                    last_name = '{ e.l_name }',
                    first_name = '{ e.f_name }',
                    patronymic_name = '{ e.p_name }',
                    birthday = '{ e.dob }',
                    employment_date = '{ e.employment_date }',
                    dismissal_date = { ((e.dismissal_date != "null") ? "'" + e.dismissal_date + "'" : "null") },
                    photo = @photo,
                    addr = '{ e.addr }',
                    phone_number = '{ e.phone }',
                    education = { e.education }
                WHERE
                    id = {e.id}
                
            ";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlParameter param = new SqlParameter
            {

                ParameterName = "photo",
                IsNullable = true,
                SqlDbType = SqlDbType.VarBinary,
                Value = e.bytes_photo

            };

            string msg = "";

            try {

                connection.Open();

                cmd.Parameters.Add(param);
                connection.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs ea) { msg = ea.Message; };

                cmd.ExecuteNonQuery();

                return msg;

            }
            catch (Exception ex) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // добавить объявление
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string add_notice( string title, string text, int id ) {

            string query = $@"
                
                INSERT INTO dbo.Notification VALUES( '{ title }', '{ text }', '{ DateTime.Now.ToString("yyyy-MM-dd") }', { id } )
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            string msg = "";

            try {

                connection.Open();
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs e ) { msg = e.Message; };
                cmd.ExecuteNonQuery();

                return msg;

            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить список объявлений
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static void get_notices() {

            string query = $@"
            
                SELECT
                    n.title,
                    n.text_notice,
                    n.date_notice,
                    ( e.last_name + ' ' + e.first_name + ' ' + e.patronymic_name ) full_name
                FROM dbo.Notification n
                INNER JOIN
                    dbo.Employees e ON e.id = n.author
                ORDER BY
	                n.date_notice DESC
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );

            data_set_notices = new DataSet();

            adapter.Fill( data_set_notices, "notices" );

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить пользователя по ID
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static User get_user( int id ) {

            string query = $@"
                
                SELECT * FROM dbo.Users u WHERE u.employee_id = { id }
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );
            DataSet data_set_tmp = new DataSet();

            adapter.Fill( data_set_tmp, "user" );

            User usr = null;

            if ( data_set_tmp.Tables["user"].Rows.Count > 0 ) {

                usr = new User {

                    Id = Convert.ToInt32( data_set_tmp.Tables["user"].Rows[0][0] ),
                    employee_id = Convert.ToInt32( data_set_tmp.Tables["user"].Rows[0][1] ),
                    Login = data_set_tmp.Tables["user"].Rows[0][2].ToString(),
                    Password = data_set_tmp.Tables["user"].Rows[0][3].ToString(),
                    IsAdmin = Convert.ToBoolean( data_set_tmp.Tables["user"].Rows[0][4] )

                };
            }

            return usr;
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить пользователя по ID
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string add_user( User u ) {

            string query = $@"
                
                DECLARE @user_id INT
                
                SELECT @user_id = u.id FROM dbo.Users u WHERE u._login = '{ u.Login }'
                
                IF( @user_id IS NULL )
                BEGIN
                    INSERT INTO dbo.Users VALUES( { u.employee_id }, '{ u.Login }', '{ u.Password }', { Convert.ToInt32(u.IsAdmin) } ) 
                END
                ELSE
                BEGIN
	                PRINT 'Пользователь с таким именем уже существует'
                END
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            string msg = "";
            
            try {

                connection.Open();
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs e ) { msg = e.Message; };
                cmd.ExecuteNonQuery();

                return msg;

            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить пользователя по ID
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string update_user( User u ) {

            string query = $@"
                
                UPDATE dbo.Users
                SET
                    employee_id = { u.employee_id },
                    _login = '{ u.Login }',
                    _pass = '{ u.Password }',
                    is_admin = { Convert.ToInt32( u.IsAdmin ) }
                WHERE
                    id = { u.Id }
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            string msg = "";
            
            try {

                connection.Open();
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs e ) { msg = e.Message; };
                cmd.ExecuteNonQuery();

                return msg;

            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить список классов
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static List<Class> get_classes() {

            string query = $@"
            
                SELECT 
                    c.name class_name,
                    ( e.last_name + ' ' + e.first_name + ' ' + e.patronymic_name ) classroom_teacher
                FROM dbo.Classes c
                INNER JOIN
                    dbo.Employees e on e.id = c.classroom_teacher
                ORDER BY
                    c.name
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );
            DataSet data_set_tmp = new DataSet();

            adapter.Fill( data_set_tmp, "classes" );

            List<Class> classes = new List<Class>();

            foreach ( DataRow item in data_set_tmp.Tables["classes"].Rows ) {
                classes.Add( new Class { class_name = item["class_name"].ToString(), classroom_teacher = item["classroom_teacher"].ToString() } );
            }

            return classes;
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // добавить новый класс
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string add_new_class( Class c ) {

            string query = $@"
                
                DECLARE @class_id INT

                SELECT @class_id = c.id FROM dbo.Classes c WHERE c.name = '{ c.class_name }'

                IF( @class_id IS NULL )
                BEGIN
                    
	                INSERT INTO dbo.Classes VALUES( '{ c.class_name }', { c.classroom_teacher_id } )
                    INSERT INTO dbo.ClassJournal VALUES( ( SELECT c.id FROM dbo.Classes c WHERE c.name = '{ c.class_name }' ) )
                    
                END
                ELSE
                BEGIN
	                PRINT 'Такой класс уже существует'
                END
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            string msg = "";
            
            try {

                connection.Open();
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs e ) { msg = e.Message; };
                cmd.ExecuteNonQuery();

                return msg;

            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить список классов с ID
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static void get_classes_with_id() {

            string query = $@"
            
                SELECT
                    c.id,
                    c.name class_name,
                    ( e.last_name + ' ' + e.first_name + ' ' + e.patronymic_name ) classroom_teacher
                FROM dbo.Classes c
                INNER JOIN
                    dbo.Employees e ON e.id = c.classroom_teacher
                ORDER BY
                    c.name
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );
            data_set_classes = new DataSet();

            adapter.Fill( data_set_classes, "classes" );
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить расписание по сотруднику
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static List<Subject> get_schedule_by_employee( int id ) {

            string query = $@"
                
                DECLARE @day_of_week INT
                SET @day_of_week = DATEPART( WEEKDAY, GETDATE() )

                IF( @day_of_week BETWEEN 2 AND 7 ) SET @day_of_week = @day_of_week - 1
                ELSE IF( @day_of_week = 1 ) SET @day_of_week = 7
                
                SELECT
	                sd.number,
	                sb.name
                FROM
	                dbo.Schedule sd
                INNER JOIN
	                dbo.Subjects sb ON sb.id = sd.subject_id
                WHERE
	                sd.teacher_id = { id } AND sd.day_of_week = @day_of_week
                ORDER BY
	                sd.number
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );
            DataSet data_set_tmp = new DataSet();

            adapter.Fill( data_set_tmp, "schedule" );

            List<Subject> subjects = new List<Subject>();

            foreach ( DataRow s in data_set_tmp.Tables["schedule"].Rows ) {
                subjects.Add( new Subject { number = Convert.ToInt32( s[0] ), name = s[1].ToString() } );
            }

            return subjects;
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить расписание
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static void get_schedule( int _class, int semestr, int teacher ) {

            string query = $@"
                
                SELECT
                    sd.day_of_week,
	                sd.number,
	                sb.name
                FROM
	                dbo.Schedule sd
                INNER JOIN
	                dbo.Subjects sb ON sb.id = sd.subject_id
                WHERE
	                sd.class_id = { _class } AND
	                sd.semester = { semestr }
                    { ( ( teacher != 0 ) ? $"AND sd.teacher_id = { teacher }": "" ) }
                ORDER BY
	                sd.day_of_week,
	                sd.number
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );
            data_set_schedule = new DataSet();

            adapter.Fill( data_set_schedule, "schedule" );

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить список предметов
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static List<Subject> get_subjects() {

            string query = $@"
                
                SELECT * FROM dbo.Subjects s
                ORDER BY s.name
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );

            DataSet data_set_tmp = new DataSet();

            adapter.Fill( data_set_tmp, "subjects" );

            List<Subject> subjects = new List<Subject>();

            foreach ( DataRow s in data_set_tmp.Tables["subjects"].Rows ) {
                subjects.Add( new Subject { id = Convert.ToInt32( s["id"] ), name = s["name"].ToString() } );
            }

            return subjects;

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить список предметов в DataSet
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static void get_subjects_data() {

            string query = $@"
                
                SELECT * FROM dbo.Subjects s
                ORDER BY s.name
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );

            data_set_subjects = new DataSet();

            adapter.Fill( data_set_subjects, "subjects" );
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // добавление предмета
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string add_subject( string subj_name ) {

            string query = $@"
                
                DECLARE @subj_id INT

                SELECT @subj_id = s.id FROM dbo.Subjects s
                WHERE
	                s.name = '{ subj_name }'

                IF( @subj_id is null )
                BEGIN
	                INSERT INTO dbo.Subjects VALUES( '{ subj_name }' )
                END
                ELSE
                BEGIN
	                PRINT 'Такой предмет уже существует'
                END
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            string msg = "";
            
            try {

                connection.Open();
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs e ) { msg = e.Message; };
                cmd.ExecuteNonQuery();

                return msg;

            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // добавить расписание 
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string add_subject_for_schedule( int class_id, int day_of_week, int semestr, int numb, int subj_id, int teacher_id ) {

            string query = $@"
                
                DECLARE @schedule_id INT

                SELECT @schedule_id = s.id FROM dbo.Schedule s
                WHERE
	                s.class_id = { class_id } AND
	                s.day_of_week = { day_of_week } AND
	                s.semester = { semestr } AND
	                s.number = { numb }

                IF( @schedule_id IS NULL )
                BEGIN
	                INSERT INTO dbo.Schedule VALUES( { class_id }, { day_of_week }, { semestr }, { numb }, { subj_id }, { teacher_id } )
                END
                ELSE
                BEGIN
	                PRINT 'Расписание по указанным данным занято'
                END
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            string msg = "";
            
            try {

                connection.Open();
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs e ) { msg = e.Message; };
                cmd.ExecuteNonQuery();

                return msg;
            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // обновить расписание
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string update_subject_for_schedule( int class_id, int day_of_week, int semestr, int numb, int subj_id, int teacher_id ) {

            string query = $@"
                
                DECLARE @shedule_id INT

                SELECT @shedule_id = s.id FROM dbo.Schedule s
                WHERE
	                s.class_id = { class_id } AND
	                s.semester = { semestr } AND
	                s.day_of_week = { day_of_week } AND
	                s.number = { numb }

                IF( @shedule_id IS NOT NULL )
                BEGIN
	                UPDATE dbo.Schedule
                    SET
                        subject_id = { subj_id },
                        teacher_id = { teacher_id }
                    WHERE
                        id = @shedule_id
                END
                ELSE
                BEGIN
	                PRINT 'Расписания с такими данными не существует'
                END
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            string msg = "";

            try {

                connection.Open();
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs ea ) { msg = ea.Message; };

                cmd.ExecuteNonQuery();

                return msg;

            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // удалить расписание
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string delete_subject_for_schedule( int class_id, int day_of_week, int semestr, int numb ) {

            string query = $@"
                
                DECLARE @shedule_id INT

                SELECT @shedule_id = s.id FROM dbo.Schedule s
                WHERE
	                s.class_id = { class_id } AND
	                s.semester = { semestr } AND
	                s.day_of_week = { day_of_week } AND
	                s.number = { numb }

                IF( @shedule_id IS NOT NULL )
                BEGIN
	                
                    DELETE FROM dbo.Schedule
                    WHERE
                        id = @shedule_id
                END
                ELSE
                BEGIN
	                PRINT 'Расписания с такими данными не существует'
                END
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            string msg = "";

            try {

                connection.Open();
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs ea ) { msg = ea.Message; };

                cmd.ExecuteNonQuery();

                return msg;

            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // запись заметок при закрытии приложения
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static void save_user_notes( string note ) {

            string query = $@"
            
                DECLARE @user_notes INT

                SELECT @user_notes = un.id FROM dbo.UserNotes un
                WHERE
                    un.user_id = { session_parameters.current_user.Id }
            
                IF( @user_notes IS NOT NULL )
                BEGIN
                
                    UPDATE dbo.UserNotes
                    SET
                        note_text = '{ note }'
                    WHERE
                        id = @user_notes
                
                END
                ELSE
                    INSERT INTO dbo.UserNotes VALUES( { session_parameters.current_user.Id }, '{ note }' )
            
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            try {

                connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch ( Exception ) { }
            finally { connection.Close(); }

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить заметки пользователя
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string get_notes() {

            string query = $@"
                
                DECLARE @note_id INT
                
                SELECT
                    @note_id = un.id
                FROM dbo.UserNotes un
                WHERE
                    un.user_id = { session_parameters.current_user.Id }
                    
                IF( @note_id IS NOT NULL )
                BEGIN
                    
                    SELECT
                        un.note_text
                    FROM dbo.UserNotes un
                    WHERE
                        un.id = @note_id
                END
                ELSE
                    SELECT ''
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );

            connection.Open();

            try {

                var note = cmd.ExecuteScalar();

                return note.ToString();
            }
            catch  ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить константы
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static void get_const_values() {

            string query = $@"

                SELECT
                    c.id,
                    c.const_name [Параметр],
                    c.value [Значение]
                FROM dbo.ConstantValues c
                ORDER BY
                    c.const_name
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );

            data_set_const = new DataSet();

            adapter.Fill( data_set_const, "const" );

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // удалить константы
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string update_const_value( int id ) {

            string query = $@"
                
                IF( ( SELECT id FROM dbo.ConstantValues c WHERE c.id = { id } ) IS NOT NULL )
                BEGIN
                    DELETE FROM dbo.ConstantValues WHERE id = '{ id }'
                END
                ELSE
                BEGIN
                    PRINT 'Элемент не может быть удален, так как его не существует'
                END
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            string msg = "";

            try {

                connection.Open();
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs ea ) { msg = ea.Message; };

                cmd.ExecuteNonQuery();

                return msg;

            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // сохранить константы
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string update_const_value( int id, string const_name, string value ) {

            string query = $@"
                
                IF( ( SELECT id FROM dbo.ConstantValues c WHERE c.id = { id } ) IS NOT NULL )
                BEGIN
                    
                    UPDATE dbo.ConstantValues
                    SET
                        const_name = '{ const_name }',
                        value = '{ value }'
                END
                ELSE
                BEGIN
                    INSERT INTO dbo.ConstantValues VALUES( '{ const_name }', '{ value }' )
                END
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            string msg = "";

            try {

                connection.Open();
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs ea ) { msg = ea.Message; };

                cmd.ExecuteNonQuery();

                return msg;

            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // сохранить константы
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string delete_const_value( int id ) {

            string query = $@"
                
                IF( ( SELECT id FROM dbo.ConstantValues c WHERE c.id = { id } ) IS NOT NULL )
                BEGIN
                    DELETE FROM dbo.ConstantValues
                    WHERE id = { id }
                END
                ELSE
                BEGIN
                    PRINT 'Значения с id: { id } не существует в БД'
                END
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            string msg = "";

            try {

                connection.Open();
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs ea ) { msg = ea.Message; };

                cmd.ExecuteNonQuery();

                return msg;

            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить список учеников по значению класса
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static DataTable get_students( int _class ) {

            string query = $@"
                
                SELECT
                    s.id,
                    ( s.last_name + ' ' + s.first_name + ' ' + s.patronymic_name ) full_name,
                    s.birthday,
                    s.mother,
                    s.mother_phone,
                    s.father,
                    s.father_phone,
                    s.photo,
                    s.addr,
                    s.phone_number,
                    c.name class_name
                FROM dbo.Students s
                INNER JOIN
                    dbo.Classes c ON c.id = s.class_id
                { ( ( _class == 0 ) ? "" : $"WHERE s.class_id = { _class }" )  }
                ORDER BY
                    full_name DESC
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );

            data_set_students = new DataSet();

            adapter.Fill( data_set_students, "students" );

            return data_set_students.Tables["students"];
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // добавить ученика
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string add_student( Student s ) {

            string query = $@"
                
                INSERT INTO dbo.Students VALUES(
	                '{ s.last_name }',
	                '{ s.first_name }',
	                '{ s.patr_name }',
	                '{ DateTime.Parse(s.dob).ToString("yyyy-MM-dd") }',
	                '{ s.mother }',
	                '{ s.mother_phone }',
	                '{ s.father }',
	                '{ s.father_phone }',
	                { ( ( s.bytes_photo != null ) ? "@photo," : "NULL," ) } 
	                '{ s.addr }',
	                '{ s.phone }',
	                { s.class_id }
                )
                
            ";

            SqlCommand cmd = new SqlCommand( query, sql_data.connection );

            SqlParameter param = new SqlParameter {

                ParameterName = "photo",
                IsNullable = true,
                SqlDbType = SqlDbType.VarBinary,
                Value = s.bytes_photo

            };

            string msg = "";

            try {

                connection.Open();

                cmd.Parameters.Add( param );
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs e ) { msg = e.Message; };

                cmd.ExecuteNonQuery();

                return msg;

            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить ученика по id
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static Student get_studet_by_id( int id ) {

            string query = $@"
                
                SELECT * FROM dbo.Students s WHERE s.id = { id }
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );

            DataSet ds_tmp = new DataSet();

            adapter.Fill( ds_tmp, "students" );

            DataRow row = ds_tmp.Tables["students"].Rows[0];

            byte[] bytes = ( byte[] )row["photo"];
            MemoryStream stream = new MemoryStream( bytes );

            Student st = new Student {

                id = ( int )row["id"],
                last_name = row["last_name"].ToString(),
                first_name = row["first_name"].ToString(),
                patr_name = row["patronymic_name"].ToString(),
                dob = DateTime.Parse( row["birthday"].ToString() ).ToString( "dd.MM.yyyy" ),
                mother = row["mother"].ToString(),
                mother_phone = row["mother_phone"].ToString(),
                father = row["father"].ToString(),
                father_phone = row["father_phone"].ToString(),
                bytes_photo = ( byte[] )row["photo"],
                photo = new Bitmap( stream ),
                addr = row["addr"].ToString(),
                phone = row["phone_number"].ToString(),
                class_id = ( int )row["class_id"]

            };

            return st;

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // изменить данные о ученике
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string update_student( Student s ) {

            string query = $@"
                
                UPDATE dbo.Students
                SET
                    last_name = '{ s.last_name }',
                    first_name = '{ s.first_name }',
                    patronymic_name = '{ s.patr_name }',
                    birthday = '{ DateTime.Parse( s.dob ).ToString( "yyyy-MM-dd" ) }',
                    mother = '{ s.mother }',
                    mother_phone = '{ s.mother_phone }',
                    father = '{ s.father }',
                    father_phone = '{ s.father_phone }',
                    photo = { ( ( s.bytes_photo != null ) ? "@photo," : "NULL," ) }
                    addr = '{ s.addr }',
                    phone_number = '{ s.phone }',
                    class_id = { s.class_id }
                WHERE
                    id = { s.id }
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            SqlParameter param = new SqlParameter {

                ParameterName = "photo",
                IsNullable = true,
                SqlDbType = SqlDbType.VarBinary,
                Value = s.bytes_photo

            };

            string msg = "";

            try {

                connection.Open();

                cmd.Parameters.Add( param );
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs ea ) { msg = ea.Message; };

                cmd.ExecuteNonQuery();

                return msg;

            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // изменить данные о ученике
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static DataTable find_students( string name ) {

            string query = $@"
                
                SELECT
                    s.id,
                    ( s.last_name + ' ' + s.first_name + ' ' + s.patronymic_name ) full_name,
                    s.birthday,
                    s.mother,
                    s.mother_phone,
                    s.father,
                    s.father_phone,
                    s.photo,
                    s.addr,
                    s.phone_number,
                    c.name class_name
                FROM dbo.Students s
                INNER JOIN
                    dbo.Classes c ON c.id = s.class_id
                WHERE
                    s.last_name LIKE '%{ name }%' OR s.first_name LIKE '%{ name }%' OR s.patronymic_name LIKE '%{ name }%'
                ORDER BY
                    full_name DESC
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );

            DataSet data_set_tmp = new DataSet();

            adapter.Fill(data_set_tmp, "students" );

            return data_set_tmp.Tables["students"];

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // изменить данные о ученике
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string add_lesson( int subj_journ_id, string lesson_date, string theme ) {

            string query = $@"
                
                INSERT INTO dbo.Lessons VALUES( { subj_journ_id }, '{ lesson_date }', '{ theme }', NULL )
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            string msg = "";
            
            try {

                connection.Open();
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs e ) { msg = e.Message; };
                cmd.ExecuteNonQuery();

                return msg;
            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // добавление предмета в журнал
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string add_subj_for_journal( int class_id, int subj_id ) {

            string query = $@"
                
                DECLARE @journ_id INT

                SELECT @journ_id = cj.id FROM dbo.ClassJournal cj WHERE cj.class_id = { class_id }

                IF( @journ_id IS NOT NULL )
                BEGIN
                    INSERT INTO dbo.SubjectJournal VALUES( @journ_id, { subj_id } )
                END
                ELSE
                    PRINT 'У выбранного класса отсутствует журнал'
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            string msg = "";
            
            try {

                connection.Open();
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs e ) { msg = e.Message; };
                cmd.ExecuteNonQuery();

                return msg;
            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить предметы из классного журнала
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static DataTable get_subj_from_journal( int class_id ) {

            string query = $@"
                
                SELECT
	                sj.id,
	                sj.journal_id,
	                sj.subj_id,
	                s.name subj_name
                FROM dbo.SubjectJournal sj
                INNER JOIN
	                dbo.Subjects s ON s.id = sj.subj_id
                WHERE
	                sj.journal_id = ( SELECT cj.id FROM dbo.ClassJournal cj WHERE cj.class_id = { class_id } )
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );

            DataSet ds_tmp = new DataSet();

            adapter.Fill( ds_tmp, "subj" );

            return ds_tmp.Tables["subj"];

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить предметы из классного журнала
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static List<Lesson> get_lessons( int subj_journal ) {

            string query = $@"
                
                SELECT
	                l.id,
                    s.id subj_id,
	                s.name subj_name,
	                l.lesson_date,
	                l.lesson_topic,
	                l.lesson_report
                FROM dbo.Lessons l
                INNER JOIN
	                dbo.SubjectJournal sj ON sj.id = l.subj_jour_id
                INNER JOIN
	                dbo.Subjects s ON s.id = sj.subj_id
                WHERE
	                sj.id = 1
                ORDER BY
	                l.lesson_date
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );
            DataSet ds_tmp = new DataSet();

            adapter.Fill( ds_tmp, "lessons" );

            List<Lesson> lessons = new List<Lesson>();

            foreach ( DataRow r in ds_tmp.Tables["lessons"].Rows ) {

                lessons.Add( new Lesson {

                    id = ( int )r[0],
                    subj_id = ( int )r[1],
                    subj_name = r[2].ToString(),
                    lesson_date = DateTime.Parse( r[3].ToString() ).ToString( "dd.MM.yyyy" ),
                    lesson_topic = r[4].ToString(),
                    lesson_report = r[5].ToString()

                } );
            }

            return lessons;
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // получить список учеников для урока
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static DataTable get_students_for_lesson( int lesson_id ) {

            string query = $@"
                
                SELECT
	                s.id,
                    ( s.last_name + ' ' + s.first_name + ' ' + s.patronymic_name ) [ФИО],
                    ( CASE
		                WHEN mv.visit = 1 THEN 'П'
		                WHEN mv.visit = 0 THEN 'О'
	                ELSE '' END ) [П],
                    COALESCE( CAST( mv.mark_homework AS NVARCHAR ), '' ) [ДмЗ],
                    COALESCE( CAST( mv.mark_classwork AS NVARCHAR ), '' ) [КлР],
                    COALESCE( CAST( mv.mark_independent_work AS NVARCHAR ), '' ) [СмР],
                    COALESCE( CAST( mv.mark_test_work AS NVARCHAR ), '' ) [КрР],
                    COALESCE( CAST( mv.mark_exam AS NVARCHAR ), '' ) [Экз]
                FROM dbo.Students s
                INNER JOIN (
	                SELECT DISTINCT
		                mv.lesson_id,
		                mv.students_id,
		                mv.visit,
		                mv.mark_homework,
		                mv.mark_classwork,
		                mv.mark_independent_work,
		                mv.mark_test_work,
		                mv.mark_exam
	                FROM dbo.MarksAndVisits mv
	                WHERE
		                mv.lesson_id = { lesson_id }
                ) mv ON mv.students_id = s.id
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataAdapter adapter = new SqlDataAdapter( cmd );

            DataSet ds_tmp = new DataSet();

            adapter.Fill( ds_tmp, "students_lesson" );

            return ds_tmp.Tables["students_lesson"];

        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
        // сохранить урок
        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +

        public static string save_lesson( MarkAndVisit mv ) {

            string query = $@"
                
                DECLARE @stud_id INT

                SELECT @stud_id = mv.students_id FROM dbo.MarksAndVisits mv
                WHERE
                    mv.lesson_id = 1

                IF( @stud_id IS NULL )
                BEGIN
    
                    INSERT INTO dbo.MarksAndVisits VALUES (
                    
                        { mv.lesson_id },
                        { mv.students_id },
                        { mv.visit },
                        { ((mv.mark_homework == 0) ? "NULL" : $"{ mv.mark_homework }") },
                        { ((mv.mark_classwork == 0) ? "NULL" : $"{ mv.mark_classwork }") },
                        { ((mv.mark_independent_work == 0) ? "NULL" : $"{ mv.mark_independent_work }") },
                        { ((mv.mark_test_work == 0) ? "NULL" : $"{ mv.mark_test_work }") },
                        { ((mv.mark_exam == 0) ? "NULL" : $"{ mv.mark_exam }") }
                    
                    )

                END
                ELSE
                BEGIN

                    UPDATE dbo.MarksAndVisits
                    SET
                        visit = { mv.visit },
                        mark_homework = { ((mv.mark_homework == 0) ? "NULL" : $"{ mv.mark_homework }") },
                        mark_classwork = { ((mv.mark_classwork == 0) ? "NULL" : $"{ mv.mark_classwork }") },
                        mark_independent_work = { ((mv.mark_independent_work == 0) ? "NULL" : $"{ mv.mark_independent_work }") },
                        mark_test_work = { ((mv.mark_test_work == 0) ? "NULL" : $"{ mv.mark_test_work }") },
                        mark_exam = { ((mv.mark_exam == 0) ? "NULL" : $"{ mv.mark_exam }") }
                    WHERE
                        students_id = @stud_id AND lesson_id = 1

                END
                
            ";

            SqlCommand cmd = new SqlCommand( query, connection );

            string msg = "";
            
            try {

                connection.Open();
                connection.InfoMessage += delegate ( object sender, SqlInfoMessageEventArgs e ) { msg = e.Message; };
                cmd.ExecuteNonQuery();

                return msg;
            }
            catch ( Exception ex ) {
                return ex.Message;
            }
            finally {
                connection.Close();
            }
        }

        // + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + + +
    }
}