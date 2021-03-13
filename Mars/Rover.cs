using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars
{
    public class Rover
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public int MaxX { get; private set; }
        public int MaxY { get; private set; }

        private const int MinX = 0;
        private const int MinY = 0;
        public Rover(int x, int y, int maxX, int maxY)
        {
            X = x;
            Y = y;
            MaxX = maxX;
            MaxY = maxY;
        }
        /// <summary>
        /// Set x between minx and maxx        
        /// </summary>
        /// <param name="x"></param>
        public void SetX(int x)
        {
            if (x >= MinX && x <= MaxX)
            {
                X = x;
            }
        }
        /// <summary>
        /// Set y between miny and maxy
        /// </summary>
        /// <param name="y"></param>
        public void SetY(int y)
        {
            if (y >= MinY && y <= MaxY)
            {
                Y = y;
            }
        }
    }
}
