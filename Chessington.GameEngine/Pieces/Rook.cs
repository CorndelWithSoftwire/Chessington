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
            var expectedMoves = new List<Square>();

            for (var i = 0; i < 8; i++)
                expectedMoves.Add(Square.At(board.FindPiece(this).Row, i));

            for (var i = 0; i < 8; i++)
                expectedMoves.Add(Square.At(i, board.FindPiece(this).Col));

            //Get rid of our starting location.
            expectedMoves.RemoveAll(s => s == Square.At(board.FindPiece(this).Row, board.FindPiece(this).Col));

            return expectedMoves;
        }
    }
}