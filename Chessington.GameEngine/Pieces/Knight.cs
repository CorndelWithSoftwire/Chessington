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
            var currentPos = board.FindPiece(this);
            var currentRow = currentPos.Row;
            var currentCol = currentPos.Col;
            List<Square> availableMoves = new List<Square>();

            if (Square.At(currentRow - 2, currentCol + 1).IsInbound())
                availableMoves.Add(Square.At(currentRow - 2, currentCol + 1));
            if (Square.At(currentRow - 2, currentCol - 1).IsInbound())
                availableMoves.Add(Square.At(currentRow - 2, currentCol - 1));
            if (Square.At(currentRow - 1, currentCol + 2).IsInbound())
                availableMoves.Add(Square.At(currentRow - 1, currentCol + 2));
            if (Square.At(currentRow - 1, currentCol - 2).IsInbound())
                availableMoves.Add(Square.At(currentRow -1, currentCol -2));
            if (Square.At(currentRow + 1, currentCol + 2).IsInbound())
                availableMoves.Add(Square.At(currentRow + 1, currentCol + 2));
            if (Square.At(currentRow + 1, currentCol - 2).IsInbound())
                availableMoves.Add(Square.At(currentRow + 1, currentCol - 2));
            if (Square.At(currentRow +2, currentCol - 1).IsInbound())
                availableMoves.Add(Square.At(currentRow +2, currentCol -1));
            if (Square.At(currentRow +2, currentCol + 1).IsInbound())
                availableMoves.Add(Square.At(currentRow +2, currentCol + 1));

            availableMoves.OrderBy(x => x.Row).OrderByDescending(x => x.Col);
            return availableMoves;
        }
    }
}