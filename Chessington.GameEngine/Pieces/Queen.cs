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
            var moves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            var directions = CardinalDirections.Concat(DiagonalDirections).ToList();
            var helpers = new Helpers();
            for (int i = 1; i < GameSettings.BoardSize; i++)
            {
                directions = helpers.AddMovesAndUpdateDirections(board, directions, currentSquare, i, moves, this.Player);
            }

            return moves;
        }
    }
}