using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class HorizontalLine : Figure
    {
        public HorizontalLine(int xLeft, int xRight, int y, char sym, int x_)
        {
            pointList = new List<Point>();
            for (int x = xLeft; x < xRight; x++)
            {
                Point point = new Point(x, y, sym);
                pointList.Add(point);
            }
        }
    }
}
