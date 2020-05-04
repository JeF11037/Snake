using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace Snake
{
    class GameManager
    {
        int width;
        int height;

        string new_game = "Start a new game";
        string coop = "Play coop";
        string option = "Options";
        string customisation = "Customisation";
        string exit = "Exit";

        static int shelf = 1;
        public string option_chosen;

        string name;

        public GameManager(int _width, int _height)
        {
            width = _width;
            height = _height;
        }
        
        public void Menu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("   _____                 _   _ ");
            Console.WriteLine("  / ____|               (_) | |");
            Console.WriteLine(" | (___    _ __   __ _   _  | |");
            Console.WriteLine("  ___   | '  _  |/ _` | | | | |");
            Console.WriteLine("  ____) | | | | || (_ | | | | |");
            Console.WriteLine(" |_____/__|_| |_| __,_| |_| |_|");
            Console.WriteLine("    / ____|                     ");
            Console.WriteLine("   | |  __  __ _ _ __ ___   ___  ");
            Console.WriteLine("   | | |_ |/ _` | '_ ` _  | _  |");
            Console.WriteLine("   | |__| | (_| | | | | | |  __/ ");
            Console.WriteLine("   | _____|__,_ |_| |_| |_|___| ");

            MenuControl("");
        }

        public void MenuControl(string key)
        {
            Console.SetCursorPosition(32, 16);
            Console.WriteLine(new_game);
            Console.SetCursorPosition(35, 18);
            Console.WriteLine(coop);
            Console.SetCursorPosition(36, 20);
            Console.WriteLine(option);
            Console.SetCursorPosition(33, 22);
            Console.WriteLine(customisation);
            Console.SetCursorPosition(37, 24);
            Console.WriteLine(exit);

            Console.BackgroundColor = ConsoleColor.Red;
            if (key == "up")
            {
                if (shelf != 1)
                {
                    shelf--;
                }
            } else if (key == "down")
            {
                if (shelf != 5)
                {
                    shelf++;
                }
            }

            switch (shelf)
            {
                case 1:
                    Console.SetCursorPosition(32, 16);
                    Console.WriteLine(new_game);
                    option_chosen = "game";
                    break;
                case 2:
                    Console.SetCursorPosition(35, 18);
                    Console.WriteLine(coop);
                    option_chosen = "coop";
                    break;
                case 3:
                    Console.SetCursorPosition(36, 20);
                    Console.WriteLine(option);
                    option_chosen = "options";
                    break;
                case 4:
                    Console.SetCursorPosition(33, 22);
                    Console.WriteLine(customisation);
                    option_chosen = "custom";
                    break;
                case 5:
                    Console.SetCursorPosition(37, 24);
                    Console.WriteLine(exit);
                    option_chosen = "exit";
                    break;
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void Name_asker()
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

        public void Name_writter(int score)
        {
            Console.Clear();
            StreamWriter to_file = new StreamWriter("Результаты.txt", true);
            to_file.WriteLine(name + " - " + score);
            to_file.Close();
        }

        public void GameOver()
        {
            Sound sound = new Sound();
            sound.Play(@"C:\Users\levpe\Documents\Project_CS\Snake\Snake_Game\76376__deleted-user-877451__game-over.wav");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(38, 15);
            Console.WriteLine("Game Over");
            Thread.Sleep(1000);
        }
    }
}
