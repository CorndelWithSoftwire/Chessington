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
            var moves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            moves.Add(this.Player == Player.White
                ? Square.At(currentSquare.Row - 1, currentSquare.Col)
                : Square.At(currentSquare.Row + 1, currentSquare.Col));
            if (!HasMoved)
            {
                moves.Add(this.Player == Player.White
                    ? Square.At(currentSquare.Row - 2, currentSquare.Col)
                    : Square.At(currentSquare.Row + 2, currentSquare.Col));
            }
            return moves;
        }
    }
}