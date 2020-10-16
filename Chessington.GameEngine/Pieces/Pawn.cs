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
            var location = board.FindPiece(this);
            var availableLocations = new List<Square>();

            if (Player == Player.Black)
            {
                availableLocations.Add(new Square(location.Row + 1, location.Col));
            }
            else
            {
                availableLocations.Add(new Square(location.Row - 1, location.Col));
            }
            return availableLocations;
        }
    }
}