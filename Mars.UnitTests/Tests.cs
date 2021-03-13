using System;
using System.Collections.Generic;
using Mars.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mars.UnitTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [DataRow("5 5", "1 2 E", "LRLRLRRRLL", 'E')]
        [DataRow("5 5", "1 2 N", "LLLRRLRLRRRR", 'S')]
        public void Rovers_ShouldBe_Rotated(string uppperCordinats, string firstPosition, string rotations, char expectedDirection)
        {
            //Arrange
            var uppperCordinatsArr = uppperCordinats.Split(' ');
            var firstPositionArr = firstPosition.Split(' ');
            var maxX = Convert.ToInt32(uppperCordinatsArr[0]);
            var maxY = Convert.ToInt32(uppperCordinatsArr[1]);
            var x = Convert.ToInt32(firstPositionArr[0]);
            var y = Convert.ToInt32(firstPositionArr[1]);
            var direction = firstPositionArr[2][0];
            var rover = DirectedRoverFactory.Create(new Rover(x, y, maxX, maxY), (Direction)direction);
            //Act
            for (int i = 0; i < rotations.Length; i++)
            {
                rover = DirectedRoverFactory.Create(rover.GetRover(), rover.Direction, (Rotation)rotations[i]);
            }
            //Assert
            Assert.AreEqual(expectedDirection, (char)rover.Direction);
        }
        [TestMethod]
        [DataRow("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
        [DataRow("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
        [DataRow("3 3", "3 3 S", "MMRMMRMRRM", "1 1 S")]
        [DataRow("4 4", "0 0 W", "MMRMMRMRRM", "0 2 W")]
        public void Rovers_Should_Explore(string uppperCordinats, string firstPosition, string rotations, string expectedPosition)
        {
            //Arrange
            var uppperCordinatsArr = uppperCordinats.Split(' ');
            var maxX = Convert.ToInt32(uppperCordinatsArr[0]);
            var maxY = Convert.ToInt32(uppperCordinatsArr[1]);
            var marsRoverinputs = new List<MarsRoverInput>();
            marsRoverinputs.Add(new MarsRoverInput() { Instruction = rotations, Position = firstPosition });

            //Act
            var lastPositionOfRover = UiManager.GetLastPositionsOfRovers(marsRoverinputs, maxX, maxY);

            //Assert
            Assert.AreEqual(expectedPosition, lastPositionOfRover.TrimEnd());
        }
    }
}
