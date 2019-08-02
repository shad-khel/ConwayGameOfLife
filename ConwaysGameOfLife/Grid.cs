using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    class Grid
    {
        private readonly int _universeWidth;
        private readonly int _universeHeight;
        private UniverseSquare[][] universe;

        public Grid(int universeWidth, int universeHeight)
        {
            _universeWidth = universeWidth;
            _universeHeight = universeHeight;
        }

        public void SeedUniverse()
        {

        }

    }
}
