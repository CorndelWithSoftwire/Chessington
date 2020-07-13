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
                    if (board.IsSquareEmpty(targetSquare))
                    {
                        availableMoves.Add(targetSquare);
                    }
                    else
                    {
                        Player piecePlayer = board.GetPiece(targetSquare).Player;
                        if (piecePlayer != currentPlayer)
                        {
                            availableMoves.Add(targetSquare);
                        }

                        break;
                    }
                }
            }
            foreach (var direction in directions)
            {
                var limit = direction == 1 ? GameSettings.BoardSize  - currentPosition.Row : currentPosition.Row +1;
                for (var index = 1; index <limit; index++)
                {
                    Square targetSquare = new Square(currentPosition.Row + index*direction, currentPosition.Col);
                    if (board.IsSquareEmpty(targetSquare))
                    {
                        availableMoves.Add(targetSquare);
                    }
                    else
                    {
                        Player piecePlayer = board.GetPiece(targetSquare).Player;
                        if (piecePlayer != currentPlayer)
                        {
                            availableMoves.Add(targetSquare);
                        }

                        break;
                    }
                }
            }
            return availableMoves;
        }

        public static IEnumerable<Square> GetDiagonalMoves(Board board, Square currentPosition)
        {
            List<Square> availableMoves = new List<Square>();

            for (var index = 1; index <= currentPosition.Col && index <= currentPosition.Row; index++)
            {
                availableMoves.Add(new Square(currentPosition.Row - index, currentPosition.Col - index));
            }

            for (var index = 1;
                index <= currentPosition.Col && index < GameSettings.BoardSize - currentPosition.Row;
                index++)
            {
                availableMoves.Add(new Square(currentPosition.Row + index, currentPosition.Col - index));
            }

            for (var index = 1;
                index < GameSettings.BoardSize - currentPosition.Col &&
                index < GameSettings.BoardSize - currentPosition.Row;
                index++)
            {
                availableMoves.Add(new Square(currentPosition.Row + index, currentPosition.Col + index));
            }

            for (var index = 1;
                index < GameSettings.BoardSize - currentPosition.Col && index <= currentPosition.Row;
                index++)
            {
                availableMoves.Add(new Square(currentPosition.Row - index, currentPosition.Col + index));
            }

            return availableMoves;
        }
    }
}