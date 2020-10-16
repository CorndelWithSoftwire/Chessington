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
            var moveX = 2;
            var moveY = 1;
            moves.AddIfOnBoard(new Square(currentSquare.Row + moveX, currentSquare.Col + moveY));
            moves.AddIfOnBoard(new Square(currentSquare.Row + moveX, currentSquare.Col - moveY));
            moves.AddIfOnBoard(new Square(currentSquare.Row - moveX, currentSquare.Col + moveY));
            moves.AddIfOnBoard(new Square(currentSquare.Row - moveX, currentSquare.Col - moveY));
            moves.AddIfOnBoard(new Square(currentSquare.Row + moveY, currentSquare.Col + moveX));
            moves.AddIfOnBoard(new Square(currentSquare.Row + moveY, currentSquare.Col - moveX));
            moves.AddIfOnBoard(new Square(currentSquare.Row - moveY, currentSquare.Col + moveX));
            moves.AddIfOnBoard(new Square(currentSquare.Row - moveY, currentSquare.Col - moveX));

            return moves;
        }
    }
}