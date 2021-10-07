using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frogger
{
    public class FroggerGame
    {
        public FroggerGame(int windowWidth, int windowHeight)
        {
            Raylib.InitWindow(windowHeight, windowHeight, "Frogger");
        }

        public void GameLoop()
        {
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                // Game Logic goes here
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }

    }
}
