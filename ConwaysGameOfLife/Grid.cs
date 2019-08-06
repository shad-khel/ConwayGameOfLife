using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace ConwaysGameOfLife
{
    public class Grid
    {
        //I need this to be readOnly but replaceable with the next world
        private UniverseSquare[,]  _universe;
        private const char SelfToken = '0';
        private const char OutsideBoundsToken = 'B';
        private delegate GridSquareStatusResult UniverseRule(string neighbours, GridSquareStatus cellStatus);
        private List<UniverseRule> rr;

        public Grid(int universeWidth, int universeHeight)
        {
            _universe = new UniverseSquare[universeWidth, universeHeight];

            rr = new List<UniverseRule>
            {
                new UniverseRule(UniverseRules.Underpopulated),
                new UniverseRule(UniverseRules.OverPopulated),
                new UniverseRule(UniverseRules.AliveAndCorrectAmountOfNeighboursToLive),
                new UniverseRule(UniverseRules.DeadAndCorrectAmountOfNeighboursToLive)
            };
        }

        public Grid(UniverseSquare[,] universe)
        {
            _universe = universe;

            //Move these to somthing else
            rr = new List<UniverseRule>
            {
                new UniverseRule(UniverseRules.Underpopulated),
                new UniverseRule(UniverseRules.OverPopulated),
                new UniverseRule(UniverseRules.AliveAndCorrectAmountOfNeighboursToLive),
                new UniverseRule(UniverseRules.DeadAndCorrectAmountOfNeighboursToLive)
            };
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
            var nextWorld = new UniverseSquare[_universe.GetLength(0), _universe.GetLength(1)];
            //not shallow copy
            for (var i = 0; i < nextWorld.GetLength(0); i++)
            {
                for (var j = 0; j < nextWorld.GetLength(1); j++)
                {
                    nextWorld[i,j] =  new UniverseSquare(false);
                }
            }


           

            for (var i = 0; i < _universe.GetLength(0); i++)
            {
                for (var j = 0; j < _universe.GetLength(1); j++)
                {

                    var nextWorldCellResult = GridSquareStatusResult.NoChange;

                    //Get adjecent squares
                    var aj = GetNeighbours(i, j);

                    //Find which Rule Applys
                    foreach (var rule in rr)
                    {
                        var result = rule( aj, _universe[i, j].GridStatus() );

                        if (result == GridSquareStatusResult.Live || result == GridSquareStatusResult.Die)
                        {
                            nextWorldCellResult = result;
                        }
                    }

                    //Appy Rule to next world
                    switch (nextWorldCellResult)
                    {
                        case GridSquareStatusResult.Live:
                            nextWorld[i, j].SetToAlive();
                            break;
                        case GridSquareStatusResult.Die:
                            nextWorld[i, j].SetToDie();
                            break;
                        case GridSquareStatusResult.NoChange:
                            nextWorld[i, j] = _universe[i, j];
                            break;
                    }
                }
            }

            //Replace current world with new world
            _universe =  nextWorld;
        }

        public string GetNeighbours(int x, int y)
        {
            var s = new[]
            {
                PrintSafeChar(x - 1, y - 1), PrintSafeChar(x - 1, y), PrintSafeChar(x - 1, y + 1),
                PrintSafeChar(x    , y - 1), SelfToken              , PrintSafeChar(x    , y + 1),
                PrintSafeChar(x + 1, y - 1), PrintSafeChar(x + 1, y), PrintSafeChar(x + 1, y + 1)
            };
        
            return new string(s);
        }

        private char PrintSafeChar(int x, int y)
        {
            if (x > -1 && y > -1 && y < (_universe.GetUpperBound(1) +1) && x < (_universe.GetUpperBound(0)+1) )
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
