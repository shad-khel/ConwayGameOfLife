using System;
using System.Collections.Generic;
using System.Text;
using ConwaysGameOfLife;
using Xunit;

namespace UnitTests
{
    public class UniverseRulesTest
    {
        [Fact]
        public void UnderPopulated_Should_Die()
        {
            string test = "----0----";
            var result = UniverseRules.Underpopulated(test, GridSquareStatus.Alive);
            Assert.Equal(GridSquareStatusResult.Die, result);
        }

        [Fact]
        public void NotUnderPopulated_ShouldNot_Die()
        {
            string test = "XX-0----";
            var result = UniverseRules.Underpopulated(test, GridSquareStatus.Alive);
            Assert.NotEqual(GridSquareStatusResult.Die, result);
            Assert.Equal(GridSquareStatusResult.NoChange, result);
        }

        [Fact]
        public void OverPopulated_Should_Die()
        {
            string test = "XXX0X---";
            var result = UniverseRules.OverPopulated(test, GridSquareStatus.Alive);
            Assert.Equal(GridSquareStatusResult.Die, result);
        }

        [Fact]
        public void NotOverPopulated_Should_NotDie_FromOverPopulation()
        {
            string test = "XX-0X---";
            var result = UniverseRules.OverPopulated(test, GridSquareStatus.Alive);
            Assert.NotEqual(GridSquareStatusResult.Die, result);
            Assert.Equal(GridSquareStatusResult.NoChange, result);
        }

        [Fact]
        public void Correct_Ammount_Should_Reproduction()
        {
            string test = "XX-0X---";
            var result = UniverseRules.DeadAndCorrectAmountOfNeighboursToLive(test, GridSquareStatus.Dead);
            Assert.Equal(GridSquareStatusResult.Live, result);
        }

        [Fact]
        public void NotCorrect_Ammount_ShouldNot_Reproduction()
        {
            string test = "XX-0XX--";
            var result = UniverseRules.DeadAndCorrectAmountOfNeighboursToLive(test, GridSquareStatus.Dead);
            Assert.NotEqual(GridSquareStatusResult.Live, result);
        }

        [Fact]
        public void NotCorrect_Ammount_ShouldNot_Reproduction2()
        {
            string test = "XX-0----";
            var result = UniverseRules.DeadAndCorrectAmountOfNeighboursToLive(test, GridSquareStatus.Dead);
            Assert.NotEqual(GridSquareStatusResult.Live, result);
        }

        [Fact]
        public void CorrectAmmound_Should_StayAlive()
        {
            string test = "XX-0----";
            var result = UniverseRules.AliveAndCorrectAmountOfNeighboursToLive(test, GridSquareStatus.Alive);
            Assert.Equal(GridSquareStatusResult.Live, result);
        }

        [Fact]
        public void CorrectAmmound_Should_StayAlive2()
        {
            string test = "XXX0----";
            var result = UniverseRules.AliveAndCorrectAmountOfNeighboursToLive(test, GridSquareStatus.Alive);
            Assert.Equal(GridSquareStatusResult.Live, result);
        }

        [Fact]
        public void NotCorrectAmmound_ShouldNot_ActivateStayAlive()
        {
            string test = "XX-0--XX";
            var result = UniverseRules.AliveAndCorrectAmountOfNeighboursToLive(test, GridSquareStatus.Alive);
            Assert.NotEqual(GridSquareStatusResult.Live, result);
        }
    }
}
