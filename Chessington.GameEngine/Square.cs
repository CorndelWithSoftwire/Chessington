using System.Linq;
using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine
{
    public struct Square
    {
        public readonly int Row;
        public readonly int Col;

        public Square(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public static Square At(int row, int col)
        {
            return new Square(row, col);
        }

        public bool Equals(Square other)
        {
            return Row == other.Row && Col == other.Col;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Square && Equals((Square)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Col;
            }
        }

        public static bool operator ==(Square left, Square right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Square left, Square right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return string.Format("Row {0}, Col {1}", Row, Col);
        }

        public bool IsInbound()
        {
            return Enumerable.Range(0, 8).Contains(this.Col) && Enumerable.Range(0, 8).Contains(this.Row);
        }

        public bool IsOccupied(Board board)
        {
            if (board.GetPiece(this) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CanMoveTo(Board board)
        {
            return this.IsInbound() && !this.IsOccupied(board);
        }

        public bool CanMoveOrTake(Board board, Piece piece)
        {
            return IsInbound() && (board.GetPiece(this) == null || board.GetPiece(this).Player != piece.Player);
        }
    }
}