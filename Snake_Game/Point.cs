using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        public Point()
        {

        }
        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public Point(Point point)
        {
            x = point.x;
            y = point.y;
            sym = point.sym;
        }

        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.right)
            {
                x = x + offset;
            }
            else if (direction == Direction.left)
            {
                x = x - offset;
            }
            else if (direction == Direction.up)
            {
                y = y - offset;
            }
            else if (direction == Direction.down)
            {
                y = y + offset;
            }
        }

        public bool IsHit(Point point)
        {
            return point.x == this.x && point.y == this.y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public void Clear()
        {
            sym = ' ';
            Draw();
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }

    }
}
