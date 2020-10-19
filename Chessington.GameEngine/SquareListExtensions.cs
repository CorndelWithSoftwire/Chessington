using System.Collections.Generic;

namespace Chessington.GameEngine
{
    public static class SquareListExtensions
    {
        public static void AddIfOnBoard(this List<Square> moves, Square square)
        {
            if (square.Col >= 0 && square.Col < GameSettings.BoardSize && square.Row >= 0 && square.Row < GameSettings.BoardSize)
            {
                moves.Add(square);
            }
        }
    }
}