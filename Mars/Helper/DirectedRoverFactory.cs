using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Helper
{
    public static class DirectedRoverFactory
    {
        /// <summary>
        // The method is used for first intialization of rover        
        /// </summary>
        /// <param name="rover"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static DirectedRover Create(Rover rover, Direction direction)
        {
            switch (direction)
            {
                case Direction.East:
                    return new EastDirectedRover(rover);
                case Direction.West:
                    return new WestDirectedRover(rover);
                case Direction.South:
                    return new SouthDirectedRover(rover);
                case Direction.North:
                    return new NorthDirectedRover(rover);
                default:
                    return new NullDirectedRover(rover);
            }

        }
        /// <summary>
        /// The method is used for rotating directed rover
        /// There are two rotations(left or right) First ifs are right. If not it is accepted as left rotation.
        /// </summary>
        /// <param name="rover"></param>
        /// <param name="direction"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public static DirectedRover Create(Rover rover, Direction direction, Rotation rotation)
        {
            switch (direction)
            {
                case Direction.East:
                    if (rotation == Rotation.Right)
                    {
                        return new SouthDirectedRover(rover);
                    }
                    return new NorthDirectedRover(rover);
                case Direction.West:
                    if (rotation == Rotation.Right)
                    {
                        return new NorthDirectedRover(rover);
                    }
                    return new SouthDirectedRover(rover);
                case Direction.North:
                    if (rotation == Rotation.Right)
                    {
                        return new EastDirectedRover(rover);
                    }
                    return new WestDirectedRover(rover);
                case Direction.South:
                    if (rotation == Rotation.Right)
                    {
                        return new WestDirectedRover(rover);
                    }
                    return new EastDirectedRover(rover);
                default:
                    throw new Exception("The Direction is not correct");
            }
        }
    }
}
