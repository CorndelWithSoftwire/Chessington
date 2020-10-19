using System;

namespace Chessington.GameEngine
{
    public class Direction
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Direction(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

