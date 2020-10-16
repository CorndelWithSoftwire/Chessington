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
            var moves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            var i = 1;
            moves.AddIfOnBoard(new Square(currentSquare.Row + i, currentSquare.Col + i));
            moves.AddIfOnBoard(new Square(currentSquare.Row - i, currentSquare.Col + i));
            moves.AddIfOnBoard(new Square(currentSquare.Row + i, currentSquare.Col - i));
            moves.AddIfOnBoard(new Square(currentSquare.Row - i, currentSquare.Col - i));
            moves.AddIfOnBoard(new Square(currentSquare.Row + i, currentSquare.Col));
            moves.AddIfOnBoard(new Square(currentSquare.Row - i, currentSquare.Col));
            moves.AddIfOnBoard(new Square(currentSquare.Row, currentSquare.Col + i));
            moves.AddIfOnBoard(new Square(currentSquare.Row, currentSquare.Col - i));

            return moves;
        }
    }
}