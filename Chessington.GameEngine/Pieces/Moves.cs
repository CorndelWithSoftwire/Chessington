using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces {
    public class Moves {
        public static IEnumerable<Square> GetLateralMoves(Board board, Square currentPosition)
        {
            List<Square> availableMoves = new List<Square>();
            foreach (var index in Enumerable.Range(0,GameSettings.BoardSize))
            {
                if (currentPosition.Col != index)
                {
                    availableMoves.Add(new Square(currentPosition.Row, index));
                }

                if (currentPosition.Row != index)
                {
                    availableMoves.Add(new Square(index,currentPosition.Col));
                }
            }
            return availableMoves;
        }
        
        public static IEnumerable<Square> GetDiagonalMoves(Board board, Square currentPosition)
        {
            List<Square> availableMoves = new List<Square>();
            
            for(var index=1;index<=currentPosition.Col && index<=currentPosition.Row;index ++)
            {
                availableMoves.Add(new Square(currentPosition.Row-index, currentPosition.Col-index));
            }
            for (var index=1;index<=currentPosition.Col && index<GameSettings.BoardSize-currentPosition.Row;index ++)
            {
                availableMoves.Add(new Square(currentPosition.Row+index, currentPosition.Col-index));
            }
            for (var index=1;
                index<GameSettings.BoardSize-currentPosition.Col && index<GameSettings.BoardSize-currentPosition.Row;
                index ++)
            {
                availableMoves.Add(new Square(currentPosition.Row+index, currentPosition.Col+index));
            }
            for (var index=1;index<GameSettings.BoardSize-currentPosition.Col && index<=currentPosition.Row; index++)
            {
                availableMoves.Add(new Square(currentPosition.Row - index, currentPosition.Col + index));
            }
            return availableMoves;
        }
    }
}