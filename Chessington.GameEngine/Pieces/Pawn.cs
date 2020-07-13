using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();
            Square square;
            if (Player == Player.White)
            {
                square = new Square(currentPosition.Row - 1, currentPosition.Col);
            }
            else
            {
                square = new Square(currentPosition.Row + 1, currentPosition.Col);
            }
            availableMoves.Add(square);
            return availableMoves;
        }
    }
}