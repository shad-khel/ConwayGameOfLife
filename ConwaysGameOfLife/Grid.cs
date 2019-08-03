using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace ConwaysGameOfLife
{
    public class Grid
    {
        private readonly UniverseSquare[,] _universe;
        private const char SelfToken = '0';
        private const char OutsideBoundsToken = 'B';

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
                    var aj = GetNeighbours(i, j);
                    //Apply Find which Rule Applys
                    
                    //Appy Rule to next world
                }
            }

            //Replace current world with new world
        }

        public string GetNeighbours(int x, int y)
        {
            var s = new[]
            {
                PrintSafeChar(x - 1, y - 1), PrintSafeChar(x - 1, y), PrintSafeChar(x - 1, y + 1),
                PrintSafeChar(x    , y - 1), SelfToken             , PrintSafeChar(x    , y + 1),
                PrintSafeChar(x + 1, y - 1), PrintSafeChar(x + 1, y), PrintSafeChar(x + 1, y + 1)
            };
        
            return s.ToString();
        }

        private char PrintSafeChar(int x, int y)
        {
            if (x > 0 && y > 0 && y < _universe.GetLength(1) && x < _universe.GetLength(0))
            {
                return _universe[x, y].Print();
            }
            else
            {
                return OutsideBoundsToken;
            }
        }
    }
}
