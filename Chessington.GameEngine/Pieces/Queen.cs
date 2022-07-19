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
            var expectedMoves = new List<Square>();

            for (int i = 0; i < 8; i++)
                expectedMoves.Add(Square.At(board.FindPiece(this).Row, i));

            for (int i = 0; i < 8; i++)
                expectedMoves.Add(Square.At(i, board.FindPiece(this).Col));



            return expectedMoves;
        }
    }
}