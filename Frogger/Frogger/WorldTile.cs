using System;
using System.Collections.Generic;
using System.Text;

namespace Frogger
{
    public enum WorldTileType
    {
        NotSet,
        Border,
        Grass,
        Water,
        Street
    }

    public class WorldTile
    {
        public WorldPosition WorldPosition { get; set; }
        public WorldTileType WorldTileType { get; set; } = WorldTileType.NotSet;

        public WorldTile(int x, int y)
        {
            WorldPosition = new WorldPosition(x, y);
        }
    }
}
