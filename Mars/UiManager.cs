using Mars.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mars
{
    public static class UiManager
    {
        /// <summary>
        /// Returns last positions of rovers
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <returns></returns>
        public static string GetLastPositionsOfRovers(List<MarsRoverInput> inputs, int maxX, int maxY)
        {
            var sb = new StringBuilder();
            foreach (var input in inputs)
            {
                var positionArr = input.Position.Split(' ');
                var x = Convert.ToInt32(positionArr[0]);
                var y = Convert.ToInt32(positionArr[1]);

                var rover = DirectedRoverFactory.Create(new Rover(x, y, maxX, maxY), (Direction)positionArr[2][0]);
                foreach (var instruction in input.Instruction)
                {
                    if (instruction.Equals('M') || instruction.Equals('R') || instruction.Equals('L'))
                    {
                        if (instruction.Equals('R') || instruction.Equals('L'))
                        {
                            rover = DirectedRoverFactory.Create(rover.GetRover(), rover.Direction, (Rotation)instruction);
                        }
                        else
                        {
                            rover.Move();
                        }
                    }
                    else
                    {
                        throw new Exception("The Instruction contains unexpected value");
                    }
                }
                sb.AppendLine(rover.GetLastPosition());
            }
            return sb.ToString();
        }
    }
}
