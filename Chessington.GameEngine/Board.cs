using System;
using System.Collections.Generic;
using System.Linq;
using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine
{
    public class Board
    {
        private readonly Piece[,] board;
        public Player CurrentPlayer { get; private set; }
        public IList<Piece> CapturedPieces { get; private set; }
        public Board()
            : this(Player.White) { }

        public Board(Player currentPlayer, Piece[,] boardState = null)
        {
            board = boardState ?? new Piece[GameSettings.BoardSize, GameSettings.BoardSize]; 
            CurrentPlayer = currentPlayer;
            CapturedPieces = new List<Piece>();
        }

        public bool isSquareOccupiedByFriend(int row, int col)
        {
            if(row <=7 && row >=0 && col >=0 && col <=7)//make sure we don't get array out of bounds
                if (board[row, col] != null && board[row, col].Player == CurrentPlayer)
                    return true;

            return false;
        }

        public bool isSquareOccupiedByEnemy(int row, int col)
        {
            if (row <= 7 && row >= 0 && col >= 0 && col <= 7)//make sure we don't get array out of bounds
                if (board[row, col] != null && board[row, col].Player != CurrentPlayer)
                    return true;

            return false;
        }

        public void AddPiece(Square square, Piece pawn)
        {
            board[square.Row, square.Col] = pawn;
        }
    
        public Piece GetPiece(Square square)
        {
            return board[square.Row, square.Col];
        }
        
        public Square FindPiece(Piece piece)
        {
            for (var row = 0; row < GameSettings.BoardSize; row++)
                for (var col = 0; col < GameSettings.BoardSize; col++)
                    if (board[row, col] == piece)
                        return Square.At(row, col);

            throw new ArgumentException("The supplied piece is not on the board.", "piece");
        }

        public void MovePiece(Square from, Square to)
        {
            var movingPiece = board[from.Row, from.Col];
            if (movingPiece == null) { return; }

            if (movingPiece.Player != CurrentPlayer)
            {
                throw new ArgumentException("The supplied piece does not belong to the current player.");
            }

            //If the space we're moving to is occupied, we need to mark it as captured.
            if (board[to.Row, to.Col] != null)
            {
                OnPieceCaptured(board[to.Row, to.Col]);
            }
            //check for en passant capture
            else if (movingPiece.GetType() == typeof(Chessington.GameEngine.Pieces.Pawn))
            {
                if (movingPiece.Player == Player.White)
                {
                    if (to.Row + 1 <= 7)
                    {
                        if (board[to.Row + 1, to.Col] != null && board[to.Row + 1, to.Col].was_last_piece_moved)
                        {
                            board[to.Row, to.Col] = board[to.Row + 1, to.Col];
                            board[to.Row + 1, to.Col] = null;
                            OnPieceCaptured(board[to.Row, to.Col]);
                        }
                    }
                }
                else
                {
                    if (to.Row - 1 >= 0)
                    {
                        if (board[to.Row - 1, to.Col] != null && board[to.Row - 1, to.Col].was_last_piece_moved)
                        {
                            board[to.Row, to.Col] = board[to.Row - 1, to.Col];
                            board[to.Row - 1, to.Col] = null;
                            OnPieceCaptured(board[to.Row, to.Col]);
                        }
                    }
                }
            }

            //Move the piece and set the 'from' square to be empty.
            board[to.Row, to.Col] = board[from.Row, from.Col];
            board[from.Row, from.Col] = null;

            CurrentPlayer = movingPiece.Player == Player.White ? Player.Black : Player.White;
            OnCurrentPlayerChanged(CurrentPlayer);

            //mark the last piece moved
            for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                if (board[i, j] != null)
                    board[i, j].was_last_piece_moved = false;
            board[to.Row, to.Col].was_last_piece_moved = true;
        }
        
        public delegate void PieceCapturedEventHandler(Piece piece);
        
        public event PieceCapturedEventHandler PieceCaptured;

        protected virtual void OnPieceCaptured(Piece piece)
        {
            var handler = PieceCaptured;
            if (handler != null) handler(piece);
        }

        public delegate void CurrentPlayerChangedEventHandler(Player player);

        public event CurrentPlayerChangedEventHandler CurrentPlayerChanged;

        protected virtual void OnCurrentPlayerChanged(Player player)
        {
            var handler = CurrentPlayerChanged;
            if (handler != null) handler(player);
        }

        public bool isVulnerableToEnPessant(int row, int col)
        {
            var player_checked = board[row, col];
            if (player_checked.GetType() != typeof(Chessington.GameEngine.Pieces.Pawn))
                return false;
            if (player_checked.previous_positions.Count < 1)
                return false;
            if (player_checked.previous_positions.Count == 1)
            {
                if (Math.Abs(row - player_checked.previous_positions[player_checked.previous_positions.Count - 1]
                        .Key) == 2 && player_checked.was_last_piece_moved)
                    return true;
            }
            else if (Math.Abs(player_checked.previous_positions[player_checked.previous_positions.Count - 1].Key -
                              player_checked.previous_positions[player_checked.previous_positions.Count - 2].Key) == 2 && player_checked.was_last_piece_moved)
                return true;
            return false;
        }
    }
}
