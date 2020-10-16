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
            var location = board.FindPiece(this);
            var availableLocations = new List<Square>();

            availableLocations.AddRange(
                Enumerable.Range(0, 8)
                .Select(i => new Square(location.Row, i))
            );

            availableLocations.AddRange(
                Enumerable.Range(0, 8)
                .Select(i => new Square(i, location.Col))
            );

            // Remove this location from the list
            availableLocations.RemoveAll(location.Equals);

            return availableLocations;
        }
    }
}