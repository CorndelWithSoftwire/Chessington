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
            //determine color of player
            int pos;
            if (this.Player == Player.White)
                pos = -1;
            else pos = 1;

            //create new square at new position to later add to a list with available moves
            var new_square = Square.At(board.FindPiece(this).Row + pos, board.FindPiece(this).Col);
            var moves = new List<Square>();
            moves.Add((new_square));

            return moves;
            // return Enumerable.Empty<Square>();
        }
    }
}