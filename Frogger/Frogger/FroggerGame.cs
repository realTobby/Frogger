using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frogger
{
    public class FroggerGame
    {
        private int window_width { get; set; } = 0;
        private int window_height { get; set; } = 0;
        private List<WorldTile> world;
        private List<Floaties> floaties;
        private bool _generateIsGrass = true;
        private FrogPlayer frog;
        private Random rand_func;

        private int frog_score = 0;

        public FroggerGame(int windowWidth, int windowHeight)
        {
            rand_func = new Random();
            window_width = windowWidth;
            window_height = windowHeight;
            frog = new FrogPlayer(5*32, 8 * 32);
            Raylib.InitWindow(windowWidth, windowHeight, "Frogger");

            CreateWorld();

        }

        private void CreateWorld()
        {
            world = new List<WorldTile>();
            floaties = new List<Floaties>();
            int tileWidth = 32;
            int tileHeight = 32;
            for(int y = window_height-32; y > 0; y-= tileHeight)
            {
                GenerateNewLine(y);
            }

        }

        public void GameLoop()
        {
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                // Game Logic goes here
                DrawWorld();
                HandleInput();
                HandleFloaties();
                HandleFrog();
                frog.UpdateFrog();

                DrawUI();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }

        private void DrawUI()
        {
            Raylib.DrawRectangle(0, 0, window_width, 48, Color.BLACK);
            Raylib.DrawText("Frogger!!!", 16, 0, 24, Color.WHITE);
            Raylib.DrawText("Points: " + frog_score, 16, 24, 24, Color.WHITE);
        }

        private void HandleFloaties()
        {
            foreach(Floaties floater in floaties)
            {
                floater.UpdateFloaty();
                var maybeCollision = floater.CheckCollision(frog.WorldPosition.GetX(), frog.WorldPosition.GetY());
                if (maybeCollision != null)
                {
                    frog.Attach(floater);
                }
                Raylib.DrawRectangle(floater.WorldPosition.GetX(), floater.WorldPosition.GetY() + 8, 32, 16, Color.BROWN);
            }
        }

        private void HandleFrog()
        {

            Raylib.DrawRectangle(frog.WorldPosition.GetX()+4, frog.WorldPosition.GetY()+4, 24, 24, Color.PURPLE);

        }

        private void MoveWorld()
        {
            foreach (WorldTile wt in world.ToList())
            {
                wt.WorldPosition.Y += 32;
            }

            foreach (Floaties fl in floaties.ToList())
            {
                fl.WorldPosition.Y += 32;
            }
            frog_score++;
            GenerateNewLine(1);
        }

        private void GenerateNewLine(int y)
        {
            for (int x = 0; x < 11; x++)
            {
                WorldTile newWT = new WorldTile(x * 32, y);
                if (_generateIsGrass)
                    newWT.WorldTileType = WorldTileType.Grass;
                else
                {
                    newWT.WorldTileType = WorldTileType.Water;
                    
                }
                world.Add(newWT);
            }

            if(_generateIsGrass == false)
            {
                Floaties fl = new Floaties(rand_func.Next(0, window_width), y-1, window_width);
                if(rand_func.Next(2) == 0)
                {
                    fl.isFloatingLeft = false;
                }

                floaties.Add(fl);
            }

            _generateIsGrass = !_generateIsGrass;
        }


        private void HandleInput()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
            {
                MoveWorld();
                frog.Detach();
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT))
            {
                frog.WorldPosition.X -= 32;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT))
            {
                frog.WorldPosition.X += 32;
            }
        }

        private void DrawWorld()
        {
            foreach(WorldTile wt in world)
            {
                Color colorToUse = Color.BLACK;
                switch (wt.WorldTileType)
                {
                    case WorldTileType.Grass:
                        colorToUse = Color.GREEN;
                        Raylib.DrawRectangle(wt.WorldPosition.GetX(), wt.WorldPosition.GetY(), 32, 32, colorToUse);
                        Raylib.DrawRectangleLines(wt.WorldPosition.GetX(), wt.WorldPosition.GetY(), 32, 32, Color.BLACK);
                        break;
                    case WorldTileType.Water:
                        colorToUse = Color.BLUE;
                        Raylib.DrawRectangle(wt.WorldPosition.GetX(), wt.WorldPosition.GetY(), 32, 32, colorToUse);
                        break;
                }
                
                
            }
        }

        private Color GetTileColor(WorldTileType wtt)
        {
            
            return Color.BLACK;
        }

    }
}
