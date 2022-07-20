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
            var expectedMoves = new List<Square>();

            if (board.FindPiece(this).Row - 1 >= 0 && board.FindPiece(this).Col + 1 <= 7 && !board.isSquareOccupiedByFriend(board.FindPiece(this).Row - 1, board.FindPiece(this).Col + 1))
                expectedMoves.Add(Square.At(board.FindPiece(this).Row - 1, board.FindPiece(this).Col + 1));

            if (board.FindPiece(this).Row - 1 >= 0 && board.FindPiece(this).Col - 1 >= 0 && !board.isSquareOccupiedByFriend(board.FindPiece(this).Row - 1, board.FindPiece(this).Col - 1))
                expectedMoves.Add(Square.At(board.FindPiece(this).Row - 1, board.FindPiece(this).Col - 1));

            if (board.FindPiece(this).Row - 1 >= 0 && !board.isSquareOccupiedByFriend(board.FindPiece(this).Row - 1, board.FindPiece(this).Col))
                expectedMoves.Add(Square.At(board.FindPiece(this).Row - 1, board.FindPiece(this).Col));

            if (board.FindPiece(this).Row + 1 <= 7 && !board.isSquareOccupiedByFriend(board.FindPiece(this).Row + 1, board.FindPiece(this).Col))
                expectedMoves.Add(Square.At(board.FindPiece(this).Row + 1, board.FindPiece(this).Col));

            if (board.FindPiece(this).Col - 1 >= 0 && !board.isSquareOccupiedByFriend(board.FindPiece(this).Row, board.FindPiece(this).Col - 1))
                expectedMoves.Add(Square.At(board.FindPiece(this).Row, board.FindPiece(this).Col - 1));

            if (board.FindPiece(this).Col + 1 <= 7 && !board.isSquareOccupiedByFriend(board.FindPiece(this).Row, board.FindPiece(this).Col + 1))
                expectedMoves.Add(Square.At(board.FindPiece(this).Row, board.FindPiece(this).Col + 1));

            if (board.FindPiece(this).Row + 1 <= 7 && board.FindPiece(this).Col - 1 >= 0 && !board.isSquareOccupiedByFriend(board.FindPiece(this).Row + 1, board.FindPiece(this).Col - 1))
                expectedMoves.Add(Square.At(board.FindPiece(this).Row + 1, board.FindPiece(this).Col - 1));

            if (board.FindPiece(this).Row + 1 <= 7 && board.FindPiece(this).Col + 1 <= 7 && !board.isSquareOccupiedByFriend(board.FindPiece(this).Row + 1, board.FindPiece(this).Col + 1))
                expectedMoves.Add(Square.At(board.FindPiece(this).Row + 1, board.FindPiece(this).Col + 1));

            return expectedMoves;
        }
    }
}