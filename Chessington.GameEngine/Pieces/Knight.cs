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
            var moves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            moves.AddIfOnBoard(Square.At(currentSquare.Row + 2, currentSquare.Col + 1));
            moves.AddIfOnBoard(Square.At(currentSquare.Row + 2, currentSquare.Col - 1));
            moves.AddIfOnBoard(Square.At(currentSquare.Row - 2, currentSquare.Col + 1));
            moves.AddIfOnBoard(Square.At(currentSquare.Row - 2, currentSquare.Col - 1));
            moves.AddIfOnBoard(Square.At(currentSquare.Row + 1, currentSquare.Col + 2));
            moves.AddIfOnBoard(Square.At(currentSquare.Row + 1, currentSquare.Col - 2));
            moves.AddIfOnBoard(Square.At(currentSquare.Row - 1, currentSquare.Col + 2));
            moves.AddIfOnBoard(Square.At(currentSquare.Row - 1, currentSquare.Col - 2));

            return moves;
        }
    }
}