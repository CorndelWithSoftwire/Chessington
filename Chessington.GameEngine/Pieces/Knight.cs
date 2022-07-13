using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var position = board.FindPiece(this);
            var moves = new List<Square>();
            var moveRow = new List<int> { -2, -2, -1, 1, 2, 2, 1, -1 };
            var moveCol = new List<int> { -1, 1, 2, 2, 1, -1, -2, -2 };

            for (int i = 0; i < 8; ++i)
            {
                var pos = Square.At(position.Row + moveRow[i], position.Col + moveCol[i]);

                if (pos.Row >= 0 && pos.Row <= 7 && pos.Col >= 0 && pos.Row <= 7 && (board.GetPiece(pos) == null 
                        || board.GetPiece(pos) != null && this.Player != board.GetPiece(pos).Player))
                {
                    moves.Add(pos);
                }
            }

            return moves.AsEnumerable();
        }
    }
}