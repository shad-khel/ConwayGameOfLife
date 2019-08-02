using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ConwaysGameOfLife;

namespace UnitTests
{
    public class GridTest:IDisposable
    {
        public GridTest()
        {
            
        }

        public void Dispose()
        {

        }

        [Fact]
        public void SeedWillGenarateNewUniverse_UniverseWillHaveAtLeastOneAliveSquare()
        {
            //Arrange
            var x = 10;
            var y = 10;
            var universe = new Grid(x, y);
            var aliveCheck = false;

            //Act
            universe.SeedUniverse();

            var universeArray = universe.GetUniverse();

            for(var i = 0; i < universeArray.GetLength(0); i++)
            {
                for (var j = 0; j < universeArray.GetLength(1); j++)
                {
                    if (universeArray[i,j].IsAlive())
                    {
                        aliveCheck = true;
                    };
                }
            }

            //Assert
            Assert.True(aliveCheck);
        }

        [Fact]
        public void PrintLine_PrintTheUniverserAtInputLine()
        {
            //Arrange
            var x = 10;
            var y = 10;
            var universe = new Grid(x, y);
            universe.SeedUniverse();
            var universeSquares = universe.GetUniverse();

            //Act
            var line = universeSquares.PrintHorizontalLine(0);

            //Assert
            Assert.Equal(universeSquares[0, 0].Print(), line[0]);
            Assert.Equal(universeSquares[0, 1].Print(), line[1]);
        }

        [Fact]
        public void GetNeibour_Center_AsString()
        {
            //Arrange
            var x = 10;
            var y = 10;
            char selfToken = '0';
            var universe = new Grid(x, y);
            universe.SeedUniverse();

            var testUniverse = universe.GetUniverse();

            var test = universe.GetNeighbours(3, 3);

            var stringShouldBeLike = new char[9];

            stringShouldBeLike[0] = testUniverse[0, 0].Print();
            stringShouldBeLike[1] = testUniverse[0, 1].Print();
            stringShouldBeLike[2] = testUniverse[0, 2].Print();
            stringShouldBeLike[3] = testUniverse[1, 0].Print();  
            stringShouldBeLike[4] = selfToken; //Self 1, 1
            stringShouldBeLike[5] = testUniverse[1, 2].Print();
            stringShouldBeLike[6] = testUniverse[2, 0].Print();
            stringShouldBeLike[7] = testUniverse[2, 1].Print();
            stringShouldBeLike[8] = testUniverse[2, 2].Print();

            Assert.Equal(stringShouldBeLike.ToString(), test);
        }


        [Fact]
        public void GetNeibour_TopOutsideBounds_AsString()
        {
            //Arrange
            var x = 10;
            var y = 10;
            char selfToken = '0';
            char outsideBoundsToken = 'B';
            var universe = new Grid(x, y);
            universe.SeedUniverse();

            var testUniverse = universe.GetUniverse();

            var test = universe.GetNeighbours(0, 3);

            var stringShouldBeLike = new char[9];

            stringShouldBeLike[0] = outsideBoundsToken;
            stringShouldBeLike[1] = outsideBoundsToken;
            stringShouldBeLike[2] = outsideBoundsToken;
            stringShouldBeLike[3] = testUniverse[1, 0].Print();
            stringShouldBeLike[4] = selfToken; //Self 1, 1
            stringShouldBeLike[5] = testUniverse[1, 2].Print();
            stringShouldBeLike[6] = testUniverse[2, 0].Print();
            stringShouldBeLike[7] = testUniverse[2, 1].Print();
            stringShouldBeLike[8] = testUniverse[2, 2].Print();

            Assert.Equal(stringShouldBeLike.ToString(), test);
        }
    }
}
