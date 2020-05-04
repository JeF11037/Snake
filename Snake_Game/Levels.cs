using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Levels : Figure
    {

        List<Figure> letlist;

        public Levels()
        {
            Random random = new Random();

            int count = random.Next(2, 4);

            letlist = new List<Figure>();

            for (int tick = 0; tick <= count; tick++)
            {
                int height = random.Next(3, 5);
                int width = random.Next(6, 9);

                int y = random.Next(10, 20);
                int x = random.Next(10, 70);

                HorizontalLine hor = new HorizontalLine(height+x, width+x, y, '-', x);
                VerticalLine ver = new VerticalLine(height+y, width+y, x, '|', y);

                letlist.Add(hor);
                letlist.Add(ver);
            }
        }

        internal new bool IsHit(Figure figure)
        {
            foreach (var wall in letlist)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public new void Draw()
        {
            foreach (var wall in letlist)
            {
                wall.Draw();
            }
        }
    }
}
