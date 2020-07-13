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
            if ((board.FindPiece(this).Row == 1 && Player == Player.Black) || (board.FindPiece(this).Row == GameSettings.BoardSize - 1 && Player == Player.White))
            {
                return new Square[]
                {
                    Square.At(Operation(board.FindPiece(this).Row, 1), board.FindPiece(this).Col),
                    Square.At(Operation(board.FindPiece(this).Row, 2), board.FindPiece(this).Col)
                };
            }
            else
            {
                return new Square[]
                {
                    Square.At(Operation(board.FindPiece(this).Row, 1), board.FindPiece(this).Col)
                };
            }
        }

        private int Operation(int number1, int number2)
        {
            return number1 + (Player == Player.Black ? 1 : -1) * number2;
        }
    }
}