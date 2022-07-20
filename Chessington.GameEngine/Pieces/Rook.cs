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

            //check clear path for rook to the left
            for (var i = board.FindPiece(this).Col + 1; i < 8; i++) 
            {
                if (board.isSquareOccupiedByFriend(board.FindPiece(this).Row, i))
                    break;
                if (board.isSquareOccupiedByEnemy(board.FindPiece(this).Row, i))
                {
                    expectedMoves.Add(Square.At(board.FindPiece(this).Row, i));
                    break;
                }
                expectedMoves.Add(Square.At(board.FindPiece(this).Row, i));
            }

            //check clear path for rook to the right
            for (var i = board.FindPiece(this).Col - 1; i >= 0; i--) 
            {
                if (board.isSquareOccupiedByFriend(board.FindPiece(this).Row, i))
                    break;
                if (board.isSquareOccupiedByEnemy(board.FindPiece(this).Row, i))
                {
                    expectedMoves.Add(Square.At(board.FindPiece(this).Row, i));
                    break;
                }
                expectedMoves.Add(Square.At(board.FindPiece(this).Row, i));
            }

            //check clear path for rook to go down
            for (var i = board.FindPiece(this).Row + 1; i < 8; i++)
            {
                if (board.isSquareOccupiedByFriend(i, board.FindPiece(this).Col))
                    break;
                if (board.isSquareOccupiedByEnemy(i, board.FindPiece(this).Col))
                {
                    expectedMoves.Add(Square.At(i, board.FindPiece(this).Col));
                    break;
                }
                expectedMoves.Add(Square.At(i, board.FindPiece(this).Col));
            }

            //check clear path for rook to go down
            for (var i = board.FindPiece(this).Row - 1; i >= 0; i--)
            {
                if (board.isSquareOccupiedByFriend(i, board.FindPiece(this).Col))
                    break;
                if (board.isSquareOccupiedByEnemy(i, board.FindPiece(this).Col))
                {
                    expectedMoves.Add(Square.At(i, board.FindPiece(this).Col));
                    break;
                }
                expectedMoves.Add(Square.At(i, board.FindPiece(this).Col));
            }

            //Get rid of our starting location.
            expectedMoves.RemoveAll(s => s == Square.At(board.FindPiece(this).Row, board.FindPiece(this).Col));

            return expectedMoves;
        }
    }
}