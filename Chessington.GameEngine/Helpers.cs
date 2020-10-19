using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine
{
	public class Helpers
    {
        public List<Direction> AddMovesAndUpdateDirections(Board board, List<Direction> directions, Square currentSquare, int i, List<Square> moves, Player player)
        {
            var toRemove = new List<Direction>();
            foreach (var direction in directions)
            {
                var potentialMove = Square.At(currentSquare.Row + i * direction.RowOffset,
                    currentSquare.Col + i * direction.ColOffset);
                if (board.GetPiece(potentialMove) != null)
                {
                    toRemove.Add(direction);
                    if (board.GetPiece(potentialMove).Player != player)
                    {
                        moves.AddIfOnBoard(potentialMove);
                    }
                }
                else
                {
                    moves.AddIfOnBoard(potentialMove);
                }
            }

            return directions.Except(toRemove).ToList();
        }
    }
}

