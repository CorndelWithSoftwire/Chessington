using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
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