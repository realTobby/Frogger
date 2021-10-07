using System;

namespace Frogger
{
    class Program
    {
        static void Main(string[] args)
        {
            FroggerGame fg = new FroggerGame(352, 289);
            fg.GameLoop();
        }
    }
}
