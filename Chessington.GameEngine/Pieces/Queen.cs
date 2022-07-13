using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var position = board.FindPiece(this);
            var moves = new List<Square>();

            // --- lateral movement ---
            for (int i = 0; i < 8; ++i)
            {
                moves.Add(Square.At(position.Row, i));
                moves.Add(Square.At(i, position.Col));
            }

            // --- diagonal movement ---
            // up-left
            var pos = Square.At(position.Row - 1, position.Col - 1);
            while (pos.Row >= 0 && pos.Col >= 0)
            {
                moves.Add(pos);
                pos = Square.At(pos.Row - 1, pos.Col - 1);
            }

            // up-right
            pos = Square.At(position.Row - 1, position.Col + 1);
            while (pos.Row >= 0 && pos.Col <= 7)
            {
                moves.Add(pos);
                pos = Square.At(pos.Row - 1, pos.Col + 1);
            }

            // down-left
            pos = Square.At(position.Row + 1, position.Col - 1);
            while (pos.Row <= 7 && pos.Col >= 0)
            {
                moves.Add(pos);
                pos = Square.At(pos.Row + 1, pos.Col - 1);
            }

            // down-right
            pos = Square.At(position.Row + 1, position.Col + 1);
            while (pos.Row <= 7 && pos.Col <= 7)
            {
                moves.Add(pos);
                pos = Square.At(pos.Row + 1, pos.Col + 1);
            }

            moves.RemoveAll(x => x == Square.At(position.Row, position.Col));
            return moves.AsEnumerable();
        }
    }
}