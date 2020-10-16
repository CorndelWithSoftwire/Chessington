using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var oneMinusOne = new List<int>(new[] { 1, -1 });
            var twoMinusTwo = new List<int>(new[] { 2, -2 });

            // Make set of possible jumps: (+-2, +- 1) u (+-1, +-2)
            var eastWestJumps = oneMinusOne.SelectMany(
                x => twoMinusTwo,
                (northSouth, eastWest) => (northSouth, eastWest)
            );
            var northSouthJumps = twoMinusTwo.SelectMany(
                x => oneMinusOne,
                (northSouth, eastWest) => (northSouth, eastWest)
            );
            var jumps = northSouthJumps.Union(eastWestJumps);

            return ApplyMoves(jumps, board);
        }
    }
}