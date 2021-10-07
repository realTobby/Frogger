using System;
using System.Collections.Generic;
using System.Text;

namespace Frogger
{
    public class FrogPlayer
    {
        public WorldPosition WorldPosition { get; set; }

        private Floaties currentFloater = null;

        public void UpdateFrog()
        {
            if(currentFloater != null)
            {
                WorldPosition.X = currentFloater.WorldPosition.X;
                WorldPosition.Y = currentFloater.WorldPosition.Y;
            }
        }

        public FrogPlayer(int x, int y)
        {
            WorldPosition = new WorldPosition(x, y);
        }

        public void Attach(Floaties fl)
        {
            currentFloater = fl;
        }

        public void Detach()
        {
            currentFloater = null;
        }

    }
}
