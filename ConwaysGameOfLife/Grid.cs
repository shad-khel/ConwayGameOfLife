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
        char _outsideBoundsToken = 'B';

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
                PrintSafeChar(x - 1, y - 1), PrintSafeChar(x - 1, y), PrintSafeChar(x - 1, y + 1),
                PrintSafeChar(x    , y - 1), _selfToken                 , PrintSafeChar(x    , y + 1),
                PrintSafeChar(x + 1, y - 1), PrintSafeChar(x + 1, y), PrintSafeChar(x + 1, y + 1)
            };
        
            return s.ToString();
        }

        private char PrintSafeChar(int x, int y)
        {
            if (x > 0 && y > 0)
            {
                return _universe[x, y].Print();
            }
            else
            {
                return _outsideBoundsToken;
            }
        }
    }
}
