using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        public Player Player { get; }
        public bool HasMoved { get; private set; }
        public List<Direction> CardinalDirections { get; } = new List<Direction>
        {
            new Direction(0,1),
            new Direction(0,-1),
            new Direction(-1,0),
            new Direction(1,0),
        };
        public List<Direction> DiagonalDirections { get; } = new List<Direction>
        {
            new Direction(1,1),
            new Direction(1,-1),
            new Direction(-1,1),
            new Direction(-1,-1),
        };

        protected Piece(Player player)
        {
            Player = player;
            HasMoved = false;
        }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            HasMoved = true;
        }
    }
}