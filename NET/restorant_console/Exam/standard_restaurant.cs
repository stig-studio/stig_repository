﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Exam {

    class standard_restaurant:Restaurant {

        public standard_restaurant( string name, string address, string phone ):base( name, address, phone ) { }

        public override void load_menu() {

            XmlSerializer xml = new XmlSerializer(typeof(List<Dish>));

            try {
                if (File.Exists("morning_menu.xml"))
                    using (FileStream stream = File.OpenRead("morning_menu.xml")) { this.morning_menu = xml.Deserialize(stream) as List<Dish>; }
                if (File.Exists("day_menu.xml"))
                    using (FileStream stream = File.OpenRead("day_menu.xml")) { this.day_menu = xml.Deserialize(stream) as List<Dish>; }
                if (File.Exists("evening_menu.xml"))
                    using (FileStream stream = File.OpenRead("evening_menu.xml")) { this.evening_menu = xml.Deserialize(stream) as List<Dish>; }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public override void print_menu() {

            if (DateTime.Now.Hour > 7 && DateTime.Now.Hour <= 12) {

                Console.WriteLine("\nУтренее меню");
                Console.WriteLine("-----------------------------------------------------------");

                int number = 1;

                foreach (Dish item in this.morning_menu) {
                    Console.WriteLine("{0,2}{1,40}{2,8}{3,6}", number++, item.name, item.type.ToString(), item.price);
                }
                Console.WriteLine("-----------------------------------------------------------");
            }

            if (DateTime.Now.Hour > 12 && DateTime.Now.Hour <= 17) {

                int number = 1;

                Console.WriteLine("\nДневное меню");
                Console.WriteLine("-----------------------------------------------------------");

                foreach (Dish item in this.day_menu) {
                    Console.WriteLine("{0,2}{1,40}{2,8}{3,6}", number++, item.name, item.type.ToString(), item.price);
                }
                Console.WriteLine("-----------------------------------------------------------");
            }

            if (DateTime.Now.Hour > 17 || DateTime.Now.Hour <= 7) {

                int number = 1;

                Console.WriteLine("\nВечернее меню");
                Console.WriteLine("-----------------------------------------------------------");

                foreach (Dish item in this.evening_menu) {
                    Console.WriteLine("{0,2}{1,40}{2,8}{3,6}", number++, item.name, item.type.ToString(), item.price);
                }
                Console.WriteLine("-----------------------------------------------------------");
            }

        }

        public override void service() {

            while (true) {

                Console.Clear();

                int choose = -1;

                Console.WriteLine("1 - Обслуживание клиента");
                Console.WriteLine("2 - Изменить меню");
                Console.WriteLine("0 - Выход");
                Console.Write(">");

                choose = Convert.ToInt32(Console.ReadLine());

                if (choose == 1) {

                    this.load_menu();
                    this.print_menu();

                    Sale s = new Sale(this);

                    while (true) {

                        int ch = -1;

                        Console.WriteLine("1 - Заказ блюда");
                        Console.WriteLine("2 - Изменить меню");
                        Console.WriteLine("0 - Выход");
                        Console.Write(">");

                        ch = Convert.ToInt32(Console.ReadLine());

                        if (ch == 1) {

                            Console.Write("\nВведите номер блюда:\n>");
                            int dish = Convert.ToInt32(Console.ReadLine());

                            Console.Write("\nВведите количество порций:\n>");
                            int quantity_dish = Convert.ToInt32(Console.ReadLine());

                            if (DateTime.Now.Hour > 7 && DateTime.Now.Hour <= 12) s.add_dish(this.morning_menu[dish - 1], quantity_dish);
                            else if (DateTime.Now.Hour > 12 && DateTime.Now.Hour <= 17) s.add_dish(this.day_menu[dish - 1], quantity_dish);
                            else if (DateTime.Now.Hour > 17 && DateTime.Now.Hour <= 7) s.add_dish(this.evening_menu[dish - 1], quantity_dish);

                            ch = -1;

                            Console.WriteLine("1 - Закрыть заказ");
                            Console.WriteLine("0 - Продолжить");
                            Console.Write(">");

                            ch = Convert.ToInt32(Console.ReadLine());

                            if (ch == 1) s.get_bill();
                            else continue;
                        }
                        else if (ch == 0) {
                            if (s.sum_sale() > 0)
{
                                int order = -1;

                                Console.WriteLine("Сущесвует не закрытый заказ");
                                Console.WriteLine("1 - Закрыть");
                                Console.WriteLine("0 - аннулировать и выйти");
                                Console.Write(">");

                                order = Convert.ToInt32(Console.ReadLine());

                                if (order == 1) s.get_bill();
                                else {
                                    Console.WriteLine("Заказ аннулирован!");
                                    Console.ReadKey();
                                    break;
                                }
                            }
                            else break;
                        }
                    }
                }
                else if (choose == 2) {

                    this.load_menu();

                    while (true) {

                        print_menu();

                        int ch = -1;

                        Console.WriteLine("1 - Добавить блюдо");
                        Console.WriteLine("2 - Удалить блюдо");
                        Console.WriteLine("3 - Удалить меню");
                        Console.WriteLine("4 - Сохранить меню");
                        Console.WriteLine("0 - Отмена");

                        ch = Convert.ToInt32(Console.ReadLine());

                        if (ch > -1 && ch < 5) {

                            if (ch == 1) {

                                ch = -1;

                                Console.WriteLine("1 - Утренее меню");
                                Console.WriteLine("2 - Дневное меню");
                                Console.WriteLine("3 - Вечернее меню");

                                ch = Convert.ToInt32(Console.ReadLine());

                                if (ch > 0 && ch < 4) {

                                    string name = "";
                                    type_dish type;
                                    double price = 0.0;

                                    while (true) {

                                        Console.Write("\nВведите название блюда:\n>");
                                        name = Console.ReadLine();

                                        if (name != "") break;
                                    }

                                    while (true) {

                                        Console.Write("\nВыберете тип блюда:\n0 - холодное\n1 - гарячее\n2 - десерт>");

                                        int t = Convert.ToInt32(Console.ReadLine());

                                        if (t > -1 && t < 3) { type = (type_dish)t; break; }
                                    }

                                    while (true) {

                                        Console.Write("\nВведите стоимость блюда:\n>");
                                        price = Convert.ToDouble(Console.ReadLine());

                                        if (price > 0.0) break;
                                    }

                                    Dish d = new Dish(name, type, price);

                                    if (ch == 1) this.morning_menu.Add(d);
                                    else if (ch == 2) this.day_menu.Add(d);
                                    else if (ch == 3) this.evening_menu.Add(d);
                                }
                            }
                            else if (ch == 2) {

                                int menu = -1;
                                int dish = -1;

                                Console.WriteLine("\nВыбор меню для удаления:");
                                Console.WriteLine("1 - Утренее меню");
                                Console.WriteLine("2 - Дневное меню");
                                Console.WriteLine("3 - Вечернее меню");
                                Console.Write(">");

                                menu = Convert.ToInt32(Console.ReadLine());

                                if (menu > 0 && menu < 4) {

                                    Console.Write("\nВведите номер блюда для удаления:\n>");
                                    dish = Convert.ToInt32(Console.ReadLine());

                                    if (menu == 1) {
                                        if (dish > 0 && dish <= this.morning_menu.Count())
                                            this.morning_menu.RemoveAt(dish);
                                    }
                                    else if (menu == 2) {
                                        if (dish > 0 && dish <= this.day_menu.Count())
                                            this.morning_menu.RemoveAt(dish);
                                    }
                                    else if (menu == 3) {
                                        if (dish > 0 && dish <= this.evening_menu.Count())
                                            this.morning_menu.RemoveAt(dish);
                                    }
                                }
                            }
                            else if (ch == 3) {

                                ch = -1;

                                Console.WriteLine("1 - Утренее меню");
                                Console.WriteLine("2 - Дневное меню");
                                Console.WriteLine("3 - Вечернее меню");
                                Console.Write(">");

                                ch = Convert.ToInt32(Console.ReadLine());

                                if (ch > 0 && ch < 4) {
                                    if (ch == 1) morning_menu.Clear();
                                    else if (ch == 2) day_menu.Clear();
                                    else if (ch == 3) evening_menu.Clear();
                                }
                            }
                            else if (ch == 4) this.save_menu();
                            else if (ch == 0) break;
                        }
                    }
                }
                else if (choose == 0) break;
            }
        }
    }
}