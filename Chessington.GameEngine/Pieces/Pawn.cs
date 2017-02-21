using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var location = board.FindPiece(this);
            var row = location.Row + (Player == Player.White ? -1 : 1);

            Square[] captureSquares = { Square.At(row, location.Col + 1), Square.At(row, location.Col - 1) };

            foreach (var captureSquare in captureSquares)
            {
                if (board.SquareIsOccupied(captureSquare) && board.GetPiece(captureSquare).Player != Player)
                {
                    yield return captureSquare;
                }
            }

            var nextSquare = Square.At(row, location.Col);
            if (!board.SquareIsAvailable(nextSquare))
            {
                yield break;
            }
            yield return nextSquare;

            if (HasMoved)
            {
                yield break;
            }

            var secondRow = location.Row + (Player == Player.White ? -2 : 2);
            var doubleMoveSquare = Square.At(secondRow, location.Col);

            if (!board.SquareIsAvailable(doubleMoveSquare))
            {
                yield break;
            }
            yield return doubleMoveSquare;
        }
    }
}