using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var position = board.FindPiece(this);
            var moves = new List<Square>();

            // left
            var pos = Square.At(position.Row, position.Col - 1);
            while (pos.Col >= 0 && board.GetPiece(Square.At(pos.Row, pos.Col)) == null)
            {
                moves.Add(pos);
                pos = Square.At(pos.Row, pos.Col - 1);
            }

            if (pos.Col >= 0 && this.Player != board.GetPiece(Square.At(pos.Row, pos.Col)).Player)
            {
                moves.Add(pos);
            }

            // right
            pos = Square.At(position.Row, position.Col + 1);
            while (pos.Col <= 7 && board.GetPiece(Square.At(pos.Row, pos.Col)) == null)
            {
                moves.Add(pos);
                pos = Square.At(pos.Row, pos.Col + 1);
            }

            if (pos.Col <= 7 && this.Player != board.GetPiece(Square.At(pos.Row, pos.Col)).Player)
            {
                moves.Add(pos);
            }

            // up
            pos = Square.At(position.Row - 1, position.Col);
            while (pos.Row >= 0 && board.GetPiece(Square.At(pos.Row, pos.Col)) == null)
            {
                moves.Add(pos);
                pos = Square.At(pos.Row - 1, pos.Col);
            }

            if (pos.Row >= 0 && this.Player != board.GetPiece(Square.At(pos.Row, pos.Col)).Player)
            {
                moves.Add(pos);
            }

            // down
            pos = Square.At(position.Row + 1, position.Col);
            while (pos.Row <= 7 && board.GetPiece(Square.At(pos.Row, pos.Col)) == null)
            {
                moves.Add(pos);
                pos = Square.At(pos.Row + 1, pos.Col);
            }

            if (pos.Row <= 7 && this.Player != board.GetPiece(Square.At(pos.Row, pos.Col)).Player)
            {
                moves.Add(pos);
            }

            return moves.AsEnumerable();
        }
    }
}