using System;
using System.Collections.Generic;
using System.Text;

namespace Frogger
{
    public class FrogPlayer
    {
        public WorldPosition WorldPosition { get; set; }

        public FrogPlayer(int x, int y)
        {
            WorldPosition = new WorldPosition(x, y);
        }

    }
}
