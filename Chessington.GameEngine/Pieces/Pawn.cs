using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private bool FirstMove;

        public Pawn(Player player)
            : base(player)
        {
            FirstMove = false;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var position = board.FindPiece(this);
            var moves = new List<Square>();

            if (this.Player == Player.White && position.Row > 0 && 
                board.GetPiece(Square.At(position.Row - 1, position.Col)) == null)
            {
                moves.Add(Square.At(position.Row - 1, position.Col));

                if (!this.FirstMove && position.Row > 1 && 
                    board.GetPiece(Square.At(position.Row - 2, position.Col)) == null)
                {
                    moves.Add(Square.At(position.Row - 2, position.Col));
                }
            }
            else if (this.Player == Player.Black && position.Row < 7 &&
                     board.GetPiece(Square.At(position.Row + 1, position.Col)) == null)
            {
                moves.Add(Square.At(position.Row + 1, position.Col));

                if (!this.FirstMove && position.Row < 6 &&
                    board.GetPiece(Square.At(position.Row + 2, position.Col)) == null)
                {
                    moves.Add(Square.At(position.Row + 2, position.Col));
                }
            }

            return moves.AsEnumerable();
        }

        public override void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            this.FirstMove = true;
        }
    }
}