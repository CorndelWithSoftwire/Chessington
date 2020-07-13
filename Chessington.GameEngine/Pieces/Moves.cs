using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Moves
    {
        public static IEnumerable<Square> GetLateralMoves(Board board, Square currentPosition,Player currentPlayer)
        {
            List<Square> availableMoves = new List<Square>();
            var directions = new int[] {-1, 1};
            foreach (var direction in directions)
            {
                var limit = direction == 1 ? GameSettings.BoardSize - currentPosition.Col : currentPosition.Col + 1;
                for (var index = 1; index < limit; index++)
                {
                    Square targetSquare = new Square(currentPosition.Row, currentPosition.Col + index*direction);
                    if (board.IsEmptyOrOpponent(targetSquare, currentPlayer)) availableMoves.Add(targetSquare);
                    if (!board.IsSquareEmpty(targetSquare)) break;
                }
            }
            foreach (var direction in directions)
            {
                var limit = direction == 1 ? GameSettings.BoardSize  - currentPosition.Row : currentPosition.Row +1;
                for (var index = 1; index <limit; index++)
                {
                    Square targetSquare = new Square(currentPosition.Row + index*direction, currentPosition.Col);
                    if (board.IsEmptyOrOpponent(targetSquare, currentPlayer)) availableMoves.Add(targetSquare);
                    if (!board.IsSquareEmpty(targetSquare)) break;
                }
            }
            return availableMoves;
        }

        public static IEnumerable<Square> GetDiagonalMoves(Board board, Square currentPosition, Player currentPlayer)
        {
            List<Square> availableMoves = new List<Square>();
            var directions = new int[] {-1, 1};
            foreach (var direction in directions)
            {
                var limit = direction == 1 ? 
                    Math.Min(GameSettings.BoardSize - currentPosition.Col, GameSettings.BoardSize - currentPosition.Row)
                    : Math.Min(currentPosition.Col, currentPosition.Row) + 1;
                for (var index = 1; index < limit; index++)
                {
                    Square targetSquare = new Square(currentPosition.Row + index*direction, 
                        currentPosition.Col + index*direction);
                    if (board.IsEmptyOrOpponent(targetSquare, currentPlayer)) availableMoves.Add(targetSquare);
                    if (!board.IsSquareEmpty(targetSquare)) break;
                }
            }
            foreach (var direction in directions)
            {
                var limit = direction == 1 ? 
                    Math.Min(GameSettings.BoardSize - currentPosition.Col, currentPosition.Row + 1) 
                    : Math.Min(currentPosition.Col + 1, GameSettings.BoardSize - currentPosition.Row);
                for (var index = 1; index < limit; index++)
                {
                    Square targetSquare = new Square(currentPosition.Row - index*direction, 
                        currentPosition.Col + index*direction);
                    if (board.IsEmptyOrOpponent(targetSquare, currentPlayer)) availableMoves.Add(targetSquare);
                    if (!board.IsSquareEmpty(targetSquare)) break;
                }
            }
            return availableMoves;
        }
    }
}