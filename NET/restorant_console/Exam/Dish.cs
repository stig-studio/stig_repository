using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Exam {

    public enum type_dish { холодное = 0, гарячее = 1, десерт = 2 }

    [Serializable]
    public class Dish : Attribute {

        public string name { get; set; }
        public type_dish type { get; set; }
        public double price { get; set; }

        public Dish() { }

        public Dish( string name, type_dish type, double price ) {

            this.name = name;
            this.type = type;
            this.price = price;
        }

        public static Dish operator + ( Dish d1, Dish d2 ) {
            d1.price += d2.price;
            return d1;
        }

        public static Dish operator -( Dish d1, Dish d2 ) {
            d1.price -= d2.price;
            return d1;
        }

        public override string ToString() { return $"Название: {this.name}\n     Тип: {this.type.ToString()}\n    Цена: {this.price}"; }
        public string ToTable() { return $"{this.name, 30}:{this.price, 5}"; }

        public static implicit operator double ( Dish d ) { return d.price; }
    }
}