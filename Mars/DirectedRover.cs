using Mars.Helper;
using System;

namespace Mars
{
    public abstract class DirectedRover
    {
        protected Rover _Rover;
        public Direction Direction { get; protected set; }
        public DirectedRover(Rover rover)
        {
            _Rover = rover;
        }
        /// <summary>
        /// According to direction of rover, it moves on
        /// </summary>
        public abstract void Move();

        /// <summary>
        /// Return the current position of rover
        /// </summary>
        /// <returns></returns>
        public string GetLastPosition()
        {
            return string.Format("{0} {1} {2}", _Rover.X, _Rover.Y, (char)Direction);
        }
        public Rover GetRover()
        {
            return _Rover;
        }
    }
    /// <summary>
    /// The rover which is directed to East
    /// </summary>
    public class EastDirectedRover : DirectedRover
    {
        public EastDirectedRover(Rover rover) : base(rover)
        {
            Direction = Direction.East;
        }

        public override void Move()
        {            
            _Rover.SetX(_Rover.X + 1);
        }
    }
    /// <summary>
    /// The rover which is directed to West
    /// </summary>
    public class WestDirectedRover : DirectedRover
    {
        public WestDirectedRover(Rover rover) : base(rover)
        {
            Direction = Direction.West;
        }

        public override void Move()
        {
            _Rover.SetX(_Rover.X - 1);
        }
    }
    /// <summary>
    /// The rover which is directed to South
    /// </summary>
    public class SouthDirectedRover : DirectedRover
    {
        public SouthDirectedRover(Rover rover) : base(rover)
        {
            Direction = Direction.South;
        }

        public override void Move()
        {
            _Rover.SetY(_Rover.Y - 1);
        }
    }
    /// <summary>
    /// The rover which is directed to North
    /// </summary>
    public class NorthDirectedRover : DirectedRover
    {
        public NorthDirectedRover(Rover rover) : base(rover)
        {
            Direction = Direction.North;
        }

        public override void Move()
        {
            _Rover.SetY(_Rover.Y + 1);
        }
    }
    /// <summary>
    /// The class is used when Undefined Direction is entered
    /// </summary>
    public class NullDirectedRover : DirectedRover
    {
        public NullDirectedRover(Rover rover) : base(rover)
        {

        }

        public override void Move()
        {
            throw new Exception("Written Direction is not correct");
        }
    }
}
