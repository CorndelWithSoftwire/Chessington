using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var location = board.FindPiece(this);

            // Produce a zipped set of diagonal directions (South West, South East, North West, North East)
            var diagonalDirections = new List<(int northSouth, int eastWest)>(new[] {(-1, -1), (-1, 1), (1, -1), (1, 1)});

            // Send diagonal lines out 8 squares in each diagonal direction
            var fullRangeOfMotion = diagonalDirections.Select(directions =>
                {
                    return Enumerable.Range(1, 7).Select(i => new Square(
                            location.Row + directions.northSouth * i,
                            location.Col + directions.eastWest * i)
                    );
                });

            // Flatten from four lists of lists of squares to one list
            var availableLocations = fullRangeOfMotion.SelectMany(x => x).ToList();

            // Remove squares not on the board
            availableLocations.RemoveAll(square =>
                square.Col < 0 || 7 < square.Col || square.Row < 0 || 7 < square.Row
            );

            return availableLocations;
        }
    }
}