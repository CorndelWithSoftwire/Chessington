using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPos = board.FindPiece(this);
            var currentRow = currentPos.Row;
            var currentCol = currentPos.Col;
            List<Square> availableMoves = new List<Square>();

            availableMoves.Add(Square.At(currentRow - 2, currentCol + 1));
            availableMoves.Add(Square.At(currentRow - 2, currentCol - 1));
            availableMoves.Add(Square.At(currentRow - 1, currentCol + 2));
            availableMoves.Add(Square.At(currentRow - 1, currentCol - 2));
            availableMoves.Add(Square.At(currentRow + 1, currentCol + 2));
            availableMoves.Add(Square.At(currentRow + 1, currentCol - 2));
            availableMoves.Add(Square.At(currentRow + 2, currentCol - 1));
            availableMoves.Add(Square.At(currentRow + 2, currentCol + 1));

            return availableMoves.Where(square => square.CanMoveOrTake(board, this));

        }
    }
}