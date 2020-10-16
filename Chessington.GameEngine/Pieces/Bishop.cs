using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            for (int i = 1; i < GameSettings.BoardSize; i++)
            {
                moves.AddIfOnBoard(new Square(currentSquare.Row + i, currentSquare.Col + i));
                moves.AddIfOnBoard(new Square(currentSquare.Row - i, currentSquare.Col + i));
                moves.AddIfOnBoard(new Square(currentSquare.Row + i, currentSquare.Col - i));
                moves.AddIfOnBoard(new Square(currentSquare.Row - i, currentSquare.Col - i));
            }

            return moves;
        }
    }
}