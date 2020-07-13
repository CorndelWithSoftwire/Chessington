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
    }
}