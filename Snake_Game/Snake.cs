using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Snake : Figure
    {
        Direction direction;

        public Snake(Point tail, int length, Direction _direction)
        {
            direction = _direction;
            pointList = new List<Point>();
            for (int tick = 0; tick < length; tick++)
            {
                Point point = new Point(tail);
                point.Move(tick, direction);
                pointList.Add(point);
            }
        }

        public void refresh(int width, int height, char char_, int length)
        {
            Random random = new Random();
            Point point_ = new Point(random.Next(20, width - 20), random.Next(10, height - 10), char_);
            direction = Direction.right;
            pointList = new List<Point>();
            for (int tick = 0; tick < length; tick++)
            {
                Point point = new Point(point_);
                point.Move(tick, direction);
                pointList.Add(point);
            }
        }

        internal void Move()
        {
            Point tail = pointList.First();
            pointList.Remove(tail);
            Point head = GetNextPoint();
            pointList.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = pointList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        internal bool IsHitTail()
        {
            var head = pointList.Last();
            for(int tick = 0; tick < pointList.Count - 2; tick++)
            {
                if (head.IsHit(pointList[tick]))
                    return true;
            }
            return false;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.left;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.right;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.up;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.down;
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pointList.Add(food);
                return true;
            }
            else
                return false;
        }

    }
}
