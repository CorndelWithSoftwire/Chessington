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

            //diagonally check
            int current_col_pos = board.FindPiece(this).Col;
            int current_row_pos = board.FindPiece(this).Row;

            //check from current to top left corner : (can't use do while loop => need a check for first one too)
            current_row_pos -= 1;
            current_col_pos -= 1;
            while (current_row_pos >= 0 && current_col_pos >= 0)
            {
                if (board.isSquareOccupiedByFriend(current_row_pos, current_col_pos))
                    break;
                if (board.isSquareOccupiedByEnemy(current_row_pos, current_col_pos))
                {
                    expectedMoves.Add(Square.At(current_row_pos, current_col_pos));
                    break;
                }
                expectedMoves.Add(Square.At(current_row_pos, current_col_pos));
                current_row_pos -= 1;
                current_col_pos -= 1;
            }

            //check from current to top right corner
            current_col_pos = board.FindPiece(this).Col;
            current_row_pos = board.FindPiece(this).Row;
            current_row_pos -= 1;
            current_col_pos += 1;
            while (current_row_pos >= 0 && current_col_pos <= 7)
            {
                if (board.isSquareOccupiedByFriend(current_row_pos, current_col_pos))
                    break;
                if (board.isSquareOccupiedByEnemy(current_row_pos, current_col_pos))
                {
                    expectedMoves.Add(Square.At(current_row_pos, current_col_pos));
                    break;
                }
                expectedMoves.Add(Square.At(current_row_pos, current_col_pos));
                current_row_pos -= 1;
                current_col_pos += 1;
            }

            //check from current to low left corner
            current_col_pos = board.FindPiece(this).Col;
            current_row_pos = board.FindPiece(this).Row;
            current_row_pos += 1;
            current_col_pos -= 1;
            while (current_row_pos <= 7 && current_col_pos >= 0)
            {
                if (board.isSquareOccupiedByFriend(current_row_pos, current_col_pos))
                    break;
                if (board.isSquareOccupiedByEnemy(current_row_pos, current_col_pos))
                {
                    expectedMoves.Add(Square.At(current_row_pos, current_col_pos));
                    break;
                }
                expectedMoves.Add(Square.At(current_row_pos, current_col_pos));
                current_row_pos += 1;
                current_col_pos -= 1;
            }

            //check from current to low right corner
            current_col_pos = board.FindPiece(this).Col;
            current_row_pos = board.FindPiece(this).Row;
            current_row_pos += 1;
            current_col_pos += 1;
            while (current_row_pos >= 0 && current_col_pos <= 7)
            {
                if (board.isSquareOccupiedByFriend(current_row_pos, current_col_pos))
                    break;
                if (board.isSquareOccupiedByEnemy(current_row_pos, current_col_pos))
                {
                    expectedMoves.Add(Square.At(current_row_pos, current_col_pos));
                    break;
                }
                expectedMoves.Add(Square.At(current_row_pos, current_col_pos));
                current_row_pos += 1;
                current_col_pos += 1;
            }

            expectedMoves.RemoveAll(s => s == Square.At(board.FindPiece(this).Row, board.FindPiece(this).Col));

            return expectedMoves;
        }
    }
}