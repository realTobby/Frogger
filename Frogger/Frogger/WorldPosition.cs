using System;
using System.Collections.Generic;
using System.Text;

namespace Frogger
{
    public class WorldPosition
    {
        public float X { get; set; }
        public float Y { get; set; }

        public WorldPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int GetX() => Convert.ToInt32(X);
        public int GetY() => Convert.ToInt32(Y);

    }
}
