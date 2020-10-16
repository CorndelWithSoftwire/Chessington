using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private bool hasMoved = false;

        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var location = board.FindPiece(this);
            var availableLocations = new List<Square>();

            var direction = Player == Player.Black ? 1 : -1;

            // Normal advancing
            availableLocations.Add(new Square(location.Row + direction*1, location.Col));

            // Two places on first move
            if (!hasMoved)
            {
                availableLocations.Add(new Square(location.Row + direction * 2, location.Col));
            }

            return availableLocations;
        }

        public new void MoveTo(Board board, Square newSquare)
        {
            base.MoveTo(board, newSquare);
            hasMoved = true;
        }
    }
}