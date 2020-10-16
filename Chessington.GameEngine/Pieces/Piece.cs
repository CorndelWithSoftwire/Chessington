using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
            HasMoved = false;
        }

        public Player Player { get; private set; }
        public bool HasMoved { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            HasMoved = true;
        }

        public void AddIfOnBoard(Square square, List<Square> moves)
        {
            if (!(square.Col < 0 | square.Col >= GameSettings.BoardSize | square.Row < 0 |
                square.Row >= GameSettings.BoardSize))
            {
                moves.Add(square);
            }
        }
    }
}