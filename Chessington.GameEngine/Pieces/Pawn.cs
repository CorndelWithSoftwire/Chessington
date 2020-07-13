using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        
        public Pawn(Player player) 
            : base(player) { }

        public IEnumerable<Square> PawnMove(Board board, int direction, int startingRow)
        {
            var currentPos = board.FindPiece(this);
            var currentRow = currentPos.Row;
            var currentCol = currentPos.Col;

            if (Square.At(currentRow + direction, currentCol).CanMoveTo(board))
            {
                yield return Square.At(currentRow + direction, currentCol);

                if (currentRow == startingRow &&
                    Square.At(currentRow + 2 * direction, currentCol).CanMoveTo(board))
                {
                    yield return Square.At(currentRow + 2 * direction, currentCol);
                }
            }
        }

        public IEnumerable<Square> PawnTake(Board board, int direction)
        {
            var currentPos = board.FindPiece(this);
            var currentRow = currentPos.Row;
            var currentCol = currentPos.Col;

            var diagonallyRight = Square.At(currentRow + direction, currentCol + 1);
            var diagonallyLeft = Square.At(currentRow + direction, currentCol - 1);
            if (diagonallyRight.CanMoveOrTake(board, this) && diagonallyRight.IsOccupied(board))
            {
                yield return Square.At(currentRow + direction, currentCol + 1);
            }
            if (diagonallyLeft.CanMoveOrTake(board, this) && diagonallyLeft.IsOccupied(board))
            {
                yield return Square.At(currentRow + direction, currentCol - 1);
            }
        }
        
        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            if (Player == Player.White)
            {
                return PawnMove(board, -1, GameSettings.BoardSize - 2).Concat(PawnTake(board, -1));
            }
            else
            {
                return PawnMove(board, 1, 1).Concat(PawnTake(board, 1));
            }
        }
    }
}