using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            List<Square> available = new List<Square>();
            Square here = board.FindPiece(this);
            if (Player == Player.White) {
                if (here.Row != 0) {
                    available.Add(new Square(here.Row - 1, here.Col ));
                }
                if (here.Row == 6) {
                    available.Add(new Square(4, here.Col ));
                }
            } else {
                if (here.Row != 7) {
                    available.Add(new Square(here.Row + 1, here.Col));
                }
                if (here.Row == 1) {
                    available.Add(new Square(3, here.Col ));
                }
            }
            return available;
        }
    }
}