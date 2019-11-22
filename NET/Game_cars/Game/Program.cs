using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace Game {

    class Program {

        [DllImport("kernel32.dll", EntryPoint = "GetConsoleWindow", SetLastError = true)]
        private static extern IntPtr GetConsoleHandle();

        static void Main(string[] args) {

            ConsoleKeyInfo key;

            Menu( 0 );

            do {
                int x = Console.CursorLeft;

                key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow) Menu(1);
                else if (key.Key == ConsoleKey.RightArrow) Menu(2);
                else if (key.Key == ConsoleKey.Enter && x == 40) start_game();
                else if (key.Key == ConsoleKey.Enter && x == 60) break;
            }
            while (key.Key != ConsoleKey.Escape);
        }

        static void print_image(string img_path, int x, int y, int img_w, int img_h) {

            var handler = GetConsoleHandle();

            using (var graphics = Graphics.FromHwnd(handler))
            using (var image = Image.FromFile(img_path))
                graphics.DrawImage(image, x, y, img_w, img_h);

        }

        static void Menu(int step) {

            string curr_path = Environment.CurrentDirectory;

            if (step == 0) {

                Console.SetCursorPosition(40, 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("****** Car racing ******");
                Console.SetCursorPosition(40, 15);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("START");
                Console.ResetColor();
                Console.SetCursorPosition(60, 15);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("EXIT");
                Console.ResetColor();
                Console.SetCursorPosition(52, 15);
                print_image(curr_path + @"\img\logo.png", 360, 50, 100, 100);

            }
            else if (step == 1) {

                Console.SetCursorPosition(40, 15);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("START");
                Console.ResetColor();
                Console.SetCursorPosition(41, 10);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Press Enter please ...");
                Console.SetCursorPosition(40, 15);
                Console.ResetColor();
                Console.SetCursorPosition(60, 15);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("EXIT");
                Console.ResetColor();
                Console.SetCursorPosition(40, 15);
                print_image(curr_path + @"\img\logo.png", 360, 50, 100, 100);

            }
            else if(step == 2) {

                Console.SetCursorPosition(40, 15);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("START");
                Console.ResetColor();
                Console.SetCursorPosition(41, 10);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Press Enter please ...");
                Console.SetCursorPosition(60, 15);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("EXIT");
                Console.ResetColor();
                Console.SetCursorPosition(60, 15);
                print_image(curr_path + @"\img\logo.png", 360, 50, 100, 100);

            }
            else if(step == 3) {

                Console.SetCursorPosition(45, 25);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("CONTINUE");
                Console.ResetColor();
                Console.SetCursorPosition(65, 25);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("EXIT");
                Console.SetCursorPosition(53, 25);

            }
            else if (step == 4) {

                Console.SetCursorPosition(45, 25);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("CONTINUE");
                Console.ResetColor();
                Console.SetCursorPosition(47, 20);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Press Enter please ...");
                Console.SetCursorPosition(65, 25);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("EXIT");
                Console.SetCursorPosition(45, 25);

            }
            else if(step == 5) {

                Console.SetCursorPosition(45, 25);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("CONTINUE");
                Console.ResetColor();
                Console.SetCursorPosition(47, 20);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Press Enter please ...");
                Console.SetCursorPosition(65, 25);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("EXIT");
                Console.SetCursorPosition(65, 25);

            }

        }

        static bool percent_crash( int percent ) {

            Thread.Sleep(100);
            Random rnd = new Random();
            int val = rnd.Next(0, 101);
            //return (val <= percent) ? true : false;
            if (val <= 5) {
                Console.WriteLine(val);
                return true;
            }
            else return false;

        }

        static void start_game() {

            string img_path = Environment.CurrentDirectory;

            int pos_x = 30;
            int pos_y = 20;
            int curr_car = 0;

            string name = "";
            int quantity_players = 0;

            Random rnd = new Random();

            ConsoleKeyInfo key;
            int race = 0;

            Console.Clear();

            Console.SetCursorPosition(20, 2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter your name: ");
            name = Console.ReadLine();

            while ( quantity_players < 2 || quantity_players > 7 ) {

                Console.Clear();
                Console.SetCursorPosition(20, 2);
                Console.Write("Enter quantity players: ");
                quantity_players = Convert.ToInt32(Console.ReadLine());

            }
            
            Console.Clear();
            Console.SetCursorPosition(10, 5);

            for (int i = 1; i < 10; i++ ) {

                Thread.Sleep(100);
                print_image( img_path + @"\img\" + i + ".png", pos_x, pos_y, 25, 25 );
                pos_x += 56;

            }

            Thread.Sleep(100);
            Console.SetCursorPosition(2, 3);

            for(int i = 1; i < 10; i++) Console.Write($"   {i}   ");

            Console.SetCursorPosition(5, 5);

            while (curr_car < 1 || curr_car > 9) {

                Console.SetCursorPosition(5, 6);
                Console.Write("                                                                 ");
                Console.SetCursorPosition(5, 6);
                Console.Write("Choose a car: ");
                curr_car = Convert.ToInt32(Console.ReadLine());

            }

            Console.Clear();
            Console.ResetColor();

            Console.Write("\n\tYour name: " + name);
            Console.Write("\n\t Your car: " );

            Console.SetCursorPosition(30, 7);

            Thread.Sleep(100);

            print_image(img_path + @"\img\" + curr_car + ".png", 152, 30, 25, 25);

            for (int i = 0; i < quantity_players; i++) {

                Thread.Sleep(100);
                Console.SetCursorPosition(100, 7 + i);
                Console.Write("▀▄▀▄");

            }

            ArrayList car_list = new ArrayList(quantity_players);

            pos_x = 30;
            pos_y = 100;

            if (curr_car > quantity_players) {

                Car car = new Car(pos_x, pos_y, curr_car);

                car_list.Add(car);

                print_image(img_path + @"\img\" + curr_car + ".png", pos_x, pos_y, 25, 25);

                Thread.Sleep(100);

                for (int i = 1; i < quantity_players; i++) {

                    if(i != curr_car) {

                        pos_y += 17;

                        Car tmp = new Car(pos_x, pos_y, i);
                        car_list.Add(tmp);
                        
                        print_image(img_path + @"\img\" + i + ".png", pos_x, pos_y, 25, 25);
                        Thread.Sleep(100);

                    }
                }
            }
            else {

                Thread.Sleep(100);

                for (int i = 0; i < quantity_players; i++) {

                    Car tmp = new Car(pos_x, pos_y, i + 1);
                    car_list.Add(tmp);

                    print_image(img_path + @"\img\" + ( i + 1 ) + ".png", pos_x, pos_y, 25, 25);
                    pos_y += 17;
                    Thread.Sleep(100);

                }
            }

            do {

                Console.SetCursorPosition(40, 3);
                Console.Write("                                 ");
                Console.SetCursorPosition(40, 3);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("To start the race press space ...");
                key = Console.ReadKey();

            } while (key.Key != ConsoleKey.Spacebar);

            Console.ResetColor();

            Console.SetCursorPosition(40, 3);
            Console.Write("▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄ 3 ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
            Thread.Sleep(1000);
            Console.SetCursorPosition(40, 3);
            Console.Write("▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄ 2 ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
            Thread.Sleep(1000);
            Console.SetCursorPosition(40, 3);
            Console.Write("▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄ 1 ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄");
            Thread.Sleep(1000);
            Console.SetCursorPosition(40, 3);
            Console.Write("▀▄▀▄▀▄▀▄▀▄▀▄▀▄ START ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");

            while (true) {

                Car tmp = new Car();
                race = rnd.Next(0, quantity_players);

                //if ( percent_crash(5) == true ) {

                //    Car csh = new Car();
                //    csh.x = ((Car)car_list[race]).x;
                //    csh.y = ((Car)car_list[race]).y;
                //    csh.color = ((Car)car_list[race]).color;
                //    csh.working = false;
                //    car_list[race] = csh;

                //}

                tmp.x = ((Car)car_list[race]).x;
                tmp.y = ((Car)car_list[race]).y;
                tmp.color = ((Car)car_list[race]).color;
                tmp.working = ((Car)car_list[race]).working;

                if (tmp.x == 776) {

                    Console.SetCursorPosition(40, 3);
                    Console.Write("▀▄▀▄▀▄▀▄▀▄▀▄▀▄ FINISH ▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀");

                    if (tmp.color == curr_car) {

                        Console.SetCursorPosition(40, 15);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("-=-=-= Congratulations, you won =-=-=-");
                    }
                    else {
                        Console.SetCursorPosition(47, 15);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("-=-=-= You lose =-=-=-");
                    }
                    break;
                }

                print_image(img_path + @"\img\black_block.png", tmp.x, tmp.y, 25, 25);

                try {
                    tmp++;
                    print_image(img_path + @"\img\" + tmp.color + ".png", tmp.x, tmp.y, 25, 25);
                    car_list[race] = tmp;
                }
                catch (Exception) {
                    //print_image(img_path + @"\img\" + tmp.color + "_c.png", tmp.x, tmp.y, 25, 25);
                }
            }

            Menu(3);

            do {
                int x = Console.CursorLeft;

                key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow) Menu(4);
                else if (key.Key == ConsoleKey.RightArrow) Menu(5);
                else if (key.Key == ConsoleKey.Enter && x == 45) start_game();
                else if (key.Key == ConsoleKey.Enter && x == 65) Environment.Exit(0);
            } while ( key.Key != ConsoleKey.Escape );
        }
    }
}