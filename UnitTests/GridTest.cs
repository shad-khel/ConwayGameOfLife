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
                    if (universeArray[i][j].IsAlive())
                    {
                        aliveCheck = true;
                    };
                }
            }

            //Assert
            Assert.True(aliveCheck);
        }
       
    }
}
