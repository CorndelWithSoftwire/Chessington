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
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        public IEnumerable<Square> GetDiagonalMoves(Board board)
        {
            var currentPos = board.FindPiece(this);
            var currentRow = currentPos.Row;
            var currentCol = currentPos.Col;
            List<Square> availableMoves = new List<Square>();
            foreach (var col in Enumerable.Range(0, 8))
            {
                var columnsAway = col - currentCol;
                if (Enumerable.Range(0, 8).Contains(currentRow + columnsAway))
                {
                    availableMoves.Add(Square.At(currentRow + columnsAway, col));
                }
                if (Enumerable.Range(0, 8).Contains(currentRow - columnsAway))
                {
                    availableMoves.Add(Square.At(currentRow - columnsAway, col));
                }
            }
            availableMoves.RemoveAll(x => x == Square.At(currentRow, currentCol));
            return availableMoves; 
        }

        public IEnumerable<Square> GetLateralMoves(Board board)
        {
            var currentPos = board.FindPiece(this);
            var row = currentPos.Row;
            var col = currentPos.Col;
            List<Square> availableMoves = new List<Square>();
            foreach (var i in Enumerable.Range(0, 8))
            {
                availableMoves.Add(Square.At(row, i));
                availableMoves.Add(Square.At(i, col));
            }
            availableMoves.RemoveAll(x => x == Square.At(row, col));
            return availableMoves;
        }
    }
}