using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Options
    {
        public string playing_music = "Selected music: Guitar1";
        public string music_value = "Music value: 100";
        public string on_off_music = "Music: ON";
        public string name_asking = "Ask for a name before starting a game: ON";
        string exit = "Exit";

        public int shelf = 1;

        public int music = 1;
        public int value = 100;
        public bool onoff = true;
        public bool name = true;

        public string option_chosen;

        public void OptionsControl(string key)
        {
            Console.SetCursorPosition(21, 16);
            Console.WriteLine(name_asking);
            Console.SetCursorPosition(30, 18);
            Console.WriteLine(playing_music);
            Console.SetCursorPosition(32, 20);
            Console.WriteLine(music_value);
            Console.SetCursorPosition(35, 22);
            Console.WriteLine(on_off_music);
            Console.SetCursorPosition(37, 24);
            Console.WriteLine(exit);

            Console.BackgroundColor = ConsoleColor.Red;
            if (key == "up")
            {
                if (shelf != 1)
                {
                    shelf--;
                }
            }
            else if (key == "down")
            {
                if (shelf != 5)
                {
                    shelf++;
                }
            }

            switch (shelf)
            {
                case 1:
                    Console.SetCursorPosition(21, 16);
                    Console.WriteLine(name_asking);
                    option_chosen = "name";
                    break;
                case 2:
                    Console.SetCursorPosition(30, 18);
                    Console.WriteLine(playing_music);
                    option_chosen = "music";
                    break;
                case 3:
                    Console.SetCursorPosition(32, 20);
                    Console.WriteLine(music_value);
                    option_chosen = "value";
                    break;
                case 4:
                    Console.SetCursorPosition(35, 22);
                    Console.WriteLine(on_off_music);
                    option_chosen = "onoff";
                    break;
                case 5:
                    Console.SetCursorPosition(37, 24);
                    Console.WriteLine(exit);
                    option_chosen = "exit";
                    break;
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
