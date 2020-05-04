using Snake_Game;
using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 30);

            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            int time = 100;
            int score = 0;

            bool on = true;
            bool gameOn = false;
            string option = "";
            char char_;
            bool coop = false;

            Console.CursorVisible = false;
            Console.SetBufferSize(width, height);

            Console.Title = "Snake Game";

            Walls walls = new Walls(width, height);
            Random random = new Random();
            Point point = new Point(random.Next(30, width - 30), random.Next(5, height - 5), '+');
            Snake snake = new Snake(point, 4, Direction.right);
            FoodCreator foodCreator = new FoodCreator(width, height, 'o');
            Point food = foodCreator.CreateFood();

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(18, 13);
            Console.WriteLine("This is a Snake project. Created by Lev Petryakov");
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("Enjoy !");
            Console.SetCursorPosition(32, 17);
            Console.WriteLine("Press Enter to start...");

            GameManager menu = new GameManager(width, height);
            Options options = new Options();
            Custom custom = new Custom();
            Levels lvl = new Levels();

            Sound music = new Sound();
            music.PlayMusic(@"C:\Users\levpe\Documents\Project_CS\Snake\Snake_Game\JeF11037-Guitar8D.wav");

            while (on)
            {
                if(options.music == 1 && music.player.Position >= new TimeSpan(0, 1, 43))
                {
                    music.player.Position = new TimeSpan(0, 0, 00);
                    music.player.Play();
                }
                else if (options.music == 2 && music.player.Position >= new TimeSpan(0, 1, 56))
                {
                    music.player.Position = new TimeSpan(0, 0, 00);
                    music.player.Play();
                }
                else if (options.music == 3 && music.player.Position >= new TimeSpan(0, 1, 44))
                {
                    music.player.Position = new TimeSpan(0, 0, 00);
                    music.player.Play();
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        if (option == "menu")
                        {
                            option = menu.option_chosen;
                        }
                        if (option == "")
                        {
                            option = "menu";
                        }
                        if (option == "options")
                        {
                            switch (options.option_chosen)
                            {
                                case "name":
                                    options.name = !options.name;
                                    if (options.name == true)
                                    {
                                        options.name_asking = "Ask for a name before starting a game: ON";
                                    }
                                    else
                                    {
                                        options.name_asking = "Ask for a name before starting a game: OFF";
                                    }
                                    break;
                                case "music":
                                    music.Stop();
                                    switch (options.music)
                                    {
                                        case 1:
                                            options.music = 2;
                                            options.playing_music = "Selected music: Guitar2";
                                            music.PlayMusic(@"C:\Users\levpe\Documents\Project_CS\Snake\Snake_Game\Guitar2.mp3");
                                            break;
                                        case 2:
                                            options.music = 3;
                                            options.playing_music = "Selected music: Guitar3";
                                            music.PlayMusic(@"C:\Users\levpe\Documents\Project_CS\Snake\Snake_Game\Guitar3.wav");
                                            break;
                                        case 3:
                                            options.music = 1;
                                            options.playing_music = "Selected music: Guitar1";
                                            music.PlayMusic(@"C:\Users\levpe\Documents\Project_CS\Snake\Snake_Game\JeF11037-Guitar8D.wav");
                                            break;
                                    }
                                    break;
                                case "value":
                                    options.value = options.value - 10;
                                    if (options.value < 0)
                                    {
                                        options.value = 100;
                                    }
                                    music.SetVolume(options.value);
                                    options.music_value = "Music value: " + options.value;
                                    break;
                                case "onoff":
                                    options.onoff = !options.onoff;
                                    if (options.onoff == true)
                                    {
                                        music.Unpause();
                                        options.on_off_music = "Music: ON";
                                    }
                                    else
                                    {
                                        music.Pause();
                                        options.on_off_music = "Music: OFF";
                                    }
                                    break;
                                case "exit":
                                    options.option_chosen = "";
                                    option = "menu";
                                    break;
                            }
                        }
                        if (option == "custom")
                        {
                            switch (custom.option_chosen)
                            {
                                case "color":
                                    custom.color_order++;
                                    if (custom.color_order > 3)
                                    {
                                        custom.color_order = 1;
                                    }
                                    break;
                                case "shape":
                                    custom.shape_order++;
                                    if (custom.shape_order > 3)
                                    {
                                        custom.shape_order = 1;
                                    }
                                    break;
                                case "exit":
                                    custom.option_chosen = "";
                                    option = "menu";
                                    break;
                            }
                        }
                        switch (option)
                        {
                            case "game":
                                gameOn = true;
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                lvl.Draw();
                                walls.Draw();
                                Console.ForegroundColor = ConsoleColor.Red;
                                food.Draw();
                                char_ = custom.char_;
                                snake.refresh(width, height, char_, 4);
                                break;
                            case "menu":
                                menu.Menu();
                                break;
                            case "options":
                                options.OptionsControl("");
                                break;
                            case "custom":
                                custom.CustomControl("");
                                break;
                            case "coop":
                                coop = true;
                                gameOn = true;
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                walls.Draw();
                                Console.ForegroundColor = ConsoleColor.Red;
                                food.Draw();
                                char_ = custom.char_;
                                snake.refresh(width, height, char_, 4);
                                break;
                            case "exit":
                                on = false;
                                break;
                        }
                    } 
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (option == "menu")
                        {
                            menu.MenuControl("up");
                        }
                        else if (option == "options")
                        {
                            options.OptionsControl("up");
                        }
                        else if (option == "custom")
                        {
                            custom.CustomControl("up");
                        }
                    } 
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (option == "menu")
                        {
                            menu.MenuControl("down");
                        }
                        else if (option == "options")
                        {
                            options.OptionsControl("down");
                        }
                        else if (option == "custom")
                        {
                            custom.CustomControl("down");
                        }
                    }
                }
                while (gameOn)
                {
                    if (options.music == 1 && music.player.Position >= new TimeSpan(0, 1, 43))
                    {
                        music.player.Position = new TimeSpan(0, 0, 00);
                        music.player.Play();
                    }
                    else if (options.music == 2 && music.player.Position >= new TimeSpan(0, 1, 56))
                    {
                        music.player.Position = new TimeSpan(0, 0, 00);
                        music.player.Play();
                    }
                    else if (options.music == 3 && music.player.Position >= new TimeSpan(0, 1, 44))
                    {
                        music.player.Position = new TimeSpan(0, 0, 00);
                        music.player.Play();
                    }
                    if (walls.IsHit(snake) || snake.IsHitTail() || lvl.IsHit(snake) && coop == false)
                    {
                        menu.GameOver();
                        gameOn = false;
                        coop = false;
                        score = 0;
                        time = 100;
                        char_ = custom.char_;
                        snake.refresh(width, height, char_, 4);
                        menu.Menu();
                        option = "menu";
                        break;
                    }

                    if (snake.Eat(food))
                    {
                        music.Play(@"C:\Users\levpe\Documents\Project_CS\Snake\Snake_Game\429593__inspectorj__chewing-breadstick-single-b.wav");
                        Console.ForegroundColor = ConsoleColor.Red;
                        food = foodCreator.CreateFood();
                        food.Draw();

                        if (time >= 20)
                            time = time - 5;
                        score++;
                    }
                    else
                    {
                        switch (custom.color_order)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                        }
                        snake.Move();
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(5, 2);
                    Console.WriteLine("Your score: " + score);

                    Thread.Sleep(time);

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        snake.HandleKey(key.Key);
                        if (coop == true)
                        {
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                food.Clear();
                                food = foodCreator.CreateFood();
                                food.Draw();
                            }
                        }
                    }
                }
            }
        }
    }
}