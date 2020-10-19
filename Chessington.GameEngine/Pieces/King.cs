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
            var directions = CardinalDirections.Concat(DiagonalDirections).ToList();
            var helpers = new Helpers();
            directions = helpers.AddMovesAndUpdateDirections(board, directions, currentSquare, 1, moves, this.Player);
            return moves;
        }
    }
}