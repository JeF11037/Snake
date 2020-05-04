using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class VerticalLine : Figure
    {
        public VerticalLine(int yUp, int yDown, int x, char sym, int y_)
        {
            pointList = new List<Point>();
            for (int y = yUp; y < yDown; y++)
            {
                Point point = new Point(x, y, sym);
                pointList.Add(point);
            }
        }
    }
}
