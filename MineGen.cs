using System;
using System.Collections.Generic;
using System.Linq;

namespace Mine
{
    class MineGen
    {
        public static void Generate(List<Tile> tiles, int mine_count)
        {
            var RN = new Random();
            List<int> randonNums = new List<int>();
            for (int j = 0; j < mine_count; j++)
            {
                var rn = RN.Next(0, tiles.Count);
                while (randonNums.Contains(rn))
                { 
                    rn = RN.Next(0, tiles.Count);
                }
                randonNums.Add(rn);
                tiles[rn].IsMine = true;                
            }
            foreach (Tile tile in tiles)
            {
                var h = 0;
                foreach (Tile t in tile.Neighbors)
                {
                    if (t.IsMine == true) h++;
                }
                tile.Hint = h;
            }
        }
    }
}
