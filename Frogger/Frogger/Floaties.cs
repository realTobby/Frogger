using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frogger
{
    public class Floaties
    {
        public WorldPosition WorldPosition { get; set; }

        private float floatSpeed = 50f;
        public bool isFloatingLeft = true;
        private int gameWidth { get; set; }

        public Floaties(int x, int y, int gw)
        {
            WorldPosition = new WorldPosition(x, y);
            gameWidth = gw;
        }

        public void UpdateFloaty()
        {
            if(isFloatingLeft)
            {
                WorldPosition.X -= Raylib.GetFrameTime() * floatSpeed;
                if(WorldPosition.X <= -50)
                {
                    WorldPosition.X = gameWidth + 49;
                }
            }
            else
            {
                WorldPosition.X += Raylib.GetFrameTime() * floatSpeed;
                if (WorldPosition.X >= gameWidth+50)
                {
                    WorldPosition.X = -49;
                }
            }

           
        }

        public Floaties CheckCollision(int x, int y)
        {
            if(x >= WorldPosition.X && x <= WorldPosition.X + 32
                && y <= WorldPosition.Y + 16 && y >= WorldPosition.Y)
            {
                return this;
            }
            return null;
        }

    }
}
