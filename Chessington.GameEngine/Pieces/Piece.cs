using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
            previous_positions = new List<KeyValuePair<int, int>>();
            was_last_piece_moved = false;
        }

        public Player Player { get; private set; }
        public IList<KeyValuePair<int,int>> previous_positions { get; set; }
        public bool was_last_piece_moved { get; set; }
        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            if (previous_positions.Count != 0)
                previous_positions.Add(new KeyValuePair<int, int>(board.FindPiece(this).Row,
                    board.FindPiece(this).Col));
            else
                previous_positions.Add(new KeyValuePair<int, int>(board.FindPiece(this).Row, board.FindPiece(this).Col));
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }
    }
}