using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.NetworkInformation;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var potentialMoves = new List<Square>()
            {
                Square.At(currentSquare.Row + 2, currentSquare.Col + 1),
                Square.At(currentSquare.Row + 2, currentSquare.Col - 1),
                Square.At(currentSquare.Row - 2, currentSquare.Col + 1),
                Square.At(currentSquare.Row - 2, currentSquare.Col - 1),
                Square.At(currentSquare.Row + 1, currentSquare.Col + 2),
                Square.At(currentSquare.Row + 1, currentSquare.Col - 2),
                Square.At(currentSquare.Row - 1, currentSquare.Col + 2),
                Square.At(currentSquare.Row - 1, currentSquare.Col - 2)
            };

            return CheckAndAddMoves(potentialMoves, board);
        }

        public List<Square> CheckAndAddMoves(List<Square> potentialMoves, Board board)
        {
            var moves = new List<Square>();
            foreach (var move in potentialMoves)
            {
                if (board.GetPiece(move) != null)
                {
                    if (board.GetPiece(move).Player != this.Player)
                    {
                        moves.AddIfOnBoard(move);
                    }
                }
                else
                {
                    moves.AddIfOnBoard(move);
                }
            }

            return moves;
        }
    }
}