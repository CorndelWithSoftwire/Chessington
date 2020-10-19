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
            var playerDirection = this.Player == Player.White ? -1 : 1;
            for (int i = 1; i < 3; i++)
            {
                if (i == 2 && (HasMoved || !moves.Any()))
                {
                    break;
                }
                var potentialMove = Square.At(currentSquare.Row + playerDirection * i, currentSquare.Col);
                if (board.GetPiece(potentialMove) == null)
                {
                    moves.AddIfOnBoard(potentialMove);
                }
            }
            return moves;
        }
    }
}