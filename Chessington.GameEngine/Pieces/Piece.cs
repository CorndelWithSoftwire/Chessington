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
            List<Square> availableMoves = new List<Square>();

            availableMoves.AddRange(ExploreInOneDirection(1, 0, board));
            availableMoves.AddRange(ExploreInOneDirection(-1, 0, board));
            availableMoves.AddRange(ExploreInOneDirection(0, 1, board));
            availableMoves.AddRange(ExploreInOneDirection(0, -1, board));

            availableMoves.OrderBy(x => x.Row).OrderByDescending(x => x.Col);

            return availableMoves;
        }

        public IEnumerable<Square> ExploreInOneDirection(int rowDirection, int colDirection, Board board)
        {
            var currentPos = board.FindPiece(this);
            var currentRow = currentPos.Row;
            var currentCol = currentPos.Col;
            List<Square> availableMoves = new List<Square>();

            int tileDistance = 1;
            while (Square.At(currentRow + tileDistance * rowDirection, currentCol + tileDistance * colDirection)
                       .IsInbound() &&
                   !Square.At(currentRow + tileDistance * rowDirection, currentCol + tileDistance * colDirection)
                       .IsOccupied(board))
            {
                availableMoves.Add(Square.At(currentRow + tileDistance * rowDirection,
                    currentCol + tileDistance * colDirection));
                tileDistance++;
            }

            return availableMoves;
        }
    }
}