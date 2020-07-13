using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        
        
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();
            
            if (Player == Player.White)
            {
                if (!Square.At(currentPosition.Row - 1, currentPosition.Col).IsOccupied(board))
                {
                    availableMoves.Add(new Square(currentPosition.Row - 1, currentPosition.Col));

                    if (currentPosition.Row == 6 &&
                        !Square.At(currentPosition.Row - 2, currentPosition.Col).IsOccupied(board))
                    {
                        availableMoves.Add(new Square(currentPosition.Row - 2, currentPosition.Col));
                    }
                }
            }
            else
            {
                if (!Square.At(currentPosition.Row + 1, currentPosition.Col).IsOccupied(board))
                {
                    availableMoves.Add(new Square(currentPosition.Row + 1, currentPosition.Col));

                    if (currentPosition.Row == 1 &&
                        !Square.At(currentPosition.Row + 2, currentPosition.Col).IsOccupied(board))
                    {
                        availableMoves.Add(new Square(currentPosition.Row + 2, currentPosition.Col));
                    }
                }
            }
            return availableMoves;
        }
    }
}