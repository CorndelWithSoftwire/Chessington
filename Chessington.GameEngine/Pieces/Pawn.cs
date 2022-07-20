using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            //determine color of player
            int direction_to_move;
            if (this.Player == Player.White)
                direction_to_move = -1;
            else
                direction_to_move = 1;

            var moves = new List<Square>();


            if (board.FindPiece(this).Row + direction_to_move < 0 ||
                board.FindPiece(this).Row + direction_to_move > 7 || board.FindPiece(this).Col < 0 ||
                board.FindPiece(this).Col > 7)
                return moves;


            if (!board.isSquareOccupiedByFriend(board.FindPiece(this).Row + direction_to_move, board.FindPiece(this).Col) && !board.isSquareOccupiedByEnemy(board.FindPiece(this).Row + direction_to_move, board.FindPiece(this).Col))
            {
                moves.Add(Square.At(board.FindPiece(this).Row + direction_to_move, board.FindPiece(this).Col));

                if (this.previous_positions.Count == 0)
                {
                    if (board.FindPiece(this).Row + direction_to_move * 2 < 0 ||
                        board.FindPiece(this).Row + direction_to_move * 2 > 7 || board.FindPiece(this).Col < 0 ||
                        board.FindPiece(this).Col > 7)
                        return moves;
                    if (!board.isSquareOccupiedByFriend(board.FindPiece(this).Row + direction_to_move * 2,
                            board.FindPiece(this).Col) && !board.isSquareOccupiedByEnemy(board.FindPiece(this).Row + direction_to_move * 2,
                            board.FindPiece(this).Col))
                        moves.Add(Square.At(board.FindPiece(this).Row + direction_to_move * 2,
                            board.FindPiece(this).Col));
                }
            }

            //diagonally possible attack check
            if (board.FindPiece(this).Row + direction_to_move <= 7 && board.FindPiece(this).Row + direction_to_move >=0  && board.FindPiece(this).Col - 1 >=0)
                if (board.isSquareOccupiedByEnemy(board.FindPiece(this).Row + direction_to_move,
                        board.FindPiece(this).Col - 1))
                    moves.Add(Square.At(board.FindPiece(this).Row + direction_to_move, board.FindPiece(this).Col - 1));

            if (board.FindPiece(this).Row + direction_to_move <= 7 && board.FindPiece(this).Row + direction_to_move >= 0 && board.FindPiece(this).Col + 1 <= 7)
                if (board.isSquareOccupiedByEnemy(board.FindPiece(this).Row + direction_to_move,
                        board.FindPiece(this).Col + 1))
                    moves.Add(Square.At(board.FindPiece(this).Row + direction_to_move, board.FindPiece(this).Col + 1));

            //check if en passant move is possible to the left
            if (board.FindPiece(this).Col - 1 >= 0 &&
                board.isSquareOccupiedByEnemy(board.FindPiece(this).Row, board.FindPiece(this).Col - 1) &&
                board.isVulnerableToEnPessant(board.FindPiece(this).Row, board.FindPiece(this).Col - 1))
                moves.Add(Square.At(board.FindPiece(this).Row + direction_to_move, board.FindPiece(this).Col - 1));

            //check if en passant move is possible to the left
            if (board.FindPiece(this).Col + 1 <= 7 &&
                board.isSquareOccupiedByEnemy(board.FindPiece(this).Row, board.FindPiece(this).Col + 1) &&
                board.isVulnerableToEnPessant(board.FindPiece(this).Row, board.FindPiece(this).Col + 1))
                moves.Add(Square.At(board.FindPiece(this).Row + direction_to_move, board.FindPiece(this).Col + 1));

            return moves;

        }


    }
}