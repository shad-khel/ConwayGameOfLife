﻿using System;
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

            var test = universe.GetNeighbours(1, 1);

            var stringShouldBeLike = new[]
            {
                testUniverse[0, 0].Print(), testUniverse[0, 1].Print(), testUniverse[0, 2].Print(),
                testUniverse[1, 0].Print(), selfToken                 , testUniverse[1, 2].Print(),
                testUniverse[2, 0].Print(), testUniverse[2, 1].Print(), testUniverse[2, 2].Print()
            };

            Assert.Equal(new string(stringShouldBeLike), test);
        }
         

        [Theory]
        [InlineData(0, 0, "BBBB0XB-X")]
        [InlineData(0, 1, "BBB-0--X-")]
        [InlineData(0, 2, "BBBX0BX-B")]
        [InlineData(1, 0, "B-XB0XB-X")]
        [InlineData(1, 1, "-X--0--X-")]
        [InlineData(1, 2, "X-BX0BX-B")]
        [InlineData(2, 0, "B-XB0XBBB")]
        [InlineData(2, 1, "-X--0-BBB")]
        [InlineData(2, 2, "X-BX0BBBB")]
        public void GetNeighbourTest1(int x, int y, string expectedResult)
        {
            char selfToken = '0';
            char outsideBoundsToken = 'B';  
            var universe = new Grid(GetKnownPattern());

            var test = universe.GetNeighbours(x, y);
            

            Assert.Equal(expectedResult, test);
        }


        public static UniverseSquare[,] GetKnownPattern()
        {
            //http://pi.math.cornell.edu/~lipa/mec/lesson6.html

            var example = new UniverseSquare[3, 3];
            example[0, 0] = new UniverseSquare(false); example[0, 1] = new UniverseSquare(true); example[0, 2] = new UniverseSquare(false);
            example[1, 0] = new UniverseSquare(false); example[1, 1] = new UniverseSquare(true); example[1, 2] = new UniverseSquare(false);
            example[2, 0] = new UniverseSquare(false); example[2, 1] = new UniverseSquare(true); example[2, 2] = new UniverseSquare(false);

            return example;
        }
    }
}
