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
        private bool _generateIsGrass = true;
        private FrogPlayer frog;

        public FroggerGame(int windowWidth, int windowHeight)
        {
            window_width = windowWidth;
            window_height = windowHeight;
            frog = new FrogPlayer(5*32, 8 * 32);
            Raylib.InitWindow(windowWidth, windowHeight, "Frogger");

            CreateWorld();

        }

        private void CreateWorld()
        {
            world = new List<WorldTile>();

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
                HandleFrog();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }

        private void HandleFrog()
        {

            Raylib.DrawRectangle(frog.WorldPosition.X, frog.WorldPosition.Y, 24, 24, Color.PURPLE);

        }

        private void MoveWorld()
        {
            foreach(WorldTile wt in world.ToList())
            {
                wt.WorldPosition.Y += 32;
            }

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
                    newWT.WorldTileType = WorldTileType.Water;

                world.Add(newWT);

            }
            _generateIsGrass = !_generateIsGrass;
        }


        private void HandleInput()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
            {
                MoveWorld();
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
                        Raylib.DrawRectangle(wt.WorldPosition.X, wt.WorldPosition.Y, 32, 32, colorToUse);
                        Raylib.DrawRectangleLines(wt.WorldPosition.X, wt.WorldPosition.Y, 32, 32, Color.BLACK);
                        break;
                    case WorldTileType.Water:
                        colorToUse = Color.BLUE;
                        Raylib.DrawRectangle(wt.WorldPosition.X, wt.WorldPosition.Y, 32, 32, colorToUse);
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
