using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            int time = 100;

            Console.CursorVisible = false;
            Console.SetBufferSize(width, height);

            Walls walls = new Walls(width, height);
            walls.Draw();

            Random random = new Random();
            Point point = new Point(random.Next(30, width - 30), random.Next(5, height - 5), '#');
            Snake snake = new Snake(point, 4, Direction.right);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(width, height, 'o');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();

                    if (time >= 80)
                        time--;

                }
                else
                {
                    snake.Move();
                }

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
