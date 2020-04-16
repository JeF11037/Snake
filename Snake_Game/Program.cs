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

            bool gameOn = false;

            Console.CursorVisible = false;
            Console.SetBufferSize(width, height);

            Console.Title = "Snake Game";

            Walls walls = new Walls(width, height);
            Random random = new Random();
            Point point = new Point(random.Next(30, width - 30), random.Next(5, height - 5), '+');
            Snake snake = new Snake(point, 4, Direction.right);
            FoodCreator foodCreator = new FoodCreator(width, height, 'o');
            Point food = foodCreator.CreateFood();

            GameManager menu = new GameManager(width, height);
            menu.menu();

            Sound music = new Sound();
            music.background_music();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();

                        menu.name_asker();

                        Console.Clear();

                        gameOn = true;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        walls.Draw();
                        Console.ForegroundColor = ConsoleColor.Red;
                        food.Draw();
                        music.stop();
                    }
                }
                while (gameOn)
                {
                    if (walls.IsHit(snake) || snake.IsHitTail())
                    {
                        menu.name_writter(score);
                        music.game_over();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(38, 15);
                        Console.WriteLine("Game Over");
                        Thread.Sleep(1000);
                        gameOn = false;
                        menu.menu();
                        snake.refresh(width, height);
                        break;
                    }
                    if (snake.Eat(food))
                    {
                        music.chewing();
                        Console.ForegroundColor = ConsoleColor.Red;
                        food = foodCreator.CreateFood();
                        food.Draw();

                        if (time >= 50)
                            time = time - 5;

                        score++;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
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
                    }
                }
            }
        }
    }
}
