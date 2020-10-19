using System;

namespace Chessington.GameEngine
{
    public class Direction
    {
        public int RowOffset { get; private set; }
        public int ColOffset { get; private set; }

        public Direction(int rowOffset, int colOffset)
        {
            RowOffset = rowOffset;
            ColOffset = colOffset;
        }
    }
}

