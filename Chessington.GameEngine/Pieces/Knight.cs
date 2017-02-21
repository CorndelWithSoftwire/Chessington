using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);

            var targetSquares = GetKnightsMoveSquares(currentSquare);
            return targetSquares.Where(square => board.SquareIsAvailable(square)
               || (board.SquareIsOccupied(square) && board.GetPiece(square).Player != Player));
        }

        public IEnumerable<Square> GetKnightsMoveSquares(Square currentSquare)
        {
            var row = currentSquare.Row;
            var column = currentSquare.Col;
            yield return Square.At(row + 2, column + 1);
            yield return Square.At(row + 2, column - 1);
            yield return Square.At(row + 1, column + 2);
            yield return Square.At(row + 1, column - 2);
            yield return Square.At(row - 1, column + 2);
            yield return Square.At(row - 1, column - 2);
            yield return Square.At(row - 2, column + 1);
            yield return Square.At(row - 2, column - 1);
        }
    }
}