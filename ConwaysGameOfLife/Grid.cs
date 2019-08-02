using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace ConwaysGameOfLife
{
    public class Grid
    {
        private readonly UniverseSquare[,] _universe;

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
            //for (var i = 0; i < _universe.GetLength(0); i++)
            //{
            //    for (var j = 0; j < _universe.GetLength(1); j++)
            //    {
            //        //Get agjecent squares
            //        //Apply Find which Rule Applys 
            //        //Appy Rule
            //    }
            //}
        }
    }
}
