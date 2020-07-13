using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();

            for (var i = 0; i <= 7; i++)
            {
                var row = KnightPosition(board.FindPiece(this), i).Row;
                var col = KnightPosition(board.FindPiece(this), i).Col;
                if (CheckPosition(row, col))
                {
                    availableMoves.Add(Square.At(row,col));
                }
            }

            return availableMoves;
        }
        
        private bool CheckPosition(int row, int col)
        {
            return row < GameSettings.BoardSize && row >= 0 && col < GameSettings.BoardSize && col >= 0;
        }

        private Square KnightPosition(Square initialPosition, int direction)
        {
            if (direction % 2 == 0)
            {
                return Square.At(initialPosition.Row + (direction % 4 == 0 ? 1 : -1) * 2, initialPosition.Col + (direction > 3.5 ? 1 : -1));
            }
            else
            {
                return Square.At(initialPosition.Row + (direction > 3.5 ? 1 : -1), initialPosition.Col + (direction % 4 == 1 ? 1 : -1) * 2);
            }
        }
    }
}