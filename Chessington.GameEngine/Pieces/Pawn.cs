using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private bool firstMove;
        private int ranksMoved;

        public Pawn(Player player)
            : base(player)
        {
            firstMove = false;
            ranksMoved = 0;
        }

        public bool GetFirstMove()
        {
            return firstMove;
        }

        public int GetRanksMoved()
        {
            return ranksMoved;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var position = board.FindPiece(this);
            var moves = new List<Square>();

            if (this.Player == Player.White && position.Row > 0)
            {
                // can move up 1 square
                if (board.GetPiece(Square.At(position.Row - 1, position.Col)) == null)
                {
                    moves.Add(Square.At(position.Row - 1, position.Col));

                    // can move up 2 squares
                    if (!this.firstMove && position.Row > 1 &&
                        board.GetPiece(Square.At(position.Row - 2, position.Col)) == null)
                    {
                        moves.Add(Square.At(position.Row - 2, position.Col));
                    }
                }

                // can move left diagonally
                if (position.Col > 0 && board.GetPiece(Square.At(position.Row - 1, position.Col - 1)) != null
                                     && board.GetPiece(Square.At(position.Row - 1, position.Col - 1)).Player ==
                                     Player.Black)
                {
                    moves.Add(Square.At(position.Row - 1, position.Col - 1));
                }

                // can move right diagonally
                if (position.Col < 7 && board.GetPiece(Square.At(position.Row - 1, position.Col + 1)) != null
                                     && board.GetPiece(Square.At(position.Row - 1, position.Col + 1)).Player ==
                                     Player.Black)
                {
                    moves.Add(Square.At(position.Row - 1, position.Col + 1));
                }

                // en passant
                if (this.ranksMoved == 3) // the capturing pawn must have advanced exactly 3 ranks to perform the move
                {
                    // left case
                    var targetPiece = board.GetPiece(Square.At(position.Row, position.Col - 1));

                    // the target piece must be a pawn landed right next to the capturing pawn
                    if (targetPiece != null && targetPiece is Pawn)
                    {
                        var targetPawn = (Pawn)targetPiece;

                        // the target pawn must have moved 2 squares in 1 move
                        // the en passant capture must be performed on the turn immediately after the pawn being captured moves
                        if (targetPawn.GetMovesCount() == 1 && targetPawn.GetFirstMove() && board.GetLastMoved() == targetPawn)
                        {
                            // we move the target pawn to the same position
                            board.MovePiece(Square.At(position.Row, position.Col - 1),
                                Square.At(position.Row - 1, position.Col - 1), true);
                            moves.Add(Square.At(position.Row - 1, position.Col - 1));
                        }
                    }

                    // right case
                    targetPiece = board.GetPiece(Square.At(position.Row, position.Col + 1));

                    if (targetPiece != null && targetPiece is Pawn)
                    {
                        var targetPawn = (Pawn)targetPiece;

                        if (targetPawn.GetMovesCount() == 1 && targetPawn.GetFirstMove() && board.GetLastMoved() == targetPawn)
                        {
                            board.MovePiece(Square.At(position.Row, position.Col + 1),
                                Square.At(position.Row - 1, position.Col + 1), true);
                            moves.Add(Square.At(position.Row - 1, position.Col + 1));
                        }
                    }
                }
            }
            else if (this.Player == Player.Black && position.Row < 7) 
            {
                // can move down 1 square
                if (board.GetPiece(Square.At(position.Row + 1, position.Col)) == null)
                {
                    moves.Add(Square.At(position.Row + 1, position.Col));

                    // can move down 2 squares
                    if (!this.firstMove && position.Row < 6 &&
                        board.GetPiece(Square.At(position.Row + 2, position.Col)) == null)
                    {
                        moves.Add(Square.At(position.Row + 2, position.Col));
                    }
                }

                // can move right diagonally
                if (position.Col < 7 && board.GetPiece(Square.At(position.Row + 1, position.Col + 1)) != null
                                     && board.GetPiece(Square.At(position.Row + 1, position.Col + 1)).Player ==
                                     Player.White)
                {
                    moves.Add(Square.At(position.Row + 1, position.Col + 1));
                }

                // can move left diagonally
                if (position.Col > 0 && board.GetPiece(Square.At(position.Row + 1, position.Col - 1)) != null
                                     && board.GetPiece(Square.At(position.Row + 1, position.Col - 1)).Player ==
                                     Player.White)
                {
                    moves.Add(Square.At(position.Row + 1, position.Col - 1));
                }

                // en passant
                if (this.ranksMoved == 3)
                {
                    // left case
                    var targetPiece = board.GetPiece(Square.At(position.Row, position.Col - 1));

                    if (targetPiece != null && targetPiece is Pawn)
                    {
                        var targetPawn = (Pawn)targetPiece;

                        if (targetPawn.GetMovesCount() == 1 && targetPawn.GetFirstMove() && board.GetLastMoved() == targetPawn)
                        {
                            board.MovePiece(Square.At(position.Row, position.Col - 1),
                                Square.At(position.Row + 1, position.Col - 1), true);
                            moves.Add(Square.At(position.Row + 1, position.Col - 1));
                        }
                    }

                    // right case
                    targetPiece = board.GetPiece(Square.At(position.Row, position.Col + 1));

                    if (targetPiece != null && targetPiece is Pawn)
                    {
                        var targetPawn = (Pawn)targetPiece;

                        if (targetPawn.GetMovesCount() == 1 && targetPawn.GetFirstMove() && board.GetLastMoved() == targetPawn)
                        {
                            board.MovePiece(Square.At(position.Row, position.Col + 1),
                                Square.At(position.Row + 1, position.Col + 1), true);
                            moves.Add(Square.At(position.Row + 1, position.Col + 1));
                        }
                    }
                }
            }

            return moves.AsEnumerable();
        }

        public override void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);

            this.MovesCount++;
            this.firstMove = true;
            this.ranksMoved += Math.Max(Math.Abs(currentSquare.Row - newSquare.Row), Math.Abs(currentSquare.Col - newSquare.Col));

            // pawn promotion
            if (newSquare.Row == 0 && this.Player == Player.White || newSquare.Row == 7 && this.Player == Player.Black)
            {
                board.RemovePiece(newSquare);
                board.AddPiece(newSquare, new Queen(this.Player));
            }
        }
    }
}