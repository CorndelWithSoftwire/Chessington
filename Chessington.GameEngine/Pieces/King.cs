using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var position = board.FindPiece(this);
            var moves = new List<Square>();
            var moveRow = new List<int> { -1, -1, 0, 1, 1, 1, 0, -1 };
            var moveCol = new List<int> { 0, 1, 1, 1, 0, -1, -1, -1 };

            for (int i = 0; i < 8; ++i)
            {
                moves.Add(Square.At(position.Row + moveRow[i], position.Col + moveCol[i]));
            }

            moves.RemoveAll(x => x.Row < 0 || x.Row > 7 || x.Col < 0 || x.Row > 7);
            return moves.AsEnumerable();
        }
    }
}