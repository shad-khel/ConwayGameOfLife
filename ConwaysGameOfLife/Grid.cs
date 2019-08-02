using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    public class Grid
    {
        private readonly int _universeWidth;
        private readonly int _universeHeight;
        private UniverseSquare[,] universe;

        public Grid(int universeWidth, int universeHeight)
        {
            _universeWidth = universeWidth;
            _universeHeight = universeHeight;
            universe = new UniverseSquare[universeWidth, universeHeight];
        }

        public UniverseSquare[,] GetUniverse()
        {
            return universe;
        }

        public void SeedUniverse()
        {
            for (var i = 0; i < universe.GetLength(0); i++)
            {
                for (var j = 0; j < universe.GetLength(1); j++)
                {
                    universe[i, j] = new UniverseSquare();
                    universe[i,j].SetToRandomState();
                }
            }
        }
    }
}
