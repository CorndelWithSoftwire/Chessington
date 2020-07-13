using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            for (int i = 0; i < GameSettings.BoardSize; i++)
            {
                availableMoves.Add(Square.At(board.FindPiece(this).Row, i));
                availableMoves.Add(Square.At(i, board.FindPiece(this).Col));
            }

            return availableMoves;
        }
    }
}