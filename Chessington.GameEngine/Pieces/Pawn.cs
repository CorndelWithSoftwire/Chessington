using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player)
        {
            
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            return new Square[]
            {
                Square.At(Operation(board.FindPiece(this).Row,1), board.FindPiece(this).Col)
            };
        }

        private int Operation(int number1, int number2)
        {
            return number1 + (Player == Player.Black ? 1 : -1) * number2;
        }
    }
}