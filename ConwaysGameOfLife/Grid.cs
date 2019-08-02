using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace ConwaysGameOfLife
{
    public class Grid
    {
        private readonly UniverseSquare[,] _universe;
        char _selfToken = '0';

        public Grid(int universeWidth, int universeHeight)
        {
            _universe = new UniverseSquare[universeWidth, universeHeight];
        }

        public UniverseSquare[,] GetUniverse()
        {
            return _universe;
        }

        public void SeedUniverse()
        {
            for (var i = 0; i < _universe.GetLength(0); i++)
            {
                for (var j = 0; j < _universe.GetLength(1); j++)
                {
                    _universe[i, j] = new UniverseSquare();
                    _universe[i,j].SetToRandomState();
                }
            }
        }

        public void Tick()
        {
            for (var i = 0; i < _universe.GetLength(0); i++)
            {
                for (var j = 0; j < _universe.GetLength(1); j++)
                {
                    //Get agjecent squares
                    //Apply Find which Rule Applys 
                    //Appy Rule
                }
            }
        }

        public string GetNeighbours(int x, int y)
        {
            var s = new[]
            {
                _universe[x - 1, y - 1].Print(), _universe[x - 1, y].Print(), _universe[x - 1, y + 1].Print(),
                _universe[x    , y - 1].Print(), _selfToken                 , _universe[x    , y + 1].Print(),
                _universe[x + 1, y - 1].Print(), _universe[x + 1, y].Print(), _universe[x + 1, y + 1].Print()
            };
        
            return s.ToString();
        }
    }
}
