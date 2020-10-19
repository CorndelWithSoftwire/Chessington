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
            var moves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            var directions = DiagonalDirections;
            for (int i = 1; i < GameSettings.BoardSize; i++)
            {
                foreach (var direction in directions)
                {
                    moves.AddIfOnBoard(Square.At(currentSquare.Row + i * direction.Item1, currentSquare.Col + i * direction.Item2));
                }
            }

            return moves;
        }
    }
}