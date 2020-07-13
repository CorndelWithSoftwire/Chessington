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
            List<Square> availableMoves = new List<Square>();
            Square currentPosition = board.FindPiece(this);
            
            for(var index=1;index<=currentPosition.Col && index<=currentPosition.Row;index ++)
            {
                availableMoves.Add(new Square(currentPosition.Row-index, currentPosition.Col-index));
            }
            for (var index=1;index<=currentPosition.Col && index<8-currentPosition.Row;index ++)
            {
                availableMoves.Add(new Square(currentPosition.Row+index, currentPosition.Col-index));
            }
            for (var index=1;index<8-currentPosition.Col && index<8-currentPosition.Row;index ++)
            {
                availableMoves.Add(new Square(currentPosition.Row+index, currentPosition.Col+index));
            }
            for (var index=1;index<8-currentPosition.Col && index<=currentPosition.Row; index++)
            {
                availableMoves.Add(new Square(currentPosition.Row - index, currentPosition.Col + index));
            }
            return availableMoves;
        }
    }
}