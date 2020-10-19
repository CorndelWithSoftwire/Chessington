using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            var i = 1;
            var directions = CardinalDirections.Concat(DiagonalDirections);
            foreach (var direction in directions)
            {
                moves.AddIfOnBoard(Square.At(currentSquare.Row + i * direction.RowOffset, currentSquare.Col + i * direction.ColOffset));
            }

            return moves;
        }
    }
}