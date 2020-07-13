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
            Square here = board.FindPiece(this);
            foreach (var index in Enumerable.Range(1,7))
            {
                if (index<=here.Col && index<=here.Row)
                {
                    availableMoves.Add(new Square(here.Row-index, here.Col-index));
                }
                if (index<=here.Col && index<8-here.Row)
                {
                    availableMoves.Add(new Square(here.Row+index, here.Col-index));
                }
                if (index<8-here.Col && index<8-here.Row)
                {
                    availableMoves.Add(new Square(here.Row+index, here.Col+index));
                }
                if (index<8-here.Col && index<=here.Row)
                {
                    availableMoves.Add(new Square(here.Row-index, here.Col+index));
                }
            }
            return availableMoves;
        }
    }
}