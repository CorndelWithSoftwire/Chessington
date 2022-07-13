using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected int MovesCount;
        
        protected Piece(Player player)
        {
            Player = player;
            MovesCount = 0;
        }

        public Player Player { get; private set; }

        public int GetMovesCount()
        {
            return MovesCount;
        }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public virtual void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            this.MovesCount++;
        }
    }
}