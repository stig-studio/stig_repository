using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam {

    public enum color_hair { Неопределен = 0, Блондин = 1, Русый = 2, Рыжий = 3, Шатен = 4, Брюнет = 5, Седой = 6 }
    public enum color_eye { Неопределен = 0, Синий = 1, Голоубой = 2, Серый = 3, Зеленый = 4, Янтарный = 5, Оливковый = 6, Карий = 7, Желтый = 8 }

    [Serializable]
    public class Client {

        public string full_name { get; set; }
        public string dob { get; set; }
        public string sex { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public color_hair hair { get; set; }
        public color_eye eye { get; set; }
        
        public Client( string f_name, string dt, string _sex, string _country, string _city, double _height, double _weight, color_hair c_hair, color_eye c_eye ) {

            this.full_name = f_name;
            this.dob = dt;
            this.sex = _sex;
            this.country = _country;
            this.city = _city;
            this.height = _height;
            this.weight = _weight;
            this.hair = c_hair;
            this.eye = c_eye;

        }

        public Client() {  }

        public string get_zodiac() {

            int month = DateTime.Parse( this.dob ).Month;
            int day = DateTime.Parse( this.dob ).Day;

            string zod = "";

            switch ( month ) {
                case 1: zod = ( day <= 20 ) ? "козерог" : "водолей"; break;
                case 2: zod = ( day <= 19 ) ? "водолей" : "рыбы"; break;
                case 3: zod = ( day <= 21 ) ? "рыбы" : "овен"; break;
                case 4: zod = ( day <= 20 ) ? "овен" : "телец"; break;
                case 5: zod = ( day <= 21 ) ? "телец" : "близнецы"; break;
                case 6: zod = ( day <= 22 ) ? "близнецы" : "рак"; break;
                case 7: zod = ( day <= 23 ) ? "рак" : "лев"; break;
                case 8: zod = ( day <= 23 ) ? "лев" : "дева"; break;
                case 9: zod = ( day <= 24 ) ? "дева" : "весы"; break;
                case 10: zod = ( day <= 23 ) ? "весы" : "скорпион"; break;
                case 11: zod = ( day <= 23 ) ? "скорпион" : "стрелец"; break;
                case 12: zod = (day <= 22) ? "стрелец" : "козерог"; break;
            }

            return zod;
        }

    }
}