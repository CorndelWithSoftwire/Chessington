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
            List<Square> availableMoves = new List<Square>();
            var currentPosition = board.FindPiece(this);

            for (int x = -1; x < 2; x++) {
                for (int y = -1; y < 2; y++) {
                    if (x != 0 || y != 0) {
                        var moveTo = new Square(currentPosition.Row + x, currentPosition.Col + y);
                        if (moveTo.isValid()) {
                            availableMoves.Add(moveTo);
                        }
                    }
                }
            }

            return availableMoves;
        }
    }
}