using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        protected IEnumerable<Square> GetAvailableLateralMoves(Board board)
        {
            var zeroes = Enumerable.Repeat(0, 15);
            var minusSevenToSeven = Enumerable.Range(-7, 15);

            var moves = zeroes.Zip(minusSevenToSeven, (x,y)=>(x,y));
            moves = moves.Union(minusSevenToSeven.Zip(zeroes, (x, y) => (x, y)));

            return ApplyMoves(moves, board);
        }

        protected IEnumerable<Square> GetAvailableDiagonalMoves(Board board)
        {
            // Produce a zipped set of diagonal directions (South West, South East, North West, North East)
            var diagonalDirections = new List<(int northSouth, int eastWest)>(new[] { (-1, -1), (-1, 1), (1, -1), (1, 1) });

            // Send diagonal lines out 8 squares in each diagonal direction
            var moves = diagonalDirections.Select(directions =>
            {
                return Enumerable.Range(1, 7).Select(i => (
                    directions.northSouth * i,
                    directions.eastWest * i)
                );
            });

            // Flatten from four lists of lists of squares to one list
            var movesFlattened = moves.SelectMany(x => x).ToList();

            return ApplyMoves(movesFlattened, board);
        }

        protected IEnumerable<Square> ApplyMoves(IEnumerable<(int northSouth, int eastWest)> moves, Board board)
        {
            var location = board.FindPiece(this);

            var availableLocations = moves.Select(directions =>
                new Square(
                    location.Row + directions.northSouth,
                    location.Col + directions.eastWest
                )
            );

            // Remove squares not on the board
            availableLocations = Piece.RemoveInvalidSquares(availableLocations);

            // Remove current location
            availableLocations = availableLocations.Where(square => square != location);

            return availableLocations;
        }

        protected static IEnumerable<Square> RemoveInvalidSquares(IEnumerable<Square> squares)
        {
            return squares.Where(square =>
                0 <= square.Col && square.Col <= 7 && 0 <= square.Row && square.Row <= 7
            );
        }
    }
}
