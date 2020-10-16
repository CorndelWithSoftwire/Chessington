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
            var moves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            for (int i = 1; i < GameSettings.BoardSize; i++)
            {
                var row = (currentSquare.Row + i) % GameSettings.BoardSize;
                var col = (currentSquare.Col + i) % GameSettings.BoardSize;
                moves.Add(new Square(currentSquare.Row, col));
                moves.Add(new Square(row, currentSquare.Col));
            }

            return moves;
        }
    }
}