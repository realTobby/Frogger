using System;

namespace Frogger
{
    class Program
    {
        static void Main(string[] args)
        {
            FroggerGame fg = new FroggerGame(300, 300);
            fg.GameLoop();
        }
    }
}
