using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var initialRow = board.FindPiece(this).Row;
            var initialCol = board.FindPiece(this).Col;
            var availableMoves = new List<Square>();

            for (var i = -GameSettings.BoardSize; i <= GameSettings.BoardSize; i++)
            {
                if (CheckPosition(initialRow + i, initialCol + i))
                {
                    availableMoves.Add(Square.At(initialRow + i, initialCol + i));
                }

                if (CheckPosition(initialRow + i, initialCol - i))
                {
                    availableMoves.Add(Square.At(initialRow + i, initialCol - i));
                }
            }
            availableMoves.RemoveAll(x => x == Square.At(initialRow,initialCol));

            return availableMoves;
        }

        public Bishop(Player player)
            : base(player) { }

        private bool CheckPosition(int row, int col)
        {
            return row < GameSettings.BoardSize && row >= 0 && col < GameSettings.BoardSize && col >= 0;
        }
    }
}