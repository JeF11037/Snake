using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Snake
{
    class GameManager
    {
        public int width;
        public int height;
        public GameManager(int _width, int _height)
        {
            width = _width;
            height = _height;
        }
        
        public void menu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("   _____                 _   _ ");
            Console.WriteLine("  / ____|               (_) | |");
            Console.WriteLine(" | (___    _ __   __ _   _  | |");
            Console.WriteLine("  ___   | '_    |/ _` | | | | |");
            Console.WriteLine("  ____) | | | | || (_ | | | | |");
            Console.WriteLine(" |_____/__|_| |_| __,_| |_| |_|");
            Console.WriteLine("    / ____|                     ");
            Console.WriteLine("   | |  __  __ _ _ __ ___   ___  ");
            Console.WriteLine("   | | |_ |/ _` | '_ ` _  | _  |");
            Console.WriteLine("   | |__| | (_| | | | | | |  __/ ");
            Console.WriteLine("   | _____|__,_ |_| |_| |_|___| ");

            Console.SetCursorPosition(18, 13);
            Console.WriteLine("This is a Snake project. Created by Lev Petryakov");
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("To start press Enter...");
        }

        string name;

        public void name_asker()
        {
            Console.Clear();

            Console.WriteLine("Write your name: ");

            try
            {
                name = Console.ReadLine();

                Console.WriteLine("Вы ввели: " + name);

                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка! Введите правильно !");
            }
        }

        public void name_writter(int score)
        {
            Console.Clear();
            StreamWriter to_file = new StreamWriter("Результаты.txt", true);
            to_file.WriteLine(name + " - " + score);
            to_file.Close();
        }
    }
}
