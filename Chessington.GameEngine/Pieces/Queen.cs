using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var lateralMoves = GetAvailableLateralMoves(board);
            var diagonalMoves = GetAvailableDiagonalMoves(board);

            return lateralMoves.Union(diagonalMoves);
        }
    }
}