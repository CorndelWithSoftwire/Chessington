using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
            HasMoved = false;
            CardinalDirections = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(0, -1),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(-1, 0)
            };
            DiagonalDirections = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(1, -1),
                new Tuple<int, int>(-1, -1),
                new Tuple<int, int>(-1, 1)
            };
        }

        public Player Player { get; private set; }
        public bool HasMoved { get; private set; }
        public List<Tuple<int, int>> CardinalDirections { get; private set; }
        public List<Tuple<int, int>> DiagonalDirections { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            HasMoved = true;
        }
    }
}