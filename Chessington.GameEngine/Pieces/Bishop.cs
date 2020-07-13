using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            for (int i = -GameSettings.BoardSize; i < GameSettings.BoardSize; i++)
            {
                if ((board.FindPiece(this).Row + i <= GameSettings.BoardSize) && (board.FindPiece(this).Col + i <= GameSettings.BoardSize))
                {
                    availableMoves.Add(Square.At(board.FindPiece(this).Row + i, board.FindPiece(this).Col + i));
                }
                else if ((board.FindPiece(this).Row + i <= GameSettings.BoardSize) && (board.FindPiece(this).Col - i >= 0))
                {
                    availableMoves.Add(Square.At(board.FindPiece(this).Row + i, board.FindPiece(this).Col - i));
                }
            }

            return availableMoves;
        }

        private bool CheckPosition(int row, int col)
        {
            return (row <= GameSettings.BoardSize && row >= 0 && col <= GameSettings.BoardSize && col >= 0
                ? true
                : false);
        }
    }
}