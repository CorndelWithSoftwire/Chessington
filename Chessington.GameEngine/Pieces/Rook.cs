using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> availableMoves = new List<Square>();
            Square here = board.FindPiece(this);
            foreach (var index in Enumerable.Range(0,8))
            {
                if (here.Col != index)
                {
                    availableMoves.Add(new Square(here.Row, index));
                }

                if (here.Row != index)
                {
                    availableMoves.Add(new Square(index,here.Col));
                }
            }
            return availableMoves;
        }
    }
}